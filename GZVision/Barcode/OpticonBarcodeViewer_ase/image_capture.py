"""Opticon MDI-4x00 / N210 CCD image capture over the serial interface.

Protocol references (provided by the customer in
``D:\\GZVision Files\\Important Files\\Barcode``):

- Opticon "MDI-4x00 / N210 Image Capture Manual" (2nd edition, 2022-11-23)
- Opticon reference sample ``scanner_pic`` (C# ImageCapture, VS2008), whose
  framing, checksum and ACK/NAK handling are proven against real hardware.

After a successful barcode decode the engine is still in decode mode.  To grab
an image *for* that scan a separate command exchange switches the engine into
image-capture mode and takes one exposure:

    DE7 <params>   set image-processing settings (six Q0..Q9 values each)
    DE8 Q0         image capture, mode m=0 ("commands in conjunction": the
                   picture is taken immediately, no trigger press needed)

As in the manual's command examples, all DE7 settings are combined into one
conjunction frame (several ``[DE7...`` segments, a single terminating <CR>)
followed by the separate capture frame ``<ESC>[DE8Q0<CR>``:

    crop left/top/right/bottom = 0/0/639/479   (full default frame)
    subsampling horizontal/vertical = 1/1
    bit depth = 8 bits per pixel
    JPEG quality = 75
    output format = JPEG      (DE7 Q5 ... Q1)
    transmission mode = ALL   (DE7 Q6 ... Q1)

An engine that does not accept one of these settings simply keeps its current
configuration (firmware default is BMP output with PART transmission).  The
receiver below therefore understands *both* transfer modes:

    ALL  one packet  : Start recNo=0 Length  Information(256) + whole image
    PART packet 0    : Start recNo=0 Length=256  Information
         packet n    : Start recNo=n Length   one image line / chunk

Packet frame (multi-byte fields are big-endian, as implemented by the
reference sample):

    Start(0x21 '!')  recNo(2)  Length(4)  payload(Length)  Checksum(2)  End(0x0D)

The checksum is the 16-bit sum of the payload bytes weighted by (index + 1),
stored high byte first.  The host must ACK (0x06) every good packet and NAK
(0x15) bad ones; the engine resends a NAKed packet (stop-and-wait per record).

The 256-byte Information field carries width/height/bits-per-pixel/file
format/image size/total transfer count; the receiver uses it to decide when a
PART transfer is complete.  BMP payload (raw, header-less pixel data, "the
bitmap header is omitted" per the manual) is converted to JPEG, so callers
always receive JPEG bytes ready for storage.

The module is fully defensive: any serial/protocol/timing problem returns
``None`` (or emits a failure) instead of raising, so a failed picture never
invalidates the barcode scan itself.
"""

from __future__ import annotations

import time
from dataclasses import dataclass
from typing import NamedTuple, Optional

import serial  # type: ignore

import app_config
from PySide6.QtCore import (
    QBuffer,
    QIODevice,
    QThread,
    Signal,
)
from PySide6.QtGui import QImage

# ---- Wire-level constants -------------------------------------------------

_ESC = b"\x1b"
_CR = b"\x0d"
_ACK = b"\x06"
_NAK = b"\x15"
_CAN = b"\x18"  # host -> engine: stop transmission
_START = 0x21   # '!'
_END = 0x0D     # <CR>
_INFO_HEADER_LEN = 256  # fixed "Information" header preceding the image data

# Serial timing constants.
_RX_CHUNK_TIMEOUT = 0.2   # seconds per blocking serial read()
_CONFIG_SETTLE_S = 0.25   # settle time after the DE7 frame (as reference sample)
_SILENCE_FLOOR_S = 4.0    # abort when the engine stays silent this long
_MAX_TRANSFER_S = 90.0    # absolute safety cap for one image transfer
_MAX_NAKS = 12            # give up after too many corrupted packets

# Frame sanity guards.
_MAX_PAYLOAD_BYTES = 8 * 1024 * 1024
# Raw sensor bounds used as parse sanity limits. MDI-4x00/N210: 752x480,
# MDI-5250/5350: up to 1280x800 (decode-area range per serial manual §8.10).
_MAX_SENSOR_WIDTH = 1280
_MAX_SENSOR_HEIGHT = 800

# Default capture geometry.  The **full sensor** is captured by default so the
# saved scan picture shows the whole field of view — the previous 640x480 crop
# captured only the top-left quarter on MDI-5250/5350 engines (1280x800
# sensor).  Everything is overridable via app_config.json:
#   image_capture_width / image_capture_height  -> crop size in pixels
#   image_capture_subsample (1, 2, 4)           -> trades resolution for time
#   image_capture_jpeg_quality (5..100)         -> JPEG quality
# MDI-4x00/N210 engines (752x480 sensor) should configure 752/480.
_DEFAULT_CAPTURE_WIDTH = 1280
_DEFAULT_CAPTURE_HEIGHT = 800
_DEFAULT_SUBSAMPLE = 1
_DEFAULT_JPEG_QUALITY = 75


# ---- Command building -----------------------------------------------------


def _cmd(text: str) -> bytes:
    """Wrap a command string as ``<ESC>[<text><CR>`` (Opticon command frame)."""
    return _ESC + b"[" + text.encode("ascii", errors="replace") + _CR


def _de7_param_text(item_group: str, item: str, value: int) -> str:
    """Build one DE7 parameter segment with a 4-digit numeric value.

    Example: ``_de7_param_text("DE7Q1", "Q2", 1279)`` -> ``DE7Q1Q2Q1Q2Q7Q9``
    (crop right = 1279).
    """
    digits = f"{max(0, min(int(value), 9999)):04d}"
    # ``item`` already starts with ``Q`` (e.g. ``Q2``), so do NOT add another
    # one here - ``DE7Q1Q2Q1Q2Q7Q9`` is the manual's segment format.
    return (
        f"{item_group}{item}"
        f"Q{digits[0]}Q{digits[1]}Q{digits[2]}Q{digits[3]}"
    )


def _resolve_geometry(width, height, subsample, quality) -> tuple:
    """Resolve capture geometry from arguments or app_config defaults."""
    if None in (width, height, subsample, quality):
        def _get(getter: str, fallback: int) -> int:
            try:
                return int(getattr(app_config, getter)())
            except Exception:
                return fallback

        if width is None:
            width = _get("get_image_capture_width", _DEFAULT_CAPTURE_WIDTH)
        if height is None:
            height = _get("get_image_capture_height", _DEFAULT_CAPTURE_HEIGHT)
        if subsample is None:
            subsample = _get("get_image_capture_subsample", _DEFAULT_SUBSAMPLE)
        if quality is None:
            quality = _get("get_image_capture_jpeg_quality", _DEFAULT_JPEG_QUALITY)

    try:
        width = max(1, min(int(width), 9999))
    except Exception:
        width = _DEFAULT_CAPTURE_WIDTH
    try:
        height = max(1, min(int(height), 9999))
    except Exception:
        height = _DEFAULT_CAPTURE_HEIGHT
    try:
        subsample = int(subsample)
    except Exception:
        subsample = _DEFAULT_SUBSAMPLE
    if subsample not in (1, 2, 4):
        subsample = _DEFAULT_SUBSAMPLE
    try:
        quality = max(5, min(int(quality), 100))
    except Exception:
        quality = _DEFAULT_JPEG_QUALITY
    return width, height, subsample, quality


def build_capture_commands(
    width: Optional[int] = None,
    height: Optional[int] = None,
    subsample: Optional[int] = None,
    quality: Optional[int] = None,
) -> list[bytes]:
    """Return the command frames to configure and trigger one capture.

    Frame 1 combines every DE7 image-processing setting into a single
    conjunction frame exactly as in the manual's transmission examples;
    frame 2 is the DE8 capture command in "commands in conjunction" mode
    (m=0: take the picture immediately, no trigger press required).

    The crop defaults to the **full sensor** (1280x800 on MDI-5250/5350) so
    the saved scan picture shows the whole field of view — the previous fixed
    640x480 crop captured only the top-left quarter there.  All values can be
    overridden per call or persistently via ``app_config.json`` (see
    ``_resolve_geometry``).  MDI-4x00/N210 engines (752x480 sensor) should
    configure ``image_capture_width: 752`` / ``image_capture_height: 480``.
    """
    width, height, subsample, quality = _resolve_geometry(width, height, subsample, quality)
    settings = [
        _de7_param_text("DE7Q1", "Q0", 0),           # crop left   = 0
        _de7_param_text("DE7Q1", "Q1", 0),           # crop top    = 0
        _de7_param_text("DE7Q1", "Q2", width - 1),   # crop right  = width - 1
        _de7_param_text("DE7Q1", "Q3", height - 1),  # crop bottom = height - 1
        _de7_param_text("DE7Q2", "Q0", subsample),   # horizontal subsampling
        _de7_param_text("DE7Q2", "Q1", subsample),   # vertical subsampling
        _de7_param_text("DE7Q3", "Q0", 0),           # bit depth = 8 bits per pixel
        _de7_param_text("DE7Q4", "Q0", quality),     # JPEG quality
        _de7_param_text("DE7Q5", "Q0", 1),           # output format = JPEG
        _de7_param_text("DE7Q6", "Q0", 1),           # transmission mode = ALL
    ]
    config = _ESC + b"[" + b"[".join(s.encode("ascii") for s in settings) + _CR
    return [config, _cmd("DE8Q0")]


# ---- Checksum -------------------------------------------------------------


def checksum(data: bytes) -> int:
    """16-bit weighted checksum of ``data``: sum of byte*(index+1) mod 65536."""
    total = 0
    for i, b in enumerate(data):
        total += (i + 1) * b
    return total & 0xFFFF


# ---- Packet parsing -------------------------------------------------------


class ImageRecord(NamedTuple):
    """Result of one :func:`parse_image_record` attempt.

    ``status`` is one of:

    - ``"ok"``:          checksum-valid frame; ``rec_no``/``payload``/``end`` set
    - ``"bad"``:         well-formed frame (sane length + end marker) whose
                         checksum failed; ``end`` = past the frame; caller NAKs
    - ``"incomplete"``:  need more bytes; ``end`` = index of the candidate
                         start marker (caller may trim the garbage before it)
    """

    status: str
    rec_no: int
    payload: bytes
    end: int


def parse_image_record(buf: bytes, start: int = 0) -> ImageRecord:
    """Parse the first complete packet frame in ``buf`` at/after ``start``.

    Frame layout (big-endian multi-byte fields, per manual and reference
    sample): ``Start(0x21) recNo(2) Length(4) payload Length bytes
    Checksum(2) End(0x0D)``.  The checksum covers the payload only and is
    stored high byte first.
    """
    pos = start
    total = len(buf)
    while True:
        s = buf.find(_START, pos)
        if s < 0:
            return ImageRecord("incomplete", 0, b"", total)
        if s + 7 > total:
            return ImageRecord("incomplete", 0, b"", s)
        rec_no = int.from_bytes(buf[s + 1:s + 3], "big")
        length = int.from_bytes(buf[s + 3:s + 7], "big")
        # Sanity guards against garbage bytes that merely look like a start.
        if length < 1 or length > _MAX_PAYLOAD_BYTES:
            pos = s + 1
            continue
        payload_end = s + 7 + length
        frame_end = payload_end + 3  # checksum(2) + End(1)
        if frame_end > total:
            return ImageRecord("incomplete", 0, b"", s)
        if buf[payload_end + 2] != _END:
            pos = s + 1
            continue
        payload = bytes(buf[s + 7:payload_end])
        stored = int.from_bytes(buf[payload_end:payload_end + 2], "big")
        if checksum(payload) != stored:
            return ImageRecord("bad", rec_no, payload, frame_end)
        return ImageRecord("ok", rec_no, payload, frame_end)


def parse_image_packet(buf: bytes) -> Optional[bytes]:
    """Return the image bytes of the first complete ALL-mode packet in ``buf``.

    In ALL transmission mode the single packet carries the 256-byte
    Information header followed directly by the whole image, so the returned
    bytes can be loaded straight into a QPixmap/QImage or written to disk.
    Returns ``None`` when no complete, checksum-valid packet with image data
    is present (PART-mode transfers are assembled by :func:`_collect_image`).
    """
    pos = 0
    while True:
        rec = parse_image_record(buf, pos)
        if rec.status != "ok":
            return None
        pos = rec.end
        if rec.rec_no == 0 and len(rec.payload) > _INFO_HEADER_LEN:
            return rec.payload[_INFO_HEADER_LEN:]
        # A PART information packet (rec 0, exactly 256 bytes) or a PART data
        # record (rec > 0) is not an ALL-mode image; keep scanning.


# ---- Information field ----------------------------------------------------


@dataclass(frozen=True)
class ImageInformation:
    """Parsed 256-byte Information field of an image transfer."""

    image_size: int = 0            # size of the output image in bytes
    image_number: int = 0          # identification number in engine memory
    width: int = 0                 # processed image width  [pixel]
    height: int = 0                # processed image height [pixel]
    bits_per_pixel: int = 0        # 1, 4, 8 or 10
    file_format: int = 0           # 1 = JPEG, 3 = BMP (raw, header omitted)
    total_transfer_count: int = 0  # packets of this transmission, incl. this

    def expected_data_size(self) -> int:
        """Return the expected raw data size for BMP-style payloads."""
        if self.width <= 0 or self.height <= 0:
            return 0
        pixels = self.width * self.height
        if self.bits_per_pixel == 10:
            size = pixels * 2  # raw 16-bit words, upper 10 bits used
        elif self.bits_per_pixel in (1, 4, 8):
            size = (pixels * self.bits_per_pixel + 7) // 8
        else:
            return 0
        return size if size <= _MAX_PAYLOAD_BYTES else 0


def _plausible(be: int, le: int, limit: int) -> int:
    """Prefer the big-endian value, fall back to little-endian if sane."""
    if 0 < be <= limit:
        return be
    if 0 < le <= limit:
        return le
    return 0


def parse_information(payload: bytes) -> Optional[ImageInformation]:
    """Parse the 256-byte Information subfield (subfields per manual §3.3.3a)."""
    if len(payload) < _INFO_HEADER_LEN:
        return None
    info = payload[:_INFO_HEADER_LEN]
    return ImageInformation(
        image_size=_plausible(
            int.from_bytes(info[1:5], "big"),
            int.from_bytes(info[1:5], "little"),
            _MAX_PAYLOAD_BYTES,
        ),
        image_number=int.from_bytes(info[5:7], "big"),
        width=_plausible(
            int.from_bytes(info[7:9], "big"),
            int.from_bytes(info[7:9], "little"),
            _MAX_SENSOR_WIDTH,
        ),
        height=_plausible(
            int.from_bytes(info[9:11], "big"),
            int.from_bytes(info[9:11], "little"),
            _MAX_SENSOR_HEIGHT,
        ),
        bits_per_pixel=info[23] if info[23] in (1, 4, 8, 10) else 0,
        file_format=info[24] if info[24] in (1, 3) else 0,
        total_transfer_count=_plausible(
            int.from_bytes(info[43:45], "big"),
            int.from_bytes(info[43:45], "little"),
            0xFFFF,
        ),
    )


# ---- BMP payload conversion -----------------------------------------------


def raw_bmp_to_jpeg(data: bytes, info: ImageInformation) -> Optional[bytes]:
    """Convert header-less BMP payload (raw pixel values) to JPEG bytes.

    Per the manual, in BMP output mode "only the data (uncompressed color
    saturation values) is transmitted; the bitmap header is omitted".  Lines
    are transmitted top-down (as consumed by the reference sample).  Only
    grayscale depths (1/4/8 bpp and 10-bit raw) are produced by the engines
    covered by the manual, so the result is a grayscale JPEG.
    """
    width, height, bpp = info.width, info.height, info.bits_per_pixel
    if width <= 0 or height <= 0 or bpp not in (1, 4, 8, 10):
        return None
    pixels = width * height

    if bpp == 8:
        if len(data) < pixels:
            return None
        gray = bytearray(data[:pixels])
    elif bpp == 4:
        need = (pixels + 1) // 2
        if len(data) < need:
            return None
        gray = bytearray(pixels)
        for i, byte in enumerate(data[:need]):
            hi = (byte >> 4) & 0x0F
            gray[2 * i] = (hi << 4) | hi  # scale 0..15 -> 0..255
            if 2 * i + 1 < pixels:
                lo = byte & 0x0F
                gray[2 * i + 1] = (lo << 4) | lo
    elif bpp == 1:
        need = (pixels + 7) // 8
        if len(data) < need:
            return None
        gray = bytearray(pixels)
        for i in range(pixels):
            gray[i] = 0xFF if (data[i >> 3] >> (7 - (i & 7))) & 1 else 0x00
    else:  # 10-bit raw: 16-bit word per pixel, upper 8 bits extracted
        if len(data) < pixels * 2:
            return None
        gray = bytearray(pixels)
        for i in range(pixels):
            gray[i] = data[2 * i]  # upper 8 bits of the big-endian word

    # QImage scanlines must be 32-bit aligned.
    stride = (width + 3) & ~3
    if stride == width:
        raw = bytes(gray)
    else:
        padded = bytearray(stride * height)
        for row in range(height):
            base = row * width
            padded[row * stride:row * stride + width] = gray[base:base + width]
        raw = bytes(padded)

    try:
        image = QImage(raw, width, height, stride, QImage.Format.Format_Grayscale8)
        if image.isNull():
            return None
        out = QBuffer()
        out.open(QIODevice.OpenModeFlag.WriteOnly)
        if not image.save(out, "JPEG", 85):
            return None
        jpeg = bytes(out.data())
        out.close()
        return jpeg or None
    except Exception:
        return None


# ---- Transfer assembly ----------------------------------------------------


def _send(ser: serial.Serial, payload: bytes) -> bool:
    try:
        ser.write(payload)
        ser.flush()
        return True
    except Exception:
        return False


def _finalize(info: Optional[ImageInformation], data: bytearray) -> Optional[bytes]:
    """Turn completed raw payload bytes into JPEG bytes for storage."""
    if not data:
        return None
    payload = bytes(data)
    looks_jpeg = payload[:2] == b"\xff\xd8"
    if info is None:
        return payload if looks_jpeg else None
    if info.file_format == 3:
        return raw_bmp_to_jpeg(payload, info)
    if looks_jpeg:
        return payload
    # Announced JPEG but raw bytes arrived: try decoding as raw BMP.
    return raw_bmp_to_jpeg(payload, info)


def _salvage(info: Optional[ImageInformation], data: bytearray) -> Optional[bytes]:
    """Best-effort completion after the engine fell silent mid-transfer."""
    if not data:
        return None
    payload = bytes(data)
    if payload[:2] == b"\xff\xd8" and payload[-2:] == b"\xff\xd9":
        return payload  # complete JPEG despite missing trailer bookkeeping
    if info is not None and info.file_format == 3:
        expected = info.expected_data_size()
        if expected > 0 and len(payload) >= expected:
            return raw_bmp_to_jpeg(payload, info)
    return None


def _part_complete(
    info: Optional[ImageInformation],
    total_records: Optional[int],
    rec_no: int,
    data: bytearray,
) -> bool:
    """Decide whether a PART transfer has delivered every byte."""
    if info is not None:
        if info.image_size > 0 and len(data) >= info.image_size:
            return True
        if info.file_format != 1:
            expected = info.expected_data_size()
            if expected > 0 and len(data) >= expected:
                return True
    if total_records is not None and rec_no >= total_records - 1:
        return True
    return False


def _extend_deadline(ser: serial.Serial, deadline: float,
                     info: Optional[ImageInformation], received: int) -> float:
    """Give slow baud rates enough time for the announced image size."""
    if info is None or info.image_size <= 0:
        return deadline
    baud = getattr(ser, "baudrate", 0) or 0
    if baud <= 0:
        return deadline
    remaining = max(0, info.image_size - received)
    need_s = remaining * 10.0 / baud * 1.5 + 5.0
    return max(deadline, time.monotonic() + need_s)


def _collect_image(ser: serial.Serial, timeout_ms: int) -> Optional[bytes]:
    """Read one complete image transfer from ``ser``.

    Handles ALL transmission (single packet with Information + whole image)
    as well as PART transmission (information packet followed by line-by-line
    data packets, each confirmed with ACK; bad packets are NAKed and resent
    by the engine).  ``timeout_ms`` is the silence window: the transfer is
    aborted when the engine stops talking for that long, while an ongoing
    transfer at slow baud rates is granted extra time via the announced
    image size.
    """
    silence_s = max(timeout_ms / 1000.0, _SILENCE_FLOOR_S)
    hard_deadline = time.monotonic() + _MAX_TRANSFER_S
    last_rx = time.monotonic()

    buffer = bytearray()
    data = bytearray()
    info: Optional[ImageInformation] = None
    total_records: Optional[int] = None
    last_data_rec_no = 0
    naks = 0

    while time.monotonic() < hard_deadline:
        if time.monotonic() - last_rx > silence_s:
            return _salvage(info, data)
        try:
            waiting = ser.in_waiting
            chunk = ser.read(waiting if waiting > 0 else 1)
        except Exception:
            return None
        if not chunk:
            continue
        buffer.extend(chunk)
        last_rx = time.monotonic()

        while True:
            rec = parse_image_record(buffer)
            if rec.status == "incomplete":
                if rec.end > 0:
                    del buffer[:rec.end]
                break
            if rec.status == "bad":
                del buffer[:rec.end]
                naks += 1
                if naks > _MAX_NAKS or not _send(ser, _NAK):
                    return None
                continue

            # Checksum-valid frame: confirm it before reading further.
            del buffer[:rec.end]
            if not _send(ser, _ACK):
                return None

            if rec.rec_no == 0:
                if len(rec.payload) > _INFO_HEADER_LEN:
                    # ALL transmission: information + whole image in one go.
                    info = parse_information(rec.payload[:_INFO_HEADER_LEN])
                    data.extend(rec.payload[_INFO_HEADER_LEN:])
                    hard_deadline = _extend_deadline(ser, hard_deadline, info, len(data))
                    return _finalize(info, data)
                if len(rec.payload) == _INFO_HEADER_LEN:
                    # PART transmission: packet 0 carries only the information.
                    info = parse_information(rec.payload)
                    if info is not None:
                        hard_deadline = _extend_deadline(ser, hard_deadline, info, 0)
                        if 1 <= info.total_transfer_count <= 0xFFFF:
                            total_records = info.total_transfer_count
                        if total_records == 1:
                            return None  # information only, no image data
                    continue
                # Malformed information packet: ask for a resend.
                naks += 1
                if naks > _MAX_NAKS or not _send(ser, _NAK):
                    return None
                continue

            # PART data record (line/chunk).  Ignore duplicates caused by a
            # lost ACK so a resent record is not appended twice.
            if rec.rec_no <= last_data_rec_no:
                continue
            last_data_rec_no = rec.rec_no
            data.extend(rec.payload)
            if _part_complete(info, total_records, rec.rec_no, data):
                return _finalize(info, data)

    return None


# ---- Serial capture -------------------------------------------------------


def capture_image_from_serial(ser: serial.Serial, timeout_ms: int = 4000) -> Optional[bytes]:
    """Capture one JPEG through an already open serial connection.

    The caller owns ``ser`` and must ensure that no other serial operation is
    performed concurrently.  Keeping the port open is important for a CCD
    scanner: opening a second connection to the same COM port can cause the
    scanner or the operating system to reject the image request.

    Returns the JPEG bytes on success, else ``None``.  Protocol failures are
    intentionally converted to ``None`` so the barcode scan remains usable.
    """
    try:
        # Bytes belonging to the preceding barcode line must not be
        # interpreted as the beginning of an image packet.  The scan has
        # already been delivered to the GUI before this function is requested.
        try:
            ser.reset_input_buffer()
        except Exception:
            pass

        frames = build_capture_commands()
        # Frame 1 configures the image processing; the reference sample waits
        # briefly afterwards and discards whatever the engine echoes back, so
        # stray response bytes cannot pollute the image data stream.
        if not _send(ser, frames[0]):
            return None
        time.sleep(_CONFIG_SETTLE_S)
        try:
            ser.reset_input_buffer()
        except Exception:
            pass
        if not _send(ser, frames[1]):
            return None

        jpeg = _collect_image(ser, timeout_ms)
        if jpeg is None:
            # The engine may still be in image-capture mode (e.g. the
            # transfer was aborted halfway).  CAN politely ends the
            # transmission so the engine returns to normal decode operation.
            _send(ser, _CAN)
            return None
        return jpeg
    except Exception:
        return None


def capture_image(port: str, baud: int, timeout_ms: int = 4000) -> Optional[bytes]:
    """Open a serial connection, send the capture commands, read one JPEG.

    This compatibility wrapper is useful for callers that do not already own
    a reader connection.  The main application uses
    :func:`capture_image_from_serial` so it never opens a second connection to
    the active scanner port.
    """
    try:
        ser = serial.Serial(
            port=port,
            baudrate=baud,
            bytesize=serial.EIGHTBITS,
            parity=serial.PARITY_NONE,
            stopbits=serial.STOPBITS_ONE,
            timeout=_RX_CHUNK_TIMEOUT,
        )
    except Exception:
        return None

    try:
        return capture_image_from_serial(ser, timeout_ms)
    finally:
        try:
            ser.close()
        except Exception:
            pass


# ---- Qt worker ------------------------------------------------------------


class ImageCaptureWorker(QThread):
    """Background worker that captures one image on a serial port.

    Emits ``image_ready(object)`` with the JPEG ``bytes`` on success, or
    ``capture_failed(str)`` otherwise. Never raises into the GUI thread.
    """

    image_ready = Signal(object)     # JPEG bytes
    capture_failed = Signal(str)     # reason

    def __init__(self, port: str, baud: int, timeout_ms: int = 4000, parent=None):
        super().__init__(parent)
        self._port = port
        self._baud = baud
        self._timeout_ms = timeout_ms

    def run(self) -> None:
        jpeg = capture_image(self._port, self._baud, self._timeout_ms)
        if jpeg:
            self.image_ready.emit(jpeg)
        else:
            self.capture_failed.emit("image_capture_failed")








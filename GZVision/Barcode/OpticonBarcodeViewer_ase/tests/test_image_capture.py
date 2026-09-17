"""Unit tests for the Opticon CCD image protocol (MDI-4x00 / N210).

The frame format follows the "MDI-4x00 / N210 Image Capture Manual" and the
reference C# sample ``scanner_pic``: big-endian recNo/Length fields, a 16-bit
weighted checksum over the payload only (stored high byte first), ACK per
valid packet, NAK + resend for corrupted packets, and BOTH transmission
modes (ALL: one packet with Information + whole image; PART: information
packet plus line-by-line data packets).
"""

from __future__ import annotations

import io
import struct
import sys
from pathlib import Path
from unittest.mock import MagicMock

import pytest
from PIL import Image
from PySide6.QtWidgets import QApplication, QTableWidget

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

import image_capture
from image_capture import (
    _END,
    _INFO_HEADER_LEN,
    _START,
    ImageInformation,
    build_capture_commands,
    capture_image_from_serial,
    checksum,
    parse_image_packet,
    parse_image_record,
    parse_information,
    raw_bmp_to_jpeg,
)
from main_window import MainWindow
from models import Scan
from scan_table import ScanTablePresenter, COL_IMAGE

_ACK = b"\x06"
_NAK = b"\x15"
_CAN = b"\x18"
_COMMAND_PREFIX = b"".join(build_capture_commands())


# ---- Wire-format helpers ---------------------------------------------------


def _frame(rec_no: int, payload: bytes, *, corrupt: bool = False) -> bytes:
    """Build one packet frame exactly as the engine transmits it."""
    header = (
        bytes([_START])
        + rec_no.to_bytes(2, "big")
        + len(payload).to_bytes(4, "big")
    )
    value = checksum(payload)
    if corrupt:
        value ^= 0x0001
    return header + payload + value.to_bytes(2, "big") + bytes([_END])


def _information(
    *,
    width: int = 640,
    height: int = 480,
    bpp: int = 8,
    file_format: int = 1,
    image_size: int = 0,
    total: int = 1,
) -> bytes:
    """Build a 256-byte Information field (subfields per manual §3.3.3a)."""
    info = bytearray(_INFO_HEADER_LEN)
    struct.pack_into(">I", info, 1, image_size)
    struct.pack_into(">H", info, 7, width)
    struct.pack_into(">H", info, 9, height)
    info[23] = bpp
    info[24] = file_format
    struct.pack_into(">H", info, 43, total)
    return bytes(info)


class FakeSerial:
    """Minimal ``serial.Serial`` stand-in that feeds queued response chunks."""

    def __init__(self, chunks=(), baudrate: int = 115200):
        self._chunks = [bytes(c) for c in chunks]
        self.baudrate = baudrate
        self.written = bytearray()

    @property
    def in_waiting(self) -> int:
        return len(self._chunks[0]) if self._chunks else 0

    def read(self, size: int = 1) -> bytes:
        if not self._chunks:
            return b""
        chunk = self._chunks[0][:size]
        self._chunks[0] = self._chunks[0][size:]
        if not self._chunks[0]:
            self._chunks.pop(0)
        return chunk

    def write(self, data) -> int:
        self.written.extend(data)
        return len(data)

    def flush(self) -> None:
        pass

    def reset_input_buffer(self) -> None:
        pass


def _jpeg_payload() -> bytes:
    return b"\xff\xd8fake-jpeg-data\x01\x02\xff\xd9"


# ---- Capture geometry (DE7 crop / subsample / quality) ---------------------


def test_build_capture_commands_full_frame_1280x800():
    """Default geometry captures the whole 1280x800 sensor."""
    frames = build_capture_commands(width=1280, height=800, subsample=1, quality=75)
    # Wire format as in the reference sample: ESC '[' opens the first DE7
    # segment, every following segment is prefixed with '[' (joined), and one
    # trailing <CR> terminates the conjunction frame.
    assert frames[0] == (
        b"\x1b["
        b"DE7Q1Q0Q0Q0Q0Q0"    # crop left   = 0
        b"[DE7Q1Q1Q0Q0Q0Q0"   # crop top    = 0
        b"[DE7Q1Q2Q1Q2Q7Q9"   # crop right  = 1279
        b"[DE7Q1Q3Q0Q7Q9Q9"   # crop bottom = 799
        b"[DE7Q2Q0Q0Q0Q0Q1"   # subsampling horizontal = 1
        b"[DE7Q2Q1Q0Q0Q0Q1"   # subsampling vertical   = 1
        b"[DE7Q3Q0Q0Q0Q0Q0"   # bit depth = 8 bpp
        b"[DE7Q4Q0Q0Q0Q7Q5"   # JPEG quality = 75
        b"[DE7Q5Q0Q0Q0Q0Q1"   # output format = JPEG
        b"[DE7Q6Q0Q0Q0Q0Q1"   # transmission mode = ALL
        b"\x0d"
    )
    assert frames[1] == b"\x1b[DE8Q0\x0d"


def test_build_capture_commands_backward_compatible_640x480():
    """The old 640x480 geometry still produces the original byte sequence."""
    frames = build_capture_commands(width=640, height=480, subsample=1, quality=75)
    assert frames[0] == (
        b"\x1b["
        b"DE7Q1Q0Q0Q0Q0Q0"
        b"[DE7Q1Q1Q0Q0Q0Q0"
        b"[DE7Q1Q2Q0Q6Q3Q9"   # crop right  = 639
        b"[DE7Q1Q3Q0Q4Q7Q9"   # crop bottom = 479
        b"[DE7Q2Q0Q0Q0Q0Q1"
        b"[DE7Q2Q1Q0Q0Q0Q1"
        b"[DE7Q3Q0Q0Q0Q0Q0"
        b"[DE7Q4Q0Q0Q0Q7Q5"
        b"[DE7Q5Q0Q0Q0Q0Q1"
        b"[DE7Q6Q0Q0Q0Q0Q1"
        b"\x0d"
    )


def test_build_capture_commands_subsample_and_quality():
    frames = build_capture_commands(width=1280, height=800, subsample=2, quality=90)
    assert b"[DE7Q2Q0Q0Q0Q0Q2" in frames[0]   # horizontal subsampling = 2
    assert b"[DE7Q2Q1Q0Q0Q0Q2" in frames[0]   # vertical subsampling   = 2
    assert b"[DE7Q4Q0Q0Q0Q9Q0" in frames[0]     # JPEG quality = 90
    assert b"[DE7Q1Q2Q1Q2Q7Q9" in frames[0]   # crop right = 1279


def _application() -> QApplication:
    return QApplication.instance() or QApplication(sys.argv)


@pytest.fixture(autouse=True)
def _fast_capture(monkeypatch):
    """Skip the post-config settle delay to keep the tests fast."""
    monkeypatch.setattr(image_capture, "_CONFIG_SETTLE_S", 0.0)


# ---- Frame parsing ---------------------------------------------------------


def test_checksum_is_weighted_and_16_bit():
    assert checksum(b"\x01\x02\x03") == 1 + 4 + 9
    assert checksum(b"\xff" * 1000) == (255 * sum(range(1, 1001))) & 0xFFFF


def test_parse_image_record_accepts_valid_frame():
    payload = _jpeg_payload()
    rec = parse_image_record(_frame(1, payload))
    assert rec.status == "ok"
    assert rec.rec_no == 1
    assert rec.payload == payload


def test_frame_fields_are_big_endian():
    payload = _jpeg_payload()
    frame = _frame(0, payload)
    assert frame[1:3] == (0).to_bytes(2, "big")
    assert frame[3:7] == len(payload).to_bytes(4, "big")
    assert parse_image_record(frame).status == "ok"

    # The same frame with a little-endian length must NOT parse as valid.
    wrong = bytes([_START]) + (0).to_bytes(2, "big")
    wrong += len(payload).to_bytes(4, "little")
    wrong += payload + checksum(payload).to_bytes(2, "big") + bytes([_END])
    assert parse_image_record(wrong).status != "ok"


def test_checksum_covers_payload_only():
    payload = _jpeg_payload()
    assert parse_image_record(_frame(2, payload)).status == "ok"

    # Checksum computed over recNo + Length + payload (the previous, wrong
    # interpretation) must be rejected.
    header = bytes([_START]) + (2).to_bytes(2, "big") + len(payload).to_bytes(4, "big")
    value = checksum(header[1:] + payload)
    wrong_frame = header + payload + value.to_bytes(2, "big") + bytes([_END])
    rec = parse_image_record(wrong_frame)
    assert rec.status == "bad"


def test_checksum_is_stored_high_byte_first():
    payload = b"\x00" * 10
    frame = _frame(0, payload)
    stored = frame[7 + len(payload):7 + len(payload) + 2]
    assert stored == checksum(payload).to_bytes(2, "big")


def test_parse_image_record_flags_corrupt_checksum():
    rec = parse_image_record(_frame(0, b"image", corrupt=True))
    assert rec.status == "bad"


def test_parse_image_record_waits_for_complete_packet():
    frame = _frame(0, b"image")
    assert parse_image_record(frame[:-1]).status == "incomplete"
    assert parse_image_record(frame[:5]).status == "incomplete"
    assert parse_image_record(b"").status == "incomplete"


def test_parse_image_record_skips_garbage_before_start():
    payload = _jpeg_payload()
    rec = parse_image_record(b"garbage\x21 trail" + _frame(0, payload))
    assert rec.status == "ok"
    assert rec.payload == payload


def test_parse_image_packet_returns_data_after_information_header():
    jpeg = _jpeg_payload()
    assert parse_image_packet(_frame(0, bytes(_INFO_HEADER_LEN) + jpeg)) == jpeg


def test_parse_image_packet_ignores_part_records():
    info = _information()
    assert parse_image_packet(_frame(0, info)) is None
    assert parse_image_packet(_frame(1, b"line-data")) is None


def test_parse_image_packet_rejects_corrupt_checksum():
    assert parse_image_packet(_frame(0, bytes(_INFO_HEADER_LEN) + b"img", corrupt=True)) is None


# ---- Information field -----------------------------------------------------


def test_parse_information_reads_big_endian_fields():
    info = parse_information(
        _information(width=640, height=480, bpp=8, file_format=1,
                     image_size=40256, total=17)
    )
    assert info == ImageInformation(
        image_size=40256,
        image_number=0,
        width=640,
        height=480,
        bits_per_pixel=8,
        file_format=1,
        total_transfer_count=17,
    )


def test_parse_information_falls_back_to_little_endian():
    raw = bytearray(_INFO_HEADER_LEN)
    struct.pack_into("<H", raw, 7, 640)   # big-endian read = 0x8002 > 752
    struct.pack_into("<H", raw, 9, 480)   # big-endian read = 0xE001 > 480
    info = parse_information(bytes(raw))
    assert info.width == 640
    assert info.height == 480


def test_expected_data_size_for_bmp_depths():
    assert ImageInformation(width=640, height=480, bits_per_pixel=8).expected_data_size() == 307200
    assert ImageInformation(width=640, height=480, bits_per_pixel=4).expected_data_size() == 153600
    assert ImageInformation(width=640, height=480, bits_per_pixel=1).expected_data_size() == 38400
    assert ImageInformation(width=640, height=480, bits_per_pixel=10).expected_data_size() == 614400


# ---- Capture over a (fake) serial connection -------------------------------


def _split(data: bytes, size: int) -> list:
    return [data[i:i + size] for i in range(0, len(data), size)]


def test_capture_all_mode_returns_jpeg_and_acks():
    jpeg = _jpeg_payload()
    frame = _frame(0, bytes(_INFO_HEADER_LEN) + jpeg)
    ser = FakeSerial(_split(frame, 7))  # dribble the packet in tiny chunks

    result = capture_image_from_serial(ser, timeout_ms=1000)

    assert result == jpeg
    assert ser.written.startswith(_COMMAND_PREFIX)
    assert ser.written[len(_COMMAND_PREFIX):] == _ACK


def test_capture_all_mode_bmp_payload_is_converted():
    width, height = 8, 6
    raw = bytes(range(0, width * height))
    info = _information(width=width, height=height, bpp=8, file_format=3,
                        image_size=len(raw), total=1)
    ser = FakeSerial([_frame(0, info + raw)])

    result = capture_image_from_serial(ser, timeout_ms=1000)

    assert result is not None
    assert result[:2] == b"\xff\xd8"  # JPEG SOI
    image = Image.open(io.BytesIO(result))
    assert image.size == (width, height)


def test_capture_part_mode_assembles_records_and_acks_each():
    jpeg = _jpeg_payload()
    info = _information(file_format=1, image_size=len(jpeg), total=3)
    ser = FakeSerial([
        _frame(0, info),
        _frame(1, jpeg[:4]),
        _frame(2, jpeg[4:]),
    ])

    result = capture_image_from_serial(ser, timeout_ms=1000)

    assert result == jpeg
    tail = ser.written[len(_COMMAND_PREFIX):]
    assert tail == _ACK * 3


def test_capture_part_mode_naks_corrupt_record_and_accepts_resend():
    jpeg = _jpeg_payload()
    info = _information(file_format=1, image_size=len(jpeg), total=3)
    ser = FakeSerial([
        _frame(0, info),
        _frame(1, jpeg[:4], corrupt=True),   # damaged on the wire
        _frame(1, jpeg[:4]),                 # engine resends after NAK
        _frame(2, jpeg[4:]),
    ])

    result = capture_image_from_serial(ser, timeout_ms=1000)

    assert result == jpeg
    tail = ser.written[len(_COMMAND_PREFIX):]
    assert tail == _ACK + _NAK + _ACK + _ACK


def test_capture_part_mode_ignores_duplicate_record_after_lost_ack():
    jpeg = _jpeg_payload()
    info = _information(file_format=1, image_size=len(jpeg), total=3)
    ser = FakeSerial([
        _frame(0, info),
        _frame(1, jpeg[:4]),
        _frame(1, jpeg[:4]),  # engine did not see our ACK and resends
        _frame(2, jpeg[4:]),
    ])

    result = capture_image_from_serial(ser, timeout_ms=1000)

    assert result == jpeg  # the resent record must not be appended twice


def test_capture_part_mode_completes_on_total_transfer_count():
    jpeg = _jpeg_payload()
    # No image_size announced: completion must come from the record count.
    info = _information(file_format=1, image_size=0, total=3)
    ser = FakeSerial([
        _frame(0, info),
        _frame(1, jpeg[:4]),
        _frame(2, jpeg[4:]),
    ])

    assert capture_image_from_serial(ser, timeout_ms=1000) == jpeg


def test_capture_part_mode_bmp_completes_on_expected_data_size():
    width, height = 8, 6
    raw = bytes([0x00] * width + [0x80] * (width * (height - 2)) + [0xFF] * width)
    info = _information(width=width, height=height, bpp=8, file_format=3,
                        image_size=0, total=2)
    ser = FakeSerial([_frame(0, info), _frame(1, raw)])

    result = capture_image_from_serial(ser, timeout_ms=1000)

    assert result is not None and result[:2] == b"\xff\xd8"
    image = Image.open(io.BytesIO(result))
    assert image.size == (width, height)
    assert image.mode in ("L", "RGB")


def test_capture_information_only_transfer_returns_none():
    ser = FakeSerial([_frame(0, _information(total=1))])

    assert capture_image_from_serial(ser, timeout_ms=1000) is None


def test_capture_silence_timeout_returns_none_and_sends_can(monkeypatch):
    monkeypatch.setattr(image_capture, "_SILENCE_FLOOR_S", 0.05)
    ser = FakeSerial([])

    result = capture_image_from_serial(ser, timeout_ms=50)

    assert result is None
    assert ser.written.endswith(_CAN)


def test_capture_unwritable_port_returns_none():
    class BrokenSerial(FakeSerial):
        def write(self, data):
            raise OSError("port gone")

    assert capture_image_from_serial(BrokenSerial(), timeout_ms=1000) is None


def test_capture_terminates_after_too_many_corrupt_packets(monkeypatch):
    monkeypatch.setattr(image_capture, "_SILENCE_FLOOR_S", 0.05)
    info = _information(file_format=1, image_size=8, total=3)
    chunks = [_frame(0, info)]
    chunks += [_frame(1, b"\x00" * 4, corrupt=True)] * 20
    ser = FakeSerial(chunks)

    assert capture_image_from_serial(ser, timeout_ms=1000) is None


def test_raw_bmp_to_jpeg_rejects_insufficient_data():
    info = ImageInformation(width=8, height=6, bits_per_pixel=8, file_format=3)
    assert raw_bmp_to_jpeg(b"\x00" * 10, info) is None


def test_raw_bmp_to_jpeg_rejects_unknown_geometry():
    info = ImageInformation(width=0, height=0, bits_per_pixel=8, file_format=3)
    assert raw_bmp_to_jpeg(b"\x00" * 100, info) is None


# ---- Main window picture saving --------------------------------------------


def test_image_callback_saves_jpeg_and_displays_thumbnail(tmp_path: Path):
    _application()
    table = QTableWidget(0, 7)
    table.setHorizontalHeaderLabels(
        ["Time", "Operator", "Status", "Barcode", "Input", "Image", "Save"]
    )
    presenter = ScanTablePresenter(table)
    scan = Scan(barcode_value="CCD-001", status="GOOD")
    presenter.insert_scan(scan, "GOOD", highlight_ng=False)

    target = tmp_path / "CCD-001.jpg"
    Image.new("RGB", (24, 16), (12, 120, 220)).save(target, format="JPEG")
    jpeg_bytes = target.read_bytes()
    target.unlink()

    window = MainWindow.__new__(MainWindow)
    window._table = table
    window._scan_table = presenter
    MainWindow._on_image_ready(window, (scan, target), jpeg_bytes)

    assert target.exists()
    assert scan.image_path == str(target)
    row = presenter.row_for_scan(scan)
    assert table.cellWidget(row, COL_IMAGE) is not None

def test_image_callback_saves_jpeg_even_when_row_is_gone(tmp_path: Path):
    """The picture is persisted beside the TXT even if the row vanished.

    A new session (or a cleared table) during the 1-4 s CCD transfer must not
    discard the scan's picture: the text file already exists on disk.
    """
    _application()
    table = QTableWidget(0, 7)
    presenter = ScanTablePresenter(table)
    scan = Scan(barcode_value="CCD-003", status="GOOD")
    presenter.insert_scan(scan, "GOOD", highlight_ng=False)

    target = tmp_path / "CCD-003.jpg"
    Image.new("RGB", (24, 16), (12, 120, 220)).save(target, format="JPEG")
    jpeg_bytes = target.read_bytes()
    target.unlink()

    window = MainWindow.__new__(MainWindow)
    window._table = table
    window._scan_table = presenter

    presenter.clear()  # row disappeared while the image was in flight
    MainWindow._on_image_ready(window, (scan, target), jpeg_bytes)

    assert target.exists()
    assert scan.image_path == str(target)
    assert table.rowCount() == 0  # no thumbnail crash without a row


def test_start_image_capture_requests_parallel_jpg(tmp_path: Path):
    """A saved scan queues a CCD capture targeting the .jpg beside the TXT."""
    _application()
    scan = Scan(barcode_value="CCD-004", status="GOOD")
    saved_path = tmp_path / "Null#CCD-004#Null#20260831120000.txt"

    window = MainWindow.__new__(MainWindow)
    window._worker = MagicMock()
    window._worker.is_connected.return_value = True

    MainWindow._start_image_capture(window, 0, scan, saved_path)

    window._worker.request_image_capture.assert_called_once()
    context = window._worker.request_image_capture.call_args.args[0]
    assert context[0] is scan
    assert context[1] == saved_path.with_suffix(".jpg")  # parallel to the TXT
    assert window._worker.request_image_capture.call_args.kwargs["timeout_ms"] == 4000


def test_start_image_capture_skips_when_disconnected_or_unsaved(tmp_path: Path):
    """No capture request without a connection or without a saved TXT."""
    scan = Scan(barcode_value="CCD-005", status="GOOD")
    saved_path = tmp_path / "Null#CCD-005#Null#20260831120001.txt"

    window = MainWindow.__new__(MainWindow)
    window._worker = MagicMock()
    window._worker.is_connected.return_value = False

    MainWindow._start_image_capture(window, 0, scan, saved_path)
    window._worker.request_image_capture.assert_not_called()

    window._worker.is_connected.return_value = True
    MainWindow._start_image_capture(window, 0, scan, None)  # TXT was not saved
    window._worker.request_image_capture.assert_not_called()



def test_image_callback_ignores_invalid_payload(tmp_path: Path):
    _application()
    table = QTableWidget(0, 7)
    presenter = ScanTablePresenter(table)
    scan = Scan(barcode_value="CCD-002", status="GOOD")
    presenter.insert_scan(scan, "GOOD", highlight_ng=False)

    target = tmp_path / "CCD-002.jpg"
    window = MainWindow.__new__(MainWindow)
    window._table = table
    window._scan_table = presenter

    MainWindow._on_image_ready(window, (scan, target), b"")
    MainWindow._on_image_ready(window, (scan, target), None)
    MainWindow._on_image_ready(window, scan, b"\xff\xd8\xff\xd9")

    assert not target.exists()
    assert scan.image_path == ""




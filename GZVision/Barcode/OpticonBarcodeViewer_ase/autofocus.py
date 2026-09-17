"""Image-guided barcode location for the CCD calibration workflow.

The engine's own Auto Focus / tuning pass optimizes whatever code or object is
inside the field of view, which is not necessarily the barcode the operator
placed there.  This module gives the application the missing piece:

1. :func:`locate_barcode` finds THE barcode in a captured CCD frame (decode +
   bounding box via the zxing-cpp port of the ZXing library).
2. :func:`df8_margin_commands` builds the engine's decode-area margin commands
   (``[DF8``, MDI-5250/5350 Serial Interface Software Manual section 8.10) so
   the following tuning pass can only read *that* barcode.
3. :func:`sharpness_score` provides a Laplacian-variance clarity metric for
   the barcode region, used to report the calibration outcome.

zxing-cpp is an optional dependency: when it is missing (or no barcode is
visible), every function degrades to ``None``/empty results and the caller
falls back to the previous unrestricted tuning behaviour.

Note for maintainers: only the *reader* functions of zxing-cpp are used here.
The zxing-cpp writer (``create_barcode().to_image()`` + buffer access) must
not be called in this application - accessing the written image buffer
crashes with an access violation when PySide6 is loaded in the same process
(observed with zxing-cpp 3.1.1 + PySide6 6.6.1).  The unit tests therefore
decode a committed fixture image instead of rendering barcodes at test time.
"""

from __future__ import annotations

import io
import math
import re
from dataclasses import dataclass
from typing import Optional

try:  # optional runtime dependency - calibration degrades gracefully
    import zxingcpp  # type: ignore
except Exception:  # pragma: no cover - exercised only without the package
    zxingcpp = None  # type: ignore[assignment]

def _capture_size() -> tuple:
    """Capture geometry mirroring image_capture's configured sensor size.

    Full sensor by default (1280x800 on MDI-5250/5350) so capture-image
    coordinates map 1:1 onto the engine's `[DF8` decode-area coordinates.
    """
    try:
        import app_config

        width = int(getattr(app_config, "get_image_capture_width", lambda: 1280)())
        height = int(getattr(app_config, "get_image_capture_height", lambda: 800)())
        return max(1, width), max(1, height)
    except Exception:
        return 1280, 800


# Capture geometry configured by image_capture (full sensor by default).
CAPTURE_WIDTH, CAPTURE_HEIGHT = _capture_size()

# Padding kept around the located barcode inside the decode area.
DEFAULT_PADDING_PX = 12

# The decode area must cover at least this fraction of the frame so that a
# coordinate mismatch between the capture image and the engine's sensor does
# not push the located barcode outside the restricted window.
DF8_MIN_AREA_FRACTION = 0.35

# A located box smaller than this cannot be a usable tuning target.
MIN_BOX_WIDTH = 8
MIN_BOX_HEIGHT = 4

# ---- Wire constants for the [DF8 decode-area command -----------------------
_ESC = b"\x1b"
_CR = b"\x0d"
# DF8 item selectors: 0=top, 1=right, 2=bottom, 3=left margin, 4=initialize.
_DF8_TOP, _DF8_RIGHT, _DF8_BOTTOM, _DF8_LEFT, _DF8_RESET = 0, 1, 2, 3, 4


@dataclass(frozen=True)
class BarcodeLocation:
    """A decoded barcode and its bounding box inside the CCD frame."""

    text: str
    format_name: str
    x0: int
    y0: int
    x1: int
    y1: int

    @property
    def width(self) -> int:
        return max(0, self.x1 - self.x0)

    @property
    def height(self) -> int:
        return max(0, self.y1 - self.y0)

    def is_usable(self) -> bool:
        return (
            self.width >= MIN_BOX_WIDTH
            and self.height >= MIN_BOX_HEIGHT
            and self.x1 < CAPTURE_WIDTH
            and self.y1 < CAPTURE_HEIGHT
        )


def _open_grayscale(image_bytes: bytes):
    from PIL import Image

    image = Image.open(io.BytesIO(bytes(image_bytes)))
    image.load()
    return image.convert("L")


def _pattern_matches(text: str, pattern: Optional[str]) -> bool:
    """Return True when ``text`` matches the configured Wafer-ID pattern."""
    if not pattern or not text:
        return False
    try:
        return re.match(pattern, text) is not None
    except re.error:
        return False


def _read_candidates(image) -> list:
    """Decode with several strategies and return the merged result list.

    A single pass can miss small, dim, inverted or heavily binarized codes,
    so zxing-cpp is invoked with rotation/inversion enabled, with a second
    histogram-based binarizer, and finally on a 2x upscaled copy of the
    frame (cheap Lanczos) which helps low-resolution barcodes.
    """
    if zxingcpp is None:
        return []
    results = []

    def _read(img):
        try:
            return list(zxingcpp.read_barcodes(
                img,
                try_rotate=True,
                try_invert=True,
                try_downscale=True,
            ))
        except Exception:
            return []

    base_results = _read(image)
    results.extend(base_results)

    # Alternative binarizer (only if the default pass found nothing).
    if not results and hasattr(zxingcpp, "Binarizer"):
        try:
            results.extend(list(zxingcpp.read_barcodes(
                image,
                try_rotate=True,
                try_invert=True,
                binarizer=zxingcpp.Binarizer.GlobalHistogram,
            )))
        except Exception:
            pass

    # Upscaled copy for small barcodes.
    if not results:
        from PIL import Image as _PILImage

        try:
            upscaled = image.resize(
                (image.width * 2, image.height * 2), _PILImage.LANCZOS
            )
            results.extend(_read(upscaled))
        except Exception:
            pass
    return results


def _to_location(result) -> Optional[BarcodeLocation]:
    """Build a BarcodeLocation from a zxing-cpp result (best-effort)."""
    try:
        position = result.position
        points = (
            position.top_left,
            position.top_right,
            position.bottom_left,
            position.bottom_right,
        )
        xs = [int(point.x) for point in points]
        ys = [int(point.y) for point in points]
        x0, x1 = max(0, min(xs)), max(xs)
        y0, y1 = max(0, min(ys)), max(ys)
        text = str(result.text or "")
        try:
            format_name = str(result.format.name)
        except Exception:
            format_name = ""
        return BarcodeLocation(text, format_name, x0, y0, x1, y1)
    except Exception:
        return None


def _score_location(
    location: BarcodeLocation, wafer_pattern: Optional[str]
) -> tuple:
    """Rank a located barcode.

    Barcodes that match the configured Wafer-ID pattern are strongly preferred
    (the tuning target should be THE product code, not a larger unrelated
    code in the field of view); otherwise the largest bounding box wins, which
    preserves the previous behaviour when no pattern is configured or nothing
    matches.
    """
    return (
        1 if _pattern_matches(location.text, wafer_pattern) else 0,
        location.width * location.height,
    )


def locate_barcode(image_bytes: bytes, wafer_pattern: Optional[str] = None) -> Optional[BarcodeLocation]:
    """Find the dominant barcode in a CCD frame and return it with its box.

    ``wafer_pattern`` (an optional regex, typically the configured
    ``wafer_id_pattern``) makes the decoder prefer barcodes that look like the
    product Wafer ID even when a larger foreign barcode is visible.  When no
    pattern is given (or nothing matches) the barcode with the largest
    bounding-box area wins.

    Returns ``None`` when zxing-cpp is unavailable, the image is undecodable,
    or no barcode is found after all decoding strategies.
    """
    if zxingcpp is None or not image_bytes:
        return None
    try:
        image = _open_grayscale(image_bytes)
    except Exception:
        return None

    candidates = []
    seen_boxes = set()
    for result in _read_candidates(image):
        location = _to_location(result)
        if location is None:
            continue
        key = (location.x0, location.y0, location.x1, location.y1,
               location.text)
        if key in seen_boxes:
            continue
        seen_boxes.add(key)
        candidates.append(location)

    if not candidates:
        return None

    best = max(
        candidates, key=lambda loc: _score_location(loc, wafer_pattern)
    )
    return best


def decode_text(image_bytes: bytes) -> Optional[str]:
    """Return the text of the dominant barcode in ``image_bytes``, if any."""
    location = locate_barcode(image_bytes)
    return location.text if location else None


def sharpness_score(image_bytes: bytes, box: Optional[BarcodeLocation] = None) -> float:
    """Return a clarity metric (Laplacian variance) for ``box`` in the frame.

    Higher values mean sharper edges.  The metric is diagnostic only - a
    barcode that decodes is considered clear regardless of the score.
    Returns ``0.0`` when the image or the requested region cannot be read.
    """
    try:
        image = _open_grayscale(image_bytes)
    except Exception:
        return 0.0
    if box is not None:
        left = max(0, int(box.x0))
        top = max(0, int(box.y0))
        right = min(image.width, int(box.x1) + 1)
        bottom = min(image.height, int(box.y1) + 1)
        if right - left < 3 or bottom - top < 3:
            return 0.0
        image = image.crop((left, top, right, bottom))

    try:
        pixels = list(image.getdata())
    except Exception:
        return 0.0
    width, height = image.size
    if width < 3 or height < 3:
        return 0.0

    values = []
    for y in range(1, height - 1):
        row = y * width
        for x in range(1, width - 1):
            index = row + x
            laplacian = (
                4 * pixels[index]
                - pixels[index - 1]
                - pixels[index + 1]
                - pixels[index - width]
                - pixels[index + width]
            )
            values.append(laplacian)
    if not values:
        return 0.0
    mean = sum(values) / len(values)
    variance = sum((value - mean) ** 2 for value in values) / len(values)
    return float(variance)


# ---- [DF8 decode-area commands ---------------------------------------------


def _df8_frame(item: int, value: int) -> bytes:
    """Build one ``[DF8`` margin frame (4-digit value, per manual section 8.10)."""
    digits = f"{max(0, min(int(value), 9999)):04d}"
    payload = (
        f"DF8Q{item}Q{digits[0]}Q{digits[1]}Q{digits[2]}Q{digits[3]}"
    )
    return _ESC + b"[" + payload.encode("ascii") + _CR


def df8_margin_commands(
    box: BarcodeLocation, padding: int = DEFAULT_PADDING_PX
) -> list[bytes]:
    """Decode-area margin frames that restrict decoding to the barcode region.

    Margins are distances from the image edges (0=top, 1=right, 2=bottom,
    3=left).  The resulting decode window is the union of:

    - the located barcode inflated by ``padding``, and
    - a window of at least ``DF8_MIN_AREA_FRACTION`` of the frame, centered on
      the barcode.

    The minimum-fraction window guards against a coordinate mismatch between
    the capture image and the engine's (possibly wider) sensor: even if the
    exact pixel mapping is off, a comfortably large window around the barcode
    still contains it, while a full-frame barcode simply keeps the whole
    image (margins clamp to 0).
    """
    if box is None or not box.is_usable():
        return []
    pad = max(0, int(padding))
    cx = box.x0 + box.width / 2.0
    cy = box.y0 + box.height / 2.0
    half_w = max(
        box.width / 2.0 + pad,
        (CAPTURE_WIDTH * DF8_MIN_AREA_FRACTION) / 2.0,
    )
    half_h = max(
        box.height / 2.0 + pad,
        (CAPTURE_HEIGHT * DF8_MIN_AREA_FRACTION) / 2.0,
    )

    left = min(
        max(0, box.x0 - pad),
        max(0, int(math.floor(cx - half_w))),
    )
    top = min(
        max(0, box.y0 - pad),
        max(0, int(math.floor(cy - half_h))),
    )
    right = min(
        max(0, CAPTURE_WIDTH - (box.x1 + 1) - pad),
        max(0, int(math.floor(CAPTURE_WIDTH - (cx + half_w)))),
    )
    bottom = min(
        max(0, CAPTURE_HEIGHT - (box.y1 + 1) - pad),
        max(0, int(math.floor(CAPTURE_HEIGHT - (cy + half_h)))),
    )
    return [
        _df8_frame(_DF8_TOP, top),
        _df8_frame(_DF8_RIGHT, right),
        _df8_frame(_DF8_BOTTOM, bottom),
        _df8_frame(_DF8_LEFT, left),
    ]


def df8_reset_command() -> bytes:
    """Initialize the decode area in all directions (full image again)."""
    return _df8_frame(_DF8_RESET, 0)



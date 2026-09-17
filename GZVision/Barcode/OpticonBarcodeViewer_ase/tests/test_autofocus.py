"""Tests for the image-guided barcode location and decode-area commands.

Barcode frames come from the committed fixture image
``tests/fixtures/locatable_barcode.png`` (a Code128 barcode with the text
``1-123CD4-001-001`` on a 640x480 canvas).  The zxing-cpp writer is not used
at test time because its image buffer access crashes when PySide6 is loaded
in the same process; the reader - the only production code path - is safe and
is exercised directly.
"""

from __future__ import annotations

import io
import sys
from pathlib import Path


PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

from PIL import Image, ImageFilter

import autofocus
from autofocus import BarcodeLocation, df8_margin_commands, df8_reset_command, locate_barcode, sharpness_score

EXPECTED = "1-123CD4-001-001"
NON_WAFER = "NOTAWAFER"
FIXTURE_PATH = Path(__file__).resolve().parent / "fixtures" / "locatable_barcode.png"
NON_WAFER_FIXTURE_PATH = Path(__file__).resolve().parent / "fixtures" / "locatable_barcode_non_wafer.png"
# The barcode inside the fixture canvas, including its built-in quiet zones.
_FIXTURE_CROP = (200, 200, 431, 250)
_NON_WAFER_CROP = (200, 200, 354, 250)


def _fixture_barcode() -> Image.Image:
    return Image.open(FIXTURE_PATH).convert("L").crop(_FIXTURE_CROP)


def _non_wafer_fixture_barcode() -> Image.Image:
    return Image.open(NON_WAFER_FIXTURE_PATH).convert("L").crop(_NON_WAFER_CROP)


def _barcode_jpeg(at=(200, 200), canvas=(640, 480)) -> bytes:
    """Render the fixture barcode at ``at`` on a CCD-size canvas (JPEG)."""
    image = Image.new("L", canvas, 255)
    image.paste(_fixture_barcode(), at)
    buffer = io.BytesIO()
    image.save(buffer, "JPEG", quality=90)
    return buffer.getvalue()


def _blank_jpeg(canvas=(640, 480)) -> bytes:
    image = Image.new("L", canvas, 255)
    buffer = io.BytesIO()
    image.save(buffer, "JPEG", quality=90)
    return buffer.getvalue()


# ---- locate_barcode --------------------------------------------------------


def test_locate_finds_barcode_with_position_and_format():
    location = locate_barcode(_barcode_jpeg())
    assert location is not None
    assert location.text == EXPECTED
    assert location.format_name == "Code128"
    assert 0 <= location.x0 < location.x1 < 640
    assert 0 <= location.y0 < location.y1 < 480
    assert location.is_usable()


def test_locate_picks_the_largest_barcode_when_several_are_visible():
    image = Image.new("L", (640, 480), 255)
    small = _fixture_barcode().resize((100, 22))
    image.paste(small, (20, 20))
    image.paste(_fixture_barcode(), (200, 200))
    buffer = io.BytesIO()
    image.save(buffer, "JPEG", quality=90)

    location = locate_barcode(buffer.getvalue())
    assert location is not None
    assert location.text == EXPECTED
    assert location.x0 > 150  # the larger barcode (at x=200) won


def test_locate_prefers_wafer_pattern_over_larger_foreign_barcode():
    # A large foreign barcode dominates the frame, a small Wafer-ID barcode
    # sits in the corner.  With the wafer pattern the SMALL wafer code must
    # be chosen as the tuning target, without it the largest one wins.
    foreign = _non_wafer_fixture_barcode().resize(
        (_non_wafer_fixture_barcode().width * 3,
         _non_wafer_fixture_barcode().height * 3),
        Image.LANCZOS,
    )
    image = Image.new("L", (640, 480), 255)
    image.paste(foreign, (200, 200))
    image.paste(_fixture_barcode(), (20, 20))
    buffer = io.BytesIO()
    image.save(buffer, "JPEG", quality=90)
    frame = buffer.getvalue()

    wafer_pattern = "^(?P<seg1>[^-]+)-(?P<seg2>[^-]+)-(?P<seg3>[^-]+)-(?P<seg4>[^-]+)$"

    assert locate_barcode(frame).text == NON_WAFER  # largest wins by default
    located = locate_barcode(frame, wafer_pattern=wafer_pattern)
    assert located.text == EXPECTED  # wafer-like code preferred
    assert located.x0 < 150  # the small corner barcode was chosen


def test_locate_reads_rotated_barcode():
    rotated = _fixture_barcode().rotate(90, expand=True).resize((50, 231))
    image = Image.new("L", (640, 480), 255)
    image.paste(rotated, (300, 100))
    buffer = io.BytesIO()
    image.save(buffer, "JPEG", quality=90)

    location = locate_barcode(buffer.getvalue())
    assert location is not None
    assert location.text == EXPECTED


def test_locate_returns_none_for_blank_frame():
    assert locate_barcode(_blank_jpeg()) is None


def test_locate_returns_none_for_empty_payload():
    assert locate_barcode(b"") is None


def test_locate_degrades_gracefully_without_zxingcpp(monkeypatch):
    monkeypatch.setattr(autofocus, "zxingcpp", None)
    assert locate_barcode(_barcode_jpeg()) is None


# ---- sharpness_score -------------------------------------------------------


def test_sharpness_distinguishes_sharp_from_blurred_barcode():
    sharp = Image.open(io.BytesIO(_barcode_jpeg()))
    blurred = sharp.filter(ImageFilter.GaussianBlur(radius=4))
    sharp_buffer = io.BytesIO()
    blurred_buffer = io.BytesIO()
    sharp.save(sharp_buffer, "JPEG", quality=95)
    blurred.save(blurred_buffer, "JPEG", quality=95)

    sharp_score = sharpness_score(sharp_buffer.getvalue())
    blurred_score = sharpness_score(blurred_buffer.getvalue())

    assert sharp_score > 0
    assert blurred_score >= 0
    assert sharp_score > blurred_score


def test_sharpness_of_blank_image_is_zero():
    assert sharpness_score(_blank_jpeg()) == 0.0


def test_sharpness_of_invalid_payload_is_zero():
    assert sharpness_score(b"") == 0.0
    assert sharpness_score(b"not-an-image") == 0.0


# ---- [DF8 decode-area commands ---------------------------------------------


def test_df8_margin_frames_use_a_minimum_fraction_of_the_frame():
    # A small barcode must not produce a tiny decode window: the margins are
    # limited by DF8_MIN_AREA_FRACTION of the configured 1280x800 capture
    # frame (224 px half-width, 140 px half-height around the centre).  A
    # window that extends past an edge simply clamps to 0 on that side.
    box = BarcodeLocation(text=EXPECTED, format_name="Code128", x0=125, y0=100, x1=200, y1=150)
    frames = df8_margin_commands(box, padding=0)
    assert frames == [
        b"\x1b[DF8Q0Q0Q0Q0Q0\x0d",  # top margin 0 (window reaches the top edge)
        b"\x1b[DF8Q1Q0Q8Q9Q3\x0d",  # right margin 893
        b"\x1b[DF8Q2Q0Q5Q3Q5\x0d",  # bottom margin 535
        b"\x1b[DF8Q3Q0Q0Q0Q0\x0d",  # left margin 0 (window reaches the left edge)
    ]
    # The decode window must still contain the barcode box.
    decode_left = 0
    decode_right = 1280 - 893
    decode_top = 0
    decode_bottom = 800 - 535
    assert decode_left <= box.x0 and box.x1 < decode_right
    assert decode_top <= box.y0 and box.y1 < decode_bottom


def test_df8_reset_command_matches_the_manual():
    assert df8_reset_command() == b"\x1b[DF8Q4Q0Q0Q0Q0\x0d"


def test_margins_are_clamped_at_the_image_edges():
    # A barcode covering the whole 1280x800 frame leaves every margin 0.
    box = BarcodeLocation(text=EXPECTED, format_name="Code128", x0=0, y0=0, x1=1279, y1=799)
    frames = df8_margin_commands(box, padding=12)
    assert frames == [
        b"\x1b[DF8Q0Q0Q0Q0Q0\x0d",
        b"\x1b[DF8Q1Q0Q0Q0Q0\x0d",
        b"\x1b[DF8Q2Q0Q0Q0Q0\x0d",
        b"\x1b[DF8Q3Q0Q0Q0Q0\x0d",
    ]


def test_unusable_boxes_produce_no_commands():
    tiny = BarcodeLocation(text="", format_name="", x0=10, y0=10, x1=14, y1=12)
    assert df8_margin_commands(tiny) == []
    assert df8_margin_commands(None) == []



"""Unit tests for wafer_id.py (UV-300 Wafer-ID parsing)."""

import sys
from pathlib import Path


# Ensure the project root is importable when running pytest from anywhere.
PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

import app_config  # noqa: E402
import wafer_id  # noqa: E402


# ---------------------------------------------------------------------------
# parse_wafer_id
# ---------------------------------------------------------------------------

class TestParseWaferId:
    def test_standard_format_example(self):
        """Customer example: '1-123CD4-001-001' -> standard, folder '123CD4B001'."""
        result = wafer_id.parse_wafer_id("1-123CD4-001-001")
        assert result.is_standard is True
        assert result.segment2 == "123CD4"
        assert result.segment3 == "001"
        assert result.folder_name == "123CD4B001"

    def test_standard_format_strips_whitespace(self):
        result = wafer_id.parse_wafer_id("  1-123CD4-001-001  ")
        assert result.is_standard is True
        assert result.folder_name == "123CD4B001"

    def test_single_segment_is_nonstandard(self):
        result = wafer_id.parse_wafer_id("123CD4")
        assert result.is_standard is False
        assert result.segment2 is None
        assert result.segment3 is None
        assert result.folder_name is None

    def test_wrong_first_field_is_nonstandard(self):
        result = wafer_id.parse_wafer_id("A-123CD4-001-001")
        assert result.is_standard is False

    def test_wrong_separator_is_nonstandard(self):
        # Underscore instead of dash -> not standard
        result = wafer_id.parse_wafer_id("1_123CD4_001_001")
        assert result.is_standard is False

    def test_three_segments_is_nonstandard(self):
        result = wafer_id.parse_wafer_id("1-123CD4-001")
        assert result.is_standard is False

    def test_five_segments_is_nonstandard(self):
        result = wafer_id.parse_wafer_id("1-123CD4-001-001-999")
        assert result.is_standard is False

    def test_empty_string_is_nonstandard(self):
        result = wafer_id.parse_wafer_id("")
        assert result.is_standard is False

    def test_none_is_nonstandard(self):
        result = wafer_id.parse_wafer_id(None)
        assert result.is_standard is False

    def test_empty_segment_is_nonstandard(self):
        # Leading dash -> empty first segment
        result = wafer_id.parse_wafer_id("-123CD4-001-001")
        assert result.is_standard is False
        # Trailing dash -> empty last segment
        result = wafer_id.parse_wafer_id("1-123CD4-001-")
        assert result.is_standard is False
        # Double dash in middle -> empty segment
        result = wafer_id.parse_wafer_id("1-123CD4--001")
        assert result.is_standard is False

    def test_only_dashes_is_nonstandard(self):
        result = wafer_id.parse_wafer_id("---")
        assert result.is_standard is False


# ---------------------------------------------------------------------------
# build_folder_name
# ---------------------------------------------------------------------------

class TestBuildFolderName:
    def test_example(self):
        assert wafer_id.build_folder_name("123CD4", "001") == "123CD4B001"

    def test_alphanumeric(self):
        assert wafer_id.build_folder_name("AB12", "345") == "AB12B345"


# ---------------------------------------------------------------------------
# Custom pattern from config
# ---------------------------------------------------------------------------

class TestCustomPattern:
    def test_custom_pattern_3_segments(self, monkeypatch, tmp_path):
        """A custom pattern matching 3 segments should work."""
        custom_pattern = r"^(?P<seg1>[^-]+)-(?P<seg2>[^-]+)-(?P<seg3>[^-]+)$"
        monkeypatch.setattr(app_config, "get_wafer_id_pattern", lambda: custom_pattern)
        # Re-initialize the internal pattern cache by calling parse_wafer_id
        result = wafer_id.parse_wafer_id("ABC-123-XYZ")
        assert result.is_standard is True
        assert result.segment2 == "123"
        assert result.segment3 == "XYZ"
        assert result.folder_name == "123BXYZ"

    def test_custom_pattern_with_underscore(self, monkeypatch, tmp_path):
        """Custom pattern using underscore as separator."""
        custom_pattern = r"^(?P<seg1>[^_]+)_(?P<seg2>[^_]+)_(?P<seg3>[^_]+)_(?P<seg4>[^_]+)$"
        monkeypatch.setattr(app_config, "get_wafer_id_pattern", lambda: custom_pattern)
        result = wafer_id.parse_wafer_id("1_ABCD_002_003")
        assert result.is_standard is True
        assert result.segment2 == "ABCD"
        assert result.segment3 == "002"
        assert result.folder_name == "ABCDB002"

    def test_invalid_pattern_falls_back_to_default(self, monkeypatch):
        """An invalid regex pattern should fall back to the default 4-segment pattern."""
        monkeypatch.setattr(app_config, "get_wafer_id_pattern", lambda: r"*** invalid [")
        # Should not crash; should use default pattern
        result = wafer_id.parse_wafer_id("1-123CD4-001-001")
        assert result.is_standard is True
        assert result.folder_name == "123CD4B001"
        # A string that would match the invalid pattern (if it were valid) should
        # still be parsed with the default pattern
        result2 = wafer_id.parse_wafer_id("garbage")
        assert result2.is_standard is False


# ---------------------------------------------------------------------------
# resolve_target_folder
# ---------------------------------------------------------------------------

class TestResolveTargetFolder:
    def test_standard_format_uses_standard_root(self, tmp_path):
        root = tmp_path / "std"
        nonstd = tmp_path / "nonstd"
        path = wafer_id.resolve_target_folder(
            "1-123CD4-001-001",
            standard_root_path=str(root),
            nonstandard_path=str(nonstd),
        )
        assert path == root / "Standardized Format" / "1-123CD4-001-001"

    def test_nonstandard_format_uses_nonstandard_path(self, tmp_path):
        root = tmp_path / "std"
        nonstd = tmp_path / "nonstd"
        path = wafer_id.resolve_target_folder(
            "garbage",
            standard_root_path=str(root),
            nonstandard_path=str(nonstd),
        )
        assert path == root / "Non-Standardized Format" / "garbage"

    def test_none_wafer_id_uses_nonstandard_path(self, tmp_path):
        root = tmp_path / "std"
        nonstd = tmp_path / "nonstd"
        path = wafer_id.resolve_target_folder(
            None,
            standard_root_path=str(root),
            nonstandard_path=str(nonstd),
        )
        assert path == root / "Non-Standardized Format" / "Unknown"

    def test_empty_wafer_id_uses_nonstandard_path(self, tmp_path):
        root = tmp_path / "std"
        nonstd = tmp_path / "nonstd"
        path = wafer_id.resolve_target_folder(
            "",
            standard_root_path=str(root),
            nonstandard_path=str(nonstd),
        )
        assert path == root / "Non-Standardized Format" / "Unknown"

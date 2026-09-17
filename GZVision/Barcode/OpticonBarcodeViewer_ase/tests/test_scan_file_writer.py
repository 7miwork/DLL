"""Unit tests for scan_file_writer.py (UV-300 filename schema).

The customer schema is:

    <Substrate2D>#<WaferID>#<OperatorID>#<yyyyMMddHHmmss>.txt

Substrate 2D is always "Null". Automatic reads use "Null" for the manual
operator field; manual reads use the authenticated employee ID.
"""

import sys
from datetime import datetime
from pathlib import Path


PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

import scan_file_writer  # noqa: E402


# Fixed timestamp used across all filename tests so they are deterministic.
FIXED_TS = datetime(2026, 7, 29, 11, 22, 57)
FIXED_TS_STR = "20260729112257"


class TestBuildFilename:
    def test_automatic_scan_filename(self):
        """Automatic scan: Substrate=Null, WaferID, Operator=Null."""
        filename = scan_file_writer.build_filename(
            wafer_id_value="1-123CD4-001-001",
            operator_id=scan_file_writer.OPERATOR_NULL,
            timestamp=FIXED_TS,
        )
        assert filename == f"Null#1-123CD4-001-001#Null#{FIXED_TS_STR}.txt"

    def test_manual_entry_filename(self):
        """Manual entry: Substrate=Null, WaferID, Operator=login ID."""
        filename = scan_file_writer.build_filename(
            wafer_id_value="1-123CD4-001-001",
            operator_id="A12345",
            timestamp=FIXED_TS,
        )
        assert filename == f"Null#1-123CD4-001-001#A12345#{FIXED_TS_STR}.txt"

    def test_default_substrate_is_null(self):
        """If substrate_2d is not provided, it defaults to 'Null'."""
        filename = scan_file_writer.build_filename(
            wafer_id_value="1-123CD4-001-001",
            operator_id=scan_file_writer.OPERATOR_NULL,
            timestamp=FIXED_TS,
        )
        assert filename.startswith("Null#1-123CD4-001-001#Null#")

    def test_sanitization_replaces_separator_hash(self):
        """A '#' inside the Wafer ID must be sanitized to '_' so the schema isn't broken."""
        filename = scan_file_writer.build_filename(
            wafer_id_value="1-123CD4#001-001",
            operator_id=scan_file_writer.OPERATOR_NULL,
            timestamp=FIXED_TS,
        )
        assert "Null#1-123CD4_001-001#Null#" in filename
        assert filename.count("#") == 3

    def test_sanitization_replaces_invalid_chars(self):
        """Colons / backslashes / etc. are replaced with '_'."""
        filename = scan_file_writer.build_filename(
            wafer_id_value="1-12:CD4\\001",
            operator_id=scan_file_writer.OPERATOR_NULL,
            timestamp=FIXED_TS,
        )
        assert "Null#1-12_CD4_001#Null#" in filename
        field_part = filename.replace(f"#{FIXED_TS_STR}.txt", "")
        for bad in [":", "\\", "/", "*", "?", '"', "<", "|"]:
            assert bad not in field_part
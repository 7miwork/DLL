"""Data models for the Opticon Barcode Viewer application."""

from dataclasses import dataclass, field
from datetime import datetime


@dataclass
class Scan:
    """Represents a single decoded barcode scan result."""
    timestamp: datetime = field(default_factory=datetime.now)
    barcode_value: str = ""
    operator_id: str = ""
    status: str = "GOOD"  # "GOOD", "NG", or "GOOD (manual)"
    is_duplicate: bool = False
    is_manual: bool = False
    # UV-300 Wafer-ID storage fields
    wafer_id: str = ""  # The Wafer ID (same as barcode_value for UV-300)
    folder_path: str = ""  # Target folder path where file was saved
    saved_file_path: str = ""  # Full path of saved file
    save_status: str = "pending"  # "saved", "failed", or "pending"
    # Opticon image-capture field: full path to the captured JPEG ("" if none).
    image_path: str = ""
    input_source: str = ""  # Localized "Automatic" or "Manual input" for display

    def formatted_time(self) -> str:
        """Return timestamp as HH:mm:ss.fff for display."""
        return self.timestamp.strftime("%H:%M:%S.%f")[:12]
"""Production configuration for Opticon Barcode Viewer (UV-300 Wafer-ID storage).

This module is intentionally separate from ``settings.py``: ``settings.json``
stores window/UI state (operator-editable at runtime), whereas
``app_config.json`` is the production configuration maintained by the
manufacturing/IT team. The administrator supplies one scan-data root path.

On first start, if ``app_config.json`` does not exist, it is created with an
empty scan-storage root and the application reports a configuration error
until the administrator supplies the save location. The application then
creates ``Standardized Format`` and ``Non-Standardized Format`` below that
root, followed by one folder named after each barcode. TXT records and CCD
JPEG files are colocated in each barcode folder.
"""

import json
import sys
from pathlib import Path
from typing import Any, Dict


def _app_dir() -> Path:
    """Return the directory where the production ``app_config.json`` lives.

    - Dev mode (``python main.py``): the project root.
    - Frozen build: next to the ``.exe`` so the IT team can configure
      storage paths and they persist across runs.
    """
    if getattr(sys, "frozen", False):
        return Path(sys.executable).resolve().parent
    return Path(__file__).resolve().parent


CONFIG_FILE = _app_dir() / "app_config.json"

# Default values used when the config file is missing or corrupt.
# These are the *only* place where default paths live — they are never
# hard-coded elsewhere in the application code.
DEFAULT_CONFIG: Dict[str, Any] = {
    # The administrator selects one root. The application creates the two
    # category folders below it automatically.
    "scan_storage_root_path": "",
    # Legacy keys are retained for migration of older installations.
    "standard_root_path": "",
    "nonstandard_path": "",
    # Legacy image-root key retained for migration; images now always sit
    # beside the TXT file in the barcode folder.
    "image_storage_path": "",
    # Standardized example: 1-123CD4-001-001.
    "wafer_id_pattern": r"^(?P<seg1>[0-9]+)-(?P<seg2>[A-Za-z0-9]+)-(?P<seg3>[0-9]{3})-(?P<seg4>[0-9]{3})$",
    # Timeout in seconds after trigger before "no scan" is assumed
    # and manual entry (with login) is offered.
    "scan_timeout_seconds": 5,
    # Trigger source configuration
    "trigger_source_mode": "manual",
    "trigger_source_com_port": "",
    "trigger_source_baud_rate": 9600,
    "trigger_source_expected_string": "TRIGGER",
    # Auto Focus command identifier used by the UniversalTuningTool workflow.
    "autofocus_command": "AF",
    # CCD capture geometry.  Defaults capture the full 1280x800 sensor of the
    # MDI-5250/5350 family so the saved picture shows the whole field of view.
    # MDI-4x00/N210 engines (752x480 sensor) should use 752 / 480.
    "image_capture_width": 1280,
    "image_capture_height": 800,
    # Subsampling factor (1, 2 or 4): higher values shrink the transferred
    # picture (faster) at the cost of resolution.
    "image_capture_subsample": 1,
    # JPEG quality of the captured picture (5..100).
    "image_capture_jpeg_quality": 75,
}


def load() -> Dict[str, Any]:
    """Load production config from ``app_config.json``.

    If the file does not exist, it is created with default values.
    If the file is corrupt or missing keys, defaults are merged in.
    """
    if not CONFIG_FILE.exists():
        save(DEFAULT_CONFIG)
        return dict(DEFAULT_CONFIG)

    try:
        data = json.loads(CONFIG_FILE.read_text(encoding="utf-8"))
        if not isinstance(data, dict):
            return dict(DEFAULT_CONFIG)
        merged = dict(DEFAULT_CONFIG)
        merged.update(data)
        return merged
    except (json.JSONDecodeError, OSError):
        return dict(DEFAULT_CONFIG)


def save(config: Dict[str, Any]) -> None:
    """Save config dict to ``app_config.json``."""
    try:
        CONFIG_FILE.write_text(
            json.dumps(config, indent=2, ensure_ascii=False),
            encoding="utf-8",
        )
    except OSError:
        pass


def get_scan_storage_root_path() -> str:
    """Return the administrator-selected root for all scan data."""
    config = load()
    value = str(config.get("scan_storage_root_path", "") or "").strip()
    if value:
        return value
    # Migrate the old standard root as the parent of the new two-branch layout.
    return str(config.get("standard_root_path", "") or "").strip()


def set_scan_storage_root_path(path: str) -> None:
    """Persist the single administrator-selected scan-storage root."""
    _set_config_value("scan_storage_root_path", str(path or "").strip())


def get_standard_root_path() -> str:
    """Legacy accessor; new code should use get_scan_storage_root_path()."""
    return load().get("standard_root_path", DEFAULT_CONFIG["standard_root_path"])


def get_nonstandard_path() -> str:
    """Return the configured non-standard path from external JSON."""
    return load().get("nonstandard_path", DEFAULT_CONFIG["nonstandard_path"])


def get_image_storage_path() -> str:
    """Return the optional external CCD image root path.

    An empty value means that an image is saved beside its scan text file.
    """
    value = load().get("image_storage_path", DEFAULT_CONFIG["image_storage_path"])
    return str(value or "").strip()


def _int_setting(key: str, default: int, minimum: int, maximum: int) -> int:
    """Return an integer config value clamped to ``minimum..maximum``."""
    try:
        value = int(load().get(key, default))
    except (TypeError, ValueError):
        return default
    return max(minimum, min(value, maximum))


def get_image_capture_width() -> int:
    """Return the CCD capture crop width (full sensor by default)."""
    return _int_setting("image_capture_width", 1280, 1, 9999)


def get_image_capture_height() -> int:
    """Return the CCD capture crop height (full sensor by default)."""
    return _int_setting("image_capture_height", 800, 1, 9999)


def get_image_capture_subsample() -> int:
    """Return the CCD capture subsampling factor (1, 2 or 4)."""
    value = _int_setting("image_capture_subsample", 1, 1, 4)
    return value if value in (1, 2, 4) else 1


def get_image_capture_jpeg_quality() -> int:
    """Return the CCD capture JPEG quality (5..100)."""
    return _int_setting("image_capture_jpeg_quality", 75, 5, 100)


def get_wafer_id_pattern() -> str:
    """Return the configured Wafer-ID regex pattern, or the default.

    The pattern must contain named groups ``seg1``, ``seg2``, ``seg3``, ``seg4``.
    The folder name is built from ``<seg2>B<seg3>``.
    """
    return load().get("wafer_id_pattern", DEFAULT_CONFIG["wafer_id_pattern"])


def get_scan_timeout_seconds() -> int:
    """Return the configured scan timeout in seconds, or the default (5)."""
    val = load().get("scan_timeout_seconds", DEFAULT_CONFIG["scan_timeout_seconds"])
    try:
        return int(val)
    except (ValueError, TypeError):
        return int(DEFAULT_CONFIG["scan_timeout_seconds"])


def get_trigger_source_mode() -> str:
    """Return the trigger source mode: 'manual' or 'serial_line'."""
    return load().get("trigger_source_mode", "manual")


def get_trigger_source_com_port() -> str:
    """Return the configured COM port for the serial-line trigger source."""
    return load().get("trigger_source_com_port", "")


def get_trigger_source_baud_rate() -> int:
    """Return the configured baud rate for the serial-line trigger source."""
    val = load().get("trigger_source_baud_rate", 9600)
    try:
        return int(val)
    except (ValueError, TypeError):
        return 9600


def get_trigger_source_expected_string() -> str:
    """Return the expected trigger string for the serial-line source."""
    return str(load().get("trigger_source_expected_string", "TRIGGER") or "")


def _set_config_value(key: str, value: Any) -> None:
    """Persist one production setting without exposing file handling to the UI."""
    config = load()
    config[key] = value
    save(config)


def set_image_storage_path(path: str) -> None:
    """Persist the optional CCD image root path."""
    _set_config_value("image_storage_path", str(path or "").strip())


def set_trigger_source_mode(mode: str) -> None:
    """Persist a supported trigger-source mode."""
    _set_config_value("trigger_source_mode", mode if mode in {"manual", "serial_line"} else "manual")


def set_trigger_source_com_port(port: str) -> None:
    """Persist the sensor COM port."""
    _set_config_value("trigger_source_com_port", str(port or "").strip())


def set_trigger_source_baud_rate(baud_rate: int) -> None:
    """Persist the sensor baud rate as an integer."""
    try:
        value = int(baud_rate)
    except (TypeError, ValueError):
        value = 9600
    _set_config_value("trigger_source_baud_rate", value)


def set_trigger_source_expected_string(expected: str) -> None:
    """Persist the sensor trigger marker."""
    _set_config_value("trigger_source_expected_string", str(expected or ""))


def get_autofocus_command() -> str:
    """Return the configured scanner Auto Focus command identifier."""
    value = str(load().get("autofocus_command", DEFAULT_CONFIG["autofocus_command"]) or "")
    return value.strip() or DEFAULT_CONFIG["autofocus_command"]


def set_autofocus_command(command: str) -> None:
    """Persist the scanner Auto Focus command identifier."""
    _set_config_value("autofocus_command", str(command or "").strip())

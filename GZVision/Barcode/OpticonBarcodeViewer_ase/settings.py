"""Persistent settings for Opticon Barcode Viewer.

Stores window position/size and last-used COM port + baud rate as JSON.
"""

import json
import sys
from pathlib import Path


def _app_dir() -> Path:
    """Return the directory where mutable runtime files should live.

    - Dev mode (``python main.py``): the project root.
    - Frozen build: next to the ``.exe`` so settings persist across runs.
    """
    if getattr(sys, "frozen", False):
        return Path(sys.executable).resolve().parent
    return Path(__file__).resolve().parent


SETTINGS_FILE = _app_dir() / "settings.json"

DEFAULT_SETTINGS = {
    "window_x": -1,
    "window_y": -1,
    "window_width": 984,
    "window_height": 600,
    "window_maximized": False,
    "last_com_port": None,
    "last_baud_rate": 115200,
    "ignore_duplicates": True,
    "language": "en",
    "barcode_prefix": "",
    "barcode_suffix": "",
    "trigger_max_attempts": 5,
    "trigger_retry_delay_ms": 1000,
    "trigger_per_attempt_timeout_ms": 5000,
    "tutorial_completed": False,
}


def load() -> dict:
    """Load settings from JSON file, returning defaults if missing or corrupt."""
    try:
        if SETTINGS_FILE.exists():
            data = json.loads(SETTINGS_FILE.read_text(encoding="utf-8"))
            merged = dict(DEFAULT_SETTINGS)
            merged.update(data)
            return merged
    except (json.JSONDecodeError, OSError):
        pass
    return dict(DEFAULT_SETTINGS)


def save(settings: dict) -> None:
    """Save settings dict to JSON file."""
    try:
        SETTINGS_FILE.write_text(
            json.dumps(settings, indent=2, ensure_ascii=False),
            encoding="utf-8",
        )
    except OSError:
        pass
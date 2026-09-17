"""Wafer-ID validation and scan-storage routing.

A standardized Wafer ID follows the client pattern ``1-123CD4-001-001``:
number, alphanumeric equipment/code segment, three digits, and three digits.
Every other value is routed to the Non-Standardized Format branch.

The storage hierarchy is always::

    <scan_storage_root_path>/Standardized Format/<barcode>/...
    <scan_storage_root_path>/Non-Standardized Format/<barcode>/...

The barcode folder is sanitized only when the raw value contains a character
that Windows cannot use in a directory name. Normal barcode text is preserved.
"""

from __future__ import annotations

import logging
import re
from dataclasses import dataclass
from pathlib import Path
from typing import Optional, Tuple

import app_config

logger = logging.getLogger(__name__)

_DEFAULT_PATTERN_STR = (
    r"^(?P<seg1>[0-9]+)-(?P<seg2>[A-Za-z0-9]+)-"
    r"(?P<seg3>[0-9]{3})-(?P<seg4>[0-9]{3})$"
)
_DEFAULT_PATTERN = re.compile(_DEFAULT_PATTERN_STR)
STANDARDIZED_FOLDER = "Standardized Format"
NON_STANDARDIZED_FOLDER = "Non-Standardized Format"
_INVALID_FOLDER_CHARS = re.compile(r'[\\/:*?"<>|]')


def _get_pattern() -> re.Pattern:
    """Load the configured standardized-format regex with safe fallback."""
    pattern_str = app_config.get_wafer_id_pattern()
    if not pattern_str:
        return _DEFAULT_PATTERN
    try:
        return re.compile(pattern_str)
    except re.error as exc:
        logger.warning(
            "Invalid wafer_id_pattern in app_config.json (%s); using default: %s",
            pattern_str,
            exc,
        )
        return _DEFAULT_PATTERN


@dataclass(frozen=True)
class WaferIdParseResult:
    is_standard: bool
    segment2: Optional[str] = None
    segment3: Optional[str] = None
    folder_name: Optional[str] = None
    segments: Tuple[str, ...] = ()


def parse_wafer_id(wafer_id: Optional[str]) -> WaferIdParseResult:
    """Classify a raw barcode as standardized or non-standardized."""
    if wafer_id is None:
        return WaferIdParseResult(is_standard=False)

    text = str(wafer_id).strip()
    if not text:
        return WaferIdParseResult(is_standard=False)

    match = _get_pattern().fullmatch(text)
    if not match:
        return WaferIdParseResult(is_standard=False)

    groups = match.groupdict()
    try:
        segment2 = match.group("seg2")
        segment3 = match.group("seg3")
    except IndexError:
        return WaferIdParseResult(is_standard=False)

    segments = tuple(
        groups[key]
        for key in sorted(
            (key for key in groups if key.startswith("seg")),
            key=lambda key: int(key[3:]) if key[3:].isdigit() else 999,
        )
        if groups[key] is not None
    )
    return WaferIdParseResult(
        is_standard=True,
        segment2=segment2,
        segment3=segment3,
        # Retained for compatibility with older callers; storage now uses the
        # complete barcode as the directory name.
        folder_name=f"{segment2}B{segment3}",
        segments=segments,
    )


def split_wafer_id(wafer_id: Optional[str]) -> Tuple[str, ...]:
    result = parse_wafer_id(wafer_id)
    if result.is_standard:
        return result.segments
    if wafer_id is None:
        return ()
    return tuple(part for part in str(wafer_id).strip().split("-") if part)


def build_folder_name(segment2: str, segment3: str) -> str:
    """Legacy helper retained for compatibility with older integrations."""
    return f"{segment2}B{segment3}"


def barcode_folder_name(wafer_id: Optional[str]) -> str:
    """Return a safe directory name based on the complete barcode value."""
    text = str(wafer_id or "").strip()
    text = text.replace("\r", "_").replace("\n", "_")
    text = _INVALID_FOLDER_CHARS.sub("_", text)
    if text in {"", ".", ".."}:
        return "Unknown"
    return text[:180]


def _configured_storage_root(
    storage_root_path: Optional[str],
    legacy_standard_root: Optional[str],
    legacy_nonstandard_root: Optional[str],
) -> str:
    if str(storage_root_path or "").strip():
        return str(storage_root_path).strip()
    configured = app_config.get_scan_storage_root_path()
    if configured:
        return configured
    # Legacy compatibility: an old installation’s standard root becomes the
    # parent of the new two-branch layout. The new UI always writes the single
    # scan_storage_root_path value.
    if str(legacy_standard_root or "").strip():
        return str(legacy_standard_root).strip()
    if str(legacy_nonstandard_root or "").strip():
        return str(legacy_nonstandard_root).strip()
    return ""


def resolve_target_folder(
    wafer_id: Optional[str],
    storage_root_path: Optional[str] = None,
    standard_root_path: Optional[str] = None,
    nonstandard_path: Optional[str] = None,
) -> Path:
    """Return ``<root>/<category>/<barcode>`` without creating it."""
    root_text = _configured_storage_root(
        storage_root_path,
        standard_root_path,
        nonstandard_path,
    )
    if not root_text:
        raise ValueError("scan_storage_root_path is not configured in app_config.json")

    result = parse_wafer_id(wafer_id)
    category = STANDARDIZED_FOLDER if result.is_standard else NON_STANDARDIZED_FOLDER
    return Path(root_text).expanduser() / category / barcode_folder_name(wafer_id)

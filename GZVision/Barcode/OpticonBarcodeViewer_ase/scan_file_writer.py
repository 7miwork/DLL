"""Write one scan record and derive its colocated CCD image path.

The client-required filename schema is::

    Substrate 2D#Wafer ID#Manual Operator ID#yyyyMMddHHmmss.txt

For this machine the first field is always ``Null``. A normal equipment read
uses ``Null`` for the third field; a manual replacement uses the authenticated
employee ID. Both the TXT file and the CCD JPEG are stored in the same
barcode-named folder.
"""

from __future__ import annotations

import re
from datetime import datetime
from pathlib import Path
from typing import Optional, Tuple

import wafer_id

_INVALID_FILENAME_CHARS = re.compile(r'[\\/:*?"<>|]')
_FIELD_SEPARATOR = "#"
SUBSTRATE_2D_NULL = "Null"
OPERATOR_NULL = "Null"


def sanitize_field(value: str) -> str:
    """Return a value safe to embed as one filename field."""
    if value is None:
        return ""
    cleaned = str(value).replace(_FIELD_SEPARATOR, "_")
    return _INVALID_FILENAME_CHARS.sub("_", cleaned)


def build_filename(
    wafer_id_value: str,
    operator_id: str,
    timestamp: Optional[datetime] = None,
    substrate_2d: str = SUBSTRATE_2D_NULL,
) -> str:
    """Build ``Null#WaferID#OperatorID#yyyyMMddHHmmss.txt``."""
    if not str(operator_id or "").strip():
        raise ValueError("operator_id is required for every scan filename")
    if timestamp is None:
        timestamp = datetime.now()

    ts = timestamp.strftime("%Y%m%d%H%M%S")
    safe_substrate = sanitize_field(substrate_2d)
    safe_wafer = sanitize_field(wafer_id_value)
    safe_operator = sanitize_field(operator_id)
    return (
        f"{safe_substrate}{_FIELD_SEPARATOR}{safe_wafer}"
        f"{_FIELD_SEPARATOR}{safe_operator}{_FIELD_SEPARATOR}{ts}.txt"
    )


def build_file_content(wafer_id_value: str) -> str:
    """Return one Wafer-ID line followed by a newline."""
    value = str(wafer_id_value or "").replace("\r", " ").replace("\n", " ").strip()
    return f"{value}\n"


def _resolve_non_colliding_path(folder: Path, filename: str) -> Path:
    """Return a path that does not overwrite a prior same-second record."""
    target = folder / filename
    if not target.exists():
        return target

    stem, ext = filename.rsplit(".", 1) if "." in filename else (filename, "")
    counter = 1
    while True:
        candidate_name = f"{stem}({counter}).{ext}" if ext else f"{stem}({counter})"
        candidate = folder / candidate_name
        if not candidate.exists():
            return candidate
        counter += 1


def save_scan_file(
    wafer_id_value: str,
    operator_id: str,
    timestamp: Optional[datetime] = None,
    storage_root_path: Optional[str] = None,
    standard_root_path: Optional[str] = None,
    nonstandard_path: Optional[str] = None,
) -> Tuple[bool, str, Optional[Path]]:
    """Create the category and barcode folders and write one TXT record.

    The new preferred argument is ``storage_root_path``. The two legacy path
    arguments remain accepted so older integrations do not crash; routing is
    still normalized to the new two-branch hierarchy.
    """
    if timestamp is None:
        timestamp = datetime.now()
    if not str(wafer_id_value or "").strip():
        return False, "Wafer ID is empty", None

    raw = str(wafer_id_value)
    has_invalid = bool(_INVALID_FILENAME_CHARS.search(raw)) or (_FIELD_SEPARATOR in raw)

    try:
        folder = wafer_id.resolve_target_folder(
            wafer_id_value,
            storage_root_path=storage_root_path,
            standard_root_path=standard_root_path,
            nonstandard_path=nonstandard_path,
        )
        folder.mkdir(parents=True, exist_ok=True)

        filename = build_filename(wafer_id_value, operator_id, timestamp)
        target = _resolve_non_colliding_path(folder, filename)
        target.write_text(build_file_content(wafer_id_value), encoding="utf-8")

        if has_invalid:
            msg = f"Saved (sanitized invalid chars): {target}"
        else:
            msg = f"Saved: {target}"
        return True, msg, target
    except PermissionError as error:
        return False, f"Permission denied: {error}", None
    except OSError as error:
        return False, f"Save failed: {error}", None
    except Exception as error:  # pragma: no cover - defensive GUI boundary
        return False, f"Unexpected error: {error}", None


def image_path_for_scan(
    saved_text_path: str | Path,
    image_storage_path: Optional[str] = None,
) -> Path:
    """Return the CCD JPEG path beside the TXT record.

    ``image_storage_path`` is accepted for source compatibility but deliberately
    ignored: the client requirement is that the picture is stored inside the
    same barcode-named folder as its scan TXT file.
    """
    del image_storage_path
    return Path(saved_text_path).with_suffix(".jpg")

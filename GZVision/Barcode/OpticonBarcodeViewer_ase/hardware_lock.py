"""Hardware license lock for Opticon Barcode Viewer.

This module implements a hardware-bound license check whose behavior
is controlled by the build-time constant ``BUILD_MODE`` in
``build_config.py``.

Two strictly separated build types exist:

- **Portable build** (``BUILD_MODE == "portable"``):
  No license check at all. Runs on any PC. A ``license.lock`` file
  that happens to sit next to the executable is **completely ignored**.

- **Licensed build** (``BUILD_MODE == "licensed"``):
  A valid ``license.lock`` file MUST be present next to the executable.
  If the file is missing, empty, unreadable, or the hardware hash does
  not match, the application shows an error dialog and exits with
  code 1. There is **no fallback** to portable mode.

The fingerprint is a SHA-256 hash of the concatenation (joined with ``|``)
of the following WMI values:
    - Win32_BaseBoard.SerialNumber
    - Win32_BIOS.SerialNumber
    - Win32_Processor.ProcessorId
    - Win32_ComputerSystemProduct.UUID

To generate a ``license.lock`` for a specific PC, run
``generate_license_lock.py`` on that PC once.
"""

from __future__ import annotations

import hashlib
import subprocess
import sys
from pathlib import Path

from build_config import BUILD_MODE

# Name of the lock file that activates the hardware check.
LICENSE_LOCK_FILENAME = "license.lock"

# Timeout for PowerShell hardware query (seconds)
HARDWARE_QUERY_TIMEOUT = 10


def _get_app_dir() -> Path:
    """Return the directory where the application lives.

    - In dev mode (``python main.py``): the project root (where ``main.py`` is).
    - In a PyInstaller build (frozen): the directory of the ``.exe``.
    """
    if getattr(sys, "frozen", False):
        # PyInstaller: sys.executable points to the .exe
        return Path(sys.executable).resolve().parent
    # Dev mode: this file lives in the project root
    return Path(__file__).resolve().parent


def get_machine_fingerprint() -> str:
    """Compute a SHA-256 machine fingerprint from WMI hardware values.

    Uses a subprocess call to PowerShell ``Get-CimInstance`` (no pywin32/wmi
    dependency required). The four values are joined with ``|`` and hashed.

    Returns:
        The SHA-256 hex digest as a string.

    Raises:
        RuntimeError: If the WMI query fails or a value cannot be read.
    """
    ps_script = (
        "$ErrorActionPreference = 'Stop'; "
        "$bb = (Get-CimInstance Win32_BaseBoard).SerialNumber; "
        "$bios = (Get-CimInstance Win32_BIOS).SerialNumber; "
        "$cpu = (Get-CimInstance Win32_Processor).ProcessorId; "
        "$uuid = (Get-CimInstance Win32_ComputerSystemProduct).UUID; "
        "Write-Output (\"$bb|$bios|$cpu|$uuid\")"
    )

    try:
        result = subprocess.run(
            ["powershell", "-NoProfile", "-NonInteractive", "-Command", ps_script],
            capture_output=True,
            text=True,
            timeout=HARDWARE_QUERY_TIMEOUT,
            check=True,
        )
    except subprocess.TimeoutExpired as exc:
        raise RuntimeError("timeout") from exc
    except subprocess.CalledProcessError as exc:
        raise RuntimeError(
            f"Hardware fingerprint query failed (PowerShell exit {exc.returncode}): "
            f"{exc.stderr.strip()}"
        ) from exc
    except OSError as exc:
        raise RuntimeError(f"os_error: {exc}") from exc

    raw = result.stdout.strip()
    if not raw:
        raise RuntimeError("no_data")

    # Hash the concatenated values
    return hashlib.sha256(raw.encode("utf-8")).hexdigest()


def get_license_status() -> str:
    """Return the current license status without exiting the app.

    This is purely informational and does NOT trigger the exit behavior of
    :func:`check_hardware_lock`. It is called separately for the status
    indicator in the main window.

    Returns:
        One of:
        - ``"portable"``  → portable build (always, regardless of license.lock)
        - ``"licensed"``  → licensed build AND license.lock present AND hash matches
        - ``"invalid"``   → licensed build but license.lock missing/empty/wrong
    """
    if BUILD_MODE == "portable":
        return "portable"

    # --- licensed build ---
    app_dir = _get_app_dir()
    lock_file = app_dir / LICENSE_LOCK_FILENAME

    if not lock_file.exists():
        return "invalid"

    try:
        expected = lock_file.read_text(encoding="utf-8").strip()
    except OSError:
        return "invalid"

    if not expected:
        return "invalid"

    try:
        current = get_machine_fingerprint()
    except RuntimeError:
        return "invalid"

    if current != expected:
        return "invalid"

    return "licensed"


def check_hardware_lock() -> None:
    """Perform the hardware license check based on BUILD_MODE.

    - **Portable build**: returns immediately, no check, ignores license.lock.
    - **Licensed build**: ``license.lock`` MUST be present and valid.
      Missing file → same error dialog + ``sys.exit(1)`` as a wrong hash.
      No fallback to portable mode.

    Raises:
        SystemExit: If the license check fails (licensed build only).
    """
    if BUILD_MODE == "portable":
        # Portable build: no check at all, ignore any license.lock.
        return

    # --- licensed build ---
    app_dir = _get_app_dir()
    lock_file = app_dir / LICENSE_LOCK_FILENAME

    # Missing file → error + exit (NO fallback to portable mode).
    if not lock_file.exists():
        _show_license_error_and_exit("missing_lock")

    # Read the expected hash from the lock file.
    try:
        expected = lock_file.read_text(encoding="utf-8").strip()
    except OSError:
        _show_license_error_and_exit("read_lock_failed")

    if not expected:
        _show_license_error_and_exit("empty_lock")

    try:
        current = get_machine_fingerprint()
    except RuntimeError as exc:
        # If we cannot compute the fingerprint, treat as not licensed.
        _show_license_error_and_exit(str(exc))

    if current != expected:
        _show_license_error_and_exit("hash_mismatch")


def _show_license_error_and_exit(error_code: str = "hash_mismatch") -> None:
    """Show the license error dialog and exit the application.

    Args:
        error_code: One of "missing_lock", "read_lock_failed", "empty_lock",
                    "timeout", "os_error: ...", "no_data", "hash_mismatch"
    """
    # Imported lazily so this module can be used without a QApplication
    # (e.g. by generate_license_lock.py).
    from PySide6.QtWidgets import QMessageBox
    import i18n

    # Map error codes to i18n keys
    if error_code == "timeout":
        title = i18n.tr("license_error_title")
        text = i18n.tr("license_error_timeout")
    elif error_code.startswith("os_error:"):
        title = i18n.tr("license_error_title")
        text = i18n.tr("license_error_hardware_query").format(error=error_code[9:])
    elif error_code == "no_data":
        title = i18n.tr("license_error_title")
        text = i18n.tr("license_error_no_data")
    elif error_code == "missing_lock":
        title = i18n.tr("license_error_title")
        text = i18n.tr("license_error_not_licensed")
    elif error_code == "read_lock_failed":
        title = i18n.tr("license_error_title")
        text = i18n.tr("license_error_not_licensed")
    elif error_code == "empty_lock":
        title = i18n.tr("license_error_title")
        text = i18n.tr("license_error_not_licensed")
    else:  # hash_mismatch or any other
        title = i18n.tr("license_error_title")
        text = i18n.tr("license_error_not_licensed")

    msg = QMessageBox()
    msg.setIcon(QMessageBox.Critical)
    msg.setWindowTitle(title)
    msg.setText(text)
    msg.exec()
    sys.exit(1)

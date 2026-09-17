#!/usr/bin/env python3
"""Real .exe verification script for Opticon Barcode Viewer.

Tests the actual built .exe files (not Python, not mocked):
a1) Portable.exe without license.lock → should start (main window visible)
a2) Portable.exe with wrong license.lock → should start (main window visible)
b1) Licensed.exe without license.lock → should show error dialog and exit
b2) Licensed.exe with correct license.lock → should start (main window visible)
b3) Licensed.exe with wrong license.lock → should show error dialog and exit
"""

import subprocess
import sys
import time
from pathlib import Path

PROJECT_DIR = Path(__file__).resolve().parent.parent
DIST_DIR = PROJECT_DIR / "dist"
PORTABLE_EXE = DIST_DIR / "OpticonBarcodeViewer_Portable.exe"
LICENSED_EXE = DIST_DIR / "OpticonBarcodeViewer_Licensed.exe"

results = []


def kill_all_opticon_processes():
    """Kill ALL OpticonBarcodeViewer processes (including child processes)."""
    try:
        subprocess.run(
            ["taskkill", "/F", "/IM", "OpticonBarcodeViewer_Portable.exe"],
            capture_output=True, timeout=5
        )
        subprocess.run(
            ["taskkill", "/F", "/IM", "OpticonBarcodeViewer_Licensed.exe"],
            capture_output=True, timeout=5
        )
        time.sleep(1)
    except Exception:
        pass


def get_window_titles():
    """Get all window titles using PowerShell."""
    ps_cmd = "Get-Process | Where-Object { $_.MainWindowTitle -ne '' } | Select-Object -ExpandProperty MainWindowTitle"
    try:
        result = subprocess.run(
            ["powershell", "-NoProfile", "-NonInteractive", "-Command", ps_cmd],
            capture_output=True, text=True, timeout=10
        )
        titles = [t.strip() for t in result.stdout.strip().split("\n") if t.strip()]
        return titles
    except Exception:
        return []


def start_exe_and_check(exe_path, test_id, expected, expect_success, timeout=10):
    """Start an .exe, wait, check windows, kill it. Return result tuple."""
    print(f"\n--- {test_id}: Starting {exe_path.name} ---")

    # Kill any leftover processes first
    kill_all_opticon_processes()
    # Wait for processes to fully terminate
    time.sleep(3)

    # Start the process
    proc = subprocess.Popen(
        [str(exe_path)],
        creationflags=subprocess.CREATE_NEW_PROCESS_GROUP,
    )
    print(f"  Process started, PID={proc.pid}")

    # Poll for windows multiple times
    titles = []
    main_window_found = False
    license_error_found = False
    is_alive = True

    for attempt in range(5):
        time.sleep(3)
        poll = proc.poll()
        is_alive = poll is None
        titles = get_window_titles()
        main_window_found = any("Opticon Barcode Viewer" in t for t in titles)
        license_error_found = any("License" in t for t in titles)
        print(f"  Attempt {attempt+1}: alive={is_alive}, titles={titles}")
        if main_window_found or license_error_found or not is_alive:
            break

    print(f"  Final: Process alive: {is_alive}")
    print(f"  Final: Window titles: {titles}")
    print(f"  Main window found: {main_window_found}")
    print(f"  License error found: {license_error_found}")

    # Determine result
    main_window_found = any("Opticon Barcode Viewer" in t for t in titles)
    license_error_found = any("License" in t for t in titles)

    if expect_success:
        # Should show main window
        if main_window_found and not license_error_found:
            actual = "Main window appeared"
            status = "OK"
        elif license_error_found:
            actual = "License error dialog appeared (UNEXPECTED)"
            status = "FAIL"
        elif not is_alive:
            actual = "Process exited (UNEXPECTED)"
            status = "FAIL"
        else:
            actual = f"Process alive but no main window found. Titles: {titles}"
            status = "FAIL"
    else:
        # Should show license error dialog and/or exit
        if license_error_found:
            actual = "License error dialog appeared"
            status = "OK"
        elif not is_alive:
            actual = "Process exited (likely showed error and was dismissed)"
            status = "OK"
        elif main_window_found:
            actual = "Main window appeared (UNEXPECTED - should have failed)"
            status = "FAIL"
        else:
            actual = f"Process alive, no error dialog. Titles: {titles}"
            status = "FAIL"

    # Kill the process and all children
    kill_all_opticon_processes()

    results.append((test_id, expected, actual, status))
    print(f"  Result: {status} - {actual}")
    return status == "OK"


def generate_real_license_lock(target_dir):
    """Generate a real license.lock for this PC in target_dir."""
    # Run generate_license_lock.py
    result = subprocess.run(
        [sys.executable, str(PROJECT_DIR / "generate_license_lock.py")],
        capture_output=True, text=True, timeout=60,
        cwd=str(PROJECT_DIR)
    )
    print(f"  generate_license_lock.py stdout: {result.stdout.strip()}")
    if result.stderr.strip():
        print(f"  generate_license_lock.py stderr: {result.stderr.strip()}")

    # The script creates license.lock in the project dir
    src_lock = PROJECT_DIR / "license.lock"
    if src_lock.exists():
        # Copy to target dir
        dest_lock = Path(target_dir) / "license.lock"
        content = src_lock.read_text(encoding="utf-8")
        dest_lock.write_text(content, encoding="utf-8")
        print(f"  license.lock created at: {dest_lock}")
        print(f"  Content (first 20 chars): {content[:20]}...")
        return True
    else:
        print("  ERROR: license.lock was not generated!")
        return False


def cleanup_license_lock(directory):
    """Remove license.lock from a directory if it exists."""
    lock_file = Path(directory) / "license.lock"
    if lock_file.exists():
        lock_file.unlink()
        print(f"  Cleaned up: {lock_file}")
    else:
        print(f"  No license.lock to clean in: {directory}")


def main():
    print("=" * 70)
    print("REAL .exe VERIFICATION TEST")
    print("=" * 70)

    # Verify .exe files exist
    if not PORTABLE_EXE.exists():
        print(f"ERROR: {PORTABLE_EXE} not found!")
        return 1
    if not LICENSED_EXE.exists():
        print(f"ERROR: {LICENSED_EXE} not found!")
        return 1

    print(f"Portable exe: {PORTABLE_EXE} ({PORTABLE_EXE.stat().st_size / 1024 / 1024:.1f} MB)")
    print(f"Licensed exe: {LICENSED_EXE} ({LICENSED_EXE.stat().st_size / 1024 / 1024:.1f} MB)")

    # Kill any leftover processes
    kill_all_opticon_processes()

    # --- a1: Portable without license.lock ---
    print("\n" + "=" * 70)
    print("a1: Portable.exe WITHOUT license.lock -> should start normally")
    print("=" * 70)
    cleanup_license_lock(DIST_DIR)
    start_exe_and_check(
        PORTABLE_EXE, "a1",
        "Portable, no lock -> main window",
        expect_success=True,
        timeout=10  # Longer for first extraction
    )

    # --- a2: Portable with wrong license.lock ---
    print("\n" + "=" * 70)
    print("a2: Portable.exe WITH wrong license.lock -> should start normally (ignore)")
    print("=" * 70)
    wrong_lock = DIST_DIR / "license.lock"
    wrong_lock.write_text("0123456789abcdef_wrong_hash", encoding="utf-8")
    print(f"  Created wrong license.lock: {wrong_lock}")
    start_exe_and_check(
        PORTABLE_EXE, "a2",
        "Portable, wrong lock -> main window (ignored)",
        expect_success=True
    )
    cleanup_license_lock(DIST_DIR)

    # --- b1: Licensed without license.lock ---
    print("\n" + "=" * 70)
    print("b1: Licensed.exe WITHOUT license.lock -> should show error and exit")
    print("=" * 70)
    cleanup_license_lock(DIST_DIR)
    start_exe_and_check(
        LICENSED_EXE, "b1",
        "Licensed, no lock -> error dialog / exit",
        expect_success=False
    )

    # --- b2: Licensed with correct license.lock ---
    print("\n" + "=" * 70)
    print("b2: Licensed.exe WITH correct license.lock -> should start normally")
    print("=" * 70)
    print("  Generating real license.lock for this PC...")
    if generate_real_license_lock(DIST_DIR):
        start_exe_and_check(
            LICENSED_EXE, "b2",
            "Licensed, correct lock -> main window",
            expect_success=True
        )
    else:
        results.append(("b2", "Licensed, correct lock -> main window", "Could not generate license.lock", "FAIL"))
    cleanup_license_lock(DIST_DIR)

    # --- b3: Licensed with wrong license.lock ---
    print("\n" + "=" * 70)
    print("b3: Licensed.exe WITH wrong license.lock -> should show error and exit")
    print("=" * 70)
    wrong_lock = DIST_DIR / "license.lock"
    wrong_lock.write_text("0123456789abcdef_wrong_hash", encoding="utf-8")
    print(f"  Created wrong license.lock: {wrong_lock}")
    start_exe_and_check(
        LICENSED_EXE, "b3",
        "Licensed, wrong lock -> error dialog / exit",
        expect_success=False
    )
    cleanup_license_lock(DIST_DIR)

    # Also clean up license.lock from project dir if generate_license_lock created one
    cleanup_license_lock(PROJECT_DIR)

    # Final cleanup
    kill_all_opticon_processes()

    # --- Summary ---
    print("\n" + "=" * 80)
    print(f"{'Test':<5} | {'Expected':<50} | {'Actual':<45} | {'Result':<6}")
    print("-" * 80)
    for test_id, expected, actual, status in results:
        print(f"{test_id:<5} | {expected:<50} | {actual:<45} | {status:<6}")
    print("=" * 80)

    failures = [r for r in results if r[3] == "FAIL"]
    if failures:
        print(f"\n{len(failures)} test(s) FAILED!")
        return 1
    else:
        print(f"\nAll {len(results)} tests PASSED!")
        return 0


if __name__ == "__main__":
    sys.exit(main())
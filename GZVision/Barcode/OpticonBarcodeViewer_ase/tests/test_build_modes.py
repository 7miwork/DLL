#!/usr/bin/env python3
"""Test script to verify hardware_lock behavior with both BUILD_MODE values.

Tests:
a1) Portable build, no license.lock → should run (return normally)
a2) Portable build, with wrong license.lock → should run (ignore it)
b1) Licensed build, no license.lock → should exit(1)
b2) Licensed build, with correct license.lock → should run
b3) Licensed build, with wrong license.lock → should exit(1)
"""

import sys
import tempfile
from pathlib import Path
from unittest.mock import patch

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

# We need to test hardware_lock without actually calling sys.exit
# or showing QMessageBox, so we'll mock those.

results = []

def test_portable_no_lock():
    """a1: Portable build, no license.lock → should run normally."""
    import importlib
    import build_config
    build_config.BUILD_MODE = "portable"
    import hardware_lock
    importlib.reload(hardware_lock)
    
    # Create temp dir without license.lock
    with tempfile.TemporaryDirectory() as tmpdir:
        with patch.object(hardware_lock, '_get_app_dir', return_value=Path(tmpdir)):
            with patch.object(hardware_lock, 'get_machine_fingerprint', return_value="fake_hash"):
                try:
                    hardware_lock.check_hardware_lock()
                    results.append(("a1", "Portable, no lock → runs", "Ran normally", "OK"))
                except SystemExit:
                    results.append(("a1", "Portable, no lock → runs", "EXITED", "FAIL"))

def test_portable_wrong_lock():
    """a2: Portable build, with wrong license.lock → should run normally (ignore it)."""
    import importlib
    import build_config
    build_config.BUILD_MODE = "portable"
    import hardware_lock
    importlib.reload(hardware_lock)
    
    with tempfile.TemporaryDirectory() as tmpdir:
        # Create a wrong license.lock
        (Path(tmpdir) / "license.lock").write_text("wrong_hash", encoding="utf-8")
        
        with patch.object(hardware_lock, '_get_app_dir', return_value=Path(tmpdir)):
            with patch.object(hardware_lock, 'get_machine_fingerprint', return_value="correct_hash"):
                try:
                    hardware_lock.check_hardware_lock()
                    results.append(("a2", "Portable, wrong lock → runs", "Ran normally", "OK"))
                except SystemExit:
                    results.append(("a2", "Portable, wrong lock → runs", "EXITED", "FAIL"))

def test_licensed_no_lock():
    """b1: Licensed build, no license.lock → should exit(1)."""
    import importlib
    import build_config
    build_config.BUILD_MODE = "licensed"
    import hardware_lock
    importlib.reload(hardware_lock)
    
    with tempfile.TemporaryDirectory() as tmpdir:
        with patch.object(hardware_lock, '_get_app_dir', return_value=Path(tmpdir)):
            with patch.object(hardware_lock, 'get_machine_fingerprint', return_value="fake_hash"):
                # Mock QMessageBox to avoid GUI
                with patch('PySide6.QtWidgets.QMessageBox'):
                    try:
                        hardware_lock.check_hardware_lock()
                        results.append(("b1", "Licensed, no lock → exit(1)", "Ran normally", "FAIL"))
                    except SystemExit as e:
                        if e.code == 1:
                            results.append(("b1", "Licensed, no lock → exit(1)", "Exited with code 1", "OK"))
                        else:
                            results.append(("b1", "Licensed, no lock → exit(1)", f"Exited with code {e.code}", "FAIL"))

def test_licensed_correct_lock():
    """b2: Licensed build, with correct license.lock → should run normally."""
    import importlib
    import build_config
    build_config.BUILD_MODE = "licensed"
    import hardware_lock
    importlib.reload(hardware_lock)
    
    with tempfile.TemporaryDirectory() as tmpdir:
        # Create a correct license.lock
        (Path(tmpdir) / "license.lock").write_text("correct_hash", encoding="utf-8")
        
        with patch.object(hardware_lock, '_get_app_dir', return_value=Path(tmpdir)):
            with patch.object(hardware_lock, 'get_machine_fingerprint', return_value="correct_hash"):
                try:
                    hardware_lock.check_hardware_lock()
                    results.append(("b2", "Licensed, correct lock → runs", "Ran normally", "OK"))
                except SystemExit:
                    results.append(("b2", "Licensed, correct lock → runs", "EXITED", "FAIL"))

def test_licensed_wrong_lock():
    """b3: Licensed build, with wrong license.lock → should exit(1)."""
    import importlib
    import build_config
    build_config.BUILD_MODE = "licensed"
    import hardware_lock
    importlib.reload(hardware_lock)
    
    with tempfile.TemporaryDirectory() as tmpdir:
        # Create a wrong license.lock
        (Path(tmpdir) / "license.lock").write_text("wrong_hash", encoding="utf-8")
        
        with patch.object(hardware_lock, '_get_app_dir', return_value=Path(tmpdir)):
            with patch.object(hardware_lock, 'get_machine_fingerprint', return_value="correct_hash"):
                # Mock QMessageBox to avoid GUI
                with patch('PySide6.QtWidgets.QMessageBox'):
                    try:
                        hardware_lock.check_hardware_lock()
                        results.append(("b3", "Licensed, wrong lock → exit(1)", "Ran normally", "FAIL"))
                    except SystemExit as e:
                        if e.code == 1:
                            results.append(("b3", "Licensed, wrong lock → exit(1)", "Exited with code 1", "OK"))
                        else:
                            results.append(("b3", "Licensed, wrong lock → exit(1)", f"Exited with code {e.code}", "FAIL"))

def test_get_license_status():
    """Test get_license_status() for both modes."""
    import importlib
    import build_config
    import hardware_lock
    
    # Portable mode
    build_config.BUILD_MODE = "portable"
    importlib.reload(hardware_lock)
    with tempfile.TemporaryDirectory() as tmpdir:
        (Path(tmpdir) / "license.lock").write_text("wrong", encoding="utf-8")
        with patch.object(hardware_lock, '_get_app_dir', return_value=Path(tmpdir)):
            status = hardware_lock.get_license_status()
            if status == "portable":
                results.append(("s1", "get_license_status portable → 'portable'", f"'{status}'", "OK"))
            else:
                results.append(("s1", "get_license_status portable → 'portable'", f"'{status}'", "FAIL"))
    
    # Licensed mode, no lock
    build_config.BUILD_MODE = "licensed"
    importlib.reload(hardware_lock)
    with tempfile.TemporaryDirectory() as tmpdir:
        with patch.object(hardware_lock, '_get_app_dir', return_value=Path(tmpdir)):
            status = hardware_lock.get_license_status()
            if status == "invalid":
                results.append(("s2", "get_license_status licensed, no lock → 'invalid'", f"'{status}'", "OK"))
            else:
                results.append(("s2", "get_license_status licensed, no lock → 'invalid'", f"'{status}'", "FAIL"))
    
    # Licensed mode, correct lock
    with tempfile.TemporaryDirectory() as tmpdir:
        (Path(tmpdir) / "license.lock").write_text("correct_hash", encoding="utf-8")
        with patch.object(hardware_lock, '_get_app_dir', return_value=Path(tmpdir)):
            with patch.object(hardware_lock, 'get_machine_fingerprint', return_value="correct_hash"):
                status = hardware_lock.get_license_status()
                if status == "licensed":
                    results.append(("s3", "get_license_status licensed, correct → 'licensed'", f"'{status}'", "OK"))
                else:
                    results.append(("s3", "get_license_status licensed, correct → 'licensed'", f"'{status}'", "FAIL"))

if __name__ == "__main__":
    # Add project dir to path
    sys.path.insert(0, str(Path(__file__).resolve().parent.parent))
    
    test_portable_no_lock()
    test_portable_wrong_lock()
    test_licensed_no_lock()
    test_licensed_correct_lock()
    test_licensed_wrong_lock()
    test_get_license_status()
    
    # Restore safe default
    import build_config
    build_config.BUILD_MODE = "portable"
    
    print("\n" + "=" * 80)
    print(f"{'Test':<5} | {'Expected':<45} | {'Actual':<20} | {'Result':<6}")
    print("-" * 80)
    for test_id, expected, actual, result in results:
        print(f"{test_id:<5} | {expected:<45} | {actual:<20} | {result:<6}")
    print("=" * 80)
    
    failures = [r for r in results if r[3] == "FAIL"]
    if failures:
        print(f"\n{len(failures)} test(s) FAILED!")
        sys.exit(1)
    else:
        print(f"\nAll {len(results)} tests PASSED!")
        sys.exit(0)
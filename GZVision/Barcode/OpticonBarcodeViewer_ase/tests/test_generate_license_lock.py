"""Tests for creation of a hardware-bound license.lock file."""

from __future__ import annotations

import sys
from pathlib import Path

import pytest

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

from generate_license_lock import create_license_lock, normalize_fingerprint


@pytest.mark.parametrize("value", ["", "not-a-hash", "a" * 63, "g" * 64])
def test_normalize_fingerprint_rejects_invalid_sha256_values(value: str):
    with pytest.raises(ValueError):
        normalize_fingerprint(value)


def test_create_license_lock_writes_the_given_fingerprint(tmp_path: Path):
    lock_path = create_license_lock(tmp_path, "a" * 64, overwrite=False)

    assert lock_path == tmp_path / "license.lock"
    assert lock_path.read_text(encoding="utf-8") == ("a" * 64) + "\n"


def test_create_license_lock_preserves_an_existing_file_without_force(tmp_path: Path):
    lock_path = tmp_path / "license.lock"
    lock_path.write_text("existing\n", encoding="utf-8")

    with pytest.raises(FileExistsError):
        create_license_lock(tmp_path, "b" * 64, overwrite=False)

    assert lock_path.read_text(encoding="utf-8") == "existing\n"


def test_create_license_lock_replaces_an_existing_file_only_when_forced(tmp_path: Path):
    lock_path = tmp_path / "license.lock"
    lock_path.write_text("old\n", encoding="utf-8")

    create_license_lock(tmp_path, "c" * 64, overwrite=True)

    assert lock_path.read_text(encoding="utf-8") == ("c" * 64) + "\n"

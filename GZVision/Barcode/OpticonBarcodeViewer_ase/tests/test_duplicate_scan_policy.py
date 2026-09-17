"""Tests for the duplicate-scan policy used by MainWindow."""

from __future__ import annotations

import sys
from pathlib import Path

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

from main_window import MainWindow


class _CheckBox:
    def __init__(self, checked: bool):
        self.checked = checked

    def isChecked(self) -> bool:
        return self.checked


class _PolicyObject:
    _chk_ignore_dupes = _CheckBox(True)
    _pending_ng_row = None
    _seen_barcode_values = {"ABC-123"}

    _should_ignore_duplicate = MainWindow._should_ignore_duplicate


def test_duplicate_is_ignored_before_processing_when_enabled():
    assert _PolicyObject()._should_ignore_duplicate("  ABC-123  ") is True
    assert _PolicyObject()._should_ignore_duplicate("NEW-001") is False


def test_duplicate_policy_is_disabled_when_checkbox_is_off():
    policy = _PolicyObject()
    policy._chk_ignore_dupes.checked = False
    assert policy._should_ignore_duplicate("ABC-123") is False


def test_open_ng_retry_is_allowed_even_for_an_existing_barcode():
    policy = _PolicyObject()
    policy._pending_ng_row = 0
    assert policy._should_ignore_duplicate("ABC-123") is False

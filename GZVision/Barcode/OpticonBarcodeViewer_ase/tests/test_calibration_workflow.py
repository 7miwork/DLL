"""Tests for the image-guided CCD calibration workflow.

The workflow phases: Auto Focus (best-effort) -> locate (find THE barcode in
a CCD frame and restrict the engine's decode area to it) -> Auto Tuning (DT1,
which can then only read that barcode) -> verify (capture again and confirm
the barcode is clear).  Engines whose firmware ignores the Auto Focus command
must not prevent the documented tuning from running.
"""

from __future__ import annotations

from unittest.mock import MagicMock

import i18n
import app_config
from main_window import (
    CALIBRATION_CAPTURE_TIMEOUT_MS,
    CALIBRATION_LOCATE_ATTEMPTS,
    CALIBRATION_TUNING_ATTEMPTS,
    TUNING_CMDS,
    MainWindow,
    _CalibrationCapture,
)
from test_autofocus import _barcode_jpeg, _blank_jpeg


EXPECTED = "1-123CD4-001-001"


class _FakeTimer:
    def __init__(self):
        self.stopped = 0
        self.started_with = None

    def stop(self):
        self.stopped += 1

    def start(self, milliseconds):
        self.started_with = milliseconds


class _FakeStatusBar:
    def __init__(self):
        self.messages = []

    def showMessage(self, message):
        self.messages.append(message)


def _calibration_window(phase: str = "autofocus"):
    window = MainWindow.__new__(MainWindow)
    window._combined_calibration_active = True
    window._calibration_phase = phase
    window._calibration_autofocus_command = "AF"
    window._calibration_autofocus_answered = False
    window._calibration_autofocus_ok = False
    window._calibration_rejection_line = ""
    window._calibration_barcode = None
    window._calibration_read_data = ""
    window._calibration_decode_area_active = False
    window._calibration_locate_attempt = 0
    window._calibration_tuning_attempt = 0
    window._calibration_verify_attempt = 0
    window._calibration_relocate_retunes = 0
    window._calibration_timeout_timer = _FakeTimer()
    window._tuning_response_count = 0
    window._tuning_result_value = ""
    window._worker = MagicMock()
    window._worker.is_connected.return_value = True
    window._worker.request_image_capture.return_value = True
    window._worker.send_raw_command.return_value = True
    window._tuning_result_set = MagicMock()
    window._tuning_set_busy = MagicMock()
    window._tuning_done = MagicMock()
    window._finish_combined_calibration = MagicMock()
    window._send_tuning_command = MagicMock(return_value=True)
    window._status_bar = _FakeStatusBar()
    window.statusBar = lambda: window._status_bar
    window._parse_tuning_result = MagicMock()
    return window


# ---- Phase: Auto Focus (best-effort) ---------------------------------------


def test_autofocus_response_starts_barcode_locate():
    window = _calibration_window()
    MainWindow._on_command_response(window, "AF", "OK")
    assert window._calibration_phase == "locate"
    assert window._calibration_autofocus_answered is True
    assert window._calibration_autofocus_ok is True
    window._send_tuning_command.assert_not_called()
    context = window._worker.request_image_capture.call_args.args[0]
    assert context.purpose == "locate"
    assert window._calibration_timeout_timer.started_with == CALIBRATION_CAPTURE_TIMEOUT_MS
    assert window._finish_combined_calibration.call_count == 0


def test_rejected_autofocus_still_starts_barcode_locate():
    window = _calibration_window()
    MainWindow._on_command_response(window, "AF", "NG")
    assert window._calibration_phase == "locate"
    assert window._calibration_autofocus_ok is False
    window._send_tuning_command.assert_not_called()
    window._finish_combined_calibration.assert_not_called()


def test_silent_autofocus_starts_barcode_locate_on_timeout():
    window = _calibration_window()
    MainWindow._on_calibration_timeout(window)
    assert window._calibration_phase == "locate"
    window._send_tuning_command.assert_not_called()
    window._finish_combined_calibration.assert_not_called()
    assert window._status_bar.messages == [
        i18n.tr("autofocus_no_response_status", command="AF"),
        i18n.tr("autofocus_locating_status"),
    ]


def test_locate_capture_timeout_retries_then_starts_plain_tuning():
    window = _calibration_window(phase="locate")

    # The first two timeouts schedule another capture attempt...
    for expected_attempt in (1, 2):
        MainWindow._on_calibration_timeout(window)
        assert window._calibration_locate_attempt == expected_attempt
        assert window._calibration_phase == "locate"
        assert window._calibration_timeout_timer.started_with == CALIBRATION_CAPTURE_TIMEOUT_MS
    window._send_tuning_command.assert_not_called()

    # ...the third (last) timeout falls back to unrestricted tuning.
    MainWindow._on_calibration_timeout(window)
    window._worker.send_raw_command.assert_not_called()
    window._send_tuning_command.assert_called_once_with("start_tuning")
    assert window._calibration_phase == "tuning"
    assert window._calibration_timeout_timer.started_with == TUNING_CMDS["start_tuning"][2]
    assert window._status_bar.messages[-1] == i18n.tr("autofocus_barcode_not_found_status")


def test_tuning_timeout_fails_combined_calibration():
    window = _calibration_window(phase="tuning")
    MainWindow._on_calibration_timeout(window)
    window._send_tuning_command.assert_not_called()
    window._finish_combined_calibration.assert_called_once_with(
        False, i18n.tr("autotuning_timeout_error")
    )


def test_verify_timeout_retries_then_finishes_without_verification():
    window = _calibration_window(phase="verify")

    MainWindow._on_calibration_timeout(window)
    assert window._calibration_verify_attempt == 1
    assert window._calibration_phase == "verify"
    assert window._calibration_timeout_timer.started_with == CALIBRATION_CAPTURE_TIMEOUT_MS
    window._finish_combined_calibration.assert_not_called()

    MainWindow._on_calibration_timeout(window)
    window._send_tuning_command.assert_not_called()
    window._finish_combined_calibration.assert_called_once_with(
        True, status_message=i18n.tr("autofocus_verify_failed_status")
    )
    assert window._status_bar.messages[-1] == i18n.tr("autofocus_verify_failed_status")


def test_standalone_autofocus_timeout_releases_busy():
    window = _calibration_window(phase="autofocus_only")
    window._combined_calibration_active = False
    MainWindow._on_calibration_timeout(window)
    window._tuning_set_busy.assert_called_once_with(False)
    assert window._calibration_phase == ""
    window._worker.request_image_capture.assert_not_called()
    window._send_tuning_command.assert_not_called()
    window._finish_combined_calibration.assert_not_called()


def test_standalone_autofocus_response_releases_busy():
    window = _calibration_window(phase="autofocus_only")
    window._combined_calibration_active = False
    MainWindow._on_command_response(window, "AF", "OK")
    window._tuning_set_busy.assert_called_once_with(False)
    assert window._calibration_phase == ""
    window._worker.request_image_capture.assert_not_called()
    window._send_tuning_command.assert_not_called()
    assert window._status_bar.messages == [i18n.tr("autofocus_done_status")]


# ---- Phase: locate -> restricted tuning ------------------------------------


def test_locate_capture_restricts_decode_area_and_starts_tuning():
    window = _calibration_window(phase="locate")
    MainWindow._on_calibration_image_ready(window, _CalibrationCapture("locate"), _barcode_jpeg())

    assert window._calibration_barcode is not None
    assert window._calibration_barcode.text == EXPECTED
    assert window._worker.send_raw_command.call_count == 4
    assert window._calibration_decode_area_active is True
    window._send_tuning_command.assert_called_once_with("start_tuning")
    assert window._calibration_phase == "tuning"
    assert window._calibration_timeout_timer.started_with == TUNING_CMDS["start_tuning"][2]
    assert window._status_bar.messages[-1] == i18n.tr(
        "autofocus_barcode_found_status", value=EXPECTED
    )


def test_locate_without_barcode_retries_then_starts_plain_tuning():
    window = _calibration_window(phase="locate")
    for _ in range(CALIBRATION_LOCATE_ATTEMPTS - 1):
        MainWindow._on_calibration_image_ready(
            window, _CalibrationCapture("locate"), _blank_jpeg()
        )
        assert window._calibration_phase == "locate"
    window._send_tuning_command.assert_not_called()

    MainWindow._on_calibration_image_ready(
        window, _CalibrationCapture("locate"), _blank_jpeg()
    )
    assert window._calibration_barcode is None
    window._worker.send_raw_command.assert_not_called()
    assert window._calibration_decode_area_active is False
    window._send_tuning_command.assert_called_once_with("start_tuning")
    assert window._calibration_phase == "tuning"
    assert window._status_bar.messages[-1] == i18n.tr("autofocus_barcode_not_found_status")


def test_locate_capture_failure_retries_then_starts_plain_tuning():
    window = _calibration_window(phase="locate")
    for _ in range(CALIBRATION_LOCATE_ATTEMPTS - 1):
        MainWindow._on_calibration_image_failed(
            window, _CalibrationCapture("locate"), "failed"
        )
        assert window._calibration_phase == "locate"
    window._send_tuning_command.assert_not_called()

    MainWindow._on_calibration_image_failed(
        window, _CalibrationCapture("locate"), "failed"
    )
    window._worker.send_raw_command.assert_not_called()
    window._send_tuning_command.assert_called_once_with("start_tuning")
    assert window._calibration_phase == "tuning"


def test_stale_calibration_capture_is_ignored():
    window = _calibration_window(phase="locate")
    window._combined_calibration_active = False
    MainWindow._on_calibration_image_ready(window, _CalibrationCapture("locate"), _barcode_jpeg())

    window._worker.send_raw_command.assert_not_called()
    window._send_tuning_command.assert_not_called()


# ---- Phase: tuning -> verify ------------------------------------------------


def test_tuning_completion_starts_verification_and_restores_decode_area():
    window = _calibration_window(phase="tuning")
    window._calibration_decode_area_active = True
    result_line = (
        "BANK 1:CODETYPE QRCode:SHUTTER 177[us]:GAIN 648[%]:RATE 100[%]"
        ":TIME 25 - 26[ms]:" + EXPECTED
    )

    MainWindow._on_command_response(window, "DT1", "Tuning complete")
    assert window._finish_combined_calibration.call_count == 0

    MainWindow._on_command_response(window, "DT1", result_line)
    assert window._calibration_read_data == EXPECTED
    reset_frame = window._worker.send_raw_command.call_args.args[0]
    assert reset_frame == b"\x1b[DF8Q4Q0Q0Q0Q0\x0d"
    assert window._calibration_decode_area_active is False
    context = window._worker.request_image_capture.call_args.args[0]
    assert context.purpose == "verify"
    assert window._calibration_phase == "verify"
    window._finish_combined_calibration.assert_not_called()


def test_verification_success_reports_barcode():
    window = _calibration_window(phase="verify")
    window._calibration_read_data = EXPECTED
    from autofocus import locate_barcode

    window._calibration_barcode = locate_barcode(_barcode_jpeg())

    MainWindow._on_calibration_image_ready(window, _CalibrationCapture("verify"), _barcode_jpeg())

    window._finish_combined_calibration.assert_called_once()
    assert window._finish_combined_calibration.call_args.args == (True,)
    assert window._finish_combined_calibration.call_args.kwargs.get("status_message") == (
        i18n.tr("autofocus_verified_status", value=EXPECTED)
    )
    assert EXPECTED in window._tuning_result_set.call_args.args[0]


def test_verification_mismatch_retunes_once_then_fails():
    window = _calibration_window(phase="verify")
    window._calibration_read_data = "OTHER-CODE"
    from autofocus import locate_barcode

    window._calibration_barcode = locate_barcode(_barcode_jpeg())

    # First mismatch: trigger a fresh locate + re-tune cycle.
    MainWindow._on_calibration_image_ready(window, _CalibrationCapture("verify"), _barcode_jpeg())
    assert window._calibration_relocate_retunes == 1
    assert window._calibration_phase == "locate"
    assert window._worker.request_image_capture.call_args.args[0].purpose == "locate"
    assert window._finish_combined_calibration.call_count == 0
    assert i18n.tr("autofocus_retune_status") in window._status_bar.messages

    # Second mismatch after the retune: retry budget exhausted -> abort.
    window._calibration_read_data = "OTHER-CODE"
    window._calibration_barcode = locate_barcode(_barcode_jpeg())
    window._calibration_phase = "verify"
    MainWindow._on_calibration_image_ready(window, _CalibrationCapture("verify"), _barcode_jpeg())
    window._finish_combined_calibration.assert_called_once()
    assert window._finish_combined_calibration.call_args.args == (False,)
    assert window._finish_combined_calibration.call_args.kwargs.get("error") == i18n.tr(
        "autofocus_read_mismatch_status", read="OTHER-CODE", expected=EXPECTED
    )


def test_verification_failure_retries_then_still_completes_tuning():
    window = _calibration_window(phase="verify")
    window._calibration_barcode = None
    window._calibration_read_data = ""

    # First unclear frame: retry.
    MainWindow._on_calibration_image_ready(window, _CalibrationCapture("verify"), _blank_jpeg())
    assert window._calibration_phase == "verify"
    assert window._calibration_verify_attempt == 1
    assert window._finish_combined_calibration.call_count == 0

    # Second unclear frame: retry budget exhausted -> complete without image.
    MainWindow._on_calibration_image_ready(window, _CalibrationCapture("verify"), _blank_jpeg())
    window._finish_combined_calibration.assert_called_once_with(
        True, status_message=i18n.tr("autofocus_verify_unclear_status")
    )


def test_tuning_failed_retries_with_full_view_then_aborts():
    window = _calibration_window(phase="tuning")
    window._calibration_decode_area_active = True

    # First "Tuning failed": the decode-area restriction is dropped and DT1
    # is retried over the full view.
    MainWindow._on_command_response(window, "DT1", "Tuning failed")
    assert window._finish_combined_calibration.call_count == 0
    assert window._calibration_decode_area_active is False
    assert window._worker.send_raw_command.call_args.args[0] == b"\x1b[DF8Q4Q0Q0Q0Q0\x0d"
    assert window._calibration_phase == "tuning"
    assert window._calibration_tuning_attempt == 1
    assert window._calibration_timeout_timer.started_with == TUNING_CMDS["start_tuning"][2]
    assert window._status_bar.messages[-1] == i18n.tr(
        "autofocus_tuning_retry_status",
        attempt=1,
        maximum=CALIBRATION_TUNING_ATTEMPTS,
    )

    # Second "Tuning failed": retry budget exhausted -> abort.
    MainWindow._on_command_response(window, "DT1", "Tuning failed")
    window._finish_combined_calibration.assert_called_once_with(False, "Tuning failed")
    assert window._calibration_tuning_attempt == 1


def test_tuning_failed_releases_busy_in_standalone_mode():
    window = _calibration_window(phase="")
    window._combined_calibration_active = False
    MainWindow._on_command_response(window, "DT1", "Tuning failed")
    window._tuning_done.assert_called_once_with()
    window._finish_combined_calibration.assert_not_called()


# ---- Completion messages ----------------------------------------------------


def test_completion_message_reflects_missing_autofocus():
    window = _calibration_window()
    window._tuning_set_busy = MagicMock()
    window._apply_role_ui = MagicMock()
    MainWindow._finish_combined_calibration(window, True)
    assert window._status_bar.messages == [
        i18n.tr("calibration_complete_tuning_only_status")
    ]

    window2 = _calibration_window()
    window2._calibration_autofocus_answered = True
    window2._calibration_autofocus_ok = True
    window2._tuning_set_busy = MagicMock()
    MainWindow._finish_combined_calibration(window2, True)
    assert window2._status_bar.messages == [i18n.tr("calibration_complete_status")]


def test_calibration_failure_markers_are_rejected():
    for response in ("ERR", "NG", "ERROR unsupported", "Unknown command"):
        assert MainWindow._calibration_response_failed(response)
    assert not MainWindow._calibration_response_failed("OK")


def test_autofocus_command_is_external_and_persisted(tmp_path, monkeypatch):
    config_file = tmp_path / "app_config.json"
    monkeypatch.setattr(app_config, "CONFIG_FILE", config_file)
    app_config.set_autofocus_command("AF2")
    assert app_config.get_autofocus_command() == "AF2"





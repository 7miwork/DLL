from __future__ import annotations

import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent.parent))

from PySide6.QtWidgets import QApplication

import auth
import i18n
import settings_dialog
from main_window import MainWindow


app = QApplication.instance() or QApplication(sys.argv)
i18n.set_bilingual(True)
window = MainWindow()
assert "Enter Manually" in window._btn_manual_entry.text()
assert "手動輸入" in window._btn_manual_entry.text()
assert window._current_user is None
assert not window._btn_connect.isEnabled()
assert not window._btn_export.isVisible()

window._current_user = auth.User("admin", True, "admin")
window._apply_role_ui()
assert window._btn_export.isVisible()
assert window._act_user_management.isVisible()
assert window._btn_logout.isVisible()
assert not window._btn_autofocus.isHidden()
assert not window._btn_auto_tuning.isHidden()
assert not window._btn_calibration.isHidden()
assert "Auto Focus" in window._btn_autofocus.text()
assert "Auto Tuning" in window._btn_auto_tuning.text()
assert "Auto Focus" in window._btn_calibration.text()

window._current_user = auth.User("A12345", True, "operator")
window._apply_role_ui()
assert not window._btn_export.isVisible()
assert not window._act_user_management.isVisible()
assert not window._btn_refresh.isVisible()
assert not window._btn_auto_detect.isVisible()
assert not window._lbl_baud.isVisible()
assert not window._cmb_baud.isVisible()
assert not window._btn_menu.isVisible()
assert not window._lbl_lang.isVisible()
assert not window._cmb_language.isVisible()
assert not window._btn_autofocus.isVisible()
assert not window._btn_auto_tuning.isVisible()
assert not window._btn_calibration.isVisible()
assert not window._btn_copy_selected.isVisible()
assert not window._btn_copy_all.isVisible()
assert not window._btn_clear.isVisible()
assert not window._btn_export.isVisible()
assert not window._chk_ignore_dupes.isVisible()
assert window._btn_logout.isVisible()
assert window._btn_retry.isVisible()
assert window._btn_manual_entry.isVisible()
assert window._btn_trigger.isVisible()
assert window._btn_continuous.isVisible()
assert window._btn_stop.isVisible()
assert window._btn_connect.isVisible()
assert window._txt_operator.text() == "A12345"
window._worker.is_connected = lambda: True
window._operator_manual_input_available = True
window._apply_role_ui()
assert window._btn_manual_entry.isEnabled()
window._operator_manual_input_available = False
window._apply_role_ui()
assert not window._btn_manual_entry.isEnabled()

calibration_dialog = settings_dialog.SettingsDialog(window)
assert "Auto Focus" in calibration_dialog._btn_calibrate.text()
assert calibration_dialog._txt_autofocus_command.text() == "AF"
calibration_dialog.close()

window.close()
print("ui smoke: OK")

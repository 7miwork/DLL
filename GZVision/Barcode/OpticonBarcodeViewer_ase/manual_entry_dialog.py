"""Focused manual Wafer-ID entry dialog."""

from __future__ import annotations

from PySide6.QtCore import QTimer
from PySide6.QtWidgets import QDialog, QDialogButtonBox, QLabel, QLineEdit, QVBoxLayout

import i18n


class ManualEntryDialog(QDialog):
    """Small modal form that is ready for keyboard/scanner input immediately."""

    def __init__(self, parent=None):
        super().__init__(parent)
        self.setModal(True)
        self.setFixedWidth(480)
        self._build_ui()
        self.retranslate_ui()
        QTimer.singleShot(0, self._focus_input)

    def _build_ui(self):
        layout = QVBoxLayout(self)
        self._lbl_info = QLabel()
        self._lbl_info.setWordWrap(True)
        layout.addWidget(self._lbl_info)
        self._txt_wafer_id = QLineEdit()
        self._txt_wafer_id.setClearButtonEnabled(True)
        self._txt_wafer_id.returnPressed.connect(self.accept)
        layout.addWidget(self._txt_wafer_id)
        self._buttons = QDialogButtonBox(QDialogButtonBox.Ok | QDialogButtonBox.Cancel)
        self._buttons.accepted.connect(self.accept)
        self._buttons.rejected.connect(self.reject)
        layout.addWidget(self._buttons)

    def _focus_input(self):
        self._txt_wafer_id.setFocus()
        self._txt_wafer_id.selectAll()

    def showEvent(self, event):
        super().showEvent(event)
        self.retranslate_ui()
        QTimer.singleShot(0, self._focus_input)

    def retranslate_ui(self):
        self.setWindowTitle(i18n.tr("manual_entry_dialog_title"))
        self._lbl_info.setText(i18n.tr("manual_entry_no_scan_text"))
        self._txt_wafer_id.setPlaceholderText(i18n.tr("manual_entry_wafer_id_placeholder"))
        self._txt_wafer_id.setToolTip(i18n.tr("manual_entry_wafer_id_label"))
        self._buttons.button(QDialogButtonBox.Ok).setText(i18n.tr("dialog_ok"))
        self._buttons.button(QDialogButtonBox.Cancel).setText(i18n.tr("dialog_cancel"))

    def wafer_id(self) -> str:
        return self._txt_wafer_id.text().strip()

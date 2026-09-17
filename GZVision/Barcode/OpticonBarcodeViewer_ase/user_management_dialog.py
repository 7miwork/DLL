"""Administrator-only local user management dialog."""

from __future__ import annotations

from PySide6.QtCore import Qt
from PySide6.QtWidgets import (
    QCheckBox,
    QComboBox,
    QDialog,
    QFormLayout,
    QHBoxLayout,
    QLabel,
    QLineEdit,
    QListWidget,
    QMessageBox,
    QPushButton,
    QVBoxLayout,
)

import auth
import i18n


class UserManagementDialog(QDialog):
    """Create/replace/delete local accounts without exposing password hashes."""

    def __init__(self, parent=None):
        super().__init__(parent)
        self.setModal(True)
        self.resize(520, 460)
        self._build_ui()
        self._refresh_users()
        self._txt_login.setFocus()

    def _build_ui(self):
        layout = QVBoxLayout(self)

        self._lbl_info = QLabel()
        self._lbl_info.setWordWrap(True)
        layout.addWidget(self._lbl_info)

        self._users = QListWidget()
        self._users.currentRowChanged.connect(self._on_user_selected)
        layout.addWidget(self._users)

        form = QFormLayout()
        self._txt_login = QLineEdit()
        form.addRow(QLabel(), self._txt_login)
        self._txt_password = QLineEdit()
        self._txt_password.setEchoMode(QLineEdit.Password)
        form.addRow(QLabel(), self._txt_password)
        self._cmb_role = QComboBox()
        form.addRow(QLabel(), self._cmb_role)
        self._chk_manual = QCheckBox()
        form.addRow(QLabel(), self._chk_manual)
        layout.addLayout(form)

        actions = QHBoxLayout()
        self._btn_save = QPushButton()
        self._btn_save.clicked.connect(self._save_user)
        actions.addWidget(self._btn_save)
        self._btn_delete = QPushButton()
        self._btn_delete.clicked.connect(self._delete_user)
        actions.addWidget(self._btn_delete)
        actions.addStretch()
        self._btn_close = QPushButton()
        self._btn_close.clicked.connect(self.accept)
        actions.addWidget(self._btn_close)
        layout.addLayout(actions)

        self._retranslate_labels = [
            (self, "user_management_title", "setWindowTitle"),
            (self._lbl_info, "user_management_info", "setText"),
            (self._btn_save, "user_save_button", "setText"),
            (self._btn_delete, "user_delete_button", "setText"),
            (self._btn_close, "dialog_close", "setText"),
        ]
        self._field_labels = form.labelForField(self._txt_login), form.labelForField(self._txt_password), form.labelForField(self._cmb_role), form.labelForField(self._chk_manual)
        self._retranslate_ui()

    def _retranslate_ui(self):
        for widget, key, setter in self._retranslate_labels:
            getattr(widget, setter)(i18n.tr(key))
        labels = [
            (self._field_labels[0], "user_login_label"),
            (self._field_labels[1], "user_password_label"),
            (self._field_labels[2], "user_role_label"),
            (self._field_labels[3], "user_manual_permission"),
        ]
        for widget, key in labels:
            if widget is not None:
                widget.setText(i18n.tr(key))
        current_role = self._cmb_role.currentData()
        self._cmb_role.blockSignals(True)
        self._cmb_role.clear()
        self._cmb_role.addItem(i18n.tr("role_operator"), "operator")
        self._cmb_role.addItem(i18n.tr("role_admin"), "admin")
        if current_role:
            idx = self._cmb_role.findData(current_role)
            if idx >= 0:
                self._cmb_role.setCurrentIndex(idx)
        self._cmb_role.blockSignals(False)

    def showEvent(self, event):
        super().showEvent(event)
        self._retranslate_ui()
        self._refresh_users()
        self._txt_login.setFocus()

    def _refresh_users(self):
        selected = self._txt_login.text().strip()
        self._users.clear()
        for user in auth.list_users():
            label = f"{user.login_id} — {i18n.tr('role_admin') if user.is_admin else i18n.tr('role_operator')}"
            item = self._users.addItem(label)
            del item
            self._users.item(self._users.count() - 1).setData(Qt.UserRole, user.login_id)
        for row in range(self._users.count()):
            if self._users.item(row).data(Qt.UserRole) == selected:
                self._users.setCurrentRow(row)
                break

    def _on_user_selected(self, row: int):
        if row < 0:
            return
        login_id = self._users.item(row).data(Qt.UserRole)
        user = next((u for u in auth.list_users() if u.login_id == login_id), None)
        if user is None:
            return
        self._txt_login.setText(user.login_id)
        self._txt_password.clear()
        self._cmb_role.setCurrentIndex(self._cmb_role.findData(user.role))
        self._chk_manual.setChecked(user.can_manual_entry)

    def _save_user(self):
        login_id = self._txt_login.text().strip()
        password = self._txt_password.text()
        if not login_id or not password:
            QMessageBox.warning(self, i18n.tr("user_error_title"), i18n.tr("user_error_required"))
            return
        role = self._cmb_role.currentData() or "operator"
        if not auth.add_user(login_id, password, self._chk_manual.isChecked(), role):
            QMessageBox.warning(self, i18n.tr("user_error_title"), i18n.tr("user_error_save"))
            return
        self._txt_password.clear()
        self._refresh_users()
        QMessageBox.information(self, i18n.tr("user_saved_title"), i18n.tr("user_saved_text").format(login_id=login_id))

    def _delete_user(self):
        login_id = self._txt_login.text().strip()
        if not login_id:
            return
        if login_id.lower() == "admin" and len(auth.list_users()) <= 1:
            return
        answer = QMessageBox.question(self, i18n.tr("user_delete_title"), i18n.tr("user_delete_text").format(login_id=login_id), QMessageBox.Yes | QMessageBox.No, QMessageBox.No)
        if answer != QMessageBox.Yes:
            return
        auth.remove_user(login_id)
        self._txt_login.clear()
        self._txt_password.clear()
        self._refresh_users()

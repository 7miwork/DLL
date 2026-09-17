"""Login dialog for manual Wafer-ID entry (UV-300).

Provides a QDialog with login ID and password fields for authenticating
users who need to manually enter Wafer IDs when the device fails to read.
"""

from PySide6.QtWidgets import (
    QDialog, QVBoxLayout, QHBoxLayout, QLabel,
    QLineEdit, QPushButton, QMessageBox,
)
import auth
import i18n


class LoginDialog(QDialog):
    """Dialog for user authentication before manual Wafer-ID entry."""

    def __init__(self, parent=None):
        super().__init__(parent)
        self._authenticated_user = None
        self._build_ui()
        self.retranslate_ui()
        # Focus the login ID field for immediate typing
        self._txt_id.setFocus()

    def showEvent(self, event):
        """Re-translate UI on show so it reflects the current language."""
        super().showEvent(event)
        self.retranslate_ui()

    def _build_ui(self):
        self.setWindowTitle(i18n.tr("login_dialog_title"))
        self.setModal(True)
        self.setFixedWidth(400)

        layout = QVBoxLayout(self)
        layout.setSpacing(8)
        layout.setContentsMargins(12, 12, 12, 12)

        # Info label
        self._lbl_info = QLabel()
        self._lbl_info.setWordWrap(True)
        layout.addWidget(self._lbl_info)

        # Login ID
        id_layout = QHBoxLayout()
        self._lbl_id = QLabel()
        self._lbl_id.setFixedWidth(80)
        id_layout.addWidget(self._lbl_id)

        self._txt_id = QLineEdit()
        self._txt_id.setPlaceholderText("")
        self._txt_id.setClearButtonEnabled(True)
        id_layout.addWidget(self._txt_id)
        layout.addLayout(id_layout)

        # Password
        pwd_layout = QHBoxLayout()
        self._lbl_pwd = QLabel()
        self._lbl_pwd.setFixedWidth(80)
        pwd_layout.addWidget(self._lbl_pwd)

        self._txt_pwd = QLineEdit()
        self._txt_pwd.setEchoMode(QLineEdit.Password)
        self._txt_pwd.setClearButtonEnabled(True)
        pwd_layout.addWidget(self._txt_pwd)
        layout.addLayout(pwd_layout)

        # Buttons
        btn_layout = QHBoxLayout()
        btn_layout.addStretch()

        self._btn_login = QPushButton()
        self._btn_login.setDefault(True)
        self._btn_login.clicked.connect(self._on_login_clicked)
        btn_layout.addWidget(self._btn_login)

        self._btn_cancel = QPushButton()
        self._btn_cancel.clicked.connect(self.reject)
        btn_layout.addWidget(self._btn_cancel)

        layout.addLayout(btn_layout)

        # Allow Enter / Return in either field to trigger login
        self._txt_id.returnPressed.connect(self._on_login_clicked)
        self._txt_pwd.returnPressed.connect(self._on_login_clicked)

    def retranslate_ui(self):
        self.setWindowTitle(i18n.tr("login_dialog_title"))
        self._lbl_info.setText(i18n.tr("login_dialog_info"))
        self._lbl_id.setText(i18n.tr("login_id_label"))
        self._txt_id.setPlaceholderText(i18n.tr("login_id_placeholder"))
        self._txt_id.setToolTip(i18n.tr("login_id_tooltip"))
        self._lbl_pwd.setText(i18n.tr("password_label"))
        self._txt_pwd.setPlaceholderText(i18n.tr("password_placeholder"))
        self._txt_pwd.setToolTip(i18n.tr("password_tooltip"))
        self._btn_login.setText(i18n.tr("login_button"))
        self._btn_login.setToolTip(i18n.tr("login_button_tooltip"))
        self._btn_cancel.setText(i18n.tr("cancel_button"))
        self._btn_cancel.setToolTip(i18n.tr("cancel_button_tooltip"))

    def _on_login_clicked(self):
        login_id = self._txt_id.text().strip()
        password = self._txt_pwd.text()

        if not login_id or not password:
            QMessageBox.warning(
                self,
                i18n.tr("login_error_title"),
                i18n.tr("login_error_empty"),
            )
            return

        user = auth.authenticate(login_id, password)
        if user is None:
            QMessageBox.warning(
                self,
                i18n.tr("login_error_title"),
                i18n.tr("login_error_invalid"),
            )
            self._txt_pwd.clear()
            self._txt_pwd.setFocus()
            return

        self._authenticated_user = user
        self.accept()

    def get_authenticated_user(self):
        """Return the authenticated User object, or None if cancelled."""
        return self._authenticated_user

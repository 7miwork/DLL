"""Tabbed settings dialog for Opticon Barcode Viewer."""

from PySide6.QtWidgets import (
    QDialog, QVBoxLayout, QHBoxLayout, QTabWidget, QWidget,
    QLabel, QLineEdit, QComboBox, QCheckBox, QSpinBox,
    QPushButton, QFormLayout, QProgressBar, QFileDialog
)
from PySide6.QtCore import Qt

import i18n
import app_config


class SettingsDialog(QDialog):
    """Tabbed settings dialog for rarely-used configuration."""

    def __init__(self, main_window, parent=None):
        super().__init__(parent)
        self.setWindowTitle(i18n.tr("settings_dialog_title"))
        self.setModal(False)
        self.resize(520, 420)
        self._main_window = main_window
        self._settings = dict(main_window._settings)

        layout = QVBoxLayout(self)
        self._tabs = QTabWidget()
        layout.addWidget(self._tabs)

        self._build_trigger_sensor_tab()
        self._build_barcode_tab()
        self._build_tuning_tab()
        self._build_interface_tab()

        btn_layout = QHBoxLayout()
        btn_layout.addStretch()
        ok_btn = QPushButton(i18n.tr("dialog_ok"))
        ok_btn.clicked.connect(self._on_ok)
        btn_layout.addWidget(ok_btn)
        cancel_btn = QPushButton(i18n.tr("dialog_cancel"))
        cancel_btn.clicked.connect(self.reject)
        btn_layout.addWidget(cancel_btn)
        layout.addLayout(btn_layout)

    # ------------------------------------------------------------------
    # Tabs
    # ------------------------------------------------------------------

    def _build_trigger_sensor_tab(self):
        tab = QWidget()
        form = QFormLayout(tab)

        form.addRow(QLabel(i18n.tr("trigger_source_mode_label")))
        self._cmb_trigger_mode = QComboBox()
        self._cmb_trigger_mode.addItems([
            i18n.tr("trigger_source_manual"),
            i18n.tr("trigger_source_serial_line"),
        ])
        mode = app_config.get_trigger_source_mode()
        self._cmb_trigger_mode.setCurrentText(
            i18n.tr("trigger_source_serial_line") if mode == "serial_line"
            else i18n.tr("trigger_source_manual")
        )
        self._cmb_trigger_mode.currentIndexChanged.connect(self._on_trigger_mode_changed)
        form.addRow(self._cmb_trigger_mode)

        form.addRow(QLabel(i18n.tr("trigger_source_com_port_label")))
        self._cmb_trigger_port = QComboBox()
        self._cmb_trigger_port.setEditable(True)
        self._refresh_trigger_ports()
        port = app_config.get_trigger_source_com_port()
        if port:
            idx = self._cmb_trigger_port.findText(port)
            if idx >= 0:
                self._cmb_trigger_port.setCurrentIndex(idx)
            else:
                self._cmb_trigger_port.setCurrentText(port)
        self._cmb_trigger_port.currentIndexChanged.connect(self._on_trigger_port_changed)
        form.addRow(self._cmb_trigger_port)

        form.addRow(QLabel(i18n.tr("trigger_source_baud_rate_label")))
        self._cmb_trigger_baud = QComboBox()
        self._cmb_trigger_baud.addItems(["9600", "19200", "38400", "57600", "115200"])
        baud = str(app_config.get_trigger_source_baud_rate())
        idx = self._cmb_trigger_baud.findText(baud)
        if idx >= 0:
            self._cmb_trigger_baud.setCurrentIndex(idx)
        self._cmb_trigger_baud.currentIndexChanged.connect(self._on_trigger_baud_changed)
        form.addRow(self._cmb_trigger_baud)

        form.addRow(QLabel(i18n.tr("trigger_source_expected_string_label")))
        self._txt_trigger_expected = QLineEdit(
            app_config.get_trigger_source_expected_string()
        )
        self._txt_trigger_expected.editingFinished.connect(self._on_trigger_expected_changed)
        form.addRow(self._txt_trigger_expected)

        form.addRow(QLabel(i18n.tr("trigger_max_attempts_label")))
        self._spin_max_attempts = QSpinBox()
        self._spin_max_attempts.setRange(1, 20)
        self._spin_max_attempts.setValue(
            self._settings.get("trigger_max_attempts", 5)
        )
        self._spin_max_attempts.valueChanged.connect(self._on_max_attempts_changed)
        form.addRow(self._spin_max_attempts)

        form.addRow(QLabel(i18n.tr("trigger_retry_delay_label")))
        self._spin_retry_delay = QSpinBox()
        self._spin_retry_delay.setRange(100, 30000)
        self._spin_retry_delay.setSingleStep(100)
        self._spin_retry_delay.setValue(
            self._settings.get("trigger_retry_delay_ms", 1000)
        )
        self._spin_retry_delay.valueChanged.connect(self._on_retry_delay_changed)
        form.addRow(self._spin_retry_delay)

        self._tabs.addTab(tab, i18n.tr("settings_tab_trigger_sensor"))

    def _build_barcode_tab(self):
        tab = QWidget()
        form = QFormLayout(tab)

        form.addRow(QLabel(i18n.tr("prefix_label")))
        self._txt_prefix = QLineEdit(
            self._settings.get("barcode_prefix", "")
        )
        self._txt_prefix.editingFinished.connect(self._on_prefix_changed)
        form.addRow(self._txt_prefix)

        form.addRow(QLabel(i18n.tr("suffix_label")))
        self._txt_suffix = QLineEdit(
            self._settings.get("barcode_suffix", "")
        )
        self._txt_suffix.editingFinished.connect(self._on_suffix_changed)
        form.addRow(self._txt_suffix)

        self._tabs.addTab(tab, i18n.tr("settings_tab_barcode"))

    def _build_tuning_tab(self):
        tab = QWidget()
        form = QFormLayout(tab)

        form.addRow(QLabel(i18n.tr("current_bank_label")))
        self._lbl_current_bank = QLabel("--")
        form.addRow(self._lbl_current_bank)

        self._btn_refresh_bank = QPushButton(i18n.tr("refresh_bank_button"))
        self._btn_refresh_bank.clicked.connect(self._main_window._get_current_bank)
        form.addRow(self._btn_refresh_bank)

        form.addRow(QLabel(i18n.tr("select_bank_label")))
        self._cmb_bank = QComboBox()
        self._cmb_bank.addItems(["01", "02", "03", "04", "05", "06", "07"])
        self._cmb_bank.setCurrentIndex(0)
        form.addRow(self._cmb_bank)

        self._btn_select_bank = QPushButton(i18n.tr("select_bank_button"))
        self._btn_select_bank.clicked.connect(self._on_select_bank)
        form.addRow(self._btn_select_bank)

        form.addRow(QLabel(i18n.tr("autofocus_command_label")))
        self._txt_autofocus_command = QLineEdit(app_config.get_autofocus_command())
        self._txt_autofocus_command.setPlaceholderText(i18n.tr("autofocus_command_placeholder"))
        self._txt_autofocus_command.editingFinished.connect(self._on_autofocus_command_changed)
        form.addRow(self._txt_autofocus_command)

        self._btn_calibrate = QPushButton(i18n.tr("autofocus_then_tuning_button"))
        self._btn_calibrate.clicked.connect(self._main_window._start_autofocus_then_tuning)
        form.addRow(self._btn_calibrate)

        self._btn_start_tuning = QPushButton(i18n.tr("start_tuning_button"))
        self._btn_start_tuning.clicked.connect(self._on_start_tuning)
        form.addRow(self._btn_start_tuning)

        self._btn_stop_tuning = QPushButton(i18n.tr("stop_tuning_button"))
        self._btn_stop_tuning.clicked.connect(self._on_stop_tuning)
        form.addRow(self._btn_stop_tuning)

        self._btn_bank_trigger = QPushButton(i18n.tr("trigger_with_bank_button"))
        self._btn_bank_trigger.clicked.connect(self._on_bank_trigger)
        form.addRow(self._btn_bank_trigger)

        self._btn_reset_bank = QPushButton(i18n.tr("reset_bank_button"))
        self._btn_reset_bank.clicked.connect(self._on_reset_bank)
        form.addRow(self._btn_reset_bank)

        self._btn_reset_all_banks = QPushButton(i18n.tr("reset_all_banks_button"))
        self._btn_reset_all_banks.clicked.connect(self._on_reset_all_banks)
        form.addRow(self._btn_reset_all_banks)

        self._progress_tuning = QProgressBar()
        self._progress_tuning.setRange(0, 0)
        self._progress_tuning.setVisible(False)
        form.addRow(self._progress_tuning)

        self._lbl_tuning_result = QLabel("")
        self._lbl_tuning_result.setWordWrap(True)
        form.addRow(self._lbl_tuning_result)

        self._tabs.addTab(tab, i18n.tr("settings_tab_tuning"))

    def _build_interface_tab(self):
        tab = QWidget()
        form = QFormLayout(tab)

        # Scan storage location comes first: it decides where every TXT
        # record and its parallel scan image (JPG) are written.
        storage_root_row = QWidget()
        storage_root_layout = QHBoxLayout(storage_root_row)
        self._txt_scan_root = QLineEdit(app_config.get_scan_storage_root_path())
        self._txt_scan_root.setPlaceholderText(i18n.tr("scan_storage_root_placeholder"))
        storage_root_layout.addWidget(self._txt_scan_root)
        self._btn_browse_scan_root = QPushButton(i18n.tr("browse_scan_storage_root_button"))
        self._btn_browse_scan_root.clicked.connect(self._browse_scan_root)
        storage_root_layout.addWidget(self._btn_browse_scan_root)
        form.addRow(i18n.tr("scan_storage_root_label"), storage_root_row)
        layout_hint = QLabel(i18n.tr("scan_storage_layout_hint"))
        layout_hint.setWordWrap(True)
        form.addRow(layout_hint)

        form.addRow(QLabel(i18n.tr("lang_selector_label")))
        self._cmb_language = QComboBox()
        self._cmb_language.addItems(list(i18n.LANGUAGE_NAMES.values()))
        lang_code = self._settings.get("language", "en")
        lang_name = i18n.LANGUAGE_NAMES.get(lang_code, "English")
        self._cmb_language.setCurrentText(lang_name)
        self._cmb_language.currentIndexChanged.connect(self._on_language_changed)
        form.addRow(self._cmb_language)

        form.addRow(QLabel(i18n.tr("ignore_dupes_checkbox")))
        self._chk_ignore_dupes = QCheckBox()
        self._chk_ignore_dupes.setChecked(
            self._settings.get("ignore_duplicates", False)
        )
        self._chk_ignore_dupes.stateChanged.connect(self._on_dupe_toggle)
        form.addRow(self._chk_ignore_dupes)

        self._tabs.addTab(tab, i18n.tr("settings_tab_interface"))

    # ------------------------------------------------------------------
    # Live update slots
    # ------------------------------------------------------------------

    def _refresh_trigger_ports(self):
        try:
            from serial_reader import enumerate_ports
            self._cmb_trigger_port.clear()
            self._cmb_trigger_port.addItems(enumerate_ports())
        except Exception:
            self._cmb_trigger_port.clear()

    def _on_trigger_mode_changed(self, index: int):
        text = self._cmb_trigger_mode.currentText()
        mode = "manual" if text == i18n.tr("trigger_source_manual") else "serial_line"
        app_config.set_trigger_source_mode(mode)
        self._main_window._on_trigger_mode_changed(index)

    def _on_trigger_port_changed(self, index: int):
        app_config.set_trigger_source_com_port(self._cmb_trigger_port.currentText())

    def _on_trigger_baud_changed(self, index: int):
        app_config.set_trigger_source_baud_rate(
            int(self._cmb_trigger_baud.currentText())
        )

    def _on_trigger_expected_changed(self):
        app_config.set_trigger_source_expected_string(
            self._txt_trigger_expected.text()
        )

    def _on_max_attempts_changed(self, value: int):
        self._settings["trigger_max_attempts"] = value
        self._main_window._settings["trigger_max_attempts"] = value
        self._main_window._on_trigger_settings_changed()

    def _on_retry_delay_changed(self, value: int):
        self._settings["trigger_retry_delay_ms"] = value
        self._main_window._settings["trigger_retry_delay_ms"] = value
        self._main_window._on_trigger_settings_changed()

    def _on_prefix_changed(self):
        self._settings["barcode_prefix"] = self._txt_prefix.text()
        self._main_window._settings["barcode_prefix"] = self._txt_prefix.text()

    def _on_suffix_changed(self):
        self._settings["barcode_suffix"] = self._txt_suffix.text()
        self._main_window._settings["barcode_suffix"] = self._txt_suffix.text()

    def _on_autofocus_command_changed(self):
        app_config.set_autofocus_command(self._txt_autofocus_command.text())

    def _on_language_changed(self, index: int):
        lang_names = list(i18n.LANGUAGE_NAMES.values())
        if index < 0 or index >= len(lang_names):
            return
        selected_name = lang_names[index]
        lang_code = None
        for code, name in i18n.LANGUAGE_NAMES.items():
            if name == selected_name:
                lang_code = code
                break
        if lang_code:
            i18n.set_language(lang_code)
            self._settings["language"] = lang_code
            self._main_window._settings["language"] = lang_code
            self._main_window._on_language_changed(index)

    def _browse_scan_root(self):
        """Choose the root under which all scan data is organized."""
        selected = QFileDialog.getExistingDirectory(
            self,
            i18n.tr("browse_scan_storage_root_title"),
            self._txt_scan_root.text().strip(),
        )
        if selected:
            self._txt_scan_root.setText(selected)

    def _on_dupe_toggle(self, state: int):

        self._settings["ignore_duplicates"] = state == Qt.Checked
        self._main_window._settings["ignore_duplicates"] = state == Qt.Checked
        self._main_window._chk_ignore_dupes.setChecked(state == Qt.Checked)

    # ------------------------------------------------------------------
    # Tuning slots
    # ------------------------------------------------------------------

    def _on_select_bank(self):
        self._main_window._select_bank()

    def _on_start_tuning(self):
        self._main_window._start_tuning()

    def _on_stop_tuning(self):
        self._main_window._stop_tuning()

    def _on_bank_trigger(self):
        self._main_window._trigger_with_bank()

    def _on_reset_bank(self):
        self._main_window._reset_bank()

    def _on_reset_all_banks(self):
        self._main_window._reset_all_banks()

    # ------------------------------------------------------------------
    # Public API for main window
    # ------------------------------------------------------------------

    def set_tuning_busy(self, busy: bool):
        self._btn_start_tuning.setEnabled(not busy)
        self._btn_calibrate.setEnabled(not busy)
        self._btn_select_bank.setEnabled(not busy)
        self._btn_bank_trigger.setEnabled(not busy)
        self._btn_reset_bank.setEnabled(not busy)
        self._btn_reset_all_banks.setEnabled(not busy)
        self._progress_tuning.setVisible(busy)

    def set_current_bank(self, bank_text: str):
        self._lbl_current_bank.setText(bank_text)

    def set_tuning_result(self, text: str):
        self._lbl_tuning_result.setText(text)

    def get_selected_bank(self) -> str:
        return self._cmb_bank.currentText().strip()

    # ------------------------------------------------------------------
    # OK / Cancel
    # ------------------------------------------------------------------

    def _on_ok(self):
        self._settings["barcode_prefix"] = self._txt_prefix.text()
        self._settings["barcode_suffix"] = self._txt_suffix.text()
        lang_code = "en"
        for code, name in i18n.LANGUAGE_NAMES.items():
            if name == self._cmb_language.currentText():
                lang_code = code
                break
        self._settings["language"] = lang_code
        self._settings["ignore_duplicates"] = self._chk_ignore_dupes.isChecked()
        self._settings["trigger_max_attempts"] = self._spin_max_attempts.value()
        self._settings["trigger_retry_delay_ms"] = self._spin_retry_delay.value()
        self._main_window._settings.update(self._settings)
        app_config.set_autofocus_command(self._txt_autofocus_command.text())
        app_config.set_scan_storage_root_path(self._txt_scan_root.text())
        self.accept()

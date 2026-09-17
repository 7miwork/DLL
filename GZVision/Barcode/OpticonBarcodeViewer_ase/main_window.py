"""Main window for Opticon Barcode Viewer."""

from datetime import datetime
from pathlib import Path
from typing import Optional
from PySide6.QtWidgets import (
    QApplication, QMainWindow, QWidget, QVBoxLayout, QHBoxLayout,
    QComboBox, QPushButton, QLabel, QTableWidget,
    QHeaderView, QAbstractItemView, QCheckBox, QMessageBox,
    QFrame, QLineEdit,
    QToolButton, QDialog, QStyle, QStackedLayout,
    QScrollArea, QFileDialog, QMenu,
)
from PySide6.QtCore import Qt, QTimer, QThread, Signal, QObject, QSize
from openpyxl import Workbook
import serial
from PySide6.QtGui import QFont, QKeySequence, QShortcut, QPixmap

import autofocus
from models import Scan
from scan_table import COL_IMAGE, ScanTablePresenter

from serial_reader import SerialReaderWorker, enumerate_ports
import settings as app_settings
import i18n
import auth
import scan_file_writer
import login_dialog
import app_config
import hardware_lock
import trigger_controller
import trigger_source
import settings_dialog
import help_dialog
import tutorial_overlay
import user_management_dialog
import manual_entry_dialog





TUNING_CMDS = {
    # The Auto Focus identifier is configurable because not every firmware
    # documents it (MDI-5250/5350 ignore undefined commands silently), so the
    # answer window is short and the workflow continues without it.
    "auto_focus":      ("AF", 1, 2000),
    "start_tuning":    ("DT1", 2, 30000),
    "stop_tuning":     ("DT2", 1, 5000),
    "get_exposure_range": ("DT4", 1, 5000),
    "reset_exposure_range": ("DT5", 1, 5000),
    "set_fixed_exposure": ("D23", 1, 5000),
    "enable_auto_exposure": ("D24", 1, 5000),
    "set_fixed_gain":   ("E70", 1, 5000),
    "enable_auto_gain": ("E71", 1, 5000),
    "select_bank":      (),
    "bank_trigger":     ("TRG", 1, 5000),
    "reset_bank":       ("BRB", 1, 5000),
    "reset_all_banks":  ("BRC", 1, 8000),
    "get_current_bank": ("DGQ", 1, 5000),
}

# Timeout for one calibration CCD capture (locate / verify phases).
CALIBRATION_CAPTURE_TIMEOUT_MS = 8000
# How many times each calibration phase is retried before giving up.  Retries
# make the workflow tolerant of single bad frames ("some barcodes" that fail
# on the first attempt) without hanging forever.
CALIBRATION_LOCATE_ATTEMPTS = 3
CALIBRATION_TUNING_ATTEMPTS = 2
CALIBRATION_VERIFY_ATTEMPTS = 2
# How often a tuning/read mismatch triggers a fresh locate + re-tune cycle.
CALIBRATION_RETUNE_ATTEMPTS = 1


class _CalibrationCapture:
    """Context marker for CCD captures requested by the calibration workflow."""

    def __init__(self, purpose: str):
        self.purpose = purpose  # "locate" | "verify"


class _BaudDetectWorker(QObject):
    finished = Signal(object)

    def __init__(self, port: str, baud_rates: list[str]):
        super().__init__()
        self._port = port
        self._baud_rates = [int(b) for b in baud_rates]

    def run(self):
        import time
        for baud in self._baud_rates:
            try:
                ser = serial.Serial(
                    port=self._port,
                    baudrate=baud,
                    bytesize=serial.EIGHTBITS,
                    parity=serial.PARITY_NONE,
                    stopbits=serial.STOPBITS_ONE,
                    timeout=0.3,
                )
                time.sleep(0.2)
                if ser.in_waiting > 0:
                    ser.close()
                    self.finished.emit(baud)
                    return
                for cmd, desc in [(b"\x1bZ\r", "ESC+Z+CR"), (b"Z\r", "Z+CR")]:
                    ser.write(cmd)
                    ser.flush()
                    print(f"[BaudDetect] TX: {cmd.hex(' ')} ({desc}) @ {baud} baud")
                time.sleep(0.3)
                if ser.in_waiting > 0:
                    rx = ser.read(ser.in_waiting)
                    print(f"[BaudDetect] RX: {rx.hex(' ')} @ {baud} baud")
                    ser.close()
                    self.finished.emit(baud)
                    return
                ser.close()
            except Exception:
                continue
        self.finished.emit(None)


class MainWindow(QMainWindow):
    BAUD_RATES = ["1200", "2400", "4800", "9600", "19200",
                  "38400", "57600", "115200"]

    def __init__(self):
        super().__init__()
        self.resize(1050, 720)
        self._settings = app_settings.load()
        # Duplicate suppression is a production default. Admins can change it;
        # operators use the standard enabled behavior without seeing the switch.
        self._settings.setdefault("ignore_duplicates", True)
        self._settings_dialog = None
        self._user_management_dialog = None
        self._current_user: Optional[auth.User] = None
        self._help_dialog = None
        self._tutorial_overlay = None
        self._tutorial_shown_once = False
        self._i18n_registry: list[tuple] = []
        # Tuning/current-bank state kept on MainWindow (UI lives in SettingsDialog)
        self._current_bank_value = ""
        self._tuning_result_value = ""
        self._combined_calibration_active = False
        self._calibration_autofocus_command = ""
        # Calibration phase tracking: "", "autofocus", "autofocus_only" or
        # "tuning".  The Auto Focus command is optional on engines whose
        # firmware does not implement it; the phase drives the timeout
        # behaviour and the status messages.
        self._calibration_phase = ""
        self._calibration_autofocus_answered = False
        self._calibration_autofocus_ok = False
        self._calibration_rejection_line = ""
        # Image-guided tuning state: the barcode located in the CCD frame, the
        # data the engine read while tuning, and whether the decode area is
        # currently restricted to the located barcode (must be restored).
        self._calibration_barcode = None
        self._calibration_read_data = ""
        self._calibration_decode_area_active = False
        # Retry bookkeeping per calibration phase.
        self._calibration_locate_attempt = 0
        self._calibration_tuning_attempt = 0
        self._calibration_verify_attempt = 0
        self._calibration_relocate_retunes = 0
        self._tuning_response_count = 0
        self._calibration_timeout_timer = QTimer(self)
        self._calibration_timeout_timer.setSingleShot(True)
        self._calibration_timeout_timer.timeout.connect(self._on_calibration_timeout)
        self._scans: list[Scan] = []
        self._seen_barcode_values: set[str] = set()
        self._continuous_scan_active = False
        # Operators may use manual input only until an equipment scan is received.
        self._operator_manual_input_available = True
        # Production timeout comes from app_config.json, not mutable UI state.
        self._scan_timeout_ms = max(1, app_config.get_scan_timeout_seconds()) * 1000

        self._pending_ng_row: Optional[int] = None
        self._pending_ng_scan: Optional[Scan] = None
        self._copy_flash_timer = QTimer(self)
        self._copy_flash_timer.setSingleShot(True)
        self._copy_flash_timer.timeout.connect(self._clear_copy_flash)

        self._worker = SerialReaderWorker()
        self._worker.scan_received.connect(self._on_scan_received)
        self._worker.error_occurred.connect(self._on_error)
        self._worker.connected_changed.connect(self._on_connected_changed)
        self._worker.command_response.connect(self._on_command_response)
        self._worker.connection_lost.connect(self._on_connection_lost)
        self._worker.image_capture_ready.connect(self._on_image_ready)
        self._worker.image_capture_failed.connect(self._on_image_failed)
        self._worker.start()

        # Trigger controller
        self._trigger_policy = trigger_controller.TriggerRetryPolicy(
            max_attempts=self._settings.get("trigger_max_attempts", 5),
            retry_delay_ms=self._settings.get("trigger_retry_delay_ms", 1000),
            per_attempt_timeout_ms=self._scan_timeout_ms,
        )
        self._trigger_controller = trigger_controller.TriggerController(
            worker=self._worker, policy=self._trigger_policy
        )
        self._trigger_controller.trigger_requested.connect(self._on_trigger_requested)
        self._trigger_controller.cycle_exhausted.connect(self._on_trigger_cycle_exhausted)
        self._trigger_controller.scan_received_in_cycle.connect(self._on_trigger_scan_received)
        self._trigger_controller.status_changed.connect(self._on_trigger_status_changed)
        self._trigger_source = self._build_trigger_source()

        i18n.set_language(self._settings.get("language", "en"))

        # Initialize default users and always render operational labels in both
        # English and Traditional Chinese as requested by the client.
        auth.ensure_default_users_file()
        i18n.set_bilingual(True)

        self._build_ui()
        self._apply_theme()
        self._restore_settings()
        self.retranslate_ui()

        # Global shortcut: F1 opens the help dialog from anywhere.
        QShortcut(QKeySequence("F1"), self, activated=self._open_help_dialog)

    def _apply_theme(self):
        try:
            theme_path = Path(__file__).parent / "theme.qss"
            if theme_path.exists():
                self.setStyleSheet(theme_path.read_text(encoding="utf-8"))
        except Exception:
            pass

    def _setup_license_indicator(self):
        """Set the license status icon once at startup.

        Uses QStyle standard icons (no external image files) so it blends
        with the existing theme. The status does not change at runtime
        because license.lock is only checked at app start.
        """
        status = hardware_lock.get_license_status()
        style = self.style()

        if status == "licensed":
            # Green closed-lock: licensed for this PC
            icon = style.standardIcon(QStyle.SP_DialogApplyButton)
            self._lbl_license.setPixmap(icon.pixmap(16, 16))
            self._lbl_license.setToolTip(i18n.tr("license_tooltip_licensed"))
        elif status == "invalid":
            # Red warning: invalid license
            icon = style.standardIcon(QStyle.SP_MessageBoxWarning)
            self._lbl_license.setPixmap(icon.pixmap(16, 16))
            self._lbl_license.setToolTip(i18n.tr("license_tooltip_invalid"))
        else:  # portable
            # Neutral help icon: portable version, no license binding
            icon = style.standardIcon(QStyle.SP_DialogHelpButton)
            self._lbl_license.setPixmap(icon.pixmap(16, 16))
            self._lbl_license.setToolTip(i18n.tr("license_tooltip_portable"))

    def _build_trigger_source(self):
        """Instantiate the appropriate TriggerSource based on settings."""
        mode = app_config.get_trigger_source_mode()
        if mode == "serial_line":
            port = app_config.get_trigger_source_com_port()
            baud = app_config.get_trigger_source_baud_rate()
            expected = app_config.get_trigger_source_expected_string()
            if not port:
                self.statusBar().showMessage(i18n.tr("trigger_source_open_failed", port="(empty)"))
                return trigger_source.ManualTriggerSource(self)
            self.statusBar().showMessage(i18n.tr("trigger_source_open_failed", port=port))
            src = trigger_source.SerialLineTriggerSource(
                port_name=port, baud_rate=baud, expected_string=expected, parent=self
            )
            src.signal_received.connect(self._on_trigger_source_signal)
            src.start()
            return src
        return trigger_source.ManualTriggerSource(self)

    def _on_trigger_source_signal(self):
        """Handle incoming trigger from sensor or manual source."""
        self._trigger_controller.start_cycle(manual=True)

    def _on_trigger_requested(self):
        """Send the actual trigger command to the scanner."""
        self._send_trigger_raw()

    def _on_trigger_cycle_exhausted(self):
        """Max retries reached -> escalate to manual entry."""
        self._on_scan_timeout()

    def _on_trigger_scan_received(self):
        """A scan arrived during an active cycle (already handled)."""
        self.statusBar().showMessage(i18n.tr("ready_status"))

    def _on_trigger_status_changed(self, text: str):
        if text:
            self.statusBar().showMessage(text)

    def _on_trigger_mode_changed(self, index: int):
        mode = "manual" if index == 0 else "serial_line"
        self._settings["trigger_source_mode"] = mode
        if self._trigger_source:
            self._trigger_source.stop()
        self._trigger_source = self._build_trigger_source()

    def _on_trigger_settings_changed(self):
        self._trigger_policy = trigger_controller.TriggerRetryPolicy(
            max_attempts=self._settings.get("trigger_max_attempts", 5),
            retry_delay_ms=self._settings.get("trigger_retry_delay_ms", 1000),
            per_attempt_timeout_ms=self._scan_timeout_ms,
        )
        self._trigger_controller.set_policy(self._trigger_policy)

    def _tr_text(self, widget, key: str, setter: str = "setText"):
        """Set a translatable text on a widget and register it for re-translation.

        Every translatable label/button/menu/tooltip should be set through this
        helper so that ``retranslate_ui()`` can re-apply the current language to
        *all* registered widgets without a manually maintained list.
        """
        getattr(widget, setter)(i18n.tr(key))
        self._i18n_registry.append((widget, key, setter))

    def _build_ui(self):
        # Wrap the whole content in a scroll area so that when the window
        # is resized very small, the dense panels are not clipped but can
        # be scrolled to (responsive resize behavior).
        scroll = QScrollArea()
        scroll.setObjectName("mainScrollArea")
        scroll.setWidgetResizable(True)
        scroll.setFrameShape(QFrame.NoFrame)
        scroll.setHorizontalScrollBarPolicy(Qt.ScrollBarAsNeeded)
        scroll.setVerticalScrollBarPolicy(Qt.ScrollBarAsNeeded)

        central = QWidget()
        scroll.setWidget(central)
        self.setCentralWidget(scroll)
        layout = QVBoxLayout(central)
        layout.setContentsMargins(10, 10, 10, 10)
        layout.setSpacing(6)

        # ========== Connection Panel ==========
        conn_frame = QFrame()
        conn_frame.setObjectName("connFrame")
        conn_frame.setFrameStyle(QFrame.Box | QFrame.Plain)
        conn_layout = QHBoxLayout(conn_frame)
        conn_layout.setContentsMargins(8, 4, 8, 4)

        self._lbl_com_port = QLabel()
        self._tr_text(self._lbl_com_port, "com_port_label")
        conn_layout.addWidget(self._lbl_com_port)
        self._cmb_port = QComboBox()
        self._cmb_port.setMinimumWidth(110)
        conn_layout.addWidget(self._cmb_port)

        self._btn_refresh = QPushButton()
        # Icon-only button: show a clear refresh icon instead of the translated
        # word (which would be clipped into an unreadable dot in the 28px box).
        self._btn_refresh.setIcon(self.style().standardIcon(QStyle.SP_BrowserReload))
        self._btn_refresh.setIconSize(QSize(16, 16))
        self._btn_refresh.setObjectName("btnRefresh")
        self._btn_refresh.setFixedWidth(30)
        self._tr_text(self._btn_refresh, "tooltip_refresh", "setToolTip")
        self._btn_refresh.clicked.connect(self._refresh_ports)
        conn_layout.addWidget(self._btn_refresh)

        conn_layout.addSpacing(5)
        self._lbl_operator = QLabel()
        self._tr_text(self._lbl_operator, "operator_number_label")
        conn_layout.addWidget(self._lbl_operator)
        self._txt_operator = QLineEdit()
        self._txt_operator.setObjectName("txtOperatorId")
        self._txt_operator.setFixedWidth(110)
        self._txt_operator.setReadOnly(True)
        self._txt_operator.setFocusPolicy(Qt.NoFocus)
        self._txt_operator.setPlaceholderText(i18n.tr("not_logged_in"))
        conn_layout.addWidget(self._txt_operator)

        conn_layout.addSpacing(10)
        self._lbl_baud = QLabel()
        self._tr_text(self._lbl_baud, "baud_rate_label")
        conn_layout.addWidget(self._lbl_baud)
        self._cmb_baud = QComboBox()
        self._cmb_baud.addItems(self.BAUD_RATES)
        self._cmb_baud.setCurrentText("115200")
        self._cmb_baud.setMinimumWidth(90)
        conn_layout.addWidget(self._cmb_baud)

        self._btn_auto_detect = QPushButton()
        self._tr_text(self._btn_auto_detect, "auto_detect_button")
        self._btn_auto_detect.setObjectName("btnAutoDetect")
        self._btn_auto_detect.setMinimumWidth(100)
        self._tr_text(self._btn_auto_detect, "tooltip_auto_detect", "setToolTip")
        self._btn_auto_detect.clicked.connect(self._auto_detect_baud)
        conn_layout.addWidget(self._btn_auto_detect)

        conn_layout.addSpacing(10)
        self._btn_connect = QPushButton()
        self._tr_text(self._btn_connect, "connect_button")
        self._btn_connect.setObjectName("btnConnect")
        self._btn_connect.setMinimumWidth(100)
        self._btn_connect.clicked.connect(self._toggle_connect)
        conn_layout.addWidget(self._btn_connect)

        conn_layout.addSpacing(10)
        self._lbl_status = QLabel()
        self._tr_text(self._lbl_status, "status_led_disconnected")
        self._lbl_status.setObjectName("statusLed")

        self._lbl_status.setProperty("connected", False)
        conn_layout.addWidget(self._lbl_status)

        conn_layout.addSpacing(10)
        self._btn_login = QPushButton()
        self._tr_text(self._btn_login, "login_menu_button")
        self._btn_login.setObjectName("btnLogin")
        self._btn_login.setMinimumWidth(90)
        self._btn_login.clicked.connect(self._login)
        conn_layout.addWidget(self._btn_login)

        self._btn_logout = QPushButton()
        self._tr_text(self._btn_logout, "logout_button")
        self._btn_logout.setObjectName("btnLogout")
        self._btn_logout.setMinimumWidth(90)
        self._btn_logout.clicked.connect(self._logout)
        conn_layout.addWidget(self._btn_logout)

        conn_layout.addSpacing(10)
        self._btn_menu = QToolButton()
        self._tr_text(self._btn_menu, "btn_menu")
        self._tr_text(self._btn_menu, "menu_tooltip", "setToolTip")
        self._btn_menu.setPopupMode(QToolButton.InstantPopup)
        self._menu = QMenu()
        self._menu_trigger = self._menu.addMenu("")
        self._tr_text(self._menu_trigger, "menu_action_trigger_manual", "setTitle")
        self._act_trigger_manual = self._menu_trigger.addAction("", self._send_trigger)
        self._tr_text(self._act_trigger_manual, "menu_action_trigger_manual")
        self._act_trigger_continuous = self._menu_trigger.addAction("", self._toggle_continuous_scan)
        self._tr_text(self._act_trigger_continuous, "menu_action_trigger_continuous")
        self._act_trigger_stop = self._menu_trigger.addAction("", self._send_stop)
        self._tr_text(self._act_trigger_stop, "menu_action_trigger_stop")
        self._act_manual_entry = self._menu.addAction("", self._on_manual_entry_clicked)
        self._tr_text(self._act_manual_entry, "manual_entry_button")
        self._menu.addSeparator()
        self._act_settings = self._menu.addAction("", self._on_settings_clicked)
        self._tr_text(self._act_settings, "menu_action_settings")
        self._act_user_management = self._menu.addAction("", self._on_user_management_clicked)
        self._tr_text(self._act_user_management, "admin_user_management")
        self._act_export = self._menu.addAction("", self._export_scans)
        self._tr_text(self._act_export, "menu_action_export")
        self._menu.addSeparator()
        self._act_help = self._menu.addAction("", self._open_help_dialog)
        self._tr_text(self._act_help, "menu_action_help")
        self._act_restart_tutorial = self._menu.addAction("", self._restart_tutorial)
        self._tr_text(self._act_restart_tutorial, "menu_action_restart_tutorial")
        self._act_about = self._menu.addAction("", self._on_about_clicked)
        self._tr_text(self._act_about, "menu_action_about")
        self._act_login = self._menu.addAction("", self._login)
        self._tr_text(self._act_login, "menu_action_login")
        self._act_logout = self._menu.addAction("", self._logout)
        self._tr_text(self._act_logout, "menu_action_logout")
        self._menu.addSeparator()
        self._act_exit = self._menu.addAction("", self.close)
        self._tr_text(self._act_exit, "menu_action_exit")
        self._btn_menu.setMenu(self._menu)
        conn_layout.addWidget(self._btn_menu)

        conn_layout.addStretch()
        layout.addWidget(conn_frame)

        # ========== Action Row ==========
        action_row = QHBoxLayout()
        action_row.setContentsMargins(0, 0, 0, 0)

        self._btn_retry = QPushButton()
        self._tr_text(self._btn_retry, "retry_button")
        self._btn_retry.setObjectName("btnRetry")
        self._btn_retry.setMinimumWidth(100)
        self._btn_retry.setEnabled(False)
        self._btn_retry.clicked.connect(self._on_retry_clicked)
        action_row.addWidget(self._btn_retry)

        self._btn_manual_entry = QPushButton()
        self._tr_text(self._btn_manual_entry, "manual_entry_button")
        self._btn_manual_entry.setObjectName("btnManualEntry")
        self._btn_manual_entry.setMinimumWidth(120)
        self._btn_manual_entry.setEnabled(False)
        self._btn_manual_entry.clicked.connect(self._on_manual_entry_clicked)
        action_row.addWidget(self._btn_manual_entry)

        self._btn_trigger = QPushButton()
        self._tr_text(self._btn_trigger, "trigger_button")
        self._btn_trigger.setObjectName("btnTrigger")
        self._btn_trigger.setMinimumWidth(90)
        self._btn_trigger.setEnabled(False)
        self._btn_trigger.clicked.connect(self._send_trigger)
        action_row.addWidget(self._btn_trigger)

        self._btn_continuous = QPushButton()
        self._tr_text(self._btn_continuous, "continuous_scan_button")
        self._btn_continuous.setObjectName("btnContinuousScan")
        self._btn_continuous.setMinimumWidth(130)
        self._btn_continuous.setEnabled(False)
        self._btn_continuous.setCheckable(True)
        self._btn_continuous.setChecked(False)
        self._btn_continuous.clicked.connect(self._toggle_continuous_scan)
        action_row.addWidget(self._btn_continuous)

        # CCD calibration controls remain visible in the operational window.
        # They are enabled only for a connected administrator session.
        self._btn_autofocus = QPushButton()
        self._tr_text(self._btn_autofocus, "autofocus_button")
        self._btn_autofocus.setObjectName("btnAutoFocus")
        self._btn_autofocus.setMinimumWidth(100)
        self._btn_autofocus.setEnabled(False)
        self._btn_autofocus.clicked.connect(self._start_autofocus_only)
        action_row.addWidget(self._btn_autofocus)

        self._btn_auto_tuning = QPushButton()
        self._tr_text(self._btn_auto_tuning, "auto_tuning_button")
        self._btn_auto_tuning.setObjectName("btnAutoTuning")
        self._btn_auto_tuning.setMinimumWidth(105)
        self._btn_auto_tuning.setEnabled(False)
        self._btn_auto_tuning.clicked.connect(self._start_tuning)
        action_row.addWidget(self._btn_auto_tuning)

        self._btn_calibration = QPushButton()
        self._tr_text(self._btn_calibration, "autofocus_then_tuning_button")
        self._btn_calibration.setObjectName("btnCalibration")
        self._btn_calibration.setMinimumWidth(165)
        self._btn_calibration.setEnabled(False)
        self._btn_calibration.clicked.connect(self._start_autofocus_then_tuning)
        action_row.addWidget(self._btn_calibration)

        self._btn_stop = QPushButton()
        self._tr_text(self._btn_stop, "stop_button")
        self._btn_stop.setObjectName("btnStop")
        self._btn_stop.setMinimumWidth(90)
        self._btn_stop.setEnabled(False)
        self._btn_stop.clicked.connect(self._send_stop)
        action_row.addWidget(self._btn_stop)

        action_row.addSpacing(20)
        self._lbl_tx_log = QLabel("")
        self._lbl_tx_log.setObjectName("txLog")
        action_row.addWidget(self._lbl_tx_log)

        action_row.addSpacing(20)
        self._lbl_lang = QLabel()
        self._tr_text(self._lbl_lang, "lang_selector_label")
        action_row.addWidget(self._lbl_lang)
        self._cmb_language = QComboBox()
        self._cmb_language.addItems(list(i18n.LANGUAGE_NAMES.values()))
        self._cmb_language.setCurrentText(i18n.LANGUAGE_NAMES.get(i18n.get_language(), "English"))
        self._cmb_language.setMinimumWidth(120)
        self._cmb_language.currentIndexChanged.connect(self._on_language_changed)
        action_row.addWidget(self._cmb_language)

        action_row.addStretch()
        layout.addLayout(action_row)

        # ========== Scan Table ==========

        # Use a stacked layout so we can show a placeholder when empty
        table_container = QWidget()
        table_container.setObjectName("tableContainer")
        self._table_stack = QStackedLayout(table_container)
        self._table_stack.setContentsMargins(0, 0, 0, 0)

        self._lbl_table_empty = QLabel("")
        self._lbl_table_empty.setObjectName("tableEmptyHint")
        self._lbl_table_empty.setAlignment(Qt.AlignCenter)
        self._lbl_table_empty.setWordWrap(True)
        self._table_stack.addWidget(self._lbl_table_empty)

        self._table = QTableWidget(0, 7)
        self._table.setHorizontalHeaderLabels([
            i18n.tr("col_time"), i18n.tr("col_operator"),
            i18n.tr("col_status"), i18n.tr("col_barcode"),
            i18n.tr("col_input_source"), i18n.tr("col_image"),
            i18n.tr("col_save_status"),
        ])
        self._table.horizontalHeader().setStretchLastSection(False)
        self._table.horizontalHeader().setSectionResizeMode(0, QHeaderView.ResizeToContents)
        self._table.horizontalHeader().setSectionResizeMode(1, QHeaderView.ResizeToContents)
        self._table.horizontalHeader().setSectionResizeMode(2, QHeaderView.ResizeToContents)
        self._table.horizontalHeader().setSectionResizeMode(3, QHeaderView.Stretch)
        self._table.horizontalHeader().setSectionResizeMode(4, QHeaderView.ResizeToContents)
        self._table.horizontalHeader().setSectionResizeMode(5, QHeaderView.ResizeToContents)
        self._table.horizontalHeader().setSectionResizeMode(6, QHeaderView.ResizeToContents)
        self._table.verticalHeader().setVisible(False)
        self._table.setSelectionBehavior(QAbstractItemView.SelectRows)
        self._table.setSelectionMode(QAbstractItemView.ExtendedSelection)
        self._table.setEditTriggers(QAbstractItemView.NoEditTriggers)
        self._table.setAlternatingRowColors(True)
        self._table.setShowGrid(True)
        mono_font = QFont("Consolas", 11)
        self._table.setFont(mono_font)
        self._table.itemSelectionChanged.connect(self._on_selection_changed)
        self._table.cellDoubleClicked.connect(self._on_cell_double_clicked)
        self._scan_table = ScanTablePresenter(self._table)
        self._table_stack.addWidget(self._table)

        layout.addWidget(table_container, 1)
        self._sync_table_empty_state()

        # ========== Bottom Toolbar ==========
        toolbar = QHBoxLayout()
        self._btn_copy_selected = QPushButton()
        self._btn_copy_selected.setObjectName("toolbarBtn")
        self._tr_text(self._btn_copy_selected, "copy_selected_button")

        self._btn_copy_selected.setEnabled(False)
        self._btn_copy_selected.clicked.connect(self._copy_selected)
        toolbar.addWidget(self._btn_copy_selected)

        self._btn_copy_all = QPushButton()
        self._btn_copy_all.setObjectName("toolbarBtn")
        self._tr_text(self._btn_copy_all, "copy_all_button")

        self._btn_copy_all.clicked.connect(self._copy_all)
        toolbar.addWidget(self._btn_copy_all)

        self._btn_clear = QPushButton()
        self._btn_clear.setObjectName("btnClear")
        self._tr_text(self._btn_clear, "clear_button")

        self._btn_clear.clicked.connect(self._clear_list)
        toolbar.addWidget(self._btn_clear)

        self._btn_export = QPushButton()
        self._btn_export.setObjectName("toolbarBtn")
        self._tr_text(self._btn_export, "export_button")

        self._btn_export.clicked.connect(self._export_scans)
        toolbar.addWidget(self._btn_export)

        toolbar.addSpacing(10)
        self._chk_ignore_dupes = QCheckBox()
        self._tr_text(self._chk_ignore_dupes, "ignore_dupes_checkbox")
        self._chk_ignore_dupes.stateChanged.connect(self._on_dupe_toggle)
        toolbar.addWidget(self._chk_ignore_dupes)

        toolbar.addStretch()
        self._lbl_scan_count = QLabel(i18n.tr("scans_count", count=0))
        self._lbl_scan_count.setObjectName("scanCount")

        toolbar.addWidget(self._lbl_scan_count)
        layout.addLayout(toolbar)

        self._lbl_copy_flash = QLabel("")
        self._lbl_copy_flash.setObjectName("copyFlash")
        layout.addWidget(self._lbl_copy_flash)

        # License status indicator in the status bar (right side)
        self.statusBar().showMessage(i18n.tr("ready_status"))
        self._lbl_license = QLabel()
        self._lbl_license.setObjectName("licenseIndicator")
        self._lbl_license.setFixedSize(20, 20)
        self._lbl_license.setAlignment(Qt.AlignCenter)
        self.statusBar().addPermanentWidget(self._lbl_license)
        self._setup_license_indicator()
        self._admin_only_widgets = [
            self._btn_copy_selected, self._btn_copy_all, self._btn_clear,
            self._btn_export, self._chk_ignore_dupes,
            self._btn_refresh, self._btn_auto_detect, self._lbl_baud, self._cmb_baud,
            self._lbl_lang, self._cmb_language, self._btn_menu,
            self._btn_autofocus, self._btn_auto_tuning, self._btn_calibration,
            self._act_settings, self._act_user_management, self._act_export,
            self._act_help, self._act_restart_tutorial, self._act_about,
        ]
        self._apply_role_ui()
        self._clipboard = QApplication.clipboard()

    # ========== Session / Roles ==========

    def _current_operator_id(self) -> str:
        return self._current_user.login_id if self._current_user is not None else ""

    def _require_login(self) -> bool:
        if self._current_user is not None:
            return True
        self.statusBar().showMessage(i18n.tr("session_login_required"))
        self._login()
        return self._current_user is not None

    def _login(self):
        if self._current_user is not None:
            self._focus_primary_action()
            return
        dialog = login_dialog.LoginDialog(self)
        if dialog.exec() != QDialog.Accepted:
            return
        user = dialog.get_authenticated_user()
        if user is None:
            return
        self._current_user = user
        self._apply_role_ui()
        self.statusBar().showMessage(
            i18n.tr("logged_in_as") + f" {user.login_id} ({i18n.tr('role_admin') if user.is_admin else i18n.tr('role_operator')})"
        )
        self._focus_primary_action()

    def _logout(self):
        if self._current_user is None:
            return
        self._trigger_controller.stop()
        self._continuous_scan_active = False
        if self._btn_continuous.isChecked():
            self._btn_continuous.blockSignals(True)
            self._btn_continuous.setChecked(False)
            self._btn_continuous.blockSignals(False)
        self._pending_ng_row = None
        self._pending_ng_scan = None
        self._btn_retry.setEnabled(False)
        self._btn_manual_entry.setEnabled(False)
        if self._worker.is_connected():
            self._worker.request_disconnect()
        self._current_user = None
        self._operator_manual_input_available = False
        self._apply_role_ui()
        self.statusBar().showMessage(i18n.tr("session_logged_out"))
        QTimer.singleShot(0, self._btn_login.setFocus)

    def _on_user_management_clicked(self):
        if self._current_user is None or not self._current_user.is_admin:
            return
        if self._user_management_dialog is None:
            self._user_management_dialog = user_management_dialog.UserManagementDialog(self)
        self._user_management_dialog.show()
        self._user_management_dialog.raise_()
        self._user_management_dialog.activateWindow()

    def _focus_primary_action(self):
        """Focus the next safe production action for keyboard operation."""
        def focus():
            if not self.isVisible():
                return
            overlay = getattr(self, "_tutorial_overlay", None)
            if overlay is not None and overlay.isVisible():
                return
            if self._current_user is None:
                target = self._btn_login
            elif self._worker.is_connected():
                target = self._btn_trigger
            else:
                target = self._btn_connect
            target.setFocus(Qt.OtherFocusReason)
        QTimer.singleShot(0, focus)

    def _apply_role_ui(self):
        logged_in = self._current_user is not None
        is_admin = logged_in and self._current_user.is_admin
        operator_id = self._current_operator_id()
        self._txt_operator.setText(operator_id)
        self._txt_operator.setPlaceholderText(i18n.tr("not_logged_in"))
        self._btn_login.setVisible(not logged_in)
        self._btn_logout.setVisible(logged_in)
        self._act_login.setVisible(not logged_in)
        self._act_logout.setVisible(logged_in)
        self._act_manual_entry.setVisible(logged_in)
        self._menu_trigger.menuAction().setVisible(logged_in)
        for widget in self._admin_only_widgets:
            widget.setVisible(is_admin)
        self._btn_connect.setEnabled(logged_in and not self._worker.is_connected())
        connected = logged_in and self._worker.is_connected()
        self._btn_trigger.setEnabled(connected)
        self._btn_stop.setEnabled(connected)
        self._btn_continuous.setEnabled(connected)
        calibration_enabled = connected and is_admin
        self._btn_autofocus.setEnabled(calibration_enabled and not self._combined_calibration_active)
        self._btn_auto_tuning.setEnabled(calibration_enabled and not self._combined_calibration_active)
        self._btn_calibration.setEnabled(calibration_enabled and not self._combined_calibration_active)
        self._btn_retry.setEnabled(connected and self._pending_ng_row is not None)
        manual_allowed = bool(
            self._current_user
            and self._current_user.can_manual_entry
            and (is_admin or self._operator_manual_input_available)
        )
        self._btn_manual_entry.setEnabled(connected and manual_allowed)
        self._chk_ignore_dupes.setChecked(
            True if not is_admin else bool(self._settings.get("ignore_duplicates", True))
        )

    # ========== Connection ==========

    def _refresh_ports(self):
        previous = self._cmb_port.currentText()
        self._cmb_port.clear()
        self._cmb_port.addItems(enumerate_ports())
        idx = self._cmb_port.findText(previous)
        if idx >= 0:
            self._cmb_port.setCurrentIndex(idx)

    def _toggle_connect(self):
        print("[MainWindow] _toggle_connect called")
        if not self._worker.is_connected() and not self._require_login():
            return
        if self._worker.is_connected():
            print("[MainWindow] Requesting disconnect")
            self._worker.request_disconnect()
        else:
            port = self._cmb_port.currentText()
            if not port:
                self.statusBar().showMessage(i18n.tr("please_select_port"))
                return
            try:
                baud = int(self._cmb_baud.currentText())
            except ValueError:
                baud = 115200
            print(f"[MainWindow] Requesting connect to {port} @ {baud}")
            self._worker.request_connect(port, baud)
        QTimer.singleShot(500, self._check_worker_alive)

    def _check_worker_alive(self):
        if not self._worker.isRunning():
            print("[MainWindow] Worker thread is dead! Restarting...")
            self._worker = SerialReaderWorker()
            self._worker.scan_received.connect(self._on_scan_received)
            self._worker.error_occurred.connect(self._on_error)
            self._worker.connected_changed.connect(self._on_connected_changed)
            self._worker.command_response.connect(self._on_command_response)
            self._worker.connection_lost.connect(self._on_connection_lost)
            self._worker.image_capture_ready.connect(self._on_image_ready)
            self._worker.image_capture_failed.connect(self._on_image_failed)
            self._worker.start()

            port = self._settings.get("last_com_port", self._cmb_port.currentText())
            if port:
                try:
                    baud = int(self._cmb_baud.currentText())
                except ValueError:
                    baud = 115200
                self._worker.request_connect(port, baud)

    def _send_trigger_raw(self) -> bool:
        """Queue the raw trigger command and update the visible transmission state."""
        if not self._require_login():
            return False
        cmd = b"\x1bZ\r"
        if not self._worker.send_raw_command(cmd):
            self.statusBar().showMessage(i18n.tr("not_connected_short"))
            return False
        self._lbl_tx_log.setText(i18n.tr("tx_log_prefix") + f" {cmd.hex(' ')}")
        QTimer.singleShot(2000, lambda: self._lbl_tx_log.setText(""))
        # TriggerController owns retry timing. The legacy one-shot timer is
        # intentionally not started here, otherwise it would open manual
        # entry while configured automatic retries are still in progress.
        self.statusBar().showMessage(i18n.tr("waiting_for_scan_status"))
        return True

    def _send_trigger(self):
        if not self._require_login():
            return
        if not self._worker.is_connected():
            self.statusBar().showMessage(i18n.tr("not_connected_short"))
            return
        if self._current_user is not None and not self._current_user.is_admin:
            self._operator_manual_input_available = True
            self._apply_role_ui()
        self._trigger_controller.start_cycle(manual=True)

    def _send_stop(self):
        if not self._worker.is_connected():
            self.statusBar().showMessage(i18n.tr("not_connected_short"))
            return
        self._trigger_controller.stop()
        cmd = b"\x1bY\r"
        if not self._worker.send_raw_command(cmd):
            self.statusBar().showMessage(i18n.tr("stop_failed_status", error="serial port unavailable"))
            return
        self._lbl_tx_log.setText(i18n.tr("tx_log_prefix") + f" {cmd.hex(' ')}")
        QTimer.singleShot(2000, lambda: self._lbl_tx_log.setText(""))

    def _on_retry_clicked(self):
        """Run a new retry cycle for the current pending NG row."""
        if not self._require_login():
            return
        if not self._worker.is_connected():
            self.statusBar().showMessage(i18n.tr("not_connected_short"))
            return
        # Use the same retry controller as the primary Trigger action so the
        # button gets the configured retry policy and final manual-entry path.
        if self._current_user is not None and not self._current_user.is_admin:
            self._operator_manual_input_available = True
            self._apply_role_ui()
        self._trigger_controller.start_cycle(manual=True)
        self.statusBar().showMessage(i18n.tr("retry_triggered_status"))

    def _on_manual_entry_clicked(self):
        """Enter one Wafer ID manually and mark it as manual in the table."""
        if not self._require_login():
            return
        if not self._current_user.can_manual_entry:
            self.statusBar().showMessage(i18n.tr("manual_entry_permission_denied"))
            return

        entry_dialog = manual_entry_dialog.ManualEntryDialog(self)
        if entry_dialog.exec() != QDialog.Accepted:
            self._focus_primary_action()
            return
        normalized = entry_dialog.wafer_id()
        if not normalized:
            self._focus_primary_action()
            return
        if self._should_ignore_duplicate(normalized):
            self.statusBar().showMessage(
                i18n.tr("duplicate_scan_ignored").format(barcode=normalized)
            )
            return

        timestamp = datetime.now()
        operator_id = self._current_operator_id()
        _save_success, save_status_text, saved_path = self._save_scan_file(
            wafer_id=normalized,
            operator_id=operator_id,
            timestamp=timestamp,
        )
        scan = Scan(
            timestamp=timestamp,
            barcode_value=normalized,
            operator_id=operator_id,
            status="GOOD (manual)",
            is_manual=True,
            wafer_id=normalized,
            folder_path=str(Path(saved_path).parent) if saved_path else "",
            saved_file_path=str(saved_path) if saved_path else "",
            save_status=save_status_text,
            input_source=i18n.tr("input_source_manual"),
        )
        self.statusBar().showMessage(
            i18n.tr("manual_entry_completed").format(path=saved_path or "")
        )

        if self._pending_ng_scan is not None:
            row = self._scan_table.row_for_scan(self._pending_ng_scan)
            if row < 0:
                row = self._pending_ng_row if self._pending_ng_row is not None else -1
            if row >= 0:
                self._replace_scan_row(row, scan, highlight_ng=False)
            for index, existing in enumerate(self._scans):
                if existing is self._pending_ng_scan:
                    self._scans[index] = scan
                    break
            else:
                self._scans.append(scan)
            self._pending_ng_row = None
            self._pending_ng_scan = None
        else:
            self._append_scan_row(scan, highlight_ng=False)
            self._scans.append(scan)
        self._seen_barcode_values.add(normalized)
        self._btn_retry.setEnabled(False)
        if self._current_user is not None and not self._current_user.is_admin:
            self._operator_manual_input_available = False
        self._apply_role_ui()
        self._table.scrollToTop()
        self._update_scan_count()
        self._focus_primary_action()

    def _toggle_continuous_scan(self, checked: bool):
        if checked and not self._require_login():
            self._btn_continuous.blockSignals(True)
            self._btn_continuous.setChecked(False)
            self._btn_continuous.blockSignals(False)
            return
        if checked:
            if not self._worker.is_connected():
                self.statusBar().showMessage(i18n.tr("not_connected_short"))
                self._btn_continuous.setChecked(False)
                return
            self._continuous_scan_active = True
            self._send_trigger_raw()
            self._btn_trigger.setEnabled(False)
            self.statusBar().showMessage(i18n.tr("continuous_scan_active_status"))
        else:
            self._continuous_scan_active = False
            self._send_stop()
            self._btn_trigger.setEnabled(True)
            self.statusBar().showMessage(i18n.tr("continuous_scan_stopped_status"))

    def _auto_detect_baud(self):
        port = self._cmb_port.currentText()
        if not port:
            self.statusBar().showMessage(i18n.tr("please_select_port_first"))
            return
        if self._worker.is_connected():
            self.statusBar().showMessage(i18n.tr("disconnect_first"))
            return
        self._btn_auto_detect.setEnabled(False)
        self._btn_auto_detect.setText(i18n.tr("auto_detect_detecting"))
        self._cmb_baud.setEnabled(False)
        self._btn_connect.setEnabled(False)
        self._btn_refresh.setEnabled(False)
        self._cmb_port.setEnabled(False)
        self._detect_thread = QThread(self)
        self._detect_worker = _BaudDetectWorker(port, self.BAUD_RATES)
        self._detect_worker.moveToThread(self._detect_thread)
        self._detect_thread.started.connect(self._detect_worker.run)
        self._detect_worker.finished.connect(self._on_detect_finished)
        self._detect_worker.finished.connect(self._detect_thread.quit)
        self._detect_worker.finished.connect(self._detect_worker.deleteLater)
        self._detect_thread.finished.connect(self._detect_thread.deleteLater)
        self._detect_thread.start()

    def _on_detect_finished(self, found_baud: int | None):
        self._btn_auto_detect.setEnabled(True)
        self._btn_auto_detect.setText(i18n.tr("auto_detect_button"))
        self._cmb_baud.setEnabled(True)
        self._btn_connect.setEnabled(True)
        self._btn_refresh.setEnabled(True)
        self._cmb_port.setEnabled(True)
        if found_baud is not None:
            idx = self._cmb_baud.findText(str(found_baud))
            if idx >= 0:
                self._cmb_baud.setCurrentIndex(idx)
            self.statusBar().showMessage(i18n.tr("auto_detect_success", baud=found_baud))
        else:
            self.statusBar().showMessage(i18n.tr("auto_detect_no_response"))

    def _on_connected_changed(self, connected: bool):
        if connected:
            self._lbl_status.setText(i18n.tr("status_connected"))
            self._lbl_status.setProperty("connected", True)
            self._lbl_status.style().polish(self._lbl_status)
            self._btn_connect.setText(i18n.tr("disconnect_button"))
            self._cmb_port.setEnabled(False)
            self._cmb_baud.setEnabled(False)
            self._btn_auto_detect.setEnabled(False)
            self._btn_refresh.setEnabled(False)
            self._btn_trigger.setEnabled(self._current_user is not None)
            self._btn_stop.setEnabled(self._current_user is not None)
            self._btn_continuous.setEnabled(self._current_user is not None)
            port_name = self._worker.port_name or self._cmb_port.currentText()
            self.statusBar().showMessage(i18n.tr("connected_to_status", port=port_name))
        else:
            self._lbl_status.setText(i18n.tr("status_disconnected"))
            self._lbl_status.setProperty("connected", False)
            self._lbl_status.style().polish(self._lbl_status)
            self._btn_connect.setText(i18n.tr("connect_button"))
            self._cmb_port.setEnabled(True)
            self._cmb_baud.setEnabled(True)
            self._btn_auto_detect.setEnabled(True)
            self._btn_refresh.setEnabled(True)
            self._btn_trigger.setEnabled(False)
            self._btn_stop.setEnabled(False)
            self._btn_continuous.setEnabled(False)
            self._btn_retry.setEnabled(False)
            self._btn_manual_entry.setEnabled(False)
            self._pending_ng_row = None
            self._pending_ng_scan = None
            if self._btn_continuous.isChecked():
                self._btn_continuous.blockSignals(True)
                self._btn_continuous.setChecked(False)
                self._btn_continuous.blockSignals(False)
                self._continuous_scan_active = False
            current = self.statusBar().currentMessage()
            for kw in ["Connected", "Verbunden", "已連線"]:
                if kw in current:
                    self.statusBar().showMessage(i18n.tr("disconnected_status_bar"))
                    break
        self._apply_role_ui()
        if connected and self._current_user is not None and not self._current_user.is_admin:
            self._operator_manual_input_available = True
            self._apply_role_ui()
        if connected:
            self._focus_primary_action()

    def _on_connection_lost(self, message: str):
        """Handle unexpected connection loss from the serial reader thread."""
        self.statusBar().showMessage(i18n.tr("connection_lost_status").format(error=message))
        # The connected_changed signal will also be emitted, which handles UI state

    def _on_error(self, message: str):
        self.statusBar().showMessage(self._friendly_serial_error(message))

    def _friendly_serial_error(self, message: str) -> str:
        """Translate common Windows serial failures into recovery guidance."""
        text = str(message or "")
        lowered = text.lower()
        port = self._cmb_port.currentText().strip() or "COM port"
        if "access denied" in lowered or "permissionerror" in lowered:
            return i18n.tr("serial_port_access_denied", port=port)
        if "port not found" in lowered or "file not found" in lowered:
            return i18n.tr("serial_port_not_found", port=port)
        return i18n.tr("serial_port_open_failed", port=port, error=text)

    # ========== Prefix/Suffix ==========

    def _evaluate_barcode(self, value: str) -> bool:
        """Return True (GOOD) if value matches prefix/suffix rules, else False (NG).

        Prefix/suffix are read from ``self._settings`` (the single source of
        truth) since the corresponding widgets now live in the Settings dialog.
        """
        prefix = self._settings.get("barcode_prefix", "").strip()
        suffix = self._settings.get("barcode_suffix", "").strip()
        if prefix and not value.startswith(prefix):
            return False
        if suffix and not value.endswith(suffix):
            return False
        return True

    # ========== Tuning / Bank ==========

    def _send_tuning_command(self, key: str, bank_param: str = "") -> bool:
        if not self._worker.is_connected():
            self.statusBar().showMessage(i18n.tr("not_connected_short"))
            return False
        if key == "select_bank":
            cmd_id = f"BRA {bank_param}"
        elif key == "auto_focus":
            cmd_id = app_config.get_autofocus_command()
            if not cmd_id:
                self.statusBar().showMessage(
                    i18n.tr("command_failed_status", error="autofocus command is empty")
                )
                return False
        else:
            info = TUNING_CMDS.get(key)
            if info is None:
                return False
            cmd_id = info[0]
        try:
            timeout = 2000
            expected = 1
            if key in TUNING_CMDS and TUNING_CMDS[key]:
                timeout = TUNING_CMDS[key][2]
                expected = TUNING_CMDS[key][1]
            self._worker.send_command(cmd_id, timeout_ms=timeout, expected_lines=expected)
            return True
        except Exception as e:
            self.statusBar().showMessage(i18n.tr("command_failed_status", error=str(e)))
            return False

    def _tuning_set_busy(self, busy: bool):
        if self._settings_dialog is not None:
            self._settings_dialog.set_tuning_busy(busy)

    def _get_current_bank(self):
        self._tuning_result_clear()
        self._send_tuning_command("get_current_bank")

    def _selected_bank(self) -> str:
        if self._settings_dialog is not None:
            return self._settings_dialog.get_selected_bank()
        return "01"

    def _tuning_result_set(self, text: str):
        self._tuning_result_value = text
        if self._settings_dialog is not None:
            self._settings_dialog.set_tuning_result(text)

    def _tuning_result_clear(self):
        self._tuning_result_set("")

    def _current_bank_set(self, text: str):
        self._current_bank_value = text
        if self._settings_dialog is not None:
            self._settings_dialog.set_current_bank(text)

    def _select_bank(self):
        bank = self._selected_bank()
        if len(bank) != 2 or not bank.isdigit():
            self.statusBar().showMessage(i18n.tr("invalid_bank_msg"))
            return
        param = f"Q0Q{bank[0]}Q{bank[1]}"
        self._tuning_result_clear()
        if self._send_tuning_command("select_bank", bank_param=param):
            self.statusBar().showMessage(i18n.tr("bank_selected_status", bank=bank))

    def _calibration_is_allowed(self) -> bool:
        if self._current_user is None or not self._current_user.is_admin:
            self.statusBar().showMessage(i18n.tr("calibration_admin_required"))
            return False
        if not self._worker.is_connected():
            self.statusBar().showMessage(i18n.tr("not_connected_short"))
            return False
        return True

    def _start_autofocus_only(self):
        """Send Auto Focus alone for positioning and diagnostic use."""
        if not self._calibration_is_allowed() or self._combined_calibration_active:
            return
        self._calibration_phase = "autofocus_only"
        self._calibration_autofocus_command = app_config.get_autofocus_command()
        self._calibration_autofocus_answered = False
        self._calibration_autofocus_ok = False
        self._tuning_result_clear()
        self._tuning_set_busy(True)
        if self._send_tuning_command("auto_focus"):
            self._calibration_timeout_timer.start(TUNING_CMDS["auto_focus"][2])
            self.statusBar().showMessage(i18n.tr("autofocus_in_progress"))
        else:
            self._calibration_phase = ""
            self._tuning_set_busy(False)

    def _start_autofocus_then_tuning(self):
        """Run the screenshot workflow: Auto Focus first, then Auto Tuning."""
        if not self._calibration_is_allowed():
            return
        if self._combined_calibration_active:
            return
        self._combined_calibration_active = True
        self._calibration_phase = "autofocus"
        self._calibration_autofocus_command = app_config.get_autofocus_command()
        self._calibration_autofocus_answered = False
        self._calibration_autofocus_ok = False
        self._calibration_locate_attempt = 0
        self._calibration_tuning_attempt = 0
        self._calibration_verify_attempt = 0
        self._calibration_relocate_retunes = 0
        self._tuning_response_count = 0
        self._tuning_result_clear()
        self._tuning_set_busy(True)
        if not self._send_tuning_command("auto_focus"):
            self._finish_combined_calibration(False, "could not send Auto Focus command")
            return
        self._calibration_timeout_timer.start(TUNING_CMDS["auto_focus"][2])
        self.statusBar().showMessage(i18n.tr("autofocus_in_progress"))

    def _proceed_after_autofocus(self):
        """Continue the combined calibration with image-guided Auto Tuning.

        The Auto Focus step is deliberately non-blocking: engines whose
        firmware does not implement the configured Auto Focus command stay
        silent (or reject it), but Auto Tuning remains valid on its own, so
        the calibration always reaches the tuning stage.
        """
        if self._calibration_autofocus_answered and self._calibration_autofocus_ok:
            self.statusBar().showMessage(i18n.tr("autofocus_complete_status"))
        elif self._calibration_autofocus_answered:
            self.statusBar().showMessage(
                i18n.tr("autofocus_rejected_status", line=self._calibration_rejection_line)
            )
        else:
            self.statusBar().showMessage(
                i18n.tr("autofocus_no_response_status", command=self._calibration_autofocus_command)
            )
        self._begin_barcode_locate()

    def _begin_barcode_locate(self):
        """Capture a CCD frame and locate the barcode the operator positioned."""
        self._calibration_phase = "locate"
        self._tuning_response_count = 0
        self._calibration_barcode = None
        self._calibration_read_data = ""
        self._calibration_decode_area_active = False
        self._calibration_locate_attempt = 0
        self._request_locate_capture()

    def _request_locate_capture(self) -> None:
        """Queue the next locate capture (first or a retry)."""
        if not self._request_calibration_capture("locate"):
            # Capture unavailable: tune without area restriction.
            self._start_tuning_for_calibration(None)
            return
        self._calibration_timeout_timer.start(CALIBRATION_CAPTURE_TIMEOUT_MS)
        if self._calibration_locate_attempt > 0:
            self.statusBar().showMessage(
                i18n.tr(
                    "autofocus_locate_retry_status",
                    attempt=self._calibration_locate_attempt,
                    maximum=CALIBRATION_LOCATE_ATTEMPTS,
                )
            )
        else:
            self.statusBar().showMessage(i18n.tr("autofocus_locating_status"))

    def _on_locate_unavailable(self) -> None:
        """A locate capture failed/timed out: retry or fall back to plain tuning."""
        if self._calibration_locate_attempt + 1 >= CALIBRATION_LOCATE_ATTEMPTS:
            self.statusBar().showMessage(i18n.tr("autofocus_barcode_not_found_status"))
            self._start_tuning_for_calibration(self._calibration_barcode)
            return
        self._calibration_locate_attempt += 1
        self._request_locate_capture()

    def _request_calibration_capture(self, purpose: str) -> bool:
        """Queue one CCD capture for the calibration workflow."""
        if not self._worker.is_connected():
            return False
        try:
            return bool(
                self._worker.request_image_capture(
                    _CalibrationCapture(purpose), timeout_ms=4000
                )
            )
        except Exception:
            return False

    def _start_tuning_for_calibration(self, location, broaden: bool = False):
        """Restrict the decode area to the located barcode (if any) and tune.

        With the decode area ([DF8) limited to the barcode region, the tuning
        pass can only read THE barcode, so its exposure optimization targets
        exactly that code instead of whatever else is in the field of view.
        ``broaden=True`` is used on a tuning retry: the restriction is dropped
        (full frame) and DT1 is attempted again.
        """
        # Drop any leaked pending command (e.g. a single "Tuning failed" that
        # left the serial reader still expecting a second response line).
        try:
            self._worker.clear_pending_command()
        except Exception:
            pass

        if location is not None and not broaden:
            frames = autofocus.df8_margin_commands(location)
            if frames:
                sent_all = True
                for frame in frames:
                    try:
                        sent_all = self._worker.send_raw_command(frame) and sent_all
                    except Exception:
                        sent_all = False
                if sent_all:
                    self._calibration_decode_area_active = True
        if not self._send_tuning_command("start_tuning"):
            self._finish_combined_calibration(False, "could not send Auto Tuning command")
            return
        self._calibration_phase = "tuning"
        self._tuning_response_count = 0
        self._calibration_timeout_timer.start(TUNING_CMDS["start_tuning"][2])
        if broaden:
            self.statusBar().showMessage(
                i18n.tr(
                    "autofocus_tuning_retry_status",
                    attempt=self._calibration_tuning_attempt,
                    maximum=CALIBRATION_TUNING_ATTEMPTS,
                )
            )
        elif location is None:
            self.statusBar().showMessage(i18n.tr("autofocus_barcode_not_found_status"))
        else:
            self.statusBar().showMessage(
                i18n.tr("autofocus_barcode_found_status", value=location.text)
            )

    def _retry_tuning(self) -> bool:
        """Broaden the decode area and retry DT1 when tuning read nothing.

        Returns True when a retry was scheduled, False when the retry budget
        is exhausted (caller should abort the calibration).
        """
        if self._calibration_tuning_attempt + 1 >= CALIBRATION_TUNING_ATTEMPTS:
            return False
        self._calibration_tuning_attempt += 1
        # Drop the area restriction so the engine sees the full frame.
        self._restore_decode_area()
        self._start_tuning_for_calibration(self._calibration_barcode, broaden=True)
        return True

    def _restore_decode_area(self):
        """Reset a restricted decode area so production scanning is unaffected."""
        if not self._calibration_decode_area_active:
            return
        self._calibration_decode_area_active = False
        try:
            self._worker.send_raw_command(autofocus.df8_reset_command())
        except Exception:
            pass

    def _begin_barcode_verification(self):
        """After tuning, capture a frame and verify the barcode is clear."""
        self._calibration_phase = "verify"
        self._calibration_verify_attempt = 0
        self._restore_decode_area()
        self._request_verify_capture()

    def _request_verify_capture(self) -> None:
        """Queue the next verification capture (first or a retry)."""
        if not self._request_calibration_capture("verify"):
            self._handle_verify_unavailable(capture_failed=True)
            return
        self._calibration_timeout_timer.start(CALIBRATION_CAPTURE_TIMEOUT_MS)
        if self._calibration_verify_attempt > 0:
            self.statusBar().showMessage(
                i18n.tr(
                    "autofocus_verify_retry_status",
                    attempt=self._calibration_verify_attempt,
                    maximum=CALIBRATION_VERIFY_ATTEMPTS,
                )
            )
        else:
            self.statusBar().showMessage(i18n.tr("autofocus_verifying_status"))

    def _handle_verify_unavailable(self, capture_failed: bool = False) -> None:
        """Verification capture failed/timed out or the frame stayed unclear.

        Retries a couple of times (a momentary blurry or badly lit frame is
        common with some barcodes), then completes the calibration anyway -
        the tuning itself already succeeded.
        """
        if self._calibration_verify_attempt + 1 >= CALIBRATION_VERIFY_ATTEMPTS:
            if capture_failed:
                self.statusBar().showMessage(i18n.tr("autofocus_verify_failed_status"))
                self._finish_combined_calibration(
                    True, status_message=i18n.tr("autofocus_verify_failed_status")
                )
            else:
                self._tuning_result_set(i18n.tr("autofocus_verify_unclear_status"))
                self._finish_combined_calibration(
                    True, status_message=i18n.tr("autofocus_verify_unclear_status")
                )
            return
        self._calibration_verify_attempt += 1
        self._request_verify_capture()

    def _on_calibration_image_ready(self, capture, jpeg_bytes) -> None:
        """Handle a calibration CCD capture (locate or verify phase)."""
        if not self._combined_calibration_active:
            return
        if capture.purpose == "locate":
            location = autofocus.locate_barcode(
                jpeg_bytes, wafer_pattern=app_config.get_wafer_id_pattern()
            )
            self._calibration_barcode = location
            if location is not None:
                self._start_tuning_for_calibration(location)
            elif self._calibration_locate_attempt + 1 >= CALIBRATION_LOCATE_ATTEMPTS:
                self.statusBar().showMessage(i18n.tr("autofocus_barcode_not_found_status"))
                self._start_tuning_for_calibration(None)
            else:
                self._calibration_locate_attempt += 1
                self._request_locate_capture()
        elif capture.purpose == "verify":
            self._finish_barcode_verification(jpeg_bytes)

    def _on_calibration_image_failed(self, capture, _reason) -> None:
        if not self._combined_calibration_active:
            return
        if capture.purpose == "locate":
            self._on_locate_unavailable()
        else:
            self._handle_verify_unavailable(capture_failed=True)

    def _finish_barcode_verification(self, jpeg_bytes) -> None:
        """Compare the verification frame against the located barcode."""
        location = self._calibration_barcode
        expected = location.text if location is not None else ""
        if (
            expected
            and self._calibration_read_data
            and self._calibration_read_data != expected
        ):
            # The tuning pass optimized a different code than the located one.
            # Retry from scratch once with a fresh locate (the first frame may
            # have picked the wrong of several visible barcodes).
            if self._calibration_relocate_retunes >= CALIBRATION_RETUNE_ATTEMPTS:
                self._finish_combined_calibration(
                    False,
                    error=i18n.tr(
                        "autofocus_read_mismatch_status",
                        read=self._calibration_read_data,
                        expected=expected,
                    ),
                )
                return
            self._calibration_relocate_retunes += 1
            self._tuning_result_set(i18n.tr("autofocus_retune_status"))
            self.statusBar().showMessage(i18n.tr("autofocus_retune_status"))
            self._begin_barcode_locate()
            return

        decoded = autofocus.locate_barcode(
            jpeg_bytes, wafer_pattern=app_config.get_wafer_id_pattern()
        )
        score = autofocus.sharpness_score(jpeg_bytes, location)
        if decoded is not None and (not expected or decoded.text == expected):
            self._tuning_result_set(
                i18n.tr("autofocus_verified_status", value=decoded.text)
                + f" (clarity {score:.0f})"
            )
            self._finish_combined_calibration(
                True,
                status_message=i18n.tr("autofocus_verified_status", value=decoded.text),
            )
        else:
            self._handle_verify_unavailable(capture_failed=False)

    def _on_calibration_timeout(self):
        if not self._combined_calibration_active:
            if self._calibration_phase == "autofocus_only":
                # Standalone Auto Focus: release the UI and report clearly.
                self._calibration_phase = ""
                self._tuning_set_busy(False)
                self._tuning_result_set(
                    i18n.tr("autofocus_no_response_status", command=self._calibration_autofocus_command)
                )
                self.statusBar().showMessage(
                    i18n.tr("autofocus_no_response_status", command=self._calibration_autofocus_command)
                )
            return
        if self._calibration_phase == "autofocus":
            # The engine did not answer the Auto Focus command within the
            # window (undefined commands stay silent per the serial interface
            # manual).  Tuning must still run instead of failing the workflow.
            self._proceed_after_autofocus()
        elif self._calibration_phase == "locate":
            # The locate capture never completed: retry or fall back to plain tuning.
            self._on_locate_unavailable()
        elif self._calibration_phase == "tuning":
            self._finish_combined_calibration(False, i18n.tr("autotuning_timeout_error"))
        elif self._calibration_phase == "verify":
            self._handle_verify_unavailable(capture_failed=True)

    def _finish_combined_calibration(self, success: bool, error: str = "",
                                     status_message: Optional[str] = None):
        self._calibration_timeout_timer.stop()
        self._combined_calibration_active = False
        self._calibration_phase = ""
        self._restore_decode_area()
        # Drop a possibly leaked pending command so subsequent scanner lines
        # are treated as barcode scans again.
        try:
            self._worker.clear_pending_command()
        except Exception:
            pass
        self._tuning_set_busy(False)
        if hasattr(self, "_btn_autofocus"):
            self._apply_role_ui()
        if success:
            if status_message:
                self.statusBar().showMessage(status_message)
            elif self._calibration_autofocus_answered and self._calibration_autofocus_ok:
                self.statusBar().showMessage(i18n.tr("calibration_complete_status"))
            else:
                self.statusBar().showMessage(i18n.tr("calibration_complete_tuning_only_status"))
        else:
            message = i18n.tr("calibration_failed_status", error=error)
            self._tuning_result_set(message)
            self.statusBar().showMessage(message)

    def _start_tuning(self):
        if not self._calibration_is_allowed() or self._combined_calibration_active:
            return
        self._tuning_response_count = 0
        self._tuning_result_clear()
        self._tuning_set_busy(True)
        if self._send_tuning_command("start_tuning"):
            self.statusBar().showMessage(i18n.tr("tuning_in_progress"))
        else:
            self._tuning_set_busy(False)

    def _stop_tuning(self):
        self._calibration_timeout_timer.stop()
        self._combined_calibration_active = False
        self._calibration_phase = ""
        self._restore_decode_area()
        try:
            self._worker.clear_pending_command()
        except Exception:
            pass
        self._send_tuning_command("stop_tuning")
        self._tuning_set_busy(False)
        self.statusBar().showMessage(i18n.tr("tuning_stopped"))

    def _trigger_with_bank(self):
        bank = self._selected_bank()
        if len(bank) != 2:
            self.statusBar().showMessage(i18n.tr("invalid_bank_short"))
            return
        param = f"Q0Q{bank[0]}Q{bank[1]}"
        self._tuning_result_clear()
        self._send_tuning_command("bank_trigger", bank_param=param)

    def _reset_bank(self):
        bank = self._selected_bank()
        reply = QMessageBox.question(
            self, i18n.tr("confirm_reset_bank"),
            i18n.tr("confirm_reset_bank_msg").format(bank=bank),
            QMessageBox.Yes | QMessageBox.No, QMessageBox.No,
        )
        if reply != QMessageBox.Yes:
            return
        self._tuning_result_clear()
        param = f"Q0Q{bank[0]}Q{bank[1]}"
        self._send_tuning_command("reset_bank", bank_param=param)
        self.statusBar().showMessage(i18n.tr("bank_reset_status", bank=bank))

    def _reset_all_banks(self):
        reply = QMessageBox.question(
            self, i18n.tr("confirm_reset_all_banks"),
            i18n.tr("confirm_reset_all_banks_msg"),
            QMessageBox.Yes | QMessageBox.No, QMessageBox.No,
        )
        if reply != QMessageBox.Yes:
            return
        self._tuning_result_clear()
        self._send_tuning_command("reset_all_banks")
        self.statusBar().showMessage(i18n.tr("all_banks_reset_status"))

    def _tuning_done(self):
        self._tuning_set_busy(False)

    def _on_command_response(self, command_id: str, line: str):
        if command_id == "DGQ":
            self._current_bank_set(line)
            self.statusBar().showMessage(i18n.tr("current_bank_status", bank=line))
            return

        if (
            self._calibration_phase in ("autofocus", "autofocus_only")
            and command_id == self._calibration_autofocus_command
        ):
            self._calibration_autofocus_answered = True
            self._calibration_rejection_line = line
            self._calibration_timeout_timer.stop()
            failed = self._calibration_response_failed(line)
            self._calibration_autofocus_ok = not failed
            if failed:
                # The engine explicitly rejected the Auto Focus command
                # (e.g. "NG" for an undefined command).  Auto Tuning remains
                # valid on its own, so continue instead of aborting.
                self._tuning_result_set(
                    i18n.tr("autofocus_rejected_status", line=line)
                )
            else:
                self._tuning_result_set(line)
            if self._calibration_phase == "autofocus":
                self._proceed_after_autofocus()
            else:  # standalone Auto Focus
                self._calibration_phase = ""
                self._tuning_set_busy(False)
                if failed:
                    self.statusBar().showMessage(
                        i18n.tr("autofocus_rejected_status", line=line)
                    )
                else:
                    self.statusBar().showMessage(i18n.tr("autofocus_done_status"))
            return

        if command_id == "DT1":
            self._tuning_response_count += 1
            if "tuning failed" in str(line).lower():
                self._tuning_result_set(i18n.tr("tuning_failed"))
                if self._combined_calibration_active:
                    # Some barcodes cannot be tuned on the first attempt (e.g.
                    # the restricted decode area misses them).  Retry once with
                    # the full view before reporting failure.
                    if self._retry_tuning():
                        return
                    self._finish_combined_calibration(False, line)
                else:
                    self.statusBar().showMessage(i18n.tr("tuning_failed"))
                    self._tuning_done()
                return
            elif "BANK" in line and "CODETYPE" in line:
                if self._combined_calibration_active:
                    # The last segment is the data the engine read while
                    # tuning; the verification step compares it with the
                    # located barcode.
                    segments = [segment.strip() for segment in str(line).split(":")]
                    if segments:
                        self._calibration_read_data = segments[-1]
                self._parse_tuning_result(line)
            else:
                current = self._tuning_result_value
                self._tuning_result_set((current + "; " + line) if current else line)

            expected_lines = TUNING_CMDS["start_tuning"][1]
            if self._tuning_response_count < expected_lines:
                return
            if self._combined_calibration_active:
                self._begin_barcode_verification()
            else:
                self.statusBar().showMessage(i18n.tr("tuning_complete"))
                self._tuning_done()
            return
        if command_id == "DT2":
            self._tuning_result_set(i18n.tr("tuning_stopped"))
            self.statusBar().showMessage(i18n.tr("tuning_stopped"))
            self._tuning_done()
            return
        self._tuning_result_set(line)
        self.statusBar().showMessage(i18n.tr("command_response_status", command_id=command_id, line=line))
        self._tuning_done()

    @staticmethod
    def _calibration_response_failed(line: str) -> bool:
        normalized = str(line or "").strip().upper()
        failure_words = ("ERROR", "FAIL", "FAILED", "INVALID", "UNKNOWN", "UNSUPPORTED")
        return normalized in {"ERR", "NG"} or any(word in normalized for word in failure_words)

    def _parse_tuning_result(self, line: str):
        try:
            parts = {}
            for segment in line.split(":"):
                segment = segment.strip()
                if " " in segment:
                    key, val = segment.split(" ", 1)
                    parts[key.strip()] = val.strip()
            bank = parts.get("BANK", "?")
            code = parts.get("CODETYPE", "?")
            shutter = parts.get("SHUTTER", "?")
            gain = parts.get("GAIN", "?")
            rate = parts.get("RATE", "?")
            time_ms = parts.get("TIME", "?")
            html = (
                f"{i18n.tr('tuning_complete')}\n"
                f"Bank: {bank} | Code: {code}\n"
                f"Shutter: {shutter}\n"
                f"Gain: {gain}\n"
                f"Rate: {rate}\n"
                f"Time: {time_ms}"
            )
            self._tuning_result_set(html)
        except Exception as e:
            print(f"[MainWindow] Parse tuning error: {e!r}")

    # ========== Scan Handling ==========

    def _save_scan_file(self, wafer_id: str, operator_id: str, timestamp: datetime = None) -> tuple[bool, str, Optional[str]]:
        """Save a scan file for the given Wafer ID.

        Automatic device reads pass ``scan_file_writer.OPERATOR_NULL`` and
        manual entries pass the authenticated employee ID, matching the
        client filename specification.
        """
        if timestamp is None:
            timestamp = datetime.now()

        success, message, path = scan_file_writer.save_scan_file(
            wafer_id_value=wafer_id,
            operator_id=operator_id,
            timestamp=timestamp,
            storage_root_path=app_config.get_scan_storage_root_path(),
        )

        if success:
            self.statusBar().showMessage(i18n.tr("scan_saved_status").format(path=path))
            return True, i18n.tr("save_status_saved"), str(path)
        else:
            self.statusBar().showMessage(i18n.tr("scan_save_failed_status").format(error=message))
            return False, i18n.tr("save_status_failed"), None

    def _display_status_for(self, scan: Scan) -> str:
        """Return the localized status text used in the scan table."""
        if scan.is_manual:
            return i18n.tr("status_manual")
        return i18n.tr("status_good") if scan.status == "GOOD" else i18n.tr("status_ng")

    def _append_scan_row(self, scan: Scan, *, highlight_ng: bool) -> int:
        """Insert one scan at the top of the table and return its row index."""
        return self._scan_table.insert_scan(
            scan,
            self._display_status_for(scan),
            highlight_ng=highlight_ng,
        )

    def _replace_scan_row(self, row: int, scan: Scan, *, highlight_ng: bool) -> bool:
        """Update a pending scan row without duplicating cell creation logic."""
        return self._scan_table.replace_scan(
            row,
            scan,
            self._display_status_for(scan),
            highlight_ng=highlight_ng,
        )

    def _on_scan_timeout(self):
        """Offer manual input after a trigger timeout using the active session."""
        self.statusBar().showMessage(i18n.tr("no_scan_timeout_status"))
        self._on_manual_entry_clicked()

    def _should_ignore_duplicate(self, barcode_value: str) -> bool:
        """Return whether a barcode must be ignored by the user setting.

        A barcode that arrives while an NG row is pending is intentionally not
        ignored: that scan is the retry that replaces the pending NG row.
        Outside that retry flow, the check happens before any text file or CCD
        image is created.
        """
        normalized = barcode_value.strip()
        return bool(
            normalized
            and self._chk_ignore_dupes.isChecked()
            and self._pending_ng_row is None
            and normalized in self._seen_barcode_values
        )

    def _continue_continuous_scan(self) -> None:
        """Request the next trigger after a handled scan, including a duplicate."""
        if not self._continuous_scan_active:
            return
        ok = self._send_trigger_raw()
        if ok:
            return
        self._continuous_scan_active = False
        self._btn_continuous.blockSignals(True)
        self._btn_continuous.setChecked(False)
        self._btn_continuous.blockSignals(False)
        self._btn_trigger.setEnabled(True)
        self.statusBar().showMessage(i18n.tr("continuous_scan_stopped_error"))

    def _on_scan_received(self, barcode_value: str):
        if not self._require_login():
            return
        self._trigger_controller.on_scan_received()

        normalized = barcode_value.strip()
        if self._should_ignore_duplicate(normalized):
            self.statusBar().showMessage(
                i18n.tr("duplicate_scan_ignored").format(barcode=normalized)
            )
            self._update_scan_count()
            self._continue_continuous_scan()
            self._focus_primary_action()
            return

        # The UI retains the authenticated session for traceability, but the
        # presentation explicitly requires automatic filenames to contain
        # ``Null`` in the manual-operator field.
        display_operator_id = self._current_operator_id()
        file_operator_id = scan_file_writer.OPERATOR_NULL
        is_good = self._evaluate_barcode(normalized)
        status = "GOOD" if is_good else "NG"
        timestamp = datetime.now()

        _save_success, save_status_text, saved_path = self._save_scan_file(
            wafer_id=normalized,
            operator_id=file_operator_id,
            timestamp=timestamp,
        )

        scan = Scan(
            timestamp=timestamp,
            barcode_value=normalized,
            operator_id=display_operator_id,
            status=status,
            wafer_id=normalized,
            folder_path=str(Path(saved_path).parent) if saved_path else "",
            saved_file_path=str(saved_path) if saved_path else "",
            save_status=save_status_text,
            input_source=i18n.tr("input_source_auto"),
        )

        if self._pending_ng_row is not None:
            row = self._pending_ng_row
            previous_pending_scan = self._pending_ng_scan
            self._replace_scan_row(row, scan, highlight_ng=not is_good)
            self._seen_barcode_values.add(normalized)

            if is_good:
                self._pending_ng_row = None
                self._pending_ng_scan = None
                self._btn_retry.setEnabled(False)
                self._btn_manual_entry.setEnabled(False)
            else:
                self._pending_ng_scan = scan
            # Every equipment read gets its CCD image, including an NG read.
            self._start_image_capture(row, scan, saved_path)

            for index, existing in enumerate(self._scans):
                if previous_pending_scan is not None and existing is previous_pending_scan:
                    self._scans[index] = scan
                    break
            else:
                self._scans.append(scan)
            self._table.scrollToTop()
            self._update_scan_count()
        else:
            self._scans.append(scan)
            row = self._append_scan_row(scan, highlight_ng=not is_good)
            self._seen_barcode_values.add(normalized)

            if not is_good:
                self._pending_ng_row = row
                self._pending_ng_scan = scan
                self._btn_retry.setEnabled(True)
                self._btn_manual_entry.setEnabled(True)
            else:
                self._pending_ng_row = None
                self._btn_retry.setEnabled(False)
                self._btn_manual_entry.setEnabled(False)

            # Every equipment read gets its CCD image, including an NG read.
            self._start_image_capture(row, scan, saved_path)
            self._table.scrollToTop()
            self._update_scan_count()

        if self._current_user is not None and not self._current_user.is_admin:
            # Any equipment scan consumes the operator's one manual-input opportunity.
            self._operator_manual_input_available = False
            self._apply_role_ui()
        self._continue_continuous_scan()
        self._focus_primary_action()

    # ========== Image capture helpers ==========

    def _start_image_capture(self, row: int, scan: Scan, saved_path) -> None:
        """Queue a CCD capture through the already open barcode connection.

        The row index is intentionally not retained: newer scans are inserted
        at row zero while the image packet is travelling back from the reader.
        The ``scan`` object is used as the stable row identity instead.
        """
        del row
        if not saved_path or not self._worker.is_connected():
            return
        try:
            target_jpg = scan_file_writer.image_path_for_scan(saved_path)
        except (TypeError, ValueError, OSError):
            return
        context = (scan, target_jpg)
        self._worker.request_image_capture(context, timeout_ms=4000)

    def _on_image_ready(self, context, jpeg_bytes) -> None:
        """Write the CCD JPEG and display its thumbnail next to the barcode."""
        if isinstance(context, _CalibrationCapture):
            self._on_calibration_image_ready(context, jpeg_bytes)
            return
        if not jpeg_bytes or not isinstance(context, tuple) or len(context) != 2:
            return
        scan, target_jpg = context
        if not isinstance(scan, Scan):
            return
        # Persist first: the JPEG must land beside its text file even when the
        # table row is already gone (e.g. a new session started during the
        # 1-4 s transfer). The thumbnail display needs the row, the file does not.
        try:
            target_jpg = Path(target_jpg)
            target_jpg.parent.mkdir(parents=True, exist_ok=True)
            target_jpg.write_bytes(bytes(jpeg_bytes))
            scan.image_path = str(target_jpg)
        except (OSError, TypeError, ValueError):
            return

        row = self._scan_table.row_for_scan(scan)
        if row < 0:
            return

        pix = QPixmap(str(target_jpg))
        if pix.isNull():
            return
        pix = pix.scaled(96, 96, Qt.KeepAspectRatio, Qt.SmoothTransformation)
        label = QLabel()
        label.setPixmap(pix)
        label.setAlignment(Qt.AlignCenter)
        label.setToolTip(str(target_jpg))
        self._table.setCellWidget(row, COL_IMAGE, label)
        self._table.setRowHeight(row, 104)

    def _on_image_failed(self, context, _reason) -> None:
        if isinstance(context, _CalibrationCapture):
            self._on_calibration_image_failed(context, _reason)
            return
        # CCD support is optional at runtime; a failed image must not invalidate
        # the barcode result or its text-file save.
        self.statusBar().showMessage(i18n.tr("image_capture_failed_status"))

    def _sync_table_empty_state(self):
        """Show a placeholder label when there are no scans, else the table."""
        if self._scans:
            self._table_stack.setCurrentWidget(self._table)
        else:
            self._table_stack.setCurrentWidget(self._lbl_table_empty)
            self._lbl_table_empty.setText(i18n.tr("table_empty_hint"))

    def _update_scan_count(self):
        real_count = sum(1 for s in self._scans if not s.is_duplicate)
        total = len(self._scans)
        if self._chk_ignore_dupes.isChecked():
            self._lbl_scan_count.setText(i18n.tr("scans_count_with_total", real_count=real_count, total_count=total))
        else:
            self._lbl_scan_count.setText(i18n.tr("scans_count", count=total))
        self._sync_table_empty_state()

    # ========== Selection & Copy ==========

    def _on_selection_changed(self):
        self._btn_copy_selected.setEnabled(len(self._table.selectedItems()) > 0)

    def _on_cell_double_clicked(self, row: int, col: int):
        barcode = self._scan_table.barcode_at(row)
        if barcode:
            self._copy_to_clipboard(barcode)

    def keyPressEvent(self, event):
        if event.matches(QKeySequence.Copy):
            self._copy_selected()
            return
        super().keyPressEvent(event)

    def _copy_selected(self):
        lines = self._scan_table.selected_barcodes()
        if not lines:
            return
        self._copy_to_clipboard("\n".join(lines))

    def _copy_all(self):
        lines = self._scan_table.all_barcodes()

        if not lines:
            self.statusBar().showMessage(i18n.tr("no_scans_to_copy_status"))
            return
        self._copy_to_clipboard("\n".join(lines))

    def _copy_to_clipboard(self, text: str):
        try:
            self._clipboard.setText(text)
            preview = text[:40] + "..." if len(text) > 40 else text
            self._lbl_copy_flash.setText(i18n.tr("clipboard_copied", preview=preview))
            self._copy_flash_timer.start(2000)
        except Exception as e:
            self.statusBar().showMessage(i18n.tr("clipboard_error_status", error=str(e)))

    def _clear_copy_flash(self):
        self._lbl_copy_flash.setText("")

    # ========== List Management ==========

    def _clear_list(self):
        if self._current_user is None or not self._current_user.is_admin:
            return
        if not self._scans:
            return
        # Always show confirmation dialog (regardless of count)
        result = QMessageBox.question(
            self,
            i18n.tr("clear_confirm_title"),
            i18n.tr("clear_confirm_text").format(count=len(self._scans)),
            QMessageBox.Yes | QMessageBox.No, QMessageBox.No,
        )
        if result != QMessageBox.Yes:
            return
        self._scans.clear()
        self._scan_table.clear()

        self._seen_barcode_values.clear()
        self._pending_ng_row = None
        self._pending_ng_scan = None
        self._btn_retry.setEnabled(False)
        self._btn_manual_entry.setEnabled(False)
        self._update_scan_count()
        self.statusBar().showMessage(i18n.tr("list_cleared"))

    def _export_scans(self):
        """Export the current scan list to CSV or XLSX."""
        if self._current_user is None or not self._current_user.is_admin:
            return
        if not self._scans:
            self.statusBar().showMessage(i18n.tr("export_no_data"))
            return

        # Suggest filename with timestamp
        ts = datetime.now().strftime("%Y-%m-%d_%H%M")
        suggested = f"scan_export_{ts}"

        # File dialog
        caption = i18n.tr("export_dialog_title")
        csv_filter = i18n.tr("export_file_filter_csv")
        xlsx_filter = i18n.tr("export_file_filter_xlsx")
        file_path, selected_filter = QFileDialog.getSaveFileName(
            self,
            caption,
            suggested,
            f"{csv_filter};;{xlsx_filter}",
        )
        if not file_path:
            return

        try:
            # Visible table values define the exported column order.
            headers, rows = self._scan_table.export_data()

            if file_path.lower().endswith(".xlsx"):
                self._export_xlsx(file_path, headers, rows)
            else:
                self._export_csv(file_path, headers, rows)

            self.statusBar().showMessage(
                i18n.tr("export_success").format(
                    rows=len(rows), path=file_path
                )
            )
        except Exception as e:
            self.statusBar().showMessage(
                i18n.tr("export_error").format(error=str(e))
            )

    def _export_csv(self, file_path: str, headers: list[str], rows: list[list[str]]):
        """Write UTF-8 with BOM CSV for Excel compatibility."""
        import csv
        with open(file_path, "w", encoding="utf-8-sig", newline="") as f:
            writer = csv.writer(f)
            writer.writerow(headers)
            for row in rows:
                writer.writerow(row)

    def _export_xlsx(self, file_path: str, headers: list[str], rows: list[list[str]]):
        """Write Excel file via openpyxl."""
        wb = Workbook()
        ws = wb.active
        ws.title = "Scans"
        ws.append(headers)
        for row in rows:
            ws.append(row)
        wb.save(file_path)

    def _on_dupe_toggle(self):
        if self._current_user is None or not self._current_user.is_admin:
            self._chk_ignore_dupes.blockSignals(True)
            self._chk_ignore_dupes.setChecked(True)
            self._chk_ignore_dupes.blockSignals(False)
            self._settings["ignore_duplicates"] = True
        else:
            self._settings["ignore_duplicates"] = self._chk_ignore_dupes.isChecked()
        self._update_scan_count()

    # ========== Menu Actions ==========

    def _on_settings_clicked(self):
        """Open the tabbed settings dialog."""
        if self._current_user is None or not self._current_user.is_admin:
            return
        if self._settings_dialog is None:
            self._settings_dialog = settings_dialog.SettingsDialog(self)
        self._settings_dialog.show()
        self._settings_dialog.raise_()
        self._settings_dialog.activateWindow()

    def _on_about_clicked(self):
        """Show the About dialog."""
        version = "1.0.0"  # TODO: make this dynamic if needed
        text = i18n.tr("about_text").format(version=version)
        QMessageBox.about(self, i18n.tr("menu_action_about"), text)

    def _open_help_dialog(self):
        """Open the non-modal Help / reference dialog (also bound to F1)."""
        if self._help_dialog is None:
            self._help_dialog = help_dialog.HelpDialog(self)
        self._help_dialog.show()
        self._help_dialog.raise_()
        self._help_dialog.activateWindow()

    # ========== Tutorial ==========

    def _maybe_auto_start_tutorial(self):
        """Show the tutorial on the very first launch only (once)."""
        if self._settings.get("tutorial_completed", False):
            return
        # Delay slightly so the layout is fully measured and visible.
        QTimer.singleShot(300, self._start_tutorial)

    def _restart_tutorial(self):
        """Manually start the tutorial from the beginning (Help menu)."""
        self._start_tutorial()

    def _start_tutorial(self):
        """Show (or restart) the tutorial overlay over the main window.

        The overlay is purely visual and never triggers real connection or
        scan actions, so it is safe to show even while connected.
        """
        if self._tutorial_overlay is None:
            self._tutorial_overlay = tutorial_overlay.TutorialOverlay(self)
            self._tutorial_overlay.finished.connect(self._on_tutorial_finished)
        self._tutorial_overlay.restart()
        self._tutorial_overlay.setGeometry(self.rect())
        self._tutorial_overlay.show()
        self._tutorial_overlay.raise_()
        self._tutorial_overlay.activateWindow()

    def _on_tutorial_finished(self):
        """Tutorial completed/skipped: hide it and never auto-show again."""
        if self._tutorial_overlay is not None:
            self._tutorial_overlay.hide()
        self._settings["tutorial_completed"] = True
        app_settings.save(self._settings)
        self._focus_primary_action()

    # ========== Settings Persistence ==========

    def _restore_settings(self):
        self._refresh_ports()
        last_port = self._settings.get("last_com_port")
        if last_port:
            idx = self._cmb_port.findText(last_port)
            if idx >= 0:
                self._cmb_port.setCurrentIndex(idx)
        last_baud = str(self._settings.get("last_baud_rate", 115200))
        idx = self._cmb_baud.findText(last_baud)
        if idx >= 0:
            self._cmb_baud.setCurrentIndex(idx)
        wx = self._settings.get("window_x", -1)
        wy = self._settings.get("window_y", -1)
        ww = self._settings.get("window_width", 984)
        wh = self._settings.get("window_height", 720)
        if wx >= 0 and wy >= 0:
            self.move(wx, wy)
        self.resize(ww, wh)
        if self._settings.get("window_maximized", False):
            self.showMaximized()
        self._chk_ignore_dupes.setChecked(self._settings.get("ignore_duplicates", True))
        lang_code = self._settings.get("language", "en")
        lang_name = i18n.LANGUAGE_NAMES.get(lang_code, "English")
        idx = self._cmb_language.findText(lang_name)
        if idx >= 0:
            self._cmb_language.blockSignals(True)
            self._cmb_language.setCurrentIndex(idx)
            self._cmb_language.blockSignals(False)
        self._apply_role_ui()

    # ========== i18n ==========

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
            self.retranslate_ui()

    def retranslate_ui(self):
        self.setWindowTitle(i18n.tr("window_title"))
        # Re-apply configured language to every registered widget/menu/tooltip.
        for widget, key, setter in self._i18n_registry:
            getattr(widget, setter)(i18n.tr(key))
        # Dynamic text that depends on the current application state.
        self._btn_connect.setText(
            i18n.tr("connect_button") if not self._worker.is_connected()
            else i18n.tr("disconnect_button")
        )
        if self._worker.is_connected():
            self._lbl_status.setText(i18n.tr("status_connected"))
        else:
            self._lbl_status.setText(i18n.tr("status_disconnected"))
        self._table.setHorizontalHeaderLabels([
            i18n.tr("col_time"), i18n.tr("col_operator"),
            i18n.tr("col_status"), i18n.tr("col_barcode"),
            i18n.tr("col_input_source"), i18n.tr("col_image"),
            i18n.tr("col_save_status"),
        ])
        current = self.statusBar().currentMessage()
        for kw in ["Ready", "Bereit", "Ready"]:
            if kw in current:
                self.statusBar().showMessage(i18n.tr("ready_status"))
                break
        self._update_scan_count()
        self._apply_role_ui()

    def showEvent(self, event):
        """Auto-show the first-run tutorial once the window becomes visible."""
        super().showEvent(event)
        if not self._tutorial_shown_once:
            self._tutorial_shown_once = True
            self._maybe_auto_start_tutorial()
        else:
            self._focus_primary_action()

    def resizeEvent(self, event):
        """Keep the tutorial overlay covering the window when it is resized."""
        super().resizeEvent(event)
        overlay = getattr(self, "_tutorial_overlay", None)
        if overlay is not None and overlay.isVisible():
            overlay.setGeometry(self.rect())

    # ========== Close ==========

    def closeEvent(self, event):
        geo = self.geometry()
        self._settings["window_x"] = geo.x()
        self._settings["window_y"] = geo.y()
        self._settings["window_width"] = geo.width()
        self._settings["window_height"] = geo.height()
        self._settings["window_maximized"] = self.isMaximized()
        self._settings["last_com_port"] = self._cmb_port.currentText() or None
        self._settings["last_baud_rate"] = int(self._cmb_baud.currentText() or "115200")
        self._settings["ignore_duplicates"] = self._chk_ignore_dupes.isChecked()
        app_settings.save(self._settings)
        self._calibration_timeout_timer.stop()
        self._combined_calibration_active = False
        if self._trigger_source:
            self._trigger_source.stop()
        self._trigger_controller.stop()
        self._worker.request_disconnect()
        self._worker.stop()
        self._worker.wait(2000)
        super().closeEvent(event)
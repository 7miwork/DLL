"""Abstract trigger source interface and implementations.

A TriggerSource provides an abstract event source that tells the
TriggerController "a part is ready, start the read cycle".
"""

from typing import Optional

from PySide6.QtCore import QObject, QThread, QTimer, Signal
from PySide6.QtSerialPort import QSerialPort

import i18n


class TriggerSource(QObject):
    """Abstract base class for trigger event sources."""

    signal_received = Signal()

    def start(self) -> None:
        raise NotImplementedError

    def stop(self) -> None:
        raise NotImplementedError


class ManualTriggerSource(TriggerSource):
    """Trivial trigger source that emits when trigger() is called."""

    def __init__(self, parent: Optional[QObject] = None) -> None:
        super().__init__(parent)

    def start(self) -> None:
        pass

    def stop(self) -> None:
        pass

    def trigger(self) -> None:
        self.signal_received.emit()

class SerialLineTriggerWorker(QObject):
    """Background worker that reads lines from a serial port.

    Emits ``line_received`` whenever a complete line (terminated by \\n or \\r)
    is decoded. The owning thread manages the QSerialPort event loop.
    """

    line_received = Signal(str)
    error_occurred = Signal(str)

    def __init__(self, port_name: str, baud_rate: int = 9600,
                 expected_string: str = "TRIGGER", parent: Optional[QObject] = None) -> None:
        super().__init__(parent)
        self._port_name = port_name
        self._baud_rate = baud_rate
        self._expected_string = expected_string.strip()
        self._serial: Optional[QSerialPort] = None
        self._running = False

    def run(self) -> None:
        """Open the serial port and enter the event loop."""
        self._running = True
        self._serial = QSerialPort(self._port_name, baudRate=self._baud_rate,
                                   dataBits=QSerialPort.Data8,
                                   parity=QSerialPort.NoParity,
                                   stopBits=QSerialPort.OneStop,
                                   flowControl=QSerialPort.NoFlowControl)

        if not self._serial.open(QSerialPort.ReadWrite):
            self.error_occurred.emit(
                i18n.tr("trigger_source_open_failed", port=self._port_name)
            )
            return

        self._serial.readyRead.connect(self._on_ready_read)
        self._serial.errorOccurred.connect(self._on_error)

        while self._running and self._serial and self._serial.isOpen():
            import time
            time.sleep(0.05)

        self._cleanup()

    def _on_ready_read(self) -> None:
        if not self._serial:
            return
        while self._serial.canReadLine():
            try:
                line = self._serial.readLine().data().decode("ascii", errors="replace").strip()
                if line:
                    self.line_received.emit(line)
            except Exception as e:
                self.error_occurred.emit(str(e))

    def _on_error(self, error) -> None:
        if error != QSerialPort.NoError:
            self.error_occurred.emit(str(error))

    def _cleanup(self) -> None:
        if self._serial and self._serial.isOpen():
            try:
                self._serial.close()
            except Exception:
                pass
        self._serial = None

    def stop(self) -> None:
        self._running = False
        self._cleanup()


class SerialLineTriggerSource(TriggerSource):
    """Trigger source that listens on a dedicated COM port for a string.

    Runs the SerialLineTriggerWorker on its own QThread.
    """

    def __init__(self, port_name: str, baud_rate: int = 9600,
                 expected_string: str = "TRIGGER",
                 parent: Optional[QObject] = None) -> None:
        super().__init__(parent)
        self._port_name = port_name
        self._baud_rate = baud_rate
        self._expected_string = expected_string
        self._worker: Optional[SerialLineTriggerWorker] = None
        self._thread: Optional[QThread] = None
        self._reconnect_timer: Optional[QTimer] = None  # type: ignore[name-defined]
        self._reconnect_interval_ms = 2000

    def start(self) -> None:
        self._connect_worker()

    def _connect_worker(self) -> None:
        if self._thread and self._thread.isRunning():
            return

        self._worker = SerialLineTriggerWorker(
            self._port_name, self._baud_rate, self._expected_string
        )
        self._thread = QThread(self)
        self._worker.moveToThread(self._thread)
        self._thread.started.connect(self._worker.run)
        self._worker.line_received.connect(self._on_line_received)
        self._worker.error_occurred.connect(self._on_worker_error)
        self._thread.start()

    def _on_line_received(self, line: str) -> None:
        if self._expected_string and line == self._expected_string:
            self.signal_received.emit()

    def _on_worker_error(self, message: str) -> None:
        self._schedule_reconnect()

    def _schedule_reconnect(self) -> None:
        if self._reconnect_timer is None:
            self._reconnect_timer = QTimer(self)
            self._reconnect_timer.setSingleShot(True)
            self._reconnect_timer.timeout.connect(self._connect_worker)
        self._reconnect_timer.start(self._reconnect_interval_ms)

    def stop(self) -> None:
        if self._reconnect_timer:
            self._reconnect_timer.stop()
        if self._worker:
            self._worker.stop()
        if self._thread:
            self._thread.quit()
            self._thread.wait(2000)


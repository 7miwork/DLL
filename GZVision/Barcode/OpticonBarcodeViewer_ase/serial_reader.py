"""Serial port reader running on a background QThread.

Opens a COM port, buffers incoming bytes, splits on <CR> (0x0D),
handles CRLF, filters ACK (0x06) / NAK (0x15) bytes, and emits
signals for each completed barcode line or error.

Also supports sending Opticon-style commands (<ESC>[...<CR>) and
receiving their responses via the command_response signal, so
tuning/bank management commands don't get mixed up with barcode scans.
"""

import time
import traceback
import serial
from serial.tools import list_ports
from PySide6.QtCore import QThread, Signal, QMutex, QMutexLocker

import image_capture

# Entwicklungs-/Fehlersuche-Logging. Auf True setzen für detaillierte
# TX/RX-Ausgaben im Terminal; im Normalbetrieb auf False lassen, um
# teure hex()-Konvertierungen und Console-I/O zu vermeiden.
DEBUG_SERIAL = False


def format_connection_error(port_name: str, error: Exception) -> str:
    """Return a concise, actionable connection error for the GUI."""
    text = str(error)
    winerror = getattr(error, "winerror", None)
    if (
        isinstance(error, PermissionError)
        or winerror == 5
        or "access is denied" in text.lower()
        or "permissionerror" in text.lower()
    ):
        return (
            f"Failed to connect to {port_name}: access denied. "
            "The port may be in use by another application or blocked by Windows."
        )
    if isinstance(error, FileNotFoundError) or winerror == 2:
        return f"Failed to connect to {port_name}: port not found or device disconnected."
    return f"Failed to connect to {port_name}: {text}"


class SerialReaderWorker(QThread):
    """Background worker for reading from a serial port.

    Emits:
        scan_received(str): A complete, non-empty barcode line.
        error_occurred(str): An error description.
        connected_changed(bool): True when connected, False when disconnected.
        command_response(str, str): (command_id, response_line) for
            command responses that should NOT be treated as barcode scans.
    """

    scan_received = Signal(str)
    error_occurred = Signal(str)
    connected_changed = Signal(bool)
    command_response = Signal(str, str)  # (command_id, response_line)
    connection_lost = Signal(str)  # Emitted when connection is lost unexpectedly
    image_capture_ready = Signal(object, object)  # (context, JPEG bytes)
    image_capture_failed = Signal(object, str)  # (context, reason)

    def __init__(self, parent=None):
        super().__init__(parent)
        self._port = None
        self._mutex = QMutex()
        self._running = False
        self._should_connect = False
        self._connect_params = (None, None)  # (port_name, baud_rate)

        # Command/response state
        self._pending_command_id = None  # str | None
        self._pending_lines_remaining = 0
        self._pending_timeout_ms = 0
        self._pending_start_time = 0.0
        self._command_queue = []  # list of (command_id, timeout_ms, expected_lines)
        self._raw_command_queue = []  # list of bytes to be written by this thread
        self._image_capture_requests = []  # list of (context, timeout_ms)
        self._image_capture_active = False

        # Idle-gap framing state.
        # Dieser Wert bestimmt die maximale Latenz für Codes ohne CR/LF-
        # Terminierung: nach 15 ms ohne neue Bytes wird der Puffer als
        # vollständige Zeile gewertet. Bei Problemen (abgeschnittene
        # Zeilen) ggf. wieder erhöhen, z. B. auf 25–40 ms.
        self._last_byte_time = 0.0
        self._IDLE_GAP_MS = 15

    def request_connect(self, port_name: str, baud_rate: int):
        """Request a connection on the given port/baud from the thread."""
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        self._connect_params = (port_name, baud_rate)
        self._should_connect = True

    def request_disconnect(self):
        """Request disconnection from the thread."""
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        self._should_connect = False
        self._connect_params = (None, None)

    def send_raw_command(self, payload: bytes) -> bool:
        """Queue a pre-framed command for transmission on the worker thread.

        This is intended for Opticon commands that are already represented as
        raw bytes (for example the trigger command). Keeping the actual serial
        write in ``run`` avoids GUI-thread access to the private serial-port
        object and keeps all port I/O in one place.
        """
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        if self._port is None or not self._port.is_open:
            return False
        self._raw_command_queue.append(payload)
        return True

    def send_command(self, command_id: str, timeout_ms: int = 2000, expected_lines: int = 1):
        """Queue a command to be sent.

        The command will be framed as <ESC>[<command_id><CR> and sent
        at the next opportunity. The next `expected_lines` completed
        lines will be reported via `command_response` instead of
        `scan_received`.

        Args:
            command_id: The command string, e.g. "DT1", "BRA Q0Q1", "DGQ"
            timeout_ms: Max wait time for the response before resetting
            expected_lines: Number of response lines to capture
        """
        now = time.monotonic()
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        self._command_queue.append((command_id, timeout_ms, expected_lines))
        # If no command is currently pending, start the timeout timer
        if self._pending_command_id is None:
            self._pending_timeout_ms = timeout_ms
            self._pending_start_time = now

    def clear_pending_command(self):
        """Drop the currently pending command/response bookkeeping (thread-safe).

        Used by the calibration workflow after an aborted tuning or image
        exchange: a command that ended early (e.g. a single "Tuning failed"
        line although two were expected) would otherwise keep swallowing
        following serial lines as responses instead of barcode scans.
        """
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        self._pending_command_id = None
        self._pending_lines_remaining = 0
        self._pending_timeout_ms = 0
        self._pending_start_time = 0.0

    def request_image_capture(self, context=None, timeout_ms: int = 4000) -> bool:
        """Queue one CCD image capture on the active reader connection.

        The request is executed by this worker thread, never by the GUI thread,
        and therefore shares the already open COM port with barcode reads.  A
        single capture may be active at a time; callers receive the original
        ``context`` together with the result through the image signals.
        """
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        if self._port is None or not self._port.is_open:
            return False
        if self._image_capture_active or self._image_capture_requests:
            return False
        self._image_capture_requests.append((context, int(timeout_ms)))
        return True

    def is_connected(self) -> bool:
        """Check if the serial port is currently open (thread-safe)."""
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        return self._port is not None and self._port.is_open

    @property
    def port_name(self) -> str | None:
        """Return the current port name (thread-safe)."""
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        if self._port and self._port.is_open:
            return self._port.port
        return None

    def run(self):
        """Main loop: check for connect/disconnect requests, read data."""
        self._running = True
        buffer = bytearray()

        while self._running:
            locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method

            # Process command queue
            if self._pending_command_id is None and self._command_queue:
                cmd_id, timeout_ms, expected_lines = self._command_queue.pop(0)
                self._pending_command_id = cmd_id
                self._pending_lines_remaining = expected_lines
                self._pending_timeout_ms = timeout_ms
                self._pending_start_time = time.monotonic()

            # Check for pending command timeout
            if self._pending_command_id is not None:
                if (time.monotonic() - self._pending_start_time) * 1000 > self._pending_timeout_ms:
                    if DEBUG_SERIAL:
                        print(f"[SerialReader] Command {self._pending_command_id} timed out after {self._pending_timeout_ms}ms")
                    self._pending_command_id = None
                    self._pending_lines_remaining = 0
                    buffer.clear()

            # Check for connection requests
            if self._should_connect and self._connect_params[0] is not None:
                port_name, baud_rate = self._connect_params
                self._should_connect = False

                self._close_port_internal()

                try:
                    if DEBUG_SERIAL:
                        print(f"[SerialReader] Opening {port_name} @ {baud_rate} baud...")
                    self._port = serial.Serial(
                        port=port_name,
                        baudrate=baud_rate,
                        bytesize=serial.EIGHTBITS,
                        parity=serial.PARITY_NONE,
                        stopbits=serial.STOPBITS_ONE,
                        timeout=0.1,
                    )
                    if DEBUG_SERIAL:
                        print(f"[SerialReader] Port opened successfully: {self._port.port}")
                    buffer.clear()
                    self._last_byte_time = 0.0
                    self.connected_changed.emit(True)
                except Exception as e:
                    if DEBUG_SERIAL:
                        print(f"[SerialReader] FAILED to connect: {e!r}")
                        traceback.print_exc()
                    self.error_occurred.emit(format_connection_error(port_name, e))
                    self._port = None
                    self.connected_changed.emit(False)

            elif not self._should_connect and self._port is not None and self._connect_params[0] is None:
                if DEBUG_SERIAL:
                    print(f"[SerialReader] Disconnecting from {self._port.port} (user requested)")
                self._close_port_internal()
                buffer.clear()
                self._last_byte_time = 0.0
                self.connected_changed.emit(False)

            locker.unlock()

            # CCD image capture must use the same open port as barcode reads.
            # Process it before queued trigger bytes so continuous scanning does
            # not trigger the next exposure while the current image is pending.
            locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
            capture_request = None
            if self._image_capture_requests and self._port is not None and self._port.is_open:
                capture_request = self._image_capture_requests.pop(0)
                self._image_capture_active = True
            port_for_capture = self._port
            locker.unlock()

            if capture_request is not None:
                context, timeout_ms = capture_request
                try:
                    buffer.clear()
                    jpeg = image_capture.capture_image_from_serial(port_for_capture, timeout_ms)
                    buffer.clear()
                    self._last_byte_time = 0.0
                    if jpeg:
                        self.image_capture_ready.emit(context, jpeg)
                    else:
                        self.image_capture_failed.emit(context, "image_capture_failed")
                finally:
                    locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
                    self._image_capture_active = False
                    locker.unlock()

            # Send raw commands and protocol commands from this worker thread.
            locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
            raw_commands = self._raw_command_queue[:]
            self._raw_command_queue.clear()
            pending_command_id = self._pending_command_id
            locker.unlock()

            for raw_command in raw_commands:
                self._write_payload(raw_command, "raw command")

            if pending_command_id is not None:
                cmd_bytes = b"\x1b[" + pending_command_id.encode("ascii") + b"\r"
                if not self._write_payload(cmd_bytes, pending_command_id):
                    locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
                    self._pending_command_id = None
                    self._pending_lines_remaining = 0
                    locker.unlock()

            # Read data if connected
            port = self._port
            if port is not None and port.is_open:
                try:
                    if port.in_waiting > 0:
                        raw = port.read(port.in_waiting)
                        if DEBUG_SERIAL:
                            print(f"[SerialReader] RX ({len(raw)} bytes): {raw.hex(' ')}")
                        now = time.monotonic()
                        self._last_byte_time = now

                        for byte in raw:
                            # Filter ACK/NAK
                            if byte in (0x06, 0x15):
                                continue

                            # CR terminates a line
                            if byte == 0x0D:
                                line = buffer.decode("ascii", errors="replace").strip()
                                buffer.clear()
                                if line:
                                    self._handle_completed_line(line)
                                continue

                            # LF without preceding CR — treat as terminator too
                            if byte == 0x0A:
                                line = buffer.decode("ascii", errors="replace").strip()
                                buffer.clear()
                                if line:
                                    self._handle_completed_line(line)
                                continue

                            # Normal byte
                            buffer.append(byte)
                    else:
                        # No data waiting — check idle-gap timeout
                        now = time.monotonic()
                        if (buffer and self._last_byte_time > 0 and
                                (now - self._last_byte_time) * 1000 >= self._IDLE_GAP_MS):
                            line = buffer.decode("ascii", errors="replace").strip()
                            buffer.clear()
                            self._last_byte_time = 0.0
                            if line:
                                if DEBUG_SERIAL:
                                    print(f"[SerialReader] IDLE-GAP DECODED: {line!r}")
                                self._handle_completed_line(line)
                        # Reduzierte Polling-Latenz: 2 ms statt 10 ms, damit
                        # empfangene Bytes während einer laufenden Tuning-
                        # Sequenz (DT1) schneller verarbeitet und angezeigt werden.
                        self.msleep(2)
                except serial.SerialException as e:
                    print(f"[SerialReader] SerialException during read: {e!r}")
                    traceback.print_exc()
                    locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
                    self._close_port_internal()
                    locker.unlock()
                    self.error_occurred.emit(f"Connection lost: {e}")
                    self.connection_lost.emit(f"Serial error: {e}")
                    self.connected_changed.emit(False)
                except OSError as e:
                    print(f"[SerialReader] OSError during read: {e!r}")
                    traceback.print_exc()
                    locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
                    self._close_port_internal()
                    locker.unlock()
                    self.error_occurred.emit(f"Connection lost: {e}")
                    self.connection_lost.emit(f"OS error: {e}")
                    self.connected_changed.emit(False)
                except Exception as e:
                    print(f"[SerialReader] Read error: {e!r}")
                    traceback.print_exc()
                    self.error_occurred.emit(f"Read error: {e}")
            else:
                self.msleep(50)

    def _write_payload(self, payload: bytes, label: str) -> bool:
        """Write bytes to the active port from the worker thread only."""
        port = self._port
        if port is None or not port.is_open:
            self.error_occurred.emit("Cannot send command: serial port is not connected.")
            return False
        try:
            port.write(payload)
            port.flush()
            if DEBUG_SERIAL:
                print(f"[SerialReader] TX {label}: {payload.hex(' ')}")
            return True
        except Exception as error:
            if DEBUG_SERIAL:
                print(f"[SerialReader] Failed to send {label}: {error!r}")
            self.error_occurred.emit(f"Failed to send command: {error}")
            return False

    def _handle_completed_line(self, line: str):
        """Route a completed line to the appropriate signal."""
        if self._pending_command_id is not None and self._pending_lines_remaining > 0:
            if DEBUG_SERIAL:
                print(f"[SerialReader] CMD RESPONSE ({self._pending_command_id}): {line!r}")
            self.command_response.emit(self._pending_command_id, line)
            self._pending_lines_remaining -= 1
            if self._pending_lines_remaining <= 0:
                self._pending_command_id = None
        else:
            if DEBUG_SERIAL:
                print(f"[SerialReader] DECODED: {line!r}")
            self.scan_received.emit(line)

    def stop(self):
        """Signal the thread to stop and clean up immediately."""
        locker = QMutexLocker(self._mutex)  # noqa: F841 - keep the locker referenced so the mutex stays locked for the whole method
        self._running = False
        self._should_connect = False
        self._connect_params = (None, None)
        self._command_queue.clear()
        self._raw_command_queue.clear()
        self._image_capture_requests.clear()
        self._image_capture_active = False
        self._pending_command_id = None
        self._pending_lines_remaining = 0
        self._close_port_internal()
        locker.unlock()

    def _close_port_internal(self):
        """Close the serial port (caller must hold mutex)."""
        if self._port:
            try:
                if self._port.is_open:
                    self._port.close()
            except Exception:
                pass
            self._port = None


def enumerate_ports() -> list[str]:
    """Return a sorted list of available COM port names."""
    return sorted([p.device for p in list_ports.comports()])
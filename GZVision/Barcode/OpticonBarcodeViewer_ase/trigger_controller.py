"""Qt-based trigger controller (state machine) for the UV-300 retry logic."""

from typing import Optional

from PySide6.QtCore import QObject, QTimer, Signal

import i18n
from trigger_retry_policy import TriggerRetryPolicy


class TriggerController(QObject):
    """Stateful controller for the trigger-retry cycle."""

    trigger_requested = Signal()
    cycle_exhausted = Signal()
    manual_trigger_requested = Signal()
    scan_received_in_cycle = Signal()
    status_changed = Signal(str)

    STATE_IDLE = "idle"
    STATE_ARMED = "armed"
    STATE_RETRY_DELAY = "retry_delay"

    def __init__(self, worker, policy: Optional[TriggerRetryPolicy] = None,
                 parent: Optional[QObject] = None) -> None:
        super().__init__(parent)
        self._worker = worker
        self._policy = policy or TriggerRetryPolicy(
            max_attempts=5, retry_delay_ms=1000, per_attempt_timeout_ms=5000
        )
        self._generation = 0
        self._state = self.STATE_IDLE

        self._attempt_timer = QTimer(self)
        self._attempt_timer.setSingleShot(True)
        self._attempt_timer.timeout.connect(self._on_attempt_timeout)

        self._retry_timer = QTimer(self)
        self._retry_timer.setSingleShot(True)
        self._retry_timer.timeout.connect(self._on_retry_delay_expired)

    def start_cycle(self, manual: bool = False) -> None:
        if manual:
            self._abort_cycle()
        self._generation += 1
        gen = self._generation
        self._policy.reset()
        self._policy.register_attempt()
        self._set_state(self.STATE_ARMED)
        self._update_status()
        self.trigger_requested.emit()
        self._attempt_timer.start(self._policy.per_attempt_timeout_ms())
        self._attempt_timer.setProperty("generation", gen)

    def on_scan_received(self) -> None:
        if self._state != self.STATE_ARMED:
            return
        gen = self._attempt_timer.property("generation")
        if gen != self._generation:
            return
        self._attempt_timer.stop()
        self._retry_timer.stop()
        self._set_state(self.STATE_IDLE)
        self.scan_received_in_cycle.emit()
        self.status_changed.emit("")

    def stop(self) -> None:
        self._abort_cycle()

    def policy(self) -> TriggerRetryPolicy:
        return self._policy

    def set_policy(self, policy: TriggerRetryPolicy) -> None:
        self._policy = policy

    def current_state(self) -> str:
        return self._state

    def _abort_cycle(self) -> None:
        self._attempt_timer.stop()
        self._retry_timer.stop()
        self._set_state(self.STATE_IDLE)
        self.status_changed.emit("")

    def _set_state(self, state: str) -> None:
        self._state = state

    def _on_attempt_timeout(self) -> None:
        gen = self._attempt_timer.property("generation")
        if gen != self._generation:
            return
        if self._state != self.STATE_ARMED:
            return
        if self._policy.is_exhausted():
            self._set_state(self.STATE_IDLE)
            self.status_changed.emit("")
            self.cycle_exhausted.emit()
            return
        self._set_state(self.STATE_RETRY_DELAY)
        self._update_status()
        self._retry_timer.start(self._policy.retry_delay_ms())
        self._retry_timer.setProperty("generation", gen)

    def _on_retry_delay_expired(self) -> None:
        if self._state != self.STATE_RETRY_DELAY:
            return
        gen = self._retry_timer.property("generation")
        if gen != self._generation:
            return
        self.start_cycle(manual=False)

    def _update_status(self) -> None:
        if self._state == self.STATE_IDLE:
            self.status_changed.emit("")
        elif self._state == self.STATE_ARMED:
            self.status_changed.emit(
                i18n.tr("trigger_cycle_status",
                        attempt=self._policy.attempt_count(),
                        max_attempts=self._policy.max_attempts())
            )
        elif self._state == self.STATE_RETRY_DELAY:
            self.status_changed.emit(
                i18n.tr("trigger_retry_delay_status",
                        attempt=self._policy.attempt_count(),
                        max_attempts=self._policy.max_attempts())
            )

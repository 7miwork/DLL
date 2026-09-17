"""Pure-Python retry policy for trigger cycles (no Qt dependency).

Tracks how many trigger attempts have been made within a single cycle and
reports exhaustion so the controller can decide whether to retry or escalate
to manual entry.
"""


class TriggerRetryPolicy:
    """Stateful retry policy for trigger cycles.

    Args:
        max_attempts: Maximum number of trigger attempts per cycle.
        retry_delay_ms: Milliseconds to wait between attempts.
        per_attempt_timeout_ms: Milliseconds to wait for a scan before
            considering an attempt as timed out.
    """

    def __init__(self, max_attempts: int, retry_delay_ms: int,
                 per_attempt_timeout_ms: int) -> None:
        self._max_attempts = max_attempts
        self._retry_delay_ms = retry_delay_ms
        self._per_attempt_timeout_ms = per_attempt_timeout_ms
        self._attempt_count = 0

    def reset(self) -> None:
        """Reset the attempt counter for a new cycle."""
        self._attempt_count = 0

    def attempt_count(self) -> int:
        """Return the current number of registered attempts."""
        return self._attempt_count

    def register_attempt(self) -> None:
        """Register one completed attempt (timeout without scan)."""
        self._attempt_count += 1

    def is_exhausted(self) -> bool:
        """Return True if the maximum number of attempts has been reached."""
        return self._attempt_count >= self._max_attempts

    def max_attempts(self) -> int:
        return self._max_attempts

    def retry_delay_ms(self) -> int:
        return self._retry_delay_ms

    def per_attempt_timeout_ms(self) -> int:
        return self._per_attempt_timeout_ms

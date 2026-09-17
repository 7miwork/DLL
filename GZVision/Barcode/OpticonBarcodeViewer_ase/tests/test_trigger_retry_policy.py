"""Tests for trigger_retry_policy.py (pure pytest, no Qt required)."""

import sys
from pathlib import Path


PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

from trigger_retry_policy import TriggerRetryPolicy


class TestTriggerRetryPolicy:
    def test_zero_attempts_not_exhausted(self):
        policy = TriggerRetryPolicy(max_attempts=3, retry_delay_ms=500,
                                    per_attempt_timeout_ms=2000)
        assert policy.attempt_count() == 0
        assert not policy.is_exhausted()

    def test_exactly_max_attempts_is_exhausted(self):
        policy = TriggerRetryPolicy(max_attempts=3, retry_delay_ms=500,
                                    per_attempt_timeout_ms=2000)
        for _ in range(3):
            policy.register_attempt()
        assert policy.attempt_count() == 3
        assert policy.is_exhausted()

    def test_below_max_not_exhausted(self):
        policy = TriggerRetryPolicy(max_attempts=5, retry_delay_ms=1000,
                                    per_attempt_timeout_ms=3000)
        for _ in range(4):
            policy.register_attempt()
        assert not policy.is_exhausted()

    def test_above_max_is_exhausted(self):
        policy = TriggerRetryPolicy(max_attempts=2, retry_delay_ms=100,
                                    per_attempt_timeout_ms=500)
        for _ in range(5):
            policy.register_attempt()
        assert policy.is_exhausted()

    def test_reset_clears_attempts(self):
        policy = TriggerRetryPolicy(max_attempts=3, retry_delay_ms=500,
                                    per_attempt_timeout_ms=2000)
        for _ in range(3):
            policy.register_attempt()
        assert policy.is_exhausted()
        policy.reset()
        assert policy.attempt_count() == 0
        assert not policy.is_exhausted()

    def test_reset_allows_new_cycle(self):
        policy = TriggerRetryPolicy(max_attempts=2, retry_delay_ms=100,
                                    per_attempt_timeout_ms=500)
        policy.register_attempt()
        policy.register_attempt()
        assert policy.is_exhausted()
        policy.reset()
        policy.register_attempt()
        assert not policy.is_exhausted()

    def test_accessors_return_constructor_values(self):
        policy = TriggerRetryPolicy(max_attempts=7, retry_delay_ms=1234,
                                    per_attempt_timeout_ms=5678)
        assert policy.max_attempts() == 7
        assert policy.retry_delay_ms() == 1234
        assert policy.per_attempt_timeout_ms() == 5678

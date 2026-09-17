"""Regression tests for actionable serial connection errors."""

from serial_reader import format_connection_error


def test_permission_error_is_actionable():
    error = PermissionError(13, "Access is denied.")
    message = format_connection_error("COM4", error)
    assert "COM4" in message
    assert "access denied" in message.lower()
    assert "another application" in message.lower()


def test_pyserial_wrapped_permission_error_is_actionable():
    error = RuntimeError("could not open port 'COM4': PermissionError(13, 'Access is denied.', None, 5)")
    message = format_connection_error("COM4", error)
    assert "access denied" in message.lower()
    assert "blocked by Windows" in message


def test_missing_port_is_actionable():
    error = FileNotFoundError(2, "The system cannot find the file specified")
    message = format_connection_error("COM4", error)
    assert "COM4" in message
    assert "not found" in message.lower()

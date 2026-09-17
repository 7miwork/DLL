from __future__ import annotations

from datetime import datetime
from pathlib import Path

import pytest

import app_config
import auth
import i18n
import scan_file_writer
import wafer_id


def test_bilingual_display_contains_english_and_chinese():
    i18n.set_language("en")
    i18n.set_bilingual(True)
    value = i18n.tr("manual_entry_button")
    assert "Enter Manually" in value
    assert "手動輸入" in value
    i18n.set_bilingual(False)


def test_default_users_and_roles_are_available(tmp_path, monkeypatch):
    users_file = tmp_path / "users.json"
    monkeypatch.setattr(auth, "USERS_FILE", users_file)
    auth.ensure_default_users_file()

    operator = auth.authenticate("A12345", "password")
    administrator = auth.authenticate("admin", "admin")
    assert operator is not None and operator.is_operator
    assert administrator is not None and administrator.is_admin
    assert operator.can_manual_entry is True


def test_admin_can_add_operator_without_manual_permission(tmp_path, monkeypatch):
    users_file = tmp_path / "users.json"
    monkeypatch.setattr(auth, "USERS_FILE", users_file)
    assert auth.add_user("line-01", "secret", can_manual_entry=False, role="operator")
    user = auth.authenticate("line-01", "secret")
    assert user is not None
    assert user.is_operator
    assert user.can_manual_entry is False


def test_filename_requires_operator_id():
    with pytest.raises(ValueError):
        scan_file_writer.build_filename("1-123CD4-001-001", "")


def test_storage_paths_are_read_from_external_parameter_file(tmp_path, monkeypatch):
    config_file = tmp_path / "app_config.json"
    config_file.write_text(
        '{"scan_storage_root_path": "ROOT", "standard_root_path": "STD", "nonstandard_path": "NONSTD"}',
        encoding="utf-8",
    )
    monkeypatch.setattr(app_config, "CONFIG_FILE", config_file)
    assert app_config.get_scan_storage_root_path() == "ROOT"


def test_missing_external_storage_path_is_rejected(tmp_path):
    import pytest
    with pytest.raises(ValueError):
        wafer_id.resolve_target_folder(
            "1-123CD4-001-001",
            storage_root_path="",
        )
    with pytest.raises(ValueError):
        wafer_id.resolve_target_folder(
            "UNREADABLE",
            storage_root_path="",
        )


def test_each_barcode_gets_its_own_text_file_and_content_is_one_line(tmp_path):
    timestamp = datetime(2026, 8, 26, 10, 11, 12)
    first_ok, _, first_path = scan_file_writer.save_scan_file(
        "1-123CD4-001-001", "A12345", timestamp,
        storage_root_path=str(tmp_path / "storage"),
    )
    second_ok, _, second_path = scan_file_writer.save_scan_file(
        "1-123CD4-001-002", "A12345", timestamp,
        storage_root_path=str(tmp_path / "storage"),
    )
    assert first_ok and second_ok
    assert first_path is not None and second_path is not None
    assert first_path != second_path
    assert first_path.parent == tmp_path / "storage" / "Standardized Format" / "1-123CD4-001-001"
    assert second_path.parent == tmp_path / "storage" / "Standardized Format" / "1-123CD4-001-002"
    assert first_path.name.startswith("Null#1-123CD4-001-001#A12345#")
    assert second_path.name.startswith("Null#1-123CD4-001-002#A12345#")
    assert first_path.read_text(encoding="utf-8") == "1-123CD4-001-001\n"
    assert second_path.read_text(encoding="utf-8") == "1-123CD4-001-002\n"
    assert wafer_id.split_wafer_id("1-123CD4-001-001") == ("1", "123CD4", "001", "001")
    assert wafer_id.resolve_target_folder(
        "1-123CD4-001-001",
        storage_root_path=str(tmp_path / "storage"),
    ) == tmp_path / "storage" / "Standardized Format" / "1-123CD4-001-001"
    manual_nonstandard_ok, _, manual_nonstandard_path = scan_file_writer.save_scan_file(
        "UNREADABLE", "A12345", timestamp,
        storage_root_path=str(tmp_path / "storage"),
    )
    assert manual_nonstandard_ok
    assert manual_nonstandard_path.parent == tmp_path / "storage" / "Non-Standardized Format" / "UNREADABLE"
    assert (tmp_path / "storage" / "Standardized Format").is_dir()
    assert (tmp_path / "storage" / "Non-Standardized Format").is_dir()
    assert "#A12345#" in manual_nonstandard_path.name
    assert Path(first_path).with_suffix(".jpg").name.startswith("Null#1-123CD4-001-001#A12345#")


def test_image_path_is_always_beside_text_file(tmp_path):
    text_path = tmp_path / "1-123#Null#Null#20260826101112.txt"
    beside = scan_file_writer.image_path_for_scan(text_path, "")
    configured = scan_file_writer.image_path_for_scan(text_path, str(tmp_path / "ccd"))
    assert beside == text_path.with_suffix(".jpg")
    assert configured == text_path.with_suffix(".jpg")


def test_external_config_can_persist_scan_root_and_trigger_settings(tmp_path, monkeypatch):
    config_file = tmp_path / "app_config.json"
    monkeypatch.setattr(app_config, "CONFIG_FILE", config_file)
    app_config.set_scan_storage_root_path("C:/ScanData")
    app_config.set_trigger_source_mode("serial_line")
    app_config.set_trigger_source_com_port("COM7")
    app_config.set_trigger_source_baud_rate("19200")
    app_config.set_trigger_source_expected_string("UV_DONE")
    loaded = app_config.load()
    assert loaded["scan_storage_root_path"] == "C:/ScanData"
    assert loaded["trigger_source_mode"] == "serial_line"
    assert loaded["trigger_source_com_port"] == "COM7"
    assert loaded["trigger_source_baud_rate"] == 19200
    assert loaded["trigger_source_expected_string"] == "UV_DONE"

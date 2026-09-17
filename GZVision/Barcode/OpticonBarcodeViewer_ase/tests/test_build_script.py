"""Regression tests for deterministic portable/licensed build orchestration."""

from __future__ import annotations

import json

import build


def test_runtime_config_migration_preserves_existing_values(tmp_path, monkeypatch):
    project_dir = tmp_path / "project"
    dist_dir = tmp_path / "dist"
    project_dir.mkdir()
    dist_dir.mkdir()
    (project_dir / "app_config.json").write_text(
        json.dumps(
            {
                "scan_storage_root_path": "",
                "standard_root_path": "C:/KH/strip2D/",
                "nonstandard_path": "C:/KH/strip2D/2490/",
                "image_storage_path": "",
                "scan_timeout_seconds": 5,
            }
        ),
        encoding="utf-8",
    )
    (project_dir / "users.json").write_text("{\"users\": []}\n", encoding="utf-8")
    (dist_dir / "app_config.json").write_text(
        json.dumps(
            {
                "scan_storage_root_path": "Z:/customer/scan-data/",
                "standard_root_path": "Z:/customer/standard/",
                "nonstandard_path": "Z:/customer/nonstandard/",
            }
        ),
        encoding="utf-8",
    )

    monkeypatch.setattr(build, "PROJECT_DIR", project_dir)
    monkeypatch.setattr(build, "DIST_DIR", dist_dir)
    build.copy_runtime_templates("licensed")

    merged = json.loads((dist_dir / "app_config.json").read_text(encoding="utf-8"))
    assert merged["scan_storage_root_path"] == "Z:/customer/scan-data/"
    assert merged["standard_root_path"] == "Z:/customer/standard/"
    assert merged["nonstandard_path"] == "Z:/customer/nonstandard/"
    assert merged["image_storage_path"] == ""
    assert (dist_dir / "users.json").exists()


def test_temporary_build_mode_restores_portable_default(tmp_path, monkeypatch):
    config_path = tmp_path / "build_config.py"
    monkeypatch.setattr(build, "BUILD_CONFIG_PATH", config_path)
    with build.temporary_build_mode("licensed"):
        assert 'BUILD_MODE = "licensed"' in config_path.read_text(encoding="utf-8")
    assert 'BUILD_MODE = "portable"' in config_path.read_text(encoding="utf-8")

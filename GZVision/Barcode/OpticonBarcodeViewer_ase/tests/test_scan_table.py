"""Tests for the presentation-only scan table component."""

from __future__ import annotations

import sys
from datetime import datetime
from pathlib import Path

from PySide6.QtCore import Qt
from PySide6.QtWidgets import QApplication, QTableWidget, QTableWidgetSelectionRange

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

from models import Scan
from scan_table import COL_BARCODE, ScanTablePresenter


def _application() -> QApplication:
    return QApplication.instance() or QApplication(sys.argv)


def _table() -> QTableWidget:
    table = QTableWidget(0, 6)
    table.setHorizontalHeaderLabels([
        "Time", "Operator", "Status", "Barcode", "Image", "Save status",
    ])
    table.setSelectionBehavior(QTableWidget.SelectRows)
    table.setSelectionMode(QTableWidget.ExtendedSelection)
    return table


def test_inserted_scan_is_rendered_and_exported_in_visible_column_order():
    _application()
    table = _table()
    presenter = ScanTablePresenter(table)
    scan = Scan(
        timestamp=datetime(2026, 8, 14, 9, 30, 1, 120000),
        barcode_value="ABC-123",
        operator_id="OP-01",
        status="GOOD",
        save_status="saved",
    )

    row = presenter.insert_scan(scan, "GOOD", highlight_ng=False)

    assert row == 0
    assert presenter.barcode_at(row) == "ABC-123"
    assert presenter.row_for_scan(scan) == row
    headers, rows = presenter.export_data()
    assert headers == ["Time", "Operator", "Status", "Barcode", "Image", "Save status"]
    assert rows == [["09:30:01.120", "OP-01", "GOOD", "ABC-123", "", "saved"]]


def test_selected_barcodes_and_ng_highlight_are_based_on_table_rows():
    _application()
    table = _table()
    presenter = ScanTablePresenter(table)
    ng_scan = Scan(barcode_value="NG-001", status="NG")
    good_scan = Scan(barcode_value="GOOD-001", status="GOOD")

    presenter.insert_scan(ng_scan, "NG", highlight_ng=True)
    good_row = presenter.insert_scan(good_scan, "GOOD", highlight_ng=False)
    ng_row = 1  # Inserting the GOOD scan at the top moves the NG row down.
    table.setRangeSelected(QTableWidgetSelectionRange(good_row, 0, good_row, 5), True)
    table.setRangeSelected(QTableWidgetSelectionRange(ng_row, 0, ng_row, 5), True)

    assert presenter.selected_barcodes() == ["GOOD-001", "NG-001"]
    assert presenter.all_barcodes() == ["GOOD-001", "NG-001"]
    assert table.item(ng_row, COL_BARCODE).background().color().name() == "#ffcccc"

    assert presenter.replace_scan(ng_row, good_scan, "GOOD", highlight_ng=False)
    assert table.item(ng_row, COL_BARCODE).background().style() == Qt.NoBrush


def test_replace_scan_rejects_a_row_removed_while_background_work_was_running():
    _application()
    presenter = ScanTablePresenter(_table())

    assert not presenter.replace_scan(0, Scan(barcode_value="late"), "GOOD", highlight_ng=False)
    assert presenter.row_for_scan(Scan(barcode_value="late")) == -1

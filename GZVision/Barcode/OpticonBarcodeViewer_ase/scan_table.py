"""Qt table presentation helpers for scan records."""

from __future__ import annotations

from PySide6.QtCore import Qt
from PySide6.QtGui import QColor, QBrush
from PySide6.QtWidgets import QTableWidget, QTableWidgetItem

from models import Scan


COL_TIME = 0
COL_OPERATOR = 1
COL_STATUS = 2
COL_BARCODE = 3
COL_INPUT_SOURCE = 4
COL_IMAGE = 5
COL_SAVE_STATUS = 6


class ScanTablePresenter:
    """Keep table rendering and export separate from scan business logic."""

    NG_BACKGROUND = QColor("#ffcccc")

    def __init__(self, table: QTableWidget) -> None:
        self._table = table

    def insert_scan(self, scan: Scan, status_text: str, *, highlight_ng: bool) -> int:
        row = 0
        self._table.insertRow(row)
        self.set_scan(row, scan, status_text, highlight_ng=highlight_ng)
        return row

    def replace_scan(self, row: int, scan: Scan, status_text: str, *, highlight_ng: bool) -> bool:
        if row < 0 or row >= self._table.rowCount():
            return False
        self.set_scan(row, scan, status_text, highlight_ng=highlight_ng)
        return True

    def set_scan(self, row: int, scan: Scan, status_text: str, *, highlight_ng: bool) -> None:
        self._set_item(row, COL_TIME, scan.formatted_time(), Qt.AlignLeft | Qt.AlignVCenter)
        self._set_item(row, COL_OPERATOR, scan.operator_id, Qt.AlignCenter)
        self._set_item(row, COL_STATUS, status_text, Qt.AlignCenter)
        barcode_item = self._set_item(row, COL_BARCODE, scan.barcode_value)
        barcode_item.setData(Qt.UserRole, scan)
        if self._table.columnCount() >= 7:
            self._set_item(row, COL_INPUT_SOURCE, scan.input_source, Qt.AlignCenter)
            image_column = COL_IMAGE
            save_column = COL_SAVE_STATUS
        else:
            # Compatibility for callers that still create the original table.
            image_column = 4
            save_column = 5
        self._set_item(row, image_column, "", Qt.AlignCenter)
        self._set_item(row, save_column, scan.save_status, Qt.AlignCenter)
        self.set_ng_highlight(row, highlight_ng)

    def set_ng_highlight(self, row: int, enabled: bool) -> None:
        background = self.NG_BACKGROUND if enabled else QBrush()
        for column in range(self._table.columnCount()):
            item = self._table.item(row, column)
            if item is not None:
                item.setBackground(background)

    def barcode_at(self, row: int) -> str:
        item = self._table.item(row, COL_BARCODE)
        return item.text() if item is not None else ""

    def row_for_scan(self, scan: Scan) -> int:
        for row in range(self._table.rowCount()):
            item = self._table.item(row, COL_BARCODE)
            if item is not None and item.data(Qt.UserRole) is scan:
                return row
        return -1

    def selected_barcodes(self) -> list[str]:
        selected_rows = sorted({item.row() for item in self._table.selectedItems()})
        return [barcode for row in selected_rows if (barcode := self.barcode_at(row))]

    def all_barcodes(self) -> list[str]:
        return [barcode for row in range(self._table.rowCount()) if (barcode := self.barcode_at(row))]

    def export_data(self) -> tuple[list[str], list[list[str]]]:
        headers = [
            self._table.horizontalHeaderItem(column).text()
            for column in range(self._table.columnCount())
        ]
        rows = [
            [
                self._table.item(row, column).text()
                if self._table.item(row, column) is not None
                else ""
                for column in range(self._table.columnCount())
            ]
            for row in range(self._table.rowCount())
        ]
        return headers, rows

    def clear(self) -> None:
        self._table.setRowCount(0)

    def _set_item(
        self,
        row: int,
        column: int,
        text: str,
        alignment: Qt.AlignmentFlag | None = None,
    ) -> QTableWidgetItem:
        item = QTableWidgetItem(str(text or ""))
        if alignment is not None:
            item.setTextAlignment(alignment)
        self._table.setItem(row, column, item)
        return item

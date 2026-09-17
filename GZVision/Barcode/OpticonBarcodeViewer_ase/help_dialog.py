"""Non-modal Help / Reference dialog.

Left side: searchable chapter list (QListWidget). Right side: a
QTextBrowser that renders the selected chapter's rich-text (HTML) body.

The dialog is deliberately kept simple: its size/position are not persisted.
It always reflects the currently active i18n language (see ``_populate()``).
"""

from PySide6.QtWidgets import (
    QDialog, QVBoxLayout, QLineEdit, QListWidget, QTextBrowser, QSplitter,
)
from PySide6.QtCore import Qt

import i18n
import help_content


class HelpDialog(QDialog):
    """A searchable, language-aware help window."""

    def __init__(self, parent=None):
        super().__init__(parent)
        self.setObjectName("helpDialog")
        self.setWindowTitle(i18n.tr("help_dialog_title"))
        self.setMinimumSize(800, 600)
        self.resize(900, 650)
        # Position slightly centered over the parent window on first show.
        if parent is not None:
            pr = parent.frameGeometry()
            self.move(pr.center() - self.rect().center())

        self._rows = []          # all rows: (key, title, body_html)
        self._visible_rows = []  # rows currently shown (after filter)

        self._build_ui()
        self._populate()

    def _build_ui(self):
        layout = QVBoxLayout(self)
        layout.setContentsMargins(10, 10, 10, 10)
        layout.setSpacing(6)

        self._search = QLineEdit()
        self._search.setObjectName("helpSearch")
        self._search.setPlaceholderText(i18n.tr("help_search_placeholder"))
        self._search.setClearButtonEnabled(True)
        self._search.textChanged.connect(self._filter)
        layout.addWidget(self._search)

        splitter = QSplitter(Qt.Horizontal)
        self._nav = QListWidget()
        self._nav.setObjectName("helpNav")
        self._nav.currentRowChanged.connect(self._on_select)
        self._browser = QTextBrowser()
        self._browser.setObjectName("helpBrowser")
        self._browser.setOpenExternalLinks(True)
        splitter.addWidget(self._nav)
        splitter.addWidget(self._browser)
        splitter.setStretchFactor(0, 0)
        splitter.setStretchFactor(1, 1)
        splitter.setSizes([220, 640])
        layout.addWidget(splitter, 1)

    def showEvent(self, event):
        """Re-populate on every show so a language change is reflected."""
        super().showEvent(event)
        self._populate()

    def _populate(self):
        """Load chapters for the currently active language and reset search."""
        lang = i18n.get_language()
        content = help_content.HELP_CONTENT.get(lang, help_content.HELP_CONTENT["en"])

        self._rows = []
        for key in help_content.SECTION_ORDER:
            item = content.get(key)
            if not item:
                continue
            self._rows.append((key, item["title"], item["body_html"]))

        self._search.clear()          # resets the filter
        self._search.setPlaceholderText(i18n.tr("help_search_placeholder"))
        self._nav.blockSignals(True)
        self._nav.clear()
        self._visible_rows = list(self._rows)
        for _key, title, _body in self._visible_rows:
            self._nav.addItem(title)
        self._nav.blockSignals(False)
        if self._nav.count():
            self._nav.setCurrentRow(0)

    def _filter(self, text):
        """Show only chapters whose title or body matches ``text``."""
        needle = (text or "").strip().lower()
        self._nav.blockSignals(True)
        self._nav.clear()
        self._visible_rows = [
            row for row in self._rows
            if not needle
            or needle in row[1].lower()
            or needle in row[2].lower()
        ]
        for _key, title, _body in self._visible_rows:
            self._nav.addItem(title)
        self._nav.blockSignals(False)
        if self._visible_rows:
            self._nav.setCurrentRow(0)
            self._on_select(0)
        else:
            self._browser.setHtml("")

    def _on_select(self, row):
        if row < 0 or row >= len(self._visible_rows):
            return
        self._browser.setHtml(self._visible_rows[row][2])

"""Lightweight, package-free tutorial overlay.

A non-modal, semi-transparent overlay that highlights one control at a time
(a "spotlight" rectangle) and shows a speech bubble with explanatory text and
"Next" / "Skip" buttons. It is purely visual: it never triggers real
connect/scan actions, so it is safe to show even while a connection is live.

The highlight is drawn with the classic "four rectangles" technique (dim the
areas around the target instead of punching a hole), which works reliably on
opaque child widgets.
"""

from PySide6.QtWidgets import (
    QWidget, QFrame, QLabel, QPushButton, QVBoxLayout, QHBoxLayout,
)
from PySide6.QtGui import QPainter, QColor, QPen
from PySide6.QtCore import QRect, QPoint, Signal

import i18n
import themes

# Each step references a widget by its attribute name on MainWindow and a
# translatable explanation key (i18n).
TUTORIAL_STEPS = [
    {"target_widget": "_cmb_port", "text_key": "tutorial_step_port"},
    {"target_widget": "_txt_operator", "text_key": "tutorial_step_operator"},
    {"target_widget": "_btn_connect", "text_key": "tutorial_step_connect"},
    {"target_widget": "_btn_trigger", "text_key": "tutorial_step_trigger"},
    {"target_widget": "_table", "text_key": "tutorial_step_table"},
    {"target_widget": "_btn_copy_all", "text_key": "tutorial_step_copy"},
]

# Overlay colors are centralized in themes.py (theming convention).
_TUTORIAL = themes.DARK_THEME
_DIM_COLOR = QColor(_TUTORIAL["tutorial_dim"])
_DIM_COLOR.setAlpha(int(_TUTORIAL["tutorial_dim_alpha"]))
_HIGHLIGHT_COLOR = QColor(_TUTORIAL["tutorial_highlight"])
_BUBBLE_MARGIN = 12
_BUBBLE_GAP = 12


class TutorialOverlay(QWidget):
    """Spotlight overlay + speech bubble over a MainWindow."""

    finished = Signal()  # emitted when the tutorial is completed or skipped

    def __init__(self, main_window, parent=None):
        super().__init__(parent or main_window)
        self._main = main_window
        self._index = 0
        self._highlight = QRect()
        self.setObjectName("tutorialOverlay")

        # --- speech bubble ---
        self._bubble = QFrame(self)
        self._bubble.setObjectName("tutorialBubble")
        bubble_layout = QVBoxLayout(self._bubble)
        bubble_layout.setContentsMargins(14, 12, 14, 10)
        bubble_layout.setSpacing(8)

        self._lbl = QLabel()
        self._lbl.setObjectName("tutorialText")
        self._lbl.setWordWrap(True)
        bubble_layout.addWidget(self._lbl)

        btn_row = QHBoxLayout()
        btn_row.addStretch()
        self._btn_skip = QPushButton()
        self._btn_skip.setText(i18n.tr("tutorial_skip"))
        self._btn_skip.setObjectName("tutorialSkip")
        self._btn_skip.clicked.connect(self._on_skip)
        btn_row.addWidget(self._btn_skip)
        self._btn_next = QPushButton()
        self._btn_next.setText(i18n.tr("tutorial_next"))
        self._btn_next.setObjectName("tutorialNext")
        self._btn_next.setDefault(True)
        self._btn_next.clicked.connect(self._on_next)
        btn_row.addWidget(self._btn_next)
        bubble_layout.addLayout(btn_row)

        self._apply_step()
    # ------------------------------------------------------------------
    # Public API (used by MainWindow)
    # ------------------------------------------------------------------
    def restart(self):
        """Restart the tour from the first step."""
        self._index = 0
        self._apply_step()

    def current_step_name(self) -> str:
        """Name of the control highlighted by the current step."""
        return TUTORIAL_STEPS[self._index]["target_widget"]

    # ------------------------------------------------------------------
    # Step navigation
    # ------------------------------------------------------------------
    def _on_next(self):
        if self._index >= len(TUTORIAL_STEPS) - 1:
            self._finish()
            return
        self._index += 1
        self._apply_step()

    def _on_skip(self):
        self._finish()

    def _finish(self):
        self.finished.emit()

    # ------------------------------------------------------------------
    # Rendering
    # ------------------------------------------------------------------
    def _apply_step(self):
        """Resolve the target widget, update text/highlight/bubble."""
        if self._index >= len(TUTORIAL_STEPS):
            self._finish()
            return

        step = TUTORIAL_STEPS[self._index]
        widget = getattr(self._main, step["target_widget"], None)
        if widget is None:
            # Defensive: if a widget is missing, skip to the next step.
            self._index += 1
            self._apply_step()
            return

        self._lbl.setText(i18n.tr(step["text_key"]))
        if self._index == len(TUTORIAL_STEPS) - 1:
            self._btn_next.setText(i18n.tr("tutorial_close"))
        else:
            self._btn_next.setText(i18n.tr("tutorial_next"))
        self._reflow(widget)

    def _reflow(self, widget=None):
        """Recompute highlight rect + bubble position (also on resize)."""
        if widget is None and self._index < len(TUTORIAL_STEPS):
            name = TUTORIAL_STEPS[self._index]["target_widget"]
            widget = getattr(self._main, name, None)
        if widget is None:
            self._highlight = QRect()
            return

        tl = widget.mapTo(self._main, QPoint(0, 0))
        # The overlay is always sized to the main window (setGeometry(self.rect())),
        # so main-window coordinates equal overlay coordinates. Mapping via the
        # common ancestor avoids sibling mapTo() warnings.
        self._highlight = QRect(tl, widget.size())
        self._bubble.adjustSize()
        self._position_bubble()
        self.update()

    def _position_bubble(self):
        bw = self._bubble.width()
        bh = self._bubble.height()
        h = self._highlight

        # Try to the right of the highlight first, then left, then below.
        x = h.right() + _BUBBLE_GAP
        if x + bw > self.width() - _BUBBLE_MARGIN:
            x = h.left() - _BUBBLE_GAP - bw
        if x < _BUBBLE_MARGIN:
            x = _BUBBLE_MARGIN

        y = h.top()
        if y + bh > self.height() - _BUBBLE_MARGIN:
            y = max(_BUBBLE_MARGIN, self.height() - bh - _BUBBLE_MARGIN)
        self._bubble.move(x, y)
        self._bubble.raise_()

    def paintEvent(self, event):
        painter = QPainter(self)
        r = self.rect()
        h = self._highlight

        if h.isNull() or h.isEmpty():
            painter.fillRect(r, _DIM_COLOR)
            return

        def dim(rect):
            if rect.isValid() and not rect.isEmpty():
                painter.fillRect(rect, _DIM_COLOR)

        # Dim the four bands around the highlighted control.
        dim(QRect(r.left(), r.top(), r.width(), h.top() - r.top()))
        dim(QRect(r.left(), h.bottom() + 1, r.width(), r.bottom() - h.bottom()))
        dim(QRect(r.left(), h.top(), h.left() - r.left(), h.height()))
        dim(QRect(h.right() + 1, h.top(), r.right() - h.right(), h.height()))

        # Spotlight border around the highlighted control.
        painter.setPen(QPen(_HIGHLIGHT_COLOR, 2))
        painter.drawRect(h.adjusted(-2, -2, 2, 2))

    def resizeEvent(self, event):
        super().resizeEvent(event)
        self._reflow()

    def mousePressEvent(self, event):
        # Clicks on the dim overlay intentionally do nothing.
        event.accept()


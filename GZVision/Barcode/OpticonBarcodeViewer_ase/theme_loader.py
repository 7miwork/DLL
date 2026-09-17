"""Theme loading/application for the Opticon Barcode Viewer.

The stylesheet is built from a single shared template (``theme_template.qss``)
whose ``{{token}}`` placeholders are filled from a named palette in
:mod:`themes`. The template is applied at the ``QApplication`` level only —
this is the single place the stylesheet is set, so runtime theme switching
does not leave stale overrides on widgets.
"""

from pathlib import Path

from PySide6.QtWidgets import QApplication

import themes

# Relative to modules directory (a.k.a. the serial_reader / source folder).
_TEMPLATE_PATH = Path(__file__).parent / "theme_template.qss"

_template_cache: str | None = None


def _load_template() -> str:
    global _template_cache
    if _template_cache is None:
        _template_cache = _TEMPLATE_PATH.read_text(encoding="utf-8")
    return _template_cache


def build_stylesheet(theme_name: str) -> str:
    """Build the full QSS stylesheet for ``theme_name`` ('dark' or 'light').

    Reads ``theme_template.qss`` and replaces every ``{{token}}`` placeholder
    with the corresponding color from the palette (falling back to ``dark``
    for unknown names).
    """
    tokens = themes.THEMES.get(theme_name, themes.DARK_THEME)
    text = _load_template()
    for key, value in tokens.items():
        text = text.replace("{{" + key + "}}", value)
    return text


def apply_theme(app: QApplication, theme_name: str) -> None:
    """Apply the stylesheet for ``theme_name`` to the whole application."""
    try:
        app.setStyleSheet(build_stylesheet(theme_name))
    except Exception:
        pass  # Non-critical: continue without theme styling

"""Smoke tests: HelpDialog and TutorialOverlay instantiate without errors.

Uses the same QApplication + MainWindow pattern as the existing tests.
"""

import sys
from pathlib import Path

import pytest

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))


@pytest.fixture(scope="module")
def app():
    from PySide6.QtWidgets import QApplication
    return QApplication.instance() or QApplication(sys.argv)


@pytest.fixture(scope="module")
def main_window(app):
    import i18n
    from main_window import MainWindow
    i18n.set_language("en")
    w = MainWindow()
    yield w
    w._worker.stop()
    w._worker.wait(2000)


def test_help_dialog_instantiates(app, main_window):
    """The Help dialog builds a populated nav list in every language."""
    import i18n
    from help_dialog import HelpDialog
    for lang in ("en", "de", "zh_Hant"):
        i18n.set_language(lang)
        dlg = HelpDialog(main_window)
        assert dlg._nav.count() > 0, f"empty help nav for {lang}"
        dlg.close()
    i18n.set_language("en")


def test_tutorial_overlay_instantiates(app, main_window):
    """The tutorial overlay builds with the expected step list and bubble."""
    from tutorial_overlay import TutorialOverlay, TUTORIAL_STEPS
    assert len(TUTORIAL_STEPS) > 0
    ov = TutorialOverlay(main_window)
    assert ov._bubble is not None
    assert ov._lbl.text() != ""
    # Stepping through all steps must not raise.
    for _ in TUTORIAL_STEPS:
        ov._on_next()
    ov._finish()
    ov.deleteLater()

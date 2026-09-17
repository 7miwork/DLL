import sys
from pathlib import Path

import pytest

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

import i18n


@pytest.fixture(scope="module")
def main_window():
    """Build a MainWindow with a Qt application context."""
    from PySide6.QtWidgets import QApplication
    from main_window import MainWindow
    QApplication.instance() or QApplication(sys.argv)
    i18n.set_language("en")
    w = MainWindow()
    yield w
    w._worker.stop()
    w._worker.wait(2000)


def test_i18n_registry_nonempty(main_window):
    """After building the UI, the translation registry must be populated."""
    assert len(main_window._i18n_registry) >= 15, (
        f"Translation registry too small ({len(main_window._i18n_registry)}); "
        "a newly added translatable element was probably not registered via _tr_text()."
    )


def test_all_registered_keys_exist_in_all_languages(main_window):
    """Every key in the registry must be present in all three languages."""
    langs = ("en", "de", "zh_Hant")
    missing = []
    for widget, key, setter in main_window._i18n_registry:
        for lang in langs:
            if key not in i18n.TRANSLATIONS[lang]:
                missing.append((key, lang))
    assert not missing, f"Keys missing from translations: {missing}"


def test_retranslate_ui_reapplies_registered_keys(main_window):
    """retranslate_ui() must re-set every registered widget without error."""
    for lang in ("en", "de", "zh_Hant"):
        i18n.set_language(lang)
        main_window.retranslate_ui()  # should not raise
    # restore to English
    i18n.set_language("en")
    main_window.retranslate_ui()
    assert True

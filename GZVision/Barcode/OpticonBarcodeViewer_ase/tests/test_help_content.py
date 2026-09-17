"""Tests for the multi-language help content.

Verifies that HELP_CONTENT defines the same chapter keys in all three
languages (analogous to tests/check_i18n_keys.py).
"""

import sys
from pathlib import Path

PROJECT_ROOT = Path(__file__).resolve().parent.parent
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

import help_content

LANGS = ("en", "de", "zh_Hant")


def test_all_three_languages_present():
    """Every supported language must have a content section."""
    for lang in LANGS:
        assert lang in help_content.HELP_CONTENT, f"Missing help content for {lang}"


def test_same_section_keys_in_all_languages():
    """All languages must expose the exact same set of section keys."""
    keysets = {lang: set(help_content.HELP_CONTENT[lang]) for lang in LANGS}
    reference = keysets["en"]
    differences = {
        lang: (reference - keysets[lang]) | (keysets[lang] - reference)
        for lang in LANGS
    }
    assert not any(differences.values()), f"Section keys differ: {differences}"


def test_section_order_keys_exist():
    """Every ordered section in SECTION_ORDER must exist in each language."""
    for lang in LANGS:
        for key in help_content.SECTION_ORDER:
            assert key in help_content.HELP_CONTENT[lang], (
                f"{lang} missing ordered section {key}"
            )


def test_every_section_has_title_and_body():
    """Each chapter must carry a non-empty title and body_html."""
    for lang in LANGS:
        for key, item in help_content.HELP_CONTENT[lang].items():
            assert item.get("title"), (lang, key, "missing title")
            assert item.get("body_html"), (lang, key, "missing body_html")

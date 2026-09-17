"""Theme color palettes for the Opticon Barcode Viewer.

Each palette fills the ``{{token}}`` placeholders in ``theme_template.qss``.
``DARK_THEME`` reproduces the original ``theme.qss`` look exactly (it is the
default and is used as the golden reference for the regression test).
``LIGHT_THEME`` provides a light-mode alternative with WCAG-friendly contrast.
"""

# ---------------------------------------------------------------------------
# Dark theme (default) — values mirror the original theme.qss so switching to
# the template + palette produces byte-identical output for the dark case.
# ---------------------------------------------------------------------------
DARK_THEME = {
    "bg_base": "#1a1d21",
    "bg_panel": "#22262b",
    "bg_hover": "#2a2f36",
    "bg_pressed": "#1e2227",
    "fg_primary": "#e8eaed",
    "fg_secondary": "#9aa0a6",
    "fg_muted": "#6b7280",
    "fg_disabled": "#5a6068",
    "accent": "#00b8d9",
    "accent_dim": "#009bb3",
    "accent_hover": "#2fd1e0",
    "accent_glow": "rgba(0,184,217,0.35)",
    "border": "#2d3239",
    "border_focus": "#00b8d9",
    "border_hover": "#3a4048",
    "on_accent": "#0d1117",
    "statusbar_bg": "#16191d",
    "hover_mid": "#323840",
    "green_led": "#3adb76",
    "green_glow": "rgba(58,219,118,0.4)",
    "green_dim": "rgba(58,219,118,0.1)",
    "red_led": "#e04d4d",
    "red_glow": "rgba(224,77,77,0.35)",
    "table_alt": "#1e2227",
    "table_header": "#252a30",
    "table_grid": "#2d3239",
    "selection": "rgba(0,184,217,0.25)",
    "dupe_text": "#80868d",
    "gray_glow": "rgba(128,134,141,0.1)",
    "tutorial_highlight": "#00b8d9",
    "tutorial_dim": "#000000",
    "tutorial_dim_alpha": "150",
}

# ---------------------------------------------------------------------------
# Light theme — tuned for readability on a light background.
# ---------------------------------------------------------------------------
LIGHT_THEME = {
    "bg_base": "#f4f5f7",
    "bg_panel": "#ffffff",
    "bg_hover": "#e9ebef",
    "bg_pressed": "#dde0e5",
    "fg_primary": "#1a1d21",
    "fg_secondary": "#5a6068",
    "fg_muted": "#656c74",
    "fg_disabled": "#a5abb2",
    "accent": "#00a3c2",
    "accent_dim": "#008da9",
    "accent_hover": "#17b6d5",
    "accent_glow": "rgba(0,163,194,0.25)",
    "border": "#d5d8dd",
    "border_focus": "#00a3c2",
    "border_hover": "#b9bec6",
    "on_accent": "#0d1117",
    "statusbar_bg": "#eceef1",
    "hover_mid": "#e2e4e8",
    "green_led": "#1e9e4f",
    "green_glow": "rgba(30,158,79,0.3)",
    "green_dim": "rgba(30,158,79,0.12)",
    "red_led": "#c62f2f",
    "red_glow": "rgba(198,47,47,0.25)",
    "table_alt": "#f7f8fa",
    "table_header": "#eceef1",
    "table_grid": "#d5d8dd",
    "selection": "rgba(0,163,194,0.2)",
    "dupe_text": "#8b9199",
    "gray_glow": "rgba(138,144,153,0.12)",
    "tutorial_highlight": "#00a3c2",
    "tutorial_dim": "#000000",
    "tutorial_dim_alpha": "150",
}

THEMES = {
    "dark": DARK_THEME,
    "light": LIGHT_THEME,
}

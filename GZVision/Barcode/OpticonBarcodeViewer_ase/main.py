"""Entry point for Opticon Barcode Viewer.

Run with: python main.py
Build (portable/licensed variants) with: python build.py portable | licensed | all
"""

import sys
from pathlib import Path
from PySide6.QtWidgets import QApplication
import hardware_lock
from main_window import MainWindow
import i18n


def load_theme(app: QApplication):
    """Load and apply the Semiconductor dark theme from theme.qss."""
    try:
        theme_path = Path(__file__).parent / "theme.qss"
        if theme_path.exists():
            app.setStyleSheet(theme_path.read_text(encoding="utf-8"))
    except Exception:
        pass  # Non-critical, continue without theme


def main():
    app = QApplication(sys.argv)
    app.setApplicationName("Opticon Barcode Viewer")
    app.setOrganizationName("Opticon")

    # The customer requested English and Traditional Chinese together on all
    # visible application messages, including startup/license messages.
    i18n.set_bilingual(True)

    # Hardware license check (controlled by build_config.BUILD_MODE):
    # - Portable build → no check, runs anywhere, ignores license.lock.
    # - Licensed build → requires valid license.lock, exits on mismatch.
    hardware_lock.check_hardware_lock()

    # Apply global theme
    load_theme(app)

    window = MainWindow()
    window.show()

    sys.exit(app.exec())


if __name__ == "__main__":
    main()

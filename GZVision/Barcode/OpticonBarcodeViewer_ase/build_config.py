"""Buildzeit-Konfiguration für den Opticon Barcode Viewer.

Diese Datei wird ausschließlich durch ``build.py`` für die Dauer eines
PyInstaller-Builds geändert. ``BUILD_MODE`` wird in die erzeugte Anwendung
übernommen und kann zur Laufzeit weder über Einstellungen noch über
Umgebungsvariablen verändert werden.

Gültige Werte:
    "portable" -> keine Lizenzprüfung
    "licensed" -> passende license.lock neben der EXE erforderlich
"""

BUILD_MODE = "portable"

# Build- und Lizenzanleitung

## Zweck

Das Projekt erzeugt drei voneinander getrennte Windows-Programme. Die beiden eigentlichen Programmvarianten sind eine **portable** Ausgabe ohne Lizenzprüfung und eine **lizenzierte** Ausgabe, die ausschließlich auf einem PC mit passender Hardware-Hash-Lizenzdatei startet. Zusätzlich wird ein kleines Hash-Hilfsprogramm erzeugt, mit dem der Ziel-PC seinen Fingerprint an den Lizenz-Aussteller übermitteln kann.

> Die Build-Ausführung für Windows muss auf einem **Windows-Rechner** erfolgen. PyInstaller erzeugt betriebssystemspezifische Programme; ein unter Linux erzeugtes Programm ist keine Windows-EXE.

| Build-Ziel | Ausgabedatei | Verhalten |
|---|---|---|
| `portable` | `dist\OpticonBarcodeViewer_Portable.exe` | Startet auf jedem PC. Eine daneben liegende `license.lock` wird vollständig ignoriert. |
| `licensed` | `dist\OpticonBarcodeViewer_Licensed.exe` | Startet nur mit einer gültigen `license.lock` direkt neben der EXE. Die Datei muss zum Hardware-Hash des Ziel-PCs passen. |
| `hash-tool` | `dist\OpticonHardwareHash.exe` | Gibt ausschließlich den Hardware-Hash des aktuellen Ziel-PCs aus. Es erstellt keine Lizenzdatei und aktiviert keine Anwendung. |

## Voraussetzungen auf dem Build-PC

Installieren Sie auf einem Windows-Build-PC eine unterstützte Python-Umgebung und die Projektabhängigkeiten. Führen Sie anschließend den Build im Projektordner aus.

```powershell
py -m pip install -r requirements.txt
py build.py all --clean
```

Für einzelne Zieltypen können Sie die folgenden Befehle verwenden.

```powershell
py build.py portable --clean
py build.py licensed --clean
py build.py hash-tool --clean
```

Die Option `--dry-run` prüft ohne EXE-Erzeugung, welche PyInstaller-Befehle ausgeführt würden.

```powershell
py build.py all --clean --dry-run
```

Während eines Build-Vorgangs wird der passende Modus kurzzeitig in `build_config.py` gesetzt und direkt danach wieder auf `portable` zurückgestellt. Dadurch kann der Entwicklungsstand nicht versehentlich dauerhaft im Lizenzmodus verbleiben.

## Startup-Fehler `ModuleNotFoundError: jaraco`

Wenn eine alte portable EXE beim Start in `PyInstaller\\hooks\\rthooks\\pyi_rth_pkgres.py` mit `ModuleNotFoundError: No module named 'jaraco'` abbricht, wurde sie mit einem unnötigen setuptools/pkg_resources-Runtime-Hook gebaut. Nicht einfach Python-Pakete neben die EXE kopieren. Stattdessen die EXE mit den aktualisierten Projektdateien neu erstellen:

```powershell
py -m pip install -r requirements.txt
py build.py portable --clean
```

Die Projekt-Specs schließen `setuptools`, `pkg_resources` und `jaraco` aus, weil die Anwendung diese Pakete nicht zur Laufzeit benötigt. Dadurch wird der fehlerhafte Runtime-Hook nicht in die neue EXE übernommen.

## Portable Auslieferung

Für eine portable Auslieferung genügt die Datei `OpticonBarcodeViewer_Portable.exe`. Beim ersten Start erzeugt die Anwendung bei Bedarf ihre editierbaren Konfigurationsdateien; der Build legt außerdem `app_config.json` und `users.json` neben die Anwendung, sofern dort noch keine Dateien vorhanden sind.

Die portable Ausgabe prüft **niemals** den Hardware-Hash. Sie darf daher nicht mit der lizenzierten Ausgabedatei verwechselt werden.

## Lizenzierte Auslieferung mit Hardware-Hash

Die lizenzierte EXE enthält die Hardwareprüfung. Der komplette Ablauf besteht aus zwei getrennten Rollen: Der Ziel-PC liefert nur seinen Hash; der Lizenz-Aussteller erzeugt daraus die Lizenzdatei.

| Schritt | Rolle | Aktion |
|---|---|---|
| 1 | Build-PC | `py build.py licensed --clean` und `py build.py hash-tool --clean` ausführen. |
| 2 | Ziel-PC | `OpticonHardwareHash.exe` starten und den ausgegebenen Hash an den Lizenz-Aussteller senden. Optional: `OpticonHardwareHash.exe --output C:\Temp\opticon_hardware_hash.txt`. |
| 3 | Lizenz-Aussteller | Den erhaltenen Hash mit `generate_license_lock.py` validieren und in eine `license.lock` schreiben. |
| 4 | Ziel-PC | Die erzeugte `license.lock` in **denselben Ordner** wie `OpticonBarcodeViewer_Licensed.exe` kopieren. |
| 5 | Ziel-PC | Lizenzierte EXE starten. Nur bei exakter Übereinstimmung von Datei und Hardware-Hash startet das Programm. |

Der Lizenz-Aussteller führt im geschützten Quellprojekt beispielsweise diesen Befehl aus. Das Ausstellerwerkzeug `generate_license_lock.py` wird nicht an Kunden weitergegeben.

```powershell
py generate_license_lock.py --fingerprint <HASH_DES_ZIEL_PCS> --output-dir .\licenses\kunde_a
```

Alternativ kann eine gespeicherte Hash-Datei verarbeitet werden.

```powershell
py generate_license_lock.py --fingerprint-file C:\Temp\opticon_hardware_hash.txt --output-dir .\licenses\kunde_a
```

Die resultierende Datei heißt immer `license.lock`. Ein vorhandenes Lizenzfile wird standardmäßig nicht überschrieben. Ein Ersetzen ist nur mit der ausdrücklichen Option `--force` möglich.

```powershell
py generate_license_lock.py --fingerprint <HASH_DES_ZIEL_PCS> --output-dir .\licenses\kunde_a --force
```

## Lizenzprüfung beim Start

Die lizenzierte Anwendung vergleicht den gespeicherten Wert in `license.lock` mit einem SHA-256-Fingerprint aus folgenden Windows-Hardwareinformationen: Baseboard-Seriennummer, BIOS-Seriennummer, Prozessor-ID und System-UUID. Bei fehlender, leerer, nicht lesbarer oder nicht passender Lizenzdatei wird eine Fehlermeldung angezeigt und die Anwendung beendet.

> Änderungen an Mainboard, BIOS, CPU oder System-UUID können den Hardware-Hash verändern. In diesem Fall muss für den Ziel-PC eine neue `license.lock` erzeugt werden.

## Sicherheitsgrenze

Die Implementierung bindet die lizenzierte Anwendung an einen Hardware-Hash. Sie ist sinnvoll für eine kontrollierte Auslieferung, stellt aber allein keinen vollständigen Manipulationsschutz dar. Der Aussteller muss insbesondere `generate_license_lock.py` und den Quellcode geschützt halten. Für einen erhöhten Schutzbedarf sollten zusätzlich der Code signiert und Lizenzdateien mit einer asymmetrischen digitalen Signatur geprüft werden; der private Signaturschlüssel darf dabei ausschließlich beim Aussteller liegen.

## Verifikation

Die Variantensteuerung wurde mit `py build.py all --clean --dry-run` für alle drei Ziele geprüft. Die automatisierte Testsuite wurde zusätzlich im grafisch isolierten Modus ausgeführt und meldet **76 erfolgreich bestandene Tests**.

```powershell
$env:QT_QPA_PLATFORM = "offscreen"
py -m pytest -q
```

Der Wert in `build_config.py` bleibt nach Tests und Builds auf `BUILD_MODE = "portable"` zurückgesetzt.


## Installer als Setup-EXE

Für die beiden Setup-Dateien wird zusätzlich **Inno Setup 6** auf dem Windows-Build-PC benötigt. Das Skript `build_installers.ps1` baut zunächst die drei PyInstaller-Ziele und erzeugt anschließend:

| Installer | Inhalt | Lizenzverhalten |
|---|---|---|
| `installer\OpticonBarcodeViewer_Portable_Setup.exe` | Portable Anwendung, Standardkonfiguration und Benutzerdatei | Keine Lizenzdatei erforderlich; `license.lock` wird vollständig ignoriert. |
| `installer\OpticonBarcodeViewer_Licensed_Setup.exe` | Lizenzierte Anwendung, Hash-Hilfsprogramm und Standardkonfiguration | Die Anwendung startet erst mit einer passenden `license.lock` neben der lizenzierten EXE. |

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build_installers.ps1 -Clean
```

Der lizenzierte Installer enthält absichtlich niemals eine kundenspezifische Lizenzdatei. Nach dem Hash-Austausch wird die passende `license.lock` manuell in das Installationsverzeichnis neben `OpticonBarcodeViewer_Licensed.exe` kopiert.

## Dateiformat, Duplikate und CCD-Bilder

Die Dateinamen folgen der Präsentation: `<WaferID>#Null#<OperatorID>#<yyyyMMddHHmmss>.txt`. Bei einem automatischen Gerätescan lautet `OperatorID` `Null`; bei einer manuellen Eingabe wird die authentifizierte Mitarbeiter-ID verwendet. Der Textinhalt ist die rohe Wafer-ID als eine UTF-8-Zeile. Wenn **„Aufeinanderfolgende Duplikate ignorieren“** aktiviert ist, wird ein bereits erfasster Barcode vor der Dateispeicherung und vor der CCD-Aufnahme verworfen. Im kontinuierlichen Scanmodus läuft die Triggerfolge trotzdem weiter. Eine neue Erfassung während einer offenen NG-Retry-Zeile bleibt erlaubt, damit der bestehende Retry-Ablauf weiterhin funktioniert.

Nach einem gültigen Scan fordert die Anwendung das CCD-Bild über dieselbe bereits geöffnete COM-Verbindung an. Die JPEG-Datei erhält denselben Basisnamen wie die Barcode-Textdatei. Ohne weitere Konfiguration wird sie im gleichen Zielordner abgelegt; mit einem gesetzten `image_storage_path` in `app_config.json` wird sie direkt unter diesem externen Verzeichnis gespeichert. In der Tabelle erscheint eine Vorschau direkt in der Spalte **Bild**; der vollständige Bildpfad ist als Tooltip hinterlegt. Ein Fehler bei der optionalen Bildaufnahme macht den Barcode-Scan und die Textdatei nicht ungültig.

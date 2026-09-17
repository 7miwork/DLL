# AGENTS.md – GZVision-Systemkopplung

Kontext für KI-Coding-Assistenten (Cline, Cursor, Copilot, Aider, ...), die in
diesem Ordner arbeiten. Ziel: **Connectors** bauen, die die hier dokumentierten
Komponenten miteinander verbinden.

## 1. Hardware-Komponenten und Schnittstellen

| Komponente | Schnittstelle | Wie ansprechen | Wichtigste Quelle im Repo |
|---|---|---|---|
| SENTECH-Kamera (Sentry) | USB3-Vision / GenICam | Python: `stapipy` (wheel in `Sentech-Kamera/`) | `Sentech-Kamera/` |
| Sony XCL-5005CR | Camera-Link (Framegrabber nötig) | Kameradateien `.cam` im Framegrabber-Tool laden | `Drivers/SONY-XCL-5005CR/` |
| Opticon Barcode-Scanner | Seriell (COM) | Bestehende Software `Barcode/OpticonBarcodeViewer_ase/` (Python/PySide, `serial_reader.py`, `trigger_*.py`) erweitern oder als Referenz nutzen | `Barcode/OpticonBarcodeViewer_ase/` |
| 30U/60U-Gerät | USB-CDC (virtueller COM-Port) | VB.NET-Beispiel `Hersteller/30U-60U-Steuerung-Beispiel-VB/` (`Form1.vb`, ~50 KB Logik) | dito |
| LCUS-1 USB-Relais | USB→CH340→COM | Protokoll: 7 Byte, `FF <Kanal> <Befehl>`; `FF 01 00`=EIN, `FF 01 01`=AUS (Befehle je nach Firmware prüfen, Doku unter `LCUS-USB-Relais/Doku/`) | `LCUS-USB-Relais/` |
| GZDP-A00 Lichtquelle | seriell/USB (4 Kanäle) | Hersteller-Software als Referenz (Original in `Lichtquelle-GZDP-A00/Original`) | dito |
| SUNIX SDC0880I DI/DO | PCIe, `sdciodll.dll` | **Verifizierte API**: `Lib_init` → `SDC_enumerate_dio_info` → `SDC_dio_open` → `SDC_get_di_value(DioIndex, Port, &value)`; Details + fertiger Tester in `../SUNIX/Tester/` | `../SUNIX/` |

## 2. Verbindungsarchitektur (empfohlen)

- **Eine Connector-Bibliothek pro Komponente** (kleine Klassen mit
  `open()/close()/read()/write()`), darüber eine Orchestrator-App.
- Serielle Geräte (Barcode, 30U/60U, LCUS-Relais) via `pyserial` bzw.
  `System.IO.Ports` – Port-Erkennung über VID/PID (CH340: VID 0x1A86).
- Kamera (SENTECH) über `stapipy`-Wheel (Python 3.11, win_amd64, im Ordner
  `Sentech-Kamera/`).
- Digitale I/O über die SUNIX-DLL; **Signaturen nicht erfinden**, die
  verifizierte API steht in `../SUNIX/AGENTS.md` und `../SUNIX/Tester/`.

## 3. Regeln

1. **Keine API-Namen/-Signaturen raten.** Was nicht dokumentiert ist, wird als
   TODO markiert oder am Hersteller-Samplecode (`Original`-Ordner) abgelesen.
2. Build-Artefakte (`bin/`, `obj/`, `build/`, `dist/`, `__pycache__/`, `*.exe`)
   bleiben aus dem Git-Repo draußen (siehe `../.gitignore`).
3. Große Installer/SDKs liegen **nicht** im Repo: `Z:\GZVision\_LargeFiles_Upload\`
   (siehe `LARGE_FILES.md` – dort steht die komplette Dateiliste inkl. Spalte
   „Upload-Link"; nach dem Hochladen werden die Links in die `__LINK__`-Platzhalter
   eingetragen). Im Code/README nur darauf verweisen.
4. Chinesische Originaldateien (Ordner-/Dateinamen) nicht umbenennen, wenn sie
   von Hersteller-Tools referenziert werden – stattdessen im README übersetzen.
5. Neue Connector-Ordner nach dem Muster `<Komponente>-Connector/` anlegen und
   in `README.md` (Komponenten-Tabelle) eintragen.

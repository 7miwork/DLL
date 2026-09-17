# Opticon Barcode Viewer

A lightweight Windows desktop utility that connects to an Opticon scan engine (MDI-4x00, N210, MDI-5250, MDI-5350 series) over a serial/USB-COM interface and displays every scanned barcode as a clean, copyable list.

## Purpose

This is a **standalone companion** to the Universal Tuning Tool (UTT). It does **one thing**: listen passively on a COM port and show decoded barcodes. It does not configure or tune the scanner — use the UTT for that.

## Tech Stack

- **Language:** Python 3.11
- **GUI Framework:** PySide6 (Qt for Python)
- **Serial:** pyserial
- **Packaging:** PyInstaller (standalone .exe)

## Quick Start (packaged .exe)

1. Download `OpticonBarcodeViewer.exe` from the `dist/` folder.
2. Connect your Opticon scan engine via USB (it will appear as a virtual COM port).
3. Run the .exe — no Python installation required.

## Running from Source (dev)

```bash
# Create and activate virtual environment
python -m venv venv
.\venv\Scripts\activate

# Install dependencies
pip install -r requirements.txt

# Run the app
python main.py
```

## Building the .exe (Portable vs. Licensed)

There are **two separate builds** from the same codebase, controlled by a
build-time constant (`BUILD_MODE` in `build_config.py`):

| Build | Output | License check | Use case |
|-------|--------|---------------|----------|
| **Portable** | `dist/OpticonBarcodeViewer_Portable.exe` | None — runs on any PC, ignores `license.lock` | Internal testing and demonstrations only |
| **Licensed** | `dist/OpticonBarcodeViewer_Licensed.exe` | Requires a valid `license.lock` next to the `.exe` | Customer production delivery |

### Which .exe do I ship to the customer?

| Recipient | Ship this file | Why |
|-----------|---------------|-----|
| **Customer with license** | `OpticonBarcodeViewer_Licensed.exe` + `license.lock` | Enforces hardware binding — only runs on the licensed PC |
| **Internal / demo / test** | `OpticonBarcodeViewer_Portable.exe` | No license check — runs anywhere, for testing and demonstrations |

> **⚠️ Never ship `OpticonBarcodeViewer_Portable.exe` to a customer.**
> The portable build has **no license protection** and will run on any PC
> without restriction. It is intended for internal testing and demos only.

> **Never edit `build_config.py` manually.** The build script overwrites it
> automatically with the correct value before each build and restores a safe
> default (`"portable"`) afterwards. See the warning comment at the top of
> `build_config.py` for details.

### Build with the build script (recommended)

```bash
# Activate venv first
.\venv\Scripts\activate

# Build portable version only
python build.py portable

# Build licensed version only
python build.py licensed

# Build both
python build.py all
```

The script:
1. Sets `BUILD_MODE` in `build_config.py` only for the current PyInstaller analysis.
2. Runs PyInstaller with the matching `.spec` file and a target-specific work directory.
3. Stages `app_config.json` and `users.json` beside the executable without overwriting existing runtime values.
4. Restores `build_config.py` to `"portable"` (safe development default), even when a build fails.

### Manual build (not recommended)

If you must build without the script, you need to manually set
`BUILD_MODE` in `build_config.py` before running PyInstaller:

```bash
# 1. Edit build_config.py: set BUILD_MODE = "portable" or "licensed"
# 2. Run PyInstaller with the matching spec:
.\venv\Scripts\pyinstaller --noconfirm OpticonBarcodeViewer_Portable.spec
# or
.\venv\Scripts\pyinstaller --noconfirm OpticonBarcodeViewer_Licensed.spec
```

### Generating a `license.lock` for a target PC

Run `OpticonHardwareHash.exe` on the target PC and send the displayed SHA-256
fingerprint to the license issuer. The issuer runs the protected
`generate_license_lock.py` utility and provides the resulting `license.lock`.
Place that file next to `OpticonBarcodeViewer_Licensed.exe`. Do not ship the
portable executable as a substitute: it intentionally has no license check.

## Project Structure

```
OpticonBarcodeViewer/
├── main.py                # Entry point
├── main_window.py         # PySide6 GUI (connection panel, scan list, copy, etc.)
├── serial_reader.py       # QThread-based serial reader (CR/LF framing, ACK/NAK filter)
├── models.py              # Scan dataclass
├── settings.py            # JSON settings persistence
├── app_config.json        # Production paths, image root, and Wafer-ID pattern
├── requirements.txt       # pyserial, PySide6, pyinstaller
├── README.md
└── dist/                  # (after building) standalone .exe
```

## Serial Protocol Assumption

The engine transmits decoded barcode data as ASCII bytes followed by a single `<CR>` (0x0D) terminator:

```
ReadData<CR>
```

- **CRLF** (0x0D 0x0A) is also handled as a single terminator.
- Stray **ACK** (0x06) and **NAK** (0x15) bytes are filtered out and never shown as scans.
- The app does **not** parse or strip Code ID prefixes, custom prefixes/suffixes, or any other device-configured adornments. The full raw string between terminators is displayed as-is.

## Features

- COM port dropdown with live refresh button
- Baud rate selection (1200–115200, default 9600)
- Connect/Disconnect with colored status indicator
- Newest scans appear at the top
- Monospace (Consolas) font for easy reading
- Running scan count
- **Copy:**
  - Double-click a row → copies that barcode immediately
  - Multi-select (Ctrl/Shift + click) + "Copy Selected" → copies one per line
  - "Copy All" → copies all barcodes, one per line
  - Ctrl+C keyboard shortcut
  - Visual "✓ Copied" confirmation (auto-fades after 2s)
- **Clear** button (with confirmation dialog for 10+ scans)
- **Ignore consecutive duplicates** toggle (greys out duplicates)
- Persists window position/size and last-used COM port + baud rate
- Gracefully handles device unplug/replug (no crash)
- Runs serial I/O on background QThread — GUI never freezes

## Out of Scope (v1)

- Device configuration/tuning commands
- Image capture
- Barcode symbology filtering or validation
- Networking, cloud sync, or export integrations

## License

Internal utility — no license specified.


## Wafer-ID Speicherlogik (UV-300)

This section documents the UV-300 Wafer-ID storage logic added for the customer requirement.

### Standard / Non-Standard Format

- **Standard format:** Exactly 4 non-empty segments separated by ``-`` (e.g. ``1-123CD4-001-001``).
  The target folder is ``<standard_root_path>/<S2>B<S3>/`` (e.g. ``C:\KH\strip2D\123CD4B001\``).
- **Non-standard format:** Any Wafer ID that does not match the standard format (wrong number of
  segments, empty, ``None``, etc.) is stored directly under ``nonstandard_path``
  (default ``C:\KH\strip2D\2490\``).

### External Configuration (``app_config.json``)

Storage paths are **not** hard-coded in Python code. They are defined in ``app_config.json``:

```json
{
  "standard_root_path": "C:\\KH\\strip2D\\",
  "nonstandard_path": "C:\\KH\\strip2D\\2490\\",
  "wafer_id_pattern": "^(?P<seg1>[^-]+)-(?P<seg2>[^-]+)-(?P<seg3>[^-]+)-(?P<seg4>[^-]+)$",
  "scan_timeout_seconds": 5
}
```

This file is created automatically on first start with the above defaults.

**Configurable Wafer-ID pattern (``wafer_id_pattern``):**
The standard-format validation uses a regex pattern with named groups ``seg1``, ``seg2``, ``seg3``, ``seg4``.
The folder name is always built from ``<seg2>B<seg3>``. If the customer has different Wafer-ID formats
(e.g. 3 segments, different separators), they can change this pattern in ``app_config.json`` without
modifying the Python code. If the pattern is invalid, the application falls back to the default
4-segment pattern and logs a warning — it never crashes.

**Configurable scan timeout (``scan_timeout_seconds``):**
The timeout after a trigger before "no scan" is assumed (and manual entry with login is offered)
is read from this field. Default is 5 seconds. Change it in ``app_config.json`` to adjust.

*Why ``app_config.json`` and not ``settings.json``?* The timeout is a production parameter
(like the storage paths), not a user-facing UI preference. It belongs in the same file as the
other manufacturing/IT configuration, keeping ``settings.json`` for window/UI state only.

### File Name Schema

```
<WaferID>#<Substrate2D>#<OperatorId>#<yyyyMMddHHmmss>.txt
```

- ``WaferID``: The raw decoded or manually entered Wafer ID.
- ``Substrate2D``: Always ``Null`` (this machine does not read it).
- ``OperatorId``: ``Null`` for automatic scans; login ID (e.g. ``A12345``) for manual entry.
- Timestamp: ``yyyyMMddHHmmss`` format.

### Login & Manual Entry

When the device does not return a scan within 5 seconds of a trigger, a **login dialog** appears.
The user must authenticate (local ``users.json``, default demo user ``A12345`` / ``password``).
After successful login, the user can enter the Wafer ID manually. The login ID is written to the
third field of the filename (Wafer ID is first, Substrate 2D is second, Operator ID is third).

### New / Modified Files

| File | Description |
|------|-------------|
| ``app_config.py`` / ``app_config.json`` | Production config (storage paths and image root) |
| ``wafer_id.py`` | Wafer-ID parsing and folder resolution |
| ``scan_file_writer.py`` | Builds filename, writes scan file |
| ``auth.py`` / ``users.json`` | Local authentication (SHA-256 + salt) |
| ``login_dialog.py`` | Login dialog (QDialog) |
| ``tests/test_wafer_id.py`` | Unit tests for wafer_id.py |
| ``models.py`` | Extended ``Scan`` dataclass (wafer_id, folder_path, etc.) |
| ``main_window.py`` | Integrated UV-300 logic (timeout, save, login flow) |
| ``i18n.py`` | New i18n strings for login, save status, etc. |

## Wafer-ID Speicherlogik (UV-300) / Wafer-ID Storage Logic (UV-300)

Für den UV-300 Reader wurde eine Wafer-ID-Speicherlogik implementiert, die jeden gescannten Barcode als Datei in einem konfigurierten Ordner speichert.

For the UV-300 reader, a Wafer-ID storage logic has been implemented that saves every scanned barcode as a file in a configured folder.

### Standard- vs. Nicht-Standard-Format / Standard vs. Non-Standard Format

**Standardformat Wafer ID:** `1-123CD4-001-001` (4 durch `-` getrennte Segmente / 4 segments separated by `-`)
- Ordnername: `<Segment2>B<Segment3>` → `123CD4B001` / Folder name: `<Segment2>B<Segment3>` → `123CD4B001`
- Vollständiger Pfad: `<standard_root_path>\<Ordnername>\` / Full path: `<standard_root_path>\<FolderName>\`

**Nicht-Standardformat:** Alle Wafer-IDs, die nicht dem Standardformat entsprechen / **Non-Standard Format:** All Wafer IDs that do not match the standard format
- Vollständiger Pfad: `<nonstandard_path>` (direkt, kein Unterordner / directly, no subfolder)

### Konfigurationsdatei / Configuration File

Die Pfade werden in `app_config.json` konfiguriert (wird beim ersten Start automatisch erstellt) / Paths are configured in `app_config.json` (automatically created on first start):

```json
{
  "standard_root_path": "C:\\KH\\strip2D\\",
  "nonstandard_path": "C:\\KH\\strip2D\\2490\\",
  "image_storage_path": ""
}
```

Das CCD-JPEG wird immer **parallel zur Textdatei** im selben Barcode-Ordner abgelegt (gleicher Dateiname, Endung `.jpg`) / The CCD JPEG is always stored **in parallel to the text file** inside the same barcode-named folder (same filename, `.jpg` extension).

Das Bild umfasst standardmäßig den **gesamten Scanbereich** des Sensors (1280×800 Pixel bei MDI-5250/5350; kein Viertel-Crop) / By default the picture covers the **whole sensor scan area** (1280×800 pixels on MDI-5250/5350; not a quarter crop). Die Geometrie ist über `app_config.json` anpassbar / The geometry is configurable in `app_config.json`: `image_capture_width`, `image_capture_height`, `image_capture_subsample` (1/2/4), `image_capture_jpeg_quality` (5-100). Für MDI-4x00/N210-Engines (752×480-Sensor) `752`/`480` setzen / For MDI-4x00/N210 engines (752×480 sensor) set `752`/`480`.

### Dateinamensschema / Filename Schema

Jeder Scan wird als `.txt`-Datei mit folgendem Namensschema gespeichert / Each scan is saved as a `.txt` file with the following naming schema:

```
<WaferID>#<Substrate2D>#<OperatorID>#<yyyyMMddHHmmss>.txt
```

- **WaferID:** Die gescannte/eingegebene Wafer-ID / The scanned or entered Wafer ID
- **Substrate2D:** Immer `"Null"`, da dieses Gerät diesen Wert nicht liest / Always `"Null"`, because this machine does not read it
- **OperatorID:** `"Null"` beim automatischen Scan, Login-ID bei manueller Eingabe / `"Null"` for automatic scan, login ID for manual entry
- **Timestamp:** Zeitstempel im Format `yyyyMMddHHmmss` / Timestamp in format `yyyyMMddHHmmss`

Beispiele / Examples:
- Automatischer Scan / Automatic scan: `1-123CD4-001-001#Null#Null#20260729112257.txt`
- Manuelle Eingabe / Manual entry: `1-123CD4-001-001#Null#A12345#20260729112257.txt`

### Manuelle Eingabe mit Login / Manual Entry with Login

Wenn das Gerät keine Wafer-ID lesen kann (Timeout nach 5 Sekunden nach Trigger), erscheint ein Login-Dialog. Nach erfolgreicher Authentifizierung kann die Wafer-ID manuell eingegeben werden.

If the device cannot read a Wafer ID (timeout after 5 seconds after trigger), a login dialog appears. After successful authentication, the Wafer ID can be entered manually.

**Benutzerverwaltung:** `users.json` (wird beim ersten Start automatisch erstellt) / **User Management:** `users.json` (automatically created on first start)
- Standard-Benutzer: Login `A12345`, Passwort `password` / Default user: Login `A12345`, Password `password`
- Passwörter sind SHA-256-gehasht mit Salt (nicht im Klartext) / Passwords are SHA-256 hashed with salt (not in clear text)
- Berechtigungs-Flag `can_manual_entry` steuert, ob ein Benutzer manuell eingeben darf / Permission flag `can_manual_entry` controls whether a user can enter manually

### Dateiinhalt / File Content

Die Datei enthält standardmäßig die rohe Wafer-ID als einzige Zeile. Dies kann in `scan_file_writer.py` in der Funktion `build_file_content()` angepasst werden, falls der Kunde ein anderes Format erwartet.

The file contains the raw Wafer ID as a single line by default. This can be adjusted in `scan_file_writer.py` in the function `build_file_content()` if the customer expects a different format.

### Timestamp-Kollision / Timestamp Collision

Wenn im selben Sekundenbruchteil zwei Scans mit identischer Wafer-ID auftreten, wird ein Zähler-Suffix angehängt: `...#20260729112257(1).txt`. Die Datei wird niemals stillschweigend überschrieben.

If two scans with identical Wafer ID occur in the same second, a counter suffix is appended: `...#20260729112257(1).txt`. The file is never silently overwritten.

### Tabellenanzeige / Table Display

Die Tabelle zeigt zusätzlich eine Spalte "Save Status" an / The table shows an additional "Save Status" column:
- **gespeichert** (saved): Datei erfolgreich geschrieben / File written successfully
- **fehlgeschlagen** (failed): Schreibfehler (Berechtigung, Netzwerk offline, etc.) / Write error (permission, network offline, etc.)
- **ausstehend** (pending): Noch nicht versucht (sollte im Normalfall nicht auftreten) / Not yet attempted (should not occur in normal operation)

### Offene Fragen zur Kundenverifizierung / Open Questions for Customer Verification

1. **Standardformat-Regel / Standard Format Rule:** Die Validierung basiert auf der Annahme "genau 4 durch `-` getrennte, nicht-leere Segmente". Falls es weitere Wafer-ID-Formate gibt, muss diese Annahme verifiziert werden.

Validation is based on the assumption "exactly 4 non-empty segments separated by `-`". If other Wafer ID formats exist, this assumption must be verified.

2. **Dateiinhalt / File Content:** Das Dokument spezifiziert nur den Dateinamen, nicht den Inhalt. Aktuell wird die rohe Wafer-ID als einzige Zeile geschrieben. Falls eine leere Datei oder ein anderes Format erwartet wird, muss dies angepasst werden.

The document specifies only the filename, not the content. Currently, the raw Wafer ID is written as a single line. If an empty file or a different format is expected, this must be adjusted.

3. **Timestamp-Kollision / Timestamp Collision:** Bei identischem Timestamp wird ein Zähler-Suffix angehängt. Falls stattdessen überschrieben oder abgelehnt werden soll, muss dies geändert werden.

For identical timestamps, a counter suffix is appended. If instead overwriting or rejection is desired, this must be changed.

4. **Authentifizierungssystem / Authentication System:** Aktuell wird eine lokale `users.json`-Datei verwendet. Falls ein zentrales AD-/LDAP-System angebunden werden soll, kann dies in `auth.authenticate()` implementiert werden.

Currently, a local `users.json` file is used. If a central AD/LDAP system should be connected, this can be implemented in `auth.authenticate()`.

5. **Timeout für manuelle Eingabe / Timeout for Manual Entry:** Die Implementierung geht davon aus, dass "kein Scan nach Trigger" (Timeout nach 5 Sekunden) die manuelle Eingabe auslöst. Falls dies anders gemeint war, muss die Logik angepasst werden.

The implementation assumes that "no scan after trigger" (timeout after 5 seconds) triggers manual entry. If this was meant differently, the logic must be adjusted.

---

## Hilfe & Tutorial / Help & Tutorial

### Hilfe / Nachschlagewerk / Help & Reference

Ein integriertes Handbuch ist über das **Menü ▸ Hilfe...** oder die Taste
**F1** erreichbar. Es ist mehrsprachig (EN/DE/zh_Hant — folgt der aktuell in
den Einstellungen gewählten Sprache). Im Dialog gibt es links eine
durchsuchbare Kapitelliste und rechts den Inhalt des gewählten Kapitels:

- Erste Schritte / Continuous Scan / Operator-ID & Validierung
- Trigger / Retry / Manuelle Eingabe / Tuning-Tool (Banks)
- Portable vs. Licensed Build / Fehlerbehebung / Über & Support

Über das Suchfeld kann nach Kapitel-Titel **und** Inhalt gefiltert werden.

The integrated reference manual is opened via **Menu ▸ Help...** or the
**F1** key. It follows the currently selected language (EN/DE/zh_Hant). The
dialog shows a searchable chapter list on the left and the chapter content
on the right (Getting Started, Continuous Scan, Operator ID & Validation,
Trigger/Retry/Manual Entry, Tuning (Banks), Portable vs. Licensed, Troubleshooting,
About & Support). The search box filters by title **and** body.

### Tutorial (geführte Erstbenutzer-Tour / Guided First-Run Tour)

Beim **allerersten Start** erscheint automatisch eine kurze, halbtransparente
Überlagerung, die den Kern-Workflow erklärt (COM-Port wählen → verbinden →
scannen → kopieren). Sie kann jederzeit übersprungen werden
(**Überspringen**). Danach startet sie nie wieder automatisch; über
**Menü ▸ Tutorial erneut starten** kann die Tour jederzeit manuell neu
gestartet werden. Die Tour ist rein visuell und löst keine echten
Verbindungs-/Scan-Aktionen aus.

On the **very first launch** a short, semi-transparent overlay explains the
core workflow (select COM port → connect → scan → copy). It can be skipped
any time (**Skip**) and never auto-starts again afterwards. You can restart
it manually via **Menu ▸ Restart Tutorial**. The tour is purely visual and
never triggers real connection/scan actions.

Die Fertigstellung/Skipping wird in `settings.json` unter
`tutorial_completed` gespeichert.


## Client workflow update (2026-08)

The application uses an authenticated session before connection or triggering. The active operator remains visible in the UI, while the presentation’s filename rule is followed exactly: automatic records use `Null` in the operator field and manual records use the authenticated employee ID. Manual input is available only to accounts with the manual-entry permission and is clearly marked as **Manual input** in the table and exported data.

The production interface is bilingual by default and displays English and Traditional Chinese together. Operators see only the connection, start/trigger, stop, manual-entry, session, and scan-result controls. Administrators retain the complete settings, tuning, export, history, duplicate-policy, help, and user-management controls.

Duplicate ignoring is enabled as the standard behavior. Each accepted barcode is written to its own UTF-8 `.txt` file with one raw Wafer-ID line, using the filename schema `<WaferID>#Null#<OperatorID>#<yyyyMMddHHmmss>.txt`. If a CCD image is returned, it is saved as a same-basename `.jpg` **in parallel to the text file** inside the same barcode folder — even when the scan table row is already gone by the time the picture arrives (e.g. a new session during the transfer). Existing files are never overwritten; a numeric suffix is added on timestamp collisions.

Standard Wafer IDs are split into configured segments. For the default value `1-123CD4-001-001`, the target folder is `<standard_root_path>/123CD4B001/`; non-standard IDs are stored in the configured non-standard directory. The manual-entry dialog and login form autofocus their primary input, while the main window returns focus to Connect or Trigger for keyboard/scanner operation. The physical UV interlock and MIS upload protocol are not specified in the presentation and require the customer’s I/O and network-interface documentation before safe implementation.

For the interpreted acceptance criteria and implementation assumptions, see `CLIENT_WORKFLOW.md`.


## CCD calibration: Auto Focus → Auto Tuning

The administrator tuning tab includes a combined calibration action matching the UniversalTuningTool workflow. Ensure the barcode target is positioned in the CCD view, select the correct bank, and press **Auto Focus → Auto Tuning**. The calibration now actively targets **the barcode** instead of whatever else is in the field of view:

1. **Auto Focus (best-effort):** the configured Auto Focus command is sent first and waits up to two seconds. If the engine confirms it, the workflow continues immediately; if the engine rejects the command or stays silent, the calibration **continues anyway** with a clear status message — many Opticon engines (the MDI-5250/5350 command set, for example) have no Auto Focus command at all and ignore undefined commands silently.
2. **Locate:** one or more CCD frames are captured (up to 3 attempts) and the barcode in them is decoded and located (zxing-cpp, with multiple decode strategies: rotation/inversion, a histogram binarizer and 2x upscaling for small codes). Barcodes that match the configured `wafer_id_pattern` are **preferred over larger foreign barcodes** in the field of view. The engine's decode area (`[DF8` margins, serial interface manual §8.10) is then restricted to a comfortable window around that barcode — at least ~35 % of the frame so a sensor/mapping mismatch cannot push it out of the window. If no barcode is found, tuning runs unrestricted as before.
3. **Auto Tuning (`[DT1`):** the exposure optimization now measures the located barcode only. The data the engine read while tuning is compared against the located barcode. If tuning fails or reads nothing, the restriction is dropped and DT1 retried once over the full view before reporting failure. If tuning locked onto a different code, the workflow re-locates from a fresh frame and retries once.
4. **Verify:** after tuning, the decode area is reset and a CCD frame is captured (up to 2 attempts; a momentary blurry frame is retried). The barcode is decoded again and reported as *"Barcode verified clear in the CCD image"* together with a sharpness (clarity) metric in the tuning result box.

Each phase retries a bounded number of times, so a single bad frame ("some barcodes") no longer fails the whole calibration.

The decode-area restriction is always restored (after tuning, on abort, on stop), so production scanning is never limited to the calibration region. Engines that do not implement `[DF8` ignore the restriction silently and simply tune on the full view.

The default Auto Focus command identifier is `AF`, stored in `app_config.json` as `autofocus_command`; it stays editable in the administrator tuning settings for firmwares that do implement Auto Focus. The standalone **Auto Focus** button releases its busy state automatically when the engine does not answer, and the standalone **Start Tuning** action remains available for tuning-only operation.

The main window, login dialog, and manual-entry dialog restore keyboard focus to their next safe primary control or input field after activation and workflow transitions.


## Scan Data Save Location and Folder Structure

The administrator must select one **Scan Data Save Location** in **Menu → Settings → Interface**. The application creates the following folders inside that location:

```text
<selected root>/Standardized Format/<barcode>/
<selected root>/Non-Standardized Format/<barcode>/
```

The barcode `1-123CD4-001-001` is a **Standardized Format** barcode. All other barcode values are stored under **Non-Standardized Format**. Each scan folder is named with the complete barcode. The folder contains the TXT record and its CCD picture.

The TXT filename format is:

```text
Null#<Wafer ID>#<Manual Operator ID>#yyyyMMddHHmmss.txt
```

For a normal equipment reading, the filename is, for example:

```text
Null#1-123CD4-001-001#Null#20260729112257.txt
```

The corresponding image is saved in the same barcode folder with the same base filename and a `.jpg` extension. A manual entry uses the authenticated employee ID in the third field and does not produce a CCD image because it is not an equipment camera read.

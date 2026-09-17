# SUNIX PCI Express Industrial I/O Control Board

Dokumentation, Beispielcode und KI-Assistenz-Kontext für die Anbindung der
**SUNIX SDC4880B** (Serial RS-232/422/485 + Digital I/O) bzw.
**SDC0880I** (nur Digital I/O) über die Hersteller-DLL `sdciodll.dll`.

## Dateien in diesem Ordner

| Datei | Zweck |
|---|---|
| [`AGENTS.md`](./AGENTS.md) | Werkzeug-neutraler KI-Kontext (Cursor, Copilot, Aider, ChatGPT, Claude in der IDE, ...) – Hardware-Fakten, bekannte DLL-Funktionen, Regeln für die Zusammenarbeit ohne physische Hardware vor Ort. |
| [`.clinerules`](./.clinerules) | Dieselben Inhalte wie `AGENTS.md`, in Cline-eigener Konvention. |
| [`SUNIX_DLL_Python.md`](./SUNIX_DLL_Python.md) | Beispielcode: DLL-Zugriff per `ctypes` (Python). |
| [`SUNIX_DLL_Cpp.md`](./SUNIX_DLL_Cpp.md) | Beispielcode: DLL-Einbindung in Visual Studio (C++), inkl. Projekt-Setup. |
| [`SUNIX_DLL_VisualBasic.md`](./SUNIX_DLL_VisualBasic.md) | Beispielcode: DLL-Zugriff per `DllImport` (VB.NET). |
| [`SUNIX_Installation_Kurzanleitung.md`](./SUNIX_Installation_Kurzanleitung.md) | Kurzanleitung Hardware-Einbau + Treiberinstallation, inkl. Begriffe für traditionell-chinesisches Windows. |
| [`SUNIX_Install_Helper.ps1`](./SUNIX_Install_Helper.ps1) | PowerShell-Skript: startet die Treiberinstallation und prüft danach per `Get-PnpDevice`, ob Karte/COM-Ports erkannt wurden. |

## Wichtigster Fakt für jede KI, die hier arbeitet

Aus der Hersteller-Dokumentation sind nur diese vier DLL-Funktionen bestätigt:
`_sdc_dll_init()`, `_sdc_dll_free()`, `_sdc_get_service_info()`,
`_sdc_get_sdc_info()`. Alles darüber hinaus (insbesondere Lesen der Digital
Inputs / Schreiben der Digital Outputs) steht nur in der `sdciodll.h` aus dem
Hersteller-SDK, die **nicht** Teil dieses Repos ist. Details siehe
[`AGENTS.md`](./AGENTS.md), Abschnitt 3.

## Hardware kurz zusammengefasst

- SDC4880B: 4× RS-232/422/485 (16C950 UART) + 8× isolierter Digital Input +
  8× isolierter Digital Output.
- SDC0880I: nur 8× isolierter Digital Input + 8× isolierter Digital Output.
- Anschluss über DB44-Terminalblock (SDC4880B) bzw. DB25 (SDC0880I).

Vollständige Pin-Zuordnung und technische Details: siehe `AGENTS.md`
Abschnitt 1 bzw. das Original-Handbuch des Herstellers (nicht Teil dieses
Repos).

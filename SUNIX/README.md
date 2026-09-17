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
| [`Driver/`](./Driver) | Original-Treiber-/API-Pakete des Herstellers (ZIP): SDC IO Manager x86/x64 (Treiber + SDC Manager), Windows SDC API V1.0.6.0 (enthält `sdciodll.h`, `sdciodll.dll` x86/x64 sowie C/C#/VB-Samples) und der Linux-Treiber. Nur zur Referenz/Installation gedacht – die Binärdateien werden nicht ins Git-Repo committet. |
| [`Manual/`](./Manual), [`Guide/`](./Guide), [`Datasheet/`](./Datasheet) | Hersteller-Dokumentation als PDF: Benutzerhandbuch (SDC Manager inkl. Invert-Option), Quick Installation Guide und Datenblatt (SDC0880I). |
| [`Tester/`](./Tester) | Lauffähiger **DI-Tester** (Python/C++/VB.NET) für die 8 Digital Inputs – inkl. Mock-Fallback, damit er auch ohne eingebaute Karte läuft. Details: [`Tester/README.md`](./Tester/README.md). |

## Digital-Input-Tester (`Tester/`)

Im Unterordner [`Tester/`](./Tester) liegt ein fertiges kleines Testprogramm,
das die 8 Digital Inputs live anzeigt: **DI1–DI8**, grün = von der API als
aktiv/1 gemeldet, grau = inaktiv, Polling alle 250 ms. Es gibt das Programm
dreimal – Python (Tkinter), C++ (Konsole) und VB.NET (WinForms) – jeweils mit
identischer Architektur (Abstraktionsschicht `SdcIoClient`, dynamisches Laden
der DLL, automatischer **Mock-Modus** als Fallback).

Wichtig: Ob „aktiv“ elektrisch High oder Low ist, wird nicht ausgewertet – das
stellt man im SDC Manager über die Invert-Option ein. Die DLL-API
(`Lib_init` / `SDC_enumerate_dio_info` / `SDC_dio_open` / `SDC_get_di_value`)
ist inzwischen über das API-Paket in `Driver/` **vollständig verifiziert** und
 gegen die echte DLL getestet (Details: [`Tester/README.md`](./Tester/README.md)).

## Wichtigster Fakt für jede KI, die hier arbeitet

Die echten DLL-Exporte (bestätigt per `sdciodll.h` aus dem API-Paket in
`Driver/` sowie per `dumpbin /exports`): `Lib_init`, `Lib_free`,
`Get_library_info`, `SDC_enumerate_dio_info`, `SDC_dio_open`, `SDC_dio_close`,
`SDC_get_di_value`, `SDC_set_di_invert`, `SDC_set_do_value`, u. a. (39 Exporte,
x86/x64 identisch). Die im älteren Handbuch genannten Namen (`_sdc_dll_init`
usw.) existieren in dieser DLL-Version **nicht**. Details siehe
[`AGENTS.md`](./AGENTS.md), Abschnitt 3, und [`Tester/README.md`](./Tester/README.md).

## Hardware kurz zusammengefasst

- SDC4880B: 4× RS-232/422/485 (16C950 UART) + 8× isolierter Digital Input +
  8× isolierter Digital Output.
- SDC0880I: nur 8× isolierter Digital Input + 8× isolierter Digital Output.
- Anschluss über DB44-Terminalblock (SDC4880B) bzw. DB25 (SDC0880I).

Vollständige Pin-Zuordnung und technische Details: siehe `AGENTS.md`
Abschnitt 1 bzw. das Original-Handbuch des Herstellers (nicht Teil dieses
Repos).

# Repo-Index (für KI-Assistenten & Menschen)

> **Schnellstart für KIs:** Lies zuerst `README.md` (Übergeordnete Regeln),
> dann im jeweiligen Projektordner `AGENTS.md` / `.clinerules`.
> **Niemals DLL-Funktionssignaturen erfinden** – nur verifizierte Namen aus
> Headers/Exportlisten verwenden; wo nichts verifiziert ist: TODO + nachfragen.

## Projekt 1: `SUNIX/` – SUNIX SDC0880I (PCIe Digital-I/O-Karte)

**Zweck:** Ansteuerung der 8 Digital-Inputs über `sdciodll.dll`; DI-Tester in
3 Sprachen; API vollständig verifiziert.

| Pfad | Inhalt |
|---|---|
| `SUNIX/AGENTS.md`, `SUNIX/.clinerules` | **ZUERST LESEN** – KI-Kontext, Regeln, Hardware-Fakten, verifizierte API |
| `SUNIX/README.md` | Projektübersicht, Hardware-Kurzbeschreibung |
| `SUNIX/SUNIX_DLL_Python.md` | ctypes-Beispielcode |
| `SUNIX/SUNIX_DLL_Cpp.md` | C++-Einbindung (LoadLibrary) |
| `SUNIX/SUNIX_DLL_VisualBasic.md` | VB.NET DllImport-Beispiel |
| `SUNIX/SUNIX_Installation_Kurzanleitung.md` | Einbau + Treiberinstallation |
| `SUNIX/SUNIX_Install_Helper.ps1` | Treiberinstallation + Erkennungscheck |
| `SUNIX/Tester/` | **Lauffähiger DI-Tester** (Python/C++/VB.NET, je eigener README, Mock-Fallback) – Details `Tester/README.md` |
| `SUNIX/Driver/` | Original-Herstellerpakete (ZIP): SDC API 1.0.6.0 mit `sdciodll.h` + `sdciodll.dll` x86/x64 + Beispielen, SDC-IO-Manager |
| `SUNIX/Manual/`, `SUNIX/Guide/`, `SUNIX/Datasheet/` | Hersteller-PDFs (Handbuch, Quick Guide, Datenblatt) |

**Verifizierte DLL-API** (Exporte der echten `sdciodll.dll`, alle `__cdecl`, 0 = OK):
`Lib_init`, `Lib_free`, `SDC_enumerate_dio_info`, `SDC_dio_open(DioIndex)`,
`SDC_dio_close(DioIndex)`, `SDC_get_di_value(DioIndex, Port, &value)`,
`SDC_get_do_value`, `SDC_set_do_value`, `SDC_set_di_invert`, u. a.
Die alten Manual-Namen (`_sdc_dll_init`, …) existieren in dieser DLL-Version **nicht**.

## Projekt 2: `GZVision/` – Produktionsanlagen-Komponenten (Kamera, Licht, Relais, Barcode)

**Zweck:** Quellcode + Doku der Systemkomponenten einer Produktionslinie, als
Grundlage für **Connectors** (Systeme miteinander verbinden).

| Pfad | Inhalt / Verwendung |
|---|---|
| `GZVision/README.md` | Übersicht + Zweck je Unterordner |
| `GZVision/AGENTS.md` | **KI-Kontext für Connector-Bau** (Schnittstellen, Ansprechpartner-Code) |
| `GZVision/LARGE_FILES.md` | **Verweise auf große Dateien** (Installer/SDKs, ~1,4 GB), die NICHT im Repo liegen, sondern separat unter `Z:\GZVision\_LargeFiles_Upload\` hochgeladen werden |
| `GZVision/Sentech-Kamera/` | Sentech-GigE-Kamera (Doku/Verweis) |
| `GZVision/Drivers/SONY-XCL-5005CR/` | Sony-Kamera-Unterlagen |
| `GZVision/Barcode/Csharp-ImageCapture-VS2008-Beispiel/` | Barcode-Scanner C#-Beispiel (Bildaufnahme) |
| `GZVision/Barcode/OpticonBarcodeViewer_ase/` | Opticon-Barcode-Viewer (Python, mit tests) |
| `GZVision/AOI-HoleDetection/HoleDetection-Quellcode/` | AOI-Locherkennung (VB.NET-Quellcode) |
| `GZVision/LCUS-USB-Relais/` | LCUS USB-Relaiskarte: Quellcode + Doku + HEX/Flash-Tools |
| `GZVision/Lichtquelle-GZDP-A00/` | 4-Kanal-Lichtquellensteuerung GZDP-A00 (Original-Doku/Software – große Teile siehe LARGE_FILES.md) |
| `GZVision/Hersteller/30U-60U-Steuerung-Beispiel-VB/` | VB.NET USB-CDC-Demo (30U/60U-Gerätesteuerung) |

## Konventionen im Repo

- **Ein Top-Level-Ordner pro Projekt** (Hersteller/Anlage), darin:
  `README.md` + `AGENTS.md`/`.clinerules` + Doku + ggf. `Tester/` o. ä.
- **Keine großen Binärdateien im Git** (Installer, SDK-ZIPs > ~5 MB): diese
  liegen separat (`_LargeFiles_Upload` o. ä.) und werden in `LARGE_FILES.md`
  bzw. Projekt-READMEs verlinkt.
- Hersteller-DLLs/Headers im Repo = Original-Pakete (`Driver/`-Ordner), damit
  Signaturen immer gegen die echte Quelle prüfbar sind.
- Build-Artefakte (`dist/`, `bin/`, `obj/`, `__pycache__/`, `*.exe`, …) sind
  in `.gitignore` ausgeschlossen – nur Quellcode + Doku committen.
- Arbeitsweise: KI-Ideen zuerst zeigen, vor jedem Push kurz bestätigen lassen.
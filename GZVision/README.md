# GZVision – Systemkopplung: Kamera, I/O, Barcode, Relais, Lichtquelle

Dieser Ordner bündelt **Treiber, Beispielcode und Dokumentation** aller
Systemkomponenten einer GZVision-Inspektionsanlage, damit daraus
**Connectors** (Anbindungssoftware zwischen den Komponenten) gebaut werden
können – von Hand oder mit KI-Assistenz (Cline, Copilot, ...).

## Komponenten-Übersicht

| Ordner | Komponente | Typ | Anbindung |
|---|---|---|---|
| [`Sentech-Kamera/`](./Sentech-Kamera) | SENTECH (Sentry) Industriekamera | SDK | `stapipy` (Python-GenICam/USB3-Vision), wheel beigelegt |
| [`Drivers/SONY-XCL-5005CR/`](./Drivers/SONY-XCL-5005CR) | Sony XCL-5005CR Camera-Link-Kamera | Treiber/Kameradateien | `.cam`-Kameradateien + Installationsanleitung + Datenblatt |
| [`Barcode/OpticonBarcodeViewer_ase/`](./Barcode/OpticonBarcodeViewer_ase) | Opticon Barcode-Scanner (ASE-Arbeitsplatz) | Eigene Software (Python/PySide) | seriell (COM), Trigger-Steuerung, Wafer-ID-Parsing |
| [`Barcode/Csharp-ImageCapture-VS2008-Beispiel/`](./Barcode/Csharp-ImageCapture-VS2008-Beispiel) | Bildaufnahme per Scanner/Camera (Herstellerbeispiel) | C#-Beispiel | Referenzcode |
| [`AOI-HoleDetection/`](./AOI-HoleDetection) | 薄帶孔位 AOI-Lochdetektion (Band inspection) | Eigene Software (VB.NET) | Oberflächen-/Lochprüfung, Send-Data-Version 2026-09-07 |
| [`Hersteller/30U-60U-Steuerung-Beispiel-VB/`](./Hersteller/30U-60U-Steuerung-Beispiel-VB) | 30U/60U-Gerätesteuerung (客户端 V1.1) | Herstellerbeispiel (VB.NET) | USB-CDC (virtueller COM-Port) |
| [`LCUS-USB-Relais/`](./LCUS-USB-Relais) | LCUS-1 USB-Relais (CH340) | Doku + Firmware-Tools | USB→COM (CH340), Protokoll: `FF 01 00` = an, `FF 01 01` = aus (Kanal 1) |
| [`Lichtquelle-GZDP-A00/`](./Lichtquelle-GZDP-A00) | GZDP-A00 4-Kanal-Lichtquellensteuerung | Hersteller-Software | siehe README im Ordner |
| [`../SUNIX/`](../SUNIX) | SUNIX SDC0880I Digital-I/O-Karte | Treiber + Tester | `sdciodll.dll`, verifizierte API, lauffähiger DI-Tester |

**Große Dateien** (SDK-Installer, ~1,4 GB) liegen **nicht** im Repo, sondern in
`Z:\GZVision\_LargeFiles_Upload\` und werden von dort separat hochgeladen /
auf dem Ziel-PC installiert. Details: [`LARGE_FILES.md`](./LARGE_FILES.md).

## Für KI-Assistenten (Cline etc.)

- [`AGENTS.md`](./AGENTS.md) – Hardware-Fakten, Schnittstellen, Regeln für die
  Zusammenarbeit (auch automatisch von Cline/Cursor/Copilot erkannt).

## Verwandte Projekte im Repo

- [`SUNIX/`](../SUNIX) – Digital-I/O-Karte mit verifizierter DLL-API und
  DI-Tester (Python/C++/VB.NET) – Baustein für die Kopplung an die Anlage.

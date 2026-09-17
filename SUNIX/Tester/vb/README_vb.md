# DI-Tester (VB.NET / WinForms) - README

WinForms-Testprogramm für die 8 digitalen Eingänge der SUNIX SDC4880B /
SDC0880I. 8 kreisförmige Anzeigen **DI1..DI8**: grün = vom Treiber als
aktiv/1 gemeldet, grau = inaktiv. Polling alle 250 ms.

## Dateien

| Datei | Zweck |
|---|---|
| `SdcIoClient.vb` | Abstraktionsschicht: `DllImport` + Try/Catch gegen `DllNotFoundException`/`EntryPointNotFoundException`/`BadImageFormatException`, Mock-Fallback |
| `Form1.vb` | UI-Logik: Timer, Farben, Kreisform, Statuszeile |
| `Form1.Designer.vb` | Designer-Teil: 8 Panels (DI1..DI8), Kopf- und Statuszeile |
| `Program.vb` | Eigener Einstiegspunkt inkl. Argument-Parsing und `--selftest` |
| `DI_Tester.vbproj` | SDK-Style-Projekt, `x64`, `net8.0-windows` |

## Bauen

```bat
cd /d Z:\Codes\My Projects\DDL\SUNIX\Tester\vb
dotnet build -c Release
```

Ergebnis: `vb\bin\Release\DI_Tester.exe` (plus `DI_Tester.dll` und
`DI_Tester.runtimeconfig.json` - daher den **kompletten** Ordner kopieren).

Alternativ mit Visual Studio: Projekt öffnen und im **Release**-Modus bauen
(Konfiguration `x64`, nicht `Any CPU`).

Voraussetzung auf dem Ziel-PC: **.NET 8 Desktop Runtime**.

## Starten

```bat
DI_Tester.exe                    :: Auto: echte DLL wenn vorhanden, sonst Mock
DI_Tester.exe --mock             :: Mock-Modus erzwingen
DI_Tester.exe --board-id 1       :: Mehrkarten-Systeme (Board-ID)
DI_Tester.exe --dll C:\...\sdciodll.dll
DI_Tester.exe --selftest 3       :: headless Selbsttest (Ergebnis-Datei siehe unten)
```

`--selftest` schreibt das Protokoll nach
`%TEMP%\di_tester_vb_selftest.txt` (eine WinExe hat kein Konsolenfenster).
Dialog schließen mit **Esc** oder Fensterschließen-Button.

## Mock-Modus vs. echte Hardware

- **Mock:** Kopfzeile gelb: `MOCK - keine Karte erkannt`; die Anzeige läuft
  als wanderndes Muster (ein Kanal aktiv, DI1 -> DI8 -> DI1).
- **Echt:** Kopfzeile grün: `echte Hardware (Board-ID N)`; Statuszeile zeigt
  DLL-Pfad und DI-Funktionsnamen.

Die Suche der DLL erfolgt über den Standardweg von .NET (Programmordner,
`PATH`) bzw. über den per `--dll` gesetzten Pfad (dann wird ein
`DllImportResolver` installiert, siehe `SdcIoClient.vb`).

Ob "aktiv" elektrisch High oder Low bedeutet, wird **nicht** hier ausgewertet -
das stellt man im SDC Manager über die Invert-Option ein.

## Noch zu verifizieren (TODO) - sobald Karte/SDK real vorhanden ist

1. **Name der DI-Lesefunktion:** `_sdc_get_di_value` in `SdcIoClient.vb` ist
   **UNBESTÄTIGT** (aus dem Handbuch bestätigt sind nur `_sdc_dll_init`,
   `_sdc_dll_free`, `_sdc_get_service_info`, `_sdc_get_sdc_info`).
   Prüfen mit `sdciodll.h` bzw. `dumpbin /exports sdciodll.dll`.
2. **Signaturen:** Annahme `int f(unsigned int boardId, unsigned int* pValue)`
   sowie `int _sdc_dll_init(void)` / `int _sdc_dll_free(void)`, Aufruf-
   konvention `__cdecl`, Rückgabe `0` = Erfolg. Die Exporte werden vor dem
   ersten Aufruf per `NativeLibrary.TryGetExport` geprüft (ohne Aufruf), damit
   ein falscher Name nicht abstürzen kann - eine falsche **Signatur** kann
   das aber trotzdem.
3. **Bit-Zuordnung:** Annahme `DI1 = Bit 0` (TODO-Kommentar im Code).
4. **Bitness:** Projekt ist auf `x64` festgelegt und muss zur `sdciodll.dll`
   passen.

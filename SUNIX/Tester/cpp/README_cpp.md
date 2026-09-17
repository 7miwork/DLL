# DI-Tester (C++) - README

Konsolen-Testprogramm für die 8 digitalen Eingänge der SUNIX SDC0880I /
SDC4880B. Zeigt DI1..DI8 als farbige Blöcke an (grün = vom Treiber als
aktiv/1 gemeldet, grau = inaktiv), Polling alle 250 ms.

> **Build-Status auf dieser Entwicklungsmaschine:** Das installierte
> Visual Studio 18 Community enthält **keine C++-Workload** (kein `cl.exe`)
> und es ist kein MinGW/Clang vorhanden – die EXE wurde hier daher **nicht
> kompiliert**. Auf dem Ziel-PC genügt die "Developer Command Prompt for VS"
> (mit C++-Workload) und `build.bat`. Der Quellcode nutzt nur die
> verifizierten DLL-Exporte (`Lib_init`, `SDC_enumerate_dio_info`,
> `SDC_dio_open`, `SDC_get_di_value`, …) und lädt die DLL zur Laufzeit.

## Dateien

| Datei | Zweck |
|---|---|
| `SdcIoClient.h` / `SdcIoClient.cpp` | Abstraktionsschicht um `sdciodll.dll`: dynamisches Laden per `LoadLibraryA`/`GetProcAddress`, Mock-Fallback |
| `main.cpp` | Konsolen-UI (Win32-Konsolenfarben), Argument-Parsing, Selbsttest |
| `build.bat` | Build mit `cl.exe` aus einer Developer Command Prompt |

## Bauen

Es wird **nicht** gegen `sdciodll.lib` gelinkt - die DLL wird zur Laufzeit
geladen. Deshalb ist **kein SUNIX-SDK zum Bauen nötig**.

```bat
rem 1. Developer Command Prompt for VS öffnen (x64!), dort:
cd /d Z:\Codes\My Projects\DDL\SUNIX\Tester\cpp
build.bat
```

Falls `cl.exe` nicht im PATH ist, vorher z. B.:
```bat
"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat"
```

Alternative (MinGW-w64 `g++`):
```bat
g++ -std=c++17 -O2 -o DI_Tester.exe main.cpp SdcIoClient.cpp -static
```

Ergebnis: `cpp\DI_Tester.exe`

## Starten

```bat
DI_Tester.exe                    :: Auto: echte DLL wenn vorhanden, sonst Mock
DI_Tester.exe --mock             :: Mock-Modus erzwingen (keine DLL wird geladen)
DI_Tester.exe --board-id 1       :: Mehrkarten-Systeme (Board-ID)
DI_Tester.exe --dll C:\...\sdciodll.dll
DI_Tester.exe --interval 250     :: Polling-Intervall in ms (Minimum 50)
DI_Tester.exe --selftest 3       :: headless Selbsttest, 3 Sekunden
```

Die DLL wird im Arbeitsverzeichnis, per `--dll` oder über die Umgebungsvariable
`SUNIX_DLL_PATH` gesucht. Ist sie nicht vorhanden, läuft das Programm im
**Mock-Modus** weiter (wanderndes Testmuster: ein Kanal aktiv, DI1 -> DI8 ->
DI1) - das ist auf Entwicklungsrechnern ohne Karte der erwartete Zustand.

## Mock-Modus vs. echte Hardware

- **Mock:** Titel/Status gelb: `MOCK - keine Karte erkannt`.
- **Echt:** Titel/Status grün: `echte Hardware (Board-ID N)` plus gefundener
  DLL-Pfad und DI-Funktionsname.

Ob "aktiv" elektrisch High oder Low bedeutet, wird **nicht** hier ausgewertet -
das stellt man im SDC Manager über die Invert-Option ein. Der Tester zeigt
genau das, was die API als `1` liefert.

## Noch zu verifizieren (TODO) - sobald Karte/SDK real vorhanden ist

1. **Name der DI-Lesefunktion.** Aus dem Handbuch bestätigt sind nur
   `_sdc_dll_init`, `_sdc_dll_free`, `_sdc_get_service_info`,
   `_sdc_get_sdc_info`. Der Name in `SdcIoClient.cpp`
   (`_sdc_get_di_value`, plus Kandidatenliste) ist **UNBESTÄTIGT** und wird
   nur verwendet, wenn der Export in der DLL tatsächlich existiert.
   Verifikation: `dumpbin /exports sdciodll.dll` (Developer Command Prompt)
   bzw. `sdciodll.h` aus dem SUNIX-SDK lesen.
2. **Signatur der DI-Lesefunktion** (Parameter, Zeiger/ByRef, Aufrufkonvention
   `__cdecl`/`__stdcall`, Rückgabecode). Aktuelle Annahme:
   `int f(unsigned int boardId, unsigned int* pValue)`, `0` = Erfolg.
   **Bis das verifiziert ist, kann ein Aufruf mit falscher Signatur die
   Anwendung zum Absturz bringen** - auf dem Ziel-PC daher zuerst mit
   `--mock` testen und die Signatur in `SdcIoClient.cpp` anpassen.
3. **Bit-Zuordnung:** Annahme `DI1 = Bit 0`. Ebenfalls in `SdcIoClient.cpp`
   mit TODO markiert.
4. **Bitness:** Prozess (x64) und `sdciodll.dll` müssen zusammenpassen.

# SUNIX DI-Tester (Python / C++ / VB.NET)

Einfaches **Testprogramm für die 8 Digital-Input-Kanäle** (DI1..DI8) der
SUNIX **SDC4880B / SDC0880I**. Zweck: prüfen, ob die Karte im Zielsystem
über `sdciodll.dll` überhaupt Daten liefert, und die Anzeige-/Polling-Logik
ohne Hardware testen können.

Dasselbe Programm gibt es **dreimal**, jeweils als eigenständig lauffähige
`.exe`:

| Variante | Ordner | Erzeugtes Programm |
|---|---|---|
| Python (Tkinter) | [`python/`](./python) | `python/dist/DI_Tester.exe` |
| C++ (Konsole) | [`cpp/`](./cpp) | `cpp/DI_Tester.exe` |
| VB.NET (WinForms) | [`vb/`](./vb) | `vb/bin/Release/DI_Tester.exe` |

## Was das Programm macht

- **8 Anzeigeelemente**, beschriftet **DI1..DI8** (Kreis/Panel/Balken).
- Ein Kanal wird **grün**, sobald die API für ihn "1" bzw. aktiv meldet -
  sonst grau/inaktiv. Aktualisierung per Polling alle **250 ms**.
- Statuszeile: zeigt, ob **Mock-Modus** (keine Karte erkannt) oder **echte
  Hardware** (Board-ID N) aktiv ist.
- Wechsel per Tastatur/Maus beenden: Python = Fenster schließen,
  C++ = `Strg+C`, VB.NET = `Esc` oder Fenster schließen.

**Wichtig:** Ob "aktiv" elektrisch High oder Low entspricht, wird **nicht**
hier ausgewertet. Das stellt man im **SDC Manager** über die Invert-Option
ein. Der Tester zeigt genau den Wert, den die API liefert - unabhängig von
der Spannungslogik.

## Architektur (für alle drei Sprachen identisch)

1. **Abstraktionsschicht** (`SdcIoClient`) mit `ReadDigitalInputs()` ->
   8 Bool-Werte. Keine DLL-Aufrufe im UI-Code (Vorgabe aus
   [`../AGENTS.md`](../AGENTS.md) und [`../.clinerules`](../.clinerules)).
2. **Dynamisches Laden der DLL** statt festem Linken:
   - Python: `ctypes.WinDLL(...)` in `try/except`
   - C++: `LoadLibraryA` / `GetProcAddress` (kein Linken gegen
     `sdciodll.lib` -> kein SUNIX-SDK zum Bauen nötig)
   - VB.NET: `DllImport` (bindet erst zur Laufzeit) + `Try/Catch` gegen
     `DllNotFoundException`, `EntryPointNotFoundException`,
     `BadImageFormatException`
3. **Mock-Fallback ist Pflicht:** fehlt die DLL (typisch auf
   Entwicklungsrechnern ohne Treiber), läuft das Programm weiter und zeigt
   ein wanderndes Testmuster - ein Kanal aktiv, **DI1 -> DI8 -> DI1**.
   Kein Absturz, kein Hängen.

## Bauen und Starten

Kurzfassung (Details jeweils im Unterordner-README):

```bat
rem Python: Skript direkt starten
cd python
python di_tester_gui.py
rem .exe bauen:
powershell -ExecutionPolicy Bypass -File build_exe.ps1
rem -> python\dist\DI_Tester.exe

rem C++ (Developer Command Prompt for VS, x64):
cd ..\cpp
build.bat
rem -> cpp\DI_Tester.exe

rem VB.NET:
cd ..\vb
dotnet build -c Release
rem -> vb\bin\Release\DI_Tester.exe
```

Gemeinsame Kommandozeilenoptionen aller drei Varianten:

```
--mock               Mock-Modus erzwingen (keine DLL wird geladen)
--board-id N         Board-ID für Mehrkarten-Systeme (Default 0)
--selftest [SEK]     headless Selbsttest (Default 2 s), Ergebnis im Protokoll
```

Die DLL wird im Programmordner, per `--dll PFAD` bzw. (Python/C++) über die
Umgebungsvariable `SUNIX_DLL_PATH` gesucht. Auf dem Ziel-PC `sdciodll.dll`
einfach neben die `.exe` legen.

### Selbsttest-Protokolle

Da die `.exe`-Varianten teilweise kein Konsolenfenster haben, schreiben die
Selbsttests eine Protokolldatei:

| Variante | Protokoll |
|---|---|
| Python | `%TEMP%\di_tester_py_selftest.txt` |
| C++ | Standardausgabe (Konsole) |
| VB.NET | `%TEMP%\di_tester_vb_selftest.txt` |

## Verifizierte DLL-API (nicht mehr geraten!)

Die API ist inzwischen **vollständig verifiziert** – beide Quellen liegen im
Repo unter [`../../Driver/`](../../Driver):

1. **`sdciodll.h`** aus `Windows SDC API V1.0.6.0_20260617.zip` (Ordner `DLL/`).
2. **Exportliste der `sdciodll.dll`** (x86 und x64 identisch, 39 Exporte,
   ausgelesen mit `dumpbin /exports`). Wichtigste Exporte:

   ```
   Lib_init, Lib_free, Get_library_info
   SDC_enumerate_dio_info, SDC_dio_open, SDC_dio_close
   SDC_get_di_value, SDC_get_all_di_info, SDC_get_di_info
   SDC_set_di_invert, SDC_set_di_filter_value, SDC_set_di_counter,
   SDC_set_di_event_mode, SDC_set_di_latch_reset
   SDC_get_do_value, SDC_set_do_value, SDC_set_do_init_value
   Register_DI_Event_callback
   Can_*  (CAN-Bus-Funktionen, hier nicht relevant)
   ```

   Hinweis: Die im älteren Handbuch genannten Namen (`_sdc_dll_init` usw.)
   existieren in dieser DLL-Version **nicht** – der Tester nutzt ausschließlich
   die oben gezeigten, echten Exporte.

3. **Verwendeter Aufrufablauf** (in allen drei Sprachen identisch):
   1. `Lib_init()` – Bibliothek initialisieren
   2. `SDC_enumerate_dio_info(&list)` – Karten auflisten
      (`uint32 DioAmount` + je Karte `{int32 DioIndex; int32 Version;
      int32 PciNumber}`, 12 Byte/Eintrag)
   3. `SDC_dio_open(DioIndex)` – Karte öffnen
   4. pro Kanal: `SDC_get_di_value(DioIndex, Port, &value)` – Wert lesen
   5. beim Beenden: `SDC_dio_close(DioIndex)` + `Lib_free()`

   Alle Funktionen sind `__cdecl`, Rückgabe `0` = `STATUS_SUCCESS`.

4. **Bereits gegen die echte DLL getestet:** Die x64-`sdciodll.dll` aus dem
   API-Paket wurde dynamisch geladen; `Lib_init` und die Enumeration liefen
   durch, `SDC_dio_open` lieferte ohne eingebaute Karte Fehlercode `-9` –
   der Tester fiel sauber in den Mock-Modus (kein Absturz). Damit ist die
   Aufrufkette real validiert; nur die Werte selbst brauchen die Hardware.

### Port-Nummerierung (DI1 = Port 0 oder 1?)

Die API adressiert Kanäle über eine Port-Nummer. Der Tester nimmt standardmäßig
**DI1 = Port 0** (…DI8 = Port 7) an. Falls die Karte die Kanäle als 1..8
adressiert (nach dem ersten Hardware-Test im SDC Manager erkennbar), lässt sich
das ohne Codeänderung umschalten:

- Python/C++: Umgebungsvariable `SUNIX_DI_PORT_BASE=1`
- C++: zusätzlich Kommandozeilenoption `--port-base 1`
- VB.NET: Parameter `portBase` im `SdcIoClient`-Konstruktor

## Optionen (alle drei Varianten)

```
--mock               Mock-Modus erzwingen (keine DLL wird geladen)
--board-id N         Karte N bei Mehrkarten-Systemen (Default 0 = erste Karte)
--port-base N        DI-Port-Nummerierung, 0 (Default) oder 1 (nur C++)
--dll PFAD           Pfad zur sdciodll.dll (Python/C++ auch: SUNIX_DLL_PATH)
--interval MS        Polling-Intervall (nur C++, Default 250 ms)
--selftest [SEK]     headless Selbsttest (Default 2 s), Ergebnis im Protokoll
```

Die DLL wird im Programmordner, per `--dll PFAD` bzw. (Python/C++) über die
Umgebungsvariable `SUNIX_DLL_PATH` gesucht. Auf dem Ziel-PC die passende
`sdciodll.dll` (x64/x86 = Bitness der Anwendung) einfach neben die `.exe`
legen – sie ist im API-Paket unter
`SUNIX/Driver/…Windows_SDC_API_V1.0.6.0….zip` (Ordner `DLL/x64` bzw. `DLL/x86`)
enthalten.

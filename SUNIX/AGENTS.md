# AI-Projektkontext – SUNIX SDC I/O Control Board Integration

Diese Datei ist bewusst werkzeug-unabhängig geschrieben (funktioniert mit
Cline, GitHub Copilot, Cursor, Aider, ChatGPT, Claude in der IDE, etc.).
Viele Tools lesen automatisch eine Datei namens `AGENTS.md` (oder
`CONTEXT.md`) im Projekt-Root; bei Tools ohne Auto-Erkennung einfach den
Inhalt am Anfang eines neuen Chats einfügen oder als Datei mitschicken.

## 0. Repo-Struktur (wichtig für den Fundort dieser Datei)
Dieses Dokument liegt im Repository **https://github.com/7miwork/DLL** im
Ordner **`/SUNIX/`**. Das Repo ist so organisiert, dass **jedes Projekt einen
eigenen Top-Level-Ordner** bekommt (Konvention, gilt auch für zukünftige
Projekte, nicht nur SUNIX). Alle in diesem Dokument referenzierten
Geschwisterdateien liegen also ebenfalls unter `/SUNIX/`:

```
DLL/
├── README.md                          <- Repo-weite Konvention (alle Projekte)
└── SUNIX/
    ├── README.md                      <- Projekt-Index für SUNIX
    ├── AGENTS.md                      <- diese Datei
    ├── .clinerules                    <- Cline-spezifische Variante desselben Kontexts
    ├── SUNIX_DLL_Python.md
    ├── SUNIX_DLL_Cpp.md
    ├── SUNIX_DLL_VisualBasic.md
    ├── SUNIX_Installation_Kurzanleitung.md
    └── SUNIX_Install_Helper.ps1
```

Wenn eine KI mit Zugriff auf dieses Repo arbeitet (Clone/Checkout vorhanden):
Bitte **nicht raten**, ob eine Datei existiert – stattdessen den Ordner
`/SUNIX/` aus dem Repo direkt auflisten/lesen. Die eigentliche `sdciodll.h`
und `sdciodll.dll`/`.lib` sind **nicht** Teil dieses Repos (Hersteller-SDK,
urheberrechtlich beim Hersteller) – diese liegen nur lokal im
SUNIX-Treiberpaket auf dem jeweiligen Entwicklungs-/Zielrechner.

## 1. Projektüberblick
Ziel ist die Software-Integration einer **SUNIX PCI Express Industrial I/O
Control Board** (Modelle **SDC4880B** oder **SDC0880I**) in eigene
Anwendungen. Ansteuerung erfolgt entweder über das Herstellertool
**SDC Manager** (GUI) oder programmatisch über die Hersteller-DLL
**sdciodll.dll** (per DLL-Import/Interop aus C/C++, VB.NET, C# oder
Python/ctypes).

Hardware-Eckdaten:
- SDC4880B: 4x RS-232/422/485 (16C950 UART, 50 bps–921.6 kbps) + 8x isolierter
  Digital Input + 8x isolierter Digital Output.
- SDC0880I: nur 8x isolierter Digital Input + 8x isolierter Digital Output.
- Digital Input: NPN & PNP, 32-Bit-Zähler pro Kanal, Trigger-Modi
  Rising/Falling/Both, Polling möglich.
- Digital Output: NPN, 3.5–40 VDC, 500 mA/Kanal, Initial-Value-Schutz bei
  Boot/Restart.
- DB44-Terminalblock (DB44MDWB), Pinbelegung:
  - Digital Input: DI COM = Pin 1–2, DI GND = Pin 3–4, DI1–DI8 = Pin 5–12
  - Digital Output: DO PWR = Pin 14–15, DO GND = Pin 16–17, DO1–DO8 = Pin 18–25

## 2. Wichtigste Einschränkung: Kein direkter Hardwarezugriff auf dieser Maschine
Diese Entwicklungsumgebung hat **weder die physische Karte noch den
SUNIX-Treiber/die DLL installiert**. Der erzeugte Code muss trotzdem
kompilierbar/lauffähig sein und soll erst auf dem eigentlichen Ziel-PC
(Industrie-Rechner mit eingebauter Karte) gegen echte Hardware getestet
werden.

Daraus folgende Vorgaben für jede KI, die an diesem Projekt arbeitet:

1. **Abstraktionsschicht statt direkter DLL-Aufrufe im Fachcode.**
   Alle Aufrufe von `sdciodll.dll` hinter einem klar benannten Interface
   kapseln (z. B. `ISdcIoDevice`, `SdcIoClient`), niemals verstreut im
   Business-Code aufrufen.
2. **Mock-/Stub-Implementierung bereitstellen**, die ohne echte Hardware
   plausible Werte liefert (z. B. feste DI-Zustände, Erfolgscode `0`), damit
   UI und Logik lokal getestet werden können.
3. **Umschaltbar per Konfiguration/Flag**, z. B. `USE_REAL_HARDWARE`,
   Default `false` in der Entwicklungsumgebung.
4. Ein Fehler beim Laden der echten DLL (z. B. „DLL nicht gefunden“,
   `BadImageFormatException`, `OSError: [WinError 193]`) auf dieser Maschine
   ist **erwartet und kein Bug** – Ursache ist die fehlende Treiberinstallation
   bzw. eine Architektur-Fehlpassung (x86 vs. x64), nicht der Code selbst.

## 3. Regel: Keine Funktionssignaturen oder Installer-Parameter erfinden
Die DLL-API ist inzwischen **VERIFIZIERT** (Quellen: `sdciodll.h` und
Exportliste der `sdciodll.dll` x86/x64 aus dem API-Paket
`Driver/…Windows_SDC_API_V1.0.6.0….zip`):
- `Lib_init()`, `Lib_free()`, `Get_library_info()`
- `SDC_enumerate_dio_info(PSDC_DIO_BASIC_INFO_LIST)` – Karten auflisten
  (`uint32 DioAmount` + 256 x `{int32 DioIndex; int32 Version; int32 PciNumber}`,
  12 Byte/Eintrag)
- `SDC_dio_open(int DioIndex)`, `SDC_dio_close(int DioIndex)`
- `SDC_get_di_value(int DioIndex, int DiPortNumber, unsigned* value)`
- weitere: `SDC_get_all_di_info`, `SDC_get_di_info`, `SDC_set_di_invert`,
  `SDC_set_di_filter_value`, `SDC_set_di_event_mode`, `SDC_set_do_value`, ...
- alle `__cdecl`, Rückgabe `0` = `STATUS_SUCCESS`

**Wichtig:** Die im älteren Handbuch genannten Namen (`_sdc_dll_init()` usw.)
existieren in dieser DLL-Version **nicht** als Exporte – die alten
Grundgerüste in `SUNIX_DLL_*.md` sind diesbezüglich veraltet.

Weiter gilt:
- Bei abweichenden/anderen DLL-Versionen vorher die Exportliste per
  `dumpbin /exports sdciodll.dll` prüfen – nicht raten.
- Ebenso keine Silent-Install-Parameter für `Setup.exe` (InstallShield)
  erfinden – für dieses Paket sind keine Kommandozeilenschalter dokumentiert.

## 4. Vorhandene Referenzdateien in diesem Ordner (`/SUNIX/` im Repo)
- `SUNIX_DLL_Python.md` – Grundgerüst mit ctypes (nur die vier bestätigten
  Funktionen).
- `SUNIX_DLL_Cpp.md` – Grundgerüst als Visual-Studio-Konsolenprojekt.
- `SUNIX_DLL_VisualBasic.md` – Grundgerüst mit `DllImport` in VB.NET.
- `SUNIX_Installation_Kurzanleitung.md` – Installationsschritte inkl.
  Begriffe für die traditionell-chinesische Windows-Oberfläche.
- `SUNIX_Install_Helper.ps1` – PowerShell-Skript, das die Installation startet
  und danach per `Get-PnpDevice` prüft, ob Karte/COM-Ports korrekt erkannt
  wurden.
- `README.md` – kurzer Index dieses Projektordners.

## 5. Plattform-/Architektur-Hinweise (sprachübergreifend)
- Windows-only API (P/Invoke, ctypes.WinDLL) – auf Nicht-Windows-Umgebungen
  automatisch auf die Mock-Implementierung zurückfallen, nicht versuchen, die
  DLL zu laden.
- Bitness von Anwendung und DLL muss übereinstimmen (x86 mit x86, x64 mit
  x64); „Any CPU“/architekturunabhängige Builds vermeiden, wenn die DLL
  eingebunden wird.
- Bei Mehrkarten-Systemen wird vermutlich eine Board-ID/Index als Parameter
  benötigt (im SDC Manager sichtbar als „Board ID“) – auch das bitte anhand
  der echten Header-Datei verifizieren statt anzunehmen.

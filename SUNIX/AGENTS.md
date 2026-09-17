# AI-Projektkontext – SUNIX SDC I/O Control Board Integration

Diese Datei ist bewusst werkzeug-unabhängig geschrieben (funktioniert mit
Cline, GitHub Copilot, Cursor, Aider, ChatGPT, Claude in der IDE, etc.).
Viele Tools lesen automatisch eine Datei namens `AGENTS.md` (oder
`CONTEXT.md`) im Projekt-Root; bei Tools ohne Auto-Erkennung einfach den
Inhalt am Anfang eines neuen Chats einfügen oder als Datei mitschicken.

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
Aus der Handbuch-Dokumentation sind nur folgende DLL-Funktionen bestätigt:
- `_sdc_dll_init()`
- `_sdc_dll_free()`
- `_sdc_get_service_info()`
- `_sdc_get_sdc_info()`

Für alle weiteren Funktionen (insbesondere tatsächliches Lesen der Digital
Inputs bzw. Schreiben der Digital Outputs) gilt:
- Signaturen (Parameter, Rückgabetyp, Pointer/ByRef-Verhalten) sind **nicht**
  aus dem Handbuch bekannt, sondern stehen nur in der `sdciodll.h`, die Teil
  des SUNIX-SDK-Ordners im Treiberpaket ist.
- Nicht raten. Stattdessen im Repository nach `sdciodll.h` oder vorhandenen
  Beispielprojekten suchen; falls nicht vorhanden, Platzhalter klar als TODO
  markieren und beim Menschen nachfragen, bevor produktiv genutzt.
- Ebenso keine Silent-Install-Parameter für `Setup.exe` (InstallShield)
  erfinden – für dieses Paket sind keine Kommandozeilenschalter dokumentiert.

## 4. Bereits vorhandene Referenzdateien (falls im Repo abgelegt)
- `SUNIX_DLL_Python.md` – Grundgerüst mit ctypes (nur die vier bestätigten
  Funktionen).
- `SUNIX_DLL_Cpp.md` – Grundgerüst als Visual-Studio-Konsolenprojekt.
- `SUNIX_DLL_VisualBasic.md` – Grundgerüst mit `DllImport` in VB.NET.
- `SUNIX_Installation_Kurzanleitung.md` – Installationsschritte inkl.
  Begriffe für die traditionell-chinesische Windows-Oberfläche.

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

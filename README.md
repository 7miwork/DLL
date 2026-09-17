# DLL – Sammlung von DLL-/SDK-Integrationsprojekten

> **KI-Einstiegspunkt:** Vollständige Verzeichnisübersicht mit Zwecken und
> verifizierter API steht in [`INDEX.md`](./INDEX.md) – bitte zuerst dort
> nachschlagen.

Dieses Repository sammelt Dokumentation, Beispielcode und
KI-Assistenz-Kontextdateien für die Anbindung verschiedener Hersteller-DLLs
und -SDKs (z. B. Industrie-I/O-Karten, Kamera-SDKs, etc.) an eigene
Anwendungen.

## Struktur: Ein Ordner pro Projekt

Ab sofort bekommt **jedes Projekt einen eigenen Top-Level-Ordner**, benannt
nach Hersteller/Produkt (z. B. `SUNIX/`). Innerhalb eines Projektordners gilt
folgendes Grundschema (nicht jede Datei ist bei jedem Projekt zwingend
vorhanden – je nachdem, was das Projekt braucht):

```
<ProjektName>/
├── README.md                          # Kurzer Index: was ist das, was ist drin
├── AGENTS.md                          # Werkzeug-neutraler KI-Kontext
│                                       #   (Cursor, Copilot, Aider, ChatGPT, Claude, ...)
├── .clinerules                        # Cline-spezifische Variante desselben Kontexts
├── <ProjektName>_DLL_Python.md        # Beispielcode Python (ctypes)
├── <ProjektName>_DLL_Cpp.md           # Beispielcode C/C++
├── <ProjektName>_DLL_VisualBasic.md   # Beispielcode VB.NET
├── <ProjektName>_Installation_*.md    # Installationsanleitung(en), falls relevant
└── <ProjektName>_Install_Helper.ps1   # Optionales PowerShell-Hilfsskript
```

## Warum diese Struktur

- **AGENTS.md** ist der inzwischen von mehreren KI-Coding-Tools (Cursor,
  GitHub Copilot, Aider, Cline u. a.) automatisch erkannte Standardname für
  Projektkontext. Sie beschreibt Hardware/API-Hintergrund, bekannte
  Fakten vs. unbekannte/nicht zu erratende Details, und Regeln für die
  Zusammenarbeit (z. B. "keine Funktionssignaturen erfinden").
- **.clinerules** enthält denselben Kontext, aber in der Cline-eigenen
  Konvention – für Projekte, die primär mit Cline bearbeitet werden.
- Die **`*_DLL_<Sprache>.md`**-Dateien enthalten jeweils ein lauffähiges
  Grundgerüst in der jeweiligen Sprache, inkl. Hinweisen, was bestätigt
  dokumentiert ist und was (noch) nicht.
- Jedes Projekt ist **eigenständig lesbar**: Eine KI (oder ein Mensch), die
  nur den jeweiligen Projektordner öffnet, hat alles Nötige beisammen, ohne
  im ganzen Repo suchen zu müssen.

## Wichtiger Grundsatz für alle Projekte in diesem Repo

Die Hersteller-DLLs/-SDKs (`*.dll`, `*.lib`, `*.h`) selbst sind **nicht**
Teil dieses Repos (Urheberrecht beim jeweiligen Hersteller) – nur
Dokumentation, Beispielcode und KI-Kontext dazu. Wo Funktionssignaturen oder
Verhalten nicht aus offizieller Dokumentation bestätigt sind, wird das in den
jeweiligen Dateien explizit als "nicht raten, sondern verifizieren"
gekennzeichnet.

## Projektübersicht

| Ordner | Hersteller/Produkt | Beschreibung |
|---|---|---|
| [`SUNIX/`](./SUNIX) | SUNIX SDC4880B / SDC0880I | PCI Express Industrial I/O Control Board (Digital I/O + RS-232/422/485), Ansteuerung über `sdciodll.dll`; inkl. lauffähigem DI-Tester (Python/C++/VB.NET) unter [`SUNIX/Tester/`](./SUNIX/Tester) |
| [`GZVision/`](./GZVision) | GZVision-Anlage (SENTECH-Kamera, Sony XCL-5005CR, Opticon-Barcode, AOI-Lochdetektion, 30U/60U-Steuerung, LCUS-USB-Relais, GZDP-A00-Lichtquelle) | Treiber, Doku und Beispielcode aller Komponenten zur Systemkopplung (Connectors); KI-Kontext siehe [`GZVision/AGENTS.md`](./GZVision/AGENTS.md) |

Neue Projekte werden hier ergänzt, sobald ein neuer Ordner angelegt wird.

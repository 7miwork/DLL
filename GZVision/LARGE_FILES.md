# Große Dateien (nicht im Git-Repo!) – Komplette Dateiliste

> **Für KIs:** Diese Dateien sind nicht Teil des Repos. Die Installations-/Daten-
> ordner liegen lokal unter `Z:\GZVision\_LargeFiles_Upload\` und werden separat
> hochgeladen (Netzlaufwerk/Cloud). **In der Spalte „Upload-Link" werden die
> Links zum hochgeladenen Ablageort eingetragen** (Platzhalter: `__LINK__`).
> Keine dieser Dateien selbst im Code referenzieren – nur auf diese Datei verweisen.

Quellordner (lokal): `Z:\GZVision\_LargeFiles_Upload\` · Gesamtgröße: **~1,38 GB**, 103 Dateien

## 1. `SentechSDKv1.2.2\` – SENTECH SDK (Kamera-Treiber) — 737,7 MB

| Datei | Größe | Upload-Link |
|---|---|---|
| `SentechSDKv1.2.2\SentechSDK(v1.2.2)\SentechSDKInstaller.exe` | 737,7 MB | `__LINK__` |

Installieren für: SENTECH USB3-Vision-Kamera (Treiber + Runtime). Danach
Python-Anbindung per `stapipy` (Wheel liegt im Repo unter `Sentech-Kamera/`).

## 2. `HIK VISION CCD Software\` – HIKVISION MVS — 617,5 MB

| Datei | Größe | Upload-Link |
|---|---|---|
| `HIK VISION CCD Software\MVS_Win_STD_4.6.3_260205.zip` | 307,6 MB | `__LINK__` |
| `HIK VISION CCD Software\MVS_Win_STD_4.6.3_260205\MVS_STD_4.6.3_260205.exe` | 309,9 MB | `__LINK__` |

Installieren für: HIKVISION CCD-Kamera-Software (MVS, Windows Standard).

## 3. `ASE-Tuning-Daten\` – ASE-Kalibrier-/Tuning-Daten — ~2 MB, 34 Dateien

Messwerte-/Bilddateien der ASE-Tuning-Läufe (Maschine 2490, Modul ER4053500401 /
PG3P880001.MRG / „Tuning complete", Gerät 35VSE1B014). Je Messung ein Paar
`.txt` (Messwerte) + `.jpg` (Bild). Referenz für die AOI-/Locherkennung.

| Datei (Unterordner `ASE-Tuning-Daten\`) | Größe | Upload-Link |
|---|---|---|
| `2490\ER4053500401\` – 9 Messpaare (.txt/.jpg), z. B. `Null#ER4053500401#A12345#20260901163728.txt` | je ~0,1 MB | `__LINK__` |
| `2490\PG3P880001.MRG\` – 6 Messpaare (.txt/.jpg), z. B. `Null#PG3P880001.MRG#Null#20260901162041.jpg` | je ~0,1 MB | `__LINK__` |
| `2490\Tuning complete\` – 3 Messpaare (.txt/.jpg), z. B. `Null#Tuning complete#Null#20260901144859.jpg` | je ~0,1 MB | `__LINK__` |
| `35VSE1B014\Null#6-35VSE1-014-004#Null#20260901170222.txt` + `.jpg` | ~0,1 MB | `__LINK__` |

*(Vollständige Einzeldateinamen per `Get-ChildItem -Recurse` im Quellordner;
die Namen enthalten `#`-trennte Muster: Seriennummer/Status/Zeitstempel.)*

## 4. `LCUS_Tools\` – LCUS-Relais: Flash-/Treiber-Tools — ~7 MB, 64 Dateien

| Datei (Unterordner `LCUS_Tools\`) | Größe | Upload-Link |
|---|---|---|
| `CH341SER.EXE` | 0,2 MB | `__LINK__` |
| `stc-isp-15xx-v6.19.exe` | 0,6 MB | `__LINK__` |
| `stc-isp-v4.80-not-setup.EXE` | 3,2 MB | `__LINK__` |
| `stc-isp-v4.80-not-setup\` – VB6-Runtime-DLLs/OCXe + `STC_ISP_V480.exe` (u. a. `msvbvm60.dll`, `MSCOMCTL.OCX`, `MSCOMM32.OCX`, `MSJET35.DLL`) | ~7 MB | `__LINK__` |
| `stc-isp-v4.80-not-setup\test-hex\` – STC-Demo-Firmware (`.bin/.hex/.rom`) | ~1 MB | `__LINK__` |

Installieren für: `CH341SER.EXE` = USB-Seriell-Treiber (CH340) der LCUS-Relaiskarte;
`stc-isp-*` = STC-Flash-Tools (nur nötig, wenn die Relais-Firmware neu geflasht wird).

## Vorgehen auf dem Ziel-PC

1. Ordner `_LargeFiles_Upload` von der Upload-Stelle (Links oben) auf den
   Ziel-PC kopieren bzw. die Installer direkt von dort ausführen.
2. `SentechSDKInstaller.exe` installieren (SENTECH-Kamera).
3. `MVS_STD_4.6.3_260205.exe` installieren (HIKVISION).
4. `LCUS_Tools\CH341SER.EXE` installieren (Relais-USB-Treiber).
5. Danach reicht das Git-Repo – alle Quellcodes/Docs sind dort enthalten.

## Pflege

- Nach dem Hochladen: **Upload-Links in die `__LINK__`-Platzhalter eintragen**
  und diese Datei committen – dann weiß jede KI (und jeder Mensch), wo die
  Dateien liegen.
- Neue große Dateien (> ~5 MB) gehören **nicht** ins Git, sondern hierher
  (Ordner + Tabellenzeile ergänzen).


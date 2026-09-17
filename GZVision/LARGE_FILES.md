# Große Dateien (nicht im Git-Repo!) – Komplette Dateiliste

> **Für KIs:** Diese Dateien sind nicht Teil des Repos. Sie liegen lokal unter
> `Z:\GZVision\_LargeFiles_Upload\` und werden separat hochgeladen. Die
> Upload-Links stehen in der Link-Liste unten (Platzhalter `LINK:` = noch leer).
> Im Code nur auf diese Datei verweisen, nie auf die Binärdateien selbst.

Quellordner (lokal): `Z:\GZVision\_LargeFiles_Upload\` · Gesamt: **~1,38 GB**, 103 Dateien

## 📋 Link-Liste — HIER die URLs einfügen (nach `LINK:` einfügen, fertig)

```text
L01  SENTECH SDK Installer                (737,7 MB)
     LINK:
     https://

L02  HIKVISION MVS 4.6.3 – ZIP            (307,6 MB)
     LINK:
     https://

L03  HIKVISION MVS 4.6.3 – Setup-EXE      (309,9 MB)
     LINK:
     https://

L04  ASE-Tuning-Daten  2490\ER4053500401  (18 Dateien, ~2 MB)
     LINK:
     https://

L05  ASE-Tuning-Daten  2490\PG3P880001.MRG (12 Dateien)
     LINK:
     https://

L06  ASE-Tuning-Daten  2490\Tuning complete (6 Dateien)
     LINK:
     https://

L07  ASE-Tuning-Daten  35VSE1B014         (2 Dateien)
     LINK:
     https://

L08  LCUS  CH341SER.EXE (USB-Treiber)     (0,2 MB)
     LINK:
     https://

L09  LCUS  stc-isp-15xx-v6.19.exe         (0,6 MB)
     LINK:
     https://

L10  LCUS  stc-isp-v4.80 (Tool + Runtime) (~7 MB, Ordner)
     LINK:
     https://

L11  LCUS  stc-isp test-hex (Demo-FW)     (~1 MB, Ordner)
     LINK:
     https://
```

*Regel: einfach die URL auf die `https://`-Zeile schreiben (oder die Zeile
`LINK:` ersetzen). Alles unterhalb ist nur noch Erklärung – muss beim
Einfügen nicht angefasst werden.*

## Details zu den Einträgen

### L01 – `SentechSDKv1.2.2\` – SENTECH SDK (Kamera-Treiber) — 737,7 MB

`SentechSDKv1.2.2\SentechSDK(v1.2.2)\SentechSDKInstaller.exe`
Installieren für: SENTECH USB3-Vision-Kamera (Treiber + Runtime). Danach
Python-Anbindung per `stapipy` (Wheel liegt im Repo unter `Sentech-Kamera/`).

### L02 / L03 – `HIK VISION CCD Software\` – HIKVISION MVS — 617,5 MB

- `MVS_Win_STD_4.6.3_260205.zip` (Original-ZIP, L02)
- `MVS_Win_STD_4.6.3_260205\MVS_STD_4.6.3_260205.exe` (entpacktes Setup, L03)

Installieren für: HIKVISION CCD-Kamera-Software (MVS, Windows Standard).

### L04–L07 – `ASE-Tuning-Daten\` – ASE-Kalibrier-/Tuning-Daten — ~2 MB, 34 Dateien

Messwerte-/Bilddateien der ASE-Tuning-Läufe (Maschine 2490, Gerät 35VSE1B014).
Je Messung ein Paar `.txt` (Messwerte) + `.jpg` (Bild); Namensmuster
`Null#<Seriennummer/Status>#<Status>#<Zeitstempel>`. Referenz für die
AOI-/Locherkennung.

| ID | Unterordner | Inhalt |
|---|---|---|
| L04 | `2490\ER4053500401\` | 9 Messpaare, z. B. `Null#ER4053500401#A12345#20260901163728.txt` |
| L05 | `2490\PG3P880001.MRG\` | 6 Messpaare, z. B. `Null#PG3P880001.MRG#Null#20260901162041.jpg` |
| L06 | `2490\Tuning complete\` | 3 Messpaare, z. B. `Null#Tuning complete#Null#20260901144859.jpg` |
| L07 | `35VSE1B014\` | 1 Messpaar `Null#6-35VSE1-014-004#Null#20260901170222.txt` + `.jpg` |

### L08–L11 – `LCUS_Tools\` – LCUS-Relais: Flash-/Treiber-Tools — ~7 MB, 64 Dateien

| ID | Datei/Ordner | Größe | Zweck |
|---|---|---|---|
| L08 | `CH341SER.EXE` | 0,2 MB | USB-Seriell-Treiber (CH340) der Relaiskarte – **pflicht** |
| L09 | `stc-isp-15xx-v6.19.exe` | 0,6 MB | STC-Flash-Tool V6.19 |
| L10 | `stc-isp-v4.80-not-setup\` | ~7 MB | STC-ISP V4.80 + `STC_ISP_V480.exe` + VB6-Runtime-DLLs/OCXe (`msvbvm60.dll`, `MSCOMCTL.OCX`, `MSCOMM32.OCX`, …) |
| L11 | `stc-isp-v4.80-not-setup\test-hex\` | ~1 MB | STC-Demo-Firmwares (`.bin/.hex/.rom`) |

L09–L11 nur nötig, wenn die Relais-Firmware neu geflasht wird.

## Vorgehen auf dem Ziel-PC

1. Ordner `_LargeFiles_Upload` von der Upload-Stelle (Links oben) auf den
   Ziel-PC kopieren bzw. die Installer direkt von dort ausführen.
2. `SentechSDKInstaller.exe` installieren (SENTECH-Kamera).
3. `MVS_STD_4.6.3_260205.exe` installieren (HIKVISION).
4. `LCUS_Tools\CH341SER.EXE` installieren (Relais-USB-Treiber).
5. Danach reicht das Git-Repo – alle Quellcodes/Docs sind dort enthalten.

## Pflege

- Nach dem Hochladen: **URLs in die Link-Liste oben eintragen** (auf die
  `https://`-Zeile nach dem jeweiligen `LINK:`) und diese Datei committen –
  dann weiß jede KI (und jeder Mensch), wo die Dateien liegen.
- Neue große Dateien (> ~5 MB) gehören **nicht** ins Git, sondern in
  `_LargeFiles_Upload` – dann hier eine neue ID (L12, L13, …) ergänzen.


# Große Dateien (nicht im Git-Repo!)

Alle Installer/SDKs, die zu groß für GitHub sind, liegen lokal in:

```
Z:\GZVision\_LargeFiles_Upload\
```

Diese Dateien werden **separat** hochgeladen (z. B. Netzlaufwerk/Cloud) und
auf dem Ziel-PC installiert. Im Repo wird nur hierauf verwiesen.

| Ordner/Datei | Inhalt | Größe |
|---|---|---|
| `SentechSDKv1.2.2\` | SENTECH SDK-Installer (inkl. Treiber für USB3-Vision-Kamera) | ~738 MB |
| `HIK VISION CCD Software\` | HIKVISION CCD-Software-Setup | ~617 MB |
| `ASE-Tuning-Daten\` | ASE-Kalibrier-/Tuning-Daten (2490, 35VSE1B014) | binär |
| `LCUS_Tools\` | LCUS-Relais: STC-ISP Flash-Tools (V4.80, V6.19), CH340-USB-Treiber `CH341SER.EXE` | ~7 MB |

## Vorgehen auf dem Ziel-PC

1. Ordner `_LargeFiles_Upload` von der Upload-Stelle auf den Ziel-PC kopieren.
2. `SentechSDKv1.2.2` installieren (Kamera-Treiber + Runtime).
3. `HIK VISION CCD Software` installieren.
4. `LCUS_Tools\CH341SER.EXE` installieren (Relais-USB-Treiber).
5. Danach reicht das Git-Repo – alle Quellcodes/Docs sind dort enthalten.

# SUNIX PCI Express Industrial I/O Control Board – Kurzanleitung

Gilt für: **SDC4880B** (Serial + Digital I/O) und **SDC0880I** (nur Digital I/O)

## 1. Karte einbauen
1. PC ausschalten, Netzstecker ziehen.
2. Gehäuse öffnen, Karte in einen freien PCIe-Steckplatz stecken, verschrauben.
3. Gehäuse schließen, Strom wieder anschließen, PC starten.

## 2. Treiber installieren
1. ZIP-Datei des Treibers entpacken.
2. `Setup.exe` per Rechtsklick → **Als Administrator ausführen**.
3. Im Sprachfenster **Chinese (Traditional)** oder **English (United States)** wählen (beide funktionieren gleich, nur die Anzeige der Installer-Texte ändert sich).
4. Auf **Next → Install → Finish** klicken.
5. Treiber wird automatisch installiert (SUNIX Industrial I/O Control Board + COM-Ports).

## 3. Installation prüfen (Geräte-Manager)
Öffnen über: **Systemsteuerung → Geräte-Manager**
(繁體中文: **控制台 → 裝置管理員**)

Gesucht wird:
| Englisch | 繁體中文 (Traditional Chinese UI) |
|---|---|
| Multifunction adapters → SUNIX Industrial I/O Control Board | 多功能介面卡 → SUNIX Industrial I/O Control Board |
| Ports (COM & LPT) → SUNIX COM Port (COMx) | 連接埠 (COM 和 LPT) → SUNIX COM Port (COMx) |

Wenn beide Einträge ohne gelbes Warndreieck erscheinen, ist die Installation erfolgreich.

## 4. I/O Control Manager (Software) nutzen
- Über Startmenü öffnen: **SDC Manager**.
- Links Board wählen (z. B. SDC4880B) → **Digital Input** / **Digital Output** / **COMx** konfigurieren.
- Nach Änderungen immer **Apply** klicken.

## 5. Verkabelung (DB44 → Terminalblock, DB44MDWB)
- Digital Input: Pin 5–12 = DI1–DI8, Pin 1/2 = DI COM, Pin 3/4 = DI GND
- Digital Output: Pin 18–25 = DO1–DO8, Pin 14/15 = DO PWR, Pin 16/17 = DO GND
- Details siehe Pin-Zuordnungs-Tabelle im Handbuch (Kapitel 2.4).

## 6. Firmware-Update (optional)
1. Aktuelle Firmware-Datei von sunix.com laden.
2. Im SDC Manager: Board wählen → **Update Firmware → Browse → Apply**.
3. **Wichtig:** Nach Update den PC komplett ausschalten und neu einschalten (kein Neustart – "Restart" reicht nicht).

## Support
- E-Mail: info@sunix.com
- Web: http://www.sunix.com

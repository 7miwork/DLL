# Änderungen am Opticon Barcode Viewer

## Bildgeführter Auto Focus (Kalibrierung trifft den Barcode)

Der Auto-Focus-/Tuning-Durchlauf des Scanners optimiert bisher alles, was gerade im Sichtfeld steht - nicht zwangsläufig den Wafer-Barcode. Die Kalibrierung **Auto Focus → Auto Tuning** arbeitet deshalb jetzt bildgeführt:

1. Nach dem Auto-Focus-Schritt (weiterhin Best-Effort, zwei Sekunden Antwortfenster) wird ein CCD-Bild über die bereits geöffnete Verbindung aufgenommen.
2. Der Barcode in diesem Bild wird dekodiert und lokalisiert (zxing-cpp-Bibliothek, neu in `requirements.txt`). Anschließend wird der Dekodierbereich des Scanners über die dokumentierten `[DF8`-Randbefehle (Handbuch Abschnitt 8.10) genau auf diesen Barcode beschränkt.
3. Das DT1-Auto-Tuning kann danach nur noch *diesen* Barcode lesen und optimiert Belichtung/Verstärkung ausschließlich für ihn. Stimmt der beim Tuning gelesene Code nicht mit dem lokalisierten Barcode überein, bricht die Kalibrierung mit einer klaren Meldung ab, damit das Ziel neu positioniert werden kann.
4. Nach dem Tuning wird der Dekodierbereich zurückgesetzt und ein zweites CCD-Bild aufgenommen. Der Barcode wird erneut dekodiert und als „Barcode verified clear" mit Klarheitskennwert (Laplace-Varianz) bestätigt; das Prüfbild-ergebnis erscheint im Tuning-Ergebnisfeld.

Die Bereichsbeschränkung wird in jedem Fall wieder zurückgesetzt (nach dem Tuning, bei Abbruch und beim Stoppen), damit die Produktionsscans nie auf den Kalibrierbereich begrenzt bleiben. Scanner ohne `[DF8`-Unterstützung ignorieren die Beschränkung stumm, und ohne auffindbaren Barcode läuft das Tuning wie bisher über das gesamte Bild.

### Robuster bei schwierigen Barcodes

Damit die Kalibrierung auch mit Barcodes klappt, die beim ersten Versuch Probleme machen, arbeitet der Ablauf jetzt mehrstufig selbstheilend:

- **Locate:** bis zu 3 Aufnahmen werden versucht. Dekodiert wird mit mehreren Strategien (Rotation/Invertierung aktiviert, zweite Histogramm-Binarisierung, 2×-Upscaling für kleine Codes). Barcodes, die zum konfigurierten `wafer_id_pattern` passen, werden gegenüber größeren Fremd-Barcodes bevorzugt.
- **Dekodierbereich:** Das `[DF8`-Fenster ist jetzt mindestens ~35 % der Bildfläche groß (um den Barcode zentriert), damit ein Koordinatenversatz zwischen Kamerabild und Sensor den Barcode nicht aus dem Fenster schiebt.
- **Tuning (DT1):** Schlägt das Tuning fehl („Tuning failed"), wird die Bereichsbeschränkung entfernt und DT1 einmal über das gesamte Bild erneut versucht. Liest das Tuning einen anderen Code als den lokalisierten (Mismatch), wird einmal frisch lokalisiert und erneut getunt.
- **Verify:** Ist das Prüfbild unklar oder fehlt, wird es bis zu 2-mal erneut aufgenommen, bevor die Kalibrierung abgeschlossen wird.
- **Hängende Befehle:** Ein abgebrochener Tuning-/Bildwechsel setzt den Befehls-Puffer des seriellen Readers zurück (`clear_pending_command`), damit nachfolgende Barcode-Zeilen nicht mehr fälschlich als Befehlsantworten verschluckt werden.

Jede Phase hat eine begrenzte Anzahl an Versuchen, sodass ein einzelnes schlechtes Bild die Kalibrierung nicht mehr komplett scheitern lässt.

## Scan-Bild parallel zur Textdatei (Randfall behoben)

Nach jedem Scan wird die CCD-Aufnahme bereits parallel zur Textdatei gespeichert (gleicher Dateiname, Endung `.jpg`, gleicher Barcode-Ordner) - basierend auf dem Opticon-Referenzsample `scanner_pic` (C# ImageCapture) aus dem Kundenverzeichnis. Ein Randfall war dabei unbehoben: War die Tabellenzeile beim Bildeingang bereits verschwunden (z. B. weil während der 1-4 Sekunden Übertragung eine neue Session gestartet oder die Tabelle geleert wurde), wurde das JPEG verworfen, obwohl die Textdatei existierte.

`_on_image_ready` persistiert das JPEG jetzt **immer** auf Disk, bevor die Zeilensuche für die Thumbnail-Anzeige läuft. Ein neuer Regressionstest (`test_image_callback_saves_jpeg_even_when_row_is_gone`) stellt sicher, dass jeder Scan sein Bild behält.

## Scan-Bild: gesamter Scanbereich statt nur Viertel (behoben)

Der von den DE7-Befehlen verwendete Bildausschnitt (Crop) war bisher fest auf 640×480 eingestellt. Auf Engines der MDI-5250/5350-Familie mit 1280×800-Sensor (siehe `[DF8`-Bereich in §8.10 des Seriellen Handbuchs) entspricht das nur **dem oberen linken Viertel** des gesamten Scanbereichs - das gespeicherte Bild zeigte also nie den vollen Sichtbereich.

- `image_capture.py` sendet jetzt standardmäßig den **vollen Sensor** als Crop: links/oben 0, rechts 1279, unten 799, Subsampling 1/1, 8 bpp, JPEG-Qualität 75, Format JPEG, Modus ALL.
- Alle Werte sind konfigurierbar: `image_capture_width`, `image_capture_height`, `image_capture_subsample`, `image_capture_jpeg_quality` in `app_config.json` (bzw. `app_config.py`-Default). MDI-4x00/N210-Engines (752×480-Sensor) setzen `752`/`480`.
- Die DE7-Segmentcodierung wurde gegen das C#-Referenzsample `scanner_pic` verifiziert: Jeder Wert besteht aus dem Item (z. B. `Q2`) plus **vier** Ziffern-Gruppen (`Qc Qd Qe Qf`). Zwei daraus abgeleitete Test-Erwartungen sind korrigiert (JPEG-Qualität benötigt vier Ziffern, und das Verbund-Frame beginnt nur mit einem `[` nach ESC - das erste DE7-Segment trägt kein eigenes `[`).
- `autofocus.py` spiegelt die konfigurierte Sensorgröße (Standard 1280×800), damit die DF8-Dekodierbereich-Koordinaten exakt zur Aufnahme passen; die zugehörigen DF8-Tests verwenden die neue Geometrie.

Regressionstests: `test_build_capture_commands_full_frame_1280x800`, `..._backward_compatible_640x480`, `..._subsample_and_quality`, `test_df8_margin_frames_use_a_minimum_fraction_of_the_frame`, `test_margins_are_clamped_at_the_image_edges`.

## Auto Focus / CCD-Kalibrierung

Die kombinierte Aktion **Auto Focus → Auto Tuning** hing bisher an der Annahme, der Scanner beantworte den konfigurierbaren Auto-Focus-Befehl (`AF`) zuverlässig. Die Kommandoreferenz im Handbuch „MDI-5250/5350 Serial Interface Software Manual" enthält keinen Auto-Focus-Befehl, und unbestimmte Befehle bleiben laut Handbuch stumm (bei aktiviertem ACK/NAK-Modus antwortet der Scanner mit NAK, das der Leser filtert). Dadurch wartete die Kalibrierung 30 Sekunden auf eine Antwort, die nie kam, brach mit „Auto Focus timed out" ab und startete das eigentliche DT1-Auto-Tuning nie. Der einzelne Auto-Focus-Button blieb zusätzlich dauerhaft im Zustand „in progress".

Der Ablauf wurde daher umgebaut: Der Auto-Focus-Befehl wird weiterhin zuerst gesendet (Befehlskennung frei konfigurierbar), die Antwortwartezeit beträgt aber nur noch zwei Sekunden. Bestätigt der Scanner den Befehl, startet das DT1-Tuning sofort; lehnt der Scanner den Befehl ab oder antwortet nicht, startet das Auto-Tuning trotzdem und die Statusleiste erklärt den Ausgang („Keine Antwort auf den Auto-Focus-Befehl … - Auto-Tuning wird trotzdem gestartet"). Die Kalibrierung überwacht jetzt jede Phase separat (Auto Focus, Tuning), ein Timeout in der Tuning-Phase bricht mit klarer Meldung ab statt ewig zu hängen, und der Abschlussbericht unterscheidet „Auto Focus und Auto Tuning abgeschlossen" von „Auto Tuning abgeschlossen (keine Auto-Focus-Antwort)". Auch der einzelne Auto-Focus-Button gibt seine Sperranzeige automatisch frei, und „Tuning failed" beendet im reinen Tuning-Modus die Beschäftigungsanzeige zuverlässig.

## Duplikate

Wenn die Option **„Aufeinanderfolgende Duplikate ignorieren“** aktiviert ist, wird ein bereits erfasster Barcode vor dem Anlegen der Textdatei und vor der CCD-Bildaufnahme verworfen. Dadurch entstehen für ignorierte Wiederholungen weder zusätzliche Dateien noch zusätzliche Tabellenzeilen. Im Dauerbetrieb wird anschließend trotzdem der nächste Trigger ausgelöst. Eine Erfassung während einer offenen NG-Retry-Zeile bleibt erlaubt, weil sie die bestehende Retry-Zeile ersetzt.

## CCD-Bilder

Die CCD-Aufnahme läuft über die bereits geöffnete Barcode-COM-Verbindung. Der frühere parallele Zugriff über eine zweite Verbindung wurde entfernt, weil viele Scanner einen zweiten Zugriff auf denselben COM-Port nicht zuverlässig unterstützen. Nach einem erfolgreichen Bildtransfer wird die JPEG-Datei mit demselben Basisnamen wie die Barcode-Textdatei im gleichen Zielordner gespeichert. Die Tabelle zeigt eine 96-Pixel-Vorschau direkt in der Bildspalte; der vollständige Dateipfad ist als Tooltip verfügbar. Ein CCD-Fehler verwirft nicht den bereits gespeicherten Barcode.

Das Übertragungsprotokoll wurde anhand der Originalquellen implementiert: dem Handbuch „MDI-4x00 / N210 Image Capture Manual" (2. Ausgabe, 2022) und dem funktionierenden Opticon-Referenzmuster „scanner_pic" (C#-ImageCapture-Beispiel). Die Paketrahmen folgen jetzt exakt der Dokumentation: RecNo (2 Byte) und Length (4 Byte) werden big-endian gelesen, die gewichtete 16-Bit-Prüfsumme läuft nur über die Nutzdaten und wird ebenso big-endian übertragen. Jedes gültige Paket wird mit ACK (0x06) bestätigt, jedes beschädigte mit NAK (0x15) abgelehnt; die Kamera sendet das Paket daraufhin erneut (Stopp-und-Warten pro Datensatz, doppelte Datensätze nach verlorenem ACK werden ignoriert).

Die Bildeinstellungen werden als DE7-Konjunktionsrahmen gesendet (Zuschnitt 0/0/639/479, Subsampling 1/1, 8 Bit pro Pixel, JPEG-Qualität 75, Ausgabeformat JPEG, Übertragungsmodus ALL), danach folgt der separate Erfassungsrahmen DE8 Q0 („commands in conjunction", Aufnahme sofort ohne Trigger). Der Empfänger versteht zusätzlich den PART-Übertragungsmodus, den viele Scanner als Werksstandard nutzen: Paket 0 enthält die 256-Byte-Information, danach kommen die Bilddaten zeilenweise; die Vollständigkeit wird über Image Size, Total Transfer Count und Bildgeometrie aus der Information ermittelt. Ein roher BMP-Transport (Bittiefe 1/4/8/10 ohne Bitmap-Header) wird anhand der Information in ein JPEG umgewandelt, sodass immer eine JPEG-Datei gespeichert wird. Bei stiller Leitung bricht die Erfassung nach dem Ruhezeitfenster ab und sendet CAN (0x18), damit der Scanner zurück in den Decodiermodus kehrt; bei niedrigen Baudraten verlängert sich das Zeitlimit anhand der gemeldeten Bildgröße. Ein fehlgeschlagener CCD-Transfer zeigt eine Statusmeldung und macht den Scan nicht ungültig.

## Lizenzierte und portable Variante

Die vorhandene Build-Umschaltung bleibt erhalten. `build.py portable` erzeugt eine Variante ohne Lizenzprüfung, während `build.py licensed` eine passende `license.lock` mit dem SHA-256-Hardware-Fingerprint des Ziel-PCs verlangt. Der Hash wird weiterhin über Baseboard-Seriennummer, BIOS-Seriennummer, Prozessor-ID und System-UUID gebildet. Die Datei `build_installers.ps1` erzeugt nach dem PyInstaller-Build zusätzlich die beiden Inno-Setup-Dateien. Der lizenzierte Installer legt keine kundenspezifische Lizenzdatei fest in das Paket; sie wird nach dem Hash-Austausch neben die lizenzierte EXE kopiert.

## Windows-Build

Ein echter Windows-Build muss auf Windows ausgeführt werden, da PyInstaller betriebssystemspezifische Programme erzeugt. Benötigt werden Python, die Abhängigkeiten aus `requirements.txt` und Inno Setup 6.

```powershell
py -m pip install -r requirements.txt
.\build_installers.ps1 -Clean
```

Die Ergebnisse liegen anschließend in `dist\` und `installer\`. Die Testsuite wurde im isolierten Qt-Modus mit **65 bestandenen Tests** ausgeführt.

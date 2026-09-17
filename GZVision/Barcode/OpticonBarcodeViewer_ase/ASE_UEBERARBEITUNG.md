# ASE-Überarbeitung: Opticon Barcode Viewer

## Ziel der Überarbeitung

Die bestehende Anwendung wurde **ohne Funktionsstreichungen** für einen klareren, wartbareren Aufbau überarbeitet. Der Schwerpunkt liegt auf einer nachvollziehbaren Trennung von Benutzeroberfläche, Tabellenpräsentation und serieller Kommunikation. Bestehende Scan-, NG-, manuellen Eingabe-, Export-, Bildaufnahme-, Sprach- und Konfigurationsabläufe bleiben erhalten.

> Die Überarbeitung versteht „ASE“ als eine strukturierte, wartbare Anwendungsentwicklung: klar abgegrenzte Verantwortlichkeiten, keine unnötigen direkten Zugriffe auf interne Objekte und reproduzierbare Tests.

| Bereich | Überarbeitung | Nutzen |
|---|---|---|
| Scan-Tabelle | Neue Klasse `ScanTablePresenter` in `scan_table.py` | Alle Tabellenzeilen, NG-Markierungen, Auswahl- und Exportdaten werden zentral behandelt. |
| Hauptfenster | Wiederverwendbare Hilfsmethoden zum Ergänzen und Aktualisieren von Scan-Zeilen | Weniger duplizierter Code und übersichtlichere Scan-Abläufe. |
| Serielle Kommunikation | Öffentliche Methode `send_raw_command()` im `SerialReaderWorker` | Das Hauptfenster greift nicht mehr direkt auf den privaten seriellen Port zu; Schreibzugriffe bleiben im Worker-Thread. |
| Oberflächengestaltung | Erweiterte `theme.qss` und eindeutige UI-Objektnamen | Prozessschritte, Warnaktionen und Konfigurationsbereiche sind klarer unterscheidbar. |
| Testbarkeit | Projektbezogene Testpfade und eigene Tests für die Tabellenkomponente | Die Tests funktionieren unabhängig vom ursprünglichen Entwicklungsrechner. |

## Struktur nach der Überarbeitung

```text
OpticonBarcodeViewer/
├── main.py                   # Programmeinstieg
├── main_window.py            # Orchestrierung der UI- und Fachabläufe
├── scan_table.py             # Darstellung und Auslesen der Scan-Tabelle
├── serial_reader.py          # Nebenläufige serielle Kommunikation
├── models.py                 # Scan-Datenmodell
├── theme.qss                 # Zentrales Dark-Industrial-Design
├── tests/
│   ├── test_scan_table.py    # Tests der neuen Tabellenkomponente
│   ├── test_export.py        # Bereinigter GUI-Exporttest
│   └── ...                   # Bestehende Funktionsprüfungen
└── ASE_UEBERARBEITUNG.md     # Diese Dokumentation
```

## Erhaltene Funktionen

Die optische Überarbeitung und der Strukturumbau ändern weder die Fachlogik noch die Bedienabläufe. Insbesondere bleiben Scanner-Verbindung, einmaliger und kontinuierlicher Trigger, Stoppen, NG- und GOOD-Behandlung, manuelle Wafer-ID-Eingabe, Wiederholung, Duplikaterkennung, Bildaufnahme, Dateiablage, Zwischenablage, CSV/XLSX-Export, Mehrsprachigkeit und Konfiguration weiterhin verfügbar.

## Qualitätssicherung

Die vollständige Testsuite wurde im grafisch isolierten Qt-Modus ausgeführt. Das Ergebnis lautet **65 erfolgreich bestandene Tests**. Zusätzlich prüft `test_scan_table.py` nun das Einfügen, Aktualisieren, Hervorheben, Auswählen und Exportieren von Scan-Zeilen.

```bash
QT_QPA_PLATFORM=offscreen pytest -q
```

Für die normale Anwendung wird die im Projekt beschriebene Umgebung mit den Abhängigkeiten aus `requirements.txt` verwendet. Die grafische Umgebungsvariable wird nur für automatisierte Tests ohne sichtbaren Desktop benötigt.

## Hinweise für die Weiterentwicklung

Neue Regeln für sichtbare Tabellenzeilen gehören in `scan_table.py`. Neue Serialbefehle sollten über öffentliche Methoden des `SerialReaderWorker` angefordert werden, statt den Port aus `main_window.py` heraus direkt zu verwenden. Dadurch bleibt die vorhandene Trennung auch bei weiteren Funktionen nachvollziehbar.

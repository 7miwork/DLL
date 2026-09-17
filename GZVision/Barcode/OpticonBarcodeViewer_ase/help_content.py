"""Multi-language help/reference content for the Help dialog.

Structured as::

    HELP_CONTENT[lang][section_key] = {"title": ..., "body_html": ...}

Languages follow the same convention as ``i18n.py``: ``en``, ``de``,
``zh_Hant``. The body is **rich text / HTML** (rendered via QTextBrowser),
not raw Markdown.
"""

from typing import Dict

# Order in which the chapters should appear in the navigation list.
# Must be identical for every language so the left navigation stays in sync.
SECTION_ORDER = [
    "getting_started",
    "continuous_scan",
    "operator_validation",
    "trigger_retry_manual",
    "tuning",
    "builds",
    "troubleshooting",
    "about_support",
]

HELP_CONTENT: Dict[str, Dict[str, Dict[str, str]]] = {
    # ------------------------------------------------------------------
    # English
    # ------------------------------------------------------------------
    "en": {
        "getting_started": {
            "title": "Getting Started",
            "body_html": (
                "<h3>First steps</h3>"
                "<ol>"
                "<li>Pick the serial port of the scanner in the <b>COM Port</b> "
                "combo box at the top-left. Use the <b>Refresh</b> icon button "
                "next to it if your port is not listed.</li>"
                "<li>Choose the correct <b>Baud Rate</b> (default 115200). You can "
                "use <b>Auto Detect</b> to try common rates automatically.</li>"
                "<li>Press <b>Connect</b>. The status LED turns green and the "
                "connection buttons are enabled.</li>"
                "<li>Press <b>Trigger</b> to request a scan from the device, or "
                "use <b>Continuous Scan</b> to keep scanning continuously.</li>"
                "</ol>"
                "<p>Scanned barcodes appear in the table. You can select rows and "
                "use <b>Copy Selected</b> / <b>Copy All</b>, or <b>Clear</b> the "
                "list.</p>"
            ),
        },
        "continuous_scan": {
            "title": "Continuous Scan Mode",
            "body_html": (
                "<h3>Continuous Scan</h3>"
                "<p><b>Continuous Scan</b> keeps the scanner reading repeatedly "
                "until you stop it with <b>Stop</b>. While active, the button "
                "stays checked.</p>"
                "<ul>"
                "<li>Every scanned barcode is appended to the table.</li>"
                "<li>Use <b>Ignore consecutive dupes</b> to skip a barcode that "
                "equals the immediately previous one.</li>"
                "<li>You can toggle Continuous Scan from the <b>Menu</b> button "
                "as well.</li>"
                "</ul>"
                "<p>Press <b>Stop</b> (or <b>Trigger</b> for single reads) to "
                "return to manual scanning.</p>"
            ),
        },
        "operator_validation": {
            "title": "Operator ID & Validation",
            "body_html": (
                "<h3>Operator ID</h3>"
                "<p>Enter the operator / badge ID in the <b>Operator ID</b> field. "
                "It is written into the saved scan filename, so a meaningful ID is "
                "recommended.</p>"
                "<h3>Prefix / Suffix validation</h3>"
                "<p>In the Settings (<b>Settings &gt; Barcode validation</b>) "
                "you can define an <b>Expected Prefix</b> and <b>Expected Suffix</b>. "
                "Scans that do not match are marked <b>NG</b> instead of "
                "<b>GOOD</b>.</p>"
                "<p>The Wafer-ID folder logic expects exactly 4 dash-separated "
                "segments (e.g. <code>1-123CD4-001-001</code>). Non-standard "
                "Wafer-IDs are saved to the separate non-standard folder.</p>"
            ),
        },
        "trigger_retry_manual": {
            "title": "Trigger / Retry / Manual Entry",
            "body_html": (
                "<h3>Trigger cycle</h3>"
                "<p><b>Trigger</b> sends a request to the scanner. If no scan is "
                "received within the configured timeout, the app retries "
                "automatically (see <b>Settings &gt; Trigger &amp; sensor</b> for "
                "max attempts / retry delay).</p>"
                "<h3>Retry</h3>"
                "<p>If a read fails, <b>Retry Scan</b> re-sends the request "
                "manually.</p>"
                "<h3>Manual entry</h3>"
                "<p>After the retries are exhausted, a login dialog opens. "
                "Authenticate (default user <code>A12345</code>) and type the "
                "Wafer-ID manually. Operator ID and timestamp are stored in the "
                "filename as usual.</p>"
            ),
        },
        "tuning": {
            "title": "Tuning Tool (Banks)",
            "body_html": (
                "<h3>Connection to the tuning tool</h3>"
                "<p>The tuning tab in <b>Settings</b> talks to the reader via the "
                "same serial connection while it is open.</p>"
                "<ul>"
                "<li><b>Select Bank</b> – pick one of the 7 memory banks "
                "(01&ndash;07).</li>"
                "<li><b>Start/Stop Tuning</b> – run or stop a tuning sequence.</li>"
                "<li><b>Trigger in Bank</b> – fire the selected bank's trigger.</li>"
                "<li><b>Reset Bank / Reset All Banks</b> – restore factory "
                "defaults.</li>"
                "</ul>"
                "<p>The current selection is kept on the main window and shown in "
                "the status bar.</p>"
            ),
        },
        "builds": {
            "title": "Portable vs. Licensed Build",
            "body_html": (
                "<h3>Two build variants</h3>"
                "<p>The application is delivered in two versions:</p>"
                "<ul>"
                "<li><b>Portable</b> – runs on any PC, no hardware license "
                "check. It ignores any <code>license.lock</code> file.</li>"
                "<li><b>Licensed</b> – requires a valid <code>license.lock</code> "
                "next to the .exe. The lock binds the app to one PC via a "
                "hardware fingerprint (baseboard/BIOS/CPU/UUID).</li>"
                "</ul>"
                "<p>The build mode is baked in at build time by "
                "<code>build.py</code>; it cannot be changed at runtime.</p>"
            ),
        },
        "troubleshooting": {
            "title": "Troubleshooting",
            "body_html": (
                "<h3>No COM port is visible</h3>"
                "<ul>"
                "<li>Check the USB/serial cable and that the scanner is powered on.</li>"
                "<li>Press the <b>Refresh</b> button to re-enumerate ports.</li>"
                "<li>On Windows, verify the driver appears in Device Manager "
                "(Ports).</li>"
                "</ul>"
                "<h3>Wrong baud rate</h3>"
                "<p>Use <b>Auto Detect</b> or set the baud rate that matches the "
                "device configuration.</p>"
                "<h3>License error (Licensed build)</h3>"
                "<p>Place the correct <code>license.lock</code> next to the "
                "executable, or re-generate it on this PC with "
                "<code>generate_license_lock.py</code>.</p>"
                "<h3>Tuning does not respond</h3>"
                "<p>Make sure the reader is connected to the same COM port and "
                "that a bank is selected.</p>"
            ),
        },
        "about_support": {
            "title": "About & Support",
            "body_html": (
                "<h3>About</h3>"
                "<p>Opticon Barcode Viewer – a serial barcode scanning and "
                "management tool for the UV-300 reader (Wafer-ID storage).</p>"
                "<h3>Support contact</h3>"
                "<p>Please direct questions to your equipment vendor / optics "
                "support team. Include: which build (Portable/Licensed), the "
                "operating system, the COM port in use and a screenshot of the "
                "main window.</p>"
            ),
        },
        # __MORE_EN__
    },
    # ------------------------------------------------------------------
    # Deutsch
    # ------------------------------------------------------------------
    "de": {
        "getting_started": {
            "title": "Erste Schritte",
            "body_html": (
                "<h3>Erste Schritte</h3>"
                "<ol>"
                "<li>Wählen Sie den seriellen Port des Scanners im "
                "<b>COM-Port</b>-Feld oben links. Nutzen Sie den "
                "<b>Refresh</b>-Icon-Button daneben, wenn Ihr Port nicht "
                "angezeigt wird.</li>"
                "<li>Wählen Sie die richtige <b>Baudrate</b> (Standard 115200). "
                "Mit <b>Auto Erkennung</b> werden übliche Raten automatisch "
                "durchprobiert.</li>"
                "<li>Drücken Sie <b>Verbinden</b>. Die Status-LED wird grün und "
                "die Verbindungs-Buttons werden aktiviert.</li>"
                "<li>Drücken Sie <b>Trigger</b>, um einen Scan anzufordern, oder "
                "verwenden Sie <b>Kontinuierlicher Scan</b> für Dauerbetrieb.</li>"
                "</ol>"
                "<p>Gescannte Barcodes erscheinen in der Tabelle. Sie können "
                "Zeilen markieren und <b>Auswahl kopieren</b> / <b>Alle "
                "kopieren</b> nutzen oder die Liste mit <b>Leeren</b> "
                "zurücksetzen.</p>"
            ),
        },
        "continuous_scan": {
            "title": "Kontinuierlicher Scan",
            "body_html": (
                "<h3>Kontinuierlicher Scan</h3>"
                "<p><b>Kontinuierlicher Scan</b> liest wiederholt weiter, bis Sie "
                "mit <b>Stopp</b> anhalten. Solange der Modus aktiv ist, bleibt "
                "der Button aktiviert.</p>"
                "<ul>"
                "<li>Jeder Scan wird in die Tabelle eingetragen.</li>"
                "<li>Mit <b>Aufeinanderfolgende Duplikate ignorieren</b> wird ein "
                "Barcode übersprungen, der dem letzten gleicht.</li>"
                "<li>Der Modus kann auch über den <b>Menü</b>-Button umgeschaltet "
                "werden.</li>"
                "</ul>"
                "<p>Mit <b>Stopp</b> (oder <b>Trigger</b> für Einzelablesungen) "
                "kehren Sie zum manuellen Scannen zurück.</p>"
            ),
        },
        "operator_validation": {
            "title": "Operator-ID & Validierung",
            "body_html": (
                "<h3>Operator-ID</h3>"
                "<p>Tragen Sie die Operator-/Ausweis-ID im Feld "
                "<b>Operator-ID</b> ein. Sie wird in den gespeicherten "
                "Dateinamen geschrieben, daher ist eine aussagekräftige ID "
                "empfehlenswert.</p>"
                "<h3>Präfix-/Suffix-Validierung</h3>"
                "<p>Unter <b>Einstellungen &gt; Barcode-Validierung</b> können "
                "Sie ein <b>Erwartetes Präfix</b> und <b>Erwartetes Suffix</b> "
                "festlegen. Nicht passende Scans werden als <b>NG</b> statt "
                "<b>GOOD</b> markiert.</p>"
                "<p>Die Wafer-ID-Logik erwartet genau 4 durch <code>-</code> "
                "getrennte Segmente (z.&nbsp;B. <code>1-123CD4-001-001</code>). "
                "Nicht standardkonforme Wafer-IDs werden im separaten "
                "Nicht-Standard-Ordner gespeichert.</p>"
            ),
        },
        "trigger_retry_manual": {
            "title": "Trigger / Retry / Manuelle Eingabe",
            "body_html": (
                "<h3>Trigger-Zyklus</h3>"
                "<p><b>Trigger</b> sendet eine Anforderung an den Scanner. Wird "
                "innerhalb des konfigurierten Timeouts kein Scan empfangen, "
                "wiederholt die App automatisch (siehe <b>Einstellungen &gt; "
                "Trigger &amp; Sensor</b> für maximale Versuche / "
                "Wiederholungsverzögerung).</p>"
                "<h3>Retry</h3>"
                "<p>Bei einem fehlgeschlagenen Lesevorgang wiederholt "
                "<b>Erneut lesen</b> die Anforderung manuell.</p>"
                "<h3>Manuelle Eingabe</h3>"
                "<p>Nach aufgebrauchten Versuchen öffnet sich ein "
                "Anmeldedialog. Authentifizieren Sie sich (Standard-Benutzer "
                "<code>A12345</code>) und geben Sie die Wafer-ID manuell ein. "
                "Operator-ID und Zeitstempel werden wie üblich im Dateinamen "
                "abgelegt.</p>"
            ),
        },
        "tuning": {
            "title": "Tuning-Tool (Banks)",
            "body_html": (
                "<h3>Verbindung zum Tuning-Tool</h3>"
                "<p>Der Tuning-Tab in <b>Einstellungen</b> kommuniziert über "
                "dieselbe serielle Verbindung mit dem Lesegerät, solange diese "
                "geöffnet ist.</p>"
                "<ul>"
                "<li><b>Bank wählen</b> – eine der 7 Speicherbänke "
                "(01&ndash;07) auswählen.</li>"
                "<li><b>Start/Stopp Tuning</b> – Tuning-Sequenz starten oder "
                "stoppen.</li>"
                "<li><b>Trigger in Bank</b> – den Trigger der gewählten Bank "
                "auslösen.</li>"
                "<li><b>Bank zurücksetzen / Alle Bänke zurücksetzen</b> – "
                "Werkseinstellungen wiederherstellen.</li>"
                "</ul>"
                "<p>Die aktuelle Auswahl wird im Hauptfenster gehalten und in der "
                "Statusleiste angezeigt.</p>"
            ),
        },
        "builds": {
            "title": "Portable vs. Lizenziert",
            "body_html": (
                "<h3>Zwei Build-Varianten</h3>"
                "<p>Die Anwendung wird in zwei Versionen ausgeliefert:</p>"
                "<ul>"
                "<li><b>Portable</b> – läuft auf jedem PC, keine "
                "Hardware-Lizenzprüfung. Eine vorhandene "
                "<code>license.lock</code> wird ignoriert.</li>"
                "<li><b>Lizenziert</b> – erfordert eine gültige "
                "<code>license.lock</code> neben der EXE. Die Lizenz bindet die "
                "App über einen Hardware-Fingerprint "
                "(Mainboard/BIOS/CPU/UUID) an einen PC.</li>"
                "</ul>"
                "<p>Der Build-Modus wird zur Build-Zeit von "
                "<code>build.py</code> eingebacken; er kann zur Laufzeit nicht "
                "geändert werden.</p>"
            ),
        },
        "troubleshooting": {
            "title": "Fehlerbehebung",
            "body_html": (
                "<h3>Kein COM-Port sichtbar</h3>"
                "<ul>"
                "<li>Prüfen Sie USB-/serielles Kabel und dass der Scanner "
                "eingeschaltet ist.</li>"
                "<li>Drücken Sie den <b>Refresh</b>-Button, um Ports neu zu "
                "ermitteln.</li>"
                "<li>Unter Windows prüfen Sie den Treiber im Geräte-Manager "
                "(Anschlüsse).</li>"
                "</ul>"
                "<h3>Falsche Baudrate</h3>"
                "<p>Nutzen Sie <b>Auto Erkennung</b> oder stellen Sie die zum "
                "Gerät passende Baudrate ein.</p>"
                "<h3>Lizenzfehler (lizensierter Build)</h3>"
                "<p>Legen Sie die korrekte <code>license.lock</code> neben die "
                "EXE oder erzeugen Sie sie auf diesem PC mit "
                "<code>generate_license_lock.py</code> neu.</p>"
                "<h3>Tuning reagiert nicht</h3>"
                "<p>Stellen Sie sicher, dass das Lesegerät am selben COM-Port "
                "angeschlossen ist und eine Bank gewählt wurde.</p>"
            ),
        },
        "about_support": {
            "title": "Über & Support",
            "body_html": (
                "<h3>Über</h3>"
                "<p>Opticon Barcode Viewer – ein serielles "
                "Barcode-Scan- und Verwaltungswerkzeug für den UV-300-Reader "
                "(Wafer-ID-Speicherung).</p>"
                "<h3>Support-Kontakt</h3>"
                "<p>Wenden Sie sich an Ihren Anlagenhersteller / das "
                "Optik-Support-Team. Geben Sie an: welchen Build (Portable/"
                "Lizenziert), das Betriebssystem, den verwendeten COM-Port und "
                "einen Screenshot des Hauptfensters.</p>"
            ),
        },
        # __MORE_DE__
    },
    # ------------------------------------------------------------------
    # 繁體中文 (zh_Hant)
    # ------------------------------------------------------------------
    "zh_Hant": {
        "getting_started": {
            "title": "快速入門",
            "body_html": (
                "<h3>第一步</h3>"
                "<ol>"
                "<li>在左上角 <b>COM 埠</b> 選取掃描器的序列埠。如果找不到您的埠，"
                "請按它旁邊的 <b>重新整理</b> 圖示按鈕。</li>"
                "<li>選擇正確的 <b>鮑率</b>（預設 115200）。可使用 <b>自動偵測</b> "
                "自動嘗試常見速率。</li>"
                "<li>按 <b>連線</b>。狀態指示燈變綠，連線按鈕啟用。</li>"
                "<li>按 <b>觸發</b> 要求掃描，或使用 <b>連續掃描</b> 持續讀取。</li>"
                "</ol>"
                "<p>掃描的條碼會顯示在表格中。您可以選取列並使用 "
                "<b>複製所選</b> / <b>全部複製</b>，或用 <b>清除</b> 清空清單。</p>"
            ),
        },
        "continuous_scan": {
            "title": "連續掃描模式",
            "body_html": (
                "<h3>連續掃描</h3>"
                "<p><b>連續掃描</b> 會持續重複讀取，直到您按 <b>停止</b>。啟動時按鈕"
                "會保持勾選。</p>"
                "<ul>"
                "<li>每次掃描都會加入表格。</li>"
                "<li>使用 <b>略過連續重複</b> 來跳過與上一個相同的條碼。</li>"
                "<li>也可以透過 <b>選單</b> 按鈕切換連續掃描。</li>"
                "</ul>"
                "<p>按 <b>停止</b>（或 <b>觸發</b> 進行單次讀取）即可回到手動掃描。</p>"
            ),
        },
        "operator_validation": {
            "title": "操作員 ID 與驗證",
            "body_html": (
                "<h3>操作員 ID</h3>"
                "<p>在 <b>操作員 ID</b> 欄位輸入操作員／徽章 ID。它會寫入儲存的掃描"
                "檔名，因此建議使用有意義的 ID。</p>"
                "<h3>前置／後綴驗證</h3>"
                "<p>您可以在 <b>設定 &gt; 條碼驗證</b> 定義 <b>預期前置</b> 與 "
                "<b>預期後綴</b>。不符合的掃描會標記為 <b>NG</b> 而非 <b>GOOD</b>。</p>"
                "<p>Wafer ID 資料夾邏輯預期剛好 4 個以 <code>-</code> 分隔的區段"
                "（例如 <code>1-123CD4-001-001</code>）。非標準 Wafer ID 會儲存到"
                "獨立的非標準資料夾。</p>"
            ),
        },
        "trigger_retry_manual": {
            "title": "觸發 / 重試 / 手動輸入",
            "body_html": (
                "<h3>觸發循環</h3>"
                "<p><b>觸發</b> 會向掃描器送出要求。如果在設定的逾時內未收到掃描，"
                "應用程式會自動重試（請見 <b>設定 &gt; 觸發與感測器</b> 中的最大"
                "嘗試次數／重試延遲）。</p>"
                "<h3>重試</h3>"
                "<p>讀取失敗時，<b>重新掃描</b> 會手動重新送出要求。</p>"
                "<h3>手動輸入</h3>"
                "<p>重試用完後會開啟登入對話框。請登入（預設使用者 "
                "<code>A12345</code>）並手動輸入 Wafer ID。操作員 ID 與時間戳會"
                "照常寫入檔名。</p>"
            ),
        },
        "tuning": {
            "title": "調諧工具（Bank）",
            "body_html": (
                "<h3>連接調諧工具</h3>"
                "<p>當序列連線開啟時，<b>設定</b> 中的調諧分頁會透過同一連線與"
                "讀取器通訊。</p>"
                "<ul>"
                "<li><b>選擇 Bank</b> – 選擇 7 個記憶體 Bank（01–07）。</li>"
                "<li><b>開始/停止調諧</b> – 執行或停止調諧序列。</li>"
                "<li><b>在 Bank 中觸發</b> – 觸發所選 Bank。</li>"
                "<li><b>重設 Bank / 重設全部 Bank</b> – 恢復原廠預設。</li>"
                "</ul>"
                "<p>目前的選擇會保留在主視窗並顯示在狀態列。</p>"
            ),
        },
        "builds": {
            "title": "可攜版 vs. 授權版",
            "body_html": (
                "<h3>兩種建置版本</h3>"
                "<p>本應用程式有兩種版本：</p>"
                "<ul>"
                "<li><b>可攜版</b> – 可在任何 PC 上執行，無硬體授權檢查，"
                "會忽略任何 <code>license.lock</code>。</li>"
                "<li><b>授權版</b> – 需要在 .exe 旁有有效的 "
                "<code>license.lock</code>。授權會透過硬體指紋"
                "（主機板/BIOS/CPU/UUID）綁定到一台 PC。</li>"
                "</ul>"
                "<p>建置模式由 <code>build.py</code> 在建置時寫入，執行期間無法"
                "變更。</p>"
            ),
        },
        "troubleshooting": {
            "title": "疑難排解",
            "body_html": (
                "<h3>看不到 COM 埠</h3>"
                "<ul>"
                "<li>檢查 USB／序列纜線，並確認掃描器已開機。</li>"
                "<li>按 <b>重新整理</b> 按鈕重新列舉連接埠。</li>"
                "<li>在 Windows 上，檢查裝置管理員（連接埠）中的驅動程式。</li>"
                "</ul>"
                "<h3>鮑率錯誤</h3>"
                "<p>使用 <b>自動偵測</b>，或設定符合裝置設定的鮑率。</p>"
                "<h3>授權錯誤（授權版）</h3>"
                "<p>將正確的 <code>license.lock</code> 放在執行檔旁，或在目前 "
                "PC 上使用 <code>generate_license_lock.py</code> 重新產生。</p>"
                "<h3>調諧沒有回應</h3>"
                "<p>確認讀取器連接在相同 COM 埠，且已選擇 Bank。</p>"
            ),
        },
        "about_support": {
            "title": "關於與支援",
            "body_html": (
                "<h3>關於</h3>"
                "<p>Opticon Barcode Viewer – 適用於 UV-300 讀取器（Wafer ID 儲存）"
                "的序列條碼掃描與管理工具。</p>"
                "<h3>支援聯絡</h3>"
                "<p>請向您的設備供應商／光學支援團隊提問，並註明：哪個版本"
                "（可攜/授權）、作業系統、使用的 COM 埠，以及主視窗截圖。</p>"
            ),
        },
    },
}

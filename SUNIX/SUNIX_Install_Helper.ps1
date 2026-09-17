<#
.SYNOPSIS
    Hilfsskript für die Installation/Prüfung des SUNIX PCI Express Industrial
    I/O Control Board Treibers (SDC4880B / SDC0880I).

.DESCRIPTION
    - Sucht die Setup.exe automatisch (oder nimmt den angegebenen Pfad).
    - Startet die Installation (Sprachauswahl im Installer wählt der Benutzer
      selbst - z.B. "Chinese (Traditional)").
    - Prüft danach per Geräte-Manager (PnP), ob die Karte und die COM-Ports
      korrekt erkannt wurden - unabhängig von der Windows-Anzeigesprache,
      da nach "SUNIX" gefiltert wird (Gerätename bleibt meist Englisch,
      auch unter traditionellem Chinesisch).

.PARAMETER SetupPath
    Optionaler vollständiger Pfad zur Setup.exe. Wenn leer, wird im aktuellen
    Ordner und Unterordnern danach gesucht.

.EXAMPLE
    .\SUNIX_Install_Helper.ps1
    .\SUNIX_Install_Helper.ps1 -SetupPath "D:\Treiber\SDC4880B\Setup.exe"
#>

param(
    [string]$SetupPath = ""
)

function Write-Section($text) {
    Write-Host ""
    Write-Host "=== $text ===" -ForegroundColor Cyan
}

# --- 0. Administratorrechte prüfen ---
$isAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $isAdmin) {
    Write-Host "Dieses Skript muss als Administrator ausgeführt werden." -ForegroundColor Red
    Write-Host "Bitte PowerShell mit 'Als Administrator ausführen' erneut starten." -ForegroundColor Yellow
    exit 1
}

Write-Section "SUNIX I/O Control Board - Installationshelfer"

# --- 1. Setup.exe finden ---
if ([string]::IsNullOrWhiteSpace($SetupPath)) {
    Write-Host "Suche nach Setup.exe im aktuellen Ordner und Unterordnern..."
    $found = Get-ChildItem -Path (Get-Location) -Filter "Setup.exe" -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1
    if ($found) {
        $SetupPath = $found.FullName
        Write-Host "Gefunden: $SetupPath" -ForegroundColor Green
    } else {
        Write-Host "Keine Setup.exe gefunden." -ForegroundColor Yellow
        Write-Host "Bitte Pfad manuell angeben, z.B.:" -ForegroundColor Yellow
        Write-Host "  .\SUNIX_Install_Helper.ps1 -SetupPath 'D:\Treiber\Setup.exe'"
        exit 1
    }
} elseif (-not (Test-Path $SetupPath)) {
    Write-Host "Angegebener Pfad nicht gefunden: $SetupPath" -ForegroundColor Red
    exit 1
}

# --- 2. Installation starten ---
Write-Section "Installation wird gestartet"
Write-Host "Datei: $SetupPath"
Write-Host "Hinweis: Im Sprachfenster kannst du 'Chinese (Traditional)' oder" -ForegroundColor Yellow
Write-Host "         'English (United States)' wählen - das Ergebnis ist identisch." -ForegroundColor Yellow
Write-Host "Bitte den Assistenten normal durchklicken (Next -> Install -> Finish)."
Write-Host ""

try {
    Start-Process -FilePath $SetupPath -Wait -ErrorAction Stop
} catch {
    Write-Host "Fehler beim Starten der Installation: $_" -ForegroundColor Red
    exit 1
}

Write-Host "Installer-Fenster wurde geschlossen." -ForegroundColor Green
Start-Sleep -Seconds 2

# --- 3. Geräte prüfen ---
Write-Section "Prüfe erkannte SUNIX-Geräte (Geräte-Manager / PnP)"

$devices = Get-PnpDevice | Where-Object { $_.FriendlyName -like "*SUNIX*" }

if ($devices) {
    Write-Host "Gefundene SUNIX-Geräte:" -ForegroundColor Green
    $devices | Sort-Object Class | Format-Table FriendlyName, Class, Status -AutoSize
} else {
    Write-Host "Keine SUNIX-Geräte gefunden." -ForegroundColor Red
    Write-Host "-> Ist die Karte physisch eingebaut und der PC neu gestartet worden?"
}

# --- 4. COM Ports separat auflisten ---
Write-Section "SUNIX COM-Ports"

$comPorts = Get-PnpDevice -Class Ports -ErrorAction SilentlyContinue | Where-Object { $_.FriendlyName -like "*SUNIX*" }

if ($comPorts) {
    $comPorts | Format-Table FriendlyName, Status -AutoSize

    # COM-Portnamen extrahieren, z.B. "SUNIX COM Port (COM6)"
    foreach ($p in $comPorts) {
        if ($p.FriendlyName -match '\((COM\d+)\)') {
            Write-Host ("  -> {0}: {1}" -f $Matches[1], $p.Status)
        }
    }
} else {
    Write-Host "Keine SUNIX COM-Ports gefunden (normal bei SDC0880I - reines Digital-I/O-Board)." -ForegroundColor Yellow
}

# --- 5. Geräte mit Problemen anzeigen ---
Write-Section "Warnungen / Probleme"
$problemDevices = Get-PnpDevice | Where-Object { $_.FriendlyName -like "*SUNIX*" -and $_.Status -ne "OK" }
if ($problemDevices) {
    Write-Host "Folgende SUNIX-Geräte melden ein Problem:" -ForegroundColor Red
    $problemDevices | Format-Table FriendlyName, Status, ConfigManagerErrorCode -AutoSize
    Write-Host "-> Rechtsklick im Geräte-Manager -> Treiber aktualisieren -> Setup.exe erneut ausführen."
} else {
    Write-Host "Keine Probleme erkannt." -ForegroundColor Green
}

Write-Section "Fertig"
Write-Host "Öffne bei Bedarf den 'SDC Manager' aus dem Startmenü, um Digital I/O und COM-Ports zu konfigurieren."

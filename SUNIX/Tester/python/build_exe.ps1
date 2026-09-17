<#
.SYNOPSIS
    Baut den Python-DI-Tester mit PyInstaller zu einer einzelnen .exe.

.DESCRIPTION
    Ergebnis: python\dist\DI_Tester.exe
    (Einzeldatei, ohne Konsolenfenster - reine Tkinter-GUI.)

    Hinweis: sdciodll.dll wird NICHT mit eingepackt (Hersteller-DLL, gehoert
    nicht ins Repo). Auf dem Ziel-PC die DLL neben die .exe legen oder
    SUNIX_DLL_PATH setzen.

.EXAMPLE
    .\build_exe.ps1
    .\build_exe.ps1 -Clean
#>

param(
    [switch]$Clean
)

$ErrorActionPreference = "Stop"
Set-Location -Path $PSScriptRoot

Write-Host "=== DI-Tester (Python) bauen ===" -ForegroundColor Cyan

# --- 1. PyInstaller vorhanden? ---
$pyinstaller = python -m PyInstaller --version 2>$null
if ($LASTEXITCODE -ne 0) {
    Write-Host "PyInstaller fehlt. Installation mit:" -ForegroundColor Yellow
    Write-Host "  python -m pip install -r requirements.txt"
    exit 1
}
Write-Host "PyInstaller $pyinstaller gefunden." -ForegroundColor Green

# --- 2. Aufraeumen (optional) ---
if ($Clean) {
    Remove-Item -Recurse -Force build, dist, DI_Tester.spec -ErrorAction SilentlyContinue
    Write-Host "Alte Build-Artefakte entfernt."
}

# --- 3. Bauen ---
python -m PyInstaller --onefile --windowed --name DI_Tester di_tester_gui.py
if ($LASTEXITCODE -ne 0) {
    Write-Host "Build fehlgeschlagen." -ForegroundColor Red
    exit 1
}

$exe = Join-Path $PSScriptRoot "dist\DI_Tester.exe"
if (Test-Path $exe) {
    Write-Host "Fertig: $exe" -ForegroundColor Green
    Write-Host "Hinweis: sdciodll.dll bei Bedarf neben die .exe kopieren (Mock laeuft ohne DLL)."
} else {
    Write-Host "Build lief ohne Fehler, aber $exe wurde nicht gefunden." -ForegroundColor Red
    exit 1
}
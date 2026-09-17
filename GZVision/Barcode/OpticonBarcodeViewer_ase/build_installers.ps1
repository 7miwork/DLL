[CmdletBinding()]
param(
    [switch]$SkipApplicationBuild,
    [switch]$Clean
)

$ErrorActionPreference = "Stop"
$ProjectDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $ProjectDir

function Find-InnoSetupCompiler {
    $command = Get-Command ISCC.exe -ErrorAction SilentlyContinue
    if ($command) {
        return $command.Source
    }

    $candidates = @(
        "$env:ProgramFiles\Inno Setup 6\ISCC.exe",
        "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe"
    )
    foreach ($candidate in $candidates) {
        if (Test-Path $candidate) {
            return $candidate
        }
    }
    throw "ISCC.exe wurde nicht gefunden. Installieren Sie Inno Setup 6 und starten Sie das Skript erneut."
}

if (-not $SkipApplicationBuild) {
    $buildArgs = @("build.py", "all")
    if ($Clean) {
        $buildArgs += "--clean"
    }
    & py @buildArgs
    if ($LASTEXITCODE -ne 0) {
        throw "Der PyInstaller-Build ist fehlgeschlagen (Exitcode $LASTEXITCODE)."
    }
}

$required = @(
    "dist\OpticonBarcodeViewer_Portable.exe",
    "dist\OpticonBarcodeViewer_Licensed.exe",
    "dist\OpticonHardwareHash.exe",
    "dist\app_config.json",
    "dist\users.json"
)
foreach ($path in $required) {
    if (-not (Test-Path $path)) {
        throw "Erforderliche Builddatei fehlt: $path"
    }
}

$compiler = Find-InnoSetupCompiler
New-Item -ItemType Directory -Force -Path "installer" | Out-Null

foreach ($script in @("installer_portable.iss", "installer_licensed.iss")) {
    & $compiler "/Qp" $script
    if ($LASTEXITCODE -ne 0) {
        throw "Inno Setup ist bei $script fehlgeschlagen (Exitcode $LASTEXITCODE)."
    }
}

Write-Host "Fertig. Installer liegen in $ProjectDir\installer."

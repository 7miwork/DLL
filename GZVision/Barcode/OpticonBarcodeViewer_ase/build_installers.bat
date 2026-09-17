@echo off
setlocal
cd /d "%~dp0"
powershell.exe -NoProfile -ExecutionPolicy Bypass -File "%~dp0build_installers.ps1" -Clean
if errorlevel 1 (
  echo.
  echo Build fehlgeschlagen.
  pause
  exit /b 1
)
echo.
echo Build erfolgreich abgeschlossen.
pause

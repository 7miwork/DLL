@echo off
rem ---------------------------------------------------------------------------
rem Baut den C++-DI-Tester zu DI_Tester.exe (Konsolen-App).
rem Aufruf aus einer "Developer Command Prompt for VS" (x64), damit cl.exe im PATH
rem liegt (vcvars64.bat). Es wird NICHT gegen sdciodll.lib gelinkt - die DLL
rem wird zur Laufzeit per LoadLibraryA geladen (kein SUNIX-SDK zum Bauen noetig).
rem ---------------------------------------------------------------------------
setlocal

echo === DI-Tester (C++) bauen ===

where cl.exe >nul 2>nul
if errorlevel 1 goto noclexe

cl.exe /nologo /std:c++17 /EHsc /W3 /O2 /D_CRT_SECURE_NO_WARNINGS ^
       /Fe:DI_Tester.exe main.cpp SdcIoClient.cpp
if errorlevel 1 goto buildfail

echo.
echo Fertig: %CD%\DI_Tester.exe
echo Hinweis: sdciodll.dll bei Bedarf in dieses Verzeichnis legen (Mock laeuft ohne DLL).
goto end

:noclexe
echo.
echo FEHLER: cl.exe wurde nicht gefunden.
echo.
echo Dieses Skript braucht eine "Developer Command Prompt for VS" (oder ein
echo vorher aufgerufenes vcvars64.bat), damit der MSVC-Compiler im PATH ist.
echo Beispiel:
echo   "C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvars64.bat"
echo.
echo Alternative ohne MSVC (MinGW-w64 im PATH):
echo   g++ -std=c++17 -O2 -o DI_Tester.exe main.cpp SdcIoClient.cpp -static
exit /b 1

:buildfail
echo Fehler beim Kompilieren.
exit /b 1

:end
endlocal
; Opticon Barcode Viewer - portable installer
; Build after the application EXE exists:
;   ISCC.exe installer_portable.iss

#define AppName "Opticon Barcode Viewer"
#define AppVersion "1.0.1"
#define AppPublisher "Opticon"
#define AppExeName "OpticonBarcodeViewer_Portable.exe"

[Setup]
AppId={{8A4A6F07-3C17-4A86-A4A7-0F7C0A1B2C3D}}
AppName={#AppName} Portable
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={localappdata}\Programs\OpticonBarcodeViewer\Portable
DefaultGroupName={#AppName} Portable
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
OutputDir=installer
OutputBaseFilename=OpticonBarcodeViewer_Portable_Setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
Uninstallable=yes

[Files]
Source: "dist\{#AppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "dist\app_config.json"; DestDir: "{app}"; Flags: onlyifdoesntexist
Source: "dist\users.json"; DestDir: "{app}"; Flags: onlyifdoesntexist

[Icons]
Name: "{autoprograms}\{#AppName} Portable"; Filename: "{app}\{#AppExeName}"
Name: "{autodesktop}\{#AppName} Portable"; Filename: "{app}\{#AppExeName}"

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Start {#AppName} Portable"; Flags: postinstall nowait skipifsilent

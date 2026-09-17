; Opticon Barcode Viewer - hardware-licensed installer
; The customer-specific license.lock is copied manually next to the EXE.
; Build after the application EXEs exist:
;   ISCC.exe installer_licensed.iss

#define AppName "Opticon Barcode Viewer"
#define AppVersion "1.0.1"
#define AppPublisher "Opticon"
#define AppExeName "OpticonBarcodeViewer_Licensed.exe"
#define HashToolName "OpticonHardwareHash.exe"

[Setup]
AppId={{D8F0C2A1-94B5-4E31-8D9F-65A7B8C9D0E1}}
AppName={#AppName} Licensed
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={localappdata}\Programs\OpticonBarcodeViewer\Licensed
DefaultGroupName={#AppName} Licensed
DisableProgramGroupPage=yes
PrivilegesRequired=lowest
OutputDir=installer
OutputBaseFilename=OpticonBarcodeViewer_Licensed_Setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
Uninstallable=yes

[Files]
Source: "dist\{#AppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "dist\{#HashToolName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "dist\app_config.json"; DestDir: "{app}"; Flags: onlyifdoesntexist
Source: "dist\users.json"; DestDir: "{app}"; Flags: onlyifdoesntexist
; A customer-specific license.lock is intentionally never bundled.
; Copy the issued license.lock beside the installed EXE after installation.

[Icons]
Name: "{autoprograms}\{#AppName} Licensed"; Filename: "{app}\{#AppExeName}"
Name: "{autodesktop}\{#AppName} Licensed"; Filename: "{app}\{#AppExeName}"
Name: "{autoprograms}\{#AppName} Hardware Hash"; Filename: "{app}\{#HashToolName}"

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Start {#AppName} Licensed"; Flags: postinstall nowait skipifsilent

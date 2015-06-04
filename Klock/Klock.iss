; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Klock"
#define MyAppVersion "1.0.0.14"
#define MyAppPublisher "keleven"
#define MyAppURL "www.keleven.co.uk"
#define MyAppExeName "Klock.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId=4E5C74C7-6D9B-40d3-8CDF-0B364D4E681C
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

;  all source files here
SourceDir=C:\My\shed\projects\VB\klock\V1\Klock

DefaultDirName={pf}\keleven\Klock
DefaultGroupName={#MyAppName}
LicenseFile=License.txt
InfoAfterFile=Help.txt
OutputDir=C:\My\shed\projects\VB
OutputBaseFilename=Klock_14
SetupIconFile=Klock.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Types]
Name: full; Description: "Klock Program + source"
Name: prog; Description: "Klock program only"

[Components]
Name: all; Description: Klock Program + source; Types: full
Name: exe; Description: exe's only; Types: full prog

[Files]
Source: "bin\Release\Klock.exe" ; DestDir: "{app}"       ; Components : exe; Flags: ignoreversion
Source: "bin\Release\sounds\*"  ; DestDir: "{app}\sounds"; Components : exe; Flags: ignoreversion
Source: "help.txt"              ; DestDir: "{app}"       ; Components : exe; Flags: ignoreversion
Source: "License.txt"           ; DestDir: "{app}"       ; Components : exe; Flags: ignoreversion
Source: "History.txt"           ; DestDir: "{app}"       ; Components : exe; Flags: ignoreversion

;  include source if directed :: NB needs a clean CVS checkout :: recursesubdirs for recursion
;  install into My Documents foler.
Source: "C:\My\shed\projects\VB\clean_Klock\*" ; DestDir: "{userdocs}\Keleven_source\Klock" ; Components : all; Flags: ignoreversion recursesubdirs


; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"                                               ; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"                         ; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"                                       ; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, "&", "&&")}}"; Flags: nowait postinstall skipifsilent


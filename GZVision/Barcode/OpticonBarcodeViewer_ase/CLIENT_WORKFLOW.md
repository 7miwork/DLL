# UV-300 Client Workflow and Acceptance Criteria

This document reconciles the uploaded client presentation with the implemented
application. Where the presentation specifies a file or folder rule, that
rule is authoritative.

## Production workflow

The operator places the Wafer on the UV-300 Reader tray and pushes the tray
into the UV drawer. The operator starts the UV exposure with the green button.
After exposure stops, the tray is pulled out to its positioning point and the
reader is triggered to read the Wafer barcode. The current application can
send the reader trigger and handle the decoded result; the presentation does
not define the electrical protocol for the UV button, drawer position, or MIS
network upload, so those interfaces require customer-provided specifications
before they can be safely added.

## Operator and administrator access

The application requires a logged-in local user before connecting or
triggering the reader. The active employee ID is shown in the operational UI.
Manual entry is available only to an account with the `can_manual_entry`
permission. Administrators retain configuration, tuning, export, help,
duplicate-policy, and user-management controls; operators receive the
production connection, trigger, retry, stop, manual-entry, and session
controls. Operational labels are displayed bilingually in English and
Traditional Chinese.

## Read results and recovery

The barcode reading result is displayed in the scan table. Optional prefix and
suffix validation marks a result as GOOD or NG. A failed NG read can be
repeated with the Retry button. If the configured retry cycle is exhausted,
the operator can use the permission-controlled manual-entry form. Manual
entries are marked as `Manual input` in the table and export data. Consecutive
duplicate suppression is enabled by default and occurs before text-file and
image creation.

## Text-file storage

Each accepted barcode creates one UTF-8 text file containing the raw Wafer ID
and a trailing newline. The filename schema is:

```text
<WaferID>#<Substrate2D>#<OperatorID>#<yyyyMMddHHmmss>.txt
```

`Substrate2D` is always `Null` because this machine does not read it.
Automatic device reads use `Null` for `OperatorID`; manual entries use the
authenticated employee ID, such as `A12345`.

For example:

```text
Automatic: 1-123CD4-001-001#Null#Null#20260729112257.txt
Manual:    1-123CD4-001-001#Null#A12345#20260729112257.txt
```

A standard Wafer ID such as `1-123CD4-001-001` is stored under
`<standard_root_path>/123CD4B001/`. A non-standard Wafer ID is stored directly
under `nonstandard_path`. Both roots are read from the external
`app_config.json` file. Existing files are never overwritten; a numeric suffix
is added on same-second collisions.

## CCD images

When the reader returns a CCD image, the application saves it as a JPEG with
the same basename as the text file. By default the JPEG is stored beside the
text file. Administrators can set `image_storage_path` in `app_config.json` or
through the Settings dialog; a configured value stores the JPEG directly under
that external directory. A failed optional CCD transfer does not invalidate a
successful barcode read or its text file.

## Build and licensing acceptance

`python build.py portable` creates an internal/demo executable that ignores
`license.lock`. `python build.py licensed` creates the customer executable
that requires a matching hardware-bound `license.lock` beside the executable.
`python build.py hash-tool` creates the target-PC fingerprint helper, and
`python build.py all --clean` creates all three targets. The build script
restores `build_config.py` to the safe `portable` development value after each
attempt and never generates or embeds a customer license automatically.

## CCD calibration workflow

The administrator tuning tab provides a combined **Auto Focus → Auto Tuning** action based on the UniversalTuningTool reference. The application sends the configured Auto Focus command first and waits for its response. Only after Auto Focus succeeds does it send the existing `DT1` Auto Tuning/teaching command. The tuning result is shown after all expected response lines arrive. The standalone Start Tuning action remains available when Auto Focus is not required.

The default command identifier is `AF`, configured as `autofocus_command` in `app_config.json`. Because the screenshot does not reveal the scanner firmware’s serial identifier, administrators can replace `AF` with the documented value for the installed UV-300 reader before calibration.

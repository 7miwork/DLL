# Opticon Barcode Viewer — Implementation Handoff

## Scope completed

The uploaded client presentation was compared with the application source. The corrected project now follows the presentation’s UV-300 file-storage requirements and retains the existing authenticated operator, retry, manual-entry, duplicate-suppression, bilingual UI, and CCD-reader workflow.

| Area | Correction |
|---|---|
| Filename schema | Changed to `<WaferID>#<Substrate2D>#<OperatorID>#<yyyyMMddHHmmss>.txt`. `Substrate2D` is `Null`; automatic reads use `Null` for the operator field; manual input uses the authenticated employee ID. |
| Wafer folders | Standard IDs continue to resolve to `<standard_root_path>/<segment2>B<segment3>/`; non-standard IDs continue to use `nonstandard_path`. |
| Retry workflow | The Retry button now starts the same configured retry controller as the primary Trigger action, and the retry controller alone owns per-attempt timeout handling. |
| Manual input | Manual entry remains permission-controlled and is still used after the configured retry cycle is exhausted. |
| CCD image storage | Added external `image_storage_path` configuration. A blank value stores the JPEG beside the text file; a configured value stores the same-basename JPEG directly under that directory. |
| Settings persistence | Added the missing trigger-setting persistence functions and an administrator-facing CCD image-folder selector. |
| Build safety | `build.py` now migrates `app_config.json` without overwriting existing customer values, copies missing runtime templates, and always restores the safe portable development mode. |
| Installer safety | The generic licensed installer never bundles a project-level `license.lock`; the issued license must be copied beside the installed licensed executable explicitly. |

## Build on Windows

PyInstaller creates platform-specific executables. Run the following commands on a Windows build PC from the project directory:

```powershell
py -m pip install -r requirements.txt
py build.py portable --clean
py build.py licensed --clean
py build.py hash-tool --clean
```

To build all application targets in one pass:

```powershell
py build.py all --clean
```

To create both Inno Setup installers, install Inno Setup 6 and run:

```powershell
Set-ExecutionPolicy -Scope Process Bypass
.\build_installers.ps1 -Clean
```

The portable executable is for internal testing and demonstrations only. The licensed executable is the customer-delivery variant and requires a matching `license.lock` beside it.

## License issuance workflow

Run `OpticonHardwareHash.exe` on the target PC and send the displayed SHA-256 fingerprint to the license issuer. The issuer runs the protected `generate_license_lock.py` utility and returns the resulting `license.lock`. Copy that file into the same directory as `OpticonBarcodeViewer_Licensed.exe` after installation. The generic licensed installer intentionally does not package a customer-specific license file.

## Validation completed

The test suite passes with **76 tests** in headless Qt mode. The translation registry contains the same **216 keys** in English, German, and Traditional Chinese. Python syntax compilation passes for the modified modules. PyInstaller successfully produced portable, licensed, and hardware-hash artifacts in the Linux sandbox; the embedded PYZ archives contain `BUILD_MODE = "portable"` and `BUILD_MODE = "licensed"` respectively, and the source `build_config.py` was restored to `portable`.

The sandbox build artifacts are Linux executables because the sandbox is Linux. A Windows build must be performed on Windows to obtain the requested `.exe` files.

## Customer information still required

The presentation describes the physical UV exposure interlock and MIS upload behavior but does not provide the corresponding interfaces. The project therefore does not invent a safety-critical hardware protocol or a network upload contract. To implement those portions, provide the UV button, drawer/tray-position, UV-complete, and reader-trigger I/O protocol, together with the MIS endpoint, authentication method, payload schema, timeout, and success/NG response rules. Prefix and suffix examples are also needed if barcode validation must be fixed to a customer-defined format.

## References

[1]: HIGHMAXUV-300條碼追朔防呆系統20260617.ppt — uploaded client presentation.
[2]: CLIENT_WORKFLOW.md — project acceptance summary updated during this correction.

## Startup fix for `ModuleNotFoundError: jaraco`

The uploaded `OpticonBarcodeViewer_Portable.exe` contains PyInstaller’s `pyi_rth_pkgres`/setuptools runtime hook even though the application does not import `pkg_resources` or `setuptools`. That hook imports `pkg_resources`, which then requires an optional `jaraco` package that was not included in the executable. All application and helper `.spec` files now explicitly exclude `setuptools`, `pkg_resources`, and `jaraco`, preventing the unused runtime hook from being bundled. A fresh portable and licensed build completed successfully with no such runtime hook or warning, and the rebuilt portable artifact launched under headless Qt without the jaraco error.

Do not repair the old executable by copying random Python packages beside it. Rebuild the executable from the corrected source on Windows using `py build.py portable --clean` or `py build.py all --clean`, then replace the old executable. If the customer build environment has a custom PyInstaller hook that still forces `pkg_resources`, remove that hook or use the project specs supplied in this archive.

## CCD calibration workflow from the UniversalTuningTool reference

The screenshot confirms that the requested “auto turning” means the scanner calibration/teaching workflow, not automatic barcode triggering. The tuning tab now includes one administrator action labeled **Auto Focus → Auto Tuning**. When the reader is connected, this action sends the configured Auto Focus command first, waits for its response, and only then sends the existing `DT1` Auto Tuning command. The tuning result is considered complete only after the configured DT1 response lines have arrived.

The default Auto Focus command identifier is `AF`, stored in `app_config.json` as `autofocus_command`. Because the screenshot does not expose the serial command identifier and Opticon firmware variants may differ, the field is editable in the tuning settings tab. If the UV-300 firmware uses another identifier, enter that documented value before running calibration. The existing Start Tuning button remains available for a tuning-only operation, while the combined action enforces the requested order.

The main and modal operator workflows now restore keyboard focus after the window becomes active, after login/logout, after connection changes, and after scan results. Login and manual-entry dialogs defer focus until visible and select their primary input for immediate keyboard/scanner entry.

## Visible calibration controls

The calibration functions are now exposed directly in the main operational action row, not only in the administrator settings dialog. The row contains **Auto Focus**, **Auto Tuning**, and **Auto Focus → Auto Tuning**. These controls remain visible for discoverability, but are enabled only when an administrator is logged in and the scanner is connected. The combined button is the recommended production action because it enforces Auto Focus before the Auto Tuning/teaching step.

## COM4 access-denied handling

The Windows screenshot shows `PermissionError(13)` / `Access is denied` while opening `COM4`. This is an operating-system port-lock or device-access problem, not a barcode-decoding failure. The serial worker now recognizes native and PySerial-wrapped access-denied errors and reports actionable guidance: close UniversalTuningTool or any other serial terminal using the port, confirm the device is connected, then retry. Missing-port errors are also reported separately. The original exception traceback is logged only when `DEBUG_SERIAL` is enabled, avoiding an alarming traceback in normal packaged operation.

## Scan-data storage specification

The administrator selects one **Scan Data Save Location** in **Menu → Settings → Interface**. The application creates these folders automatically:

```text
<selected root>/Standardized Format/<barcode>/
<selected root>/Non-Standardized Format/<barcode>/
```

A barcode such as `1-123CD4-001-001` is classified as **Standardized Format**. All other barcode values are classified as **Non-Standardized Format**. The folder name is the complete barcode value, with only Windows-invalid characters sanitized.

Each barcode folder receives the TXT record and the CCD picture. The TXT filename is:

```text
Null#<Wafer ID>#<Manual Operator ID>#yyyyMMddHHmmss.txt
```

For a normal equipment read, for example, the result is:

```text
Null#1-123CD4-001-001#Null#20260729112257.txt
```

The corresponding picture is saved beside it as the same filename with a `.jpg` extension. Manual entries use the authenticated employee ID in the third field and do not create a CCD picture because they do not come from a camera scan.

## Role-based operator panel

The operator interface is intentionally minimal. An operator can see only the COM-port selector and connect/disconnect controls, login/logout, **Continuous Scan**, **Retry Scan**, **Trigger**, **Manual Input**, and **Stop**, together with the scan-results table. Baud-rate selection, auto-detect, refresh, menus, settings, export/copy/clear actions, language selection, duplicate-policy controls, and all CCD calibration controls are administrator-only and hidden from operators.

For an operator, Manual Input is available before the equipment scan. After an equipment barcode is received, it is disabled for that scan cycle. It becomes available again when the operator starts the next Trigger or Retry Scan cycle, or after reconnecting. Administrators are not restricted by this operator-only manual-input gate.

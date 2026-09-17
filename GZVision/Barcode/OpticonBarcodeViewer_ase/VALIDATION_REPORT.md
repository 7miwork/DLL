# Validation Report

## Implemented client requirements

The corrected source implements role-aware login/logout sessions. A user must be authenticated before connecting or starting a scan. The active login ID is shown in the read-only operator field. In accordance with the client presentation, automatic device reads use `Null` in the filename’s operator field, while manual entries use the authenticated employee ID. Operators receive a simplified production interface, while administrators retain the full settings, tuning, export, history, duplicate-policy, help, and user-management controls.

The operational UI displays English and Traditional Chinese together. Manual records are marked in the table and exported data as **Manual input**, and automatic records are marked as **Automatic**. The retry button uses the configured retry controller, and exhausted retries expose the permission-controlled manual-entry flow.

Each barcode is written to an individual UTF-8 text file with exactly one raw Wafer-ID line. The filename is `<WaferID>#<Substrate2D>#<OperatorID>#<yyyyMMddHHmmss>.txt`, with `Substrate2D` fixed to `Null`. The CCD JPEG, when returned by the scanner, uses the same base name. It is saved beside the text file by default or under the externally configured `image_storage_path`. Existing files are not overwritten on timestamp collisions. Wafer IDs continue to route to the standard `<segment2>B<segment3>` folder or the configured non-standard folder.

Duplicate ignoring is enabled as the standard operator behavior. Administrators can change the policy. Duplicate suppression remains active before text-file and image creation.

## Jaraco startup fix

The uploaded portable executable included PyInstaller’s `pyi_rth_pkgres`/setuptools runtime hook even though the application does not use `pkg_resources` or `setuptools`. That hook attempted to import an optional `jaraco` dependency that was absent from the frozen package. All project specs now exclude `setuptools`, `pkg_resources`, and `jaraco`, and `build.py` continues to build through those corrected specs. A fresh portable, licensed, and hardware-hash build completed without those runtime hooks, and the rebuilt portable artifact launched under headless Qt without the jaraco error.

## Verification performed

| Check | Result |
|---|---:|
| Automated test suite | 84 passed |
| Translation-key consistency across English, German, and Traditional Chinese | 234 keys present in all languages |
| Python source compilation | Passed |
| `build.py all --clean --dry-run` | Passed; `build_config.py` restored to portable |
| Portable PyInstaller build | Passed; native validation binary created |
| Licensed PyInstaller build | Passed; native validation binary created |
| Hardware-hash PyInstaller build | Passed; native validation binary created |
| `pkg_resources`/jaraco runtime-hook scan of all three artifacts | None found |
| Packaged portable startup smoke test | Passed; stayed running until controlled timeout without the jaraco error |
| Settings-dialog and main-window calibration UI smoke test | Passed; standalone Auto Focus, Auto Tuning, and combined Auto Focus → Auto Tuning controls initialize correctly |
| Windows serial-error regression tests | Passed; access-denied and missing-port diagnostics are actionable |
| Scan storage hierarchy tests | Passed; standardized/non-standardized categories, barcode folders, required TXT names, and colocated image paths are covered |
| All-target PyInstaller build after storage changes | Passed; portable, licensed, and hardware-hash artifacts created |

## Packaging note

The project is designed for Windows delivery, and the build scripts produce the historical `.exe` names on Windows. The sandbox used for this validation is Linux, so its generated artifacts were native Linux executables rather than Windows `.exe` files. A Windows build must be produced on Windows with the project’s normal commands:

```powershell
py -m pip install -r requirements.txt
py build.py all --clean
```

The generic licensed installer intentionally does not bundle a project-level `license.lock`. After the target-PC hardware hash is issued, copy the matching `license.lock` beside `OpticonBarcodeViewer_Licensed.exe`.

## Remaining customer interface information

The presentation describes the physical UV exposure interlock and MIS upload behavior but does not specify the hardware I/O or network contract. Those portions require the UV button, drawer/tray-position, UV-complete, and reader-trigger protocol, together with the MIS endpoint, authentication, payload, timeout, and success/NG response rules.

| Minimal operator-panel smoke test | Passed; only connection, login/logout, Continuous Scan, Retry Scan, Trigger, Manual Input, Stop, and scan table remain visible |
| Operator Manual Input state test | Passed; enabled before a scan, disabled after equipment scan, restored for the next Trigger/Retry cycle |
| Administrator panel visibility test | Passed; calibration, tuning, settings, management, export, language, baud, and utility controls remain available to administrators |

"""Erstellt die zwei offiziellen Ausgaben des Opticon Barcode Viewer.

Aufruf unter Windows aus dem Projektordner::

    py build.py portable
    py build.py licensed
    py build.py hash-tool
    py build.py all

Die Varianten sind strikt getrennt:

* ``portable`` erzeugt ``dist/OpticonBarcodeViewer_Portable.exe``. Diese
  Anwendung führt **keine** Hardware- oder Lizenzprüfung aus und ignoriert
  eine daneben liegende ``license.lock``.
* ``licensed`` erzeugt ``dist/OpticonBarcodeViewer_Licensed.exe``. Diese
  Anwendung startet nur, wenn eine passende ``license.lock`` neben der EXE
  liegt. Die Datei enthält den SHA-256-Hardware-Fingerprint des Ziel-PCs.
* ``hash-tool`` erzeugt ``dist/OpticonHardwareHash.exe``. Dieses Hilfsprogramm
  gibt nur den Hardware-Fingerprint eines Ziel-PCs aus; es erstellt keine
  Lizenzdatei und aktiviert keine Anwendung.

Der Modus wird ausschließlich während der PyInstaller-Analyse in
``build_config.py`` geschrieben und anschließend immer wiederhergestellt.
Dadurch bleibt der Entwicklungsbaum auch nach einem fehlgeschlagenen Build
im sicheren portablen Standardmodus.
"""

from __future__ import annotations

import argparse
import json
import shutil
import subprocess
import sys
from contextlib import contextmanager
from pathlib import Path
from typing import Iterator


PROJECT_DIR = Path(__file__).resolve().parent
BUILD_CONFIG_PATH = PROJECT_DIR / "build_config.py"
DIST_DIR = PROJECT_DIR / "dist"
BUILD_DIR = PROJECT_DIR / "build"

BUILD_MODES = ("portable", "licensed")
BUILD_TARGETS = ("portable", "licensed", "hash-tool")
SPECS = {
    "portable": "OpticonBarcodeViewer_Portable.spec",
    "licensed": "OpticonBarcodeViewer_Licensed.spec",
    "hash-tool": "OpticonHardwareHash.spec",
}
EXECUTABLES = {
    "portable": "OpticonBarcodeViewer_Portable.exe",
    "licensed": "OpticonBarcodeViewer_Licensed.exe",
    "hash-tool": "OpticonHardwareHash.exe",
}
BUILD_MODE_BY_TARGET = {
    "portable": "portable",
    "licensed": "licensed",
    "hash-tool": "portable",
}
RUNTIME_TEMPLATES = ("app_config.json", "users.json")


def _diagnose_locked_exe(executable_path: Path, error: OSError) -> None:
    """Gibt eine verständliche Diagnose aus, wenn eine EXE nicht ersetzt werden kann.

    Windows sperrt eine ``.exe``, solange ein Prozess daraus läuft. Statt eines
    nackten ``PermissionError``-Stacktraces werden der mutmaßliche Sperrprozess
    und die Behebungsoptionen angezeigt.
    """
    print(f"[build] ERROR: Cannot replace {executable_path.name} ({error.strerror or error}).")
    if sys.platform != "win32":
        print("[build] HINT: Close any running copy of the application and retry.")
        return
    try:
        import psutil  # optional; nur für die Diagnose
        matches = [
            p for p in psutil.process_iter(["pid", "name", "exe"])
            if p.info.get("exe") and Path(p.info["exe"]).resolve() == executable_path.resolve()
        ]
        if not matches:
            matches = [
                p for p in psutil.process_iter(["pid", "name", "exe"])
                if p.info.get("name") and executable_path.name.lower() in str(p.info["name"]).lower()
            ]
    except Exception:
        matches = []
    if matches:
        for proc in matches:
            print(
                "  - Locked by running process: "
                f"{proc.info.get('name', '?')} (PID {proc.info.get('pid', '?')})"
            )
        print("[build] HINT: Stop it and retry, e.g.:  Stop-Process -Id <PID> -Force")
    else:
        print(
            "[build] HINT: The file may be locked by a running application or "
            "antivirus. Close the app and retry."
        )


def executable_filename(target: str) -> str:
    """Return the platform-native output name for a build target.

    Customer delivery is Windows and keeps the historical ``.exe`` names.
    PyInstaller omits that suffix on Linux/macOS, so cross-platform validation
    must check the actual native artifact instead of reporting a false failure.
    """
    filename = EXECUTABLES[target]
    return filename if sys.platform == "win32" else Path(filename).stem

BUILD_CONFIG_TEMPLATE = '''"""Buildzeit-Konfiguration für den Opticon Barcode Viewer.

Diese Datei wird ausschließlich durch ``build.py`` für die Dauer eines
PyInstaller-Builds geändert. ``BUILD_MODE`` wird in die erzeugte Anwendung
übernommen und kann zur Laufzeit weder über Einstellungen noch über
Umgebungsvariablen verändert werden.

Gültige Werte:
    "portable" -> keine Lizenzprüfung
    "licensed" -> passende license.lock neben der EXE erforderlich
"""

BUILD_MODE = "{mode}"
'''


def write_build_mode(mode: str) -> None:
    """Schreibt den während der Analyse eingebetteten Build-Modus."""
    if mode not in BUILD_MODES:
        raise ValueError(f"Unsupported build mode: {mode}")
    BUILD_CONFIG_PATH.write_text(
        BUILD_CONFIG_TEMPLATE.format(mode=mode),
        encoding="utf-8",
    )
    print(f'[build] BUILD_MODE = "{mode}"')


@contextmanager
def temporary_build_mode(mode: str) -> Iterator[None]:
    """Aktiviert einen Build-Modus und stellt danach stets den sicheren Standard her."""
    try:
        write_build_mode(mode)
        yield
    finally:
        write_build_mode("portable")
        print("[build] build_config.py restored to the portable development default")


def ensure_pyinstaller_available() -> bool:
    """Prüft PyInstaller vor dem Build und gibt bei Bedarf eine klare Anleitung aus."""
    result = subprocess.run(
        [sys.executable, "-m", "PyInstaller", "--version"],
        cwd=PROJECT_DIR,
        capture_output=True,
        text=True,
    )
    if result.returncode == 0:
        print(f"[build] PyInstaller {result.stdout.strip()}")
        return True

    print("[build] ERROR: PyInstaller is not available in this Python environment.")
    print("[build] Install the project dependencies first: py -m pip install -r requirements.txt")
    return False


def prepare_output(mode: str, clean: bool) -> tuple[Path, Path]:
    """Bereitet einen mode-spezifischen Arbeitsordner und die Ziel-EXE vor."""
    work_path = BUILD_DIR / mode
    executable_path = DIST_DIR / executable_filename(mode)

    if clean:
        shutil.rmtree(work_path, ignore_errors=True)
    try:
        executable_path.unlink(missing_ok=True)
    except OSError as exc:  # z. B. WinError 5, wenn die EXE noch läuft
        _diagnose_locked_exe(executable_path, exc)
        raise SystemExit(2) from exc

    DIST_DIR.mkdir(parents=True, exist_ok=True)
    work_path.parent.mkdir(parents=True, exist_ok=True)
    return work_path, executable_path


def copy_runtime_templates(target: str) -> None:
    """Stage editable runtime JSON beside the application executable.

    ``app_config.json`` is schema-migrated from the source template while
    retaining values already present in ``dist``. This adds new production
    parameters (including ``scan_storage_root_path``) without silently replacing
    a customer’s configured save location. ``users.json`` is copied only when absent so
    an existing local user store is never overwritten by a rebuild.
    """
    if target not in {"portable", "licensed"}:
        return

    for filename in RUNTIME_TEMPLATES:
        source = PROJECT_DIR / filename
        destination = DIST_DIR / filename
        if not source.exists():
            continue

        if not destination.exists():
            shutil.copy2(source, destination)
            print(f"[build] Runtime template created: {destination.name}")
            continue

        if filename != "app_config.json":
            continue

        try:
            template = json.loads(source.read_text(encoding="utf-8"))
            existing = json.loads(destination.read_text(encoding="utf-8"))
            if not isinstance(template, dict) or not isinstance(existing, dict):
                raise ValueError("runtime configuration must be a JSON object")
            merged = dict(template)
            merged.update(existing)
            if merged != existing:
                destination.write_text(
                    json.dumps(merged, indent=2, ensure_ascii=False) + "\n",
                    encoding="utf-8",
                )
                print(f"[build] Runtime configuration migrated: {destination.name}")
        except (OSError, ValueError, TypeError, json.JSONDecodeError):
            # A corrupt runtime file must not prevent the PyInstaller result
            # from being produced; replace it with the known-good template.
            shutil.copy2(source, destination)
            print(f"[build] Runtime configuration reset: {destination.name}")


def run_pyinstaller(spec_file: str, work_path: Path, dry_run: bool) -> int:
    """Führt PyInstaller mit eindeutigen Build- und Ausgabepfaden aus."""
    command = [
        sys.executable,
        "-m",
        "PyInstaller",
        "--noconfirm",
        "--clean",
        "--distpath",
        str(DIST_DIR),
        "--workpath",
        str(work_path),
    ]
    command.append(spec_file)
    print(f"[build] Command: {' '.join(command)}")
    if dry_run:
        return 0
    return subprocess.run(command, cwd=PROJECT_DIR).returncode


def build(target: str, *, clean: bool, dry_run: bool) -> int:
    """Erstellt ein einzelnes Auslieferungsziel und liefert einen Prozessrückgabecode."""
    if target not in BUILD_TARGETS:
        print(f"[build] ERROR: Unknown target '{target}'.")
        return 1

    spec_file = SPECS[target]
    if not (PROJECT_DIR / spec_file).is_file():
        print(f"[build] ERROR: Missing PyInstaller spec: {spec_file}")
        return 1

    print(f"\n{'=' * 72}\n[build] Building {target.upper()} target\n{'=' * 72}")
    work_path, executable_path = prepare_output(target, clean)

    if not dry_run and not ensure_pyinstaller_available():
        return 1

    with temporary_build_mode(BUILD_MODE_BY_TARGET[target]):
        return_code = run_pyinstaller(spec_file, work_path, dry_run)

    if return_code != 0:
        print(f"[build] FAILED: PyInstaller exited with code {return_code}")
        return return_code

    if dry_run:
        print(f"[build] DRY RUN successful: would create {executable_path}")
        return 0

    if not executable_path.is_file():
        print(f"[build] ERROR: Build finished but output is missing: {executable_path}")
        return 1

    copy_runtime_templates(target)
    print(f"[build] SUCCESS: {executable_path}")
    if target == "licensed":
        print("[build] NEXT STEP: Run OpticonHardwareHash.exe on the target PC and send the hash to the license issuer.")
        print("[build]            The issuer creates license.lock and it is copied next to this EXE.")
    elif target == "hash-tool":
        print("[build] NEXT STEP: Distribute this utility with the licensed application for target-PC hash collection.")
    return 0


def parse_arguments() -> argparse.Namespace:
    """Liest und validiert die Kommandozeilenparameter."""
    parser = argparse.ArgumentParser(
        description="Create portable and hardware-locked Opticon Barcode Viewer builds."
    )
    parser.add_argument("target", choices=(*BUILD_TARGETS, "all"), help="Build target")
    parser.add_argument(
        "--clean",
        action="store_true",
        help="Remove the selected variant's PyInstaller work directory before building.",
    )
    parser.add_argument(
        "--dry-run",
        action="store_true",
        help="Validate configuration and print PyInstaller commands without building.",
    )
    return parser.parse_args()


def main() -> int:
    """Build the requested variant or both variants in a deterministic order."""
    arguments = parse_arguments()
    targets = BUILD_TARGETS if arguments.target == "all" else (arguments.target,)

    result_codes = [
        build(target, clean=arguments.clean, dry_run=arguments.dry_run)
        for target in targets
    ]
    return 0 if all(code == 0 for code in result_codes) else 1


if __name__ == "__main__":
    raise SystemExit(main())

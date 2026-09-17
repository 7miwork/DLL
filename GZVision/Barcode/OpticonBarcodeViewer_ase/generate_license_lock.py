"""Erzeugt eine ``license.lock`` für die lizenzierte Opticon-Ausgabe.

Dieses Skript ist ein **Ausstellerwerkzeug** und bleibt beim Hersteller bzw.
der berechtigten IT-Stelle. Es benötigt den Hardware-Fingerprint des Ziel-PCs,
den das getrennte Hilfsprogramm ``get_hardware_hash.py`` ausgibt.

Beispiele::

    py generate_license_lock.py --fingerprint <64-stelliger-SHA256-Hash> --output-dir .
    py generate_license_lock.py --fingerprint-file C:\\Temp\\opticon_hardware_hash.txt --output-dir C:\\Release

Die erzeugte ``license.lock`` wird zusammen mit
``OpticonBarcodeViewer_Licensed.exe`` auf den Ziel-PC kopiert. Dieses Skript
gehört nicht in die Kundenauslieferung.
"""

from __future__ import annotations

import argparse
import re
import sys
from pathlib import Path


LICENSE_LOCK_FILENAME = "license.lock"
SHA256_HEX_PATTERN = re.compile(r"^[0-9a-fA-F]{64}$")


def normalize_fingerprint(value: str) -> str:
    """Validiert einen SHA-256-Hardware-Fingerprint und normalisiert ihn in Kleinbuchstaben."""
    fingerprint = value.strip().lower()
    if not SHA256_HEX_PATTERN.fullmatch(fingerprint):
        raise ValueError("Fingerprint must be a 64-character SHA-256 hexadecimal value.")
    return fingerprint


def create_license_lock(output_dir: Path, fingerprint: str, *, overwrite: bool) -> Path:
    """Schreibt einen geprüften Fingerprint als einzelne Zeile in ``license.lock``."""
    target_dir = output_dir.expanduser().resolve()
    target_dir.mkdir(parents=True, exist_ok=True)
    lock_path = target_dir / LICENSE_LOCK_FILENAME

    if lock_path.exists() and not overwrite:
        raise FileExistsError(
            f"{lock_path} already exists. Use --force only for the intended target installation."
        )

    lock_path.write_text(normalize_fingerprint(fingerprint) + "\n", encoding="utf-8")
    return lock_path


def parse_arguments() -> argparse.Namespace:
    """Liest genau eine Quelle für den Ziel-Fingerprint ein."""
    parser = argparse.ArgumentParser(
        description="Create a hardware-bound license.lock from a target PC fingerprint."
    )
    source = parser.add_mutually_exclusive_group(required=True)
    source.add_argument(
        "--fingerprint",
        help="64-character SHA-256 fingerprint reported by the target PC.",
    )
    source.add_argument(
        "--fingerprint-file",
        type=Path,
        help="Text file containing the target PC's SHA-256 fingerprint.",
    )
    parser.add_argument(
        "--output-dir",
        type=Path,
        default=Path.cwd(),
        help="Directory in which license.lock is created (default: current directory).",
    )
    parser.add_argument(
        "--force",
        action="store_true",
        help="Replace an existing license.lock in the output directory.",
    )
    return parser.parse_args()


def read_fingerprint(arguments: argparse.Namespace) -> str:
    """Liest und validiert die Fingerprint-Quelle aus den Kommandozeilenargumenten."""
    if arguments.fingerprint is not None:
        return normalize_fingerprint(arguments.fingerprint)

    try:
        return normalize_fingerprint(arguments.fingerprint_file.read_text(encoding="utf-8"))
    except OSError as exc:
        raise ValueError(f"Unable to read fingerprint file: {exc}") from exc


def main() -> int:
    """Erstellt die Lizenzdatei aus einem vom Ziel-PC gemeldeten Fingerprint."""
    arguments = parse_arguments()
    try:
        fingerprint = read_fingerprint(arguments)
        lock_path = create_license_lock(
            arguments.output_dir,
            fingerprint,
            overwrite=arguments.force,
        )
    except (OSError, ValueError, FileExistsError) as exc:
        print(f"ERROR: {exc}", file=sys.stderr)
        return 1

    print(f"license.lock created: {lock_path}")
    print(f"Target fingerprint: {fingerprint}")
    print("Copy this file next to OpticonBarcodeViewer_Licensed.exe on the matching target PC.")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

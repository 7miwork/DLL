"""Gibt den Hardware-Fingerprint dieses Windows-PCs aus.

Dieses Hilfsprogramm darf an den Ziel-PC weitergegeben werden. Es erzeugt
keine Lizenzdatei und aktiviert keine Anwendung. Der ausgegebene Hash wird an
den Lizenz-Aussteller übermittelt, der daraus mit
``generate_license_lock.py`` eine ``license.lock`` erstellt.

Beispiele::

    py get_hardware_hash.py
    py get_hardware_hash.py --output C:\\Temp\\opticon_hardware_hash.txt
"""

from __future__ import annotations

import argparse
import sys
from pathlib import Path

import hardware_lock


def parse_arguments() -> argparse.Namespace:
    """Liest den optionalen Speicherort für die Hash-Datei ein."""
    parser = argparse.ArgumentParser(
        description="Print the Opticon Barcode Viewer hardware fingerprint for this PC."
    )
    parser.add_argument(
        "--output",
        type=Path,
        help="Optional text file to receive the SHA-256 fingerprint.",
    )
    return parser.parse_args()


def main() -> int:
    """Ermittelt und gibt den SHA-256-Fingerprint des aktuellen PCs aus."""
    arguments = parse_arguments()
    try:
        fingerprint = hardware_lock.get_machine_fingerprint()
    except RuntimeError as exc:
        print(f"ERROR: Unable to read hardware fingerprint: {exc}", file=sys.stderr)
        return 1

    if arguments.output is not None:
        try:
            output_path = arguments.output.expanduser().resolve()
            output_path.parent.mkdir(parents=True, exist_ok=True)
            output_path.write_text(fingerprint + "\n", encoding="utf-8")
            print(f"Hardware fingerprint saved: {output_path}")
        except OSError as exc:
            print(f"ERROR: Unable to save fingerprint: {exc}", file=sys.stderr)
            return 1

    print(fingerprint)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())

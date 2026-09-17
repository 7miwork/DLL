"""DI-Tester (Tkinter-GUI) fuer SUNIX SDC4880B / SDC0880I.

Zeigt die 8 digitalen Eingaenge DI1..DI8 live an (gruen = vom Treiber als
aktiv/1 gemeldet, grau = inaktiv). Polling alle 250 ms.

Die elektrische Logik (High/Low, Invertierung) wird NICHT hier ausgewertet -
das stellt man im SDC Manager ein. Dieses Programm zeigt nur, was die API
als "1"/aktiv liefert.

Start:
    python di_tester_gui.py                 (Auto: echte DLL, sonst Mock)
    python di_tester_gui.py --mock          (Mock erzwingen)
    python di_tester_gui.py --board-id 1    (Mehrkarten-System)
    python di_tester_gui.py --selftest 2    (headless Selbsttest, 2 s)
"""

from __future__ import annotations

import argparse
import os
import sys
import tempfile
import time
from typing import List

import tkinter as tk

from sdc_io_client import CHANNEL_COUNT, SdcIoClient

POLL_MS = 250
COLOR_BG = "#1e1e1e"
COLOR_PANEL = "#2b2b2b"
COLOR_ACTIVE = "#2ecc71"
COLOR_INACTIVE = "#4d4d4d"
COLOR_OUTLINE = "#111111"
COLOR_TEXT = "#e6e6e6"
COLOR_MOCK = "#f1c40f"
COLOR_REAL = "#2ecc71"

RADIUS = 30
SPACING = 90
MARGIN = 40


class DiTesterApp:
    """Fenster mit 8 kreisfoermigen Anzeigen und Statuszeile."""

    def __init__(self, root: tk.Tk, client: SdcIoClient) -> None:
        self.root = root
        self.client = client
        self.indicators: List[int] = []
        self._job = None

        self._build_ui()
        self._update()

    # -- Aufbau ------------------------------------------------------------
    def _build_ui(self) -> None:
        self.root.configure(bg=COLOR_BG)
        self.root.resizable(False, False)

        if self.client.is_mock:
            suffix = "MOCK - keine Karte erkannt"
        else:
            suffix = self.client.hardware_info
        self.root.title(f"DI-Tester ({suffix})")

        width = MARGIN + SPACING * CHANNEL_COUNT
        height = 200

        header = tk.Label(
            self.root,
            text=f"SUNIX DI-Tester - {suffix}",
            font=("Segoe UI", 12, "bold"),
            bg=COLOR_BG,
            fg=COLOR_MOCK if self.client.is_mock else COLOR_REAL,
        )
        header.pack(pady=(10, 0))

        canvas = tk.Canvas(
            self.root,
            width=width,
            height=height,
            bg=COLOR_PANEL,
            highlightthickness=1,
            highlightbackground=COLOR_OUTLINE,
        )
        canvas.pack(padx=10, pady=10)
        self.canvas = canvas

        for index in range(CHANNEL_COUNT):
            cx = MARGIN + SPACING * index
            cy = 80
            oval = canvas.create_oval(
                cx - RADIUS,
                cy - RADIUS,
                cx + RADIUS,
                cy + RADIUS,
                fill=COLOR_INACTIVE,
                outline=COLOR_OUTLINE,
                width=2,
            )
            self.indicators.append(oval)
            canvas.create_text(
                cx,
                cy + RADIUS + 26,
                text=f"DI{index + 1}",
                fill=COLOR_TEXT,
                font=("Segoe UI", 11, "bold"),
            )

        self.status_var = tk.StringVar(value=self.client.status_text)
        status = tk.Label(
            self.root,
            textvariable=self.status_var,
            font=("Consolas", 8),
            bg=COLOR_BG,
            fg="#9e9e9e",
            wraplength=width,
            justify="left",
        )
        status.pack(padx=10, pady=(0, 6))

        self.root.bind("<Escape>", lambda _event: self._on_close())
        self.root.protocol("WM_DELETE_WINDOW", self._on_close)

    # -- Polling -----------------------------------------------------------
    def _update(self) -> None:
        states = self.client.read_digital_inputs()
        for index, state in enumerate(states):
            self.canvas.itemconfigure(
                self.indicators[index],
                fill=COLOR_ACTIVE if state else COLOR_INACTIVE,
            )
        self.status_var.set(self.client.status_text)
        self._job = self.root.after(POLL_MS, self._update)

    # -- Ende --------------------------------------------------------------
    def _on_close(self) -> None:
        if self._job is not None:
            try:
                self.root.after_cancel(self._job)
            except Exception:  # noqa: BLE001
                pass
            self._job = None
        self.client.close()
        self.root.destroy()


# -- Selbsttest (headless, ohne GUI) ---------------------------------------

def selftest_log_path() -> str:
    """Protokolldatei des Selbsttests (wichtig fuer die --windowed-.exe)."""
    return os.path.join(tempfile.gettempdir(), "di_tester_py_selftest.txt")


def run_selftest(client: SdcIoClient, seconds: float) -> int:
    """Prueft die Lese-Logik ohne GUI (fuer Build-/CI-Validierung)."""
    lines = [f"Selbsttest gestartet: {client.status_text}"]
    samples = 0
    active_channels = set()
    deadline = time.monotonic() + max(0.5, seconds)
    while time.monotonic() < deadline:
        states = client.read_digital_inputs()
        active_channels.update(i + 1 for i, s in enumerate(states) if s)
        lines.append(" ".join("DI%d=%s" % (i + 1, "1" if s else "0") for i, s in enumerate(states)))
        samples += 1
        time.sleep(POLL_MS / 1000.0)

    client.close()
    lines.append(
        f"Selbsttest beendet: {samples} Messungen, aktive Kanaele gesehen: "
        f"{', '.join('DI%d' % c for c in sorted(active_channels)) or 'keine'}"
    )
    text = "\n".join(lines)

    # Im Fenster-Modus (--windowed) gibt es kein stdout -> immer protokollieren.
    try:
        with open(selftest_log_path(), "w", encoding="utf-8") as handle:
            handle.write(text + "\n")
    except OSError:
        pass

    if sys.stdout is not None:
        try:
            print(text)
        except Exception:  # noqa: BLE001 - Ausgabe ist optional
            pass
    return 0


def main(argv=None) -> int:
    parser = argparse.ArgumentParser(description="SUNIX DI-Tester (Digital-Input-Monitor)")
    parser.add_argument("--mock", action="store_true", help="Mock-Modus erzwingen")
    parser.add_argument("--board-id", type=int, default=0,
                        help="Board-ID fuer Mehrkarten-Systeme (Default 0)")
    parser.add_argument("--dll", default=None, help="Pfad zur sdciodll.dll")
    parser.add_argument("--selftest", nargs="?", const=2.0, type=float, default=None,
                        help="headless Selbsttest fuer N Sekunden (Default 2)")
    args = parser.parse_args(argv)

    client = SdcIoClient(board_id=args.board_id, dll_path=args.dll, force_mock=args.mock)

    if args.selftest is not None:
        return run_selftest(client, args.selftest)

    root = tk.Tk()
    DiTesterApp(root, client)
    root.mainloop()
    return 0


if __name__ == "__main__":
    sys.exit(main())
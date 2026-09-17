"""SdcIoClient - Abstraktionsschicht fuer die SUNIX SDC0880I DLL.

Regeln (siehe ../../AGENTS.md und ../../.clinerules im Repo):
- Alle DLL-Aufrufe sind hier gekapselt, nie verstreut im UI-Code.
- Ohne installierte sdciodll.dll laeuft der Client automatisch im Mock-Modus.
- Es werden KEINE Funktionssignaturen erfunden.

API-Status: VERIFIZIERT (nicht mehr geraten)
- Quelle 1: sdciodll.h aus "Windows SDC API V1.0.6.0_20260617" (liegt im Repo
  unter SUNIX/Driver/, ZIP - SDK ist nicht installiert).
- Quelle 2: Exportliste der sdciodll.dll (x86 UND x64 identisch, 39 Exporte),
  ausgelesen mit dumpbin /exports:
      Lib_init, Lib_free, Get_library_info,
      SDC_enumerate_dio_info, SDC_dio_open, SDC_dio_close,
      SDC_get_di_value, SDC_get_all_di_info, SDC_get_di_info,
      SDC_set_di_invert, ...
- Signaturen aus sdciodll.h / offiziellem VB- und C-Sample (alle __cdecl):
      int  Lib_init(void);
      int  Lib_free(void);
      int  SDC_enumerate_dio_info(PSDC_DIO_BASIC_INFO_LIST listPtr);
      int  SDC_dio_open(int DioIndex);
      int  SDC_dio_close(int DioIndex);
      int  SDC_get_di_value(int DioIndex, int DiPortNumber, unsigned* value);
  Rueckgabe 0 = STATUS_SUCCESS.
  SDC_DIO_BASIC_INFO_LIST = { uint32 DioAmount; struct { int32 DioIndex;
  int32 Version; int32 PciNumber; } DioBasicInfoList[256]; }  (12 Byte/Eintrag,
  Layout identisch zum offiziellen VB-Sample "SdcDioBasicInfo(List).vb").
  Hinweis: Die im Manual genannten Namen (_sdc_dll_init, ...) existieren in
  dieser DLL-Version NICHT als Exporte.
"""

from __future__ import annotations

import ctypes
import glob
import os
import struct
import time
from typing import List, Optional

CHANNEL_COUNT = 8

# ---------------------------------------------------------------------------
# VERIFIZIERTE Export-Namen und Konstanten (siehe Modul-Kopf)
# ---------------------------------------------------------------------------
FUNC_DLL_INIT = "Lib_init"
FUNC_DLL_FREE = "Lib_free"
FUNC_ENUMERATE_DIO = "SDC_enumerate_dio_info"
FUNC_DIO_OPEN = "SDC_dio_open"
FUNC_DIO_CLOSE = "SDC_dio_close"
FUNC_GET_DI_VALUE = "SDC_get_di_value"

STATUS_SUCCESS = 0

# SDC_DIO_BASIC_INFO_LIST: uint32 DioAmount + 256 x 12 Byte Eintraege
DIO_LIST_MAX_AMOUNT = 256
DIO_LIST_ENTRY_BYTES = 12  # int32 DioIndex, int32 Version, int32 PciNumber
DIO_LIST_BUFFER_BYTES = 4 + DIO_LIST_MAX_AMOUNT * DIO_LIST_ENTRY_BYTES


def _default_port_base() -> int:
    """DI-Port-Nummerierung: Default 0 (DI1 = Port 0). Ueber die Umgebungs-
    variable SUNIX_DI_PORT_BASE kann 1 gesetzt werden, falls die Karte die
    Kanaele als Port 1..8 adressiert. Der SDC-Manager zeigt die Nummerierung
    nach dem ersten Hardware-Test ebenfalls an."""
    raw = os.environ.get("SUNIX_DI_PORT_BASE", "0")
    try:
        return 1 if int(raw) == 1 else 0
    except ValueError:
        return 0


class SdcIoClient:
    """Liest die 8 digitalen Eingaenge, mit automatischem Mock-Fallback."""

    def __init__(
        self,
        board_id: int = 0,
        dll_path: Optional[str] = None,
        force_mock: bool = False,
        port_base: Optional[int] = None,
    ) -> None:
        # board_id = Position der Karte im Mehrkarten-System (Default 0 =
        # erste Karte). Der interne DioIndex wird per SDC_enumerate_dio_info
        # ermittelt; board_id dient nur als Fallback, wenn die Enumeration
        # nicht verfuegbar ist.
        self.board_id = board_id
        self.port_base = _default_port_base() if port_base is None else port_base
        self.dll_path: Optional[str] = None
        self.dio_index: Optional[int] = None
        self.card_count: int = 0
        self.last_error: str = ""

        self._dll = None
        self._dio_opened = False
        self._mock = True

        # Mock-Muster-Status (siehe _mock_read)
        self._mock_step = 0

        if not force_mock:
            self._try_open_real(dll_path)

    # -- Status ------------------------------------------------------------
    @property
    def is_mock(self) -> bool:
        return self._mock

    @property
    def hardware_info(self) -> str:
        if self._mock:
            return "MOCK - keine Karte erkannt"
        return (
            f"echte Hardware (Karte {self.board_id + 1} von {self.card_count}, "
            f"DIO-Index {self.dio_index})"
        )

    @property
    def status_text(self) -> str:
        if self._mock:
            reason = self.last_error or "sdciodll.dll nicht gefunden/initialisierbar"
            return f"MOCK-Modus: {reason}"
        return (
            f"Echte Hardware: {self.dll_path} | {self.hardware_info} | "
            f"Ports {self.port_base}..{self.port_base + CHANNEL_COUNT - 1} "
            f"({FUNC_GET_DI_VALUE})"
        )

    # -- DLL laden ---------------------------------------------------------
    def _try_open_real(self, dll_path: Optional[str]) -> bool:
        if os.name != "nt":
            self.last_error = "kein Windows - ctypes.WinDLL nicht verfuegbar"
            return False

        path = dll_path or os.environ.get("SUNIX_DLL_PATH") or self._find_dll()
        if not path:
            self.last_error = "sdciodll.dll nicht gefunden"
            return False

        try:
            self._dll = ctypes.WinDLL(path)  # __cdecl
        except OSError as ex:
            # Erwartet, wenn DLL/Treiber fehlt oder Architektur nicht passt.
            self.last_error = f"DLL nicht ladbar: {ex}"
            self._dll = None
            return False

        dll = self._dll
        try:
            # Signaturen: verifiziert, siehe Modul-Kopf.
            init_func = getattr(dll, FUNC_DLL_INIT)
            init_func.restype = ctypes.c_int
            init_func.argtypes = []

            free_func = getattr(dll, FUNC_DLL_FREE)
            free_func.restype = ctypes.c_int
            free_func.argtypes = []

            enum_func = getattr(dll, FUNC_ENUMERATE_DIO)
            enum_func.restype = ctypes.c_int
            enum_func.argtypes = [ctypes.c_void_p]

            open_func = getattr(dll, FUNC_DIO_OPEN)
            open_func.restype = ctypes.c_int
            open_func.argtypes = [ctypes.c_int]

            close_func = getattr(dll, FUNC_DIO_CLOSE)
            close_func.restype = ctypes.c_int
            close_func.argtypes = [ctypes.c_int]

            di_func = getattr(dll, FUNC_GET_DI_VALUE)
            di_func.restype = ctypes.c_int
            di_func.argtypes = [ctypes.c_int, ctypes.c_int, ctypes.POINTER(ctypes.c_uint)]
        except AttributeError as ex:
            self.last_error = f"Export fehlt: {ex}"
            self._dll = None
            return False

        # 1) Bibliothek initialisieren
        rc = init_func()
        if rc != STATUS_SUCCESS:
            self.last_error = f"{FUNC_DLL_INIT}() lieferte {rc}"
            self._dll = None
            return False

        # 2) DIO-Karten auflisten (0 Karten -> Mock-Modus, kein Absturz)
        self.dio_index = self.board_id  # Fallback ohne Enumeration
        buf = ctypes.create_string_buffer(DIO_LIST_BUFFER_BYTES)
        rc = enum_func(ctypes.cast(buf, ctypes.c_void_p))
        if rc == STATUS_SUCCESS:
            amount = struct.unpack_from("<I", buf.raw, 0)[0]
            self.card_count = amount
            if amount == 0:
                self.last_error = (
                    f"{FUNC_ENUMERATE_DIO}() ok, aber 0 DIO-Karten erkannt "
                    "(Karte eingebaut? Treiber installiert?)"
                )
                free_func()
                self._dll = None
                return False
            if self.board_id < amount:
                offset = 4 + self.board_id * DIO_LIST_ENTRY_BYTES
                self.dio_index = struct.unpack_from("<i", buf.raw, offset)[0]
        else:
            # Enumeration fehlgeschlagen: mit DioIndex = board_id weiter-
            # versuchen (dio_open entscheidet dann, ob die Karte existiert).
            self.last_error = f"{FUNC_ENUMERATE_DIO}() lieferte {rc} - Fallback DioIndex={self.board_id}"

        # 3) Karte oeffnen
        rc = open_func(self.dio_index)
        if rc != STATUS_SUCCESS:
            self.last_error = f"{FUNC_DIO_OPEN}({self.dio_index}) lieferte {rc}"
            free_func()
            self._dll = None
            return False

        self._di_func = di_func
        self._dio_open_func = open_func
        self._dio_close_func = close_func
        self._free_func = free_func
        self._dio_opened = True
        self.dll_path = path
        self._mock = False
        self.last_error = ""
        return True

    def _find_dll(self) -> Optional[str]:
        """Sucht sdciodll.dll an plausiblen Orten (schnell, ohne C:\\-Scan)."""
        import sys

        candidates: List[str] = []
        base_dirs = []
        if getattr(sys, "frozen", False):
            base_dirs.append(os.path.dirname(os.path.abspath(sys.executable)))
        base_dirs.append(os.path.dirname(os.path.abspath(__file__)))
        base_dirs.append(os.getcwd())
        for folder in base_dirs:
            candidates.append(os.path.join(folder, "sdciodll.dll"))

        sysroot = os.environ.get("SystemRoot", r"C:\Windows")
        candidates.append(os.path.join(sysroot, "System32", "sdciodll.dll"))
        candidates.append(os.path.join(sysroot, "SysWOW64", "sdciodll.dll"))

        for pattern in (
            r"C:\SUNIX\**\sdciodll.dll",
            r"C:\Program Files\SUNIX\**\sdciodll.dll",
            r"C:\Program Files (x86)\SUNIX\**\sdciodll.dll",
            r"C:\Program Files\SDC*\**\sdciodll.dll",
            r"C:\Program Files (x86)\SDC*\**\sdciodll.dll",
        ):
            candidates.extend(glob.glob(pattern, recursive=True))

        for path in candidates:
            if path and os.path.isfile(path):
                return path
        return None

    # -- Lesen -------------------------------------------------------------
    def read_digital_inputs(self) -> List[bool]:
        """Liefert 8 Werte (DI1..DI8); True = vom Treiber als aktiv/1 gemeldet.

        Die elektrische Logik (High/Low bzw. Invertierung) stellt der
        SDC Manager ein - hier wird nur der gelieferte Wert abgebildet:
        ein Portwert != 0 gilt als aktiv (typisch 0/1).
        """
        if self._mock:
            return self._mock_read()

        states = [False] * CHANNEL_COUNT
        failures = 0
        for channel in range(CHANNEL_COUNT):
            port = self.port_base + channel
            value = ctypes.c_uint(0)
            try:
                rc = self._di_func(self.dio_index, port, ctypes.byref(value))
            except Exception as ex:  # noqa: BLE001 - nie abstuerzen
                self.last_error = f"{FUNC_GET_DI_VALUE}() fehlgeschlagen: {ex}"
                self._enter_mock()
                return self._mock_read()
            if rc != STATUS_SUCCESS:
                failures += 1
                self.last_error = f"{FUNC_GET_DI_VALUE}(Port {port}) lieferte {rc}"
            else:
                states[channel] = value.value != 0

        if failures == CHANNEL_COUNT:
            # Karte antwortet gar nicht mehr -> sicher in den Mock-Modus.
            self._enter_mock()
            return self._mock_read()

        return states

    # -- Mock --------------------------------------------------------------
    def _enter_mock(self) -> None:
        self._release_native()
        self._mock = True
        if not self.last_error:
            self.last_error = "unbekannter Fehler - Fallback in Mock-Modus"

    def _release_native(self) -> None:
        if self._dio_opened and self._dll is not None:
            try:
                self._dio_close_func(self.dio_index)
            except Exception:  # noqa: BLE001
                pass
            self._dio_opened = False
        if self._dll is not None:
            try:
                self._free_func()
            except Exception:  # noqa: BLE001
                pass
        self._dll = None

    def _mock_read(self) -> List[bool]:
        """Wanderndes Testmuster: ein Kanal aktiv, DI1 -> DI8 -> DI1."""
        steps = CHANNEL_COUNT * 2 - 2  # 14 Schritte fuer Hin- und Rueckweg
        step = self._mock_step % steps
        channel = step if step < CHANNEL_COUNT else steps - step
        self._mock_step += 1

        states = [False] * CHANNEL_COUNT
        states[channel] = True
        return states

    # -- Aufraeumen --------------------------------------------------------
    def close(self) -> None:
        self._release_native()


if __name__ == "__main__":  # kleine Selbstprobe ohne GUI
    client = SdcIoClient()
    print(client.status_text)
    for _ in range(16):
        states = client.read_digital_inputs()
        print(" ".join("DI%d=%s" % (i + 1, "1" if s else "0") for i, s in enumerate(states)))
        time.sleep(0.1)
    client.close()

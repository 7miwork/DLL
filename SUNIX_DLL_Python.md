# SUNIX sdciodll.dll – Beispiel in Python (ctypes)

## Voraussetzungen
- `sdciodll.dll` (aus dem SUNIX-Treiberpaket) liegt im selben Ordner wie das Python-Skript
  (oder Pfad unten anpassen).
- Architektur beachten: **32-Bit-Python → 32-Bit-DLL**, **64-Bit-Python → 64-Bit-DLL**
  (im Treiberpaket meist unter `x86\` bzw. `x64\`).
- Aus dem Handbuch sind folgende Funktionen bekannt (Kapitel 5, Testprogramm):
  `_sdc_dll_init`, `_sdc_dll_free`, `_sdc_get_service_info`, `_sdc_get_sdc_info`.

> **Hinweis:** Das Handbuch zeigt nur diese vier Funktionsnamen in einem Menü-Testprogramm.
> Die genauen Parameter/Rückgabewerte für Digital-Input-Lesen bzw. Digital-Output-Schreiben
> stehen nicht im vorliegenden Handbuchauszug – dafür bitte in der mitgelieferten
> `sdciodll.h` (C-Header, Teil des SDK) nachsehen und die `argtypes`/`restype` unten
> entsprechend ergänzen, bevor produktiv genutzt wird.

## Beispielcode

```python
import ctypes
import os

# Pfad zur DLL ggf. anpassen
DLL_PATH = os.path.join(os.path.dirname(__file__), "sdciodll.dll")

# DLL laden
sdc = ctypes.WinDLL(DLL_PATH)

# --- Bekannte Funktionen aus dem Handbuch ---
# Die exakten Signaturen (Parameter/Rückgabetyp) sind im Handbuchauszug nicht
# dokumentiert. Als Startpunkt wird hier angenommen, dass keine Parameter
# nötig sind und ein int (Fehlercode) zurückgegeben wird. Bitte mit der
# sdciodll.h abgleichen und ggf. korrigieren.

sdc._sdc_dll_init.restype = ctypes.c_int
sdc._sdc_dll_free.restype = ctypes.c_int
sdc._sdc_get_service_info.restype = ctypes.c_int
sdc._sdc_get_sdc_info.restype = ctypes.c_int


def init_dll():
    """Initialisiert die DLL-Verbindung zum SDC-Dienst."""
    result = sdc._sdc_dll_init()
    print(f"_sdc_dll_init() -> {result}")
    return result


def free_dll():
    """Gibt die DLL-Ressourcen wieder frei."""
    result = sdc._sdc_dll_free()
    print(f"_sdc_dll_free() -> {result}")
    return result


def get_service_info():
    """Liest Informationen zum SDC-Hintergrunddienst."""
    result = sdc._sdc_get_service_info()
    print(f"_sdc_get_service_info() -> {result}")
    return result


def get_sdc_info():
    """Liest Informationen zur installierten I/O-Karte (z.B. SDC4880B)."""
    result = sdc._sdc_get_sdc_info()
    print(f"_sdc_get_sdc_info() -> {result}")
    return result


def main():
    print("=== SUNIX SDC I/O – Python Testmenü ===")
    print("a: DLL Init | b: DLL Free | c: Service Info | d: SDC Info | q: Beenden")

    while True:
        cmd = input("\nCMD: ").strip().lower()
        if cmd == "a":
            init_dll()
        elif cmd == "b":
            free_dll()
        elif cmd == "c":
            get_service_info()
        elif cmd == "d":
            get_sdc_info()
        elif cmd == "q":
            break
        else:
            print("Unbekannter Befehl.")


if __name__ == "__main__":
    main()
```

## Nächste Schritte
- Für konkretes Lesen der Digital-Inputs / Schreiben der Digital-Outputs die
  passenden Funktionen aus `sdciodll.h` (im SDK-Ordner des Treiberpakets) suchen,
  z. B. etwas wie `_sdc_get_di_value(...)` / `_sdc_set_do_value(...)` – Name kann
  je nach SDK-Version abweichen.
- `argtypes` für jede Funktion setzen, sobald die Parametertypen bekannt sind
  (z. B. `ctypes.c_int`, `ctypes.POINTER(ctypes.c_ulong)` für Ausgabewerte per Referenz).
- Bei Fehlermeldungen wie `OSError: [WinError 193]` liegt meist eine
  Architektur-Fehlpassung vor (32-Bit-DLL mit 64-Bit-Python oder umgekehrt).

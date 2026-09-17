# SUNIX sdciodll.dll – Beispiel in C++

## Voraussetzungen (aus Handbuch Kapitel 5)
1. Visual Studio Console-App (C++) anlegen.
2. `sdciodll.h` unter **C/C++ → General → Additional Include Directories** eintragen.
3. `sdciodll.lib` unter **Linker → Input → Additional Dependencies** eintragen.
4. Den Ordner der `sdciodll.lib` unter **Linker → General → Additional Library Directories** eintragen.
5. Unter **Build Events → Post-Build Event → Command Line** die DLL neben die .exe kopieren, z. B.:
   ```
   xcopy /y /d "..\..\sdciodll\$(IntDir)sdciodll.dll" "$(OutDir)"
   ```
6. Architektur (x86/x64) von Projekt und DLL/LIB müssen übereinstimmen.

> **Hinweis:** Das Handbuch zeigt nur ein Testmenü mit vier Funktionsaufrufen
> (`_sdc_dll_init`, `_sdc_dll_free`, `_sdc_get_service_info`, `_sdc_get_sdc_info`).
> Die genauen Funktionssignaturen stehen in `sdciodll.h` im SDK-Ordner des
> Treiberpakets – dort bitte die tatsächlichen Prototypen (Parameter, Rückgabetyp)
> nachsehen, falls sie von der Annahme unten (`int`, keine Parameter) abweichen.

## Beispielcode

```cpp
#include <cstdio>
#include <conio.h>
#include "sdciodll.h"   // aus dem SUNIX SDK

void _PrintCmd()
{
    printf("=== SUNIX SDC I/O - Testmenu ===\n");
    printf("a: DLL Init\n");
    printf("b: DLL Free\n");
    printf("c: Service Info\n");
    printf("d: SDC Info\n");
    printf("q: Beenden\n");
}

int main()
{
    int nReturn = 0;
    int nCmd = 0x00;

    _PrintCmd();

    do
    {
        printf("\nCMD : ");
        nCmd = _getche();
        printf("\n");

        switch (nCmd)
        {
        case 'a': case 'A':
            nReturn = _sdc_dll_init();
            printf("_sdc_dll_init() -> %d\n", nReturn);
            break;

        case 'b': case 'B':
            nReturn = _sdc_dll_free();
            printf("_sdc_dll_free() -> %d\n", nReturn);
            break;

        case 'c': case 'C':
            nReturn = _sdc_get_service_info();
            printf("_sdc_get_service_info() -> %d\n", nReturn);
            break;

        case 'd': case 'D':
            nReturn = _sdc_get_sdc_info();
            printf("_sdc_get_sdc_info() -> %d\n", nReturn);
            break;

        case 'q': case 'Q':
            break;

        default:
            printf("Unbekannter Befehl.\n");
            break;
        }

    } while (nCmd != 'q' && nCmd != 'Q');

    return 0;
}
```

## Nächste Schritte
- Für Digital-Input-Lesen / Digital-Output-Schreiben die entsprechenden Prototypen
  aus `sdciodll.h` verwenden (Name kann je nach SDK-Version abweichen, z. B.
  `_sdc_get_di_value(...)`, `_sdc_set_do_value(...)`).
- Rückgabewerte / Fehlercodes gemäß SDK-Dokumentation prüfen (0 = Erfolg ist bei
  vielen SUNIX-APIs üblich, aber im vorliegenden Handbuchauszug nicht bestätigt).
- Board-ID (z. B. `Board ID: 1` im SDC Manager sichtbar) wird bei Mehrkarten-Systemen
  meist als Parameter benötigt, um die richtige Karte anzusprechen.

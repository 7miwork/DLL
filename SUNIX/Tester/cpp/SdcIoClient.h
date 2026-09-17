#ifndef SDC_IO_CLIENT_H
#define SDC_IO_CLIENT_H

// ---------------------------------------------------------------------------
// SdcIoClient - Abstraktionsschicht um sdciodll.dll (SUNIX SDC0880I)
//
// Regeln (siehe ../../AGENTS.md / ../../.clinerules im Repo):
//  - Alle DLL-Aufrufe nur hier, nie im UI-/Fachcode.
//  - DLL wird DYNAMISCH per LoadLibraryA/GetProcAddress geladen; es wird
//    NICHT gegen sdciodll.lib gelinkt -> kein SUNIX-SDK zur Build-Zeit noetig.
//  - Fehlt die DLL (Entwicklungsmaschine ohne Treiber), schaltet der Client
//    automatisch in den Mock-Modus. Das ist erwartet, kein Bug.
//  - Keine erfundenen Signaturen: Die unten genutzten Funktionen sind
//    VERIFIZIERT (sdciodll.h aus "Windows SDC API V1.0.6.0" im Repo unter
//    SUNIX/Driver/ + Exportliste der sdciodll.dll x86/x64):
//        int  Lib_init(void);
//        int  Lib_free(void);
//        int  SDC_enumerate_dio_info(void* listPtr);
//        int  SDC_dio_open(int DioIndex);
//        int  SDC_dio_close(int DioIndex);
//        int  SDC_get_di_value(int DioIndex, int DiPortNumber, unsigned* v);
//    alle __cdecl, Rueckgabe 0 = STATUS_SUCCESS.
//    Enumerate-Liste: uint32 DioAmount + 256 x {int32 DioIndex; int32
//    Version; int32 PciNumber;} (12 Byte/Eintrag, offizielles VB-Sample).
// ---------------------------------------------------------------------------

#include <string>

class SdcIoClient
{
public:
    static const int kChannelCount = 8;

    SdcIoClient();
    ~SdcIoClient();

    // Oeffnet die DLL (leerer Pfad = automatische Suche). Bei Fehlschlag
    // wird automatisch der Mock-Modus aktiviert (Rueckgabe dann false).
    // boardId = Position der Karte im Mehrkarten-System (0 = erste Karte);
    // portBase = erste DI-Port-Nummer auf der Karte (0 oder 1, Default 0).
    bool Open(const std::string& dllPath, unsigned int boardId, int portBase);

    // Gibt Ressourcen frei (SDC_dio_close + Lib_free, sofern geladen).
    void Close();

    // Liest die 8 digitalen Eingaenge. true = vom Treiber als aktiv (Wert
    // != 0) gemeldet; elektrische Logik/Invertierung stellt der SDC Manager.
    bool ReadDigitalInputs(bool states[kChannelCount]);

    bool IsMock() const { return m_mock; }
    const std::string& StatusText() const { return m_status; }
    const std::string& LastError() const { return m_lastError; }
    std::string HardwareInfo() const;
    unsigned int BoardId() const { return m_boardId; }

private:
    bool TryOpenReal(const std::string& dllPath);
    void EnterMock();
    bool MockRead(bool states[kChannelCount]);

    void* m_hDll;                // HMODULE (void* -> windows.h nicht im Header)
    void* m_pInit;               // Lib_init
    void* m_pFree;               // Lib_free
    void* m_pEnumDio;            // SDC_enumerate_dio_info
    void* m_pDioOpen;            // SDC_dio_open
    void* m_pDioClose;           // SDC_dio_close
    void* m_pReadDi;             // SDC_get_di_value

    std::string m_dllPath;
    std::string m_lastError;
    std::string m_status;
    unsigned int m_boardId;
    int m_portBase;
    int m_dioIndex;              // interner Karten-Index der DLL
    int m_cardCount;             // Anzahl erkannter DIO-Karten
    bool m_dioOpened;
    bool m_mock;
    int m_mockStep;              // Mock-Muster (siehe MockRead)
};

#endif // SDC_IO_CLIENT_H
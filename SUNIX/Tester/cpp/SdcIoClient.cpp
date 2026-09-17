// ---------------------------------------------------------------------------
// SdcIoClient - Implementierung (dynamisches Laden, Mock-Fallback)
//
// Alle hier genutzten Exporte und Signaturen sind VERIFIZIERT:
//  - sdciodll.h aus "Windows SDC API V1.0.6.0_20260617" (Repo: SUNIX/Driver/)
//  - Exportliste der sdciodll.dll (x86/x64 identisch, dumpbin /exports)
// Alle Funktionen sind __cdecl, Rueckgabe 0 = STATUS_SUCCESS.
// ---------------------------------------------------------------------------

#include "SdcIoClient.h"

#include <windows.h>

#include <cstdio>
#include <cstring>
#include <cstdlib>
#include <vector>

// ---------------------------------------------------------------------------
// VERIFIZIERTE Export-Namen
// ---------------------------------------------------------------------------
static const char* const kFuncDllInit = "Lib_init";
static const char* const kFuncDllFree = "Lib_free";
static const char* const kFuncEnumDio = "SDC_enumerate_dio_info";
static const char* const kFuncDioOpen = "SDC_dio_open";
static const char* const kFuncDioClose = "SDC_dio_close";
static const char* const kFuncGetDiValue = "SDC_get_di_value";

// ---------------------------------------------------------------------------
// Signatur-Typen (aus sdciodll.h, verifiziert)
// ---------------------------------------------------------------------------
typedef int(__cdecl* SdcLibInitFunc)();
typedef int(__cdecl* SdcLibFreeFunc)();
typedef int(__cdecl* SdcEnumerateDioFunc)(void* listPtr);
typedef int(__cdecl* SdcDioOpenFunc)(int dioIndex);
typedef int(__cdecl* SdcDioCloseFunc)(int dioIndex);
typedef int(__cdecl* SdcGetDiValueFunc)(int dioIndex, int diPortNumber,
                                        unsigned int* diValue);

namespace
{
bool FileExists(const std::string& path)
{
    DWORD attrs = GetFileAttributesA(path.c_str());
    return attrs != INVALID_FILE_ATTRIBUTES && (attrs & FILE_ATTRIBUTE_DIRECTORY) == 0;
}

// SDC_DIO_BASIC_INFO_LIST: uint32 DioAmount + 256 x 12 Byte Eintraege
// {int32 DioIndex; int32 Version; int32 PciNumber;} (offizielles VB-Sample)
const unsigned int kDioListMaxAmount = 256;
const unsigned int kDioListEntryBytes = 12;
const unsigned int kDioListBufferBytes = 4 + kDioListMaxAmount * kDioListEntryBytes;
const int kStatusSuccess = 0;

int DefaultPortBase()
{
    // DI-Port-Nummerierung: Default 0 (DI1 = Port 0). Per Umgebungsvariable
    // SUNIX_DI_PORT_BASE=1 umschaltbar, falls die Karte 1..8 adressiert.
    const char* env = getenv("SUNIX_DI_PORT_BASE");
    if (env != NULL && env[0] == '1')
    {
        return 1;
    }
    return 0;
}
} // namespace

SdcIoClient::SdcIoClient()
    : m_hDll(NULL),
      m_pInit(NULL),
      m_pFree(NULL),
      m_pEnumDio(NULL),
      m_pDioOpen(NULL),
      m_pDioClose(NULL),
      m_pReadDi(NULL),
      m_boardId(0),
      m_portBase(0),
      m_dioIndex(0),
      m_cardCount(0),
      m_dioOpened(false),
      m_mock(true),
      m_mockStep(0)
{
    m_status = "MOCK-Modus: noch nicht initialisiert";
}

SdcIoClient::~SdcIoClient()
{
    Close();
}

// ---------------------------------------------------------------------------
// Oeffnen
// ---------------------------------------------------------------------------
bool SdcIoClient::Open(const std::string& dllPath, unsigned int boardId, int portBase)
{
    m_boardId = boardId;
    m_portBase = (portBase == 1) ? 1 : 0;

    if (!TryOpenReal(dllPath))
    {
        m_mock = true;
        m_status = "MOCK-Modus: " +
                   (m_lastError.empty() ? std::string("sdciodll.dll nicht gefunden") : m_lastError);
        return false;
    }
    return true;
}

bool SdcIoClient::TryOpenReal(const std::string& dllPath)
{
    std::string path = dllPath;

    if (path.empty())
    {
        const char* envPath = getenv("SUNIX_DLL_PATH");
        if (envPath != NULL && envPath[0] != '\0')
        {
            path = envPath;
        }
    }

    if (path.empty() && FileExists("sdciodll.dll"))
    {
        path = "sdciodll.dll";
    }

    if (path.empty())
    {
        m_lastError = "sdciodll.dll nicht gefunden (Suchpfad: Arbeitsverzeichnis, SUNIX_DLL_PATH)";
        return false;
    }

    HMODULE hDll = LoadLibraryA(path.c_str());
    if (hDll == NULL)
    {
        char buffer[160];
        sprintf_s(buffer, sizeof(buffer), "LoadLibraryA fehlgeschlagen (Fehler %lu) - "
                  "DLL fehlt oder Architektur (x86/x64) passt nicht zur Anwendung",
                  static_cast<unsigned long>(GetLastError()));
        m_lastError = buffer;
        return false;
    }

    m_pInit = reinterpret_cast<void*>(GetProcAddress(hDll, kFuncDllInit));
    m_pFree = reinterpret_cast<void*>(GetProcAddress(hDll, kFuncDllFree));
    m_pEnumDio = reinterpret_cast<void*>(GetProcAddress(hDll, kFuncEnumDio));
    m_pDioOpen = reinterpret_cast<void*>(GetProcAddress(hDll, kFuncDioOpen));
    m_pDioClose = reinterpret_cast<void*>(GetProcAddress(hDll, kFuncDioClose));
    m_pReadDi = reinterpret_cast<void*>(GetProcAddress(hDll, kFuncGetDiValue));

    if (m_pInit == NULL || m_pFree == NULL || m_pEnumDio == NULL ||
        m_pDioOpen == NULL || m_pReadDi == NULL)
    {
        m_lastError = "erwarteter Export fehlt (sdciodll.dll-Version pruefen)";
        FreeLibrary(hDll);
        m_pInit = m_pFree = m_pEnumDio = m_pDioOpen = m_pDioClose = m_pReadDi = NULL;
        return false;
    }

    // 1) Bibliothek initialisieren
    int rc = reinterpret_cast<SdcLibInitFunc>(m_pInit)();
    if (rc != kStatusSuccess)
    {
        char buffer[96];
        sprintf_s(buffer, sizeof(buffer), "%s() lieferte %d", kFuncDllInit, rc);
        m_lastError = buffer;
        FreeLibrary(hDll);
        m_pInit = m_pFree = m_pEnumDio = m_pDioOpen = m_pDioClose = m_pReadDi = NULL;
        return false;
    }

    // 2) DIO-Karten auflisten (0 Karten -> Mock-Modus)
    m_dioIndex = static_cast<int>(m_boardId); // Fallback ohne Enumeration
    m_cardCount = 0;
    std::vector<unsigned char> listBuffer(kDioListBufferBytes, 0);
    rc = reinterpret_cast<SdcEnumerateDioFunc>(m_pEnumDio)(listBuffer.data());
    if (rc == kStatusSuccess)
    {
        unsigned int amount = 0;
        memcpy(&amount, listBuffer.data(), sizeof(amount));
        m_cardCount = static_cast<int>(amount);
        if (amount == 0)
        {
            m_lastError = "keine DIO-Karte erkannt (Karte eingebaut? Treiber installiert?)";
            reinterpret_cast<SdcLibFreeFunc>(m_pFree)();
            FreeLibrary(hDll);
            m_pInit = m_pFree = m_pEnumDio = m_pDioOpen = m_pDioClose = m_pReadDi = NULL;
            return false;
        }
        if (m_boardId < amount)
        {
            int dioIndex = 0;
            memcpy(&dioIndex, listBuffer.data() + 4 + m_boardId * kDioListEntryBytes,
                   sizeof(dioIndex));
            m_dioIndex = dioIndex;
        }
    }
    else
    {
        char buffer[128];
        sprintf_s(buffer, sizeof(buffer), "%s() lieferte %d - Fallback DioIndex=%d",
                  kFuncEnumDio, rc, m_dioIndex);
        m_lastError = buffer;
    }

    // 3) Karte oeffnen
    rc = reinterpret_cast<SdcDioOpenFunc>(m_pDioOpen)(m_dioIndex);
    if (rc != kStatusSuccess)
    {
        char buffer[128];
        sprintf_s(buffer, sizeof(buffer), "%s(%d) lieferte %d", kFuncDioOpen, m_dioIndex, rc);
        m_lastError = buffer;
        reinterpret_cast<SdcLibFreeFunc>(m_pFree)();
        FreeLibrary(hDll);
        m_pInit = m_pFree = m_pEnumDio = m_pDioOpen = m_pDioClose = m_pReadDi = NULL;
        return false;
    }
    m_dioOpened = true;

    char buffer[192];
    sprintf_s(buffer, sizeof(buffer),
              "Echte Hardware: %s | Karte %u von %d (DIO-Index %d) | Ports %d..%d (%s)",
              path.c_str(), m_boardId + 1, m_cardCount, m_dioIndex,
              m_portBase, m_portBase + kChannelCount - 1, kFuncGetDiValue);
    m_hDll = hDll;
    m_dllPath = path;
    m_mock = false;
    m_lastError.clear();
    m_status = buffer;
    return true;
}

// ---------------------------------------------------------------------------
// Schliessen
// ---------------------------------------------------------------------------
void SdcIoClient::Close()
{
    if (m_hDll != NULL)
    {
        if (m_dioOpened && m_pDioClose != NULL)
        {
            reinterpret_cast<SdcDioCloseFunc>(m_pDioClose)(m_dioIndex);
            m_dioOpened = false;
        }
        if (m_pFree != NULL)
        {
            reinterpret_cast<SdcLibFreeFunc>(m_pFree)();
        }
        FreeLibrary(reinterpret_cast<HMODULE>(m_hDll));
        m_hDll = NULL;
    }
    m_pInit = NULL;
    m_pFree = NULL;
    m_pEnumDio = NULL;
    m_pDioOpen = NULL;
    m_pDioClose = NULL;
    m_pReadDi = NULL;
}

// ---------------------------------------------------------------------------
// Lesen
// ---------------------------------------------------------------------------
bool SdcIoClient::ReadDigitalInputs(bool states[kChannelCount])
{
    if (m_mock)
    {
        return MockRead(states);
    }

    int failures = 0;
    for (int i = 0; i < kChannelCount; ++i)
    {
        states[i] = false;
        unsigned int value = 0;
        int rc = reinterpret_cast<SdcGetDiValueFunc>(m_pReadDi)(
            m_dioIndex, m_portBase + i, &value);
        if (rc != kStatusSuccess)
        {
            ++failures;
            char buffer[128];
            sprintf_s(buffer, sizeof(buffer), "%s(Port %d) lieferte %d",
                      kFuncGetDiValue, m_portBase + i, rc);
            m_lastError = buffer;
        }
        else
        {
            states[i] = (value != 0);
        }
    }

    if (failures == kChannelCount)
    {
        EnterMock(); // Karte antwortet gar nicht mehr -> Mock-Fallback (Pflicht)
        return MockRead(states);
    }
    return true;
}

std::string SdcIoClient::HardwareInfo() const
{
    if (m_mock)
    {
        return "MOCK - keine Karte erkannt";
    }

    char buffer[64];
    sprintf_s(buffer, sizeof(buffer), "echte Hardware (Board-ID %u)", m_boardId);
    return buffer;
}

void SdcIoClient::EnterMock()
{
    Close();
    m_mock = true;
    m_status = "MOCK-Modus: " + m_lastError;
}

bool SdcIoClient::MockRead(bool states[kChannelCount])
{
    // Wanderndes Testmuster: ein Kanal aktiv, DI1 -> DI8 -> DI1.
    const int steps = kChannelCount * 2 - 2; // 14
    const int step = m_mockStep % steps;
    const int channel = (step < kChannelCount) ? step : (steps - step);
    ++m_mockStep;

    for (int i = 0; i < kChannelCount; ++i)
    {
        states[i] = (i == channel);
    }
    return true;
}
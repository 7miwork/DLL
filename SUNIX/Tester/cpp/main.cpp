// ---------------------------------------------------------------------------
// main.cpp - Konsolen-UI des DI-Testers (SUNIX SDC4880B / SDC0880I)
//
// Zeigt die 8 digitalen Eingaenge DI1..DI8 als farbige Bloecke an:
//   gruen = vom Treiber als aktiv/1 gemeldet, grau = inaktiv (Polling 250 ms).
// Die elektrische Logik (High/Low, Invertierung) wird NICHT hier ausgewertet;
// das stellt man im SDC Manager ein.
//
// Aufruf:
//   DI_Tester.exe                    (Auto: echte DLL, sonst Mock)
//   DI_Tester.exe --mock             (Mock erzwingen)
//   DI_Tester.exe --board-id 1       (Mehrkarten-Systeme)
//   DI_Tester.exe --dll C:\...\sdciodll.dll
//   DI_Tester.exe --interval 250     (Polling-Intervall in ms)
//   DI_Tester.exe --selftest 3       (headless Selbsttest, 3 Sekunden)
// ---------------------------------------------------------------------------

#include "SdcIoClient.h"

#include <windows.h>

#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <string>

namespace
{

const WORD kAttrReset = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE;
const WORD kAttrActive = FOREGROUND_GREEN | FOREGROUND_INTENSITY;
const WORD kAttrInactive = FOREGROUND_INTENSITY;
const WORD kAttrHeader = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE | FOREGROUND_INTENSITY;
const WORD kAttrMock = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_INTENSITY; // gelb

const size_t kLineWidth = 84;

void SetColor(HANDLE hOut, WORD attributes)
{
    SetConsoleTextAttribute(hOut, attributes);
}

// Schreibt eine Zeile und fuellt sie mit Leerzeichen auf, damit beim
// Neuzeichnen keine Reste der vorherigen Anzeige stehen bleiben.
void PrintPaddedLine(HANDLE hOut, WORD attributes, const std::string& text)
{
    std::string padded = text;
    if (padded.size() < kLineWidth)
    {
        padded.append(kLineWidth - padded.size(), ' ');
    }
    SetColor(hOut, attributes);
    printf("%s\n", padded.c_str());
    SetColor(hOut, kAttrReset);
}

std::string Fit(const std::string& text)
{
    if (text.size() <= kLineWidth)
    {
        return text;
    }
    return text.substr(0, kLineWidth - 3) + "...";
}

std::string ModeSuffix(const SdcIoClient& client)
{
    return client.IsMock() ? "MOCK - keine Karte erkannt" : client.HardwareInfo();
}

void DrawFrame(HANDLE hOut, const SdcIoClient& client, const bool states[SdcIoClient::kChannelCount],
               int intervalMs)
{
    COORD origin = {0, 0};
    SetConsoleCursorPosition(hOut, origin);

    std::string title = "SUNIX DI-Tester  -  " + ModeSuffix(client);
    PrintPaddedLine(hOut, client.IsMock() ? kAttrMock : kAttrActive, Fit(title));
    PrintPaddedLine(hOut, kAttrHeader, Fit(client.StatusText()));
    PrintPaddedLine(hOut, kAttrReset, "");

    for (int i = 0; i < SdcIoClient::kChannelCount; ++i)
    {
        std::string bar;
        for (int block = 0; block < 10; ++block)
        {
            bar += states[i] ? '#' : '.';
        }
        char line[128];
        sprintf_s(line, sizeof(line), "   DI%d   [ %s ]   %-7s", i + 1, bar.c_str(),
                  states[i] ? "AKTIV" : "inaktiv");
        PrintPaddedLine(hOut, states[i] ? kAttrActive : kAttrInactive, line);
    }

    PrintPaddedLine(hOut, kAttrReset, "");
    char footer[160];
    sprintf_s(footer, sizeof(footer), "   Polling: %d ms        Beenden: Strg+C", intervalMs);
    PrintPaddedLine(hOut, kAttrHeader, footer);
    PrintPaddedLine(hOut, kAttrHeader,
                    "   Hinweis: High/Low-Logik (Invert) wird im SDC Manager eingestellt.");
}

int RunSelfTest(SdcIoClient& client, double seconds)
{
    printf("Selbsttest gestartet: %s\n", client.StatusText().c_str());

    int samples = 0;
    char active[64] = "";
    DWORD start = GetTickCount();
    const DWORD durationMs = static_cast<DWORD>((seconds > 0.0 ? seconds : 2.0) * 1000.0);

    while (GetTickCount() - start < durationMs)
    {
        bool states[SdcIoClient::kChannelCount];
        client.ReadDigitalInputs(states);

        std::string line;
        for (int i = 0; i < SdcIoClient::kChannelCount; ++i)
        {
            char part[16];
            sprintf_s(part, sizeof(part), "DI%d=%d ", i + 1, states[i] ? 1 : 0);
            line += part;
            if (states[i])
            {
                char name[8];
                sprintf_s(name, sizeof(name), "DI%d ", i + 1);
                if (strstr(active, name) == NULL && strlen(active) + strlen(name) < sizeof(active) - 1)
                {
                    strcat_s(active, sizeof(active), name);
                }
            }
        }
        printf("%s\n", line.c_str());
        ++samples;
        Sleep(250);
    }

    client.Close();
    printf("Selbsttest beendet: %d Messungen, aktive Kanaele gesehen: %s\n",
           samples, active[0] != '\0' ? active : "keine");
    return 0;
}

void PrintUsage()
{
    printf("Aufruf: DI_Tester.exe [--mock] [--board-id N] [--port-base N] [--dll PFAD] "
           "[--interval MS] [--selftest [SEKUNDEN]]\n");
}

} // namespace

int main(int argc, char** argv)
{
    std::string dllPath;
    unsigned int boardId = 0;
    int portBase = 0;
    int intervalMs = 250;
    bool forceMock = false;
    bool selftest = false;
    double selftestSeconds = 2.0;

    for (int i = 1; i < argc; ++i)
    {
        const char* arg = argv[i];
        if (_stricmp(arg, "--mock") == 0)
        {
            forceMock = true;
        }
        else if (_stricmp(arg, "--board-id") == 0 && i + 1 < argc)
        {
            int parsedBoardId = atoi(argv[++i]);
            boardId = (parsedBoardId < 0) ? 0u : static_cast<unsigned int>(parsedBoardId);
        }
        else if (_stricmp(arg, "--port-base") == 0 && i + 1 < argc)
        {
            portBase = atoi(argv[++i]); // 0 oder 1 (DI-Port-Nummerierung)
        }
        else if (_stricmp(arg, "--dll") == 0 && i + 1 < argc)
        {
            dllPath = argv[++i];
        }
        else if (_stricmp(arg, "--interval") == 0 && i + 1 < argc)
        {
            intervalMs = atoi(argv[++i]);
            if (intervalMs < 50)
            {
                intervalMs = 50;
            }
        }
        else if (_stricmp(arg, "--selftest") == 0)
        {
            selftest = true;
            if (i + 1 < argc && argv[i + 1][0] != '-')
            {
                selftestSeconds = atof(argv[++i]);
            }
        }
        else if (_stricmp(arg, "--help") == 0 || _stricmp(arg, "-h") == 0)
        {
            PrintUsage();
            return 0;
        }
    }

    SdcIoClient client;
    if (forceMock)
    {
        printf("Hinweis: --mock gesetzt - es wird keine DLL geladen.\n");
    }
    else if (!client.Open(dllPath, boardId, portBase))
    {
        // Erwartet auf Entwicklungsmaschinen ohne Karte/Treiber - kein Fehler.
        printf("Hinweis: echte sdciodll.dll nicht verfuegbar - Mock-Modus aktiv.\n");
    }
    printf("%s\n", client.StatusText().c_str());

    if (selftest)
    {
        return RunSelfTest(client, selftestSeconds);
    }

    HANDLE hOut = GetStdHandle(STD_OUTPUT_HANDLE);
    if (hOut == INVALID_HANDLE_VALUE || hOut == NULL)
    {
        printf("Fehler: keine Konsole verfuegbar (Ausgabe umgeleitet?).\n");
        return 1;
    }

    system("cls");
    bool states[SdcIoClient::kChannelCount];
    for (;;)
    {
        client.ReadDigitalInputs(states);
        DrawFrame(hOut, client, states, intervalMs);
        Sleep(static_cast<DWORD>(intervalMs));
    }
}
# SUNIX sdciodll.dll – Beispiel in Visual Basic (.NET)

## Voraussetzungen
- `sdciodll.dll` (aus dem SUNIX-Treiberpaket) liegt im Ausgabeordner der Anwendung
  (`bin\Debug` bzw. `bin\Release`) oder wird per Post-Build-Event dorthin kopiert.
- Architektur des VB.NET-Projekts (Project → Properties → Compile → Advanced Compile
  Options → Target CPU) muss zur DLL passen: **x86** für die 32-Bit-DLL,
  **x64** für die 64-Bit-DLL (nicht "Any CPU" verwenden, sonst evtl. `BadImageFormatException`).
- Aus dem Handbuch bekannte Funktionen: `_sdc_dll_init`, `_sdc_dll_free`,
  `_sdc_get_service_info`, `_sdc_get_sdc_info`.

> **Hinweis:** Wie bei den anderen Sprachen gilt: Das Handbuch dokumentiert nur diese
> vier Funktionsnamen in einem Testmenü. Für Digital-I/O-Lesen/Schreiben bitte die
> genauen Deklarationen aus `sdciodll.h` (SDK-Ordner) übernehmen und unten anpassen.

## Beispielcode (Konsolen-App, VB.NET)

```vb
Imports System.Runtime.InteropServices

Module SdcTest

    ' --- DLL-Importe ---
    ' Rückgabetyp/Parameter sind im Handbuchauszug nicht dokumentiert;
    ' hier als Integer ohne Parameter angenommen - bitte mit sdciodll.h abgleichen.

    <DllImport("sdciodll.dll")>
    Private Function _sdc_dll_init() As Integer
    End Function

    <DllImport("sdciodll.dll")>
    Private Function _sdc_dll_free() As Integer
    End Function

    <DllImport("sdciodll.dll")>
    Private Function _sdc_get_service_info() As Integer
    End Function

    <DllImport("sdciodll.dll")>
    Private Function _sdc_get_sdc_info() As Integer
    End Function

    Sub PrintCmd()
        Console.WriteLine("=== SUNIX SDC I/O - Testmenue ===")
        Console.WriteLine("a: DLL Init")
        Console.WriteLine("b: DLL Free")
        Console.WriteLine("c: Service Info")
        Console.WriteLine("d: SDC Info")
        Console.WriteLine("q: Beenden")
    End Sub

    Sub Main()
        Dim nReturn As Integer
        Dim cmd As String

        PrintCmd()

        Do
            Console.Write(vbCrLf & "CMD : ")
            cmd = Console.ReadLine().Trim().ToLower()

            Select Case cmd
                Case "a"
                    nReturn = _sdc_dll_init()
                    Console.WriteLine($"_sdc_dll_init() -> {nReturn}")
                Case "b"
                    nReturn = _sdc_dll_free()
                    Console.WriteLine($"_sdc_dll_free() -> {nReturn}")
                Case "c"
                    nReturn = _sdc_get_service_info()
                    Console.WriteLine($"_sdc_get_service_info() -> {nReturn}")
                Case "d"
                    nReturn = _sdc_get_sdc_info()
                    Console.WriteLine($"_sdc_get_sdc_info() -> {nReturn}")
                Case "q"
                    Exit Do
                Case Else
                    Console.WriteLine("Unbekannter Befehl.")
            End Select

        Loop While cmd <> "q"

    End Sub

End Module
```

## Nächste Schritte
- Für Digital-Input/-Output entsprechende `DllImport`-Deklarationen aus der
  `sdciodll.h` übernehmen (Name kann je nach SDK-Version abweichen, z. B.
  `_sdc_get_di_value(...)`, `_sdc_set_do_value(...)`).
- Bei Parametern per Referenz (`out`-Werte) in C `unsigned long* pValue` → in VB.NET
  `ByRef pValue As UInteger` verwenden.
- Bei `BadImageFormatException`: Target CPU des Projekts (x86/x64) prüfen, muss zur
  DLL-Architektur passen.

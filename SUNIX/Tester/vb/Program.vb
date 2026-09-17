' ---------------------------------------------------------------------------
' Program.vb - Einstiegspunkt des VB.NET-DI-Testers
'
' Aufruf:
'   DI_Tester.exe                    (Auto: echte DLL, sonst Mock)
'   DI_Tester.exe --mock             (Mock erzwingen)
'   DI_Tester.exe --board-id 1       (Mehrkarten-Systeme)
'   DI_Tester.exe --dll C:\...\sdciodll.dll
'   DI_Tester.exe --selftest 3       (headless Selbsttest, 3 Sekunden;
'                                     Ergebnis in %TEMP%\di_tester_vb_selftest.txt,
'                                     da eine WinExe kein Konsolenfenster hat)
' ---------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Module Program

    <STAThread>
    Sub Main(ByVal args As String())
        Dim boardId As UInteger = 0UI
        Dim dllPath As String = Nothing
        Dim forceMock As Boolean = False
        Dim selftest As Boolean = False
        Dim selftestSeconds As Double = 2.0

        Dim index As Integer = 0
        While index < args.Length
            Select Case args(index).ToLowerInvariant()
                Case "--mock"
                    forceMock = True

                Case "--board-id"
                    If index + 1 < args.Length Then
                        Dim parsed As Integer
                        If Integer.TryParse(args(index + 1), parsed) AndAlso parsed > 0 Then
                            boardId = CUInt(parsed)
                        End If
                        index += 1
                    End If

                Case "--dll"
                    If index + 1 < args.Length Then
                        dllPath = args(index + 1)
                        index += 1
                    End If

                Case "--selftest"
                    selftest = True
                    If index + 1 < args.Length AndAlso Not args(index + 1).StartsWith("-") Then
                        Dim seconds As Double
                        If Double.TryParse(args(index + 1), seconds) AndAlso seconds > 0.0 Then
                            selftestSeconds = seconds
                        End If
                        index += 1
                    End If
            End Select
            index += 1
        End While

        Try
            Using client As New SdcIoClient(boardId, dllPath, forceMock)
                If selftest Then
                    Environment.ExitCode = RunSelfTest(client, selftestSeconds)
                    Return
                End If

                Application.EnableVisualStyles()
                Application.SetCompatibleTextRenderingDefault(False)
                Application.Run(New Form1(client))
            End Using
        Catch ex As Exception
            ' Letzte Absicherung: nie mit unbehandelter Exception enden.
            Try
                File.WriteAllText(SelfTestLogPath(), "Unerwarteter Fehler: " & ex.ToString())
            Catch
                ' Logdatei nicht schreibbar - dann eben ohne Protokoll.
            End Try
            Environment.ExitCode = 1
        End Try
    End Sub

    Friend Function SelfTestLogPath() As String
        Return Path.Combine(Path.GetTempPath(), "di_tester_vb_selftest.txt")
    End Function

    ''' <summary>Liest einige Sekunden lang Werte und protokolliert sie.</summary>
    Private Function RunSelfTest(ByVal client As SdcIoClient, ByVal seconds As Double) As Integer
        Dim log As New StringBuilder()
        log.AppendLine("Selbsttest gestartet: " & client.StatusText)

        Dim samples As Integer = 0
        Dim seen As New List(Of Integer)()
        Dim duration As Double = If(seconds > 0.0, seconds, 2.0)
        Dim deadline As DateTime = DateTime.UtcNow.AddSeconds(duration)

        While DateTime.UtcNow < deadline
            Dim states() As Boolean = client.ReadDigitalInputs()
            Dim line As New StringBuilder()
            For channel As Integer = 0 To states.Length - 1
                line.Append(If(states(channel), "1 ", "0 "))
                If states(channel) AndAlso Not seen.Contains(channel + 1) Then
                    seen.Add(channel + 1)
                End If
            Next
            log.AppendLine(line.ToString().TrimEnd())
            samples += 1
            System.Threading.Thread.Sleep(250)
        End While

        Dim names As New List(Of String)()
        For Each channel As Integer In seen
            names.Add("DI" & channel.ToString())
        Next

        Dim summary As String = "Selbsttest beendet: " & samples.ToString() & " Messungen, aktive Kanaele gesehen: " &
                                If(names.Count > 0, String.Join(", ", names), "keine")
        log.AppendLine(summary)
        File.WriteAllText(SelfTestLogPath(), log.ToString())

        Return 0
    End Function

End Module
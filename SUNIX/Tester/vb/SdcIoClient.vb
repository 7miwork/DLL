' ---------------------------------------------------------------------------
' SdcIoClient.vb - Abstraktionsschicht um sdciodll.dll (SUNIX SDC0880I)
'
' Regeln (siehe ../../AGENTS.md / ../../.clinerules im Repo):
'  - Alle DLL-Aufrufe nur hier, nie im UI-Code.
'  - DllImport bindet erst zur LAUFZEIT -> das Projekt kompiliert auch ohne
'    installiertes SUNIX-SDK. Jeder Aufruf ist gegen DllNotFoundException /
'    EntryPointNotFoundException (und sonstige Fehler) abgesichert; bei einem
'    Fehler schaltet der Client automatisch in den Mock-Modus.
'  - Keine erfundenen Signaturen: alle unten genutzten Funktionen sind
'    VERIFIZIERT (sdciodll.h aus "Windows SDC API V1.0.6.0" im Repo unter
'    SUNIX/Driver/ + Exportliste der sdciodll.dll x86/x64):
'        int  Lib_init(void);
'        int  Lib_free(void);
'        int  SDC_enumerate_dio_info(PSDC_DIO_BASIC_INFO_LIST listPtr);
'        int  SDC_dio_open(int DioIndex);
'        int  SDC_dio_close(int DioIndex);
'        int  SDC_get_di_value(int DioIndex, int DiPortNumber, uint* value);
'    alle __cdecl, Rueckgabe 0 = STATUS_SUCCESS.
'    SDC_DIO_BASIC_INFO_LIST = uint32 DioAmount + 256 x {int32 DioIndex;
'    int32 Version; int32 PciNumber;} (12 Byte/Eintrag - identisch zum
'    offiziellen Hersteller-Sample "SdcDioBasicInfo(List).vb").
' ---------------------------------------------------------------------------

Imports System
Imports System.Runtime.InteropServices

''' <summary>Liest die 8 digitalen Eingaenge, mit automatischem Mock-Fallback.</summary>
Public Class SdcIoClient
    Implements IDisposable

    Public Const ChannelCount As Integer = 8

    Private Const DllName As String = "sdciodll.dll"

    ' VERIFIZIERTE Export-Namen und Konstanten (siehe Klassenkopf)
    Private Const FuncDllInit As String = "Lib_init"
    Private Const FuncDllFree As String = "Lib_free"
    Private Const FuncEnumerateDio As String = "SDC_enumerate_dio_info"
    Private Const FuncDioOpen As String = "SDC_dio_open"
    Private Const FuncDioClose As String = "SDC_dio_close"
    Private Const FuncGetDiValue As String = "SDC_get_di_value"

    Private Const StatusSuccess As Integer = 0
    Private Const DioListMaxAmount As Integer = 256
    Private Const DioListEntryBytes As Integer = 12 ' DioIndex, Version, PciNumber
    Private ReadOnly DioListBufferBytes As Integer = 4 + DioListMaxAmount * DioListEntryBytes

    <DllImport(DllName, EntryPoint:=FuncDllInit, CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function NativeDllInit() As Integer
    End Function

    <DllImport(DllName, EntryPoint:=FuncDllFree, CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function NativeDllFree() As Integer
    End Function

    <DllImport(DllName, EntryPoint:=FuncEnumerateDio, CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function NativeEnumerateDio(ByVal listPtr As IntPtr) As Integer
    End Function

    <DllImport(DllName, EntryPoint:=FuncDioOpen, CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function NativeDioOpen(ByVal dioIndex As Integer) As Integer
    End Function

    <DllImport(DllName, EntryPoint:=FuncDioClose, CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function NativeDioClose(ByVal dioIndex As Integer) As Integer
    End Function

    <DllImport(DllName, EntryPoint:=FuncGetDiValue, CallingConvention:=CallingConvention.Cdecl)>
    Private Shared Function NativeGetDiValue(ByVal dioIndex As Integer,
                                             ByVal diPortNumber As Integer,
                                             ByRef diValue As UInteger) As Integer
    End Function

    Private Shared _resolverInstalled As Boolean

    Private ReadOnly _boardId As UInteger
    Private ReadOnly _dllPath As String
    Private ReadOnly _portBase As Integer
    Private _dioIndex As Integer
    Private _cardCount As Integer
    Private _dioOpened As Boolean
    Private _mock As Boolean = True
    Private _loaded As Boolean
    Private _lastError As String = ""
    Private _mockStep As Integer

    ''' <param name="boardId">Position der Karte im Mehrkarten-System (Default 0 = erste Karte).</param>
    ''' <param name="dllPath">Optionaler Pfad zur sdciodll.dll.</param>
    ''' <param name="forceMock">True = Mock-Modus erzwingen (keine DLL laden).</param>
    ''' <param name="portBase">Erste DI-Port-Nummer auf der Karte (0 oder 1, Default 0).</param>
    Public Sub New(Optional ByVal boardId As UInteger = 0UI,
                   Optional ByVal dllPath As String = Nothing,
                   Optional ByVal forceMock As Boolean = False,
                   Optional ByVal portBase As Integer = 0)
        _boardId = boardId
        _dllPath = dllPath
        _portBase = If(portBase = 1, 1, 0)

        If forceMock Then
            _lastError = "Mock-Modus erzwungen (--mock)"
            Return
        End If
        TryOpenReal()
    End Sub

    ' -- Status ------------------------------------------------------------
    Public ReadOnly Property IsMock As Boolean
        Get
            Return _mock
        End Get
    End Property

    Public ReadOnly Property LastError As String
        Get
            Return _lastError
        End Get
    End Property

    Public ReadOnly Property HardwareInfo As String
        Get
            If _mock Then
                Return "MOCK - keine Karte erkannt"
            End If
            Return String.Format("echte Hardware (Karte {0} von {1}, DIO-Index {2})",
                                 _boardId + 1UI, _cardCount, _dioIndex)
        End Get
    End Property

    Public ReadOnly Property StatusText As String
        Get
            If _mock Then
                Dim reason As String = _lastError
                If String.IsNullOrEmpty(reason) Then
                    reason = "sdciodll.dll nicht gefunden/initialisierbar"
                End If
                Return "MOCK-Modus: " & reason
            End If
            Return String.Format("Echte Hardware: {0} | {1} | Ports {2}..{3} ({4})",
                                 If(_dllPath, DllName), HardwareInfo,
                                 _portBase, _portBase + ChannelCount - 1, FuncGetDiValue)
        End Get
    End Property

    ' -- DLL laden ---------------------------------------------------------
    ''' <summary>
    ''' Setzt (nur wenn --dll mit Pfad angegeben wurde) einen Resolver, damit
    ''' DllImport die DLL auch aus einem beliebigen Ordner findet.
    ''' </summary>
    Private Sub InstallResolver(ByVal path As String)
        If _resolverInstalled Then
            Return
        End If

        Try
            NativeLibrary.SetDllImportResolver(GetType(SdcIoClient).Assembly,
                Function(libraryName As String, assembly As Reflection.Assembly,
                         searchPath As DllImportSearchPath?) As IntPtr
                    If String.Equals(libraryName, DllName, StringComparison.OrdinalIgnoreCase) Then
                        Dim resolved As IntPtr
                        If NativeLibrary.TryLoad(path, resolved) Then
                            Return resolved
                        End If
                    End If
                    Return IntPtr.Zero
                End Function)
            _resolverInstalled = True
        Catch ex As InvalidOperationException
            ' Resolver war bereits gesetzt - dann gilt die Standard-Suche.
        End Try
    End Sub

    Private Sub TryOpenReal()
        ' Erwartet auf Entwicklungsmaschinen ohne Treiber: DLL fehlt -> Mock.
        Dim handle As IntPtr = IntPtr.Zero
        Dim loaded As Boolean

        Try
            If Not String.IsNullOrEmpty(_dllPath) Then
                InstallResolver(_dllPath)
                loaded = NativeLibrary.TryLoad(_dllPath, handle)
            Else
                loaded = NativeLibrary.TryLoad(DllName, GetType(SdcIoClient).Assembly, Nothing, handle)
            End If
        Catch ex As Exception
            _lastError = "DLL nicht ladbar: " & ex.Message
            Return
        End Try

        If Not loaded Then
            _lastError = "sdciodll.dll nicht gefunden (Arbeitsverzeichnis, PATH oder --dll)"
            Return
        End If

        ' Exporte pruefen, OHNE sie aufzurufen - so kann ein falscher Name
        ' nicht zu einem Absturz fuehren.
        Dim address As IntPtr
        For Each funcName As String In New String() {
                FuncDllInit, FuncDllFree, FuncEnumerateDio,
                FuncDioOpen, FuncDioClose, FuncGetDiValue}
            If Not NativeLibrary.TryGetExport(handle, funcName, address) Then
                _lastError = "Export " & funcName & " fehlt (sdciodll.dll-Version pruefen)"
                NativeLibrary.Free(handle)
                Return
            End If
        Next

        ' Die eigentlichen Aufrufe laufen ueber DllImport; das Pruef-Handle
        ' wird daher sofort wieder freigegeben.
        NativeLibrary.Free(handle)

        Try
            ' 1) Bibliothek initialisieren
            Dim rc As Integer = NativeDllInit()
            If rc <> StatusSuccess Then
                _lastError = String.Format("{0}() lieferte {1}", FuncDllInit, rc)
                Return
            End If

            ' 2) DIO-Karten auflisten (0 Karten -> Mock-Modus)
            _dioIndex = CInt(_boardId) ' Fallback ohne Enumeration
            _cardCount = 0
            Dim buffer(DioListBufferBytes - 1) As Byte
            Dim pinned As GCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned)
            Try
                rc = NativeEnumerateDio(pinned.AddrOfPinnedObject())
            Finally
                pinned.Free()
            End Try

            If rc = StatusSuccess Then
                _cardCount = BitConverter.ToInt32(buffer, 0)
                If _cardCount = 0 Then
                    _lastError = "keine DIO-Karte erkannt (Karte eingebaut? Treiber installiert?)"
                    NativeDllFree()
                    Return
                End If
                If _boardId < CUInt(_cardCount) Then
                    _dioIndex = BitConverter.ToInt32(buffer, 4 + CInt(_boardId) * DioListEntryBytes)
                End If
            Else
                _lastError = String.Format("{0}() lieferte {1} - Fallback DioIndex={2}",
                                           FuncEnumerateDio, rc, _dioIndex)
            End If

            ' 3) Karte oeffnen
            rc = NativeDioOpen(_dioIndex)
            If rc <> StatusSuccess Then
                _lastError = String.Format("{0}({1}) lieferte {2}", FuncDioOpen, _dioIndex, rc)
                NativeDllFree()
                Return
            End If

            _dioOpened = True
            _mock = False
            _loaded = True
            _lastError = ""
        Catch ex As DllNotFoundException
            _lastError = "DLL nicht gefunden: " & ex.Message
        Catch ex As EntryPointNotFoundException
            _lastError = "Export fehlt: " & ex.Message
        Catch ex As BadImageFormatException
            _lastError = "falsche Architektur (x86/x64): " & ex.Message
        Catch ex As Exception
            _lastError = ex.Message
        End Try
    End Sub

    ' -- Lesen -------------------------------------------------------------
    ''' <summary>
    ''' Liefert 8 Werte (DI1..DI8); True = vom Treiber als aktiv gemeldet
    ''' (Portwert != 0). Die elektrische Logik (High/Low bzw. Invertierung)
    ''' wird im SDC Manager eingestellt - hier wird nur der gelieferte Wert
    ''' abgebildet.
    ''' </summary>
    Public Function ReadDigitalInputs() As Boolean()
        If _mock Then
            Return MockRead()
        End If

        Dim states(ChannelCount - 1) As Boolean
        Dim failures As Integer = 0

        Try
            For index As Integer = 0 To ChannelCount - 1
                Dim value As UInteger = 0UI
                Dim rc As Integer = NativeGetDiValue(_dioIndex, _portBase + index, value)
                If rc <> StatusSuccess Then
                    failures += 1
                    _lastError = String.Format("{0}(Port {1}) lieferte {2}",
                                               FuncGetDiValue, _portBase + index, rc)
                Else
                    states(index) = (value <> 0UI)
                End If
            Next
        Catch ex As DllNotFoundException
            _lastError = "DLL nicht gefunden: " & ex.Message
        Catch ex As EntryPointNotFoundException
            _lastError = "Export " & FuncGetDiValue & " fehlt: " & ex.Message
        Catch ex As BadImageFormatException
            _lastError = "falsche Architektur (x86/x64): " & ex.Message
        Catch ex As Exception
            _lastError = ex.Message
        End Try

        If failures = ChannelCount Then
            ' Karte antwortet gar nicht mehr -> Mock-Fallback (Pflicht: nie abstuerzen).
            EnterMock()
            Return MockRead()
        End If
        Return states
    End Function

    Private Sub EnterMock()
        DisposeNative()
        _mock = True
    End Sub

    ''' <summary>Wanderndes Testmuster: ein Kanal aktiv, DI1 -> DI8 -> DI1.</summary>
    Private Function MockRead() As Boolean()
        Dim stepCount As Integer = ChannelCount * 2 - 2 ' 14 Schritte (hin + zurueck)
        Dim stepIndex As Integer = _mockStep Mod stepCount
        Dim channel As Integer = If(stepIndex < ChannelCount, stepIndex, stepCount - stepIndex)
        _mockStep += 1

        Dim states(ChannelCount - 1) As Boolean
        states(channel) = True
        Return states
    End Function

    ' -- Aufraeumen --------------------------------------------------------
    Private Sub DisposeNative()
        If Not _loaded Then
            Return
        End If
        Try
            If _dioOpened Then
                NativeDioClose(_dioIndex)
                _dioOpened = False
            End If
            NativeDllFree()
        Catch ex As Exception
            ' Aufraeumen darf nicht werfen (Tabelle nicht geladen o. Ae.)
        End Try
        _loaded = False
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        DisposeNative()
    End Sub
End Class
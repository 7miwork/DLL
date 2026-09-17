Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Acquisition.Imaqdx
Imports NationalInstruments.Vision.Analysis
Imports Automation.BDaq
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Windows.Forms
Imports System.Runtime
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class A_FormMain
  Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" _
                                              (ByVal lpApplicationName As String, _
                                               ByVal lpKeyName As String, _
                                               ByVal lpDefault As String, _
                                               ByVal lpReturnedString As String, _
                                               ByVal nSize As Int32, _
                                               ByVal lpFileName As String) As Int32
  Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" _
                                              (ByVal lpApplicationName As String, _
                                               ByVal lpKeyName As String, _
                                               ByVal lpString As String, _
                                               ByVal lpFileName As String) As Int32

  Private Const LTDLL_NAME As String = "FyMfcDll.dll"
  <DllImport(LTDLL_NAME, CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Ansi, EntryPoint:="NewImageView")> _
  Public Shared Function NewImageView(ByVal hParentWnd As IntPtr) As IntPtr
  End Function
  <DllImport(LTDLL_NAME, CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Ansi, EntryPoint:="SetImage")> _
  Public Shared Function SetImage(ByVal MyIntPtr As IntPtr, ByVal ImagePath As String) As Boolean
  End Function
  <DllImport(LTDLL_NAME, CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Ansi, EntryPoint:="SetParameter")> _
  Public Shared Function SetParameter(ByVal MyIntPtr As IntPtr, ByVal In_CenterX As Single, ByVal In_CenterY As Single, ByVal In_Tolerance As Single, ByVal In_Diameter As Single, ByVal In_CircleInward As Integer, ByVal In_Type As Integer, ByVal In_Choice As Integer, ByVal In_Threshold As Integer, ByVal In_SamplingStep As Integer, ByVal In_LineThreshold As Integer) As Boolean
  End Function
  <DllImport(LTDLL_NAME, CallingConvention:=CallingConvention.Cdecl, CharSet:=CharSet.Ansi, EntryPoint:="Measure")> _
  Public Shared Function Measure(ByVal MyIntPtr As IntPtr, ByVal In_LinkSamplingLong As Integer, ByVal In_NoLinkSamplingLong As Integer, ByVal In_Gain As Double, ByVal In_Offset As Double) As Boolean
  End Function
  '系統參數 -----------------------------------------------------------------------------------------------------------------------------------------------
  Dim MyProgramPath As String = Application.StartupPath

  '存檔參數 -----------------------------------------------------------------------------------------------------------------------------------------------
  'Public LastFile As String   '記錄最後執行之產品檔
  Public IsSaveKey As Boolean '判別是否儲存產品檔

  'Camera 及影像參數 --------------------------------------------------------------------------------------------------------------------------------------------
  Public CheckRun_Live_CCD(4) As CheckBox
  Public CCD_Session(4) As ImaqdxSession
  Public CCD1_Session, CCD2_Session, CCD3_Session, CCD4_Session As ImaqdxSession
  Public CCD_Buffer(4) As Long
  Public CCD1_Buffer, CCD2_Buffer, CCD3_Buffer, CCD4_Buffer As Long
  Public CCD1_ThreadLive, CCD2_ThreadLive, CCD3_ThreadLive, CCD4_ThreadLive As Threading.Thread
  Public CCD1_Thread_StartOnlyTime_Live As Boolean = True '程式一起動 , 先執行一次執行緒將其預先配置給記憶體 , 防止例外錯誤
  Public CCD2_Thread_StartOnlyTime_Live As Boolean = True '程式一起動 , 先執行一次執行緒將其預先配置給記憶體 , 防止例外錯誤
  Public CCD3_Thread_StartOnlyTime_Live As Boolean = True '程式一起動 , 先執行一次執行緒將其預先配置給記憶體 , 防止例外錯誤
  Public CCD4_Thread_StartOnlyTime_Live As Boolean = True '程式一起動 , 先執行一次執行緒將其預先配置給記憶體 , 防止例外錯誤
  Public CCD_ImageBeforeRotate(4) As VisionImage
  Public CCD1_ImageBeforeRotate As New VisionImage 'CCD1 取像原圖
  Public CCD2_ImageBeforeRotate As New VisionImage 'CCD2 取像原圖
  Public CCD3_ImageBeforeRotate As New VisionImage 'CCD3 取像原圖
  Public CCD4_ImageBeforeRotate As New VisionImage 'CCD4 取像原圖
  Public CCD_ImageSource(4) As VisionImage
  Public CCD1_ImageSource As New VisionImage       'CCD1 取像原圖(翻轉180後)
  Public CCD2_ImageSource As New VisionImage       'CCD2 取像原圖(翻轉180後)
  Public CCD3_ImageSource As New VisionImage       'CCD3 取像原圖(翻轉180後)
  Public CCD4_ImageSource As New VisionImage       'CCD4 取像原圖(翻轉180後)
  Public CCD1_ImageAdjust_1 As New VisionImage       'CCD1 影像處理圖
  Public CCD2_ImageAdjust_2 As New VisionImage       'CCD2 影像處理圖
  Public CCD3_ImageAdjust_3 As New VisionImage       'CCD3 影像處理圖
  Public CCD4_ImageAdjust_4 As New VisionImage       'CCD4 影像處理圖
  Public CCD1_LiveKey, CCD2_LiveKey, CCD3_LiveKey, CCD4_LiveKey As Boolean
  Public CCD1_LineCross1 As New LineContour '十字線
  Public CCD1_LineCross2 As New LineContour '十字線
  Public CCD2_LineCross1 As New LineContour '十字線
  Public CCD2_LineCross2 As New LineContour '十字線
  Public CCD3_LineCross1 As New LineContour '十字線
  Public CCD3_LineCross2 As New LineContour '十字線
  Public CCD4_LineCross1 As New LineContour '十字線
  Public CCD4_LineCross2 As New LineContour '十字線
  Public CCD1_ThreadLiveBusyKey As Boolean = True  '取像執行緒是否正在執行中
  Public CCD2_ThreadLiveBusyKey As Boolean = True  '取像執行緒是否正在執行中
  Public CCD3_ThreadLiveBusyKey As Boolean = True  '取像執行緒是否正在執行中
  Public CCD4_ThreadLiveBusyKey As Boolean = True  '取像執行緒是否正在執行中
  Public CCD1_ThreadLiveStopKey, CCD2_ThreadLiveStopKey, CCD3_ThreadLiveStopKey, CCD4_ThreadLiveStopKey As Boolean         '確保 Live 執行緒已完全結束
  Public CCD_WaitCapture(4) As Object
  Public CCD1_WaitCapture As New Object '取像指令隔開
  Public CCD2_WaitCapture As New Object '取像指令隔開
  Public CCD3_WaitCapture As New Object '取像指令隔開
  Public CCD4_WaitCapture As New Object '取像指令隔開
  Public CCD_Coefficients() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1}
  Public CCD_StructElem As New StructuringElement(3, 3, CCD_Coefficients)
  Public CCD_Coefficients_Open() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
  Public CCD_StructElem_Open As New StructuringElement(7, 7, CCD_Coefficients_Open)
  'Public StartProcess_Thread As Threading.Thread
  'Public Delegate Sub StartProcess_Delegate()

  Public ImageResult As New VisionImage(ImageType.U8, 7) '結果示意圖

  Public LabSearch1_Result_CCD(4) As Label

  '影像處理參數
  Public ParticleFilterCriteria_RemoveLength(4) As Collection(Of ParticleFilterCriteria)      '濾除細長
  Public ParticleFilterCriteria_RemoveMaxLength(4) As Collection(Of ParticleFilterCriteria)   '濾除最大長度
  Public ParticleFilterCriteria_RemoveTrueCircle As New Collection(Of ParticleFilterCriteria) '濾除真圓度
  Public ParticleFilterOptions_RemoveLength(4) As ParticleFilterOptions
  Public MaskToRoiReport_CCD(4) As MaskToRoiReport '畫出缺點
  Public RoiDefectOutside_CCD(4) As Roi
  Public MaskToRoiReport_DefectOutside(4) As MaskToRoiReport
  Public Calib_Coefficients() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1}
  Public Calib_StructElem As New StructuringElement(3, 3, Calib_Coefficients)

  'PLC 參數
  Public Delegate Sub ScanPlcStates_Delegate()
  Public Delegate Sub ScanPlcDIO_Delegate()
  Public Delegate Sub ShowPlcAlarmToLabel_Delegate(ByVal MyAlarmCode As Integer)
  Public PlcRunningKey As Boolean = False
  Public PlcRunStates_Thread As Threading.Thread
  Public PlcDIO_Thread As Threading.Thread
  Public ShowPlcAlarmCode_Thread As Threading.Thread
  Public ScanPlcStatesKey As Boolean = False
  Public ScanPlcDioKey As Boolean = False

  'Search2 參數
  Private Delegate Sub ShowReceiveDataDelegate(ByVal index As Integer, ByVal text As String)
  Public ClassIntPtr(4) As IntPtr
  Public LabSearch2_Result_CCD(4) As Label
  Dim ListenSocket As Socket
  Dim ListenThread As Thread
  Dim ClientSocket As Socket
  Dim IP_Server As IPAddress = IPAddress.Parse("127.0.0.1")
  Dim IPEndPoint_Server As New IPEndPoint(IP_Server, 10000)
  Dim TextServer_Receive_CCD(4) As TextBox
  Dim LabServer_Receive_ContinueCount_CCD(4) As Label
  Dim LabServer_Receive_NonContinueCount_CCD(4) As Label
  Dim CcdIndex_Search2 As Integer = 0

  '資料上傳參數
  Dim p As New Process
  Dim PsaKitPath As String = "D:\Program\HoleDetection_20251210_SendData\bin\Debug\myPsaKitCommandUI_4.6.2\myPsaKitCommandUI.exe"

  Sub New()

    ' 此為 Windows Form 設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

  End Sub
  '改變 D/O 狀態
  Public Sub ChangeDO(ByVal MyDoIndex As Integer, ByVal MyState As Boolean)
    CheckDo(MyDoIndex).Checked = MyState
    Call TimerDIO_Tick(TimerDIO, Nothing)
  End Sub
  'CCD1 Live
  Public Function FunctionThread_Live_CCD1() As Boolean
    '主畫面剛建立先執行一次避免例外錯誤發生 ---------------------------------------------------------------------------------------------------------------
    If CCD1_Thread_StartOnlyTime_Live Then
      CCD1_Thread_StartOnlyTime_Live = False
      Exit Function
    End If

    Do : Application.DoEvents() : Threading.Thread.Sleep(1)
      If CCD1_LiveKey = True Then
        Try
          SyncLock CCD1_WaitCapture
            CCD1_Session.Grab(CCD1_ImageBeforeRotate, True, CCD1_Buffer)
            Algorithms.Rotate(CCD1_ImageBeforeRotate, CCD1_ImageSource, 180)
            Algorithms.Copy(CCD1_ImageSource, ImageViewer_CCD1.Image)

            '十字線
            If CheckOption_DrawCross.Checked = True Then
              CCD1_LineCross1.Start.X = 5
              CCD1_LineCross1.Start.Y = ImageViewer_CCD1.Image.Height / 2
              CCD1_LineCross1.End.X = ImageViewer_CCD1.Image.Width - 10
              CCD1_LineCross1.End.Y = ImageViewer_CCD1.Image.Height / 2
              CCD1_LineCross2.Start.X = ImageViewer_CCD1.Image.Width / 2
              CCD1_LineCross2.Start.Y = 5
              CCD1_LineCross2.End.X = ImageViewer_CCD1.Image.Width / 2
              CCD1_LineCross2.End.Y = ImageViewer_CCD1.Image.Height - 10
              ImageViewer_CCD1.Image.Overlays.Default.AddLine(CCD1_LineCross1, Rgb32Value.GreenColor)
              ImageViewer_CCD1.Image.Overlays.Default.AddLine(CCD1_LineCross2, Rgb32Value.GreenColor)
            End If

          End SyncLock

        Catch ex As Exception
          Call WriteMessage("CCD1 Live 發生錯誤")
          MsgBox("CCD1 Live 發生錯誤", MsgBoxStyle.Critical, "例外錯誤(Exception error)")
          CCD1_ThreadLiveBusyKey = False
        End Try
      End If
    Loop Until CCD1_ThreadLiveBusyKey = False

    CCD1_ThreadLiveStopKey = False

  End Function
  'CCD2 Live
  Public Function FunctionThread_Live_CCD2() As Boolean
    '主畫面剛建立先執行一次避免例外錯誤發生 ---------------------------------------------------------------------------------------------------------------
    If CCD2_Thread_StartOnlyTime_Live Then
      CCD2_Thread_StartOnlyTime_Live = False
      Exit Function
    End If

    Do : Application.DoEvents() : Threading.Thread.Sleep(1)
      If CCD2_LiveKey = True Then
        Try
          SyncLock CCD2_WaitCapture
            CCD2_Session.Grab(CCD2_ImageBeforeRotate, True, CCD2_Buffer)
            Algorithms.Rotate(CCD2_ImageBeforeRotate, CCD2_ImageSource, 90)
            Algorithms.Copy(CCD2_ImageSource, ImageViewer_CCD2.Image)

            '十字線
            If CheckOption_DrawCross.Checked = True Then
              CCD2_LineCross1.Start.X = 5
              CCD2_LineCross1.Start.Y = ImageViewer_CCD2.Image.Height / 2
              CCD2_LineCross1.End.X = ImageViewer_CCD2.Image.Width - 10
              CCD2_LineCross1.End.Y = ImageViewer_CCD2.Image.Height / 2
              CCD2_LineCross2.Start.X = ImageViewer_CCD2.Image.Width / 2
              CCD2_LineCross2.Start.Y = 5
              CCD2_LineCross2.End.X = ImageViewer_CCD2.Image.Width / 2
              CCD2_LineCross2.End.Y = ImageViewer_CCD2.Image.Height - 10
              ImageViewer_CCD2.Image.Overlays.Default.AddLine(CCD2_LineCross1, Rgb32Value.GreenColor)
              ImageViewer_CCD2.Image.Overlays.Default.AddLine(CCD2_LineCross2, Rgb32Value.GreenColor)
            End If

          End SyncLock

        Catch ex As Exception
          Call WriteMessage("CCD2 Live 發生錯誤")
          MsgBox("CCD2 Live 發生錯誤", MsgBoxStyle.Critical, "例外錯誤(Exception error)")
          CCD2_ThreadLiveBusyKey = False
        End Try
      End If
    Loop Until CCD2_ThreadLiveBusyKey = False

    CCD2_ThreadLiveStopKey = False

  End Function
  'CCD3 Live
  Public Function FunctionThread_Live_CCD3() As Boolean
    '主畫面剛建立先執行一次避免例外錯誤發生 ---------------------------------------------------------------------------------------------------------------
    If CCD3_Thread_StartOnlyTime_Live Then
      CCD3_Thread_StartOnlyTime_Live = False
      Exit Function
    End If

    Do : Application.DoEvents() : Threading.Thread.Sleep(1)
      If CCD3_LiveKey = True Then
        Try
          SyncLock CCD3_WaitCapture
            CCD3_Session.Grab(CCD3_ImageBeforeRotate, True, CCD3_Buffer)
            Algorithms.Rotate(CCD3_ImageBeforeRotate, CCD3_ImageSource, 0)
            Algorithms.Copy(CCD3_ImageSource, ImageViewer_CCD3.Image)

            '十字線
            If CheckOption_DrawCross.Checked = True Then
              CCD3_LineCross1.Start.X = 5
              CCD3_LineCross1.Start.Y = ImageViewer_CCD3.Image.Height / 2
              CCD3_LineCross1.End.X = ImageViewer_CCD3.Image.Width - 10
              CCD3_LineCross1.End.Y = ImageViewer_CCD3.Image.Height / 2
              CCD3_LineCross2.Start.X = ImageViewer_CCD3.Image.Width / 2
              CCD3_LineCross2.Start.Y = 5
              CCD3_LineCross2.End.X = ImageViewer_CCD3.Image.Width / 2
              CCD3_LineCross2.End.Y = ImageViewer_CCD3.Image.Height - 10
              ImageViewer_CCD3.Image.Overlays.Default.AddLine(CCD3_LineCross1, Rgb32Value.GreenColor)
              ImageViewer_CCD3.Image.Overlays.Default.AddLine(CCD3_LineCross2, Rgb32Value.GreenColor)
            End If

          End SyncLock

        Catch ex As Exception
          Call WriteMessage("CCD3 Live 發生錯誤")
          MsgBox("CCD3 Live 發生錯誤", MsgBoxStyle.Critical, "例外錯誤(Exception error)")
          CCD3_ThreadLiveBusyKey = False
        End Try
      End If
    Loop Until CCD3_ThreadLiveBusyKey = False

    CCD3_ThreadLiveStopKey = False

  End Function
  'CCD4 Live
  Public Function FunctionThread_Live_CCD4() As Boolean
    '主畫面剛建立先執行一次避免例外錯誤發生 ---------------------------------------------------------------------------------------------------------------
    If CCD4_Thread_StartOnlyTime_Live Then
      CCD4_Thread_StartOnlyTime_Live = False
      Exit Function
    End If

    Do : Application.DoEvents() : Threading.Thread.Sleep(1)
      If CCD4_LiveKey = True Then
        Try
          SyncLock CCD4_WaitCapture
            CCD4_Session.Grab(CCD4_ImageBeforeRotate, True, CCD4_Buffer)
            Algorithms.Rotate(CCD4_ImageBeforeRotate, CCD4_ImageSource, 270)
            Algorithms.Copy(CCD4_ImageSource, ImageViewer_CCD4.Image)

            '十字線
            If CheckOption_DrawCross.Checked = True Then
              CCD4_LineCross1.Start.X = 5
              CCD4_LineCross1.Start.Y = ImageViewer_CCD4.Image.Height / 2
              CCD4_LineCross1.End.X = ImageViewer_CCD4.Image.Width - 10
              CCD4_LineCross1.End.Y = ImageViewer_CCD4.Image.Height / 2
              CCD4_LineCross2.Start.X = ImageViewer_CCD4.Image.Width / 2
              CCD4_LineCross2.Start.Y = 5
              CCD4_LineCross2.End.X = ImageViewer_CCD4.Image.Width / 2
              CCD4_LineCross2.End.Y = ImageViewer_CCD4.Image.Height - 10
              ImageViewer_CCD4.Image.Overlays.Default.AddLine(CCD4_LineCross1, Rgb32Value.GreenColor)
              ImageViewer_CCD4.Image.Overlays.Default.AddLine(CCD4_LineCross2, Rgb32Value.GreenColor)
            End If

          End SyncLock

        Catch ex As Exception
          Call WriteMessage("CCD4 Live 發生錯誤")
          MsgBox("CCD4 Live 發生錯誤", MsgBoxStyle.Critical, "例外錯誤(Exception error)")
          CCD4_ThreadLiveBusyKey = False
        End Try
      End If
    Loop Until CCD4_ThreadLiveBusyKey = False

    CCD4_ThreadLiveStopKey = False

  End Function
  'PLC
  Public Function FunctionThread_RunStates_PLC() As Boolean
    ''主畫面剛建立先執行一次避免例外錯誤發生 ---------------------------------------------------------------------------------------------------------------
    'If PlcRunStates_Thread_StartOnlyTime_Live Then
    '  PlcRunStates_Thread_StartOnlyTime_Live = False
    '  Exit Function
    'End If

    'Dim MyInvokeRequired As Boolean = Me.InvokeRequired

    Do : Application.DoEvents() : Threading.Thread.Sleep(100)
      If PlcRunningKey = True AndAlso PlcThreadStopKey = False Then
        If ScanPlcStatesKey = False Then
          ScanPlcStatesKey = True
          Me.Invoke(New ScanPlcStates_Delegate(AddressOf ScanPlcStates))
        End If

        If ScanPlcDioKey = False Then
          ScanPlcDioKey = True
          Me.Invoke(New ScanPlcDIO_Delegate(AddressOf ScanPlcDIO))
        End If

      End If
    Loop
    'If Radio_PlcRunning.Checked = True Then

    'End If
  End Function
  '掃描PLC相關狀態
  Public Sub ScanPlcStates()
    '檢測片數
    Dim iReturnCode11 As Integer              'Return code
    Dim sData1 As Short
    If PlcRunningKey = True Then
      iReturnCode11 = AxActUtlType_PLC.ReadDeviceBlock2("D3000", 1, sData1)
      Text_SearchCount_D3000.Text = sData1
    End If

    'CYCLE TIME
    Dim iReturnCode12 As Integer              'Return code
    Dim sData2 As Short
    If PlcRunningKey = True Then
      iReturnCode12 = AxActUtlType_PLC.ReadDeviceBlock2("D3002", 1, sData2)
      Lab_CycleTime_D3002.Text = sData2
    End If

    '測高
    Dim iReturnCode13 As Integer              'Return code
    Dim sData311 As Char
    Dim sData31 As Integer
    Dim sData321 As Char
    Dim sData32 As Integer
    Dim sData331 As Char
    Dim sData33 As Integer
    Dim sData341 As Char
    Dim sData34 As Integer
    Dim sData351 As Char
    Dim sData35 As Integer

    If PlcRunningKey = True Then
      iReturnCode13 = AxActUtlType_PLC.ReadDeviceBlock("D960", 1, sData31)
      sData311 = Chr(sData31)
      iReturnCode13 = AxActUtlType_PLC.ReadDeviceBlock("D961", 1, sData32)
      sData321 = Chr(sData32)
      iReturnCode13 = AxActUtlType_PLC.ReadDeviceBlock("D962", 1, sData33)
      sData331 = Chr(sData33)
      iReturnCode13 = AxActUtlType_PLC.ReadDeviceBlock("D963", 1, sData34)
      sData341 = Chr(sData34)
      iReturnCode13 = AxActUtlType_PLC.ReadDeviceBlock("D964", 1, sData35)
      sData351 = Chr(sData35)
      Text_LaserHeight_D950.Text = sData311 & sData321 & "." & sData331 & sData341 & sData351
    End If

    'Trigger延遲時間
    Dim iReturnCode14 As Integer              'Return code
    Dim sData4 As Short
    If PlcRunningKey = True Then
      iReturnCode14 = AxActUtlType_PLC.ReadDeviceBlock2("D3010", 1, sData4)
      Text_TriggerDelay_D3010.Text = sData4
    End If

    '目前自動速度
    Dim iReturnCode15 As Integer              'Return code
    Dim sData5 As Short
    If PlcRunningKey = True Then
      iReturnCode15 = AxActUtlType_PLC.ReadDeviceBlock2("D1030", 2, sData5)
      Lab_MoveSpeed_D1030.Text = sData5
    End If

    '馬達目前位置
    Dim iReturnCode16 As Integer              'Return code
    Dim sData61 As Long
    Dim sData62 As Long
    If PlcRunningKey = True Then
      iReturnCode16 = AxActUtlType_PLC.ReadDeviceBlock("D1090", 1, sData61)
      iReturnCode16 = AxActUtlType_PLC.ReadDeviceBlock("D1091", 1, sData62)
      Text_NowPosition_D1090.Text = ((sData62 * 65536) + sData61).ToString
    End If

    '檢測區位置
    Dim iReturnCode17 As Long              'Return code
    Dim sData71 As Integer
    Dim sData72 As Integer
    If PlcRunningKey = True Then
      iReturnCode17 = AxActUtlType_PLC.ReadDeviceBlock("D1110", 1, sData71)
      iReturnCode17 = AxActUtlType_PLC.ReadDeviceBlock("D1111", 1, sData72)
      Text_SearchPosition_D1110.Text = ((sData72 * 65536) + sData71)
    End If

    '讀碼區位置 測試
    Dim iReturnCode18 As Long              'Return code
    Dim sData81 As Integer
    Dim sData82 As Integer
    If PlcRunningKey = True Then
      iReturnCode18 = AxActUtlType_PLC.ReadDeviceBlock("D1100", 1, sData81)
      iReturnCode18 = AxActUtlType_PLC.ReadDeviceBlock("D1101", 1, sData82)
      Text_BarcodePosition_D1100.Text = ((sData82 * 65536) + sData81)

    End If

    '待命區位置
    Dim iReturnCode19 As Long              'Return code
    Dim sData91 As Integer
    Dim sData92 As Integer
    If PlcRunningKey = True Then
      iReturnCode19 = AxActUtlType_PLC.ReadDeviceBlock("D1120", 1, sData91)
      iReturnCode19 = AxActUtlType_PLC.ReadDeviceBlock("D1121", 1, sData92)
      Text_StandbyPosition_D1120.Text = ((sData92 * 65536) + sData91)
    End If
    ScanPlcStatesKey = False
  End Sub
  '掃描 PLC I/O
  Public Sub ScanPlcDIO()
    Dim lGreen As Integer = 1 'PLC是否運行中
    Dim oM1408 As Integer = 1 '讀碼結果 M1408
    Dim oM1400 As Integer = 1 '檢測結果 M1400
    Dim oM1401 As Integer = 1 '檢測結果 M1401
    Dim oX2B As Integer = 1   '真空檢知 X2B
    Dim oM1601 As Integer = 1 '檢測區 M1601
    Dim oM1600 As Integer = 1 '讀碼區 M1600
    Dim oM1602 As Integer = 1 '待命區 M1602
    Dim oSM403 As Integer = 1 'PLC_REDAY SM403
    Dim oX33 As Integer = 1   'AOI_REDAY X33
    Dim oM1001 As Integer = 1 '伺服復歸完成 M1001
    Dim oL1011 As Integer = 1 'SP L1011
    Dim oL1012 As Integer = 1 'SP L1012
    Dim oM1112 As Integer = 1 '0.1m/min
    Dim oM1111 As Integer = 1 '0.5m/min
    Dim oM1110 As Integer = 1 '1m/min
    Dim oM1002 As Integer = 1 '復歸中
    Dim oM1140 As Integer = 1 '1um
    Dim oM1141 As Integer = 1 '10um
    Dim oM1142 As Integer = 1 '100um

    'PLC是否運行中
    AxActUtlType_PLC.ReadDeviceRandom2("SM412", 1, lGreen)
    LabPlcRunning.BackColor = IIf(lGreen = 1, Color.Lime, Color.Red)

    'Barcode 讀取結果是否OK
    If PlcRunningKey = True Then
      AxActUtlType_PLC.ReadDeviceRandom2("M1408", 1, oM1408)
      If oM1408 = 1 Then
        Lab_BarcodeResult_M1408.BackColor = Color.Green
        Lab_SearchResult_M1408_2.BackColor = Color.Green
        Lab_SearchResult_M1408_2.Text = "OK"
      Else
        Lab_BarcodeResult_M1408.BackColor = Color.White
        Lab_SearchResult_M1408_2.BackColor = Color.White
        Lab_SearchResult_M1408_2.Text = ""
      End If

      '檢測結果是否OK
      AxActUtlType_PLC.ReadDeviceRandom2("M1400", 1, oM1400)
      AxActUtlType_PLC.ReadDeviceRandom2("M1401", 1, oM1401)
      If oM1400 = 0 And oM1401 = 0 Then '未收到AOI回傳結果
        Lab_SearchResult_M1400.BackColor = Color.White
        Lab_SearchResult_M1400.Text = "        "
        Lab_SearchResult_M1400_2.Text = "        "
      Else
        If oM1400 = 1 Then 'OK
          Lab_SearchResult_M1400.BackColor = Color.Green
          Lab_SearchResult_M1400.Text = "OK"
          Lab_SearchResult_M1400_2.Text = "OK"
        Else
          Lab_SearchResult_M1400.BackColor = Color.Red
          Lab_SearchResult_M1400.Text = "NG"
          Lab_SearchResult_M1400_2.Text = "NG"
        End If
      End If

      '真空信號
      AxActUtlType_PLC.ReadDeviceRandom2("X2B", 1, oX2B)
      If oX2B = 1 Then
        Lab_Vacuum_X2B.BackColor = Color.Green
        Lab_Vacuum_X2B_2.Text = "RUN"
      Else
        Lab_Vacuum_X2B.BackColor = Color.Red
        Lab_Vacuum_X2B_2.Text = "STOP"
      End If

      '檢測區信號
      AxActUtlType_PLC.ReadDeviceRandom2("M1601", 1, oM1601)
      If oM1601 = 1 Then
        Lab_Search_M1601.BackColor = Color.Green
        Lab_Search__M1601_2.BackColor = Color.Green
      Else
        Lab_Search_M1601.BackColor = Color.WhiteSmoke
        Lab_Search__M1601_2.BackColor = Color.WhiteSmoke
      End If

      '讀碼區信號
      AxActUtlType_PLC.ReadDeviceRandom2("M1600", 1, oM1600)
      If oM1600 = 1 Then
        Lab_Barcode_M1600.BackColor = Color.Green
        Lab_Barcode_M1600_2.BackColor = Color.Green
      Else
        Lab_Barcode_M1600.BackColor = Color.WhiteSmoke
        Lab_Barcode_M1600_2.BackColor = Color.WhiteSmoke
      End If

      '待命區信號
      AxActUtlType_PLC.ReadDeviceRandom2("M1602", 1, oM1602)
      If oM1602 = 1 Then
        M1602_1.BackColor = Color.Lime
        Lab_Standby_M1602.BackColor = Color.Green
        Lab_Standby_M1602_2.BackColor = Color.Green
      Else
        Lab_Standby_M1602.BackColor = Color.WhiteSmoke
        Lab_Standby_M1602_2.BackColor = Color.WhiteSmoke
      End If

      'PLC Ready 信號
      AxActUtlType_PLC.ReadDeviceRandom2("SM403", 1, oSM403)
      Lab_PlcReady_SM403.BackColor = IIf(oSM403 = 1, Color.Lime, Color.WhiteSmoke)

      'AOI Ready 信號
      AxActUtlType_PLC.ReadDeviceRandom2("X33", 1, oX33)
      Lab_AoiReady_X33.BackColor = IIf(oX33 = 1, Color.Lime, Color.WhiteSmoke)

      '馬達前極限信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1001", 1, oL1001)
      Lab_LimitFront_L1001.BackColor = IIf(oL1001 = 1, Color.Red, Color.WhiteSmoke)

      '馬達後極限信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1000", 1, oL1000)
      Lab_LimitBack_L1000.BackColor = IIf(oL1000 = 1, Color.Red, Color.WhiteSmoke)

      '伺服馬達異常信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1002", 1, oL1002)
      Lab_ServoError_L1002.BackColor = IIf(oL1002 = 1, Color.Red, Color.WhiteSmoke)

      '伺服驅動器異常信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1003", 1, oL1003)
      Lab_DriverError_L1003.BackColor = IIf(oL1003 = 1, Color.Red, Color.WhiteSmoke)

      '真空異常信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1004", 1, oL1004)
      Lab_VacuumError_L1004.BackColor = IIf(oL1004 = 1, Color.Red, Color.WhiteSmoke)

      '門檢1信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1005", 1, oL1005)
      Lab_SafeDoor1_L1005.BackColor = IIf(oL1005 = 1, Color.Red, Color.WhiteSmoke)

      '門檢2信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1006", 1, oL1006)
      Lab_SafeDoor2_L1006.BackColor = IIf(oL1006 = 1, Color.Red, Color.WhiteSmoke)

      '門檢3信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1007", 1, oL1007)
      Lab_SafeDoor3_L1007.BackColor = IIf(oL1007 = 1, Color.Red, Color.WhiteSmoke)

      '保留
      AxActUtlType_PLC.ReadDeviceRandom2("L1008", 1, oL1008)
      L1008.BackColor = IIf(oL1008 = 1, Color.Red, Color.WhiteSmoke)

      '掃描器逾時信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1009", 1, oL1009)
      Lab_BarcodeTimeout_L1009.BackColor = IIf(oL1009 = 1, Color.Red, Color.WhiteSmoke)

      'CCD逾時信號
      AxActUtlType_PLC.ReadDeviceRandom2("L1010", 1, oL1010)
      Lab_CcdTimeout_L1010.BackColor = IIf(oL1010 = 1, Color.Red, Color.WhiteSmoke)

      '保留
      AxActUtlType_PLC.ReadDeviceRandom2("L1011", 1, oL1011)
      L1011.BackColor = IIf(oL1011 = 1, Color.Red, Color.WhiteSmoke)

      '保留
      AxActUtlType_PLC.ReadDeviceRandom2("L1012", 1, oL1012)
      L1012.BackColor = IIf(oL1012 = 1, Color.Red, Color.WhiteSmoke)

      '啟動燈
      AxActUtlType_PLC.ReadDeviceRandom("Y6B", 1, Y6B)

      '警報停止鈕
      AxActUtlType_PLC.ReadDeviceRandom2("X2E", 1, X2E)

      '手動運行參數(0.1 m/min)
      AxActUtlType_PLC.ReadDeviceRandom2("M1112", 1, oM1112)
      M1112.BackColor = IIf(oM1112 = 1, Color.Green, Color.WhiteSmoke)

      '手動運行參數(0.5 m/min)
      AxActUtlType_PLC.ReadDeviceRandom2("M1111", 1, oM1111)
      M1111.BackColor = IIf(oM1111 = 1, Color.Green, Color.WhiteSmoke)

      '手動運行參數(1 m/min)
      AxActUtlType_PLC.ReadDeviceRandom2("M1110", 1, oM1110)
      M1110.BackColor = IIf(oM1110 = 1, Color.Green, Color.WhiteSmoke)

      '復歸完成信號
      AxActUtlType_PLC.ReadDeviceRandom2("M1001", 1, oM1001)
      AxActUtlType_PLC.ReadDeviceRandom2("M1002", 1, oM1002)
      If oM1001 = 0 AndAlso oM1002 = 0 Then
        Lab_HomeFinish_M1001.BackColor = Color.WhiteSmoke
        Lab_HomeFinish_M1002.BackColor = Color.WhiteSmoke
        Lab_HomeFinish_M1002.Text = ""
      Else
        If oM1002 = 1 Then
          Lab_HomeFinish_M1001.BackColor = Color.Yellow
          Lab_HomeFinish_M1001.Text = "復歸中"
          Lab_HomeFinish_M1002.BackColor = Color.Yellow
          Lab_HomeFinish_M1002.Text = "復歸中"
        Else
          Lab_HomeFinish_M1001.BackColor = Color.Lime
          Lab_HomeFinish_M1001.Text = "復歸完成"
          Lab_HomeFinish_M1002.BackColor = Color.Lime
          Lab_HomeFinish_M1002.Text = "復歸完成"
        End If
      End If

      ''伺服復歸完成信號
      'AxActUtlType_PLC.ReadDeviceRandom2("M1001", 1, oM1001)
      'Lab_HomeFinish_M1001.BackColor = IIf(oM1001 = 1, Color.Lime, Color.WhiteSmoke)
      'Lab_HomeFinish_M1002.BackColor = IIf(oM1001 = 1, Color.Lime, Color.WhiteSmoke)
      'If oM1001 = 1 Then Lab_HomeFinish_M1002.Text = "復歸完成"

      '吋動運行參數(0.1 m/min)
      AxActUtlType_PLC.ReadDeviceRandom2("M1140", 1, oM1140)
      M1140.BackColor = IIf(oM1140 = 1, Color.Green, Color.WhiteSmoke)

      '吋動運行參數(0.5 m/min)
      AxActUtlType_PLC.ReadDeviceRandom2("M1141", 1, oM1141)
      M1141.BackColor = IIf(oM1141 = 1, Color.Green, Color.WhiteSmoke)

      '吋動運行參數(1 m/min)
      AxActUtlType_PLC.ReadDeviceRandom2("M1142", 1, oM1142)
      M1142.BackColor = IIf(oM1142 = 1, Color.Green, Color.WhiteSmoke)
    End If
    ScanPlcDioKey = False
  End Sub
  '掃描並顯示 PLC 是否 Alarm
  Public Sub FunctionThread_ShowPlcAlarmCode()
    Do : Application.DoEvents() : Threading.Thread.Sleep(100)
      Dim MyAlarmCode As Integer = 0

      If DI1_X(7) = True Then MyAlarmCode = 7
      If DI1_X(8) = True Then MyAlarmCode = 8
      If DI1_X(9) = True Then MyAlarmCode = 9
      If DI1_X(10) = True Then MyAlarmCode = 10

      LabRun_Msg_PLC.Invoke(New ShowPlcAlarmToLabel_Delegate(AddressOf ShowPlcAlarmToLabel), MyAlarmCode)
    Loop
  End Sub
  '將Alarm信息顯示至Label
  Public Sub ShowPlcAlarmToLabel(ByVal MyAlarmCode As Integer)
    Dim MyAlarmMsg As String = ""

    Select Case MyAlarmCode
      Case 3 : MyAlarmMsg = "馬達前極限"
      Case 4 : MyAlarmMsg = "馬達後極限"
      Case 5 : MyAlarmMsg = "伺服馬達異常"
      Case 6 : MyAlarmMsg = "伺服驅動器異常"
      Case 7 : MyAlarmMsg = "真空異常"
      Case 8 : MyAlarmMsg = "門檢1開啟"
      Case 9 : MyAlarmMsg = "門檢2開啟"
      Case 10 : MyAlarmMsg = "門檢3開啟"
      Case 11 : MyAlarmMsg = "掃描器逾時"
      Case 12 : MyAlarmMsg = "CCD逾時"
    End Select

    LabRun_Msg_PLC.Text = MyAlarmMsg
  End Sub
  '[檢測2] Socket 連線
  Private Sub Search2_StartServer()
    ListenSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)

    ListenSocket.Bind(IPEndPoint_Server)
    ListenSocket.Listen(10)

    While True
      Application.DoEvents() : Thread.Sleep(100)
      ClientSocket = ListenSocket.Accept()
      Application.DoEvents() : Thread.Sleep(1)

      Dim t As New Thread(AddressOf Search2_HandleClient)
      t.IsBackground = True
      t.Start(ClientSocket)
    End While
  End Sub
  '等待回傳資料
  Private Sub Search2_HandleClient(ByVal obj As Object)
    Dim MyClient As Socket = CType(obj, Socket)
    Dim buffer(1023) As Byte

    Try
      While True
        Application.DoEvents() : Thread.Sleep(1)
        Dim recvLen As Integer = MyClient.Receive(buffer)
        If recvLen = 0 Then Exit While

        Dim msg As String = Encoding.UTF8.GetString(buffer, 0, recvLen)
        Search2_ShowReceiveData(CcdIndex_Search2, msg)
      End While
    Catch ex As Exception
    End Try
    MyClient.Close()
  End Sub
  '顯示回傳資料至TextBox
  Private Sub Search2_ShowReceiveData(ByVal MyIndex As Integer, ByVal MyText As String)
    Dim MyTextBox As TextBox = Choose(MyIndex, TextServer_Receive_CCD1, TextServer_Receive_CCD2, TextServer_Receive_CCD3, TextServer_Receive_CCD4)
    If MyTextBox.InvokeRequired Then
      MyTextBox.Invoke(New ShowReceiveDataDelegate(AddressOf Search2_ShowReceiveData), MyIndex, MyText)
    Else
      MyTextBox.Text = MyText
    End If
  End Sub
  '影像處理(Pixel校正)
  Public Function ImageAdjust_Calib_Pixel(ByVal MyAdjustIndex As Integer, ByVal MyImageSource As VisionImage, ByVal MyImageDest As VisionImage, ByVal MyShowAdjust As Boolean) As Boolean
    Dim i As Integer
    Try
      If CheckTool_CcdLive.Checked = True Then CheckTool_CcdLive.Checked = False ' '若為Live則關閉Live
      For i = 1 To 4
        'If CheckRun_Live_CCD(i).Checked = True Then CheckRun_Live_CCD(i).Checked = False '若為Live則關閉Live
        ImageViewer_CCD(i).Image.Overlays.Default.Clear() '清除畫線
      Next i
      '二值化
      Algorithms.Threshold(MyImageSource, MyImageDest, New Range(Val(TextAdv_Calib_BinaryMin.Text), Val(TextAdv_Calib_BinaryMax.Text)), True, 1)
      If MyAdjustIndex = 1 Then GoTo AdjustEnd

      '濾除邊
      Algorithms.RejectBorder(Calib_ImageAdjust_CCD(i), Calib_ImageAdjust_CCD(i), Connectivity.Connectivity8)
      If MyAdjustIndex = 2 Then GoTo AdjustEnd

      '濾除小雜點
      Calib_StructElem_RemoveParticle.Shape = StructuringElementShape.Square
      Algorithms.RemoveParticle(Calib_ImageAdjust_CCD(i), Calib_ImageAdjust_CCD(i), UpDownAdv_Calib_Remove.Value, SizeToKeep.KeepLarge, Connectivity.Connectivity8, Calib_StructElem_RemoveParticle)
      If MyAdjustIndex = 3 Then GoTo AdjustEnd

      '填滿
      Algorithms.FillHoles(Calib_ImageAdjust_CCD(i), Calib_ImageAdjust_CCD(i), Connectivity.Connectivity8)

      ''補滿鋸齒邊
      'Algorithms.ConvexHull(Calib_ImageAdjust_CCD(i), Calib_ImageAdjust_CCD(i), Connectivity.Connectivity8)
      If MyAdjustIndex = 4 Then GoTo AdjustEnd

AdjustEnd:
      '將影像處理結果顯示至Viewer上
      If MyShowAdjust = True Then
        ImageViewer_CCD(i).Palette.Type = PaletteType.Binary
        Algorithms.Copy(Calib_ImageAdjust_CCD(i), ImageViewer_CCD(i).Image)
      Else
        ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
        Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)
      End If


      Return True
    Catch ex As Exception
      MsgBox("CCD" & i.ToString & " 影像處理失敗", MsgBoxStyle.Critical, "CCD Pixel校正")
      Return False
    End Try

  End Function
  '影像處理(距離校正)
  Public Function ImageAdjust_Calib_Distance(ByVal MyAdjustIndex As Integer, ByVal MyShowAdjust As Boolean) As Boolean
    Dim i As Integer

    If CheckTool_CcdLive.Checked = True Then CheckTool_CcdLive.Checked = False ' '若為Live則關閉Live
    For i = 1 To 4
      Try
        '若為Live則關閉Live
        'If CheckRun_Live_CCD(i).Checked = True Then CheckRun_Live_CCD(i).Checked = False

        LabRun_Msg_CCD(i).Text = ""
        If CCD_ImageSource(i).Width = 0 Then
          LabRun_Msg_CCD(i).Text = "畫面無影像"
          Continue For
        End If

        '二值化
        Algorithms.Threshold(CCD_ImageSource(i), Calib_ImageAdjust_CCD(i), New Range(Val(TextAdv_Calib_BinaryMin.Text), Val(TextAdv_Calib_BinaryMax.Text)), True, 1)
        If MyAdjustIndex = 1 Then GoTo AdjustEnd

        '濾除邊
        Algorithms.RejectBorder(Calib_ImageAdjust_CCD(i), Calib_ImageAdjust_CCD(i), Connectivity.Connectivity8)
        If MyAdjustIndex = 2 Then GoTo AdjustEnd

        '濾除小雜點
        Calib_StructElem_RemoveParticle.Shape = StructuringElementShape.Square
        Algorithms.RemoveParticle(Calib_ImageAdjust_CCD(i), Calib_ImageAdjust_CCD(i), UpDownAdv_Calib_Remove.Value, SizeToKeep.KeepLarge, Connectivity.Connectivity8, Calib_StructElem_RemoveParticle)
        If MyAdjustIndex = 3 Then GoTo AdjustEnd

        '填滿
        Algorithms.FillHoles(Calib_ImageAdjust_CCD(i), Calib_ImageAdjust_CCD(i), Connectivity.Connectivity8)

        '補滿鋸齒邊
        Algorithms.ConvexHull(Calib_ImageAdjust_CCD(i), Calib_ImageAdjust_CCD(i), Connectivity.Connectivity8)
        If MyAdjustIndex = 4 Then GoTo AdjustEnd

AdjustEnd:
        '將影像處理結果顯示至Viewer上
        If MyShowAdjust = True Then
          ImageViewer_CCD(i).Palette.Type = PaletteType.Binary
          Algorithms.Copy(Calib_ImageAdjust_CCD(i), ImageViewer_CCD(i).Image)
        Else
          ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
          Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)
        End If
      Catch ex As Exception
        LabRun_Msg_CCD(i).Text = "影像處理失敗"
      End Try
    Next i
    Return True

  End Function
  '影像處理(檢測)
  Public Function ImageAdjust_Search(ByVal MyCcdIndex As Integer, ByVal MyAdjustIndex As Integer, ByVal MyShowAdjust As Boolean) As Boolean
    If LoadingFile = True Then Return True
    Dim i As Integer
    Dim MyRoi As New Roi
    Dim MyForCount As Integer = 0
    Dim MyParticleReport_Circle(4) As ParticleMeasurementsReport           'Particle 分析報告(圓)
    Dim MyDiameterDiffMin As Double = 10000                                '最接近被測圓直徑之直徑差值
    Dim MyDiameterDiff_Pixel As Double = 0                                 '被測圓之直徑差
    Dim MyCenterX(4), MyCenterY(4) As Double                               '被測圓的中心點

    Dim MyCount As Integer = 0
    Dim MyIndex As Integer = 0
    Dim MyOval As New OvalContour(724, 524, 1000, 1000)
    Dim MyDiameter_Pixel As Double = 0

    MyForCount = IIf(MyCcdIndex = 0, 4, 1)
    Try
      If CheckTool_CcdLive.Checked = True Then CheckTool_CcdLive.Checked = False ' '若為Live則關閉Live
      For i = 1 To MyForCount
        If MyCcdIndex > 0 Then i = MyCcdIndex
        '若為Live則關閉Live
        'If CheckRun_Live_CCD(i).Checked = True Then CheckRun_Live_CCD(i).Checked = False
        If CheckSearch_LeftRight.Checked = False AndAlso (i = 2 Or i = 3) Then Continue For
        If CheckSearch_UpDown.Checked = False AndAlso (i = 1 Or i = 4) Then Exit For

        If MyAdjustIndex > 8 AndAlso MyAdjustIndex < 10 Then GoTo Circle_Outside
        '圓尺寸 ================================================================================================================================================================================================================
        '原圖二值化 -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Algorithms.Threshold(CCD_ImageSource(i), ImageAdjustBeforeHull_CCD(i), New Range(Val(TextTeach_BinaryMin.Text), Val(TextTeach_BinaryMax.Text)), True, 1)
        '細化處理
        For MyAdjustCount = 1 To 10 : Algorithms.Morphology(ImageAdjustBeforeHull_CCD(i), ImageAdjustBeforeHull_CCD(i), MorphologyMethod.Erode, CCD_StructElem) : Next
        '粗化處理
        For MyAdjustCount = 1 To 10 : Algorithms.Morphology(ImageAdjustBeforeHull_CCD(i), ImageAdjustBeforeHull_CCD(i), MorphologyMethod.Dilate, CCD_StructElem) : Next
        If MyAdjustIndex = 1 Then
          Algorithms.Copy(ImageAdjustBeforeHull_CCD(i), ImageAdjust_CCD(i))
          GoTo AdjustEnd_All
        End If

        '填滿仿真圓 -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Algorithms.ConvexHull(ImageAdjustBeforeHull_CCD(i), ImageAdjustHull_CCD(i), Connectivity.Connectivity8)
        If MyAdjustIndex = 2 Then
          Algorithms.Copy(ImageAdjustHull_CCD(i), ImageAdjust_CCD(i))
          GoTo AdjustEnd_All
        End If

        '二值化→灰階 -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Algorithms.Equalize(ImageAdjustHull_CCD(i), ImageAdjustHull_CCD(i), Nothing, New Range(0, 255), Nothing)

        If MyAdjustIndex = 3 Then
          Algorithms.Copy(ImageAdjustHull_CCD(i), ImageAdjust_CCD(i))
          GoTo AdjustEnd_All
        End If

Circle_Outside:
        '圓外 ================================================================================================================================================================================================================
        '分析並取得圓中心 ----------------------------------------------------------------------------------------------------------------------------------------------------------------
        '(0:中心X , 1:中心Y , 2:實際直徑 , 3:面積 , 4:最大直徑 , 5:真園度)
        MyParticleReport_Circle(i) = Algorithms.ParticleMeasurements(ImageAdjustHull_CCD(i), PixelMeasurements_CCD(i), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Pixel)
        MyCount = MyParticleReport_Circle(i).PixelMeasurements.GetLength(0)
        MyCenterX(i) = 1224 : MyCenterY(i) = 1024
        If MyCount > 0 Then
          If MyCount = 1 Then '只有一個被測圓
            MyIndex = 0
          Else '兩個以上被測圓
            '找出最接近被測圓的Index
            MyDiameterDiffMin = 10000
            For j = 0 To MyCount - 1
              MyDiameterDiff_Pixel = Math.Abs(MyParticleReport_Circle(i).PixelMeasurements(j, 2) - ((Val(TextTeach_Diameter_CCD(i).Text) * 1000) / Val(TextAdv_Pixel_CCD(i).Text)))
              If MyDiameterDiff_Pixel < MyDiameterDiffMin Then '直徑差(檢測直徑-設定直徑)絕對值 < 設定直徑差
                MyDiameterDiffMin = MyDiameterDiff_Pixel
                MyIndex = j
              End If
            Next
          End If

          '取得圓的中心點
          MyCenterX(i) = MyParticleReport_Circle(i).PixelMeasurements(MyIndex, 0)
          MyCenterY(i) = MyParticleReport_Circle(i).PixelMeasurements(MyIndex, 1)
        End If

        MyDiameter_Pixel = (Val(TextTeach_MaskCircleSize.Text) * 1000) / Val(TextAdv_Pixel_CCD(i).Text)
        MyOval.Initialize(MyCenterX(i) - (MyDiameter_Pixel / 2), MyCenterY(i) - (MyDiameter_Pixel / 2), MyDiameter_Pixel, MyDiameter_Pixel)
        If MyAdjustIndex = 8 Then
          GoTo AdjustEnd_All
        End If

        'MyOval.Initialize(200, 250, 200, 200)
        MyRoi.Clear() : MyRoi.Add(MyOval)
        Using imageMask As New VisionImage(ImageType.U8, 7)

          Dim fillValue As New PixelValue(255)

          'Transforms the region of interest into a mask image.
          Algorithms.RoiToMask(imageMask, MyRoi, fillValue, CCD_ImageSource(i))

          'Inverts the mask image.
          Algorithms.Xor(imageMask, fillValue, imageMask)

          'Masks the input image using the mask image we just created.
          Algorithms.Mask(CCD_ImageSource(i), ImageAdjust_CCD(i), imageMask)

        End Using
        'Algorithms.Copy(ImageAdjust_CCD(i), ImageViewer_CCD(i).Image)
        FillValue_Outside = Nothing

        If MyAdjustIndex = 9 Then GoTo AdjustEnd_All

        '圓外缺點二值化 ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Algorithms.Threshold(ImageAdjust_CCD(i), ImageAdjust_DefectOut(i), New Range(Val(TextTeach_BinaryDefectOut.Text), 255), True, 1)
        If MyAdjustIndex = 10 Then
          Algorithms.Copy(ImageAdjust_DefectOut(i), ImageAdjust_CCD(i))
          GoTo AdjustEnd_All
        End If

AdjustEnd_All:
        '將影像處理結果顯示至Viewer上
        If MyShowAdjust = True Then
          Select Case MyAdjustIndex
            Case 8
              ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
              Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)
              ImageViewer_CCD(i).Image.Overlays.Default.Clear() : ImageViewer_CCD(i).Refresh()
              ImageViewer_CCD(i).Image.Overlays.Default.AddOval(MyOval, Rgb32Value.RedColor)
            Case 9
              ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
              Algorithms.Copy(ImageAdjust_CCD(i), ImageViewer_CCD(i).Image)
            Case Else
              ImageViewer_CCD(i).Palette.Type = PaletteType.Binary
              Algorithms.Copy(ImageAdjust_CCD(i), ImageViewer_CCD(i).Image)
          End Select
        Else
          ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
          Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)
        End If
      Next i

      Return True

    Catch ex As Exception
      If MyCcdIndex = 0 Then MyCcdIndex = i
      If StartKey = False AndAlso Searching = False Then MsgBox("CCD" & MyCcdIndex.ToString & " 影像處理失敗", MsgBoxStyle.Critical, "檢測")
      Return False
    End Try

  End Function

  Public Sub LoadLastProgramName()
    Dim MyName As String = ""

    Try
      If File.Exists(ProgramPath & "\LastProgram.txt") = True Then
        FileOpen(1, ProgramPath & "\LastProgram.txt", OpenMode.Input)
        Do Until EOF(1)
          MyName = LineInput(1)
        Loop
        FileClose(1)
      End If
    Catch ex As Exception : End Try

    If MyName <> "" Then
      Call LoadProductParFormFile(MyName)
    End If
  End Sub
  '載入產品擋
  Public Sub LoadProductParFormFile(ByVal MyFileName As String)
    Dim MyFilePath = ProgramPath & "\Product\" & MyFileName & "\"
    Dim buff As String
    Dim i As Integer = 0

    If Directory.Exists(MyFilePath) = False Then
      Call WriteMessage("產品檔路徑不存在")
      MsgBox("產品檔路徑不存在", MsgBoxStyle.Critical, "載入產品檔")
      Exit Sub
    End If

    MyFileName &= ".ccd"
    If File.Exists(MyFilePath & MyFileName) = False Then
      Call WriteMessage("產品檔：" & MyFileName & " 不存在")
      MsgBox("產品檔：" & MyFileName & " 不存在", MsgBoxStyle.Exclamation, "載入產品檔")
      Exit Sub
    End If

    buff = New String(Chr(0), 255)
    LoadingFile = True '表正在載入產品參數
    '教導參數 ------------------------------------------------------------------------------------------------------------------------------------------------
    For i = 1 To 4
      Call GetPrivateProfileString("教導參數", "光源" & i.ToString, "0", buff, 256, MyFilePath & MyFileName) : TextTeach_Search_Light(i).Text = Val(buff)
      Call GetPrivateProfileString("教導參數", "孔徑" & i.ToString, "1", buff, 256, MyFilePath & MyFileName) : TextTeach_Diameter_CCD(i).Text = Val(buff)
      Call GetPrivateProfileString("教導參數", "孔徑公差" & i.ToString, "0", buff, 256, MyFilePath & MyFileName) : TextTeach_DiameterTolerance_CCD(i).Text = Val(buff)
      Call GetPrivateProfileString("教導參數", "真圓度" & i.ToString, "1", buff, 256, MyFilePath & MyFileName) : TextTeach_TrueCircle_CCD(i).Text = Val(buff)
      Call GetPrivateProfileString("教導參數", "瑕疵長度圓外" & i.ToString, "1", buff, 256, MyFilePath & MyFileName) : TextTeach_DefectLength_Outside_CCD(i).Text = Val(buff)
    Next i

    Call GetPrivateProfileString("教導參數", "二值化Min", "0", buff, 256, MyFilePath & MyFileName) : TextTeach_BinaryMin.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "二值化Max", "0", buff, 256, MyFilePath & MyFileName) : TextTeach_BinaryMax.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "圓外覆蓋圓尺寸", "0", buff, 256, MyFilePath & MyFileName) : TextTeach_MaskCircleSize.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "圓外缺點二值化", "0", buff, 256, MyFilePath & MyFileName) : TextTeach_BinaryDefectOut.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "左右孔距離", "0", buff, 256, MyFilePath & MyFileName) : TextTeach_Distance_LeftRight.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "左右孔距離公差", "0", buff, 256, MyFilePath & MyFileName) : TextTeach_DistanceTolerance_LeftRight.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "上下孔距離", "0", buff, 256, MyFilePath & MyFileName) : TextTeach_Distance_UpDown.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "上下孔距離公差", "0", buff, 256, MyFilePath & MyFileName) : TextTeach_DistanceTolerance_UpDown.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "雷射測高下限", "-1", buff, 256, MyFilePath & MyFileName) : TextTeach_Laser_LimitDown.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "雷射測高上限", "1", buff, 256, MyFilePath & MyFileName) : TextTeach_Laser_LimitUp.Text = Val(buff)

    Call GetPrivateProfileString("教導參數", "檢測二量測寬度", "50", buff, 256, MyFilePath & MyFileName) : TextSearch2_MeasureWidth.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "檢測二直徑", "850", buff, 256, MyFilePath & MyFileName) : TextSearch2_CircleDiameter.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "檢測二灰階門檻", "13", buff, 256, MyFilePath & MyFileName) : TextSearch2_Threshold.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "檢測二門檻值", "415", buff, 256, MyFilePath & MyFileName) : UpDownSearch2_Score.Value = Val(buff)
    Call GetPrivateProfileString("教導參數", "檢測二連續數量", "180", buff, 256, MyFilePath & MyFileName) : TextSearch2_ContinueCount.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "檢測二不連續數量", "45", buff, 256, MyFilePath & MyFileName) : TextSearch2_NonContinueCount.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "檢測二圓內縮量", "-10", buff, 256, MyFilePath & MyFileName) : TextSearch2_Inward.Text = Val(buff)
    Call GetPrivateProfileString("教導參數", "檢測二Gain", "1.00", buff, 256, MyFilePath & MyFileName) : TextSearch2_Gain.Text = Format(Val(buff), "0.00")
    Call GetPrivateProfileString("教導參數", "檢測二Offset", "0.00", buff, 256, MyFilePath & MyFileName) : TextSearch2_Offset.Text = Format(Val(buff), "0.00")

    LabFileName.Text = Mid(MyFileName, 1, MyFileName.Length - 4)
    LabRunningMsg.Text = "產品檔 " & LabFileName.Text & " 載入成功"
    Call WriteMessage("載入產品檔 " & LabFileName.Text)
    IsSaveKey = False

    RunIndex_Main = 1
    Call SaveLastProgramName() '儲存最後執行之產品檔
    LoadingFile = False '載入產品參數結束
  End Sub
  '儲存產品擋
  Public Sub SaveProductParToFile(ByVal MyFileName As String)
    Dim SaveSuccessKey As Boolean = True
    Dim MyPathAndFileName As String = ProgramPath & "\Product\" & MyFileName & "\" & MyFileName
    Dim MyParName As String = ""
    Dim i As Integer = 0

    Try
      Dim MyFilePath As String = ProgramPath & "\Product\"
      Dim MyDirExist As Boolean = Directory.Exists(MyFilePath)
      If MyDirExist = False Then Directory.CreateDirectory(MyFilePath)
      If Strings.Right(SaveAs_FileName, 4) = ".ccd" Then SaveAs_FileName = Mid(SaveAs_FileName, 1, SaveAs_FileName.Length - 4)
      MyDirExist = Directory.Exists(MyFilePath & SaveAs_FileName)
      If MyDirExist = False Then Directory.CreateDirectory(MyFilePath & SaveAs_FileName)

    Catch ex As Exception
      Call WriteMessage("產品檔目錄夾建立失敗(儲存產品擋)")
      MsgBox("產品檔目錄夾建立失敗", MsgBoxStyle.Critical, "儲存產品擋")
      SaveSuccessKey = False
      Exit Sub
    End Try

    Try
      '教導參數 ------------------------------------------------------------------------------------------------------------------------------------------------
      For i = 1 To 4
        MyParName = "檢測光源" & i.ToString : WritePrivateProfileString("教導參數", "光源" & i.ToString, Val(TextTeach_Search_Light(i).Text), MyPathAndFileName & ".ccd")
        MyParName = "孔徑" & i.ToString : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_Diameter_CCD(i).Text), MyPathAndFileName & ".ccd")
        MyParName = "孔徑公差" & i.ToString : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_DiameterTolerance_CCD(i).Text), MyPathAndFileName & ".ccd")
        MyParName = "真圓度" & i.ToString : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_TrueCircle_CCD(i).Text), MyPathAndFileName & ".ccd")
        MyParName = "瑕疵長度圓外" & i.ToString : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_DefectLength_Outside_CCD(i).Text), MyPathAndFileName & ".ccd")
      Next
      MyParName = "二值化Min" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_BinaryMin.Text), MyPathAndFileName & ".ccd")
      MyParName = "二值化Max" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_BinaryMax.Text), MyPathAndFileName & ".ccd")
      MyParName = "圓外覆蓋圓尺寸" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_MaskCircleSize.Text), MyPathAndFileName & ".ccd")
      MyParName = "圓外缺點二值化" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_BinaryDefectOut.Text), MyPathAndFileName & ".ccd")
      MyParName = "左右孔距離" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_Distance_LeftRight.Text), MyPathAndFileName & ".ccd")
      MyParName = "左右孔距離公差" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_DistanceTolerance_LeftRight.Text), MyPathAndFileName & ".ccd")
      MyParName = "上下孔距離" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_Distance_UpDown.Text), MyPathAndFileName & ".ccd")
      MyParName = "上下孔距離公差" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_DistanceTolerance_UpDown.Text), MyPathAndFileName & ".ccd")
      MyParName = "雷射測高下限" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_Laser_LimitDown.Text), MyPathAndFileName & ".ccd")
      MyParName = "雷射測高上限" : WritePrivateProfileString("教導參數", MyParName, Val(TextTeach_Laser_LimitUp.Text), MyPathAndFileName & ".ccd")

      MyParName = "檢測二量測寬度" : WritePrivateProfileString("教導參數", MyParName, Val(TextSearch2_MeasureWidth.Text), MyPathAndFileName & ".ccd")
      MyParName = "檢測二直徑" : WritePrivateProfileString("教導參數", MyParName, Val(TextSearch2_CircleDiameter.Text), MyPathAndFileName & ".ccd")
      MyParName = "檢測二灰階門檻" : WritePrivateProfileString("教導參數", MyParName, Val(TextSearch2_Threshold.Text), MyPathAndFileName & ".ccd")
      MyParName = "檢測二門檻值" : WritePrivateProfileString("教導參數", MyParName, UpDownSearch2_Score.Value.ToString, MyPathAndFileName & ".ccd")
      MyParName = "檢測二連續數量" : WritePrivateProfileString("教導參數", MyParName, Val(TextSearch2_ContinueCount.Text), MyPathAndFileName & ".ccd")
      MyParName = "檢測二不連續數量" : WritePrivateProfileString("教導參數", MyParName, Val(TextSearch2_NonContinueCount.Text), MyPathAndFileName & ".ccd")
      MyParName = "檢測二圓內縮量" : WritePrivateProfileString("教導參數", MyParName, Val(TextSearch2_Inward.Text), MyPathAndFileName & ".ccd")
      MyParName = "檢測二Gain" : WritePrivateProfileString("教導參數", MyParName, Val(TextSearch2_Gain.Text), MyPathAndFileName & ".ccd")
      MyParName = "檢測二Offset" : WritePrivateProfileString("教導參數", MyParName, Val(TextSearch2_Offset.Text), MyPathAndFileName & ".ccd")
    Catch ex As Exception
      Call WriteMessage("教導參數→" & MyParName & " 儲存失敗")
      MsgBox("教導參數→" & MyParName & " 儲存失敗", MsgBoxStyle.Critical, "儲存產品擋")
      SaveSuccessKey = False
    End Try

    LabFileName.Text = MyFileName
    LabRunningMsg.Text = "產品檔 " & LabFileName.Text & " 儲存成功"
    Call WriteMessage("儲存產品檔 " & LabFileName.Text)
    IsSaveKey = Not SaveSuccessKey

    Call SaveLastProgramName() '儲存最後執行之產品檔
  End Sub
  '儲存最後執行之產品檔
  Public Sub SaveLastProgramName()
    'If LabFileName.Text <> "" And LabRunType.Text <> "" Then Call BtnTool_FileSave_Click(Nothing, Nothing) '儲存目前產品檔

    Try
      FileOpen(1, ProgramPath & "\LastProgram.txt", OpenMode.Output)
      PrintLine(1, LabFileName.Text)
      FileClose(1)
    Catch ex As Exception : End Try
  End Sub
  '儲存檢測資料
  Public Sub SaveSearchData()
    '偵測存放檢測資料之根目錄夾是否存在，不存在則建立
    If Directory.Exists(SearchDataPathRoot) = False Then Directory.CreateDirectory(SearchDataPathRoot)

    Dim MySearchDataPath As String = SearchDataPathRoot & "\" & Trim(TextOpInf_ProductNumber.Text)

    '偵測存放檢測資料之料號目錄夾是否存在，不存在則建立
    If Directory.Exists(MySearchDataPath) = False Then Directory.CreateDirectory(MySearchDataPath)

    Dim MyFileName As String = TextOpInf_NotNumber.Text & "_" & Format(Now, "yyyyMMddHHmmss") & ".txt"

    Try
      FileOpen(2, MySearchDataPath & "\" & MyFileName, OpenMode.Append)

      '儲存設定參數
      PrintLine(2, "Config Parameters -Start-")
      For i As Integer = 1 To 4
        PrintLine(2, "CCD" & i.ToString & "燈光:" & TextTeach_Search_Light(i).Text)
      Next

      '儲存檢測結果
      PrintLine(2, "檢測結果:" & LabRun_SearchResult.Text)

      '影像處理參數
      PrintLine(2, "影像處理(圓內)-二值化Min:" & TextTeach_BinaryMin.Text)
      PrintLine(2, "影像處理(圓內)-二值化Max:" & TextTeach_BinaryMax.Text)
      PrintLine(2, "影像處理(圓外)-二值化:" & TextTeach_BinaryOutside.Text)

      '產品規格參數
      For i As Integer = 1 To 4
        PrintLine(2, "CCD" & i.ToString & "孔徑:" & TextTeach_Diameter_CCD(i).Text)
        PrintLine(2, "CCD" & i.ToString & "孔徑公差:" & TextTeach_DiameterTolerance_CCD(i).Text)
        PrintLine(2, "CCD" & i.ToString & "真圓度:" & TextTeach_TrueCircle_CCD(i).Text)
        PrintLine(2, "CCD" & i.ToString & "缺點長度(圓外):" & TextTeach_DefectLength_Outside_CCD(i).Text)
      Next

      PrintLine(2, "左右孔距離:" & TextTeach_Distance_LeftRight.Text)
      PrintLine(2, "左右孔距離公差:" & TextTeach_DistanceTolerance_LeftRight.Text)
      PrintLine(2, "上下孔距離:" & TextTeach_Distance_UpDown.Text)
      PrintLine(2, "上下孔距離公差:" & TextTeach_DistanceTolerance_UpDown.Text)
      PrintLine(2, "雷射測高下限:" & TextTeach_BinaryOutside.Text)
      PrintLine(2, "雷射測高上限:" & TextTeach_BinaryOutside.Text)
      PrintLine(2, "Config Parameters -End-")

      '儲存作業資訊
      PrintLine(2, "Operation Information -Start-")
      PrintLine(2, "人員工號:" & TextOpInf_UserNo.Text)
      PrintLine(2, "日期時間:" & TextOpInf_DateTime.Text)
      PrintLine(2, "批號:" & TextOpInf_NotNumber.Text)
      PrintLine(2, "料號:" & TextOpInf_ProductNumber.Text)
      PrintLine(2, "孔品質結果判定:" & TextOpInf_HoleQualityResult.Text)
      PrintLine(2, "孔品質種類判定:" & TextOpInf_HoleQualityType.Text)
      PrintLine(2, "X方向孔距離量測及判定結果:" & TextOpInf_HoleDustanceAndResultX.Text)
      PrintLine(2, "Y方向孔距離量測及判定結果:" & TextOpInf_HoleDustanceAndResultY.Text)
      PrintLine(2, "打拔機編號:" & TextOpInf_MachineCode.Text)
      PrintLine(2, "模具編號:" & TextOpInf_MouldNumber.Text)
      PrintLine(2, "上沖針編號:" & TextOpInf_OunchNeedleNumberUp.Text)
      PrintLine(2, "下沖針編號:" & TextOpInf_OunchNeedleNumberDown.Text)
      PrintLine(2, "包號:" & TextOpInf_PackNumber.Text)
      PrintLine(2, "Operation Information -End-")

      '儲存檢測結果
      PrintLine(2, "Measurement Results -Start-")
      PrintLine(2, "左右孔距離:" & LabRun_Distance_LeftRight.Text)
      PrintLine(2, "上下孔距離:" & LabRun_Distance_UpDown.Text)

      For i As Integer = 1 To 4
        PrintLine(2, "CCD" & i.ToString & "孔徑:" & LabRun_Diameter_CCD(i).Text)
        PrintLine(2, "CCD" & i.ToString & "真圓度:" & LabRun_Defect_TrueCircle_CCD(i).Text)
        'PrintLine(2, "CCD" & i.ToString & "缺點長度(圓外):" & TextTeach_DefectLength_Outside_CCD(i).Text)

        '圓內缺點
        If LabServer_Receive_ContinueCount_CCD(i).ForeColor = Color.Red Then PrintLine(2, "CCD" & i.ToString & "毛邊連續長度(圓內):" & LabServer_Receive_ContinueCount_CCD(i).Text)
        If LabServer_Receive_NonContinueCount_CCD(i).ForeColor = Color.Red Then PrintLine(2, "CCD" & i.ToString & "毛邊累計長度(圓內):" & LabServer_Receive_NonContinueCount_CCD(i).Text)

        '圓外缺點
        Dim MyDefectString As String = ""
        MyDefectString = ""
        If DataGrid_DefectLength_Outside.RowCount > 0 Then
          For j = 0 To DataGrid_DefectLength_Outside.RowCount - 1
            If Not (DataGrid_DefectLength_Outside.Item(i, j).Value Is Nothing) OrElse DataGrid_DefectLength_Outside.Item(i, j).Value <> "" Then
              If j = 0 Then
                If Val(DataGrid_DefectLength_Outside.Item(i, j).Value) <> 0 Then MyDefectString = DataGrid_DefectLength_Outside.Item(i, j).Value
              Else
                If Val(DataGrid_DefectLength_Outside.Item(i, j).Value) <> 0 Then MyDefectString = MyDefectString & "," & DataGrid_DefectLength_Outside.Item(i, j).Value
              End If
            End If
          Next
          PrintLine(2, "CCD" & i.ToString & "缺點長度(圓外):" & MyDefectString)
        End If
      Next
      PrintLine(2, "Measurement Results -End-")
      FileClose(2)
      LabSendData_FileName.Text = MyFileName
      Call WriteMessage(MySearchDataPath & " 儲存檢測資料完成")
      LabRunningMsg.Text = "儲存檢測資料完成" : LabRunningMsg.Refresh()
    Catch ex As Exception
      FileClose(2)
      LabRunningMsg.Text = "儲存檢測資料失敗" : LabRunningMsg.Refresh()
      Call WriteMessage(MySearchDataPath & " 儲存檢測資料失敗")
      MsgBox(MySearchDataPath & "\" & MyFileName & vbNewLine & vbNewLine & "儲存檢測資料失敗")
    End Try
  End Sub
  '載入機械參數
  Public Sub LoadMachineParFormFile()
    'Dim KeyValue As New StringBuilder(1024)
    'Dim nSize As UInt32 = Convert.ToUInt32(1024)
    Dim buff As String = New String(Chr(0), 255)
    Dim MyPath As String = ProgramPath
    Dim i As Integer = 0

    '進階設定→Pixel 校正 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Call GetPrivateProfileString("機械參數-Pixel校正", "Circle Size", "1", buff, 256, MyPath & "\Machine.ini") : TextAdv_CircleSize.Text = Val(buff)
    For i = 1 To 4
      Call GetPrivateProfileString("機械參數-Pixel校正", "光源" & i.ToString, "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Calib_Light(i).Text = Val(buff)
      Call GetPrivateProfileString("機械參數-Pixel校正", "CCD" & i.ToString, "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Pixel_CCD(i).Text = Val(buff) : Call TextAdv_Pixel_CCD_TextChanged(TextAdv_Pixel_CCD(i), Nothing)
    Next i
    Call GetPrivateProfileString("機械參數-校正影像處理", "二值化Min", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Calib_BinaryMin.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-校正影像處理", "二值化Max", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Calib_BinaryMax.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-校正影像處理", "濾除邊", "1", buff, 256, MyPath & "\Machine.ini") : CheckAdv_Calib_RejectBorder.Checked = IIf(Val(buff) = 1, True, False)
    Call GetPrivateProfileString("機械參數-校正影像處理", "濾除雜點", "0", buff, 256, MyPath & "\Machine.ini") : UpDownAdv_Calib_Remove.Value = Val(buff)
    Call GetPrivateProfileString("機械參數-距離校正", "校正片距離X", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_CalibTool_DistanceX.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-距離校正", "校正片距離Y", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_CalibTool_DistanceY.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-距離校正", "左右孔距離", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Distance_LeftRight.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-距離校正", "左右孔補償距離", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Distance_LeftRight_Offset.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-距離校正", "左右孔角度", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Angle_LeftRight.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-距離校正", "上下孔距離", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Distance_UpDown.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-距離校正", "上下孔補償距離", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Distance_UpDown_Offset.Text = Val(buff)
    Call GetPrivateProfileString("機械參數-距離校正", "上下孔角度", "0", buff, 256, MyPath & "\Machine.ini") : TextAdv_Angle_UpDown.Text = Val(buff)

  End Sub
  '儲存機械參數
  Public Sub SaveMachineParToFile()
    Dim MyPath As String = ProgramPath
    Dim i As Integer = 0

    '進階設定→Pixel 校正 ----------------------------------------------------------------------------------------------------------------------------------
    Call WritePrivateProfileString("機械參數-Pixel校正", "Circle Size", TextAdv_CircleSize.Text, MyPath & "\Machine.ini")
    For i = 1 To 4
      Call WritePrivateProfileString("機械參數-Pixel校正", "光源" & i.ToString, TextAdv_Calib_Light(i).Text.ToString, MyPath & "\Machine.ini")
      Call WritePrivateProfileString("機械參數-Pixel校正", "CCD" & i.ToString, TextAdv_Pixel_CCD(i).Text, MyPath & "\Machine.ini")
    Next

    Call WritePrivateProfileString("機械參數-校正影像處理", "二值化Min", TextAdv_Calib_BinaryMin.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-校正影像處理", "二值化Max", TextAdv_Calib_BinaryMax.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-校正影像處理", "濾除邊", Int(CheckAdv_Calib_RejectBorder.Checked), MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-校正影像處理", "濾除雜點", UpDownAdv_Calib_Remove.Value.ToString, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-距離校正", "校正片距離X", TextAdv_CalibTool_DistanceX.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-距離校正", "校正片距離Y", TextAdv_CalibTool_DistanceY.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-距離校正", "左右孔距離", TextAdv_Distance_LeftRight.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-距離校正", "左右孔補償距離", TextAdv_Distance_LeftRight_Offset.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-距離校正", "左右孔角度", TextAdv_Angle_LeftRight.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-距離校正", "上下孔距離", TextAdv_Distance_UpDown.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-距離校正", "上下孔補償距離", TextAdv_Distance_UpDown_Offset.Text, MyPath & "\Machine.ini")
    Call WritePrivateProfileString("機械參數-距離校正", "上下孔角度", TextAdv_Angle_UpDown.Text, MyPath & "\Machine.ini")
    '-------------------------------------------------------------------------------------------------------------------------------------------------------

    '進階設定→功能選項設定 --------------------------------------------------------------------------------------------------------------------------------
    'Call WritePrivateProfileString("機械參數-功能選項設定", "開啟檢測功能", Int(CheckAdv_Option_Search.Checked), MyPath & "\Machine.ini")
    'Call WritePrivateProfileString("機械參數-功能選項設定", "出料Delay", TextAdv_Delay_Output.Text, MyPath & "\Machine.ini")
    'Call WritePrivateProfileString("機械參數-功能選項設定", "儲存NG圖", Int(CheckAdv_Option_SaveNgPic.Checked), MyPath & "\Machine.ini")
    '-------------------------------------------------------------------------------------------------------------------------------------------------------
  End Sub
  '設定按鈕致能狀態
  Public Sub SetBtnState(ByVal MyLogin As Boolean, ByVal MyFileLoad As Boolean, ByVal MyFileSave As Boolean, ByVal MyFileSaveAs As Boolean, ByVal MyFileDelete As Boolean, ByVal MyIo As Boolean, ByVal MyLog As Boolean, ByVal MyStart As Boolean, ByVal MyStop As Boolean, ByVal MyLive As Boolean, ByVal MyBarcode As Boolean, ByVal MyShowPassword As Boolean, ByVal MyResetPassword As Boolean)
    BtnTool_Login.Enabled = MyLogin
    BtnTool_FileLoad.Enabled = MyFileLoad
    BtnTool_FileSave.Enabled = MyFileSave
    BtnTool_FileSaveAs.Enabled = MyFileSaveAs
    BtnTool_FileDelete.Enabled = MyFileDelete
    BtnTool_IO.Enabled = MyIo
    BtnTool_Log.Enabled = MyLog
    BtnTool_Start.Enabled = MyStart
    BtnTool_Stop.Enabled = MyStop
    CheckTool_CcdLive.Enabled = MyLive
    BtnTool_ReadBarcode.Enabled = MyBarcode
    B_FormLogin.BtnShowPassword.Visible = MyShowPassword
    B_FormLogin.BtnResetPassword.Visible = MyResetPassword
  End Sub
  '登入權限後各元件之致能狀態
  Public Sub SetBtnStateLevel(ByVal MyLevel As String)

    If StartKey = False Then Call SetBtnState(1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0) '   '上方工具列
    GroupProduct.Enabled = False                                                         '產品參數
    GroupAdv.Enabled = False                                                             '進階參數
    Panel_IO.Enabled = False                                                             'I/O 視窗

    Select Case MyLevel
      Case "未登入"

      Case "作業員"
        If StartKey = False Then Call SetBtnState(1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0) '上方工具列
        LabLevel.Text = "作業員"                                                         '顯示登入級別
        GroupProduct.Enabled = False                                                     '產品參數
        GroupAdv.Enabled = False                                                         '進階參數
        Panel_IO.Enabled = False                                                         'I/O 視窗
        PanelTimeInf.Visible = False                                                     '細項時間
        PanelService.Visible = False                                                     'Service

      Case "工程師"
        If StartKey = False Then Call SetBtnState(1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0) '上方工具列
        LabLevel.Text = "工程師"                                                         '顯示登入級別
        GroupProduct.Enabled = True                                                      '產品參數
        GroupAdv.Enabled = True                                                          '進階參數
        Panel_IO.Enabled = True                                                          'I/O 視窗
        PanelTimeInf.Visible = False                                                     '細項時間
        PanelService.Visible = False                                                     'Service

      Case "系統管理員"
        If StartKey = False Then Call SetBtnState(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1) '上方工具列
        LabLevel.Text = "系統管理員"                                                     '顯示登入級別
        GroupProduct.Enabled = True                                                      '產品參數
        GroupAdv.Enabled = True                                                          '進階參數
        Panel_IO.Enabled = True                                                          'I/O 視窗
        PanelTimeInf.Visible = False                                                     '細項時間
        PanelService.Visible = False                                                     'Service


      Case "程式設計師"
        Call SetBtnState(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)                          '上方工具列
        LabLevel.Text = "程式設計師"                                                     '顯示登入級別
        GroupProduct.Enabled = True                                                      '產品參數
        GroupAdv.Enabled = True                                                          '進階參數
        Panel_IO.Enabled = True                                                          'I/O 視窗
        PanelTimeInf.Visible = True                                                      '細項時間
        PanelService.Visible = True                                                      'Service
    End Select

    LabLevel.Tag = MyLevel
  End Sub
  '設定元件陣列指向
  Public Sub SetComponent()
    Dim i As Integer
    'DI 所有燈號以 Label 陣列指向 ----------------------------------------------------------------------
    LabDi(1) = LabDi_X101 : LabDi(2) = LabDi_X102 : LabDi(3) = LabDi_X103 : LabDi(4) = LabDi_X104     '|
    LabDi(5) = LabDi_X105 : LabDi(6) = LabDi_X106 : LabDi(7) = LabDi_X107 : LabDi(8) = LabDi_X108     '|
    LabDi(9) = LabDi_X109 : LabDi(10) = LabDi_X110 : LabDi(11) = LabDi_X111 : LabDi(12) = LabDi_X112  '|
    LabDi(13) = LabDi_X113 : LabDi(14) = LabDi_X114 : LabDi(15) = LabDi_X115 : LabDi(16) = LabDi_X116 '|
    '---------------------------------------------------------------------------------------------------
    'DO 所有狀態以 CheckBox 陣列指向 -----------------------------------------------------------------------------------
    CheckDo(1) = CheckDo_Y101 : CheckDo(2) = CheckDo_Y102 : CheckDo(3) = CheckDo_Y103 : CheckDo(4) = CheckDo_Y104     '|
    CheckDo(5) = CheckDo_Y105 : CheckDo(6) = CheckDo_Y106 : CheckDo(7) = CheckDo_Y107 : CheckDo(8) = CheckDo_Y108     '|
    CheckDo(9) = CheckDo_Y109 : CheckDo(10) = CheckDo_Y110 : CheckDo(11) = CheckDo_Y111 : CheckDo(12) = CheckDo_Y112  '|
    CheckDo(13) = CheckDo_Y113 : CheckDo(14) = CheckDo_Y114 : CheckDo(15) = CheckDo_Y115 : CheckDo(16) = CheckDo_Y116 '|
    '-------------------------------------------------------------------------------------------------------------------
    CheckRun_Live_CCD(1) = CheckRun_Live_CCD1 : CheckRun_Live_CCD(2) = CheckRun_Live_CCD2 : CheckRun_Live_CCD(3) = CheckRun_Live_CCD3 : CheckRun_Live_CCD(4) = CheckRun_Live_CCD4
    ImageViewer_CCD(1) = ImageViewer_CCD1 : ImageViewer_CCD(2) = ImageViewer_CCD2 : ImageViewer_CCD(3) = ImageViewer_CCD3 : ImageViewer_CCD(4) = ImageViewer_CCD4
    CCD_Session(1) = CCD1_Session : CCD_Session(2) = CCD2_Session : CCD_Session(3) = CCD3_Session : CCD_Session(4) = CCD4_Session
    CCD_Buffer(1) = CCD1_Buffer : CCD_Buffer(2) = CCD2_Buffer : CCD_Buffer(3) = CCD3_Buffer : CCD_Buffer(4) = CCD4_Buffer
    CCD_ImageBeforeRotate(1) = CCD1_ImageBeforeRotate : CCD_ImageBeforeRotate(2) = CCD2_ImageBeforeRotate : CCD_ImageBeforeRotate(3) = CCD3_ImageBeforeRotate : CCD_ImageBeforeRotate(4) = CCD4_ImageBeforeRotate
    CCD_WaitCapture(1) = CCD1_WaitCapture : CCD_WaitCapture(2) = CCD2_WaitCapture : CCD_WaitCapture(3) = CCD3_WaitCapture : CCD_WaitCapture(4) = CCD4_WaitCapture

    CCD_ImageSource(1) = CCD1_ImageSource : CCD_ImageSource(2) = CCD2_ImageSource : CCD_ImageSource(3) = CCD3_ImageSource : CCD_ImageSource(4) = CCD4_ImageSource
    TextTeach_Search_Light(1) = TextTeach_Search_Light1 : TextTeach_Search_Light(2) = TextTeach_Search_Light2 : TextTeach_Search_Light(3) = TextTeach_Search_Light3 : TextTeach_Search_Light(4) = TextTeach_Search_Light4
    TextTeach_Diameter_CCD(1) = TextTeach_Diameter_CCD1 : TextTeach_Diameter_CCD(2) = TextTeach_Diameter_CCD2 : TextTeach_Diameter_CCD(3) = TextTeach_Diameter_CCD3 : TextTeach_Diameter_CCD(4) = TextTeach_Diameter_CCD4
    TextTeach_DiameterTolerance_CCD(1) = TextTeach_DiameterTolerance_CCD1 : TextTeach_DiameterTolerance_CCD(2) = TextTeach_DiameterTolerance_CCD2 : TextTeach_DiameterTolerance_CCD(3) = TextTeach_DiameterTolerance_CCD3 : TextTeach_DiameterTolerance_CCD(4) = TextTeach_DiameterTolerance_CCD4
    'TextTeach_TrueCircle_CCD
    TextTeach_TrueCircle_CCD(1) = TextTeach_TrueCircle_CCD1 : TextTeach_TrueCircle_CCD(2) = TextTeach_TrueCircle_CCD2 : TextTeach_TrueCircle_CCD(3) = TextTeach_TrueCircle_CCD3 : TextTeach_TrueCircle_CCD(4) = TextTeach_TrueCircle_CCD4
    TextTeach_DefectLength_Inside_CCD(1) = TextTeach_DefectLength_Inside_CCD1 : TextTeach_DefectLength_Inside_CCD(2) = TextTeach_DefectLength_Inside_CCD2 : TextTeach_DefectLength_Inside_CCD(3) = TextTeach_DefectLength_Inside_CCD3 : TextTeach_DefectLength_Inside_CCD(4) = TextTeach_DefectLength_Inside_CCD4
    TextTeach_DefectLength_Outside_CCD(1) = TextTeach_DefectLength_Outside_CCD1 : TextTeach_DefectLength_Outside_CCD(2) = TextTeach_DefectLength_Outside_CCD2 : TextTeach_DefectLength_Outside_CCD(3) = TextTeach_DefectLength_Outside_CCD3 : TextTeach_DefectLength_Outside_CCD(4) = TextTeach_DefectLength_Outside_CCD4
    RadioAdv_Pixel_CCD(1) = RadioAdv_Pixel_CCD1 : RadioAdv_Pixel_CCD(2) = RadioAdv_Pixel_CCD2 : RadioAdv_Pixel_CCD(3) = RadioAdv_Pixel_CCD3 : RadioAdv_Pixel_CCD(4) = RadioAdv_Pixel_CCD4
    TextAdv_Pixel_CCD(1) = TextAdv_Pixel_CCD1 : TextAdv_Pixel_CCD(2) = TextAdv_Pixel_CCD2 : TextAdv_Pixel_CCD(3) = TextAdv_Pixel_CCD3 : TextAdv_Pixel_CCD(4) = TextAdv_Pixel_CCD4
    LabAdv_FovX_CCD(1) = LabAdv_FovX_CCD1 : LabAdv_FovX_CCD(2) = LabAdv_FovX_CCD2 : LabAdv_FovX_CCD(3) = LabAdv_FovX_CCD3 : LabAdv_FovX_CCD(4) = LabAdv_FovX_CCD4
    LabAdv_FovY_CCD(1) = LabAdv_FovY_CCD1 : LabAdv_FovY_CCD(2) = LabAdv_FovY_CCD2 : LabAdv_FovY_CCD(3) = LabAdv_FovY_CCD3 : LabAdv_FovY_CCD(4) = LabAdv_FovY_CCD4
    Calib_ImageAdjust_CCD(1) = Calib_ImageAdjust_CCD1 : Calib_ImageAdjust_CCD(2) = Calib_ImageAdjust_CCD2 : Calib_ImageAdjust_CCD(3) = Calib_ImageAdjust_CCD3 : Calib_ImageAdjust_CCD(4) = Calib_ImageAdjust_CCD4
    TextAdv_Calib_Light(1) = TextAdv_Calib_Light1 : TextAdv_Calib_Light(2) = TextAdv_Calib_Light2 : TextAdv_Calib_Light(3) = TextAdv_Calib_Light3 : TextAdv_Calib_Light(4) = TextAdv_Calib_Light4

    For i = 1 To 4
      Calib_PixelMeasurements(i) = New Collection(Of MeasurementType)(New MeasurementType() {MeasurementType.CenterOfMassX, MeasurementType.CenterOfMassY, MeasurementType.WaddelDiskDiameter})
      '(0:中心X , 1:中心Y , 2:實際直徑 , 3:面積 , 4:最大直徑 , 5:真園度)
      PixelMeasurements_CCD(i) = New Collection(Of MeasurementType)(New MeasurementType() {MeasurementType.CenterOfMassX, MeasurementType.CenterOfMassY, MeasurementType.WaddelDiskDiameter, MeasurementType.Area, MeasurementType.MaxFeretDiameter, MeasurementType.TypeFactor})
      ParticleFilterCriteria_RemoveLength(i) = New Collection(Of ParticleFilterCriteria)
      ParticleFilterCriteria_RemoveLength(i).Clear()
      ParticleFilterCriteria_RemoveLength(i).Add(New ParticleFilterCriteria(MeasurementType.EquivalentEllipseMinorAxis, New Range(0, 1), False, RangeType.InsideRange))
      ParticleFilterCriteria_RemoveMaxLength(i) = New Collection(Of ParticleFilterCriteria)
      ParticleFilterCriteria_RemoveMaxLength(i).Clear()
      ParticleFilterCriteria_RemoveMaxLength(i).Add(New ParticleFilterCriteria(MeasurementType.MaxFeretDiameter, New Range(0, 1), False, RangeType.InsideRange))
      ParticleFilterOptions_RemoveLength(i) = New ParticleFilterOptions(True, False, False, Connectivity.Connectivity8)

      ImageAdjust_CCD(i) = New VisionImage
      ImageAdjustBeforeHull_CCD(i) = New VisionImage
      ImageAdjustHull_CCD(i) = New VisionImage
      ImageAdjust_DefectOut(i) = New VisionImage
      RoiDefectOutside_CCD(i) = New Roi
    Next
    ParticleFilterCriteria_RemoveTrueCircle.Clear()
    ParticleFilterCriteria_RemoveTrueCircle.Add(New ParticleFilterCriteria(MeasurementType.ElongationFactor, New Range(0, 5), False, RangeType.InsideRange))

    ImageAdjustMask.SetSize(2448, 2048)
    ImageAdjustMask.FillImage(New PixelValue(0))

    '作業視窗 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    LabRun_Msg_CCD(1) = LabRun_Msg_CCD1 : LabRun_Msg_CCD(2) = LabRun_Msg_CCD2 : LabRun_Msg_CCD(3) = LabRun_Msg_CCD3 : LabRun_Msg_CCD(4) = LabRun_Msg_CCD4
    LabRun_Diameter_CCD(1) = LabRun_Diameter_CCD1 : LabRun_Diameter_CCD(2) = LabRun_Diameter_CCD2 : LabRun_Diameter_CCD(3) = LabRun_Diameter_CCD3 : LabRun_Diameter_CCD(4) = LabRun_Diameter_CCD4
    LabRun_Defect_TrueCircle_CCD(1) = LabRun_Defect_TrueCircle_CCD1 : LabRun_Defect_TrueCircle_CCD(2) = LabRun_Defect_TrueCircle_CCD2 : LabRun_Defect_TrueCircle_CCD(3) = LabRun_Defect_TrueCircle_CCD3 : LabRun_Defect_TrueCircle_CCD(4) = LabRun_Defect_TrueCircle_CCD4
    'LabRun_Defect_Area_CCD(1) = LabRun_Defect_Area_CCD1 : LabRun_Defect_Area_CCD(2) = LabRun_Defect_Area_CCD2 : LabRun_Defect_Area_CCD(3) = LabRun_Defect_Area_CCD3 : LabRun_Defect_Area_CCD(4) = LabRun_Defect_Area_CCD4

    LabSearch1_Result_CCD(1) = LabSearch1_Result_CCD1 : LabSearch1_Result_CCD(2) = LabSearch1_Result_CCD2 : LabSearch1_Result_CCD(3) = LabSearch1_Result_CCD3 : LabSearch1_Result_CCD(4) = LabSearch1_Result_CCD4

    'Search2 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    LabSearch2_Result_CCD(1) = LabSearch2_Result_CCD1 : LabSearch2_Result_CCD(2) = LabSearch2_Result_CCD2 : LabSearch2_Result_CCD(3) = LabSearch2_Result_CCD3 : LabSearch2_Result_CCD(4) = LabSearch2_Result_CCD4
    LabSearch2_Result_CCD(1) = LabSearch2_Result_CCD1 : LabSearch2_Result_CCD(2) = LabSearch2_Result_CCD2 : LabSearch2_Result_CCD(3) = LabSearch2_Result_CCD3 : LabSearch2_Result_CCD(4) = LabSearch2_Result_CCD4
    TextServer_Receive_CCD(1) = TextServer_Receive_CCD1 : TextServer_Receive_CCD(2) = TextServer_Receive_CCD2 : TextServer_Receive_CCD(3) = TextServer_Receive_CCD3 : TextServer_Receive_CCD(4) = TextServer_Receive_CCD4
    LabServer_Receive_ContinueCount_CCD(1) = LabServer_Receive_ContinueCount_CCD1 : LabServer_Receive_ContinueCount_CCD(2) = LabServer_Receive_ContinueCount_CCD2 : LabServer_Receive_ContinueCount_CCD(3) = LabServer_Receive_ContinueCount_CCD3 : LabServer_Receive_ContinueCount_CCD(4) = LabServer_Receive_ContinueCount_CCD4
    LabServer_Receive_NonContinueCount_CCD(1) = LabServer_Receive_NoncontinueCount_CCD1 : LabServer_Receive_NonContinueCount_CCD(2) = LabServer_Receive_NoncontinueCount_CCD2 : LabServer_Receive_NonContinueCount_CCD(3) = LabServer_Receive_NoncontinueCount_CCD3 : LabServer_Receive_NonContinueCount_CCD(4) = LabServer_Receive_NoncontinueCount_CCD4
  End Sub
  '寫入運行記錄
  Public Sub WriteMessage(ByVal MyMsg As String)
    Dim MyToday As String = Format(Now, "yyyyMMdd")
    Dim MyMsg_All As String = ""
    Dim MyLevel As String = ""

    If Directory.Exists(ProgramPath & "\Message") = False Then Directory.CreateDirectory(ProgramPath & "\Message")
    Try
      FileOpen(5, ProgramPath & "\Message\" & MyToday & ".Err", OpenMode.Append)
      MyMsg_All = Format(Now, "yyyyMMdd  HH:mm:ss    ") & MyMsg
      If LabLevel.Tag <> "未登入" Then
        MyLevel = LabLevel.Tag
        Select Case LabLevel.Tag
          'Case "工程師", "系統管理員" : MyLevel = " (" & LabLevel.Tag & "：" & LabBadgeNb.Text & ")"
          Case "作業員", "程式設計師" : MyLevel = " (" & LabLevel.Tag & ")"
        End Select
      End If
      PrintLine(5, Format(Now, "yyyyMMdd  HH:mm:ss    ") & MyMsg)
      FileClose(5)
    Catch ex As Exception : End Try
  End Sub
  Private Sub A_FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ''偵測是否取得合法之 License --------------------------------------------------------
    'Dim LicensePassKey As Boolean = False
    'Dim LicenseCode As String = ""
    'Try
    '  If Dir("C:\WINDOWS\system32\bofeng.dll", FileAttribute.Normal) <> "" Then
    '    FileOpen(1, "C:\WINDOWS\system32\bofeng.dll", OpenMode.Input)
    '    Do Until EOF(1)
    '      LicenseCode = LineInput(1)
    '      'MsgBox(GetLicense.GetLicenseCode)
    '      If GetLicense.GetLicenseCode = LicenseCode Then
    '        LicensePassKey = True
    '        Exit Do
    '      End If

    '    Loop
    '    FileClose(1)
    '  End If
    'Catch ex As Exception : End Try
    'If LicensePassKey = False Then
    '  MsgBox("請取得合法之 License !!", MsgBoxStyle.Exclamation, "警告")
    '  End
    'End If

    '主程式版本 ----------------------------------------------------------------------------------
    ProgramVer = Strings.Left(Application.ProductVersion, Application.ProductVersion.Length - 2)
    LabProgramInfo.Text = "冠睿薄帶孔位自動量測系統 V" & ProgramVer

    '關閉執行緒跨 Form Error 偵測 -----------------------
    A_FormMain.CheckForIllegalCrossThreadCalls = False '|
    '----------------------------------------------------

    '設定 Viewer Show 圖的大小 ---------------
    Dim MyZoom As Double = 0.21             '|
    ImageViewer_CCD1.ZoomInfo.X = MyZoom    '|
    ImageViewer_CCD1.ZoomInfo.Y = MyZoom    '|
    ImageViewer_CCD2.ZoomInfo.X = MyZoom    '|
    ImageViewer_CCD2.ZoomInfo.Y = MyZoom    '|
    ImageViewer_CCD3.ZoomInfo.X = MyZoom    '|
    ImageViewer_CCD3.ZoomInfo.Y = MyZoom    '|
    ImageViewer_CCD4.ZoomInfo.X = MyZoom    '|
    ImageViewer_CCD4.ZoomInfo.Y = MyZoom    '|
    '-----------------------------------------

    ImageResult.SetSize(1000, 900)

    ImageViewer_CCD1.ToolsShown = ViewerTools.Selection + ViewerTools.Pan + ViewerTools.ZoomIn + ViewerTools.ZoomOut
    ImageViewer_CCD2.ToolsShown = ViewerTools.Selection + ViewerTools.Pan + ViewerTools.ZoomIn + ViewerTools.ZoomOut
    ImageViewer_CCD3.ToolsShown = ViewerTools.Selection + ViewerTools.Pan + ViewerTools.ZoomIn + ViewerTools.ZoomOut
    ImageViewer_CCD4.ToolsShown = ViewerTools.Selection + ViewerTools.Pan + ViewerTools.ZoomIn + ViewerTools.ZoomOut

    '開啟 CCD1 ----------------------------------------------------------------------
    Try                                                                            '|
      CCD1_Session = New ImaqdxSession("cam0")                                     '|
      CCD1_Session.Acquisition.Configure(ImaqdxAcquisitionType.Continuous, 10)     '|
      CCD1_Session.Acquisition.Unconfigure()                                       '|
      CCD1_Session.Acquisition.Configure(ImaqdxAcquisitionType.Continuous, 10)     '|
      CCD1_Session.Acquisition.Start()                                             '|
      '                                                                            '|
      '程式一啟動 , 先執行一次執行緒將其預先配置給記憶體 , 防止例外錯誤            '|
      CCD1_ThreadLive = New Threading.Thread(AddressOf FunctionThread_Live_CCD1)   '|
      CCD1_ThreadLive.SetApartmentState(Threading.ApartmentState.STA)              '|
      CCD1_ThreadLive.Start()                                                      '|
      Do Until CCD1_Thread_StartOnlyTime_Live = False : Loop                       '|
      CCD1_ThreadLiveStopKey = True                                                '|
      '正式啟動 Camera                                                             '|
      CCD1_ThreadLive = New Threading.Thread(AddressOf FunctionThread_Live_CCD1)   '|
      CCD1_ThreadLive.SetApartmentState(Threading.ApartmentState.STA)              '|
      CCD1_ThreadLive.Start()                                                      '|
      Call WriteMessage("CCD1 啟動成功")                                           '|
      '                                                                            '|
    Catch ex As Exception                                                          '|
      Call WriteMessage("CCD1 啟動失敗")                                           '|
      MsgBox("CCD1 啟動失敗", MsgBoxStyle.Critical, "Form Load")                   '|
    End Try                                                                        '|
    '--------------------------------------------------------------------------------

    '開啟 CCD2 ----------------------------------------------------------------------
    Try                                                                            '|
      CCD2_Session = New ImaqdxSession("cam1")                                     '|
      CCD2_Session.Acquisition.Configure(ImaqdxAcquisitionType.Continuous, 10)     '|
      CCD2_Session.Acquisition.Unconfigure()                                       '|
      CCD2_Session.Acquisition.Configure(ImaqdxAcquisitionType.Continuous, 10)     '|
      CCD2_Session.Acquisition.Start()                                             '|
      '                                                                            '|
      '程式一啟動 , 先執行一次執行緒將其預先配置給記憶體 , 防止例外錯誤            '|
      CCD2_ThreadLive = New Threading.Thread(AddressOf FunctionThread_Live_CCD2)   '|
      CCD2_ThreadLive.SetApartmentState(Threading.ApartmentState.STA)              '|
      CCD2_ThreadLive.Start()                                                      '|
      Do Until CCD2_Thread_StartOnlyTime_Live = False : Loop                       '|
      CCD2_ThreadLiveStopKey = True                                                '|
      '正式啟動 Camera                                                             '|
      CCD2_ThreadLive = New Threading.Thread(AddressOf FunctionThread_Live_CCD2)   '|
      CCD2_ThreadLive.SetApartmentState(Threading.ApartmentState.STA)              '|
      CCD2_ThreadLive.Start()                                                      '|
      Call WriteMessage("CCD2 啟動成功")                                           '|
      '                                                                            '|
    Catch ex As Exception                                                          '|
      Call WriteMessage("CCD2 啟動失敗")                                           '|
      MsgBox("CCD2 啟動失敗", MsgBoxStyle.Critical, "Form Load")                   '|
    End Try                                                                        '|
    '--------------------------------------------------------------------------------

    '開啟 CCD3 ----------------------------------------------------------------------
    Try                                                                            '|
      CCD3_Session = New ImaqdxSession("cam2")                                     '|
      CCD3_Session.Acquisition.Configure(ImaqdxAcquisitionType.Continuous, 10)     '|
      CCD3_Session.Acquisition.Unconfigure()                                       '|
      CCD3_Session.Acquisition.Configure(ImaqdxAcquisitionType.Continuous, 10)     '|
      CCD3_Session.Acquisition.Start()                                             '|
      '                                                                            '|
      '程式一啟動 , 先執行一次執行緒將其預先配置給記憶體 , 防止例外錯誤            '|
      CCD3_ThreadLive = New Threading.Thread(AddressOf FunctionThread_Live_CCD3)   '|
      CCD3_ThreadLive.SetApartmentState(Threading.ApartmentState.STA)              '|
      CCD3_ThreadLive.Start()                                                      '|
      Do Until CCD3_Thread_StartOnlyTime_Live = False : Loop                       '|
      CCD3_ThreadLiveStopKey = True                                                '|
      '正式啟動 Camera                                                             '|
      CCD3_ThreadLive = New Threading.Thread(AddressOf FunctionThread_Live_CCD3)   '|
      CCD3_ThreadLive.SetApartmentState(Threading.ApartmentState.STA)              '|
      CCD3_ThreadLive.Start()                                                      '|
      Call WriteMessage("CCD3 啟動成功")                                           '|
      '                                                                            '|
    Catch ex As Exception                                                          '|
      Call WriteMessage("CCD3 啟動失敗")                                           '|
      MsgBox("CCD3 啟動失敗", MsgBoxStyle.Critical, "Form Load")                   '|
    End Try                                                                        '|
    '--------------------------------------------------------------------------------

    '開啟 CCD4 ----------------------------------------------------------------------
    Try                                                                            '|
      CCD4_Session = New ImaqdxSession("cam3")                                     '|
      CCD4_Session.Acquisition.Configure(ImaqdxAcquisitionType.Continuous, 10)     '|
      CCD4_Session.Acquisition.Unconfigure()                                       '|
      CCD4_Session.Acquisition.Configure(ImaqdxAcquisitionType.Continuous, 10)     '|
      CCD4_Session.Acquisition.Start()                                             '|
      '                                                                            '|
      '程式一啟動 , 先執行一次執行緒將其預先配置給記憶體 , 防止例外錯誤            '|
      CCD4_ThreadLive = New Threading.Thread(AddressOf FunctionThread_Live_CCD4)   '|
      CCD4_ThreadLive.SetApartmentState(Threading.ApartmentState.STA)              '|
      CCD4_ThreadLive.Start()                                                      '|
      Do Until CCD4_Thread_StartOnlyTime_Live = False : Loop                       '|
      CCD4_ThreadLiveStopKey = True                                                '|
      '正式啟動 Camera                                                             '|
      CCD4_ThreadLive = New Threading.Thread(AddressOf FunctionThread_Live_CCD4)   '|
      CCD4_ThreadLive.SetApartmentState(Threading.ApartmentState.STA)              '|
      CCD4_ThreadLive.Start()                                                      '|
      Call WriteMessage("CCD4 啟動成功")                                           '|
      '                                                                            '|
    Catch ex As Exception                                                          '|
      Call WriteMessage("CCD4 啟動失敗")                                           '|
      MsgBox("CCD4 啟動失敗", MsgBoxStyle.Critical, "Form Load")                   '|
    End Try                                                                        '|
    '--------------------------------------------------------------------------------

    '建立 Search2 視窗 ----------------------------------------------------------------------
    ClassIntPtr(1) = NewImageView(Panel_Search2_CCD1.Handle)
    ClassIntPtr(2) = NewImageView(Panel_Search2_CCD2.Handle)
    ClassIntPtr(3) = NewImageView(Panel_Search2_CCD3.Handle)
    ClassIntPtr(4) = NewImageView(Panel_Search2_CCD4.Handle)

    Call SetComponent()

    '開啟 I/O 卡 ----------------------------------------------------------------------------------------------
    Try
      InstantCtrl_DI.SelectedDevice = New DeviceInformation(1)
      InstantCtrl_DO.SelectedDevice = New DeviceInformation(1)
      For i As Integer = 1 To 16
        CheckDo(i).Checked = IIf(DO1_Y(i) = True, True, False)
      Next
      Call WriteMessage("I/O 啟動成功")
      TimerDIO.Enabled = True
    Catch ex As Exception
      Call WriteMessage("I/O 啟動失敗")
      MsgBox("I/O 啟動失敗", MsgBoxStyle.Critical, "Form Load")
    End Try

    '啟動光源 ---------------------------------------------------------------------------------------------------
    Try                                                                                                        '|
      Dim mPortName As String = "com1"                 '欲開啟的通訊埠                                         '|
      Dim mBaudRate As Integer = 115200                '通訊速度                                               '|
      Dim mParity As IO.Ports.Parity = Parity.None     '同位位元檢查設定                                       '|
      Dim mDataBit As Integer = 8                      '資料位元設定值                                         '|
      Dim mStopbit As IO.Ports.StopBits = StopBits.One '停止位元設定值                                         '|
      '                                                                                                        '|
      RS232_Light = New IO.Ports.SerialPort(mPortName, mBaudRate, mParity, mDataBit, mStopbit) '設定RS232參數  '|
      '                                                                                                        '|
      If Not RS232_Light.IsOpen Then RS232_Light.Open() '開啟通訊埠                                            '|
      LightControl(0) = &H1                                                                                    '|
      LightControl(1) = &H6                                                                                    '|
      LightControl(3) = &HA                                                                                    '|
      LightControl(4) = &H0                                                                                    '|
      Call WriteMessage("光源開啟成功(COM1)")                                                                  '|
    Catch ex As Exception                                                                                      '|
      Call WriteMessage("光源開啟失敗(COM1)")                                                                  '|
      MsgBox("光源開啟失敗(COM1)", MsgBoxStyle.Critical, "Form Load")                                          '|
    End Try                                                                                                    '|
    '------------------------------------------------------------------------------------------------------------
    If SerialPort_Barcode.IsOpen = False Then SerialPort_Barcode.Open()
    '啟動 Barcode Reader ------------------------------------------------------------------------------------------
    Try                                                                                                          '|
      'Dim mPortName As String = "com2"                 '欲開啟的通訊埠                                           '|
      'Dim mBaudRate As Integer = 9600                  '通訊速度                                                 '|
      'Dim mParity As IO.Ports.Parity = Parity.None     '同位位元檢查設定                                         '|
      'Dim mDataBit As Integer = 8                      '資料位元設定值                                           '|
      'Dim mStopbit As IO.Ports.StopBits = StopBits.One '停止位元設定值                                           '|
      '                                                                                                          '|
      RS232_Barcode = New IO.Ports.SerialPort("COM3", 9600, Parity.None, 8, StopBits.One) '設定RS232參數  '|

      '|
      If Not RS232_Barcode.IsOpen Then RS232_Barcode.Open() '開啟通訊埠                                          '|
      TimerBarcode.Enabled = True
      Call WriteMessage("Barcode Reader 開啟成功(COM3)")                                                         '|
    Catch ex As Exception                                                                                        '|
      Call WriteMessage("Barcode Reader 開啟失敗(COM3)")                                                         '|
      MsgBox("Barcode Reader 開啟失敗(COM3)", MsgBoxStyle.Critical, "Form Load")                                 '|
    End Try                                                                                                      '|
    '--------------------------------------------------------------------------------------------------------------

    '載入機械參數 ----------------------------------------------------------------------
    MachineParPath = ProgramPath & "\Machine.ini"                                     '|
    If File.Exists(MachineParPath) = False Then                                       '|
      Call WriteMessage("機械參數檔不存在")                                           '|
      MsgBox("機械參數檔不存在", MsgBoxStyle.Exclamation, "Form Load")                '|
    Else                                                                              '|
      Try : Call LoadMachineParFormFile()                                             '|
      Catch ex As Exception                                                           '|
        MsgBox("機械參數載入失敗", MsgBoxStyle.Critical, "Form Load")                 '|
      End Try                                                                         '|
    End If                                                                            '|
    '-----------------------------------------------------------------------------------

    '偵測存放檢測資料之目錄夾是否存在，不存在則建立
    If Directory.Exists(SearchDataPathRoot) = False Then IO.Directory.CreateDirectory(SearchDataPathRoot)

    '偵測存放檢測2圖檔目錄夾是否存在，不存在則建立
    Try
      If Directory.Exists(SourceImagePath) = False Then
        Directory.CreateDirectory(SourceImagePath)
        LabRunningMsg.Text = SourceImagePath & " 目錄夾建立成功"
      End If
    Catch ex As Exception
      LabRunningMsg.Text = SourceImagePath & " 目錄夾建立失敗"
      Call WriteMessage(SourceImagePath & " 目錄夾建立失敗")
    End Try

    'Binary Inverse
    Calib_Pixel_LookupTable.Add(1)
    For i As Integer = 1 To 255
      Calib_Pixel_LookupTable.Add(0)
    Next

    Calib_StructElem.Shape = StructuringElementShape.Square
    CCD_StructElem.Shape = StructuringElementShape.Square
    CCD_StructElem_Open.Shape = StructuringElementShape.Square

    '啟動PLC -------------------------------------------------------------------------------------------------------------------------------------
    Radio_PlcRunning.Checked = True
    Call BtnOpen_Click(BtnOpen, e)

    '啟動PLC掃描(狀態及I/O)之執行緒 -----------------------------------------------------
    PlcRunStates_Thread = New Threading.Thread(AddressOf FunctionThread_RunStates_PLC) '|
    PlcRunStates_Thread.SetApartmentState(Threading.ApartmentState.STA)                '|
    PlcRunStates_Thread.Start()                                                        '|
    '------------------------------------------------------------------------------------

    '啟動PLC掃描(是否Alarm)之執行緒 ------------------------------------------------------------
    ShowPlcAlarmCode_Thread = New Threading.Thread(AddressOf FunctionThread_ShowPlcAlarmCode) '|
    ShowPlcAlarmCode_Thread.SetApartmentState(Threading.ApartmentState.STA)                   '|
    ShowPlcAlarmCode_Thread.Start()                                                           '|
    '-------------------------------------------------------------------------------------------

    '啟動與檢測二溝通Socket之執行緒 ---------------------------
    ListenThread = New Thread(AddressOf Search2_StartServer) '|
    ListenThread.IsBackground = True                         '|
    ListenThread.Start()                                     '|
    '----------------------------------------------------------

    Call LoadLastProgramName() '載入最後執行之產品檔
  End Sub
  '工具列→等級登入鈕
  Private Sub BtnTool_Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_Login.Click
    B_FormLogin.TextLogin_BadgeNb.Text = ""
    B_FormLogin.ShowDialog()
  End Sub
  '工具列→載入產品檔鈕
  Private Sub BtnTool_FileLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_FileLoad.Click
    C_FormFile.BtnOpen.Visible = True
    C_FormFile.BtnDelete.Visible = False
    C_FormFile.ShowDialog()
  End Sub
  '工具列→儲存產品檔鈕
  Public Sub BtnTool_FileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_FileSave.Click
    Call SaveMachineParToFile() '儲存[機械參數]
    If LabFileName.Text = "" Then
      Call BtnTool_FileSaveAs_Click(sender, e)
    Else
      Call SaveProductParToFile(LabFileName.Text)
    End If
  End Sub
  '工具列→另存產品檔鈕
  Public Sub BtnTool_FileSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_FileSaveAs.Click
    SaveAs_FileName = ""
    FormSaveAs.TextSaveAs_FileName.Text = LabFileName.Text

    If FormSaveAs.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim MyFilePath As String = ProgramPath & "\Product\"
      Dim MyDirExist As Boolean = Directory.Exists(MyFilePath)

      If MyDirExist = False Then Directory.CreateDirectory(MyFilePath)
      If Strings.Right(SaveAs_FileName, 4) = ".ccd" Then SaveAs_FileName = Mid(SaveAs_FileName, 1, SaveAs_FileName.Length - 4)
      MyDirExist = Directory.Exists(MyFilePath & SaveAs_FileName)
      If MyDirExist = False Then Directory.CreateDirectory(MyFilePath & SaveAs_FileName)
      If SaveAs_FileName = "" Then Exit Sub

      MyDirExist = File.Exists(MyFilePath & SaveAs_FileName & "\" & SaveAs_FileName & ".ccd")
      If MyDirExist = True Then
        MsgBox("產品擋：" & SaveAs_FileName & " 已存在 , 請重新輸入", MsgBoxStyle.Exclamation, "儲存檔案")
        Exit Sub
      End If
      Call SaveProductParToFile(SaveAs_FileName)
    End If
  End Sub
  '工具列→刪除產品檔鈕
  Private Sub BtnTool_FileDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_FileDelete.Click
    C_FormFile.BtnOpen.Visible = False
    C_FormFile.BtnDelete.Visible = True
    C_FormFile.ShowDialog()
  End Sub
  '工具列→I/O鈕
  Private Sub BtnTool_IO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_IO.Click
    TabControl_SendData.SelectedIndex = 2
  End Sub
  '工具列→運行記錄鈕
  Private Sub BtnTool_Log_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_Log.Click
    GroupTools.Enabled = False
    If FormLog.Created = False Then FormLog.Show(Me)
  End Sub
  '工具列→啟動鈕
  Private Sub BtnTool_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_Start.Click
    Dim i As Integer = 0
    Dim MyMsgResult As Microsoft.VisualBasic.MsgBoxResult = Nothing
    Dim MyTime1 As Date = Now
    Dim MyTime2 As TimeSpan

    If Lab_HomeFinish_M1001.BackColor = Color.WhiteSmoke Then
      MsgBox("馬達尚未復歸，請先執行馬達復歸")
      Exit Sub
    End If

    Call WriteMessage("使用者按下啟動鈕")

    '偵測是否已載入產品檔 -----------------------------------------------------------------------------------------------------------------------------------
    If LabFileName.Text = "" Then
      Call WriteMessage("尚未載入產品檔")
      MsgBox("請先載入產品擋", MsgBoxStyle.Exclamation, "啟動")
      Exit Sub
    End If

    '偵測檢測功能是否勾選 -----------------------------------------------------------------------------------------------------------------------------------
    If CheckAdv_Option_Search.Checked = False Then
      If MsgBox("檢測功能未開啟 , 是否繼續執行?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "啟動") = MsgBoxResult.No Then
        Exit Sub
      Else
        Call WriteMessage("[檢測]功能未開啟 , 人員強制執行")
      End If
    End If

    Dim MyTextBox() As TextBox = {TextOpInf_UserNo, TextOpInf_NotNumber, TextOpInf_ProductNumber, TextOpInf_MachineCode, TextOpInf_MouldNumber, TextOpInf_OunchNeedleNumberUp, TextOpInf_OunchNeedleNumberDown, TextOpInf_PackNumber}
    Dim MyLabelName() As String = {"人員工號", "批號", "料號", "打拔機編號", "模具編號", "上沖針編號", "下沖針編號", "包號"}
    Dim MyTextName As String = ""

    For i = 0 To MyTextBox.GetLength(0) - 1
      If MyTextBox(i).Text = "" Then
        MsgBox(MyLabelName(i) & " 尚未輸入", MsgBoxStyle.Exclamation, "啟動")
        TabControl_SendData.SelectedIndex = 0
        MyTextBox(i).Focus()
        Exit Sub
      End If
    Next

    '設定 NG 圖存放路徑 -------------------------------------------------------------------------------------------------------------------------------------
    If CheckAdv_Option_Search.Checked = True Then
      '建立 ProgramPath\NG Image 目錄夾
      Try
        If Directory.Exists(NgImagePath) = False Then
          Directory.CreateDirectory(NgImagePath)
          LabRunningMsg.Text = NgImagePath & " 目錄夾建立成功"
        End If
      Catch ex As Exception
        LabRunningMsg.Text = NgImagePath & " 目錄夾建立失敗"
        Call WriteMessage(NgImagePath & " 目錄夾建立失敗")
      End Try

      NgImagePath = ProgramPath & "\NG Image\" & LabFileName.Text
      '建立 ProgramPath\NG Image\產品檔名稱 之目錄夾
      Try
        If Directory.Exists(NgImagePath) = False Then
          Directory.CreateDirectory(NgImagePath)
          LabRunningMsg.Text = NgImagePath & " 目錄夾建立成功"
        End If
      Catch ex As Exception
        LabRunningMsg.Text = NgImagePath & " 目錄夾建立失敗"
        Call WriteMessage(NgImagePath & " 目錄夾建立失敗")
      End Try
    End If

    '設定原始圖存放路徑 -------------------------------------------------------------------------------------------------------------------------------------
    '建立 ProgramPath\Source Image 目錄夾
    Try
      If Directory.Exists(SourceImagePath) = False Then
        Directory.CreateDirectory(SourceImagePath)
        LabRunningMsg.Text = SourceImagePath & " 目錄夾建立成功"
      End If
    Catch ex As Exception
      LabRunningMsg.Text = SourceImagePath & " 目錄夾建立失敗"
      Call WriteMessage(SourceImagePath & " 目錄夾建立失敗")
    End Try

    '相關元件 Disable ------------------------------------------------------------------------------------------------------------------------------------------
    'Call B_FormLogin.CheckPassword("作業員")               '自動跳回作業員等級
    Call SetBtnState(0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0) '設定控制按鈕致能狀態
    PanelParameter.Enabled = False                          '參數頁面→關
    BtnRun_ResetRunIndex.Enabled = False                    '[清除作業程序]鈕→關
    TabControl_SendData.SelectedIndex = 0                        '回到作業視窗

    '相關參數初始 ----------------------------------------------------------------------------------------------------------------------------------------------
    'TabControl_AOI.SelectedIndex = 0                  '畫面切回 [作業視窗]
    If CheckTool_CcdLive.Checked = True Then CheckTool_CcdLive.Checked = False ' '若為Live則關閉Live
    For i = 1 To 4
      'If CheckRun_Live_CCD(i).Checked = True Then CheckRun_Live_CCD(i).Checked = False '     '若為 Live 則關閉
      LabRun_Msg_CCD(i).Text = "" : LabRun_Msg_CCD(i).BackColor = Color.WhiteSmoke           '[訊息] 欄初始
      LabRun_Diameter_CCD(i).Text = "" : LabRun_Diameter_CCD(i).BackColor = Color.WhiteSmoke '[孔徑] 欄初始
      LabRun_Defect_TrueCircle_CCD(i).Text = ""                                              '[瑕疵面積比] 欄初始
    Next i
    LabRun_Distance_LeftRight.Text = "" : LabRun_Distance_LeftRight.ForeColor = Color.Black  '[左右孔距離]欄初始
    LabRun_Distance_UpDown.Text = "" : LabRun_Distance_UpDown.ForeColor = Color.Black        '[上下孔距離]欄初始
    LabRun_SearchResult.Text = "" : LabRun_SearchResult.BackColor = Color.WhiteSmoke         '檢測結果(OK or NG)初始
    LabTimeInf_Total.Text = ""
    'Call ChangeDO(2, False) '條碼讀取完成信號→OFF

    '開啟燈光 --------------------------------------------------------------------------------------------------------------------------------------------------
    Call BtnLight_On_Click(BtnTeach_SearchLight_On, e)

    'RunIndex_Main = 1      '執行步驟值
    Call ChangeDO(1, True) 'AOI Ready 信號→ON
    StartKey = True        '表目前為執行狀態
    LabRunningMsg.Text = "視覺檢測啟動"
    Call WriteMessage("視覺檢測啟動")

    Call Btn_AlarmReset_M1300_Click(Btn_AlarmReset_M1300, Nothing) '執行警報復歸
    Call Btn_StandbyPositionMove_M1154_Click(Btn_StandbyPositionMove_M1154, Nothing) '馬達移至待命區

    PlcThreadStopKey = True

    TextOpInf_DateTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss") '取得目前日期及時間

    Do : Application.DoEvents() : Threading.Thread.Sleep(1)

      Select Case RunIndex_Main
        Case 1 '等待 PLC Reader 訊號 ===========================================================================================================================
          If StartKey = False Then Exit Select
          LabRunningMsg.Text = "等待條碼讀取訊號" : LabRunningMsg.Refresh()
          If DI1_X(1) = True Then                                 '接收到 PLC 條碼讀取信號
            If CheckAdv_Option_Barcode.Checked = True Then        '是否開啟條碼讀取功能
ReReadBarcode:
              TextRun_Barcode_Reader.Text = "" : TextRun_Barcode_Reader.Refresh() '清除 Barcode 欄位
              Call BtnReadBarcode_Click(BtnTool_ReadBarcode, e)   '讀取 Barcode

              '判斷條碼受否讀取成功
              If TextRun_Barcode_Reader.Text.Length = 0 Then
                Call WriteMessage("條碼讀取錯誤 → [" & TextRun_Barcode_Reader.Text & "]")
                MyMsgResult = MsgBox("條碼讀取錯誤" & vbNewLine & vbNewLine & vbNewLine & "[Retry] → 重新讀取" & vbNewLine & vbNewLine & "[Cancel] → 手動輸入", MsgBoxStyle.RetryCancel, "Start")
                If MyMsgResult = MsgBoxResult.Retry Then '重新讀取條碼
                  Call Btn_AlarmReset_M1300_Click(Btn_AlarmReset_M1300, e)
                  GoTo ReReadBarcode
                Else '手動輸入條碼
                  TextRun_Barcode_Reader.Text = ""
                  Dim MyDialogResult As DialogResult = Dialog_KeyinBarcode.DialogResult
                  Dialog_KeyinBarcode.ShowDialog(Me)
                  If MyDialogResult = Windows.Forms.DialogResult.OK Then
                    Call WriteMessage("手動輸入條碼 → [" & TextRun_Barcode_Reader.Text & "]")
                    LabRunningMsg.Text = "手動輸入條碼完成" : LabRunningMsg.Refresh()
                  Else
                    LabRunningMsg.Text = "手動輸入條碼失敗" : LabRunningMsg.Refresh()
                    'Btn_StandbyPositionMove_M1154_Click(Btn_StandbyPositionMove_M1154, Nothing)
                    Call ChangeDO(1, False)              'AOI Ready 信號→OFF
                    Exit Select
                  End If
                End If
              Else
                Call WriteMessage("自動讀取條碼 → [" & TextRun_Barcode_Reader.Text & "]")
                LabRunningMsg.Text = "自動讀取條碼完成" : LabRunningMsg.Refresh()
              End If
            End If
            Call ChangeDO(2, True) '條碼讀取完成信號→ON
            RunIndex_Main = 5
          End If
          Call ScanPlcStates()
          Call ScanPlcDIO()
          LaserHeight = Val(Text_LaserHeight_D950.Text)
          If DI1_X(2) = True Then RunIndex_Main = 5

        Case 5 '等待 PLC 取像訊號 ==============================================================================================================================
          If StartKey = False Then Exit Select
          LabRunningMsg.Text = "等待取像訊號" : LabRunningMsg.Refresh()
          If DI1_X(2) = True Then RunIndex_Main = 10

        Case 10 '取像→檢測 ====================================================================================================================================
          If StartKey = False Then Exit Select
          Call ChangeDO(2, False) '條碼讀取完成信號→OFF
          Dim MyResult As String = "OK" '檢測結果

          '偵測雷射測高產品厚度是否超規
          If LaserHeight > Val(TextTeach_Laser_LimitUp.Text) OrElse LaserHeight < Val(TextTeach_Laser_LimitDown.Text) Then
            For i = 1 To 4
              LabRun_Msg_CCD(i).Text = "" : LabRun_Msg_CCD(i).Refresh()
            Next
            LabRun_SearchResult.Text = "NG"
            LabRun_SearchResult.BackColor = Color.Red
            LabRunningMsg.Text = "雷射測高超規 (測高值：" & LaserHeight.ToString & ")"
            Call WriteMessage("雷射測高超規 (測高值：" & LaserHeight.ToString & " , 測高規格：" & Val(TextTeach_Laser_LimitDown.Text) & " ~ " & Val(TextTeach_Laser_LimitUp.Text) & ")")
            Call ChangeDO(3, False) '檢測OK信號→OFF
            Call ChangeDO(4, True)  '檢測NG信號→ON
            Threading.Thread.Sleep(300)
            Call ChangeDO(3, False) '檢測OK信號→OFF
            Call ChangeDO(4, False) '檢測NG信號→OFF
            RunIndex_Main = 30
            Exit Select
          End If

          '取像 ----------------------------------------------------------------------------------------------------------------------------
          Dim MyCapture(4) As Boolean
          Dim MyCcdAngle(4) As Double
          MyCcdAngle(1) = 180 : MyCcdAngle(2) = 90 : MyCcdAngle(3) = 0 : MyCcdAngle(4) = 270
          Call ChangeDO(2, False) '條碼讀取完成信號→OFF
          LabRunningMsg.Text = "取像" : LabRunningMsg.Refresh()
          LabRun_SearchResult.Text = "" : LabRun_SearchResult.BackColor = Color.WhiteSmoke
          Threading.Thread.Sleep(Val(TextAdv_Option_CaptureDelay.Text)) '取像前Delay時間(ms)

          For i = 1 To 4
            '取像 --------------------------------------------------------------------------------------------------------------------------
            CCD_ImageSource(i).SetSize(0, 0) '影像初始
            LabRun_Msg_CCD(i).Text = "取像" : LabRun_Msg_CCD(i).Refresh()

            Try
              CCD_Session(i).Grab(CCD_ImageBeforeRotate(i), True, CCD_Buffer(i))
              Algorithms.Rotate(CCD_ImageBeforeRotate(i), CCD_ImageSource(i), MyCcdAngle(i))
              Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)
              If CCD_ImageSource(i).Width = 0 Then
                LabRun_Msg_CCD(i).Text = "取像失敗"
                MyCapture(i) = False
                MyResult = "NG"
              Else
                MyCapture(i) = True
                CCD_ImageSource(i).WritePngFile(SourceImagePath & "\SourceImage" & i.ToString & ".png")
              End If
            Catch ex As Exception
              MyCapture(i) = False
            End Try
          Next i

          '任一CCD取像失敗 ----------------------------------
          For i = 1 To 4
            If MyCapture(i) = False Then
              Call ChangeDO(3, False) '檢測OK信號→OFF
              Call ChangeDO(4, True)  '檢測NG信號→ON
              Threading.Thread.Sleep(300)
              Call ChangeDO(3, False) '檢測OK信號→OFF
              Call ChangeDO(4, False) '檢測NG信號→OFF
              LabRun_SearchResult.Text = "NG"
              LabRun_SearchResult.BackColor = Color.Red
              RunIndex_Main = 30
              Exit Select
            End If
          Next

          '檢測 -----------------------------------------------------------------------------------------------------------------------------
          LabRunningMsg.Text = "檢測中" : LabRunningMsg.Refresh()
          If MyResult = "NG" Then GoTo SearchEnd '取像失敗

          Call BtnTool_Search_Click(BtnTool_Search, Nothing) '檢測

SearchEnd:
          ''Show檢測結果→OK or NG
          'LabRun_SearchResult.Text = MyResult
          'LabRun_SearchResult.BackColor = IIf(MyResult = "OK", Color.Lime, Color.Red)

          '輸出檢測結果至PLC
          If MyResult = "OK" Then
            Call ChangeDO(3, True)  '檢測OK信號→ON
            Call ChangeDO(4, False) '檢測NG信號→OFF
          Else
            Call ChangeDO(3, False) '檢測OK信號→OFF
            Call ChangeDO(4, True)  '檢測NG信號→ON
          End If
          Threading.Thread.Sleep(300)
          Call ChangeDO(3, False) '檢測OK信號→OFF
          Call ChangeDO(4, False) '檢測NG信號→OFF

          RunIndex_Main = 20

        Case 20 '儲存檢測資料 ==================================================================================================================================
          'LabRunningMsg.Text = "儲存檢測資料" : LabRunningMsg.Refresh()
          'Call SaveSearchData() '儲存檢測資料
          RunIndex_Main = 30

        Case 30
          RunIndex_Main = 1
          MyTime2 = Now.Subtract(MyTime1)
          LabTimeInf_Total.Text = Format(MyTime2.TotalMilliseconds, "0")
      End Select

    Loop Until StartKey = False
  End Sub
  '工具列→停止鈕
  Public Sub BtnTool_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_Stop.Click
    StartKey = False
    Call ChangeDO(1, False)              'AOI Ready 信號→OFF
    LabRunningMsg.Text = "視覺檢測停止"
    Call WriteMessage("使用者按下停止鈕")
    Call SetBtnStateLevel(LabLevel.Tag)  '設定控制按鈕致能狀態
    PanelParameter.Enabled = True        '參數頁面→開
    BtnRun_ResetRunIndex.Enabled = True  '[清除作業程序]鈕→開
    PlcThreadStopKey = False
  End Sub
  '工具列→離開鈕
  Private Sub BtnTool_Exit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BtnTool_Exit.MouseDown
    If MsgBox("確定要離開嗎 ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "離開") = MsgBoxResult.Yes Then

      If IsSaveKey = True Then
        If MsgBox("程式離開前是否儲存產品檔案 ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "離開程式") = MsgBoxResult.Yes Then
          Call BtnTool_FileSave_Click(sender, e)
        End If
      End If

      Call SaveMachineParToFile() '儲存[機械參數]

      '關閉光源(COM1) ------------------------------------------
      Try                                                     '|
        Call TurnOnLight(0, 0, 0, 0)                          '|
        If RS232_Light.IsOpen = True Then RS232_Light.Close() '|
      Catch ex As Exception : End Try                         '|
      '---------------------------------------------------------

      If SerialPort_Barcode.IsOpen = True Then SerialPort_Barcode.Close()

      ''關閉 Live 執行緒 ----------------------------------------
      'ThreadLiveBusyKey = False                               '|
      'Do : Application.DoEvents() : Threading.Thread.Sleep(1) '|
      'Loop Until ThreadLiveStopKey = False                    '|
      ''---------------------------------------------------------
      'Try
      '  Session_CCD.Acquisition.Stop()
      '  Session_CCD.Acquisition.Unconfigure()
      '  Session_CCD.Acquisition.Dispose()
      'Catch ex As Exception : End Try

      ''關閉 I/O 執行緒 -----------------------------------------
      'Call ResetDO()                                          '|
      'Threading.Thread.Sleep(100)                             '|
      'ThreadIoBusyKey = False                                 '|
      'Do : Application.DoEvents() : Threading.Thread.Sleep(1) '|
      'Loop Until ThreadIoStopKey = False                      '|
      ''---------------------------------------------------------
      ''關閉 I/O ---------------------------------------
      'Try : DRV_DeviceClose(DeviceHandle_DIO) '關卡  '|
      'Catch ex As Exception : End Try                '|
      ''------------------------------------------------
      End
    End If

    'Call SaveLastProgramName() '儲存最後執行之產品檔
  End Sub
  '原圖
  Private Sub BtnRun_ImageSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun_ImageSource_CCD1.Click, BtnRun_ImageSource_CCD2.Click, BtnRun_ImageSource_CCD3.Click, BtnRun_ImageSource_CCD4.Click
    Dim MyBtn As Button = sender
    Dim MyViewer As ImageViewer = Microsoft.VisualBasic.Choose(Val(MyBtn.Tag), ImageViewer_CCD1, ImageViewer_CCD2, ImageViewer_CCD3, ImageViewer_CCD4)
    Dim MyImageSource As VisionImage
    Dim MyCheckLive As CheckBox

    Select Case Val(MyBtn.Tag)
      Case 1 : MyViewer = ImageViewer_CCD1 : MyImageSource = CCD1_ImageSource : MyCheckLive = CheckRun_Live_CCD1
      Case 2 : MyViewer = ImageViewer_CCD2 : MyImageSource = CCD2_ImageSource : MyCheckLive = CheckRun_Live_CCD2
      Case 3 : MyViewer = ImageViewer_CCD3 : MyImageSource = CCD3_ImageSource : MyCheckLive = CheckRun_Live_CCD3
      Case Else : MyViewer = ImageViewer_CCD4 : MyImageSource = CCD4_ImageSource : MyCheckLive = CheckRun_Live_CCD4
    End Select
    MyViewer.Palette.Type = PaletteType.Gray
    Algorithms.Copy(MyImageSource, MyViewer.Image)
  End Sub
  '載圖
  Private Sub BtnRun_ImageLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun_ImageLoad_CCD1.Click, BtnRun_ImageLoad_CCD2.Click, BtnRun_ImageLoad_CCD3.Click, BtnRun_ImageLoad_CCD4.Click
    Dim MyBtn As Button = sender
    Dim MyViewer As ImageViewer = Microsoft.VisualBasic.Choose(Val(MyBtn.Tag), ImageViewer_CCD1, ImageViewer_CCD2, ImageViewer_CCD3, ImageViewer_CCD4)
    Dim MyImageSource As VisionImage
    Dim MyCheckLive As CheckBox

    Select Case Val(MyBtn.Tag)
      Case 1 : MyImageSource = CCD1_ImageSource : MyCheckLive = CheckRun_Live_CCD1
      Case 2 : MyImageSource = CCD2_ImageSource : MyCheckLive = CheckRun_Live_CCD2
      Case 3 : MyImageSource = CCD3_ImageSource : MyCheckLive = CheckRun_Live_CCD3
      Case Else : MyImageSource = CCD4_ImageSource : MyCheckLive = CheckRun_Live_CCD4
    End Select

    OpenFileDialog_LoadImage.Filter = "圖檔類型 (*.PNG;*.BMP;*.JPG)|*.PNG;*.BMP;*.JPG"

    If OpenFileDialog_LoadImage.ShowDialog() = Windows.Forms.DialogResult.OK Then
      If MyCheckLive.Checked = True Then MyCheckLive.Checked = False '若為 Live 則關閉
      MyImageSource.ReadFile(OpenFileDialog_LoadImage.FileName)
      'LabLoadPic_FileName.Text = OpenFileDialog_LoadImage.FileName
      MyViewer.Palette.Type = PaletteType.Gray
      Algorithms.Copy(MyImageSource, MyViewer.Image)

      '建立 ProgramPath\Source Image 目錄夾
      Try : If Directory.Exists(SourceImagePath) = False Then Directory.CreateDirectory(SourceImagePath)
      Catch ex As Exception : End Try

      '儲存檢測2圖檔
      MyImageSource.WritePngFile(SourceImagePath & "\SourceImage" & MyBtn.Tag & ".png")

      '載入檢測2圖檔
      Dim MyImagePathAndName As String
      LabSearch2_Result_CCD(MyBtn.Tag).BackColor = Color.White
      MyImagePathAndName = SourceImagePath & "\SourceImage" & MyBtn.Tag & ".png"
      If File.Exists(MyImagePathAndName) = False Then
        LabRun_Msg_CCD(MyBtn.Tag).Text = "檢測2圖像" & MyBtn.Tag & " 不存在"
      Else
        Try : SetImage(ClassIntPtr(MyBtn.Tag), MyImagePathAndName)
        Catch ex As Exception
          LabRun_Msg_CCD(MyBtn.Tag).Text = "檢測2圖像" & MyBtn.Tag & " 載入失敗"
        End Try
      End If
    End If
  End Sub
  '存圖
  Private Sub BtnRun_ImageSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun_ImageSave_CCD1.Click, BtnRun_ImageSave_CCD2.Click, BtnRun_ImageSave_CCD3.Click, BtnRun_ImageSave_CCD4.Click
    Dim MyBtn As Button = sender
    Dim MyViewer As ImageViewer = Microsoft.VisualBasic.Choose(Val(MyBtn.Tag), ImageViewer_CCD1, ImageViewer_CCD2, ImageViewer_CCD3, ImageViewer_CCD4)

    SaveFileDialog_SaveImage.Filter = "PNG圖檔|*.PNG|BMP圖檔|*.BMP|JPG圖檔|*.JPG"

    If SaveFileDialog_SaveImage.ShowDialog() = Windows.Forms.DialogResult.OK Then
      Try
        Select Case SaveFileDialog_SaveImage.FilterIndex
          Case 1 : MyViewer.Image.WritePngFile(SaveFileDialog_SaveImage.FileName)  'PNG 檔
          Case 2 : MyViewer.Image.WriteBmpFile(SaveFileDialog_SaveImage.FileName)  'BMP 檔
          Case 3 : MyViewer.Image.WriteJpegFile(SaveFileDialog_SaveImage.FileName) 'JPG 檔
        End Select
        MsgBox("CCD" & MyBtn.Tag & " 圖像 " & SaveFileDialog_SaveImage.FileName & " 儲存成功", MsgBoxStyle.Information, "存圖")
      Catch ex As Exception
        MsgBox("CCD" & MyBtn.Tag & " 圖像 " & SaveFileDialog_SaveImage.FileName & " 儲存失敗", MsgBoxStyle.Information, "存圖")
      End Try
    End If
  End Sub
  'All CCD Live
  Private Sub CheckTool_CcdLive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckTool_CcdLive.CheckedChanged
    CheckTool_CcdLive.BackColor = IIf(CheckTool_CcdLive.Checked = True, Color.Lime, Color.White)
    For i As Integer = 1 To 4
      CheckRun_Live_CCD(i).Checked = CheckTool_CcdLive.Checked
    Next
  End Sub
  'CCD→Live 鈕
  Private Sub CheckRun_Live_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckRun_Live_CCD1.CheckedChanged, CheckRun_Live_CCD2.CheckedChanged, CheckRun_Live_CCD3.CheckedChanged, CheckRun_Live_CCD4.CheckedChanged
    Dim MyCheckLive As CheckBox = sender
    Dim MyViewer As ImageViewer

    Select Case Val(MyCheckLive.Tag)
      Case 1 : CCD1_LiveKey = True : MyViewer = ImageViewer_CCD1
      Case 2 : CCD2_LiveKey = True : MyViewer = ImageViewer_CCD2
      Case 3 : CCD3_LiveKey = True : MyViewer = ImageViewer_CCD3
      Case Else : CCD4_LiveKey = True : MyViewer = ImageViewer_CCD4
    End Select
    MyViewer.Palette.Type = PaletteType.Gray

    If MyCheckLive.Checked = True Then
      Select Case Val(MyCheckLive.Tag)
        Case 1 : CCD1_LiveKey = True
        Case 2 : CCD2_LiveKey = True
        Case 3 : CCD3_LiveKey = True
        Case Else : CCD4_LiveKey = True
      End Select
      MyCheckLive.BackColor = Color.Lime

    Else
      Dim MySession As ImaqdxSession

      Dim MyImageSource As VisionImage
      Dim MyImageBeforeRotate As VisionImage
      Dim MyWait As Object
      Dim MyBuffer As Long
      Dim MyAngle As Double

      Select Case Val(MyCheckLive.Tag)
        Case 1 : CCD1_LiveKey = False : MySession = CCD1_Session : MyViewer = ImageViewer_CCD1 : MyImageSource = CCD1_ImageSource : MyImageBeforeRotate = CCD1_ImageBeforeRotate : MyWait = CCD1_WaitCapture : MyBuffer = CCD1_Buffer : MyAngle = 180
        Case 2 : CCD2_LiveKey = False : MySession = CCD2_Session : MyViewer = ImageViewer_CCD2 : MyImageSource = CCD2_ImageSource : MyImageBeforeRotate = CCD2_ImageBeforeRotate : MyWait = CCD2_WaitCapture : MyBuffer = CCD2_Buffer : MyAngle = 90
        Case 3 : CCD3_LiveKey = False : MySession = CCD3_Session : MyViewer = ImageViewer_CCD3 : MyImageSource = CCD3_ImageSource : MyImageBeforeRotate = CCD3_ImageBeforeRotate : MyWait = CCD3_WaitCapture : MyBuffer = CCD3_Buffer : MyAngle = 0
        Case Else : CCD4_LiveKey = False : MySession = CCD4_Session : MyViewer = ImageViewer_CCD4 : MyImageSource = CCD4_ImageSource : MyImageBeforeRotate = CCD4_ImageBeforeRotate : MyWait = CCD4_WaitCapture : MyBuffer = CCD4_Buffer : MyAngle = 270
      End Select
      MyCheckLive.BackColor = Color.White

      '停止狀態時才執行 ---------------------------------------------------------
      If StartKey = False Then
        Threading.Thread.Sleep(100)
        SyncLock MyWait
          Try
            MySession.Grab(MyImageBeforeRotate, True, MyBuffer)
            Algorithms.Rotate(MyImageBeforeRotate, MyImageSource, MyAngle)
            Algorithms.Copy(MyImageSource, MyViewer.Image)

            '建立 ProgramPath\Source Image 目錄夾
            Try : If Directory.Exists(SourceImagePath) = False Then Directory.CreateDirectory(SourceImagePath)
            Catch ex As Exception : End Try

            '儲存檢測2圖檔
            MyImageSource.WritePngFile(SourceImagePath & "\SourceImage" & MyCheckLive.Tag & ".png")
          Catch ex As Exception : End Try
        End SyncLock
      End If

    End If

  End Sub

  Private Sub BtnRun_ZoomToFit_CCD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun_ZoomToFit_CCD1.Click, BtnRun_ZoomToFit_CCD2.Click, BtnRun_ZoomToFit_CCD3.Click, BtnRun_ZoomToFit_CCD4.Click
    Dim MyBtn As Button = sender
    Dim MyViewer As ImageViewer = Microsoft.VisualBasic.Choose(Val(MyBtn.Tag), ImageViewer_CCD1, ImageViewer_CCD2, ImageViewer_CCD3, ImageViewer_CCD4)

    MyViewer.ZoomToFit = True
  End Sub

  Private Sub TimerDIO_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDIO.Tick
    Dim portData As Byte = 0
    Dim portDir As Byte = &HFF
    Dim mask As Byte() = InstantCtrl_DO.Features.DoDataMask
    Dim err As Automation.BDaq.ErrorCode = Automation.BDaq.ErrorCode.Success
    Dim MyIndex As Integer = 0
    Dim i, j As Integer
    Dim MyDoValue As Integer

    Try
      'D/I ----------------------------------------------------------------------------------------------
      err = InstantCtrl_DI.Read(0, portData)
      For j = 0 To 1
        MyIndex = j + 1
        DI1_X(MyIndex) = IIf(Int((portData >> j) And &H1) = 0, False, True)
        LabDi(MyIndex).BackColor = IIf(DI1_X(MyIndex) = True, Color.Lime, Color.DarkGreen)
      Next


      '馬達前極限信號
      DI1_X(3) = IIf(oL1001 = 1, True, False)

      '馬達後極限信號
      DI1_X(4) = IIf(oL1000 = 1, True, False)

      '伺服馬達異常信號
      DI1_X(5) = IIf(oL1002 = 1, True, False)

      '伺服驅動器異常信號
      DI1_X(6) = IIf(oL1003 = 1, True, False)

      '真空異常信號
      DI1_X(7) = IIf(oL1004 = 1, True, False)

      '門檢1信號
      DI1_X(8) = IIf(oL1005 = 1, True, False)

      '門檢2信號
      DI1_X(9) = IIf(oL1006 = 1, True, False)

      '門檢3信號
      DI1_X(10) = IIf(oL1007 = 1, True, False)

      '掃描器逾時信號
      DI1_X(11) = IIf(oL1009 = 1, True, False)

      'CCD逾時信號
      DI1_X(12) = IIf(oL1010 = 1, True, False)

      '啟動燈
      DI1_X(13) = IIf(Y6B = 1, True, False)

      '警報停止鈕
      DI1_X(14) = IIf(X2E = 1, True, False)

      'D/O ----------------------------------------------------------------------------------------------
      For i = 0 To 1
        err = InstantCtrl_DI.Read(i, portData)
        If err <> Automation.BDaq.ErrorCode.Success Then
          TimerDIO.Enabled = False
          Exit For
        End If

        'For j = 0 To 7
        '  MyIndex = i * 8 + j + 1
        '  DI1_X(MyIndex) = IIf(Int((portData >> j) And &H1) = 0, False, True)
        '  LabDi(MyIndex).BackColor = IIf(DI1_X(MyIndex) = True, Color.Lime, Color.DarkGreen)
        'Next

        err = InstantCtrl_DO.Read(i, portData)
        If err <> Automation.BDaq.ErrorCode.Success Then
          TimerDIO.Enabled = False
          Exit For
        End If
        'portDir = InstantCtrl_DO.Ports(i).DirectionMask
        MyDoValue = 0
        For j = 0 To 7
          MyIndex = i * 8 + j + 1
          LabDi(MyIndex).BackColor = IIf(DI1_X(MyIndex) = True, Color.Lime, Color.DarkGreen)
          If DO1_Y(MyIndex) = True Then MyDoValue = MyDoValue + (2 ^ j)
        Next j
        InstantCtrl_DO.Write(i, CByte(MyDoValue))
      Next i
    Catch ex As Exception : End Try

  End Sub
  'DO 控制按鈕
  Private Sub CheckDo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDo_Y101.CheckedChanged, CheckDo_Y116.CheckedChanged, CheckDo_Y115.CheckedChanged, CheckDo_Y114.CheckedChanged, CheckDo_Y113.CheckedChanged, CheckDo_Y112.CheckedChanged, CheckDo_Y111.CheckedChanged, CheckDo_Y110.CheckedChanged, CheckDo_Y109.CheckedChanged, CheckDo_Y108.CheckedChanged, CheckDo_Y107.CheckedChanged, CheckDo_Y106.CheckedChanged, CheckDo_Y105.CheckedChanged, CheckDo_Y104.CheckedChanged, CheckDo_Y103.CheckedChanged, CheckDo_Y102.CheckedChanged
    If Me.Created = False Then Exit Sub
    Dim MyCheckBox As CheckBox = sender

    MyCheckBox.BackColor = IIf(MyCheckBox.Checked = True, Color.Lime, Color.WhiteSmoke)
    DO1_Y(MyCheckBox.Tag) = MyCheckBox.Checked
  End Sub
  '檢測燈光→設定紐
  Private Sub BtnLight_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTeach_SearchLight_Set.Click, BtnAdv_CalibLight_Set.Click
    If Me.Created = False Then Exit Sub
    LightSetName = sender.Tag.ToString

    Select Case sender.Tag
      Case "檢測" : TextLight1 = TextTeach_Search_Light1 : TextLight2 = TextTeach_Search_Light2 : TextLight3 = TextTeach_Search_Light3 : TextLight4 = TextTeach_Search_Light4
      Case "校正" : TextLight1 = TextAdv_Calib_Light1 : TextLight2 = TextAdv_Calib_Light2 : TextLight3 = TextAdv_Calib_Light3 : TextLight4 = TextAdv_Calib_Light4
    End Select

    Call TurnOnLight(CByte(TextLight1.Text), CByte(TextLight2.Text), CByte(TextLight3.Text), CByte(TextLight4.Text))
    DialogLight.ShowDialog(Me)
  End Sub
  '校正→影像處理→二值化(拉霸)
  Private Sub TrackBarAdv_Calib_Binary_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarAdv_Calib_BinaryMin.ValueChanged, TrackBarAdv_Calib_BinaryMax.ValueChanged
    If Me.Created = False Then Exit Sub
    Dim MyTrackBar As TrackBar = sender
    TextAdv_Calib_BinaryMin.Text = TrackBarAdv_Calib_BinaryMin.Value
    TextAdv_Calib_BinaryMax.Text = TrackBarAdv_Calib_BinaryMax.Value
    Call ImageAdjust_Calib_Distance(1, True)
  End Sub
  '校正→影像處理→二值化(值)
  Private Sub TextAdv_Calib_Binary_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextAdv_Calib_BinaryMin.TextChanged, TextAdv_Calib_BinaryMax.TextChanged
    If Me.Created = False Then Exit Sub
    TrackBarAdv_Calib_BinaryMin.Value = TextAdv_Calib_BinaryMin.Text
    TrackBarAdv_Calib_BinaryMax.Value = TextAdv_Calib_BinaryMax.Text
  End Sub
  '校正→影像處理→濾除邊
  Private Sub BtnAdv_Calib_RejectBorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdv_Calib_RejectBorder.Click
    Call ImageAdjust_Calib_Distance(IIf(CheckAdv_Calib_RejectBorder.Checked = True, 2, 1), True)
  End Sub
  '校正→影像處理→濾除雜點
  Private Sub UpDownAdv_Calib_Remove_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownAdv_Calib_Remove.ValueChanged
    If Me.Created = False Then Exit Sub
    Call ImageAdjust_Calib_Distance(3, True)
  End Sub
  '校正→影像處理→填滿
  Private Sub BtnAdv_Calib_Fill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdv_Calib_Fill.Click
    If Me.Created = False Then Exit Sub
    Call ImageAdjust_Calib_Distance(4, True)
  End Sub
  '校正鈕(距離校正)
  Private Sub BtnAdv_Calib_CcdDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdv_Calib_CcdDistance.Click
    Dim i As Integer
    Dim MyParticleReport(4) As ParticleMeasurementsReport
    Dim MyRoi As New Roi
    Dim MyLine1 As New LineContour
    Dim MyLine2 As New LineContour
    Dim MyCrossLen As Integer = 20
    Dim MyCenterX(4), MyCenterY(4) As Double

    If Lab_Search_M1601.BackColor <> Color.Green Then
      Call Btn_SearchPositionMove_M1153_Click(BtnRun_MoveToSearchPos, e)
      Do Until Lab_Search_M1601.BackColor = Color.Green
        Application.DoEvents() : Thread.Sleep(1)
      Loop
    End If

    If Lab_Vacuum_X2B_2.Text = "STOP" Then
      Call Btn_VacuumOnOff_M1912_Click(Btn_VacuumOnOff_M1912, e)
      Do Until Lab_Vacuum_X2B_2.Text = "RUN"
        Application.DoEvents() : Thread.Sleep(1)
      Loop
    End If

    If ImageAdjust_Calib_Distance(4, False) = False Then GoTo CalibEnd

    Try
      For i = 1 To 4
        If ImageViewer_CCD(i).Image.Width = 0 Then
          LabRun_Msg_CCD(i).Text = "畫面無影像"
          Continue For
        End If
        ImageViewer_CCD(i).Image.Overlays.Default.Clear() : ImageViewer_CCD(i).Refresh()
        MyParticleReport(i) = Algorithms.ParticleMeasurements(Calib_ImageAdjust_CCD(i), Calib_PixelMeasurements(i), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Pixel)
        Calib_MaskToRoiReport = Algorithms.MaskToRoi(Calib_ImageAdjust_CCD(i))
        MyRoi.Clear()
        ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
        Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)
        If MyParticleReport(i).PixelMeasurements.GetLength(0) > 0 Then
          MyCenterX(i) = MyParticleReport(i).PixelMeasurements(0, 0)
          MyCenterY(i) = MyParticleReport(i).PixelMeasurements(0, 1)
          MyLine1.Start.Initialize(MyCenterX(i) - MyCrossLen, MyCenterY(i))
          MyLine1.End.Initialize(MyCenterX(i) + MyCrossLen, MyCenterY(i))
          MyLine2.Start.Initialize(MyCenterX(i), MyCenterY(i) - MyCrossLen)
          MyLine2.End.Initialize(MyCenterX(i), MyCenterY(i) + MyCrossLen)
          ImageViewer_CCD(i).Image.Overlays.Default.AddLine(MyLine1, Rgb32Value.RedColor)
          ImageViewer_CCD(i).Image.Overlays.Default.AddLine(MyLine2, Rgb32Value.RedColor)
          MyRoi.Add(Calib_MaskToRoiReport.Roi(0).Shape)
          MyRoi(0).Color = Rgb32Value.RedColor
          ImageViewer_CCD(i).Image.Overlays.Default.AddRoi(MyRoi)
        Else
          MsgBox("CCD" & i.ToString & " 找不到校正圓", MsgBoxStyle.Exclamation, "校正")
          GoTo CalibEnd
        End If
      Next
    Catch ex As Exception
      MsgBox("CCD" & i.ToString & " 校正分析失敗", MsgBoxStyle.Critical, "CCD 距離校正")
    End Try

    Dim MyCenterX_mm(4), MyCenterY_mm(4) As Double
    Dim MySideDistance_Long As Double = 0
    Dim MySideDistance_Short As Double = 0
    Dim MySlope As Double = 0 '斜率
    Dim MyAngle As Double = 0 '角度

    '計算左右之校正距離
    If CheckAdv_Calib_LeftRight.Checked = True Then
      MyCenterX_mm(4) = (MyCenterX(4) * Val(TextAdv_Pixel_CCD4.Text)) / 1000 '左視窗→CCD4 圓中心X (mm)
      MyCenterY_mm(4) = (MyCenterY(4) * Val(TextAdv_Pixel_CCD4.Text)) / 1000 '左視窗→CCD4 圓中心Y (mm)
      MyCenterX_mm(2) = (MyCenterX(2) * Val(TextAdv_Pixel_CCD2.Text)) / 1000 '右視窗→CCD2 圓中心X (mm)
      MyCenterY_mm(2) = (MyCenterY(2) * Val(TextAdv_Pixel_CCD2.Text)) / 1000 '右視窗→CCD2 圓中心Y (mm)

      'MyCenterX_mm(2) = 38.2 : MyCenterY_mm(2) = 31.7
      'MyCenterX_mm(4) = 28.8 : MyCenterY_mm(4) = 19.4
      'MyCenterX_mm(2) = 17.8 : MyCenterY_mm(2) = 43.2
      'MyCenterX_mm(4) = 12.5 : MyCenterY_mm(4) = 7

      MySideDistance_Short = MyCenterY_mm(2) - MyCenterY_mm(4)
      MySideDistance_Long = Math.Sqrt((Val(TextAdv_CalibTool_DistanceX.Text) ^ 2) - (MySideDistance_Short ^ 2)) '已知斜邊及對邊，求鄰邊
      TextAdv_Distance_LeftRight.Text = Format(MySideDistance_Long - (MyCenterX_mm(2) - MyCenterX_mm(4)), "0.000")
      MySlope = MySideDistance_Short / MySideDistance_Long '斜率
      MyAngle = Math.Atan(MySlope) * (180 / Math.PI) '角度
      TextAdv_Angle_LeftRight.Text = Format(MyAngle, "0.000")
    End If
    '計算上下之校正距離
    If CheckAdv_Calib_UpDown.Checked = True Then
      MyCenterX_mm(1) = (MyCenterX(1) * Val(TextAdv_Pixel_CCD1.Text)) / 1000 '上視窗→CCD1 圓中心X (mm)
      MyCenterY_mm(1) = (MyCenterY(1) * Val(TextAdv_Pixel_CCD1.Text)) / 1000 '上視窗→CCD1 圓中心Y (mm)
      MyCenterX_mm(3) = (MyCenterX(3) * Val(TextAdv_Pixel_CCD3.Text)) / 1000 '下視窗→CCD3 圓中心X (mm)
      MyCenterY_mm(3) = (MyCenterY(3) * Val(TextAdv_Pixel_CCD3.Text)) / 1000 '下視窗→CCD3 圓中心Y (mm)
      MySideDistance_Short = MyCenterX_mm(3) - MyCenterX_mm(1)
      MySideDistance_Long = Math.Sqrt((Val(TextAdv_CalibTool_DistanceY.Text) ^ 2) - (MySideDistance_Short ^ 2)) '已知斜邊及對邊，求鄰邊
      TextAdv_Distance_UpDown.Text = Format(MySideDistance_Long - (MyCenterY_mm(3) - MyCenterY_mm(1)), "0.000")
      MySlope = MySideDistance_Short / MySideDistance_Long '斜率
      MyAngle = Math.Atan(MySlope) * (180 / Math.PI) '角度
      TextAdv_Angle_UpDown.Text = Format(MyAngle, "0.000")
    End If

CalibEnd:
    MyRoi.Dispose()
    MyLine1 = Nothing : MyLine2 = Nothing

    If Lab_Standby_M1602.BackColor <> Color.Green Then
      Call Btn_StandbyPositionMove_M1154_Click(Btn_StandbyPositionMove_M1154, e)
      Do Until Lab_Standby_M1602.BackColor = Color.Green
        Application.DoEvents() : Thread.Sleep(1)
      Loop
    End If

    If Lab_Vacuum_X2B_2.Text = "RUN" Then
      Call Btn_VacuumOnOff_M1912_Click(Btn_VacuumOnOff_M1912, e)
      Do Until Lab_Vacuum_X2B_2.Text = "STOP"
        Application.DoEvents() : Thread.Sleep(1)
      Loop
    End If
  End Sub
  '校正鈕(Pixel校正)
  Private Sub BtnAdv_Calib_Pixel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdv_Calib_Pixel.Click
    Dim MyRoi As New Roi
    Dim MyCoefficients() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1}
    Dim MyStructElem As New StructuringElement(3, 3, MyCoefficients)
    Dim MyIndex As Integer = 0
    Dim i As Integer = 0
    Dim MyBeforeValue As Double = 0

    For i = 1 To 4
      If RadioAdv_Pixel_CCD(i).Checked = True Then
        MyIndex = i : Exit For
      End If
    Next i

    If CheckTool_CcdLive.Checked = True Then CheckTool_CcdLive.Checked = False ' '若為Live則關閉Live
    For i = 1 To 4
      'If CheckRun_Live_CCD(i).Checked = True Then CheckRun_Live_CCD(i).Checked = False '若為Live則關閉Live
      ImageViewer_CCD(i).Image.Overlays.Default.Clear() '清除畫線
    Next i
    ImageViewer_CCD(MyIndex).Refresh() : Threading.Thread.Sleep(1)
    Try
      '影像處理
      'Algorithms.AutoThreshold(CCD_ImageSource(MyIndex), ImageCalibPixel, 2, ThresholdMethod.Metric)                                  '二值化(Metric)
      Algorithms.Threshold(CCD_ImageSource(MyIndex), ImageCalibPixel, New Range(Val(TextAdv_Calib_BinaryMin.Text), Val(TextAdv_Calib_BinaryMax.Text)), True, 1)
      'Algorithms.UserLookup(ImageCalibPixel, ImageCalibPixel, Calib_Pixel_LookupTable)                                                '二值化反向
      MyStructElem.Shape = StructuringElementShape.Square
      Algorithms.RemoveParticle(ImageCalibPixel, ImageCalibPixel, 50, SizeToKeep.KeepLarge, Connectivity.Connectivity8, MyStructElem) '濾除小雜點
      Algorithms.RejectBorder(ImageCalibPixel, ImageCalibPixel, Connectivity.Connectivity8)                                           '濾除邊
      Algorithms.FillHoles(ImageCalibPixel, ImageCalibPixel, Connectivity.Connectivity8)                                              '填滿
      'Algorithms.ConvexHull(ImageCalibPixel, ImageCalibPixel, Connectivity.Connectivity8)                                             '補滿鋸齒邊
      Algorithms.Equalize(ImageCalibPixel, ImageCalibPixel, Nothing, New Range(0, 255), Nothing)                                      '二值化→灰階

      'Particle 分析
      Dim MyParticleReport As ParticleMeasurementsReport = Algorithms.ParticleMeasurements(ImageCalibPixel, Calib_PixelMeasurements(MyIndex), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Pixel)

      Calib_MaskToRoiReport = Algorithms.MaskToRoi(ImageCalibPixel)
      Algorithms.Copy(CCD_ImageSource(MyIndex), ImageViewer_CCD(MyIndex).Image)
      If MyParticleReport.PixelMeasurements.GetLength(0) > 0 Then
        MyRoi.Add(Calib_MaskToRoiReport.Roi(0).Shape) : MyRoi(0).Color = Rgb32Value.RedColor
        ImageViewer_CCD(MyIndex).Image.Overlays.Default.AddRoi(MyRoi)
        MyBeforeValue = Val(TextAdv_Pixel_CCD(MyIndex).Text)
        TextAdv_Pixel_CCD(MyIndex).Text = Format((Val(TextAdv_CircleSize.Text) * 1000) / MyParticleReport.PixelMeasurements(0, 2), "0.000")
        LabAdv_FovX_CCD(MyIndex).Text = Format((Val(TextAdv_Pixel_CCD(MyIndex).Text) * CcdDpiX) / 1000, "0.0")
        LabAdv_FovY_CCD(MyIndex).Text = Format((Val(TextAdv_Pixel_CCD(MyIndex).Text) * CcdDpiY) / 1000, "0.0")
        Call WriteMessage("CCD" & MyIndex.ToString & " Pixel校正成功：" & MyBeforeValue.ToString & " → " & TextAdv_Pixel_CCD(MyIndex).Text)
      Else
        MsgBox("CCD" & MyIndex.ToString & " 找不到校正圓", MsgBoxStyle.Exclamation, "Pixel校正")
        GoTo CalibEnd
      End If

    Catch ex As Exception
      MsgBox("CCD" & MyIndex.ToString & " 校正圓搜尋失敗", MsgBoxStyle.Critical, "Pixel校正")
    End Try

CalibEnd:
    MyRoi.Dispose()
    MyStructElem = Nothing
  End Sub
  'Pixel校正→校正值改變
  Private Sub TextAdv_Pixel_CCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextAdv_Pixel_CCD1.TextChanged, TextAdv_Pixel_CCD2.TextChanged, TextAdv_Pixel_CCD3.TextChanged, TextAdv_Pixel_CCD4.TextChanged
    If Me.Created = False Then Exit Sub
    Dim MyTextBox As TextBox = sender

    LabAdv_FovX_CCD(Val(MyTextBox.Tag)).Text = Format((Val(TextAdv_Pixel_CCD(Val(MyTextBox.Tag)).Text) * CcdDpiX) / 1000, "0.0")
    LabAdv_FovY_CCD(Val(MyTextBox.Tag)).Text = Format((Val(TextAdv_Pixel_CCD(Val(MyTextBox.Tag)).Text) * CcdDpiY) / 1000, "0.0")
    IsSaveKey = True
  End Sub

  Private Sub BtnLight_On_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdv_CalibLight_On.Click, BtnTeach_SearchLight_On.Click
    Dim MyBtn As Button = sender
    Dim MyTextLight(4) As TextBox

    Select Case MyBtn.Tag
      Case "檢測" : MyTextLight(1) = TextTeach_Search_Light1 : MyTextLight(2) = TextTeach_Search_Light2 : MyTextLight(3) = TextTeach_Search_Light3 : MyTextLight(4) = TextTeach_Search_Light4
      Case "校正" : MyTextLight(1) = TextAdv_Calib_Light1 : MyTextLight(2) = TextAdv_Calib_Light2 : MyTextLight(3) = TextAdv_Calib_Light3 : MyTextLight(4) = TextAdv_Calib_Light4
    End Select
    Call TurnOnLight(CByte(MyTextLight(1).Text), CByte(MyTextLight(2).Text), CByte(MyTextLight(3).Text), CByte(MyTextLight(4).Text))
  End Sub

  Private Sub BtnLight_Off_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdv_CalibLight_Off.Click, BtnTeach_SearchLight_Off.Click
    Call TurnOnLight(0, 0, 0, 0)
  End Sub
  '檢測鈕
  Private Sub BtnTool_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_Search.Click
    Dim i, j As Integer                                                          '迴圈參數
    Dim MyCount As Integer                                                       '影像處理後的圓個數
    Dim MyParticleReport_TrueCircle(4) As ParticleMeasurementsReport                        'Particle 分析報告
    Dim MyParticleReport_Hull(4) As ParticleMeasurementsReport                   'Particle 分析報告
    Dim MyParticleReport_DefectInside(4) As ParticleMeasurementsReport           'Particle 分析報告(圓內缺點)
    Dim MyParticleReport_DefectOutside(4) As ParticleMeasurementsReport          'Particle 分析報告(圓外缺點)
    Dim MyRoi As New Roi                                                         '畫被測圓之外輪廓
    Dim MyLine1 As New LineContour                                               '被測圓的中心點之十字線(橫線)
    Dim MyLine2 As New LineContour                                               '被測圓的中心點之十字線(直線)
    Dim MyCrossLen As Integer = 20                                               '被測圓的中心點之十字線長度
    Dim MyCenterX(4), MyCenterY(4) As Double                                     '被測圓的中心點
    'Dim MyDiameter(4) As Double                                                 '被測圓的直徑
    Dim MyArea(4) As Double                                                      '被測圓的面積
    Dim MyIndex As Integer = 0                                                   '被測圓的Index
    Dim MyDiameterDiffMin As Double = 10000                                      '最接近被測圓直徑之直徑差值
    Dim MyDiameterDiff_Pixel As Double = 0                                       '被測圓之直徑差
    Dim MyDiameterSet_Pixel As Double = 0                                        '孔徑設定值換算成Pixel
    Dim MyResult(4) As String                                                    '檢測結果(OK or NG)
    Dim MyResult_Search2(4) As String                                            '檢測2結果(OK or NG)
    Dim MyRowCountOutside(4)                                                     '四支CCD瑕疵之最數量(圓外)
    Dim MySearch1_Time1 As Date
    Dim MySearch1_Time2 As TimeSpan
    Dim MySearch2_Time1 As Date
    Dim MySearch2_Time2 As TimeSpan
    Dim MyHoleQualityResult(4) As String
    Dim MyHoleQualityType(4) As String
    Dim MyHoleDustanceAndResultX As String = ""
    Dim MyHoleDustanceAndResultY As String = ""

    PlcThreadStopKey = True
    Searching = True
    '作業資訊清空 -------------------------------------------------------------------------------------------------------------------------------------
    TextOpInf_HoleQualityResult.Text = ""      '孔品質結果判定
    TextOpInf_HoleQualityType.Text = ""        '孔品質種類判定
    TextOpInf_HoleDustanceAndResultX.Text = "" 'X方向孔距離量測及判定結果
    TextOpInf_HoleDustanceAndResultY.Text = "" 'Y方向孔距離量測及判定結果

    If CheckTool_CcdLive.Checked = True Then CheckTool_CcdLive.Checked = False ' '若為Live則關閉Live
    For i = 1 To 4
      ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
      'If CheckRun_Live_CCD(i).Checked = True Then CheckRun_Live_CCD(i).Checked = False '                           '若為Live則關閉Live
      ImageViewer_CCD(i).Image.Overlays.Default.Clear() : ImageViewer_CCD(i).Refresh()                              '清除畫線
      LabRun_Msg_CCD(i).Text = ""                                                                                   '動作訊息
      LabRun_Diameter_CCD(i).Text = 0 : LabRun_Diameter_CCD(i).ForeColor = Color.Black                              '孔徑歸零
      LabRun_Defect_TrueCircle_CCD(i).Text = "" : LabRun_Defect_TrueCircle_CCD(i).ForeColor = Color.Black           '瑕疵面積比初始
      TextServer_Receive_CCD(i).Text = ""                                                                           '[檢測2] 回傳訊息欄位清空
      LabServer_Receive_ContinueCount_CCD(i).Text = ""                                                              '[檢測2] 連續數量欄位清空
      LabServer_Receive_NonContinueCount_CCD(i).Text = ""                                                           '[檢測2] 不連續數量欄位清空
      MyCenterX(i) = -1 : MyCenterY(i) = -1                                                                         '被測圓中心點初始
      MyResult(i) = "OK"
    Next i
    LabRun_Distance_LeftRight.Text = "" : LabRun_Distance_LeftRight.ForeColor = Color.Black                         '左右孔距離歸零
    LabRun_Distance_UpDown.Text = "" : LabRun_Distance_UpDown.ForeColor = Color.Black                               '上下孔距離歸零
    LabRun_SearchResult.Text = "" : LabRun_SearchResult.BackColor = Color.WhiteSmoke                                '檢測結果(OK or NG)初始

    LabTimeInf_Search1.Text = "" : LabTimeInf_Search1.Refresh()
    LabTimeInf_Search2.Text = "" : LabTimeInf_Search2.Refresh()
    LabTimeInf_SearchTotal.Text = "" : LabTimeInf_SearchTotal.Refresh()
    DataGrid_DefectLength_Outside.RowCount = 0

    Application.DoEvents() : Threading.Thread.Sleep(100)

    MySearch1_Time1 = Now
    '左右孔 ====================================================================================================================================================================================================
    For i = 1 To 4
      MyHoleQualityResult(i) = "OK" : MyHoleQualityType(i) = "OK" : MyHoleDustanceAndResultX = "OK" : MyHoleDustanceAndResultY = "OK"
      If CheckSearch_LeftRight.Checked = False AndAlso (i = 2 OrElse i = 4) Then Continue For
      If CheckSearch_UpDown.Checked = False AndAlso (i = 1 OrElse i = 3) Then Continue For
      Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)

      '影像處理 -------------------------------------------------------------
      If ImageAdjust_Search(i, 10, False) = False Then
        LabRun_Msg_CCD(i).Text = "影像處理失敗 "
        MyHoleQualityResult(i) = "NG"
        MyHoleQualityType(i) = "NG"
        MyHoleDustanceAndResultX = "NG"
        MyHoleDustanceAndResultY = "NG"
        MyResult(i) = "NG"
        Continue For
      End If

      '圓尺寸分析 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
      '(0:中心X , 1:中心Y , 2:實際直徑 , 3:面積 , 4:最大直徑 , 5:真園度)
      MyParticleReport_TrueCircle(i) = Algorithms.ParticleMeasurements(ImageAdjustBeforeHull_CCD(i), PixelMeasurements_CCD(i), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Pixel) '真圓度的圓
      MyParticleReport_Hull(i) = Algorithms.ParticleMeasurements(ImageAdjustHull_CCD(i), PixelMeasurements_CCD(i), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Pixel) '中心點及直徑的圓
      MaskToRoiReport_CCD(i) = Algorithms.MaskToRoi(ImageAdjustHull_CCD(i)) '圓的外輪廓

      MyCount = MyParticleReport_Hull(i).PixelMeasurements.GetLength(0)
      If MyCount > 0 Then
        If MyCount = 1 Then '只有一個被測圓
          MyIndex = 0
        Else '兩個以上被測圓
          '找出最接近被測圓的Index
          MyDiameterDiffMin = 10000
          For j = 0 To MyCount - 1
            MyDiameterSet_Pixel = ((Val(TextTeach_Diameter_CCD(i).Text) * 1000) / Val(TextAdv_Pixel_CCD(i).Text))
            MyDiameterDiff_Pixel = Math.Abs(MyParticleReport_Hull(i).PixelMeasurements(j, 2) - MyDiameterSet_Pixel)
            If MyDiameterDiff_Pixel < MyDiameterDiffMin Then '直徑差(檢測直徑-設定直徑)絕對值 < 設定直徑差
              MyDiameterDiffMin = MyDiameterDiff_Pixel
              MyIndex = j
            End If
          Next
        End If

        '取得圓的中心點
        MyCenterX(i) = MyParticleReport_Hull(i).PixelMeasurements(MyIndex, 0)
        MyCenterY(i) = MyParticleReport_Hull(i).PixelMeasurements(MyIndex, 1)

        '取得並畫出圓的中心點十字線
        MyLine1.Start.Initialize(MyCenterX(i) - MyCrossLen, MyCenterY(i))
        MyLine1.End.Initialize(MyCenterX(i) + MyCrossLen, MyCenterY(i))
        MyLine2.Start.Initialize(MyCenterX(i), MyCenterY(i) - MyCrossLen)
        MyLine2.End.Initialize(MyCenterX(i), MyCenterY(i) + MyCrossLen)
        ImageViewer_CCD(i).Image.Overlays.Default.AddLine(MyLine1, Rgb32Value.RedColor)
        ImageViewer_CCD(i).Image.Overlays.Default.AddLine(MyLine2, Rgb32Value.RedColor)

        '取得並畫出圓的外輪廓
        MyRoi.Clear() : MyRoi.Add(MaskToRoiReport_CCD(i).Roi(MyIndex).Shape)
        MyRoi(0).Color = Rgb32Value.YellowColor
        ImageViewer_CCD(i).Image.Overlays.Default.AddRoi(MyRoi)

        '取得被測圓之直徑
        LabRun_Diameter_CCD(i).Text = Format((MyParticleReport_Hull(i).PixelMeasurements(MyIndex, 2) * Val(TextAdv_Pixel_CCD(i).Text)) / 1000, "0.000")

        '顯示孔之真圓度
        If MyParticleReport_TrueCircle(i).PixelMeasurements.GetLength(0) > 0 Then
          For MyCount = 0 To MyParticleReport_TrueCircle(i).PixelMeasurements.GetLength(0) - 1
            If Val(MyParticleReport_TrueCircle(i).PixelMeasurements(0, 5)) > 0 Then LabRun_Defect_TrueCircle_CCD(i).Text = Format(Val(MyParticleReport_TrueCircle(i).PixelMeasurements(0, 5)) * 100, "0.0")
          Next
        End If

        '判斷孔徑是否超規
        If Val(LabRun_Diameter_CCD(i).Text) > (Val(TextTeach_Diameter_CCD(i).Text) + Val(TextTeach_DiameterTolerance_CCD(i).Text)) OrElse _
           Val(LabRun_Diameter_CCD(i).Text) < (Val(TextTeach_Diameter_CCD(i).Text) - Val(TextTeach_DiameterTolerance_CCD(i).Text)) Then '孔徑超規
          LabRun_Diameter_CCD(i).ForeColor = Color.Red
          LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "孔徑超規  "
          MyHoleQualityType(i) = "NG"
          MyResult(i) = "NG"
        Else '孔徑未超規
          LabRun_Diameter_CCD(i).ForeColor = Color.Green
        End If

        '判斷真圓度是否超規
        If Val(LabRun_Defect_TrueCircle_CCD(i).Text) < Val(TextTeach_TrueCircle_CCD(i).Text) Then '真圓度超規
          LabRun_Defect_TrueCircle_CCD(i).ForeColor = Color.Red
          LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "真圓度超規  "
          MyHoleQualityType(i) = "NG"
          MyResult(i) = "NG"
        Else 'OK
          LabRun_Defect_TrueCircle_CCD(i).ForeColor = Color.Green
        End If
      Else
        LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "找不到孔位"
        MyHoleQualityResult(i) = "NG"
        MyHoleQualityType(i) = "NG"
        MyResult(i) = "NG"
      End If
      If Strings.InStr(LabRun_Msg_CCD(i).Text, "孔徑超規") = 0 Then TextOpInf_HoleQualityType.Text = "OK"

      '分析並取得缺點圖像(圓外) ----------------------------------------------------------------------------------------------------------------------------------------------------------------
      '(0:中心X , 1:中心Y , 2:實際直徑 , 3:面積 , 4:最大直徑 , 5:真園度)
      MyParticleReport_DefectOutside(i) = Algorithms.ParticleMeasurements(ImageAdjust_DefectOut(i), PixelMeasurements_CCD(i), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Pixel)
      MaskToRoiReport_DefectOutside(i) = Algorithms.MaskToRoi(ImageAdjust_DefectOut(i))
    Next i

    '將超規之圓外缺點數值及缺點輪廓存至陣列
    Dim MyDefectOverSpec(4, 5000) As String
    For i = 1 To 4
      Dim MyDefectLen_mm As Double = 0
      RoiDefectOutside_CCD(i).Clear()
      MyRowCountOutside(i) = 0
      If MyParticleReport_DefectOutside(i) Is Nothing Then
        LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "圓外檢測失敗"
        MyHoleQualityResult(i) = "NG"
        MyHoleQualityType(i) = "NG"
        MyResult(i) = "NG"
      Else
        For MyLen As Integer = 0 To MyParticleReport_DefectOutside(i).PixelMeasurements.GetLength(0) - 1
          MyDefectLen_mm = Format((MyParticleReport_DefectOutside(i).PixelMeasurements(MyLen, 4) * Val(TextAdv_Pixel_CCD(i).Text)) / 1000, "0.000") '瑕疵長度(mm)
          If MyDefectLen_mm > Val(TextTeach_DefectLength_Outside_CCD(i).Text) Then
            MyRowCountOutside(i) += 1
            MyDefectOverSpec(i, MyRowCountOutside(i)) = MyDefectLen_mm
            RoiDefectOutside_CCD(i).Add(MaskToRoiReport_DefectOutside(i).Roi(MyLen).Shape)
            RoiDefectOutside_CCD(i)(MyRowCountOutside(i) - 1).Color = Rgb32Value.BlueColor
          End If
        Next MyLen
      End If
    Next

    '找出四支CCD之最大缺點數
    Dim DefectCountMax As Integer = 0
    For i = 1 To 4
      If MyRowCountOutside(i) > DefectCountMax Then DefectCountMax = MyRowCountOutside(i)
    Next
    DataGrid_DefectLength_Outside.RowCount = DefectCountMax

    '將超規之圓外缺點數值丟入DataGrid內並於畫面顯示缺點圖
    For i = 1 To 4
      If MyRowCountOutside(i) > 0 Then
        For MyLen As Integer = 0 To MyRowCountOutside(i) - 1
          DataGrid_DefectLength_Outside.Item(i, MyLen).Value = MyDefectOverSpec(i, MyLen + 1) '瑕疵長度(mm)
          DataGrid_DefectLength_Outside.Item(i, MyLen).Style.ForeColor = Color.Red
          ImageViewer_CCD(i).Image.Overlays.Default.AddRoi(RoiDefectOutside_CCD(i))           '顯示缺點圖
        Next
        LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "圓外缺點長度超規  "
        MyHoleQualityResult(i) = "NG"
        MyResult(i) = "NG"
      End If
    Next

    '顯示DataGrid序列號
    For i = 0 To DefectCountMax - 1
      DataGrid_DefectLength_Outside.Item(0, i).Value = i + 1
    Next

    '取像或影像處理失敗(左右孔)
    If Strings.InStr(LabRun_Msg_CCD(2).Text, "失敗") = 0 AndAlso Strings.InStr(LabRun_Msg_CCD(4).Text, "失敗") = 0 Then
      '計算兩被測圓之距離(左右) -----------------------------------------------------------------------------------------------------------------------------------------------------------------------
      Dim MyTwoHoleDistance_X As Double = 0 '兩被測圓之距離X (mm)
      Dim MyTwoHoleDistance_Y As Double = 0 '兩被測圓之距離Y (mm)

      If MyCenterX(2) > -1 AndAlso MyCenterY(2) > -1 AndAlso MyCenterX(4) > -1 AndAlso MyCenterY(4) > -1 Then '左右兩被測圓皆有找到
        MyTwoHoleDistance_X = (((MyCenterX(2) * Val(TextAdv_Pixel_CCD(2).Text)) - (MyCenterX(4) * Val(TextAdv_Pixel_CCD(4).Text))) / 1000) + Val(TextAdv_Distance_LeftRight.Text)   '兩被測圓之距離X (mm)
        MyTwoHoleDistance_Y = ((MyCenterY(2) * Val(TextAdv_Pixel_CCD(2).Text)) - (MyCenterY(4) * Val(TextAdv_Pixel_CCD(4).Text))) / 1000                                            '兩被測圓之距離Y (mm)
        LabRun_Distance_LeftRight.Text = Format(Math.Sqrt((MyTwoHoleDistance_X ^ 2) + (MyTwoHoleDistance_Y ^ 2)), "0.0000") + Val(TextAdv_Distance_LeftRight_Offset.Text)           '兩被測圓之距離  (mm)

        '判斷兩孔距離是否超規(左右)
        If Val(LabRun_Distance_LeftRight.Text) > (Val(TextTeach_Distance_LeftRight.Text) + Val(TextTeach_DistanceTolerance_LeftRight.Text)) OrElse _
           Val(LabRun_Distance_LeftRight.Text) < (Val(TextTeach_Distance_LeftRight.Text) - Val(TextTeach_DistanceTolerance_LeftRight.Text)) Then '孔距離超規
          LabRun_Distance_LeftRight.ForeColor = Color.Red
          LabRun_Msg_CCD(2).Text = LabRun_Msg_CCD(2).Text & "左右孔距離超規  "
          LabRun_Msg_CCD(4).Text = LabRun_Msg_CCD(4).Text & "左右孔距離超規  "
          MyHoleDustanceAndResultX = "NG"
          MyResult(2) = "NG" : MyResult(4) = "NG"
        Else '孔距離未超規
          LabRun_Distance_LeftRight.ForeColor = Color.Green
        End If
      End If
    Else
      If Strings.InStr(LabRun_Msg_CCD(2).Text, "失敗") = 0 Then MyResult(2) = "NG"
      If Strings.InStr(LabRun_Msg_CCD(4).Text, "失敗") = 0 Then MyResult(4) = "NG"
    End If

    '取像或影像處理失敗(上下孔)
    If Strings.InStr(LabRun_Msg_CCD(1).Text, "失敗") = 0 OrElse Strings.InStr(LabRun_Msg_CCD(3).Text, "失敗") = 0 Then
      '計算兩被測圓之距離(上下) -----------------------------------------------------------------------------------------------------------------------------------------------------------------------
      Dim MyTwoHoleDistance_X As Double = 0 '兩被測圓之距離X (mm)
      Dim MyTwoHoleDistance_Y As Double = 0 '兩被測圓之距離Y (mm)

      If MyCenterX(1) > -1 AndAlso MyCenterY(1) > -1 AndAlso MyCenterX(3) > -1 AndAlso MyCenterY(3) > -1 Then '左右兩被測圓皆有找到
        MyTwoHoleDistance_X = ((MyCenterX(3) * Val(TextAdv_Pixel_CCD(3).Text)) - (MyCenterX(1) * Val(TextAdv_Pixel_CCD(1).Text))) / 1000                                        '兩被測圓之距離X (mm)
        MyTwoHoleDistance_Y = (((MyCenterY(3) * Val(TextAdv_Pixel_CCD(3).Text)) - (MyCenterY(1) * Val(TextAdv_Pixel_CCD(1).Text))) / 1000) + Val(TextAdv_Distance_UpDown.Text)  '兩被測圓之距離Y (mm)
        LabRun_Distance_UpDown.Text = Format(Math.Sqrt((MyTwoHoleDistance_X ^ 2) + (MyTwoHoleDistance_Y ^ 2)), "0.0000") + Val(TextAdv_Distance_UpDown_Offset.Text)             '兩被測圓之距離  (mm)

        '判斷兩孔距離是否超規(上下)
        If Val(LabRun_Distance_UpDown.Text) > (Val(TextTeach_Distance_UpDown.Text) + Val(TextTeach_DistanceTolerance_UpDown.Text)) OrElse _
           Val(LabRun_Distance_UpDown.Text) < (Val(TextTeach_Distance_UpDown.Text) - Val(TextTeach_DistanceTolerance_UpDown.Text)) Then '孔距離超規
          LabRun_Distance_UpDown.ForeColor = Color.Red
          LabRun_Msg_CCD(1).Text = LabRun_Msg_CCD(1).Text & "上下孔距離超規  "
          LabRun_Msg_CCD(3).Text = LabRun_Msg_CCD(3).Text & "上下孔距離超規  "
          MyHoleDustanceAndResultY = "NG"
          MyResult(1) = "NG" : MyResult(3) = "NG"
        Else '孔距離未超規
          LabRun_Distance_UpDown.ForeColor = Color.Green
        End If
      End If
    Else
      If Strings.InStr(LabRun_Msg_CCD(1).Text, "失敗") = 0 Then MyResult(1) = "NG"
      If Strings.InStr(LabRun_Msg_CCD(3).Text, "失敗") = 0 Then MyResult(3) = "NG"
    End If

    MySearch1_Time2 = Now.Subtract(MySearch1_Time1)
    LabTimeInf_Search1.Text = Format(MySearch1_Time2.TotalMilliseconds, "0")

    'Search2 檢測 =============================================================================================================================================================================================
    MySearch2_Time1 = Now
    '載入圖片 ------------------------------------------------------------------------
    Dim MyImagePathAndName As String
    Dim MyHaveImage(4) As Boolean
    For i = 1 To 4
      LabSearch2_Result_CCD(i).BackColor = Color.White
      MyImagePathAndName = SourceImagePath & "\SourceImage" & i.ToString & ".png"
      If File.Exists(MyImagePathAndName) = False Then
        LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "檢測2圖像不存在  "
        MyHaveImage(i) = False
      Else
        Try
          SetImage(ClassIntPtr(i), MyImagePathAndName)
          MyHaveImage(i) = True
        Catch ex As Exception
          LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "檢測2圖像載入失敗  "
          MyHaveImage(i) = False
        End Try
      End If
    Next

    '載入參數 ------------------------------------------------------------------------
    For i = 1 To 4
      SetParameter(ClassIntPtr(i), MyCenterX(i), MyCenterY(i), CSng(TextSearch2_MeasureWidth.Text), CSng(TextSearch2_CircleDiameter.Text), Val(TextSearch2_Inward.Text), 2, 1, Val(TextSearch2_Threshold.Text), 360, UpDownSearch2_Score.Value)
    Next
    'Call BtnSearch2_SetParameter_Click(BtnSearch2_SetParameter, e)
    Application.DoEvents()

    '檢測 ----------------------------------------------------------------------------
    'Dim MySearchResult As Boolean
    Dim MySplit() As String = Nothing
    Dim MySearch2_ReceiveTime1 As Date = Now
    Dim MySearch2_ReceiveTime2 As TimeSpan

    For i = 1 To 4
      MySearch2_ReceiveTime1 = Now
      MyResult_Search2(i) = False
      LabSearch2_Result_CCD(i).BackColor = Color.White
      If MyHaveImage(i) = True Then
        CcdIndex_Search2 = i
        MyResult_Search2(i) = Measure(ClassIntPtr(i), Val(TextSearch2_ContinueCount.Text), Val(TextSearch2_NonContinueCount.Text), CDbl(TextSearch2_Gain.Text), CDbl(TextSearch2_Offset.Text))
        If MyResult_Search2(i) = True Then
          MyResult_Search2(i) = "OK"
          LabSearch2_Result_CCD(i).BackColor = Color.Lime
        Else
          MyResult_Search2(i) = "NG"
          MyHoleQualityResult(i) = "NG"
          LabSearch2_Result_CCD(i).BackColor = Color.Red
        End If
      Else
        MyResult_Search2(i) = "NG"
        MyHoleQualityResult(i) = "NG"
      End If

      '等待回傳資料
      Do Until TextServer_Receive_CCD(i).Text <> ""
        MySearch2_ReceiveTime2 = Now.Subtract(MySearch2_ReceiveTime1)
        If MySearch2_ReceiveTime2.TotalMilliseconds > 3000 Then Exit Do
        Application.DoEvents() : Thread.Sleep(1)
      Loop

      If MySearch2_ReceiveTime2.TotalMilliseconds > 3000 Then
        LabRun_Msg_CCD(i).Text = "檢測二回傳毛邊數值逾時"
        Call WriteMessage("檢測二回傳 CCD" & i.ToString & " 毛邊數值逾時")
      Else
        MySplit = Strings.Split(TextServer_Receive_CCD(i).Text, ",")
        LabServer_Receive_ContinueCount_CCD(i).Text = Val(MySplit(0))
        LabServer_Receive_NonContinueCount_CCD(i).Text = Val(MySplit(1))
        If LabServer_Receive_ContinueCount_CCD(i).Text >= Val(TextSearch2_ContinueCount.Text) Then LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "毛邊連續長度超規  "
        If LabServer_Receive_NonContinueCount_CCD(i).Text >= Val(TextSearch2_NonContinueCount.Text) Then LabRun_Msg_CCD(i).Text = LabRun_Msg_CCD(i).Text & "毛邊累計長度超規  "
        LabServer_Receive_ContinueCount_CCD(i).ForeColor = IIf(Val(LabServer_Receive_ContinueCount_CCD(i).Text) >= Val(TextSearch2_ContinueCount.Text), Color.Red, Color.Green)
        LabServer_Receive_NonContinueCount_CCD(i).ForeColor = IIf(Val(LabServer_Receive_NonContinueCount_CCD(i).Text) >= Val(TextSearch2_NonContinueCount.Text), Color.Red, Color.Green)
      End If
    Next
    MySearch2_Time2 = Now.Subtract(MySearch2_Time1)
    LabTimeInf_Search2.Text = Format(MySearch2_Time2.TotalMilliseconds, "0")
    LabTimeInf_SearchTotal.Text = Val(LabTimeInf_Search1.Text) + Val(LabTimeInf_Search2.Text)
SearchEnd:
    MyRoi.Dispose()
    MyLine1 = Nothing : MyLine2 = Nothing
    'MyHoleQualityResult,MyHoleQualityType,MyHoleDustanceAndResultX,MyHoleDustanceAndResultY
    '孔品質結果判定 ----------------------------------------------------------------------------------------------------------------------------------------------------------------
    If MyHoleQualityResult(1) = "OK" AndAlso MyHoleQualityResult(2) = "OK" AndAlso MyHoleQualityResult(3) = "OK" AndAlso MyHoleQualityResult(4) = "OK" Then
      TextOpInf_HoleQualityResult.Text = "OK"
    Else
      TextOpInf_HoleQualityResult.Text = "NG"
    End If
    '孔品質種類判定 ----------------------------------------------------------------------------------------------------------------------------------------------------------------
    If MyHoleQualityType(1) = "OK" AndAlso MyHoleQualityType(2) = "OK" AndAlso MyHoleQualityType(3) = "OK" AndAlso MyHoleQualityType(4) = "OK" Then
      TextOpInf_HoleQualityType.Text = "OK"
    Else
      TextOpInf_HoleQualityType.Text = "NG"
    End If
    'X方向孔距離量測及判定結果------------------------------------------------------------------------------------------------------------------------------------------------------
    If MyHoleDustanceAndResultX = "OK" Then
      TextOpInf_HoleDustanceAndResultX.Text = "OK"
      TextOpInf_HoleDustanceAndResultX.ForeColor = Color.Green
    Else
      TextOpInf_HoleDustanceAndResultX.Text = "NG"
      TextOpInf_HoleDustanceAndResultX.ForeColor = Color.Red
    End If
    'Y方向孔距離量測及判定結果 -----------------------------------------------------------------------------------------------------------------------------------------------------
    If MyHoleDustanceAndResultY = "OK" Then
      TextOpInf_HoleDustanceAndResultY.Text = "OK"
      TextOpInf_HoleDustanceAndResultY.ForeColor = Color.Green
    Else
      TextOpInf_HoleDustanceAndResultY.Text = "NG"
      TextOpInf_HoleDustanceAndResultY.ForeColor = Color.Red
    End If

    '最終結果 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------
    For i = 1 To 4
      If MyResult(i) = "OK" Then
        LabSearch1_Result_CCD(i).BackColor = Color.Lime
      Else
        LabSearch1_Result_CCD(i).BackColor = Color.Red
      End If
    Next
    If (MyResult(1) = "OK" AndAlso MyResult_Search2(1) = "OK") AndAlso (MyResult(2) = "OK" AndAlso MyResult_Search2(2) = "OK") AndAlso (MyResult(3) = "OK" AndAlso MyResult_Search2(3) = "OK") AndAlso (MyResult(4) = "OK" AndAlso MyResult_Search2(4) = "OK") Then
      LabRun_SearchResult.Text = "OK"
      LabRun_SearchResult.BackColor = Color.Lime
    Else
      LabRun_SearchResult.Text = "NG"
      LabRun_SearchResult.BackColor = Color.Red
    End If

    Call SaveSearchData() '儲存檢測資料

    '儲存NG圖 ------------------------------------------------------------------------------------------
    If CheckAdv_Option_SaveNgPic.Checked = True Then
      If LabRun_SearchResult.Text = "NG" Then
        '設定 NG 圖存放路徑
        NgImagePath = ProgramPath & "\NG Image"
        '建立 ProgramPath\NG Image 目錄夾
        Try
          If Directory.Exists(NgImagePath) = False Then
            Directory.CreateDirectory(NgImagePath)
            LabRunningMsg.Text = NgImagePath & " 目錄夾建立成功"
          End If
        Catch ex As Exception
          LabRunningMsg.Text = NgImagePath & " 目錄夾建立失敗"
          Call WriteMessage(NgImagePath & " 目錄夾建立失敗")
          Exit Sub
        End Try

        NgImagePath = ProgramPath & "\NG Image\" & LabFileName.Text
        '建立 ProgramPath\NG Image\產品檔名稱 之目錄夾
        Try
          If Directory.Exists(NgImagePath) = False Then
            MkDir(NgImagePath)
            LabRunningMsg.Text = NgImagePath & " 目錄夾建立成功"
          End If
        Catch ex As Exception
          LabRunningMsg.Text = NgImagePath & " 目錄夾建立失敗"
          Call WriteMessage(NgImagePath & " 目錄夾建立失敗")
          Exit Sub
        End Try

        Dim MyDateTime As String = Format(Now, "yyyyMMdd-HHmmss_CCD")
        For i = 1 To 4
          If CCD_ImageSource(i).Width > 0 Then CCD_ImageSource(i).WritePngFile(NgImagePath & "\" & MyDateTime & i.ToString & "_" & IIf(LabRun_Msg_CCD(i).Text <> "", Strings.Trim(LabRun_Msg_CCD(i).Text), "OK") & ".png")
        Next
      End If
    End If

    Searching = False
    PlcThreadStopKey = False
  End Sub
  '產品參數→影像處理→孔徑二值化(拉霸)
  Private Sub TrackBarTeach_Binary_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarTeach_BinaryMin.ValueChanged, TrackBarTeach_BinaryMax.ValueChanged
    If Me.Created = False Then Exit Sub
    TextTeach_BinaryMin.Text = TrackBarTeach_BinaryMin.Value
    TextTeach_BinaryMax.Text = TrackBarTeach_BinaryMax.Value
    Call ImageAdjust_Search(0, 1, True)
  End Sub
  '產品參數→影像處理→孔徑二值化(值)
  Private Sub TextTeach_Binary_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextTeach_BinaryMin.TextChanged, TextTeach_BinaryMax.TextChanged
    If Me.Created = False Then Exit Sub
    If TextTeach_BinaryMin.Text = "" OrElse TextTeach_BinaryMax.Text = "" Then Exit Sub
    TrackBarTeach_BinaryMin.Value = TextTeach_BinaryMin.Text
    TrackBarTeach_BinaryMax.Value = TextTeach_BinaryMax.Text
  End Sub
  '產品參數→影像處理→填滿仿真圓
  Private Sub BtnTeach_Hull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTeach_Hull.Click
    If Me.Created = False Then Exit Sub
    Call ImageAdjust_Search(0, 2, True)
  End Sub
  '顯示覆蓋圓 BtnTeach_ShowMaskCircle
  Private Sub BtnTeach_ShowMaskCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTeach_ShowMaskCircle.Click
    Call ImageAdjust_Search(0, 8, True)
  End Sub
  '圓外覆蓋圓
  Private Sub BtnTeach_MaskCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTeach_MaskCircle.Click
    Call ImageAdjust_Search(0, 9, True)
  End Sub
  '產品參數→影像處理→圓外缺點二值化(拉霸)
  Private Sub TrackBarTeach_BinaryDefectOut_Binary_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarTeach_BinaryDefectOut.ValueChanged
    If Me.Created = False Then Exit Sub
    TextTeach_BinaryDefectOut.Text = TrackBarTeach_BinaryDefectOut.Value
    Call ImageAdjust_Search(0, 10, True)
  End Sub
  '產品參數→影像處理→圓外缺點二值化(值)
  Private Sub TextTeach_BinaryDefectOut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextTeach_BinaryDefectOut.TextChanged
    If Me.Created = False Then Exit Sub
    'If TrackBarTeach_BinaryDefectOut.Text = "" Then Exit Sub
    TrackBarTeach_BinaryDefectOut.Value = TextTeach_BinaryDefectOut.Text
  End Sub

  Private Sub TimerRunState_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRunState.Tick
    LabService_RunIndex.Text = RunIndex_Main
  End Sub

  Private Sub BtnRun_ResetRunIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun_ResetRunIndex.Click
    If MsgBox("確定清除作業程序 ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
      Call WriteMessage("清除作業程序")
      RunIndex_Main = 1

      'Dim MyIndex As Short = 1
      'Dim MyStr As String = ""
      'Dim MyStrAll As String = ""
      'Dim i, j As Integer

      'For i = 1 To 3
      '  For j = 0 To 15
      '    MyIndex = 1
      '    MyStr = "X" & i.ToString & Hex(j).ToString
      '    AxActUtlType_PLC.ReadDeviceRandom2(MyStr, 1, MyIndex)
      '    If MyIndex = 1 Then
      '      MyStrAll = MyStrAll & MyStr & vbNewLine
      '    End If
      '  Next
      'Next
      'MsgBox(MyStrAll)
    End If
  End Sub
  '只能輸入數字
  Private Sub TextTeach_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextTeach_Diameter_CCD1.KeyPress, TextTeach_Diameter_CCD2.KeyPress, TextTeach_Diameter_CCD3.KeyPress, TextTeach_Diameter_CCD4.KeyPress, TextTeach_DistanceTolerance_UpDown.KeyPress, TextTeach_DistanceTolerance_LeftRight.KeyPress, TextTeach_Distance_UpDown.KeyPress, TextTeach_Distance_LeftRight.KeyPress, TextTeach_DiameterTolerance_CCD1.KeyPress, TextTeach_DiameterTolerance_CCD2.KeyPress, TextTeach_DiameterTolerance_CCD3.KeyPress, TextTeach_DiameterTolerance_CCD4.KeyPress, TextTeach_BinaryMin.KeyPress, TextTeach_BinaryMax.KeyPress, TextAdv_Pixel_CCD4.KeyPress, TextAdv_Pixel_CCD3.KeyPress, TextAdv_Pixel_CCD2.KeyPress, TextAdv_Pixel_CCD1.KeyPress, TextAdv_Option_CaptureDelay.KeyPress, TextAdv_Distance_UpDown.KeyPress, TextAdv_Distance_LeftRight.KeyPress, TextAdv_CircleSize.KeyPress, TextAdv_CalibTool_DistanceY.KeyPress, TextAdv_CalibTool_DistanceX.KeyPress, TextAdv_Calib_BinaryMin.KeyPress, TextAdv_Calib_BinaryMax.KeyPress, TextAdv_Angle_UpDown.KeyPress, TextAdv_Angle_LeftRight.KeyPress, TextTeach_DefectLength_Inside_CCD1.KeyPress, TextTeach_DefectLength_Inside_CCD2.KeyPress, TextTeach_DefectLength_Inside_CCD3.KeyPress, TextTeach_DefectLength_Inside_CCD4.KeyPress, TextTeach_TrueCircle_CCD4.KeyPress, TextTeach_TrueCircle_CCD3.KeyPress, TextTeach_TrueCircle_CCD2.KeyPress, TextTeach_TrueCircle_CCD1.KeyPress, TextTeach_MaskCircleSize.KeyPress, TextTeach_Laser_LimitUp.KeyPress, TextTeach_Laser_LimitDown.KeyPress, TextTeach_DefectLength_Outside_CCD4.KeyPress, TextTeach_DefectLength_Outside_CCD3.KeyPress, TextTeach_DefectLength_Outside_CCD2.KeyPress, TextTeach_DefectLength_Outside_CCD1.KeyPress, TextAdv_Distance_UpDown_Offset.KeyPress, TextAdv_Distance_LeftRight_Offset.KeyPress
    If Not (Char.IsNumber(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "." OrElse e.KeyChar = "-") Then e.KeyChar = Nothing
  End Sub
  '讀取 Barcode
  Private Sub BtnReadBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTool_ReadBarcode.Click
    Dim MySendData(2) As Byte
    Dim MyTime1 As Date = Now
    Dim MyTime2 As TimeSpan

    BtnTool_ReadBarcode.Enabled = False
    TextRun_Barcode_Reader.Text = "" : TextRun_Barcode_Reader.Refresh()
    LabRunningMsg.Text = "條碼讀取中" : LabRunningMsg.Refresh()
    Threading.Thread.Sleep(100)
    MySendData(0) = &H1B
    MySendData(1) = &H5A
    MySendData(2) = &HD

    SerialPort_Barcode.Write(MySendData, 0, 3)

    Do : Application.DoEvents() : Threading.Thread.Sleep(1)
      MyTime2 = Now.Subtract(MyTime1)
    Loop Until TextRun_Barcode_Reader.Text.Length > 0 OrElse MyTime2.Seconds >= 2

    If MyTime2.Seconds >= 2 Then
      '關閉條碼讀取
      MySendData(0) = &H1B
      MySendData(1) = &H59
      MySendData(2) = &HD
      SerialPort_Barcode.Write(MySendData, 0, 3)

      LabRunningMsg.Text = "讀取條碼逾時"
      Call WriteMessage("讀取條碼逾時")
    End If
    BtnTool_ReadBarcode.Enabled = True
  End Sub
  '接收Barcode回傳資料
  Private Sub SerialPort_Barcode_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort_Barcode.DataReceived
    Try
      LabRunningMsg.Text = "讀取條碼中 ..."
      Dim MyBuff(SerialPort_Barcode.BytesToRead - 1) As Byte
      Dim MyStr As String = ""
      Dim MyValue As Integer = 0

      SerialPort_Barcode.Read(MyBuff, 0, MyBuff.Length)

      For i As Integer = 0 To MyBuff.Length - 1
        If MyBuff(i) <> 13 Then MyStr &= Chr(MyBuff(i))
      Next
      TextRun_Barcode_Reader.Text &= MyStr
      LabRunningMsg.Text = "條碼讀取完成"
    Catch ex As Exception
      LabRunningMsg.Text = "讀取條碼逾時"
      TextRun_Barcode_Reader.Text = ""
    End Try
  End Sub
  '載入最後NG圖
  Private Sub BtnRun_LoadNgImages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun_LoadNgImages.Click
    Dim MyImagePath As String = ProgramPath & "\NG Image\" & LabFileName.Text

    If Directory.Exists(MyImagePath) = False Then
      MsgBox("NG圖路徑不存在" & vbNewLine & vbNewLine & "(" & MyImagePath & ")")
      Exit Sub
    End If
    Dim MyAllFile() As String = Directory.GetFiles(MyImagePath) '取得指定資料夾內所有檔案名稱
    Dim MyLastFile As String = ""                               '資料夾內最新的一筆檔案名稱
    Dim MyLastFile_GetDateTime As String = ""                   '取得最新一筆檔案名稱的日期時間部分
    'Dim MyLastFile_Conform() As String                          '存放所有符合該日期時間的檔案
    'Dim MyConformCount As Integer = 0                           '符合該日期時間的檔案個數
    Dim MyList_FindFile As New List(Of String)

    Try
      Array.Sort(MyAllFile) '將陣列內檔案名稱做排序
      MyLastFile = MyAllFile(MyAllFile.Length - 1)
      MyLastFile_GetDateTime = Strings.Mid(MyLastFile, MyLastFile.LastIndexOf("\") + 2, 15)
      MyList_FindFile.Clear()
      For i As Integer = 0 To MyAllFile.Length - 1
        'MyConformCount += 1
        If Strings.InStr(MyAllFile(i), MyLastFile_GetDateTime) > 0 Then
          MyList_FindFile.Add(MyAllFile(i))
        End If
      Next

      If MyList_FindFile.Count > 4 Then
        MsgBox("NG圖數量錯誤", MsgBoxStyle.Information, BtnRun_LoadNgImages.Text)
        Exit Sub
      End If
      For i As Integer = 0 To MyList_FindFile.Count - 1
        ImageViewer_CCD(i + 1).Image.ReadFile(MyList_FindFile(i))
        Algorithms.Copy(ImageViewer_CCD(i + 1).Image, CCD_ImageSource(i + 1))

        '建立 ProgramPath\Source Image 目錄夾
        Try : If Directory.Exists(SourceImagePath) = False Then Directory.CreateDirectory(SourceImagePath)
        Catch ex As Exception : End Try

        '儲存檢測2圖檔
        CCD_ImageSource(i + 1).WritePngFile(SourceImagePath & "\SourceImage" & (i + 1).ToString & ".png")

        '載入檢測2圖檔
        Dim MyImagePathAndName As String
        LabSearch2_Result_CCD(i + 1).BackColor = Color.White
        MyImagePathAndName = SourceImagePath & "\SourceImage" & (i + 1).ToString & ".png"
        If File.Exists(MyImagePathAndName) = False Then
          LabRun_Msg_CCD(i + 1).Text = "檢測2圖像" & (i + 1).ToString & " 不存在"
        Else
          Try : SetImage(ClassIntPtr(i + 1), MyImagePathAndName)
          Catch ex As Exception
            LabRun_Msg_CCD(i + 1).Text = "檢測2圖像" & (i + 1).ToString & " 載入失敗"
          End Try
        End If

      Next
    Catch ex As Exception
      MsgBox(ex.Message, MsgBoxStyle.Critical, BtnRun_LoadNgImages.Text)
    End Try

    'DialogLoadNgImage.BtnOpen.Visible = True
    'DialogLoadNgImage.BtnDelete.Visible = IIf(LabLevel.Text = "未登入" Or LabLevel.Text = "作業員", False, True)
    'DialogLoadNgImage.ShowDialog()
  End Sub

  Private Sub DataGrid_DefectLength_Inside_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    'If Searching = True Then Exit Sub
    'If DataGrid_DefectLength_Inside.RowCount = 0 Then Exit Sub

    'Dim MyRoi As New Roi
    'Dim MyIndex As Integer = DataGrid_DefectLength_Inside.Item(0, DataGrid_DefectLength_Inside.SelectedRows(0).Index).Value - 1

    'For i As Integer = 1 To 4
    '  ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
    '  Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)

    '  '左右孔
    '  If CheckSearch_LeftRight.Checked = True AndAlso (i = 1 OrElse i = 4) Then
    '    '畫出缺點位置
    '    If MaskToRoiReport_DefectInside(i).Roi.Count > 0 AndAlso MaskToRoiReport_DefectInside(i).Roi.Count > MyIndex Then
    '      MyRoi.Clear()
    '      MyRoi.Add(MaskToRoiReport_DefectInside(i).Roi(MyIndex).Shape)
    '      MyRoi(0).Color = Rgb32Value.RedColor
    '      ImageViewer_CCD(i).Image.Overlays.Default.AddRoi(MyRoi)
    '    End If
    '  End If

    '  '上下孔
    '  If CheckSearch_LeftRight.Checked = True AndAlso (i = 2 OrElse i = 3) Then
    '    '畫出缺點位置
    '    If MaskToRoiReport_DefectInside(i).Roi.Count > 0 AndAlso MaskToRoiReport_DefectInside(i).Roi.Count > MyIndex Then
    '      MyRoi.Clear()
    '      MyRoi.Add(MaskToRoiReport_DefectInside(i).Roi(MyIndex).Shape)
    '      MyRoi(0).Color = Rgb32Value.RedColor
    '      ImageViewer_CCD(i).Image.Overlays.Default.AddRoi(MyRoi)
    '    End If
    '  End If
    'Next
    'MyRoi.Dispose()
  End Sub

  Private Sub DataGrid_DefectLength_Outside_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGrid_DefectLength_Outside.CellEnter
    If Searching = True Then Exit Sub
    If DataGrid_DefectLength_Outside.RowCount = 0 Then Exit Sub

    Dim MyRoi As New Roi
    Dim MyIndex As Integer = DataGrid_DefectLength_Outside.Item(0, DataGrid_DefectLength_Outside.SelectedRows(0).Index).Value - 1

    For i As Integer = 1 To 4
      ImageViewer_CCD(i).Palette.Type = PaletteType.Gray
      Algorithms.Copy(CCD_ImageSource(i), ImageViewer_CCD(i).Image)

      '左右孔
      If CheckSearch_LeftRight.Checked = True AndAlso (i = 1 OrElse i = 4) Then
        '畫出缺點位置
        If RoiDefectOutside_CCD(i).Count > 0 AndAlso RoiDefectOutside_CCD(i).Count > MyIndex Then
          MyRoi.Clear()
          MyRoi.Add(RoiDefectOutside_CCD(i)(MyIndex).Shape)
          MyRoi(0).Color = Rgb32Value.BlueColor
          ImageViewer_CCD(i).Image.Overlays.Default.AddRoi(MyRoi)
        End If
      End If

      '上下孔
      If CheckSearch_LeftRight.Checked = True AndAlso (i = 2 OrElse i = 3) Then
        '畫出缺點位置
        If RoiDefectOutside_CCD(i).Count > 0 AndAlso RoiDefectOutside_CCD(i).Count > MyIndex Then
          MyRoi.Clear()
          MyRoi.Add(RoiDefectOutside_CCD(i)(MyIndex).Shape)
          MyRoi(0).Color = Rgb32Value.BlueColor
          ImageViewer_CCD(i).Image.Overlays.Default.AddRoi(MyRoi)
        End If
      End If
    Next
    MyRoi.Dispose()
  End Sub
  'PLC連線鈕
  Public Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click

    Dim iReturnCode As Integer
    Dim iLogicalStationNumber = 1
    Text_ReturnCode.Text = ""
    Try
      If Radio_PlcRunning.Checked = False Then

        iReturnCode = AxActUtlType_PLC.Open()
      Else
        If GetIntValue(txt_LogicalStationNumber, iLogicalStationNumber) = False Then
          Exit Sub
        End If
        AxActUtlType_PLC.ActLogicalStationNumber = iLogicalStationNumber
        iReturnCode = AxActUtlType_PLC.Open()
        If iReturnCode = 0 Then
          txt_LogicalStationNumber.Enabled = False
        End If
        PlcRunningKey = True
      End If
    Catch exception As Exception
      MessageBox.Show(exception.Message, Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End Try
    Text_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)
  End Sub
  'PLC斷線鈕
  Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
    Dim iReturnCode As Integer
    Text_ReturnCode.Text = ""
    Try
      If Radio_PlcRunning.Checked = True Then
        iReturnCode = AxActUtlType_PLC.Close()
        PlcRunningKey = False
      Else
        If iReturnCode = 0 Then

        End If
      End If

    Catch exception As Exception
      MessageBox.Show(exception.Message, Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End Try

    Text_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", iReturnCode)

  End Sub
  '清除片數
  Private Sub Btn_ClearSearchCount_M1820_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ClearSearchCount_M1820.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1820", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1820", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  'AlarmReset
  Public Sub Btn_AlarmReset_M1300_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_AlarmReset_M1300.Click, BtnTool_AlarmReset.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1300", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1300", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '手動Trigger CCD
  Private Sub M1902_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_CcdTrigger_M1902.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1902", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1902", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '手動Trigger Reader 
  Private Sub Btn_ReaderTrigger_M1900_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_ReaderTrigger_M1900.Click
    Dim MyBtn As Button = sender
    Btn_ReaderTrigger_M1900.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1900", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1900", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    Btn_ReaderTrigger_M1900.Enabled = True
  End Sub
  '手動真空
  Private Sub Btn_VacuumOnOff_M1912_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_VacuumOnOff_M1912.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1912", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1912", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '手動運行前進
  Private Sub Btn_MoveFront_M1120_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_MoveFront_M1120.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1120", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1120", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '手動運行後退
  Private Sub Btn_MoveBack_M1121_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_MoveBack_M1121.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1121", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1121", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '吋動運行→前進
  Private Sub Btn_MoveFront_M1150_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_MoveFront_M1150.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1150", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1150", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '吋動運行→後退
  Private Sub Btn_MoveBack_M1151_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_MoveBack_M1151.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1151", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1151", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '選擇運行模式0.1m/min
  Private Sub M1103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_MoveSpeedPtp_M1103.Click
    Dim MyRadio As RadioButton = sender
    'MyRadio.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1103", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1102", 1, 0)
      AxActUtlType_PLC.WriteDeviceRandom2("M1101", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, "手動運行參數")
    End If
    'MyRadio.Enabled = True
  End Sub
  '選擇運行模式0.5m/min
  Private Sub M1102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_MoveSpeedPtp_M1102.Click
    Dim MyRadio As RadioButton = sender
    'MyRadio.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1102", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1103", 1, 0)
      AxActUtlType_PLC.WriteDeviceRandom2("M1101", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, "手動運行參數")
    End If
    'MyRadio.Enabled = True
  End Sub
  '選擇運行模式1m/min
  Private Sub M1101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_MoveSpeedPtp_M1101.Click
    Dim MyRadio As RadioButton = sender
    'MyRadio.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1101", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1102", 1, 0)
      AxActUtlType_PLC.WriteDeviceRandom2("M1103", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, "手動運行參數")
    End If
    'MyRadio.Enabled = True
  End Sub
  '手動原點復歸
  Private Sub M1000_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Home_M1000.Click, BtnTool_Home.Click
    Dim MyBtn As Button = sender
    Dim MyTime1 As Date
    Dim MyTime2 As TimeSpan

    'MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1000", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1000", 1, 0)
      LabRunningMsg.Text = "馬達開始復歸" : LabRun_Msg_PLC.Refresh()
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
      GoTo HomeEnd
    End If
    MyTime1 = Now
    Do : Application.DoEvents() : Threading.Thread.Sleep(1)
      LabRunningMsg.Text = "馬達復歸中" : LabRun_Msg_PLC.Refresh()
      MyTime2 = Now.Subtract(MyTime1)
    Loop Until Lab_HomeFinish_M1001.BackColor = Color.WhiteSmoke OrElse Lab_HomeFinish_M1001.BackColor = Color.Yellow OrElse MyTime2.Seconds > 30

    If MyTime2.Seconds > 30 Then
      MsgBox("馬達原點復歸逾時", MsgBoxStyle.Exclamation, "馬達復歸")
      GoTo HomeEnd
    End If

    Do : Application.DoEvents() : Threading.Thread.Sleep(1)
    Loop Until Lab_HomeFinish_M1001.BackColor = Color.Lime
    LabRunningMsg.Text = "馬達復歸完成"

    Threading.Thread.Sleep(2000)

    Call Btn_StandbyPositionMove_M1154_Click(Btn_StandbyPositionMove_M1154, Nothing) '馬達移至待命區
HomeEnd:
    MyBtn.Enabled = True
  End Sub
  '選擇吋動運行模式1un
  Private Sub Radio_MoveSpeedC_M1130_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_MoveSpeedC_M1130.Click
    Dim MyRadio As RadioButton = sender
    'MyRadio.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1130", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1131", 1, 0)
      AxActUtlType_PLC.WriteDeviceRandom2("M1132", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, "吋動運行參數")
    End If
    'MyRadio.Enabled = True
  End Sub
  '選擇吋動運行模式10un
  Private Sub Radio_MoveSpeedC_M1131_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_MoveSpeedC_M1131.Click
    Dim MyRadio As RadioButton = sender
    MyRadio.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1131", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1130", 1, 0)
      AxActUtlType_PLC.WriteDeviceRandom2("M1132", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, "吋動運行參數")
    End If
    MyRadio.Enabled = True
  End Sub
  '選擇吋動運行模式100un
  Private Sub Radio_MoveSpeedC_M1132_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_MoveSpeedC_M1132.Click
    Dim MyRadio As RadioButton = sender
    'MyRadio.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1132", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1130", 1, 0)
      AxActUtlType_PLC.WriteDeviceRandom2("M1131", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, "吋動運行參數")
    End If

  End Sub
  '指定到檢測碼區
  Private Sub Btn_SearchPositionMove_M1153_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_SearchPositionMove_M1153.Click, BtnRun_MoveToSearchPos.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1153", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1153", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '寫入位置→檢測區
  Private Sub Btn_SearchPositionSet_M1201_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_SearchPositionSet_M1201.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1201", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1201", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '指定到達讀碼區
  Private Sub Btn_BarcodePositionMove_M1152_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BarcodePositionMove_M1152.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1152", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1152", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '寫入位置→掃描區
  Private Sub Btn_BarcodePositionSet_M1200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BarcodePositionSet_M1200.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1200", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1200", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '指定到達待命區
  Private Sub Btn_StandbyPositionMove_M1154_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_StandbyPositionMove_M1154.Click, BtnRun_MoveToStandbyPos.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1154", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1154", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '寫入位置→待命區
  Private Sub Btn_StandbyPositionSet_M1202_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_StandbyPositionSet_M1202.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M1202", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M1202", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
  End Sub
  '設定Trigger延遲時間
  Private Sub Btn_TriggerDelaySet_D3010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_TriggerDelaySet_D3010.Click
    Dim iReturnCode20 As Long
    If Radio_PlcRunning.Checked = True Then
      iReturnCode20 = AxActUtlType_PLC.WriteDeviceBlock2("D3010", 1, Val(Text_TriggerDelaySet_D3010.Text))
    End If

  End Sub
  '設定馬達移動速度
  Private Sub Btn_MoveSpeedSet_D1030_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_MoveSpeedSet_D1030.Click
    Dim iReturnCode21 As Long
    If Val(Lab_MoveSpeedSet_D1030.Text) > 2 Then Lab_MoveSpeedSet_D1030.Text = "2"

    If Radio_PlcRunning.Checked = True Then
      iReturnCode21 = AxActUtlType_PLC.WriteDeviceBlock2("D1030", 1, Val(Lab_MoveSpeedSet_D1030.Text))
    End If
  End Sub
  'Processing of OnDeviceStatus event by ActUtlType
  Private Sub AxActUtlType1_OnDeviceStatus(ByVal sender As System.Object, ByVal e As AxActUtlTypeLib._IActUtlTypeEvents_OnDeviceStatusEvent)

    'Assign the array for editing the data of 'Data'.
    Dim szarrData(txt_Data.Lines.Length) As String

    'Set the lateset data of 'Data' to lpszarrData.
    Array.Copy(txt_Data.Lines, szarrData, txt_Data.Lines.Length)

    'Add the content of new event to lpszarrData
    szarrData(txt_Data.Lines.Length) _
    = String.Format("OnDeviceStatus event by ActUtlType [{0}={1}]", e.szDevice, e.lData)

    'The new 'Data' is displayed.
    txt_Data.Lines = szarrData

    'The return code of the method is displayed by the hexadecimal.
    Text_ReturnCode.Text = String.Format("0x{0:x8} [HEX]", e.lReturnCode)

  End Sub
  '雷射測高歸零
  Private Sub Btn_LaserReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_LaserReset.Click
    Dim MyBtn As Button = sender
    MyBtn.Enabled = False : MyBtn.Refresh()
    If Radio_PlcRunning.Checked = True Then
      AxActUtlType_PLC.WriteDeviceRandom2("M3960", 1, 1)
      System.Threading.Thread.Sleep(500)
      AxActUtlType_PLC.WriteDeviceRandom2("M3960", 1, 0)
    Else
      MsgBox("PLC 尚未啟動", MsgBoxStyle.Exclamation, MyBtn.Text)
    End If
    MyBtn.Enabled = True
    'MsgBox(Asc("+"))
  End Sub
  'Search2→'[載入圖片]鈕
  Private Sub BtnSearch2_ImageLoad_CCD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch2_ImageLoad_CCD1.Click, BtnSearch2_ImageLoad_CCD2.Click, BtnSearch2_ImageLoad_CCD3.Click, BtnSearch2_ImageLoad_CCD4.Click
    Dim MyBtn As Button = sender
    OpenFileDialog_LoadImage.Filter = "圖檔類型 (*.PNG;*.BMP;*.JPG;*.TIF)|*.PNG;*.BMP;*.JPG;*.TIF"
    If OpenFileDialog_LoadImage.ShowDialog() = Windows.Forms.DialogResult.OK Then
      LabSearch2_Result_CCD(MyBtn.Tag).BackColor = Color.White
      SetImage(ClassIntPtr(MyBtn.Tag), OpenFileDialog_LoadImage.FileName)
    End If
  End Sub
  'Search2→'[量測]鈕
  Private Sub BtnSearch2_Measure_CCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch2_Measure_CCD1.Click, BtnSearch2_Measure_CCD2.Click, BtnSearch2_Measure_CCD3.Click, BtnSearch2_Measure_CCD4.Click
    Dim MyBtn As Button = sender
    Dim MySearchResult As Boolean

    LabSearch2_Result_CCD(MyBtn.Tag).BackColor = Color.White
    Application.DoEvents()
    MySearchResult = Measure(ClassIntPtr(Val(MyBtn.Tag)), Val(TextSearch2_ContinueCount.Text), Val(TextSearch2_NonContinueCount.Text), CDbl(TextSearch2_Gain.Text), CDbl(TextSearch2_Offset.Text))
    LabSearch2_Result_CCD(MyBtn.Tag).BackColor = IIf(MySearchResult = True, Color.Lime, Color.Red)
  End Sub
  'Search2→'[載入參數]鈕
  Private Sub BtnSearch2_SetParameter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch2_SetParameter.Click
    For i As Integer = 1 To 4
      SetParameter(ClassIntPtr(i), 1215.0F, 1040.0F, CSng(TextSearch2_MeasureWidth.Text), CSng(TextSearch2_CircleDiameter.Text), Val(TextSearch2_Inward.Text), 2, 1, Val(TextSearch2_Threshold.Text), 360, UpDownSearch2_Score.Value)
    Next
  End Sub
  Private Sub UpDownSearch2_Score_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownSearch2_Score.ValueChanged
    If Me.Created = False Then Exit Sub
    For i As Integer = 1 To 4
      SetParameter(ClassIntPtr(i), 1224.0F, 1024.0F, CSng(TextSearch2_MeasureWidth.Text), CSng(TextSearch2_CircleDiameter.Text), Val(TextSearch2_Inward.Text), 2, 1, Val(TextSearch2_Threshold.Text), 360, UpDownSearch2_Score.Value)
    Next
  End Sub
  '取得目前日期及時間
  Private Sub TextOpInf_DateTime_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextOpInf_DateTime.Enter
    TextOpInf_DateTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
  End Sub
  '按下 Enter 鍵
  Private Sub TextOpInf_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextOpInf_UserNo.KeyDown, TextOpInf_MachineCode.KeyDown, TextOpInf_ProductNumber.KeyDown, TextOpInf_PackNumber.KeyDown, TextOpInf_OunchNeedleNumberUp.KeyDown, TextOpInf_OunchNeedleNumberDown.KeyDown, TextOpInf_NotNumber.KeyDown, TextOpInf_MouldNumber.KeyDown
    Dim MyText As TextBox = sender
    If e.KeyCode = Keys.Enter Then
      e.SuppressKeyPress = True '防止系統發出"叮咚"聲
      If MyText.Name = "TextOpInf_PackNumber" Then
        BtnTool_Start.Focus()
      Else
        Me.SelectNextControl(CType(sender, Control), True, True, True, True)
      End If
    End If
  End Sub
  '游標位於該 TextBox 時
  Private Sub TextOpInf_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextOpInf_UserNo.Enter, TextOpInf_MachineCode.Enter, TextOpInf_ProductNumber.Enter, TextOpInf_PackNumber.Enter, TextOpInf_OunchNeedleNumberUp.Enter, TextOpInf_OunchNeedleNumberDown.Enter, TextOpInf_NotNumber.Enter, TextOpInf_MouldNumber.Enter, TextRun_Barcode_Reader.Enter
    Dim MyText As TextBox = sender
    MyText.BackColor = Color.Khaki
  End Sub
  '游標離開該 TextBox 時
  Private Sub TextOpInf_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextOpInf_UserNo.Leave, TextOpInf_MachineCode.Leave, TextOpInf_ProductNumber.Leave, TextOpInf_PackNumber.Leave, TextOpInf_OunchNeedleNumberUp.Leave, TextOpInf_OunchNeedleNumberDown.Leave, TextOpInf_NotNumber.Leave, TextOpInf_MouldNumber.Leave, TextRun_Barcode_Reader.Leave
    Dim MyText As TextBox = sender
    TextOpInf_DateTime.Text = Format(Now, "yyyy/MM/dd HH:mm:ss")
    MyText.BackColor = Color.White
  End Sub
  '載入檢測資料
  Private Sub BtnRun_LoadResultFile_LoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun_LoadResultFile.Click
    If OpenFileDialog_SendData.FileName <> "" Then
      Dim MyString_Par As String = ""
      'Dim MyString_Split() As String

      Try
        If File.Exists(ProgramPath & "\LastProgram.txt") = True Then
          FileOpen(1, ProgramPath & "\LastProgram.txt", OpenMode.Input)
          Do Until EOF(1)
            MyString_Par = LineInput(1)
          Loop
          FileClose(1)
        End If
      Catch ex As Exception : End Try

      If MyString_Par <> "" Then
        Call LoadProductParFormFile(MyString_Par)
      End If
    End If
  End Sub
  '檢測資料上傳
  Private Sub BtnRun_SendData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRun_SendData.Click
    ' 解析條碼
    'ProcessCode = "8120"              '建議設為常數 / 不會變動 / WebApi判斷用
    'UserNo = tbxUserNo.Text.Trim()
    'MachineCode = tbxMachineCode.Text.Trim()
    'BarCode = tbxBarCode.Text.Trim()
    Dim output As String = ""

    Try
      LabRunningMsg.Text = "解析條碼中..." : LabRunningMsg.Refresh()
      Me.UseWaitCursor = True : Me.Refresh()
      p.StartInfo.FileName = PsaKitPath
      TextRun_Barcode_Reader.Text = "AMBPF2008A17X     8A1N001399 97.20"
      p.StartInfo.Arguments = "{""TOKENID"":""223"",""FUNCTION"":""GetWipAuthOnEqpt"",""COMMAND"":{""ProcessCode"":""8120"",""UserNo"":""" & TextOpInf_UserNo.Text & """,""MachineCode"":""" & TextOpInf_MachineCode.Text & """,""BarCode"":""" & TextRun_Barcode_Reader.Text & """}}"
      p.StartInfo.RedirectStandardOutput = True
      p.StartInfo.UseShellExecute = False
      p.StartInfo.CreateNoWindow = True
      p.Start()

      output = p.StandardOutput.ReadToEnd()
      p.WaitForExit()
    Catch ex As Exception

    End Try

    LabRunningMsg.Text = "解析條碼完成"
    Me.UseWaitCursor = False
    MessageBox.Show("外部程式輸出：" & output)
    ' 解析條碼 Eof

    p.StartInfo.FileName = PsaKitPath
    p.StartInfo.Arguments = "{""TOKENID"":""223"",""FUNCTION"":""RecordFile"",""COMMAND"":{""EqptName"":""" & TextOpInf_MachineCode.Text & """,""EqptVendor"":""GZVISION"",""FileFormat"":""8121,HolePitch,Record,251101"",""FileName"":""" & LabSendData_FileName.Text & """,""FilePath"":""D:\\Program\\HoleDetection_20251210_SendData\\bin\\Debug\\Search Data"",""MD5Code"":""""}}"
    p.StartInfo.RedirectStandardOutput = True
    p.StartInfo.UseShellExecute = False
    p.StartInfo.CreateNoWindow = True

    Try
      LabRunningMsg.Text = "資料上拋中..." : LabRunningMsg.Refresh()
      Me.UseWaitCursor = True : Me.Refresh()
      p.Start()

      output = p.StandardOutput.ReadToEnd()
      p.WaitForExit()

      LabRunningMsg.Text = "資料上拋完成"
      Me.UseWaitCursor = False
      MessageBox.Show("外部程式輸出：" & output)
    Catch ex As Exception
      MessageBox.Show(ex.Message, "上拋檔案")
    End Try

    ' 上拋檔案 Eof
  End Sub

  Private Sub TextRun_Barcode_Reader_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextRun_Barcode_Reader.KeyDown
    If e.KeyCode = 13 Then
      Dim MyStr_Step As String = ""
      Dim MyStr_Lot As String = ""
      Dim MyStr_Product As String = ""
      Dim MyProductStartPos As Integer = 0

      'TextRun_Barcode_Reader.Text = "AMBPF2008A17X     8A1N001399 97.20"
      '批號條碼
      For i = 1 To TextRun_Barcode_Reader.Text.Length
        MyStr_Step = Strings.Mid(TextRun_Barcode_Reader.Text, i, 1)
        If MyStr_Step <> " " Then
          MyStr_Lot = MyStr_Lot & MyStr_Step
        Else
          MyProductStartPos = i + 1
          Exit For
        End If
      Next
      '料號條碼起始位置
      For i = MyProductStartPos To TextRun_Barcode_Reader.Text.Length
        MyStr_Step = Strings.Mid(TextRun_Barcode_Reader.Text, i, 1)
        If MyStr_Step <> " " Then
          MyProductStartPos = i
          Exit For
        End If
      Next
      '料號條碼
      For i = MyProductStartPos To TextRun_Barcode_Reader.Text.Length
        MyStr_Step = Strings.Mid(TextRun_Barcode_Reader.Text, i, 1)
        If MyStr_Step <> " " Then
          MyStr_Product = MyStr_Product & MyStr_Step
        Else
          Exit For
        End If
      Next

      TextOpInf_NotNumber.Text = MyStr_Product
      TextOpInf_ProductNumber.Text = MyStr_Lot

      'If MyStr_Lot.Length <> 10 Then
      '  MsgBox("批號碼數錯誤", MsgBoxStyle.Exclamation, "條碼輸入")
      '  TextRun_Barcode_Reader.Text = ""
      'Else
      '  TextOpInf_NotNumber.Text = MyStr_Product
      'End If
      'If MyStr_Product.Length <> 10 Then
      '  MsgBox("料號碼數錯誤", MsgBoxStyle.Exclamation, "條碼輸入")
      '  TextRun_Barcode_Reader.Text = ""
      'Else
      '  TextOpInf_ProductNumber.Text = MyStr_Lot
      'End If
    End If
  End Sub
  '作業視窗→清除鈕
  Private Sub BtnOpInf_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpInf_Clear.Click
    If MsgBox("是否清除所有作業資訊", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "清除") = MsgBoxResult.Yes Then
      TextOpInf_UserNo.Text = ""
      TextOpInf_ProductNumber.Text = ""
      TextOpInf_NotNumber.Text = ""
      TextOpInf_MachineCode.Text = ""
      TextOpInf_MouldNumber.Text = ""
      TextOpInf_OunchNeedleNumberUp.Text = ""
      TextOpInf_OunchNeedleNumberDown.Text = ""
      TextOpInf_PackNumber.Text = ""
    End If
  End Sub
End Class

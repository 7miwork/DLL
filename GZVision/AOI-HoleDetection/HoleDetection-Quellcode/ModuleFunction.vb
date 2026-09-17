Imports System.IO
Imports System.IO.Ports

Module ModuleFunction
  '系統參數 ----------------------------------------------------------------------------------------------------------------------------------------------------
  Public ProgramPath As String = Application.StartupPath             '主程式所在路徑
  Public ProgramVer As String                                        '程式目前版本
  Public MachineParPath As String                                    '機械參數擋路徑含檔名
  Public SaveAs_FileName As String                                   '存放[另存產品檔]之檔名
  Public LoadingFile As Boolean                                      '是否正在執行載入產品
  Public NgImagePath As String = ProgramPath & "\NG Image"           '存放 NG 圖之路徑
  Public SourceImagePath As String = ProgramPath & "\Source Image"   '存放原始圖之路徑
  Public SearchDataPathRoot As String = ProgramPath & "\Search Data" '存放檢測資料之根路徑
  Public PlcThreadStopKey As Boolean = False

  'CCD參數
  Public Const CcdDpiX As Integer = 2448
  Public Const CcdDpiY As Integer = 2048
  Public ImageViewer_CCD(4) As ImageViewer

  '燈光參數
  Public RS232_Light As SerialPort
  Public LightControl(8) As Byte
  Public LightValueBefore1, LightValueBefore2, LightValueBefore3, LightValueBefore4 As Integer '存放調整前之燈光值
  Public LightSetName As String                                                                '調整哪一參數之燈光(如：檢測、校正片)
  Public TextLight1, TextLight2, TextLight3, TextLight4 As TextBox                             '指向目前調整燈光之輸入框
  Public TextTeach_Search_Light(4) As TextBox                                                  '指向檢測燈光

  'Barcode Reader 參數
  Public RS232_Barcode As SerialPort

  'PLC參數
  Public oL1000 As Integer = 1 '馬達前極限 L1000
  Public oL1001 As Integer = 1 '馬達後極限 L1001
  Public oL1002 As Integer = 1 '伺服馬達異常 L1002
  Public oL1003 As Integer = 1 '伺服驅動器異常 L1003
  Public oL1004 As Integer = 1 '真空異常 L1004
  Public oL1005 As Integer = 1 '門檢1 L1005
  Public oL1006 As Integer = 1 '門檢2 L1006
  Public oL1007 As Integer = 1 '門檢3 L1007
  Public oL1008 As Integer = 1 'SP L1008
  Public oL1009 As Integer = 1 '掃描器逾時 L1009
  Public oL1010 As Integer = 1 'CCD逾時 L1010
  Public Y6B As Integer = 1    '啟動燈
  Public X2E As Integer = 1    '警報停止鈕

  '產品參數
  Public TextTeach_Diameter_CCD(4) As TextBox             '孔徑
  Public TextTeach_DiameterTolerance_CCD(4) As TextBox    '孔徑公差
  Public TextTeach_DefectLength_Inside_CCD(4) As TextBox  '缺點長度(圓內)
  Public TextTeach_DefectLength_Outside_CCD(4) As TextBox '缺點長度(圓外)
  Public TextTeach_TrueCircle_CCD(4) As TextBox           '真圓度

  '距離校正參數
  Public TextAdv_Calib_Light(4) As TextBox               '指向校正燈光
  Public RadioAdv_Pixel_CCD(4) As RadioButton            '點選哪一顆CCD (Pixel校正)
  'Public CheckAdv_Calib_CCD(4) As CheckBox               '勾選哪一顆CCD (距離校正)
  Public Calib_ImageAdjust_CCD(4) As VisionImage         'CCD 影像處理圖(陣列)
  Public Calib_ImageAdjust_CCD1 As New VisionImage       'CCD1 影像處理圖
  Public Calib_ImageAdjust_CCD2 As New VisionImage       'CCD2 影像處理圖
  Public Calib_ImageAdjust_CCD3 As New VisionImage       'CCD3 影像處理圖
  Public Calib_ImageAdjust_CCD4 As New VisionImage       'CCD4 影像處理圖
  Public Calib_Coefficients_RemoveParticle() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1}
  Public Calib_StructElem_RemoveParticle As New StructuringElement(3, 3, Calib_Coefficients_RemoveParticle)
  Public Calib_Coefficients_GradientIn() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
  Public Calib_StructElem_GradientIn As New StructuringElement(7, 7, Calib_Coefficients_GradientIn)
  Public Calib_PixelMeasurements(4) As Collection(Of MeasurementType)
  'Public Calib_ParticleReport(4) As ParticleMeasurementsReport
  Public Calib_MaskToRoiReport As MaskToRoiReport

  '雷射測高參數
  Public LaserHeight As Double = 9999

  'Pixel校正參數
  Public TextAdv_Pixel_CCD(4) As TextBox                        'Pixel校正值
  Public LabAdv_FovX_CCD(4), LabAdv_FovY_CCD(4) As Label        'FOV
  Public ImageCalibPixel As New VisionImage
  Public Calib_Pixel_LookupTable As New Collection(Of Short)()

  'I/O 參數
  Public DI1_X(16), DO1_Y(16) As Boolean '存放 I/O 目前狀態之陣列
  Public LabDi(16) As Label
  Public CheckDo(16) As CheckBox

  'Login 參數
  Public PasswordFile As String = ProgramPath & "\Bfpas.dll"
  Public PasswordData(3) As String '1→存放作業員密碼 , 2→存放工程師密碼 , 1→存放系統管理員密碼
  Public LevelName() As String = {"", "[作業員]", "[工程師]", "[系統管理員]"}
  Structure LoginData
    Dim BadgeNumber As String
    Dim Password As String
    Dim Level As String
  End Structure
  Public LevelPath As String = ProgramPath & "\Level.dll"
  Public LoginDatas(10000) As LoginData
  Public Data_Count As Integer

  '執行參數 -----------------------------------------------------------------------------------------------------------------------------------------------
  Public StartKey As Boolean                                        '是否為執行狀態
  Public RunIndex_Main As Integer = 1                               '執行到第幾個步驟
  Public ImageAdjust_CCD(4) As VisionImage                          '檢測影像處理圖
  Public ImageAdjustBeforeHull_CCD(4) As VisionImage                '檢測影像處理圖(仿真填滿前)
  Public ImageAdjustHull_CCD(4) As VisionImage                      '檢測影像處理圖(仿真填滿後)
  Public ImageAdjustMask As New VisionImage
  Public ImageAdjust_DefectOut(4) As VisionImage                   '檢測影像處理圖(圓以外之缺點)
  Public FillValue_Outside As New PixelValue(255)
  Public PixelMeasurements_CCD(4) As Collection(Of MeasurementType) 'Particle 分析
  Public MaskToRoiReport_CCD(4) As MaskToRoiReport                  'Particle 輪廓
  Public Searching As Boolean                                       '是否正在檢測中

  '作業視窗 -----------------------------------------------------------------------------------------------------------------------------------------------
  Public LabRun_Msg_CCD(4) As Label                '動作訊息
  Public LabRun_Diameter_CCD(4) As Label           '孔徑
  Public LabRun_Defect_TrueCircle_CCD(4) As Label  '真圓度
  'Public LabRun_Defect_Area_CCD(4) As Label        '瑕疵面積值


  Public Function CRC_CODE(ByVal Lengh As Integer, ByRef DATA() As Byte)
    Dim CRCHi_Struct() As Byte = {&H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, _
                                 &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, _
                                 &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, _
                                 &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, _
                                 &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, _
                                 &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, _
                                 &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, _
                                 &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, _
                                 &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, _
                                 &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, _
                                 &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, _
                                 &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, _
                                 &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, _
                                 &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H1, &HC0, _
                                 &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, _
                                 &HC0, &H80, &H41, &H0, &HC1, &H81, &H40, &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, _
                                 &H0, &HC1, &H81, &H40, &H1, &HC0, &H80, &H41, &H1, &HC0, &H80, &H41, &H0, &HC1, &H81, _
                                 &H40}
    Dim CRCLo_Struct() As Byte = {&H0, &HC0, &HC1, &H1, &HC3, &H3, &H2, &HC2, &HC6, &H6, &H7, &HC7, &H5, &HC5, &HC4, _
                                 &H4, &HCC, &HC, &HD, &HCD, &HF, &HCF, &HCE, &HE, &HA, &HCA, &HCB, &HB, &HC9, &H9, _
                                 &H8, &HC8, &HD8, &H18, &H19, &HD9, &H1B, &HDB, &HDA, &H1A, &H1E, &HDE, &HDF, &H1F, &HDD, _
                                 &H1D, &H1C, &HDC, &H14, &HD4, &HD5, &H15, &HD7, &H17, &H16, &HD6, &HD2, &H12, &H13, &HD3, _
                                 &H11, &HD1, &HD0, &H10, &HF0, &H30, &H31, &HF1, &H33, &HF3, &HF2, &H32, &H36, &HF6, &HF7, _
                                 &H37, &HF5, &H35, &H34, &HF4, &H3C, &HFC, &HFD, &H3D, &HFF, &H3F, &H3E, &HFE, &HFA, &H3A, _
                                 &H3B, &HFB, &H39, &HF9, &HF8, &H38, &H28, &HE8, &HE9, &H29, &HEB, &H2B, &H2A, &HEA, &HEE, _
                                 &H2E, &H2F, &HEF, &H2D, &HED, &HEC, &H2C, &HE4, &H24, &H25, &HE5, &H27, &HE7, &HE6, &H26, _
                                 &H22, &HE2, &HE3, &H23, &HE1, &H21, &H20, &HE0, &HA0, &H60, &H61, &HA1, &H63, &HA3, &HA2, _
                                 &H62, &H66, &HA6, &HA7, &H67, &HA5, &H65, &H64, &HA4, &H6C, &HAC, &HAD, &H6D, &HAF, &H6F, _
                                 &H6E, &HAE, &HAA, &H6A, &H6B, &HAB, &H69, &HA9, &HA8, &H68, &H78, &HB8, &HB9, &H79, &HBB, _
                                 &H7B, &H7A, &HBA, &HBE, &H7E, &H7F, &HBF, &H7D, &HBD, &HBC, &H7C, &HB4, &H74, &H75, &HB5, _
                                 &H77, &HB7, &HB6, &H76, &H72, &HB2, &HB3, &H73, &HB1, &H71, &H70, &HB0, &H50, &H90, &H91, _
                                 &H51, &H93, &H53, &H52, &H92, &H96, &H56, &H57, &H97, &H55, &H95, &H94, &H54, &H9C, &H5C, _
                                 &H5D, &H9D, &H5F, &H9F, &H9E, &H5E, &H5A, &H9A, &H9B, &H5B, &H99, &H59, &H58, &H98, &H88, _
                                 &H48, &H49, &H89, &H4B, &H8B, &H8A, &H4A, &H4E, &H8E, &H8F, &H4F, &H8D, &H4D, &H4C, &H8C, _
                                 &H44, &H84, &H85, &H45, &H87, &H47, &H46, &H86, &H82, &H42, &H43, &H83, &H41, &H81, &H80, _
                                 &H40}

    Dim CRCHi As Byte = &HFF '創建一個CRC計算值
    Dim CRCLo As Byte = &HFF '創建一個CRC計算值
    Dim math_a As Integer '創建一個計算值
    Dim Answer As Integer '創建一個答案計算值
    Dim index As Integer '創建一個陣列的指標
    Lengh -= 1 '將使用者傳送過來的Lengh減1
    For math_a = 0 To Lengh Step 1 '設定一個迴圈，這個迴圈重複次數為 Lengh
      index = CRCLo Xor DATA(math_a) '將CRCHi跟被指定到的DATA陣列的值 做互斥或運算，得到一個指標
      CRCLo = CRCHi Xor CRCHi_Struct(index) 'CRCHi= 把CRCLo跟被指定到的CRCHi_Struct陣列的值做互斥或
      CRCHi = CRCLo_Struct(index) 'CRCLo=被指定到的CRCLo_Struct陣列的值
    Next '重複迴圈
    Answer = CRCLo '將CRCLo跟CRCHi資料合併成為16bit的資料
    Answer = (Answer << 8) Or CRCHi
    Return Answer
  End Function
  '載入 Login 資料至陣列
  Public Function TxtToArray() As Boolean
    Dim MyData_Line As String     '讀取一列
    Dim MyData_Split() As String  '分割
    'Dim MyData_Count As Integer   '筆數

    Try
      If File.Exists(LevelPath) = False Then
        FileOpen(1, LevelPath, OpenMode.Append)
        FileClose(1)
      End If
      FileOpen(1, LevelPath, OpenMode.Input)
      Data_Count = 0

      Do Until EOF(1)
        'MyData_Count += 1
        Data_Count += 1
        MyData_Line = LineInput(1)
        MyData_Split = Split(MyData_Line, ",")

        LoginDatas(Data_Count).BadgeNumber = MyData_Split(0)
        LoginDatas(Data_Count).Password = MyData_Split(1)
        LoginDatas(Data_Count).Level = MyData_Split(2)
      Loop
    Catch ex As Exception : End Try

    FileClose(1)

  End Function
  Public Sub TurnOnLight(ByVal MyLight1 As Byte, ByVal MyLight2 As Byte, ByVal MyLight3 As Byte, ByVal MyLight4 As Byte)
    Dim MyLightValue(4) As Byte
    MyLightValue(1) = MyLight1 : MyLightValue(2) = MyLight2 : MyLightValue(3) = MyLight3 : MyLightValue(4) = MyLight4
    For i As Integer = 1 To 4
      LightControl(2) = CByte(16 * i)
      LightControl(5) = MyLightValue(i)
      Dim MyValue As Integer = CRC_CODE(6, LightControl)
      LightControl(6) = Convert.ToInt32(Strings.Mid(Hex(MyValue).ToString, 1, 2), 16)
      LightControl(7) = Convert.ToInt32(Strings.Mid(Hex(MyValue).ToString, 3, 2), 16)
      RS232_Light.Write(LightControl, 0, 8)
      Threading.Thread.Sleep(20)
    Next
  End Sub
  Public Function GetIntValue(ByVal txt_SourceOfIntValue As TextBox, ByRef iGottenIntValue As Integer) As Boolean

    'Get the value as 32bit integer from TextBox
    Try
      iGottenIntValue = Convert.ToInt32(txt_SourceOfIntValue.Text)

    Catch exExcepion As Exception
      'When the value is nothing or out of the range, the exception is processed.
      MessageBox.Show(exExcepion.Message, "Get Int Value Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End Try

    Return True

  End Function
End Module

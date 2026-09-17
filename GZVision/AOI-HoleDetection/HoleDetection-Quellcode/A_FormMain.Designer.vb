<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_FormMain
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(A_FormMain))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.GroupTools = New System.Windows.Forms.GroupBox
    Me.AxActUtlType_PLC = New AxActUtlTypeLib.AxActUtlType
    Me.BtnTool_AlarmReset = New System.Windows.Forms.Button
    Me.BtnTool_Home = New System.Windows.Forms.Button
    Me.CheckTool_CcdLive = New System.Windows.Forms.CheckBox
    Me.BtnTool_ReadBarcode = New System.Windows.Forms.Button
    Me.PictureLogo = New System.Windows.Forms.PictureBox
    Me.BtnTool_Search = New System.Windows.Forms.Button
    Me.GroupOption = New System.Windows.Forms.GroupBox
    Me.CheckOption_DrawCross = New System.Windows.Forms.CheckBox
    Me.BtnTool_Exit = New System.Windows.Forms.Button
    Me.LabLevel = New System.Windows.Forms.Label
    Me.BtnTool_Log = New System.Windows.Forms.Button
    Me.BtnTool_IO = New System.Windows.Forms.Button
    Me.BtnTool_FileDelete = New System.Windows.Forms.Button
    Me.BtnTool_FileSaveAs = New System.Windows.Forms.Button
    Me.BtnTool_FileSave = New System.Windows.Forms.Button
    Me.LabFileName = New System.Windows.Forms.Label
    Me.BtnTool_FileLoad = New System.Windows.Forms.Button
    Me.BtnTool_Login = New System.Windows.Forms.Button
    Me.Label37 = New System.Windows.Forms.Label
    Me.BtnTool_Start = New System.Windows.Forms.Button
    Me.BtnTool_Stop = New System.Windows.Forms.Button
    Me.Label54 = New System.Windows.Forms.Label
    Me.LabProgramInfo = New System.Windows.Forms.Label
    Me.OpenFileDialog_LoadImage = New System.Windows.Forms.OpenFileDialog
    Me.SaveFileDialog_SaveImage = New System.Windows.Forms.SaveFileDialog
    Me.InstantCtrl_DI = New Automation.BDaq.InstantDiCtrl(Me.components)
    Me.TimerDIO = New System.Windows.Forms.Timer(Me.components)
    Me.TabPage_IO = New System.Windows.Forms.TabPage
    Me.Panel_IO = New System.Windows.Forms.Panel
    Me.GroupIO_PLC = New System.Windows.Forms.GroupBox
    Me.TabControlPLC = New System.Windows.Forms.TabControl
    Me.TabPage1 = New System.Windows.Forms.TabPage
    Me.GroupBox5 = New System.Windows.Forms.GroupBox
    Me.Label66 = New System.Windows.Forms.Label
    Me.Label67 = New System.Windows.Forms.Label
    Me.Lab_BarcodeResult_M1408 = New System.Windows.Forms.Label
    Me.Text_SearchCount_D3000 = New System.Windows.Forms.TextBox
    Me.Label68 = New System.Windows.Forms.Label
    Me.D100 = New System.Windows.Forms.Label
    Me.Btn_ClearSearchCount_M1820 = New System.Windows.Forms.Button
    Me.Lab_SearchResult_M1400 = New System.Windows.Forms.Label
    Me.Label69 = New System.Windows.Forms.Label
    Me.Lab_CycleTime_D3002 = New System.Windows.Forms.TextBox
    Me.GroupBox4 = New System.Windows.Forms.GroupBox
    Me.Btn_LaserReset = New System.Windows.Forms.Button
    Me.Lab_Vacuum_X2B = New System.Windows.Forms.Label
    Me.Label70 = New System.Windows.Forms.Label
    Me.Lab_Search_M1601 = New System.Windows.Forms.Label
    Me.Label71 = New System.Windows.Forms.Label
    Me.Label72 = New System.Windows.Forms.Label
    Me.Text_LaserHeight_D950 = New System.Windows.Forms.TextBox
    Me.Lab_Barcode_M1600 = New System.Windows.Forms.Label
    Me.Label73 = New System.Windows.Forms.Label
    Me.Label74 = New System.Windows.Forms.Label
    Me.Label75 = New System.Windows.Forms.Label
    Me.Lab_Standby_M1602 = New System.Windows.Forms.Label
    Me.GroupBox3 = New System.Windows.Forms.GroupBox
    Me.Label76 = New System.Windows.Forms.Label
    Me.Lab_PlcReady_SM403 = New System.Windows.Forms.Label
    Me.Label77 = New System.Windows.Forms.Label
    Me.Label78 = New System.Windows.Forms.Label
    Me.Lab_AoiReady_X33 = New System.Windows.Forms.Label
    Me.Lab_HomeFinish_M1001 = New System.Windows.Forms.Label
    Me.Label79 = New System.Windows.Forms.Label
    Me.Label80 = New System.Windows.Forms.Label
    Me.M1602_1 = New System.Windows.Forms.Label
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.Label81 = New System.Windows.Forms.Label
    Me.Label82 = New System.Windows.Forms.Label
    Me.Btn_AlarmReset_M1300 = New System.Windows.Forms.Button
    Me.Label83 = New System.Windows.Forms.Label
    Me.L1012 = New System.Windows.Forms.Label
    Me.Lab_LimitFront_L1001 = New System.Windows.Forms.Label
    Me.Label84 = New System.Windows.Forms.Label
    Me.Lab_LimitBack_L1000 = New System.Windows.Forms.Label
    Me.Label85 = New System.Windows.Forms.Label
    Me.Lab_ServoError_L1002 = New System.Windows.Forms.Label
    Me.Label86 = New System.Windows.Forms.Label
    Me.Lab_DriverError_L1003 = New System.Windows.Forms.Label
    Me.Label87 = New System.Windows.Forms.Label
    Me.Lab_VacuumError_L1004 = New System.Windows.Forms.Label
    Me.Label88 = New System.Windows.Forms.Label
    Me.Lab_SafeDoor1_L1005 = New System.Windows.Forms.Label
    Me.Label89 = New System.Windows.Forms.Label
    Me.Lab_SafeDoor2_L1006 = New System.Windows.Forms.Label
    Me.Label90 = New System.Windows.Forms.Label
    Me.Lab_SafeDoor3_L1007 = New System.Windows.Forms.Label
    Me.Label91 = New System.Windows.Forms.Label
    Me.L1008 = New System.Windows.Forms.Label
    Me.Label92 = New System.Windows.Forms.Label
    Me.Lab_BarcodeTimeout_L1009 = New System.Windows.Forms.Label
    Me.Label93 = New System.Windows.Forms.Label
    Me.Lab_CcdTimeout_L1010 = New System.Windows.Forms.Label
    Me.Label94 = New System.Windows.Forms.Label
    Me.L1011 = New System.Windows.Forms.Label
    Me.TabPage2 = New System.Windows.Forms.TabPage
    Me.GroupBox16 = New System.Windows.Forms.GroupBox
    Me.Text_StandbyPosition_D1120 = New System.Windows.Forms.TextBox
    Me.Label95 = New System.Windows.Forms.Label
    Me.Lab_Standby_M1602_2 = New System.Windows.Forms.Label
    Me.Btn_StandbyPositionMove_M1154 = New System.Windows.Forms.Button
    Me.Btn_StandbyPositionSet_M1202 = New System.Windows.Forms.Button
    Me.GroupBox15 = New System.Windows.Forms.GroupBox
    Me.Label96 = New System.Windows.Forms.Label
    Me.Lab_Barcode_M1600_2 = New System.Windows.Forms.Label
    Me.Btn_BarcodePositionMove_M1152 = New System.Windows.Forms.Button
    Me.Btn_BarcodePositionSet_M1200 = New System.Windows.Forms.Button
    Me.Text_BarcodePosition_D1100 = New System.Windows.Forms.TextBox
    Me.GroupBox14 = New System.Windows.Forms.GroupBox
    Me.Lab_HomeFinish_M1002 = New System.Windows.Forms.Label
    Me.Label97 = New System.Windows.Forms.Label
    Me.Btn_Home_M1000 = New System.Windows.Forms.Button
    Me.GroupBox13 = New System.Windows.Forms.GroupBox
    Me.Label98 = New System.Windows.Forms.Label
    Me.Text_NowPosition_D1090 = New System.Windows.Forms.TextBox
    Me.GroupVacuum = New System.Windows.Forms.GroupBox
    Me.Label100 = New System.Windows.Forms.Label
    Me.Lab_Vacuum_X2B_2 = New System.Windows.Forms.Label
    Me.Btn_VacuumOnOff_M1912 = New System.Windows.Forms.Button
    Me.GroupBox11 = New System.Windows.Forms.GroupBox
    Me.Lab_MoveSpeed_D1030 = New System.Windows.Forms.TextBox
    Me.Label101 = New System.Windows.Forms.Label
    Me.Lab_MoveSpeedSet_D1030 = New System.Windows.Forms.TextBox
    Me.Label102 = New System.Windows.Forms.Label
    Me.Btn_MoveSpeedSet_D1030 = New System.Windows.Forms.Button
    Me.GroupBox10 = New System.Windows.Forms.GroupBox
    Me.Label103 = New System.Windows.Forms.Label
    Me.Text_TriggerDelay_D3010 = New System.Windows.Forms.TextBox
    Me.Text_TriggerDelaySet_D3010 = New System.Windows.Forms.TextBox
    Me.Label104 = New System.Windows.Forms.Label
    Me.Btn_TriggerDelaySet_D3010 = New System.Windows.Forms.Button
    Me.GroupBox9 = New System.Windows.Forms.GroupBox
    Me.Label105 = New System.Windows.Forms.Label
    Me.Lab_Search__M1601_2 = New System.Windows.Forms.Label
    Me.Btn_SearchPositionMove_M1153 = New System.Windows.Forms.Button
    Me.Btn_SearchPositionSet_M1201 = New System.Windows.Forms.Button
    Me.Text_SearchPosition_D1110 = New System.Windows.Forms.TextBox
    Me.GroupBox8 = New System.Windows.Forms.GroupBox
    Me.Label106 = New System.Windows.Forms.Label
    Me.Label107 = New System.Windows.Forms.Label
    Me.Lab_SearchResult_M1408_2 = New System.Windows.Forms.Label
    Me.Btn_ReaderTrigger_M1900 = New System.Windows.Forms.Button
    Me.GroupBox7 = New System.Windows.Forms.GroupBox
    Me.Lab_SearchResult_M1400_2 = New System.Windows.Forms.Label
    Me.Label108 = New System.Windows.Forms.Label
    Me.Btn_CcdTrigger_M1902 = New System.Windows.Forms.Button
    Me.Label109 = New System.Windows.Forms.Label
    Me.GroupBox6 = New System.Windows.Forms.GroupBox
    Me.M1142 = New System.Windows.Forms.Label
    Me.M1141 = New System.Windows.Forms.Label
    Me.M1140 = New System.Windows.Forms.Label
    Me.Label110 = New System.Windows.Forms.Label
    Me.Btn_MoveBack_M1151 = New System.Windows.Forms.Button
    Me.Btn_MoveFront_M1150 = New System.Windows.Forms.Button
    Me.Radio_MoveSpeedC_M1130 = New System.Windows.Forms.RadioButton
    Me.Radio_MoveSpeedC_M1131 = New System.Windows.Forms.RadioButton
    Me.Radio_MoveSpeedC_M1132 = New System.Windows.Forms.RadioButton
    Me.GroupBox12 = New System.Windows.Forms.GroupBox
    Me.M1111 = New System.Windows.Forms.Label
    Me.M1112 = New System.Windows.Forms.Label
    Me.M1110 = New System.Windows.Forms.Label
    Me.Label111 = New System.Windows.Forms.Label
    Me.Btn_MoveBack_M1121 = New System.Windows.Forms.Button
    Me.Btn_MoveFront_M1120 = New System.Windows.Forms.Button
    Me.Radio_MoveSpeedPtp_M1101 = New System.Windows.Forms.RadioButton
    Me.Radio_MoveSpeedPtp_M1102 = New System.Windows.Forms.RadioButton
    Me.Radio_MoveSpeedPtp_M1103 = New System.Windows.Forms.RadioButton
    Me.Label112 = New System.Windows.Forms.Label
    Me.Label113 = New System.Windows.Forms.Label
    Me.LabPlcRunning = New System.Windows.Forms.Label
    Me.txt_Data = New System.Windows.Forms.TextBox
    Me.txt_LogicalStationNumber = New System.Windows.Forms.TextBox
    Me.lbl_LogicalStationNumber = New System.Windows.Forms.Label
    Me.Radio_PlcRunning = New System.Windows.Forms.RadioButton
    Me.Text_ReturnCode = New System.Windows.Forms.TextBox
    Me.BtnClose = New System.Windows.Forms.Button
    Me.BtnOpen = New System.Windows.Forms.Button
    Me.GroupIO_AOI = New System.Windows.Forms.GroupBox
    Me.GroupIO_Input = New System.Windows.Forms.GroupBox
    Me.Label65 = New System.Windows.Forms.Label
    Me.LabDi_X116 = New System.Windows.Forms.Label
    Me.LabDi_X115 = New System.Windows.Forms.Label
    Me.LabDi_X114 = New System.Windows.Forms.Label
    Me.LabDi_X113 = New System.Windows.Forms.Label
    Me.LabDi_X112 = New System.Windows.Forms.Label
    Me.LabDi_X111 = New System.Windows.Forms.Label
    Me.LabDi_X110 = New System.Windows.Forms.Label
    Me.LabDi_X109 = New System.Windows.Forms.Label
    Me.LabDi_X108 = New System.Windows.Forms.Label
    Me.LabDi_X107 = New System.Windows.Forms.Label
    Me.LabDi_X106 = New System.Windows.Forms.Label
    Me.LabDi_X105 = New System.Windows.Forms.Label
    Me.LabDi_X104 = New System.Windows.Forms.Label
    Me.LabDi_X103 = New System.Windows.Forms.Label
    Me.LabDi_X102 = New System.Windows.Forms.Label
    Me.LabDi_X101 = New System.Windows.Forms.Label
    Me.Label13 = New System.Windows.Forms.Label
    Me.GroupIO_Output = New System.Windows.Forms.GroupBox
    Me.CheckDo_Y116 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y115 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y114 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y113 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y112 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y111 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y110 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y109 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y108 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y107 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y105 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y106 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y103 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y104 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y102 = New System.Windows.Forms.CheckBox
    Me.CheckDo_Y101 = New System.Windows.Forms.CheckBox
    Me.LabService_RunIndex = New System.Windows.Forms.Label
    Me.Label49 = New System.Windows.Forms.Label
    Me.TabPage_Parameter = New System.Windows.Forms.TabPage
    Me.PanelParameter = New System.Windows.Forms.Panel
    Me.GroupAdv = New System.Windows.Forms.GroupBox
    Me.GroupAdv_Option = New System.Windows.Forms.GroupBox
    Me.CheckAdv_Option_Barcode = New System.Windows.Forms.CheckBox
    Me.CheckSearch_LeftRight = New System.Windows.Forms.CheckBox
    Me.CheckSearch_UpDown = New System.Windows.Forms.CheckBox
    Me.Label223 = New System.Windows.Forms.Label
    Me.CheckAdv_Option_SaveNgPic = New System.Windows.Forms.CheckBox
    Me.CheckAdv_Option_Search = New System.Windows.Forms.CheckBox
    Me.TextAdv_Option_CaptureDelay = New System.Windows.Forms.TextBox
    Me.Label222 = New System.Windows.Forms.Label
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.CheckAdv_Calib_LeftRight = New System.Windows.Forms.CheckBox
    Me.CheckAdv_Calib_UpDown = New System.Windows.Forms.CheckBox
    Me.GroupAdv_Calib_ImageAdjust = New System.Windows.Forms.GroupBox
    Me.CheckAdv_Calib_RejectBorder = New System.Windows.Forms.CheckBox
    Me.Label21 = New System.Windows.Forms.Label
    Me.TrackBarAdv_Calib_BinaryMax = New System.Windows.Forms.TrackBar
    Me.TextAdv_Calib_BinaryMax = New System.Windows.Forms.TextBox
    Me.UpDownAdv_Calib_Remove = New System.Windows.Forms.NumericUpDown
    Me.TrackBarAdv_Calib_BinaryMin = New System.Windows.Forms.TrackBar
    Me.TextAdv_Calib_BinaryMin = New System.Windows.Forms.TextBox
    Me.Label23 = New System.Windows.Forms.Label
    Me.BtnAdv_Calib_Fill = New System.Windows.Forms.Button
    Me.Label24 = New System.Windows.Forms.Label
    Me.BtnAdv_Calib_RejectBorder = New System.Windows.Forms.Button
    Me.GroupAdv_Calib_Distance = New System.Windows.Forms.GroupBox
    Me.TextAdv_Distance_UpDown_Offset = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.TextAdv_Distance_LeftRight_Offset = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.TextAdv_Angle_UpDown = New System.Windows.Forms.TextBox
    Me.TextAdv_Angle_LeftRight = New System.Windows.Forms.TextBox
    Me.Label52 = New System.Windows.Forms.Label
    Me.Label47 = New System.Windows.Forms.Label
    Me.Label53 = New System.Windows.Forms.Label
    Me.Label50 = New System.Windows.Forms.Label
    Me.TextAdv_CalibTool_DistanceY = New System.Windows.Forms.TextBox
    Me.Label22 = New System.Windows.Forms.Label
    Me.Label25 = New System.Windows.Forms.Label
    Me.TextAdv_CalibTool_DistanceX = New System.Windows.Forms.TextBox
    Me.Label26 = New System.Windows.Forms.Label
    Me.Label27 = New System.Windows.Forms.Label
    Me.TextAdv_Distance_UpDown = New System.Windows.Forms.TextBox
    Me.Label11 = New System.Windows.Forms.Label
    Me.Label12 = New System.Windows.Forms.Label
    Me.BtnAdv_Calib_CcdDistance = New System.Windows.Forms.Button
    Me.TextAdv_Distance_LeftRight = New System.Windows.Forms.TextBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.GroupAdv_Calib_Pixel = New System.Windows.Forms.GroupBox
    Me.RadioAdv_Pixel_CCD4 = New System.Windows.Forms.RadioButton
    Me.RadioAdv_Pixel_CCD3 = New System.Windows.Forms.RadioButton
    Me.RadioAdv_Pixel_CCD2 = New System.Windows.Forms.RadioButton
    Me.RadioAdv_Pixel_CCD1 = New System.Windows.Forms.RadioButton
    Me.LabAdv_FovY_CCD4 = New System.Windows.Forms.Label
    Me.LabAdv_FovX_CCD4 = New System.Windows.Forms.Label
    Me.LabAdv_FovY_CCD3 = New System.Windows.Forms.Label
    Me.LabAdv_FovX_CCD3 = New System.Windows.Forms.Label
    Me.LabAdv_FovY_CCD2 = New System.Windows.Forms.Label
    Me.LabAdv_FovX_CCD2 = New System.Windows.Forms.Label
    Me.TextAdv_Pixel_CCD4 = New System.Windows.Forms.TextBox
    Me.TextAdv_Pixel_CCD3 = New System.Windows.Forms.TextBox
    Me.TextAdv_Pixel_CCD2 = New System.Windows.Forms.TextBox
    Me.LabAdv_FovY_CCD1 = New System.Windows.Forms.Label
    Me.BtnAdv_Calib_Pixel = New System.Windows.Forms.Button
    Me.LabAdv_FovX_CCD1 = New System.Windows.Forms.Label
    Me.Label99 = New System.Windows.Forms.Label
    Me.TextAdv_CircleSize = New System.Windows.Forms.TextBox
    Me.Label28 = New System.Windows.Forms.Label
    Me.TextAdv_Pixel_CCD1 = New System.Windows.Forms.TextBox
    Me.Label45 = New System.Windows.Forms.Label
    Me.Label29 = New System.Windows.Forms.Label
    Me.Label30 = New System.Windows.Forms.Label
    Me.GroupAdv_Calib_Light = New System.Windows.Forms.GroupBox
    Me.BtnAdv_CalibLight_Off = New System.Windows.Forms.Button
    Me.BtnAdv_CalibLight_On = New System.Windows.Forms.Button
    Me.TextAdv_Calib_Light4 = New System.Windows.Forms.TextBox
    Me.TextAdv_Calib_Light3 = New System.Windows.Forms.TextBox
    Me.Label17 = New System.Windows.Forms.Label
    Me.Label18 = New System.Windows.Forms.Label
    Me.Label19 = New System.Windows.Forms.Label
    Me.BtnAdv_CalibLight_Set = New System.Windows.Forms.Button
    Me.TextAdv_Calib_Light2 = New System.Windows.Forms.TextBox
    Me.TextAdv_Calib_Light1 = New System.Windows.Forms.TextBox
    Me.Label20 = New System.Windows.Forms.Label
    Me.GroupProduct = New System.Windows.Forms.GroupBox
    Me.Label115 = New System.Windows.Forms.Label
    Me.PanelProduct_Function1 = New System.Windows.Forms.Panel
    Me.GroupTeach_ImageAdjust_Inside = New System.Windows.Forms.GroupBox
    Me.Label114 = New System.Windows.Forms.Label
    Me.TextSearch2_Offset = New System.Windows.Forms.TextBox
    Me.Label61 = New System.Windows.Forms.Label
    Me.TextSearch2_Gain = New System.Windows.Forms.TextBox
    Me.Label62 = New System.Windows.Forms.Label
    Me.TextSearch2_Inward = New System.Windows.Forms.TextBox
    Me.Label60 = New System.Windows.Forms.Label
    Me.TextSearch2_NonContinueCount = New System.Windows.Forms.TextBox
    Me.Label58 = New System.Windows.Forms.Label
    Me.TextSearch2_ContinueCount = New System.Windows.Forms.TextBox
    Me.Label57 = New System.Windows.Forms.Label
    Me.TextSearch2_Threshold = New System.Windows.Forms.TextBox
    Me.Label56 = New System.Windows.Forms.Label
    Me.TextSearch2_CircleDiameter = New System.Windows.Forms.TextBox
    Me.Label55 = New System.Windows.Forms.Label
    Me.TextSearch2_MeasureWidth = New System.Windows.Forms.TextBox
    Me.UpDownSearch2_Score = New System.Windows.Forms.NumericUpDown
    Me.BtnSearch2_SetParameter = New System.Windows.Forms.Button
    Me.Label137 = New System.Windows.Forms.Label
    Me.GroupTeach_ImageAdjust_Outside = New System.Windows.Forms.GroupBox
    Me.Label8 = New System.Windows.Forms.Label
    Me.BtnTeach_ShowMaskCircle = New System.Windows.Forms.Button
    Me.TextTeach_MaskCircleSize = New System.Windows.Forms.TextBox
    Me.BtnTeach_MaskCircle = New System.Windows.Forms.Button
    Me.Label139 = New System.Windows.Forms.Label
    Me.TextTeach_BinaryDefectOut = New System.Windows.Forms.TextBox
    Me.TrackBarTeach_BinaryDefectOut = New System.Windows.Forms.TrackBar
    Me.TextTeach_BinaryOutside = New System.Windows.Forms.TextBox
    Me.TrackBarTeach_BinaryOutside = New System.Windows.Forms.TrackBar
    Me.GroupTeach_ImageAdjust_Size = New System.Windows.Forms.GroupBox
    Me.BtnTeach_Binary = New System.Windows.Forms.Button
    Me.Label7 = New System.Windows.Forms.Label
    Me.TrackBarTeach_BinaryMax = New System.Windows.Forms.TrackBar
    Me.TextTeach_BinaryMax = New System.Windows.Forms.TextBox
    Me.TrackBarTeach_BinaryMin = New System.Windows.Forms.TrackBar
    Me.TextTeach_BinaryMin = New System.Windows.Forms.TextBox
    Me.BtnTeach_Hull = New System.Windows.Forms.Button
    Me.Label9 = New System.Windows.Forms.Label
    Me.GroupTeacht_Spec = New System.Windows.Forms.GroupBox
    Me.TextTeach_DefectLength_Outside_CCD4 = New System.Windows.Forms.TextBox
    Me.TextTeach_DefectLength_Outside_CCD3 = New System.Windows.Forms.TextBox
    Me.TextTeach_DefectLength_Outside_CCD2 = New System.Windows.Forms.TextBox
    Me.Label116 = New System.Windows.Forms.Label
    Me.TextTeach_DefectLength_Outside_CCD1 = New System.Windows.Forms.TextBox
    Me.TextTeach_Laser_LimitUp = New System.Windows.Forms.TextBox
    Me.TextTeach_Laser_LimitDown = New System.Windows.Forms.TextBox
    Me.TextTeach_TrueCircle_CCD4 = New System.Windows.Forms.TextBox
    Me.TextTeach_TrueCircle_CCD3 = New System.Windows.Forms.TextBox
    Me.TextTeach_TrueCircle_CCD2 = New System.Windows.Forms.TextBox
    Me.Label43 = New System.Windows.Forms.Label
    Me.TextTeach_TrueCircle_CCD1 = New System.Windows.Forms.TextBox
    Me.TextTeach_DefectLength_Inside_CCD4 = New System.Windows.Forms.TextBox
    Me.TextTeach_DefectLength_Inside_CCD3 = New System.Windows.Forms.TextBox
    Me.TextTeach_DefectLength_Inside_CCD2 = New System.Windows.Forms.TextBox
    Me.Label38 = New System.Windows.Forms.Label
    Me.TextTeach_DefectLength_Inside_CCD1 = New System.Windows.Forms.TextBox
    Me.TextTeach_DiameterTolerance_CCD4 = New System.Windows.Forms.TextBox
    Me.TextTeach_Diameter_CCD4 = New System.Windows.Forms.TextBox
    Me.TextTeach_DiameterTolerance_CCD3 = New System.Windows.Forms.TextBox
    Me.TextTeach_Diameter_CCD3 = New System.Windows.Forms.TextBox
    Me.TextTeach_DiameterTolerance_CCD2 = New System.Windows.Forms.TextBox
    Me.TextTeach_Diameter_CCD2 = New System.Windows.Forms.TextBox
    Me.Label59 = New System.Windows.Forms.Label
    Me.TextTeach_DiameterTolerance_CCD1 = New System.Windows.Forms.TextBox
    Me.TextTeach_Diameter_CCD1 = New System.Windows.Forms.TextBox
    Me.Label44 = New System.Windows.Forms.Label
    Me.TextTeach_DistanceTolerance_UpDown = New System.Windows.Forms.TextBox
    Me.TextTeach_DistanceTolerance_LeftRight = New System.Windows.Forms.TextBox
    Me.Label42 = New System.Windows.Forms.Label
    Me.TextTeach_Distance_UpDown = New System.Windows.Forms.TextBox
    Me.TextTeach_Distance_LeftRight = New System.Windows.Forms.TextBox
    Me.Label40 = New System.Windows.Forms.Label
    Me.Label32 = New System.Windows.Forms.Label
    Me.Label39 = New System.Windows.Forms.Label
    Me.Label64 = New System.Windows.Forms.Label
    Me.Label46 = New System.Windows.Forms.Label
    Me.GroupProduct_Light = New System.Windows.Forms.GroupBox
    Me.BtnTeach_SearchLight_Off = New System.Windows.Forms.Button
    Me.BtnTeach_SearchLight_On = New System.Windows.Forms.Button
    Me.TextTeach_Search_Light4 = New System.Windows.Forms.TextBox
    Me.TextTeach_Search_Light3 = New System.Windows.Forms.TextBox
    Me.Label16 = New System.Windows.Forms.Label
    Me.Label15 = New System.Windows.Forms.Label
    Me.Label14 = New System.Windows.Forms.Label
    Me.BtnTeach_SearchLight_Set = New System.Windows.Forms.Button
    Me.TextTeach_Search_Light2 = New System.Windows.Forms.TextBox
    Me.TextTeach_Search_Light1 = New System.Windows.Forms.TextBox
    Me.Label215 = New System.Windows.Forms.Label
    Me.TabPage_Run = New System.Windows.Forms.TabPage
    Me.PanelRun = New System.Windows.Forms.Panel
    Me.GroupRun_SendData = New System.Windows.Forms.GroupBox
    Me.DataGrid_SendData = New System.Windows.Forms.DataGridView
    Me.Column1_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Column2_Value = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.BtnRun_SendData = New System.Windows.Forms.Button
    Me.Label141 = New System.Windows.Forms.Label
    Me.LabSendData_FileName = New System.Windows.Forms.Label
    Me.BtnRun_LoadResultFile = New System.Windows.Forms.Button
    Me.GroupRun_CycleTime = New System.Windows.Forms.GroupBox
    Me.PanelTimeInf = New System.Windows.Forms.Panel
    Me.LabTimeInf_Search1 = New System.Windows.Forms.Label
    Me.Label138 = New System.Windows.Forms.Label
    Me.Label140 = New System.Windows.Forms.Label
    Me.LabTimeInf_Total = New System.Windows.Forms.Label
    Me.LabTimeInf_Search2 = New System.Windows.Forms.Label
    Me.Label142 = New System.Windows.Forms.Label
    Me.LabTimeInf_SearchTotal = New System.Windows.Forms.Label
    Me.Label143 = New System.Windows.Forms.Label
    Me.GroupBox17 = New System.Windows.Forms.GroupBox
    Me.TextOpInf_PackNumber = New System.Windows.Forms.TextBox
    Me.Label130 = New System.Windows.Forms.Label
    Me.TextOpInf_OunchNeedleNumberDown = New System.Windows.Forms.TextBox
    Me.Label126 = New System.Windows.Forms.Label
    Me.TextOpInf_OunchNeedleNumberUp = New System.Windows.Forms.TextBox
    Me.Label127 = New System.Windows.Forms.Label
    Me.TextOpInf_MouldNumber = New System.Windows.Forms.TextBox
    Me.Label128 = New System.Windows.Forms.Label
    Me.TextOpInf_MachineCode = New System.Windows.Forms.TextBox
    Me.Label129 = New System.Windows.Forms.Label
    Me.TextOpInf_HoleDustanceAndResultY = New System.Windows.Forms.TextBox
    Me.Label122 = New System.Windows.Forms.Label
    Me.TextOpInf_HoleDustanceAndResultX = New System.Windows.Forms.TextBox
    Me.Label123 = New System.Windows.Forms.Label
    Me.TextOpInf_HoleQualityType = New System.Windows.Forms.TextBox
    Me.Label124 = New System.Windows.Forms.Label
    Me.TextOpInf_HoleQualityResult = New System.Windows.Forms.TextBox
    Me.Label125 = New System.Windows.Forms.Label
    Me.TextOpInf_ProductNumber = New System.Windows.Forms.TextBox
    Me.Label120 = New System.Windows.Forms.Label
    Me.TextOpInf_NotNumber = New System.Windows.Forms.TextBox
    Me.Label121 = New System.Windows.Forms.Label
    Me.TextOpInf_DateTime = New System.Windows.Forms.TextBox
    Me.Label119 = New System.Windows.Forms.Label
    Me.TextOpInf_UserNo = New System.Windows.Forms.TextBox
    Me.Label118 = New System.Windows.Forms.Label
    Me.BtnRun_MoveToStandbyPos = New System.Windows.Forms.Button
    Me.GroupRun_BarcodeInLine = New System.Windows.Forms.GroupBox
    Me.TextRun_Barcode_Reader = New System.Windows.Forms.TextBox
    Me.BtnRun_MoveToSearchPos = New System.Windows.Forms.Button
    Me.GroupRun_Result = New System.Windows.Forms.GroupBox
    Me.GroupRun_DefectLength_Outside = New System.Windows.Forms.GroupBox
    Me.DataGrid_DefectLength_Outside = New System.Windows.Forms.DataGridView
    Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.GroupRun_DefectCount_Inside = New System.Windows.Forms.GroupBox
    Me.LabServer_Receive_NoncontinueCount_CCD4 = New System.Windows.Forms.Label
    Me.LabServer_Receive_NoncontinueCount_CCD3 = New System.Windows.Forms.Label
    Me.LabServer_Receive_NoncontinueCount_CCD2 = New System.Windows.Forms.Label
    Me.LabServer_Receive_NoncontinueCount_CCD1 = New System.Windows.Forms.Label
    Me.LabServer_Receive_ContinueCount_CCD4 = New System.Windows.Forms.Label
    Me.LabServer_Receive_ContinueCount_CCD3 = New System.Windows.Forms.Label
    Me.LabServer_Receive_ContinueCount_CCD2 = New System.Windows.Forms.Label
    Me.LabServer_Receive_ContinueCount_CCD1 = New System.Windows.Forms.Label
    Me.Label63 = New System.Windows.Forms.Label
    Me.Label117 = New System.Windows.Forms.Label
    Me.LabRun_Diameter_CCD4 = New System.Windows.Forms.Label
    Me.LabRun_Diameter_CCD3 = New System.Windows.Forms.Label
    Me.LabRun_Diameter_CCD2 = New System.Windows.Forms.Label
    Me.LabRun_Diameter_CCD1 = New System.Windows.Forms.Label
    Me.GroupRun_OkNg = New System.Windows.Forms.GroupBox
    Me.LabRun_SearchResult = New System.Windows.Forms.Label
    Me.Label51 = New System.Windows.Forms.Label
    Me.LabRun_Defect_TrueCircle_CCD4 = New System.Windows.Forms.Label
    Me.LabRun_Defect_TrueCircle_CCD3 = New System.Windows.Forms.Label
    Me.LabRun_Defect_TrueCircle_CCD2 = New System.Windows.Forms.Label
    Me.LabRun_Defect_TrueCircle_CCD1 = New System.Windows.Forms.Label
    Me.Label33 = New System.Windows.Forms.Label
    Me.LabRun_Distance_UpDown = New System.Windows.Forms.Label
    Me.Label34 = New System.Windows.Forms.Label
    Me.LabRun_Distance_LeftRight = New System.Windows.Forms.Label
    Me.Label31 = New System.Windows.Forms.Label
    Me.Label35 = New System.Windows.Forms.Label
    Me.Label36 = New System.Windows.Forms.Label
    Me.Label41 = New System.Windows.Forms.Label
    Me.GroupRun_Msg = New System.Windows.Forms.GroupBox
    Me.LabRun_Msg_PLC = New System.Windows.Forms.Label
    Me.LabRunningMsg = New System.Windows.Forms.Label
    Me.Label48 = New System.Windows.Forms.Label
    Me.LabRun_Msg_CCD4 = New System.Windows.Forms.Label
    Me.LabRun_Msg_CCD3 = New System.Windows.Forms.Label
    Me.LabRun_Msg_CCD2 = New System.Windows.Forms.Label
    Me.LabRun_Msg_CCD1 = New System.Windows.Forms.Label
    Me.Label10 = New System.Windows.Forms.Label
    Me.BtnRun_LoadNgImages = New System.Windows.Forms.Button
    Me.BtnRun_ResetRunIndex = New System.Windows.Forms.Button
    Me.LabSearch1_Result_CCD4 = New System.Windows.Forms.Label
    Me.LabSearch1_Result_CCD3 = New System.Windows.Forms.Label
    Me.LabSearch1_Result_CCD2 = New System.Windows.Forms.Label
    Me.LabSearch1_Result_CCD1 = New System.Windows.Forms.Label
    Me.BtnRun_ImageLoad_CCD4 = New System.Windows.Forms.Button
    Me.BtnRun_ImageSave_CCD4 = New System.Windows.Forms.Button
    Me.BtnRun_ImageLoad_CCD2 = New System.Windows.Forms.Button
    Me.BtnRun_ImageSave_CCD2 = New System.Windows.Forms.Button
    Me.BtnRun_ImageLoad_CCD1 = New System.Windows.Forms.Button
    Me.BtnRun_ImageSave_CCD1 = New System.Windows.Forms.Button
    Me.BtnRun_ImageLoad_CCD3 = New System.Windows.Forms.Button
    Me.BtnRun_ImageSave_CCD3 = New System.Windows.Forms.Button
    Me.CheckRun_Live_CCD4 = New System.Windows.Forms.CheckBox
    Me.BtnRun_ZoomToFit_CCD4 = New System.Windows.Forms.Button
    Me.CheckRun_Live_CCD2 = New System.Windows.Forms.CheckBox
    Me.BtnRun_ZoomToFit_CCD2 = New System.Windows.Forms.Button
    Me.CheckRun_Live_CCD3 = New System.Windows.Forms.CheckBox
    Me.BtnRun_ZoomToFit_CCD3 = New System.Windows.Forms.Button
    Me.ImageViewer_CCD3 = New NationalInstruments.Vision.WindowsForms.ImageViewer
    Me.CheckRun_Live_CCD1 = New System.Windows.Forms.CheckBox
    Me.BtnRun_ZoomToFit_CCD1 = New System.Windows.Forms.Button
    Me.ImageViewer_CCD4 = New NationalInstruments.Vision.WindowsForms.ImageViewer
    Me.ImageViewer_CCD1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
    Me.ImageViewer_CCD2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
    Me.TabControl_SendData = New System.Windows.Forms.TabControl
    Me.TabPage_Service = New System.Windows.Forms.TabPage
    Me.PanelService_Back = New System.Windows.Forms.Panel
    Me.PanelService = New System.Windows.Forms.Panel
    Me.GroupBox18 = New System.Windows.Forms.GroupBox
    Me.Label144 = New System.Windows.Forms.Label
    Me.TextServer_Receive_CCD1 = New System.Windows.Forms.TextBox
    Me.TextServer_Receive_CCD2 = New System.Windows.Forms.TextBox
    Me.TextServer_Receive_CCD3 = New System.Windows.Forms.TextBox
    Me.TextServer_Receive_CCD4 = New System.Windows.Forms.TextBox
    Me.Label136 = New System.Windows.Forms.Label
    Me.InstantCtrl_DO = New Automation.BDaq.InstantDoCtrl(Me.components)
    Me.TimerRunState = New System.Windows.Forms.Timer(Me.components)
    Me.TimerBarcode = New System.Windows.Forms.Timer(Me.components)
    Me.SerialPort_Barcode = New System.IO.Ports.SerialPort(Me.components)
    Me.Panel_CCD1 = New System.Windows.Forms.Panel
    Me.BtnRun_ImageSource_CCD1 = New System.Windows.Forms.Button
    Me.Panel_CCD2 = New System.Windows.Forms.Panel
    Me.BtnRun_ImageSource_CCD2 = New System.Windows.Forms.Button
    Me.Panel_CCD4 = New System.Windows.Forms.Panel
    Me.BtnRun_ImageSource_CCD4 = New System.Windows.Forms.Button
    Me.Panel_CCD3 = New System.Windows.Forms.Panel
    Me.BtnRun_ImageSource_CCD3 = New System.Windows.Forms.Button
    Me.TabControl_CCD = New System.Windows.Forms.TabControl
    Me.TabPage_Search1 = New System.Windows.Forms.TabPage
    Me.TabPage_Search2 = New System.Windows.Forms.TabPage
    Me.Panel_Search2_CCD2 = New System.Windows.Forms.Panel
    Me.Label133 = New System.Windows.Forms.Label
    Me.Panel_Search2_CCD4 = New System.Windows.Forms.Panel
    Me.Label134 = New System.Windows.Forms.Label
    Me.Panel_Search2_CCD3 = New System.Windows.Forms.Panel
    Me.Label135 = New System.Windows.Forms.Label
    Me.Panel_Search2_CCD1 = New System.Windows.Forms.Panel
    Me.Label132 = New System.Windows.Forms.Label
    Me.Panel_Search2 = New System.Windows.Forms.Panel
    Me.LabSearch2_Result_CCD4 = New System.Windows.Forms.Label
    Me.LabSearch2_Result_CCD3 = New System.Windows.Forms.Label
    Me.LabSearch2_Result_CCD2 = New System.Windows.Forms.Label
    Me.BtnSearch2_Measure_CCD2 = New System.Windows.Forms.Button
    Me.BtnSearch2_ImageLoad_CCD1 = New System.Windows.Forms.Button
    Me.BtnSearch2_ImageLoad_CCD2 = New System.Windows.Forms.Button
    Me.BtnSearch2_ImageLoad_CCD4 = New System.Windows.Forms.Button
    Me.BtnSearch2_Measure_CCD1 = New System.Windows.Forms.Button
    Me.BtnSearch2_Measure_CCD3 = New System.Windows.Forms.Button
    Me.BtnSearch2_ImageLoad_CCD3 = New System.Windows.Forms.Button
    Me.BtnSearch2_Measure_CCD4 = New System.Windows.Forms.Button
    Me.LabSearch2_Result_CCD1 = New System.Windows.Forms.Label
    Me.CheckBox1 = New System.Windows.Forms.CheckBox
    Me.Label131 = New System.Windows.Forms.Label
    Me.ImageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
    Me.OpenFileDialog_SendData = New System.Windows.Forms.OpenFileDialog
    Me.BtnOpInf_Clear = New System.Windows.Forms.Button
    Me.GroupTools.SuspendLayout()
    CType(Me.AxActUtlType_PLC, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupOption.SuspendLayout()
    Me.TabPage_IO.SuspendLayout()
    Me.Panel_IO.SuspendLayout()
    Me.GroupIO_PLC.SuspendLayout()
    Me.TabControlPLC.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    Me.GroupBox16.SuspendLayout()
    Me.GroupBox15.SuspendLayout()
    Me.GroupBox14.SuspendLayout()
    Me.GroupBox13.SuspendLayout()
    Me.GroupVacuum.SuspendLayout()
    Me.GroupBox11.SuspendLayout()
    Me.GroupBox10.SuspendLayout()
    Me.GroupBox9.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.GroupBox12.SuspendLayout()
    Me.GroupIO_AOI.SuspendLayout()
    Me.GroupIO_Input.SuspendLayout()
    Me.GroupIO_Output.SuspendLayout()
    Me.TabPage_Parameter.SuspendLayout()
    Me.PanelParameter.SuspendLayout()
    Me.GroupAdv.SuspendLayout()
    Me.GroupAdv_Option.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupAdv_Calib_ImageAdjust.SuspendLayout()
    CType(Me.TrackBarAdv_Calib_BinaryMax, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.UpDownAdv_Calib_Remove, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TrackBarAdv_Calib_BinaryMin, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupAdv_Calib_Distance.SuspendLayout()
    Me.GroupAdv_Calib_Pixel.SuspendLayout()
    Me.GroupAdv_Calib_Light.SuspendLayout()
    Me.GroupProduct.SuspendLayout()
    Me.PanelProduct_Function1.SuspendLayout()
    Me.GroupTeach_ImageAdjust_Inside.SuspendLayout()
    CType(Me.UpDownSearch2_Score, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupTeach_ImageAdjust_Outside.SuspendLayout()
    CType(Me.TrackBarTeach_BinaryDefectOut, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TrackBarTeach_BinaryOutside, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupTeach_ImageAdjust_Size.SuspendLayout()
    CType(Me.TrackBarTeach_BinaryMax, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TrackBarTeach_BinaryMin, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupTeacht_Spec.SuspendLayout()
    Me.GroupProduct_Light.SuspendLayout()
    Me.TabPage_Run.SuspendLayout()
    Me.PanelRun.SuspendLayout()
    Me.GroupRun_SendData.SuspendLayout()
    CType(Me.DataGrid_SendData, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupRun_CycleTime.SuspendLayout()
    Me.PanelTimeInf.SuspendLayout()
    Me.GroupBox17.SuspendLayout()
    Me.GroupRun_BarcodeInLine.SuspendLayout()
    Me.GroupRun_Result.SuspendLayout()
    Me.GroupRun_DefectLength_Outside.SuspendLayout()
    CType(Me.DataGrid_DefectLength_Outside, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupRun_DefectCount_Inside.SuspendLayout()
    Me.GroupRun_OkNg.SuspendLayout()
    Me.GroupRun_Msg.SuspendLayout()
    Me.TabControl_SendData.SuspendLayout()
    Me.TabPage_Service.SuspendLayout()
    Me.PanelService_Back.SuspendLayout()
    Me.PanelService.SuspendLayout()
    Me.GroupBox18.SuspendLayout()
    Me.Panel_CCD1.SuspendLayout()
    Me.Panel_CCD2.SuspendLayout()
    Me.Panel_CCD4.SuspendLayout()
    Me.Panel_CCD3.SuspendLayout()
    Me.TabControl_CCD.SuspendLayout()
    Me.TabPage_Search1.SuspendLayout()
    Me.TabPage_Search2.SuspendLayout()
    Me.Panel_Search2_CCD2.SuspendLayout()
    Me.Panel_Search2_CCD4.SuspendLayout()
    Me.Panel_Search2_CCD3.SuspendLayout()
    Me.Panel_Search2_CCD1.SuspendLayout()
    Me.Panel_Search2.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupTools
    '
    Me.GroupTools.BackColor = System.Drawing.SystemColors.ControlDark
    Me.GroupTools.Controls.Add(Me.AxActUtlType_PLC)
    Me.GroupTools.Controls.Add(Me.BtnTool_AlarmReset)
    Me.GroupTools.Controls.Add(Me.BtnTool_Home)
    Me.GroupTools.Controls.Add(Me.CheckTool_CcdLive)
    Me.GroupTools.Controls.Add(Me.BtnTool_ReadBarcode)
    Me.GroupTools.Controls.Add(Me.PictureLogo)
    Me.GroupTools.Controls.Add(Me.BtnTool_Search)
    Me.GroupTools.Controls.Add(Me.GroupOption)
    Me.GroupTools.Controls.Add(Me.BtnTool_Exit)
    Me.GroupTools.Controls.Add(Me.LabLevel)
    Me.GroupTools.Controls.Add(Me.BtnTool_Log)
    Me.GroupTools.Controls.Add(Me.BtnTool_IO)
    Me.GroupTools.Controls.Add(Me.BtnTool_FileDelete)
    Me.GroupTools.Controls.Add(Me.BtnTool_FileSaveAs)
    Me.GroupTools.Controls.Add(Me.BtnTool_FileSave)
    Me.GroupTools.Controls.Add(Me.LabFileName)
    Me.GroupTools.Controls.Add(Me.BtnTool_FileLoad)
    Me.GroupTools.Controls.Add(Me.BtnTool_Login)
    Me.GroupTools.Controls.Add(Me.Label37)
    Me.GroupTools.Controls.Add(Me.BtnTool_Start)
    Me.GroupTools.Controls.Add(Me.BtnTool_Stop)
    Me.GroupTools.Controls.Add(Me.Label54)
    Me.GroupTools.Location = New System.Drawing.Point(5, 14)
    Me.GroupTools.Name = "GroupTools"
    Me.GroupTools.Size = New System.Drawing.Size(1913, 89)
    Me.GroupTools.TabIndex = 94
    Me.GroupTools.TabStop = False
    '
    'AxActUtlType_PLC
    '
    Me.AxActUtlType_PLC.Enabled = True
    Me.AxActUtlType_PLC.Location = New System.Drawing.Point(1353, 12)
    Me.AxActUtlType_PLC.Name = "AxActUtlType_PLC"
    Me.AxActUtlType_PLC.OcxState = CType(resources.GetObject("AxActUtlType_PLC.OcxState"), System.Windows.Forms.AxHost.State)
    Me.AxActUtlType_PLC.Size = New System.Drawing.Size(32, 32)
    Me.AxActUtlType_PLC.TabIndex = 152
    '
    'BtnTool_AlarmReset
    '
    Me.BtnTool_AlarmReset.BackColor = System.Drawing.Color.White
    Me.BtnTool_AlarmReset.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_AlarmReset.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_AlarmReset.Image = CType(resources.GetObject("BtnTool_AlarmReset.Image"), System.Drawing.Image)
    Me.BtnTool_AlarmReset.Location = New System.Drawing.Point(1017, 9)
    Me.BtnTool_AlarmReset.Name = "BtnTool_AlarmReset"
    Me.BtnTool_AlarmReset.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_AlarmReset.TabIndex = 151
    Me.BtnTool_AlarmReset.TabStop = False
    Me.BtnTool_AlarmReset.Text = "異常復歸"
    Me.BtnTool_AlarmReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_AlarmReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_AlarmReset.UseVisualStyleBackColor = False
    '
    'BtnTool_Home
    '
    Me.BtnTool_Home.BackColor = System.Drawing.Color.White
    Me.BtnTool_Home.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_Home.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_Home.Image = CType(resources.GetObject("BtnTool_Home.Image"), System.Drawing.Image)
    Me.BtnTool_Home.Location = New System.Drawing.Point(939, 9)
    Me.BtnTool_Home.Name = "BtnTool_Home"
    Me.BtnTool_Home.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_Home.TabIndex = 149
    Me.BtnTool_Home.TabStop = False
    Me.BtnTool_Home.Text = "馬達復歸"
    Me.BtnTool_Home.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_Home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_Home.UseVisualStyleBackColor = False
    '
    'CheckTool_CcdLive
    '
    Me.CheckTool_CcdLive.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckTool_CcdLive.BackColor = System.Drawing.Color.White
    Me.CheckTool_CcdLive.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckTool_CcdLive.ForeColor = System.Drawing.Color.MidnightBlue
    Me.CheckTool_CcdLive.Image = CType(resources.GetObject("CheckTool_CcdLive.Image"), System.Drawing.Image)
    Me.CheckTool_CcdLive.Location = New System.Drawing.Point(783, 9)
    Me.CheckTool_CcdLive.Name = "CheckTool_CcdLive"
    Me.CheckTool_CcdLive.Size = New System.Drawing.Size(78, 78)
    Me.CheckTool_CcdLive.TabIndex = 143
    Me.CheckTool_CcdLive.TabStop = False
    Me.CheckTool_CcdLive.Text = "Live"
    Me.CheckTool_CcdLive.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.CheckTool_CcdLive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.CheckTool_CcdLive.UseVisualStyleBackColor = False
    '
    'BtnTool_ReadBarcode
    '
    Me.BtnTool_ReadBarcode.BackColor = System.Drawing.Color.White
    Me.BtnTool_ReadBarcode.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_ReadBarcode.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_ReadBarcode.Image = CType(resources.GetObject("BtnTool_ReadBarcode.Image"), System.Drawing.Image)
    Me.BtnTool_ReadBarcode.Location = New System.Drawing.Point(861, 9)
    Me.BtnTool_ReadBarcode.Name = "BtnTool_ReadBarcode"
    Me.BtnTool_ReadBarcode.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_ReadBarcode.TabIndex = 142
    Me.BtnTool_ReadBarcode.TabStop = False
    Me.BtnTool_ReadBarcode.Text = "讀取條碼"
    Me.BtnTool_ReadBarcode.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_ReadBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_ReadBarcode.UseVisualStyleBackColor = False
    '
    'PictureLogo
    '
    Me.PictureLogo.Image = CType(resources.GetObject("PictureLogo.Image"), System.Drawing.Image)
    Me.PictureLogo.Location = New System.Drawing.Point(1628, 11)
    Me.PictureLogo.Name = "PictureLogo"
    Me.PictureLogo.Size = New System.Drawing.Size(281, 74)
    Me.PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.PictureLogo.TabIndex = 141
    Me.PictureLogo.TabStop = False
    '
    'BtnTool_Search
    '
    Me.BtnTool_Search.BackColor = System.Drawing.Color.White
    Me.BtnTool_Search.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_Search.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_Search.Image = CType(resources.GetObject("BtnTool_Search.Image"), System.Drawing.Image)
    Me.BtnTool_Search.Location = New System.Drawing.Point(705, 9)
    Me.BtnTool_Search.Name = "BtnTool_Search"
    Me.BtnTool_Search.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_Search.TabIndex = 122
    Me.BtnTool_Search.TabStop = False
    Me.BtnTool_Search.Text = "檢測"
    Me.BtnTool_Search.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_Search.UseVisualStyleBackColor = False
    '
    'GroupOption
    '
    Me.GroupOption.Controls.Add(Me.CheckOption_DrawCross)
    Me.GroupOption.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupOption.Location = New System.Drawing.Point(1391, 11)
    Me.GroupOption.Name = "GroupOption"
    Me.GroupOption.Size = New System.Drawing.Size(156, 34)
    Me.GroupOption.TabIndex = 52
    Me.GroupOption.TabStop = False
    Me.GroupOption.Text = "功能選項"
    '
    'CheckOption_DrawCross
    '
    Me.CheckOption_DrawCross.AutoSize = True
    Me.CheckOption_DrawCross.Checked = True
    Me.CheckOption_DrawCross.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckOption_DrawCross.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckOption_DrawCross.Location = New System.Drawing.Point(6, 15)
    Me.CheckOption_DrawCross.Name = "CheckOption_DrawCross"
    Me.CheckOption_DrawCross.Size = New System.Drawing.Size(84, 16)
    Me.CheckOption_DrawCross.TabIndex = 93
    Me.CheckOption_DrawCross.TabStop = False
    Me.CheckOption_DrawCross.Text = "顯示十字線"
    Me.CheckOption_DrawCross.UseVisualStyleBackColor = True
    '
    'BtnTool_Exit
    '
    Me.BtnTool_Exit.BackColor = System.Drawing.Color.White
    Me.BtnTool_Exit.Font = New System.Drawing.Font("新細明體", 9.75!)
    Me.BtnTool_Exit.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_Exit.Image = CType(resources.GetObject("BtnTool_Exit.Image"), System.Drawing.Image)
    Me.BtnTool_Exit.Location = New System.Drawing.Point(1549, 9)
    Me.BtnTool_Exit.Name = "BtnTool_Exit"
    Me.BtnTool_Exit.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_Exit.TabIndex = 47
    Me.BtnTool_Exit.Text = "離開"
    Me.BtnTool_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_Exit.UseVisualStyleBackColor = False
    '
    'LabLevel
    '
    Me.LabLevel.BackColor = System.Drawing.Color.Pink
    Me.LabLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.LabLevel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabLevel.Location = New System.Drawing.Point(1180, 16)
    Me.LabLevel.Name = "LabLevel"
    Me.LabLevel.Size = New System.Drawing.Size(130, 29)
    Me.LabLevel.TabIndex = 98
    Me.LabLevel.Tag = "未登入"
    Me.LabLevel.Text = "未登入"
    Me.LabLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnTool_Log
    '
    Me.BtnTool_Log.BackColor = System.Drawing.Color.White
    Me.BtnTool_Log.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_Log.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_Log.Image = CType(resources.GetObject("BtnTool_Log.Image"), System.Drawing.Image)
    Me.BtnTool_Log.Location = New System.Drawing.Point(471, 9)
    Me.BtnTool_Log.Name = "BtnTool_Log"
    Me.BtnTool_Log.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_Log.TabIndex = 44
    Me.BtnTool_Log.TabStop = False
    Me.BtnTool_Log.Text = "運行記錄"
    Me.BtnTool_Log.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_Log.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_Log.UseVisualStyleBackColor = False
    '
    'BtnTool_IO
    '
    Me.BtnTool_IO.BackColor = System.Drawing.Color.White
    Me.BtnTool_IO.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_IO.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_IO.Image = CType(resources.GetObject("BtnTool_IO.Image"), System.Drawing.Image)
    Me.BtnTool_IO.Location = New System.Drawing.Point(393, 9)
    Me.BtnTool_IO.Name = "BtnTool_IO"
    Me.BtnTool_IO.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_IO.TabIndex = 43
    Me.BtnTool_IO.TabStop = False
    Me.BtnTool_IO.Text = "I/O"
    Me.BtnTool_IO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_IO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_IO.UseVisualStyleBackColor = False
    '
    'BtnTool_FileDelete
    '
    Me.BtnTool_FileDelete.BackColor = System.Drawing.Color.White
    Me.BtnTool_FileDelete.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_FileDelete.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_FileDelete.Image = CType(resources.GetObject("BtnTool_FileDelete.Image"), System.Drawing.Image)
    Me.BtnTool_FileDelete.Location = New System.Drawing.Point(315, 9)
    Me.BtnTool_FileDelete.Name = "BtnTool_FileDelete"
    Me.BtnTool_FileDelete.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_FileDelete.TabIndex = 42
    Me.BtnTool_FileDelete.TabStop = False
    Me.BtnTool_FileDelete.Tag = "刪除產品檔"
    Me.BtnTool_FileDelete.Text = "刪除產品"
    Me.BtnTool_FileDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_FileDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_FileDelete.UseVisualStyleBackColor = False
    '
    'BtnTool_FileSaveAs
    '
    Me.BtnTool_FileSaveAs.BackColor = System.Drawing.Color.White
    Me.BtnTool_FileSaveAs.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_FileSaveAs.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_FileSaveAs.Image = CType(resources.GetObject("BtnTool_FileSaveAs.Image"), System.Drawing.Image)
    Me.BtnTool_FileSaveAs.Location = New System.Drawing.Point(237, 9)
    Me.BtnTool_FileSaveAs.Name = "BtnTool_FileSaveAs"
    Me.BtnTool_FileSaveAs.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_FileSaveAs.TabIndex = 41
    Me.BtnTool_FileSaveAs.TabStop = False
    Me.BtnTool_FileSaveAs.Text = "另存產品"
    Me.BtnTool_FileSaveAs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_FileSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_FileSaveAs.UseVisualStyleBackColor = False
    '
    'BtnTool_FileSave
    '
    Me.BtnTool_FileSave.BackColor = System.Drawing.Color.White
    Me.BtnTool_FileSave.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_FileSave.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_FileSave.Image = CType(resources.GetObject("BtnTool_FileSave.Image"), System.Drawing.Image)
    Me.BtnTool_FileSave.Location = New System.Drawing.Point(159, 9)
    Me.BtnTool_FileSave.Name = "BtnTool_FileSave"
    Me.BtnTool_FileSave.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_FileSave.TabIndex = 40
    Me.BtnTool_FileSave.TabStop = False
    Me.BtnTool_FileSave.Text = "儲存產品"
    Me.BtnTool_FileSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_FileSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_FileSave.UseVisualStyleBackColor = False
    '
    'LabFileName
    '
    Me.LabFileName.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabFileName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabFileName.ForeColor = System.Drawing.Color.Blue
    Me.LabFileName.Location = New System.Drawing.Point(1179, 47)
    Me.LabFileName.Name = "LabFileName"
    Me.LabFileName.Size = New System.Drawing.Size(369, 39)
    Me.LabFileName.TabIndex = 120
    '
    'BtnTool_FileLoad
    '
    Me.BtnTool_FileLoad.BackColor = System.Drawing.Color.White
    Me.BtnTool_FileLoad.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_FileLoad.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_FileLoad.Image = CType(resources.GetObject("BtnTool_FileLoad.Image"), System.Drawing.Image)
    Me.BtnTool_FileLoad.Location = New System.Drawing.Point(81, 9)
    Me.BtnTool_FileLoad.Name = "BtnTool_FileLoad"
    Me.BtnTool_FileLoad.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_FileLoad.TabIndex = 38
    Me.BtnTool_FileLoad.TabStop = False
    Me.BtnTool_FileLoad.Tag = "載入產品檔"
    Me.BtnTool_FileLoad.Text = "載入產品"
    Me.BtnTool_FileLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_FileLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_FileLoad.UseVisualStyleBackColor = False
    '
    'BtnTool_Login
    '
    Me.BtnTool_Login.BackColor = System.Drawing.Color.White
    Me.BtnTool_Login.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_Login.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_Login.Image = CType(resources.GetObject("BtnTool_Login.Image"), System.Drawing.Image)
    Me.BtnTool_Login.Location = New System.Drawing.Point(3, 9)
    Me.BtnTool_Login.Name = "BtnTool_Login"
    Me.BtnTool_Login.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_Login.TabIndex = 37
    Me.BtnTool_Login.TabStop = False
    Me.BtnTool_Login.Text = "等級登入"
    Me.BtnTool_Login.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_Login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_Login.UseVisualStyleBackColor = False
    '
    'Label37
    '
    Me.Label37.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label37.ForeColor = System.Drawing.Color.Maroon
    Me.Label37.Location = New System.Drawing.Point(1096, 50)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(85, 16)
    Me.Label37.TabIndex = 121
    Me.Label37.Tag = ""
    Me.Label37.Text = "產品名稱"
    Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnTool_Start
    '
    Me.BtnTool_Start.BackColor = System.Drawing.Color.White
    Me.BtnTool_Start.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_Start.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_Start.Image = CType(resources.GetObject("BtnTool_Start.Image"), System.Drawing.Image)
    Me.BtnTool_Start.Location = New System.Drawing.Point(549, 9)
    Me.BtnTool_Start.Name = "BtnTool_Start"
    Me.BtnTool_Start.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_Start.TabIndex = 45
    Me.BtnTool_Start.TabStop = False
    Me.BtnTool_Start.Text = "啟動"
    Me.BtnTool_Start.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_Start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_Start.UseVisualStyleBackColor = False
    '
    'BtnTool_Stop
    '
    Me.BtnTool_Stop.BackColor = System.Drawing.Color.White
    Me.BtnTool_Stop.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTool_Stop.ForeColor = System.Drawing.Color.MidnightBlue
    Me.BtnTool_Stop.Image = CType(resources.GetObject("BtnTool_Stop.Image"), System.Drawing.Image)
    Me.BtnTool_Stop.Location = New System.Drawing.Point(627, 9)
    Me.BtnTool_Stop.Name = "BtnTool_Stop"
    Me.BtnTool_Stop.Size = New System.Drawing.Size(78, 78)
    Me.BtnTool_Stop.TabIndex = 50
    Me.BtnTool_Stop.TabStop = False
    Me.BtnTool_Stop.Text = "停止"
    Me.BtnTool_Stop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BtnTool_Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    Me.BtnTool_Stop.UseVisualStyleBackColor = False
    '
    'Label54
    '
    Me.Label54.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label54.ForeColor = System.Drawing.Color.Maroon
    Me.Label54.Location = New System.Drawing.Point(1096, 23)
    Me.Label54.Name = "Label54"
    Me.Label54.Size = New System.Drawing.Size(85, 16)
    Me.Label54.TabIndex = 144
    Me.Label54.Tag = ""
    Me.Label54.Text = "登入級別"
    Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabProgramInfo
    '
    Me.LabProgramInfo.BackColor = System.Drawing.Color.Navy
    Me.LabProgramInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabProgramInfo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabProgramInfo.ForeColor = System.Drawing.Color.White
    Me.LabProgramInfo.Location = New System.Drawing.Point(2, 2)
    Me.LabProgramInfo.Name = "LabProgramInfo"
    Me.LabProgramInfo.Size = New System.Drawing.Size(1915, 18)
    Me.LabProgramInfo.TabIndex = 95
    Me.LabProgramInfo.Text = "圓孔量測及瑕疵檢測系統"
    Me.LabProgramInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'OpenFileDialog_LoadImage
    '
    Me.OpenFileDialog_LoadImage.Title = "載入圖像"
    '
    'SaveFileDialog_SaveImage
    '
    Me.SaveFileDialog_SaveImage.SupportMultiDottedExtensions = True
    '
    'InstantCtrl_DI
    '
    Me.InstantCtrl_DI._StateStream = CType(resources.GetObject("InstantCtrl_DI._StateStream"), Automation.BDaq.DeviceStateStreamer)
    '
    'TimerDIO
    '
    Me.TimerDIO.Interval = 50
    '
    'TabPage_IO
    '
    Me.TabPage_IO.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TabPage_IO.Controls.Add(Me.Panel_IO)
    Me.TabPage_IO.Location = New System.Drawing.Point(4, 30)
    Me.TabPage_IO.Name = "TabPage_IO"
    Me.TabPage_IO.Size = New System.Drawing.Size(851, 938)
    Me.TabPage_IO.TabIndex = 2
    Me.TabPage_IO.Text = "I/O"
    Me.TabPage_IO.UseVisualStyleBackColor = True
    '
    'Panel_IO
    '
    Me.Panel_IO.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Panel_IO.Controls.Add(Me.GroupIO_PLC)
    Me.Panel_IO.Controls.Add(Me.GroupIO_AOI)
    Me.Panel_IO.Controls.Add(Me.LabService_RunIndex)
    Me.Panel_IO.Controls.Add(Me.Label49)
    Me.Panel_IO.Location = New System.Drawing.Point(0, 0)
    Me.Panel_IO.Name = "Panel_IO"
    Me.Panel_IO.Size = New System.Drawing.Size(851, 942)
    Me.Panel_IO.TabIndex = 0
    '
    'GroupIO_PLC
    '
    Me.GroupIO_PLC.Controls.Add(Me.TabControlPLC)
    Me.GroupIO_PLC.Controls.Add(Me.Label113)
    Me.GroupIO_PLC.Controls.Add(Me.LabPlcRunning)
    Me.GroupIO_PLC.Controls.Add(Me.txt_Data)
    Me.GroupIO_PLC.Controls.Add(Me.txt_LogicalStationNumber)
    Me.GroupIO_PLC.Controls.Add(Me.lbl_LogicalStationNumber)
    Me.GroupIO_PLC.Controls.Add(Me.Radio_PlcRunning)
    Me.GroupIO_PLC.Controls.Add(Me.Text_ReturnCode)
    Me.GroupIO_PLC.Controls.Add(Me.BtnClose)
    Me.GroupIO_PLC.Controls.Add(Me.BtnOpen)
    Me.GroupIO_PLC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.GroupIO_PLC.Location = New System.Drawing.Point(2, 270)
    Me.GroupIO_PLC.Name = "GroupIO_PLC"
    Me.GroupIO_PLC.Size = New System.Drawing.Size(847, 665)
    Me.GroupIO_PLC.TabIndex = 60
    Me.GroupIO_PLC.TabStop = False
    Me.GroupIO_PLC.Text = "PLC"
    '
    'TabControlPLC
    '
    Me.TabControlPLC.Controls.Add(Me.TabPage1)
    Me.TabControlPLC.Controls.Add(Me.TabPage2)
    Me.TabControlPLC.Location = New System.Drawing.Point(6, 102)
    Me.TabControlPLC.Name = "TabControlPLC"
    Me.TabControlPLC.SelectedIndex = 0
    Me.TabControlPLC.Size = New System.Drawing.Size(834, 473)
    Me.TabControlPLC.TabIndex = 91
    '
    'TabPage1
    '
    Me.TabPage1.BackColor = System.Drawing.Color.Silver
    Me.TabPage1.Controls.Add(Me.GroupBox5)
    Me.TabPage1.Controls.Add(Me.GroupBox4)
    Me.TabPage1.Controls.Add(Me.GroupBox3)
    Me.TabPage1.Controls.Add(Me.GroupBox2)
    Me.TabPage1.Location = New System.Drawing.Point(4, 28)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(826, 441)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "Main"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.Label66)
    Me.GroupBox5.Controls.Add(Me.Label67)
    Me.GroupBox5.Controls.Add(Me.Lab_BarcodeResult_M1408)
    Me.GroupBox5.Controls.Add(Me.Text_SearchCount_D3000)
    Me.GroupBox5.Controls.Add(Me.Label68)
    Me.GroupBox5.Controls.Add(Me.D100)
    Me.GroupBox5.Controls.Add(Me.Btn_ClearSearchCount_M1820)
    Me.GroupBox5.Controls.Add(Me.Lab_SearchResult_M1400)
    Me.GroupBox5.Controls.Add(Me.Label69)
    Me.GroupBox5.Controls.Add(Me.Lab_CycleTime_D3002)
    Me.GroupBox5.Location = New System.Drawing.Point(40, 30)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(154, 397)
    Me.GroupBox5.TabIndex = 141
    Me.GroupBox5.TabStop = False
    '
    'Label66
    '
    Me.Label66.AutoSize = True
    Me.Label66.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold)
    Me.Label66.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label66.Location = New System.Drawing.Point(7, -3)
    Me.Label66.Name = "Label66"
    Me.Label66.Size = New System.Drawing.Size(138, 26)
    Me.Label66.TabIndex = 100
    Me.Label66.Text = "自動運行結果"
    '
    'Label67
    '
    Me.Label67.AutoSize = True
    Me.Label67.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label67.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label67.Location = New System.Drawing.Point(33, 30)
    Me.Label67.Name = "Label67"
    Me.Label67.Size = New System.Drawing.Size(86, 24)
    Me.Label67.TabIndex = 82
    Me.Label67.Text = "讀碼結果"
    '
    'Lab_BarcodeResult_M1408
    '
    Me.Lab_BarcodeResult_M1408.BackColor = System.Drawing.Color.Honeydew
    Me.Lab_BarcodeResult_M1408.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_BarcodeResult_M1408.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_BarcodeResult_M1408.Location = New System.Drawing.Point(24, 54)
    Me.Lab_BarcodeResult_M1408.Name = "Lab_BarcodeResult_M1408"
    Me.Lab_BarcodeResult_M1408.Size = New System.Drawing.Size(105, 24)
    Me.Lab_BarcodeResult_M1408.TabIndex = 82
    Me.Lab_BarcodeResult_M1408.Text = "                "
    '
    'Text_SearchCount_D3000
    '
    Me.Text_SearchCount_D3000.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Text_SearchCount_D3000.Location = New System.Drawing.Point(24, 263)
    Me.Text_SearchCount_D3000.Name = "Text_SearchCount_D3000"
    Me.Text_SearchCount_D3000.ReadOnly = True
    Me.Text_SearchCount_D3000.Size = New System.Drawing.Size(105, 26)
    Me.Text_SearchCount_D3000.TabIndex = 77
    Me.Text_SearchCount_D3000.TabStop = False
    '
    'Label68
    '
    Me.Label68.AutoSize = True
    Me.Label68.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label68.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label68.Location = New System.Drawing.Point(33, 100)
    Me.Label68.Name = "Label68"
    Me.Label68.Size = New System.Drawing.Size(86, 24)
    Me.Label68.TabIndex = 83
    Me.Label68.Text = "檢測結果"
    Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'D100
    '
    Me.D100.AutoSize = True
    Me.D100.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.D100.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.D100.Location = New System.Drawing.Point(33, 240)
    Me.D100.Name = "D100"
    Me.D100.Size = New System.Drawing.Size(86, 24)
    Me.D100.TabIndex = 78
    Me.D100.Text = "檢測片數"
    '
    'Btn_ClearSearchCount_M1820
    '
    Me.Btn_ClearSearchCount_M1820.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Btn_ClearSearchCount_M1820.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_ClearSearchCount_M1820.Location = New System.Drawing.Point(28, 290)
    Me.Btn_ClearSearchCount_M1820.Name = "Btn_ClearSearchCount_M1820"
    Me.Btn_ClearSearchCount_M1820.Size = New System.Drawing.Size(94, 32)
    Me.Btn_ClearSearchCount_M1820.TabIndex = 87
    Me.Btn_ClearSearchCount_M1820.Text = "清除片數"
    Me.Btn_ClearSearchCount_M1820.UseVisualStyleBackColor = True
    '
    'Lab_SearchResult_M1400
    '
    Me.Lab_SearchResult_M1400.BackColor = System.Drawing.Color.Honeydew
    Me.Lab_SearchResult_M1400.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_SearchResult_M1400.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_SearchResult_M1400.Location = New System.Drawing.Point(24, 124)
    Me.Lab_SearchResult_M1400.Name = "Lab_SearchResult_M1400"
    Me.Lab_SearchResult_M1400.Size = New System.Drawing.Size(105, 24)
    Me.Lab_SearchResult_M1400.TabIndex = 84
    '
    'Label69
    '
    Me.Label69.AutoSize = True
    Me.Label69.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label69.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label69.Location = New System.Drawing.Point(23, 170)
    Me.Label69.Name = "Label69"
    Me.Label69.Size = New System.Drawing.Size(108, 24)
    Me.Label69.TabIndex = 86
    Me.Label69.Text = "Cycle Time"
    Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Lab_CycleTime_D3002
    '
    Me.Lab_CycleTime_D3002.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_CycleTime_D3002.Location = New System.Drawing.Point(24, 194)
    Me.Lab_CycleTime_D3002.Name = "Lab_CycleTime_D3002"
    Me.Lab_CycleTime_D3002.ReadOnly = True
    Me.Lab_CycleTime_D3002.Size = New System.Drawing.Size(105, 26)
    Me.Lab_CycleTime_D3002.TabIndex = 85
    Me.Lab_CycleTime_D3002.TabStop = False
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.Btn_LaserReset)
    Me.GroupBox4.Controls.Add(Me.Lab_Vacuum_X2B)
    Me.GroupBox4.Controls.Add(Me.Label70)
    Me.GroupBox4.Controls.Add(Me.Lab_Search_M1601)
    Me.GroupBox4.Controls.Add(Me.Label71)
    Me.GroupBox4.Controls.Add(Me.Label72)
    Me.GroupBox4.Controls.Add(Me.Text_LaserHeight_D950)
    Me.GroupBox4.Controls.Add(Me.Lab_Barcode_M1600)
    Me.GroupBox4.Controls.Add(Me.Label73)
    Me.GroupBox4.Controls.Add(Me.Label74)
    Me.GroupBox4.Controls.Add(Me.Label75)
    Me.GroupBox4.Controls.Add(Me.Lab_Standby_M1602)
    Me.GroupBox4.Location = New System.Drawing.Point(214, 30)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(199, 397)
    Me.GroupBox4.TabIndex = 140
    Me.GroupBox4.TabStop = False
    '
    'Btn_LaserReset
    '
    Me.Btn_LaserReset.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Btn_LaserReset.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_LaserReset.Location = New System.Drawing.Point(40, 363)
    Me.Btn_LaserReset.Name = "Btn_LaserReset"
    Me.Btn_LaserReset.Size = New System.Drawing.Size(108, 28)
    Me.Btn_LaserReset.TabIndex = 102
    Me.Btn_LaserReset.Text = "歸零"
    Me.Btn_LaserReset.UseVisualStyleBackColor = True
    '
    'Lab_Vacuum_X2B
    '
    Me.Lab_Vacuum_X2B.BackColor = System.Drawing.Color.Red
    Me.Lab_Vacuum_X2B.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Lab_Vacuum_X2B.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_Vacuum_X2B.Location = New System.Drawing.Point(41, 54)
    Me.Lab_Vacuum_X2B.Name = "Lab_Vacuum_X2B"
    Me.Lab_Vacuum_X2B.Size = New System.Drawing.Size(105, 24)
    Me.Lab_Vacuum_X2B.TabIndex = 91
    Me.Lab_Vacuum_X2B.Text = "                "
    '
    'Label70
    '
    Me.Label70.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label70.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label70.Location = New System.Drawing.Point(50, 30)
    Me.Label70.Name = "Label70"
    Me.Label70.Size = New System.Drawing.Size(90, 24)
    Me.Label70.TabIndex = 92
    Me.Label70.Text = "真空檢知"
    Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Lab_Search_M1601
    '
    Me.Lab_Search_M1601.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_Search_M1601.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_Search_M1601.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_Search_M1601.Location = New System.Drawing.Point(41, 124)
    Me.Lab_Search_M1601.Name = "Lab_Search_M1601"
    Me.Lab_Search_M1601.Size = New System.Drawing.Size(105, 24)
    Me.Lab_Search_M1601.TabIndex = 93
    Me.Lab_Search_M1601.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label71
    '
    Me.Label71.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label71.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label71.Location = New System.Drawing.Point(50, 310)
    Me.Label71.Name = "Label71"
    Me.Label71.Size = New System.Drawing.Size(90, 24)
    Me.Label71.TabIndex = 101
    Me.Label71.Text = "雷射測高"
    Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label72
    '
    Me.Label72.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label72.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label72.Location = New System.Drawing.Point(50, 100)
    Me.Label72.Name = "Label72"
    Me.Label72.Size = New System.Drawing.Size(90, 24)
    Me.Label72.TabIndex = 94
    Me.Label72.Text = "檢測區"
    Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Text_LaserHeight_D950
    '
    Me.Text_LaserHeight_D950.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Text_LaserHeight_D950.Location = New System.Drawing.Point(41, 334)
    Me.Text_LaserHeight_D950.Name = "Text_LaserHeight_D950"
    Me.Text_LaserHeight_D950.ReadOnly = True
    Me.Text_LaserHeight_D950.Size = New System.Drawing.Size(105, 26)
    Me.Text_LaserHeight_D950.TabIndex = 100
    Me.Text_LaserHeight_D950.TabStop = False
    Me.Text_LaserHeight_D950.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Lab_Barcode_M1600
    '
    Me.Lab_Barcode_M1600.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_Barcode_M1600.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_Barcode_M1600.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_Barcode_M1600.Location = New System.Drawing.Point(41, 194)
    Me.Lab_Barcode_M1600.Name = "Lab_Barcode_M1600"
    Me.Lab_Barcode_M1600.Size = New System.Drawing.Size(105, 24)
    Me.Lab_Barcode_M1600.TabIndex = 95
    Me.Lab_Barcode_M1600.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label73
    '
    Me.Label73.AutoSize = True
    Me.Label73.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold)
    Me.Label73.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label73.Location = New System.Drawing.Point(8, -3)
    Me.Label73.Name = "Label73"
    Me.Label73.Size = New System.Drawing.Size(180, 26)
    Me.Label73.TabIndex = 99
    Me.Label73.Text = "伺服馬達目前位置"
    '
    'Label74
    '
    Me.Label74.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label74.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label74.Location = New System.Drawing.Point(50, 170)
    Me.Label74.Name = "Label74"
    Me.Label74.Size = New System.Drawing.Size(90, 24)
    Me.Label74.TabIndex = 96
    Me.Label74.Text = "讀碼區"
    Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label75
    '
    Me.Label75.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label75.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label75.Location = New System.Drawing.Point(50, 240)
    Me.Label75.Name = "Label75"
    Me.Label75.Size = New System.Drawing.Size(90, 24)
    Me.Label75.TabIndex = 98
    Me.Label75.Text = "待命區"
    Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Lab_Standby_M1602
    '
    Me.Lab_Standby_M1602.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_Standby_M1602.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_Standby_M1602.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_Standby_M1602.Location = New System.Drawing.Point(41, 264)
    Me.Lab_Standby_M1602.Name = "Lab_Standby_M1602"
    Me.Lab_Standby_M1602.Size = New System.Drawing.Size(105, 24)
    Me.Lab_Standby_M1602.TabIndex = 97
    Me.Lab_Standby_M1602.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.Label76)
    Me.GroupBox3.Controls.Add(Me.Lab_PlcReady_SM403)
    Me.GroupBox3.Controls.Add(Me.Label77)
    Me.GroupBox3.Controls.Add(Me.Label78)
    Me.GroupBox3.Controls.Add(Me.Lab_AoiReady_X33)
    Me.GroupBox3.Controls.Add(Me.Lab_HomeFinish_M1001)
    Me.GroupBox3.Controls.Add(Me.Label79)
    Me.GroupBox3.Controls.Add(Me.Label80)
    Me.GroupBox3.Controls.Add(Me.M1602_1)
    Me.GroupBox3.Location = New System.Drawing.Point(433, 30)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(160, 396)
    Me.GroupBox3.TabIndex = 139
    Me.GroupBox3.TabStop = False
    '
    'Label76
    '
    Me.Label76.AutoSize = True
    Me.Label76.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold)
    Me.Label76.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label76.Location = New System.Drawing.Point(29, -3)
    Me.Label76.Name = "Label76"
    Me.Label76.Size = New System.Drawing.Size(96, 26)
    Me.Label76.TabIndex = 110
    Me.Label76.Text = "運轉條件"
    '
    'Lab_PlcReady_SM403
    '
    Me.Lab_PlcReady_SM403.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_PlcReady_SM403.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Lab_PlcReady_SM403.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_PlcReady_SM403.Location = New System.Drawing.Point(18, 54)
    Me.Lab_PlcReady_SM403.Name = "Lab_PlcReady_SM403"
    Me.Lab_PlcReady_SM403.Size = New System.Drawing.Size(115, 24)
    Me.Lab_PlcReady_SM403.TabIndex = 102
    Me.Lab_PlcReady_SM403.Text = "                "
    '
    'Label77
    '
    Me.Label77.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label77.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label77.Location = New System.Drawing.Point(13, 30)
    Me.Label77.Name = "Label77"
    Me.Label77.Size = New System.Drawing.Size(126, 24)
    Me.Label77.TabIndex = 103
    Me.Label77.Text = "PLC Ready"
    Me.Label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label78
    '
    Me.Label78.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label78.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label78.Location = New System.Drawing.Point(13, 240)
    Me.Label78.Name = "Label78"
    Me.Label78.Size = New System.Drawing.Size(126, 24)
    Me.Label78.TabIndex = 109
    Me.Label78.Text = "伺服復歸完成"
    Me.Label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Lab_AoiReady_X33
    '
    Me.Lab_AoiReady_X33.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_AoiReady_X33.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Lab_AoiReady_X33.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_AoiReady_X33.Location = New System.Drawing.Point(18, 124)
    Me.Lab_AoiReady_X33.Name = "Lab_AoiReady_X33"
    Me.Lab_AoiReady_X33.Size = New System.Drawing.Size(115, 24)
    Me.Lab_AoiReady_X33.TabIndex = 104
    Me.Lab_AoiReady_X33.Text = "                "
    '
    'Lab_HomeFinish_M1001
    '
    Me.Lab_HomeFinish_M1001.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_HomeFinish_M1001.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Lab_HomeFinish_M1001.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_HomeFinish_M1001.Location = New System.Drawing.Point(18, 264)
    Me.Lab_HomeFinish_M1001.Name = "Lab_HomeFinish_M1001"
    Me.Lab_HomeFinish_M1001.Size = New System.Drawing.Size(115, 24)
    Me.Lab_HomeFinish_M1001.TabIndex = 108
    Me.Lab_HomeFinish_M1001.Text = "                "
    '
    'Label79
    '
    Me.Label79.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label79.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label79.Location = New System.Drawing.Point(13, 100)
    Me.Label79.Name = "Label79"
    Me.Label79.Size = New System.Drawing.Size(126, 24)
    Me.Label79.TabIndex = 105
    Me.Label79.Text = "AOI Ready"
    Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label80
    '
    Me.Label80.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label80.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label80.Location = New System.Drawing.Point(13, 170)
    Me.Label80.Name = "Label80"
    Me.Label80.Size = New System.Drawing.Size(126, 24)
    Me.Label80.TabIndex = 107
    Me.Label80.Text = "待命區"
    Me.Label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'M1602_1
    '
    Me.M1602_1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.M1602_1.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.M1602_1.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.M1602_1.Location = New System.Drawing.Point(18, 194)
    Me.M1602_1.Name = "M1602_1"
    Me.M1602_1.Size = New System.Drawing.Size(115, 24)
    Me.M1602_1.TabIndex = 106
    Me.M1602_1.Text = "                "
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.Label81)
    Me.GroupBox2.Controls.Add(Me.Label82)
    Me.GroupBox2.Controls.Add(Me.Btn_AlarmReset_M1300)
    Me.GroupBox2.Controls.Add(Me.Label83)
    Me.GroupBox2.Controls.Add(Me.L1012)
    Me.GroupBox2.Controls.Add(Me.Lab_LimitFront_L1001)
    Me.GroupBox2.Controls.Add(Me.Label84)
    Me.GroupBox2.Controls.Add(Me.Lab_LimitBack_L1000)
    Me.GroupBox2.Controls.Add(Me.Label85)
    Me.GroupBox2.Controls.Add(Me.Lab_ServoError_L1002)
    Me.GroupBox2.Controls.Add(Me.Label86)
    Me.GroupBox2.Controls.Add(Me.Lab_DriverError_L1003)
    Me.GroupBox2.Controls.Add(Me.Label87)
    Me.GroupBox2.Controls.Add(Me.Lab_VacuumError_L1004)
    Me.GroupBox2.Controls.Add(Me.Label88)
    Me.GroupBox2.Controls.Add(Me.Lab_SafeDoor1_L1005)
    Me.GroupBox2.Controls.Add(Me.Label89)
    Me.GroupBox2.Controls.Add(Me.Lab_SafeDoor2_L1006)
    Me.GroupBox2.Controls.Add(Me.Label90)
    Me.GroupBox2.Controls.Add(Me.Lab_SafeDoor3_L1007)
    Me.GroupBox2.Controls.Add(Me.Label91)
    Me.GroupBox2.Controls.Add(Me.L1008)
    Me.GroupBox2.Controls.Add(Me.Label92)
    Me.GroupBox2.Controls.Add(Me.Lab_BarcodeTimeout_L1009)
    Me.GroupBox2.Controls.Add(Me.Label93)
    Me.GroupBox2.Controls.Add(Me.Lab_CcdTimeout_L1010)
    Me.GroupBox2.Controls.Add(Me.Label94)
    Me.GroupBox2.Controls.Add(Me.L1011)
    Me.GroupBox2.Location = New System.Drawing.Point(629, 30)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(156, 396)
    Me.GroupBox2.TabIndex = 138
    Me.GroupBox2.TabStop = False
    '
    'Label81
    '
    Me.Label81.AutoSize = True
    Me.Label81.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label81.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label81.Location = New System.Drawing.Point(40, 36)
    Me.Label81.Name = "Label81"
    Me.Label81.Size = New System.Drawing.Size(68, 16)
    Me.Label81.TabIndex = 123
    Me.Label81.Text = "馬達前極限"
    '
    'Label82
    '
    Me.Label82.AutoSize = True
    Me.Label82.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold)
    Me.Label82.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label82.Location = New System.Drawing.Point(29, -3)
    Me.Label82.Name = "Label82"
    Me.Label82.Size = New System.Drawing.Size(96, 26)
    Me.Label82.TabIndex = 137
    Me.Label82.Text = "異常警報"
    '
    'Btn_AlarmReset_M1300
    '
    Me.Btn_AlarmReset_M1300.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Bold)
    Me.Btn_AlarmReset_M1300.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_AlarmReset_M1300.Location = New System.Drawing.Point(15, 339)
    Me.Btn_AlarmReset_M1300.Name = "Btn_AlarmReset_M1300"
    Me.Btn_AlarmReset_M1300.Size = New System.Drawing.Size(127, 37)
    Me.Btn_AlarmReset_M1300.TabIndex = 89
    Me.Btn_AlarmReset_M1300.Text = "異常復歸"
    Me.Btn_AlarmReset_M1300.UseVisualStyleBackColor = True
    '
    'Label83
    '
    Me.Label83.AutoSize = True
    Me.Label83.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label83.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label83.Location = New System.Drawing.Point(40, 301)
    Me.Label83.Name = "Label83"
    Me.Label83.Size = New System.Drawing.Size(22, 16)
    Me.Label83.TabIndex = 136
    Me.Label83.Text = "SP"
    '
    'L1012
    '
    Me.L1012.AutoSize = True
    Me.L1012.BackColor = System.Drawing.Color.WhiteSmoke
    Me.L1012.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.L1012.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.L1012.Location = New System.Drawing.Point(17, 300)
    Me.L1012.Name = "L1012"
    Me.L1012.Size = New System.Drawing.Size(17, 17)
    Me.L1012.TabIndex = 135
    Me.L1012.Text = "   "
    '
    'Lab_LimitFront_L1001
    '
    Me.Lab_LimitFront_L1001.AutoSize = True
    Me.Lab_LimitFront_L1001.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_LimitFront_L1001.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_LimitFront_L1001.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_LimitFront_L1001.Location = New System.Drawing.Point(17, 35)
    Me.Lab_LimitFront_L1001.Name = "Lab_LimitFront_L1001"
    Me.Lab_LimitFront_L1001.Size = New System.Drawing.Size(17, 17)
    Me.Lab_LimitFront_L1001.TabIndex = 111
    Me.Lab_LimitFront_L1001.Text = "   "
    '
    'Label84
    '
    Me.Label84.AutoSize = True
    Me.Label84.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label84.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label84.Location = New System.Drawing.Point(40, 278)
    Me.Label84.Name = "Label84"
    Me.Label84.Size = New System.Drawing.Size(22, 16)
    Me.Label84.TabIndex = 134
    Me.Label84.Text = "SP"
    '
    'Lab_LimitBack_L1000
    '
    Me.Lab_LimitBack_L1000.AutoSize = True
    Me.Lab_LimitBack_L1000.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_LimitBack_L1000.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_LimitBack_L1000.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_LimitBack_L1000.Location = New System.Drawing.Point(17, 57)
    Me.Lab_LimitBack_L1000.Name = "Lab_LimitBack_L1000"
    Me.Lab_LimitBack_L1000.Size = New System.Drawing.Size(17, 17)
    Me.Lab_LimitBack_L1000.TabIndex = 112
    Me.Lab_LimitBack_L1000.Text = "   "
    '
    'Label85
    '
    Me.Label85.AutoSize = True
    Me.Label85.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label85.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label85.Location = New System.Drawing.Point(40, 256)
    Me.Label85.Name = "Label85"
    Me.Label85.Size = New System.Drawing.Size(57, 16)
    Me.Label85.TabIndex = 133
    Me.Label85.Text = "CCD逾時"
    '
    'Lab_ServoError_L1002
    '
    Me.Lab_ServoError_L1002.AutoSize = True
    Me.Lab_ServoError_L1002.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_ServoError_L1002.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_ServoError_L1002.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_ServoError_L1002.Location = New System.Drawing.Point(17, 79)
    Me.Lab_ServoError_L1002.Name = "Lab_ServoError_L1002"
    Me.Lab_ServoError_L1002.Size = New System.Drawing.Size(17, 17)
    Me.Lab_ServoError_L1002.TabIndex = 113
    Me.Lab_ServoError_L1002.Text = "   "
    '
    'Label86
    '
    Me.Label86.AutoSize = True
    Me.Label86.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label86.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label86.Location = New System.Drawing.Point(40, 234)
    Me.Label86.Name = "Label86"
    Me.Label86.Size = New System.Drawing.Size(68, 16)
    Me.Label86.TabIndex = 132
    Me.Label86.Text = "掃描器逾時"
    '
    'Lab_DriverError_L1003
    '
    Me.Lab_DriverError_L1003.AutoSize = True
    Me.Lab_DriverError_L1003.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_DriverError_L1003.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_DriverError_L1003.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_DriverError_L1003.Location = New System.Drawing.Point(17, 101)
    Me.Lab_DriverError_L1003.Name = "Lab_DriverError_L1003"
    Me.Lab_DriverError_L1003.Size = New System.Drawing.Size(17, 17)
    Me.Lab_DriverError_L1003.TabIndex = 114
    Me.Lab_DriverError_L1003.Text = "   "
    '
    'Label87
    '
    Me.Label87.AutoSize = True
    Me.Label87.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label87.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label87.Location = New System.Drawing.Point(40, 211)
    Me.Label87.Name = "Label87"
    Me.Label87.Size = New System.Drawing.Size(22, 16)
    Me.Label87.TabIndex = 131
    Me.Label87.Text = "SP"
    '
    'Lab_VacuumError_L1004
    '
    Me.Lab_VacuumError_L1004.AutoSize = True
    Me.Lab_VacuumError_L1004.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_VacuumError_L1004.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_VacuumError_L1004.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_VacuumError_L1004.Location = New System.Drawing.Point(17, 123)
    Me.Lab_VacuumError_L1004.Name = "Lab_VacuumError_L1004"
    Me.Lab_VacuumError_L1004.Size = New System.Drawing.Size(17, 17)
    Me.Lab_VacuumError_L1004.TabIndex = 115
    Me.Lab_VacuumError_L1004.Text = "   "
    '
    'Label88
    '
    Me.Label88.AutoSize = True
    Me.Label88.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label88.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label88.Location = New System.Drawing.Point(40, 190)
    Me.Label88.Name = "Label88"
    Me.Label88.Size = New System.Drawing.Size(47, 16)
    Me.Label88.TabIndex = 130
    Me.Label88.Text = "門檢(3)"
    '
    'Lab_SafeDoor1_L1005
    '
    Me.Lab_SafeDoor1_L1005.AutoSize = True
    Me.Lab_SafeDoor1_L1005.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_SafeDoor1_L1005.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_SafeDoor1_L1005.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_SafeDoor1_L1005.Location = New System.Drawing.Point(17, 145)
    Me.Lab_SafeDoor1_L1005.Name = "Lab_SafeDoor1_L1005"
    Me.Lab_SafeDoor1_L1005.Size = New System.Drawing.Size(17, 17)
    Me.Lab_SafeDoor1_L1005.TabIndex = 116
    Me.Lab_SafeDoor1_L1005.Text = "   "
    '
    'Label89
    '
    Me.Label89.AutoSize = True
    Me.Label89.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label89.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label89.Location = New System.Drawing.Point(40, 168)
    Me.Label89.Name = "Label89"
    Me.Label89.Size = New System.Drawing.Size(47, 16)
    Me.Label89.TabIndex = 129
    Me.Label89.Text = "門檢(2)"
    '
    'Lab_SafeDoor2_L1006
    '
    Me.Lab_SafeDoor2_L1006.AutoSize = True
    Me.Lab_SafeDoor2_L1006.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_SafeDoor2_L1006.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_SafeDoor2_L1006.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_SafeDoor2_L1006.Location = New System.Drawing.Point(17, 167)
    Me.Lab_SafeDoor2_L1006.Name = "Lab_SafeDoor2_L1006"
    Me.Lab_SafeDoor2_L1006.Size = New System.Drawing.Size(17, 17)
    Me.Lab_SafeDoor2_L1006.TabIndex = 117
    Me.Lab_SafeDoor2_L1006.Text = "   "
    '
    'Label90
    '
    Me.Label90.AutoSize = True
    Me.Label90.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label90.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label90.Location = New System.Drawing.Point(40, 146)
    Me.Label90.Name = "Label90"
    Me.Label90.Size = New System.Drawing.Size(47, 16)
    Me.Label90.TabIndex = 128
    Me.Label90.Text = "門檢(1)"
    '
    'Lab_SafeDoor3_L1007
    '
    Me.Lab_SafeDoor3_L1007.AutoSize = True
    Me.Lab_SafeDoor3_L1007.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_SafeDoor3_L1007.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_SafeDoor3_L1007.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_SafeDoor3_L1007.Location = New System.Drawing.Point(17, 189)
    Me.Lab_SafeDoor3_L1007.Name = "Lab_SafeDoor3_L1007"
    Me.Lab_SafeDoor3_L1007.Size = New System.Drawing.Size(17, 17)
    Me.Lab_SafeDoor3_L1007.TabIndex = 118
    Me.Lab_SafeDoor3_L1007.Text = "   "
    '
    'Label91
    '
    Me.Label91.AutoSize = True
    Me.Label91.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label91.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label91.Location = New System.Drawing.Point(40, 124)
    Me.Label91.Name = "Label91"
    Me.Label91.Size = New System.Drawing.Size(56, 16)
    Me.Label91.TabIndex = 127
    Me.Label91.Text = "真空異常"
    '
    'L1008
    '
    Me.L1008.AutoSize = True
    Me.L1008.BackColor = System.Drawing.Color.WhiteSmoke
    Me.L1008.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.L1008.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.L1008.Location = New System.Drawing.Point(17, 211)
    Me.L1008.Name = "L1008"
    Me.L1008.Size = New System.Drawing.Size(17, 17)
    Me.L1008.TabIndex = 119
    Me.L1008.Text = "   "
    '
    'Label92
    '
    Me.Label92.AutoSize = True
    Me.Label92.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label92.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label92.Location = New System.Drawing.Point(40, 103)
    Me.Label92.Name = "Label92"
    Me.Label92.Size = New System.Drawing.Size(92, 16)
    Me.Label92.TabIndex = 126
    Me.Label92.Text = "伺服驅動器異常"
    '
    'Lab_BarcodeTimeout_L1009
    '
    Me.Lab_BarcodeTimeout_L1009.AutoSize = True
    Me.Lab_BarcodeTimeout_L1009.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_BarcodeTimeout_L1009.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_BarcodeTimeout_L1009.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_BarcodeTimeout_L1009.Location = New System.Drawing.Point(17, 233)
    Me.Lab_BarcodeTimeout_L1009.Name = "Lab_BarcodeTimeout_L1009"
    Me.Lab_BarcodeTimeout_L1009.Size = New System.Drawing.Size(17, 17)
    Me.Lab_BarcodeTimeout_L1009.TabIndex = 120
    Me.Lab_BarcodeTimeout_L1009.Text = "   "
    '
    'Label93
    '
    Me.Label93.AutoSize = True
    Me.Label93.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label93.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label93.Location = New System.Drawing.Point(40, 80)
    Me.Label93.Name = "Label93"
    Me.Label93.Size = New System.Drawing.Size(80, 16)
    Me.Label93.TabIndex = 125
    Me.Label93.Text = "伺服馬達異常"
    '
    'Lab_CcdTimeout_L1010
    '
    Me.Lab_CcdTimeout_L1010.AutoSize = True
    Me.Lab_CcdTimeout_L1010.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_CcdTimeout_L1010.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Lab_CcdTimeout_L1010.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_CcdTimeout_L1010.Location = New System.Drawing.Point(17, 255)
    Me.Lab_CcdTimeout_L1010.Name = "Lab_CcdTimeout_L1010"
    Me.Lab_CcdTimeout_L1010.Size = New System.Drawing.Size(17, 17)
    Me.Lab_CcdTimeout_L1010.TabIndex = 121
    Me.Lab_CcdTimeout_L1010.Text = "   "
    '
    'Label94
    '
    Me.Label94.AutoSize = True
    Me.Label94.Font = New System.Drawing.Font("微軟正黑體", 9.0!)
    Me.Label94.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label94.Location = New System.Drawing.Point(40, 58)
    Me.Label94.Name = "Label94"
    Me.Label94.Size = New System.Drawing.Size(68, 16)
    Me.Label94.TabIndex = 124
    Me.Label94.Text = "馬達後極限"
    '
    'L1011
    '
    Me.L1011.AutoSize = True
    Me.L1011.BackColor = System.Drawing.Color.WhiteSmoke
    Me.L1011.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.L1011.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.L1011.Location = New System.Drawing.Point(17, 277)
    Me.L1011.Name = "L1011"
    Me.L1011.Size = New System.Drawing.Size(17, 17)
    Me.L1011.TabIndex = 122
    Me.L1011.Text = "   "
    '
    'TabPage2
    '
    Me.TabPage2.BackColor = System.Drawing.Color.Silver
    Me.TabPage2.Controls.Add(Me.GroupBox16)
    Me.TabPage2.Controls.Add(Me.GroupBox15)
    Me.TabPage2.Controls.Add(Me.GroupBox14)
    Me.TabPage2.Controls.Add(Me.GroupBox13)
    Me.TabPage2.Controls.Add(Me.GroupVacuum)
    Me.TabPage2.Controls.Add(Me.GroupBox11)
    Me.TabPage2.Controls.Add(Me.GroupBox10)
    Me.TabPage2.Controls.Add(Me.GroupBox9)
    Me.TabPage2.Controls.Add(Me.GroupBox8)
    Me.TabPage2.Controls.Add(Me.GroupBox7)
    Me.TabPage2.Controls.Add(Me.GroupBox6)
    Me.TabPage2.Controls.Add(Me.GroupBox12)
    Me.TabPage2.Controls.Add(Me.Label112)
    Me.TabPage2.Location = New System.Drawing.Point(4, 28)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(826, 441)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "Manual"
    '
    'GroupBox16
    '
    Me.GroupBox16.Controls.Add(Me.Text_StandbyPosition_D1120)
    Me.GroupBox16.Controls.Add(Me.Label95)
    Me.GroupBox16.Controls.Add(Me.Lab_Standby_M1602_2)
    Me.GroupBox16.Controls.Add(Me.Btn_StandbyPositionMove_M1154)
    Me.GroupBox16.Controls.Add(Me.Btn_StandbyPositionSet_M1202)
    Me.GroupBox16.Location = New System.Drawing.Point(549, 214)
    Me.GroupBox16.Name = "GroupBox16"
    Me.GroupBox16.Size = New System.Drawing.Size(220, 100)
    Me.GroupBox16.TabIndex = 136
    Me.GroupBox16.TabStop = False
    '
    'Text_StandbyPosition_D1120
    '
    Me.Text_StandbyPosition_D1120.AcceptsReturn = True
    Me.Text_StandbyPosition_D1120.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Text_StandbyPosition_D1120.Location = New System.Drawing.Point(111, 64)
    Me.Text_StandbyPosition_D1120.Name = "Text_StandbyPosition_D1120"
    Me.Text_StandbyPosition_D1120.ReadOnly = True
    Me.Text_StandbyPosition_D1120.Size = New System.Drawing.Size(99, 26)
    Me.Text_StandbyPosition_D1120.TabIndex = 137
    Me.Text_StandbyPosition_D1120.TabStop = False
    Me.Text_StandbyPosition_D1120.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label95
    '
    Me.Label95.AutoSize = True
    Me.Label95.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label95.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label95.Location = New System.Drawing.Point(72, -3)
    Me.Label95.Name = "Label95"
    Me.Label95.Size = New System.Drawing.Size(67, 24)
    Me.Label95.TabIndex = 137
    Me.Label95.Text = "待命區"
    '
    'Lab_Standby_M1602_2
    '
    Me.Lab_Standby_M1602_2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_Standby_M1602_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_Standby_M1602_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_Standby_M1602_2.Location = New System.Drawing.Point(111, 32)
    Me.Lab_Standby_M1602_2.Name = "Lab_Standby_M1602_2"
    Me.Lab_Standby_M1602_2.Size = New System.Drawing.Size(99, 22)
    Me.Lab_Standby_M1602_2.TabIndex = 135
    Me.Lab_Standby_M1602_2.Text = "                     "
    Me.Lab_Standby_M1602_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_StandbyPositionMove_M1154
    '
    Me.Btn_StandbyPositionMove_M1154.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_StandbyPositionMove_M1154.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_StandbyPositionMove_M1154.Location = New System.Drawing.Point(19, 27)
    Me.Btn_StandbyPositionMove_M1154.Name = "Btn_StandbyPositionMove_M1154"
    Me.Btn_StandbyPositionMove_M1154.Size = New System.Drawing.Size(86, 31)
    Me.Btn_StandbyPositionMove_M1154.TabIndex = 134
    Me.Btn_StandbyPositionMove_M1154.Text = "移動"
    Me.Btn_StandbyPositionMove_M1154.UseVisualStyleBackColor = True
    '
    'Btn_StandbyPositionSet_M1202
    '
    Me.Btn_StandbyPositionSet_M1202.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_StandbyPositionSet_M1202.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_StandbyPositionSet_M1202.Location = New System.Drawing.Point(19, 60)
    Me.Btn_StandbyPositionSet_M1202.Name = "Btn_StandbyPositionSet_M1202"
    Me.Btn_StandbyPositionSet_M1202.Size = New System.Drawing.Size(86, 31)
    Me.Btn_StandbyPositionSet_M1202.TabIndex = 133
    Me.Btn_StandbyPositionSet_M1202.Text = "寫入位置"
    Me.Btn_StandbyPositionSet_M1202.UseVisualStyleBackColor = True
    '
    'GroupBox15
    '
    Me.GroupBox15.Controls.Add(Me.Label96)
    Me.GroupBox15.Controls.Add(Me.Lab_Barcode_M1600_2)
    Me.GroupBox15.Controls.Add(Me.Btn_BarcodePositionMove_M1152)
    Me.GroupBox15.Controls.Add(Me.Btn_BarcodePositionSet_M1200)
    Me.GroupBox15.Controls.Add(Me.Text_BarcodePosition_D1100)
    Me.GroupBox15.Location = New System.Drawing.Point(549, 108)
    Me.GroupBox15.Name = "GroupBox15"
    Me.GroupBox15.Size = New System.Drawing.Size(220, 100)
    Me.GroupBox15.TabIndex = 136
    Me.GroupBox15.TabStop = False
    '
    'Label96
    '
    Me.Label96.AutoSize = True
    Me.Label96.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label96.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label96.Location = New System.Drawing.Point(72, -3)
    Me.Label96.Name = "Label96"
    Me.Label96.Size = New System.Drawing.Size(67, 24)
    Me.Label96.TabIndex = 136
    Me.Label96.Text = "掃碼區"
    '
    'Lab_Barcode_M1600_2
    '
    Me.Lab_Barcode_M1600_2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_Barcode_M1600_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_Barcode_M1600_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_Barcode_M1600_2.Location = New System.Drawing.Point(111, 32)
    Me.Lab_Barcode_M1600_2.Name = "Lab_Barcode_M1600_2"
    Me.Lab_Barcode_M1600_2.Size = New System.Drawing.Size(99, 22)
    Me.Lab_Barcode_M1600_2.TabIndex = 135
    Me.Lab_Barcode_M1600_2.Text = "                     "
    Me.Lab_Barcode_M1600_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_BarcodePositionMove_M1152
    '
    Me.Btn_BarcodePositionMove_M1152.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_BarcodePositionMove_M1152.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_BarcodePositionMove_M1152.Location = New System.Drawing.Point(19, 27)
    Me.Btn_BarcodePositionMove_M1152.Name = "Btn_BarcodePositionMove_M1152"
    Me.Btn_BarcodePositionMove_M1152.Size = New System.Drawing.Size(86, 31)
    Me.Btn_BarcodePositionMove_M1152.TabIndex = 134
    Me.Btn_BarcodePositionMove_M1152.Text = "移動"
    Me.Btn_BarcodePositionMove_M1152.UseVisualStyleBackColor = True
    '
    'Btn_BarcodePositionSet_M1200
    '
    Me.Btn_BarcodePositionSet_M1200.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_BarcodePositionSet_M1200.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_BarcodePositionSet_M1200.Location = New System.Drawing.Point(19, 60)
    Me.Btn_BarcodePositionSet_M1200.Name = "Btn_BarcodePositionSet_M1200"
    Me.Btn_BarcodePositionSet_M1200.Size = New System.Drawing.Size(86, 31)
    Me.Btn_BarcodePositionSet_M1200.TabIndex = 133
    Me.Btn_BarcodePositionSet_M1200.Text = "寫入位置"
    Me.Btn_BarcodePositionSet_M1200.UseVisualStyleBackColor = True
    '
    'Text_BarcodePosition_D1100
    '
    Me.Text_BarcodePosition_D1100.AcceptsReturn = True
    Me.Text_BarcodePosition_D1100.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Text_BarcodePosition_D1100.Location = New System.Drawing.Point(111, 65)
    Me.Text_BarcodePosition_D1100.MaxLength = 3276700
    Me.Text_BarcodePosition_D1100.Name = "Text_BarcodePosition_D1100"
    Me.Text_BarcodePosition_D1100.ReadOnly = True
    Me.Text_BarcodePosition_D1100.Size = New System.Drawing.Size(99, 26)
    Me.Text_BarcodePosition_D1100.TabIndex = 113
    Me.Text_BarcodePosition_D1100.TabStop = False
    Me.Text_BarcodePosition_D1100.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'GroupBox14
    '
    Me.GroupBox14.Controls.Add(Me.Lab_HomeFinish_M1002)
    Me.GroupBox14.Controls.Add(Me.Label97)
    Me.GroupBox14.Controls.Add(Me.Btn_Home_M1000)
    Me.GroupBox14.Location = New System.Drawing.Point(413, 2)
    Me.GroupBox14.Name = "GroupBox14"
    Me.GroupBox14.Size = New System.Drawing.Size(130, 100)
    Me.GroupBox14.TabIndex = 131
    Me.GroupBox14.TabStop = False
    '
    'Lab_HomeFinish_M1002
    '
    Me.Lab_HomeFinish_M1002.BackColor = System.Drawing.Color.Honeydew
    Me.Lab_HomeFinish_M1002.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_HomeFinish_M1002.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_HomeFinish_M1002.Location = New System.Drawing.Point(21, 71)
    Me.Lab_HomeFinish_M1002.Name = "Lab_HomeFinish_M1002"
    Me.Lab_HomeFinish_M1002.Size = New System.Drawing.Size(90, 24)
    Me.Lab_HomeFinish_M1002.TabIndex = 107
    Me.Lab_HomeFinish_M1002.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label97
    '
    Me.Label97.AutoSize = True
    Me.Label97.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label97.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label97.Location = New System.Drawing.Point(23, 12)
    Me.Label97.Name = "Label97"
    Me.Label97.Size = New System.Drawing.Size(86, 24)
    Me.Label97.TabIndex = 133
    Me.Label97.Text = "原點復歸"
    '
    'Btn_Home_M1000
    '
    Me.Btn_Home_M1000.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_Home_M1000.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_Home_M1000.Location = New System.Drawing.Point(23, 38)
    Me.Btn_Home_M1000.Name = "Btn_Home_M1000"
    Me.Btn_Home_M1000.Size = New System.Drawing.Size(86, 31)
    Me.Btn_Home_M1000.TabIndex = 132
    Me.Btn_Home_M1000.Text = "復歸"
    Me.Btn_Home_M1000.UseVisualStyleBackColor = True
    '
    'GroupBox13
    '
    Me.GroupBox13.Controls.Add(Me.Label98)
    Me.GroupBox13.Controls.Add(Me.Text_NowPosition_D1090)
    Me.GroupBox13.Location = New System.Drawing.Point(277, 2)
    Me.GroupBox13.Name = "GroupBox13"
    Me.GroupBox13.Size = New System.Drawing.Size(130, 100)
    Me.GroupBox13.TabIndex = 130
    Me.GroupBox13.TabStop = False
    '
    'Label98
    '
    Me.Label98.AutoSize = True
    Me.Label98.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Label98.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label98.Location = New System.Drawing.Point(13, 18)
    Me.Label98.Name = "Label98"
    Me.Label98.Size = New System.Drawing.Size(103, 40)
    Me.Label98.TabIndex = 113
    Me.Label98.Text = "伺服馬達" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "現在位置mm"
    Me.Label98.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Text_NowPosition_D1090
    '
    Me.Text_NowPosition_D1090.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Text_NowPosition_D1090.Location = New System.Drawing.Point(17, 61)
    Me.Text_NowPosition_D1090.Name = "Text_NowPosition_D1090"
    Me.Text_NowPosition_D1090.ReadOnly = True
    Me.Text_NowPosition_D1090.Size = New System.Drawing.Size(99, 26)
    Me.Text_NowPosition_D1090.TabIndex = 112
    Me.Text_NowPosition_D1090.TabStop = False
    Me.Text_NowPosition_D1090.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'GroupVacuum
    '
    Me.GroupVacuum.Controls.Add(Me.Label100)
    Me.GroupVacuum.Controls.Add(Me.Lab_Vacuum_X2B_2)
    Me.GroupVacuum.Controls.Add(Me.Btn_VacuumOnOff_M1912)
    Me.GroupVacuum.Location = New System.Drawing.Point(141, 2)
    Me.GroupVacuum.Name = "GroupVacuum"
    Me.GroupVacuum.Size = New System.Drawing.Size(130, 100)
    Me.GroupVacuum.TabIndex = 130
    Me.GroupVacuum.TabStop = False
    '
    'Label100
    '
    Me.Label100.AutoSize = True
    Me.Label100.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label100.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label100.Location = New System.Drawing.Point(27, -3)
    Me.Label100.Name = "Label100"
    Me.Label100.Size = New System.Drawing.Size(84, 24)
    Me.Label100.TabIndex = 106
    Me.Label100.Text = "Vacuum"
    '
    'Lab_Vacuum_X2B_2
    '
    Me.Lab_Vacuum_X2B_2.BackColor = System.Drawing.Color.Honeydew
    Me.Lab_Vacuum_X2B_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_Vacuum_X2B_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_Vacuum_X2B_2.Location = New System.Drawing.Point(21, 63)
    Me.Lab_Vacuum_X2B_2.Name = "Lab_Vacuum_X2B_2"
    Me.Lab_Vacuum_X2B_2.Size = New System.Drawing.Size(90, 24)
    Me.Lab_Vacuum_X2B_2.TabIndex = 104
    Me.Lab_Vacuum_X2B_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_VacuumOnOff_M1912
    '
    Me.Btn_VacuumOnOff_M1912.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_VacuumOnOff_M1912.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_VacuumOnOff_M1912.Location = New System.Drawing.Point(23, 20)
    Me.Btn_VacuumOnOff_M1912.Name = "Btn_VacuumOnOff_M1912"
    Me.Btn_VacuumOnOff_M1912.Size = New System.Drawing.Size(86, 31)
    Me.Btn_VacuumOnOff_M1912.TabIndex = 105
    Me.Btn_VacuumOnOff_M1912.Text = "On/Off"
    Me.Btn_VacuumOnOff_M1912.UseVisualStyleBackColor = True
    '
    'GroupBox11
    '
    Me.GroupBox11.Controls.Add(Me.Lab_MoveSpeed_D1030)
    Me.GroupBox11.Controls.Add(Me.Label101)
    Me.GroupBox11.Controls.Add(Me.Lab_MoveSpeedSet_D1030)
    Me.GroupBox11.Controls.Add(Me.Label102)
    Me.GroupBox11.Controls.Add(Me.Btn_MoveSpeedSet_D1030)
    Me.GroupBox11.Location = New System.Drawing.Point(141, 108)
    Me.GroupBox11.Name = "GroupBox11"
    Me.GroupBox11.Size = New System.Drawing.Size(130, 143)
    Me.GroupBox11.TabIndex = 130
    Me.GroupBox11.TabStop = False
    '
    'Lab_MoveSpeed_D1030
    '
    Me.Lab_MoveSpeed_D1030.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.Lab_MoveSpeed_D1030.Location = New System.Drawing.Point(23, 21)
    Me.Lab_MoveSpeed_D1030.Name = "Lab_MoveSpeed_D1030"
    Me.Lab_MoveSpeed_D1030.ReadOnly = True
    Me.Lab_MoveSpeed_D1030.Size = New System.Drawing.Size(86, 22)
    Me.Lab_MoveSpeed_D1030.TabIndex = 107
    Me.Lab_MoveSpeed_D1030.TabStop = False
    Me.Lab_MoveSpeed_D1030.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label101
    '
    Me.Label101.AutoSize = True
    Me.Label101.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Label101.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label101.Location = New System.Drawing.Point(13, -1)
    Me.Label101.Name = "Label101"
    Me.Label101.Size = New System.Drawing.Size(105, 20)
    Me.Label101.TabIndex = 108
    Me.Label101.Text = "目前自動速度"
    Me.Label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Lab_MoveSpeedSet_D1030
    '
    Me.Lab_MoveSpeedSet_D1030.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.Lab_MoveSpeedSet_D1030.Location = New System.Drawing.Point(23, 80)
    Me.Lab_MoveSpeedSet_D1030.MaxLength = 2
    Me.Lab_MoveSpeedSet_D1030.Name = "Lab_MoveSpeedSet_D1030"
    Me.Lab_MoveSpeedSet_D1030.Size = New System.Drawing.Size(86, 22)
    Me.Lab_MoveSpeedSet_D1030.TabIndex = 109
    Me.Lab_MoveSpeedSet_D1030.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label102
    '
    Me.Label102.AutoSize = True
    Me.Label102.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Label102.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label102.Location = New System.Drawing.Point(20, 43)
    Me.Label102.Name = "Label102"
    Me.Label102.Size = New System.Drawing.Size(86, 34)
    Me.Label102.TabIndex = 110
    Me.Label102.Text = "自動速度設置" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "min:1 max:2"
    Me.Label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_MoveSpeedSet_D1030
    '
    Me.Btn_MoveSpeedSet_D1030.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Btn_MoveSpeedSet_D1030.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_MoveSpeedSet_D1030.Location = New System.Drawing.Point(35, 105)
    Me.Btn_MoveSpeedSet_D1030.Name = "Btn_MoveSpeedSet_D1030"
    Me.Btn_MoveSpeedSet_D1030.Size = New System.Drawing.Size(59, 31)
    Me.Btn_MoveSpeedSet_D1030.TabIndex = 111
    Me.Btn_MoveSpeedSet_D1030.Text = "OK"
    Me.Btn_MoveSpeedSet_D1030.UseVisualStyleBackColor = True
    '
    'GroupBox10
    '
    Me.GroupBox10.Controls.Add(Me.Label103)
    Me.GroupBox10.Controls.Add(Me.Text_TriggerDelay_D3010)
    Me.GroupBox10.Controls.Add(Me.Text_TriggerDelaySet_D3010)
    Me.GroupBox10.Controls.Add(Me.Label104)
    Me.GroupBox10.Controls.Add(Me.Btn_TriggerDelaySet_D3010)
    Me.GroupBox10.Location = New System.Drawing.Point(5, 257)
    Me.GroupBox10.Name = "GroupBox10"
    Me.GroupBox10.Size = New System.Drawing.Size(130, 166)
    Me.GroupBox10.TabIndex = 129
    Me.GroupBox10.TabStop = False
    '
    'Label103
    '
    Me.Label103.AutoSize = True
    Me.Label103.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Label103.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label103.Location = New System.Drawing.Point(22, 12)
    Me.Label103.Name = "Label103"
    Me.Label103.Size = New System.Drawing.Size(86, 34)
    Me.Label103.TabIndex = 100
    Me.Label103.Text = "Trigger" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "延遲時間(ms)"
    Me.Label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Text_TriggerDelay_D3010
    '
    Me.Text_TriggerDelay_D3010.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.Text_TriggerDelay_D3010.Location = New System.Drawing.Point(22, 47)
    Me.Text_TriggerDelay_D3010.Name = "Text_TriggerDelay_D3010"
    Me.Text_TriggerDelay_D3010.ReadOnly = True
    Me.Text_TriggerDelay_D3010.Size = New System.Drawing.Size(86, 22)
    Me.Text_TriggerDelay_D3010.TabIndex = 99
    Me.Text_TriggerDelay_D3010.TabStop = False
    Me.Text_TriggerDelay_D3010.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Text_TriggerDelaySet_D3010
    '
    Me.Text_TriggerDelaySet_D3010.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.Text_TriggerDelaySet_D3010.Location = New System.Drawing.Point(22, 103)
    Me.Text_TriggerDelaySet_D3010.Name = "Text_TriggerDelaySet_D3010"
    Me.Text_TriggerDelaySet_D3010.Size = New System.Drawing.Size(86, 22)
    Me.Text_TriggerDelaySet_D3010.TabIndex = 101
    Me.Text_TriggerDelaySet_D3010.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label104
    '
    Me.Label104.AutoSize = True
    Me.Label104.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Label104.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label104.Location = New System.Drawing.Point(9, 69)
    Me.Label104.Name = "Label104"
    Me.Label104.Size = New System.Drawing.Size(112, 34)
    Me.Label104.TabIndex = 102
    Me.Label104.Text = "Trigger" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "延遲時間設置(ms)"
    Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_TriggerDelaySet_D3010
    '
    Me.Btn_TriggerDelaySet_D3010.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Btn_TriggerDelaySet_D3010.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_TriggerDelaySet_D3010.Location = New System.Drawing.Point(34, 131)
    Me.Btn_TriggerDelaySet_D3010.Name = "Btn_TriggerDelaySet_D3010"
    Me.Btn_TriggerDelaySet_D3010.Size = New System.Drawing.Size(59, 31)
    Me.Btn_TriggerDelaySet_D3010.TabIndex = 103
    Me.Btn_TriggerDelaySet_D3010.Text = "OK"
    Me.Btn_TriggerDelaySet_D3010.UseVisualStyleBackColor = True
    '
    'GroupBox9
    '
    Me.GroupBox9.Controls.Add(Me.Label105)
    Me.GroupBox9.Controls.Add(Me.Lab_Search__M1601_2)
    Me.GroupBox9.Controls.Add(Me.Btn_SearchPositionMove_M1153)
    Me.GroupBox9.Controls.Add(Me.Btn_SearchPositionSet_M1201)
    Me.GroupBox9.Controls.Add(Me.Text_SearchPosition_D1110)
    Me.GroupBox9.Location = New System.Drawing.Point(549, 2)
    Me.GroupBox9.Name = "GroupBox9"
    Me.GroupBox9.Size = New System.Drawing.Size(220, 100)
    Me.GroupBox9.TabIndex = 129
    Me.GroupBox9.TabStop = False
    '
    'Label105
    '
    Me.Label105.AutoSize = True
    Me.Label105.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label105.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label105.Location = New System.Drawing.Point(72, -3)
    Me.Label105.Name = "Label105"
    Me.Label105.Size = New System.Drawing.Size(67, 24)
    Me.Label105.TabIndex = 134
    Me.Label105.Text = "檢測區"
    '
    'Lab_Search__M1601_2
    '
    Me.Lab_Search__M1601_2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Lab_Search__M1601_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_Search__M1601_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_Search__M1601_2.Location = New System.Drawing.Point(111, 32)
    Me.Lab_Search__M1601_2.Name = "Lab_Search__M1601_2"
    Me.Lab_Search__M1601_2.Size = New System.Drawing.Size(99, 22)
    Me.Lab_Search__M1601_2.TabIndex = 135
    Me.Lab_Search__M1601_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_SearchPositionMove_M1153
    '
    Me.Btn_SearchPositionMove_M1153.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_SearchPositionMove_M1153.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_SearchPositionMove_M1153.Location = New System.Drawing.Point(19, 27)
    Me.Btn_SearchPositionMove_M1153.Name = "Btn_SearchPositionMove_M1153"
    Me.Btn_SearchPositionMove_M1153.Size = New System.Drawing.Size(86, 31)
    Me.Btn_SearchPositionMove_M1153.TabIndex = 134
    Me.Btn_SearchPositionMove_M1153.Text = "移動"
    Me.Btn_SearchPositionMove_M1153.UseVisualStyleBackColor = True
    '
    'Btn_SearchPositionSet_M1201
    '
    Me.Btn_SearchPositionSet_M1201.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_SearchPositionSet_M1201.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_SearchPositionSet_M1201.Location = New System.Drawing.Point(19, 60)
    Me.Btn_SearchPositionSet_M1201.Name = "Btn_SearchPositionSet_M1201"
    Me.Btn_SearchPositionSet_M1201.Size = New System.Drawing.Size(86, 31)
    Me.Btn_SearchPositionSet_M1201.TabIndex = 133
    Me.Btn_SearchPositionSet_M1201.Text = "寫入位置"
    Me.Btn_SearchPositionSet_M1201.UseVisualStyleBackColor = True
    '
    'Text_SearchPosition_D1110
    '
    Me.Text_SearchPosition_D1110.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Text_SearchPosition_D1110.Location = New System.Drawing.Point(111, 65)
    Me.Text_SearchPosition_D1110.Name = "Text_SearchPosition_D1110"
    Me.Text_SearchPosition_D1110.ReadOnly = True
    Me.Text_SearchPosition_D1110.Size = New System.Drawing.Size(99, 26)
    Me.Text_SearchPosition_D1110.TabIndex = 113
    Me.Text_SearchPosition_D1110.TabStop = False
    Me.Text_SearchPosition_D1110.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.Label106)
    Me.GroupBox8.Controls.Add(Me.Label107)
    Me.GroupBox8.Controls.Add(Me.Lab_SearchResult_M1408_2)
    Me.GroupBox8.Controls.Add(Me.Btn_ReaderTrigger_M1900)
    Me.GroupBox8.Location = New System.Drawing.Point(5, 108)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(130, 143)
    Me.GroupBox8.TabIndex = 129
    Me.GroupBox8.TabStop = False
    '
    'Label106
    '
    Me.Label106.AutoSize = True
    Me.Label106.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label106.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label106.Location = New System.Drawing.Point(29, -3)
    Me.Label106.Name = "Label106"
    Me.Label106.Size = New System.Drawing.Size(73, 24)
    Me.Label106.TabIndex = 97
    Me.Label106.Text = "Reader"
    '
    'Label107
    '
    Me.Label107.AutoSize = True
    Me.Label107.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label107.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label107.Location = New System.Drawing.Point(22, 79)
    Me.Label107.Name = "Label107"
    Me.Label107.Size = New System.Drawing.Size(86, 24)
    Me.Label107.TabIndex = 94
    Me.Label107.Text = "檢測結果"
    Me.Label107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Lab_SearchResult_M1408_2
    '
    Me.Lab_SearchResult_M1408_2.BackColor = System.Drawing.Color.Honeydew
    Me.Lab_SearchResult_M1408_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_SearchResult_M1408_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_SearchResult_M1408_2.Location = New System.Drawing.Point(20, 103)
    Me.Lab_SearchResult_M1408_2.Name = "Lab_SearchResult_M1408_2"
    Me.Lab_SearchResult_M1408_2.Size = New System.Drawing.Size(90, 24)
    Me.Lab_SearchResult_M1408_2.TabIndex = 95
    Me.Lab_SearchResult_M1408_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_ReaderTrigger_M1900
    '
    Me.Btn_ReaderTrigger_M1900.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_ReaderTrigger_M1900.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_ReaderTrigger_M1900.Location = New System.Drawing.Point(22, 38)
    Me.Btn_ReaderTrigger_M1900.Name = "Btn_ReaderTrigger_M1900"
    Me.Btn_ReaderTrigger_M1900.Size = New System.Drawing.Size(86, 31)
    Me.Btn_ReaderTrigger_M1900.TabIndex = 96
    Me.Btn_ReaderTrigger_M1900.Text = "Trigger"
    Me.Btn_ReaderTrigger_M1900.UseVisualStyleBackColor = True
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.Lab_SearchResult_M1400_2)
    Me.GroupBox7.Controls.Add(Me.Label108)
    Me.GroupBox7.Controls.Add(Me.Btn_CcdTrigger_M1902)
    Me.GroupBox7.Controls.Add(Me.Label109)
    Me.GroupBox7.Location = New System.Drawing.Point(5, 2)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(130, 100)
    Me.GroupBox7.TabIndex = 128
    Me.GroupBox7.TabStop = False
    '
    'Lab_SearchResult_M1400_2
    '
    Me.Lab_SearchResult_M1400_2.BackColor = System.Drawing.Color.Honeydew
    Me.Lab_SearchResult_M1400_2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.Lab_SearchResult_M1400_2.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Lab_SearchResult_M1400_2.Location = New System.Drawing.Point(20, 69)
    Me.Lab_SearchResult_M1400_2.Name = "Lab_SearchResult_M1400_2"
    Me.Lab_SearchResult_M1400_2.Size = New System.Drawing.Size(90, 24)
    Me.Lab_SearchResult_M1400_2.TabIndex = 90
    Me.Lab_SearchResult_M1400_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label108
    '
    Me.Label108.AutoSize = True
    Me.Label108.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Label108.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label108.Location = New System.Drawing.Point(34, 53)
    Me.Label108.Name = "Label108"
    Me.Label108.Size = New System.Drawing.Size(60, 17)
    Me.Label108.TabIndex = 89
    Me.Label108.Text = "檢測結果"
    Me.Label108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_CcdTrigger_M1902
    '
    Me.Btn_CcdTrigger_M1902.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Btn_CcdTrigger_M1902.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_CcdTrigger_M1902.Location = New System.Drawing.Point(22, 20)
    Me.Btn_CcdTrigger_M1902.Name = "Btn_CcdTrigger_M1902"
    Me.Btn_CcdTrigger_M1902.Size = New System.Drawing.Size(86, 31)
    Me.Btn_CcdTrigger_M1902.TabIndex = 91
    Me.Btn_CcdTrigger_M1902.Text = "Trigger"
    Me.Btn_CcdTrigger_M1902.UseVisualStyleBackColor = True
    '
    'Label109
    '
    Me.Label109.AutoSize = True
    Me.Label109.Font = New System.Drawing.Font("微軟正黑體", 14.25!)
    Me.Label109.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label109.Location = New System.Drawing.Point(40, -3)
    Me.Label109.Name = "Label109"
    Me.Label109.Size = New System.Drawing.Size(50, 24)
    Me.Label109.TabIndex = 93
    Me.Label109.Text = "CCD"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.M1142)
    Me.GroupBox6.Controls.Add(Me.M1141)
    Me.GroupBox6.Controls.Add(Me.M1140)
    Me.GroupBox6.Controls.Add(Me.Label110)
    Me.GroupBox6.Controls.Add(Me.Btn_MoveBack_M1151)
    Me.GroupBox6.Controls.Add(Me.Btn_MoveFront_M1150)
    Me.GroupBox6.Controls.Add(Me.Radio_MoveSpeedC_M1130)
    Me.GroupBox6.Controls.Add(Me.Radio_MoveSpeedC_M1131)
    Me.GroupBox6.Controls.Add(Me.Radio_MoveSpeedC_M1132)
    Me.GroupBox6.Location = New System.Drawing.Point(413, 108)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(130, 143)
    Me.GroupBox6.TabIndex = 127
    Me.GroupBox6.TabStop = False
    '
    'M1142
    '
    Me.M1142.AutoSize = True
    Me.M1142.BackColor = System.Drawing.Color.WhiteSmoke
    Me.M1142.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.M1142.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.M1142.Location = New System.Drawing.Point(102, 72)
    Me.M1142.Name = "M1142"
    Me.M1142.Size = New System.Drawing.Size(17, 17)
    Me.M1142.TabIndex = 125
    Me.M1142.Text = "   "
    '
    'M1141
    '
    Me.M1141.AutoSize = True
    Me.M1141.BackColor = System.Drawing.Color.WhiteSmoke
    Me.M1141.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.M1141.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.M1141.Location = New System.Drawing.Point(102, 50)
    Me.M1141.Name = "M1141"
    Me.M1141.Size = New System.Drawing.Size(17, 17)
    Me.M1141.TabIndex = 123
    Me.M1141.Text = "   "
    '
    'M1140
    '
    Me.M1140.AutoSize = True
    Me.M1140.BackColor = System.Drawing.Color.WhiteSmoke
    Me.M1140.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.M1140.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.M1140.Location = New System.Drawing.Point(102, 28)
    Me.M1140.Name = "M1140"
    Me.M1140.Size = New System.Drawing.Size(17, 17)
    Me.M1140.TabIndex = 121
    Me.M1140.Text = "   "
    '
    'Label110
    '
    Me.Label110.AutoSize = True
    Me.Label110.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Label110.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label110.Location = New System.Drawing.Point(13, -1)
    Me.Label110.Name = "Label110"
    Me.Label110.Size = New System.Drawing.Size(105, 20)
    Me.Label110.TabIndex = 133
    Me.Label110.Text = "吋動運行參數"
    Me.Label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_MoveBack_M1151
    '
    Me.Btn_MoveBack_M1151.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Btn_MoveBack_M1151.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_MoveBack_M1151.Location = New System.Drawing.Point(68, 98)
    Me.Btn_MoveBack_M1151.Name = "Btn_MoveBack_M1151"
    Me.Btn_MoveBack_M1151.Size = New System.Drawing.Size(52, 31)
    Me.Btn_MoveBack_M1151.TabIndex = 132
    Me.Btn_MoveBack_M1151.Text = "後退"
    Me.Btn_MoveBack_M1151.UseVisualStyleBackColor = True
    '
    'Btn_MoveFront_M1150
    '
    Me.Btn_MoveFront_M1150.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Btn_MoveFront_M1150.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_MoveFront_M1150.Location = New System.Drawing.Point(11, 98)
    Me.Btn_MoveFront_M1150.Name = "Btn_MoveFront_M1150"
    Me.Btn_MoveFront_M1150.Size = New System.Drawing.Size(52, 31)
    Me.Btn_MoveFront_M1150.TabIndex = 131
    Me.Btn_MoveFront_M1150.Text = "前進"
    Me.Btn_MoveFront_M1150.UseVisualStyleBackColor = True
    '
    'Radio_MoveSpeedC_M1130
    '
    Me.Radio_MoveSpeedC_M1130.AutoSize = True
    Me.Radio_MoveSpeedC_M1130.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Radio_MoveSpeedC_M1130.Location = New System.Drawing.Point(12, 24)
    Me.Radio_MoveSpeedC_M1130.Name = "Radio_MoveSpeedC_M1130"
    Me.Radio_MoveSpeedC_M1130.Size = New System.Drawing.Size(95, 23)
    Me.Radio_MoveSpeedC_M1130.TabIndex = 120
    Me.Radio_MoveSpeedC_M1130.Text = "0.1m/min"
    Me.Radio_MoveSpeedC_M1130.UseVisualStyleBackColor = True
    '
    'Radio_MoveSpeedC_M1131
    '
    Me.Radio_MoveSpeedC_M1131.AutoSize = True
    Me.Radio_MoveSpeedC_M1131.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Radio_MoveSpeedC_M1131.Location = New System.Drawing.Point(12, 46)
    Me.Radio_MoveSpeedC_M1131.Name = "Radio_MoveSpeedC_M1131"
    Me.Radio_MoveSpeedC_M1131.Size = New System.Drawing.Size(95, 23)
    Me.Radio_MoveSpeedC_M1131.TabIndex = 122
    Me.Radio_MoveSpeedC_M1131.Text = "0.5m/min"
    Me.Radio_MoveSpeedC_M1131.UseVisualStyleBackColor = True
    '
    'Radio_MoveSpeedC_M1132
    '
    Me.Radio_MoveSpeedC_M1132.AutoSize = True
    Me.Radio_MoveSpeedC_M1132.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Radio_MoveSpeedC_M1132.Location = New System.Drawing.Point(12, 68)
    Me.Radio_MoveSpeedC_M1132.Name = "Radio_MoveSpeedC_M1132"
    Me.Radio_MoveSpeedC_M1132.Size = New System.Drawing.Size(82, 23)
    Me.Radio_MoveSpeedC_M1132.TabIndex = 124
    Me.Radio_MoveSpeedC_M1132.Text = "1m/min"
    Me.Radio_MoveSpeedC_M1132.UseVisualStyleBackColor = True
    '
    'GroupBox12
    '
    Me.GroupBox12.Controls.Add(Me.M1111)
    Me.GroupBox12.Controls.Add(Me.M1112)
    Me.GroupBox12.Controls.Add(Me.M1110)
    Me.GroupBox12.Controls.Add(Me.Label111)
    Me.GroupBox12.Controls.Add(Me.Btn_MoveBack_M1121)
    Me.GroupBox12.Controls.Add(Me.Btn_MoveFront_M1120)
    Me.GroupBox12.Controls.Add(Me.Radio_MoveSpeedPtp_M1101)
    Me.GroupBox12.Controls.Add(Me.Radio_MoveSpeedPtp_M1102)
    Me.GroupBox12.Controls.Add(Me.Radio_MoveSpeedPtp_M1103)
    Me.GroupBox12.Location = New System.Drawing.Point(277, 108)
    Me.GroupBox12.Name = "GroupBox12"
    Me.GroupBox12.Size = New System.Drawing.Size(130, 143)
    Me.GroupBox12.TabIndex = 126
    Me.GroupBox12.TabStop = False
    '
    'M1111
    '
    Me.M1111.AutoSize = True
    Me.M1111.BackColor = System.Drawing.Color.WhiteSmoke
    Me.M1111.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.M1111.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.M1111.Location = New System.Drawing.Point(102, 50)
    Me.M1111.Name = "M1111"
    Me.M1111.Size = New System.Drawing.Size(17, 17)
    Me.M1111.TabIndex = 117
    Me.M1111.Text = "   "
    '
    'M1112
    '
    Me.M1112.AutoSize = True
    Me.M1112.BackColor = System.Drawing.Color.WhiteSmoke
    Me.M1112.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.M1112.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.M1112.Location = New System.Drawing.Point(102, 28)
    Me.M1112.Name = "M1112"
    Me.M1112.Size = New System.Drawing.Size(17, 17)
    Me.M1112.TabIndex = 115
    Me.M1112.Text = "   "
    '
    'M1110
    '
    Me.M1110.AutoSize = True
    Me.M1110.BackColor = System.Drawing.Color.WhiteSmoke
    Me.M1110.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.M1110.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.M1110.Location = New System.Drawing.Point(102, 72)
    Me.M1110.Name = "M1110"
    Me.M1110.Size = New System.Drawing.Size(17, 17)
    Me.M1110.TabIndex = 119
    Me.M1110.Text = "   "
    '
    'Label111
    '
    Me.Label111.AutoSize = True
    Me.Label111.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
    Me.Label111.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label111.Location = New System.Drawing.Point(13, -1)
    Me.Label111.Name = "Label111"
    Me.Label111.Size = New System.Drawing.Size(105, 20)
    Me.Label111.TabIndex = 122
    Me.Label111.Text = "手動運行參數"
    Me.Label111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Btn_MoveBack_M1121
    '
    Me.Btn_MoveBack_M1121.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Btn_MoveBack_M1121.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_MoveBack_M1121.Location = New System.Drawing.Point(68, 98)
    Me.Btn_MoveBack_M1121.Name = "Btn_MoveBack_M1121"
    Me.Btn_MoveBack_M1121.Size = New System.Drawing.Size(52, 31)
    Me.Btn_MoveBack_M1121.TabIndex = 121
    Me.Btn_MoveBack_M1121.Text = "後退"
    Me.Btn_MoveBack_M1121.UseVisualStyleBackColor = True
    '
    'Btn_MoveFront_M1120
    '
    Me.Btn_MoveFront_M1120.Font = New System.Drawing.Font("微軟正黑體", 9.75!)
    Me.Btn_MoveFront_M1120.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Btn_MoveFront_M1120.Location = New System.Drawing.Point(11, 98)
    Me.Btn_MoveFront_M1120.Name = "Btn_MoveFront_M1120"
    Me.Btn_MoveFront_M1120.Size = New System.Drawing.Size(52, 31)
    Me.Btn_MoveFront_M1120.TabIndex = 120
    Me.Btn_MoveFront_M1120.Text = "前進"
    Me.Btn_MoveFront_M1120.UseVisualStyleBackColor = True
    '
    'Radio_MoveSpeedPtp_M1101
    '
    Me.Radio_MoveSpeedPtp_M1101.AutoSize = True
    Me.Radio_MoveSpeedPtp_M1101.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Radio_MoveSpeedPtp_M1101.Location = New System.Drawing.Point(12, 69)
    Me.Radio_MoveSpeedPtp_M1101.Name = "Radio_MoveSpeedPtp_M1101"
    Me.Radio_MoveSpeedPtp_M1101.Size = New System.Drawing.Size(82, 23)
    Me.Radio_MoveSpeedPtp_M1101.TabIndex = 118
    Me.Radio_MoveSpeedPtp_M1101.Text = "1m/min"
    Me.Radio_MoveSpeedPtp_M1101.UseVisualStyleBackColor = True
    '
    'Radio_MoveSpeedPtp_M1102
    '
    Me.Radio_MoveSpeedPtp_M1102.AutoSize = True
    Me.Radio_MoveSpeedPtp_M1102.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Radio_MoveSpeedPtp_M1102.Location = New System.Drawing.Point(12, 47)
    Me.Radio_MoveSpeedPtp_M1102.Name = "Radio_MoveSpeedPtp_M1102"
    Me.Radio_MoveSpeedPtp_M1102.Size = New System.Drawing.Size(95, 23)
    Me.Radio_MoveSpeedPtp_M1102.TabIndex = 116
    Me.Radio_MoveSpeedPtp_M1102.Text = "0.5m/min"
    Me.Radio_MoveSpeedPtp_M1102.UseVisualStyleBackColor = True
    '
    'Radio_MoveSpeedPtp_M1103
    '
    Me.Radio_MoveSpeedPtp_M1103.AutoSize = True
    Me.Radio_MoveSpeedPtp_M1103.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Radio_MoveSpeedPtp_M1103.Location = New System.Drawing.Point(12, 25)
    Me.Radio_MoveSpeedPtp_M1103.Name = "Radio_MoveSpeedPtp_M1103"
    Me.Radio_MoveSpeedPtp_M1103.Size = New System.Drawing.Size(95, 23)
    Me.Radio_MoveSpeedPtp_M1103.TabIndex = 114
    Me.Radio_MoveSpeedPtp_M1103.Text = "0.1m/min"
    Me.Radio_MoveSpeedPtp_M1103.UseVisualStyleBackColor = True
    '
    'Label112
    '
    Me.Label112.AutoSize = True
    Me.Label112.BackColor = System.Drawing.Color.Transparent
    Me.Label112.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label112.Location = New System.Drawing.Point(198, 34)
    Me.Label112.Name = "Label112"
    Me.Label112.Size = New System.Drawing.Size(13, 19)
    Me.Label112.TabIndex = 98
    Me.Label112.Text = " "
    '
    'Label113
    '
    Me.Label113.AutoSize = True
    Me.Label113.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label113.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Label113.Location = New System.Drawing.Point(48, 18)
    Me.Label113.Name = "Label113"
    Me.Label113.Size = New System.Drawing.Size(61, 15)
    Me.Label113.TabIndex = 90
    Me.Label113.Text = "PLC_RUN"
    '
    'LabPlcRunning
    '
    Me.LabPlcRunning.AutoSize = True
    Me.LabPlcRunning.BackColor = System.Drawing.Color.White
    Me.LabPlcRunning.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.LabPlcRunning.Location = New System.Drawing.Point(110, 18)
    Me.LabPlcRunning.Name = "LabPlcRunning"
    Me.LabPlcRunning.Size = New System.Drawing.Size(69, 19)
    Me.LabPlcRunning.TabIndex = 89
    Me.LabPlcRunning.Text = "               "
    '
    'txt_Data
    '
    Me.txt_Data.AcceptsReturn = True
    Me.txt_Data.Location = New System.Drawing.Point(348, 69)
    Me.txt_Data.Multiline = True
    Me.txt_Data.Name = "txt_Data"
    Me.txt_Data.ReadOnly = True
    Me.txt_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txt_Data.Size = New System.Drawing.Size(160, 22)
    Me.txt_Data.TabIndex = 88
    Me.txt_Data.TabStop = False
    '
    'txt_LogicalStationNumber
    '
    Me.txt_LogicalStationNumber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.txt_LogicalStationNumber.Location = New System.Drawing.Point(228, 69)
    Me.txt_LogicalStationNumber.Name = "txt_LogicalStationNumber"
    Me.txt_LogicalStationNumber.Size = New System.Drawing.Size(40, 21)
    Me.txt_LogicalStationNumber.TabIndex = 87
    Me.txt_LogicalStationNumber.Text = "1"
    Me.txt_LogicalStationNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'lbl_LogicalStationNumber
    '
    Me.lbl_LogicalStationNumber.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbl_LogicalStationNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.lbl_LogicalStationNumber.Location = New System.Drawing.Point(148, 74)
    Me.lbl_LogicalStationNumber.Name = "lbl_LogicalStationNumber"
    Me.lbl_LogicalStationNumber.Size = New System.Drawing.Size(120, 16)
    Me.lbl_LogicalStationNumber.TabIndex = 86
    Me.lbl_LogicalStationNumber.Text = "PLC連線編號"
    '
    'Radio_PlcRunning
    '
    Me.Radio_PlcRunning.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Radio_PlcRunning.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.Radio_PlcRunning.Location = New System.Drawing.Point(50, 45)
    Me.Radio_PlcRunning.Name = "Radio_PlcRunning"
    Me.Radio_PlcRunning.Size = New System.Drawing.Size(44, 16)
    Me.Radio_PlcRunning.TabIndex = 85
    Me.Radio_PlcRunning.TabStop = True
    Me.Radio_PlcRunning.Text = "PLC"
    '
    'Text_ReturnCode
    '
    Me.Text_ReturnCode.BackColor = System.Drawing.Color.White
    Me.Text_ReturnCode.Location = New System.Drawing.Point(348, 42)
    Me.Text_ReturnCode.Name = "Text_ReturnCode"
    Me.Text_ReturnCode.Size = New System.Drawing.Size(160, 26)
    Me.Text_ReturnCode.TabIndex = 84
    Me.Text_ReturnCode.TabStop = False
    '
    'BtnClose
    '
    Me.BtnClose.BackColor = System.Drawing.Color.White
    Me.BtnClose.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.BtnClose.Location = New System.Drawing.Point(221, 42)
    Me.BtnClose.Name = "BtnClose"
    Me.BtnClose.Size = New System.Drawing.Size(121, 27)
    Me.BtnClose.TabIndex = 83
    Me.BtnClose.Text = "斷線"
    Me.BtnClose.UseVisualStyleBackColor = False
    '
    'BtnOpen
    '
    Me.BtnOpen.BackColor = System.Drawing.Color.White
    Me.BtnOpen.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.BtnOpen.Location = New System.Drawing.Point(94, 42)
    Me.BtnOpen.Name = "BtnOpen"
    Me.BtnOpen.Size = New System.Drawing.Size(121, 27)
    Me.BtnOpen.TabIndex = 82
    Me.BtnOpen.Text = "連線"
    Me.BtnOpen.UseVisualStyleBackColor = False
    '
    'GroupIO_AOI
    '
    Me.GroupIO_AOI.Controls.Add(Me.GroupIO_Input)
    Me.GroupIO_AOI.Controls.Add(Me.GroupIO_Output)
    Me.GroupIO_AOI.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupIO_AOI.Location = New System.Drawing.Point(2, 2)
    Me.GroupIO_AOI.Name = "GroupIO_AOI"
    Me.GroupIO_AOI.Size = New System.Drawing.Size(846, 262)
    Me.GroupIO_AOI.TabIndex = 62
    Me.GroupIO_AOI.TabStop = False
    Me.GroupIO_AOI.Text = "AOI"
    '
    'GroupIO_Input
    '
    Me.GroupIO_Input.Controls.Add(Me.Label65)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X116)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X115)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X114)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X113)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X112)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X111)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X110)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X109)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X108)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X107)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X106)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X105)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X104)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X103)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X102)
    Me.GroupIO_Input.Controls.Add(Me.LabDi_X101)
    Me.GroupIO_Input.Controls.Add(Me.Label13)
    Me.GroupIO_Input.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupIO_Input.Location = New System.Drawing.Point(6, 17)
    Me.GroupIO_Input.Name = "GroupIO_Input"
    Me.GroupIO_Input.Size = New System.Drawing.Size(296, 235)
    Me.GroupIO_Input.TabIndex = 58
    Me.GroupIO_Input.TabStop = False
    Me.GroupIO_Input.Text = "Input"
    '
    'Label65
    '
    Me.Label65.AutoSize = True
    Me.Label65.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Label65.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label65.Location = New System.Drawing.Point(211, 27)
    Me.Label65.Name = "Label65"
    Me.Label65.Size = New System.Drawing.Size(72, 195)
    Me.Label65.TabIndex = 19
    Me.Label65.Text = "門檢(2)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "門檢(3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "掃描器逾時" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CCD逾時" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "啟動燈" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "警報停止鈕" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "保留" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "保留"
    '
    'LabDi_X116
    '
    Me.LabDi_X116.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X116.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X116.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X116.Location = New System.Drawing.Point(168, 205)
    Me.LabDi_X116.Name = "LabDi_X116"
    Me.LabDi_X116.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X116.TabIndex = 18
    Me.LabDi_X116.Text = "X116"
    Me.LabDi_X116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X115
    '
    Me.LabDi_X115.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X115.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X115.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X115.Location = New System.Drawing.Point(168, 179)
    Me.LabDi_X115.Name = "LabDi_X115"
    Me.LabDi_X115.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X115.TabIndex = 17
    Me.LabDi_X115.Text = "X115"
    Me.LabDi_X115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X114
    '
    Me.LabDi_X114.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X114.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X114.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X114.Location = New System.Drawing.Point(168, 153)
    Me.LabDi_X114.Name = "LabDi_X114"
    Me.LabDi_X114.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X114.TabIndex = 16
    Me.LabDi_X114.Text = "X114"
    Me.LabDi_X114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X113
    '
    Me.LabDi_X113.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X113.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X113.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X113.Location = New System.Drawing.Point(168, 127)
    Me.LabDi_X113.Name = "LabDi_X113"
    Me.LabDi_X113.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X113.TabIndex = 15
    Me.LabDi_X113.Text = "X113"
    Me.LabDi_X113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X112
    '
    Me.LabDi_X112.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X112.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X112.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X112.Location = New System.Drawing.Point(168, 101)
    Me.LabDi_X112.Name = "LabDi_X112"
    Me.LabDi_X112.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X112.TabIndex = 14
    Me.LabDi_X112.Text = "X112"
    Me.LabDi_X112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X111
    '
    Me.LabDi_X111.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X111.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X111.Location = New System.Drawing.Point(168, 75)
    Me.LabDi_X111.Name = "LabDi_X111"
    Me.LabDi_X111.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X111.TabIndex = 13
    Me.LabDi_X111.Text = "X111"
    Me.LabDi_X111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X110
    '
    Me.LabDi_X110.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X110.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X110.Location = New System.Drawing.Point(168, 49)
    Me.LabDi_X110.Name = "LabDi_X110"
    Me.LabDi_X110.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X110.TabIndex = 12
    Me.LabDi_X110.Text = "X110"
    Me.LabDi_X110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X109
    '
    Me.LabDi_X109.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X109.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X109.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X109.Location = New System.Drawing.Point(168, 23)
    Me.LabDi_X109.Name = "LabDi_X109"
    Me.LabDi_X109.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X109.TabIndex = 11
    Me.LabDi_X109.Text = "X109"
    Me.LabDi_X109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X108
    '
    Me.LabDi_X108.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X108.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X108.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X108.Location = New System.Drawing.Point(10, 205)
    Me.LabDi_X108.Name = "LabDi_X108"
    Me.LabDi_X108.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X108.TabIndex = 10
    Me.LabDi_X108.Text = "X108"
    Me.LabDi_X108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X107
    '
    Me.LabDi_X107.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X107.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X107.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X107.Location = New System.Drawing.Point(10, 179)
    Me.LabDi_X107.Name = "LabDi_X107"
    Me.LabDi_X107.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X107.TabIndex = 9
    Me.LabDi_X107.Text = "X107"
    Me.LabDi_X107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X106
    '
    Me.LabDi_X106.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X106.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X106.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X106.Location = New System.Drawing.Point(10, 153)
    Me.LabDi_X106.Name = "LabDi_X106"
    Me.LabDi_X106.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X106.TabIndex = 8
    Me.LabDi_X106.Text = "X106"
    Me.LabDi_X106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X105
    '
    Me.LabDi_X105.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X105.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X105.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X105.Location = New System.Drawing.Point(10, 127)
    Me.LabDi_X105.Name = "LabDi_X105"
    Me.LabDi_X105.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X105.TabIndex = 7
    Me.LabDi_X105.Text = "X105"
    Me.LabDi_X105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X104
    '
    Me.LabDi_X104.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X104.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X104.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X104.Location = New System.Drawing.Point(10, 101)
    Me.LabDi_X104.Name = "LabDi_X104"
    Me.LabDi_X104.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X104.TabIndex = 6
    Me.LabDi_X104.Text = "X104"
    Me.LabDi_X104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X103
    '
    Me.LabDi_X103.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X103.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X103.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X103.Location = New System.Drawing.Point(10, 75)
    Me.LabDi_X103.Name = "LabDi_X103"
    Me.LabDi_X103.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X103.TabIndex = 4
    Me.LabDi_X103.Text = "X103"
    Me.LabDi_X103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X102
    '
    Me.LabDi_X102.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X102.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X102.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X102.Location = New System.Drawing.Point(10, 49)
    Me.LabDi_X102.Name = "LabDi_X102"
    Me.LabDi_X102.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X102.TabIndex = 2
    Me.LabDi_X102.Text = "X102"
    Me.LabDi_X102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabDi_X101
    '
    Me.LabDi_X101.BackColor = System.Drawing.Color.DarkGreen
    Me.LabDi_X101.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabDi_X101.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabDi_X101.Location = New System.Drawing.Point(10, 23)
    Me.LabDi_X101.Name = "LabDi_X101"
    Me.LabDi_X101.Size = New System.Drawing.Size(40, 21)
    Me.LabDi_X101.TabIndex = 0
    Me.LabDi_X101.Text = "X101"
    Me.LabDi_X101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Label13.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label13.Location = New System.Drawing.Point(53, 27)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(98, 195)
    Me.Label13.TabIndex = 1
    Me.Label13.Text = "Reader Trigger" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CCD Trigger" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "馬達前極限" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "馬達後極限" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "伺服馬達異常" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "伺服驅動器異常" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "真空異常" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "門" & _
        "檢(1)"
    '
    'GroupIO_Output
    '
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y116)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y115)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y114)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y113)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y112)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y111)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y110)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y109)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y108)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y107)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y105)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y106)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y103)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y104)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y102)
    Me.GroupIO_Output.Controls.Add(Me.CheckDo_Y101)
    Me.GroupIO_Output.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupIO_Output.Location = New System.Drawing.Point(308, 17)
    Me.GroupIO_Output.Name = "GroupIO_Output"
    Me.GroupIO_Output.Size = New System.Drawing.Size(403, 235)
    Me.GroupIO_Output.TabIndex = 59
    Me.GroupIO_Output.TabStop = False
    Me.GroupIO_Output.Text = "Output"
    '
    'CheckDo_Y116
    '
    Me.CheckDo_Y116.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y116.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y116.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y116.Location = New System.Drawing.Point(203, 202)
    Me.CheckDo_Y116.Name = "CheckDo_Y116"
    Me.CheckDo_Y116.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y116.TabIndex = 15
    Me.CheckDo_Y116.Tag = "16"
    Me.CheckDo_Y116.Text = "Y116    保留"
    Me.CheckDo_Y116.UseVisualStyleBackColor = False
    '
    'CheckDo_Y115
    '
    Me.CheckDo_Y115.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y115.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y115.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y115.Location = New System.Drawing.Point(203, 176)
    Me.CheckDo_Y115.Name = "CheckDo_Y115"
    Me.CheckDo_Y115.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y115.TabIndex = 14
    Me.CheckDo_Y115.Tag = "15"
    Me.CheckDo_Y115.Text = "Y115    保留"
    Me.CheckDo_Y115.UseVisualStyleBackColor = False
    '
    'CheckDo_Y114
    '
    Me.CheckDo_Y114.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y114.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y114.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y114.Location = New System.Drawing.Point(203, 150)
    Me.CheckDo_Y114.Name = "CheckDo_Y114"
    Me.CheckDo_Y114.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y114.TabIndex = 13
    Me.CheckDo_Y114.Tag = "14"
    Me.CheckDo_Y114.Text = "Y114    保留"
    Me.CheckDo_Y114.UseVisualStyleBackColor = False
    '
    'CheckDo_Y113
    '
    Me.CheckDo_Y113.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y113.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y113.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y113.Location = New System.Drawing.Point(203, 124)
    Me.CheckDo_Y113.Name = "CheckDo_Y113"
    Me.CheckDo_Y113.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y113.TabIndex = 12
    Me.CheckDo_Y113.Tag = "13"
    Me.CheckDo_Y113.Text = "Y113    保留"
    Me.CheckDo_Y113.UseVisualStyleBackColor = False
    '
    'CheckDo_Y112
    '
    Me.CheckDo_Y112.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y112.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y112.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y112.Location = New System.Drawing.Point(203, 98)
    Me.CheckDo_Y112.Name = "CheckDo_Y112"
    Me.CheckDo_Y112.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y112.TabIndex = 11
    Me.CheckDo_Y112.Tag = "12"
    Me.CheckDo_Y112.Text = "Y112    保留"
    Me.CheckDo_Y112.UseVisualStyleBackColor = False
    '
    'CheckDo_Y111
    '
    Me.CheckDo_Y111.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y111.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y111.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y111.Location = New System.Drawing.Point(203, 72)
    Me.CheckDo_Y111.Name = "CheckDo_Y111"
    Me.CheckDo_Y111.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y111.TabIndex = 10
    Me.CheckDo_Y111.Tag = "11"
    Me.CheckDo_Y111.Text = "Y111    保留"
    Me.CheckDo_Y111.UseVisualStyleBackColor = False
    '
    'CheckDo_Y110
    '
    Me.CheckDo_Y110.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y110.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y110.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y110.Location = New System.Drawing.Point(203, 46)
    Me.CheckDo_Y110.Name = "CheckDo_Y110"
    Me.CheckDo_Y110.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y110.TabIndex = 9
    Me.CheckDo_Y110.Tag = "10"
    Me.CheckDo_Y110.Text = "Y110    保留"
    Me.CheckDo_Y110.UseVisualStyleBackColor = False
    '
    'CheckDo_Y109
    '
    Me.CheckDo_Y109.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y109.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y109.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y109.Location = New System.Drawing.Point(203, 20)
    Me.CheckDo_Y109.Name = "CheckDo_Y109"
    Me.CheckDo_Y109.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y109.TabIndex = 8
    Me.CheckDo_Y109.Tag = "9"
    Me.CheckDo_Y109.Text = "Y109    保留"
    Me.CheckDo_Y109.UseVisualStyleBackColor = False
    '
    'CheckDo_Y108
    '
    Me.CheckDo_Y108.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y108.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y108.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y108.Location = New System.Drawing.Point(6, 202)
    Me.CheckDo_Y108.Name = "CheckDo_Y108"
    Me.CheckDo_Y108.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y108.TabIndex = 7
    Me.CheckDo_Y108.Tag = "8"
    Me.CheckDo_Y108.Text = "Y108    保留"
    Me.CheckDo_Y108.UseVisualStyleBackColor = False
    '
    'CheckDo_Y107
    '
    Me.CheckDo_Y107.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y107.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y107.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y107.Location = New System.Drawing.Point(6, 176)
    Me.CheckDo_Y107.Name = "CheckDo_Y107"
    Me.CheckDo_Y107.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y107.TabIndex = 6
    Me.CheckDo_Y107.Tag = "7"
    Me.CheckDo_Y107.Text = "Y107    保留"
    Me.CheckDo_Y107.UseVisualStyleBackColor = False
    '
    'CheckDo_Y105
    '
    Me.CheckDo_Y105.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y105.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y105.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y105.Location = New System.Drawing.Point(6, 124)
    Me.CheckDo_Y105.Name = "CheckDo_Y105"
    Me.CheckDo_Y105.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y105.TabIndex = 5
    Me.CheckDo_Y105.Tag = "5"
    Me.CheckDo_Y105.Text = "Y105    保留"
    Me.CheckDo_Y105.UseVisualStyleBackColor = False
    '
    'CheckDo_Y106
    '
    Me.CheckDo_Y106.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y106.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y106.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y106.Location = New System.Drawing.Point(6, 150)
    Me.CheckDo_Y106.Name = "CheckDo_Y106"
    Me.CheckDo_Y106.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y106.TabIndex = 4
    Me.CheckDo_Y106.Tag = "6"
    Me.CheckDo_Y106.Text = "Y106    保留"
    Me.CheckDo_Y106.UseVisualStyleBackColor = False
    '
    'CheckDo_Y103
    '
    Me.CheckDo_Y103.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y103.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y103.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y103.Location = New System.Drawing.Point(6, 72)
    Me.CheckDo_Y103.Name = "CheckDo_Y103"
    Me.CheckDo_Y103.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y103.TabIndex = 3
    Me.CheckDo_Y103.Tag = "3"
    Me.CheckDo_Y103.Text = "Y103    檢測結果OK"
    Me.CheckDo_Y103.UseVisualStyleBackColor = False
    '
    'CheckDo_Y104
    '
    Me.CheckDo_Y104.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y104.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y104.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y104.Location = New System.Drawing.Point(6, 98)
    Me.CheckDo_Y104.Name = "CheckDo_Y104"
    Me.CheckDo_Y104.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y104.TabIndex = 2
    Me.CheckDo_Y104.Tag = "4"
    Me.CheckDo_Y104.Text = "Y104    檢測結果NG"
    Me.CheckDo_Y104.UseVisualStyleBackColor = False
    '
    'CheckDo_Y102
    '
    Me.CheckDo_Y102.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y102.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y102.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y102.Location = New System.Drawing.Point(6, 46)
    Me.CheckDo_Y102.Name = "CheckDo_Y102"
    Me.CheckDo_Y102.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y102.TabIndex = 1
    Me.CheckDo_Y102.Tag = "2"
    Me.CheckDo_Y102.Text = "Y102    Reader 讀取完成"
    Me.CheckDo_Y102.UseVisualStyleBackColor = False
    '
    'CheckDo_Y101
    '
    Me.CheckDo_Y101.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckDo_Y101.BackColor = System.Drawing.Color.WhiteSmoke
    Me.CheckDo_Y101.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckDo_Y101.Location = New System.Drawing.Point(6, 20)
    Me.CheckDo_Y101.Name = "CheckDo_Y101"
    Me.CheckDo_Y101.Size = New System.Drawing.Size(194, 26)
    Me.CheckDo_Y101.TabIndex = 0
    Me.CheckDo_Y101.Tag = "1"
    Me.CheckDo_Y101.Text = "Y101    AOI Ready"
    Me.CheckDo_Y101.UseVisualStyleBackColor = False
    '
    'LabService_RunIndex
    '
    Me.LabService_RunIndex.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabService_RunIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabService_RunIndex.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabService_RunIndex.ForeColor = System.Drawing.Color.Black
    Me.LabService_RunIndex.Location = New System.Drawing.Point(777, 23)
    Me.LabService_RunIndex.Name = "LabService_RunIndex"
    Me.LabService_RunIndex.Size = New System.Drawing.Size(63, 21)
    Me.LabService_RunIndex.TabIndex = 61
    Me.LabService_RunIndex.Text = "0"
    Me.LabService_RunIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label49
    '
    Me.Label49.AutoSize = True
    Me.Label49.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label49.Location = New System.Drawing.Point(702, 26)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(73, 16)
    Me.Label49.TabIndex = 60
    Me.Label49.Text = "Run Index"
    '
    'TabPage_Parameter
    '
    Me.TabPage_Parameter.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TabPage_Parameter.Controls.Add(Me.PanelParameter)
    Me.TabPage_Parameter.Location = New System.Drawing.Point(4, 30)
    Me.TabPage_Parameter.Name = "TabPage_Parameter"
    Me.TabPage_Parameter.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage_Parameter.Size = New System.Drawing.Size(851, 938)
    Me.TabPage_Parameter.TabIndex = 1
    Me.TabPage_Parameter.Text = "參數視窗"
    Me.TabPage_Parameter.UseVisualStyleBackColor = True
    '
    'PanelParameter
    '
    Me.PanelParameter.BackColor = System.Drawing.SystemColors.ControlDark
    Me.PanelParameter.Controls.Add(Me.GroupAdv)
    Me.PanelParameter.Controls.Add(Me.GroupProduct)
    Me.PanelParameter.Location = New System.Drawing.Point(0, 0)
    Me.PanelParameter.Name = "PanelParameter"
    Me.PanelParameter.Size = New System.Drawing.Size(851, 942)
    Me.PanelParameter.TabIndex = 0
    '
    'GroupAdv
    '
    Me.GroupAdv.Controls.Add(Me.GroupAdv_Option)
    Me.GroupAdv.Controls.Add(Me.GroupBox1)
    Me.GroupAdv.Controls.Add(Me.GroupAdv_Calib_Pixel)
    Me.GroupAdv.Controls.Add(Me.GroupAdv_Calib_Light)
    Me.GroupAdv.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupAdv.Location = New System.Drawing.Point(482, 1)
    Me.GroupAdv.Name = "GroupAdv"
    Me.GroupAdv.Size = New System.Drawing.Size(365, 924)
    Me.GroupAdv.TabIndex = 1
    Me.GroupAdv.TabStop = False
    Me.GroupAdv.Text = "進階參數"
    '
    'GroupAdv_Option
    '
    Me.GroupAdv_Option.Controls.Add(Me.CheckAdv_Option_Barcode)
    Me.GroupAdv_Option.Controls.Add(Me.CheckSearch_LeftRight)
    Me.GroupAdv_Option.Controls.Add(Me.CheckSearch_UpDown)
    Me.GroupAdv_Option.Controls.Add(Me.Label223)
    Me.GroupAdv_Option.Controls.Add(Me.CheckAdv_Option_SaveNgPic)
    Me.GroupAdv_Option.Controls.Add(Me.CheckAdv_Option_Search)
    Me.GroupAdv_Option.Controls.Add(Me.TextAdv_Option_CaptureDelay)
    Me.GroupAdv_Option.Controls.Add(Me.Label222)
    Me.GroupAdv_Option.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold)
    Me.GroupAdv_Option.Location = New System.Drawing.Point(9, 798)
    Me.GroupAdv_Option.Name = "GroupAdv_Option"
    Me.GroupAdv_Option.Size = New System.Drawing.Size(353, 120)
    Me.GroupAdv_Option.TabIndex = 101
    Me.GroupAdv_Option.TabStop = False
    Me.GroupAdv_Option.Text = "功能選項設定"
    '
    'CheckAdv_Option_Barcode
    '
    Me.CheckAdv_Option_Barcode.AutoSize = True
    Me.CheckAdv_Option_Barcode.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckAdv_Option_Barcode.Location = New System.Drawing.Point(14, 20)
    Me.CheckAdv_Option_Barcode.Name = "CheckAdv_Option_Barcode"
    Me.CheckAdv_Option_Barcode.Size = New System.Drawing.Size(96, 16)
    Me.CheckAdv_Option_Barcode.TabIndex = 142
    Me.CheckAdv_Option_Barcode.TabStop = False
    Me.CheckAdv_Option_Barcode.Text = "開啟條碼讀取"
    Me.CheckAdv_Option_Barcode.UseVisualStyleBackColor = True
    '
    'CheckSearch_LeftRight
    '
    Me.CheckSearch_LeftRight.AutoSize = True
    Me.CheckSearch_LeftRight.Checked = True
    Me.CheckSearch_LeftRight.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckSearch_LeftRight.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckSearch_LeftRight.Location = New System.Drawing.Point(14, 80)
    Me.CheckSearch_LeftRight.Name = "CheckSearch_LeftRight"
    Me.CheckSearch_LeftRight.Size = New System.Drawing.Size(84, 16)
    Me.CheckSearch_LeftRight.TabIndex = 140
    Me.CheckSearch_LeftRight.TabStop = False
    Me.CheckSearch_LeftRight.Text = "量測左右孔"
    Me.CheckSearch_LeftRight.UseVisualStyleBackColor = True
    '
    'CheckSearch_UpDown
    '
    Me.CheckSearch_UpDown.AutoSize = True
    Me.CheckSearch_UpDown.Checked = True
    Me.CheckSearch_UpDown.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckSearch_UpDown.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckSearch_UpDown.Location = New System.Drawing.Point(14, 100)
    Me.CheckSearch_UpDown.Name = "CheckSearch_UpDown"
    Me.CheckSearch_UpDown.Size = New System.Drawing.Size(84, 16)
    Me.CheckSearch_UpDown.TabIndex = 139
    Me.CheckSearch_UpDown.TabStop = False
    Me.CheckSearch_UpDown.Text = "量測上下孔"
    Me.CheckSearch_UpDown.UseVisualStyleBackColor = True
    '
    'Label223
    '
    Me.Label223.AutoSize = True
    Me.Label223.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label223.Location = New System.Drawing.Point(154, 61)
    Me.Label223.Name = "Label223"
    Me.Label223.Size = New System.Drawing.Size(18, 12)
    Me.Label223.TabIndex = 111
    Me.Label223.Text = "ms"
    '
    'CheckAdv_Option_SaveNgPic
    '
    Me.CheckAdv_Option_SaveNgPic.AutoSize = True
    Me.CheckAdv_Option_SaveNgPic.Checked = True
    Me.CheckAdv_Option_SaveNgPic.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckAdv_Option_SaveNgPic.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckAdv_Option_SaveNgPic.Location = New System.Drawing.Point(195, 60)
    Me.CheckAdv_Option_SaveNgPic.Name = "CheckAdv_Option_SaveNgPic"
    Me.CheckAdv_Option_SaveNgPic.Size = New System.Drawing.Size(76, 16)
    Me.CheckAdv_Option_SaveNgPic.TabIndex = 102
    Me.CheckAdv_Option_SaveNgPic.TabStop = False
    Me.CheckAdv_Option_SaveNgPic.Text = "儲存NG圖"
    Me.CheckAdv_Option_SaveNgPic.UseVisualStyleBackColor = True
    '
    'CheckAdv_Option_Search
    '
    Me.CheckAdv_Option_Search.AutoSize = True
    Me.CheckAdv_Option_Search.Checked = True
    Me.CheckAdv_Option_Search.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckAdv_Option_Search.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckAdv_Option_Search.Location = New System.Drawing.Point(14, 40)
    Me.CheckAdv_Option_Search.Name = "CheckAdv_Option_Search"
    Me.CheckAdv_Option_Search.Size = New System.Drawing.Size(96, 16)
    Me.CheckAdv_Option_Search.TabIndex = 99
    Me.CheckAdv_Option_Search.TabStop = False
    Me.CheckAdv_Option_Search.Text = "開啟檢測功能"
    Me.CheckAdv_Option_Search.UseVisualStyleBackColor = True
    '
    'TextAdv_Option_CaptureDelay
    '
    Me.TextAdv_Option_CaptureDelay.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Option_CaptureDelay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Option_CaptureDelay.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Option_CaptureDelay.Location = New System.Drawing.Point(112, 56)
    Me.TextAdv_Option_CaptureDelay.MaxLength = 4
    Me.TextAdv_Option_CaptureDelay.Name = "TextAdv_Option_CaptureDelay"
    Me.TextAdv_Option_CaptureDelay.Size = New System.Drawing.Size(41, 21)
    Me.TextAdv_Option_CaptureDelay.TabIndex = 110
    Me.TextAdv_Option_CaptureDelay.Tag = ""
    Me.TextAdv_Option_CaptureDelay.Text = "200"
    Me.TextAdv_Option_CaptureDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label222
    '
    Me.Label222.AutoSize = True
    Me.Label222.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label222.Location = New System.Drawing.Point(30, 60)
    Me.Label222.Name = "Label222"
    Me.Label222.Size = New System.Drawing.Size(80, 12)
    Me.Label222.TabIndex = 109
    Me.Label222.Text = "檢測取像Delay"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.CheckAdv_Calib_LeftRight)
    Me.GroupBox1.Controls.Add(Me.CheckAdv_Calib_UpDown)
    Me.GroupBox1.Controls.Add(Me.GroupAdv_Calib_ImageAdjust)
    Me.GroupBox1.Controls.Add(Me.GroupAdv_Calib_Distance)
    Me.GroupBox1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold)
    Me.GroupBox1.Location = New System.Drawing.Point(9, 321)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(350, 473)
    Me.GroupBox1.TabIndex = 100
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "CCD 距離校正"
    '
    'CheckAdv_Calib_LeftRight
    '
    Me.CheckAdv_Calib_LeftRight.AutoSize = True
    Me.CheckAdv_Calib_LeftRight.Checked = True
    Me.CheckAdv_Calib_LeftRight.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckAdv_Calib_LeftRight.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckAdv_Calib_LeftRight.Location = New System.Drawing.Point(13, 21)
    Me.CheckAdv_Calib_LeftRight.Name = "CheckAdv_Calib_LeftRight"
    Me.CheckAdv_Calib_LeftRight.Size = New System.Drawing.Size(108, 16)
    Me.CheckAdv_Calib_LeftRight.TabIndex = 142
    Me.CheckAdv_Calib_LeftRight.TabStop = False
    Me.CheckAdv_Calib_LeftRight.Text = "左右孔距離校正"
    Me.CheckAdv_Calib_LeftRight.UseVisualStyleBackColor = True
    '
    'CheckAdv_Calib_UpDown
    '
    Me.CheckAdv_Calib_UpDown.AutoSize = True
    Me.CheckAdv_Calib_UpDown.Checked = True
    Me.CheckAdv_Calib_UpDown.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckAdv_Calib_UpDown.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckAdv_Calib_UpDown.Location = New System.Drawing.Point(138, 21)
    Me.CheckAdv_Calib_UpDown.Name = "CheckAdv_Calib_UpDown"
    Me.CheckAdv_Calib_UpDown.Size = New System.Drawing.Size(108, 16)
    Me.CheckAdv_Calib_UpDown.TabIndex = 141
    Me.CheckAdv_Calib_UpDown.TabStop = False
    Me.CheckAdv_Calib_UpDown.Text = "上下孔距離校正"
    Me.CheckAdv_Calib_UpDown.UseVisualStyleBackColor = True
    '
    'GroupAdv_Calib_ImageAdjust
    '
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.CheckAdv_Calib_RejectBorder)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.Label21)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.TrackBarAdv_Calib_BinaryMax)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.TextAdv_Calib_BinaryMax)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.UpDownAdv_Calib_Remove)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.TrackBarAdv_Calib_BinaryMin)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.TextAdv_Calib_BinaryMin)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.Label23)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.BtnAdv_Calib_Fill)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.Label24)
    Me.GroupAdv_Calib_ImageAdjust.Controls.Add(Me.BtnAdv_Calib_RejectBorder)
    Me.GroupAdv_Calib_ImageAdjust.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Bold)
    Me.GroupAdv_Calib_ImageAdjust.Location = New System.Drawing.Point(6, 46)
    Me.GroupAdv_Calib_ImageAdjust.Name = "GroupAdv_Calib_ImageAdjust"
    Me.GroupAdv_Calib_ImageAdjust.Size = New System.Drawing.Size(337, 167)
    Me.GroupAdv_Calib_ImageAdjust.TabIndex = 93
    Me.GroupAdv_Calib_ImageAdjust.TabStop = False
    Me.GroupAdv_Calib_ImageAdjust.Text = "影像處理"
    '
    'CheckAdv_Calib_RejectBorder
    '
    Me.CheckAdv_Calib_RejectBorder.AutoSize = True
    Me.CheckAdv_Calib_RejectBorder.BackColor = System.Drawing.SystemColors.Control
    Me.CheckAdv_Calib_RejectBorder.Checked = True
    Me.CheckAdv_Calib_RejectBorder.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckAdv_Calib_RejectBorder.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.CheckAdv_Calib_RejectBorder.Location = New System.Drawing.Point(18, 76)
    Me.CheckAdv_Calib_RejectBorder.Name = "CheckAdv_Calib_RejectBorder"
    Me.CheckAdv_Calib_RejectBorder.Size = New System.Drawing.Size(15, 14)
    Me.CheckAdv_Calib_RejectBorder.TabIndex = 94
    Me.CheckAdv_Calib_RejectBorder.TabStop = False
    Me.CheckAdv_Calib_RejectBorder.UseVisualStyleBackColor = False
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label21.Location = New System.Drawing.Point(11, 48)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(70, 12)
    Me.Label21.TabIndex = 50
    Me.Label21.Text = "二值化(Max)"
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TrackBarAdv_Calib_BinaryMax
    '
    Me.TrackBarAdv_Calib_BinaryMax.AutoSize = False
    Me.TrackBarAdv_Calib_BinaryMax.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TrackBarAdv_Calib_BinaryMax.Location = New System.Drawing.Point(78, 43)
    Me.TrackBarAdv_Calib_BinaryMax.Maximum = 255
    Me.TrackBarAdv_Calib_BinaryMax.Name = "TrackBarAdv_Calib_BinaryMax"
    Me.TrackBarAdv_Calib_BinaryMax.Size = New System.Drawing.Size(202, 23)
    Me.TrackBarAdv_Calib_BinaryMax.TabIndex = 48
    Me.TrackBarAdv_Calib_BinaryMax.Tag = "1"
    Me.TrackBarAdv_Calib_BinaryMax.TickFrequency = 10
    Me.TrackBarAdv_Calib_BinaryMax.TickStyle = System.Windows.Forms.TickStyle.None
    Me.TrackBarAdv_Calib_BinaryMax.Value = 255
    '
    'TextAdv_Calib_BinaryMax
    '
    Me.TextAdv_Calib_BinaryMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Calib_BinaryMax.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Calib_BinaryMax.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Calib_BinaryMax.Location = New System.Drawing.Point(281, 43)
    Me.TextAdv_Calib_BinaryMax.MaxLength = 3
    Me.TextAdv_Calib_BinaryMax.Name = "TextAdv_Calib_BinaryMax"
    Me.TextAdv_Calib_BinaryMax.Size = New System.Drawing.Size(37, 25)
    Me.TextAdv_Calib_BinaryMax.TabIndex = 49
    Me.TextAdv_Calib_BinaryMax.Tag = "1"
    Me.TextAdv_Calib_BinaryMax.Text = "255"
    Me.TextAdv_Calib_BinaryMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'UpDownAdv_Calib_Remove
    '
    Me.UpDownAdv_Calib_Remove.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.UpDownAdv_Calib_Remove.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UpDownAdv_Calib_Remove.ForeColor = System.Drawing.Color.Blue
    Me.UpDownAdv_Calib_Remove.Location = New System.Drawing.Point(63, 101)
    Me.UpDownAdv_Calib_Remove.Name = "UpDownAdv_Calib_Remove"
    Me.UpDownAdv_Calib_Remove.Size = New System.Drawing.Size(120, 25)
    Me.UpDownAdv_Calib_Remove.TabIndex = 47
    Me.UpDownAdv_Calib_Remove.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.UpDownAdv_Calib_Remove.Value = New Decimal(New Integer() {20, 0, 0, 0})
    '
    'TrackBarAdv_Calib_BinaryMin
    '
    Me.TrackBarAdv_Calib_BinaryMin.AutoSize = False
    Me.TrackBarAdv_Calib_BinaryMin.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TrackBarAdv_Calib_BinaryMin.Location = New System.Drawing.Point(78, 16)
    Me.TrackBarAdv_Calib_BinaryMin.Maximum = 255
    Me.TrackBarAdv_Calib_BinaryMin.Name = "TrackBarAdv_Calib_BinaryMin"
    Me.TrackBarAdv_Calib_BinaryMin.Size = New System.Drawing.Size(202, 23)
    Me.TrackBarAdv_Calib_BinaryMin.TabIndex = 45
    Me.TrackBarAdv_Calib_BinaryMin.Tag = "1"
    Me.TrackBarAdv_Calib_BinaryMin.TickFrequency = 10
    Me.TrackBarAdv_Calib_BinaryMin.TickStyle = System.Windows.Forms.TickStyle.None
    Me.TrackBarAdv_Calib_BinaryMin.Value = 200
    '
    'TextAdv_Calib_BinaryMin
    '
    Me.TextAdv_Calib_BinaryMin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Calib_BinaryMin.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Calib_BinaryMin.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Calib_BinaryMin.Location = New System.Drawing.Point(281, 16)
    Me.TextAdv_Calib_BinaryMin.MaxLength = 3
    Me.TextAdv_Calib_BinaryMin.Name = "TextAdv_Calib_BinaryMin"
    Me.TextAdv_Calib_BinaryMin.Size = New System.Drawing.Size(37, 25)
    Me.TextAdv_Calib_BinaryMin.TabIndex = 46
    Me.TextAdv_Calib_BinaryMin.Tag = "1"
    Me.TextAdv_Calib_BinaryMin.Text = "200"
    Me.TextAdv_Calib_BinaryMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label23.Location = New System.Drawing.Point(11, 107)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(53, 12)
    Me.Label23.TabIndex = 40
    Me.Label23.Text = "濾除雜點"
    Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnAdv_Calib_Fill
    '
    Me.BtnAdv_Calib_Fill.BackColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_Calib_Fill.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_Calib_Fill.FlatAppearance.BorderSize = 2
    Me.BtnAdv_Calib_Fill.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnAdv_Calib_Fill.Location = New System.Drawing.Point(10, 128)
    Me.BtnAdv_Calib_Fill.Name = "BtnAdv_Calib_Fill"
    Me.BtnAdv_Calib_Fill.Size = New System.Drawing.Size(175, 34)
    Me.BtnAdv_Calib_Fill.TabIndex = 38
    Me.BtnAdv_Calib_Fill.Tag = "校正"
    Me.BtnAdv_Calib_Fill.Text = "填滿"
    Me.BtnAdv_Calib_Fill.UseVisualStyleBackColor = False
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label24.Location = New System.Drawing.Point(11, 21)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(68, 12)
    Me.Label24.TabIndex = 39
    Me.Label24.Text = "二值化(Min)"
    Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnAdv_Calib_RejectBorder
    '
    Me.BtnAdv_Calib_RejectBorder.BackColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_Calib_RejectBorder.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_Calib_RejectBorder.FlatAppearance.BorderSize = 2
    Me.BtnAdv_Calib_RejectBorder.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnAdv_Calib_RejectBorder.Location = New System.Drawing.Point(10, 65)
    Me.BtnAdv_Calib_RejectBorder.Name = "BtnAdv_Calib_RejectBorder"
    Me.BtnAdv_Calib_RejectBorder.Size = New System.Drawing.Size(175, 34)
    Me.BtnAdv_Calib_RejectBorder.TabIndex = 99
    Me.BtnAdv_Calib_RejectBorder.Tag = "校正"
    Me.BtnAdv_Calib_RejectBorder.Text = "濾除邊"
    Me.BtnAdv_Calib_RejectBorder.UseVisualStyleBackColor = False
    '
    'GroupAdv_Calib_Distance
    '
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.TextAdv_Distance_UpDown_Offset)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label3)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label4)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.TextAdv_Distance_LeftRight_Offset)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label1)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label2)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.TextAdv_Angle_UpDown)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.TextAdv_Angle_LeftRight)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label52)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label47)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label53)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label50)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.TextAdv_CalibTool_DistanceY)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label22)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label25)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.TextAdv_CalibTool_DistanceX)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label26)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label27)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.TextAdv_Distance_UpDown)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label11)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label12)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.BtnAdv_Calib_CcdDistance)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.TextAdv_Distance_LeftRight)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label5)
    Me.GroupAdv_Calib_Distance.Controls.Add(Me.Label6)
    Me.GroupAdv_Calib_Distance.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupAdv_Calib_Distance.Location = New System.Drawing.Point(6, 219)
    Me.GroupAdv_Calib_Distance.Name = "GroupAdv_Calib_Distance"
    Me.GroupAdv_Calib_Distance.Size = New System.Drawing.Size(337, 247)
    Me.GroupAdv_Calib_Distance.TabIndex = 0
    Me.GroupAdv_Calib_Distance.TabStop = False
    Me.GroupAdv_Calib_Distance.Text = "校正"
    '
    'TextAdv_Distance_UpDown_Offset
    '
    Me.TextAdv_Distance_UpDown_Offset.BackColor = System.Drawing.Color.LemonChiffon
    Me.TextAdv_Distance_UpDown_Offset.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.TextAdv_Distance_UpDown_Offset.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Distance_UpDown_Offset.Location = New System.Drawing.Point(129, 219)
    Me.TextAdv_Distance_UpDown_Offset.Name = "TextAdv_Distance_UpDown_Offset"
    Me.TextAdv_Distance_UpDown_Offset.Size = New System.Drawing.Size(67, 22)
    Me.TextAdv_Distance_UpDown_Offset.TabIndex = 29
    Me.TextAdv_Distance_UpDown_Offset.Text = "0"
    Me.TextAdv_Distance_UpDown_Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(10, 222)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(111, 15)
    Me.Label3.TabIndex = 28
    Me.Label3.Text = "上下孔距離(補償值)"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(195, 222)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(29, 15)
    Me.Label4.TabIndex = 30
    Me.Label4.Text = "mm"
    '
    'TextAdv_Distance_LeftRight_Offset
    '
    Me.TextAdv_Distance_LeftRight_Offset.BackColor = System.Drawing.Color.LemonChiffon
    Me.TextAdv_Distance_LeftRight_Offset.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.TextAdv_Distance_LeftRight_Offset.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Distance_LeftRight_Offset.Location = New System.Drawing.Point(129, 195)
    Me.TextAdv_Distance_LeftRight_Offset.Name = "TextAdv_Distance_LeftRight_Offset"
    Me.TextAdv_Distance_LeftRight_Offset.Size = New System.Drawing.Size(67, 22)
    Me.TextAdv_Distance_LeftRight_Offset.TabIndex = 26
    Me.TextAdv_Distance_LeftRight_Offset.Text = "0"
    Me.TextAdv_Distance_LeftRight_Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(10, 198)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(111, 15)
    Me.Label1.TabIndex = 25
    Me.Label1.Text = "左右孔距離(補償值)"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(195, 198)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(29, 15)
    Me.Label2.TabIndex = 27
    Me.Label2.Text = "mm"
    '
    'TextAdv_Angle_UpDown
    '
    Me.TextAdv_Angle_UpDown.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TextAdv_Angle_UpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextAdv_Angle_UpDown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.TextAdv_Angle_UpDown.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Angle_UpDown.Location = New System.Drawing.Point(129, 127)
    Me.TextAdv_Angle_UpDown.Name = "TextAdv_Angle_UpDown"
    Me.TextAdv_Angle_UpDown.ReadOnly = True
    Me.TextAdv_Angle_UpDown.Size = New System.Drawing.Size(67, 22)
    Me.TextAdv_Angle_UpDown.TabIndex = 23
    Me.TextAdv_Angle_UpDown.Text = "0"
    Me.TextAdv_Angle_UpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextAdv_Angle_LeftRight
    '
    Me.TextAdv_Angle_LeftRight.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TextAdv_Angle_LeftRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextAdv_Angle_LeftRight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.TextAdv_Angle_LeftRight.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Angle_LeftRight.Location = New System.Drawing.Point(129, 81)
    Me.TextAdv_Angle_LeftRight.Name = "TextAdv_Angle_LeftRight"
    Me.TextAdv_Angle_LeftRight.ReadOnly = True
    Me.TextAdv_Angle_LeftRight.Size = New System.Drawing.Size(67, 22)
    Me.TextAdv_Angle_LeftRight.TabIndex = 20
    Me.TextAdv_Angle_LeftRight.Text = "0"
    Me.TextAdv_Angle_LeftRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label52
    '
    Me.Label52.AutoSize = True
    Me.Label52.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label52.Location = New System.Drawing.Point(10, 130)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(111, 15)
    Me.Label52.TabIndex = 22
    Me.Label52.Text = "上下孔角度(校正值)"
    '
    'Label47
    '
    Me.Label47.AutoSize = True
    Me.Label47.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.Location = New System.Drawing.Point(10, 84)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(111, 15)
    Me.Label47.TabIndex = 19
    Me.Label47.Text = "左右孔角度(校正值)"
    '
    'Label53
    '
    Me.Label53.AutoSize = True
    Me.Label53.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label53.Location = New System.Drawing.Point(195, 130)
    Me.Label53.Name = "Label53"
    Me.Label53.Size = New System.Drawing.Size(19, 15)
    Me.Label53.TabIndex = 24
    Me.Label53.Text = "度"
    '
    'Label50
    '
    Me.Label50.AutoSize = True
    Me.Label50.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label50.Location = New System.Drawing.Point(195, 80)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(19, 15)
    Me.Label50.TabIndex = 21
    Me.Label50.Text = "度"
    '
    'TextAdv_CalibTool_DistanceY
    '
    Me.TextAdv_CalibTool_DistanceY.BackColor = System.Drawing.Color.LemonChiffon
    Me.TextAdv_CalibTool_DistanceY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.TextAdv_CalibTool_DistanceY.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_CalibTool_DistanceY.Location = New System.Drawing.Point(129, 35)
    Me.TextAdv_CalibTool_DistanceY.Name = "TextAdv_CalibTool_DistanceY"
    Me.TextAdv_CalibTool_DistanceY.Size = New System.Drawing.Size(67, 22)
    Me.TextAdv_CalibTool_DistanceY.TabIndex = 17
    Me.TextAdv_CalibTool_DistanceY.Text = "14"
    Me.TextAdv_CalibTool_DistanceY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.Location = New System.Drawing.Point(10, 38)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(99, 15)
    Me.Label22.TabIndex = 16
    Me.Label22.Text = "校正片距離(上下)"
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(195, 38)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(29, 15)
    Me.Label25.TabIndex = 18
    Me.Label25.Text = "mm"
    '
    'TextAdv_CalibTool_DistanceX
    '
    Me.TextAdv_CalibTool_DistanceX.BackColor = System.Drawing.Color.LemonChiffon
    Me.TextAdv_CalibTool_DistanceX.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.TextAdv_CalibTool_DistanceX.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_CalibTool_DistanceX.Location = New System.Drawing.Point(129, 12)
    Me.TextAdv_CalibTool_DistanceX.Name = "TextAdv_CalibTool_DistanceX"
    Me.TextAdv_CalibTool_DistanceX.Size = New System.Drawing.Size(67, 22)
    Me.TextAdv_CalibTool_DistanceX.TabIndex = 14
    Me.TextAdv_CalibTool_DistanceX.Text = "14"
    Me.TextAdv_CalibTool_DistanceX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label26
    '
    Me.Label26.AutoSize = True
    Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label26.Location = New System.Drawing.Point(10, 15)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(99, 15)
    Me.Label26.TabIndex = 13
    Me.Label26.Text = "校正片距離(左右)"
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label27.Location = New System.Drawing.Point(195, 15)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(29, 15)
    Me.Label27.TabIndex = 15
    Me.Label27.Text = "mm"
    '
    'TextAdv_Distance_UpDown
    '
    Me.TextAdv_Distance_UpDown.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TextAdv_Distance_UpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextAdv_Distance_UpDown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.TextAdv_Distance_UpDown.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Distance_UpDown.Location = New System.Drawing.Point(129, 104)
    Me.TextAdv_Distance_UpDown.Name = "TextAdv_Distance_UpDown"
    Me.TextAdv_Distance_UpDown.ReadOnly = True
    Me.TextAdv_Distance_UpDown.Size = New System.Drawing.Size(67, 22)
    Me.TextAdv_Distance_UpDown.TabIndex = 8
    Me.TextAdv_Distance_UpDown.Text = "0"
    Me.TextAdv_Distance_UpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(10, 107)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(111, 15)
    Me.Label11.TabIndex = 7
    Me.Label11.Text = "上下孔距離(校正值)"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(195, 107)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(29, 15)
    Me.Label12.TabIndex = 9
    Me.Label12.Text = "mm"
    '
    'BtnAdv_Calib_CcdDistance
    '
    Me.BtnAdv_Calib_CcdDistance.BackColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_Calib_CcdDistance.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnAdv_Calib_CcdDistance.Location = New System.Drawing.Point(230, 12)
    Me.BtnAdv_Calib_CcdDistance.Name = "BtnAdv_Calib_CcdDistance"
    Me.BtnAdv_Calib_CcdDistance.Size = New System.Drawing.Size(98, 95)
    Me.BtnAdv_Calib_CcdDistance.TabIndex = 6
    Me.BtnAdv_Calib_CcdDistance.Tag = "距離校正"
    Me.BtnAdv_Calib_CcdDistance.Text = "校正"
    Me.BtnAdv_Calib_CcdDistance.UseVisualStyleBackColor = False
    '
    'TextAdv_Distance_LeftRight
    '
    Me.TextAdv_Distance_LeftRight.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TextAdv_Distance_LeftRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextAdv_Distance_LeftRight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
    Me.TextAdv_Distance_LeftRight.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Distance_LeftRight.Location = New System.Drawing.Point(129, 58)
    Me.TextAdv_Distance_LeftRight.Name = "TextAdv_Distance_LeftRight"
    Me.TextAdv_Distance_LeftRight.ReadOnly = True
    Me.TextAdv_Distance_LeftRight.Size = New System.Drawing.Size(67, 22)
    Me.TextAdv_Distance_LeftRight.TabIndex = 1
    Me.TextAdv_Distance_LeftRight.Text = "0"
    Me.TextAdv_Distance_LeftRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(10, 61)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(111, 15)
    Me.Label5.TabIndex = 0
    Me.Label5.Text = "左右孔距離(校正值)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(195, 61)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(29, 15)
    Me.Label6.TabIndex = 2
    Me.Label6.Text = "mm"
    '
    'GroupAdv_Calib_Pixel
    '
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.RadioAdv_Pixel_CCD4)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.RadioAdv_Pixel_CCD3)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.RadioAdv_Pixel_CCD2)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.RadioAdv_Pixel_CCD1)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.LabAdv_FovY_CCD4)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.LabAdv_FovX_CCD4)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.LabAdv_FovY_CCD3)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.LabAdv_FovX_CCD3)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.LabAdv_FovY_CCD2)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.LabAdv_FovX_CCD2)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.TextAdv_Pixel_CCD4)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.TextAdv_Pixel_CCD3)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.TextAdv_Pixel_CCD2)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.LabAdv_FovY_CCD1)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.BtnAdv_Calib_Pixel)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.LabAdv_FovX_CCD1)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.Label99)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.TextAdv_CircleSize)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.Label28)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.TextAdv_Pixel_CCD1)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.Label45)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.Label29)
    Me.GroupAdv_Calib_Pixel.Controls.Add(Me.Label30)
    Me.GroupAdv_Calib_Pixel.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold)
    Me.GroupAdv_Calib_Pixel.Location = New System.Drawing.Point(9, 153)
    Me.GroupAdv_Calib_Pixel.Name = "GroupAdv_Calib_Pixel"
    Me.GroupAdv_Calib_Pixel.Size = New System.Drawing.Size(350, 162)
    Me.GroupAdv_Calib_Pixel.TabIndex = 99
    Me.GroupAdv_Calib_Pixel.TabStop = False
    Me.GroupAdv_Calib_Pixel.Text = "Pixel 校正"
    '
    'RadioAdv_Pixel_CCD4
    '
    Me.RadioAdv_Pixel_CCD4.AutoSize = True
    Me.RadioAdv_Pixel_CCD4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioAdv_Pixel_CCD4.Location = New System.Drawing.Point(214, 55)
    Me.RadioAdv_Pixel_CCD4.Name = "RadioAdv_Pixel_CCD4"
    Me.RadioAdv_Pixel_CCD4.Size = New System.Drawing.Size(14, 13)
    Me.RadioAdv_Pixel_CCD4.TabIndex = 136
    Me.RadioAdv_Pixel_CCD4.Tag = "4"
    Me.RadioAdv_Pixel_CCD4.TextAlign = System.Drawing.ContentAlignment.TopLeft
    Me.RadioAdv_Pixel_CCD4.UseVisualStyleBackColor = True
    '
    'RadioAdv_Pixel_CCD3
    '
    Me.RadioAdv_Pixel_CCD3.AutoSize = True
    Me.RadioAdv_Pixel_CCD3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioAdv_Pixel_CCD3.Location = New System.Drawing.Point(171, 55)
    Me.RadioAdv_Pixel_CCD3.Name = "RadioAdv_Pixel_CCD3"
    Me.RadioAdv_Pixel_CCD3.Size = New System.Drawing.Size(14, 13)
    Me.RadioAdv_Pixel_CCD3.TabIndex = 135
    Me.RadioAdv_Pixel_CCD3.Tag = "3"
    Me.RadioAdv_Pixel_CCD3.TextAlign = System.Drawing.ContentAlignment.TopLeft
    Me.RadioAdv_Pixel_CCD3.UseVisualStyleBackColor = True
    '
    'RadioAdv_Pixel_CCD2
    '
    Me.RadioAdv_Pixel_CCD2.AutoSize = True
    Me.RadioAdv_Pixel_CCD2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioAdv_Pixel_CCD2.Location = New System.Drawing.Point(128, 55)
    Me.RadioAdv_Pixel_CCD2.Name = "RadioAdv_Pixel_CCD2"
    Me.RadioAdv_Pixel_CCD2.Size = New System.Drawing.Size(14, 13)
    Me.RadioAdv_Pixel_CCD2.TabIndex = 134
    Me.RadioAdv_Pixel_CCD2.Tag = "2"
    Me.RadioAdv_Pixel_CCD2.TextAlign = System.Drawing.ContentAlignment.TopLeft
    Me.RadioAdv_Pixel_CCD2.UseVisualStyleBackColor = True
    '
    'RadioAdv_Pixel_CCD1
    '
    Me.RadioAdv_Pixel_CCD1.AutoSize = True
    Me.RadioAdv_Pixel_CCD1.Checked = True
    Me.RadioAdv_Pixel_CCD1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioAdv_Pixel_CCD1.Location = New System.Drawing.Point(85, 55)
    Me.RadioAdv_Pixel_CCD1.Name = "RadioAdv_Pixel_CCD1"
    Me.RadioAdv_Pixel_CCD1.Size = New System.Drawing.Size(14, 13)
    Me.RadioAdv_Pixel_CCD1.TabIndex = 133
    Me.RadioAdv_Pixel_CCD1.TabStop = True
    Me.RadioAdv_Pixel_CCD1.Tag = "1"
    Me.RadioAdv_Pixel_CCD1.TextAlign = System.Drawing.ContentAlignment.TopLeft
    Me.RadioAdv_Pixel_CCD1.UseVisualStyleBackColor = True
    '
    'LabAdv_FovY_CCD4
    '
    Me.LabAdv_FovY_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabAdv_FovY_CCD4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAdv_FovY_CCD4.ForeColor = System.Drawing.Color.Blue
    Me.LabAdv_FovY_CCD4.Location = New System.Drawing.Point(200, 130)
    Me.LabAdv_FovY_CCD4.Name = "LabAdv_FovY_CCD4"
    Me.LabAdv_FovY_CCD4.Size = New System.Drawing.Size(43, 21)
    Me.LabAdv_FovY_CCD4.TabIndex = 132
    Me.LabAdv_FovY_CCD4.Tag = "4"
    Me.LabAdv_FovY_CCD4.Text = "0"
    Me.LabAdv_FovY_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabAdv_FovX_CCD4
    '
    Me.LabAdv_FovX_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabAdv_FovX_CCD4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAdv_FovX_CCD4.ForeColor = System.Drawing.Color.Blue
    Me.LabAdv_FovX_CCD4.Location = New System.Drawing.Point(200, 110)
    Me.LabAdv_FovX_CCD4.Name = "LabAdv_FovX_CCD4"
    Me.LabAdv_FovX_CCD4.Size = New System.Drawing.Size(43, 21)
    Me.LabAdv_FovX_CCD4.TabIndex = 131
    Me.LabAdv_FovX_CCD4.Tag = "4"
    Me.LabAdv_FovX_CCD4.Text = "0"
    Me.LabAdv_FovX_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabAdv_FovY_CCD3
    '
    Me.LabAdv_FovY_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabAdv_FovY_CCD3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAdv_FovY_CCD3.ForeColor = System.Drawing.Color.Blue
    Me.LabAdv_FovY_CCD3.Location = New System.Drawing.Point(157, 130)
    Me.LabAdv_FovY_CCD3.Name = "LabAdv_FovY_CCD3"
    Me.LabAdv_FovY_CCD3.Size = New System.Drawing.Size(43, 21)
    Me.LabAdv_FovY_CCD3.TabIndex = 130
    Me.LabAdv_FovY_CCD3.Tag = "3"
    Me.LabAdv_FovY_CCD3.Text = "0"
    Me.LabAdv_FovY_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabAdv_FovX_CCD3
    '
    Me.LabAdv_FovX_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabAdv_FovX_CCD3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAdv_FovX_CCD3.ForeColor = System.Drawing.Color.Blue
    Me.LabAdv_FovX_CCD3.Location = New System.Drawing.Point(157, 110)
    Me.LabAdv_FovX_CCD3.Name = "LabAdv_FovX_CCD3"
    Me.LabAdv_FovX_CCD3.Size = New System.Drawing.Size(43, 21)
    Me.LabAdv_FovX_CCD3.TabIndex = 129
    Me.LabAdv_FovX_CCD3.Tag = "3"
    Me.LabAdv_FovX_CCD3.Text = "0"
    Me.LabAdv_FovX_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabAdv_FovY_CCD2
    '
    Me.LabAdv_FovY_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabAdv_FovY_CCD2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAdv_FovY_CCD2.ForeColor = System.Drawing.Color.Blue
    Me.LabAdv_FovY_CCD2.Location = New System.Drawing.Point(114, 130)
    Me.LabAdv_FovY_CCD2.Name = "LabAdv_FovY_CCD2"
    Me.LabAdv_FovY_CCD2.Size = New System.Drawing.Size(43, 21)
    Me.LabAdv_FovY_CCD2.TabIndex = 128
    Me.LabAdv_FovY_CCD2.Tag = "2"
    Me.LabAdv_FovY_CCD2.Text = "0"
    Me.LabAdv_FovY_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabAdv_FovX_CCD2
    '
    Me.LabAdv_FovX_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabAdv_FovX_CCD2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAdv_FovX_CCD2.ForeColor = System.Drawing.Color.Blue
    Me.LabAdv_FovX_CCD2.Location = New System.Drawing.Point(114, 110)
    Me.LabAdv_FovX_CCD2.Name = "LabAdv_FovX_CCD2"
    Me.LabAdv_FovX_CCD2.Size = New System.Drawing.Size(43, 21)
    Me.LabAdv_FovX_CCD2.TabIndex = 127
    Me.LabAdv_FovX_CCD2.Tag = "2"
    Me.LabAdv_FovX_CCD2.Text = "0"
    Me.LabAdv_FovX_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextAdv_Pixel_CCD4
    '
    Me.TextAdv_Pixel_CCD4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Pixel_CCD4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Pixel_CCD4.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Pixel_CCD4.Location = New System.Drawing.Point(200, 84)
    Me.TextAdv_Pixel_CCD4.MaxLength = 3
    Me.TextAdv_Pixel_CCD4.Name = "TextAdv_Pixel_CCD4"
    Me.TextAdv_Pixel_CCD4.Size = New System.Drawing.Size(42, 22)
    Me.TextAdv_Pixel_CCD4.TabIndex = 125
    Me.TextAdv_Pixel_CCD4.Tag = "4"
    Me.TextAdv_Pixel_CCD4.Text = "1.2"
    Me.TextAdv_Pixel_CCD4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextAdv_Pixel_CCD3
    '
    Me.TextAdv_Pixel_CCD3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Pixel_CCD3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Pixel_CCD3.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Pixel_CCD3.Location = New System.Drawing.Point(157, 84)
    Me.TextAdv_Pixel_CCD3.MaxLength = 3
    Me.TextAdv_Pixel_CCD3.Name = "TextAdv_Pixel_CCD3"
    Me.TextAdv_Pixel_CCD3.Size = New System.Drawing.Size(42, 22)
    Me.TextAdv_Pixel_CCD3.TabIndex = 124
    Me.TextAdv_Pixel_CCD3.Tag = "3"
    Me.TextAdv_Pixel_CCD3.Text = "1.2"
    Me.TextAdv_Pixel_CCD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextAdv_Pixel_CCD2
    '
    Me.TextAdv_Pixel_CCD2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Pixel_CCD2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Pixel_CCD2.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Pixel_CCD2.Location = New System.Drawing.Point(114, 84)
    Me.TextAdv_Pixel_CCD2.MaxLength = 3
    Me.TextAdv_Pixel_CCD2.Name = "TextAdv_Pixel_CCD2"
    Me.TextAdv_Pixel_CCD2.Size = New System.Drawing.Size(42, 22)
    Me.TextAdv_Pixel_CCD2.TabIndex = 123
    Me.TextAdv_Pixel_CCD2.Tag = "2"
    Me.TextAdv_Pixel_CCD2.Text = "1.2"
    Me.TextAdv_Pixel_CCD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LabAdv_FovY_CCD1
    '
    Me.LabAdv_FovY_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabAdv_FovY_CCD1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAdv_FovY_CCD1.ForeColor = System.Drawing.Color.Blue
    Me.LabAdv_FovY_CCD1.Location = New System.Drawing.Point(71, 130)
    Me.LabAdv_FovY_CCD1.Name = "LabAdv_FovY_CCD1"
    Me.LabAdv_FovY_CCD1.Size = New System.Drawing.Size(43, 21)
    Me.LabAdv_FovY_CCD1.TabIndex = 121
    Me.LabAdv_FovY_CCD1.Tag = "1"
    Me.LabAdv_FovY_CCD1.Text = "0"
    Me.LabAdv_FovY_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnAdv_Calib_Pixel
    '
    Me.BtnAdv_Calib_Pixel.BackColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_Calib_Pixel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnAdv_Calib_Pixel.Location = New System.Drawing.Point(276, 84)
    Me.BtnAdv_Calib_Pixel.Name = "BtnAdv_Calib_Pixel"
    Me.BtnAdv_Calib_Pixel.Size = New System.Drawing.Size(66, 68)
    Me.BtnAdv_Calib_Pixel.TabIndex = 71
    Me.BtnAdv_Calib_Pixel.Tag = "Pixel 校正"
    Me.BtnAdv_Calib_Pixel.Text = "校正"
    Me.BtnAdv_Calib_Pixel.UseVisualStyleBackColor = False
    '
    'LabAdv_FovX_CCD1
    '
    Me.LabAdv_FovX_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabAdv_FovX_CCD1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabAdv_FovX_CCD1.ForeColor = System.Drawing.Color.Blue
    Me.LabAdv_FovX_CCD1.Location = New System.Drawing.Point(71, 110)
    Me.LabAdv_FovX_CCD1.Name = "LabAdv_FovX_CCD1"
    Me.LabAdv_FovX_CCD1.Size = New System.Drawing.Size(43, 21)
    Me.LabAdv_FovX_CCD1.TabIndex = 120
    Me.LabAdv_FovX_CCD1.Tag = "1"
    Me.LabAdv_FovX_CCD1.Text = "0"
    Me.LabAdv_FovX_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label99
    '
    Me.Label99.AutoSize = True
    Me.Label99.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.Label99.Location = New System.Drawing.Point(5, 113)
    Me.Label99.Name = "Label99"
    Me.Label99.Size = New System.Drawing.Size(269, 15)
    Me.Label99.TabIndex = 48
    Me.Label99.Text = "CCD Fov X                                                             mm"
    '
    'TextAdv_CircleSize
    '
    Me.TextAdv_CircleSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_CircleSize.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_CircleSize.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_CircleSize.Location = New System.Drawing.Point(71, 23)
    Me.TextAdv_CircleSize.MaxLength = 5
    Me.TextAdv_CircleSize.Name = "TextAdv_CircleSize"
    Me.TextAdv_CircleSize.Size = New System.Drawing.Size(42, 22)
    Me.TextAdv_CircleSize.TabIndex = 73
    Me.TextAdv_CircleSize.TabStop = False
    Me.TextAdv_CircleSize.Text = "1"
    Me.TextAdv_CircleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label28
    '
    Me.Label28.AutoSize = True
    Me.Label28.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label28.Location = New System.Drawing.Point(5, 25)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(137, 15)
    Me.Label28.TabIndex = 72
    Me.Label28.Text = "Circle Size                mm"
    '
    'TextAdv_Pixel_CCD1
    '
    Me.TextAdv_Pixel_CCD1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Pixel_CCD1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Pixel_CCD1.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Pixel_CCD1.Location = New System.Drawing.Point(71, 84)
    Me.TextAdv_Pixel_CCD1.MaxLength = 3
    Me.TextAdv_Pixel_CCD1.Name = "TextAdv_Pixel_CCD1"
    Me.TextAdv_Pixel_CCD1.Size = New System.Drawing.Size(42, 22)
    Me.TextAdv_Pixel_CCD1.TabIndex = 70
    Me.TextAdv_Pixel_CCD1.Tag = "1"
    Me.TextAdv_Pixel_CCD1.Text = "1.2"
    Me.TextAdv_Pixel_CCD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label45
    '
    Me.Label45.AutoSize = True
    Me.Label45.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label45.Location = New System.Drawing.Point(5, 88)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(265, 15)
    Me.Label45.TabIndex = 67
    Me.Label45.Text = "1 Pixel=                                                                 um"
    '
    'Label29
    '
    Me.Label29.AutoSize = True
    Me.Label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label29.Location = New System.Drawing.Point(74, 70)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(167, 15)
    Me.Label29.TabIndex = 122
    Me.Label29.Text = "CCD1    CCD2    CCD3    CCD4"
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
    Me.Label30.Location = New System.Drawing.Point(5, 133)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(268, 15)
    Me.Label30.TabIndex = 126
    Me.Label30.Text = "CCD Fov Y                                                             mm"
    '
    'GroupAdv_Calib_Light
    '
    Me.GroupAdv_Calib_Light.Controls.Add(Me.BtnAdv_CalibLight_Off)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.BtnAdv_CalibLight_On)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.TextAdv_Calib_Light4)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.TextAdv_Calib_Light3)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.Label17)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.Label18)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.Label19)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.BtnAdv_CalibLight_Set)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.TextAdv_Calib_Light2)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.TextAdv_Calib_Light1)
    Me.GroupAdv_Calib_Light.Controls.Add(Me.Label20)
    Me.GroupAdv_Calib_Light.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupAdv_Calib_Light.Location = New System.Drawing.Point(9, 25)
    Me.GroupAdv_Calib_Light.Name = "GroupAdv_Calib_Light"
    Me.GroupAdv_Calib_Light.Size = New System.Drawing.Size(253, 122)
    Me.GroupAdv_Calib_Light.TabIndex = 92
    Me.GroupAdv_Calib_Light.TabStop = False
    Me.GroupAdv_Calib_Light.Text = "光源參數(校正)"
    '
    'BtnAdv_CalibLight_Off
    '
    Me.BtnAdv_CalibLight_Off.BackColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_CalibLight_Off.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_CalibLight_Off.FlatAppearance.BorderSize = 2
    Me.BtnAdv_CalibLight_Off.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnAdv_CalibLight_Off.Location = New System.Drawing.Point(179, 66)
    Me.BtnAdv_CalibLight_Off.Name = "BtnAdv_CalibLight_Off"
    Me.BtnAdv_CalibLight_Off.Size = New System.Drawing.Size(67, 49)
    Me.BtnAdv_CalibLight_Off.TabIndex = 46
    Me.BtnAdv_CalibLight_Off.Tag = "校正"
    Me.BtnAdv_CalibLight_Off.Text = "關閉"
    Me.BtnAdv_CalibLight_Off.UseVisualStyleBackColor = False
    '
    'BtnAdv_CalibLight_On
    '
    Me.BtnAdv_CalibLight_On.BackColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_CalibLight_On.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_CalibLight_On.FlatAppearance.BorderSize = 2
    Me.BtnAdv_CalibLight_On.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnAdv_CalibLight_On.Location = New System.Drawing.Point(179, 18)
    Me.BtnAdv_CalibLight_On.Name = "BtnAdv_CalibLight_On"
    Me.BtnAdv_CalibLight_On.Size = New System.Drawing.Size(67, 49)
    Me.BtnAdv_CalibLight_On.TabIndex = 45
    Me.BtnAdv_CalibLight_On.Tag = "校正"
    Me.BtnAdv_CalibLight_On.Text = "開啟"
    Me.BtnAdv_CalibLight_On.UseVisualStyleBackColor = False
    '
    'TextAdv_Calib_Light4
    '
    Me.TextAdv_Calib_Light4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Calib_Light4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Calib_Light4.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Calib_Light4.Location = New System.Drawing.Point(70, 91)
    Me.TextAdv_Calib_Light4.MaxLength = 3
    Me.TextAdv_Calib_Light4.Name = "TextAdv_Calib_Light4"
    Me.TextAdv_Calib_Light4.ReadOnly = True
    Me.TextAdv_Calib_Light4.Size = New System.Drawing.Size(40, 22)
    Me.TextAdv_Calib_Light4.TabIndex = 44
    Me.TextAdv_Calib_Light4.Tag = "1"
    Me.TextAdv_Calib_Light4.Text = "0"
    Me.TextAdv_Calib_Light4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextAdv_Calib_Light3
    '
    Me.TextAdv_Calib_Light3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Calib_Light3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Calib_Light3.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Calib_Light3.Location = New System.Drawing.Point(70, 67)
    Me.TextAdv_Calib_Light3.MaxLength = 3
    Me.TextAdv_Calib_Light3.Name = "TextAdv_Calib_Light3"
    Me.TextAdv_Calib_Light3.ReadOnly = True
    Me.TextAdv_Calib_Light3.Size = New System.Drawing.Size(40, 22)
    Me.TextAdv_Calib_Light3.TabIndex = 43
    Me.TextAdv_Calib_Light3.Tag = "1"
    Me.TextAdv_Calib_Light3.Text = "0"
    Me.TextAdv_Calib_Light3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label17.Location = New System.Drawing.Point(11, 96)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(59, 12)
    Me.Label17.TabIndex = 42
    Me.Label17.Text = "CCD4燈光"
    Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label18.Location = New System.Drawing.Point(11, 72)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(59, 12)
    Me.Label18.TabIndex = 41
    Me.Label18.Text = "CCD3燈光"
    Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label19.Location = New System.Drawing.Point(11, 48)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(59, 12)
    Me.Label19.TabIndex = 40
    Me.Label19.Text = "CCD2燈光"
    Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnAdv_CalibLight_Set
    '
    Me.BtnAdv_CalibLight_Set.BackColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_CalibLight_Set.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnAdv_CalibLight_Set.FlatAppearance.BorderSize = 2
    Me.BtnAdv_CalibLight_Set.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnAdv_CalibLight_Set.Location = New System.Drawing.Point(113, 18)
    Me.BtnAdv_CalibLight_Set.Name = "BtnAdv_CalibLight_Set"
    Me.BtnAdv_CalibLight_Set.Size = New System.Drawing.Size(67, 97)
    Me.BtnAdv_CalibLight_Set.TabIndex = 38
    Me.BtnAdv_CalibLight_Set.Tag = "校正"
    Me.BtnAdv_CalibLight_Set.Text = "設定"
    Me.BtnAdv_CalibLight_Set.UseVisualStyleBackColor = False
    '
    'TextAdv_Calib_Light2
    '
    Me.TextAdv_Calib_Light2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Calib_Light2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Calib_Light2.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Calib_Light2.Location = New System.Drawing.Point(70, 43)
    Me.TextAdv_Calib_Light2.MaxLength = 3
    Me.TextAdv_Calib_Light2.Name = "TextAdv_Calib_Light2"
    Me.TextAdv_Calib_Light2.ReadOnly = True
    Me.TextAdv_Calib_Light2.Size = New System.Drawing.Size(40, 22)
    Me.TextAdv_Calib_Light2.TabIndex = 37
    Me.TextAdv_Calib_Light2.Tag = "1"
    Me.TextAdv_Calib_Light2.Text = "0"
    Me.TextAdv_Calib_Light2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextAdv_Calib_Light1
    '
    Me.TextAdv_Calib_Light1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextAdv_Calib_Light1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextAdv_Calib_Light1.ForeColor = System.Drawing.Color.Blue
    Me.TextAdv_Calib_Light1.Location = New System.Drawing.Point(70, 19)
    Me.TextAdv_Calib_Light1.MaxLength = 3
    Me.TextAdv_Calib_Light1.Name = "TextAdv_Calib_Light1"
    Me.TextAdv_Calib_Light1.ReadOnly = True
    Me.TextAdv_Calib_Light1.Size = New System.Drawing.Size(40, 22)
    Me.TextAdv_Calib_Light1.TabIndex = 36
    Me.TextAdv_Calib_Light1.Tag = "1"
    Me.TextAdv_Calib_Light1.Text = "0"
    Me.TextAdv_Calib_Light1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label20.Location = New System.Drawing.Point(11, 24)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(59, 12)
    Me.Label20.TabIndex = 39
    Me.Label20.Text = "CCD1燈光"
    Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupProduct
    '
    Me.GroupProduct.Controls.Add(Me.Label115)
    Me.GroupProduct.Controls.Add(Me.PanelProduct_Function1)
    Me.GroupProduct.Controls.Add(Me.GroupProduct_Light)
    Me.GroupProduct.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupProduct.Location = New System.Drawing.Point(2, 1)
    Me.GroupProduct.Name = "GroupProduct"
    Me.GroupProduct.Size = New System.Drawing.Size(476, 924)
    Me.GroupProduct.TabIndex = 0
    Me.GroupProduct.TabStop = False
    Me.GroupProduct.Text = "產品參數"
    '
    'Label115
    '
    Me.Label115.AutoSize = True
    Me.Label115.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold)
    Me.Label115.Location = New System.Drawing.Point(16, 150)
    Me.Label115.Name = "Label115"
    Me.Label115.Size = New System.Drawing.Size(63, 13)
    Me.Label115.TabIndex = 115
    Me.Label115.Text = "檢測參數"
    Me.Label115.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'PanelProduct_Function1
    '
    Me.PanelProduct_Function1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.PanelProduct_Function1.Controls.Add(Me.GroupTeach_ImageAdjust_Inside)
    Me.PanelProduct_Function1.Controls.Add(Me.GroupTeach_ImageAdjust_Outside)
    Me.PanelProduct_Function1.Controls.Add(Me.GroupTeach_ImageAdjust_Size)
    Me.PanelProduct_Function1.Controls.Add(Me.GroupTeacht_Spec)
    Me.PanelProduct_Function1.Location = New System.Drawing.Point(10, 155)
    Me.PanelProduct_Function1.Name = "PanelProduct_Function1"
    Me.PanelProduct_Function1.Size = New System.Drawing.Size(456, 750)
    Me.PanelProduct_Function1.TabIndex = 96
    '
    'GroupTeach_ImageAdjust_Inside
    '
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label114)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.TextSearch2_Offset)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label61)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.TextSearch2_Gain)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label62)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.TextSearch2_Inward)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label60)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.TextSearch2_NonContinueCount)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label58)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.TextSearch2_ContinueCount)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label57)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.TextSearch2_Threshold)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label56)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.TextSearch2_CircleDiameter)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label55)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.TextSearch2_MeasureWidth)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.UpDownSearch2_Score)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.BtnSearch2_SetParameter)
    Me.GroupTeach_ImageAdjust_Inside.Controls.Add(Me.Label137)
    Me.GroupTeach_ImageAdjust_Inside.Font = New System.Drawing.Font("新細明體", 9.75!)
    Me.GroupTeach_ImageAdjust_Inside.ForeColor = System.Drawing.Color.MediumBlue
    Me.GroupTeach_ImageAdjust_Inside.Location = New System.Drawing.Point(10, 129)
    Me.GroupTeach_ImageAdjust_Inside.Name = "GroupTeach_ImageAdjust_Inside"
    Me.GroupTeach_ImageAdjust_Inside.Size = New System.Drawing.Size(430, 227)
    Me.GroupTeach_ImageAdjust_Inside.TabIndex = 116
    Me.GroupTeach_ImageAdjust_Inside.TabStop = False
    Me.GroupTeach_ImageAdjust_Inside.Text = "檢測二影像參數(圓內)"
    '
    'Label114
    '
    Me.Label114.AutoSize = True
    Me.Label114.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label114.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label114.Location = New System.Drawing.Point(8, 196)
    Me.Label114.Name = "Label114"
    Me.Label114.Size = New System.Drawing.Size(42, 15)
    Me.Label114.TabIndex = 164
    Me.Label114.Text = "Offset"
    Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextSearch2_Offset
    '
    Me.TextSearch2_Offset.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextSearch2_Offset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextSearch2_Offset.ForeColor = System.Drawing.Color.Blue
    Me.TextSearch2_Offset.Location = New System.Drawing.Point(75, 193)
    Me.TextSearch2_Offset.MaxLength = 5
    Me.TextSearch2_Offset.Name = "TextSearch2_Offset"
    Me.TextSearch2_Offset.Size = New System.Drawing.Size(63, 21)
    Me.TextSearch2_Offset.TabIndex = 163
    Me.TextSearch2_Offset.Tag = ""
    Me.TextSearch2_Offset.Text = "0.00"
    Me.TextSearch2_Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label61
    '
    Me.Label61.AutoSize = True
    Me.Label61.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label61.Location = New System.Drawing.Point(8, 174)
    Me.Label61.Name = "Label61"
    Me.Label61.Size = New System.Drawing.Size(32, 15)
    Me.Label61.TabIndex = 162
    Me.Label61.Text = "Gain"
    Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextSearch2_Gain
    '
    Me.TextSearch2_Gain.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextSearch2_Gain.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextSearch2_Gain.ForeColor = System.Drawing.Color.Blue
    Me.TextSearch2_Gain.Location = New System.Drawing.Point(75, 171)
    Me.TextSearch2_Gain.MaxLength = 5
    Me.TextSearch2_Gain.Name = "TextSearch2_Gain"
    Me.TextSearch2_Gain.Size = New System.Drawing.Size(63, 21)
    Me.TextSearch2_Gain.TabIndex = 161
    Me.TextSearch2_Gain.Tag = ""
    Me.TextSearch2_Gain.Text = "1.00"
    Me.TextSearch2_Gain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label62
    '
    Me.Label62.AutoSize = True
    Me.Label62.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label62.Location = New System.Drawing.Point(8, 154)
    Me.Label62.Name = "Label62"
    Me.Label62.Size = New System.Drawing.Size(53, 12)
    Me.Label62.TabIndex = 160
    Me.Label62.Text = "圓內縮量"
    Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextSearch2_Inward
    '
    Me.TextSearch2_Inward.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextSearch2_Inward.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextSearch2_Inward.ForeColor = System.Drawing.Color.Blue
    Me.TextSearch2_Inward.Location = New System.Drawing.Point(75, 149)
    Me.TextSearch2_Inward.MaxLength = 5
    Me.TextSearch2_Inward.Name = "TextSearch2_Inward"
    Me.TextSearch2_Inward.Size = New System.Drawing.Size(63, 21)
    Me.TextSearch2_Inward.TabIndex = 159
    Me.TextSearch2_Inward.Tag = ""
    Me.TextSearch2_Inward.Text = "-10"
    Me.TextSearch2_Inward.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label60
    '
    Me.Label60.AutoSize = True
    Me.Label60.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label60.Location = New System.Drawing.Point(8, 132)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(65, 12)
    Me.Label60.TabIndex = 158
    Me.Label60.Text = "不連續數量"
    Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextSearch2_NonContinueCount
    '
    Me.TextSearch2_NonContinueCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextSearch2_NonContinueCount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextSearch2_NonContinueCount.ForeColor = System.Drawing.Color.Blue
    Me.TextSearch2_NonContinueCount.Location = New System.Drawing.Point(75, 127)
    Me.TextSearch2_NonContinueCount.MaxLength = 5
    Me.TextSearch2_NonContinueCount.Name = "TextSearch2_NonContinueCount"
    Me.TextSearch2_NonContinueCount.Size = New System.Drawing.Size(63, 21)
    Me.TextSearch2_NonContinueCount.TabIndex = 157
    Me.TextSearch2_NonContinueCount.Tag = ""
    Me.TextSearch2_NonContinueCount.Text = "180"
    Me.TextSearch2_NonContinueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label58
    '
    Me.Label58.AutoSize = True
    Me.Label58.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label58.Location = New System.Drawing.Point(8, 110)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(53, 12)
    Me.Label58.TabIndex = 156
    Me.Label58.Text = "連續數量"
    Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextSearch2_ContinueCount
    '
    Me.TextSearch2_ContinueCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextSearch2_ContinueCount.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextSearch2_ContinueCount.ForeColor = System.Drawing.Color.Blue
    Me.TextSearch2_ContinueCount.Location = New System.Drawing.Point(75, 105)
    Me.TextSearch2_ContinueCount.MaxLength = 5
    Me.TextSearch2_ContinueCount.Name = "TextSearch2_ContinueCount"
    Me.TextSearch2_ContinueCount.Size = New System.Drawing.Size(63, 21)
    Me.TextSearch2_ContinueCount.TabIndex = 155
    Me.TextSearch2_ContinueCount.Tag = ""
    Me.TextSearch2_ContinueCount.Text = "45"
    Me.TextSearch2_ContinueCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label57
    '
    Me.Label57.AutoSize = True
    Me.Label57.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label57.Location = New System.Drawing.Point(8, 67)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(53, 12)
    Me.Label57.TabIndex = 154
    Me.Label57.Text = "灰階門檻"
    Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextSearch2_Threshold
    '
    Me.TextSearch2_Threshold.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextSearch2_Threshold.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextSearch2_Threshold.ForeColor = System.Drawing.Color.Blue
    Me.TextSearch2_Threshold.Location = New System.Drawing.Point(75, 62)
    Me.TextSearch2_Threshold.MaxLength = 5
    Me.TextSearch2_Threshold.Name = "TextSearch2_Threshold"
    Me.TextSearch2_Threshold.Size = New System.Drawing.Size(63, 21)
    Me.TextSearch2_Threshold.TabIndex = 153
    Me.TextSearch2_Threshold.Tag = ""
    Me.TextSearch2_Threshold.Text = "13"
    Me.TextSearch2_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label56
    '
    Me.Label56.AutoSize = True
    Me.Label56.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label56.Location = New System.Drawing.Point(8, 45)
    Me.Label56.Name = "Label56"
    Me.Label56.Size = New System.Drawing.Size(29, 12)
    Me.Label56.TabIndex = 152
    Me.Label56.Text = "直徑"
    Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextSearch2_CircleDiameter
    '
    Me.TextSearch2_CircleDiameter.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextSearch2_CircleDiameter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextSearch2_CircleDiameter.ForeColor = System.Drawing.Color.Blue
    Me.TextSearch2_CircleDiameter.Location = New System.Drawing.Point(75, 40)
    Me.TextSearch2_CircleDiameter.MaxLength = 5
    Me.TextSearch2_CircleDiameter.Name = "TextSearch2_CircleDiameter"
    Me.TextSearch2_CircleDiameter.Size = New System.Drawing.Size(63, 21)
    Me.TextSearch2_CircleDiameter.TabIndex = 151
    Me.TextSearch2_CircleDiameter.Tag = ""
    Me.TextSearch2_CircleDiameter.Text = "850"
    Me.TextSearch2_CircleDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label55
    '
    Me.Label55.AutoSize = True
    Me.Label55.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label55.Location = New System.Drawing.Point(8, 23)
    Me.Label55.Name = "Label55"
    Me.Label55.Size = New System.Drawing.Size(53, 12)
    Me.Label55.TabIndex = 150
    Me.Label55.Text = "量測寬度"
    Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextSearch2_MeasureWidth
    '
    Me.TextSearch2_MeasureWidth.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextSearch2_MeasureWidth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextSearch2_MeasureWidth.ForeColor = System.Drawing.Color.Blue
    Me.TextSearch2_MeasureWidth.Location = New System.Drawing.Point(75, 18)
    Me.TextSearch2_MeasureWidth.MaxLength = 5
    Me.TextSearch2_MeasureWidth.Name = "TextSearch2_MeasureWidth"
    Me.TextSearch2_MeasureWidth.Size = New System.Drawing.Size(63, 21)
    Me.TextSearch2_MeasureWidth.TabIndex = 149
    Me.TextSearch2_MeasureWidth.Tag = ""
    Me.TextSearch2_MeasureWidth.Text = "50"
    Me.TextSearch2_MeasureWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'UpDownSearch2_Score
    '
    Me.UpDownSearch2_Score.BackColor = System.Drawing.Color.LemonChiffon
    Me.UpDownSearch2_Score.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.UpDownSearch2_Score.ForeColor = System.Drawing.Color.Blue
    Me.UpDownSearch2_Score.Location = New System.Drawing.Point(75, 84)
    Me.UpDownSearch2_Score.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
    Me.UpDownSearch2_Score.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.UpDownSearch2_Score.Name = "UpDownSearch2_Score"
    Me.UpDownSearch2_Score.Size = New System.Drawing.Size(63, 21)
    Me.UpDownSearch2_Score.TabIndex = 148
    Me.UpDownSearch2_Score.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    Me.UpDownSearch2_Score.Value = New Decimal(New Integer() {415, 0, 0, 0})
    '
    'BtnSearch2_SetParameter
    '
    Me.BtnSearch2_SetParameter.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_SetParameter.Font = New System.Drawing.Font("新細明體", 9.0!)
    Me.BtnSearch2_SetParameter.ForeColor = System.Drawing.SystemColors.ControlText
    Me.BtnSearch2_SetParameter.Location = New System.Drawing.Point(341, 16)
    Me.BtnSearch2_SetParameter.Name = "BtnSearch2_SetParameter"
    Me.BtnSearch2_SetParameter.Size = New System.Drawing.Size(78, 25)
    Me.BtnSearch2_SetParameter.TabIndex = 147
    Me.BtnSearch2_SetParameter.Text = "更新參數"
    Me.BtnSearch2_SetParameter.UseVisualStyleBackColor = False
    '
    'Label137
    '
    Me.Label137.AutoSize = True
    Me.Label137.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label137.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label137.Location = New System.Drawing.Point(8, 89)
    Me.Label137.Name = "Label137"
    Me.Label137.Size = New System.Drawing.Size(53, 12)
    Me.Label137.TabIndex = 113
    Me.Label137.Text = "圓門檻值"
    Me.Label137.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupTeach_ImageAdjust_Outside
    '
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.Label8)
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.BtnTeach_ShowMaskCircle)
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.TextTeach_MaskCircleSize)
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.BtnTeach_MaskCircle)
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.Label139)
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.TextTeach_BinaryDefectOut)
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.TrackBarTeach_BinaryDefectOut)
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.TextTeach_BinaryOutside)
    Me.GroupTeach_ImageAdjust_Outside.Controls.Add(Me.TrackBarTeach_BinaryOutside)
    Me.GroupTeach_ImageAdjust_Outside.Font = New System.Drawing.Font("新細明體", 9.75!)
    Me.GroupTeach_ImageAdjust_Outside.ForeColor = System.Drawing.Color.MediumBlue
    Me.GroupTeach_ImageAdjust_Outside.Location = New System.Drawing.Point(10, 363)
    Me.GroupTeach_ImageAdjust_Outside.Name = "GroupTeach_ImageAdjust_Outside"
    Me.GroupTeach_ImageAdjust_Outside.Size = New System.Drawing.Size(430, 85)
    Me.GroupTeach_ImageAdjust_Outside.TabIndex = 115
    Me.GroupTeach_ImageAdjust_Outside.TabStop = False
    Me.GroupTeach_ImageAdjust_Outside.Text = "影像處理(圓外)"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label8.Location = New System.Drawing.Point(11, 26)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(65, 12)
    Me.Label8.TabIndex = 120
    Me.Label8.Text = "覆蓋圓尺寸"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnTeach_ShowMaskCircle
    '
    Me.BtnTeach_ShowMaskCircle.BackColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_ShowMaskCircle.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_ShowMaskCircle.FlatAppearance.BorderSize = 2
    Me.BtnTeach_ShowMaskCircle.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTeach_ShowMaskCircle.ForeColor = System.Drawing.SystemColors.ControlText
    Me.BtnTeach_ShowMaskCircle.Location = New System.Drawing.Point(133, 15)
    Me.BtnTeach_ShowMaskCircle.Name = "BtnTeach_ShowMaskCircle"
    Me.BtnTeach_ShowMaskCircle.Size = New System.Drawing.Size(120, 34)
    Me.BtnTeach_ShowMaskCircle.TabIndex = 119
    Me.BtnTeach_ShowMaskCircle.Tag = ""
    Me.BtnTeach_ShowMaskCircle.Text = "顯示覆蓋圓"
    Me.BtnTeach_ShowMaskCircle.UseVisualStyleBackColor = False
    '
    'TextTeach_MaskCircleSize
    '
    Me.TextTeach_MaskCircleSize.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_MaskCircleSize.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_MaskCircleSize.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_MaskCircleSize.Location = New System.Drawing.Point(78, 19)
    Me.TextTeach_MaskCircleSize.MaxLength = 5
    Me.TextTeach_MaskCircleSize.Name = "TextTeach_MaskCircleSize"
    Me.TextTeach_MaskCircleSize.Size = New System.Drawing.Size(53, 25)
    Me.TextTeach_MaskCircleSize.TabIndex = 118
    Me.TextTeach_MaskCircleSize.Tag = ""
    Me.TextTeach_MaskCircleSize.Text = "1"
    Me.TextTeach_MaskCircleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'BtnTeach_MaskCircle
    '
    Me.BtnTeach_MaskCircle.BackColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_MaskCircle.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_MaskCircle.FlatAppearance.BorderSize = 2
    Me.BtnTeach_MaskCircle.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTeach_MaskCircle.ForeColor = System.Drawing.SystemColors.ControlText
    Me.BtnTeach_MaskCircle.Location = New System.Drawing.Point(253, 15)
    Me.BtnTeach_MaskCircle.Name = "BtnTeach_MaskCircle"
    Me.BtnTeach_MaskCircle.Size = New System.Drawing.Size(120, 34)
    Me.BtnTeach_MaskCircle.TabIndex = 117
    Me.BtnTeach_MaskCircle.Tag = ""
    Me.BtnTeach_MaskCircle.Text = "覆蓋"
    Me.BtnTeach_MaskCircle.UseVisualStyleBackColor = False
    '
    'Label139
    '
    Me.Label139.AutoSize = True
    Me.Label139.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label139.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label139.Location = New System.Drawing.Point(11, 60)
    Me.Label139.Name = "Label139"
    Me.Label139.Size = New System.Drawing.Size(65, 12)
    Me.Label139.TabIndex = 116
    Me.Label139.Text = "缺點二值化"
    Me.Label139.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextTeach_BinaryDefectOut
    '
    Me.TextTeach_BinaryDefectOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_BinaryDefectOut.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_BinaryDefectOut.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_BinaryDefectOut.Location = New System.Drawing.Point(272, 55)
    Me.TextTeach_BinaryDefectOut.MaxLength = 3
    Me.TextTeach_BinaryDefectOut.Name = "TextTeach_BinaryDefectOut"
    Me.TextTeach_BinaryDefectOut.Size = New System.Drawing.Size(37, 25)
    Me.TextTeach_BinaryDefectOut.TabIndex = 115
    Me.TextTeach_BinaryDefectOut.Tag = "1"
    Me.TextTeach_BinaryDefectOut.Text = "120"
    Me.TextTeach_BinaryDefectOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TrackBarTeach_BinaryDefectOut
    '
    Me.TrackBarTeach_BinaryDefectOut.AutoSize = False
    Me.TrackBarTeach_BinaryDefectOut.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TrackBarTeach_BinaryDefectOut.Location = New System.Drawing.Point(69, 55)
    Me.TrackBarTeach_BinaryDefectOut.Maximum = 255
    Me.TrackBarTeach_BinaryDefectOut.Name = "TrackBarTeach_BinaryDefectOut"
    Me.TrackBarTeach_BinaryDefectOut.Size = New System.Drawing.Size(202, 23)
    Me.TrackBarTeach_BinaryDefectOut.TabIndex = 114
    Me.TrackBarTeach_BinaryDefectOut.Tag = "1"
    Me.TrackBarTeach_BinaryDefectOut.TickFrequency = 10
    Me.TrackBarTeach_BinaryDefectOut.TickStyle = System.Windows.Forms.TickStyle.None
    Me.TrackBarTeach_BinaryDefectOut.Value = 120
    '
    'TextTeach_BinaryOutside
    '
    Me.TextTeach_BinaryOutside.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_BinaryOutside.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_BinaryOutside.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_BinaryOutside.Location = New System.Drawing.Point(466, 80)
    Me.TextTeach_BinaryOutside.MaxLength = 3
    Me.TextTeach_BinaryOutside.Name = "TextTeach_BinaryOutside"
    Me.TextTeach_BinaryOutside.Size = New System.Drawing.Size(37, 25)
    Me.TextTeach_BinaryOutside.TabIndex = 112
    Me.TextTeach_BinaryOutside.Tag = "1"
    Me.TextTeach_BinaryOutside.Text = "120"
    Me.TextTeach_BinaryOutside.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TrackBarTeach_BinaryOutside
    '
    Me.TrackBarTeach_BinaryOutside.AutoSize = False
    Me.TrackBarTeach_BinaryOutside.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TrackBarTeach_BinaryOutside.Location = New System.Drawing.Point(263, 91)
    Me.TrackBarTeach_BinaryOutside.Maximum = 255
    Me.TrackBarTeach_BinaryOutside.Name = "TrackBarTeach_BinaryOutside"
    Me.TrackBarTeach_BinaryOutside.Size = New System.Drawing.Size(202, 23)
    Me.TrackBarTeach_BinaryOutside.TabIndex = 111
    Me.TrackBarTeach_BinaryOutside.Tag = "1"
    Me.TrackBarTeach_BinaryOutside.TickFrequency = 10
    Me.TrackBarTeach_BinaryOutside.TickStyle = System.Windows.Forms.TickStyle.None
    Me.TrackBarTeach_BinaryOutside.Value = 120
    '
    'GroupTeach_ImageAdjust_Size
    '
    Me.GroupTeach_ImageAdjust_Size.Controls.Add(Me.BtnTeach_Binary)
    Me.GroupTeach_ImageAdjust_Size.Controls.Add(Me.Label7)
    Me.GroupTeach_ImageAdjust_Size.Controls.Add(Me.TrackBarTeach_BinaryMax)
    Me.GroupTeach_ImageAdjust_Size.Controls.Add(Me.TextTeach_BinaryMax)
    Me.GroupTeach_ImageAdjust_Size.Controls.Add(Me.TrackBarTeach_BinaryMin)
    Me.GroupTeach_ImageAdjust_Size.Controls.Add(Me.TextTeach_BinaryMin)
    Me.GroupTeach_ImageAdjust_Size.Controls.Add(Me.BtnTeach_Hull)
    Me.GroupTeach_ImageAdjust_Size.Controls.Add(Me.Label9)
    Me.GroupTeach_ImageAdjust_Size.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupTeach_ImageAdjust_Size.ForeColor = System.Drawing.Color.MediumBlue
    Me.GroupTeach_ImageAdjust_Size.Location = New System.Drawing.Point(10, 9)
    Me.GroupTeach_ImageAdjust_Size.Name = "GroupTeach_ImageAdjust_Size"
    Me.GroupTeach_ImageAdjust_Size.Size = New System.Drawing.Size(430, 109)
    Me.GroupTeach_ImageAdjust_Size.TabIndex = 94
    Me.GroupTeach_ImageAdjust_Size.TabStop = False
    Me.GroupTeach_ImageAdjust_Size.Text = "影像處理(孔徑)"
    '
    'BtnTeach_Binary
    '
    Me.BtnTeach_Binary.BackColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_Binary.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_Binary.FlatAppearance.BorderSize = 2
    Me.BtnTeach_Binary.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTeach_Binary.ForeColor = System.Drawing.SystemColors.ControlText
    Me.BtnTeach_Binary.Location = New System.Drawing.Point(341, 15)
    Me.BtnTeach_Binary.Name = "BtnTeach_Binary"
    Me.BtnTeach_Binary.Size = New System.Drawing.Size(83, 54)
    Me.BtnTeach_Binary.TabIndex = 51
    Me.BtnTeach_Binary.Tag = ""
    Me.BtnTeach_Binary.Text = "二值化"
    Me.BtnTeach_Binary.UseVisualStyleBackColor = False
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label7.Location = New System.Drawing.Point(11, 48)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(94, 12)
    Me.Label7.TabIndex = 50
    Me.Label7.Text = "原圖二值化(Max)"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TrackBarTeach_BinaryMax
    '
    Me.TrackBarTeach_BinaryMax.AutoSize = False
    Me.TrackBarTeach_BinaryMax.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TrackBarTeach_BinaryMax.Location = New System.Drawing.Point(99, 43)
    Me.TrackBarTeach_BinaryMax.Maximum = 255
    Me.TrackBarTeach_BinaryMax.Name = "TrackBarTeach_BinaryMax"
    Me.TrackBarTeach_BinaryMax.Size = New System.Drawing.Size(202, 23)
    Me.TrackBarTeach_BinaryMax.TabIndex = 48
    Me.TrackBarTeach_BinaryMax.Tag = "1"
    Me.TrackBarTeach_BinaryMax.TickFrequency = 10
    Me.TrackBarTeach_BinaryMax.TickStyle = System.Windows.Forms.TickStyle.None
    Me.TrackBarTeach_BinaryMax.Value = 255
    '
    'TextTeach_BinaryMax
    '
    Me.TextTeach_BinaryMax.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_BinaryMax.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_BinaryMax.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_BinaryMax.Location = New System.Drawing.Point(302, 43)
    Me.TextTeach_BinaryMax.MaxLength = 3
    Me.TextTeach_BinaryMax.Name = "TextTeach_BinaryMax"
    Me.TextTeach_BinaryMax.Size = New System.Drawing.Size(37, 25)
    Me.TextTeach_BinaryMax.TabIndex = 49
    Me.TextTeach_BinaryMax.Tag = "1"
    Me.TextTeach_BinaryMax.Text = "255"
    Me.TextTeach_BinaryMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TrackBarTeach_BinaryMin
    '
    Me.TrackBarTeach_BinaryMin.AutoSize = False
    Me.TrackBarTeach_BinaryMin.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TrackBarTeach_BinaryMin.Location = New System.Drawing.Point(99, 16)
    Me.TrackBarTeach_BinaryMin.Maximum = 255
    Me.TrackBarTeach_BinaryMin.Name = "TrackBarTeach_BinaryMin"
    Me.TrackBarTeach_BinaryMin.Size = New System.Drawing.Size(202, 23)
    Me.TrackBarTeach_BinaryMin.TabIndex = 45
    Me.TrackBarTeach_BinaryMin.Tag = "1"
    Me.TrackBarTeach_BinaryMin.TickFrequency = 10
    Me.TrackBarTeach_BinaryMin.TickStyle = System.Windows.Forms.TickStyle.None
    Me.TrackBarTeach_BinaryMin.Value = 200
    '
    'TextTeach_BinaryMin
    '
    Me.TextTeach_BinaryMin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_BinaryMin.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_BinaryMin.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_BinaryMin.Location = New System.Drawing.Point(302, 16)
    Me.TextTeach_BinaryMin.MaxLength = 3
    Me.TextTeach_BinaryMin.Name = "TextTeach_BinaryMin"
    Me.TextTeach_BinaryMin.Size = New System.Drawing.Size(37, 25)
    Me.TextTeach_BinaryMin.TabIndex = 46
    Me.TextTeach_BinaryMin.Tag = "1"
    Me.TextTeach_BinaryMin.Text = "200"
    Me.TextTeach_BinaryMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'BtnTeach_Hull
    '
    Me.BtnTeach_Hull.BackColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_Hull.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_Hull.FlatAppearance.BorderSize = 2
    Me.BtnTeach_Hull.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTeach_Hull.ForeColor = System.Drawing.SystemColors.ControlText
    Me.BtnTeach_Hull.Location = New System.Drawing.Point(10, 70)
    Me.BtnTeach_Hull.Name = "BtnTeach_Hull"
    Me.BtnTeach_Hull.Size = New System.Drawing.Size(285, 34)
    Me.BtnTeach_Hull.TabIndex = 38
    Me.BtnTeach_Hull.Tag = "校正"
    Me.BtnTeach_Hull.Text = "填滿"
    Me.BtnTeach_Hull.UseVisualStyleBackColor = False
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label9.Location = New System.Drawing.Point(11, 21)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(92, 12)
    Me.Label9.TabIndex = 39
    Me.Label9.Text = "原圖二值化(Min)"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupTeacht_Spec
    '
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DefectLength_Outside_CCD4)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DefectLength_Outside_CCD3)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DefectLength_Outside_CCD2)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label116)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DefectLength_Outside_CCD1)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_Laser_LimitUp)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_Laser_LimitDown)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_TrueCircle_CCD4)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_TrueCircle_CCD3)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_TrueCircle_CCD2)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label43)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_TrueCircle_CCD1)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DefectLength_Inside_CCD4)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DefectLength_Inside_CCD3)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DefectLength_Inside_CCD2)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label38)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DefectLength_Inside_CCD1)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DiameterTolerance_CCD4)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_Diameter_CCD4)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DiameterTolerance_CCD3)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_Diameter_CCD3)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DiameterTolerance_CCD2)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_Diameter_CCD2)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label59)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DiameterTolerance_CCD1)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_Diameter_CCD1)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label44)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DistanceTolerance_UpDown)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_DistanceTolerance_LeftRight)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label42)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_Distance_UpDown)
    Me.GroupTeacht_Spec.Controls.Add(Me.TextTeach_Distance_LeftRight)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label40)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label32)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label39)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label64)
    Me.GroupTeacht_Spec.Controls.Add(Me.Label46)
    Me.GroupTeacht_Spec.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupTeacht_Spec.ForeColor = System.Drawing.Color.MediumBlue
    Me.GroupTeacht_Spec.Location = New System.Drawing.Point(10, 455)
    Me.GroupTeacht_Spec.Name = "GroupTeacht_Spec"
    Me.GroupTeacht_Spec.Size = New System.Drawing.Size(430, 217)
    Me.GroupTeacht_Spec.TabIndex = 95
    Me.GroupTeacht_Spec.TabStop = False
    Me.GroupTeacht_Spec.Text = "產品規格參數"
    '
    'TextTeach_DefectLength_Outside_CCD4
    '
    Me.TextTeach_DefectLength_Outside_CCD4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DefectLength_Outside_CCD4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DefectLength_Outside_CCD4.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DefectLength_Outside_CCD4.Location = New System.Drawing.Point(280, 120)
    Me.TextTeach_DefectLength_Outside_CCD4.MaxLength = 5
    Me.TextTeach_DefectLength_Outside_CCD4.Name = "TextTeach_DefectLength_Outside_CCD4"
    Me.TextTeach_DefectLength_Outside_CCD4.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DefectLength_Outside_CCD4.TabIndex = 78
    Me.TextTeach_DefectLength_Outside_CCD4.Tag = "孔缺點長度圓外"
    Me.TextTeach_DefectLength_Outside_CCD4.Text = "0.01"
    Me.TextTeach_DefectLength_Outside_CCD4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DefectLength_Outside_CCD3
    '
    Me.TextTeach_DefectLength_Outside_CCD3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DefectLength_Outside_CCD3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DefectLength_Outside_CCD3.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DefectLength_Outside_CCD3.Location = New System.Drawing.Point(228, 120)
    Me.TextTeach_DefectLength_Outside_CCD3.MaxLength = 5
    Me.TextTeach_DefectLength_Outside_CCD3.Name = "TextTeach_DefectLength_Outside_CCD3"
    Me.TextTeach_DefectLength_Outside_CCD3.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DefectLength_Outside_CCD3.TabIndex = 77
    Me.TextTeach_DefectLength_Outside_CCD3.Tag = "孔缺點長度圓外"
    Me.TextTeach_DefectLength_Outside_CCD3.Text = "0.01"
    Me.TextTeach_DefectLength_Outside_CCD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DefectLength_Outside_CCD2
    '
    Me.TextTeach_DefectLength_Outside_CCD2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DefectLength_Outside_CCD2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DefectLength_Outside_CCD2.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DefectLength_Outside_CCD2.Location = New System.Drawing.Point(176, 120)
    Me.TextTeach_DefectLength_Outside_CCD2.MaxLength = 5
    Me.TextTeach_DefectLength_Outside_CCD2.Name = "TextTeach_DefectLength_Outside_CCD2"
    Me.TextTeach_DefectLength_Outside_CCD2.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DefectLength_Outside_CCD2.TabIndex = 76
    Me.TextTeach_DefectLength_Outside_CCD2.Tag = "孔缺點長度圓外"
    Me.TextTeach_DefectLength_Outside_CCD2.Text = "0.01"
    Me.TextTeach_DefectLength_Outside_CCD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label116
    '
    Me.Label116.AutoSize = True
    Me.Label116.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label116.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label116.Location = New System.Drawing.Point(11, 125)
    Me.Label116.Name = "Label116"
    Me.Label116.Size = New System.Drawing.Size(111, 12)
    Me.Label116.TabIndex = 75
    Me.Label116.Text = "缺點長度(圓外)(mm)"
    Me.Label116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TextTeach_DefectLength_Outside_CCD1
    '
    Me.TextTeach_DefectLength_Outside_CCD1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DefectLength_Outside_CCD1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DefectLength_Outside_CCD1.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DefectLength_Outside_CCD1.Location = New System.Drawing.Point(124, 120)
    Me.TextTeach_DefectLength_Outside_CCD1.MaxLength = 5
    Me.TextTeach_DefectLength_Outside_CCD1.Name = "TextTeach_DefectLength_Outside_CCD1"
    Me.TextTeach_DefectLength_Outside_CCD1.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DefectLength_Outside_CCD1.TabIndex = 74
    Me.TextTeach_DefectLength_Outside_CCD1.Tag = "孔缺點長度圓外"
    Me.TextTeach_DefectLength_Outside_CCD1.Text = "0.01"
    Me.TextTeach_DefectLength_Outside_CCD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Laser_LimitUp
    '
    Me.TextTeach_Laser_LimitUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Laser_LimitUp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Laser_LimitUp.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Laser_LimitUp.Location = New System.Drawing.Point(223, 189)
    Me.TextTeach_Laser_LimitUp.MaxLength = 5
    Me.TextTeach_Laser_LimitUp.Name = "TextTeach_Laser_LimitUp"
    Me.TextTeach_Laser_LimitUp.Size = New System.Drawing.Size(42, 22)
    Me.TextTeach_Laser_LimitUp.TabIndex = 72
    Me.TextTeach_Laser_LimitUp.Tag = "雷射測高上限"
    Me.TextTeach_Laser_LimitUp.Text = "1"
    Me.TextTeach_Laser_LimitUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Laser_LimitDown
    '
    Me.TextTeach_Laser_LimitDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Laser_LimitDown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Laser_LimitDown.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Laser_LimitDown.Location = New System.Drawing.Point(124, 189)
    Me.TextTeach_Laser_LimitDown.MaxLength = 6
    Me.TextTeach_Laser_LimitDown.Name = "TextTeach_Laser_LimitDown"
    Me.TextTeach_Laser_LimitDown.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_Laser_LimitDown.TabIndex = 71
    Me.TextTeach_Laser_LimitDown.Tag = "雷射測高下限"
    Me.TextTeach_Laser_LimitDown.Text = "-1"
    Me.TextTeach_Laser_LimitDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_TrueCircle_CCD4
    '
    Me.TextTeach_TrueCircle_CCD4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_TrueCircle_CCD4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_TrueCircle_CCD4.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_TrueCircle_CCD4.Location = New System.Drawing.Point(280, 74)
    Me.TextTeach_TrueCircle_CCD4.MaxLength = 5
    Me.TextTeach_TrueCircle_CCD4.Name = "TextTeach_TrueCircle_CCD4"
    Me.TextTeach_TrueCircle_CCD4.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_TrueCircle_CCD4.TabIndex = 70
    Me.TextTeach_TrueCircle_CCD4.Tag = "真圓度"
    Me.TextTeach_TrueCircle_CCD4.Text = "99"
    Me.TextTeach_TrueCircle_CCD4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_TrueCircle_CCD3
    '
    Me.TextTeach_TrueCircle_CCD3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_TrueCircle_CCD3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_TrueCircle_CCD3.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_TrueCircle_CCD3.Location = New System.Drawing.Point(228, 74)
    Me.TextTeach_TrueCircle_CCD3.MaxLength = 5
    Me.TextTeach_TrueCircle_CCD3.Name = "TextTeach_TrueCircle_CCD3"
    Me.TextTeach_TrueCircle_CCD3.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_TrueCircle_CCD3.TabIndex = 69
    Me.TextTeach_TrueCircle_CCD3.Tag = "真圓度"
    Me.TextTeach_TrueCircle_CCD3.Text = "99"
    Me.TextTeach_TrueCircle_CCD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_TrueCircle_CCD2
    '
    Me.TextTeach_TrueCircle_CCD2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_TrueCircle_CCD2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_TrueCircle_CCD2.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_TrueCircle_CCD2.Location = New System.Drawing.Point(176, 74)
    Me.TextTeach_TrueCircle_CCD2.MaxLength = 5
    Me.TextTeach_TrueCircle_CCD2.Name = "TextTeach_TrueCircle_CCD2"
    Me.TextTeach_TrueCircle_CCD2.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_TrueCircle_CCD2.TabIndex = 68
    Me.TextTeach_TrueCircle_CCD2.Tag = "真圓度"
    Me.TextTeach_TrueCircle_CCD2.Text = "99"
    Me.TextTeach_TrueCircle_CCD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label43
    '
    Me.Label43.AutoSize = True
    Me.Label43.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label43.Location = New System.Drawing.Point(11, 79)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(58, 12)
    Me.Label43.TabIndex = 67
    Me.Label43.Text = "真圓度(%)"
    Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TextTeach_TrueCircle_CCD1
    '
    Me.TextTeach_TrueCircle_CCD1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_TrueCircle_CCD1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_TrueCircle_CCD1.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_TrueCircle_CCD1.Location = New System.Drawing.Point(124, 74)
    Me.TextTeach_TrueCircle_CCD1.MaxLength = 5
    Me.TextTeach_TrueCircle_CCD1.Name = "TextTeach_TrueCircle_CCD1"
    Me.TextTeach_TrueCircle_CCD1.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_TrueCircle_CCD1.TabIndex = 66
    Me.TextTeach_TrueCircle_CCD1.Tag = "真圓度"
    Me.TextTeach_TrueCircle_CCD1.Text = "99"
    Me.TextTeach_TrueCircle_CCD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DefectLength_Inside_CCD4
    '
    Me.TextTeach_DefectLength_Inside_CCD4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DefectLength_Inside_CCD4.Enabled = False
    Me.TextTeach_DefectLength_Inside_CCD4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DefectLength_Inside_CCD4.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DefectLength_Inside_CCD4.Location = New System.Drawing.Point(280, 97)
    Me.TextTeach_DefectLength_Inside_CCD4.MaxLength = 5
    Me.TextTeach_DefectLength_Inside_CCD4.Name = "TextTeach_DefectLength_Inside_CCD4"
    Me.TextTeach_DefectLength_Inside_CCD4.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DefectLength_Inside_CCD4.TabIndex = 65
    Me.TextTeach_DefectLength_Inside_CCD4.Tag = "缺點長度圓內"
    Me.TextTeach_DefectLength_Inside_CCD4.Text = "0.01"
    Me.TextTeach_DefectLength_Inside_CCD4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DefectLength_Inside_CCD3
    '
    Me.TextTeach_DefectLength_Inside_CCD3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DefectLength_Inside_CCD3.Enabled = False
    Me.TextTeach_DefectLength_Inside_CCD3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DefectLength_Inside_CCD3.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DefectLength_Inside_CCD3.Location = New System.Drawing.Point(228, 97)
    Me.TextTeach_DefectLength_Inside_CCD3.MaxLength = 5
    Me.TextTeach_DefectLength_Inside_CCD3.Name = "TextTeach_DefectLength_Inside_CCD3"
    Me.TextTeach_DefectLength_Inside_CCD3.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DefectLength_Inside_CCD3.TabIndex = 64
    Me.TextTeach_DefectLength_Inside_CCD3.Tag = "缺點長度圓內"
    Me.TextTeach_DefectLength_Inside_CCD3.Text = "0.01"
    Me.TextTeach_DefectLength_Inside_CCD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DefectLength_Inside_CCD2
    '
    Me.TextTeach_DefectLength_Inside_CCD2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DefectLength_Inside_CCD2.Enabled = False
    Me.TextTeach_DefectLength_Inside_CCD2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DefectLength_Inside_CCD2.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DefectLength_Inside_CCD2.Location = New System.Drawing.Point(176, 97)
    Me.TextTeach_DefectLength_Inside_CCD2.MaxLength = 5
    Me.TextTeach_DefectLength_Inside_CCD2.Name = "TextTeach_DefectLength_Inside_CCD2"
    Me.TextTeach_DefectLength_Inside_CCD2.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DefectLength_Inside_CCD2.TabIndex = 63
    Me.TextTeach_DefectLength_Inside_CCD2.Tag = "缺點長度圓內"
    Me.TextTeach_DefectLength_Inside_CCD2.Text = "0.01"
    Me.TextTeach_DefectLength_Inside_CCD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label38
    '
    Me.Label38.AutoSize = True
    Me.Label38.Enabled = False
    Me.Label38.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label38.Location = New System.Drawing.Point(11, 102)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(111, 12)
    Me.Label38.TabIndex = 62
    Me.Label38.Text = "缺點長度(圓內)(mm)"
    Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TextTeach_DefectLength_Inside_CCD1
    '
    Me.TextTeach_DefectLength_Inside_CCD1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DefectLength_Inside_CCD1.Enabled = False
    Me.TextTeach_DefectLength_Inside_CCD1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DefectLength_Inside_CCD1.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DefectLength_Inside_CCD1.Location = New System.Drawing.Point(124, 97)
    Me.TextTeach_DefectLength_Inside_CCD1.MaxLength = 5
    Me.TextTeach_DefectLength_Inside_CCD1.Name = "TextTeach_DefectLength_Inside_CCD1"
    Me.TextTeach_DefectLength_Inside_CCD1.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DefectLength_Inside_CCD1.TabIndex = 61
    Me.TextTeach_DefectLength_Inside_CCD1.Tag = "缺點長度圓內"
    Me.TextTeach_DefectLength_Inside_CCD1.Text = "0.01"
    Me.TextTeach_DefectLength_Inside_CCD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DiameterTolerance_CCD4
    '
    Me.TextTeach_DiameterTolerance_CCD4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DiameterTolerance_CCD4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DiameterTolerance_CCD4.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DiameterTolerance_CCD4.Location = New System.Drawing.Point(280, 51)
    Me.TextTeach_DiameterTolerance_CCD4.MaxLength = 5
    Me.TextTeach_DiameterTolerance_CCD4.Name = "TextTeach_DiameterTolerance_CCD4"
    Me.TextTeach_DiameterTolerance_CCD4.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DiameterTolerance_CCD4.TabIndex = 60
    Me.TextTeach_DiameterTolerance_CCD4.Tag = "孔徑公差"
    Me.TextTeach_DiameterTolerance_CCD4.Text = "0.005"
    Me.TextTeach_DiameterTolerance_CCD4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Diameter_CCD4
    '
    Me.TextTeach_Diameter_CCD4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Diameter_CCD4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Diameter_CCD4.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Diameter_CCD4.Location = New System.Drawing.Point(280, 28)
    Me.TextTeach_Diameter_CCD4.MaxLength = 5
    Me.TextTeach_Diameter_CCD4.Name = "TextTeach_Diameter_CCD4"
    Me.TextTeach_Diameter_CCD4.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_Diameter_CCD4.TabIndex = 59
    Me.TextTeach_Diameter_CCD4.Tag = "孔徑"
    Me.TextTeach_Diameter_CCD4.Text = "1"
    Me.TextTeach_Diameter_CCD4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DiameterTolerance_CCD3
    '
    Me.TextTeach_DiameterTolerance_CCD3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DiameterTolerance_CCD3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DiameterTolerance_CCD3.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DiameterTolerance_CCD3.Location = New System.Drawing.Point(228, 51)
    Me.TextTeach_DiameterTolerance_CCD3.MaxLength = 5
    Me.TextTeach_DiameterTolerance_CCD3.Name = "TextTeach_DiameterTolerance_CCD3"
    Me.TextTeach_DiameterTolerance_CCD3.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DiameterTolerance_CCD3.TabIndex = 58
    Me.TextTeach_DiameterTolerance_CCD3.Tag = "孔徑公差"
    Me.TextTeach_DiameterTolerance_CCD3.Text = "0.005"
    Me.TextTeach_DiameterTolerance_CCD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Diameter_CCD3
    '
    Me.TextTeach_Diameter_CCD3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Diameter_CCD3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Diameter_CCD3.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Diameter_CCD3.Location = New System.Drawing.Point(228, 28)
    Me.TextTeach_Diameter_CCD3.MaxLength = 5
    Me.TextTeach_Diameter_CCD3.Name = "TextTeach_Diameter_CCD3"
    Me.TextTeach_Diameter_CCD3.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_Diameter_CCD3.TabIndex = 57
    Me.TextTeach_Diameter_CCD3.Tag = "孔徑"
    Me.TextTeach_Diameter_CCD3.Text = "1"
    Me.TextTeach_Diameter_CCD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DiameterTolerance_CCD2
    '
    Me.TextTeach_DiameterTolerance_CCD2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DiameterTolerance_CCD2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DiameterTolerance_CCD2.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DiameterTolerance_CCD2.Location = New System.Drawing.Point(176, 51)
    Me.TextTeach_DiameterTolerance_CCD2.MaxLength = 5
    Me.TextTeach_DiameterTolerance_CCD2.Name = "TextTeach_DiameterTolerance_CCD2"
    Me.TextTeach_DiameterTolerance_CCD2.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DiameterTolerance_CCD2.TabIndex = 56
    Me.TextTeach_DiameterTolerance_CCD2.Tag = "孔徑公差"
    Me.TextTeach_DiameterTolerance_CCD2.Text = "0.005"
    Me.TextTeach_DiameterTolerance_CCD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Diameter_CCD2
    '
    Me.TextTeach_Diameter_CCD2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Diameter_CCD2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Diameter_CCD2.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Diameter_CCD2.Location = New System.Drawing.Point(176, 28)
    Me.TextTeach_Diameter_CCD2.MaxLength = 5
    Me.TextTeach_Diameter_CCD2.Name = "TextTeach_Diameter_CCD2"
    Me.TextTeach_Diameter_CCD2.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_Diameter_CCD2.TabIndex = 55
    Me.TextTeach_Diameter_CCD2.Tag = "孔徑"
    Me.TextTeach_Diameter_CCD2.Text = "1"
    Me.TextTeach_Diameter_CCD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label59
    '
    Me.Label59.AutoSize = True
    Me.Label59.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label59.Location = New System.Drawing.Point(11, 56)
    Me.Label59.Name = "Label59"
    Me.Label59.Size = New System.Drawing.Size(79, 12)
    Me.Label59.TabIndex = 53
    Me.Label59.Text = "孔徑公差(mm)"
    Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TextTeach_DiameterTolerance_CCD1
    '
    Me.TextTeach_DiameterTolerance_CCD1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DiameterTolerance_CCD1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DiameterTolerance_CCD1.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DiameterTolerance_CCD1.Location = New System.Drawing.Point(124, 51)
    Me.TextTeach_DiameterTolerance_CCD1.MaxLength = 5
    Me.TextTeach_DiameterTolerance_CCD1.Name = "TextTeach_DiameterTolerance_CCD1"
    Me.TextTeach_DiameterTolerance_CCD1.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_DiameterTolerance_CCD1.TabIndex = 52
    Me.TextTeach_DiameterTolerance_CCD1.Tag = "孔徑公差"
    Me.TextTeach_DiameterTolerance_CCD1.Text = "0.005"
    Me.TextTeach_DiameterTolerance_CCD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Diameter_CCD1
    '
    Me.TextTeach_Diameter_CCD1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Diameter_CCD1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Diameter_CCD1.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Diameter_CCD1.Location = New System.Drawing.Point(124, 28)
    Me.TextTeach_Diameter_CCD1.MaxLength = 5
    Me.TextTeach_Diameter_CCD1.Name = "TextTeach_Diameter_CCD1"
    Me.TextTeach_Diameter_CCD1.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_Diameter_CCD1.TabIndex = 50
    Me.TextTeach_Diameter_CCD1.Tag = "孔徑"
    Me.TextTeach_Diameter_CCD1.Text = "1"
    Me.TextTeach_Diameter_CCD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label44
    '
    Me.Label44.AutoSize = True
    Me.Label44.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label44.Location = New System.Drawing.Point(11, 33)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(55, 12)
    Me.Label44.TabIndex = 49
    Me.Label44.Text = "孔徑(mm)"
    Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextTeach_DistanceTolerance_UpDown
    '
    Me.TextTeach_DistanceTolerance_UpDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DistanceTolerance_UpDown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DistanceTolerance_UpDown.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DistanceTolerance_UpDown.Location = New System.Drawing.Point(223, 166)
    Me.TextTeach_DistanceTolerance_UpDown.MaxLength = 5
    Me.TextTeach_DistanceTolerance_UpDown.Name = "TextTeach_DistanceTolerance_UpDown"
    Me.TextTeach_DistanceTolerance_UpDown.Size = New System.Drawing.Size(42, 22)
    Me.TextTeach_DistanceTolerance_UpDown.TabIndex = 48
    Me.TextTeach_DistanceTolerance_UpDown.Tag = "上下孔距離公差"
    Me.TextTeach_DistanceTolerance_UpDown.Text = "0.010"
    Me.TextTeach_DistanceTolerance_UpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_DistanceTolerance_LeftRight
    '
    Me.TextTeach_DistanceTolerance_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_DistanceTolerance_LeftRight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_DistanceTolerance_LeftRight.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_DistanceTolerance_LeftRight.Location = New System.Drawing.Point(223, 143)
    Me.TextTeach_DistanceTolerance_LeftRight.MaxLength = 5
    Me.TextTeach_DistanceTolerance_LeftRight.Name = "TextTeach_DistanceTolerance_LeftRight"
    Me.TextTeach_DistanceTolerance_LeftRight.Size = New System.Drawing.Size(42, 22)
    Me.TextTeach_DistanceTolerance_LeftRight.TabIndex = 47
    Me.TextTeach_DistanceTolerance_LeftRight.Tag = "左右孔距離公差"
    Me.TextTeach_DistanceTolerance_LeftRight.Text = "0.010"
    Me.TextTeach_DistanceTolerance_LeftRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label42
    '
    Me.Label42.AutoSize = True
    Me.Label42.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label42.Location = New System.Drawing.Point(265, 169)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(30, 16)
    Me.Label42.TabIndex = 45
    Me.Label42.Text = "mm"
    '
    'TextTeach_Distance_UpDown
    '
    Me.TextTeach_Distance_UpDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Distance_UpDown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Distance_UpDown.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Distance_UpDown.Location = New System.Drawing.Point(124, 166)
    Me.TextTeach_Distance_UpDown.MaxLength = 6
    Me.TextTeach_Distance_UpDown.Name = "TextTeach_Distance_UpDown"
    Me.TextTeach_Distance_UpDown.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_Distance_UpDown.TabIndex = 37
    Me.TextTeach_Distance_UpDown.Tag = "上下孔距離"
    Me.TextTeach_Distance_UpDown.Text = "14"
    Me.TextTeach_Distance_UpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Distance_LeftRight
    '
    Me.TextTeach_Distance_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Distance_LeftRight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Distance_LeftRight.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Distance_LeftRight.Location = New System.Drawing.Point(124, 143)
    Me.TextTeach_Distance_LeftRight.MaxLength = 6
    Me.TextTeach_Distance_LeftRight.Name = "TextTeach_Distance_LeftRight"
    Me.TextTeach_Distance_LeftRight.Size = New System.Drawing.Size(50, 22)
    Me.TextTeach_Distance_LeftRight.TabIndex = 36
    Me.TextTeach_Distance_LeftRight.Tag = "左右孔距離"
    Me.TextTeach_Distance_LeftRight.Text = "14"
    Me.TextTeach_Distance_LeftRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label40
    '
    Me.Label40.AutoSize = True
    Me.Label40.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label40.Location = New System.Drawing.Point(11, 148)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(212, 12)
    Me.Label40.TabIndex = 39
    Me.Label40.Text = "左右孔距離                                         公差"
    Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label32
    '
    Me.Label32.AutoSize = True
    Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label32.Location = New System.Drawing.Point(265, 146)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(30, 16)
    Me.Label32.TabIndex = 44
    Me.Label32.Text = "mm"
    '
    'Label39
    '
    Me.Label39.AutoSize = True
    Me.Label39.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label39.Location = New System.Drawing.Point(11, 171)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(212, 12)
    Me.Label39.TabIndex = 40
    Me.Label39.Text = "上下孔距離                                         公差"
    Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label64
    '
    Me.Label64.AutoSize = True
    Me.Label64.Font = New System.Drawing.Font("Arial", 9.0!)
    Me.Label64.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label64.Location = New System.Drawing.Point(132, 14)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(194, 15)
    Me.Label64.TabIndex = 54
    Me.Label64.Text = "CCD1     CCD2     CCD3       CCD4"
    Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label46
    '
    Me.Label46.AutoSize = True
    Me.Label46.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label46.Location = New System.Drawing.Point(11, 195)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(212, 12)
    Me.Label46.TabIndex = 73
    Me.Label46.Text = "雷射測高            下限                         上限"
    Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupProduct_Light
    '
    Me.GroupProduct_Light.Controls.Add(Me.BtnTeach_SearchLight_Off)
    Me.GroupProduct_Light.Controls.Add(Me.BtnTeach_SearchLight_On)
    Me.GroupProduct_Light.Controls.Add(Me.TextTeach_Search_Light4)
    Me.GroupProduct_Light.Controls.Add(Me.TextTeach_Search_Light3)
    Me.GroupProduct_Light.Controls.Add(Me.Label16)
    Me.GroupProduct_Light.Controls.Add(Me.Label15)
    Me.GroupProduct_Light.Controls.Add(Me.Label14)
    Me.GroupProduct_Light.Controls.Add(Me.BtnTeach_SearchLight_Set)
    Me.GroupProduct_Light.Controls.Add(Me.TextTeach_Search_Light2)
    Me.GroupProduct_Light.Controls.Add(Me.TextTeach_Search_Light1)
    Me.GroupProduct_Light.Controls.Add(Me.Label215)
    Me.GroupProduct_Light.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupProduct_Light.Location = New System.Drawing.Point(10, 22)
    Me.GroupProduct_Light.Name = "GroupProduct_Light"
    Me.GroupProduct_Light.Size = New System.Drawing.Size(253, 122)
    Me.GroupProduct_Light.TabIndex = 91
    Me.GroupProduct_Light.TabStop = False
    Me.GroupProduct_Light.Text = "檢測光源參數"
    '
    'BtnTeach_SearchLight_Off
    '
    Me.BtnTeach_SearchLight_Off.BackColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_SearchLight_Off.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTeach_SearchLight_Off.Location = New System.Drawing.Point(179, 66)
    Me.BtnTeach_SearchLight_Off.Name = "BtnTeach_SearchLight_Off"
    Me.BtnTeach_SearchLight_Off.Size = New System.Drawing.Size(67, 49)
    Me.BtnTeach_SearchLight_Off.TabIndex = 46
    Me.BtnTeach_SearchLight_Off.Tag = "檢測"
    Me.BtnTeach_SearchLight_Off.Text = "關閉"
    Me.BtnTeach_SearchLight_Off.UseVisualStyleBackColor = False
    '
    'BtnTeach_SearchLight_On
    '
    Me.BtnTeach_SearchLight_On.BackColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_SearchLight_On.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTeach_SearchLight_On.Location = New System.Drawing.Point(179, 18)
    Me.BtnTeach_SearchLight_On.Name = "BtnTeach_SearchLight_On"
    Me.BtnTeach_SearchLight_On.Size = New System.Drawing.Size(67, 49)
    Me.BtnTeach_SearchLight_On.TabIndex = 45
    Me.BtnTeach_SearchLight_On.Tag = "檢測"
    Me.BtnTeach_SearchLight_On.Text = "開啟"
    Me.BtnTeach_SearchLight_On.UseVisualStyleBackColor = False
    '
    'TextTeach_Search_Light4
    '
    Me.TextTeach_Search_Light4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Search_Light4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Search_Light4.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Search_Light4.Location = New System.Drawing.Point(70, 91)
    Me.TextTeach_Search_Light4.MaxLength = 3
    Me.TextTeach_Search_Light4.Name = "TextTeach_Search_Light4"
    Me.TextTeach_Search_Light4.ReadOnly = True
    Me.TextTeach_Search_Light4.Size = New System.Drawing.Size(40, 22)
    Me.TextTeach_Search_Light4.TabIndex = 44
    Me.TextTeach_Search_Light4.Tag = "1"
    Me.TextTeach_Search_Light4.Text = "0"
    Me.TextTeach_Search_Light4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Search_Light3
    '
    Me.TextTeach_Search_Light3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Search_Light3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Search_Light3.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Search_Light3.Location = New System.Drawing.Point(70, 67)
    Me.TextTeach_Search_Light3.MaxLength = 3
    Me.TextTeach_Search_Light3.Name = "TextTeach_Search_Light3"
    Me.TextTeach_Search_Light3.ReadOnly = True
    Me.TextTeach_Search_Light3.Size = New System.Drawing.Size(40, 22)
    Me.TextTeach_Search_Light3.TabIndex = 43
    Me.TextTeach_Search_Light3.Tag = "1"
    Me.TextTeach_Search_Light3.Text = "0"
    Me.TextTeach_Search_Light3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label16.Location = New System.Drawing.Point(11, 96)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(59, 12)
    Me.Label16.TabIndex = 42
    Me.Label16.Text = "CCD4燈光"
    Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label15.Location = New System.Drawing.Point(11, 72)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(59, 12)
    Me.Label15.TabIndex = 41
    Me.Label15.Text = "CCD3燈光"
    Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label14.Location = New System.Drawing.Point(11, 48)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(59, 12)
    Me.Label14.TabIndex = 40
    Me.Label14.Text = "CCD2燈光"
    Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnTeach_SearchLight_Set
    '
    Me.BtnTeach_SearchLight_Set.BackColor = System.Drawing.SystemColors.Control
    Me.BtnTeach_SearchLight_Set.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnTeach_SearchLight_Set.Location = New System.Drawing.Point(113, 18)
    Me.BtnTeach_SearchLight_Set.Name = "BtnTeach_SearchLight_Set"
    Me.BtnTeach_SearchLight_Set.Size = New System.Drawing.Size(67, 97)
    Me.BtnTeach_SearchLight_Set.TabIndex = 38
    Me.BtnTeach_SearchLight_Set.Tag = "檢測"
    Me.BtnTeach_SearchLight_Set.Text = "設定"
    Me.BtnTeach_SearchLight_Set.UseVisualStyleBackColor = False
    '
    'TextTeach_Search_Light2
    '
    Me.TextTeach_Search_Light2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Search_Light2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Search_Light2.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Search_Light2.Location = New System.Drawing.Point(70, 43)
    Me.TextTeach_Search_Light2.MaxLength = 3
    Me.TextTeach_Search_Light2.Name = "TextTeach_Search_Light2"
    Me.TextTeach_Search_Light2.ReadOnly = True
    Me.TextTeach_Search_Light2.Size = New System.Drawing.Size(40, 22)
    Me.TextTeach_Search_Light2.TabIndex = 37
    Me.TextTeach_Search_Light2.Tag = "1"
    Me.TextTeach_Search_Light2.Text = "0"
    Me.TextTeach_Search_Light2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TextTeach_Search_Light1
    '
    Me.TextTeach_Search_Light1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TextTeach_Search_Light1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextTeach_Search_Light1.ForeColor = System.Drawing.Color.Blue
    Me.TextTeach_Search_Light1.Location = New System.Drawing.Point(70, 19)
    Me.TextTeach_Search_Light1.MaxLength = 3
    Me.TextTeach_Search_Light1.Name = "TextTeach_Search_Light1"
    Me.TextTeach_Search_Light1.ReadOnly = True
    Me.TextTeach_Search_Light1.Size = New System.Drawing.Size(40, 22)
    Me.TextTeach_Search_Light1.TabIndex = 36
    Me.TextTeach_Search_Light1.Tag = "1"
    Me.TextTeach_Search_Light1.Text = "0"
    Me.TextTeach_Search_Light1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label215
    '
    Me.Label215.AutoSize = True
    Me.Label215.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label215.Location = New System.Drawing.Point(11, 24)
    Me.Label215.Name = "Label215"
    Me.Label215.Size = New System.Drawing.Size(59, 12)
    Me.Label215.TabIndex = 39
    Me.Label215.Text = "CCD1燈光"
    Me.Label215.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TabPage_Run
    '
    Me.TabPage_Run.BackColor = System.Drawing.SystemColors.ControlDark
    Me.TabPage_Run.Controls.Add(Me.PanelRun)
    Me.TabPage_Run.Location = New System.Drawing.Point(4, 30)
    Me.TabPage_Run.Name = "TabPage_Run"
    Me.TabPage_Run.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage_Run.Size = New System.Drawing.Size(851, 938)
    Me.TabPage_Run.TabIndex = 0
    Me.TabPage_Run.Text = "作業視窗"
    Me.TabPage_Run.UseVisualStyleBackColor = True
    '
    'PanelRun
    '
    Me.PanelRun.Controls.Add(Me.GroupRun_SendData)
    Me.PanelRun.Controls.Add(Me.GroupRun_CycleTime)
    Me.PanelRun.Controls.Add(Me.GroupBox17)
    Me.PanelRun.Controls.Add(Me.BtnRun_MoveToStandbyPos)
    Me.PanelRun.Controls.Add(Me.GroupRun_BarcodeInLine)
    Me.PanelRun.Controls.Add(Me.BtnRun_MoveToSearchPos)
    Me.PanelRun.Controls.Add(Me.GroupRun_Result)
    Me.PanelRun.Controls.Add(Me.GroupRun_Msg)
    Me.PanelRun.Controls.Add(Me.BtnRun_LoadNgImages)
    Me.PanelRun.Controls.Add(Me.BtnRun_ResetRunIndex)
    Me.PanelRun.Location = New System.Drawing.Point(0, 0)
    Me.PanelRun.Name = "PanelRun"
    Me.PanelRun.Size = New System.Drawing.Size(851, 942)
    Me.PanelRun.TabIndex = 0
    '
    'GroupRun_SendData
    '
    Me.GroupRun_SendData.Controls.Add(Me.DataGrid_SendData)
    Me.GroupRun_SendData.Controls.Add(Me.BtnRun_SendData)
    Me.GroupRun_SendData.Controls.Add(Me.Label141)
    Me.GroupRun_SendData.Controls.Add(Me.LabSendData_FileName)
    Me.GroupRun_SendData.Controls.Add(Me.BtnRun_LoadResultFile)
    Me.GroupRun_SendData.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupRun_SendData.ForeColor = System.Drawing.Color.DarkBlue
    Me.GroupRun_SendData.Location = New System.Drawing.Point(6, 780)
    Me.GroupRun_SendData.Name = "GroupRun_SendData"
    Me.GroupRun_SendData.Size = New System.Drawing.Size(842, 155)
    Me.GroupRun_SendData.TabIndex = 147
    Me.GroupRun_SendData.TabStop = False
    Me.GroupRun_SendData.Text = "檢測資料上傳"
    '
    'DataGrid_SendData
    '
    Me.DataGrid_SendData.AllowUserToAddRows = False
    Me.DataGrid_SendData.AllowUserToDeleteRows = False
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrid_SendData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrid_SendData.ColumnHeadersHeight = 25
    Me.DataGrid_SendData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.DataGrid_SendData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1_Name, Me.Column2_Value})
    Me.DataGrid_SendData.Location = New System.Drawing.Point(512, 15)
    Me.DataGrid_SendData.Name = "DataGrid_SendData"
    Me.DataGrid_SendData.ReadOnly = True
    Me.DataGrid_SendData.RowHeadersVisible = False
    Me.DataGrid_SendData.RowTemplate.Height = 24
    Me.DataGrid_SendData.Size = New System.Drawing.Size(324, 136)
    Me.DataGrid_SendData.TabIndex = 143
    Me.DataGrid_SendData.Visible = False
    '
    'Column1_Name
    '
    Me.Column1_Name.HeaderText = "參數名稱"
    Me.Column1_Name.MaxInputLength = 100
    Me.Column1_Name.Name = "Column1_Name"
    Me.Column1_Name.ReadOnly = True
    Me.Column1_Name.Width = 200
    '
    'Column2_Value
    '
    Me.Column2_Value.HeaderText = "參數值"
    Me.Column2_Value.MaxInputLength = 20
    Me.Column2_Value.Name = "Column2_Value"
    Me.Column2_Value.ReadOnly = True
    '
    'BtnRun_SendData
    '
    Me.BtnRun_SendData.BackColor = System.Drawing.Color.White
    Me.BtnRun_SendData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold)
    Me.BtnRun_SendData.Location = New System.Drawing.Point(395, 75)
    Me.BtnRun_SendData.Name = "BtnRun_SendData"
    Me.BtnRun_SendData.Size = New System.Drawing.Size(116, 51)
    Me.BtnRun_SendData.TabIndex = 142
    Me.BtnRun_SendData.Tag = ""
    Me.BtnRun_SendData.Text = "上傳"
    Me.BtnRun_SendData.UseVisualStyleBackColor = False
    '
    'Label141
    '
    Me.Label141.AutoSize = True
    Me.Label141.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label141.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label141.Location = New System.Drawing.Point(5, 18)
    Me.Label141.Name = "Label141"
    Me.Label141.Size = New System.Drawing.Size(114, 19)
    Me.Label141.TabIndex = 5
    Me.Label141.Text = "載入檢測資料檔"
    '
    'LabSendData_FileName
    '
    Me.LabSendData_FileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSendData_FileName.Font = New System.Drawing.Font("Arial", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSendData_FileName.ForeColor = System.Drawing.Color.MediumBlue
    Me.LabSendData_FileName.Location = New System.Drawing.Point(7, 37)
    Me.LabSendData_FileName.Name = "LabSendData_FileName"
    Me.LabSendData_FileName.Size = New System.Drawing.Size(502, 38)
    Me.LabSendData_FileName.TabIndex = 4
    '
    'BtnRun_LoadResultFile
    '
    Me.BtnRun_LoadResultFile.BackColor = System.Drawing.Color.White
    Me.BtnRun_LoadResultFile.Location = New System.Drawing.Point(271, 75)
    Me.BtnRun_LoadResultFile.Name = "BtnRun_LoadResultFile"
    Me.BtnRun_LoadResultFile.Size = New System.Drawing.Size(124, 51)
    Me.BtnRun_LoadResultFile.TabIndex = 3
    Me.BtnRun_LoadResultFile.Text = "載入資料檔"
    Me.BtnRun_LoadResultFile.UseVisualStyleBackColor = False
    Me.BtnRun_LoadResultFile.Visible = False
    '
    'GroupRun_CycleTime
    '
    Me.GroupRun_CycleTime.Controls.Add(Me.PanelTimeInf)
    Me.GroupRun_CycleTime.Controls.Add(Me.LabTimeInf_SearchTotal)
    Me.GroupRun_CycleTime.Controls.Add(Me.Label143)
    Me.GroupRun_CycleTime.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupRun_CycleTime.ForeColor = System.Drawing.Color.DarkBlue
    Me.GroupRun_CycleTime.Location = New System.Drawing.Point(6, 724)
    Me.GroupRun_CycleTime.Name = "GroupRun_CycleTime"
    Me.GroupRun_CycleTime.Size = New System.Drawing.Size(280, 54)
    Me.GroupRun_CycleTime.TabIndex = 40
    Me.GroupRun_CycleTime.TabStop = False
    Me.GroupRun_CycleTime.Text = "時間資訊"
    '
    'PanelTimeInf
    '
    Me.PanelTimeInf.Controls.Add(Me.LabTimeInf_Search1)
    Me.PanelTimeInf.Controls.Add(Me.Label138)
    Me.PanelTimeInf.Controls.Add(Me.Label140)
    Me.PanelTimeInf.Controls.Add(Me.LabTimeInf_Total)
    Me.PanelTimeInf.Controls.Add(Me.LabTimeInf_Search2)
    Me.PanelTimeInf.Controls.Add(Me.Label142)
    Me.PanelTimeInf.Location = New System.Drawing.Point(151, 58)
    Me.PanelTimeInf.Name = "PanelTimeInf"
    Me.PanelTimeInf.Size = New System.Drawing.Size(129, 57)
    Me.PanelTimeInf.TabIndex = 23
    '
    'LabTimeInf_Search1
    '
    Me.LabTimeInf_Search1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabTimeInf_Search1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabTimeInf_Search1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabTimeInf_Search1.ForeColor = System.Drawing.Color.Black
    Me.LabTimeInf_Search1.Location = New System.Drawing.Point(69, -1)
    Me.LabTimeInf_Search1.Name = "LabTimeInf_Search1"
    Me.LabTimeInf_Search1.Size = New System.Drawing.Size(58, 20)
    Me.LabTimeInf_Search1.TabIndex = 16
    Me.LabTimeInf_Search1.Tag = "1"
    Me.LabTimeInf_Search1.Text = "0"
    Me.LabTimeInf_Search1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label138
    '
    Me.Label138.AutoSize = True
    Me.Label138.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label138.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label138.Location = New System.Drawing.Point(0, 0)
    Me.Label138.Name = "Label138"
    Me.Label138.Size = New System.Drawing.Size(68, 17)
    Me.Label138.TabIndex = 15
    Me.Label138.Text = "檢測1時間"
    '
    'Label140
    '
    Me.Label140.AutoSize = True
    Me.Label140.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label140.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label140.Location = New System.Drawing.Point(0, 19)
    Me.Label140.Name = "Label140"
    Me.Label140.Size = New System.Drawing.Size(68, 17)
    Me.Label140.TabIndex = 17
    Me.Label140.Text = "檢測2時間"
    '
    'LabTimeInf_Total
    '
    Me.LabTimeInf_Total.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabTimeInf_Total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabTimeInf_Total.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabTimeInf_Total.ForeColor = System.Drawing.Color.Black
    Me.LabTimeInf_Total.Location = New System.Drawing.Point(69, 37)
    Me.LabTimeInf_Total.Name = "LabTimeInf_Total"
    Me.LabTimeInf_Total.Size = New System.Drawing.Size(58, 20)
    Me.LabTimeInf_Total.TabIndex = 20
    Me.LabTimeInf_Total.Tag = "1"
    Me.LabTimeInf_Total.Text = "0"
    Me.LabTimeInf_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabTimeInf_Search2
    '
    Me.LabTimeInf_Search2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabTimeInf_Search2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabTimeInf_Search2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabTimeInf_Search2.ForeColor = System.Drawing.Color.Black
    Me.LabTimeInf_Search2.Location = New System.Drawing.Point(69, 18)
    Me.LabTimeInf_Search2.Name = "LabTimeInf_Search2"
    Me.LabTimeInf_Search2.Size = New System.Drawing.Size(58, 20)
    Me.LabTimeInf_Search2.TabIndex = 18
    Me.LabTimeInf_Search2.Tag = "1"
    Me.LabTimeInf_Search2.Text = "0"
    Me.LabTimeInf_Search2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label142
    '
    Me.Label142.AutoSize = True
    Me.Label142.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label142.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label142.Location = New System.Drawing.Point(0, 38)
    Me.Label142.Name = "Label142"
    Me.Label142.Size = New System.Drawing.Size(73, 17)
    Me.Label142.TabIndex = 19
    Me.Label142.Text = "全行程時間"
    '
    'LabTimeInf_SearchTotal
    '
    Me.LabTimeInf_SearchTotal.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabTimeInf_SearchTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabTimeInf_SearchTotal.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabTimeInf_SearchTotal.ForeColor = System.Drawing.Color.Black
    Me.LabTimeInf_SearchTotal.Location = New System.Drawing.Point(77, 20)
    Me.LabTimeInf_SearchTotal.Name = "LabTimeInf_SearchTotal"
    Me.LabTimeInf_SearchTotal.Size = New System.Drawing.Size(94, 28)
    Me.LabTimeInf_SearchTotal.TabIndex = 22
    Me.LabTimeInf_SearchTotal.Tag = "1"
    Me.LabTimeInf_SearchTotal.Text = "0"
    Me.LabTimeInf_SearchTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label143
    '
    Me.Label143.AutoSize = True
    Me.Label143.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label143.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label143.Location = New System.Drawing.Point(10, 25)
    Me.Label143.Name = "Label143"
    Me.Label143.Size = New System.Drawing.Size(69, 19)
    Me.Label143.TabIndex = 21
    Me.Label143.Text = "檢測時間"
    '
    'GroupBox17
    '
    Me.GroupBox17.Controls.Add(Me.BtnOpInf_Clear)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_PackNumber)
    Me.GroupBox17.Controls.Add(Me.Label130)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_OunchNeedleNumberDown)
    Me.GroupBox17.Controls.Add(Me.Label126)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_OunchNeedleNumberUp)
    Me.GroupBox17.Controls.Add(Me.Label127)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_MouldNumber)
    Me.GroupBox17.Controls.Add(Me.Label128)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_MachineCode)
    Me.GroupBox17.Controls.Add(Me.Label129)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_HoleDustanceAndResultY)
    Me.GroupBox17.Controls.Add(Me.Label122)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_HoleDustanceAndResultX)
    Me.GroupBox17.Controls.Add(Me.Label123)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_HoleQualityType)
    Me.GroupBox17.Controls.Add(Me.Label124)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_HoleQualityResult)
    Me.GroupBox17.Controls.Add(Me.Label125)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_ProductNumber)
    Me.GroupBox17.Controls.Add(Me.Label120)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_NotNumber)
    Me.GroupBox17.Controls.Add(Me.Label121)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_DateTime)
    Me.GroupBox17.Controls.Add(Me.Label119)
    Me.GroupBox17.Controls.Add(Me.TextOpInf_UserNo)
    Me.GroupBox17.Controls.Add(Me.Label118)
    Me.GroupBox17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupBox17.ForeColor = System.Drawing.Color.DarkBlue
    Me.GroupBox17.Location = New System.Drawing.Point(6, 220)
    Me.GroupBox17.Name = "GroupBox17"
    Me.GroupBox17.Size = New System.Drawing.Size(280, 498)
    Me.GroupBox17.TabIndex = 146
    Me.GroupBox17.TabStop = False
    Me.GroupBox17.Text = "作業資訊"
    '
    'TextOpInf_PackNumber
    '
    Me.TextOpInf_PackNumber.BackColor = System.Drawing.Color.White
    Me.TextOpInf_PackNumber.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_PackNumber.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_PackNumber.Location = New System.Drawing.Point(124, 416)
    Me.TextOpInf_PackNumber.Name = "TextOpInf_PackNumber"
    Me.TextOpInf_PackNumber.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_PackNumber.TabIndex = 7
    '
    'Label130
    '
    Me.Label130.AutoSize = True
    Me.Label130.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label130.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label130.Location = New System.Drawing.Point(4, 420)
    Me.Label130.Name = "Label130"
    Me.Label130.Size = New System.Drawing.Size(39, 19)
    Me.Label130.TabIndex = 38
    Me.Label130.Text = "包號"
    '
    'TextOpInf_OunchNeedleNumberDown
    '
    Me.TextOpInf_OunchNeedleNumberDown.BackColor = System.Drawing.Color.White
    Me.TextOpInf_OunchNeedleNumberDown.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_OunchNeedleNumberDown.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_OunchNeedleNumberDown.Location = New System.Drawing.Point(124, 386)
    Me.TextOpInf_OunchNeedleNumberDown.Name = "TextOpInf_OunchNeedleNumberDown"
    Me.TextOpInf_OunchNeedleNumberDown.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_OunchNeedleNumberDown.TabIndex = 6
    '
    'Label126
    '
    Me.Label126.AutoSize = True
    Me.Label126.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label126.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label126.Location = New System.Drawing.Point(4, 390)
    Me.Label126.Name = "Label126"
    Me.Label126.Size = New System.Drawing.Size(84, 19)
    Me.Label126.TabIndex = 36
    Me.Label126.Text = "下沖針編號"
    '
    'TextOpInf_OunchNeedleNumberUp
    '
    Me.TextOpInf_OunchNeedleNumberUp.BackColor = System.Drawing.Color.White
    Me.TextOpInf_OunchNeedleNumberUp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_OunchNeedleNumberUp.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_OunchNeedleNumberUp.Location = New System.Drawing.Point(124, 356)
    Me.TextOpInf_OunchNeedleNumberUp.Name = "TextOpInf_OunchNeedleNumberUp"
    Me.TextOpInf_OunchNeedleNumberUp.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_OunchNeedleNumberUp.TabIndex = 5
    '
    'Label127
    '
    Me.Label127.AutoSize = True
    Me.Label127.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label127.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label127.Location = New System.Drawing.Point(4, 360)
    Me.Label127.Name = "Label127"
    Me.Label127.Size = New System.Drawing.Size(84, 19)
    Me.Label127.TabIndex = 34
    Me.Label127.Text = "上沖針編號"
    '
    'TextOpInf_MouldNumber
    '
    Me.TextOpInf_MouldNumber.BackColor = System.Drawing.Color.White
    Me.TextOpInf_MouldNumber.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_MouldNumber.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_MouldNumber.Location = New System.Drawing.Point(124, 326)
    Me.TextOpInf_MouldNumber.Name = "TextOpInf_MouldNumber"
    Me.TextOpInf_MouldNumber.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_MouldNumber.TabIndex = 4
    '
    'Label128
    '
    Me.Label128.AutoSize = True
    Me.Label128.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label128.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label128.Location = New System.Drawing.Point(4, 330)
    Me.Label128.Name = "Label128"
    Me.Label128.Size = New System.Drawing.Size(69, 19)
    Me.Label128.TabIndex = 32
    Me.Label128.Text = "模具編號"
    '
    'TextOpInf_MachineCode
    '
    Me.TextOpInf_MachineCode.BackColor = System.Drawing.Color.White
    Me.TextOpInf_MachineCode.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_MachineCode.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_MachineCode.Location = New System.Drawing.Point(124, 296)
    Me.TextOpInf_MachineCode.Name = "TextOpInf_MachineCode"
    Me.TextOpInf_MachineCode.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_MachineCode.TabIndex = 3
    '
    'Label129
    '
    Me.Label129.AutoSize = True
    Me.Label129.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label129.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label129.Location = New System.Drawing.Point(4, 300)
    Me.Label129.Name = "Label129"
    Me.Label129.Size = New System.Drawing.Size(84, 19)
    Me.Label129.TabIndex = 30
    Me.Label129.Text = "打拔機編號"
    '
    'TextOpInf_HoleDustanceAndResultY
    '
    Me.TextOpInf_HoleDustanceAndResultY.BackColor = System.Drawing.SystemColors.ActiveBorder
    Me.TextOpInf_HoleDustanceAndResultY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextOpInf_HoleDustanceAndResultY.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_HoleDustanceAndResultY.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_HoleDustanceAndResultY.Location = New System.Drawing.Point(124, 247)
    Me.TextOpInf_HoleDustanceAndResultY.Name = "TextOpInf_HoleDustanceAndResultY"
    Me.TextOpInf_HoleDustanceAndResultY.ReadOnly = True
    Me.TextOpInf_HoleDustanceAndResultY.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_HoleDustanceAndResultY.TabIndex = 29
    Me.TextOpInf_HoleDustanceAndResultY.TabStop = False
    '
    'Label122
    '
    Me.Label122.AutoSize = True
    Me.Label122.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label122.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label122.Location = New System.Drawing.Point(4, 251)
    Me.Label122.Name = "Label122"
    Me.Label122.Size = New System.Drawing.Size(123, 38)
    Me.Label122.TabIndex = 28
    Me.Label122.Text = "Y方向孔距離量測" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "及判定結果"
    '
    'TextOpInf_HoleDustanceAndResultX
    '
    Me.TextOpInf_HoleDustanceAndResultX.BackColor = System.Drawing.SystemColors.ActiveBorder
    Me.TextOpInf_HoleDustanceAndResultX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextOpInf_HoleDustanceAndResultX.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_HoleDustanceAndResultX.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_HoleDustanceAndResultX.Location = New System.Drawing.Point(124, 200)
    Me.TextOpInf_HoleDustanceAndResultX.Name = "TextOpInf_HoleDustanceAndResultX"
    Me.TextOpInf_HoleDustanceAndResultX.ReadOnly = True
    Me.TextOpInf_HoleDustanceAndResultX.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_HoleDustanceAndResultX.TabIndex = 27
    Me.TextOpInf_HoleDustanceAndResultX.TabStop = False
    '
    'Label123
    '
    Me.Label123.AutoSize = True
    Me.Label123.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label123.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label123.Location = New System.Drawing.Point(4, 204)
    Me.Label123.Name = "Label123"
    Me.Label123.Size = New System.Drawing.Size(124, 38)
    Me.Label123.TabIndex = 26
    Me.Label123.Text = "X方向孔距離量測" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "及判定結果"
    '
    'TextOpInf_HoleQualityType
    '
    Me.TextOpInf_HoleQualityType.BackColor = System.Drawing.SystemColors.ActiveBorder
    Me.TextOpInf_HoleQualityType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextOpInf_HoleQualityType.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_HoleQualityType.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_HoleQualityType.Location = New System.Drawing.Point(124, 170)
    Me.TextOpInf_HoleQualityType.Name = "TextOpInf_HoleQualityType"
    Me.TextOpInf_HoleQualityType.ReadOnly = True
    Me.TextOpInf_HoleQualityType.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_HoleQualityType.TabIndex = 25
    Me.TextOpInf_HoleQualityType.TabStop = False
    '
    'Label124
    '
    Me.Label124.AutoSize = True
    Me.Label124.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label124.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label124.Location = New System.Drawing.Point(4, 174)
    Me.Label124.Name = "Label124"
    Me.Label124.Size = New System.Drawing.Size(114, 19)
    Me.Label124.TabIndex = 24
    Me.Label124.Text = "孔品質種類判定"
    '
    'TextOpInf_HoleQualityResult
    '
    Me.TextOpInf_HoleQualityResult.BackColor = System.Drawing.SystemColors.ActiveBorder
    Me.TextOpInf_HoleQualityResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextOpInf_HoleQualityResult.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_HoleQualityResult.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_HoleQualityResult.Location = New System.Drawing.Point(124, 140)
    Me.TextOpInf_HoleQualityResult.Name = "TextOpInf_HoleQualityResult"
    Me.TextOpInf_HoleQualityResult.ReadOnly = True
    Me.TextOpInf_HoleQualityResult.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_HoleQualityResult.TabIndex = 23
    Me.TextOpInf_HoleQualityResult.TabStop = False
    '
    'Label125
    '
    Me.Label125.AutoSize = True
    Me.Label125.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label125.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label125.Location = New System.Drawing.Point(4, 144)
    Me.Label125.Name = "Label125"
    Me.Label125.Size = New System.Drawing.Size(114, 19)
    Me.Label125.TabIndex = 22
    Me.Label125.Text = "孔品質結果判定"
    '
    'TextOpInf_ProductNumber
    '
    Me.TextOpInf_ProductNumber.BackColor = System.Drawing.Color.White
    Me.TextOpInf_ProductNumber.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_ProductNumber.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_ProductNumber.Location = New System.Drawing.Point(124, 82)
    Me.TextOpInf_ProductNumber.Name = "TextOpInf_ProductNumber"
    Me.TextOpInf_ProductNumber.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_ProductNumber.TabIndex = 1
    '
    'Label120
    '
    Me.Label120.AutoSize = True
    Me.Label120.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label120.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label120.Location = New System.Drawing.Point(4, 86)
    Me.Label120.Name = "Label120"
    Me.Label120.Size = New System.Drawing.Size(39, 19)
    Me.Label120.TabIndex = 20
    Me.Label120.Text = "料號"
    '
    'TextOpInf_NotNumber
    '
    Me.TextOpInf_NotNumber.BackColor = System.Drawing.Color.White
    Me.TextOpInf_NotNumber.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextOpInf_NotNumber.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_NotNumber.Location = New System.Drawing.Point(124, 111)
    Me.TextOpInf_NotNumber.Name = "TextOpInf_NotNumber"
    Me.TextOpInf_NotNumber.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_NotNumber.TabIndex = 2
    '
    'Label121
    '
    Me.Label121.AutoSize = True
    Me.Label121.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label121.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label121.Location = New System.Drawing.Point(4, 115)
    Me.Label121.Name = "Label121"
    Me.Label121.Size = New System.Drawing.Size(39, 19)
    Me.Label121.TabIndex = 18
    Me.Label121.Text = "批號"
    '
    'TextOpInf_DateTime
    '
    Me.TextOpInf_DateTime.BackColor = System.Drawing.SystemColors.ActiveBorder
    Me.TextOpInf_DateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextOpInf_DateTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextOpInf_DateTime.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_DateTime.Location = New System.Drawing.Point(124, 50)
    Me.TextOpInf_DateTime.Multiline = True
    Me.TextOpInf_DateTime.Name = "TextOpInf_DateTime"
    Me.TextOpInf_DateTime.ReadOnly = True
    Me.TextOpInf_DateTime.Size = New System.Drawing.Size(151, 29)
    Me.TextOpInf_DateTime.TabIndex = 1
    Me.TextOpInf_DateTime.TabStop = False
    Me.TextOpInf_DateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label119
    '
    Me.Label119.AutoSize = True
    Me.Label119.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label119.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label119.Location = New System.Drawing.Point(4, 54)
    Me.Label119.Name = "Label119"
    Me.Label119.Size = New System.Drawing.Size(69, 19)
    Me.Label119.TabIndex = 16
    Me.Label119.Text = "日期時間"
    '
    'TextOpInf_UserNo
    '
    Me.TextOpInf_UserNo.BackColor = System.Drawing.Color.White
    Me.TextOpInf_UserNo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
    Me.TextOpInf_UserNo.ForeColor = System.Drawing.SystemColors.ControlText
    Me.TextOpInf_UserNo.Location = New System.Drawing.Point(124, 20)
    Me.TextOpInf_UserNo.Name = "TextOpInf_UserNo"
    Me.TextOpInf_UserNo.Size = New System.Drawing.Size(151, 26)
    Me.TextOpInf_UserNo.TabIndex = 0
    '
    'Label118
    '
    Me.Label118.AutoSize = True
    Me.Label118.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label118.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Label118.Location = New System.Drawing.Point(4, 24)
    Me.Label118.Name = "Label118"
    Me.Label118.Size = New System.Drawing.Size(69, 19)
    Me.Label118.TabIndex = 14
    Me.Label118.Text = "人員工號"
    '
    'BtnRun_MoveToStandbyPos
    '
    Me.BtnRun_MoveToStandbyPos.BackColor = System.Drawing.Color.White
    Me.BtnRun_MoveToStandbyPos.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_MoveToStandbyPos.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.BtnRun_MoveToStandbyPos.Location = New System.Drawing.Point(664, 220)
    Me.BtnRun_MoveToStandbyPos.Name = "BtnRun_MoveToStandbyPos"
    Me.BtnRun_MoveToStandbyPos.Size = New System.Drawing.Size(125, 38)
    Me.BtnRun_MoveToStandbyPos.TabIndex = 145
    Me.BtnRun_MoveToStandbyPos.Text = "移至待命區"
    Me.BtnRun_MoveToStandbyPos.UseVisualStyleBackColor = False
    '
    'GroupRun_BarcodeInLine
    '
    Me.GroupRun_BarcodeInLine.Controls.Add(Me.TextRun_Barcode_Reader)
    Me.GroupRun_BarcodeInLine.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Bold)
    Me.GroupRun_BarcodeInLine.Location = New System.Drawing.Point(6, 154)
    Me.GroupRun_BarcodeInLine.Name = "GroupRun_BarcodeInLine"
    Me.GroupRun_BarcodeInLine.Size = New System.Drawing.Size(843, 63)
    Me.GroupRun_BarcodeInLine.TabIndex = 18
    Me.GroupRun_BarcodeInLine.TabStop = False
    Me.GroupRun_BarcodeInLine.Text = "條碼(固定)"
    '
    'TextRun_Barcode_Reader
    '
    Me.TextRun_Barcode_Reader.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold)
    Me.TextRun_Barcode_Reader.Location = New System.Drawing.Point(7, 17)
    Me.TextRun_Barcode_Reader.Name = "TextRun_Barcode_Reader"
    Me.TextRun_Barcode_Reader.Size = New System.Drawing.Size(828, 39)
    Me.TextRun_Barcode_Reader.TabIndex = 1
    Me.TextRun_Barcode_Reader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'BtnRun_MoveToSearchPos
    '
    Me.BtnRun_MoveToSearchPos.BackColor = System.Drawing.Color.White
    Me.BtnRun_MoveToSearchPos.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_MoveToSearchPos.ImeMode = System.Windows.Forms.ImeMode.NoControl
    Me.BtnRun_MoveToSearchPos.Location = New System.Drawing.Point(540, 220)
    Me.BtnRun_MoveToSearchPos.Name = "BtnRun_MoveToSearchPos"
    Me.BtnRun_MoveToSearchPos.Size = New System.Drawing.Size(125, 38)
    Me.BtnRun_MoveToSearchPos.TabIndex = 144
    Me.BtnRun_MoveToSearchPos.Text = "移至檢測區"
    Me.BtnRun_MoveToSearchPos.UseVisualStyleBackColor = False
    '
    'GroupRun_Result
    '
    Me.GroupRun_Result.Controls.Add(Me.GroupRun_DefectLength_Outside)
    Me.GroupRun_Result.Controls.Add(Me.GroupRun_DefectCount_Inside)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Diameter_CCD4)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Diameter_CCD3)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Diameter_CCD2)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Diameter_CCD1)
    Me.GroupRun_Result.Controls.Add(Me.GroupRun_OkNg)
    Me.GroupRun_Result.Controls.Add(Me.Label51)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Defect_TrueCircle_CCD4)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Defect_TrueCircle_CCD3)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Defect_TrueCircle_CCD2)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Defect_TrueCircle_CCD1)
    Me.GroupRun_Result.Controls.Add(Me.Label33)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Distance_UpDown)
    Me.GroupRun_Result.Controls.Add(Me.Label34)
    Me.GroupRun_Result.Controls.Add(Me.LabRun_Distance_LeftRight)
    Me.GroupRun_Result.Controls.Add(Me.Label31)
    Me.GroupRun_Result.Controls.Add(Me.Label35)
    Me.GroupRun_Result.Controls.Add(Me.Label36)
    Me.GroupRun_Result.Controls.Add(Me.Label41)
    Me.GroupRun_Result.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupRun_Result.Location = New System.Drawing.Point(292, 262)
    Me.GroupRun_Result.Name = "GroupRun_Result"
    Me.GroupRun_Result.Size = New System.Drawing.Size(556, 515)
    Me.GroupRun_Result.TabIndex = 124
    Me.GroupRun_Result.TabStop = False
    Me.GroupRun_Result.Text = "檢測結果資訊"
    '
    'GroupRun_DefectLength_Outside
    '
    Me.GroupRun_DefectLength_Outside.Controls.Add(Me.DataGrid_DefectLength_Outside)
    Me.GroupRun_DefectLength_Outside.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
    Me.GroupRun_DefectLength_Outside.Location = New System.Drawing.Point(4, 339)
    Me.GroupRun_DefectLength_Outside.Name = "GroupRun_DefectLength_Outside"
    Me.GroupRun_DefectLength_Outside.Size = New System.Drawing.Size(548, 172)
    Me.GroupRun_DefectLength_Outside.TabIndex = 145
    Me.GroupRun_DefectLength_Outside.TabStop = False
    Me.GroupRun_DefectLength_Outside.Text = "圓外瑕疵長度(mm)"
    '
    'DataGrid_DefectLength_Outside
    '
    Me.DataGrid_DefectLength_Outside.AllowUserToAddRows = False
    Me.DataGrid_DefectLength_Outside.AllowUserToDeleteRows = False
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGrid_DefectLength_Outside.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
    Me.DataGrid_DefectLength_Outside.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGrid_DefectLength_Outside.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
    Me.DataGrid_DefectLength_Outside.Location = New System.Drawing.Point(4, 18)
    Me.DataGrid_DefectLength_Outside.Name = "DataGrid_DefectLength_Outside"
    Me.DataGrid_DefectLength_Outside.ReadOnly = True
    Me.DataGrid_DefectLength_Outside.RowHeadersVisible = False
    Me.DataGrid_DefectLength_Outside.RowTemplate.Height = 24
    Me.DataGrid_DefectLength_Outside.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrid_DefectLength_Outside.Size = New System.Drawing.Size(539, 150)
    Me.DataGrid_DefectLength_Outside.TabIndex = 142
    '
    'DataGridViewTextBoxColumn1
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
    Me.DataGridViewTextBoxColumn1.HeaderText = "Index"
    Me.DataGridViewTextBoxColumn1.MaxInputLength = 4
    Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
    Me.DataGridViewTextBoxColumn1.ReadOnly = True
    Me.DataGridViewTextBoxColumn1.Width = 70
    '
    'DataGridViewTextBoxColumn2
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
    Me.DataGridViewTextBoxColumn2.HeaderText = "CCD1"
    Me.DataGridViewTextBoxColumn2.MaxInputLength = 10
    Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
    Me.DataGridViewTextBoxColumn2.ReadOnly = True
    Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGridViewTextBoxColumn2.Width = 111
    '
    'DataGridViewTextBoxColumn3
    '
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle5
    Me.DataGridViewTextBoxColumn3.HeaderText = "CCD2"
    Me.DataGridViewTextBoxColumn3.MaxInputLength = 10
    Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
    Me.DataGridViewTextBoxColumn3.ReadOnly = True
    Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGridViewTextBoxColumn3.Width = 111
    '
    'DataGridViewTextBoxColumn4
    '
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle6
    Me.DataGridViewTextBoxColumn4.HeaderText = "CCD3"
    Me.DataGridViewTextBoxColumn4.MaxInputLength = 10
    Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
    Me.DataGridViewTextBoxColumn4.ReadOnly = True
    Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGridViewTextBoxColumn4.Width = 111
    '
    'DataGridViewTextBoxColumn5
    '
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle7
    Me.DataGridViewTextBoxColumn5.HeaderText = "CCD4"
    Me.DataGridViewTextBoxColumn5.MaxInputLength = 10
    Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
    Me.DataGridViewTextBoxColumn5.ReadOnly = True
    Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGridViewTextBoxColumn5.Width = 111
    '
    'GroupRun_DefectCount_Inside
    '
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.LabServer_Receive_NoncontinueCount_CCD4)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.LabServer_Receive_NoncontinueCount_CCD3)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.LabServer_Receive_NoncontinueCount_CCD2)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.LabServer_Receive_NoncontinueCount_CCD1)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.LabServer_Receive_ContinueCount_CCD4)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.LabServer_Receive_ContinueCount_CCD3)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.LabServer_Receive_ContinueCount_CCD2)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.LabServer_Receive_ContinueCount_CCD1)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.Label63)
    Me.GroupRun_DefectCount_Inside.Controls.Add(Me.Label117)
    Me.GroupRun_DefectCount_Inside.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
    Me.GroupRun_DefectCount_Inside.Location = New System.Drawing.Point(4, 165)
    Me.GroupRun_DefectCount_Inside.Name = "GroupRun_DefectCount_Inside"
    Me.GroupRun_DefectCount_Inside.Size = New System.Drawing.Size(548, 134)
    Me.GroupRun_DefectCount_Inside.TabIndex = 144
    Me.GroupRun_DefectCount_Inside.TabStop = False
    Me.GroupRun_DefectCount_Inside.Text = "圓內瑕疵數量(Pixel)"
    '
    'LabServer_Receive_NoncontinueCount_CCD4
    '
    Me.LabServer_Receive_NoncontinueCount_CCD4.BackColor = System.Drawing.Color.White
    Me.LabServer_Receive_NoncontinueCount_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabServer_Receive_NoncontinueCount_CCD4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabServer_Receive_NoncontinueCount_CCD4.Location = New System.Drawing.Point(423, 68)
    Me.LabServer_Receive_NoncontinueCount_CCD4.Name = "LabServer_Receive_NoncontinueCount_CCD4"
    Me.LabServer_Receive_NoncontinueCount_CCD4.Size = New System.Drawing.Size(110, 29)
    Me.LabServer_Receive_NoncontinueCount_CCD4.TabIndex = 186
    Me.LabServer_Receive_NoncontinueCount_CCD4.Tag = ""
    Me.LabServer_Receive_NoncontinueCount_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabServer_Receive_NoncontinueCount_CCD3
    '
    Me.LabServer_Receive_NoncontinueCount_CCD3.BackColor = System.Drawing.Color.White
    Me.LabServer_Receive_NoncontinueCount_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabServer_Receive_NoncontinueCount_CCD3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabServer_Receive_NoncontinueCount_CCD3.Location = New System.Drawing.Point(312, 68)
    Me.LabServer_Receive_NoncontinueCount_CCD3.Name = "LabServer_Receive_NoncontinueCount_CCD3"
    Me.LabServer_Receive_NoncontinueCount_CCD3.Size = New System.Drawing.Size(110, 29)
    Me.LabServer_Receive_NoncontinueCount_CCD3.TabIndex = 185
    Me.LabServer_Receive_NoncontinueCount_CCD3.Tag = ""
    Me.LabServer_Receive_NoncontinueCount_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabServer_Receive_NoncontinueCount_CCD2
    '
    Me.LabServer_Receive_NoncontinueCount_CCD2.BackColor = System.Drawing.Color.White
    Me.LabServer_Receive_NoncontinueCount_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabServer_Receive_NoncontinueCount_CCD2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabServer_Receive_NoncontinueCount_CCD2.Location = New System.Drawing.Point(201, 68)
    Me.LabServer_Receive_NoncontinueCount_CCD2.Name = "LabServer_Receive_NoncontinueCount_CCD2"
    Me.LabServer_Receive_NoncontinueCount_CCD2.Size = New System.Drawing.Size(110, 29)
    Me.LabServer_Receive_NoncontinueCount_CCD2.TabIndex = 184
    Me.LabServer_Receive_NoncontinueCount_CCD2.Tag = ""
    Me.LabServer_Receive_NoncontinueCount_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabServer_Receive_NoncontinueCount_CCD1
    '
    Me.LabServer_Receive_NoncontinueCount_CCD1.BackColor = System.Drawing.Color.White
    Me.LabServer_Receive_NoncontinueCount_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabServer_Receive_NoncontinueCount_CCD1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabServer_Receive_NoncontinueCount_CCD1.Location = New System.Drawing.Point(90, 68)
    Me.LabServer_Receive_NoncontinueCount_CCD1.Name = "LabServer_Receive_NoncontinueCount_CCD1"
    Me.LabServer_Receive_NoncontinueCount_CCD1.Size = New System.Drawing.Size(110, 29)
    Me.LabServer_Receive_NoncontinueCount_CCD1.TabIndex = 183
    Me.LabServer_Receive_NoncontinueCount_CCD1.Tag = ""
    Me.LabServer_Receive_NoncontinueCount_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabServer_Receive_ContinueCount_CCD4
    '
    Me.LabServer_Receive_ContinueCount_CCD4.BackColor = System.Drawing.Color.White
    Me.LabServer_Receive_ContinueCount_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabServer_Receive_ContinueCount_CCD4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabServer_Receive_ContinueCount_CCD4.Location = New System.Drawing.Point(423, 38)
    Me.LabServer_Receive_ContinueCount_CCD4.Name = "LabServer_Receive_ContinueCount_CCD4"
    Me.LabServer_Receive_ContinueCount_CCD4.Size = New System.Drawing.Size(110, 29)
    Me.LabServer_Receive_ContinueCount_CCD4.TabIndex = 182
    Me.LabServer_Receive_ContinueCount_CCD4.Tag = ""
    Me.LabServer_Receive_ContinueCount_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabServer_Receive_ContinueCount_CCD3
    '
    Me.LabServer_Receive_ContinueCount_CCD3.BackColor = System.Drawing.Color.White
    Me.LabServer_Receive_ContinueCount_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabServer_Receive_ContinueCount_CCD3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabServer_Receive_ContinueCount_CCD3.Location = New System.Drawing.Point(312, 38)
    Me.LabServer_Receive_ContinueCount_CCD3.Name = "LabServer_Receive_ContinueCount_CCD3"
    Me.LabServer_Receive_ContinueCount_CCD3.Size = New System.Drawing.Size(110, 29)
    Me.LabServer_Receive_ContinueCount_CCD3.TabIndex = 181
    Me.LabServer_Receive_ContinueCount_CCD3.Tag = ""
    Me.LabServer_Receive_ContinueCount_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabServer_Receive_ContinueCount_CCD2
    '
    Me.LabServer_Receive_ContinueCount_CCD2.BackColor = System.Drawing.Color.White
    Me.LabServer_Receive_ContinueCount_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabServer_Receive_ContinueCount_CCD2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabServer_Receive_ContinueCount_CCD2.Location = New System.Drawing.Point(201, 38)
    Me.LabServer_Receive_ContinueCount_CCD2.Name = "LabServer_Receive_ContinueCount_CCD2"
    Me.LabServer_Receive_ContinueCount_CCD2.Size = New System.Drawing.Size(110, 29)
    Me.LabServer_Receive_ContinueCount_CCD2.TabIndex = 180
    Me.LabServer_Receive_ContinueCount_CCD2.Tag = ""
    Me.LabServer_Receive_ContinueCount_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabServer_Receive_ContinueCount_CCD1
    '
    Me.LabServer_Receive_ContinueCount_CCD1.BackColor = System.Drawing.Color.White
    Me.LabServer_Receive_ContinueCount_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabServer_Receive_ContinueCount_CCD1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabServer_Receive_ContinueCount_CCD1.Location = New System.Drawing.Point(90, 38)
    Me.LabServer_Receive_ContinueCount_CCD1.Name = "LabServer_Receive_ContinueCount_CCD1"
    Me.LabServer_Receive_ContinueCount_CCD1.Size = New System.Drawing.Size(110, 29)
    Me.LabServer_Receive_ContinueCount_CCD1.TabIndex = 179
    Me.LabServer_Receive_ContinueCount_CCD1.Tag = ""
    Me.LabServer_Receive_ContinueCount_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label63
    '
    Me.Label63.AutoSize = True
    Me.Label63.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label63.Location = New System.Drawing.Point(3, 45)
    Me.Label63.Name = "Label63"
    Me.Label63.Size = New System.Drawing.Size(87, 45)
    Me.Label63.TabIndex = 178
    Me.Label63.Text = "連續數量" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "不連續數量"
    '
    'Label117
    '
    Me.Label117.AutoSize = True
    Me.Label117.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label117.Location = New System.Drawing.Point(119, 19)
    Me.Label117.Name = "Label117"
    Me.Label117.Size = New System.Drawing.Size(381, 19)
    Me.Label117.TabIndex = 177
    Me.Label117.Text = "CCD1                CCD2                CCD3                CCD4"
    '
    'LabRun_Diameter_CCD4
    '
    Me.LabRun_Diameter_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Diameter_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Diameter_CCD4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Diameter_CCD4.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Diameter_CCD4.Location = New System.Drawing.Point(281, 106)
    Me.LabRun_Diameter_CCD4.Name = "LabRun_Diameter_CCD4"
    Me.LabRun_Diameter_CCD4.Size = New System.Drawing.Size(74, 28)
    Me.LabRun_Diameter_CCD4.TabIndex = 17
    Me.LabRun_Diameter_CCD4.Tag = "4"
    Me.LabRun_Diameter_CCD4.Text = "0"
    Me.LabRun_Diameter_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabRun_Diameter_CCD3
    '
    Me.LabRun_Diameter_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Diameter_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Diameter_CCD3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Diameter_CCD3.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Diameter_CCD3.Location = New System.Drawing.Point(208, 106)
    Me.LabRun_Diameter_CCD3.Name = "LabRun_Diameter_CCD3"
    Me.LabRun_Diameter_CCD3.Size = New System.Drawing.Size(74, 28)
    Me.LabRun_Diameter_CCD3.TabIndex = 16
    Me.LabRun_Diameter_CCD3.Tag = "3"
    Me.LabRun_Diameter_CCD3.Text = "0"
    Me.LabRun_Diameter_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabRun_Diameter_CCD2
    '
    Me.LabRun_Diameter_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Diameter_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Diameter_CCD2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Diameter_CCD2.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Diameter_CCD2.Location = New System.Drawing.Point(135, 106)
    Me.LabRun_Diameter_CCD2.Name = "LabRun_Diameter_CCD2"
    Me.LabRun_Diameter_CCD2.Size = New System.Drawing.Size(74, 28)
    Me.LabRun_Diameter_CCD2.TabIndex = 15
    Me.LabRun_Diameter_CCD2.Tag = "2"
    Me.LabRun_Diameter_CCD2.Text = "0"
    Me.LabRun_Diameter_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabRun_Diameter_CCD1
    '
    Me.LabRun_Diameter_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Diameter_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Diameter_CCD1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Diameter_CCD1.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Diameter_CCD1.Location = New System.Drawing.Point(62, 106)
    Me.LabRun_Diameter_CCD1.Name = "LabRun_Diameter_CCD1"
    Me.LabRun_Diameter_CCD1.Size = New System.Drawing.Size(74, 28)
    Me.LabRun_Diameter_CCD1.TabIndex = 14
    Me.LabRun_Diameter_CCD1.Tag = "1"
    Me.LabRun_Diameter_CCD1.Text = "0"
    Me.LabRun_Diameter_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'GroupRun_OkNg
    '
    Me.GroupRun_OkNg.Controls.Add(Me.LabRun_SearchResult)
    Me.GroupRun_OkNg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupRun_OkNg.Location = New System.Drawing.Point(432, 12)
    Me.GroupRun_OkNg.Name = "GroupRun_OkNg"
    Me.GroupRun_OkNg.Size = New System.Drawing.Size(116, 87)
    Me.GroupRun_OkNg.TabIndex = 139
    Me.GroupRun_OkNg.TabStop = False
    Me.GroupRun_OkNg.Text = "檢測結果"
    '
    'LabRun_SearchResult
    '
    Me.LabRun_SearchResult.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_SearchResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_SearchResult.Font = New System.Drawing.Font("Arial", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_SearchResult.Location = New System.Drawing.Point(7, 18)
    Me.LabRun_SearchResult.Name = "LabRun_SearchResult"
    Me.LabRun_SearchResult.Size = New System.Drawing.Size(102, 62)
    Me.LabRun_SearchResult.TabIndex = 93
    Me.LabRun_SearchResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Label51
    '
    Me.Label51.AutoSize = True
    Me.Label51.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label51.Location = New System.Drawing.Point(7, 111)
    Me.Label51.Name = "Label51"
    Me.Label51.Size = New System.Drawing.Size(42, 16)
    Me.Label51.TabIndex = 13
    Me.Label51.Text = "孔徑"
    '
    'LabRun_Defect_TrueCircle_CCD4
    '
    Me.LabRun_Defect_TrueCircle_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Defect_TrueCircle_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Defect_TrueCircle_CCD4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Defect_TrueCircle_CCD4.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Defect_TrueCircle_CCD4.Location = New System.Drawing.Point(281, 133)
    Me.LabRun_Defect_TrueCircle_CCD4.Name = "LabRun_Defect_TrueCircle_CCD4"
    Me.LabRun_Defect_TrueCircle_CCD4.Size = New System.Drawing.Size(74, 28)
    Me.LabRun_Defect_TrueCircle_CCD4.TabIndex = 11
    Me.LabRun_Defect_TrueCircle_CCD4.Tag = "4"
    Me.LabRun_Defect_TrueCircle_CCD4.Text = "0"
    Me.LabRun_Defect_TrueCircle_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabRun_Defect_TrueCircle_CCD3
    '
    Me.LabRun_Defect_TrueCircle_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Defect_TrueCircle_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Defect_TrueCircle_CCD3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Defect_TrueCircle_CCD3.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Defect_TrueCircle_CCD3.Location = New System.Drawing.Point(208, 133)
    Me.LabRun_Defect_TrueCircle_CCD3.Name = "LabRun_Defect_TrueCircle_CCD3"
    Me.LabRun_Defect_TrueCircle_CCD3.Size = New System.Drawing.Size(74, 28)
    Me.LabRun_Defect_TrueCircle_CCD3.TabIndex = 10
    Me.LabRun_Defect_TrueCircle_CCD3.Tag = "3"
    Me.LabRun_Defect_TrueCircle_CCD3.Text = "0"
    Me.LabRun_Defect_TrueCircle_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabRun_Defect_TrueCircle_CCD2
    '
    Me.LabRun_Defect_TrueCircle_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Defect_TrueCircle_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Defect_TrueCircle_CCD2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Defect_TrueCircle_CCD2.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Defect_TrueCircle_CCD2.Location = New System.Drawing.Point(135, 133)
    Me.LabRun_Defect_TrueCircle_CCD2.Name = "LabRun_Defect_TrueCircle_CCD2"
    Me.LabRun_Defect_TrueCircle_CCD2.Size = New System.Drawing.Size(74, 28)
    Me.LabRun_Defect_TrueCircle_CCD2.TabIndex = 9
    Me.LabRun_Defect_TrueCircle_CCD2.Tag = "2"
    Me.LabRun_Defect_TrueCircle_CCD2.Text = "0"
    Me.LabRun_Defect_TrueCircle_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabRun_Defect_TrueCircle_CCD1
    '
    Me.LabRun_Defect_TrueCircle_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Defect_TrueCircle_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Defect_TrueCircle_CCD1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Defect_TrueCircle_CCD1.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Defect_TrueCircle_CCD1.Location = New System.Drawing.Point(62, 133)
    Me.LabRun_Defect_TrueCircle_CCD1.Name = "LabRun_Defect_TrueCircle_CCD1"
    Me.LabRun_Defect_TrueCircle_CCD1.Size = New System.Drawing.Size(74, 28)
    Me.LabRun_Defect_TrueCircle_CCD1.TabIndex = 6
    Me.LabRun_Defect_TrueCircle_CCD1.Tag = "1"
    Me.LabRun_Defect_TrueCircle_CCD1.Text = "0"
    Me.LabRun_Defect_TrueCircle_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label33
    '
    Me.Label33.AutoSize = True
    Me.Label33.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label33.Location = New System.Drawing.Point(6, 138)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(59, 16)
    Me.Label33.TabIndex = 5
    Me.Label33.Text = "真圓度"
    '
    'LabRun_Distance_UpDown
    '
    Me.LabRun_Distance_UpDown.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Distance_UpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Distance_UpDown.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Distance_UpDown.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Distance_UpDown.Location = New System.Drawing.Point(98, 47)
    Me.LabRun_Distance_UpDown.Name = "LabRun_Distance_UpDown"
    Me.LabRun_Distance_UpDown.Size = New System.Drawing.Size(112, 28)
    Me.LabRun_Distance_UpDown.TabIndex = 4
    Me.LabRun_Distance_UpDown.Text = "0"
    Me.LabRun_Distance_UpDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label34
    '
    Me.Label34.AutoSize = True
    Me.Label34.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label34.Location = New System.Drawing.Point(6, 52)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(93, 16)
    Me.Label34.TabIndex = 3
    Me.Label34.Text = "上下孔距離"
    '
    'LabRun_Distance_LeftRight
    '
    Me.LabRun_Distance_LeftRight.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Distance_LeftRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Distance_LeftRight.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabRun_Distance_LeftRight.ForeColor = System.Drawing.Color.Black
    Me.LabRun_Distance_LeftRight.Location = New System.Drawing.Point(98, 20)
    Me.LabRun_Distance_LeftRight.Name = "LabRun_Distance_LeftRight"
    Me.LabRun_Distance_LeftRight.Size = New System.Drawing.Size(112, 28)
    Me.LabRun_Distance_LeftRight.TabIndex = 2
    Me.LabRun_Distance_LeftRight.Text = "0"
    Me.LabRun_Distance_LeftRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label31
    '
    Me.Label31.AutoSize = True
    Me.Label31.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label31.Location = New System.Drawing.Point(6, 25)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(93, 16)
    Me.Label31.TabIndex = 1
    Me.Label31.Text = "左右孔距離"
    '
    'Label35
    '
    Me.Label35.AutoSize = True
    Me.Label35.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label35.Location = New System.Drawing.Point(208, 19)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(48, 54)
    Me.Label35.TabIndex = 7
    Me.Label35.Text = "mm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "mm"
    '
    'Label36
    '
    Me.Label36.AutoSize = True
    Me.Label36.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(68, 87)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(282, 22)
    Me.Label36.TabIndex = 8
    Me.Label36.Text = "CCD1    CCD2    CCD3    CCD4"
    '
    'Label41
    '
    Me.Label41.AutoSize = True
    Me.Label41.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label41.Location = New System.Drawing.Point(352, 106)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(48, 54)
    Me.Label41.TabIndex = 12
    Me.Label41.Text = "mm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "%"
    '
    'GroupRun_Msg
    '
    Me.GroupRun_Msg.Controls.Add(Me.LabRun_Msg_PLC)
    Me.GroupRun_Msg.Controls.Add(Me.LabRunningMsg)
    Me.GroupRun_Msg.Controls.Add(Me.Label48)
    Me.GroupRun_Msg.Controls.Add(Me.LabRun_Msg_CCD4)
    Me.GroupRun_Msg.Controls.Add(Me.LabRun_Msg_CCD3)
    Me.GroupRun_Msg.Controls.Add(Me.LabRun_Msg_CCD2)
    Me.GroupRun_Msg.Controls.Add(Me.LabRun_Msg_CCD1)
    Me.GroupRun_Msg.Controls.Add(Me.Label10)
    Me.GroupRun_Msg.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.GroupRun_Msg.Location = New System.Drawing.Point(6, 6)
    Me.GroupRun_Msg.Name = "GroupRun_Msg"
    Me.GroupRun_Msg.Size = New System.Drawing.Size(843, 146)
    Me.GroupRun_Msg.TabIndex = 123
    Me.GroupRun_Msg.TabStop = False
    Me.GroupRun_Msg.Text = "動作訊息"
    '
    'LabRun_Msg_PLC
    '
    Me.LabRun_Msg_PLC.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Msg_PLC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Msg_PLC.ForeColor = System.Drawing.Color.Navy
    Me.LabRun_Msg_PLC.Location = New System.Drawing.Point(54, 119)
    Me.LabRun_Msg_PLC.Name = "LabRun_Msg_PLC"
    Me.LabRun_Msg_PLC.Size = New System.Drawing.Size(778, 21)
    Me.LabRun_Msg_PLC.TabIndex = 9
    Me.LabRun_Msg_PLC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabRunningMsg
    '
    Me.LabRunningMsg.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRunningMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRunningMsg.ForeColor = System.Drawing.Color.Navy
    Me.LabRunningMsg.Location = New System.Drawing.Point(54, 19)
    Me.LabRunningMsg.Name = "LabRunningMsg"
    Me.LabRunningMsg.Size = New System.Drawing.Size(778, 21)
    Me.LabRunningMsg.TabIndex = 8
    Me.LabRunningMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label48
    '
    Me.Label48.AutoSize = True
    Me.Label48.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label48.Location = New System.Drawing.Point(8, 23)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(43, 13)
    Me.Label48.TabIndex = 7
    Me.Label48.Text = "系  統"
    '
    'LabRun_Msg_CCD4
    '
    Me.LabRun_Msg_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Msg_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Msg_CCD4.ForeColor = System.Drawing.Color.Navy
    Me.LabRun_Msg_CCD4.Location = New System.Drawing.Point(54, 99)
    Me.LabRun_Msg_CCD4.Name = "LabRun_Msg_CCD4"
    Me.LabRun_Msg_CCD4.Size = New System.Drawing.Size(778, 21)
    Me.LabRun_Msg_CCD4.TabIndex = 6
    Me.LabRun_Msg_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabRun_Msg_CCD3
    '
    Me.LabRun_Msg_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Msg_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Msg_CCD3.ForeColor = System.Drawing.Color.Navy
    Me.LabRun_Msg_CCD3.Location = New System.Drawing.Point(54, 79)
    Me.LabRun_Msg_CCD3.Name = "LabRun_Msg_CCD3"
    Me.LabRun_Msg_CCD3.Size = New System.Drawing.Size(778, 21)
    Me.LabRun_Msg_CCD3.TabIndex = 5
    Me.LabRun_Msg_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabRun_Msg_CCD2
    '
    Me.LabRun_Msg_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Msg_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Msg_CCD2.ForeColor = System.Drawing.Color.Navy
    Me.LabRun_Msg_CCD2.Location = New System.Drawing.Point(54, 59)
    Me.LabRun_Msg_CCD2.Name = "LabRun_Msg_CCD2"
    Me.LabRun_Msg_CCD2.Size = New System.Drawing.Size(778, 21)
    Me.LabRun_Msg_CCD2.TabIndex = 4
    Me.LabRun_Msg_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LabRun_Msg_CCD1
    '
    Me.LabRun_Msg_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.LabRun_Msg_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabRun_Msg_CCD1.ForeColor = System.Drawing.Color.Navy
    Me.LabRun_Msg_CCD1.Location = New System.Drawing.Point(54, 39)
    Me.LabRun_Msg_CCD1.Name = "LabRun_Msg_CCD1"
    Me.LabRun_Msg_CCD1.Size = New System.Drawing.Size(778, 21)
    Me.LabRun_Msg_CCD1.TabIndex = 1
    Me.LabRun_Msg_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(7, 39)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(46, 100)
    Me.Label10.TabIndex = 0
    Me.Label10.Text = "CCD1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CCD2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CCD3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CCD4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PLC"
    '
    'BtnRun_LoadNgImages
    '
    Me.BtnRun_LoadNgImages.BackColor = System.Drawing.SystemColors.Control
    Me.BtnRun_LoadNgImages.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold)
    Me.BtnRun_LoadNgImages.Location = New System.Drawing.Point(292, 220)
    Me.BtnRun_LoadNgImages.Name = "BtnRun_LoadNgImages"
    Me.BtnRun_LoadNgImages.Size = New System.Drawing.Size(125, 38)
    Me.BtnRun_LoadNgImages.TabIndex = 141
    Me.BtnRun_LoadNgImages.Tag = ""
    Me.BtnRun_LoadNgImages.Text = "載入最後NG圖"
    Me.BtnRun_LoadNgImages.UseVisualStyleBackColor = False
    '
    'BtnRun_ResetRunIndex
    '
    Me.BtnRun_ResetRunIndex.BackColor = System.Drawing.SystemColors.Control
    Me.BtnRun_ResetRunIndex.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold)
    Me.BtnRun_ResetRunIndex.Location = New System.Drawing.Point(416, 220)
    Me.BtnRun_ResetRunIndex.Name = "BtnRun_ResetRunIndex"
    Me.BtnRun_ResetRunIndex.Size = New System.Drawing.Size(125, 38)
    Me.BtnRun_ResetRunIndex.TabIndex = 140
    Me.BtnRun_ResetRunIndex.Tag = ""
    Me.BtnRun_ResetRunIndex.Text = "清除作業程序"
    Me.BtnRun_ResetRunIndex.UseVisualStyleBackColor = False
    '
    'LabSearch1_Result_CCD4
    '
    Me.LabSearch1_Result_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSearch1_Result_CCD4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSearch1_Result_CCD4.Location = New System.Drawing.Point(1, 437)
    Me.LabSearch1_Result_CCD4.Name = "LabSearch1_Result_CCD4"
    Me.LabSearch1_Result_CCD4.Size = New System.Drawing.Size(334, 22)
    Me.LabSearch1_Result_CCD4.TabIndex = 138
    Me.LabSearch1_Result_CCD4.Text = "CCD4 (左)"
    Me.LabSearch1_Result_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabSearch1_Result_CCD3
    '
    Me.LabSearch1_Result_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSearch1_Result_CCD3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSearch1_Result_CCD3.Location = New System.Drawing.Point(1, 437)
    Me.LabSearch1_Result_CCD3.Name = "LabSearch1_Result_CCD3"
    Me.LabSearch1_Result_CCD3.Size = New System.Drawing.Size(334, 22)
    Me.LabSearch1_Result_CCD3.TabIndex = 137
    Me.LabSearch1_Result_CCD3.Text = "CCD3 (前)"
    Me.LabSearch1_Result_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabSearch1_Result_CCD2
    '
    Me.LabSearch1_Result_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSearch1_Result_CCD2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSearch1_Result_CCD2.Location = New System.Drawing.Point(1, 437)
    Me.LabSearch1_Result_CCD2.Name = "LabSearch1_Result_CCD2"
    Me.LabSearch1_Result_CCD2.Size = New System.Drawing.Size(334, 22)
    Me.LabSearch1_Result_CCD2.TabIndex = 136
    Me.LabSearch1_Result_CCD2.Text = "CCD2 (右)"
    Me.LabSearch1_Result_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabSearch1_Result_CCD1
    '
    Me.LabSearch1_Result_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSearch1_Result_CCD1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSearch1_Result_CCD1.Location = New System.Drawing.Point(1, 437)
    Me.LabSearch1_Result_CCD1.Name = "LabSearch1_Result_CCD1"
    Me.LabSearch1_Result_CCD1.Size = New System.Drawing.Size(334, 22)
    Me.LabSearch1_Result_CCD1.TabIndex = 135
    Me.LabSearch1_Result_CCD1.Text = "CCD1 (後)"
    Me.LabSearch1_Result_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnRun_ImageLoad_CCD4
    '
    Me.BtnRun_ImageLoad_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageLoad_CCD4.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageLoad_CCD4.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageLoad_CCD4.Location = New System.Drawing.Point(374, 436)
    Me.BtnRun_ImageLoad_CCD4.Name = "BtnRun_ImageLoad_CCD4"
    Me.BtnRun_ImageLoad_CCD4.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageLoad_CCD4.TabIndex = 133
    Me.BtnRun_ImageLoad_CCD4.TabStop = False
    Me.BtnRun_ImageLoad_CCD4.Tag = "4"
    Me.BtnRun_ImageLoad_CCD4.Text = "載圖"
    Me.BtnRun_ImageLoad_CCD4.UseVisualStyleBackColor = False
    '
    'BtnRun_ImageSave_CCD4
    '
    Me.BtnRun_ImageSave_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageSave_CCD4.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageSave_CCD4.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageSave_CCD4.Location = New System.Drawing.Point(412, 436)
    Me.BtnRun_ImageSave_CCD4.Name = "BtnRun_ImageSave_CCD4"
    Me.BtnRun_ImageSave_CCD4.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageSave_CCD4.TabIndex = 134
    Me.BtnRun_ImageSave_CCD4.TabStop = False
    Me.BtnRun_ImageSave_CCD4.Tag = "4"
    Me.BtnRun_ImageSave_CCD4.Text = "存圖"
    Me.BtnRun_ImageSave_CCD4.UseVisualStyleBackColor = False
    '
    'BtnRun_ImageLoad_CCD2
    '
    Me.BtnRun_ImageLoad_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageLoad_CCD2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageLoad_CCD2.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageLoad_CCD2.Location = New System.Drawing.Point(374, 436)
    Me.BtnRun_ImageLoad_CCD2.Name = "BtnRun_ImageLoad_CCD2"
    Me.BtnRun_ImageLoad_CCD2.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageLoad_CCD2.TabIndex = 131
    Me.BtnRun_ImageLoad_CCD2.TabStop = False
    Me.BtnRun_ImageLoad_CCD2.Tag = "2"
    Me.BtnRun_ImageLoad_CCD2.Text = "載圖"
    Me.BtnRun_ImageLoad_CCD2.UseVisualStyleBackColor = False
    '
    'BtnRun_ImageSave_CCD2
    '
    Me.BtnRun_ImageSave_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageSave_CCD2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageSave_CCD2.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageSave_CCD2.Location = New System.Drawing.Point(412, 436)
    Me.BtnRun_ImageSave_CCD2.Name = "BtnRun_ImageSave_CCD2"
    Me.BtnRun_ImageSave_CCD2.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageSave_CCD2.TabIndex = 132
    Me.BtnRun_ImageSave_CCD2.TabStop = False
    Me.BtnRun_ImageSave_CCD2.Tag = "2"
    Me.BtnRun_ImageSave_CCD2.Text = "存圖"
    Me.BtnRun_ImageSave_CCD2.UseVisualStyleBackColor = False
    '
    'BtnRun_ImageLoad_CCD1
    '
    Me.BtnRun_ImageLoad_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageLoad_CCD1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageLoad_CCD1.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageLoad_CCD1.Location = New System.Drawing.Point(374, 436)
    Me.BtnRun_ImageLoad_CCD1.Name = "BtnRun_ImageLoad_CCD1"
    Me.BtnRun_ImageLoad_CCD1.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageLoad_CCD1.TabIndex = 129
    Me.BtnRun_ImageLoad_CCD1.TabStop = False
    Me.BtnRun_ImageLoad_CCD1.Tag = "1"
    Me.BtnRun_ImageLoad_CCD1.Text = "載圖"
    Me.BtnRun_ImageLoad_CCD1.UseVisualStyleBackColor = False
    '
    'BtnRun_ImageSave_CCD1
    '
    Me.BtnRun_ImageSave_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageSave_CCD1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageSave_CCD1.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageSave_CCD1.Location = New System.Drawing.Point(412, 436)
    Me.BtnRun_ImageSave_CCD1.Name = "BtnRun_ImageSave_CCD1"
    Me.BtnRun_ImageSave_CCD1.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageSave_CCD1.TabIndex = 130
    Me.BtnRun_ImageSave_CCD1.TabStop = False
    Me.BtnRun_ImageSave_CCD1.Tag = "1"
    Me.BtnRun_ImageSave_CCD1.Text = "存圖"
    Me.BtnRun_ImageSave_CCD1.UseVisualStyleBackColor = False
    '
    'BtnRun_ImageLoad_CCD3
    '
    Me.BtnRun_ImageLoad_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageLoad_CCD3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageLoad_CCD3.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageLoad_CCD3.Location = New System.Drawing.Point(374, 436)
    Me.BtnRun_ImageLoad_CCD3.Name = "BtnRun_ImageLoad_CCD3"
    Me.BtnRun_ImageLoad_CCD3.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageLoad_CCD3.TabIndex = 127
    Me.BtnRun_ImageLoad_CCD3.TabStop = False
    Me.BtnRun_ImageLoad_CCD3.Tag = "3"
    Me.BtnRun_ImageLoad_CCD3.Text = "載圖"
    Me.BtnRun_ImageLoad_CCD3.UseVisualStyleBackColor = False
    '
    'BtnRun_ImageSave_CCD3
    '
    Me.BtnRun_ImageSave_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageSave_CCD3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageSave_CCD3.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageSave_CCD3.Location = New System.Drawing.Point(412, 436)
    Me.BtnRun_ImageSave_CCD3.Name = "BtnRun_ImageSave_CCD3"
    Me.BtnRun_ImageSave_CCD3.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageSave_CCD3.TabIndex = 128
    Me.BtnRun_ImageSave_CCD3.TabStop = False
    Me.BtnRun_ImageSave_CCD3.Tag = "3"
    Me.BtnRun_ImageSave_CCD3.Text = "存圖"
    Me.BtnRun_ImageSave_CCD3.UseVisualStyleBackColor = False
    '
    'CheckRun_Live_CCD4
    '
    Me.CheckRun_Live_CCD4.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckRun_Live_CCD4.BackColor = System.Drawing.Color.White
    Me.CheckRun_Live_CCD4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckRun_Live_CCD4.ForeColor = System.Drawing.Color.MidnightBlue
    Me.CheckRun_Live_CCD4.Location = New System.Drawing.Point(475, 436)
    Me.CheckRun_Live_CCD4.Name = "CheckRun_Live_CCD4"
    Me.CheckRun_Live_CCD4.Size = New System.Drawing.Size(45, 24)
    Me.CheckRun_Live_CCD4.TabIndex = 125
    Me.CheckRun_Live_CCD4.TabStop = False
    Me.CheckRun_Live_CCD4.Tag = "4"
    Me.CheckRun_Live_CCD4.Text = "Live"
    Me.CheckRun_Live_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.CheckRun_Live_CCD4.UseVisualStyleBackColor = False
    '
    'BtnRun_ZoomToFit_CCD4
    '
    Me.BtnRun_ZoomToFit_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ZoomToFit_CCD4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ZoomToFit_CCD4.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ZoomToFit_CCD4.Location = New System.Drawing.Point(450, 436)
    Me.BtnRun_ZoomToFit_CCD4.Name = "BtnRun_ZoomToFit_CCD4"
    Me.BtnRun_ZoomToFit_CCD4.Size = New System.Drawing.Size(26, 24)
    Me.BtnRun_ZoomToFit_CCD4.TabIndex = 126
    Me.BtnRun_ZoomToFit_CCD4.TabStop = False
    Me.BtnRun_ZoomToFit_CCD4.Tag = "4"
    Me.BtnRun_ZoomToFit_CCD4.Text = "□"
    Me.BtnRun_ZoomToFit_CCD4.UseVisualStyleBackColor = False
    '
    'CheckRun_Live_CCD2
    '
    Me.CheckRun_Live_CCD2.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckRun_Live_CCD2.BackColor = System.Drawing.Color.White
    Me.CheckRun_Live_CCD2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckRun_Live_CCD2.ForeColor = System.Drawing.Color.MidnightBlue
    Me.CheckRun_Live_CCD2.Location = New System.Drawing.Point(475, 436)
    Me.CheckRun_Live_CCD2.Name = "CheckRun_Live_CCD2"
    Me.CheckRun_Live_CCD2.Size = New System.Drawing.Size(45, 24)
    Me.CheckRun_Live_CCD2.TabIndex = 123
    Me.CheckRun_Live_CCD2.TabStop = False
    Me.CheckRun_Live_CCD2.Tag = "2"
    Me.CheckRun_Live_CCD2.Text = "Live"
    Me.CheckRun_Live_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.CheckRun_Live_CCD2.UseVisualStyleBackColor = False
    '
    'BtnRun_ZoomToFit_CCD2
    '
    Me.BtnRun_ZoomToFit_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ZoomToFit_CCD2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ZoomToFit_CCD2.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ZoomToFit_CCD2.Location = New System.Drawing.Point(450, 436)
    Me.BtnRun_ZoomToFit_CCD2.Name = "BtnRun_ZoomToFit_CCD2"
    Me.BtnRun_ZoomToFit_CCD2.Size = New System.Drawing.Size(26, 24)
    Me.BtnRun_ZoomToFit_CCD2.TabIndex = 124
    Me.BtnRun_ZoomToFit_CCD2.TabStop = False
    Me.BtnRun_ZoomToFit_CCD2.Tag = "2"
    Me.BtnRun_ZoomToFit_CCD2.Text = "□"
    Me.BtnRun_ZoomToFit_CCD2.UseVisualStyleBackColor = False
    '
    'CheckRun_Live_CCD3
    '
    Me.CheckRun_Live_CCD3.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckRun_Live_CCD3.BackColor = System.Drawing.Color.White
    Me.CheckRun_Live_CCD3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckRun_Live_CCD3.ForeColor = System.Drawing.Color.MidnightBlue
    Me.CheckRun_Live_CCD3.Location = New System.Drawing.Point(475, 436)
    Me.CheckRun_Live_CCD3.Name = "CheckRun_Live_CCD3"
    Me.CheckRun_Live_CCD3.Size = New System.Drawing.Size(45, 24)
    Me.CheckRun_Live_CCD3.TabIndex = 121
    Me.CheckRun_Live_CCD3.TabStop = False
    Me.CheckRun_Live_CCD3.Tag = "3"
    Me.CheckRun_Live_CCD3.Text = "Live"
    Me.CheckRun_Live_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.CheckRun_Live_CCD3.UseVisualStyleBackColor = False
    '
    'BtnRun_ZoomToFit_CCD3
    '
    Me.BtnRun_ZoomToFit_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ZoomToFit_CCD3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ZoomToFit_CCD3.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ZoomToFit_CCD3.Location = New System.Drawing.Point(450, 436)
    Me.BtnRun_ZoomToFit_CCD3.Name = "BtnRun_ZoomToFit_CCD3"
    Me.BtnRun_ZoomToFit_CCD3.Size = New System.Drawing.Size(26, 24)
    Me.BtnRun_ZoomToFit_CCD3.TabIndex = 122
    Me.BtnRun_ZoomToFit_CCD3.TabStop = False
    Me.BtnRun_ZoomToFit_CCD3.Tag = "3"
    Me.BtnRun_ZoomToFit_CCD3.Text = "□"
    Me.BtnRun_ZoomToFit_CCD3.UseVisualStyleBackColor = False
    '
    'ImageViewer_CCD3
    '
    Me.ImageViewer_CCD3.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Selection
    Me.ImageViewer_CCD3.BackColor = System.Drawing.SystemColors.ControlText
    Me.ImageViewer_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ImageViewer_CCD3.ImageInfoTextColor = New NationalInstruments.Vision.Rgb32Value(CType(0, Byte), CType(255, Byte), CType(0, Byte), CType(0, Byte))
    Me.ImageViewer_CCD3.Location = New System.Drawing.Point(1, 1)
    Me.ImageViewer_CCD3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.ImageViewer_CCD3.Name = "ImageViewer_CCD3"
    Me.ImageViewer_CCD3.ShowImageInfo = True
    Me.ImageViewer_CCD3.ShowToolbar = True
    Me.ImageViewer_CCD3.Size = New System.Drawing.Size(520, 435)
    Me.ImageViewer_CCD3.TabIndex = 119
    Me.ImageViewer_CCD3.TabStop = False
    '
    'CheckRun_Live_CCD1
    '
    Me.CheckRun_Live_CCD1.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckRun_Live_CCD1.BackColor = System.Drawing.Color.White
    Me.CheckRun_Live_CCD1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckRun_Live_CCD1.ForeColor = System.Drawing.Color.MidnightBlue
    Me.CheckRun_Live_CCD1.Location = New System.Drawing.Point(475, 436)
    Me.CheckRun_Live_CCD1.Name = "CheckRun_Live_CCD1"
    Me.CheckRun_Live_CCD1.Size = New System.Drawing.Size(45, 24)
    Me.CheckRun_Live_CCD1.TabIndex = 99
    Me.CheckRun_Live_CCD1.TabStop = False
    Me.CheckRun_Live_CCD1.Tag = "1"
    Me.CheckRun_Live_CCD1.Text = "Live"
    Me.CheckRun_Live_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.CheckRun_Live_CCD1.UseVisualStyleBackColor = False
    '
    'BtnRun_ZoomToFit_CCD1
    '
    Me.BtnRun_ZoomToFit_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ZoomToFit_CCD1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ZoomToFit_CCD1.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ZoomToFit_CCD1.Location = New System.Drawing.Point(450, 436)
    Me.BtnRun_ZoomToFit_CCD1.Name = "BtnRun_ZoomToFit_CCD1"
    Me.BtnRun_ZoomToFit_CCD1.Size = New System.Drawing.Size(26, 24)
    Me.BtnRun_ZoomToFit_CCD1.TabIndex = 117
    Me.BtnRun_ZoomToFit_CCD1.TabStop = False
    Me.BtnRun_ZoomToFit_CCD1.Tag = "1"
    Me.BtnRun_ZoomToFit_CCD1.Text = "□"
    Me.BtnRun_ZoomToFit_CCD1.UseVisualStyleBackColor = False
    '
    'ImageViewer_CCD4
    '
    Me.ImageViewer_CCD4.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Selection
    Me.ImageViewer_CCD4.BackColor = System.Drawing.SystemColors.ControlText
    Me.ImageViewer_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ImageViewer_CCD4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.ImageViewer_CCD4.ImageInfoTextColor = New NationalInstruments.Vision.Rgb32Value(CType(0, Byte), CType(255, Byte), CType(0, Byte), CType(0, Byte))
    Me.ImageViewer_CCD4.Location = New System.Drawing.Point(1, 1)
    Me.ImageViewer_CCD4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
    Me.ImageViewer_CCD4.Name = "ImageViewer_CCD4"
    Me.ImageViewer_CCD4.ShowImageInfo = True
    Me.ImageViewer_CCD4.ShowToolbar = True
    Me.ImageViewer_CCD4.Size = New System.Drawing.Size(520, 435)
    Me.ImageViewer_CCD4.TabIndex = 120
    Me.ImageViewer_CCD4.TabStop = False
    '
    'ImageViewer_CCD1
    '
    Me.ImageViewer_CCD1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Selection
    Me.ImageViewer_CCD1.BackColor = System.Drawing.SystemColors.ControlText
    Me.ImageViewer_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ImageViewer_CCD1.ImageInfoTextColor = New NationalInstruments.Vision.Rgb32Value(CType(0, Byte), CType(255, Byte), CType(0, Byte), CType(0, Byte))
    Me.ImageViewer_CCD1.Location = New System.Drawing.Point(1, 1)
    Me.ImageViewer_CCD1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.ImageViewer_CCD1.Name = "ImageViewer_CCD1"
    Me.ImageViewer_CCD1.ShowImageInfo = True
    Me.ImageViewer_CCD1.ShowToolbar = True
    Me.ImageViewer_CCD1.Size = New System.Drawing.Size(520, 435)
    Me.ImageViewer_CCD1.TabIndex = 92
    Me.ImageViewer_CCD1.TabStop = False
    '
    'ImageViewer_CCD2
    '
    Me.ImageViewer_CCD2.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Selection
    Me.ImageViewer_CCD2.BackColor = System.Drawing.SystemColors.ControlText
    Me.ImageViewer_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ImageViewer_CCD2.ImageInfoTextColor = New NationalInstruments.Vision.Rgb32Value(CType(0, Byte), CType(255, Byte), CType(0, Byte), CType(0, Byte))
    Me.ImageViewer_CCD2.Location = New System.Drawing.Point(1, 1)
    Me.ImageViewer_CCD2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.ImageViewer_CCD2.Name = "ImageViewer_CCD2"
    Me.ImageViewer_CCD2.ShowImageInfo = True
    Me.ImageViewer_CCD2.ShowToolbar = True
    Me.ImageViewer_CCD2.Size = New System.Drawing.Size(520, 435)
    Me.ImageViewer_CCD2.TabIndex = 93
    Me.ImageViewer_CCD2.TabStop = False
    '
    'TabControl_SendData
    '
    Me.TabControl_SendData.Controls.Add(Me.TabPage_Run)
    Me.TabControl_SendData.Controls.Add(Me.TabPage_Parameter)
    Me.TabControl_SendData.Controls.Add(Me.TabPage_IO)
    Me.TabControl_SendData.Controls.Add(Me.TabPage_Service)
    Me.TabControl_SendData.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.TabControl_SendData.Location = New System.Drawing.Point(1059, 105)
    Me.TabControl_SendData.Name = "TabControl_SendData"
    Me.TabControl_SendData.SelectedIndex = 0
    Me.TabControl_SendData.Size = New System.Drawing.Size(859, 972)
    Me.TabControl_SendData.TabIndex = 119
    '
    'TabPage_Service
    '
    Me.TabPage_Service.Controls.Add(Me.PanelService_Back)
    Me.TabPage_Service.Location = New System.Drawing.Point(4, 30)
    Me.TabPage_Service.Name = "TabPage_Service"
    Me.TabPage_Service.Size = New System.Drawing.Size(851, 938)
    Me.TabPage_Service.TabIndex = 3
    Me.TabPage_Service.Text = "Service"
    Me.TabPage_Service.UseVisualStyleBackColor = True
    '
    'PanelService_Back
    '
    Me.PanelService_Back.BackColor = System.Drawing.SystemColors.Control
    Me.PanelService_Back.Controls.Add(Me.PanelService)
    Me.PanelService_Back.Location = New System.Drawing.Point(0, 0)
    Me.PanelService_Back.Name = "PanelService_Back"
    Me.PanelService_Back.Size = New System.Drawing.Size(851, 938)
    Me.PanelService_Back.TabIndex = 0
    '
    'PanelService
    '
    Me.PanelService.BackColor = System.Drawing.Color.Black
    Me.PanelService.Controls.Add(Me.GroupBox18)
    Me.PanelService.Location = New System.Drawing.Point(0, 0)
    Me.PanelService.Name = "PanelService"
    Me.PanelService.Size = New System.Drawing.Size(851, 938)
    Me.PanelService.TabIndex = 1
    '
    'GroupBox18
    '
    Me.GroupBox18.Controls.Add(Me.Label144)
    Me.GroupBox18.Controls.Add(Me.TextServer_Receive_CCD1)
    Me.GroupBox18.Controls.Add(Me.TextServer_Receive_CCD2)
    Me.GroupBox18.Controls.Add(Me.TextServer_Receive_CCD3)
    Me.GroupBox18.Controls.Add(Me.TextServer_Receive_CCD4)
    Me.GroupBox18.Controls.Add(Me.Label136)
    Me.GroupBox18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
    Me.GroupBox18.ForeColor = System.Drawing.Color.White
    Me.GroupBox18.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox18.Name = "GroupBox18"
    Me.GroupBox18.Size = New System.Drawing.Size(513, 65)
    Me.GroupBox18.TabIndex = 147
    Me.GroupBox18.TabStop = False
    Me.GroupBox18.Text = "檢測二"
    '
    'Label144
    '
    Me.Label144.AutoSize = True
    Me.Label144.BackColor = System.Drawing.Color.Black
    Me.Label144.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label144.ForeColor = System.Drawing.Color.White
    Me.Label144.Location = New System.Drawing.Point(95, 15)
    Me.Label144.Name = "Label144"
    Me.Label144.Size = New System.Drawing.Size(384, 18)
    Me.Label144.TabIndex = 179
    Me.Label144.Text = "CCD1                 CCD2                  CCD3                  CCD4"
    '
    'TextServer_Receive_CCD1
    '
    Me.TextServer_Receive_CCD1.BackColor = System.Drawing.Color.LightGoldenrodYellow
    Me.TextServer_Receive_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextServer_Receive_CCD1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextServer_Receive_CCD1.ForeColor = System.Drawing.Color.MediumBlue
    Me.TextServer_Receive_CCD1.Location = New System.Drawing.Point(64, 34)
    Me.TextServer_Receive_CCD1.MaxLength = 100
    Me.TextServer_Receive_CCD1.Name = "TextServer_Receive_CCD1"
    Me.TextServer_Receive_CCD1.ReadOnly = True
    Me.TextServer_Receive_CCD1.Size = New System.Drawing.Size(110, 25)
    Me.TextServer_Receive_CCD1.TabIndex = 173
    Me.TextServer_Receive_CCD1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'TextServer_Receive_CCD2
    '
    Me.TextServer_Receive_CCD2.BackColor = System.Drawing.Color.LightGoldenrodYellow
    Me.TextServer_Receive_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextServer_Receive_CCD2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextServer_Receive_CCD2.ForeColor = System.Drawing.Color.MediumBlue
    Me.TextServer_Receive_CCD2.Location = New System.Drawing.Point(175, 34)
    Me.TextServer_Receive_CCD2.MaxLength = 100
    Me.TextServer_Receive_CCD2.Name = "TextServer_Receive_CCD2"
    Me.TextServer_Receive_CCD2.ReadOnly = True
    Me.TextServer_Receive_CCD2.Size = New System.Drawing.Size(110, 25)
    Me.TextServer_Receive_CCD2.TabIndex = 174
    Me.TextServer_Receive_CCD2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'TextServer_Receive_CCD3
    '
    Me.TextServer_Receive_CCD3.BackColor = System.Drawing.Color.LightGoldenrodYellow
    Me.TextServer_Receive_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextServer_Receive_CCD3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextServer_Receive_CCD3.ForeColor = System.Drawing.Color.MediumBlue
    Me.TextServer_Receive_CCD3.Location = New System.Drawing.Point(286, 34)
    Me.TextServer_Receive_CCD3.MaxLength = 100
    Me.TextServer_Receive_CCD3.Name = "TextServer_Receive_CCD3"
    Me.TextServer_Receive_CCD3.ReadOnly = True
    Me.TextServer_Receive_CCD3.Size = New System.Drawing.Size(110, 25)
    Me.TextServer_Receive_CCD3.TabIndex = 175
    Me.TextServer_Receive_CCD3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'TextServer_Receive_CCD4
    '
    Me.TextServer_Receive_CCD4.BackColor = System.Drawing.Color.LightGoldenrodYellow
    Me.TextServer_Receive_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextServer_Receive_CCD4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextServer_Receive_CCD4.ForeColor = System.Drawing.Color.MediumBlue
    Me.TextServer_Receive_CCD4.Location = New System.Drawing.Point(397, 34)
    Me.TextServer_Receive_CCD4.MaxLength = 100
    Me.TextServer_Receive_CCD4.Name = "TextServer_Receive_CCD4"
    Me.TextServer_Receive_CCD4.ReadOnly = True
    Me.TextServer_Receive_CCD4.Size = New System.Drawing.Size(110, 25)
    Me.TextServer_Receive_CCD4.TabIndex = 176
    Me.TextServer_Receive_CCD4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label136
    '
    Me.Label136.AutoSize = True
    Me.Label136.BackColor = System.Drawing.Color.Black
    Me.Label136.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label136.ForeColor = System.Drawing.Color.White
    Me.Label136.Location = New System.Drawing.Point(3, 41)
    Me.Label136.Name = "Label136"
    Me.Label136.Size = New System.Drawing.Size(63, 13)
    Me.Label136.TabIndex = 180
    Me.Label136.Text = "回傳訊息"
    '
    'InstantCtrl_DO
    '
    Me.InstantCtrl_DO._StateStream = CType(resources.GetObject("InstantCtrl_DO._StateStream"), Automation.BDaq.DeviceStateStreamer)
    '
    'TimerRunState
    '
    Me.TimerRunState.Enabled = True
    Me.TimerRunState.Interval = 20
    '
    'TimerBarcode
    '
    Me.TimerBarcode.Interval = 20
    '
    'SerialPort_Barcode
    '
    Me.SerialPort_Barcode.PortName = "COM2"
    '
    'Panel_CCD1
    '
    Me.Panel_CCD1.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_CCD1.Controls.Add(Me.BtnRun_ImageSource_CCD1)
    Me.Panel_CCD1.Controls.Add(Me.BtnRun_ImageLoad_CCD1)
    Me.Panel_CCD1.Controls.Add(Me.CheckRun_Live_CCD1)
    Me.Panel_CCD1.Controls.Add(Me.BtnRun_ZoomToFit_CCD1)
    Me.Panel_CCD1.Controls.Add(Me.BtnRun_ImageSave_CCD1)
    Me.Panel_CCD1.Controls.Add(Me.LabSearch1_Result_CCD1)
    Me.Panel_CCD1.Controls.Add(Me.ImageViewer_CCD1)
    Me.Panel_CCD1.Location = New System.Drawing.Point(0, 0)
    Me.Panel_CCD1.Name = "Panel_CCD1"
    Me.Panel_CCD1.Size = New System.Drawing.Size(522, 469)
    Me.Panel_CCD1.TabIndex = 142
    '
    'BtnRun_ImageSource_CCD1
    '
    Me.BtnRun_ImageSource_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageSource_CCD1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageSource_CCD1.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageSource_CCD1.Location = New System.Drawing.Point(335, 436)
    Me.BtnRun_ImageSource_CCD1.Name = "BtnRun_ImageSource_CCD1"
    Me.BtnRun_ImageSource_CCD1.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageSource_CCD1.TabIndex = 136
    Me.BtnRun_ImageSource_CCD1.TabStop = False
    Me.BtnRun_ImageSource_CCD1.Tag = "1"
    Me.BtnRun_ImageSource_CCD1.Text = "原圖"
    Me.BtnRun_ImageSource_CCD1.UseVisualStyleBackColor = False
    '
    'Panel_CCD2
    '
    Me.Panel_CCD2.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_CCD2.Controls.Add(Me.BtnRun_ImageSource_CCD2)
    Me.Panel_CCD2.Controls.Add(Me.BtnRun_ImageLoad_CCD2)
    Me.Panel_CCD2.Controls.Add(Me.BtnRun_ZoomToFit_CCD2)
    Me.Panel_CCD2.Controls.Add(Me.CheckRun_Live_CCD2)
    Me.Panel_CCD2.Controls.Add(Me.BtnRun_ImageSave_CCD2)
    Me.Panel_CCD2.Controls.Add(Me.LabSearch1_Result_CCD2)
    Me.Panel_CCD2.Controls.Add(Me.ImageViewer_CCD2)
    Me.Panel_CCD2.Location = New System.Drawing.Point(526, 0)
    Me.Panel_CCD2.Name = "Panel_CCD2"
    Me.Panel_CCD2.Size = New System.Drawing.Size(522, 469)
    Me.Panel_CCD2.TabIndex = 143
    '
    'BtnRun_ImageSource_CCD2
    '
    Me.BtnRun_ImageSource_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageSource_CCD2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageSource_CCD2.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageSource_CCD2.Location = New System.Drawing.Point(335, 436)
    Me.BtnRun_ImageSource_CCD2.Name = "BtnRun_ImageSource_CCD2"
    Me.BtnRun_ImageSource_CCD2.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageSource_CCD2.TabIndex = 137
    Me.BtnRun_ImageSource_CCD2.TabStop = False
    Me.BtnRun_ImageSource_CCD2.Tag = "2"
    Me.BtnRun_ImageSource_CCD2.Text = "原圖"
    Me.BtnRun_ImageSource_CCD2.UseVisualStyleBackColor = False
    '
    'Panel_CCD4
    '
    Me.Panel_CCD4.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_CCD4.Controls.Add(Me.BtnRun_ImageSource_CCD4)
    Me.Panel_CCD4.Controls.Add(Me.BtnRun_ZoomToFit_CCD4)
    Me.Panel_CCD4.Controls.Add(Me.CheckRun_Live_CCD4)
    Me.Panel_CCD4.Controls.Add(Me.BtnRun_ImageSave_CCD4)
    Me.Panel_CCD4.Controls.Add(Me.BtnRun_ImageLoad_CCD4)
    Me.Panel_CCD4.Controls.Add(Me.LabSearch1_Result_CCD4)
    Me.Panel_CCD4.Controls.Add(Me.ImageViewer_CCD4)
    Me.Panel_CCD4.Location = New System.Drawing.Point(0, 471)
    Me.Panel_CCD4.Name = "Panel_CCD4"
    Me.Panel_CCD4.Size = New System.Drawing.Size(522, 469)
    Me.Panel_CCD4.TabIndex = 144
    '
    'BtnRun_ImageSource_CCD4
    '
    Me.BtnRun_ImageSource_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageSource_CCD4.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageSource_CCD4.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageSource_CCD4.Location = New System.Drawing.Point(335, 436)
    Me.BtnRun_ImageSource_CCD4.Name = "BtnRun_ImageSource_CCD4"
    Me.BtnRun_ImageSource_CCD4.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageSource_CCD4.TabIndex = 139
    Me.BtnRun_ImageSource_CCD4.TabStop = False
    Me.BtnRun_ImageSource_CCD4.Tag = "4"
    Me.BtnRun_ImageSource_CCD4.Text = "原圖"
    Me.BtnRun_ImageSource_CCD4.UseVisualStyleBackColor = False
    '
    'Panel_CCD3
    '
    Me.Panel_CCD3.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_CCD3.Controls.Add(Me.BtnRun_ImageSource_CCD3)
    Me.Panel_CCD3.Controls.Add(Me.CheckRun_Live_CCD3)
    Me.Panel_CCD3.Controls.Add(Me.BtnRun_ZoomToFit_CCD3)
    Me.Panel_CCD3.Controls.Add(Me.BtnRun_ImageSave_CCD3)
    Me.Panel_CCD3.Controls.Add(Me.BtnRun_ImageLoad_CCD3)
    Me.Panel_CCD3.Controls.Add(Me.LabSearch1_Result_CCD3)
    Me.Panel_CCD3.Controls.Add(Me.ImageViewer_CCD3)
    Me.Panel_CCD3.Location = New System.Drawing.Point(526, 471)
    Me.Panel_CCD3.Name = "Panel_CCD3"
    Me.Panel_CCD3.Size = New System.Drawing.Size(522, 469)
    Me.Panel_CCD3.TabIndex = 145
    '
    'BtnRun_ImageSource_CCD3
    '
    Me.BtnRun_ImageSource_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnRun_ImageSource_CCD3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnRun_ImageSource_CCD3.ForeColor = System.Drawing.Color.Navy
    Me.BtnRun_ImageSource_CCD3.Location = New System.Drawing.Point(335, 436)
    Me.BtnRun_ImageSource_CCD3.Name = "BtnRun_ImageSource_CCD3"
    Me.BtnRun_ImageSource_CCD3.Size = New System.Drawing.Size(39, 24)
    Me.BtnRun_ImageSource_CCD3.TabIndex = 138
    Me.BtnRun_ImageSource_CCD3.TabStop = False
    Me.BtnRun_ImageSource_CCD3.Tag = "3"
    Me.BtnRun_ImageSource_CCD3.Text = "原圖"
    Me.BtnRun_ImageSource_CCD3.UseVisualStyleBackColor = False
    '
    'TabControl_CCD
    '
    Me.TabControl_CCD.Controls.Add(Me.TabPage_Search1)
    Me.TabControl_CCD.Controls.Add(Me.TabPage_Search2)
    Me.TabControl_CCD.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.TabControl_CCD.ItemSize = New System.Drawing.Size(66, 22)
    Me.TabControl_CCD.Location = New System.Drawing.Point(1, 105)
    Me.TabControl_CCD.Name = "TabControl_CCD"
    Me.TabControl_CCD.SelectedIndex = 0
    Me.TabControl_CCD.Size = New System.Drawing.Size(1056, 972)
    Me.TabControl_CCD.TabIndex = 146
    '
    'TabPage_Search1
    '
    Me.TabPage_Search1.Controls.Add(Me.Panel_CCD2)
    Me.TabPage_Search1.Controls.Add(Me.Panel_CCD1)
    Me.TabPage_Search1.Controls.Add(Me.Panel_CCD4)
    Me.TabPage_Search1.Controls.Add(Me.Panel_CCD3)
    Me.TabPage_Search1.Location = New System.Drawing.Point(4, 26)
    Me.TabPage_Search1.Name = "TabPage_Search1"
    Me.TabPage_Search1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage_Search1.Size = New System.Drawing.Size(1048, 942)
    Me.TabPage_Search1.TabIndex = 0
    Me.TabPage_Search1.Text = "檢測一"
    Me.TabPage_Search1.UseVisualStyleBackColor = True
    '
    'TabPage_Search2
    '
    Me.TabPage_Search2.Controls.Add(Me.Panel_Search2_CCD2)
    Me.TabPage_Search2.Controls.Add(Me.Panel_Search2_CCD4)
    Me.TabPage_Search2.Controls.Add(Me.Panel_Search2_CCD3)
    Me.TabPage_Search2.Controls.Add(Me.Panel_Search2_CCD1)
    Me.TabPage_Search2.Controls.Add(Me.Panel_Search2)
    Me.TabPage_Search2.Location = New System.Drawing.Point(4, 26)
    Me.TabPage_Search2.Name = "TabPage_Search2"
    Me.TabPage_Search2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage_Search2.Size = New System.Drawing.Size(1048, 942)
    Me.TabPage_Search2.TabIndex = 1
    Me.TabPage_Search2.Text = "檢測二"
    Me.TabPage_Search2.UseVisualStyleBackColor = True
    '
    'Panel_Search2_CCD2
    '
    Me.Panel_Search2_CCD2.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_Search2_CCD2.Controls.Add(Me.Label133)
    Me.Panel_Search2_CCD2.Location = New System.Drawing.Point(526, 0)
    Me.Panel_Search2_CCD2.Name = "Panel_Search2_CCD2"
    Me.Panel_Search2_CCD2.Size = New System.Drawing.Size(522, 325)
    Me.Panel_Search2_CCD2.TabIndex = 146
    '
    'Label133
    '
    Me.Label133.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label133.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label133.Location = New System.Drawing.Point(1, 437)
    Me.Label133.Name = "Label133"
    Me.Label133.Size = New System.Drawing.Size(334, 22)
    Me.Label133.TabIndex = 136
    Me.Label133.Text = "CCD2 (右)"
    Me.Label133.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Panel_Search2_CCD4
    '
    Me.Panel_Search2_CCD4.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_Search2_CCD4.Controls.Add(Me.Label134)
    Me.Panel_Search2_CCD4.Location = New System.Drawing.Point(0, 471)
    Me.Panel_Search2_CCD4.Name = "Panel_Search2_CCD4"
    Me.Panel_Search2_CCD4.Size = New System.Drawing.Size(522, 325)
    Me.Panel_Search2_CCD4.TabIndex = 147
    '
    'Label134
    '
    Me.Label134.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label134.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label134.Location = New System.Drawing.Point(1, 437)
    Me.Label134.Name = "Label134"
    Me.Label134.Size = New System.Drawing.Size(334, 22)
    Me.Label134.TabIndex = 138
    Me.Label134.Text = "CCD4 (左)"
    Me.Label134.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Panel_Search2_CCD3
    '
    Me.Panel_Search2_CCD3.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_Search2_CCD3.Controls.Add(Me.Label135)
    Me.Panel_Search2_CCD3.Location = New System.Drawing.Point(526, 471)
    Me.Panel_Search2_CCD3.Name = "Panel_Search2_CCD3"
    Me.Panel_Search2_CCD3.Size = New System.Drawing.Size(522, 325)
    Me.Panel_Search2_CCD3.TabIndex = 148
    '
    'Label135
    '
    Me.Label135.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label135.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label135.Location = New System.Drawing.Point(1, 437)
    Me.Label135.Name = "Label135"
    Me.Label135.Size = New System.Drawing.Size(334, 22)
    Me.Label135.TabIndex = 137
    Me.Label135.Text = "CCD3 (前)"
    Me.Label135.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Panel_Search2_CCD1
    '
    Me.Panel_Search2_CCD1.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_Search2_CCD1.Controls.Add(Me.Label132)
    Me.Panel_Search2_CCD1.Location = New System.Drawing.Point(0, 0)
    Me.Panel_Search2_CCD1.Name = "Panel_Search2_CCD1"
    Me.Panel_Search2_CCD1.Size = New System.Drawing.Size(522, 325)
    Me.Panel_Search2_CCD1.TabIndex = 143
    '
    'Label132
    '
    Me.Label132.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label132.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label132.Location = New System.Drawing.Point(1, 437)
    Me.Label132.Name = "Label132"
    Me.Label132.Size = New System.Drawing.Size(334, 22)
    Me.Label132.TabIndex = 135
    Me.Label132.Text = "CCD1 (後)"
    Me.Label132.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'Panel_Search2
    '
    Me.Panel_Search2.BackColor = System.Drawing.SystemColors.Control
    Me.Panel_Search2.Controls.Add(Me.LabSearch2_Result_CCD4)
    Me.Panel_Search2.Controls.Add(Me.LabSearch2_Result_CCD3)
    Me.Panel_Search2.Controls.Add(Me.LabSearch2_Result_CCD2)
    Me.Panel_Search2.Controls.Add(Me.BtnSearch2_Measure_CCD2)
    Me.Panel_Search2.Controls.Add(Me.BtnSearch2_ImageLoad_CCD1)
    Me.Panel_Search2.Controls.Add(Me.BtnSearch2_ImageLoad_CCD2)
    Me.Panel_Search2.Controls.Add(Me.BtnSearch2_ImageLoad_CCD4)
    Me.Panel_Search2.Controls.Add(Me.BtnSearch2_Measure_CCD1)
    Me.Panel_Search2.Controls.Add(Me.BtnSearch2_Measure_CCD3)
    Me.Panel_Search2.Controls.Add(Me.BtnSearch2_ImageLoad_CCD3)
    Me.Panel_Search2.Controls.Add(Me.BtnSearch2_Measure_CCD4)
    Me.Panel_Search2.Controls.Add(Me.LabSearch2_Result_CCD1)
    Me.Panel_Search2.Location = New System.Drawing.Point(0, 0)
    Me.Panel_Search2.Name = "Panel_Search2"
    Me.Panel_Search2.Size = New System.Drawing.Size(1048, 942)
    Me.Panel_Search2.TabIndex = 149
    '
    'LabSearch2_Result_CCD4
    '
    Me.LabSearch2_Result_CCD4.BackColor = System.Drawing.Color.White
    Me.LabSearch2_Result_CCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSearch2_Result_CCD4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSearch2_Result_CCD4.Location = New System.Drawing.Point(0, 798)
    Me.LabSearch2_Result_CCD4.Name = "LabSearch2_Result_CCD4"
    Me.LabSearch2_Result_CCD4.Size = New System.Drawing.Size(358, 35)
    Me.LabSearch2_Result_CCD4.TabIndex = 146
    Me.LabSearch2_Result_CCD4.Text = "CCD4 (左)"
    Me.LabSearch2_Result_CCD4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabSearch2_Result_CCD3
    '
    Me.LabSearch2_Result_CCD3.BackColor = System.Drawing.Color.White
    Me.LabSearch2_Result_CCD3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSearch2_Result_CCD3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSearch2_Result_CCD3.Location = New System.Drawing.Point(527, 798)
    Me.LabSearch2_Result_CCD3.Name = "LabSearch2_Result_CCD3"
    Me.LabSearch2_Result_CCD3.Size = New System.Drawing.Size(358, 35)
    Me.LabSearch2_Result_CCD3.TabIndex = 145
    Me.LabSearch2_Result_CCD3.Text = "CCD3 (前)"
    Me.LabSearch2_Result_CCD3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'LabSearch2_Result_CCD2
    '
    Me.LabSearch2_Result_CCD2.BackColor = System.Drawing.Color.White
    Me.LabSearch2_Result_CCD2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSearch2_Result_CCD2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSearch2_Result_CCD2.Location = New System.Drawing.Point(526, 327)
    Me.LabSearch2_Result_CCD2.Name = "LabSearch2_Result_CCD2"
    Me.LabSearch2_Result_CCD2.Size = New System.Drawing.Size(358, 35)
    Me.LabSearch2_Result_CCD2.TabIndex = 144
    Me.LabSearch2_Result_CCD2.Text = "CCD2 (右)"
    Me.LabSearch2_Result_CCD2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnSearch2_Measure_CCD2
    '
    Me.BtnSearch2_Measure_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_Measure_CCD2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnSearch2_Measure_CCD2.ForeColor = System.Drawing.Color.Navy
    Me.BtnSearch2_Measure_CCD2.Location = New System.Drawing.Point(968, 326)
    Me.BtnSearch2_Measure_CCD2.Name = "BtnSearch2_Measure_CCD2"
    Me.BtnSearch2_Measure_CCD2.Size = New System.Drawing.Size(80, 37)
    Me.BtnSearch2_Measure_CCD2.TabIndex = 142
    Me.BtnSearch2_Measure_CCD2.TabStop = False
    Me.BtnSearch2_Measure_CCD2.Tag = "2"
    Me.BtnSearch2_Measure_CCD2.Text = "量測"
    Me.BtnSearch2_Measure_CCD2.UseVisualStyleBackColor = False
    '
    'BtnSearch2_ImageLoad_CCD1
    '
    Me.BtnSearch2_ImageLoad_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_ImageLoad_CCD1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnSearch2_ImageLoad_CCD1.ForeColor = System.Drawing.Color.Navy
    Me.BtnSearch2_ImageLoad_CCD1.Location = New System.Drawing.Point(362, 326)
    Me.BtnSearch2_ImageLoad_CCD1.Name = "BtnSearch2_ImageLoad_CCD1"
    Me.BtnSearch2_ImageLoad_CCD1.Size = New System.Drawing.Size(80, 37)
    Me.BtnSearch2_ImageLoad_CCD1.TabIndex = 139
    Me.BtnSearch2_ImageLoad_CCD1.TabStop = False
    Me.BtnSearch2_ImageLoad_CCD1.Tag = "1"
    Me.BtnSearch2_ImageLoad_CCD1.Text = "載圖"
    Me.BtnSearch2_ImageLoad_CCD1.UseVisualStyleBackColor = False
    '
    'BtnSearch2_ImageLoad_CCD2
    '
    Me.BtnSearch2_ImageLoad_CCD2.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_ImageLoad_CCD2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnSearch2_ImageLoad_CCD2.ForeColor = System.Drawing.Color.Navy
    Me.BtnSearch2_ImageLoad_CCD2.Location = New System.Drawing.Point(887, 326)
    Me.BtnSearch2_ImageLoad_CCD2.Name = "BtnSearch2_ImageLoad_CCD2"
    Me.BtnSearch2_ImageLoad_CCD2.Size = New System.Drawing.Size(80, 37)
    Me.BtnSearch2_ImageLoad_CCD2.TabIndex = 136
    Me.BtnSearch2_ImageLoad_CCD2.TabStop = False
    Me.BtnSearch2_ImageLoad_CCD2.Tag = "2"
    Me.BtnSearch2_ImageLoad_CCD2.Text = "載圖"
    Me.BtnSearch2_ImageLoad_CCD2.UseVisualStyleBackColor = False
    '
    'BtnSearch2_ImageLoad_CCD4
    '
    Me.BtnSearch2_ImageLoad_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_ImageLoad_CCD4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnSearch2_ImageLoad_CCD4.ForeColor = System.Drawing.Color.Navy
    Me.BtnSearch2_ImageLoad_CCD4.Location = New System.Drawing.Point(362, 797)
    Me.BtnSearch2_ImageLoad_CCD4.Name = "BtnSearch2_ImageLoad_CCD4"
    Me.BtnSearch2_ImageLoad_CCD4.Size = New System.Drawing.Size(80, 37)
    Me.BtnSearch2_ImageLoad_CCD4.TabIndex = 138
    Me.BtnSearch2_ImageLoad_CCD4.TabStop = False
    Me.BtnSearch2_ImageLoad_CCD4.Tag = "4"
    Me.BtnSearch2_ImageLoad_CCD4.Text = "載圖"
    Me.BtnSearch2_ImageLoad_CCD4.UseVisualStyleBackColor = False
    '
    'BtnSearch2_Measure_CCD1
    '
    Me.BtnSearch2_Measure_CCD1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_Measure_CCD1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnSearch2_Measure_CCD1.ForeColor = System.Drawing.Color.Navy
    Me.BtnSearch2_Measure_CCD1.Location = New System.Drawing.Point(443, 326)
    Me.BtnSearch2_Measure_CCD1.Name = "BtnSearch2_Measure_CCD1"
    Me.BtnSearch2_Measure_CCD1.Size = New System.Drawing.Size(80, 37)
    Me.BtnSearch2_Measure_CCD1.TabIndex = 143
    Me.BtnSearch2_Measure_CCD1.TabStop = False
    Me.BtnSearch2_Measure_CCD1.Tag = "1"
    Me.BtnSearch2_Measure_CCD1.Text = "量測"
    Me.BtnSearch2_Measure_CCD1.UseVisualStyleBackColor = False
    '
    'BtnSearch2_Measure_CCD3
    '
    Me.BtnSearch2_Measure_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_Measure_CCD3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnSearch2_Measure_CCD3.ForeColor = System.Drawing.Color.Navy
    Me.BtnSearch2_Measure_CCD3.Location = New System.Drawing.Point(968, 797)
    Me.BtnSearch2_Measure_CCD3.Name = "BtnSearch2_Measure_CCD3"
    Me.BtnSearch2_Measure_CCD3.Size = New System.Drawing.Size(80, 37)
    Me.BtnSearch2_Measure_CCD3.TabIndex = 141
    Me.BtnSearch2_Measure_CCD3.TabStop = False
    Me.BtnSearch2_Measure_CCD3.Tag = "3"
    Me.BtnSearch2_Measure_CCD3.Text = "量測"
    Me.BtnSearch2_Measure_CCD3.UseVisualStyleBackColor = False
    '
    'BtnSearch2_ImageLoad_CCD3
    '
    Me.BtnSearch2_ImageLoad_CCD3.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_ImageLoad_CCD3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnSearch2_ImageLoad_CCD3.ForeColor = System.Drawing.Color.Navy
    Me.BtnSearch2_ImageLoad_CCD3.Location = New System.Drawing.Point(887, 797)
    Me.BtnSearch2_ImageLoad_CCD3.Name = "BtnSearch2_ImageLoad_CCD3"
    Me.BtnSearch2_ImageLoad_CCD3.Size = New System.Drawing.Size(80, 37)
    Me.BtnSearch2_ImageLoad_CCD3.TabIndex = 137
    Me.BtnSearch2_ImageLoad_CCD3.TabStop = False
    Me.BtnSearch2_ImageLoad_CCD3.Tag = "3"
    Me.BtnSearch2_ImageLoad_CCD3.Text = "載圖"
    Me.BtnSearch2_ImageLoad_CCD3.UseVisualStyleBackColor = False
    '
    'BtnSearch2_Measure_CCD4
    '
    Me.BtnSearch2_Measure_CCD4.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnSearch2_Measure_CCD4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnSearch2_Measure_CCD4.ForeColor = System.Drawing.Color.Navy
    Me.BtnSearch2_Measure_CCD4.Location = New System.Drawing.Point(443, 797)
    Me.BtnSearch2_Measure_CCD4.Name = "BtnSearch2_Measure_CCD4"
    Me.BtnSearch2_Measure_CCD4.Size = New System.Drawing.Size(80, 37)
    Me.BtnSearch2_Measure_CCD4.TabIndex = 140
    Me.BtnSearch2_Measure_CCD4.TabStop = False
    Me.BtnSearch2_Measure_CCD4.Tag = "4"
    Me.BtnSearch2_Measure_CCD4.Text = "量測"
    Me.BtnSearch2_Measure_CCD4.UseVisualStyleBackColor = False
    '
    'LabSearch2_Result_CCD1
    '
    Me.LabSearch2_Result_CCD1.BackColor = System.Drawing.Color.White
    Me.LabSearch2_Result_CCD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabSearch2_Result_CCD1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabSearch2_Result_CCD1.Location = New System.Drawing.Point(1, 327)
    Me.LabSearch2_Result_CCD1.Name = "LabSearch2_Result_CCD1"
    Me.LabSearch2_Result_CCD1.Size = New System.Drawing.Size(358, 35)
    Me.LabSearch2_Result_CCD1.TabIndex = 135
    Me.LabSearch2_Result_CCD1.Text = "CCD1 (後)"
    Me.LabSearch2_Result_CCD1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'CheckBox1
    '
    Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
    Me.CheckBox1.BackColor = System.Drawing.Color.White
    Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CheckBox1.ForeColor = System.Drawing.Color.MidnightBlue
    Me.CheckBox1.Location = New System.Drawing.Point(475, 436)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(45, 24)
    Me.CheckBox1.TabIndex = 99
    Me.CheckBox1.TabStop = False
    Me.CheckBox1.Tag = "1"
    Me.CheckBox1.Text = "Live"
    Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    Me.CheckBox1.UseVisualStyleBackColor = False
    '
    'Label131
    '
    Me.Label131.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label131.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label131.Location = New System.Drawing.Point(1, 437)
    Me.Label131.Name = "Label131"
    Me.Label131.Size = New System.Drawing.Size(334, 22)
    Me.Label131.TabIndex = 135
    Me.Label131.Text = "CCD1 (後)"
    Me.Label131.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'ImageViewer1
    '
    Me.ImageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Selection
    Me.ImageViewer1.BackColor = System.Drawing.SystemColors.ControlText
    Me.ImageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ImageViewer1.ImageInfoTextColor = New NationalInstruments.Vision.Rgb32Value(CType(0, Byte), CType(255, Byte), CType(0, Byte), CType(0, Byte))
    Me.ImageViewer1.Location = New System.Drawing.Point(1, 1)
    Me.ImageViewer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.ImageViewer1.Name = "ImageViewer1"
    Me.ImageViewer1.ShowImageInfo = True
    Me.ImageViewer1.ShowToolbar = True
    Me.ImageViewer1.Size = New System.Drawing.Size(520, 435)
    Me.ImageViewer1.TabIndex = 92
    Me.ImageViewer1.TabStop = False
    '
    'OpenFileDialog_SendData
    '
    Me.OpenFileDialog_SendData.Title = "載入圖像"
    '
    'BtnOpInf_Clear
    '
    Me.BtnOpInf_Clear.BackColor = System.Drawing.Color.White
    Me.BtnOpInf_Clear.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold)
    Me.BtnOpInf_Clear.Location = New System.Drawing.Point(159, 445)
    Me.BtnOpInf_Clear.Name = "BtnOpInf_Clear"
    Me.BtnOpInf_Clear.Size = New System.Drawing.Size(116, 42)
    Me.BtnOpInf_Clear.TabIndex = 143
    Me.BtnOpInf_Clear.Tag = ""
    Me.BtnOpInf_Clear.Text = "清除"
    Me.BtnOpInf_Clear.UseVisualStyleBackColor = False
    '
    'A_FormMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ControlDark
    Me.ClientSize = New System.Drawing.Size(1920, 1078)
    Me.ControlBox = False
    Me.Controls.Add(Me.TabControl_SendData)
    Me.Controls.Add(Me.LabProgramInfo)
    Me.Controls.Add(Me.GroupTools)
    Me.Controls.Add(Me.TabControl_CCD)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Name = "A_FormMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = resources.GetString("$this.Text")
    Me.GroupTools.ResumeLayout(False)
    CType(Me.AxActUtlType_PLC, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupOption.ResumeLayout(False)
    Me.GroupOption.PerformLayout()
    Me.TabPage_IO.ResumeLayout(False)
    Me.Panel_IO.ResumeLayout(False)
    Me.Panel_IO.PerformLayout()
    Me.GroupIO_PLC.ResumeLayout(False)
    Me.GroupIO_PLC.PerformLayout()
    Me.TabControlPLC.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage2.PerformLayout()
    Me.GroupBox16.ResumeLayout(False)
    Me.GroupBox16.PerformLayout()
    Me.GroupBox15.ResumeLayout(False)
    Me.GroupBox15.PerformLayout()
    Me.GroupBox14.ResumeLayout(False)
    Me.GroupBox14.PerformLayout()
    Me.GroupBox13.ResumeLayout(False)
    Me.GroupBox13.PerformLayout()
    Me.GroupVacuum.ResumeLayout(False)
    Me.GroupVacuum.PerformLayout()
    Me.GroupBox11.ResumeLayout(False)
    Me.GroupBox11.PerformLayout()
    Me.GroupBox10.ResumeLayout(False)
    Me.GroupBox10.PerformLayout()
    Me.GroupBox9.ResumeLayout(False)
    Me.GroupBox9.PerformLayout()
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.GroupBox12.ResumeLayout(False)
    Me.GroupBox12.PerformLayout()
    Me.GroupIO_AOI.ResumeLayout(False)
    Me.GroupIO_Input.ResumeLayout(False)
    Me.GroupIO_Input.PerformLayout()
    Me.GroupIO_Output.ResumeLayout(False)
    Me.TabPage_Parameter.ResumeLayout(False)
    Me.PanelParameter.ResumeLayout(False)
    Me.GroupAdv.ResumeLayout(False)
    Me.GroupAdv_Option.ResumeLayout(False)
    Me.GroupAdv_Option.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupAdv_Calib_ImageAdjust.ResumeLayout(False)
    Me.GroupAdv_Calib_ImageAdjust.PerformLayout()
    CType(Me.TrackBarAdv_Calib_BinaryMax, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.UpDownAdv_Calib_Remove, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TrackBarAdv_Calib_BinaryMin, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupAdv_Calib_Distance.ResumeLayout(False)
    Me.GroupAdv_Calib_Distance.PerformLayout()
    Me.GroupAdv_Calib_Pixel.ResumeLayout(False)
    Me.GroupAdv_Calib_Pixel.PerformLayout()
    Me.GroupAdv_Calib_Light.ResumeLayout(False)
    Me.GroupAdv_Calib_Light.PerformLayout()
    Me.GroupProduct.ResumeLayout(False)
    Me.GroupProduct.PerformLayout()
    Me.PanelProduct_Function1.ResumeLayout(False)
    Me.GroupTeach_ImageAdjust_Inside.ResumeLayout(False)
    Me.GroupTeach_ImageAdjust_Inside.PerformLayout()
    CType(Me.UpDownSearch2_Score, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupTeach_ImageAdjust_Outside.ResumeLayout(False)
    Me.GroupTeach_ImageAdjust_Outside.PerformLayout()
    CType(Me.TrackBarTeach_BinaryDefectOut, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TrackBarTeach_BinaryOutside, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupTeach_ImageAdjust_Size.ResumeLayout(False)
    Me.GroupTeach_ImageAdjust_Size.PerformLayout()
    CType(Me.TrackBarTeach_BinaryMax, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TrackBarTeach_BinaryMin, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupTeacht_Spec.ResumeLayout(False)
    Me.GroupTeacht_Spec.PerformLayout()
    Me.GroupProduct_Light.ResumeLayout(False)
    Me.GroupProduct_Light.PerformLayout()
    Me.TabPage_Run.ResumeLayout(False)
    Me.PanelRun.ResumeLayout(False)
    Me.GroupRun_SendData.ResumeLayout(False)
    Me.GroupRun_SendData.PerformLayout()
    CType(Me.DataGrid_SendData, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupRun_CycleTime.ResumeLayout(False)
    Me.GroupRun_CycleTime.PerformLayout()
    Me.PanelTimeInf.ResumeLayout(False)
    Me.PanelTimeInf.PerformLayout()
    Me.GroupBox17.ResumeLayout(False)
    Me.GroupBox17.PerformLayout()
    Me.GroupRun_BarcodeInLine.ResumeLayout(False)
    Me.GroupRun_BarcodeInLine.PerformLayout()
    Me.GroupRun_Result.ResumeLayout(False)
    Me.GroupRun_Result.PerformLayout()
    Me.GroupRun_DefectLength_Outside.ResumeLayout(False)
    CType(Me.DataGrid_DefectLength_Outside, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupRun_DefectCount_Inside.ResumeLayout(False)
    Me.GroupRun_DefectCount_Inside.PerformLayout()
    Me.GroupRun_OkNg.ResumeLayout(False)
    Me.GroupRun_Msg.ResumeLayout(False)
    Me.GroupRun_Msg.PerformLayout()
    Me.TabControl_SendData.ResumeLayout(False)
    Me.TabPage_Service.ResumeLayout(False)
    Me.PanelService_Back.ResumeLayout(False)
    Me.PanelService.ResumeLayout(False)
    Me.GroupBox18.ResumeLayout(False)
    Me.GroupBox18.PerformLayout()
    Me.Panel_CCD1.ResumeLayout(False)
    Me.Panel_CCD2.ResumeLayout(False)
    Me.Panel_CCD4.ResumeLayout(False)
    Me.Panel_CCD3.ResumeLayout(False)
    Me.TabControl_CCD.ResumeLayout(False)
    Me.TabPage_Search1.ResumeLayout(False)
    Me.TabPage_Search2.ResumeLayout(False)
    Me.Panel_Search2_CCD2.ResumeLayout(False)
    Me.Panel_Search2_CCD4.ResumeLayout(False)
    Me.Panel_Search2_CCD3.ResumeLayout(False)
    Me.Panel_Search2_CCD1.ResumeLayout(False)
    Me.Panel_Search2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents GroupTools As System.Windows.Forms.GroupBox
  Friend WithEvents BtnTool_Exit As System.Windows.Forms.Button
  Friend WithEvents BtnTool_Log As System.Windows.Forms.Button
  Friend WithEvents BtnTool_IO As System.Windows.Forms.Button
  Friend WithEvents BtnTool_FileDelete As System.Windows.Forms.Button
  Friend WithEvents BtnTool_FileSaveAs As System.Windows.Forms.Button
  Friend WithEvents BtnTool_FileSave As System.Windows.Forms.Button
  Friend WithEvents BtnTool_FileLoad As System.Windows.Forms.Button
  Friend WithEvents BtnTool_Login As System.Windows.Forms.Button
  Friend WithEvents BtnTool_Start As System.Windows.Forms.Button
  Friend WithEvents BtnTool_Stop As System.Windows.Forms.Button
  Friend WithEvents LabProgramInfo As System.Windows.Forms.Label
  Friend WithEvents GroupOption As System.Windows.Forms.GroupBox
  Friend WithEvents CheckOption_DrawCross As System.Windows.Forms.CheckBox
  Friend WithEvents LabLevel As System.Windows.Forms.Label
  Friend WithEvents OpenFileDialog_LoadImage As System.Windows.Forms.OpenFileDialog
  Friend WithEvents SaveFileDialog_SaveImage As System.Windows.Forms.SaveFileDialog
  Friend WithEvents LabFileName As System.Windows.Forms.Label
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents InstantCtrl_DI As Automation.BDaq.InstantDiCtrl
  Friend WithEvents TimerDIO As System.Windows.Forms.Timer
  Friend WithEvents TabPage_IO As System.Windows.Forms.TabPage
  Friend WithEvents Panel_IO As System.Windows.Forms.Panel
  Friend WithEvents GroupIO_Output As System.Windows.Forms.GroupBox
  Friend WithEvents CheckDo_Y116 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y115 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y114 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y113 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y112 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y111 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y110 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y109 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y108 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y107 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y105 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y106 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y103 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y104 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y102 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckDo_Y101 As System.Windows.Forms.CheckBox
  Friend WithEvents GroupIO_Input As System.Windows.Forms.GroupBox
  Friend WithEvents LabDi_X116 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X115 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X114 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X113 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X112 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X111 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X110 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X109 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X108 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X107 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X106 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X105 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X104 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X103 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X102 As System.Windows.Forms.Label
  Friend WithEvents LabDi_X101 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TabPage_Parameter As System.Windows.Forms.TabPage
  Friend WithEvents PanelParameter As System.Windows.Forms.Panel
  Friend WithEvents GroupAdv As System.Windows.Forms.GroupBox
  Friend WithEvents GroupAdv_Calib_Distance As System.Windows.Forms.GroupBox
  Friend WithEvents TextAdv_Distance_UpDown As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents BtnAdv_Calib_CcdDistance As System.Windows.Forms.Button
  Friend WithEvents TextAdv_Distance_LeftRight As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents GroupProduct As System.Windows.Forms.GroupBox
  Friend WithEvents TabPage_Run As System.Windows.Forms.TabPage
  Friend WithEvents PanelRun As System.Windows.Forms.Panel
  Friend WithEvents LabSearch1_Result_CCD4 As System.Windows.Forms.Label
  Friend WithEvents LabSearch1_Result_CCD3 As System.Windows.Forms.Label
  Friend WithEvents LabSearch1_Result_CCD2 As System.Windows.Forms.Label
  Friend WithEvents LabSearch1_Result_CCD1 As System.Windows.Forms.Label
  Friend WithEvents BtnRun_ImageLoad_CCD4 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageSave_CCD4 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageLoad_CCD2 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageSave_CCD2 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageLoad_CCD1 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageSave_CCD1 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageLoad_CCD3 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageSave_CCD3 As System.Windows.Forms.Button
  Friend WithEvents CheckRun_Live_CCD4 As System.Windows.Forms.CheckBox
  Friend WithEvents BtnRun_ZoomToFit_CCD4 As System.Windows.Forms.Button
  Friend WithEvents CheckRun_Live_CCD2 As System.Windows.Forms.CheckBox
  Friend WithEvents BtnRun_ZoomToFit_CCD2 As System.Windows.Forms.Button
  Friend WithEvents CheckRun_Live_CCD3 As System.Windows.Forms.CheckBox
  Friend WithEvents BtnRun_ZoomToFit_CCD3 As System.Windows.Forms.Button
  Friend WithEvents ImageViewer_CCD3 As NationalInstruments.Vision.WindowsForms.ImageViewer
  Friend WithEvents CheckRun_Live_CCD1 As System.Windows.Forms.CheckBox
  Friend WithEvents BtnRun_ZoomToFit_CCD1 As System.Windows.Forms.Button
  Friend WithEvents ImageViewer_CCD4 As NationalInstruments.Vision.WindowsForms.ImageViewer
  Friend WithEvents ImageViewer_CCD1 As NationalInstruments.Vision.WindowsForms.ImageViewer
  Friend WithEvents ImageViewer_CCD2 As NationalInstruments.Vision.WindowsForms.ImageViewer
  Friend WithEvents TabControl_SendData As System.Windows.Forms.TabControl
  Friend WithEvents InstantCtrl_DO As Automation.BDaq.InstantDoCtrl
  Friend WithEvents GroupProduct_Light As System.Windows.Forms.GroupBox
  Friend WithEvents BtnTeach_SearchLight_Set As System.Windows.Forms.Button
  Friend WithEvents TextTeach_Search_Light2 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Search_Light1 As System.Windows.Forms.TextBox
  Friend WithEvents Label215 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_Search_Light4 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Search_Light3 As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents GroupAdv_Calib_Light As System.Windows.Forms.GroupBox
  Friend WithEvents TextAdv_Calib_Light4 As System.Windows.Forms.TextBox
  Friend WithEvents TextAdv_Calib_Light3 As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents BtnAdv_CalibLight_Set As System.Windows.Forms.Button
  Friend WithEvents TextAdv_Calib_Light2 As System.Windows.Forms.TextBox
  Friend WithEvents TextAdv_Calib_Light1 As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents GroupAdv_Calib_ImageAdjust As System.Windows.Forms.GroupBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents BtnAdv_Calib_Fill As System.Windows.Forms.Button
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents TrackBarAdv_Calib_BinaryMin As System.Windows.Forms.TrackBar
  Friend WithEvents TextAdv_Calib_BinaryMin As System.Windows.Forms.TextBox
  Friend WithEvents UpDownAdv_Calib_Remove As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents TrackBarAdv_Calib_BinaryMax As System.Windows.Forms.TrackBar
  Friend WithEvents TextAdv_Calib_BinaryMax As System.Windows.Forms.TextBox
  Friend WithEvents CheckAdv_Calib_RejectBorder As System.Windows.Forms.CheckBox
  Friend WithEvents BtnAdv_Calib_RejectBorder As System.Windows.Forms.Button
  Friend WithEvents TextAdv_CalibTool_DistanceY As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents TextAdv_CalibTool_DistanceX As System.Windows.Forms.TextBox
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents GroupAdv_Calib_Pixel As System.Windows.Forms.GroupBox
  Friend WithEvents LabAdv_FovY_CCD1 As System.Windows.Forms.Label
  Private WithEvents BtnAdv_Calib_Pixel As System.Windows.Forms.Button
  Friend WithEvents LabAdv_FovX_CCD1 As System.Windows.Forms.Label
  Private WithEvents Label99 As System.Windows.Forms.Label
  Friend WithEvents TextAdv_CircleSize As System.Windows.Forms.TextBox
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents TextAdv_Pixel_CCD1 As System.Windows.Forms.TextBox
  Private WithEvents Label45 As System.Windows.Forms.Label
  Friend WithEvents TextAdv_Pixel_CCD4 As System.Windows.Forms.TextBox
  Friend WithEvents TextAdv_Pixel_CCD3 As System.Windows.Forms.TextBox
  Friend WithEvents TextAdv_Pixel_CCD2 As System.Windows.Forms.TextBox
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents LabAdv_FovY_CCD4 As System.Windows.Forms.Label
  Friend WithEvents LabAdv_FovX_CCD4 As System.Windows.Forms.Label
  Friend WithEvents LabAdv_FovY_CCD3 As System.Windows.Forms.Label
  Friend WithEvents LabAdv_FovX_CCD3 As System.Windows.Forms.Label
  Friend WithEvents LabAdv_FovY_CCD2 As System.Windows.Forms.Label
  Friend WithEvents LabAdv_FovX_CCD2 As System.Windows.Forms.Label
  Private WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RadioAdv_Pixel_CCD4 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioAdv_Pixel_CCD3 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioAdv_Pixel_CCD2 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioAdv_Pixel_CCD1 As System.Windows.Forms.RadioButton
  Friend WithEvents BtnAdv_CalibLight_On As System.Windows.Forms.Button
  Friend WithEvents BtnTeach_SearchLight_Off As System.Windows.Forms.Button
  Friend WithEvents BtnTeach_SearchLight_On As System.Windows.Forms.Button
  Friend WithEvents BtnAdv_CalibLight_Off As System.Windows.Forms.Button
  Friend WithEvents BtnTool_Search As System.Windows.Forms.Button
  Friend WithEvents CheckSearch_LeftRight As System.Windows.Forms.CheckBox
  Friend WithEvents CheckSearch_UpDown As System.Windows.Forms.CheckBox
  Friend WithEvents GroupTeach_ImageAdjust_Size As System.Windows.Forms.GroupBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TrackBarTeach_BinaryMax As System.Windows.Forms.TrackBar
  Friend WithEvents TextTeach_BinaryMax As System.Windows.Forms.TextBox
  Friend WithEvents TrackBarTeach_BinaryMin As System.Windows.Forms.TrackBar
  Friend WithEvents TextTeach_BinaryMin As System.Windows.Forms.TextBox
  Friend WithEvents BtnTeach_Hull As System.Windows.Forms.Button
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents GroupRun_Msg As System.Windows.Forms.GroupBox
  Friend WithEvents LabRun_Msg_CCD1 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Msg_CCD2 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Msg_CCD4 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Msg_CCD3 As System.Windows.Forms.Label
  Friend WithEvents GroupRun_Result As System.Windows.Forms.GroupBox
  Friend WithEvents LabRun_Distance_LeftRight As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Distance_UpDown As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Defect_TrueCircle_CCD1 As System.Windows.Forms.Label
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents Label35 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Defect_TrueCircle_CCD4 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Defect_TrueCircle_CCD3 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Defect_TrueCircle_CCD2 As System.Windows.Forms.Label
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents GroupTeacht_Spec As System.Windows.Forms.GroupBox
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_Distance_UpDown As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Distance_LeftRight As System.Windows.Forms.TextBox
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_DistanceTolerance_UpDown As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DistanceTolerance_LeftRight As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DiameterTolerance_CCD1 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Diameter_CCD1 As System.Windows.Forms.TextBox
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents Label51 As System.Windows.Forms.Label
  Friend WithEvents GroupAdv_Option As System.Windows.Forms.GroupBox
  Friend WithEvents Label223 As System.Windows.Forms.Label
  Friend WithEvents TextAdv_Option_CaptureDelay As System.Windows.Forms.TextBox
  Friend WithEvents Label222 As System.Windows.Forms.Label
  Friend WithEvents CheckAdv_Option_SaveNgPic As System.Windows.Forms.CheckBox
  Friend WithEvents CheckAdv_Option_Search As System.Windows.Forms.CheckBox
  Friend WithEvents LabRunningMsg As System.Windows.Forms.Label
  Friend WithEvents Label48 As System.Windows.Forms.Label
  Friend WithEvents TimerRunState As System.Windows.Forms.Timer
  Friend WithEvents GroupRun_OkNg As System.Windows.Forms.GroupBox
  Friend WithEvents LabRun_SearchResult As System.Windows.Forms.Label
  Friend WithEvents LabService_RunIndex As System.Windows.Forms.Label
  Friend WithEvents Label49 As System.Windows.Forms.Label
  Friend WithEvents CheckAdv_Option_Barcode As System.Windows.Forms.CheckBox
  Friend WithEvents GroupRun_BarcodeInLine As System.Windows.Forms.GroupBox
  Private WithEvents BtnRun_ResetRunIndex As System.Windows.Forms.Button
  Friend WithEvents CheckAdv_Calib_LeftRight As System.Windows.Forms.CheckBox
  Friend WithEvents CheckAdv_Calib_UpDown As System.Windows.Forms.CheckBox
  Friend WithEvents TextAdv_Angle_UpDown As System.Windows.Forms.TextBox
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents Label53 As System.Windows.Forms.Label
  Friend WithEvents TextAdv_Angle_LeftRight As System.Windows.Forms.TextBox
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents TimerBarcode As System.Windows.Forms.Timer
  Friend WithEvents SerialPort_Barcode As System.IO.Ports.SerialPort
  Friend WithEvents PictureLogo As System.Windows.Forms.PictureBox
  Friend WithEvents CheckTool_CcdLive As System.Windows.Forms.CheckBox
  Friend WithEvents BtnTool_ReadBarcode As System.Windows.Forms.Button
  Friend WithEvents Label54 As System.Windows.Forms.Label
  Private WithEvents BtnRun_LoadNgImages As System.Windows.Forms.Button
  Friend WithEvents Panel_CCD1 As System.Windows.Forms.Panel
  Friend WithEvents Panel_CCD2 As System.Windows.Forms.Panel
  Friend WithEvents Panel_CCD4 As System.Windows.Forms.Panel
  Friend WithEvents Panel_CCD3 As System.Windows.Forms.Panel
  Friend WithEvents PanelProduct_Function1 As System.Windows.Forms.Panel
  'Friend WithEvents AxActQCPUQUSB1 As AxACTPCUSBLib.AxActQCPUQUSB
  Friend WithEvents Label59 As System.Windows.Forms.Label
  Friend WithEvents Label64 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_DiameterTolerance_CCD4 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Diameter_CCD4 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DiameterTolerance_CCD3 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Diameter_CCD3 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DiameterTolerance_CCD2 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Diameter_CCD2 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DefectLength_Inside_CCD4 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DefectLength_Inside_CCD3 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DefectLength_Inside_CCD2 As System.Windows.Forms.TextBox
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_DefectLength_Inside_CCD1 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_TrueCircle_CCD4 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_TrueCircle_CCD3 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_TrueCircle_CCD2 As System.Windows.Forms.TextBox
  Friend WithEvents Label43 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_TrueCircle_CCD1 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Laser_LimitUp As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_Laser_LimitDown As System.Windows.Forms.TextBox
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents BtnTool_Home As System.Windows.Forms.Button
  Friend WithEvents GroupIO_AOI As System.Windows.Forms.GroupBox
  Friend WithEvents GroupIO_PLC As System.Windows.Forms.GroupBox
  Friend WithEvents Label65 As System.Windows.Forms.Label
  Friend WithEvents TabControlPLC As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents Label66 As System.Windows.Forms.Label
  Friend WithEvents Label67 As System.Windows.Forms.Label
  Friend WithEvents Lab_BarcodeResult_M1408 As System.Windows.Forms.Label
  Friend WithEvents Text_SearchCount_D3000 As System.Windows.Forms.TextBox
  Friend WithEvents Label68 As System.Windows.Forms.Label
  Friend WithEvents D100 As System.Windows.Forms.Label
  Friend WithEvents Btn_ClearSearchCount_M1820 As System.Windows.Forms.Button
  Friend WithEvents Lab_SearchResult_M1400 As System.Windows.Forms.Label
  Friend WithEvents Label69 As System.Windows.Forms.Label
  Friend WithEvents Lab_CycleTime_D3002 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Lab_Vacuum_X2B As System.Windows.Forms.Label
  Friend WithEvents Label70 As System.Windows.Forms.Label
  Friend WithEvents Lab_Search_M1601 As System.Windows.Forms.Label
  Friend WithEvents Label71 As System.Windows.Forms.Label
  Friend WithEvents Label72 As System.Windows.Forms.Label
  Friend WithEvents Text_LaserHeight_D950 As System.Windows.Forms.TextBox
  Friend WithEvents Lab_Barcode_M1600 As System.Windows.Forms.Label
  Friend WithEvents Label73 As System.Windows.Forms.Label
  Friend WithEvents Label74 As System.Windows.Forms.Label
  Friend WithEvents Label75 As System.Windows.Forms.Label
  Friend WithEvents Lab_Standby_M1602 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents Label76 As System.Windows.Forms.Label
  Friend WithEvents Lab_PlcReady_SM403 As System.Windows.Forms.Label
  Friend WithEvents Label77 As System.Windows.Forms.Label
  Friend WithEvents Label78 As System.Windows.Forms.Label
  Friend WithEvents Lab_AoiReady_X33 As System.Windows.Forms.Label
  Friend WithEvents Lab_HomeFinish_M1001 As System.Windows.Forms.Label
  Friend WithEvents Label79 As System.Windows.Forms.Label
  Friend WithEvents Label80 As System.Windows.Forms.Label
  Friend WithEvents M1602_1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label81 As System.Windows.Forms.Label
  Friend WithEvents Label82 As System.Windows.Forms.Label
  Friend WithEvents Btn_AlarmReset_M1300 As System.Windows.Forms.Button
  Friend WithEvents Label83 As System.Windows.Forms.Label
  Friend WithEvents L1012 As System.Windows.Forms.Label
  Friend WithEvents Lab_LimitFront_L1001 As System.Windows.Forms.Label
  Friend WithEvents Label84 As System.Windows.Forms.Label
  Friend WithEvents Lab_LimitBack_L1000 As System.Windows.Forms.Label
  Friend WithEvents Label85 As System.Windows.Forms.Label
  Friend WithEvents Lab_ServoError_L1002 As System.Windows.Forms.Label
  Friend WithEvents Label86 As System.Windows.Forms.Label
  Friend WithEvents Lab_DriverError_L1003 As System.Windows.Forms.Label
  Friend WithEvents Label87 As System.Windows.Forms.Label
  Friend WithEvents Lab_VacuumError_L1004 As System.Windows.Forms.Label
  Friend WithEvents Label88 As System.Windows.Forms.Label
  Friend WithEvents Lab_SafeDoor1_L1005 As System.Windows.Forms.Label
  Friend WithEvents Label89 As System.Windows.Forms.Label
  Friend WithEvents Lab_SafeDoor2_L1006 As System.Windows.Forms.Label
  Friend WithEvents Label90 As System.Windows.Forms.Label
  Friend WithEvents Lab_SafeDoor3_L1007 As System.Windows.Forms.Label
  Friend WithEvents Label91 As System.Windows.Forms.Label
  Friend WithEvents L1008 As System.Windows.Forms.Label
  Friend WithEvents Label92 As System.Windows.Forms.Label
  Friend WithEvents Lab_BarcodeTimeout_L1009 As System.Windows.Forms.Label
  Friend WithEvents Label93 As System.Windows.Forms.Label
  Friend WithEvents Lab_CcdTimeout_L1010 As System.Windows.Forms.Label
  Friend WithEvents Label94 As System.Windows.Forms.Label
  Friend WithEvents L1011 As System.Windows.Forms.Label
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
  Friend WithEvents Text_StandbyPosition_D1120 As System.Windows.Forms.TextBox
  Friend WithEvents Label95 As System.Windows.Forms.Label
  Friend WithEvents Lab_Standby_M1602_2 As System.Windows.Forms.Label
  Friend WithEvents Btn_StandbyPositionMove_M1154 As System.Windows.Forms.Button
  Friend WithEvents Btn_StandbyPositionSet_M1202 As System.Windows.Forms.Button
  Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
  Friend WithEvents Label96 As System.Windows.Forms.Label
  Friend WithEvents Lab_Barcode_M1600_2 As System.Windows.Forms.Label
  Friend WithEvents Btn_BarcodePositionMove_M1152 As System.Windows.Forms.Button
  Friend WithEvents Btn_BarcodePositionSet_M1200 As System.Windows.Forms.Button
  Friend WithEvents Text_BarcodePosition_D1100 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
  Friend WithEvents Lab_HomeFinish_M1002 As System.Windows.Forms.Label
  Friend WithEvents Label97 As System.Windows.Forms.Label
  Friend WithEvents Btn_Home_M1000 As System.Windows.Forms.Button
  Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
  Friend WithEvents Label98 As System.Windows.Forms.Label
  Friend WithEvents Text_NowPosition_D1090 As System.Windows.Forms.TextBox
  Friend WithEvents GroupVacuum As System.Windows.Forms.GroupBox
  Friend WithEvents Label100 As System.Windows.Forms.Label
  Friend WithEvents Lab_Vacuum_X2B_2 As System.Windows.Forms.Label
  Friend WithEvents Btn_VacuumOnOff_M1912 As System.Windows.Forms.Button
  Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
  Friend WithEvents Lab_MoveSpeed_D1030 As System.Windows.Forms.TextBox
  Friend WithEvents Label101 As System.Windows.Forms.Label
  Friend WithEvents Lab_MoveSpeedSet_D1030 As System.Windows.Forms.TextBox
  Friend WithEvents Label102 As System.Windows.Forms.Label
  Friend WithEvents Btn_MoveSpeedSet_D1030 As System.Windows.Forms.Button
  Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
  Friend WithEvents Label103 As System.Windows.Forms.Label
  Friend WithEvents Text_TriggerDelay_D3010 As System.Windows.Forms.TextBox
  Friend WithEvents Text_TriggerDelaySet_D3010 As System.Windows.Forms.TextBox
  Friend WithEvents Label104 As System.Windows.Forms.Label
  Friend WithEvents Btn_TriggerDelaySet_D3010 As System.Windows.Forms.Button
  Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
  Friend WithEvents Label105 As System.Windows.Forms.Label
  Friend WithEvents Lab_Search__M1601_2 As System.Windows.Forms.Label
  Friend WithEvents Btn_SearchPositionMove_M1153 As System.Windows.Forms.Button
  Friend WithEvents Btn_SearchPositionSet_M1201 As System.Windows.Forms.Button
  Friend WithEvents Text_SearchPosition_D1110 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents Label106 As System.Windows.Forms.Label
  Friend WithEvents Label107 As System.Windows.Forms.Label
  Friend WithEvents Lab_SearchResult_M1408_2 As System.Windows.Forms.Label
  Friend WithEvents Btn_ReaderTrigger_M1900 As System.Windows.Forms.Button
  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents Lab_SearchResult_M1400_2 As System.Windows.Forms.Label
  Friend WithEvents Label108 As System.Windows.Forms.Label
  Friend WithEvents Btn_CcdTrigger_M1902 As System.Windows.Forms.Button
  Friend WithEvents Label109 As System.Windows.Forms.Label
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents Label110 As System.Windows.Forms.Label
  Friend WithEvents Btn_MoveBack_M1151 As System.Windows.Forms.Button
  Friend WithEvents Btn_MoveFront_M1150 As System.Windows.Forms.Button
  Friend WithEvents Radio_MoveSpeedC_M1130 As System.Windows.Forms.RadioButton
  Friend WithEvents M1140 As System.Windows.Forms.Label
  Friend WithEvents M1142 As System.Windows.Forms.Label
  Friend WithEvents Radio_MoveSpeedC_M1131 As System.Windows.Forms.RadioButton
  Friend WithEvents Radio_MoveSpeedC_M1132 As System.Windows.Forms.RadioButton
  Friend WithEvents M1141 As System.Windows.Forms.Label
  Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
  Friend WithEvents Label111 As System.Windows.Forms.Label
  Friend WithEvents Btn_MoveBack_M1121 As System.Windows.Forms.Button
  Friend WithEvents Btn_MoveFront_M1120 As System.Windows.Forms.Button
  Friend WithEvents Radio_MoveSpeedPtp_M1102 As System.Windows.Forms.RadioButton
  Friend WithEvents Radio_MoveSpeedPtp_M1103 As System.Windows.Forms.RadioButton
  Friend WithEvents M1112 As System.Windows.Forms.Label
  Friend WithEvents M1111 As System.Windows.Forms.Label
  Friend WithEvents Radio_MoveSpeedPtp_M1101 As System.Windows.Forms.RadioButton
  Friend WithEvents M1110 As System.Windows.Forms.Label
  Friend WithEvents Label112 As System.Windows.Forms.Label
  Friend WithEvents Label113 As System.Windows.Forms.Label
  Friend WithEvents LabPlcRunning As System.Windows.Forms.Label
  Friend WithEvents txt_Data As System.Windows.Forms.TextBox
  Friend WithEvents txt_LogicalStationNumber As System.Windows.Forms.TextBox
  Friend WithEvents lbl_LogicalStationNumber As System.Windows.Forms.Label
  Friend WithEvents Radio_PlcRunning As System.Windows.Forms.RadioButton
  Friend WithEvents Text_ReturnCode As System.Windows.Forms.TextBox
  Friend WithEvents BtnClose As System.Windows.Forms.Button
  Friend WithEvents BtnOpen As System.Windows.Forms.Button
  Friend WithEvents BtnTool_AlarmReset As System.Windows.Forms.Button
  Friend WithEvents AxActUtlType_PLC As AxActUtlTypeLib.AxActUtlType
  Friend WithEvents LabRun_Msg_PLC As System.Windows.Forms.Label
  Friend WithEvents Btn_LaserReset As System.Windows.Forms.Button
  Friend WithEvents TrackBarTeach_BinaryOutside As System.Windows.Forms.TrackBar
  Friend WithEvents TextTeach_BinaryOutside As System.Windows.Forms.TextBox
  Friend WithEvents GroupTeach_ImageAdjust_Outside As System.Windows.Forms.GroupBox
  Friend WithEvents Label115 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_DefectLength_Outside_CCD4 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DefectLength_Outside_CCD3 As System.Windows.Forms.TextBox
  Friend WithEvents TextTeach_DefectLength_Outside_CCD2 As System.Windows.Forms.TextBox
  Friend WithEvents Label116 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_DefectLength_Outside_CCD1 As System.Windows.Forms.TextBox
  Friend WithEvents DataGrid_DefectLength_Outside As System.Windows.Forms.DataGridView
  Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BtnRun_ImageSource_CCD1 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageSource_CCD2 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageSource_CCD4 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_ImageSource_CCD3 As System.Windows.Forms.Button
  Friend WithEvents BtnRun_MoveToStandbyPos As System.Windows.Forms.Button
  Friend WithEvents BtnRun_MoveToSearchPos As System.Windows.Forms.Button
  Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
  Friend WithEvents TextOpInf_UserNo As System.Windows.Forms.TextBox
  Friend WithEvents Label118 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_DateTime As System.Windows.Forms.TextBox
  Friend WithEvents Label119 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_OunchNeedleNumberDown As System.Windows.Forms.TextBox
  Friend WithEvents Label126 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_OunchNeedleNumberUp As System.Windows.Forms.TextBox
  Friend WithEvents Label127 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_MouldNumber As System.Windows.Forms.TextBox
  Friend WithEvents Label128 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_MachineCode As System.Windows.Forms.TextBox
  Friend WithEvents Label129 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_HoleDustanceAndResultY As System.Windows.Forms.TextBox
  Friend WithEvents Label122 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_HoleDustanceAndResultX As System.Windows.Forms.TextBox
  Friend WithEvents Label123 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_HoleQualityType As System.Windows.Forms.TextBox
  Friend WithEvents Label124 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_HoleQualityResult As System.Windows.Forms.TextBox
  Friend WithEvents Label125 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_ProductNumber As System.Windows.Forms.TextBox
  Friend WithEvents Label120 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_NotNumber As System.Windows.Forms.TextBox
  Friend WithEvents Label121 As System.Windows.Forms.Label
  Friend WithEvents TextOpInf_PackNumber As System.Windows.Forms.TextBox
  Friend WithEvents Label130 As System.Windows.Forms.Label
  Friend WithEvents TabControl_CCD As System.Windows.Forms.TabControl
  Friend WithEvents TabPage_Search1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage_Search2 As System.Windows.Forms.TabPage
  Friend WithEvents Panel_Search2_CCD1 As System.Windows.Forms.Panel
  Friend WithEvents Label132 As System.Windows.Forms.Label
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents Label131 As System.Windows.Forms.Label
  Friend WithEvents ImageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
  Friend WithEvents Panel_Search2_CCD2 As System.Windows.Forms.Panel
  Friend WithEvents Label133 As System.Windows.Forms.Label
  Friend WithEvents Panel_Search2_CCD4 As System.Windows.Forms.Panel
  Friend WithEvents Label134 As System.Windows.Forms.Label
  Friend WithEvents Panel_Search2_CCD3 As System.Windows.Forms.Panel
  Friend WithEvents Label135 As System.Windows.Forms.Label
  Friend WithEvents Panel_Search2 As System.Windows.Forms.Panel
  Friend WithEvents LabSearch2_Result_CCD1 As System.Windows.Forms.Label
  Friend WithEvents BtnSearch2_Measure_CCD2 As System.Windows.Forms.Button
  Friend WithEvents BtnSearch2_ImageLoad_CCD1 As System.Windows.Forms.Button
  Friend WithEvents BtnSearch2_ImageLoad_CCD2 As System.Windows.Forms.Button
  Friend WithEvents BtnSearch2_ImageLoad_CCD4 As System.Windows.Forms.Button
  Friend WithEvents BtnSearch2_Measure_CCD1 As System.Windows.Forms.Button
  Friend WithEvents BtnSearch2_Measure_CCD3 As System.Windows.Forms.Button
  Friend WithEvents BtnSearch2_ImageLoad_CCD3 As System.Windows.Forms.Button
  Friend WithEvents BtnSearch2_Measure_CCD4 As System.Windows.Forms.Button
  Friend WithEvents LabSearch2_Result_CCD3 As System.Windows.Forms.Label
  Friend WithEvents LabSearch2_Result_CCD2 As System.Windows.Forms.Label
  Friend WithEvents LabSearch2_Result_CCD4 As System.Windows.Forms.Label
  Friend WithEvents BtnSearch2_SetParameter As System.Windows.Forms.Button
  Friend WithEvents UpDownSearch2_Score As System.Windows.Forms.NumericUpDown
  Friend WithEvents GroupTeach_ImageAdjust_Inside As System.Windows.Forms.GroupBox
  Friend WithEvents Label137 As System.Windows.Forms.Label
  Friend WithEvents GroupRun_CycleTime As System.Windows.Forms.GroupBox
  Friend WithEvents LabTimeInf_Total As System.Windows.Forms.Label
  Friend WithEvents Label142 As System.Windows.Forms.Label
  Friend WithEvents LabTimeInf_Search2 As System.Windows.Forms.Label
  Friend WithEvents Label140 As System.Windows.Forms.Label
  Friend WithEvents LabTimeInf_Search1 As System.Windows.Forms.Label
  Friend WithEvents Label138 As System.Windows.Forms.Label
  Friend WithEvents Label139 As System.Windows.Forms.Label
  Friend WithEvents TextTeach_BinaryDefectOut As System.Windows.Forms.TextBox
  Friend WithEvents TrackBarTeach_BinaryDefectOut As System.Windows.Forms.TrackBar
  Friend WithEvents OpenFileDialog_SendData As System.Windows.Forms.OpenFileDialog
  Friend WithEvents GroupRun_SendData As System.Windows.Forms.GroupBox
  Friend WithEvents Label141 As System.Windows.Forms.Label
  Friend WithEvents LabSendData_FileName As System.Windows.Forms.Label
  Friend WithEvents BtnRun_LoadResultFile As System.Windows.Forms.Button
  Private WithEvents BtnRun_SendData As System.Windows.Forms.Button
  Friend WithEvents DataGrid_SendData As System.Windows.Forms.DataGridView
  Friend WithEvents Column1_Name As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Column2_Value As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents BtnTeach_MaskCircle As System.Windows.Forms.Button
  Friend WithEvents TextRun_Barcode_Reader As System.Windows.Forms.TextBox
  Friend WithEvents BtnTeach_ShowMaskCircle As System.Windows.Forms.Button
  Friend WithEvents TextTeach_MaskCircleSize As System.Windows.Forms.TextBox
  Friend WithEvents BtnTeach_Binary As System.Windows.Forms.Button
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TextAdv_Distance_UpDown_Offset As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TextAdv_Distance_LeftRight_Offset As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label57 As System.Windows.Forms.Label
  Friend WithEvents TextSearch2_Threshold As System.Windows.Forms.TextBox
  Friend WithEvents Label56 As System.Windows.Forms.Label
  Friend WithEvents TextSearch2_CircleDiameter As System.Windows.Forms.TextBox
  Friend WithEvents Label55 As System.Windows.Forms.Label
  Friend WithEvents TextSearch2_MeasureWidth As System.Windows.Forms.TextBox
  Friend WithEvents Label114 As System.Windows.Forms.Label
  Friend WithEvents TextSearch2_Offset As System.Windows.Forms.TextBox
  Friend WithEvents Label61 As System.Windows.Forms.Label
  Friend WithEvents TextSearch2_Gain As System.Windows.Forms.TextBox
  Friend WithEvents Label62 As System.Windows.Forms.Label
  Friend WithEvents TextSearch2_Inward As System.Windows.Forms.TextBox
  Friend WithEvents Label60 As System.Windows.Forms.Label
  Friend WithEvents TextSearch2_NonContinueCount As System.Windows.Forms.TextBox
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents TextSearch2_ContinueCount As System.Windows.Forms.TextBox
  Friend WithEvents LabTimeInf_SearchTotal As System.Windows.Forms.Label
  Friend WithEvents Label143 As System.Windows.Forms.Label
  Friend WithEvents PanelTimeInf As System.Windows.Forms.Panel
  Friend WithEvents GroupRun_DefectCount_Inside As System.Windows.Forms.GroupBox
  Friend WithEvents GroupRun_DefectLength_Outside As System.Windows.Forms.GroupBox
  Friend WithEvents LabServer_Receive_NoncontinueCount_CCD4 As System.Windows.Forms.Label
  Friend WithEvents LabServer_Receive_NoncontinueCount_CCD3 As System.Windows.Forms.Label
  Friend WithEvents LabServer_Receive_NoncontinueCount_CCD2 As System.Windows.Forms.Label
  Friend WithEvents LabServer_Receive_NoncontinueCount_CCD1 As System.Windows.Forms.Label
  Friend WithEvents LabServer_Receive_ContinueCount_CCD4 As System.Windows.Forms.Label
  Friend WithEvents LabServer_Receive_ContinueCount_CCD3 As System.Windows.Forms.Label
  Friend WithEvents LabServer_Receive_ContinueCount_CCD2 As System.Windows.Forms.Label
  Friend WithEvents LabServer_Receive_ContinueCount_CCD1 As System.Windows.Forms.Label
  Friend WithEvents Label117 As System.Windows.Forms.Label
  Friend WithEvents Label63 As System.Windows.Forms.Label
  Friend WithEvents TabPage_Service As System.Windows.Forms.TabPage
  Friend WithEvents PanelService_Back As System.Windows.Forms.Panel
  Friend WithEvents PanelService As System.Windows.Forms.Panel
  Friend WithEvents LabRun_Diameter_CCD4 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Diameter_CCD3 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Diameter_CCD2 As System.Windows.Forms.Label
  Friend WithEvents LabRun_Diameter_CCD1 As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
  Friend WithEvents Label144 As System.Windows.Forms.Label
  Friend WithEvents TextServer_Receive_CCD1 As System.Windows.Forms.TextBox
  Friend WithEvents TextServer_Receive_CCD2 As System.Windows.Forms.TextBox
  Friend WithEvents TextServer_Receive_CCD3 As System.Windows.Forms.TextBox
  Friend WithEvents TextServer_Receive_CCD4 As System.Windows.Forms.TextBox
  Friend WithEvents Label136 As System.Windows.Forms.Label
  Private WithEvents BtnOpInf_Clear As System.Windows.Forms.Button

End Class

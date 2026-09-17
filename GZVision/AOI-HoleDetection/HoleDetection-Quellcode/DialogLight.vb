Imports System.Windows.Forms
Public Class DialogLight

  Private Sub DialogLight_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Text = "燈光調整 (" & LightSetName & ")"
    LightValueBefore1 = TextLight1.Text          '記憶調整前之燈光(CCD1)
    LightValueBefore2 = TextLight2.Text          '記憶調整前之燈光(CCD2)
    LightValueBefore3 = TextLight3.Text          '記憶調整前之燈光(CCD3)
    LightValueBefore4 = TextLight4.Text          '記憶調整前之燈光(CCD4)
  End Sub
  '燈光調整→拉霸
  Private Sub TrackBarTeachPar_Light_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarTeachPar_Light1.ValueChanged, TrackBarTeachPar_Light2.ValueChanged, TrackBarTeachPar_Light3.ValueChanged, TrackBarTeachPar_Light4.ValueChanged
    If Me.Created = False Then Exit Sub
    Dim MyTrackBar As TrackBar = sender

    LightControl(2) = CByte(16 * Val(MyTrackBar.Tag))
    Select Case MyTrackBar.Tag
      Case 1
        If A_FormMain.CheckRun_Live_CCD1.Checked = False Then A_FormMain.CheckRun_Live_CCD1.Checked = True '若為靜態則變動態
        TextTeachPar_Light1.Text = TrackBarTeachPar_Light1.Value
        LightControl(5) = CByte(TrackBarTeachPar_Light1.Value)
      Case 2
        If A_FormMain.CheckRun_Live_CCD2.Checked = False Then A_FormMain.CheckRun_Live_CCD2.Checked = True '若為靜態則變動態
        TextTeachPar_Light2.Text = TrackBarTeachPar_Light2.Value
        LightControl(5) = CByte(TrackBarTeachPar_Light2.Value)
      Case 3
        If A_FormMain.CheckRun_Live_CCD3.Checked = False Then A_FormMain.CheckRun_Live_CCD3.Checked = True '若為靜態則變動態
        TextTeachPar_Light3.Text = TrackBarTeachPar_Light3.Value
        LightControl(5) = CByte(TrackBarTeachPar_Light3.Value)
      Case 4
        If A_FormMain.CheckRun_Live_CCD4.Checked = False Then A_FormMain.CheckRun_Live_CCD4.Checked = True '若為靜態則變動態
        TextTeachPar_Light4.Text = TrackBarTeachPar_Light4.Value
        LightControl(5) = CByte(TrackBarTeachPar_Light4.Value)
    End Select
    Dim MyValue As Integer = CRC_CODE(6, LightControl)
    LightControl(6) = Convert.ToInt32(Strings.Mid(Hex(MyValue).ToString, 1, 2), 16)
    LightControl(7) = Convert.ToInt32(Strings.Mid(Hex(MyValue).ToString, 3, 2), 16)
    Threading.Thread.Sleep(20)

    Try
      RS232_Light.Write(LightControl, 0, 8)
    Catch ex As Exception : End Try

  End Sub
  '燈光調整→值
  Private Sub TextTeachPar_Light_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextTeachPar_Light1.TextChanged, TextTeachPar_Light2.TextChanged, TextTeachPar_Light3.TextChanged, TextTeachPar_Light4.TextChanged
    If Me.Created = False Then Exit Sub
    Dim MyText As TextBox = sender
    If Val(TextTeachPar_Light1.Text) > 255 Then TextTeachPar_Light1.Text = 255
    If Val(TextTeachPar_Light2.Text) > 255 Then TextTeachPar_Light2.Text = 255
    If Val(TextTeachPar_Light3.Text) > 255 Then TextTeachPar_Light3.Text = 255
    If Val(TextTeachPar_Light4.Text) > 255 Then TextTeachPar_Light4.Text = 255

    If TextTeachPar_Light1.Text = "" Then TextTeachPar_Light1.Text = 0
    If TextTeachPar_Light2.Text = "" Then TextTeachPar_Light2.Text = 0
    If TextTeachPar_Light3.Text = "" Then TextTeachPar_Light3.Text = 0
    If TextTeachPar_Light4.Text = "" Then TextTeachPar_Light4.Text = 0

    Select Case MyText.Tag
      Case 1 : TrackBarTeachPar_Light1.Value = TextTeachPar_Light1.Text
      Case 2 : TrackBarTeachPar_Light2.Value = TextTeachPar_Light2.Text
      Case 3 : TrackBarTeachPar_Light3.Value = TextTeachPar_Light3.Text
      Case 4 : TrackBarTeachPar_Light4.Value = TextTeachPar_Light4.Text
    End Select
  End Sub
  '確定鈕→Update 調整後之燈光
  Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
    TextLight1.Text = TextTeachPar_Light1.Text 'CCD1
    TextLight2.Text = TextTeachPar_Light2.Text 'CCD2
    TextLight3.Text = TextTeachPar_Light3.Text 'CCD3
    TextLight4.Text = TextTeachPar_Light4.Text 'CCD4
    Me.Close()
  End Sub
  '取消鈕
  Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
    TrackBarTeachPar_Light1.Value = LightValueBefore1 '還原調整前之燈光(CCD1)
    TrackBarTeachPar_Light2.Value = LightValueBefore2 '還原調整前之燈光(CCD2)
    TrackBarTeachPar_Light3.Value = LightValueBefore3 '還原調整前之燈光(CCD3)
    TrackBarTeachPar_Light4.Value = LightValueBefore4 '還原調整前之燈光(CCD4)
    Me.Close()
  End Sub
  '啟動表單時
  Private Sub DialogLight_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    TextTeachPar_Light1.Text = LightValueBefore1 '載入調整前之燈光(CCD1)
    TextTeachPar_Light2.Text = LightValueBefore2 '載入調整前之燈光(CCD2)
    TextTeachPar_Light3.Text = LightValueBefore3 '載入調整前之燈光(CCD3)
    TextTeachPar_Light4.Text = LightValueBefore4 '載入調整前之燈光(CCD4)
  End Sub
End Class

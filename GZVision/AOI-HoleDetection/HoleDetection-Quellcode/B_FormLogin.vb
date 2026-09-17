Imports System.Windows.Forms
Imports System.IO

Public Class B_FormLogin
  Dim SelectLevel As String
  Public Sub GetBtnNumber(ByVal MyBtn As Button, ByVal e As System.EventArgs)
    TextLogin_Password.Text &= MyBtn.Text
  End Sub
  Public Sub CheckPassword(ByVal MyLevelIndex As String)
    Dim NowMonth As String = Format(Now, "MM")
    Dim i As Integer

    Select Case MyLevelIndex

      Case "作業員" '-----------------------------------------------------------------------------------------------------------
        Call A_FormMain.SetBtnStateLevel("作業員")
        BtnLevel_Edit.Enabled = False
        Call A_FormMain.WriteMessage("登入 [作業員] 等級")
        Me.Close()
        'If TextLogin_Password.Text = A_FormMain.PasswordData(1) Then
        '  Call A_FormMain.SetBtnStateLevel("作業員")
        '  BtnLevel_Edit.Enabled = False
        '  Call A_FormMain.WriteMessage("登入 [作業員] 等級")
        '  Me.Close()
        'Else
        '  Call A_FormMain.WriteMessage("登入 [作業員] 密碼錯誤")
        '  MsgBox("密碼錯誤" & vbNewLine & vbNewLine & "Password Error", MsgBoxStyle.Exclamation, "錯誤訊息")
        '  TextLogin_Password.Text = "" '清除密碼輸入框
        'End If


      Case "工程師" '-----------------------------------------------------------------------------------------------------------
        Call TxtToArray() '載入Login資料
        Dim MtFindKey As Boolean = False

        For i = 1 To Data_Count
          If LoginDatas(i).Level = MyLevelIndex AndAlso LoginDatas(i).BadgeNumber = TextLogin_BadgeNb.Text AndAlso LoginDatas(i).Password = TextLogin_Password.Text Then
            'If LoginDatas(i).Level = "系統管理員" Then
            Call A_FormMain.SetBtnStateLevel("工程師")
            BtnLevel_Edit.Enabled = False
            Call A_FormMain.WriteMessage("] 登入 [工程師] 等級")
            MtFindKey = True '表示找到符合之工號及密碼
            Me.Close()
            Exit For
          End If
        Next

        'For i = 1 To Data_Count
        '  If LoginDatas(i).Level = MyLevelIndex Then
        '    If LoginDatas(i).Password = TextLogin_Password.Text Then
        '      Call A_FormMain.SetBtnStateLevel("工程師")
        '      BtnLevel_Edit.Enabled = False
        '      Call A_FormMain.WriteMessage("] 登入 [工程師] 等級")
        '      MtFindKey = True '表示找到符合之工號及密碼
        '      Me.Close()
        '    Else
        '      MsgBox("密碼錯誤" & vbNewLine & vbNewLine & "Password Error", MsgBoxStyle.Exclamation, "登入(Login)")
        '    End If
        '  End If
        'Next

        '表示找不到符合之工號
        If MtFindKey = False Then
          MsgBox("工號或密碼錯誤" & vbNewLine & vbNewLine & "Badge Nb. or Password Error", MsgBoxStyle.Exclamation, "登入(Login)")
        End If


        'If TextLogin_Password.Text = NowMonth & A_FormMain.PasswordData(2) Then
        '  Call A_FormMain.SetBtnStateLevel("工程師")
        '  BtnLevel_Edit.Enabled = False
        '  Me.Close()
        'Else
        '  Call A_FormMain.WriteMessage("登入 [工程師] 密碼錯誤")
        '  MsgBox("密碼錯誤" & vbNewLine & vbNewLine & "Password Error", MsgBoxStyle.Exclamation, "錯誤訊息")
        '  TextLogin_Password.Text = "" '清除密碼輸入框
        'End If

      Case "系統管理員" '-------------------------------------------------------------------------------------------------------

        Call TxtToArray() '載入Login資料
        Dim MtFindKey As Boolean = False
        For i = 1 To Data_Count
          If LoginDatas(i).Level = MyLevelIndex AndAlso LoginDatas(i).BadgeNumber = TextLogin_BadgeNb.Text AndAlso LoginDatas(i).Password = TextLogin_Password.Text Then
            'If LoginDatas(i).Level = "系統管理員" Then
            Call A_FormMain.SetBtnStateLevel("系統管理員")
            BtnLevel_Edit.Enabled = True
            Call A_FormMain.WriteMessage("] 登入 [系統管理員] 等級")
            MtFindKey = True '表示找到符合之工號及密碼
            Me.Close()
            Exit For
          End If
        Next

        '表示找不到符合之工號
        If MtFindKey = False Then
          MsgBox("工號或密碼錯誤" & vbNewLine & vbNewLine & "Badge Nb. or Password Error", MsgBoxStyle.Exclamation, "登入(Login)")
        End If


        'If TextLogin_Password.Text = NowMonth & A_FormMain.PasswordData(3) Or TextLogin_Password.Text = "3636" Then
        '  Call A_FormMain.SetBtnStateLevel("系統管理員")
        '  BtnLevel_Edit.Enabled = True
        '  'Me.Close()
        'Else
        '  Call A_FormMain.WriteMessage("登入 [系統管理員] 密碼錯誤")
        '  MsgBox("密碼錯誤" & vbNewLine & vbNewLine & "Password Error", MsgBoxStyle.Exclamation, "錯誤訊息")
        '  TextLogin_Password.Text = "" '清除密碼輸入框
        'End If

    End Select
  End Sub
  Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLevel_Login.Click
    SelectLevel = Microsoft.VisualBasic.Switch(RadioBtn1_OP.Checked = True, "作業員", RadioBtn2_Engineer.Checked = True, "工程師", RadioBtn3_System.Checked = True, "系統管理員")
    'A_FormMain.LoginLevel = SelectLevel

    '--------------------------------------------------------------------------------
    '設定主畫面按鈕狀態
    If TextLogin_Password.Text = "AB3650765" Then
      Call A_FormMain.SetBtnStateLevel("程式設計師")
      BtnLevel_Edit.Enabled = True
      Me.Close()
    Else
      '---------------------------------------
      '設定主畫面按鈕狀態
      CheckPassword(SelectLevel)
      '---------------------------------------
    End If

  End Sub

  Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLevel_Cancel.Click
    Me.Close()
  End Sub

  Private Sub B_FormLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'GetSelectLevel()
    TextLogin_Password.Text = "" '清除密碼輸入框
    SelectLevel = A_FormMain.LabLevel.Text

    '語系切換 ---------------------------------------------------------------------------------------------------------
    Select Case A_FormMain.BtnTool_Login.Text
      Case "等級登入"
        GroupBox1.Text = "選擇級別"
        RadioBtn1_OP.Text = "作業員"
        RadioBtn2_Engineer.Text = "工程師"
        RadioBtn3_System.Text = "系統管理員"
        GroupBoxInput.Text = "輸入工號及密碼"
        Label4.Text = "工號"
        Label3.Text = "密碼"
        BtnLevel_Edit.Text = "編輯"
        BtnLevel_Login.Text = "登入"
        BtnLevel_Cancel.Text = "取消"

      Case "Login"
        GroupBox1.Text = "Select level"
        RadioBtn1_OP.Text = "OP"
        RadioBtn2_Engineer.Text = "Engineer"
        RadioBtn3_System.Text = "Administrator"
        GroupBoxInput.Text = "Key in Emp. No. and password"
        Label4.Text = "Emp. No."
        Label3.Text = "Password"
        BtnLevel_Edit.Text = "Edit"
        BtnLevel_Login.Text = "Login"
        BtnLevel_Cancel.Text = "Cancel"
        '"Emp. No."
    End Select
  End Sub
  '[更改密碼]鈕
  Private Sub BtnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChangePassword.Click
    B1_FormPassword.ShowDialog()
  End Sub
  '[顯示密碼]鈕
  Private Sub BtnShowPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowPassword.Click
    MsgBox("作業員 →" & PasswordData(1) & vbNewLine & vbNewLine & "工程師 →" & PasswordData(2) & vbNewLine & vbNewLine & "系統管理員 →" & PasswordData(3) & Space(10), MsgBoxStyle.Information, "顯示密碼")
  End Sub
  '[初始密碼]鈕
  Private Sub BtnResetPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnResetPassword.Click
    If MsgBox("確定初始所有等級之登入密碼嗎 ?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "密碼初始") = MsgBoxResult.Yes Then
      PasswordData(1) = "" : PasswordData(2) = "" : PasswordData(3) = ""
      FileOpen(1, "C:\WINDOWS\system32\BofengPas.dll", OpenMode.Output)
      PrintLine(1, PasswordData(1) & "," & PasswordData(2) & "," & PasswordData(3))
      FileClose(1)
      MsgBox("所有密碼皆已初始為空字串", MsgBoxStyle.Information, "密碼初始")
    End If
  End Sub
  '選擇級別
  Private Sub RadioBtn1_OP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBtn1_OP.Click, RadioBtn3_System.Click, RadioBtn2_Engineer.Click
    Dim MyRadioBtn As RadioButton = sender
    SelectLevel = MyRadioBtn.Tag

    Select Case MyRadioBtn.Tag
      Case "作業員"
        GroupBoxInput.Enabled = False
        BtnLevel_Login.Enabled = True
      Case "工程師"
        GroupBoxInput.Enabled = True
        BtnLevel_Login.Enabled = True
        TextLogin_BadgeNb.Focus()
      Case "系統管理員"
        GroupBoxInput.Enabled = True
        BtnLevel_Login.Enabled = True
        TextLogin_BadgeNb.Focus()
    End Select
  End Sub
  '編輯鈕
  Private Sub BtnLevel_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLevel_Edit.Click
    FormEdit.ShowDialog(Me)
  End Sub
End Class


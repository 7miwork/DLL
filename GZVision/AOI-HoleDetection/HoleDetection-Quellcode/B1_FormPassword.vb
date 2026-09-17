Imports System.Windows.Forms
Imports System.IO

Public Class B1_FormPassword
  Dim LevelIndex As Integer '1:作業員 , 2:工程師 , 3:系統管理員

  Private Sub B1_FormPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If B_FormLogin.RadioBtn1_OP.Checked Then
      Text = "更改密碼 (作業員)"
      LevelIndex = 1
    ElseIf B_FormLogin.RadioBtn2_Engineer.Checked Then
      Text = "更改密碼 (工程師)"
      LevelIndex = 2
    ElseIf B_FormLogin.RadioBtn3_System.Checked Then
      Text = "更改密碼 (系統管理員)"
      LevelIndex = 3
    End If

    '清除所有密碼輸入欄位
    TextOldPassword.Text = "" : TextNewPassword1.Text = "" : TextNewPassword2.Text = ""
  End Sub
  '[確定]鈕
  Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click

    '偵測舊密碼是否正確
    If LevelIndex = 1 Then
      If TextOldPassword.Text <> PasswordData(LevelIndex) Then
        MsgBox("舊密碼輸入錯誤 , 請重新輸入", MsgBoxStyle.Exclamation, "Message")
        TextOldPassword.Text = "" : TextNewPassword1.Text = "" : TextNewPassword2.Text = ""
        Exit Sub
      End If
    Else
      If TextOldPassword.Text <> PasswordData(LevelIndex) Then
        MsgBox("舊密碼輸入錯誤 , 請重新輸入", MsgBoxStyle.Exclamation, "Message")
        TextOldPassword.Text = "" : TextNewPassword1.Text = "" : TextNewPassword2.Text = ""
        Exit Sub
      End If
    End If

    '偵測兩組新密碼是否相同
    If TextNewPassword1.Text <> TextNewPassword2.Text Then
      MsgBox("兩組新密碼輸入不一致 , 請重新輸入", MsgBoxStyle.Exclamation, "Message")
      TextOldPassword.Text = "" : TextNewPassword1.Text = "" : TextNewPassword2.Text = ""
      Exit Sub
    End If

    PasswordData(LevelIndex) = TextNewPassword1.Text '密碼參數更新

    '寫入密碼檔
    Try
      FileOpen(1, PasswordFile, OpenMode.Output)
      PrintLine(1, PasswordData(1) & "," & PasswordData(2) & "," & PasswordData(3))
      FileClose(1)
      Me.Close()
      Call A_FormMain.WriteMessage(LevelName(LevelIndex) & " 密碼已更改")
      MsgBox("密碼更新成功 , 下次請以新密碼登入" & Chr(10) & Chr(10) & "", MsgBoxStyle.Information, "Message")
    Catch ex As Exception
      MsgBox("新密碼寫入錯誤 , 請重新更改" & Chr(10) & Chr(10) & "New Password Write Error , Please Input Again", MsgBoxStyle.Exclamation, "Message")
    End Try

  End Sub
  '[取消]鈕
  Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click
    Me.Close()
  End Sub

  Private Sub TextOldPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextOldPassword.Click, TextNewPassword2.Click, TextNewPassword1.Click
    'A_FormMain.TextKeyboard = sender
    'Tool_FormNbKeyboard.ShowDialog()
  End Sub
End Class


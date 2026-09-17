Imports System.Windows.Forms

Public Class FormSaveAs
  '確定鈕
  Private Sub BtnSaveAs_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveAs_OK.Click
    If TextSaveAs_FileName.Text = "" Then
      MsgBox("請先輸入檔名" & vbNewLine & vbNewLine & "Please input file name first.", MsgBoxStyle.Exclamation, "另存新檔 (Save as)")
    Else
      SaveAs_FileName = TextSaveAs_FileName.Text
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
    End If
  End Sub
  '取消鈕
  Private Sub BtnSaveAs_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveAs_Cancel.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub
End Class

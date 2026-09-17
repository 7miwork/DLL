Imports System.Windows.Forms

Public Class Dialog_KeyinBarcode

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click
    If TextBarcode.Text.Length = 0 Then
      MsgBox("請先手動掃描條碼", MsgBoxStyle.Exclamation, "確定")
      Exit Sub
    End If
    A_FormMain.TextRun_Barcode_Reader.Text = TextBarcode.Text
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

End Class

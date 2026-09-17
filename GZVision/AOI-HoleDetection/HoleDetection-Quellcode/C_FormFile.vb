Imports System.Windows.Forms
Public Class C_FormFile
  Dim FileSystem_FSO As New Scripting.FileSystemObject
  Public Sub RefreshRecipe()
    Dim MySplit() As String
    ListProductFolder.Items.Clear()
    DirListBox1.Refresh()
    For i As Integer = 0 To DirListBox1.DirListCount - 1
      MySplit = Split(DirListBox1.DirList(i), "\")
      ListProductFolder.Items.Add(MySplit(MySplit.Length - 1))
    Next
  End Sub
  Private Sub C_FormFile_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

  End Sub

  Private Sub C_FormFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    FileListBox1.Path = ProgramPath & "\Product\"
    DirListBox1.Path = ProgramPath & "\Product\"
    FileListBox1.Refresh()
    Call RefreshRecipe()
  End Sub

  Private Sub C_FormFile_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    'FileListBox1.Refresh()
  End Sub
  Private Sub FileListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    If FileListBox1.SelectedIndex >= 0 Then
      BtnOpen.Enabled = True
      BtnDelete.Enabled = True
    Else
      BtnOpen.Enabled = False
      BtnDelete.Enabled = False
    End If
  End Sub
  '[開啟檔案]鈕
  Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click, FileListBox1.DoubleClick, ListProductFolder.DoubleClick
    If ListProductFolder.SelectedIndex > -1 Then
      '更換產品前詢問是否儲存產品參數 -------------------------------------------------------------------------------------------------------------
      If A_FormMain.IsSaveKey = True Then
        Dim MyString As String = MsgBox("更換產品前是否儲存先前執行之產品檔案 ?", MsgBoxStyle.YesNo, "開啟檔案")
        If MyString = vbYes Then
          If A_FormMain.LabFileName.Text = "" Then
            Call A_FormMain.BtnTool_FileSaveAs_Click(sender, e)
          Else
            Call A_FormMain.BtnTool_FileSave_Click(sender, e)
          End If
        End If
      End If

      '載入選擇之產品檔
      Call A_FormMain.LoadProductParFormFile(ListProductFolder.Items(ListProductFolder.SelectedIndex)) 'New
      Me.Close()

    Else
      MsgBox("請先選擇產品擋", MsgBoxStyle.Exclamation, "開啟檔案")
    End If

  End Sub
  '[刪除檔案]鈕
  Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
    If ListProductFolder.SelectedIndex <= -1 Then
      MsgBox("請先選擇產品擋", MsgBoxStyle.Exclamation, "刪除檔案")
      Exit Sub
    End If
    If MsgBox("確定刪除該產品檔案嗎 ?", MsgBoxStyle.YesNo, "刪除檔案") = MsgBoxResult.Yes Then

      Dim MyFileName As String = ListProductFolder.SelectedItem

      If MyFileName = A_FormMain.LabFileName.Text Then
        MsgBox("產品檔正在使用中 , 無法刪除", MsgBoxStyle.Exclamation, "刪除檔案")
        Exit Sub
      End If

      Try
        If Dir(FileListBox1.Path & "\" & MyFileName, FileAttribute.Directory) = "" Then
          MsgBox(MyFileName & " 檔案不存在" & vbNewLine & vbNewLine & MyFileName & " File does not exist", MsgBoxStyle.Exclamation, "刪除檔案")
          Exit Sub
        End If
        FileSystem_FSO.DeleteFolder(FileListBox1.Path & "\" & MyFileName, True)
        Call A_FormMain.WriteMessage("產品檔 " & MyFileName & " 刪除成功")
        MsgBox("產品檔 " & MyFileName & " 刪除成功", MsgBoxStyle.Exclamation, "刪除檔案")
      Catch ex As Exception
        Call A_FormMain.WriteMessage("產品檔 " & MyFileName & " 刪除失敗")
        MsgBox("產品檔 " & MyFileName & " 刪除失敗", MsgBoxStyle.Critical, "刪除檔案")
      End Try

      FileListBox1.Refresh()
      Call RefreshRecipe()
    End If
  End Sub
  '[關閉]鈕
  Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
    Me.Close()
  End Sub

  Private Sub DirListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirListBox1.SelectedIndexChanged
    Call RefreshRecipe()
  End Sub
End Class

Imports System.Windows.Forms
Imports System.IO

Public Class DialogLoadNgImage

  Public Sub RefreshList()
    Dim MySplit() As String
    ListNgImage_Folder.Items.Clear()
    DirListBox1.Refresh()
    For i As Integer = 0 To DirListBox1.DirListCount - 1
      MySplit = Split(DirListBox1.DirList(i), "\")
      ListNgImage_Folder.Items.Add(MySplit(MySplit.Length - 1))
    Next
  End Sub
  '四支CCD之圖形僅Show一組至ListBox上
  Public Sub ListFile_OnlyOne()
    Dim MyFileName_Now As String = ""
    Dim MyFileName_Date As String = ""

    List_NgImage_File.Items.Clear()
    For i As Integer = 0 To FileList_NgImage.Items.Count - 1
      MyFileName_Now = Strings.Left(FileList_NgImage.Items(i), 15)
      If MyFileName_Date <> MyFileName_Now Then
        List_NgImage_File.Items.Add(MyFileName_Now)
        MyFileName_Date = MyFileName_Now
      End If
    Next
  End Sub
  'Form 建立時期
  Private Sub DialogLoadNgImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    FileListBox1.Path = ProgramPath & "\NG Image\"
    DirListBox1.Path = ProgramPath & "\NG Image\"
    FileListBox1.Refresh()
    Call RefreshList()
    List_NgImage_File.Items.Clear()
  End Sub
  '[開啟檔案]鈕
  Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
    If List_NgImage_File.SelectedIndex < 0 OrElse List_NgImage_File.SelectedIndex >= List_NgImage_File.Items.Count Then
      MsgBox("請先選擇欲開啟的NG圖檔", MsgBoxStyle.Exclamation, "載入NG圖")
      Exit Sub
    End If

    Dim MyFileName As String = ""
    Dim MyFileName_Select As String = List_NgImage_File.SelectedItem
    Dim MyCcdIndex As Integer = 0
    Dim MyCcdStringPos As Integer = 0 '檔名中 "CCD" 字串的位置
    Dim MyPathAndFile As String = ""
    Dim i As Integer = 0

    For i = 1 To 4
      If ImageViewer_CCD(i).Image.Width > 0 Then ImageViewer_CCD(i).Image.SetSize(0, 0)
    Next

    MsgBox("")
    For i = 0 To FileList_NgImage.Items.Count - 1
      MyFileName = FileList_NgImage.Items(i)                   'FileList 中目前所取得的檔名
      If Strings.InStr(MyFileName, MyFileName_Select) > 0 Then '檔名中是否符合所選擇之日期時間關鍵字
        MyCcdStringPos = Strings.InStr(MyFileName, "CCD")      '檔名中 "CCD" 字串的位置
        If MyCcdStringPos > 0 Then
          MyCcdIndex = Val(Strings.Mid(MyFileName, MyCcdStringPos + 3, 1))
          MyPathAndFile = FileList_NgImage.Path & "\" & MyFileName
          'MsgBox(Directory.Exists(ProgramPath & "\NG Image") & " , " & File.Exists(MyPathAndFile))
          ImageViewer_CCD(MyCcdIndex).Image.ReadFile(MyPathAndFile)
        End If
      End If
    Next
    Me.Close()
  End Sub
  '[刪除檔案]鈕
  Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click

  End Sub
  '[關閉]鈕
  Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
    Me.Close()
  End Sub
  '點選哪一個產品檔目錄之NG圖
  Private Sub ListNgImage_Folder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListNgImage_Folder.SelectedIndexChanged
    FileList_NgImage.Path = ProgramPath & "\NG Image\" & ListNgImage_Folder.SelectedItem
    FileList_NgImage.Refresh()
    Call ListFile_OnlyOne()
  End Sub
End Class

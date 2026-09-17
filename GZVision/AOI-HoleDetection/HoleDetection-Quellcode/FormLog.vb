Public Class FormLog

  Private Sub FormHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim MyToday As String = Format(Now, "yyyyMMdd")

    Me.Left = A_FormMain.Left + 3 ' + A_FormMain.ImageViewerCamera.Left
    Me.Top = A_FormMain.Top + A_FormMain.GroupTools.Top + A_FormMain.GroupTools.Height

    TextHistory_FindStart.Text = MyToday
    TextHistory_FindEnd.Text = MyToday
  End Sub
  '查詢鈕
  Private Sub BtnHistory_FindMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHistory_FindMessage.Click
    Dim MyFindStart As String = TextHistory_FindStart.Text
    Dim MyFindEnd As String = IIf(TextHistory_FindEnd.Text <> "", TextHistory_FindEnd.Text, Format(Now, "yyyyMMdd"))
    Dim MyPath As String = ProgramPath & "\Message\"
    Dim NowLineData As String = ""
    Dim i As Long

    ListHistory_Message.Items.Clear() '清除資料

    If CLng(MyFindStart) >= CLng(MyFindEnd) Then
      If Dir(MyPath & MyFindStart & ".Err", FileAttribute.Normal) <> "" Then
        FileOpen(5, MyPath & MyFindStart & ".Err", OpenMode.Input)

        While Not EOF(5)
          NowLineData = LineInput(5)
          ListHistory_Message.Items.Add(NowLineData)
        End While

        FileClose(5)
      End If

    Else
      For i = CLng(MyFindStart) To CLng(MyFindEnd)
        If Dir(MyPath & i.ToString & ".Err", FileAttribute.Normal) <> "" Then
          FileOpen(5, MyPath & i.ToString & ".Err", OpenMode.Input)

          While Not EOF(5)
            NowLineData = LineInput(5)
            ListHistory_Message.Items.Add(NowLineData)
          End While

          FileClose(5)
        End If
      Next
    End If

  End Sub

  Private Sub BtnHistory_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHistory_Exit.Click
    A_FormMain.GroupTools.Enabled = True
    Me.Close()
  End Sub
  '只能輸入數字
  Private Sub TextHistory_FindStart_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextHistory_FindStart.KeyPress, TextHistory_FindEnd.KeyPress
    If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = ".") Then e.KeyChar = Nothing
  End Sub
End Class
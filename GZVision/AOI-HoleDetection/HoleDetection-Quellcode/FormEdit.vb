Imports System.IO
Public Class FormEdit

  'Structure LogicData
  '  Dim BadgeNumber As String
  '  Dim Password As String
  '  Dim Level As String
  'End Structure
  'Public LoginDatas(10000) As LoginData
  'Public Data_Count As Integer

  

  Public Function ArrayToTxt() As Boolean

    FileOpen(1, LevelPath, OpenMode.Output)

    For i = 1 To Data_Count
      If LoginDatas(i).BadgeNumber <> "" Then
        PrintLine(1, LoginDatas(i).BadgeNumber & "," & LoginDatas(i).Password & "," & LoginDatas(i).Level)
      End If
    Next

    FileClose(1)

  End Function
  '更新
  Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click

    TxtToArray()

    DataGridView.RowCount = Data_Count

    For i = 1 To Data_Count
      DataGridView.Item(0, i - 1).Value = LoginDatas(i).BadgeNumber
      DataGridView.Item(1, i - 1).Value = LoginDatas(i).Password
      DataGridView.Item(2, i - 1).Value = LoginDatas(i).Level
    Next

  End Sub
  '新增
  Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
    If TextAdd_BadgeNb.Text = "" Then
      MsgBox("請先輸入工號", MsgBoxStyle.Exclamation, "新增")
      TextAdd_BadgeNb.Focus()
      Exit Sub
    End If

    If ComboAdd_Level.Text = "" Then
      MsgBox("尚未選擇級別", MsgBoxStyle.Exclamation, "新增")
      ComboAdd_Level.Focus()
      Exit Sub
    End If

    Dim MyData As Boolean = True

    Call TxtToArray()

    Try
      FileOpen(1, LevelPath, OpenMode.Append)

      For i = 1 To Data_Count
        If LoginDatas(i).BadgeNumber = TextAdd_BadgeNb.Text And LoginDatas(i).Level = ComboAdd_Level.Text Then
          MsgBox("工號已存在", MsgBoxStyle.Exclamation, "錯誤訊息")
          MyData = False
          TextAdd_BadgeNb.Text = ""
          TextAdd_Password.Text = ""
          ComboAdd_Level.Text = ""
          Exit For
        End If
      Next

      If MyData = True Then
        PrintLine(1, TextAdd_BadgeNb.Text & "," & TextAdd_Password.Text & "," & ComboAdd_Level.Text)
        TextAdd_BadgeNb.Text = ""
        TextAdd_Password.Text = ""
        ComboAdd_Level.Text = ""
        MsgBox("工號新增成功", MsgBoxStyle.Information, "新增")
      End If
    Catch ex As Exception
      MsgBox("工號新增失敗", MsgBoxStyle.Information, "新增")
    End Try

    FileClose(1)

  End Sub
  '查詢
  Private Sub BtnSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
    If RadioBtn_JobNumber.Checked = True And TextSearch_BadgeNb.Text = "" Then
      MsgBox("請先輸入工號", MsgBoxStyle.Exclamation, "查詢")
      TextSearch_BadgeNb.Focus()
      Exit Sub
    End If

    Dim MyDataCount As Integer = 0

    Call TxtToArray()

    DataGridView.RowCount = 0

    Select Case Me.GroupBox1.Tag
      '輸入工號
      Case "RadioBtn_JobNumber"
        For i = 1 To Data_Count
          If LoginDatas(i).BadgeNumber = TextSearch_BadgeNb.Text Then
            DataGridView.RowCount = 1
            DataGridView.Item(0, 0).Value = LoginDatas(i).BadgeNumber
            DataGridView.Item(1, 0).Value = LoginDatas(i).Password
            DataGridView.Item(2, 0).Value = LoginDatas(i).Level
            Exit Sub
          End If
        Next

        MsgBox("找不到此工號", MsgBoxStyle.Exclamation, "錯誤訊息")

        '工程師
      Case "RadioBtn2_Engineer"
        For i = 1 To Data_Count
          If LoginDatas(i).Level = "工程師" Then
            MyDataCount += 1
            DataGridView.RowCount = MyDataCount
            DataGridView.Item(0, MyDataCount - 1).Value = LoginDatas(i).BadgeNumber
            DataGridView.Item(1, MyDataCount - 1).Value = LoginDatas(i).Password
            DataGridView.Item(2, MyDataCount - 1).Value = LoginDatas(i).Level
          End If
        Next
        '系統管理員
      Case "RadioBtn3_System"
        For i = 1 To Data_Count
          If LoginDatas(i).Level = "系統管理員" Then
            MyDataCount += 1
            DataGridView.RowCount = MyDataCount
            DataGridView.Item(0, MyDataCount - 1).Value = LoginDatas(i).BadgeNumber
            DataGridView.Item(1, MyDataCount - 1).Value = LoginDatas(i).Password
            DataGridView.Item(2, MyDataCount - 1).Value = LoginDatas(i).Level
          End If
        Next

        '全部
      Case "RadioBtn4_All"
        For i = 1 To Data_Count
          MyDataCount += 1
          DataGridView.RowCount = MyDataCount
          DataGridView.Item(0, i - 1).Value = LoginDatas(i).BadgeNumber
          DataGridView.Item(1, i - 1).Value = LoginDatas(i).Password
          DataGridView.Item(2, i - 1).Value = LoginDatas(i).Level
        Next

    End Select

  End Sub
  '刪除
  Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
    If DataGridView.SelectedRows.Count = 0 Then
      MsgBox("請先選擇刪除之資料" & vbNewLine & vbNewLine & "Please select delete data first.", MsgBoxStyle.Exclamation, "刪除 (Delete)")
      Exit Sub
    End If
    If MsgBox("確定刪除該筆資料?" & vbNewLine & vbNewLine & "Delete this data?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "刪除 (Delete)") = MsgBoxResult.No Then Exit Sub
    Dim MySelectIndex As Integer

    TxtToArray()

    Try
      MySelectIndex = DataGridView.CurrentCell.RowIndex

      For i = 1 To Data_Count
        Dim MyString As String = DataGridView(0, MySelectIndex).Value.ToString
        If DataGridView(0, MySelectIndex).Value.ToString = LoginDatas(i).BadgeNumber Then
          'If DataGridView(2, MySelectIndex).Value = "系統管理員" Then
          '  MsgBox("該員級別為[系統管理員]，無法被刪除", MsgBoxStyle.Exclamation, "刪除 (Delete)")
          'Else
          LoginDatas(i).BadgeNumber = ""
          LoginDatas(i).Password = ""
          LoginDatas(i).Level = ""
          If MySelectIndex >= 0 Then DataGridView.Rows.RemoveAt(MySelectIndex)
          ArrayToTxt()
          Exit For
          'End If
        End If
      Next

    Catch ex As Exception
      MsgBox("刪除發生錯誤", MsgBoxStyle.Critical, "例外錯誤")
    End Try

  End Sub
  '關閉
  Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
    Close()
  End Sub
  '工號
  Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBtn_JobNumber.CheckedChanged
    Me.GroupBox1.Tag = sender.name
  End Sub
  '工程師
  Private Sub RadioBtn2_Engineer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBtn2_Engineer.CheckedChanged
    Me.GroupBox1.Tag = sender.name
  End Sub
  '系統管理員
  Private Sub RadioBtn3_System_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBtn3_System.CheckedChanged
    Me.GroupBox1.Tag = sender.name
  End Sub
  '全部
  Private Sub RadioBtn4_All_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBtn4_All.CheckedChanged
    Me.GroupBox1.Tag = sender.name
  End Sub
End Class
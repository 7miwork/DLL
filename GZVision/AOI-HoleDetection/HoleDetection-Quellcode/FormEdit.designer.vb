<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEdit
  Inherits System.Windows.Forms.Form

  'Form 覆寫 Dispose 以清除元件清單。
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

  '為 Windows Form 設計工具的必要項
  Private components As System.ComponentModel.IContainer

  '注意: 以下為 Windows Form 設計工具所需的程序
  '可以使用 Windows Form 設計工具進行修改。
  '請不要使用程式碼編輯器進行修改。
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.RadioBtn4_All = New System.Windows.Forms.RadioButton
    Me.RadioBtn3_System = New System.Windows.Forms.RadioButton
    Me.RadioBtn2_Engineer = New System.Windows.Forms.RadioButton
    Me.Label2 = New System.Windows.Forms.Label
    Me.TextSearch_BadgeNb = New System.Windows.Forms.TextBox
    Me.RadioBtn_JobNumber = New System.Windows.Forms.RadioButton
    Me.DataGridView = New System.Windows.Forms.DataGridView
    Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.Label1 = New System.Windows.Forms.Label
    Me.TextAdd_BadgeNb = New System.Windows.Forms.TextBox
    Me.TextAdd_Password = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.ComboAdd_Level = New System.Windows.Forms.ComboBox
    Me.BtnAdd = New System.Windows.Forms.Button
    Me.BtnUpdate = New System.Windows.Forms.Button
    Me.BtnDelete = New System.Windows.Forms.Button
    Me.BtnClose = New System.Windows.Forms.Button
    Me.BtnSearch = New System.Windows.Forms.Button
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RadioBtn4_All)
    Me.GroupBox1.Controls.Add(Me.RadioBtn3_System)
    Me.GroupBox1.Controls.Add(Me.RadioBtn2_Engineer)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.TextSearch_BadgeNb)
    Me.GroupBox1.Controls.Add(Me.RadioBtn_JobNumber)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(425, 46)
    Me.GroupBox1.TabIndex = 4
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "工號查詢"
    '
    'RadioBtn4_All
    '
    Me.RadioBtn4_All.AutoSize = True
    Me.RadioBtn4_All.Location = New System.Drawing.Point(337, 20)
    Me.RadioBtn4_All.Name = "RadioBtn4_All"
    Me.RadioBtn4_All.Size = New System.Drawing.Size(47, 16)
    Me.RadioBtn4_All.TabIndex = 4
    Me.RadioBtn4_All.Text = "全部"
    Me.RadioBtn4_All.UseVisualStyleBackColor = True
    '
    'RadioBtn3_System
    '
    Me.RadioBtn3_System.AutoSize = True
    Me.RadioBtn3_System.Location = New System.Drawing.Point(255, 20)
    Me.RadioBtn3_System.Name = "RadioBtn3_System"
    Me.RadioBtn3_System.Size = New System.Drawing.Size(83, 16)
    Me.RadioBtn3_System.TabIndex = 3
    Me.RadioBtn3_System.TabStop = True
    Me.RadioBtn3_System.Text = "系統管理員"
    Me.RadioBtn3_System.UseVisualStyleBackColor = True
    '
    'RadioBtn2_Engineer
    '
    Me.RadioBtn2_Engineer.AutoSize = True
    Me.RadioBtn2_Engineer.Location = New System.Drawing.Point(196, 20)
    Me.RadioBtn2_Engineer.Name = "RadioBtn2_Engineer"
    Me.RadioBtn2_Engineer.Size = New System.Drawing.Size(59, 16)
    Me.RadioBtn2_Engineer.TabIndex = 2
    Me.RadioBtn2_Engineer.TabStop = True
    Me.RadioBtn2_Engineer.Text = "工程師"
    Me.RadioBtn2_Engineer.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(165, 22)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(29, 12)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "級別"
    '
    'TextSearch_BadgeNb
    '
    Me.TextSearch_BadgeNb.BackColor = System.Drawing.SystemColors.Control
    Me.TextSearch_BadgeNb.Location = New System.Drawing.Point(65, 17)
    Me.TextSearch_BadgeNb.Name = "TextSearch_BadgeNb"
    Me.TextSearch_BadgeNb.Size = New System.Drawing.Size(75, 22)
    Me.TextSearch_BadgeNb.TabIndex = 1
    '
    'RadioBtn_JobNumber
    '
    Me.RadioBtn_JobNumber.AutoSize = True
    Me.RadioBtn_JobNumber.Location = New System.Drawing.Point(12, 20)
    Me.RadioBtn_JobNumber.Name = "RadioBtn_JobNumber"
    Me.RadioBtn_JobNumber.Size = New System.Drawing.Size(47, 16)
    Me.RadioBtn_JobNumber.TabIndex = 0
    Me.RadioBtn_JobNumber.TabStop = True
    Me.RadioBtn_JobNumber.Text = "工號"
    Me.RadioBtn_JobNumber.UseVisualStyleBackColor = True
    '
    'DataGridView
    '
    Me.DataGridView.AllowUserToAddRows = False
    Me.DataGridView.AllowUserToDeleteRows = False
    Me.DataGridView.BackgroundColor = System.Drawing.SystemColors.ScrollBar
    Me.DataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.DataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
    Me.DataGridView.Location = New System.Drawing.Point(12, 64)
    Me.DataGridView.MultiSelect = False
    Me.DataGridView.Name = "DataGridView"
    Me.DataGridView.ReadOnly = True
    Me.DataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    Me.DataGridView.RowHeadersVisible = False
    Me.DataGridView.RowTemplate.Height = 16
    Me.DataGridView.RowTemplate.ReadOnly = True
    Me.DataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGridView.Size = New System.Drawing.Size(269, 291)
    Me.DataGridView.TabIndex = 103
    '
    'DataGridViewTextBoxColumn1
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
    Me.DataGridViewTextBoxColumn1.HeaderText = "工號"
    Me.DataGridViewTextBoxColumn1.MaxInputLength = 10
    Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
    Me.DataGridViewTextBoxColumn1.ReadOnly = True
    Me.DataGridViewTextBoxColumn1.Width = 90
    '
    'DataGridViewTextBoxColumn2
    '
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
    Me.DataGridViewTextBoxColumn2.HeaderText = "密碼"
    Me.DataGridViewTextBoxColumn2.MaxInputLength = 10
    Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
    Me.DataGridViewTextBoxColumn2.ReadOnly = True
    Me.DataGridViewTextBoxColumn2.Width = 90
    '
    'DataGridViewTextBoxColumn3
    '
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
    Me.DataGridViewTextBoxColumn3.HeaderText = "級別"
    Me.DataGridViewTextBoxColumn3.MaxInputLength = 10
    Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
    Me.DataGridViewTextBoxColumn3.ReadOnly = True
    Me.DataGridViewTextBoxColumn3.Width = 70
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(291, 80)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(29, 12)
    Me.Label1.TabIndex = 105
    Me.Label1.Text = "工號"
    '
    'TextAdd_BadgeNb
    '
    Me.TextAdd_BadgeNb.Location = New System.Drawing.Point(320, 76)
    Me.TextAdd_BadgeNb.Name = "TextAdd_BadgeNb"
    Me.TextAdd_BadgeNb.Size = New System.Drawing.Size(117, 22)
    Me.TextAdd_BadgeNb.TabIndex = 0
    '
    'TextAdd_Password
    '
    Me.TextAdd_Password.Location = New System.Drawing.Point(320, 104)
    Me.TextAdd_Password.Name = "TextAdd_Password"
    Me.TextAdd_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TextAdd_Password.Size = New System.Drawing.Size(117, 22)
    Me.TextAdd_Password.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(291, 108)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(29, 12)
    Me.Label3.TabIndex = 105
    Me.Label3.Text = "密碼"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(291, 135)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(29, 12)
    Me.Label4.TabIndex = 105
    Me.Label4.Text = "級別"
    '
    'ComboAdd_Level
    '
    Me.ComboAdd_Level.BackColor = System.Drawing.SystemColors.Control
    Me.ComboAdd_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboAdd_Level.FormattingEnabled = True
    Me.ComboAdd_Level.Items.AddRange(New Object() {"工程師", "系統管理員"})
    Me.ComboAdd_Level.Location = New System.Drawing.Point(320, 132)
    Me.ComboAdd_Level.Name = "ComboAdd_Level"
    Me.ComboAdd_Level.Size = New System.Drawing.Size(117, 20)
    Me.ComboAdd_Level.TabIndex = 2
    '
    'BtnAdd
    '
    Me.BtnAdd.BackColor = System.Drawing.SystemColors.Control
    Me.BtnAdd.Location = New System.Drawing.Point(320, 174)
    Me.BtnAdd.Name = "BtnAdd"
    Me.BtnAdd.Size = New System.Drawing.Size(117, 41)
    Me.BtnAdd.TabIndex = 3
    Me.BtnAdd.Text = "新增"
    Me.BtnAdd.UseVisualStyleBackColor = False
    '
    'BtnUpdate
    '
    Me.BtnUpdate.Location = New System.Drawing.Point(287, 409)
    Me.BtnUpdate.Name = "BtnUpdate"
    Me.BtnUpdate.Size = New System.Drawing.Size(38, 27)
    Me.BtnUpdate.TabIndex = 108
    Me.BtnUpdate.Text = "更新"
    Me.BtnUpdate.UseVisualStyleBackColor = True
    Me.BtnUpdate.Visible = False
    '
    'BtnDelete
    '
    Me.BtnDelete.BackColor = System.Drawing.SystemColors.Control
    Me.BtnDelete.Location = New System.Drawing.Point(320, 268)
    Me.BtnDelete.Name = "BtnDelete"
    Me.BtnDelete.Size = New System.Drawing.Size(117, 41)
    Me.BtnDelete.TabIndex = 5
    Me.BtnDelete.Text = "刪除"
    Me.BtnDelete.UseVisualStyleBackColor = False
    '
    'BtnClose
    '
    Me.BtnClose.BackColor = System.Drawing.SystemColors.Control
    Me.BtnClose.Location = New System.Drawing.Point(320, 315)
    Me.BtnClose.Name = "BtnClose"
    Me.BtnClose.Size = New System.Drawing.Size(117, 41)
    Me.BtnClose.TabIndex = 6
    Me.BtnClose.Text = "關閉"
    Me.BtnClose.UseVisualStyleBackColor = False
    '
    'BtnSearch
    '
    Me.BtnSearch.BackColor = System.Drawing.SystemColors.Control
    Me.BtnSearch.Location = New System.Drawing.Point(320, 221)
    Me.BtnSearch.Name = "BtnSearch"
    Me.BtnSearch.Size = New System.Drawing.Size(117, 41)
    Me.BtnSearch.TabIndex = 109
    Me.BtnSearch.Text = "查詢"
    Me.BtnSearch.UseVisualStyleBackColor = False
    '
    'FormEdit
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ControlDark
    Me.ClientSize = New System.Drawing.Size(452, 363)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnSearch)
    Me.Controls.Add(Me.BtnClose)
    Me.Controls.Add(Me.BtnDelete)
    Me.Controls.Add(Me.BtnUpdate)
    Me.Controls.Add(Me.BtnAdd)
    Me.Controls.Add(Me.ComboAdd_Level)
    Me.Controls.Add(Me.TextAdd_Password)
    Me.Controls.Add(Me.TextAdd_BadgeNb)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DataGridView)
    Me.Controls.Add(Me.GroupBox1)
    Me.Name = "FormEdit"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "編輯"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents TextSearch_BadgeNb As System.Windows.Forms.TextBox
  Friend WithEvents RadioBtn_JobNumber As System.Windows.Forms.RadioButton
  Friend WithEvents RadioBtn3_System As System.Windows.Forms.RadioButton
  Friend WithEvents RadioBtn2_Engineer As System.Windows.Forms.RadioButton
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
  Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextAdd_BadgeNb As System.Windows.Forms.TextBox
  Friend WithEvents TextAdd_Password As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ComboAdd_Level As System.Windows.Forms.ComboBox
  Friend WithEvents BtnAdd As System.Windows.Forms.Button
  Friend WithEvents BtnUpdate As System.Windows.Forms.Button
  Friend WithEvents BtnDelete As System.Windows.Forms.Button
  Friend WithEvents BtnClose As System.Windows.Forms.Button
  Friend WithEvents RadioBtn4_All As System.Windows.Forms.RadioButton
  Friend WithEvents BtnSearch As System.Windows.Forms.Button
End Class

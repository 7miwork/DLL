<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLog
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
    Me.TextHistory_FindStart = New System.Windows.Forms.TextBox
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.BtnHistory_FindMessage = New System.Windows.Forms.Button
    Me.TextHistory_FindEnd = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.ListHistory_Message = New System.Windows.Forms.ListBox
    Me.BtnHistory_Exit = New System.Windows.Forms.Button
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TextHistory_FindStart
    '
    Me.TextHistory_FindStart.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextHistory_FindStart.Location = New System.Drawing.Point(90, 33)
    Me.TextHistory_FindStart.Name = "TextHistory_FindStart"
    Me.TextHistory_FindStart.Size = New System.Drawing.Size(89, 26)
    Me.TextHistory_FindStart.TabIndex = 0
    Me.TextHistory_FindStart.Text = "20120522"
    Me.TextHistory_FindStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.BtnHistory_FindMessage)
    Me.GroupBox1.Controls.Add(Me.TextHistory_FindEnd)
    Me.GroupBox1.Controls.Add(Me.TextHistory_FindStart)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Location = New System.Drawing.Point(8, 1)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(399, 84)
    Me.GroupBox1.TabIndex = 1
    Me.GroupBox1.TabStop = False
    '
    'BtnHistory_FindMessage
    '
    Me.BtnHistory_FindMessage.AutoSize = True
    Me.BtnHistory_FindMessage.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnHistory_FindMessage.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnHistory_FindMessage.ForeColor = System.Drawing.Color.Navy
    Me.BtnHistory_FindMessage.Location = New System.Drawing.Point(300, 31)
    Me.BtnHistory_FindMessage.Name = "BtnHistory_FindMessage"
    Me.BtnHistory_FindMessage.Size = New System.Drawing.Size(80, 32)
    Me.BtnHistory_FindMessage.TabIndex = 30
    Me.BtnHistory_FindMessage.Text = "查詢"
    Me.BtnHistory_FindMessage.UseVisualStyleBackColor = False
    '
    'TextHistory_FindEnd
    '
    Me.TextHistory_FindEnd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextHistory_FindEnd.Location = New System.Drawing.Point(206, 33)
    Me.TextHistory_FindEnd.Name = "TextHistory_FindEnd"
    Me.TextHistory_FindEnd.Size = New System.Drawing.Size(89, 26)
    Me.TextHistory_FindEnd.TabIndex = 2
    Me.TextHistory_FindEnd.Text = "20120522"
    Me.TextHistory_FindEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label1.Location = New System.Drawing.Point(17, 37)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(184, 16)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "輸入日期                          ~"
    '
    'ListHistory_Message
    '
    Me.ListHistory_Message.BackColor = System.Drawing.SystemColors.Control
    Me.ListHistory_Message.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.ListHistory_Message.FormattingEnabled = True
    Me.ListHistory_Message.Location = New System.Drawing.Point(8, 92)
    Me.ListHistory_Message.Name = "ListHistory_Message"
    Me.ListHistory_Message.Size = New System.Drawing.Size(1904, 875)
    Me.ListHistory_Message.TabIndex = 2
    '
    'BtnHistory_Exit
    '
    Me.BtnHistory_Exit.AutoSize = True
    Me.BtnHistory_Exit.BackColor = System.Drawing.Color.WhiteSmoke
    Me.BtnHistory_Exit.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnHistory_Exit.ForeColor = System.Drawing.Color.Navy
    Me.BtnHistory_Exit.Location = New System.Drawing.Point(1809, 12)
    Me.BtnHistory_Exit.Name = "BtnHistory_Exit"
    Me.BtnHistory_Exit.Size = New System.Drawing.Size(103, 75)
    Me.BtnHistory_Exit.TabIndex = 31
    Me.BtnHistory_Exit.Text = "回主畫面"
    Me.BtnHistory_Exit.UseVisualStyleBackColor = False
    '
    'FormLog
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ControlDark
    Me.ClientSize = New System.Drawing.Size(1920, 974)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnHistory_Exit)
    Me.Controls.Add(Me.ListHistory_Message)
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.Location = New System.Drawing.Point(7, 90)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FormLog"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "運行記錄"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TextHistory_FindStart As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextHistory_FindEnd As System.Windows.Forms.TextBox
  Friend WithEvents BtnHistory_FindMessage As System.Windows.Forms.Button
  Friend WithEvents ListHistory_Message As System.Windows.Forms.ListBox
  Friend WithEvents BtnHistory_Exit As System.Windows.Forms.Button
End Class

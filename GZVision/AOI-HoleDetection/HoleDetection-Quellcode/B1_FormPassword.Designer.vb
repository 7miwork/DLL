<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B1_FormPassword
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
    Me.TextNewPassword2 = New System.Windows.Forms.TextBox
    Me.TextNewPassword1 = New System.Windows.Forms.TextBox
    Me.TextOldPassword = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.Btn_Cancel = New System.Windows.Forms.Button
    Me.Btn_OK = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'TextNewPassword2
    '
    Me.TextNewPassword2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.TextNewPassword2.Location = New System.Drawing.Point(78, 109)
    Me.TextNewPassword2.Name = "TextNewPassword2"
    Me.TextNewPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TextNewPassword2.Size = New System.Drawing.Size(254, 27)
    Me.TextNewPassword2.TabIndex = 13
    Me.TextNewPassword2.TabStop = False
    Me.TextNewPassword2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'TextNewPassword1
    '
    Me.TextNewPassword1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.TextNewPassword1.Location = New System.Drawing.Point(78, 64)
    Me.TextNewPassword1.Name = "TextNewPassword1"
    Me.TextNewPassword1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TextNewPassword1.Size = New System.Drawing.Size(254, 27)
    Me.TextNewPassword1.TabIndex = 12
    Me.TextNewPassword1.TabStop = False
    Me.TextNewPassword1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'TextOldPassword
    '
    Me.TextOldPassword.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.TextOldPassword.Location = New System.Drawing.Point(78, 19)
    Me.TextOldPassword.Name = "TextOldPassword"
    Me.TextOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TextOldPassword.Size = New System.Drawing.Size(254, 27)
    Me.TextOldPassword.TabIndex = 11
    Me.TextOldPassword.TabStop = False
    Me.TextOldPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label3.Location = New System.Drawing.Point(22, 114)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 16)
    Me.Label3.TabIndex = 18
    Me.Label3.Text = "再確認"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label2.Location = New System.Drawing.Point(22, 69)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 16)
    Me.Label2.TabIndex = 17
    Me.Label2.Text = "新密碼"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label1.Location = New System.Drawing.Point(22, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 16
    Me.Label1.Text = "舊密碼"
    '
    'Btn_Cancel
    '
    Me.Btn_Cancel.BackColor = System.Drawing.SystemColors.Control
    Me.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Btn_Cancel.Location = New System.Drawing.Point(210, 169)
    Me.Btn_Cancel.Name = "Btn_Cancel"
    Me.Btn_Cancel.Size = New System.Drawing.Size(94, 38)
    Me.Btn_Cancel.TabIndex = 15
    Me.Btn_Cancel.Text = "取消"
    Me.Btn_Cancel.UseVisualStyleBackColor = False
    '
    'Btn_OK
    '
    Me.Btn_OK.BackColor = System.Drawing.SystemColors.Control
    Me.Btn_OK.Location = New System.Drawing.Point(100, 169)
    Me.Btn_OK.Name = "Btn_OK"
    Me.Btn_OK.Size = New System.Drawing.Size(94, 38)
    Me.Btn_OK.TabIndex = 14
    Me.Btn_OK.Text = "確定"
    Me.Btn_OK.UseVisualStyleBackColor = False
    '
    'B1_FormPassword
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ControlDark
    Me.ClientSize = New System.Drawing.Size(384, 219)
    Me.Controls.Add(Me.TextNewPassword2)
    Me.Controls.Add(Me.TextNewPassword1)
    Me.Controls.Add(Me.TextOldPassword)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Btn_Cancel)
    Me.Controls.Add(Me.Btn_OK)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "B1_FormPassword"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "更改密碼"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TextNewPassword2 As System.Windows.Forms.TextBox
  Friend WithEvents TextNewPassword1 As System.Windows.Forms.TextBox
  Friend WithEvents TextOldPassword As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
  Friend WithEvents Btn_OK As System.Windows.Forms.Button

End Class

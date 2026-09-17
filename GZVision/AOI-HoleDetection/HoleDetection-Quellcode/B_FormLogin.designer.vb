<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_FormLogin
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(B_FormLogin))
    Me.BtnResetPassword = New System.Windows.Forms.Button
    Me.BtnShowPassword = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.BtnLevel_Edit = New System.Windows.Forms.Button
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.BtnChangePassword = New System.Windows.Forms.Button
    Me.RadioBtn1_OP = New System.Windows.Forms.RadioButton
    Me.RadioBtn2_Engineer = New System.Windows.Forms.RadioButton
    Me.RadioBtn3_System = New System.Windows.Forms.RadioButton
    Me.GroupBoxInput = New System.Windows.Forms.GroupBox
    Me.TextLogin_BadgeNb = New System.Windows.Forms.TextBox
    Me.TextLogin_Password = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.BtnLevel_Login = New System.Windows.Forms.Button
    Me.BtnLevel_Cancel = New System.Windows.Forms.Button
    Me.Panel1.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBoxInput.SuspendLayout()
    Me.SuspendLayout()
    '
    'BtnResetPassword
    '
    Me.BtnResetPassword.Location = New System.Drawing.Point(85, 166)
    Me.BtnResetPassword.Name = "BtnResetPassword"
    Me.BtnResetPassword.Size = New System.Drawing.Size(80, 23)
    Me.BtnResetPassword.TabIndex = 18
    Me.BtnResetPassword.Text = "初始密碼"
    Me.BtnResetPassword.UseVisualStyleBackColor = True
    '
    'BtnShowPassword
    '
    Me.BtnShowPassword.Location = New System.Drawing.Point(6, 166)
    Me.BtnShowPassword.Name = "BtnShowPassword"
    Me.BtnShowPassword.Size = New System.Drawing.Size(80, 23)
    Me.BtnShowPassword.TabIndex = 17
    Me.BtnShowPassword.Text = "顯示密碼"
    Me.BtnShowPassword.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Panel1.Controls.Add(Me.BtnLevel_Edit)
    Me.Panel1.Controls.Add(Me.GroupBox1)
    Me.Panel1.Controls.Add(Me.GroupBoxInput)
    Me.Panel1.Controls.Add(Me.BtnLevel_Login)
    Me.Panel1.Controls.Add(Me.BtnLevel_Cancel)
    Me.Panel1.Location = New System.Drawing.Point(5, 5)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(390, 160)
    Me.Panel1.TabIndex = 16
    '
    'BtnLevel_Edit
    '
    Me.BtnLevel_Edit.BackColor = System.Drawing.SystemColors.Control
    Me.BtnLevel_Edit.Enabled = False
    Me.BtnLevel_Edit.Location = New System.Drawing.Point(152, 111)
    Me.BtnLevel_Edit.Name = "BtnLevel_Edit"
    Me.BtnLevel_Edit.Size = New System.Drawing.Size(74, 38)
    Me.BtnLevel_Edit.TabIndex = 1
    Me.BtnLevel_Edit.Text = "編輯"
    Me.BtnLevel_Edit.UseVisualStyleBackColor = False
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.BtnChangePassword)
    Me.GroupBox1.Controls.Add(Me.RadioBtn1_OP)
    Me.GroupBox1.Controls.Add(Me.RadioBtn2_Engineer)
    Me.GroupBox1.Controls.Add(Me.RadioBtn3_System)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(135, 139)
    Me.GroupBox1.TabIndex = 9
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "選擇級別"
    '
    'BtnChangePassword
    '
    Me.BtnChangePassword.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.BtnChangePassword.Enabled = False
    Me.BtnChangePassword.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnChangePassword.Location = New System.Drawing.Point(17, 185)
    Me.BtnChangePassword.Name = "BtnChangePassword"
    Me.BtnChangePassword.Size = New System.Drawing.Size(130, 42)
    Me.BtnChangePassword.TabIndex = 15
    Me.BtnChangePassword.TabStop = False
    Me.BtnChangePassword.Text = "更改密碼"
    Me.BtnChangePassword.UseVisualStyleBackColor = True
    '
    'RadioBtn1_OP
    '
    Me.RadioBtn1_OP.AutoSize = True
    Me.RadioBtn1_OP.Location = New System.Drawing.Point(23, 26)
    Me.RadioBtn1_OP.Name = "RadioBtn1_OP"
    Me.RadioBtn1_OP.Size = New System.Drawing.Size(59, 16)
    Me.RadioBtn1_OP.TabIndex = 0
    Me.RadioBtn1_OP.Tag = "作業員"
    Me.RadioBtn1_OP.Text = "作業員"
    Me.RadioBtn1_OP.UseVisualStyleBackColor = True
    '
    'RadioBtn2_Engineer
    '
    Me.RadioBtn2_Engineer.AutoSize = True
    Me.RadioBtn2_Engineer.Location = New System.Drawing.Point(23, 64)
    Me.RadioBtn2_Engineer.Name = "RadioBtn2_Engineer"
    Me.RadioBtn2_Engineer.Size = New System.Drawing.Size(59, 16)
    Me.RadioBtn2_Engineer.TabIndex = 1
    Me.RadioBtn2_Engineer.Tag = "工程師"
    Me.RadioBtn2_Engineer.Text = "工程師"
    Me.RadioBtn2_Engineer.UseVisualStyleBackColor = True
    '
    'RadioBtn3_System
    '
    Me.RadioBtn3_System.AutoSize = True
    Me.RadioBtn3_System.Location = New System.Drawing.Point(23, 104)
    Me.RadioBtn3_System.Name = "RadioBtn3_System"
    Me.RadioBtn3_System.Size = New System.Drawing.Size(83, 16)
    Me.RadioBtn3_System.TabIndex = 2
    Me.RadioBtn3_System.Tag = "系統管理員"
    Me.RadioBtn3_System.Text = "系統管理員"
    Me.RadioBtn3_System.UseVisualStyleBackColor = True
    '
    'GroupBoxInput
    '
    Me.GroupBoxInput.Controls.Add(Me.TextLogin_BadgeNb)
    Me.GroupBoxInput.Controls.Add(Me.TextLogin_Password)
    Me.GroupBoxInput.Controls.Add(Me.Label4)
    Me.GroupBoxInput.Controls.Add(Me.Label3)
    Me.GroupBoxInput.Enabled = False
    Me.GroupBoxInput.Location = New System.Drawing.Point(153, 10)
    Me.GroupBoxInput.Name = "GroupBoxInput"
    Me.GroupBoxInput.Size = New System.Drawing.Size(221, 84)
    Me.GroupBoxInput.TabIndex = 0
    Me.GroupBoxInput.TabStop = False
    Me.GroupBoxInput.Text = "輸入工號及密碼"
    '
    'TextLogin_BadgeNb
    '
    Me.TextLogin_BadgeNb.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextLogin_BadgeNb.Location = New System.Drawing.Point(58, 20)
    Me.TextLogin_BadgeNb.Name = "TextLogin_BadgeNb"
    Me.TextLogin_BadgeNb.Size = New System.Drawing.Size(157, 22)
    Me.TextLogin_BadgeNb.TabIndex = 0
    Me.TextLogin_BadgeNb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'TextLogin_Password
    '
    Me.TextLogin_Password.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextLogin_Password.Location = New System.Drawing.Point(58, 48)
    Me.TextLogin_Password.Name = "TextLogin_Password"
    Me.TextLogin_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TextLogin_Password.Size = New System.Drawing.Size(157, 22)
    Me.TextLogin_Password.TabIndex = 1
    Me.TextLogin_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(9, 25)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(29, 12)
    Me.Label4.TabIndex = 111
    Me.Label4.Text = "工號"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Label3.Location = New System.Drawing.Point(9, 52)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(29, 12)
    Me.Label3.TabIndex = 110
    Me.Label3.Text = "密碼"
    '
    'BtnLevel_Login
    '
    Me.BtnLevel_Login.BackColor = System.Drawing.SystemColors.Control
    Me.BtnLevel_Login.Enabled = False
    Me.BtnLevel_Login.Location = New System.Drawing.Point(227, 111)
    Me.BtnLevel_Login.Name = "BtnLevel_Login"
    Me.BtnLevel_Login.Size = New System.Drawing.Size(74, 38)
    Me.BtnLevel_Login.TabIndex = 2
    Me.BtnLevel_Login.Text = "登入"
    Me.BtnLevel_Login.UseVisualStyleBackColor = False
    '
    'BtnLevel_Cancel
    '
    Me.BtnLevel_Cancel.BackColor = System.Drawing.SystemColors.Control
    Me.BtnLevel_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.BtnLevel_Cancel.Location = New System.Drawing.Point(302, 111)
    Me.BtnLevel_Cancel.Name = "BtnLevel_Cancel"
    Me.BtnLevel_Cancel.Size = New System.Drawing.Size(74, 38)
    Me.BtnLevel_Cancel.TabIndex = 3
    Me.BtnLevel_Cancel.Text = "取消"
    Me.BtnLevel_Cancel.UseVisualStyleBackColor = False
    '
    'B_FormLogin
    '
    Me.AcceptButton = Me.BtnLevel_Login
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ControlDark
    Me.CancelButton = Me.BtnLevel_Cancel
    Me.ClientSize = New System.Drawing.Size(403, 169)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnResetPassword)
    Me.Controls.Add(Me.BtnShowPassword)
    Me.Controls.Add(Me.Panel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "B_FormLogin"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "登入"
    Me.Panel1.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBoxInput.ResumeLayout(False)
    Me.GroupBoxInput.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents BtnResetPassword As System.Windows.Forms.Button
  Friend WithEvents BtnShowPassword As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents BtnChangePassword As System.Windows.Forms.Button
  Friend WithEvents RadioBtn1_OP As System.Windows.Forms.RadioButton
  Friend WithEvents RadioBtn2_Engineer As System.Windows.Forms.RadioButton
  Friend WithEvents RadioBtn3_System As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBoxInput As System.Windows.Forms.GroupBox
  Friend WithEvents TextLogin_Password As System.Windows.Forms.TextBox
  Friend WithEvents BtnLevel_Cancel As System.Windows.Forms.Button
  Friend WithEvents BtnLevel_Login As System.Windows.Forms.Button
  Friend WithEvents BtnLevel_Edit As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TextLogin_BadgeNb As System.Windows.Forms.TextBox

End Class

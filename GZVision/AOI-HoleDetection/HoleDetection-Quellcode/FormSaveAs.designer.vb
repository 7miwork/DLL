<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSaveAs
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
    Me.TextSaveAs_FileName = New System.Windows.Forms.TextBox
    Me.BtnSaveAs_OK = New System.Windows.Forms.Button
    Me.BtnSaveAs_Cancel = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'TextSaveAs_FileName
    '
    Me.TextSaveAs_FileName.Location = New System.Drawing.Point(12, 20)
    Me.TextSaveAs_FileName.Name = "TextSaveAs_FileName"
    Me.TextSaveAs_FileName.Size = New System.Drawing.Size(303, 22)
    Me.TextSaveAs_FileName.TabIndex = 2
    '
    'BtnSaveAs_OK
    '
    Me.BtnSaveAs_OK.Location = New System.Drawing.Point(159, 62)
    Me.BtnSaveAs_OK.Name = "BtnSaveAs_OK"
    Me.BtnSaveAs_OK.Size = New System.Drawing.Size(75, 23)
    Me.BtnSaveAs_OK.TabIndex = 3
    Me.BtnSaveAs_OK.Text = "確定"
    Me.BtnSaveAs_OK.UseVisualStyleBackColor = True
    '
    'BtnSaveAs_Cancel
    '
    Me.BtnSaveAs_Cancel.Location = New System.Drawing.Point(240, 62)
    Me.BtnSaveAs_Cancel.Name = "BtnSaveAs_Cancel"
    Me.BtnSaveAs_Cancel.Size = New System.Drawing.Size(75, 23)
    Me.BtnSaveAs_Cancel.TabIndex = 4
    Me.BtnSaveAs_Cancel.Text = "取消"
    Me.BtnSaveAs_Cancel.UseVisualStyleBackColor = True
    '
    'FormSaveAs
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(324, 94)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnSaveAs_Cancel)
    Me.Controls.Add(Me.BtnSaveAs_OK)
    Me.Controls.Add(Me.TextSaveAs_FileName)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FormSaveAs"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "另存產品檔"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TextSaveAs_FileName As System.Windows.Forms.TextBox
  Friend WithEvents BtnSaveAs_OK As System.Windows.Forms.Button
  Friend WithEvents BtnSaveAs_Cancel As System.Windows.Forms.Button

End Class

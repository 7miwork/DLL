<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_KeyinBarcode
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
    Me.Btn_OK = New System.Windows.Forms.Button
    Me.Btn_Cancel = New System.Windows.Forms.Button
    Me.TextBarcode = New System.Windows.Forms.TextBox
    Me.SuspendLayout()
    '
    'Btn_OK
    '
    Me.Btn_OK.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Btn_OK.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Btn_OK.Location = New System.Drawing.Point(220, 81)
    Me.Btn_OK.Name = "Btn_OK"
    Me.Btn_OK.Size = New System.Drawing.Size(80, 34)
    Me.Btn_OK.TabIndex = 0
    Me.Btn_OK.Text = "確定"
    '
    'Btn_Cancel
    '
    Me.Btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Btn_Cancel.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Btn_Cancel.Location = New System.Drawing.Point(306, 81)
    Me.Btn_Cancel.Name = "Btn_Cancel"
    Me.Btn_Cancel.Size = New System.Drawing.Size(80, 34)
    Me.Btn_Cancel.TabIndex = 1
    Me.Btn_Cancel.Text = "取消"
    '
    'TextBarcode
    '
    Me.TextBarcode.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold)
    Me.TextBarcode.Location = New System.Drawing.Point(12, 32)
    Me.TextBarcode.Name = "TextBarcode"
    Me.TextBarcode.Size = New System.Drawing.Size(600, 39)
    Me.TextBarcode.TabIndex = 2
    '
    'Dialog_KeyinBarcode
    '
    Me.AcceptButton = Me.Btn_OK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Btn_Cancel
    Me.ClientSize = New System.Drawing.Size(623, 132)
    Me.Controls.Add(Me.TextBarcode)
    Me.Controls.Add(Me.Btn_Cancel)
    Me.Controls.Add(Me.Btn_OK)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Dialog_KeyinBarcode"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "手動掃描條碼"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Btn_OK As System.Windows.Forms.Button
  Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
  Friend WithEvents TextBarcode As System.Windows.Forms.TextBox

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_FormFile
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(C_FormFile))
    Me.Label1 = New System.Windows.Forms.Label
    Me.PanelProduct = New System.Windows.Forms.Panel
    Me.ListProductFolder = New System.Windows.Forms.ListBox
    Me.DirListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
    Me.FileListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
    Me.BtnOpen = New System.Windows.Forms.Button
    Me.BtnDelete = New System.Windows.Forms.Button
    Me.BtnClose = New System.Windows.Forms.Button
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
    Me.TextBuffer = New System.Windows.Forms.TextBox
    Me.PanelProduct.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label1.Location = New System.Drawing.Point(13, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(752, 23)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "檔案產品列表"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'PanelProduct
    '
    Me.PanelProduct.BackColor = System.Drawing.SystemColors.ControlDark
    Me.PanelProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.PanelProduct.Controls.Add(Me.ListProductFolder)
    Me.PanelProduct.Controls.Add(Me.Label1)
    Me.PanelProduct.Controls.Add(Me.DirListBox1)
    Me.PanelProduct.Controls.Add(Me.FileListBox1)
    Me.PanelProduct.Location = New System.Drawing.Point(5, 4)
    Me.PanelProduct.Name = "PanelProduct"
    Me.PanelProduct.Size = New System.Drawing.Size(780, 442)
    Me.PanelProduct.TabIndex = 3
    '
    'ListProductFolder
    '
    Me.ListProductFolder.BackColor = System.Drawing.SystemColors.Control
    Me.ListProductFolder.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.ListProductFolder.FormattingEnabled = True
    Me.ListProductFolder.ItemHeight = 24
    Me.ListProductFolder.Location = New System.Drawing.Point(12, 40)
    Me.ListProductFolder.Name = "ListProductFolder"
    Me.ListProductFolder.Size = New System.Drawing.Size(753, 388)
    Me.ListProductFolder.TabIndex = 6
    '
    'DirListBox1
    '
    Me.DirListBox1.FormattingEnabled = True
    Me.DirListBox1.IntegralHeight = False
    Me.DirListBox1.Location = New System.Drawing.Point(12, 43)
    Me.DirListBox1.Name = "DirListBox1"
    Me.DirListBox1.Size = New System.Drawing.Size(753, 78)
    Me.DirListBox1.TabIndex = 5
    '
    'FileListBox1
    '
    Me.FileListBox1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FileListBox1.FormattingEnabled = True
    Me.FileListBox1.Location = New System.Drawing.Point(12, 43)
    Me.FileListBox1.Name = "FileListBox1"
    Me.FileListBox1.Pattern = "*.ccd"
    Me.FileListBox1.Size = New System.Drawing.Size(753, 340)
    Me.FileListBox1.TabIndex = 4
    '
    'BtnOpen
    '
    Me.BtnOpen.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnOpen.Image = CType(resources.GetObject("BtnOpen.Image"), System.Drawing.Image)
    Me.BtnOpen.Location = New System.Drawing.Point(567, 449)
    Me.BtnOpen.Name = "BtnOpen"
    Me.BtnOpen.Size = New System.Drawing.Size(99, 43)
    Me.BtnOpen.TabIndex = 4
    Me.BtnOpen.Text = "開啟檔案"
    Me.BtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnOpen.UseVisualStyleBackColor = True
    '
    'BtnDelete
    '
    Me.BtnDelete.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
    Me.BtnDelete.Location = New System.Drawing.Point(462, 449)
    Me.BtnDelete.Name = "BtnDelete"
    Me.BtnDelete.Size = New System.Drawing.Size(99, 43)
    Me.BtnDelete.TabIndex = 7
    Me.BtnDelete.Text = "刪除檔案"
    Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnDelete.UseVisualStyleBackColor = True
    '
    'BtnClose
    '
    Me.BtnClose.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
    Me.BtnClose.Location = New System.Drawing.Point(673, 449)
    Me.BtnClose.Name = "BtnClose"
    Me.BtnClose.Size = New System.Drawing.Size(99, 43)
    Me.BtnClose.TabIndex = 8
    Me.BtnClose.Text = "  關 閉"
    Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnClose.UseVisualStyleBackColor = True
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.Filter = "產品檔(*.CMI)|*.CMI"
    '
    'SaveFileDialog1
    '
    Me.SaveFileDialog1.Filter = "產品檔(*.CMI)|*.CMI"
    '
    'TextBuffer
    '
    Me.TextBuffer.Location = New System.Drawing.Point(197, 520)
    Me.TextBuffer.Name = "TextBuffer"
    Me.TextBuffer.Size = New System.Drawing.Size(100, 22)
    Me.TextBuffer.TabIndex = 9
    Me.TextBuffer.Visible = False
    '
    'C_FormFile
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ControlDark
    Me.ClientSize = New System.Drawing.Size(788, 497)
    Me.Controls.Add(Me.TextBuffer)
    Me.Controls.Add(Me.BtnClose)
    Me.Controls.Add(Me.BtnDelete)
    Me.Controls.Add(Me.BtnOpen)
    Me.Controls.Add(Me.PanelProduct)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "C_FormFile"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "產品操作"
    Me.PanelProduct.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents PanelProduct As System.Windows.Forms.Panel
  Friend WithEvents BtnOpen As System.Windows.Forms.Button
  Friend WithEvents BtnDelete As System.Windows.Forms.Button
  Friend WithEvents BtnClose As System.Windows.Forms.Button
  Friend WithEvents FileListBox1 As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
  Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents TextBuffer As System.Windows.Forms.TextBox
  Friend WithEvents DirListBox1 As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
  Friend WithEvents ListProductFolder As System.Windows.Forms.ListBox

End Class

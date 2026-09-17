<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogLoadNgImage
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogLoadNgImage))
    Me.BtnClose = New System.Windows.Forms.Button
    Me.BtnDelete = New System.Windows.Forms.Button
    Me.BtnOpen = New System.Windows.Forms.Button
    Me.PanelProduct = New System.Windows.Forms.Panel
    Me.ListNgImage_Folder = New System.Windows.Forms.ListBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.DirListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox
    Me.FileListBox1 = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
    Me.List_NgImage_File = New System.Windows.Forms.ListBox
    Me.FileList_NgImage = New Microsoft.VisualBasic.Compatibility.VB6.FileListBox
    Me.PanelProduct.SuspendLayout()
    Me.SuspendLayout()
    '
    'BtnClose
    '
    Me.BtnClose.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnClose.Image = CType(resources.GetObject("BtnClose.Image"), System.Drawing.Image)
    Me.BtnClose.Location = New System.Drawing.Point(1125, 449)
    Me.BtnClose.Name = "BtnClose"
    Me.BtnClose.Size = New System.Drawing.Size(99, 43)
    Me.BtnClose.TabIndex = 12
    Me.BtnClose.Text = "  關 閉"
    Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnClose.UseVisualStyleBackColor = True
    '
    'BtnDelete
    '
    Me.BtnDelete.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
    Me.BtnDelete.Location = New System.Drawing.Point(914, 449)
    Me.BtnDelete.Name = "BtnDelete"
    Me.BtnDelete.Size = New System.Drawing.Size(99, 43)
    Me.BtnDelete.TabIndex = 11
    Me.BtnDelete.Text = "刪除檔案"
    Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnDelete.UseVisualStyleBackColor = True
    '
    'BtnOpen
    '
    Me.BtnOpen.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.BtnOpen.Image = CType(resources.GetObject("BtnOpen.Image"), System.Drawing.Image)
    Me.BtnOpen.Location = New System.Drawing.Point(1019, 449)
    Me.BtnOpen.Name = "BtnOpen"
    Me.BtnOpen.Size = New System.Drawing.Size(99, 43)
    Me.BtnOpen.TabIndex = 10
    Me.BtnOpen.Text = "開啟檔案"
    Me.BtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
    Me.BtnOpen.UseVisualStyleBackColor = True
    '
    'PanelProduct
    '
    Me.PanelProduct.BackColor = System.Drawing.SystemColors.ControlDark
    Me.PanelProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.PanelProduct.Controls.Add(Me.FileList_NgImage)
    Me.PanelProduct.Controls.Add(Me.List_NgImage_File)
    Me.PanelProduct.Controls.Add(Me.ListNgImage_Folder)
    Me.PanelProduct.Controls.Add(Me.Label1)
    Me.PanelProduct.Controls.Add(Me.DirListBox1)
    Me.PanelProduct.Controls.Add(Me.FileListBox1)
    Me.PanelProduct.Location = New System.Drawing.Point(2, 4)
    Me.PanelProduct.Name = "PanelProduct"
    Me.PanelProduct.Size = New System.Drawing.Size(1228, 442)
    Me.PanelProduct.TabIndex = 9
    '
    'ListNgImage_Folder
    '
    Me.ListNgImage_Folder.BackColor = System.Drawing.SystemColors.Control
    Me.ListNgImage_Folder.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.ListNgImage_Folder.FormattingEnabled = True
    Me.ListNgImage_Folder.ItemHeight = 24
    Me.ListNgImage_Folder.Location = New System.Drawing.Point(12, 40)
    Me.ListNgImage_Folder.Name = "ListNgImage_Folder"
    Me.ListNgImage_Folder.Size = New System.Drawing.Size(456, 388)
    Me.ListNgImage_Folder.TabIndex = 6
    '
    'Label1
    '
    Me.Label1.BackColor = System.Drawing.SystemColors.Control
    Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Label1.Location = New System.Drawing.Point(13, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(752, 23)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "NG圖檔案列表"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'DirListBox1
    '
    Me.DirListBox1.FormattingEnabled = True
    Me.DirListBox1.IntegralHeight = False
    Me.DirListBox1.Location = New System.Drawing.Point(12, 43)
    Me.DirListBox1.Name = "DirListBox1"
    Me.DirListBox1.Size = New System.Drawing.Size(456, 78)
    Me.DirListBox1.TabIndex = 5
    '
    'FileListBox1
    '
    Me.FileListBox1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FileListBox1.FormattingEnabled = True
    Me.FileListBox1.Location = New System.Drawing.Point(12, 43)
    Me.FileListBox1.Name = "FileListBox1"
    Me.FileListBox1.Pattern = "*.ccd"
    Me.FileListBox1.Size = New System.Drawing.Size(456, 364)
    Me.FileListBox1.TabIndex = 4
    '
    'List_NgImage_File
    '
    Me.List_NgImage_File.BackColor = System.Drawing.SystemColors.Control
    Me.List_NgImage_File.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold)
    Me.List_NgImage_File.FormattingEnabled = True
    Me.List_NgImage_File.ItemHeight = 24
    Me.List_NgImage_File.Location = New System.Drawing.Point(474, 40)
    Me.List_NgImage_File.Name = "List_NgImage_File"
    Me.List_NgImage_File.Size = New System.Drawing.Size(746, 388)
    Me.List_NgImage_File.TabIndex = 7
    '
    'FileList_NgImage
    '
    Me.FileList_NgImage.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FileList_NgImage.FormattingEnabled = True
    Me.FileList_NgImage.Location = New System.Drawing.Point(764, 40)
    Me.FileList_NgImage.Name = "FileList_NgImage"
    Me.FileList_NgImage.Pattern = "*.png"
    Me.FileList_NgImage.Size = New System.Drawing.Size(456, 388)
    Me.FileList_NgImage.TabIndex = 8
    '
    'DialogLoadNgImage
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ControlDark
    Me.ClientSize = New System.Drawing.Size(1235, 497)
    Me.Controls.Add(Me.BtnClose)
    Me.Controls.Add(Me.BtnDelete)
    Me.Controls.Add(Me.BtnOpen)
    Me.Controls.Add(Me.PanelProduct)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "DialogLoadNgImage"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "載入NG圖"
    Me.PanelProduct.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents BtnClose As System.Windows.Forms.Button
  Friend WithEvents BtnDelete As System.Windows.Forms.Button
  Friend WithEvents BtnOpen As System.Windows.Forms.Button
  Friend WithEvents PanelProduct As System.Windows.Forms.Panel
  Friend WithEvents ListNgImage_Folder As System.Windows.Forms.ListBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DirListBox1 As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
  Friend WithEvents FileListBox1 As Microsoft.VisualBasic.Compatibility.VB6.FileListBox
  Friend WithEvents List_NgImage_File As System.Windows.Forms.ListBox
  Friend WithEvents FileList_NgImage As Microsoft.VisualBasic.Compatibility.VB6.FileListBox

End Class

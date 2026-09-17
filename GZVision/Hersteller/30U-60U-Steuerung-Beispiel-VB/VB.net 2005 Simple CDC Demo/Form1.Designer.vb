<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.lstCOMPorts = New System.Windows.Forms.ComboBox()
        Me.txtDataReceived = New System.Windows.Forms.TextBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ValText1 = New System.Windows.Forms.TextBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ValText4 = New System.Windows.Forms.TextBox()
        Me.ValText3 = New System.Windows.Forms.TextBox()
        Me.ValText2 = New System.Windows.Forms.TextBox()
        Me.LaBar4 = New System.Windows.Forms.HScrollBar()
        Me.LaBar3 = New System.Windows.Forms.HScrollBar()
        Me.LaBar2 = New System.Windows.Forms.HScrollBar()
        Me.LaBar1 = New System.Windows.Forms.HScrollBar()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.檔案 = New System.Windows.Forms.ToolStripMenuItem()
        Me.開啟新檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.開啟 = New System.Windows.Forms.ToolStripMenuItem()
        Me.儲存 = New System.Windows.Forms.ToolStripMenuItem()
        Me.另存新檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Fileaddress = New System.Windows.Forms.TextBox()
        Me.Clear_button = New System.Windows.Forms.Button()
        Me.Timer5 = New System.Windows.Forms.Timer(Me.components)
        Me.Now_BRG = New System.Windows.Forms.ComboBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnConnect.Location = New System.Drawing.Point(308, 56)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(67, 21)
        Me.btnConnect.TabIndex = 3
        Me.btnConnect.Text = "連結通訊"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'lstCOMPorts
        '
        Me.lstCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lstCOMPorts.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lstCOMPorts.FormattingEnabled = True
        Me.lstCOMPorts.Location = New System.Drawing.Point(286, 29)
        Me.lstCOMPorts.Name = "lstCOMPorts"
        Me.lstCOMPorts.Size = New System.Drawing.Size(89, 20)
        Me.lstCOMPorts.TabIndex = 2
        '
        'txtDataReceived
        '
        Me.txtDataReceived.BackColor = System.Drawing.SystemColors.Menu
        Me.txtDataReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDataReceived.Font = New System.Drawing.Font("新細明體", 8.139131!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDataReceived.Location = New System.Drawing.Point(10, 31)
        Me.txtDataReceived.Multiline = True
        Me.txtDataReceived.Name = "txtDataReceived"
        Me.txtDataReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDataReceived.Size = New System.Drawing.Size(270, 125)
        Me.txtDataReceived.TabIndex = 12
        '
        'SerialPort1
        '
        Me.SerialPort1.DtrEnable = True
        Me.SerialPort1.ReadTimeout = 20
        Me.SerialPort1.WriteTimeout = 10
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'ValText1
        '
        Me.ValText1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ValText1.Location = New System.Drawing.Point(324, 3)
        Me.ValText1.Name = "ValText1"
        Me.ValText1.ShortcutsEnabled = False
        Me.ValText1.Size = New System.Drawing.Size(40, 23)
        Me.ValText1.TabIndex = 2
        Me.ValText1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer2
        '
        Me.Timer2.Interval = 5000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 12)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "CH2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 12)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "CH1"
        '
        'Timer4
        '
        Me.Timer4.Enabled = True
        Me.Timer4.Interval = 500
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ValText4)
        Me.Panel1.Controls.Add(Me.ValText3)
        Me.Panel1.Controls.Add(Me.ValText2)
        Me.Panel1.Controls.Add(Me.LaBar4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LaBar3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LaBar2)
        Me.Panel1.Controls.Add(Me.LaBar1)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.ValText1)
        Me.Panel1.Location = New System.Drawing.Point(10, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(375, 111)
        Me.Panel1.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 12)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "CH4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 12)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "CH3"
        '
        'ValText4
        '
        Me.ValText4.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ValText4.Location = New System.Drawing.Point(324, 80)
        Me.ValText4.Name = "ValText4"
        Me.ValText4.Size = New System.Drawing.Size(40, 23)
        Me.ValText4.TabIndex = 5
        Me.ValText4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValText3
        '
        Me.ValText3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ValText3.Location = New System.Drawing.Point(324, 54)
        Me.ValText3.Name = "ValText3"
        Me.ValText3.Size = New System.Drawing.Size(40, 23)
        Me.ValText3.TabIndex = 4
        Me.ValText3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ValText2
        '
        Me.ValText2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ValText2.Location = New System.Drawing.Point(324, 28)
        Me.ValText2.Name = "ValText2"
        Me.ValText2.Size = New System.Drawing.Size(40, 23)
        Me.ValText2.TabIndex = 3
        Me.ValText2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LaBar4
        '
        Me.LaBar4.LargeChange = 1
        Me.LaBar4.Location = New System.Drawing.Point(36, 81)
        Me.LaBar4.Maximum = 255
        Me.LaBar4.Name = "LaBar4"
        Me.LaBar4.Size = New System.Drawing.Size(285, 22)
        Me.LaBar4.TabIndex = 9
        Me.LaBar4.TabStop = True
        '
        'LaBar3
        '
        Me.LaBar3.LargeChange = 1
        Me.LaBar3.Location = New System.Drawing.Point(36, 55)
        Me.LaBar3.Maximum = 255
        Me.LaBar3.Name = "LaBar3"
        Me.LaBar3.Size = New System.Drawing.Size(285, 22)
        Me.LaBar3.TabIndex = 8
        Me.LaBar3.TabStop = True
        '
        'LaBar2
        '
        Me.LaBar2.LargeChange = 1
        Me.LaBar2.Location = New System.Drawing.Point(36, 29)
        Me.LaBar2.Maximum = 255
        Me.LaBar2.Name = "LaBar2"
        Me.LaBar2.Size = New System.Drawing.Size(285, 22)
        Me.LaBar2.TabIndex = 7
        Me.LaBar2.TabStop = True
        '
        'LaBar1
        '
        Me.LaBar1.LargeChange = 1
        Me.LaBar1.Location = New System.Drawing.Point(36, 3)
        Me.LaBar1.Maximum = 255
        Me.LaBar1.Name = "LaBar1"
        Me.LaBar1.Size = New System.Drawing.Size(285, 22)
        Me.LaBar1.TabIndex = 6
        Me.LaBar1.TabStop = True
        '
        'btnClose
        '
        Me.btnClose.Enabled = False
        Me.btnClose.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnClose.Location = New System.Drawing.Point(15, 133)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(57, 21)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "關閉"
        Me.btnClose.UseVisualStyleBackColor = True
        Me.btnClose.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.檔案})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(387, 24)
        Me.MenuStrip1.TabIndex = 67
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '檔案
        '
        Me.檔案.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.開啟新檔ToolStripMenuItem, Me.開啟, Me.儲存, Me.另存新檔ToolStripMenuItem})
        Me.檔案.Name = "檔案"
        Me.檔案.Size = New System.Drawing.Size(71, 20)
        Me.檔案.Text = "檔案(File)"
        '
        '開啟新檔ToolStripMenuItem
        '
        Me.開啟新檔ToolStripMenuItem.Name = "開啟新檔ToolStripMenuItem"
        Me.開啟新檔ToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.開啟新檔ToolStripMenuItem.Text = "開啟新檔(New)"
        '
        '開啟
        '
        Me.開啟.Name = "開啟"
        Me.開啟.Size = New System.Drawing.Size(175, 22)
        Me.開啟.Text = "開啟(Open)"
        '
        '儲存
        '
        Me.儲存.Name = "儲存"
        Me.儲存.Size = New System.Drawing.Size(175, 22)
        Me.儲存.Text = "儲存(Save)"
        '
        '另存新檔ToolStripMenuItem
        '
        Me.另存新檔ToolStripMenuItem.Name = "另存新檔ToolStripMenuItem"
        Me.另存新檔ToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.另存新檔ToolStripMenuItem.Text = "另存新檔(Save As)"
        '
        'Fileaddress
        '
        Me.Fileaddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.Fileaddress.Enabled = False
        Me.Fileaddress.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Fileaddress.Location = New System.Drawing.Point(79, 2)
        Me.Fileaddress.Name = "Fileaddress"
        Me.Fileaddress.Size = New System.Drawing.Size(306, 22)
        Me.Fileaddress.TabIndex = 68
        Me.Fileaddress.WordWrap = False
        '
        'Clear_button
        '
        Me.Clear_button.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Clear_button.Location = New System.Drawing.Point(194, 132)
        Me.Clear_button.Name = "Clear_button"
        Me.Clear_button.Size = New System.Drawing.Size(67, 21)
        Me.Clear_button.TabIndex = 70
        Me.Clear_button.Text = "文字清除"
        Me.Clear_button.UseVisualStyleBackColor = True
        '
        'Timer5
        '
        Me.Timer5.Enabled = True
        Me.Timer5.Interval = 500
        '
        'Now_BRG
        '
        Me.Now_BRG.FormattingEnabled = True
        Me.Now_BRG.Location = New System.Drawing.Point(304, 83)
        Me.Now_BRG.Name = "Now_BRG"
        Me.Now_BRG.Size = New System.Drawing.Size(71, 20)
        Me.Now_BRG.TabIndex = 76
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(387, 275)
        Me.Controls.Add(Me.Now_BRG)
        Me.Controls.Add(Me.Clear_button)
        Me.Controls.Add(Me.Fileaddress)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtDataReceived)
        Me.Controls.Add(Me.lstCOMPorts)
        Me.Controls.Add(Me.btnConnect)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.Text = "Exlite Controller v1.0"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents lstCOMPorts As System.Windows.Forms.ComboBox
    Friend WithEvents txtDataReceived As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ValText1 As System.Windows.Forms.TextBox
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LaBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents LaBar3 As System.Windows.Forms.HScrollBar
    Friend WithEvents LaBar4 As System.Windows.Forms.HScrollBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ValText4 As System.Windows.Forms.TextBox
    Friend WithEvents ValText3 As System.Windows.Forms.TextBox
    Friend WithEvents ValText2 As System.Windows.Forms.TextBox
    Friend WithEvents LaBar2 As System.Windows.Forms.HScrollBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 檔案 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 開啟新檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 開啟 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 儲存 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 另存新檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Fileaddress As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Clear_button As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer5 As System.Windows.Forms.Timer
    Friend WithEvents Now_BRG As System.Windows.Forms.ComboBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker

End Class

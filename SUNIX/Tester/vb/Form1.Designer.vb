' ---------------------------------------------------------------------------
' Form1.Designer.vb - Designer-Definition (von Hand gepflegt)
'
' 8 kreisfoermige Panels DI1..DI8 (Kreisform wird zur Laufzeit in Form1.vb
' per Region gesetzt) + Kopfzeile + Statuszeile.
' ---------------------------------------------------------------------------

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.pnlDI1 = New System.Windows.Forms.Panel()
        Me.pnlDI2 = New System.Windows.Forms.Panel()
        Me.pnlDI3 = New System.Windows.Forms.Panel()
        Me.pnlDI4 = New System.Windows.Forms.Panel()
        Me.pnlDI5 = New System.Windows.Forms.Panel()
        Me.pnlDI6 = New System.Windows.Forms.Panel()
        Me.pnlDI7 = New System.Windows.Forms.Panel()
        Me.pnlDI8 = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        ' lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.Location = New System.Drawing.Point(12, 12)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(736, 26)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "SUNIX DI-Tester"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        ' pnlDI1
        '
        Me.pnlDI1.Location = New System.Drawing.Point(24, 50)
        Me.pnlDI1.Name = "pnlDI1"
        Me.pnlDI1.Size = New System.Drawing.Size(76, 76)
        Me.pnlDI1.TabIndex = 1
        '
        ' pnlDI2
        '
        Me.pnlDI2.Location = New System.Drawing.Point(116, 50)
        Me.pnlDI2.Name = "pnlDI2"
        Me.pnlDI2.Size = New System.Drawing.Size(76, 76)
        Me.pnlDI2.TabIndex = 2
        '
        ' pnlDI3
        '
        Me.pnlDI3.Location = New System.Drawing.Point(208, 50)
        Me.pnlDI3.Name = "pnlDI3"
        Me.pnlDI3.Size = New System.Drawing.Size(76, 76)
        Me.pnlDI3.TabIndex = 3
        '
        ' pnlDI4
        '
        Me.pnlDI4.Location = New System.Drawing.Point(300, 50)
        Me.pnlDI4.Name = "pnlDI4"
        Me.pnlDI4.Size = New System.Drawing.Size(76, 76)
        Me.pnlDI4.TabIndex = 4
        '
        ' pnlDI5
        '
        Me.pnlDI5.Location = New System.Drawing.Point(392, 50)
        Me.pnlDI5.Name = "pnlDI5"
        Me.pnlDI5.Size = New System.Drawing.Size(76, 76)
        Me.pnlDI5.TabIndex = 5
        '
        ' pnlDI6
        '
        Me.pnlDI6.Location = New System.Drawing.Point(484, 50)
        Me.pnlDI6.Name = "pnlDI6"
        Me.pnlDI6.Size = New System.Drawing.Size(76, 76)
        Me.pnlDI6.TabIndex = 6
        '
        ' pnlDI7
        '
        Me.pnlDI7.Location = New System.Drawing.Point(576, 50)
        Me.pnlDI7.Name = "pnlDI7"
        Me.pnlDI7.Size = New System.Drawing.Size(76, 76)
        Me.pnlDI7.TabIndex = 7
        '
        ' pnlDI8
        '
        Me.pnlDI8.Location = New System.Drawing.Point(668, 50)
        Me.pnlDI8.Name = "pnlDI8"
        Me.pnlDI8.Size = New System.Drawing.Size(76, 76)
        Me.pnlDI8.TabIndex = 8
        '
        ' lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(158, 158, 158)
        Me.lblStatus.Location = New System.Drawing.Point(12, 145)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(736, 60)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Status"
        '
        ' Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(30, 30, 30)
        Me.ClientSize = New System.Drawing.Size(760, 215)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pnlDI8)
        Me.Controls.Add(Me.pnlDI7)
        Me.Controls.Add(Me.pnlDI6)
        Me.Controls.Add(Me.pnlDI5)
        Me.Controls.Add(Me.pnlDI4)
        Me.Controls.Add(Me.pnlDI3)
        Me.Controls.Add(Me.pnlDI2)
        Me.Controls.Add(Me.pnlDI1)
        Me.Controls.Add(Me.lblHeader)
        Me.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DI-Tester"
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents pnlDI1 As System.Windows.Forms.Panel
    Friend WithEvents pnlDI2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDI3 As System.Windows.Forms.Panel
    Friend WithEvents pnlDI4 As System.Windows.Forms.Panel
    Friend WithEvents pnlDI5 As System.Windows.Forms.Panel
    Friend WithEvents pnlDI6 As System.Windows.Forms.Panel
    Friend WithEvents pnlDI7 As System.Windows.Forms.Panel
    Friend WithEvents pnlDI8 As System.Windows.Forms.Panel

End Class
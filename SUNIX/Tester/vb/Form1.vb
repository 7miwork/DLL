' ---------------------------------------------------------------------------
' Form1.vb - WinForms-Oberflaeche des DI-Testers
'
' 8 kreisfoermige Anzeigen (DI1..DI8): gruen = vom Treiber als aktiv/1
' gemeldet, grau = inaktiv. Polling alle 250 ms ueber einen WinForms-Timer.
' Die elektrische Logik (High/Low, Invertierung) wird NICHT hier ausgewertet -
' das stellt man im SDC Manager ein.
' ---------------------------------------------------------------------------

Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class Form1

    Private Shared ReadOnly ActiveColor As Color = Color.FromArgb(46, 204, 113)
    Private Shared ReadOnly InactiveColor As Color = Color.FromArgb(77, 77, 77)

    Private ReadOnly _client As SdcIoClient
    Private ReadOnly _timer As Timer
    Private ReadOnly _indicators As Panel()
    Private ReadOnly _labelFont As Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)

    Public Sub New(ByVal client As SdcIoClient)
        _client = client
        InitializeComponent()

        _indicators = {pnlDI1, pnlDI2, pnlDI3, pnlDI4, pnlDI5, pnlDI6, pnlDI7, pnlDI8}

        Dim suffix As String = If(client.IsMock, "MOCK - keine Karte erkannt", client.HardwareInfo)
        Me.Text = "DI-Tester (" & suffix & ")"
        lblHeader.Text = "SUNIX DI-Tester - " & suffix
        lblHeader.ForeColor = If(client.IsMock, Color.FromArgb(241, 196, 15), Color.FromArgb(46, 204, 113))

        For Each indicator As Panel In _indicators
            ' Kreisform statt Rechteck (Region bleibt bis zum Schliessen gesetzt)
            Using path As New GraphicsPath()
                path.AddEllipse(0, 0, indicator.Width - 1, indicator.Height - 1)
                indicator.Region = New Region(path)
            End Using
            indicator.BackColor = InactiveColor
            AddHandler indicator.Paint, AddressOf IndicatorPaint
        Next

        lblStatus.Text = client.StatusText

        _timer = New Timer()
        _timer.Interval = 250
        AddHandler _timer.Tick, AddressOf TimerTick
    End Sub

    Protected Overrides Sub OnShown(ByVal e As EventArgs)
        MyBase.OnShown(e)
        _timer.Start()
    End Sub

    Private Sub TimerTick(ByVal sender As Object, ByVal e As EventArgs)
        Dim states() As Boolean = _client.ReadDigitalInputs()
        For index As Integer = 0 To _indicators.Length - 1
            _indicators(index).BackColor = If(states(index), ActiveColor, InactiveColor)
        Next
        lblStatus.Text = _client.StatusText
    End Sub

    ''' <summary>Zeichnet den Kanalnamen ("DI1".."DI8") mittig in den Kreis.</summary>
    Private Sub IndicatorPaint(ByVal sender As Object, ByVal e As PaintEventArgs)
        Dim indicator As Panel = DirectCast(sender, Panel)
        Dim index As Integer = Array.IndexOf(_indicators, indicator)
        Dim text As String = "DI" & (index + 1).ToString()

        Using brush As New SolidBrush(Color.FromArgb(235, 235, 235))
            Dim size As SizeF = e.Graphics.MeasureString(text, _labelFont)
            e.Graphics.DrawString(text, _labelFont, brush,
                                  (indicator.Width - size.Width) / 2.0F,
                                  (indicator.Height - size.Height) / 2.0F)
        End Using
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        _timer.Stop()
        _client.Dispose()
        MyBase.OnFormClosing(e)
    End Sub

End Class
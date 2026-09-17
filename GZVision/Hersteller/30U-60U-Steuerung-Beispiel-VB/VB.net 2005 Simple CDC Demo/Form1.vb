
Imports System.IO.Ports
Imports System.IO

Public Class Form1
    Private Structure POINTAPI
        Dim pwm As Integer
        Dim Y As Integer
    End Structure



    Dim a As Integer = 0


    Dim TXIF As Integer = 0
    Dim RXIF As Integer = 0
    Dim TimerIF As Integer = 0
    Dim buffer_123 As String = ""

    Dim Text_1keyDOWN As Integer = 0
    Dim Text_2keyDOWN As Integer = 0
    Dim Text_3keyDOWN As Integer = 0
    Dim Text_4keyDOWN As Integer = 0

    Dim Labardata1 As Integer = 0
    Dim Labardata2 As Integer = 0
    Dim Labardata3 As Integer = 0
    Dim Labardata4 As Integer = 0
    Dim 開啟檔案 As Boolean = False '用在開啟檔案時候 會設定到LABAR的關係會誤動作
    Dim 按鈕切換 As Integer = 0 '將開啟關閉COMPORT設定在同一個按鈕時候會用到判斷式
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Fileaddress.Text = "" Then
            儲存.Enabled = False
        End If


        '      TabControl1.DefaultForeColor = Color.DarkBlue


        '  FreqBar.Value = 1000
        '   i = FreqBar.Value
        ValText1.Text = LaBar1.Value
        ValText2.Text = LaBar2.Value
        ValText3.Text = LaBar3.Value
        ValText4.Text = LaBar4.Value

        ' TextFreq.Text = FreqBar.Value

        btnClose.Enabled = False
        LaBar1.Enabled = False
        LaBar2.Enabled = False
        LaBar3.Enabled = False
        LaBar4.Enabled = False
        ValText1.Enabled = False
        ValText2.Enabled = False
        ValText3.Enabled = False
        ValText4.Enabled = False
 
        Dim i As Integer
        Dim Nb() As String = {"9600", "38400", "115200"}
        For i = 0 To 2 Step 1
            Now_BRG.Items.Add(Nb(i))
        Next
        Now_BRG.SelectedIndex = 0
        '   PictureBox1.Image = New Bitmap("控制時序圖.bmp")
    End Sub
    Private Sub Btn_Open()
        LaBar1.Enabled = True
        LaBar2.Enabled = True
        LaBar3.Enabled = True
        LaBar4.Enabled = True
        ValText1.Enabled = True
        ValText2.Enabled = True
        ValText3.Enabled = True
        ValText4.Enabled = True
        btnClose.Enabled = True

    End Sub
    Private Sub Btn_Close()
        LaBar1.Enabled = False
        LaBar2.Enabled = False
        LaBar3.Enabled = False
        LaBar4.Enabled = False
        ValText1.Enabled = False
        ValText2.Enabled = False
        ValText3.Enabled = False
        ValText4.Enabled = False
        btnClose.Enabled = False

    End Sub
    Private Sub UpdateCOMPortList()
        Dim s As String
        Dim i As Integer
        Dim foundDifference As Boolean
        Try
            i = 0
            foundDifference = False
            'If the number of COM ports is different than the last time we
            '  checked, then we know that the COM ports have changed and we
            '  don't need to verify each entry.

            If lstCOMPorts.Items.Count = SerialPort.GetPortNames().Length Then
                'Search the entire SerialPort object.  Look at COM port name
                '  returned and see if it already exists in the list.
                For Each s In SerialPort.GetPortNames()
                    'If any of the names have changed then we need to update 
                    '  the list
                    If lstCOMPorts.Items(i).Equals(s) = False Then
                        foundDifference = True
                    End If
                    i = i + 1
                Next s
            Else
                foundDifference = True
            End If

            'If nothing has changed, exit the function.
            If foundDifference = False Then
                Exit Sub
            End If

            'If something has changed, then clear the list
            lstCOMPorts.Items.Clear()

            'Add all of the current COM ports to the list

            For Each s In SerialPort.GetPortNames()
                lstCOMPorts.Items.Add(s)
            Next s

            'Set the listbox to point to the first entry in the list
            lstCOMPorts.SelectedIndex = 0
        Catch

        End Try


    End Sub


    '****************************************************************************
    '   Function:
    '       private void timer1_Tick(object sender, EventArgs e)
    '
    '   Summary:
    '       This function updates the COM ports listbox.
    '
    '   Description:
    '       This function updates the COM ports listbox.  This function is launched 
    '       periodically based on its Interval attribute (set in the form editor under
    '       the properties window).
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       EventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Update the COM ports list so that we can detect
        '  new COM ports that have been added.
        UpdateCOMPortList()

        Dim Port_disable As Boolean = True
        Dim s As String

        Try
            If SerialPort1.IsOpen = True Then
                For Each s In SerialPort.GetPortNames()
                    If SerialPort1.PortName = s Then
                        Port_disable = False
                    End If
                Next s
            End If
            If SerialPort1.IsOpen = False And 按鈕切換 = 1 Then
                btnConnect_Click(Me, e)
                MsgBox(" The serialport is close , please check! ")
            End If

            If Port_disable = True And SerialPort1.IsOpen = True Then

                '   btnClose.Enabled = False
                '  btnConnect.Enabled = True
                '   lstCOMPorts.Enabled = True

                btnConnect_Click(Me, e)
                MsgBox(" The serialport is close , please check! ")
                LaBar1.Enabled = False
                LaBar2.Enabled = False
                LaBar3.Enabled = False
                LaBar4.Enabled = False

                ValText1.Enabled = False
                ValText2.Enabled = False
                ValText3.Enabled = False
                ValText4.Enabled = False
                If SerialPort1.IsOpen = True Then
                    'Dispose the In and Out buffers;
                    SerialPort1.DiscardInBuffer()
                    SerialPort1.DiscardOutBuffer()
                    'Close the COM port
                    SerialPort1.Close()
                    'If there was an exeception then there isn't much we can
                    '  do.  The port is no longer available.
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub


    '****************************************************************************
    '   Function:
    '       private void btnConnect_Click(object sender, EventArgs e)
    '
    '   Summary:
    '       This function opens the COM port.
    '
    '   Description:
    '       This function opens the COM port.  This function is launched when the 
    '       btnConnect button is clicked.  In addition to opening the COM port, this 
    '       function will also change the Enable attribute of several of the form
    '       objects to disable the user from opening a new COM port.
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       EventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        If 按鈕切換 = 0 Then
            Try
                SerialPort1.PortName = lstCOMPorts.Items(lstCOMPorts.SelectedIndex).ToString()
                SerialPort1.Open()
                lstCOMPorts.Enabled = False
                btnClose.Enabled = True
                txtDataReceived.Clear()
                txtDataReceived.AppendText("Connected." + vbCrLf)
                Btn_Open()
                ValText1.Text = LaBar1.Value
                ValText2.Text = LaBar2.Value
                ValText3.Text = LaBar3.Value
                ValText4.Text = LaBar4.Value
                按鈕切換 = 1
                btnConnect.Text = "關閉"
                SerialPort1.DiscardInBuffer()
                SerialPort1.DiscardOutBuffer()
                SerialPort1.Close()
                SerialPort1.Open()

            Catch ex As Exception
                btnClose_Click(Me, e)
                MsgBox("You must be choose or open a comport ")
                txtDataReceived.Text = "You must be choose or open a comport "
            End Try

        Else
            Try
                按鈕切換 = 0
                btnConnect.Text = "連接通訊"
                btnClose.Enabled = False
                btnConnect.Enabled = True
                lstCOMPorts.Enabled = True
                Btn_Close()
                ValText1.Text = 0
                ValText2.Text = 0
                ValText3.Text = 0
                ValText4.Text = 0

                SerialPort1.Close()

            Catch ex As Exception

            End Try

        End If
    End Sub


    '****************************************************************************
    '   Function:
    '       private void btnClose_Click(object sender, EventArgs e)
    '
    '   Summary:
    '       This function closes the COM port.
    '
    '   Description:
    '       This function closes the COM port.  This function is launched when the 
    '       btnClose button is clicked.  This function can also be called directly
    '       from other functions.  In addition to closing the COM port, this 
    '       function will also change the Enable attribute of several of the form
    '       objects to enable the user to open a new COM port.
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       EventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Reset the state of the application objects
        btnClose.Enabled = False
        btnConnect.Enabled = True
        lstCOMPorts.Enabled = True
        btnClose.Enabled = False
        LaBar1.Enabled = False
        LaBar2.Enabled = False
        LaBar3.Enabled = False
        LaBar4.Enabled = False



        ValText3.Enabled = False
        ValText4.Enabled = False

        ValText1.Text = 0
        ValText2.Text = 0
        ValText3.Text = 0
        ValText4.Text = 0

        'This section of code will try to close the COM port.
        '  Please note that it is important to use a try/catch
        '  statement when closing the COM port.  If a USB virtual
        '  COM port is removed and the PC software tries to close
        '  the COM port before it detects its removal then
        '  an exeception is thrown.  If the execption is not in a
        '  try/catch statement this could result in the application
        '  crashing.
        Try

            'Dispose the In and Out buffers;
            SerialPort1.DiscardInBuffer()
            SerialPort1.DiscardOutBuffer()
            'Close the COM port
            SerialPort1.Close()
            'If there was an exeception then there isn't much we can
            '  do.  The port is no longer available.
        Catch ex As Exception

        End Try
    End Sub


    '****************************************************************************
    '   Function:
    '       private void serialPort1_DataReceived(  object sender, 
    '                                               SerialDataReceivedEventArgs e)
    '
    '   Summary:
    '       This function prints any data received on the COM port.
    '
    '   Description:
    '       This function is called when the data is received on the COM port.  This
    '       function attempts to write that data to the txtDataReceived textbox.  If
    '       an exception occurs the btnClose_Click() function is called in order to
    '       close the COM port that caused the exception.
    '   
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       object sender     - Sender of the event (this form)
    '       SerialDataReceivedEventArgs e       - The event arguments
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'The ReadExisting() function will read all of the data that
        '  is currently available in the COM port buffer.  In this 
        '  example we are sending all of the available COM port data
        '  to the SetText() function.
        '
        '  NOTE: the <SerialPort>_DataReceived() function is launched
        '  in a seperate thread from the rest of the application.  A
        '  delegate function is required in order to properly access
        '  any managed objects inside of the other thread.  Since we
        '  will be writing to a textBox (a managed object) the delegate
        '  function is required.  Please see the SetText() function for 
        '  more information about delegate functions and how to use them.

        '      PU = (SerialPort1.BytesToRead)
        '       If PU + Text.Length = 7 Then
        'SerialPort1.Read(Buffer, 0, SerialPort1.BytesToRead)
        '      Text = Text + Buffer

        Try
            Dim RS232_data As Integer
            Dim RS232_Text As String
            If TXIF = 1 Then
                If buffer_123.Length > 0 Then
                    RS232_data = SerialPort1.BytesToRead
                    RS232_Text = SerialPort1.ReadExisting()
                    buffer_123 = buffer_123 + RS232_Text
                Else
                    RS232_data = SerialPort1.BytesToRead
                    RS232_Text = SerialPort1.ReadExisting()
                    buffer_123 = RS232_Text
                End If
            Else
                SetText(SerialPort1.ReadExisting())
            End If

        Catch ex As Exception
            'If there was an exception, then close the handle to 
            '  the device and assume that the device was removed
            btnClose_Click(Me, e)
        End Try

    End Sub


    '****************************************************************************
    '   Function:
    '       private void SetText(string text)
    '
    '   Summary:
    '       This function prints the input text to the txtDataReceived textbox.
    '
    '   Description:
    '       This function prints the input text to the txtDataReceived textbox.  If
    '       the calling thread is the same as the thread that owns the textbox, then
    '       the AppendText() method is called directly.  If a thread other than the
    '       main thread calls this function, then an instance of the delegate function
    '       is created so that the function runs again in the main thread.
    '
    '   Precondition:
    '       None
    '
    '   Parameters:
    '       string text     - Text that needs to be printed to the textbox
    '
    '   Return Values
    '       None
    '
    '   Remarks:
    '       None
    '***************************************************************************/
    Private Sub SetText(ByVal [text] As String)
        'InvokeRequired required compares the thread ID of the
        '  calling thread to the thread ID of the creating thread.
        '  If these threads are different, it returns true.  We can
        '  use this attribute to determine if we can append text
        '  directly to the textbox or if we must launch an a delegate
        '  function instance to write to the textbox.
        If txtDataReceived.InvokeRequired Then
            'InvokeRequired returned TRUE meaning that this function
            '  was called from a thread different than the current
            '  thread.  We must launch a deleage function.

            'Create an instance of the SetTextCallback delegate and
            '  assign the delegate function to be this function.  This
            '  effectively causes this same SetText() function to be
            '  called within the main thread instead of the second
            '  thread.
            Dim d As New SetTextCallback(AddressOf SetText)

            'Invoke the new delegate sending the same text to the
            '  delegate that was passed into this function from the
            '  other thread.
            Invoke(d, New Object() {[Text]})
        Else
            'If this function was called from the same thread that 
            '  holds the required objects then just add the text.

            Try



                txtDataReceived.AppendText(text)
                txtDataReceived.SelectionStart = txtDataReceived.Text.Length
                txtDataReceived.ScrollToCaret()
            Catch ex As Exception

            End Try


        End If
    End Sub


    Private Sub LaBar1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LaBar1.KeyDown
        If e.KeyCode = Keys.Right Then
            If LaBar1.Value < 255 Then
                If LaBar1.Value + 9 >= 255 Then
                    LaBar1.Value = 255
                Else
                    LaBar1.Value += 9
                End If
                ValText1.Text = LaBar1.Value
            End If
        ElseIf e.KeyCode = Keys.Left Then
            If LaBar1.Value > 0 Then
                If LaBar1.Value - 9 <= 0 Then
                    LaBar1.Value = 0
                Else
                    LaBar1.Value -= 9
                End If
                ValText1.Text = LaBar1.Value
            End If
        End If
    End Sub

    Private Sub LaBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LaBar1.ValueChanged
        Dim rs232(0) As Byte
        Dim FDSA As UInteger = 0
        Try
            If 開啟檔案 = False Then
                If SerialPort1.IsOpen() = True Then
                    If Text_1keyDOWN <> 1 And TXIF = 0 Then
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(1))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(LaBar1.Value, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(1))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(LaBar1.Value, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        ValText1.Text = LaBar1.Value
                        TXIF = 1

                        If BackgroundWorker1.IsBusy = False Then
                            BackgroundWorker1.RunWorkerAsync()
                        End If

                    End If
                    Text_1keyDOWN = 0
                End If
                If BackgroundWorker1.IsBusy = False And TXIF = 1 Then
                    TXIF = 0
                End If
            End If
        Catch ex As Exception
            If BackgroundWorker1.IsBusy = True Then
                While BackgroundWorker1.IsBusy = True
                End While
                BackgroundWorker1.RunWorkerAsync()
            Else

                txtDataReceived.Text = "You have to choose or open a comport "
            End If

        End Try

    End Sub
    Private Sub ValText1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ValText1.KeyDown
        Dim rs232(0) As Byte
        Dim a As Integer
        If e.KeyCode = Keys.Enter Then
            Try
                If ValText1.Text > 255 And ValText1.Text < 0 Then
                    txtDataReceived.Text = txtDataReceived.Text + vbCrLf + "Over the MaxValue Please ReEnter The Value"
                    ValText1.BackColor = Color.Red
                Else
                    If Val(ValText1.Text) <> LaBar1.Value Then
                        Text_1keyDOWN = 1
                    End If
                    a = Val(ValText1.Text)
                    ValText1.BackColor = Color.White
                    If SerialPort1.IsOpen = True Then
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(1))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(a, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(1))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(a, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        LaBar1.Value = Val(ValText1.Text)
                    End If
                End If
            Catch
                txtDataReceived.Text = txtDataReceived.Text + vbCrLf + "The Textbox have Nonnumeric text "
                ValText1.BackColor = Color.Red
                txtDataReceived.SelectionStart = txtDataReceived.Text.Length
                txtDataReceived.ScrollToCaret()
            End Try
        End If


        If e.KeyCode = Keys.Right Then
            If LaBar1.Value < 255 Then
                If LaBar1.Value + 10 >= 255 Then
                    LaBar1.Value = 255
                Else
                    LaBar1.Value += 10
                End If
                ValText1.Text = LaBar1.Value
            End If
        ElseIf e.KeyCode = Keys.Left Then
            If LaBar1.Value > 0 Then
                If LaBar1.Value - 10 <= 0 Then
                    LaBar1.Value = 0
                Else
                    LaBar1.Value -= 10
                End If
                ValText1.Text = LaBar1.Value
            End If
        End If

    End Sub

    Private Sub LaBar2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LaBar2.KeyDown
        If e.KeyCode = Keys.Right Then
            If LaBar2.Value < 255 Then
                If LaBar2.Value + 9 >= 255 Then
                    LaBar2.Value = 255
                Else
                    LaBar2.Value += 9
                End If
                ValText2.Text = LaBar2.Value
            End If
        ElseIf e.KeyCode = Keys.Left Then
            If LaBar2.Value > 0 Then
                If LaBar2.Value - 9 <= 0 Then
                    LaBar2.Value = 0
                Else
                    LaBar2.Value -= 9
                End If
                ValText2.Text = LaBar2.Value
            End If
        End If
    End Sub

    Private Sub LaBar2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LaBar2.ValueChanged
        Dim rs232(0) As Byte
        If 開啟檔案 = False Then
            Try
                If SerialPort1.IsOpen() = True Then
                    If Text_2keyDOWN <> 1 Then
                        Labardata2 = LaBar2.Value
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(2))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(LaBar2.Value, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(2))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(LaBar2.Value, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        ValText2.Text = LaBar2.Value

                    End If
                    Text_2keyDOWN = 0
                End If
            Catch ex As Exception
                txtDataReceived.Text = "You have to choose or open a comport "
            End Try
        End If

    End Sub
    Private Sub ValText2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ValText2.KeyDown
        Dim rs232(0) As Byte
        Dim a As Integer
        If e.KeyCode = Keys.Enter Then
            Try
                If ValText2.Text > 255 And ValText2.Text < 0 Then
                    txtDataReceived.Text = txtDataReceived.Text + vbCrLf + "Over the MaxValue Please ReEnter The Value"
                    ValText2.BackColor = Color.Red
                Else
                    If Val(ValText2.Text) <> LaBar2.Value Then
                        Text_2keyDOWN = 1
                    End If
                    a = ValText2.Text
                    ValText2.BackColor = Color.White
                    If SerialPort1.IsOpen = True Then
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(2))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(a, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(2))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(a, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        LaBar2.Value = ValText2.Text
                    End If
                End If
            Catch
                txtDataReceived.Text = txtDataReceived.Text + vbCrLf + "The Textbox have Nonnumeric text "
                ValText2.BackColor = Color.Red
                txtDataReceived.SelectionStart = txtDataReceived.Text.Length
                txtDataReceived.ScrollToCaret()
            End Try
        End If

        If e.KeyCode = Keys.Right Then
            If LaBar2.Value < 255 Then
                If LaBar2.Value + 10 >= 255 Then
                    LaBar2.Value = 255
                Else
                    LaBar2.Value += 10
                End If
                ValText2.Text = LaBar2.Value
            End If
        ElseIf e.KeyCode = Keys.Left Then
            If LaBar2.Value > 0 Then
                If LaBar2.Value - 10 <= 0 Then
                    LaBar2.Value = 0
                Else
                    LaBar2.Value -= 10
                End If
                ValText2.Text = LaBar2.Value
            End If
        End If
    End Sub

    Private Sub LaBar3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LaBar3.KeyDown
        If e.KeyCode = Keys.Right Then
            If LaBar3.Value < 255 Then
                If LaBar3.Value + 9 >= 255 Then
                    LaBar3.Value = 255
                Else
                    LaBar3.Value += 9
                End If
                ValText3.Text = LaBar3.Value
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If LaBar3.Value > 0 Then
                If LaBar3.Value - 9 <= 0 Then
                    LaBar3.Value = 0
                Else
                    LaBar3.Value -= 9
                End If
                ValText3.Text = LaBar3.Value
            End If
        End If
    End Sub

    Private Sub LaBar3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LaBar3.ValueChanged
        Dim rs232(0) As Byte
        If 開啟檔案 = False Then
            Try
                If Text_3keyDOWN <> 1 Then
                    Labardata3 = LaBar3.Value
                    rs232(0) = CType(&HF0, Byte)
                    SerialPort1.Write(rs232, 0, 1)   'F0
                    SerialPort1.Write(ChrW(3))       '04
                    SerialPort1.Write(Chr(&HF))      '0F
                    rs232(0) = CType(LaBar3.Value, Byte)
                    SerialPort1.Write(rs232, 0, 1)   'FF
                    rs232(0) = CType(&HF0, Byte)
                    SerialPort1.Write(rs232, 0, 1)   'F0
                    SerialPort1.Write(ChrW(3))       '04
                    SerialPort1.Write(Chr(&HF))      '0F
                    rs232(0) = CType(LaBar3.Value, Byte)
                    SerialPort1.Write(rs232, 0, 1)   'FF
                    ValText3.Text = LaBar3.Value
                End If
                Text_3keyDOWN = 0
            Catch ex As Exception
                txtDataReceived.Text = "You have to choose or open a comport "
            End Try
        End If

    End Sub
    Private Sub ValText3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ValText3.KeyDown
        Dim rs232(0) As Byte
        Dim a As Integer
        If e.KeyCode = Keys.Enter Then
            Try
                If ValText3.Text > 255 And ValText3.Text < 0 Then
                    txtDataReceived.Text = txtDataReceived.Text + vbCrLf + "Over the MaxValue Please ReEnter The Value"
                    ValText3.BackColor = Color.Red
                Else
                    If Val(ValText3.Text) <> LaBar3.Value Then
                        Text_3keyDOWN = 1
                    End If
                    a = Val(ValText3.Text)
                    ValText3.BackColor = Color.White
                    If SerialPort1.IsOpen = True Then
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(3))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(a, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(3))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(a, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        LaBar3.Value = a
                    End If
                End If
            Catch
                txtDataReceived.Text = txtDataReceived.Text + vbCrLf + "The Textbox have Nonnumeric text "
                ValText3.BackColor = Color.Red
                txtDataReceived.SelectionStart = txtDataReceived.Text.Length
                txtDataReceived.ScrollToCaret()
            End Try
        End If

        If e.KeyCode = Keys.Right Then
            If LaBar3.Value < 255 Then
                If LaBar3.Value + 10 >= 255 Then
                    LaBar3.Value = 255
                Else
                    LaBar3.Value += 10
                End If
                ValText3.Text = LaBar3.Value
            End If
        ElseIf e.KeyCode = Keys.Left Then
            If LaBar3.Value > 0 Then
                If LaBar3.Value - 10 <= 0 Then
                    LaBar3.Value = 0
                Else
                    LaBar3.Value -= 10
                End If
                ValText3.Text = LaBar3.Value
            End If
        End If

    End Sub

    Private Sub LaBar4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LaBar4.KeyDown
        If e.KeyCode = Keys.Right Then
            If LaBar4.Value < 255 Then
                If LaBar4.Value + 9 >= 255 Then
                    LaBar4.Value = 255
                Else
                    LaBar4.Value += 9
                End If
                ValText4.Text = LaBar4.Value
            End If
        ElseIf e.KeyCode = Keys.Left Then
            If LaBar4.Value > 0 Then
                If LaBar4.Value - 9 <= 0 Then
                    LaBar4.Value = 0
                Else
                    LaBar4.Value -= 9
                End If
                ValText4.Text = LaBar4.Value
            End If
        End If
    End Sub

    Private Sub LaBar4_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LaBar4.ValueChanged
        Dim rs232(0) As Byte
        If 開啟檔案 = False Then
            Try
                If Text_4keyDOWN <> 1 Then
                    Labardata4 = LaBar4.Value
                    rs232(0) = CType(&HF0, Byte)
                    SerialPort1.Write(rs232, 0, 1)   'F0
                    SerialPort1.Write(ChrW(4))       '04
                    SerialPort1.Write(Chr(&HF))      '0F
                    rs232(0) = CType(LaBar4.Value, Byte)
                    SerialPort1.Write(rs232, 0, 1)   'FF
                    rs232(0) = CType(&HF0, Byte)
                    SerialPort1.Write(rs232, 0, 1)   'F0
                    SerialPort1.Write(ChrW(4))       '04
                    SerialPort1.Write(Chr(&HF))      '0F
                    rs232(0) = CType(LaBar4.Value, Byte)
                    SerialPort1.Write(rs232, 0, 1)   'FF
                    ValText4.Text = LaBar4.Value

                End If
                Text_4keyDOWN = 0
            Catch ex As Exception
                txtDataReceived.Text = "You have to choose or open a comport "
            End Try
        End If

    End Sub
    Private Sub ValText4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ValText4.KeyDown
        Dim rs232(0) As Byte
        Dim a As Integer
        If e.KeyCode = Keys.Enter Then
            Try
                If ValText4.Text > 255 And ValText4.Text < 0 Then
                    txtDataReceived.Text = txtDataReceived.Text + vbCrLf + "Over the MaxValue Please ReEnter The Value"
                    ValText4.BackColor = Color.Red
                Else
                    If Val(ValText4.Text) <> LaBar4.Value Then
                        Text_4keyDOWN = 1
                    End If
                    ValText4.BackColor = Color.White
                    a = Val(ValText4.Text)
                    If SerialPort1.IsOpen = True Then
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(4))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(a, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        rs232(0) = CType(&HF0, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'F0
                        SerialPort1.Write(ChrW(4))       '04
                        SerialPort1.Write(Chr(&HF))      '0F
                        rs232(0) = CType(a, Byte)
                        SerialPort1.Write(rs232, 0, 1)   'FF
                        Labardata4 = LaBar4.Value
                        LaBar4.Value = ValText4.Text
                    End If
                End If
            Catch
                txtDataReceived.Text = txtDataReceived.Text + vbCrLf + "The Textbox have Nonnumeric text "
                ValText4.BackColor = Color.Red
                txtDataReceived.SelectionStart = txtDataReceived.Text.Length
                txtDataReceived.ScrollToCaret()
            End Try
        End If
        If e.KeyCode = Keys.Right Then
            If LaBar4.Value < 255 Then
                If LaBar4.Value + 10 >= 255 Then
                    LaBar4.Value = 255
                Else
                    LaBar4.Value += 10
                End If
                ValText4.Text = LaBar4.Value
            End If
        ElseIf e.KeyCode = Keys.Left Then
            If LaBar4.Value > 0 Then
                If LaBar4.Value - 10 <= 0 Then
                    LaBar4.Value = 0
                Else
                    LaBar4.Value -= 10
                End If
                ValText4.Text = LaBar4.Value
            End If
        End If

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If LaBar1.Enabled = False And SerialPort1.IsOpen = True Then
            LaBar1.Enabled = True
            Label1.Text = "CH1"
            ValText1.Enabled = True
            Label1.ForeColor = Color.Black
        ElseIf SerialPort1.IsOpen = True Then
            LaBar1.Enabled = False
            Label1.ForeColor = Color.Red
            Label1.Text = "關閉"
            Sent_data2(1, 0)
            ValText1.Enabled = False

        End If
    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        If LaBar2.Enabled = False And SerialPort1.IsOpen = True Then
            LaBar2.Enabled = True
            Label2.Text = "CH2"
            ValText2.Enabled = True
            Label2.ForeColor = Color.Black
        ElseIf SerialPort1.IsOpen = True Then
            LaBar2.Enabled = False
            Label2.ForeColor = Color.Red
            Label2.Text = "關閉"
            Sent_data2(2, 0)
            ValText2.Enabled = False

        End If
    End Sub
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        If LaBar3.Enabled = False And SerialPort1.IsOpen = True Then
            LaBar3.Enabled = True
            Label3.Text = "CH3"
            ValText3.Enabled = True
            Label3.ForeColor = Color.Black
        ElseIf SerialPort1.IsOpen = True Then
            LaBar3.Enabled = False
            Label3.ForeColor = Color.Red
            Label3.Text = "關閉"
            Sent_data2(3, 0)
            ValText3.Enabled = False

        End If
    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        If LaBar4.Enabled = False And SerialPort1.IsOpen = True Then
            LaBar4.Enabled = True
            Label4.Text = "CH4"
            ValText4.Enabled = True
            Label4.ForeColor = Color.Black
        ElseIf SerialPort1.IsOpen = True Then
            LaBar4.Enabled = False
            Label4.ForeColor = Color.Red
            Label4.Text = "關閉"
            Sent_data2(4, 0)
            ValText4.Enabled = False

        End If
    End Sub

    Private Sub 開啟新檔ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 開啟新檔ToolStripMenuItem.Click


        txtDataReceived.Clear()
        開啟檔案 = True
        儲存.Enabled = False
        LaBar1.Value = 0
        LaBar2.Value = 0
        LaBar3.Value = 0
        LaBar4.Value = 0
        ValText1.Text = 0
        ValText2.Text = 0
        ValText3.Text = 0
        ValText4.Text = 0
        開啟檔案 = False
        Fileaddress.Text = ""
        Now_BRG.SelectedIndex = 0
        lstCOMPorts.SelectedIndex = 0
        If 按鈕切換 = 1 Then
            btnConnect_Click(Me, e)

        End If
        Try
            Now_BRG.SelectedIndex = 0
        Catch ex As Exception
        End Try



    End Sub
    Public Function GetINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As String
        Dim Str As String = LSet(Str, 256)
        GetPrivateProfileString(Section, AppName, lpDefault, Str, Len(Str), FileName)
        Return Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1)
    End Function
    Public Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As Long
        WriteINI = WritePrivateProfileString(Section, AppName, lpDefault, FileName)
    End Function
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    Private Sub 開啟_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 開啟.Click
        Timer1.Enabled = False
        Dim a As Integer = lstCOMPorts.Items.Count
        Dim b As Integer = Now_BRG.Items.Count
        Dim BRG_same As Boolean = False
        Dim COM_same As Boolean = False
        Try
            OpenFileDialog1.Filter = "ini檔案|*.ini"
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Fileaddress.Text = OpenFileDialog1.FileName

                Dim path As String
                path = Fileaddress.Text



                While b
                    If Now_BRG.Items(b - 1) = GetINI("Control", "BaudRate", 9600, path) Then
                        BRG_same = True
                        b -= 1
                        Now_BRG.SelectedIndex = b
                        SerialPort1.BaudRate = Now_BRG.SelectedItem
                    Else
                        b -= 1
                    End If
                End While
                If BRG_same = False Then
                    Now_BRG.SelectedIndex = 0
                    MsgBox("鮑率<" + GetINI("Control", "BaudRate", 9600, path) + ">錯誤，請檢查!!", , "BaudRate Error!")
                End If
                While a
                    If lstCOMPorts.Items(a - 1) = GetINI("Control", "COM", 0, path) Then
                        COM_same = True
                        a -= 1
                        lstCOMPorts.SelectedItem = GetINI("Control", "COM", 0, path)
                    Else
                        a -= 1
                    End If
                End While
                If COM_same = False Then
                    MsgBox(GetINI("Control", "COM", 0, path) + "不存在", , "Comport Error!")
                    If SerialPort1.IsOpen = True Then
                        SerialPort1.Close()
                        Btn_Close()
                    End If
                End If
                Try
                    開啟檔案 = True
                    LaBar1.Value = GetINI("Control", "CH1", 0, path)
                    LaBar2.Value = GetINI("Control", "CH2", 0, path)
                    LaBar3.Value = GetINI("Control", "CH3", 0, path)
                    LaBar4.Value = GetINI("Control", "CH4", 0, path)
                    ValText1.Text = LaBar1.Value
                    ValText2.Text = LaBar2.Value
                    ValText3.Text = LaBar3.Value
                    ValText4.Text = LaBar4.Value
                    If COM_same = True And BRG_same = True Then
                        If SerialPort1.IsOpen = True Then
                            SerialPort1.Close()
                        End If
                        SerialPort1.PortName = lstCOMPorts.SelectedItem
                        SerialPort1.Open()
                        lstCOMPorts.Enabled = False
                        btnConnect.Text = "關閉"
                        按鈕切換 = 1
                        btnClose.Enabled = True

                        txtDataReceived.Clear()
                        txtDataReceived.AppendText("Connected." + vbCrLf)
                        Btn_Open()

                        儲存.Enabled = True

                        Timer1.Enabled = True
                    Else
                        btnConnect.Text = "連接通訊"
                        btnClose.Enabled = False
                        btnConnect.Enabled = True
                        lstCOMPorts.Enabled = True
                        Btn_Close()
                        txtDataReceived.Clear()
                    End If

                Catch ex As Exception
                    MsgBox("請確認亮度數值是否有錯誤!!(0~255)", , "Channal數值錯誤")
                    btnConnect.Text = "連接通訊"
                    btnClose.Enabled = False
                    btnConnect.Enabled = True
                    lstCOMPorts.Enabled = True
                    Btn_Close()
                    txtDataReceived.Clear()

                End Try
            End If
            開啟檔案 = False
        Catch ex As Exception
            MsgBox("請確認數值是否有錯誤!!")
        End Try
    End Sub
    Private Sub 儲存_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 儲存.Click

        SaveFileDialog1.Filter = "ini檔案|*.ini"

        Try
            Dim path As String
            path = Fileaddress.Text
            WriteINI("Control", "COM", lstCOMPorts.SelectedItem, path)
            WriteINI("Control", "BaudRate", Now_BRG.SelectedItem, path)
            WriteINI("Control", "CH1", LaBar1.Value, path)
            WriteINI("Control", "CH2", LaBar2.Value, path)
            WriteINI("Control", "CH3", LaBar3.Value, path)
            WriteINI("Control", "CH4", LaBar4.Value, path)
            MsgBox("Complete！")
        Catch ex As Exception
            MsgBox("Error！！！！")
        End Try

    End Sub

    Private Sub 另存新檔ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 另存新檔ToolStripMenuItem.Click

        SaveFileDialog1.Filter = "ini檔案|*.ini"
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                Dim path As String
                Fileaddress.Text = SaveFileDialog1.FileName.ToString()
                path = SaveFileDialog1.FileName.ToString()
                儲存.Enabled = True
                WriteINI("Control", "COM", lstCOMPorts.SelectedItem, path)
                WriteINI("Control", "BaudRate", Now_BRG.SelectedItem, path)
                WriteINI("Control", "CH1", LaBar1.Value, path)
                WriteINI("Control", "CH2", LaBar2.Value, path)
                WriteINI("Control", "CH3", LaBar3.Value, path)
                WriteINI("Control", "CH4", LaBar4.Value, path)
                MsgBox("Complete！")
            Catch ex As Exception
                MsgBox("Error！！！！")
            End Try
        End If
    End Sub

    Private Sub Now_BRG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim a As Byte

        Dim rs232(0) As Byte
        If Now_BRG.SelectedIndex = 0 Then
            a = &HF4
        ElseIf Now_BRG.SelectedIndex = 1 Then
            a = &HFD
        ElseIf Now_BRG.SelectedIndex = 2 Then
            a = &HFF
        End If
        If SerialPort1.IsOpen = True Then
            rs232(0) = CType(&HF0, Byte)
            SerialPort1.Write(rs232, 0, 1)   'F0
            SerialPort1.Write(Chr(&HA))       '
            SerialPort1.Write(Chr(&HF))      '0F
            rs232(0) = CType(a, Byte)
            SerialPort1.Write(rs232, 0, 1)   'FF

            rs232(0) = CType(&HF0, Byte)
            SerialPort1.Write(rs232, 0, 1)   'F0
            SerialPort1.Write(Chr(&HA))       '04
            SerialPort1.Write(Chr(&HF))      '0F
            rs232(0) = CType(a, Byte)
            SerialPort1.Write(rs232, 0, 1)   'FF

            Timer5.Enabled = True
        End If


    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If SerialPort1.BytesToWrite = 0 Then
            Timer5.Enabled = False
            SerialPort1.BaudRate = Val(Now_BRG.Items.Item(Now_BRG.SelectedIndex))
        End If
    End Sub

  
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clear_button.Click
        txtDataReceived.Clear()

        Try
            SerialPort1.DiscardInBuffer()
            SerialPort1.DiscardOutBuffer()
            SerialPort1.Close()
            SerialPort1.Open()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Sent_data2(ByVal Channal As Integer, ByVal Value As Integer)
        Dim rs232(0) As Byte
        Try
            rs232(0) = CType(&HF0, Byte)
            SerialPort1.Write(rs232, 0, 1)   'F0
            rs232(0) = CType(Channal, Byte)
            SerialPort1.Write(rs232, 0, 1)   'FF    '
            SerialPort1.Write(Chr(&HF))      '0F
            rs232(0) = CType(Value, Byte)
            SerialPort1.Write(rs232, 0, 1)   'FF

            rs232(0) = CType(&HF0, Byte)
            SerialPort1.Write(rs232, 0, 1)   'F0
            rs232(0) = CType(Channal, Byte)
            SerialPort1.Write(rs232, 0, 1)   'FF
            SerialPort1.Write(Chr(&HF))      '0F
            rs232(0) = CType(Value, Byte)
            SerialPort1.Write(rs232, 0, 1)   'FF

        Catch ex As Exception
            MsgBox("COMPort可能已經關閉或者當機，請重新開啟")
        End Try
    End Sub
    Private Sub SerialPort1_PinChanged(ByVal sender As Object, ByVal e As System.IO.Ports.SerialPinChangedEventArgs) Handles SerialPort1.PinChanged
        SerialPort1.DiscardInBuffer()
        SerialPort1.DiscardOutBuffer()
        If SerialPort1.IsOpen = True Then
            Timer1.Enabled = False
            SerialPort1.Close()
            SerialPort1.Open()
            Timer1.Enabled = True

        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        For ssss As UInteger = 0 To 10000 Step 1
            While SerialPort1.BytesToRead > 0
            End While
        Next
        TXIF = 0
        If LaBar1.Value <> ValText1.Text Then

            '   ValText1.Text = LaBar1.Value
            Sent_data2(1, LaBar1.Value)

        End If
    End Sub

End Class
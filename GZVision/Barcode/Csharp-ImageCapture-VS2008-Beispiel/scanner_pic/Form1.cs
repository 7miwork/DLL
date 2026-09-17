// C# Sample Image Capture program for Opticon 2D Scanners by Oscar Jacobse
// More Info: MDI-4000 Series Image Capture Manual.pdf and
// MDI-3x00 Serial Interface Spec.pdf
// www.opticon.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;

namespace scanner_pic
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort;
        readonly static int width = 639; //751;
        readonly static int height = 479;
        byte[] rx_buf = new byte[1024];         // Receive buffer
        Bitmap my_picture;                      // Picture to store received data in
        BitmapData bitmapData;                  // the Bitmap bits
        int offset;
        int line;

        public Form1()
        {
            InitializeComponent();
            _serialPort = new SerialPort();
            using (ManagementClass i_Entity = new ManagementClass("Win32_PnPEntity"))
            {
                foreach (ManagementObject i_Inst in i_Entity.GetInstances())
                {
                    Object o_Guid = i_Inst.GetPropertyValue("ClassGuid");
                    if (o_Guid == null || o_Guid.ToString().ToUpper() != "{4D36E978-E325-11CE-BFC1-08002BE10318}")
                        continue; // Skip all devices except device class "PORTS"
                    String s_DeviceID = i_Inst.GetPropertyValue("PnpDeviceID").ToString();
                    String s_RegPath = "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Enum\\" + s_DeviceID + "\\Device Parameters";
                    String s_PortName = Registry.GetValue(s_RegPath, "PortName", "").ToString();
                    String s_Description = i_Inst.GetPropertyValue("Description").ToString();
                    //MessageBox.Show(s_Description);
                    if (s_Description.Contains("Opticon"))  // find first ComPort that has a Opticon Scanner attached to it.
                    {
                        _serialPort.PortName = s_PortName;
                        break;
                    }
                }
            }
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(MyDataReceivedHandler);
            _serialPort.Handshake = Handshake.None;
            _serialPort.BaudRate = 9600;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.ReadBufferSize = 1024;
            _serialPort.DiscardNull = false;
            _serialPort.Open();
            _serialPort.DiscardInBuffer();
            pictureBox1.Size = new Size(width, height);
            this.Size = new Size(width, height+100);    // Size Window to fit picturebox
            my_picture = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            ColorPalette pal = my_picture.Palette;
            for (int i = 0; i < 256; i++)
                pal.Entries[i] = Color.FromArgb(i, i, i);   // 256 Grayscale palette
            my_picture.Palette = pal;
        }

        void MyDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            /* receive the records from the barcode scanner                       */
            /* format:                                                            */
            /*   0    1  2    3 4 5 6    length bytes        2 bytes              */
            /* +---+--------+--------+-----------//-------+----------+------+     */
            /* | ! | Rec no | length |       data         | Checksum | 0x0d |     */
            /* +---+--------+--------+-----------//-------+----------+------+     */
            int bytesToRead;
            int n;
            byte[] answer = { 'F'-'@', 'U'-'@' };  // ACK / NAK

            while ((bytesToRead = _serialPort.BytesToRead) > 0)
            {
                offset += _serialPort.Read(rx_buf, offset, bytesToRead);
            }
            if (offset >= 7)
            {
                if (rx_buf[0] != '!')
                {
                    offset = 0;
                    _serialPort.Write(answer, 1, 1);    // NAK
                    return;
                }
                n = 1;
                int rec_no = rx_buf[n++];
                rec_no <<= 8;
                rec_no |= rx_buf[n++];
                int len = rx_buf[n++];
                len <<= 8;
                len |= rx_buf[n++];
                len <<= 8;
                len |= rx_buf[n++];
                len <<= 8;
                len |= rx_buf[n++];
                if (offset < (n + len + 1 + 1 + 1)) // '!' + R + R + L + L + L + L + data + Chi + Clo + '\r'
                {
                    return;         // there is more data needed....
                }
                offset = 0;             // whole packet is received, set offset to 0 for next packet
                ushort checksum = 0;
                for (int i = 0; i < len; i++)                  // calculate checksum over the data bytes only
                    checksum += (ushort)(rx_buf[n + i] * (i + 1));
                if (((checksum >> 8) == rx_buf[n + len]) && ((checksum & 0x00FF) == rx_buf[n + len + 1]))
                {
                    if (rec_no != 0)		// first record contains picture info, not BMP data
                    {
                        if (line < height)  // Copy the received data to the picture
                            Marshal.Copy(rx_buf, n, new IntPtr(bitmapData.Scan0.ToInt64() + line * bitmapData.Stride), len);
                        line++;
                        if (line == height)     // Ready
                        {
                            my_picture.UnlockBits(bitmapData);
                            this.Invoke((MethodInvoker)(() => pictureBox1.Image = my_picture));
                        }
                    }
                    _serialPort.Write(answer, 0, 1);    // ACK
                }
                else
                    _serialPort.Write(answer, 1, 1);    // NAK
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] command = { '[' - '@',  // ESC
                               (byte)'[',  // Q1 Q0 Qc Qd Qe Qf  Set leftmost value for cropping 1000c + 100d + 10e + f = 0 ~ 751
                               (byte)'D', 
                               (byte)'E',
                               (byte)'7',
                               (byte)'Q',
                               (byte)'1',
                               (byte)'Q',
                               (byte)'0',
                               (byte)'Q',
                               (byte)'0',  // c
                               (byte)'Q',
                               (byte)'0',  // d
                               (byte)'Q',
                               (byte)'0',  // e
                               (byte)'Q',
                               (byte)'0',  // f
                               (byte)'[', //Q1 Q1 Qc Qd Qe Qf  Set top edge value for cropping 1000c + 100d + 10e + f = 0 ~ 479 
                               (byte)'D',
                               (byte)'E',
                               (byte)'7',
                               (byte)'Q',
                               (byte)'1',
                               (byte)'Q',
                               (byte)'1',
                               (byte)'Q',
                               (byte)'0',  // c
                               (byte)'Q',
                               (byte)'0',  // d
                               (byte)'Q',
                               (byte)'0',  // e
                               (byte)'Q',
                               (byte)'0',  // f
                               (byte)'[',  // Q1 Q2 Qc Qd Qe Qf  Set rightmost value for cropping 1000c + 100d + 10e + f = 0 ~ 751 
                               (byte)'D',     
                               (byte)'E',
                               (byte)'7',
                               (byte)'Q',
                               (byte)'1',
                               (byte)'Q',
                               (byte)'2',
                               (byte)'Q',
                               (byte)('0' + (width / 1000)),  // c
                               (byte)'Q',
                               (byte)('0' + ((width % 1000) / 100)),  // d
                               (byte)'Q',
                               (byte)('0' + ((width % 100) / 10)),  // e
                               (byte)'Q',
                               (byte)('0' + (width % 10)),  // f
                               (byte)'[', // Q1 Q3 Qc Qd Qe Qf  Set bottom edge value for cropping 1000c + 100d + 10e + f = 0 ~ 479
                               (byte)'D',
                               (byte)'E',
                               (byte)'7',
                               (byte)'Q',
                               (byte)'1',
                               (byte)'Q',
                               (byte)'3',
                               (byte)'Q',
                               (byte)('0' + (height / 1000)),  // c
                               (byte)'Q',
                               (byte)('0' + ((height % 1000) / 100)),  // d
                               (byte)'Q',
                               (byte)('0' + ((height % 100) / 10)), // e
                               (byte)'Q',
                               (byte)('0' + (height % 10)),  // f
                               (byte)'[',    // Q2 Q0 Q0 Q0 Q0 Qf Set horizontal subsampling f = 1, 2, 4
                               (byte)'D',
                               (byte)'E',
                               (byte)'7',
                               (byte)'Q',
                               (byte)'2',
                               (byte)'Q',
                               (byte)'0',
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'1',  // f
                               (byte)'[',  // Q3 Q0 Q0 Q0 Q0 Qf Set bit depth (bits per pixel) f = 0: 8 bits (256 values)
                               (byte)'D',
                               (byte)'E',
                               (byte)'7',
                               (byte)'Q',
                               (byte)'3',
                               (byte)'Q',
                               (byte)'0',
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'0',  // f
                               (byte)'[',  // Q5 Q0 Q0 Q0 Q0 Qf Output format f = 3: BMP
                               (byte)'D',
                               (byte)'E',
                               (byte)'7',
                               (byte)'Q',
                               (byte)'5',
                               (byte)'Q',
                               (byte)'0',
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'0',  
                               (byte)'Q',
                               (byte)'3',  // f
                               (byte)'[',  //  Q6 Q0 Q0 Q0 Q0 Qf Transmission mode f = 0: PART
                               (byte)'D',
                               (byte)'E',
                               (byte)'7',
                               (byte)'Q',
                               (byte)'6',
                               (byte)'Q',
                               (byte)'0',
                               (byte)'Q',
                               (byte)'0',
                               (byte)'Q',
                               (byte)'0',
                               (byte)'Q',
                               (byte)'0',
                               (byte)'Q',
                               (byte)'0', // f
                               (byte)'\r'
                             };
            for (int i = 0; i < command.Length; i++)
                _serialPort.Write(command, i, 1);
            Thread.Sleep(250);
            _serialPort.DiscardInBuffer();
            line = 0;
            offset = 0;
            bitmapData = my_picture.LockBits(new Rectangle(0, 0, width, height),
                            ImageLockMode.WriteOnly, my_picture.PixelFormat);
            byte[] take_picture = { '[' - '@', // take picture immediately
                               (byte) '[', 
                               (byte) 'D',
                               (byte) 'E',
                               (byte) '8',
                               (byte) 'Q',
                               (byte) '0',
                               (byte) '\r'
                              };
            for (int i = 0; i < take_picture.Length; i++)
                _serialPort.Write(take_picture, i, 1);
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace MiLightYL5
{
    public partial class MiLight : Form
    {
        public Socket clientSocket; //The main client socket
        public EndPoint epServer;   //The EndPoint of the server
        byte[] byteData = new byte[1024];

        byte[] identifier = { 0xFA, 0xCE };
        byte[] sequenceCounter = { 0, 0 };
        byte[] sessionId = { 0, 0 };

        int brightness = 0;
        int dimmStep = 0;
        bool lightOn = false;
        bool nightlightOn = false;
        string statusResponse = "";

        Timer tKeepAlive = new Timer();
        Timer tDimmer = new Timer();

        public MiLight()
        {
            InitializeComponent();
        }

        private void btOpenSocket_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);

            IPAddress ipAddress = IPAddress.Parse(tbIp.Text);
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 5987);
            epServer = (EndPoint)ipEndPoint;

            clientSocket.Connect(epServer);

            byteData = new byte[1024];
            clientSocket.BeginReceiveFrom(byteData,
                                       0, byteData.Length,
                                       SocketFlags.None,
                                       ref epServer,
                                       new AsyncCallback(OnReceive),
                                       null);

            Random rnd = new Random();
            rnd.NextBytes(sequenceCounter);
            if(clientSocket.Connected)
            {
                btOpenSocket.Text = "Socket active";
                btOpenSocket.Enabled = false;
                tbIp.Enabled = false;
            }
        }

        private void btPair_Click(object sender, EventArgs e)
        {
            if (clientSocket==null)
                return;

            tKeepAlive.Interval = 8000;
            tKeepAlive.Tick += new EventHandler(TKeepAlive_Tick);
            tKeepAlive.Start();

            byte[] snd = { 0x23, 0x00, 0x00, 0x00, 0x18, 0x03, sequenceCounter[0], ++sequenceCounter[1], 0x09, 0x9c, 0x28, 0xf2, 0x95, 0x10, 0xc7, 0x93, 0x8b, 0xc8, 0xc3, 0x07, 0xd2, 0x87, 0x55, 0x7f, identifier[0], identifier[1], 0x00, 0x00, 0x64 };
            sendData(snd);
            System.Threading.Thread.Sleep(1000);
            tbSessionId.Text = sessionId[0].ToString("X2") + sessionId[1].ToString("X2");
        }

        private void TKeepAlive_Tick(object sender, EventArgs e)
        {
            byte[] cmdData = { 0x43, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x80 };
            command(cmdData);
            tKeepAlive.Start();
        }

        private void command(byte[] cmdData)
        {
            if (clientSocket == null)
                return;

            byte[] snd = { 0x83, 0x00, 0x00, 0x00, 0x11, sessionId[0], sessionId[1], sequenceCounter[0], ++sequenceCounter[1], 0x00, 0x41, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            Array.Copy(cmdData, 0, snd, 10, 11);

            snd[21] = (byte)(cmdData[0] + cmdData[1] + cmdData[2] + cmdData[3] + cmdData[4] + cmdData[5] + cmdData[6] + cmdData[7] + cmdData[8] + cmdData[9] + cmdData[10]);
            sendData(snd);
        }

        private void sendData(byte[] sndData)
        {
            clientSocket.BeginSendTo(sndData, 0, sndData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                clientSocket.Close();
            }
            catch (Exception)
            { }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (Exception)
            { }
        }

        private bool isSessionResponse(byte[] msgReceive)
        {
            if (msgReceive.Length == 26)
            {
                if (msgReceive[0] == 0x2b &&
                    msgReceive[1] == 0x00 &&
                    msgReceive[2] == 0x00 &&
                    msgReceive[3] == 0x00 &&
                    msgReceive[4] == 0x15 &&
                    msgReceive[5] == 0x00 &&
                    msgReceive[6] == 0x03)
                {
                    sessionId[0] = msgReceive[23];
                    sessionId[1] = msgReceive[24];                    
                    return true;
                }
            }
            return false;
        }

        private bool isKeepAlive(byte[] msgReceive)
        {
            if (msgReceive.Length == 28)
            {
                if (msgReceive[0] == 0x83 &&
                    msgReceive[1] == 0x00 &&
                    msgReceive[2] == 0x00 &&
                    msgReceive[3] == 0x00 &&
                    msgReceive[4] == 0x17 &&
                    msgReceive[5] == 0x00 &&
                    msgReceive[6] == 0x06)
                {
                    return true;
                }
            }
            return false;
        }

        private void updateStatus(byte[] msgReceive)
        {
            if (msgReceive.Length >=26 && (msgReceive[16] == 0x42 || msgReceive[16] == 0x44))
            {
                switch (msgReceive[20])
                {
                    case 0x00:
                        lightOn = false;
                        nightlightOn = false;
                        break;
                    case 0x02:
                        lightOn = true;
                        nightlightOn = false;
                        break;
                    case 0x12:
                        nightlightOn = true;
                        break;
                }
                brightness = msgReceive[23];
                statusResponse = "";
                for(int i=0;i< msgReceive.Count(); i++)
                {
                    statusResponse += msgReceive[i].ToString("X2") + ",";
                }
            }

        }

        private void refresh()
        {
            tbSessionId.Text = sessionId[0].ToString("X2") + sessionId[1].ToString("X2") + " " + brightness.ToString() + "%";
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int bufferLength = clientSocket.EndReceive(ar);
                byte[] msgReceived = new byte[bufferLength];
                Array.Copy(byteData, msgReceived, bufferLength);

                byteData = new byte[1024];
                clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epServer, new AsyncCallback(OnReceive), null);

                if (isSessionResponse(msgReceived))
                    return;

                if (isKeepAlive(msgReceived))
                {
                    byte[] snd = { 0x8b, 0x00, 0x00, 0x00, 0x03, 0x00, msgReceived[14], msgReceived[15] };
                    sendData(snd);
                }

                updateStatus(msgReceived);

            }
            catch (Exception ex)
            { }
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace("0x", "").Replace(",", "").Replace(" ", "");
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void btOn_Click(object sender, EventArgs e)
        {
            byte[] cmdData = { 0x41, 0x00, 0x00, 0x80, 0x06, 0x01, 0x00, 0x00, 0x00, 0x80, 0x80 };
            command(cmdData);
        }

        private void btOff_Click(object sender, EventArgs e)
        {
            byte[] cmdData = { 0x41, 0x00, 0x00, 0x80, 0x06, 0x02, 0x00, 0x00, 0x00, 0x80, 0x80 };
            command(cmdData);
        }

        private void btSetBrightness_Click(object sender, EventArgs e)
        {
            int brightness = 0;
            if (int.TryParse(tbBrightness.Text, out brightness) && brightness > 0 && brightness <= 100)
            {
                byte[] cmdData = { 0x41, 0x00, 0x00, 0x80, 0x02, (byte)brightness, 0x00, 0x00, 0x00, 0x80, 0x80 };
                command(cmdData);
            }
        }

        private void btSetSaturation_Click(object sender, EventArgs e)
        {
            int saturation = 0;
            if (int.TryParse(tbSaturation.Text, out saturation) && saturation >= 0 && saturation <= 100)
            {
                byte[] cmdData = { 0x41, 0x00, 0x00, 0x80, 0x04, (byte)saturation, 0x00, 0x00, 0x00, 0x80, 0x80 };
                command(cmdData);
            }
        }

        private void btSetRgb_Click(object sender, EventArgs e)
        {
            int rgb = 0;
            if (int.TryParse(tbRgb.Text, out rgb) && rgb >= 0 && rgb <= 255)
            {
                byte[] cmdData = { 0x41, 0x00, 0x00, 0x80, 0x01, (byte)rgb, (byte)rgb, (byte)rgb, (byte)rgb, 0x80, 0x80 };
                command(cmdData);
            }
        }
        
        private void btSetColorTemp_Click(object sender, EventArgs e)
        {
            int colorTemp = 0;
            if (int.TryParse(tbSaturation.Text, out colorTemp) && colorTemp >= 0 && colorTemp <= 38)
            {
                byte[] cmdData = { 0x41, 0x00, 0x00, 0x80, 0x03, (byte)colorTemp, 0x00, 0x00, 0x00, 0x80, 0x80 };
                command(cmdData);
            }
        }

        private void btSendCmd_Click(object sender, EventArgs e)
        {

            byte[] cmdData = StringToByteArray(tbCommand.Text);
            if (cmdData.Length > 0)
            {
                command(cmdData);
            }
        }

        private void btDim_MouseDown(object sender, MouseEventArgs e)
        {
            int setInterval = 0;
            int setStep = 0;

            if (int.TryParse(tbDimSpeed.Text, out setInterval) && setInterval > 0 &&
                int.TryParse(tbDimSteps.Text, out setStep) && setStep > 0 && setStep < 100)
            {
                if(dimmStep > 0)
                {
                    dimmStep = -setStep;
                }
                else
                {
                    dimmStep = setStep;
                }

                tDimmer.Interval = setInterval * 100;
                tDimmer.Tick += new EventHandler(TDimmer_Tick);
                TDimmer_Tick(this, e);
            }
            
        }

        private void btDim_MouseUp(object sender, MouseEventArgs e)
        {
            tDimmer.Stop();
        }

        private void TDimmer_Tick(object sender, EventArgs e)
        {
            brightness += dimmStep;
            if (brightness < 1)
                brightness = 1;
            else if (brightness > 100)
                brightness = 100;

            byte[] cmdData = { 0x41, 0x00, 0x00, 0x80, 0x02, (byte)brightness, 0x00, 0x00, 0x00, 0x80, 0x80 };
            command(cmdData);
            tDimmer.Start();
        }

        private void btGetStatus_Click(object sender, EventArgs e)
        {
            tbStatus.Text = statusResponse;
        }
    }
}

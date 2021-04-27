using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_UDP_Chatting
{
    public partial class FormMain : Form
    {
        Socket udpServerSocket = null;
        Thread receiptThread = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private delegate void PrintTextCB(string str);

        private void PrintText(string str)
        {
            if (TbOutput.InvokeRequired)
            {
                Invoke(new PrintTextCB(PrintText), str);
            }
            else
            {
                TbOutput.AppendText(str + "\r\n");
            }
        }

        private void MnuStart_Click(object sender, EventArgs e)
        {
            // TCP 구성 순서     1. 소켓 생성     2. EndPoint 구성      3. Binding      4. Listening
            // UDP 구성 순서     1. 소켓 생성     2. EndPoint 구성      3. Binding
            if(udpServerSocket == null)
            {
                // 소켓 생성
                udpServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            }

            // EndPoint 구성 - IPAddress.Any는 어느곳에서든 매개변수가 나타내는 포트로 들어오는 신호들을 받아드린다는 의미입니다.
            //IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(SLabel2.Text));

            // 특정 주소(sbLabel3)로 들어오는 메시지를 처리하도록 합니다.
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(SLabel3.Text), int.Parse(SLabel4.Text));

            // Binding
            udpServerSocket.Bind(iPEndPoint);

            if(receiptThread == null)
            {
                receiptThread = new Thread(receiptProcess);
                receiptThread.Start();
            }
        }

        private void receiptProcess()
        {
            while (true)
            {
                if (udpServerSocket.Available > 0)
                {
                    byte[] bArr = new byte[udpServerSocket.Available];
                    udpServerSocket.Receive(bArr);
                    PrintText(Encoding.Default.GetString(bArr));
                }
                Thread.Sleep(100);
            }
        }

        // Port Change
        private void SLabel2_DoubleClick(object sender, EventArgs e)
        {
            SLabel2.Text = MyLib.GetInput("Port");

        }

        private void SLabel1_DoubleClick(object sender, EventArgs e)
        {
            SLabel1.Text = MyLib.GetInput("IP Address");
        }

        // UDP 송신   1. Socket(1회성) 생성    2. EndPoint 구성      3. Send
        private void UdpSend(string str)
        {
            Socket localSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(SLabel1.Text), int.Parse(SLabel2.Text));
            // TCP를 사용할 때에는 새로 만든 소켓이 아니라 Listen, Accept으로 받은 세션을 사용합니다.
            // UDP를 사용할 때에는 소켓을 새로 만들기 때문에 단순 byte[]를 매개변수로 가지는 Send()를 사용할 수 없습니다.
            // Send()는 지정된 ip를 사용합니다.
            // UDP사용시에는 SendTo()를 사용합니다.
            localSocket.SendTo(Encoding.Default.GetBytes(str), iPEndPoint);
        }

        private void MnuSend_Click(object sender, EventArgs e)
        {
            UdpSend(TbInput.Text);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (receiptThread != null)
            {
                receiptThread.Abort();
            }
        }

        private void SLabel3_DoubleClick(object sender, EventArgs e)
        {
            SLabel3.Text = MyLib.GetInput("IP Address");
        }

        private void SLabel4_DoubleClick(object sender, EventArgs e)
        {
            SLabel4.Text = MyLib.GetInput("Port");
        }

    }
}

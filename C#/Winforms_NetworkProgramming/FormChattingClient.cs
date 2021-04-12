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

namespace WinForms_Chatting_Client
{
    public partial class FormChattingClient : System.Windows.Forms.Form
    {

        Socket socket = null;
        Thread receiveThread = null;
        IniFile iniFile = new IniFile(@".\FormChattingClient.ini");

        public FormChattingClient()
        {
            InitializeComponent();
        }

        delegate void AddTextCallBack(string str);

        private void AddText(string str)
        {
            if (tbReceive.InvokeRequired)
            {
                // AddTextCallBack addTextCallBack = new AddTextCallBack(AddText);
                // Invoke(addTextCallBack, new object[] { str });
                Invoke(new AddTextCallBack(AddText), str);
            }
            else
            {
                // .AppendText(string) 메소드는 string 객체를 새로 생성하지 않고,
                // 기존의 string 객체 뒤에 매개변수 문자열을 더합니다.
                tbReceive.AppendText(str);
            }
        }

        private void FormChattingClient_Load(object sender, EventArgs e)
        {
            tbIP.Text = iniFile.GetString("Server", "IP", "127.0.0.1");
            tbPort.Text = iniFile.GetString("Server", "Port", "9001");
            int openPointX = int.Parse(iniFile.GetString("Form", "OpenPointX", "300"));
            int openPointY = int.Parse(iniFile.GetString("Form", "OpenPointY", "300"));
            this.Location = new Point(openPointX, openPointY);
            int sizeWidth = int.Parse(iniFile.GetString("Form", "SizeWidth", "800"));
            int sizeHeight = int.Parse(iniFile.GetString("Form", "SizeHeigh", "800"));
            this.Size = new Size(sizeWidth, sizeHeight);
        }

        // 폼의 크기 변경이나 스플리터를 직접 조절할 때 패널의 크기를 고정하는 메소드입니다.
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            // 고정시킬 상단부 패널의 크기입니다.
            int size = 40;
            // 상단부 패널의 크기를 설정합니다.
            splitContainer1.SplitterDistance = size;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (socket == null)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }

                // 커넥션을 구성합니다. (연결을 시도합니다.) 
                socket.Connect(tbIP.Text, int.Parse(tbPort.Text));

                // EndPoint : 접속을 시도한 대상의 마지막 부분(끝 점)을 의미합니다.
                // Socket.LocalEndPoint : 연결을 시도하는 측(클라이언트 측)의 끝 점
                // Socket.RemoteEndPoint : 연결을 시도하는 타겟(서버 측)의 끝 점
                // socket.RemoteEndPoint.ToString();   // "IP번호 : 세션번호"가 리턴됩니다.
                sbIp.Text = ((IPEndPoint)socket.RemoteEndPoint).Address.ToString();
                sbPort.Text = ((IPEndPoint)socket.RemoteEndPoint).Port.ToString();

                // ReceiveProcess()를 수행하는 스레드를 생성하고 실행합니다.
                if (receiveThread == null)
                {
                    receiveThread = new Thread(ReceiveProcess);
                    receiveThread.Start();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        // Thread로 동작시키는 메소드입니다.
        private void ReceiveProcess()
        {
            while (true)
            {
                if (socket != null && socket.Connected)
                {
                    int n = socket.Available;
                    if (n > 0)
                    {
                        //C#에서의 통신은 byte[] ,  C/C++ = char
                        byte[] bArr = new byte[n];
                        socket.Receive(bArr);
                        // byte[]의 size 만큼 변환하는 것이 필요합니다. (변환하지 않으면 null이 포함되어 대입됩니다.)
                        string str = Encoding.Default.GetString(bArr);
                        AddText(str);
                    }
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (socket.Connected == true)
            {
                //string str = tbSend.Text.Split('\r').Last();
                string str = tbSend.Text.Trim();
                // 텍스트박스의 각 라인 끝에는 \n\r(CRLF)이 있습니다.
                string[] sArr = str.Split('\r');
                // sArr의 마지막 요소를 sLast에 대입합니다.
                string sLast = sArr[sArr.Length - 1];

                socket.Send(Encoding.Default.GetBytes(sLast));
            }
        }

        private void FormChattingClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            iniFile.WriteString("Server", "IP", tbIP.Text);
            iniFile.WriteString("Server", "Port", tbPort.Text);
            iniFile.WriteString("Form", "OpenPointX", $"{Location.X}");
            iniFile.WriteString("Form", "OpenPointY", $"{Location.Y}");
            iniFile.WriteString("Form", "SizeWidth", $"{Size.Width}");
            iniFile.WriteString("Form", "SizeHeigh", $"{Size.Height}");            
        }
    }
}

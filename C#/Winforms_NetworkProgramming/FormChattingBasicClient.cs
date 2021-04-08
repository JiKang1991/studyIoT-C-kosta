using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Chatting_Basic
{
    public partial class FormChattingBasicClient : Form
    {
        IniFile ini;
        private TcpListener listener = null;
        Socket socket;
        Thread listeningThread;

        /*
            [DllImport("kernel32")]
            static extern int GetPrivateProfileString(string sec, string key, string defStr, StringBuilder sb, int nsb, string path);
        
            [DllImport("kernel32")]
            static extern int WritePrivateProfileString(string sec, string key, string str, string path);
        */
        public FormChattingBasicClient()
        {
            InitializeComponent();                        
        }

        // delegate
        // c/c++ function pointer와 같은 역할을 합니다.
        // string str을 매개변수로 받아서 tbServer에 출력하는 callback 함수 입니다.
        delegate void AddTextCallBack(string str);

        // invoke
        // thread 내부에서 호출하는 함수입니다. sbServer에 출력하는 기능이 정의됩니다.
        private void AddText(string str)
        {
            if (tbClientView.InvokeRequired)
            {
                //AddTextCallBack addTextCallBack = new AddTextCallBack(AddText);
                // Invoke(addTextCallBack, new object[] { str });
                Invoke(new AddTextCallBack(AddText), str);
            }
            else
            {
                tbClientView.Text += str;
            }
        }


        private void FormChattingBasicClient_Load(object sender, EventArgs e)
        {
            ///===========================================
            /// 로드시 양식 및 형태 초기화 영역
            ///=======================
            string initIP = "127.0.0.1";
            int initPort = 9001;
            int openPointX = 200;
            int openPointY = 200;
            int sizeWidth = 600;
            int sizeHeight = 600;

            ini = new IniFile(@".\ComClient.ini");

            initIP = ini.GetString("Comm", "IP", "127.0.0.1");
            initPort = int.Parse(ini.GetString("Comm", "Port", "9001"));
            openPointX = int.Parse(ini.GetString("Form", "OpenPointX", "300"));
            openPointY = int.Parse(ini.GetString("Form", "OpenPointY", "300"));
            sizeWidth = int.Parse(ini.GetString("Form", "SizeWidth", "800"));
            sizeHeight = int.Parse(ini.GetString("Form", "SizeHeigh", "800"));
            //splitContainer1.SplitterDistance = int.Parse(ini.GetString("Form", "SizeSplitter", "500"));

            /*
            StringBuilder sb = new StringBuilder(512);
            // 파일, 섹션, 키가 없을 경우에는 sb에 기본값이 저장됩니다.
            GetPrivateProfileString("Comm", "IP", "127.0.0.1", sb, 512, @".\ComClient.ini");  // Section [Comm], Key[IP, Port] , FileName[ComClient.ini]
            initIP = sb.ToString();            
            GetPrivateProfileString("Comm", "Port", "9001", sb, 512, @".\ComClient.ini");
            initPort = int.Parse(sb.ToString());
            GetPrivateProfileString("Form", "OpenPointX", "300", sb, 512, @".\ComClient.ini");
            openPointX = int.Parse(sb.ToString());
            GetPrivateProfileString("Form", "OpenPointY", "300", sb, 512, @".\ComClient.ini");
            openPointY = int.Parse(sb.ToString());
            GetPrivateProfileString("Form", "SizeWidth", "800", sb, 512, @".\ComClient.ini");
            sizeWidth = int.Parse(sb.ToString());            
            GetPrivateProfileString("Form", "SizeHeigh", "800", sb, 512, @".\ComClient.ini");
            sizeHeight = int.Parse(sb.ToString());
            GetPrivateProfileString("Form", "SizeSplitter", "500", sb, 512, @".\ComClient.ini");
            splitContainer1.SplitterDistance = int.Parse(sb.ToString());
            */

            tbSendIP.Text = initIP;
            tbSendPort.Text = $"{initPort}";
            Location = new Point(openPointX, openPointY);
            Size = new Size(sizeWidth, sizeHeight);

            ///===========================================
            /// 로드시 수신 스레드 생성 영역
            ///=======================
            //Thread listeningThread = new Thread(listeningThreadProcess);
            //listeningThread.Start();

        }

        private void listeningThreadProcess()
        {
            while (true)
            {
                if (socket != null && socket.Connected)
                {
                    int n = socket.Available;
                    if (n > 0) {
                        // Socket.Available을 사용하여 byte 배열의 크기를 동적으로 하여 생성합니다.
                        //byte[] bArr = new byte[receiveSocket.Available];
                        byte[] bArr = new byte[n];

                        // byte 배열의 크기를 동적으로 할당하므로 while문을 사용하지 않습니다.
                        //int sizeOfReceive = receiveSocket.Receive(bArr);
                        socket.Receive(bArr); // listener가 없어도 Receive가 가능한건가????

                        string str = Encoding.Default.GetString(bArr);
                        AddText(str);
                    }
                }
                // 시스템 자원 관리를위해?
                Thread.Sleep(100); // ???? 대규모 서비스의 경우 문제가 되지는 않는가?
            }
            /*
            while (true){
                // TcpListener을 최초 1회만 생성하고 시작하기 위해 listener가 null일 경우에만 생성과 시작을 합니다.
                if (listener == null)
                {
                    listener = new TcpListener(int.Parse(tbReceivePort.Text));
                    listener.Start();
                }

                // TcpListener.Pending() 메소드는 외부에서 TcpListener에 대한 요청의 여부를 확인합니다.
                // 블록 내부의 TcpListener.AcceptTcpClient() 메소드는 TcpListener에 대한 요청을 수신할 때 까지
                // 스레드의 동작을 정지하므로 이를 피하고 요청이 없을 때에는 다른 작업을 수행하도록 설정합니다.
                if (listener.Pending())
                {
                    // TcpClient가 아닌 Socket을 이용해서 Accept 및 입력 stream 처리
                    //Socket receiveSocket = listener.AcceptSocket();
                    socket = listener.AcceptSocket();         
                }
            }
            */
        }


        // packet = 한 번에 전송하는 메시지 단위 
        // 1 packet을 전송하는 메소드 입니다.
        private void btnSend_Click(object sender, EventArgs e)
        {

            // 데이터를 전송합니다. ( 문자열 외에 이미지나 동영상도 가능합니다. 단, 양측간 약속된 규약(프로토콜)에 의거해야 합니다.)
            // string자료형으로는 전송이 불가하브로 byte 배열로 encoding하여 전송합니다.
            int ret = socket.Send(Encoding.Default.GetBytes(tbClient.Text));

            // byte[] bArr = new byte[200];
            //int n = socket.Receive(bArr);
            //tbClient.Text += $"......{Encoding.Default.GetString(bArr, 0, n)}";

            if (ret > 0)
            {
                sbMessage.Text = "succeed";
            }
            //socket.Close();
        }

        private void FormChattingBasicClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Comm", "IP", tbSendIP.Text);
            ini.WriteString("Comm", "Port", tbSendPort.Text);
            ini.WriteString("Form", "OpenPointX", $"{Location.X}");
            ini.WriteString("Form", "OpenPointY", $"{Location.Y}");
            ini.WriteString("Form", "SizeWidth", $"{Size.Width}");
            ini.WriteString("Form", "SizeHeigh", $"{Size.Height}");
            //ini.WriteString("Form", "SizeSplitter", $"{splitContainer1.SplitterDistance}");

            //Point openPoint = formChattingBasicClient.Location;
            

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // socket이 null일 경우에만 소켓을 생성합니다.
            if (socket == null)
            {
                // Socket을 생성합니다. ( 소켓은 주소를 가지고 있지 않습니다. )
                // TCP : 수신을 확인합니다.     UDP : 수신을 확인하지 않습니다.( ex. 방송 )
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }

            // Socket을 Open(Connection 수립)합니다. ( 소켓에 주소를 부여합니다. )
            socket.Connect(tbSendIP.Text, int.Parse(tbSendPort.Text));

            if (listeningThread == null)
            {
                listeningThread = new Thread(listeningThreadProcess);
                listeningThread.Start();
            }

        }
    }
}

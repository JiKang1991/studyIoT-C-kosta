using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Chatting_Basic
{
    public partial class FormChattingBasicClient : Form
    {
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string sec, string key, string defStr, StringBuilder sb, int nsb, string path);
        
        [DllImport("kernel32")]
        static extern int WritePrivateProfileString(string sec, string key, string str, string path);
        
        public FormChattingBasicClient()
        {
            InitializeComponent();                        
        }

        string initIP = "127.0.0.1";
        int initPort = 9001;
        int openPointX = 200;
        int openPointY = 200;
        int sizeWidth = 600;
        int sizeHeight = 600;
        

        private void FormChattingBasicClient_Load(object sender, EventArgs e)
        {
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

            tbIP.Text = initIP;
            tbPort.Text = $"{initPort}";
            Location = new Point(openPointX, openPointY);
            Size = new Size(sizeWidth, sizeHeight);
        }



        // packet = 한 번에 전송하는 메시지 단위 
        // 1 packet을 전송하는 메소드 입니다.
        private void btnSend_Click(object sender, EventArgs e)
        {
            // Socket을 생성합니다. ( 소켓은 주소를 가지고 있지 않습니다. )
            // TCP : 수신을 확인합니다.     UDP : 수신을 확인하지 않습니다.( ex. 방송 )
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Socket을 Open(Connection 수립)합니다. ( 소켓에 주소를 부여합니다. )
            socket.Connect(tbIP.Text, int.Parse(tbPort.Text));

            // 데이터를 전송합니다. ( 문자열 외에 이미지나 동영상도 가능합니다. 단, 양측간 약속된 규약(프로토콜)에 의거해야 합니다.)
            // string자료형으로는 전송이 불가하브로 byte 배열로 encoding하여 전송합니다.
            socket.Send(Encoding.Default.GetBytes(tbClient.Text));
            sbClient.Text = "succeed";
            socket.Close();
        }

        private void FormChattingBasicClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            WritePrivateProfileString("Comm", "IP", tbIP.Text, @".\ComClient.ini");
            WritePrivateProfileString("Comm", "Port", tbPort.Text, @".\ComClient.ini");
            WritePrivateProfileString("Form", "OpenPointX", $"{Location.X}" , @".\ComClient.ini");
            WritePrivateProfileString("Form", "OpenPointY", $"{Location.Y}" , @".\ComClient.ini");
            WritePrivateProfileString("Form", "SizeWidth", $"{Size.Width}" , @".\ComClient.ini");
            WritePrivateProfileString("Form", "SizeHeigh", $"{Size.Height}" , @".\ComClient.ini");

            //Point openPoint = formChattingBasicClient.Location;
            

        }        
    }
}

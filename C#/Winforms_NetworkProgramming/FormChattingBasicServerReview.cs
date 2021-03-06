﻿using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Chatting_Basic_Server_Reveiw
{
    public partial class FormChattingBasicServerReview : Form
    {
        private TcpListener listener = null;
        private Thread thread = null;
        private string listenMessage = "";
        IniFile ini;
        Socket sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //MyLib myLib = new MyLib();
        /*
        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string sec, string key, string defStr, StringBuilder sb, int nsb, string path);

        [DllImport("kernel32")]
        static extern int WritePrivateProfileString(string sec, string key, string str, string path);
        */
        public FormChattingBasicServerReview()
        {
            InitializeComponent();
        }
              

        private void FormChattingBasicServerReview_Load(object sender, EventArgs e)
        {
            //ini = new IniFile(@".\ComServer.ini");
            ini = new IniFile("");
            ini.ChangeIniPath(@".\ComServer.ini");

            int initServerPort = 9001;
            int openPointX = 200;
            int openPointY = 200;
            int sizeWidth = 600;
            int sizeHeight = 600;

            initServerPort = int.Parse(ini.GetString("Comm", "ServerPort", "9001"));
            openPointX = int.Parse(ini.GetString("Form", "OpenPointX", "0"));
            openPointY = int.Parse(ini.GetString("Form", "OpenPointY", "300"));
            sizeWidth = int.Parse(ini.GetString("Form", "SizeWidth", "800"));
            sizeHeight = int.Parse(ini.GetString("Form", "SizeHeigh", "800"));
            //splitContainer1.SplitterDistance = int.Parse(ini.GetString("Form", "SizeSplitter", "500"));


           /*
               StringBuilder sb = new StringBuilder(512);

               // 파일, 섹션, 키가 없을 경우에는 sb에 기본값이 저장됩니다.
               GetPrivateProfileString("Comm", "ServerPort", "9001", sb, 512, @".\ComServer.ini");
               initServerPort = int.Parse(sb.ToString());

               GetPrivateProfileString("Form", "OpenPointX", "300", sb, 512, @".\ComServer.ini");
               openPointX = int.Parse(sb.ToString());

               GetPrivateProfileString("Form", "OpenPointY", "300", sb, 512, @".\ComServer.ini");
               openPointY = int.Parse(sb.ToString());

               GetPrivateProfileString("Form", "SizeWidth", "800", sb, 512, @".\ComServer.ini");
               sizeWidth = int.Parse(sb.ToString());

               GetPrivateProfileString("Form", "SizeHeigh", "800", sb, 512, @".\ComServer.ini");
               sizeHeight = int.Parse(sb.ToString());
           */

           tbServerPort.Text = $"{initServerPort}";
            Location = new Point(openPointX, openPointY);
            Size = new Size(sizeWidth, sizeHeight);
        }

        // delegate
        // c/c++ function pointer와 같은 역할을 합니다.
        // string str을 매개변수로 받아서 tbServer에 출력하는 callback 함수 입니다.
        delegate void AddTextCallBack(string str);

        // invoke
        // thread 내부에서 호출하는 함수입니다. sbServer에 출력하는 기능이 정의됩니다.
        private void addText(string str)
        {
            if (tbServer.InvokeRequired)
            {
                AddTextCallBack addTextCallBack = new AddTextCallBack(addText);
                Invoke(addTextCallBack, new object[] { str });
            }
            else
            {
                tbServer.Text += str;
            }
        }



        private void btnStart_Click(object sender, EventArgs e)
        {
            // 스레드가 null일 경우 새 스레드를 생성합니다.
            if (thread == null)
            {
                // linten 작업을 수행하는 스레드를 생성하고 수행합니다.
                thread = new Thread(listenThreadProcess);
                thread.Start();
            }            
            // 스레드가 실행 중인 경우 메시지 박스를 호출합니다.
            else
            {
                MessageBox.Show("스레드가 실행 중 입니다.");
            }
            ThreadState threadState = thread.ThreadState;
            sbServerMessage.Text = $"thread state - {threadState.ToString()}";
            //timer1.Enabled = true;
            timer1.Start();
            addText($"ServerProcess now started ... Open Port is {tbServerPort.Text}.");
        }

        private void listenThreadProcess()
        {
            while (true)
            {
                // TcpListener을 최초 1회만 생성하고 시작하기 위해 listener가 null일 경우에만 생성과 시작을 합니다.
                if (listener == null)
                {
                    listener = new TcpListener(int.Parse(tbServerPort.Text));
                    listener.Start();                    
                }

                // TcpListener.Pending() 메소드는 외부에서 TcpListener에 대한 요청의 여부를 확인합니다.
                // 블록 내부의 TcpListener.AcceptTcpClient() 메소드는 TcpListener에 대한 요청을 수신할 때 까지
                // 스레드의 동작을 정지하므로 이를 피하고 요청이 없을 때에는 다른 작업을 수행하도록 설정합니다.
                if (listener.Pending())
                {
                    // TcpClient = remote client의 socket과 연결
                    //TcpClient tcpClient = listener.AcceptTcpClient();
                                       
                    //EndPoint endPoint = tcpClient.Client.RemoteEndPoint;
                    // statusStrip 내부의 객체에는 해당 스레드에서 선언한 객체가 아니더라도 직접 호출이 가능합니다.
                    //sbServerLabel2.Text = endPoint.ToString();  // xxx.xxx.xxx.xxx:xxxxx

                    //NetworkStream networkStream = tcpClient.GetStream();
                    
                    //byte[] bArr = new byte[200];
                    // networkStream이 사용할 데이터가 남아있다면 블록 내부의 작업을 반복합니다.
                    //while (networkStream.DataAvailable)
                    //{
                        // NetworkStream.Read()메서드가 읽은 byte[]의 크기를 변수에 대입합니다.
                        // int sizeOfRead = networkStream.Read(bArr, 0, 200);
                        // byte 배열을 string 타입에 대입하기위해 Encoding을 수행합니다.
                        // 외부 스레드에 선언되어 있는 객체에 바로 접근할 수 없습니다.
                        // tbServer.Text += Encoding.Default.GetString(bArr, 0, sizeOfRead);
                        // listenMessage += Encoding.Default.GetString(bArr, 0, sizeOfRead);
                        //string str = Encoding.Default.GetString(bArr, 0, sizeOfRead);
                        //addText(str);
                    //}

                    // TcpClient가 아닌 Socket을 이용해서 Accept 및 입력 stream 처리
                    Socket socket = listener.AcceptSocket();
                    // Socket.Available을 사용하여 byte 배열의 크기를 동적으로 하여 생성합니다.
                    byte[] bArr = new byte[socket.Available];
                    // byte 배열의 크기를 동적으로 할당하므로 while문을 사용하지 않습니다.
                    int sizeOfReceive = socket.Receive(bArr);
                    string str = Encoding.Default.GetString(bArr, 0, sizeOfReceive);
                    addText(str);

                    IPEndPoint ipEndPoint = (IPEndPoint)socket.RemoteEndPoint;
                    //sbServerLabel2.Text = $"{ipEndPoint.Address} : {ipEndPoint.Port}";
                    sbServerLabel2.Text = $"{MyLib.GetTorken(0, socket.RemoteEndPoint.ToString(), ':')}";

                    sendSocket.Connect(tbClientIP.Text, int.Parse(tbClientPort.Text));

                    sendSocket.Send(Encoding.Default.GetBytes(str));

                    sendSocket.Close();
                }
            }
        }

        // 스레드를 중지시키는 메소드
        private void btnStop_Click(object sender, EventArgs e)
        {
            //listener.Stop();
            // 스레드가 null이 아닌 경우 abort를 요청합니다.
            if (thread != null)
            {
                thread.Abort();
                ThreadState threadState = thread.ThreadState;
                sbServerMessage.Text = $"thread state - {threadState.ToString()}";
                thread = null;
                timer1.Stop();
            }
            // 스레드가 null인 경우 메시지 박스를 호출합니다.
            else
            {
                MessageBox.Show("실행 중인 스레드가 없습니다.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbServer.Text += listenMessage;
            listenMessage = "";
        }

        private void FormChattingBasicServerReview_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Comm", "ServerPort", tbServerPort.Text);
            ini.WriteString("Form", "OpenPointX", $"{Location.X}");
            ini.WriteString("Form", "OpenPointY", $"{Location.Y}");
            ini.WriteString("Form", "SizeWidth", $"{Size.Width}");
            ini.WriteString("Form", "SizeHeigh", $"{Size.Height}");
            //ini.WriteString("Form", "SizeSplitter", $"{splitContainer1.SplitterDistance}");

            /*
            WritePrivateProfileString("Comm", "ServerPort", tbServerPort.Text, @".\ComServer.ini");
            WritePrivateProfileString("Form", "OpenPointX", $"{Location.X}", @".\ComServer.ini");
            WritePrivateProfileString("Form", "OpenPointY", $"{Location.Y}", @".\ComServer.ini");
            WritePrivateProfileString("Form", "SizeWidth", $"{Size.Width}", @".\ComServer.ini");
            WritePrivateProfileString("Form", "SizeHeigh", $"{Size.Height}", @".\ComServer.ini");
            */


            // 스레드가 null이 아닌 경우 abort를 요청합니다.
            if (thread != null)
            {
                listener.Stop();
                thread.Abort();
                ThreadState threadState = thread.ThreadState;
                sbServerMessage.Text = $"thread state - {threadState.ToString()}";
            }
        }

        private void tbServerPort_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

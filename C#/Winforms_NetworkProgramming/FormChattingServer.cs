using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Chatting_Server
{
    public partial class FormChattingServer : Form
    {
        IniFile iniFile = new IniFile(@".\FormChattingServer.ini");
        Thread serverThread = null;
        Thread readThread = null;
        TcpListener listener = null;
        string tmpString;
        TcpClient tcpClient = null;

        public FormChattingServer()
        {
            InitializeComponent();
        }

        delegate void AddTextCallBack(string str);

        private void AddText(string str)
        {
            if (TbServer.InvokeRequired)
            {
                Invoke(new AddTextCallBack(AddText), str);
            }
            else
            {
                TbServer.AppendText(str+"\r\n");
            }
        }

        private void FormChattingServer_Load(object sender, EventArgs e)
        {
            TbServerPort.Text = iniFile.GetString("Server", "Port", "9001");
            int openPointX = int.Parse(iniFile.GetString("Form", "OpenPointX", "300"));
            int openPointY = int.Parse(iniFile.GetString("Form", "OpenPointY", "300"));
            this.Location = new Point(openPointX, openPointY);
            int sizeWidth = int.Parse(iniFile.GetString("Form", "SizeWidth", "800"));
            int sizeHeight = int.Parse(iniFile.GetString("Form", "SizeHeigh", "800"));
            this.Size = new Size(sizeWidth, sizeHeight);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (listener == null)
            {
                listener = new TcpListener(int.Parse(TbServerPort.Text));
                listener.Start();
            }

            if (serverThread == null)
            {
                serverThread = new Thread(ServerProcess);
                serverThread.Start();
                //readThread = new Thread(ReadProcess);                
            }
            // 스레드가 실행 중인 경우 메시지 박스를 호출합니다.
            else
            {
                MessageBox.Show("스레드가 실행 중 입니다.");
            }
            ThreadState threadState = serverThread.ThreadState;
            SbThreadStatus.Text = $"thread state - {threadState.ToString()}";            
        }

        private void ServerProcess()
        {
            while (true)
            {                
                // Pending() 메소드는 접속 요청이 있는 경우 true를 반환합니다.
                if (listener.Pending() == true)
                {
                    // TcpClient는 Socket과 비슷한 역할을 합니다.
                    // AcceptTcpClient() 메소드는 listener에 신호가 올 때까지 작업 진행을 블로킹합니다.
                    tcpClient = listener.AcceptTcpClient();

                    // client의 정보를 출력합니다.
                    AddText($"{tcpClient.Client.RemoteEndPoint.ToString()}가 접속했습니다.");
                    readThread = new Thread(ReadProcess);
                    readThread.Start();
                    /*
                        byte[] bArr = new byte[50];
                        // GetStream()메소드를 이용하여 tcpClient에서 NetworkStream을 반환받습니다.
                        NetworkStream networkStream = tcpClient.GetStream();
                        while (true)
                        {
                            while (networkStream.DataAvailable)
                            {
                                int n = networkStream.Read(bArr, 0, 50);
                                tmpString = Encoding.Default.GetString(bArr, 0, n);
                                AddText();
                            }
                        }
                    */
                    /*
                        while (networkStream.DataAvailable)
                        {
                            byte[] bArr = new byte[networkStream.Length];
                            int n = networkStream.Read(bArr, 0, networkStream.Length);
                            string tmpString = Encoding.Default.GetString(bArr, 0, n);
                            AddText();                      
                        }
                    */
                }
                Thread.Sleep(100);
            }            
        }

        private void ReadProcess()
        {
            if (tcpClient != null)
            {
                // GetStream()메소드를 이용하여 tcpClient에서 NetworkStream을 반환받습니다.
                NetworkStream networkStream = tcpClient.GetStream();
                byte[] bArr = new byte[50];
                while (true)
                {
                    while (networkStream.DataAvailable)
                    {
                        int n = networkStream.Read(bArr, 0, 50);
                        string str = Encoding.Default.GetString(bArr, 0, n);
                        AddText(str);
                    }
                }
            }
        }

        private void StrSend(string str = null)
        {
            if (tcpClient != null)
            {
                // GetStream()메소드를 이용하여 tcpClient에서 NetworkStream을 반환받습니다.
                // NetworkStream은 읽기 뿐만 아니라 쓰기도 가능합니다.
                NetworkStream networkStream = tcpClient.GetStream();
                if (str == null)
                {
                    //int pos = TbServer.SelectionStart;
                    int lineNo = TbServer.GetLineFromCharIndex(TbServer.SelectionStart);
                    //str = TbServer.Text;
                    //string[] sArr = str.Split('\n');
                    //string sLast = sArr[sArr.Length - 2];
                    //string sLast = sArr[lineNo - 1];
                    str = TbServer.Text.Split('\n')[lineNo - 1];
                }
                byte[] bArr = Encoding.Default.GetBytes(str);
                networkStream.Write(bArr, 0, bArr.Length);
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            StrSend();
        }

        private void TbServer_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                StrSend();
            }
        }
        private void FormChattingServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(serverThread != null)
            {
                serverThread.Abort();
            }
            if(readThread != null)
            {
                readThread.Abort();
            }
                        
            iniFile.WriteString("Server", "Port", TbServerPort.Text);
            iniFile.WriteString("Form", "OpenPointX", $"{Location.X}");
            iniFile.WriteString("Form", "OpenPointY", $"{Location.Y}");
            iniFile.WriteString("Form", "SizeWidth", $"{Size.Width}");
            iniFile.WriteString("Form", "SizeHeigh", $"{Size.Height}");
        }

        private void MnuSend_Click(object sender, EventArgs e)
        {
            String selectedStr = TbServer.SelectedText;
            StrSend(selectedStr);
        }
    }
}

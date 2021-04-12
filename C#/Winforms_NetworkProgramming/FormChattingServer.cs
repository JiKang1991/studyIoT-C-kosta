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
        Thread serverThread = null;
        Thread readThread = null;
        TcpListener listener = null;
        string tmpString;
        TcpClient tcpClient = null;

        public FormChattingServer()
        {
            InitializeComponent();
        }

        delegate void AddTextCallBack();

        private void AddText()
        {
            if (TbServer.InvokeRequired)
            {
                Invoke(new AddTextCallBack(AddText));
            }
            else
            {
                TbServer.AppendText(tmpString);
            }
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
                readThread = new Thread(ReadProcess);                
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
                        tmpString = Encoding.Default.GetString(bArr, 0, n);
                        AddText();
                    }
                }
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
        }
    }
}

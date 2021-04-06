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

namespace Winforms_Chatting_Basic_Server
{
    public partial class FormChattingBasicServer : Form
    {
        public static FormChattingBasicServer mainForm;
        public FormChattingBasicServer()
        {
            InitializeComponent();
            mainForm = this; 
        }
        // Server
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (thread == null) {
                thread = new Thread(serverProcess);
                thread.Start();
            }
            else
            {
                thread.Resume();
            }
            ThreadState threadState = thread.ThreadState;
            sbServerMessage.Text = threadState.ToString();
            timer1.Enabled = true;
        }

        Thread thread = null;
        string MainMsg; // tbServer.Text , invoke와 delegate를 사용하지 않기위한 편법
        // Client가 Socket으로 전송하는 정보를 수신하기위해 TcpListener를 생성합니다.
        TcpListener listener = null;
        byte[] bArr = new byte[1024];

        private void serverProcess()
        {
            while(true)
            {
                if(listener == null)
                {
                    listener = new TcpListener(int.Parse(tbServerPort.Text));                    
                }
                // 수신을 대기합니다. Stop()메소드가 호출될 때 까지 지속 대기합니다.
                listener.Start();

                // 논블로킹(nonbloking) : 해당하는 요청이 들어오지 않은 상태에서도 다른 작업을 수행하도록 합니다.
                // pending : listener에 대기중인 요청이 있는지 확인합니다.
                // 요청이 있는 경우에만 블록 내부의 작업을 수행합니다.
                //if (listener.Pending())
                {
                    // 외부에서의 접속 요청을 수신합니다.
                    // Socket socket = listener.AcceptSocket();
                    // 블로킹(blocking) : 해당하는 요청이 들어오기 전까지 대기만 합니다.
                    TcpClient tcpClient = listener.AcceptTcpClient();
                    sbServerMessage.Text = "Connected";
                    sbServerLabel2.Text = "Connected";
                    NetworkStream networkStream = tcpClient.GetStream();
                    while (networkStream.DataAvailable)
                    {
                        networkStream.Read(bArr, 0, 1024);
                        string str = Encoding.Default.GetString(bArr);
                        MainMsg += str.TrimEnd('\0');
                    }
                }
                    
                listener.Stop();
            }
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
           tbServer.Text = MainMsg;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            thread.Suspend();
            ThreadState threadState = thread.ThreadState;
            sbServerMessage.Text = threadState.ToString();
        }

        private void FormChattingBasicServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
            ThreadState threadState = thread.ThreadState;
            sbServerMessage.Text = threadState.ToString();
        }
    }
}

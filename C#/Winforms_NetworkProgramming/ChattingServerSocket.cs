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

namespace WinForms_Chatting_Server_Socket
{
    /**
     * socket을 이용한 server 프로그램 예제
     */
    public partial class ChattingServerSocket : Form
    {
        Socket serverSocket = null;
        Socket socket = null;
        Thread serverThread = null;
        Thread readThread = null;
        byte[] iP = { 127, 0, 0, 1 };
        string port = "9001";

        public ChattingServerSocket()
        {
            InitializeComponent();
        }

        delegate void printMessageCB(string str);

        private void printMessage(string str)
        {
            if (TbReceive.InvokeRequired)
            {
                Invoke(new printMessageCB(printMessage), str);
            }
            else
            {
                TbReceive.AppendText(str + "\r\n");
            }
        }

        private void MnuFileStart_Click(object sender, EventArgs e)
        {
            if(serverSocket != null)
            {
                serverSocket.Close();
            }
            if(serverThread != null)
            {
                serverThread.Abort();
            }
            if(readThread != null)
            {
                readThread.Abort();
            }

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverThread = new Thread(ServerProcess);
            readThread = new Thread(ReadProcess);

            serverThread.Start();
        }

        private void ServerProcess()
        {
            IPAddress iPAddress = new IPAddress(iP);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, int.Parse(port));
            serverSocket.Bind(iPEndPoint);
            serverSocket.Listen(50000);

            while (true)
            {
                socket = serverSocket.Accept();
                readThread.Start();
            }
        }
        
        private void ReadProcess()
        {
            while (true)
            {
                if (socket != null && socket.Available > 0)
                {
                    byte[] bArr = new byte[socket.Available];
                    socket.Receive(bArr);
                    printMessage(Encoding.Default.GetString(bArr));
                }
            }
            
        }

        private void SendMessage(string str)
        {
            socket.Send(Encoding.Default.GetBytes(str));
        }

        private void PopMnuSend_Click(object sender, EventArgs e)
        {
            SendMessage(TbSend.SelectedText);
        }
    }
}

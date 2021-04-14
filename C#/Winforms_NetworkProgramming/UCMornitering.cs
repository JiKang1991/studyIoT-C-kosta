using System;
using System.Collections;
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

namespace WinForms_Chatting_Server_Final
{
    public partial class UCMornitering : UserControl
    {
        int portNum;
        byte[] ip;
        Socket serverSocket = null;
        //Thread serverThread = null;
        //Thread readThread = null;
        bool pending = false;
        // Socket socket = null;
        IAsyncResult ar;

        public UCMornitering(int portNum, byte[] ip)
        {
            InitializeComponent();
            this.portNum = portNum;
            this.ip = ip;
        }

        delegate void printMessageCB(Control control);
        

        private void printMessage(Control control)
        {
            if (this.InvokeRequired)
            {
                Invoke(new printMessageCB(printMessage), control);
            }
            else 
            {
                flowLayoutPanel1.Controls.Add(control);                
            }
        }

        

        private void UCMornitering_Load(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(ServerProcess);
            serverThread.IsBackground = true;
            serverThread.Start();
        }
        /*
        private void DoRead()
        {
            if (readThread != null)
            {
                readThread.Abort();
                readThread = null;
            }
            readThread = new Thread(ReadProcess);
            readThread.IsBackground = true;
            readThread.Start();
        }
        */
        private Socket acceptSocket()
        {
            Socket tempSock = serverSocket.EndAccept(ar);
            // non Blocking method End : 실제 소켓을 전달한다.
            serverSocket.BeginAccept(new AsyncCallback(OnAccept), null); // Start listening for next clients
            pending = false;
            return tempSock;
        }

        private void OnAccept(IAsyncResult iar)
        {
            pending = true;
            ar = iar;
        }


        private void ServerProcess()
        {
            try
            {
                IPAddress iPAddress = new IPAddress(ip);
                IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, portNum);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(iPEndPoint);
                serverSocket.Listen(50000);
                createInfoControl("서버가 활성화 되었습니다.");

                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);  // non Blocking method start

                while (true)
                {
                   
                    if (pending)
                    {
                        Socket socket = acceptSocket();
                        //DoRead();
                        //socket = serverSocket.Accept();
                        Thread readThread = new Thread(ReadProcess(socket));
                        readThread.IsBackground = true;
                        //list.Add(readThread);
                        readThread.Start();

                    }
                    Thread.Sleep(100);
                }
            }
            finally
            {
                if (serverSocket != null)
                {
                    //serverSocket.Close();
                }
            }
        }        

        private ThreadStart ReadProcess(Socket socket)
        {
            Socket sock = socket;
            try
            {
                //string user = socket.RemoteEndPoint.AddressFamily.ToString();
                string user = ((IPEndPoint)socket.RemoteEndPoint).Port.ToString();
                createInfoControl(user + "님이 접속하였습니다.");
                while (true)
                {
                    if(socket != null && socket.Available > 0)
                    {
                        byte[] bArr = new byte[socket.Available];
                        socket.Receive(bArr);
                        createMessageControl(Encoding.Default.GetString(bArr), user);
                        broadcast(Encoding.Default.GetString(bArr), socket, user);
                    }
                }
            }
            finally
            {
                if(socket != null)
                {
                    //socket.Close();
                }
            }
        }

        //private List<Thread> list = new List<Thread>();

        private void broadcast(string message, Socket socket, string user)
        {
            try
            {
                socket.Send(Encoding.Default.GetBytes(user + " " + message));
                
            }
            finally
            {
                if (socket != null)
                {
                    //socket.Close();
                }
            }
        }

        private void createInfoControl(string message)
        {
            Label infoLabel = new Label();

            infoLabel.Text = message;
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            infoLabel.Size = new Size(300, 20);
            infoLabel.BackColor = Color.Gray;
            infoLabel.ForeColor = Color.White;

            //this.Controls.Add(infoLabel);
            printMessage(infoLabel);
        }

        private void createMessageControl(string message, string user)
        {
            Label messageLabel = new Label();
            
            messageLabel.Text = message;
            messageLabel.TextAlign = ContentAlignment.MiddleLeft;
            //messageLabel.Size = new Size(120, 30);
            messageLabel.AutoSize = true;
            messageLabel.BackColor = Color.Yellow;
            messageLabel.Margin = new Padding(10, 0, 100, 10);
            messageLabel.Padding = new Padding(10, 10, 10, 10); 

            Label userLabel = new Label();

            userLabel.Text = $"{user}'s message :" ;
            userLabel.Size = new Size(120, 20);
            userLabel.BackColor = Color.Transparent;
            userLabel.Margin = new Padding(10, 10, 100, 0);

            printMessage(userLabel);
            printMessage(messageLabel);

        }

    }
}

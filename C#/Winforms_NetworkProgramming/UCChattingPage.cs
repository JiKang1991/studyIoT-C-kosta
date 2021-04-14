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

namespace WinForms_Chatting_Client_Final
{
    public partial class UCChattingPage : UserControl
    {
        string ip;
        int portNum;
        Socket socket = null;
        //Thread receiveThread = null;

        public UCChattingPage(int portNum, string ip)
        {
            InitializeComponent();
            this.ip = ip;
            this.portNum = portNum;
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

        private void UCChattingPage_Load(object sender, EventArgs e)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(ip, portNum);

                createInfoControl("서버에 접속하였습니다.");

                Thread receiveThread = new Thread(ReceiveProcess);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (Exception exception)
            {
                createInfoControl("서버 접속에 이상이 있습니다.");
            }


        }

        private void ReceiveProcess()
        {
            while (true)
            {
                if(socket != null && socket.Connected)
                {
                    int n = socket.Available;
                    if(n > 0)
                    {
                        byte[] bArr = new byte[n];
                        socket.Receive(bArr);
                        string[] str = Encoding.Default.GetString(bArr).Split(' ');

                        string user = str[0];
                        string message = str[1];

                        string myPort = ((IPEndPoint)socket.LocalEndPoint).Port.ToString();

                        if (myPort.Equals(user))
                        {
                            createMyMessageControl(message);
                        }
                        else
                        {
                            createMessageControl(message);
                        }

                        
                    }
                }
            }
        }


        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if(socket.Connected == true)
                {
                    string message = TbSend.Text.Trim();

                    string[] sArr = message.Split('\r');

                    string sLast = sArr[sArr.Length - 1];

                    socket.Send(Encoding.Default.GetBytes(sLast));
                }
                else
                {
                    createInfoControl("서버와의 연결이 원활하지 않습니다.");
                }
            }
            catch(Exception exception)
            {
                createInfoControl(exception.Message);
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

            //PanelPrint.Controls.Add(infoLabel);
            printMessage(infoLabel);
            
        }

        private void createMessageControl(string message)
        {
            Label messageLabel = new Label();

            messageLabel.Text = message;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            messageLabel.Size = new Size(120, 30);
            //messageLabel.AutoSize = true;
            messageLabel.BackColor = Color.White;            
            messageLabel.Margin = new Padding(10, 10, 100, 10);

            //PanelPrint.Controls.Add(infoLabel);
            printMessage(messageLabel);

        }

        private void createMyMessageControl(string message)
        {
            Label messageLabel = new Label();

            messageLabel.Text = message;
            messageLabel.TextAlign = ContentAlignment.MiddleRight;
            //messageLabel.Size = new Size(120, 30);
            messageLabel.AutoSize = true;
            messageLabel.BackColor = Color.Yellow;
            messageLabel.Margin = new Padding(10, 10, 150, 10);
            messageLabel.Padding = new Padding(10, 10, 10, 10);
            messageLabel.Dock = DockStyle.Right;
            

            //PanelPrint.Controls.Add(infoLabel);
            printMessage(messageLabel);

        }
    }
}

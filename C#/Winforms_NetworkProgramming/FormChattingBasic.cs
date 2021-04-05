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

namespace WindowsFormApp1
{
    public partial class FormChattingBasic : Form
    {
        public FormChattingBasic()
        {
            InitializeComponent();
        }
        // delegate = 함수의 delegate(포인터 개념과 비슷)를 선언합니다.
        delegate void CallBackAddText(string str);

        // callBackAddText()의 기능을 정의하는 메소드입니다.
        private void addText(string str)
        {
            // tbServer에 대한 invoke가 있다면 해당 블록을 실행합니다.
            if (tbServer.InvokeRequired)
            {
                CallBackAddText callBackAddText = new CallBackAddText(addText);
                Invoke(callBackAddText, new object[] { str });
            }
            else
            {
                tbServer.Text += str;
            }
        }

        private void btnComTest_Click(object sender, EventArgs e)
        {
            // 수신측에 전달하기 위한 메세지를 대입하는 변수입니다.
            string source = tbClient.Text;
            
            // 이더넷 소켓을 만듭니다. TCP/IP 통신의 기본
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(tbIP.Text, int.Parse(tbPort.Text));
            // Encoding.Default.GetByte(string) string 문자열을 byte배열로 변환하여 리턴하는 메소드입니다.
            socket.Send(Encoding.Default.GetBytes(source));
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(serverThreadDefine);
            serverThread.Start();
        }

        private void serverThreadDefine()
        {
            while (true)
            {
                // Socket.TcpListener
                TcpListener listener = new TcpListener(int.Parse(tbPort.Text));
                // 반복문을 사용하지 않아도 TcpListener는 클라이언트의 요청이 반환될 때 까지 반복합니다.
                listener.Start();


                byte[] bArr = new byte[200];
                TcpClient tcpClient = listener.AcceptTcpClient();
                NetworkStream networkStream = tcpClient.GetStream();
                // int offset = byte[]의 인덱스 / int size = 읽어들일 크기를 의미합니다.
                networkStream.Read(bArr, 0, 200);
                // Encoding.Default : 윈도우의 설정을 적용합니다.
                string str = Encoding.Default.GetString(bArr);
                // 해당 스레드에서 만들지 않은 객체에 접근하기 위해서는 invoke 요청이 필요합니다.
                //tbServer.Text += bArr;
                addText(str);
                listener.Stop();                
            }
        }
    }
}

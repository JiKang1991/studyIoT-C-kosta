using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Chatting_Basic
{
    public partial class FormChattingBasicClient : Form
    {
        public FormChattingBasicClient()
        {
            InitializeComponent();
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Chatting_Server_Final
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            string sIp = TbIP1.Text.Trim() + TbIP2.Text.Trim() + TbIP3.Text.Trim() + TbIP4.Text.Trim();
            string port = TbServerPort.Text.Trim();

            if (IpPortCheck("IP", sIp) && IpPortCheck("Port", port))
            {                
                groupBox1.Hide();

                int portNum = int.Parse(TbServerPort.Text);
                byte[] ip =
                {
                    (byte)int.Parse(TbIP1.Text.Trim()),
                    (byte)int.Parse(TbIP2.Text.Trim()),
                    (byte)int.Parse(TbIP3.Text.Trim()),
                    (byte)int.Parse(TbIP4.Text.Trim()),
                };

                UCMornitering ucMornitering = new UCMornitering(portNum, ip);
                panelMain.Controls.Add(ucMornitering);
            }
        }

        private Boolean IpPortCheck(string type, string source)
        {
            try
            {                
                int.Parse(source);
                
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show($"{type}가 올바르지 않습니다.");
                return false;
            }
        }
    }
}

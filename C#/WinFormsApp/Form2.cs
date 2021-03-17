using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public string[] comboBoxTexts = new string[3];
        public Form2()
        {
            InitializeComponent();
        
        }

        string str;
        private void btnOk_Click(object sender, EventArgs e)
        {
            comboBoxTexts[0] = comboBox1.Text;
            comboBoxTexts[1] = comboBox2.Text;
            comboBoxTexts[2] = comboBox3.Text;
        }
    }
}

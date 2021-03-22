using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Graphic
{
    public partial class FormCircleProperties : System.Windows.Forms.Form
    {
        public int circleHeight;
        public int circleWidth;
        
        public FormCircleProperties(int circleHeight, int circleWidth, Color lineColor, int lineSize)
        {
            InitializeComponent();
            this.circleHeight = circleHeight;
            tbCircleHeight.Text = circleHeight.ToString();
            this.circleWidth = circleWidth;
            tbCircleWidth.Text = circleWidth.ToString();            
        }
            

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbCircleHeight.Text == "" || tbCircleWidth.Text == "")
            {
                MessageBox.Show("비어있는 항목을 채워주세요!");
                return;
            }
            circleHeight = int.Parse(tbCircleHeight.Text);
            circleWidth = int.Parse(tbCircleWidth.Text);            
        }        
    }
}

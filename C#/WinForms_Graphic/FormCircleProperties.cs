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
        public Color lineColor;
        public string lineColorName;
        public int lineSize;

        public FormCircleProperties(int circleHeight, int circleWidth, Color lineColor, int lineSize)
        {
            InitializeComponent();
            this.circleHeight = circleHeight;
            tbCircleHeight.Text = circleHeight.ToString();
            this.circleWidth = circleWidth;
            tbCircleWidth.Text = circleWidth.ToString();
            this.lineColor = lineColor;
            tbCircleLineColor.Text = lineColor.Name;
            this.lineSize = lineSize;
            tbCircleLineSize.Text = lineSize.ToString();
        }
            

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbCircleHeight.Text == null || tbCircleLineColor.Text == null
                || tbCircleLineSize.Text == null || tbCircleLineColor.Text == null)
            {
                MessageBox.Show("비어있는 항목을 채워주세요!");
            }
            circleHeight = int.Parse(tbCircleHeight.Text);
            circleWidth = int.Parse(tbCircleWidth.Text);
            lineSize = int.Parse(tbCircleLineSize.Text);
        }

        private void tbCircleLineColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                lineColor = colorDialog1.Color;
                tbCircleLineColor.Text = lineColor.Name;
            }
        
        }

    }
}

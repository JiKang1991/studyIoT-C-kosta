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
    public partial class DrawingBook : System.Windows.Forms.Form
    {
        Graphics graphics;
        int circleHeight = 50;
        int circleWeith = 50;
        Pen pen = new Pen(Color.Black, 10);

        public DrawingBook()
        {
            InitializeComponent();
            graphics = canvasDraw.CreateGraphics();                
        }

        private void canvasDraw_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void canvasDraw_MouseDown(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Left)
            {                   
                graphics.DrawEllipse(pen, e.X - circleHeight/2, e.Y - circleWeith/2, 200, 200);
            }
        }

        private void canvasDraw_Resize(object sender, EventArgs e)
        {
            graphics = canvasDraw.CreateGraphics();
        }

        private void mnuEraseAll_Click(object sender, EventArgs e)
        {
            graphics.Clear(canvasDraw.BackColor);
        }

        private void mnuForm_Click(object sender, EventArgs e)
        {
            FormCircleProperties circleProperties = new FormCircleProperties(circleHeight, circleWeith, Color.Black, 10);
            circleProperties.ShowDialog();

            circleHeight = circleProperties.circleHeight;
        }
    }
}

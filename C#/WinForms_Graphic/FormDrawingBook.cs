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
        Graphics Graphics;
        int CircleHeight = 50;
        int CircleWeith = 50;
        Color PenColor = Color.AliceBlue;
        int PenSize = 20;
        Pen DrawingPen;
        bool MStatus = false;    // false : 그리기 상태 아님, true : 그리기 상태
        int DrawMode = -1;      // -1 : None /  0 : DrawingPen / 1 : Circle / 2 : Arc / 3 : Line    
        Point P1;        

        public DrawingBook()
        {
            InitializeComponent();
            Graphics = canvasDraw.CreateGraphics();
            sbPenal3.Text = $"Pen Color : {PenColor.Name}, Pen Size : {PenSize}";
        }

        private void canvasDraw_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private void canvasDraw_Resize(object sender, EventArgs e)
        {
            Graphics = canvasDraw.CreateGraphics();
        }

        private void mnuEraseAll_Click(object sender, EventArgs e)
        {
            Graphics.Clear(canvasDraw.BackColor);
        }

        private void canvasDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (DrawMode == 0) {
                P1 = new Point(e.X, e.Y);
                MStatus = true;
            } else if(DrawMode == 1) {
                if (e.Button == MouseButtons.Left)
                {
                    DrawingPen = new Pen(PenColor, PenSize);
                    Graphics.DrawEllipse(DrawingPen, e.X - CircleWeith / 2, e.Y - CircleHeight / 2, CircleWeith, CircleHeight);
                }
            }
            
            
        }

        private void canvasDraw_MouseMove(object sender, MouseEventArgs e)
        {
            //int x = e.X;
            //int y = e.Y;
            // 보간 문자열을 활용하여 자료형 int 데이터를 string 자료형으로 변경하여 저장합니다.
            //string sx = $"{x}";
            //string sy = $"{y}";
            
            if(DrawMode == 0) {
                if(MStatus == true) {
                    Point p2 = new Point(e.X, e.Y);
                    DrawingPen = new Pen(PenColor, PenSize);
                    Graphics.DrawLine(DrawingPen, P1, p2);           
                    P1 = p2;
                }
            }
            

            sbPanel1.Text = $"{e.X},{e.Y}";
        }

        private void canvasDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if(DrawMode == 0) {
                MStatus = false;
            }
        }

        private void mnuDrawPen_Click(object sender, EventArgs e)
        {
            DrawMode = 0;
            sbPenal2.Text = "Drawing Mode : DrawingPen";
            //sbPenal3.Text = $"{DrawingPen.Width}";
        }

        private void mnuDrawCircle_Click(object sender, EventArgs e)
        {
            DrawMode = 1;
            sbPenal2.Text = "Drawing Mode : Circle";
        }

        private void mnuDrawArc_Click(object sender, EventArgs e)
        {
            DrawMode = 2;
            sbPenal2.Text = "Drawing Mode : Arc";
        }

        private void mnuDrawLine_Click(object sender, EventArgs e)
        {
            DrawMode = 3;
            sbPenal2.Text = "Drawing Mode : Line";
        }

        private void mnuDrawStop_Click(object sender, EventArgs e)
        {
            DrawMode = -1;
            sbPenal2.Text = "DrawingMode";
        }

        private void mnuPenProperties_Click(object sender, EventArgs e)
        {
            FormPenProperties penProperties = new FormPenProperties(PenColor, PenSize);
            DialogResult dialogResult = penProperties.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                PenColor = penProperties.PenColor;
                PenSize = penProperties.PenSize;
                sbPenal3.Text = $"Pen Color : {PenColor.Name}, Pen Size : {PenSize}";
            }
        }

        private void mnuCircleProperties_Click(object sender, EventArgs e)
        {
            FormCircleProperties circleProperties = new FormCircleProperties(CircleHeight, CircleWeith, PenColor, PenSize);
            DialogResult dialogResult = circleProperties.ShowDialog();

            if (dialogResult == DialogResult.OK) {
                CircleHeight = circleProperties.circleHeight;
                CircleWeith = circleProperties.circleWidth;
            }
        }
    }
}

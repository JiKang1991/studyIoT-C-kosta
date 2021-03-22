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
    public partial class FormPenProperties : Form
    {
        public Color PenColor;
        public int PenSize;

        public FormPenProperties(Color penColor, int penSize)
        {
            InitializeComponent();
            this.PenColor = penColor;
            tbPenColor.Text = penColor.Name;
            this.PenSize = penSize;
            tbPenSize.Text = penSize.ToString();
        }

        private void tbCircleLineColor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PenSize = int.Parse(tbPenSize.Text);
        }

        private void tbPenColor_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                PenColor = colorDialog1.Color;
                tbPenColor.Text = PenColor.Name;
            }
        }
    }
}

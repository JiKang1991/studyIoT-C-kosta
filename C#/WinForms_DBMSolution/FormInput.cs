using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_DBMSolution
{
    public partial class FormInput : Form
    {
        public string SInput;
        string SLbColumnName;
        public FormInput(string sTitle = "input")
        {
            SLbColumnName = sTitle;
            InitializeComponent();
        }

        private void FormAddColumn_Load(object sender, EventArgs e)
        {
            lbColumnName.Text = SLbColumnName;
        }

        private void btnAddColumnNameOk_Click(object sender, EventArgs e)
        {
            addColumn();
        }

        private void tbAddColumnName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                addColumn();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                // Close();
            }
        }

        private void addColumn()
        {
            if (tbAddColumnName.Text == "")
            {
                MessageBox.Show("please input column name.");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                SInput = tbAddColumnName.Text;
                Close();
            }
        }

        
    }
}

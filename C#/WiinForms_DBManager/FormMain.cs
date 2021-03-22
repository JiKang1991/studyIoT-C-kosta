using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_DBManager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            string columnName = tbInput.Text;
            dbGrid.Columns.Add(columnName, columnName);
            dbGrid.Rows.Add();
        }

        private void btnValue_Click(object sender, EventArgs e)
        {
            string value = tbValue.Text;
            dbGrid.Rows[1].Cells[2].Value = value;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            string filePath = openFileDialog1.FileName;
            //string fileName = openFileDialog1.SafeFileName;

            StreamReader streamReader = new StreamReader(filePath);

            string[] columns = streamReader.ReadLine().Split('\t');
            
            for(int i = 0; i < columns.Length; i++)
            {
                dbGrid.Columns.Add(columns[i], columns[i]);
            }

            
            for(int i = 0; streamReader.EndOfStream == false; i++)
            {
                string row = streamReader.ReadLine();
                string[] cells = row.Split('\t');
                for(int j = 0; j < cells.Length; j++)
                {
                    dbGrid.Rows[i].Cells[j].Value = cells[j];
                }
            }
            
        }
    }
}

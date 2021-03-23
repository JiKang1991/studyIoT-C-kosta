using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_DBMSolution
{
    public partial class FormMain : Form
    {
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();

        public FormMain()
        {
            InitializeComponent();
        }

        private void mnuFileMigration_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                string filePath = openFileDialog1.FileName;
                StreamReader streamReader = new StreamReader(filePath);

                // ============================================================
                //          Header 처리 프로세스
                // =======================================
                string column = streamReader.ReadLine();
                if(column == null)
                {
                    return;
                }
                string[] columns = column.Split('\t');
                for(int i = 0; i < columns.Length; i++)
                {
                    dataGridView1.Columns.Add(columns[i], columns[i]);
                }

                // ============================================================
                //          Row 데이터 처리 프로세스
                // =======================================
                for (int i = 0; streamReader.EndOfStream == false; i++)
                {
                    string row = streamReader.ReadLine();
                    if(row == null)
                    {
                        break;
                    }
                    string[] cells = row.Split('\t');
                    dataGridView1.Rows.Add(cells);
                    /*
                     * dataGridView1.Rows.Add();                    
                     * for(int j = 0; j < cells.Length; j++)
                     * {
                     *     // .Value는 object 데이터 타입입니다.
                     *     dataGridView1.Rows[i].Cells[j].Value = cells[j];
                     * }
                     */
                }
                streamReader.Close();
            } else {
                return;
            }

        }
        private void mnuFileOpenDB_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = openFileDialog1.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string attachDbFileName = openFileDialog1.FileName;
                    string connectionString = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {attachDbFileName};Integrated Security=True;Connect Timeout=30";


                    sqlConnection.ConnectionString = connectionString;
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();

                    string[] splitByBackslash = sqlConnection.ConnectionString.ToString().Split('\\');
                    string[] splitByDot = splitByBackslash[splitByBackslash.Length - 1].Split('.');
                    MessageBox.Show(splitByDot[0]);
                    sbPanel1.Text = $"DB open success";
                    sbPanel1.BackColor = Color.LightGreen;


                    //sqlConnection.Close();
                }
                else
                {
                    return;
                }
            } catch(Exception exception) {
                MessageBox.Show(exception.Message);
                sbPanel1.Text = $"DB open fail";
                sbPanel1.BackColor = Color.OrangeRed;
            } 
        }
              
        private void mnuExecuteExecuteSql_Click(object sender, EventArgs e)
        {
            string sql = tbSql.Text;
            runSql(sql);
        }

        private void mnuExcuteSelectedSql_Click(object sender, EventArgs e)
        {
            string sql = tbSql.SelectedText;    // Selected Text : 선택된(블록지정된) 텍스트만
            runSql(sql);
        }

        private int runSql(string sql)
        {
            try
            {
                sqlCommand.CommandText = sql;
                // ExecuteNonQuery() : 리턴값이 없는 SQL문 실행(UPDATE, INSERT, DELETE, CREATE, ALT 등)
                sqlCommand.ExecuteNonQuery();

                // ExecuteReader() : 리턴값이 있는 SQL문 실행(SELECT)
                //sqlCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return 0;
            
        }
    }
}

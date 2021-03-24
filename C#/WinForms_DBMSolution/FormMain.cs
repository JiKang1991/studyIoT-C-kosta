using MyClassLibrary;
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
        string TableName;       // 현재 open된 테이블

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

        public static string getToken(int index, char delimiter, string str)
        {
            string[] tokens = str.Split(delimiter);
            string token = tokens[index];
            return token;
        }

        private int runSql(string sql)
        {
            try
            {
                // ex) SELECT * FROM fstatus
                string trimedSql = sql.Trim();
                sqlCommand.CommandText = trimedSql;             
                // 사용자가 입력한 다양한 형태의 select를 대문자로 치환하여 통일한 후 비교한다. 
                if (getToken(0, ' ', trimedSql).ToUpper() == "SELECT")
                {
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    // ExecuteReader() : 리턴값이 있는 SQL문 실행(SELECT)
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    TableName = getToken(3, ' ', trimedSql);

                    // ============================================================
                    //          Header 처리 프로세스
                    // =======================================

                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        string column = sqlDataReader.GetName(i);
                        dataGridView1.Columns.Add(column, column);
                    }

                    // ============================================================
                    //          Row 데이터 처리 프로세스
                    // =======================================

                    // GetString() : 지정된 컬럼의 값을 가져옵니다.
                    // string sqlResult = sqlDataReader.GetString(0);
                    
                    for (int i = 0; sqlDataReader.Read(); i++)
                    {
                        dataGridView1.Rows.Add();
                        for (int j = 0; j < sqlDataReader.FieldCount; j++)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = sqlDataReader.GetValue(j);                            
                        }
                        
                    }
                    sqlDataReader.Close();
                    
                } else {
                    // ExecuteNonQuery() : 리턴값이 없는 SQL문 실행(UPDATE, INSERT, DELETE, CREATE, ALT 등)
                    sqlCommand.ExecuteNonQuery();
                }

                sbPenel2.Text = "Success";
                sbPenel2.BackColor = Color.LightGreen;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                sbPenel2.Text = "Error";
                sbPenel2.BackColor = Color.OrangeRed;
            }
            return 0;
            
        }

        private void tbSql_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string allSql = tbSql.Text;
                // tbSql의 전체 텍스트를 '\n' 기준으로 분할하여 대입합니다.
                string[] sqls = allSql.Split('\n');
                // 배열 중 마지막 요소(마지막에 쓴 sql 문)를 매개변수로 runSql 메소드를 호출합니다. 
                string sql = sqls[sqls.Length - 1].Trim();
                runSql(sql);
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            dataGridView1.Rows[rowIndex].Cells[columnIndex].ToolTipText = "edited";
            
            
        }

        private void mnuFileUpdate_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    string s = dataGridView1.Rows[i].Cells[j].ToolTipText;
                    if (s.Equals("edited"))  
                    {
                        // UPDATE [Table] SET [field] = [cell velue] WHERE [keyColumnName] = [keyColumnValue]
                        string tableName = TableName;
                        string fieldName = dataGridView1.Columns[j].HeaderText;
                        string cellVelue = (string)dataGridView1.Rows[i].Cells[j].Value;
                        string keyColumnName = dataGridView1.Columns[0].HeaderText;
                        int keyColumnValue = (int)dataGridView1.Rows[i].Cells[0].Value;
                        string sql = $"UPDATE {tableName} SET {fieldName} = {cellVelue} WHERE {keyColumnName} = {keyColumnValue}";
                        runSql(sql);
                    }
                }
            }
        }
    }
}

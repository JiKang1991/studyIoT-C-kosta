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

namespace WindowsForms_DBManager_Review
{
    public partial class Form1 : Form
    {
        // 클래스 필드 영역
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();

        // 클래스 메소드 영역
        public Form1()
        {
            InitializeComponent();
        }

        private void clearGrid()
        {
            // 기존 dataGrid 테이블의 Rows와 Columns를 삭제합니다.(Rows -> Columns 순으로 삭제)
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();            
        }

        // 메뉴 -> 파일 -> New를 클릭하면 실행하는 작업을 정의합니다.
        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            // 기존 dataGrid 테이블의 Rows와 Columns를 삭제합니다.(Rows -> Columns 순으로 삭제)
            dataGrid.Rows.Clear();
            dataGrid.Columns.Clear();

            // 상태 정보창의 정보들을 초기화합니다.
            sbDBName.Text = "DB File Name";
            sbTableList.Text = "Table List";
            // sbPanel2의 드롭다운 목록들을 초기화합니다.
            sbTableList.DropDownItems.Clear();
            sbMessage.Text = "Initialized";
            // 활성화(Open()) 되어있던 sqlConnection을 닫습니다.
            sqlConnection.Close();
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            int iMenuShowPointX = pbMenuBtn.Location.X;
            int iMenuShowPointY = pbMenuBtn.Location.Y;
            Point pt = new Point(iMenuShowPointX, iMenuShowPointY);
            mnuMain.Show(PointToScreen(pt));            
        }

        private void mnuFileMigration_Click(object sender, EventArgs e)
        {
            // openfileDialog1의 리턴값이 OK가 아니면 아무런 작업도 하지 않습니다.
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            clearGrid();
            // openfileDialog1에서 선택한 file의 전체 경로를 가지고 streamReader객체를 생성합니다.
            StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
            // 파일 내용의 첫번째 줄을 읽고 sColumns에 대입합니다.(첫번째 줄에는 각 Column의 Header Text가 적혀있습니다.
            string sAllColumns = streamReader.ReadLine();
            // sAllColumns의 데이터들을 ','을 기준으로 분리하여 배열 sArrColumns에 대입합니다.
            string[] sArrColumns = sAllColumns.Split(',');
            // for 반복문을 사용해 sArrcolumns의 요소를 dataGrid의 Columns에 추가합니다.
            for(int i = 0; i < sArrColumns.Length; i++)
            {
                dataGrid.Columns.Add(sArrColumns[i], sArrColumns[i]);
            }
            //
            for(int i = 0; streamReader.EndOfStream != true; i++)
            {
                string sRows = streamReader.ReadLine();
                string[] sArrRows = sRows.Split(',');
                dataGrid.Rows.Add(sArrRows);
            }
            streamReader.Close();
        }


        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            StreamWriter streamWriter = new StreamWriter(saveFileDialog1.FileName);
            string sbuf = "";
            for(int i = 0; i < dataGrid.ColumnCount; i++)
            {
                sbuf += dataGrid.Columns[i].HeaderText;
                if(i < dataGrid.ColumnCount - 1)
                {
                    sbuf += ", ";
                }
            }
            streamWriter.WriteLine(sbuf);

            for(int i = 0; i < dataGrid.RowCount; i++)
            {
                sbuf = "";
                for(int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    sbuf += dataGrid.Rows[i].Cells[j].Value;
                    if (i < dataGrid.RowCount - 1)
                    {
                        sbuf += ", ";
                    }
                }
                streamWriter.WriteLine(sbuf);
            }
            streamWriter.Close();
        }

        private void mnuFileOpenDB_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                sqlConnection.ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={openFileDialog1.FileName};Integrated Security=True;Connect Timeout=30";
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sbDBName.Text = openFileDialog1.SafeFileName;
                sbDBName.ForeColor = Color.White;

                // 데이터베이스 내부의 테이블에 대한 정보를 반환하여 대입합니다.
                DataTable dataTable = sqlConnection.GetSchema("Tables");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    sbTableList.DropDownItems.Add(dataTable.Rows[i].ItemArray[2].ToString());
                }
                sbMessage.Text = "Success";
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                sbMessage.Text = "Error";
                sbMessage.ForeColor = Color.MediumVioletRed;
            }
        }

        private void pbBackBtn_Click(object sender, EventArgs e)
        {
            // 프로그램 종료
            Close();
        }

        private void sbTableList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbTableList.Text = e.ClickedItem.Text;
            runSql($"SELECT * FROM {sbTableList.Text}");
        }

        public string getToken(int iIndex, string sSource, char cDelimiter)
        {
            string[] sArrTokens = sSource.Split(cDelimiter);
            return sArrTokens[iIndex];
        }

        private void runSql(String sSql)
        {
            
            string sTrimed = sSql.Trim();
            try
            {
                // ex.    seLecT id, fCode, from Facility
                string sToken = getToken(0, sTrimed.ToUpper(), ' ');    // SELECT
                sqlCommand.CommandText = sTrimed;
                if (sToken.Equals("SELECT"))
                {
                    clearGrid();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        string sColumnName = sqlDataReader.GetName(i);
                        dataGrid.Columns.Add(sColumnName, sColumnName);
                    }

                    for (int i = 0; sqlDataReader.Read(); i++)
                    {
                        object[] oArr = new object[sqlDataReader.FieldCount];
                        sqlDataReader.GetValues(oArr);
                        dataGrid.Rows.Add(oArr);
                    }
                    sqlDataReader.Close();
                }
                else
                {
                    sqlCommand.BeginExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void dataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "edited";
        }

        private void nmuFileUpdateFile_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGrid.RowCount; i++)
            {
                for(int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    if (dataGrid.Rows[i].Cells[j].ToolTipText == "edited")
                    {
                        string sTableName = sbTableList.Text;
                        string sCellHeader = dataGrid.Columns[j].HeaderText;
                        object oCellVelue = dataGrid.Rows[i].Cells[j].Value;
                        string sKeyHeader = dataGrid.Columns[0].HeaderText;
                        object sKeyValue = dataGrid.Rows[i].Cells[0].Value;
                        string sSql = $"UPDATE {sTableName} SET {sCellHeader} = N'{oCellVelue}' WHERE {sKeyHeader} = {sKeyValue}";
                        runSql(sSql);
                    }
                }
            }
        }
    }
}

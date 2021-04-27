using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_EquipManager
{
    public partial class FormMain : Form
    {
        TcpListener listener = null;
        List<Socket> socketList = new List<Socket>();
        Thread serverThread = null;
        Thread readThread = null;
        Thread udpReceiptThread = null;
        IniFile iniFile = new IniFile(".\\EquipManager.ini");
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Coding\WinForms_EquipManager\EquipManagerDB.mdf;Integrated Security=True;Connect Timeout=30";
        string sTable = "fStatus";
        DBConnecter dBConnecterM;
        DBConnecter dBConnecterR;
        Socket udpServerSocket = null;
        /* SqlConnection sqlConnectionR = new SqlConnection();
        SqlCommand sqlCommandR = new SqlCommand();
        SqlConnection sqlConnectionM = new SqlConnection();
        SqlCommand sqlCommandM = new SqlCommand(); */
        //Socket socket = null;   // Client / Server

        public FormMain()
        {
            InitializeComponent();
        }

        private delegate void PrintLogCB(string str);
        private delegate void PrintToSLabelCB(string str);
        
        private void PrintLog(string str)
        {
            if (TBMoniter.InvokeRequired)
            {
                Invoke(new PrintLogCB(PrintLog), str);
            }
            else
            {
                TBMoniter.AppendText(str);
            }
        }
        private void PrintToSLabel(string str)
        {
            if (statusStrip1.InvokeRequired)
            {
                Invoke(new PrintToSLabelCB(PrintToSLabel), str);
            }
            else
            {
                SLabelUdpMessage.Text = str;
            }
        }



        private void ServerProcess()
        {
            while(true) 
            {
                // Pending()은 외부 접속 요청의 여부만 확인합니다. (수락이 아닙니다.)
                if (listener.Pending())
                {
                    // 외부의 접속 요청을 수락합니다.
                    // Blocking Method입니다.( 요청이 발생할 때까지 다른 작업을 진행하지 않습니다. )
                    Socket socket = listener.AcceptSocket();
                    socketList.Add(socket);

                }
                Thread.Sleep(100);
            }
        }
        /*
        // caller가 0이면 main 스레드에서 호출합니다.
        // caller가 1이면 read 스레드에서 호출합니다.
        private object RunSql(string sql, int caller = 0)
        {

            SqlCommand sqlCommand = (caller == 1) ? sqlCommandR : sqlCommandM;

            string trimedSql = sql.Trim();
            sqlCommand.CommandText = trimedSql;

            if (MyLib.GetToken(0, trimedSql, ' ').ToUpper().Equals("SELECT"))
            {
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                sqlDataReader.Close();
                return dataTable;
            }
            else
            {
                // INSERT, UPDATE, DELETE, CREATE, ALTER 등이 이에 해당합니다.(조회 결과가 없는 sql문을 처리합니다.)
                // 영향을 받은 행의 수를 int 자료형 데이터로 반환합니다.
                return sqlCommand.ExecuteNonQuery();
            }


        }
        */
        private void ReadProcedure(Socket socket, byte[] bArr)
        {
            string str = Encoding.Default.GetString(bArr);

            string sCode         = str.Substring(1, 5);
            string sModel        = str.Substring(6, 6);
            string sNumber       = str.Substring(12, 5);
            string sBatteryV     = str.Substring(17, 5);
            string sOperate      = str.Substring(22, 1);
            string sOperateCount = str.Substring(23, 5);
            string sTemperature  = str.Substring(28, 4);
            string sHumidity     = str.Substring(32, 4);
            string sWindSpeed    = str.Substring(36, 4);
            string sOzone        = str.Substring(40, 4);
            string sFineDust     = str.Substring(44, 3);
            string sUFineDust    = str.Substring(47, 3);
            string sTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            MyLib.WriteLog(str);
            PrintLog(socket.RemoteEndPoint.ToString() + " >>> "); // 127.0.0.1:12345
            PrintLog(str + "\r\n");
            //PrintLog($"{sCode}, {sModel}, {sNumber}, {sBatteryV}, {sOperate}, " +
            //        $"{sOperateCount}, {sTemperature}, {sHumidity}, {sWindSpeed}, " +
            //        $"{sOzone}, {sFineDust}, {sUFineDust} \r\n");

            // 1. 수신한 데이터에 대한 기존 기록 검색 : ExecuteScalar
            // - 기존 데이터가 없다면 insert
            // - 기존 데이터가 있다면 update(기존 기록 중 가장 마지막 기록을 검색하여 update)

            string sql = "";
            int dataCount = (int)dBConnecterR.Get($"SELECT COUNT (*) FROM fStatus WHERE fCode = '{sCode}'");
            /*sql = $"SELECT COUNT (*) FROM fStatus WHERE fCode = '{sCode}'";
            DataTable dataTable = (DataTable)dBConnecterR.RunSql(sql);

            int dataCount = (int)dataTable.Rows[0].Field<object>(0);
            // dataCount = (int)sqlCommand.ExecuteScalar();
            */
            if (dataCount == 0)   // 기존 데이터가 없는 경우에 해당합니다. 
            {
                sql = $"INSERT INTO {sTable} VALUES ('{sCode}', '{sModel}', '{sNumber}', '{sBatteryV}', '{sOperate}', '{sOperateCount}', " +
                      $"'{sTemperature}', '{sHumidity}', '{sWindSpeed}', '{sOzone}', '{sFineDust}', '{sUFineDust}', '{sTime}')";                
            }
            else   // 기존 데이터가 있는 경우에 해당합니다.
            {
                sql = $"UPDATE {sTable} SET fModel = '{sModel}', fNumber =  '{sNumber}', fBatteryV = '{sBatteryV}', " +
                      $"fOperate = '{sOperate}', fOperateCount = '{sOperateCount}', fTemperature = '{sTemperature}', fHumidity = '{sHumidity}', " +
                      $"fWindSpeed = '{sWindSpeed}', fOzone = '{sOzone}', fFineDust = '{sFineDust}', fUFineDust = '{sUFineDust}', fTime = '{sTime}' " +
                      $"WHERE fCode = {sCode} AND fTime = (SELECT TOP 1 fTime FROM fStatus WHERE fCode = {sCode} ORDER BY fTime DESC)";
                /*
                 
                dataTable = (DataTable)RunSql($"SELECT TOP 1 * FROM {sTable} WHERE fCode = {sCode} OREDR BY fTime DESC");
                string st1 = dataTable.Rows[0][12].ToString();  // "yyyy-MM-dd (오전/오후) hh:mm:ss"
                DateTime d = DateTime.Parse(st1);
                string st2 = d.ToString("yyyy-MM-dd HH:mm:ss"); // "yyyy-MM-dd HH:mm:ss"
                */
                /*
                string st1 = dBConnectorR.Get($"SELECT TOP 1 fTime FROM {sTable} WHERE fCode = {sCode} OREDR BY fTime DESC").ToString();
                string st2 = DateTime.Parse(st1).ToString("yyyy-MM-dd HH:mm:ss");

                sql = $"UPDATE {sTable} SET fModel = '{sModel}', fNumber =  '{sNumber}', fBatteryV = '{sBatteryV}', " +
                      $"fOperate = '{sOperate}', fOperateCount = '{sOperateCount}', fTemperature = '{sTemperature}', fHumidity = '{sHumidity}', " +
                      $"fWindSpeed = '{sWindSpeed}', fOzone = '{sOzone}', fFineDust = '{sFineDust}', fUFineDust = '{sUFineDust}', fTime = '{sTime}' " +
                      $"WHERE fCode = {sCode} fTime = (SELECT TOP 1 fTime FROM fStatus WHERE fCode = {sCode} ORDER BY fTime DESC)";
                */
            }
            dBConnecterR.RunSql(sql);

        }

        private void ReadProcess()
        {
            while (true)
            {
                for (int i = 0; i < socketList.Count; i++)
                {
                    if (MyLib.IsAlive(socketList[i]) == true && socketList[i].Available > 0)
                    {
                        byte[] bArr = new byte[socketList[i].Available];
                        socketList[i].Receive(bArr);
                        ReadProcedure(socketList[i], bArr);
                    }                    
                }
                Thread.Sleep(100);
            }
        }

        private void UdpReceiptProcess()
        {
            while (true)
            {
                if(udpServerSocket.Available > 0)
                {
                    byte[] bArr = new byte[udpServerSocket.Available];
                    udpServerSocket.Receive(bArr);
                    // statusbar의 요소에는 delegate와 invoke 절차 없이 접근이 가능합니다.
                    SLabelUdpMessage.Text = Encoding.Default.GetString(bArr);
                    //PrintToSLabel(Encoding.Default.GetString(bArr));
                }
            }
        }




        private void MnuServerStart_Click(object sender, EventArgs e)
        {
            if(listener == null)
            {
                listener = new TcpListener(int.Parse(TBServerPort.Text));
            }
            else
            {
                listener.Stop(); // 임시 정지(메모리에서 삭제되지 않습니다.)
            }            
            listener.Start();

            if (serverThread != null)
            {
                serverThread.Abort();  // 완전 종결(메모리에서 삭제합니다.)
            }
            serverThread = new Thread(ServerProcess);
            serverThread.Start();

            if (readThread != null)
            {
                readThread.Abort();  // 완전 종결(메모리에서 삭제합니다.)
            }
            readThread = new Thread(ReadProcess);
            readThread.Start(); 

            // udp 통신 관련 소켓 설정
            
            if(udpServerSocket == null)
            {
                udpServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(TbUDPPort.Text));
                udpServerSocket.Bind(ipEndPoint);
            }

            // udp 통신 관련 스레드 설정

            if (udpReceiptThread == null)
            {
                udpReceiptThread = new Thread(UdpReceiptProcess);
                udpReceiptThread.Start();
            }
            

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            connectionString = iniFile.GetString("Database", "ConnectionString", @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Coding\WinForms_EquipManager\EquipManagerDB.mdf;Integrated Security=True;Connect Timeout=30");
            
            /* sqlConnectionR.ConnectionString = connectionString;
            sqlConnectionR.Open();
            sqlCommandR.Connection = sqlConnectionR;

            sqlConnectionM.ConnectionString = connectionString;
            sqlConnectionM.Open();
            sqlCommandM.Connection = sqlConnectionM; */

            // DBConnecter dBConnecter = DBConnecter.Instance;
            dBConnecterR = new DBConnecter(connectionString);
            dBConnecterM = new DBConnecter(connectionString);
            
            timer1.Start();
            
            TBServerPort.Text = iniFile.GetString("Server", "Port", "9001");

            int locationX = int.Parse(iniFile.GetString("Form", "LocationX", "0"));
            int locationY = int.Parse(iniFile.GetString("Form", "LocationY", "0"));
            Location = new Point(locationX, locationY);

            int sizeWidth = int.Parse(iniFile.GetString("Form", "SizeWidth", "500"));
            int sizeHeight = int.Parse(iniFile.GetString("Form", "SizeH", "500"));
            Size = new Size(sizeWidth, sizeHeight);

            tabControl1.SelectedIndex = int.Parse(iniFile.GetString("Form", "SelectedTabIndex", "1"));

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverThread != null)
            {
                serverThread.Abort();
            }
            if (readThread != null)
            {
                readThread.Abort();
            }
            if (udpReceiptThread != null)
            {
                udpReceiptThread.Abort();
            }

            iniFile.WriteString("Database", "ConnectionString", connectionString);
            iniFile.WriteString("Server", "Port", $"{TBServerPort.Text}");
            iniFile.WriteString("Form", "LocationX", $"{Location.X}");
            iniFile.WriteString("Form", "LocationY", $"{Location.Y}");
            iniFile.WriteString("Form", "SizeWidth", $"{Size.Width}");
            iniFile.WriteString("Form", "SizeHeight", $"{Size.Height}");
            iniFile.WriteString("Form", "SelectedTabIndex", $"{tabControl1.SelectedIndex}");            
        }
        private void SetGrid()
        {
            string sql = "SELECT * FROM fStatus";
            DataTable dataTable = (DataTable)dBConnecterM.RunSql(sql);
            dataGridView1.DataSource = dataTable;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            SetGrid();

            timer1.Start();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT COUNT(*) FROM EquipInfo WHERE fCode = {TbCode.Text}";
            int dataCount = (int)dBConnecterM.Get(sql);
            
            if(dataCount == 0)
            {
                sql = $"INSERT INTO EquipInfo VALUES (N'{TbCode.Text}', N'{TbModel.Text}', N'{TbName.Text}', " +
                    $"N'{TbDescription.Text}', N'{TbLocation1.Text}', N'{TbLocation2.Text}')";
            }
            else
            {
                sql = $"UPDATE EquipInfo SET fCode = N'{TbCode.Text}'";
                if (CbModel.Checked) {
                    sql += $", fModel = N'{TbModel.Text}'";
                }
                if (CbName.Checked)
                {
                    sql += $", fName = N'{TbName.Text}'";
                }
                if (CbDescription.Checked)
                {
                    sql += $", fDescription = N'{TbDescription.Text}'";
                }
                if (CbLocation1.Checked)
                {
                    sql += $", fLocation1 = N'{TbLocation1.Text}'";
                }
                if (CbLocation2.Checked)
                {
                    sql += $", fLocation2 = N'{TbLocation2.Text}'";
                }
                  
                sql += $"WHERE fCode = N'{TbCode.Text}'";
            }
            dBConnecterM.RunSql(sql);
        }
  
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string sCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string sql = $"SELECT * FROM EquipInfo WHERE fCode = {sCode}";
            DataTable dataTable = (DataTable)dBConnecterM.RunSql(sql);
            if (dataTable.Rows.Count > 0)
            {
                TbCode.Text = dataTable.Rows[0][0].ToString();
                TbModel.Text = dataTable.Rows[0][1].ToString();
                TbName.Text = dataTable.Rows[0][2].ToString();
                TbDescription.Text = dataTable.Rows[0][3].ToString();
                TbLocation1.Text = dataTable.Rows[0][4].ToString();
                TbLocation2.Text = dataTable.Rows[0][5].ToString();
            }
        }

        private void TbModel_TextChanged(object sender, EventArgs e)
        {
            CbModel.Checked = true;
        }

        private void TbName_TextChanged(object sender, EventArgs e)
        {
            CbName.Checked = true;
        }
        private void TbDescription_TextChanged(object sender, EventArgs e)
        {
            CbDescription.Checked = true;
        }

        private void TbLocation1_TextChanged(object sender, EventArgs e)
        {
            CbLocation1.Checked = true;
        }
        private void TbLocation2_TextChanged(object sender, EventArgs e)
        {
            CbLocation2.Checked = true;
        }
    }
}

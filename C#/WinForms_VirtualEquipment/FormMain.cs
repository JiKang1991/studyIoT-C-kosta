using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_VirtualEquipment
{
    public partial class FormMain : Form
    {
        IniFile iniFile = new IniFile(".\\VirtualEquipment.ini");
        FormClosingEventHandler formClosingEventHandler = null;
        
        public FormMain()
        {
            InitializeComponent();            
        }

        //===============================================
        //  delegate 메소드
        //==========================

        delegate void AddTextCB(string str);
        delegate void TimerTickCB(object socket);
        

        //================================================
        //  invoke 메소드
        //===========================

        private void AddText(string str)
        {
            if (TbMonitor.InvokeRequired)
            {
                Invoke(new AddTextCB(AddText), str);
            }
            else
            {
                TbMonitor.AppendText(str);
            }
        }

        private void TimerTick(object socket)
        {
            if (splitContainer1.Panel2.InvokeRequired)
            {
                Invoke(new TimerTickCB(TimerTick), socket);
            }
            else
            {
                if (CheckInTime())
                {
                    SetRandomValue();
                    char STX = '\u0002';
                    char ETX = '\u0003';
                    string str = STX + $"{int.Parse(TbEQCode.Text):D5}{int.Parse(TbEqModel.Text):D6}"
                                     + $"{int.Parse(TbEqNumber.Text):D5}{float.Parse(TbEqBatteryV.Text),5:F2}"
                                     + $"{int.Parse(TbEqOperate.Text):D1}{int.Parse(TbEqOperateCount.Text):D5}"
                                     + $"{int.Parse(TbTemperature.Text):D4}{int.Parse(TbHumidity.Text):D4}"
                                     + $"{int.Parse(TbWindSpeed.Text):D4}{int.Parse(TbOzone.Text):D4}"
                                     + $"{int.Parse(TbFineDust.Text):D3}{int.Parse(TbUltraFineDust.Text):D3}" + ETX;

                    byte[] bArr = Encoding.Default.GetBytes(str);

                    if (MyLib.IsAlive((Socket)socket))
                    {
                        ((Socket)socket).Send(bArr);
                        TbEqOperateCount.Text = $"{int.Parse(TbEqOperateCount.Text) + 1}";
                    }
                }                
            }
        }

        //================================================
        //  참조 메소드
        //===========================
        private bool IsAlive(Socket socket)
        {
            if(socket == null)
            {
                return false;
            }
            if (!socket.Connected)
            {
                return false;
            }

            bool canRead = socket.Poll(1000, SelectMode.SelectRead);
            if (socket.Poll(1000, SelectMode.SelectRead) && socket.Available == 0)
            {
                return false;
            }

            try
            {
                // 실제 전송되는 데이터 바이트는 0입니다.
                socket.Send(new byte[1], 0, SocketFlags.OutOfBand);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ReceiptProcess(Object oSocket)
        {
            Socket socket = (Socket)oSocket;
            while (true)
            {
                if (IsAlive(socket) && socket.Available > 0)
                {
                    byte[] bArr = new byte[socket.Available];
                    socket.Receive(bArr);
                    AddText(Encoding.Default.GetString(bArr) +"\r\n");
                }
                Thread.Sleep(100);
            }
        }

        private bool CheckInTime()
        {
            DateTime dateTime = DateTime.Now;
            DateTime startTime = DtStart.Value.Date + DtStartTime.Value.TimeOfDay;
            DateTime endTime = DtStop.Value.Date + DtStopTime.Value.TimeOfDay;

            

            return dateTime > startTime && dateTime < endTime;
        }

        private void SetRandomValue()
        {
            Random r = new Random();
            r.Next();
            TbTemperature.Text = $"{r.Next(0, 99)}";
            TbHumidity.Text = $"{r.Next(0, 99)}";
            TbWindSpeed.Text = $"{r.Next(0, 99)}";
            TbOzone.Text = $"{r.Next(0, 99)}";
        }

        //=============================================
        //  이벤트 처리 메소드
        //======================
        private void FormMain_Load(object sender, EventArgs e)
        {
            formClosingEventHandler = (_sender, _e) => { FormMain_FormClosing(); };
            FormClosing += formClosingEventHandler;



            TbEQCode.Text = iniFile.GetString("Equipment", "Code", "00001");                    //5
            TbEqModel.Text = iniFile.GetString("Equipment", "Model", "000000");                 //6
            TbEqNumber.Text = iniFile.GetString("Equipment", "Number", "00001");                //5
            TbEqBatteryV.Text = iniFile.GetString("Equipment", "BatteryV", "00001");            //5
            TbEqOperate.Text = iniFile.GetString("Equipment", "Operate", "1");                  //1
            TbEqOperateCount.Text = iniFile.GetString("Equipment", "OperateTime", "00001");     //5

            TbTemperature.Text = iniFile.GetString("Environment", "Temperature", "00001");      //4
            TbHumidity.Text = iniFile.GetString("Environment", "Humidity", "00001");            //4
            TbWindSpeed.Text = iniFile.GetString("Environment", "WindSpeed", "00001");          //4
            TbOzone.Text = iniFile.GetString("Environment", "Ozone", "00001");                  //4
            TbFineDust.Text = iniFile.GetString("Environment", "FineDust", "00001");            //3
            TbUltraFineDust.Text = iniFile.GetString("Environment", "UltraFineDust", "00001");  //3     total : 49byte

            DtStart.Value = new DateTime(long.Parse(iniFile.GetString("Operation", "StartDate", "0")));
            DtStartTime.Value = new DateTime(long.Parse(iniFile.GetString("Operation", "StartTime", "0")));
            DtStop.Value = new DateTime(long.Parse(iniFile.GetString("Operation", "StopDate", "0")));
            DtStopTime.Value = new DateTime(long.Parse(iniFile.GetString("Operation", "StopTime", "0")));
            TbTimeInterval.Text = iniFile.GetString("Operation", "TimeInterval", "5");

            SbLabel1.Text = iniFile.GetString("Server", "IP", "127.0.0.1");
            SbLabel2.Text = iniFile.GetString("Server", "IP", "9001");

            int locationX = int.Parse(iniFile.GetString("Form", "LocationX", "500"));
            int locationY = int.Parse(iniFile.GetString("Form", "LocationY", "500"));

            int sizeWidth = int.Parse(iniFile.GetString("Form", "SizeWidth", "800"));
            int sizeHeigth = int.Parse(iniFile.GetString("Form", "SizeHeigth", "800"));

            Location = new Point(locationX, locationY);
            Size = new Size(sizeWidth, sizeHeigth);
        }

        private void MnuStart_Click(object sender, EventArgs e)
        {
            Socket socket = null;
            Thread receiptThread = null;
            System.Threading.Timer timer1 = null;

            // 소켓이 생성되어있는 상황에서 다시 'Start'버튼을 누르면 if구문 블록의 작업이 수행됩니다.
            if (socket != null)
            {
                socket.Close();
            }
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(SbLabel1.Text, int.Parse(SbLabel2.Text));
            FormClosing -= formClosingEventHandler;

            if (receiptThread != null)
            {
                receiptThread.Abort();               
            }
            receiptThread = new Thread(new ParameterizedThreadStart(ReceiptProcess));
            receiptThread.IsBackground = true;
            receiptThread.Start(socket);

            try
            {
                
                if (timer1 == null)
                {
                    timer1 = new System.Threading.Timer(TimerTick, socket, 1000, int.Parse(TbTimeInterval.Text) * 1000);
                }
                //timer1.Interval = int.Parse(TbTimeInterval.Text) * 1000;
                //timer1.Enabled = true;
                //timer1.Tick += new EventHandler(timer1_Tick(sender, e, socket));
                //Controls.Add(timer1);
                //timer1.Start();
                MnuStop.Click += (_sender, _e) => { MnuStop_Click(receiptThread, socket, timer1); };
                FormClosing += (_sender, _e) => { FormMain_FormClosing(timer1, socket); };
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void MnuStop_Click(Thread receiptThread, Socket socket, System.Threading.Timer timer1)
        {
            timer1.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            if (receiptThread != null)
            {
                receiptThread.Abort();
                receiptThread = null;
            }
            if (socket != null)
            {
                socket.Close();
                socket = null;
            }
        }

        private void SbLabel1_DoubleClick(object sender, EventArgs e)
        {
            string str = MyLib.GetInput("IP Address");
            if(str != "")
            {
                SbLabel1.Text = str;
            }
        }

        private void SbLabel2_Click(object sender, EventArgs e)
        {
            string str = MyLib.GetInput("Port");
            if (str != "")
            {
                SbLabel2.Text = str;
            }
        }
        /*
        private void timer1_Tick(object sender, EventArgs e, Socket socket)
        {
            timer1.Stop();

            // Package 구성 : 패킷의 전후에 [02](STX : StartOfText)
            // [03](ETX : EndOfText 문자를 덧붙이는것이 관례입니다.
            // 53 + 2 = 55 byte가 한 패킷으로 구성됩니다.
            // send package : byte[]로 구성됩니다.
            string str = TbEQCode.Text + TbEqModel.Text + TbEqNumber.Text + TbEqBatteryV.Text
                + TbEqOperate.Text + TbEqOperateCount + TbTemperature.Text + TbHumidity.Text
                + TbWindSpeed.Text + TbOzone.Text + TbFineDust.Text + TbUltraFineDust.Text;

            byte[] bArr = Encoding.Default.GetBytes(str);

            if (MyLib.IsAlive(socket))
            {
                socket.Send(bArr);
                TbEqOperateCount.Text
            }
            

            timer1.Start();
        }
        */

        private void FormMain_FormClosing(System.Threading.Timer timer1 = null, Socket socket = null)
        {
            if(timer1 != null)
            {
                timer1.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            }
            if (socket != null)
            {
                socket.Close();
            }

            iniFile.WriteString("Equipment", "Code", TbEQCode.Text);                    //5
            iniFile.WriteString("Equipment", "Model", TbEqModel.Text);                 //6
            iniFile.WriteString("Equipment", "Number", TbEqNumber.Text);                //5
            iniFile.WriteString("Equipment", "BatteryV", TbEqBatteryV.Text);            //5
            iniFile.WriteString("Equipment", "Operate", TbEqOperate.Text);              //5
            iniFile.WriteString("Equipment", "OperateTime", TbEqOperateCount.Text);     //5

            iniFile.WriteString("Environment", "Temperature", TbTemperature.Text);      //4
            iniFile.WriteString("Environment", "Humidity", TbHumidity.Text);            //4
            iniFile.WriteString("Environment", "WindSpeed", TbWindSpeed.Text);          //4
            iniFile.WriteString("Environment", "Ozone", TbOzone.Text);                  //4
            iniFile.WriteString("Environment", "FineDust", TbFineDust.Text);            //3
            iniFile.WriteString("Environment", "UltraFineDust", TbUltraFineDust.Text);  //3     total : 53byte

            iniFile.WriteString("Operation", "StartDate", DtStart.Value.Ticks.ToString());
            iniFile.WriteString("Operation", "StartTime", DtStartTime.Value.Ticks.ToString());
            iniFile.WriteString("Operation", "StopDate", DtStop.Value.Ticks.ToString());
            iniFile.WriteString("Operation", "StopTime", DtStopTime.Value.Ticks.ToString());
            iniFile.WriteString("Operation", "TimeInterval", TbTimeInterval.Text);

            iniFile.WriteString("Form", "LocationX", $"{Location.X}");
            iniFile.WriteString("Form", "LocationY", $"{Location.Y}");

            iniFile.WriteString("Form", "SizeWidth", $"{Size.Width}");
            iniFile.WriteString("Form", "SizeHeigth", $"{Size.Height}");
        }

        
    }
}

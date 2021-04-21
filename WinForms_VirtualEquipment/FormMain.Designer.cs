
namespace WinForms_VirtualEquipment
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SbLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TbMonitor = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtStop = new System.Windows.Forms.DateTimePicker();
            this.DtStopTime = new System.Windows.Forms.DateTimePicker();
            this.DtStartTime = new System.Windows.Forms.DateTimePicker();
            this.DtStart = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TbTimeInterval = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TbUltraFineDust = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TbOzone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TbHumidity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TbFineDust = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TbWindSpeed = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TbTemperature = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TbEqOperateCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TbEqBatteryV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TbEqModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TbEqOperate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbEqNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbEQCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(447, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuStart,
            this.MnuStop,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MnuStart
            // 
            this.MnuStart.Name = "MnuStart";
            this.MnuStart.Size = new System.Drawing.Size(180, 22);
            this.MnuStart.Text = "Start";
            this.MnuStart.Click += new System.EventHandler(this.MnuStart_Click);
            // 
            // MnuStop
            // 
            this.MnuStop.Name = "MnuStop";
            this.MnuStop.Size = new System.Drawing.Size(180, 22);
            this.MnuStop.Text = "Stop";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SbLabel1,
            this.SbLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 522);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(447, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SbLabel1
            // 
            this.SbLabel1.AutoSize = false;
            this.SbLabel1.DoubleClickEnabled = true;
            this.SbLabel1.Name = "SbLabel1";
            this.SbLabel1.Size = new System.Drawing.Size(100, 17);
            this.SbLabel1.Text = "000.000.000.000";
            this.SbLabel1.DoubleClick += new System.EventHandler(this.SbLabel1_DoubleClick);
            // 
            // SbLabel2
            // 
            this.SbLabel2.AutoSize = false;
            this.SbLabel2.DoubleClickEnabled = true;
            this.SbLabel2.Name = "SbLabel2";
            this.SbLabel2.Size = new System.Drawing.Size(50, 17);
            this.SbLabel2.Text = "00000";
            this.SbLabel2.Click += new System.EventHandler(this.SbLabel2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TbMonitor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(447, 492);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.TabIndex = 2;
            // 
            // TbMonitor
            // 
            this.TbMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbMonitor.Location = new System.Drawing.Point(0, 0);
            this.TbMonitor.Multiline = true;
            this.TbMonitor.Name = "TbMonitor";
            this.TbMonitor.Size = new System.Drawing.Size(447, 45);
            this.TbMonitor.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.DtStop);
            this.groupBox3.Controls.Add(this.DtStopTime);
            this.groupBox3.Controls.Add(this.DtStartTime);
            this.groupBox3.Controls.Add(this.DtStart);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.TbTimeInterval);
            this.groupBox3.Location = new System.Drawing.Point(8, 290);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 130);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // DtStop
            // 
            this.DtStop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtStop.Location = new System.Drawing.Point(111, 56);
            this.DtStop.Name = "DtStop";
            this.DtStop.Size = new System.Drawing.Size(79, 21);
            this.DtStop.TabIndex = 2;
            // 
            // DtStopTime
            // 
            this.DtStopTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtStopTime.Location = new System.Drawing.Point(196, 56);
            this.DtStopTime.Name = "DtStopTime";
            this.DtStopTime.ShowUpDown = true;
            this.DtStopTime.Size = new System.Drawing.Size(122, 21);
            this.DtStopTime.TabIndex = 2;
            // 
            // DtStartTime
            // 
            this.DtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DtStartTime.Location = new System.Drawing.Point(196, 26);
            this.DtStartTime.Name = "DtStartTime";
            this.DtStartTime.ShowUpDown = true;
            this.DtStartTime.Size = new System.Drawing.Size(122, 21);
            this.DtStartTime.TabIndex = 2;
            // 
            // DtStart
            // 
            this.DtStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtStart.Location = new System.Drawing.Point(111, 26);
            this.DtStart.Name = "DtStart";
            this.DtStart.Size = new System.Drawing.Size(79, 21);
            this.DtStart.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(214, 90);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "Secound";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "Time Interval";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "Stop Time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "Start Time";
            // 
            // TbTimeInterval
            // 
            this.TbTimeInterval.Location = new System.Drawing.Point(110, 87);
            this.TbTimeInterval.Name = "TbTimeInterval";
            this.TbTimeInterval.Size = new System.Drawing.Size(100, 21);
            this.TbTimeInterval.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.TbUltraFineDust);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TbOzone);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TbHumidity);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TbFineDust);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TbWindSpeed);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TbTemperature);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(8, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 128);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox1";
            // 
            // TbUltraFineDust
            // 
            this.TbUltraFineDust.Location = new System.Drawing.Point(216, 85);
            this.TbUltraFineDust.MaxLength = 3;
            this.TbUltraFineDust.Name = "TbUltraFineDust";
            this.TbUltraFineDust.Size = new System.Drawing.Size(100, 21);
            this.TbUltraFineDust.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "UltraFine Dust(3)";
            // 
            // TbOzone
            // 
            this.TbOzone.Location = new System.Drawing.Point(216, 58);
            this.TbOzone.MaxLength = 4;
            this.TbOzone.Name = "TbOzone";
            this.TbOzone.Size = new System.Drawing.Size(100, 21);
            this.TbOzone.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ozone(4)";
            // 
            // TbHumidity
            // 
            this.TbHumidity.Location = new System.Drawing.Point(216, 31);
            this.TbHumidity.MaxLength = 4;
            this.TbHumidity.Name = "TbHumidity";
            this.TbHumidity.Size = new System.Drawing.Size(100, 21);
            this.TbHumidity.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "Humidity(4)";
            // 
            // TbFineDust
            // 
            this.TbFineDust.Location = new System.Drawing.Point(110, 85);
            this.TbFineDust.MaxLength = 3;
            this.TbFineDust.Name = "TbFineDust";
            this.TbFineDust.Size = new System.Drawing.Size(100, 21);
            this.TbFineDust.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fine Dust(3)";
            // 
            // TbWindSpeed
            // 
            this.TbWindSpeed.Location = new System.Drawing.Point(110, 58);
            this.TbWindSpeed.MaxLength = 4;
            this.TbWindSpeed.Name = "TbWindSpeed";
            this.TbWindSpeed.Size = new System.Drawing.Size(100, 21);
            this.TbWindSpeed.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "Wind Speed(4)";
            // 
            // TbTemperature
            // 
            this.TbTemperature.Location = new System.Drawing.Point(110, 31);
            this.TbTemperature.MaxLength = 4;
            this.TbTemperature.Name = "TbTemperature";
            this.TbTemperature.Size = new System.Drawing.Size(100, 21);
            this.TbTemperature.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "Temperature(4)";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.TbEqOperateCount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TbEqBatteryV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TbEqModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TbEqOperate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TbEqNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TbEQCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // TbEqOperateCount
            // 
            this.TbEqOperateCount.Location = new System.Drawing.Point(216, 85);
            this.TbEqOperateCount.MaxLength = 5;
            this.TbEqOperateCount.Name = "TbEqOperateCount";
            this.TbEqOperateCount.Size = new System.Drawing.Size(100, 21);
            this.TbEqOperateCount.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Operate Count(5)";
            // 
            // TbEqBatteryV
            // 
            this.TbEqBatteryV.Location = new System.Drawing.Point(216, 58);
            this.TbEqBatteryV.MaxLength = 5;
            this.TbEqBatteryV.Name = "TbEqBatteryV";
            this.TbEqBatteryV.Size = new System.Drawing.Size(100, 21);
            this.TbEqBatteryV.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "BatteryV(5)";
            // 
            // TbEqModel
            // 
            this.TbEqModel.Location = new System.Drawing.Point(216, 31);
            this.TbEqModel.MaxLength = 6;
            this.TbEqModel.Name = "TbEqModel";
            this.TbEqModel.Size = new System.Drawing.Size(100, 21);
            this.TbEqModel.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Model(6)";
            // 
            // TbEqOperate
            // 
            this.TbEqOperate.Location = new System.Drawing.Point(110, 85);
            this.TbEqOperate.MaxLength = 1;
            this.TbEqOperate.Name = "TbEqOperate";
            this.TbEqOperate.Size = new System.Drawing.Size(100, 21);
            this.TbEqOperate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Operate(1)";
            // 
            // TbEqNumber
            // 
            this.TbEqNumber.Location = new System.Drawing.Point(110, 58);
            this.TbEqNumber.MaxLength = 5;
            this.TbEqNumber.Name = "TbEqNumber";
            this.TbEqNumber.Size = new System.Drawing.Size(100, 21);
            this.TbEqNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number(5)";
            // 
            // TbEQCode
            // 
            this.TbEQCode.Location = new System.Drawing.Point(110, 31);
            this.TbEQCode.MaxLength = 5;
            this.TbEQCode.Name = "TbEQCode";
            this.TbEQCode.Size = new System.Drawing.Size(100, 21);
            this.TbEQCode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 34);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code(5)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 544);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(463, 583);
            this.Name = "FormMain";
            this.Text = "Virtual Equipment";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TbMonitor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TbEqOperateCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbEqBatteryV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbEqModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbEqOperate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbEqNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbEQCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TbUltraFineDust;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TbOzone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TbHumidity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TbFineDust;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TbWindSpeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TbTemperature;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripStatusLabel SbLabel1;
        private System.Windows.Forms.ToolStripStatusLabel SbLabel2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuStart;
        private System.Windows.Forms.ToolStripMenuItem MnuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DtStop;
        private System.Windows.Forms.DateTimePicker DtStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TbTimeInterval;
        private System.Windows.Forms.DateTimePicker DtStopTime;
        private System.Windows.Forms.DateTimePicker DtStartTime;
    }
}


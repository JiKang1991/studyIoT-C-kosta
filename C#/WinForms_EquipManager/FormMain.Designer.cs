
namespace WinForms_EquipManager
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuServerStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuServerStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbLocation2 = new System.Windows.Forms.CheckBox();
            this.CbLocation1 = new System.Windows.Forms.CheckBox();
            this.CbName = new System.Windows.Forms.CheckBox();
            this.CbDescription = new System.Windows.Forms.CheckBox();
            this.CbModel = new System.Windows.Forms.CheckBox();
            this.CbCode = new System.Windows.Forms.CheckBox();
            this.TbCode = new System.Windows.Forms.TextBox();
            this.LbCode = new System.Windows.Forms.Label();
            this.LbDescription = new System.Windows.Forms.Label();
            this.LbModel = new System.Windows.Forms.Label();
            this.TbDescription = new System.Windows.Forms.TextBox();
            this.TbModel = new System.Windows.Forms.TextBox();
            this.LbLocation1 = new System.Windows.Forms.Label();
            this.TbLocation1 = new System.Windows.Forms.TextBox();
            this.LbName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.TbLocation2 = new System.Windows.Forms.TextBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbInterval = new System.Windows.Forms.TextBox();
            this.TBServerPort = new System.Windows.Forms.TextBox();
            this.TBMoniter = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(977, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuServerStart,
            this.MnuServerStop,
            this.toolStripMenuItem1,
            this.MnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MnuServerStart
            // 
            this.MnuServerStart.Name = "MnuServerStart";
            this.MnuServerStart.Size = new System.Drawing.Size(99, 22);
            this.MnuServerStart.Text = "Start";
            this.MnuServerStart.Click += new System.EventHandler(this.MnuServerStart_Click);
            // 
            // MnuServerStop
            // 
            this.MnuServerStop.Name = "MnuServerStop";
            this.MnuServerStop.Size = new System.Drawing.Size(99, 22);
            this.MnuServerStop.Text = "Stop";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 6);
            // 
            // MnuExit
            // 
            this.MnuExit.Name = "MnuExit";
            this.MnuExit.Size = new System.Drawing.Size(99, 22);
            this.MnuExit.Text = "Exit";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 728);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(970, 702);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Concole";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.BtnUpdate);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(964, 696);
            this.splitContainer2.SplitterDistance = 301;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.textBox9);
            this.groupBox2.Location = new System.Drawing.Point(17, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 124);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(120, 45);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 21);
            this.textBox8.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ozone";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(14, 85);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "FineDust";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(226, 45);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 21);
            this.textBox10.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "Temperature";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(224, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "WindSpeed";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(224, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "UltraFineDust";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(120, 85);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(118, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "Humidity";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(14, 45);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 2;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(226, 85);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 21);
            this.textBox9.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbLocation2);
            this.groupBox1.Controls.Add(this.CbLocation1);
            this.groupBox1.Controls.Add(this.CbName);
            this.groupBox1.Controls.Add(this.CbDescription);
            this.groupBox1.Controls.Add(this.CbModel);
            this.groupBox1.Controls.Add(this.CbCode);
            this.groupBox1.Controls.Add(this.TbCode);
            this.groupBox1.Controls.Add(this.LbCode);
            this.groupBox1.Controls.Add(this.LbDescription);
            this.groupBox1.Controls.Add(this.LbModel);
            this.groupBox1.Controls.Add(this.TbDescription);
            this.groupBox1.Controls.Add(this.TbModel);
            this.groupBox1.Controls.Add(this.LbLocation1);
            this.groupBox1.Controls.Add(this.TbLocation1);
            this.groupBox1.Controls.Add(this.LbName);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.TbName);
            this.groupBox1.Controls.Add(this.TbLocation2);
            this.groupBox1.Location = new System.Drawing.Point(17, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 129);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // CbLocation2
            // 
            this.CbLocation2.AutoSize = true;
            this.CbLocation2.Location = new System.Drawing.Point(311, 68);
            this.CbLocation2.Name = "CbLocation2";
            this.CbLocation2.Size = new System.Drawing.Size(15, 14);
            this.CbLocation2.TabIndex = 3;
            this.CbLocation2.UseVisualStyleBackColor = true;
            // 
            // CbLocation1
            // 
            this.CbLocation1.AutoSize = true;
            this.CbLocation1.Location = new System.Drawing.Point(205, 68);
            this.CbLocation1.Name = "CbLocation1";
            this.CbLocation1.Size = new System.Drawing.Size(15, 14);
            this.CbLocation1.TabIndex = 3;
            this.CbLocation1.UseVisualStyleBackColor = true;
            // 
            // CbName
            // 
            this.CbName.AutoSize = true;
            this.CbName.Location = new System.Drawing.Point(311, 25);
            this.CbName.Name = "CbName";
            this.CbName.Size = new System.Drawing.Size(15, 14);
            this.CbName.TabIndex = 3;
            this.CbName.UseVisualStyleBackColor = true;
            // 
            // CbDescription
            // 
            this.CbDescription.AutoSize = true;
            this.CbDescription.Location = new System.Drawing.Point(96, 68);
            this.CbDescription.Name = "CbDescription";
            this.CbDescription.Size = new System.Drawing.Size(15, 14);
            this.CbDescription.TabIndex = 3;
            this.CbDescription.UseVisualStyleBackColor = true;
            // 
            // CbModel
            // 
            this.CbModel.AutoSize = true;
            this.CbModel.Location = new System.Drawing.Point(205, 25);
            this.CbModel.Name = "CbModel";
            this.CbModel.Size = new System.Drawing.Size(15, 14);
            this.CbModel.TabIndex = 3;
            this.CbModel.UseVisualStyleBackColor = true;
            // 
            // CbCode
            // 
            this.CbCode.AutoSize = true;
            this.CbCode.Location = new System.Drawing.Point(96, 25);
            this.CbCode.Name = "CbCode";
            this.CbCode.Size = new System.Drawing.Size(15, 14);
            this.CbCode.TabIndex = 3;
            this.CbCode.UseVisualStyleBackColor = true;
            // 
            // TbCode
            // 
            this.TbCode.Location = new System.Drawing.Point(18, 41);
            this.TbCode.Name = "TbCode";
            this.TbCode.Size = new System.Drawing.Size(100, 21);
            this.TbCode.TabIndex = 2;
            // 
            // LbCode
            // 
            this.LbCode.AutoSize = true;
            this.LbCode.Location = new System.Drawing.Point(16, 25);
            this.LbCode.Name = "LbCode";
            this.LbCode.Size = new System.Drawing.Size(35, 12);
            this.LbCode.TabIndex = 1;
            this.LbCode.Text = "Code";
            // 
            // LbDescription
            // 
            this.LbDescription.AutoSize = true;
            this.LbDescription.Location = new System.Drawing.Point(16, 69);
            this.LbDescription.Name = "LbDescription";
            this.LbDescription.Size = new System.Drawing.Size(68, 12);
            this.LbDescription.TabIndex = 1;
            this.LbDescription.Text = "Description";
            // 
            // LbModel
            // 
            this.LbModel.AutoSize = true;
            this.LbModel.Location = new System.Drawing.Point(122, 25);
            this.LbModel.Name = "LbModel";
            this.LbModel.Size = new System.Drawing.Size(40, 12);
            this.LbModel.TabIndex = 1;
            this.LbModel.Text = "Model";
            // 
            // TbDescription
            // 
            this.TbDescription.Location = new System.Drawing.Point(18, 85);
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.Size = new System.Drawing.Size(100, 21);
            this.TbDescription.TabIndex = 2;
            this.TbDescription.TextChanged += new System.EventHandler(this.TbDescription_TextChanged);
            // 
            // TbModel
            // 
            this.TbModel.Location = new System.Drawing.Point(124, 41);
            this.TbModel.Name = "TbModel";
            this.TbModel.Size = new System.Drawing.Size(100, 21);
            this.TbModel.TabIndex = 2;
            this.TbModel.TextChanged += new System.EventHandler(this.TbModel_TextChanged);
            // 
            // LbLocation1
            // 
            this.LbLocation1.AutoSize = true;
            this.LbLocation1.Location = new System.Drawing.Point(122, 69);
            this.LbLocation1.Name = "LbLocation1";
            this.LbLocation1.Size = new System.Drawing.Size(59, 12);
            this.LbLocation1.TabIndex = 1;
            this.LbLocation1.Text = "Location1";
            // 
            // TbLocation1
            // 
            this.TbLocation1.Location = new System.Drawing.Point(124, 85);
            this.TbLocation1.Name = "TbLocation1";
            this.TbLocation1.Size = new System.Drawing.Size(100, 21);
            this.TbLocation1.TabIndex = 2;
            this.TbLocation1.TextChanged += new System.EventHandler(this.TbLocation1_TextChanged);
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(228, 25);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(39, 12);
            this.LbName.TabIndex = 1;
            this.LbName.Text = "Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(228, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "Location2";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(230, 41);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 2;
            this.TbName.TextChanged += new System.EventHandler(this.TbName_TextChanged);
            // 
            // TbLocation2
            // 
            this.TbLocation2.Location = new System.Drawing.Point(230, 85);
            this.TbLocation2.Name = "TbLocation2";
            this.TbLocation2.Size = new System.Drawing.Size(100, 21);
            this.TbLocation2.TabIndex = 2;
            this.TbLocation2.TextChanged += new System.EventHandler(this.TbLocation2_TextChanged);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(377, 55);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 61);
            this.BtnUpdate.TabIndex = 0;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(964, 391);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(970, 702);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Environment";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TbInterval);
            this.splitContainer1.Panel1.Controls.Add(this.TBServerPort);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TBMoniter);
            this.splitContainer1.Size = new System.Drawing.Size(964, 696);
            this.splitContainer1.SplitterDistance = 329;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "초";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Interval";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server TCP Port";
            // 
            // TbInterval
            // 
            this.TbInterval.Location = new System.Drawing.Point(113, 64);
            this.TbInterval.Name = "TbInterval";
            this.TbInterval.Size = new System.Drawing.Size(47, 21);
            this.TbInterval.TabIndex = 0;
            this.TbInterval.Text = "5";
            this.TbInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBServerPort
            // 
            this.TBServerPort.Location = new System.Drawing.Point(113, 37);
            this.TBServerPort.Name = "TBServerPort";
            this.TBServerPort.Size = new System.Drawing.Size(47, 21);
            this.TBServerPort.TabIndex = 0;
            this.TBServerPort.Text = "9001";
            this.TBServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TBMoniter
            // 
            this.TBMoniter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBMoniter.Location = new System.Drawing.Point(0, 0);
            this.TBMoniter.Multiline = true;
            this.TBMoniter.Name = "TBMoniter";
            this.TBMoniter.Size = new System.Drawing.Size(631, 696);
            this.TBMoniter.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 754);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(977, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 776);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Equipment Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TBMoniter;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnuServerStart;
        private System.Windows.Forms.ToolStripMenuItem MnuServerStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MnuExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBServerPort;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbModel;
        private System.Windows.Forms.Label LbModel;
        private System.Windows.Forms.TextBox TbCode;
        private System.Windows.Forms.Label LbCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LbDescription;
        private System.Windows.Forms.TextBox TbDescription;
        private System.Windows.Forms.Label LbLocation1;
        private System.Windows.Forms.TextBox TbLocation1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TbLocation2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox CbLocation2;
        private System.Windows.Forms.CheckBox CbLocation1;
        private System.Windows.Forms.CheckBox CbName;
        private System.Windows.Forms.CheckBox CbDescription;
        private System.Windows.Forms.CheckBox CbModel;
        private System.Windows.Forms.CheckBox CbCode;
    }
}


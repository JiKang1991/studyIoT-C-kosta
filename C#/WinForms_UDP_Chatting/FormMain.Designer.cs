
namespace WinForms_UDP_Chatting
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.TbOutput = new System.Windows.Forms.TextBox();
            this.TbInput = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MnuSend = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SLabel1,
            this.SLabel2,
            this.toolStripStatusLabel1,
            this.SLabel3,
            this.SLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(372, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SLabel1
            // 
            this.SLabel1.AutoSize = false;
            this.SLabel1.DoubleClickEnabled = true;
            this.SLabel1.Name = "SLabel1";
            this.SLabel1.Size = new System.Drawing.Size(100, 17);
            this.SLabel1.Text = "127.0.0.1";
            this.SLabel1.DoubleClick += new System.EventHandler(this.SLabel1_DoubleClick);
            // 
            // SLabel2
            // 
            this.SLabel2.AutoSize = false;
            this.SLabel2.DoubleClickEnabled = true;
            this.SLabel2.Name = "SLabel2";
            this.SLabel2.Size = new System.Drawing.Size(40, 17);
            this.SLabel2.Text = "9001";
            this.SLabel2.DoubleClick += new System.EventHandler(this.SLabel2_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuStart});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(372, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnuStart
            // 
            this.MnuStart.Name = "MnuStart";
            this.MnuStart.Size = new System.Drawing.Size(44, 20);
            this.MnuStart.Text = "Start";
            this.MnuStart.Click += new System.EventHandler(this.MnuStart_Click);
            // 
            // TbOutput
            // 
            this.TbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbOutput.Location = new System.Drawing.Point(12, 27);
            this.TbOutput.Multiline = true;
            this.TbOutput.Name = "TbOutput";
            this.TbOutput.Size = new System.Drawing.Size(348, 308);
            this.TbOutput.TabIndex = 2;
            // 
            // TbInput
            // 
            this.TbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbInput.ContextMenuStrip = this.contextMenuStrip1;
            this.TbInput.Location = new System.Drawing.Point(12, 341);
            this.TbInput.Multiline = true;
            this.TbInput.Name = "TbInput";
            this.TbInput.Size = new System.Drawing.Size(348, 78);
            this.TbInput.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuSend});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            // 
            // MnuSend
            // 
            this.MnuSend.Name = "MnuSend";
            this.MnuSend.Size = new System.Drawing.Size(101, 22);
            this.MnuSend.Text = "Send";
            this.MnuSend.Click += new System.EventHandler(this.MnuSend_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(30, 17);
            // 
            // SLabel3
            // 
            this.SLabel3.AutoSize = false;
            this.SLabel3.DoubleClickEnabled = true;
            this.SLabel3.Name = "SLabel3";
            this.SLabel3.Size = new System.Drawing.Size(100, 17);
            this.SLabel3.Text = "127.0.0.1";
            this.SLabel3.DoubleClick += new System.EventHandler(this.SLabel3_DoubleClick);
            // 
            // SLabel4
            // 
            this.SLabel4.AutoSize = false;
            this.SLabel4.DoubleClickEnabled = true;
            this.SLabel4.Name = "SLabel4";
            this.SLabel4.Size = new System.Drawing.Size(40, 17);
            this.SLabel4.Text = "9100";
            this.SLabel4.DoubleClick += new System.EventHandler(this.SLabel4_DoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 444);
            this.Controls.Add(this.TbInput);
            this.Controls.Add(this.TbOutput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "UDP Chatting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SLabel1;
        private System.Windows.Forms.ToolStripStatusLabel SLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox TbOutput;
        private System.Windows.Forms.ToolStripMenuItem MnuStart;
        private System.Windows.Forms.TextBox TbInput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnuSend;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel SLabel3;
        private System.Windows.Forms.ToolStripStatusLabel SLabel4;
    }
}


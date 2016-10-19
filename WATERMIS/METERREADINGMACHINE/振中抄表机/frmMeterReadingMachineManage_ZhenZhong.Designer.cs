namespace METERREADINGMACHINE
{
    partial class frmMeterReadingMachineManage_ZhenZhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeterReadingMachineManage_ZhenZhong));
            this.btSetDateTime = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripPort = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labState = new System.Windows.Forms.Label();
            this.txtOpenFileName = new System.Windows.Forms.TextBox();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.btDownFile = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.lstMachineFileList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstMeterReader = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNameS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSetMeterReader = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSetDateTime
            // 
            this.btSetDateTime.Location = new System.Drawing.Point(41, 30);
            this.btSetDateTime.Name = "btSetDateTime";
            this.btSetDateTime.Size = new System.Drawing.Size(129, 36);
            this.btSetDateTime.TabIndex = 3;
            this.btSetDateTime.Text = "设定时间";
            this.btSetDateTime.UseVisualStyleBackColor = true;
            this.btSetDateTime.Click += new System.EventHandler(this.btSetDateTime_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRefresh,
            this.toolStripPort,
            this.toolStripConnect,
            this.toolStripClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(827, 28);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefresh.Image")));
            this.toolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.Size = new System.Drawing.Size(98, 25);
            this.toolStripRefresh.Text = "刷新端口:";
            this.toolStripRefresh.Click += new System.EventHandler(this.toolStripRefresh_Click);
            // 
            // toolStripPort
            // 
            this.toolStripPort.AutoSize = false;
            this.toolStripPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripPort.Name = "toolStripPort";
            this.toolStripPort.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripConnect
            // 
            this.toolStripConnect.Image = ((System.Drawing.Image)(resources.GetObject("toolStripConnect.Image")));
            this.toolStripConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConnect.Name = "toolStripConnect";
            this.toolStripConnect.Size = new System.Drawing.Size(62, 25);
            this.toolStripConnect.Text = "连接";
            this.toolStripConnect.Click += new System.EventHandler(this.toolStripConnect_Click);
            // 
            // toolStripClose
            // 
            this.toolStripClose.Enabled = false;
            this.toolStripClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripClose.Image")));
            this.toolStripClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripClose.Name = "toolStripClose";
            this.toolStripClose.Size = new System.Drawing.Size(62, 25);
            this.toolStripClose.Text = "断开";
            this.toolStripClose.Click += new System.EventHandler(this.toolStripClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btSetDateTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(226, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 532);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件管理";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.labState);
            this.groupBox6.Controls.Add(this.txtOpenFileName);
            this.groupBox6.Controls.Add(this.btOpenFile);
            this.groupBox6.Controls.Add(this.btDownFile);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 224);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(592, 305);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "下载文件到抄表机";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(31, 91);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(0, 16);
            this.labState.TabIndex = 7;
            // 
            // txtOpenFileName
            // 
            this.txtOpenFileName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtOpenFileName.Location = new System.Drawing.Point(118, 46);
            this.txtOpenFileName.Name = "txtOpenFileName";
            this.txtOpenFileName.ReadOnly = true;
            this.txtOpenFileName.Size = new System.Drawing.Size(467, 26);
            this.txtOpenFileName.TabIndex = 6;
            // 
            // btOpenFile
            // 
            this.btOpenFile.Location = new System.Drawing.Point(25, 40);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(88, 36);
            this.btOpenFile.TabIndex = 5;
            this.btOpenFile.Text = "导入文件";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // btDownFile
            // 
            this.btDownFile.Enabled = false;
            this.btDownFile.Location = new System.Drawing.Point(25, 226);
            this.btDownFile.Name = "btDownFile";
            this.btDownFile.Size = new System.Drawing.Size(117, 36);
            this.btDownFile.TabIndex = 4;
            this.btDownFile.Text = "下载到抄表机";
            this.btDownFile.UseVisualStyleBackColor = true;
            this.btDownFile.Visible = false;
            this.btDownFile.Click += new System.EventHandler(this.btDownFile_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btDelete);
            this.groupBox5.Controls.Add(this.lstMachineFileList);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(592, 202);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "抄表机内部文件列表";
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(192, 147);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(81, 36);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "删除文件";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // lstMachineFileList
            // 
            this.lstMachineFileList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstMachineFileList.FormattingEnabled = true;
            this.lstMachineFileList.HorizontalScrollbar = true;
            this.lstMachineFileList.ItemHeight = 16;
            this.lstMachineFileList.Location = new System.Drawing.Point(3, 22);
            this.lstMachineFileList.Name = "lstMachineFileList";
            this.lstMachineFileList.Size = new System.Drawing.Size(183, 164);
            this.lstMachineFileList.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(827, 538);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(217, 532);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstMeterReader);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.btSetMeterReader);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 442);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "抄表员设置";
            // 
            // lstMeterReader
            // 
            this.lstMeterReader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstMeterReader.FormattingEnabled = true;
            this.lstMeterReader.HorizontalScrollbar = true;
            this.lstMeterReader.ItemHeight = 16;
            this.lstMeterReader.Location = new System.Drawing.Point(3, 82);
            this.lstMeterReader.Name = "lstMeterReader";
            this.lstMeterReader.Size = new System.Drawing.Size(205, 308);
            this.lstMeterReader.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNameS);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(205, 60);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "查询条件";
            // 
            // txtNameS
            // 
            this.txtNameS.Location = new System.Drawing.Point(66, 23);
            this.txtNameS.Name = "txtNameS";
            this.txtNameS.Size = new System.Drawing.Size(100, 26);
            this.txtNameS.TabIndex = 0;
            this.txtNameS.TextChanged += new System.EventHandler(this.txtNameS_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // btSetMeterReader
            // 
            this.btSetMeterReader.Location = new System.Drawing.Point(41, 399);
            this.btSetMeterReader.Name = "btSetMeterReader";
            this.btSetMeterReader.Size = new System.Drawing.Size(129, 36);
            this.btSetMeterReader.TabIndex = 3;
            this.btSetMeterReader.Text = "设置";
            this.btSetMeterReader.UseVisualStyleBackColor = true;
            this.btSetMeterReader.Click += new System.EventHandler(this.btSetMeterReader_Click);
            // 
            // bgWork
            // 
            this.bgWork.WorkerSupportsCancellation = true;
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            // 
            // frmMeterReadingMachineManage_ZhenZhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMeterReadingMachineManage_ZhenZhong";
            this.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "抄表机设置（振中）";
            this.Load += new System.EventHandler(this.frmMeterReadingMachineManage_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMeterReadingMachineManage_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSetDateTime;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripPort;
        private System.Windows.Forms.ToolStripButton toolStripRefresh;
        private System.Windows.Forms.ToolStripButton toolStripConnect;
        private System.Windows.Forms.ToolStripButton toolStripClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btSetMeterReader;
        private System.Windows.Forms.ListBox lstMeterReader;
        private System.Windows.Forms.TextBox txtNameS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListBox lstMachineFileList;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btDownFile;
        private System.Windows.Forms.TextBox txtOpenFileName;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.Label labState;
    }
}
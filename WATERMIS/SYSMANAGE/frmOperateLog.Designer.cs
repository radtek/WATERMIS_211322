namespace SYSMANAGE
{
    partial class frmOperateLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperateLog));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labUserCount = new System.Windows.Forms.Label();
            this.ucPageSetUp1 = new BASEFUNCTION.ucPageSetUp();
            this.dgLog = new System.Windows.Forms.DataGridView();
            this.LOGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.METERREADINGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReadingNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPERATORNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGCONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPERATORID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmbWaterUserMeterReadingNO = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWorkName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.chkCancelDateTime = new System.Windows.Forms.CheckBox();
            this.cmbLogTypeS = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Tag = "9999";
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::SYSMANAGE.Properties.Resources.onebit_02;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(55, 22);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::SYSMANAGE.Properties.Resources.close;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(83, 22);
            this.toolDelete.Text = "日志清除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 637);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labUserCount);
            this.panel1.Controls.Add(this.ucPageSetUp1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 588);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 46);
            this.panel1.TabIndex = 906;
            // 
            // labUserCount
            // 
            this.labUserCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labUserCount.AutoSize = true;
            this.labUserCount.BackColor = System.Drawing.Color.Transparent;
            this.labUserCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labUserCount.Location = new System.Drawing.Point(243, 23);
            this.labUserCount.Name = "labUserCount";
            this.labUserCount.Size = new System.Drawing.Size(0, 12);
            this.labUserCount.TabIndex = 61;
            // 
            // ucPageSetUp1
            // 
            this.ucPageSetUp1.BackColor = System.Drawing.Color.Transparent;
            this.ucPageSetUp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucPageSetUp1.Location = new System.Drawing.Point(5, 5);
            this.ucPageSetUp1.Name = "ucPageSetUp1";
            this.ucPageSetUp1.Size = new System.Drawing.Size(315, 40);
            this.ucPageSetUp1.TabIndex = 901;
            // 
            // dgLog
            // 
            this.dgLog.AllowUserToAddRows = false;
            this.dgLog.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LOGID,
            this.METERREADINGID,
            this.meterReadingNO,
            this.LOGTYPE,
            this.OPERATORNAME,
            this.LOGDATETIME,
            this.LOGCONTENT,
            this.OPERATORID});
            this.dgLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgLog.Location = new System.Drawing.Point(3, 101);
            this.dgLog.MultiSelect = false;
            this.dgLog.Name = "dgLog";
            this.dgLog.ReadOnly = true;
            this.dgLog.RowHeadersWidth = 35;
            this.dgLog.RowTemplate.Height = 23;
            this.dgLog.Size = new System.Drawing.Size(1002, 481);
            this.dgLog.TabIndex = 905;
            this.dgLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgLog_CellFormatting);
            this.dgLog.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgWaterUser_CellPainting);
            // 
            // LOGID
            // 
            this.LOGID.DataPropertyName = "LOGID";
            this.LOGID.HeaderText = "LOGID";
            this.LOGID.Name = "LOGID";
            this.LOGID.ReadOnly = true;
            this.LOGID.Visible = false;
            this.LOGID.Width = 73;
            // 
            // METERREADINGID
            // 
            this.METERREADINGID.DataPropertyName = "METERREADINGID";
            this.METERREADINGID.HeaderText = "METERREADINGID";
            this.METERREADINGID.Name = "METERREADINGID";
            this.METERREADINGID.ReadOnly = true;
            this.METERREADINGID.Visible = false;
            this.METERREADINGID.Width = 145;
            // 
            // meterReadingNO
            // 
            this.meterReadingNO.DataPropertyName = "meterReadingNO";
            this.meterReadingNO.HeaderText = "抄表本号";
            this.meterReadingNO.Name = "meterReadingNO";
            this.meterReadingNO.ReadOnly = true;
            this.meterReadingNO.Visible = false;
            this.meterReadingNO.Width = 97;
            // 
            // LOGTYPE
            // 
            this.LOGTYPE.DataPropertyName = "LOGTYPE";
            this.LOGTYPE.HeaderText = "日志类型";
            this.LOGTYPE.Name = "LOGTYPE";
            this.LOGTYPE.ReadOnly = true;
            this.LOGTYPE.Width = 97;
            // 
            // OPERATORNAME
            // 
            this.OPERATORNAME.DataPropertyName = "OPERATORNAME";
            this.OPERATORNAME.HeaderText = "操作员";
            this.OPERATORNAME.Name = "OPERATORNAME";
            this.OPERATORNAME.ReadOnly = true;
            this.OPERATORNAME.Width = 81;
            // 
            // LOGDATETIME
            // 
            this.LOGDATETIME.DataPropertyName = "LOGDATETIME";
            this.LOGDATETIME.HeaderText = "日志时间";
            this.LOGDATETIME.Name = "LOGDATETIME";
            this.LOGDATETIME.ReadOnly = true;
            this.LOGDATETIME.Width = 97;
            // 
            // LOGCONTENT
            // 
            this.LOGCONTENT.DataPropertyName = "LOGCONTENT";
            this.LOGCONTENT.HeaderText = "日志内容";
            this.LOGCONTENT.Name = "LOGCONTENT";
            this.LOGCONTENT.ReadOnly = true;
            this.LOGCONTENT.Width = 97;
            // 
            // OPERATORID
            // 
            this.OPERATORID.DataPropertyName = "OPERATORID";
            this.OPERATORID.HeaderText = "OPERATORID";
            this.OPERATORID.Name = "OPERATORID";
            this.OPERATORID.ReadOnly = true;
            this.OPERATORID.Visible = false;
            this.OPERATORID.Width = 113;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFilter);
            this.groupBox3.Controls.Add(this.cmbWaterUserMeterReadingNO);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtContent);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbWorkName);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.dtpEnd);
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.chkCancelDateTime);
            this.groupBox3.Controls.Add(this.cmbLogTypeS);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1002, 92);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(788, 60);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 26);
            this.txtFilter.TabIndex = 139;
            this.txtFilter.Visible = false;
            // 
            // cmbWaterUserMeterReadingNO
            // 
            this.cmbWaterUserMeterReadingNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserMeterReadingNO.FormattingEnabled = true;
            this.cmbWaterUserMeterReadingNO.Location = new System.Drawing.Point(314, 59);
            this.cmbWaterUserMeterReadingNO.Name = "cmbWaterUserMeterReadingNO";
            this.cmbWaterUserMeterReadingNO.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserMeterReadingNO.TabIndex = 137;
            this.cmbWaterUserMeterReadingNO.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 138;
            this.label2.Text = "抄表本号:";
            this.label2.Visible = false;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(92, 55);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(100, 26);
            this.txtContent.TabIndex = 136;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 135;
            this.label1.Text = "日志内容：";
            // 
            // cmbWorkName
            // 
            this.cmbWorkName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkName.FormattingEnabled = true;
            this.cmbWorkName.Items.AddRange(new object[] {
            "全部",
            "否",
            "是"});
            this.cmbWorkName.Location = new System.Drawing.Point(788, 25);
            this.cmbWorkName.Name = "cmbWorkName";
            this.cmbWorkName.Size = new System.Drawing.Size(100, 24);
            this.cmbWorkName.TabIndex = 133;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(727, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 134;
            this.label13.Text = "操作员：";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(528, 25);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(190, 26);
            this.dtpEnd.TabIndex = 131;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(314, 25);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(190, 26);
            this.dtpStart.TabIndex = 130;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 132;
            this.label8.Text = "至";
            // 
            // chkCancelDateTime
            // 
            this.chkCancelDateTime.AutoSize = true;
            this.chkCancelDateTime.Checked = true;
            this.chkCancelDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCancelDateTime.Location = new System.Drawing.Point(221, 29);
            this.chkCancelDateTime.Name = "chkCancelDateTime";
            this.chkCancelDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkCancelDateTime.TabIndex = 129;
            this.chkCancelDateTime.Text = "日志时间:";
            this.chkCancelDateTime.UseVisualStyleBackColor = true;
            // 
            // cmbLogTypeS
            // 
            this.cmbLogTypeS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogTypeS.FormattingEnabled = true;
            this.cmbLogTypeS.Items.AddRange(new object[] {
            "全部",
            "用水用户日志",
            "用户水表日志",
            "抄表机日志",
            "清除日志",
            "登陆日志",
            "台账日志"});
            this.cmbLogTypeS.Location = new System.Drawing.Point(92, 25);
            this.cmbLogTypeS.Name = "cmbLogTypeS";
            this.cmbLogTypeS.Size = new System.Drawing.Size(116, 24);
            this.cmbLogTypeS.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 12;
            this.label12.Text = "日志类型：";
            // 
            // frmOperateLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOperateLog";
            this.Text = "操作日志";
            this.Load += new System.EventHandler(this.frmOperateLog_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbLogTypeS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkCancelDateTime;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbWorkName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgLog;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWaterUserMeterReadingNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labUserCount;
        private BASEFUNCTION.ucPageSetUp ucPageSetUp1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn METERREADINGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReadingNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPERATORNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGCONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPERATORID;
    }
}
namespace WATERFEEMANAGE
{
    partial class frmChargeEveryDayAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeEveryDayAll));
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolDayCheck = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmbChargerWorkName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtWorkerNameSearch = new System.Windows.Forms.TextBox();
            this.dtpEndSearch = new System.Windows.Forms.DateTimePicker();
            this.dtpStartSearch = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labYCCharge = new System.Windows.Forms.Label();
            this.labYCBCSZ = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labYSBCSS = new System.Windows.Forms.Label();
            this.labWaterFeeCharge = new System.Windows.Forms.Label();
            this.labBCSS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStripWaterUser.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStripWaterUser.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripWaterUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWaterUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolStripSeparator6,
            this.toolPrint,
            this.toolPrintPreview,
            this.toolDayCheck});
            this.toolStripWaterUser.Location = new System.Drawing.Point(0, 0);
            this.toolStripWaterUser.Name = "toolStripWaterUser";
            this.toolStripWaterUser.Size = new System.Drawing.Size(633, 25);
            this.toolStripWaterUser.TabIndex = 58;
            this.toolStripWaterUser.Tag = "9999";
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::WATERFEEMANAGE.Properties.Resources.search;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(57, 22);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AutoSize = false;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(10, 25);
            // 
            // toolPrint
            // 
            this.toolPrint.Image = global::WATERFEEMANAGE.Properties.Resources.打印;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(57, 22);
            this.toolPrint.Text = "打印";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolPrintPreview
            // 
            this.toolPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolPrintPreview.Image")));
            this.toolPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintPreview.Name = "toolPrintPreview";
            this.toolPrintPreview.Size = new System.Drawing.Size(87, 22);
            this.toolPrintPreview.Text = "打印预览";
            this.toolPrintPreview.Click += new System.EventHandler(this.toolPrintPreview_Click);
            // 
            // toolDayCheck
            // 
            this.toolDayCheck.Image = global::WATERFEEMANAGE.Properties.Resources.onebit_34;
            this.toolDayCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDayCheck.Name = "toolDayCheck";
            this.toolDayCheck.Size = new System.Drawing.Size(57, 22);
            this.toolDayCheck.Text = "审核";
            this.toolDayCheck.Click += new System.EventHandler(this.toolDayCheck_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 361);
            this.tableLayoutPanel1.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.cmbChargerWorkName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkChargeDateTime);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(220, 22);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 26);
            this.txtFilter.TabIndex = 131;
            this.txtFilter.Visible = false;
            // 
            // cmbChargerWorkName
            // 
            this.cmbChargerWorkName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargerWorkName.FormattingEnabled = true;
            this.cmbChargerWorkName.Location = new System.Drawing.Point(108, 24);
            this.cmbChargerWorkName.Name = "cmbChargerWorkName";
            this.cmbChargerWorkName.Size = new System.Drawing.Size(88, 24);
            this.cmbChargerWorkName.TabIndex = 129;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 130;
            this.label7.Text = "收 费 员:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(321, 55);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(190, 26);
            this.dtpEnd.TabIndex = 127;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(107, 55);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(190, 26);
            this.dtpStart.TabIndex = 126;
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Checked = true;
            this.chkChargeDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChargeDateTime.Enabled = false;
            this.chkChargeDateTime.Location = new System.Drawing.Point(14, 58);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkChargeDateTime.TabIndex = 125;
            this.chkChargeDateTime.Text = "收费时间:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(296, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 128;
            this.label8.Text = "至";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtWorkerNameSearch);
            this.groupBox2.Controls.Add(this.dtpEndSearch);
            this.groupBox2.Controls.Add(this.dtpStartSearch);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.labBCSS);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 258);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "收款结算单";
            // 
            // txtWorkerNameSearch
            // 
            this.txtWorkerNameSearch.Location = new System.Drawing.Point(341, 220);
            this.txtWorkerNameSearch.Name = "txtWorkerNameSearch";
            this.txtWorkerNameSearch.Size = new System.Drawing.Size(100, 26);
            this.txtWorkerNameSearch.TabIndex = 132;
            this.txtWorkerNameSearch.Visible = false;
            // 
            // dtpEndSearch
            // 
            this.dtpEndSearch.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndSearch.Location = new System.Drawing.Point(108, 223);
            this.dtpEndSearch.Name = "dtpEndSearch";
            this.dtpEndSearch.Size = new System.Drawing.Size(99, 26);
            this.dtpEndSearch.TabIndex = 128;
            this.dtpEndSearch.Visible = false;
            // 
            // dtpStartSearch
            // 
            this.dtpStartSearch.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartSearch.Location = new System.Drawing.Point(14, 223);
            this.dtpStartSearch.Name = "dtpStartSearch";
            this.dtpStartSearch.Size = new System.Drawing.Size(99, 26);
            this.dtpStartSearch.TabIndex = 127;
            this.dtpStartSearch.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labYCCharge);
            this.groupBox4.Controls.Add(this.labYCBCSZ);
            this.groupBox4.Location = new System.Drawing.Point(10, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(611, 91);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "预存收费";
            // 
            // labYCCharge
            // 
            this.labYCCharge.AutoSize = true;
            this.labYCCharge.Location = new System.Drawing.Point(25, 27);
            this.labYCCharge.Name = "labYCCharge";
            this.labYCCharge.Size = new System.Drawing.Size(32, 16);
            this.labYCCharge.TabIndex = 6;
            this.labYCCharge.Text = "0元";
            // 
            // labYCBCSZ
            // 
            this.labYCBCSZ.AutoSize = true;
            this.labYCBCSZ.ForeColor = System.Drawing.Color.Red;
            this.labYCBCSZ.Location = new System.Drawing.Point(25, 59);
            this.labYCBCSZ.Name = "labYCBCSZ";
            this.labYCBCSZ.Size = new System.Drawing.Size(32, 16);
            this.labYCBCSZ.TabIndex = 6;
            this.labYCBCSZ.Tag = "9999";
            this.labYCBCSZ.Text = "0元";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labYSBCSS);
            this.groupBox3.Controls.Add(this.labWaterFeeCharge);
            this.groupBox3.Location = new System.Drawing.Point(10, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(611, 86);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "水费收费";
            // 
            // labYSBCSS
            // 
            this.labYSBCSS.AutoSize = true;
            this.labYSBCSS.ForeColor = System.Drawing.Color.Red;
            this.labYSBCSS.Location = new System.Drawing.Point(25, 57);
            this.labYSBCSS.Name = "labYSBCSS";
            this.labYSBCSS.Size = new System.Drawing.Size(32, 16);
            this.labYSBCSS.TabIndex = 5;
            this.labYSBCSS.Tag = "9999";
            this.labYSBCSS.Text = "0元";
            // 
            // labWaterFeeCharge
            // 
            this.labWaterFeeCharge.AutoSize = true;
            this.labWaterFeeCharge.Location = new System.Drawing.Point(25, 27);
            this.labWaterFeeCharge.Name = "labWaterFeeCharge";
            this.labWaterFeeCharge.Size = new System.Drawing.Size(32, 16);
            this.labWaterFeeCharge.TabIndex = 0;
            this.labWaterFeeCharge.Text = "0元";
            // 
            // labBCSS
            // 
            this.labBCSS.AutoSize = true;
            this.labBCSS.ForeColor = System.Drawing.Color.Red;
            this.labBCSS.Location = new System.Drawing.Point(301, 231);
            this.labBCSS.Name = "labBCSS";
            this.labBCSS.Size = new System.Drawing.Size(32, 16);
            this.labBCSS.TabIndex = 7;
            this.labBCSS.Tag = "9999";
            this.labBCSS.Text = "0元";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "金额总计:";
            // 
            // frmChargeEveryDayAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 386);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChargeEveryDayAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "收款结算";
            this.Load += new System.EventHandler(this.frmChargeEveryDay_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbChargerWorkName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labBCSS;
        private System.Windows.Forms.Label labYSBCSS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labYCCharge;
        private System.Windows.Forms.Label labYCBCSZ;
        private System.Windows.Forms.ToolStripButton toolDayCheck;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.DateTimePicker dtpEndSearch;
        private System.Windows.Forms.DateTimePicker dtpStartSearch;
        private System.Windows.Forms.TextBox txtWorkerNameSearch;
        private System.Windows.Forms.Label labWaterFeeCharge;
    }
}
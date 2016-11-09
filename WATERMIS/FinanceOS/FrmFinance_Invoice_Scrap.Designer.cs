namespace FinanceOS
{
    partial class FrmFinance_Invoice_Scrap
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
            this.components = new System.ComponentModel.Container();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Keys = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEndNO = new System.Windows.Forms.TextBox();
            this.txtStartNO = new System.Windows.Forms.TextBox();
            this.CB_ID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.chkInvoiceRange = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btSetMonth = new System.Windows.Forms.Button();
            this.chkDateTime = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.今天ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.本月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.本年ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上年ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(1022, 469);
            this.tb1.TabIndex = 66;
            this.tb1.Tag = "9999";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TB_Keys);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEndNO);
            this.groupBox1.Controls.Add(this.txtStartNO);
            this.groupBox1.Controls.Add(this.CB_ID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Btn_Search);
            this.groupBox1.Controls.Add(this.chkInvoiceRange);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.btSetMonth);
            this.groupBox1.Controls.Add(this.chkDateTime);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 77);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "全部",
            "普通发票",
            "专用发票"});
            this.cmbType.Location = new System.Drawing.Point(287, 49);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 20);
            this.cmbType.TabIndex = 186;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 185;
            this.label5.Text = "发票类型:";
            // 
            // TB_Keys
            // 
            this.TB_Keys.Location = new System.Drawing.Point(617, 47);
            this.TB_Keys.Name = "TB_Keys";
            this.TB_Keys.Size = new System.Drawing.Size(173, 21);
            this.TB_Keys.TabIndex = 2;
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "全部",
            "正常",
            "作废"});
            this.cmbState.Location = new System.Drawing.Point(74, 49);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(121, 20);
            this.cmbState.TabIndex = 184;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 183;
            this.label3.Text = "发票状态:";
            // 
            // txtEndNO
            // 
            this.txtEndNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndNO.Location = new System.Drawing.Point(714, 19);
            this.txtEndNO.Name = "txtEndNO";
            this.txtEndNO.Size = new System.Drawing.Size(76, 21);
            this.txtEndNO.TabIndex = 181;
            // 
            // txtStartNO
            // 
            this.txtStartNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartNO.Location = new System.Drawing.Point(617, 19);
            this.txtStartNO.Name = "txtStartNO";
            this.txtStartNO.Size = new System.Drawing.Size(76, 21);
            this.txtStartNO.TabIndex = 179;
            // 
            // CB_ID
            // 
            this.CB_ID.FormattingEnabled = true;
            this.CB_ID.Location = new System.Drawing.Point(74, 21);
            this.CB_ID.Name = "CB_ID";
            this.CB_ID.Size = new System.Drawing.Size(121, 20);
            this.CB_ID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(696, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 180;
            this.label4.Text = "至";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(815, 44);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(55, 25);
            this.Btn_Search.TabIndex = 0;
            this.Btn_Search.Text = "搜 索";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // chkInvoiceRange
            // 
            this.chkInvoiceRange.AutoSize = true;
            this.chkInvoiceRange.Location = new System.Drawing.Point(544, 22);
            this.chkInvoiceRange.Name = "chkInvoiceRange";
            this.chkInvoiceRange.Size = new System.Drawing.Size(78, 16);
            this.chkInvoiceRange.TabIndex = 182;
            this.chkInvoiceRange.Text = "发票号码:";
            this.chkInvoiceRange.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "业务类型:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(400, 20);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(88, 21);
            this.dtpEnd.TabIndex = 176;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户信息:";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(287, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(88, 21);
            this.dtpStart.TabIndex = 175;
            // 
            // btSetMonth
            // 
            this.btSetMonth.BackgroundImage = global::FinanceOS.Properties.Resources.onebit_20;
            this.btSetMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetMonth.Location = new System.Drawing.Point(494, 19);
            this.btSetMonth.Name = "btSetMonth";
            this.btSetMonth.Size = new System.Drawing.Size(21, 22);
            this.btSetMonth.TabIndex = 178;
            this.btSetMonth.UseVisualStyleBackColor = true;
            this.btSetMonth.Click += new System.EventHandler(this.btSetMonth_Click);
            // 
            // chkDateTime
            // 
            this.chkDateTime.AutoSize = true;
            this.chkDateTime.Checked = true;
            this.chkDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateTime.Location = new System.Drawing.Point(214, 22);
            this.chkDateTime.Name = "chkDateTime";
            this.chkDateTime.Size = new System.Drawing.Size(78, 16);
            this.chkDateTime.TabIndex = 174;
            this.chkDateTime.Text = "打印时间:";
            this.chkDateTime.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 177;
            this.label8.Text = "至";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uC_DataGridView_Page1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1016, 375);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "待收费列表";
            // 
            // uC_DataGridView_Page1
            // 
            this.uC_DataGridView_Page1.AutoSize = true;
            this.uC_DataGridView_Page1.BackColor = System.Drawing.Color.White;
            this.uC_DataGridView_Page1.DataStatis = null;
            this.uC_DataGridView_Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DataGridView_Page1.Fields = null;
            this.uC_DataGridView_Page1.FieldStatis = null;
            this.uC_DataGridView_Page1.FiledColor = null;
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(3, 17);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(833, 80);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(1010, 355);
            this.uC_DataGridView_Page1.TabIndex = 0;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellDoubleClickEvents += new SysControl.UC_DataGridView_Page.CellDoubleClickEvent(this.uC_DataGridView_Page1_CellDoubleClickEvents);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.今天ToolStripMenuItem,
            this.toolStripSeparator1,
            this.本月ToolStripMenuItem,
            this.上月ToolStripMenuItem,
            this.下月ToolStripMenuItem,
            this.toolStripSeparator2,
            this.本年ToolStripMenuItem,
            this.上年ToolStripMenuItem,
            this.toolStripSeparator3,
            this.全部ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 190);
            // 
            // 今天ToolStripMenuItem
            // 
            this.今天ToolStripMenuItem.Name = "今天ToolStripMenuItem";
            this.今天ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.今天ToolStripMenuItem.Text = "今天";
            this.今天ToolStripMenuItem.Click += new System.EventHandler(this.今天ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // 本月ToolStripMenuItem
            // 
            this.本月ToolStripMenuItem.Name = "本月ToolStripMenuItem";
            this.本月ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.本月ToolStripMenuItem.Text = "本月";
            this.本月ToolStripMenuItem.Click += new System.EventHandler(this.本月ToolStripMenuItem_Click);
            // 
            // 上月ToolStripMenuItem
            // 
            this.上月ToolStripMenuItem.Name = "上月ToolStripMenuItem";
            this.上月ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.上月ToolStripMenuItem.Text = "上月";
            this.上月ToolStripMenuItem.Click += new System.EventHandler(this.上月ToolStripMenuItem_Click);
            // 
            // 下月ToolStripMenuItem
            // 
            this.下月ToolStripMenuItem.Name = "下月ToolStripMenuItem";
            this.下月ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.下月ToolStripMenuItem.Text = "下月";
            this.下月ToolStripMenuItem.Click += new System.EventHandler(this.下月ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(105, 6);
            // 
            // 本年ToolStripMenuItem
            // 
            this.本年ToolStripMenuItem.Name = "本年ToolStripMenuItem";
            this.本年ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.本年ToolStripMenuItem.Text = "本年";
            this.本年ToolStripMenuItem.Click += new System.EventHandler(this.本年ToolStripMenuItem_Click);
            // 
            // 上年ToolStripMenuItem
            // 
            this.上年ToolStripMenuItem.Name = "上年ToolStripMenuItem";
            this.上年ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.上年ToolStripMenuItem.Text = "上年";
            this.上年ToolStripMenuItem.Click += new System.EventHandler(this.上年ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(105, 6);
            // 
            // 全部ToolStripMenuItem
            // 
            this.全部ToolStripMenuItem.Name = "全部ToolStripMenuItem";
            this.全部ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.全部ToolStripMenuItem.Text = "全部";
            this.全部ToolStripMenuItem.Click += new System.EventHandler(this.全部ToolStripMenuItem_Click);
            // 
            // FrmFinance_Invoice_Scrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 469);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmFinance_Invoice_Scrap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发票作废";
            this.Load += new System.EventHandler(this.FrmFinance_Invoice_Scrap_Load);
            this.tb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Keys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.GroupBox groupBox2;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
        private System.Windows.Forms.Button btSetMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkDateTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 今天ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 本月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 本年ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上年ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 全部ToolStripMenuItem;
        private System.Windows.Forms.TextBox txtEndNO;
        private System.Windows.Forms.TextBox txtStartNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkInvoiceRange;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label5;
    }
}
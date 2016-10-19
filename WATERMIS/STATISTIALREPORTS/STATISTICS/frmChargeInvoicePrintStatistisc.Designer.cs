namespace STATISTIALREPORTS
{
    partial class frmChargeInvoicePrintStatistisc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeInvoicePrintStatistisc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            FastReport.Design.DesignerSettings designerSettings1 = new FastReport.Design.DesignerSettings();
            FastReport.Design.DesignerRestrictions designerRestrictions1 = new FastReport.Design.DesignerRestrictions();
            FastReport.Export.Email.EmailSettings emailSettings1 = new FastReport.Export.Email.EmailSettings();
            FastReport.PreviewSettings previewSettings1 = new FastReport.PreviewSettings();
            FastReport.ReportSettings reportSettings1 = new FastReport.ReportSettings();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEndCharge = new System.Windows.Forms.DateTimePicker();
            this.txtSummaryNO = new System.Windows.Forms.TextBox();
            this.cmbWaterFeeMonth = new System.Windows.Forms.ComboBox();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.dtpStartCharge = new System.Windows.Forms.DateTimePicker();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.btSenior = new System.Windows.Forms.Button();
            this.chkZSH = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWaterFeeYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbWaterUserMeterReadingNO = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.txtWaterUserNameSearch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cmbWaterUserTypeSearch = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkInvoiceDateTime = new System.Windows.Forms.CheckBox();
            this.cmbChargerWorkName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.toolStripWaterUser.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripWaterUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWaterUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolStripSeparator6,
            this.toolPrint,
            this.toolPrintPreview});
            this.toolStripWaterUser.Location = new System.Drawing.Point(0, 0);
            this.toolStripWaterUser.Name = "toolStripWaterUser";
            this.toolStripWaterUser.Size = new System.Drawing.Size(1008, 25);
            this.toolStripWaterUser.TabIndex = 57;
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::STATISTIALREPORTS.Properties.Resources.onebit_02;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(57, 22);
            this.toolSearch.Text = "统计";
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
            this.toolPrint.Enabled = false;
            this.toolPrint.Image = global::STATISTIALREPORTS.Properties.Resources.打印;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(57, 22);
            this.toolPrint.Text = "打印";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolPrintPreview
            // 
            this.toolPrintPreview.Enabled = false;
            this.toolPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolPrintPreview.Image")));
            this.toolPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintPreview.Name = "toolPrintPreview";
            this.toolPrintPreview.Size = new System.Drawing.Size(87, 22);
            this.toolPrintPreview.Text = "打印预览";
            this.toolPrintPreview.Click += new System.EventHandler(this.toolPrintPreview_Click);
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEndCharge);
            this.groupBox1.Controls.Add(this.txtSummaryNO);
            this.groupBox1.Controls.Add(this.cmbWaterFeeMonth);
            this.groupBox1.Controls.Add(this.cmbWaterMeterType);
            this.groupBox1.Controls.Add(this.dtpStartCharge);
            this.groupBox1.Controls.Add(this.txtSenior);
            this.groupBox1.Controls.Add(this.btSenior);
            this.groupBox1.Controls.Add(this.chkZSH);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkChargeDateTime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbWaterFeeYear);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbWaterUserMeterReadingNO);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.txtWaterUserNameSearch);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.txtWaterUserNOSearch);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.cmbWaterUserTypeSearch);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkInvoiceDateTime);
            this.groupBox1.Controls.Add(this.cmbChargerWorkName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 157);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // dtpEndCharge
            // 
            this.dtpEndCharge.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEndCharge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndCharge.Location = new System.Drawing.Point(243, 86);
            this.dtpEndCharge.Name = "dtpEndCharge";
            this.dtpEndCharge.Size = new System.Drawing.Size(105, 26);
            this.dtpEndCharge.TabIndex = 168;
            // 
            // txtSummaryNO
            // 
            this.txtSummaryNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtSummaryNO.Location = new System.Drawing.Point(652, 52);
            this.txtSummaryNO.Name = "txtSummaryNO";
            this.txtSummaryNO.Size = new System.Drawing.Size(88, 26);
            this.txtSummaryNO.TabIndex = 172;
            // 
            // cmbWaterFeeMonth
            // 
            this.cmbWaterFeeMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterFeeMonth.FormattingEnabled = true;
            this.cmbWaterFeeMonth.Items.AddRange(new object[] {
            "",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbWaterFeeMonth.Location = new System.Drawing.Point(652, 86);
            this.cmbWaterFeeMonth.Name = "cmbWaterFeeMonth";
            this.cmbWaterFeeMonth.Size = new System.Drawing.Size(97, 24);
            this.cmbWaterFeeMonth.TabIndex = 160;
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterMeterType.DropDownWidth = 150;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Location = new System.Drawing.Point(473, 54);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterMeterType.TabIndex = 170;
            // 
            // dtpStartCharge
            // 
            this.dtpStartCharge.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStartCharge.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartCharge.Location = new System.Drawing.Point(115, 86);
            this.dtpStartCharge.Name = "dtpStartCharge";
            this.dtpStartCharge.Size = new System.Drawing.Size(105, 26);
            this.dtpStartCharge.TabIndex = 167;
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.Color.White;
            this.txtSenior.Location = new System.Drawing.Point(763, 22);
            this.txtSenior.Multiline = true;
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(173, 122);
            this.txtSenior.TabIndex = 175;
            // 
            // btSenior
            // 
            this.btSenior.Location = new System.Drawing.Point(942, 23);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(50, 45);
            this.btSenior.TabIndex = 174;
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = true;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // chkZSH
            // 
            this.chkZSH.AutoSize = true;
            this.chkZSH.Checked = true;
            this.chkZSH.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZSH.Location = new System.Drawing.Point(575, 24);
            this.chkZSH.Name = "chkZSH";
            this.chkZSH.Size = new System.Drawing.Size(107, 20);
            this.chkZSH.TabIndex = 173;
            this.chkZSH.Text = "不含增值税";
            this.chkZSH.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(396, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 171;
            this.label9.Text = "用水性质:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 169;
            this.label2.Text = "至";
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Location = new System.Drawing.Point(20, 89);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkChargeDateTime.TabIndex = 166;
            this.chkChargeDateTime.Text = "收费时间:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(575, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 161;
            this.label5.Text = "水费月份:";
            // 
            // cmbWaterFeeYear
            // 
            this.cmbWaterFeeYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterFeeYear.FormattingEnabled = true;
            this.cmbWaterFeeYear.Items.AddRange(new object[] {
            "",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmbWaterFeeYear.Location = new System.Drawing.Point(474, 86);
            this.cmbWaterFeeYear.Name = "cmbWaterFeeYear";
            this.cmbWaterFeeYear.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterFeeYear.TabIndex = 158;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 159;
            this.label6.Text = "水费年份:";
            // 
            // cmbWaterUserMeterReadingNO
            // 
            this.cmbWaterUserMeterReadingNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserMeterReadingNO.FormattingEnabled = true;
            this.cmbWaterUserMeterReadingNO.Location = new System.Drawing.Point(288, 55);
            this.cmbWaterUserMeterReadingNO.Name = "cmbWaterUserMeterReadingNO";
            this.cmbWaterUserMeterReadingNO.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserMeterReadingNO.TabIndex = 156;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(210, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 16);
            this.label10.TabIndex = 157;
            this.label10.Text = "抄表本号:";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.DropDownWidth = 150;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(97, 55);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(88, 24);
            this.cmbArea.TabIndex = 154;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(20, 59);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(80, 16);
            this.label54.TabIndex = 155;
            this.label54.Text = "所属区域:";
            // 
            // txtWaterUserNameSearch
            // 
            this.txtWaterUserNameSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNameSearch.Location = new System.Drawing.Point(288, 22);
            this.txtWaterUserNameSearch.Name = "txtWaterUserNameSearch";
            this.txtWaterUserNameSearch.Size = new System.Drawing.Size(88, 26);
            this.txtWaterUserNameSearch.TabIndex = 153;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(211, 27);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(80, 16);
            this.label41.TabIndex = 152;
            this.label41.Text = "用户名称:";
            // 
            // txtWaterUserNOSearch
            // 
            this.txtWaterUserNOSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNOSearch.Location = new System.Drawing.Point(96, 22);
            this.txtWaterUserNOSearch.Name = "txtWaterUserNOSearch";
            this.txtWaterUserNOSearch.Size = new System.Drawing.Size(88, 26);
            this.txtWaterUserNOSearch.TabIndex = 141;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(20, 27);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(80, 16);
            this.label40.TabIndex = 151;
            this.label40.Text = "用户编号:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(575, 58);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(80, 16);
            this.label38.TabIndex = 148;
            this.label38.Text = "所属总表:";
            // 
            // cmbWaterUserTypeSearch
            // 
            this.cmbWaterUserTypeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserTypeSearch.DropDownWidth = 150;
            this.cmbWaterUserTypeSearch.FormattingEnabled = true;
            this.cmbWaterUserTypeSearch.Location = new System.Drawing.Point(474, 23);
            this.cmbWaterUserTypeSearch.Name = "cmbWaterUserTypeSearch";
            this.cmbWaterUserTypeSearch.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserTypeSearch.TabIndex = 144;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(396, 27);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 16);
            this.label36.TabIndex = 145;
            this.label36.Text = "用户类别:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(400, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 124;
            this.label8.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(425, 119);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 123;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(289, 119);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 122;
            // 
            // chkInvoiceDateTime
            // 
            this.chkInvoiceDateTime.AutoSize = true;
            this.chkInvoiceDateTime.Checked = true;
            this.chkInvoiceDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInvoiceDateTime.Location = new System.Drawing.Point(196, 122);
            this.chkInvoiceDateTime.Name = "chkInvoiceDateTime";
            this.chkInvoiceDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkInvoiceDateTime.TabIndex = 121;
            this.chkInvoiceDateTime.Text = "发票时间:";
            this.chkInvoiceDateTime.UseVisualStyleBackColor = true;
            // 
            // cmbChargerWorkName
            // 
            this.cmbChargerWorkName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargerWorkName.FormattingEnabled = true;
            this.cmbChargerWorkName.Location = new System.Drawing.Point(94, 120);
            this.cmbChargerWorkName.Name = "cmbChargerWorkName";
            this.cmbChargerWorkName.Size = new System.Drawing.Size(88, 24);
            this.cmbChargerWorkName.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 120;
            this.label7.Text = "收 费 员:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 364);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "历史收费明细列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 25;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(996, 339);
            this.dgList.TabIndex = 3;
            // 
            // environmentSettings1
            // 
            designerSettings1.ApplicationConnection = null;
            designerSettings1.DefaultFont = new System.Drawing.Font("宋体", 9F);
            designerSettings1.Icon = ((System.Drawing.Icon)(resources.GetObject("designerSettings1.Icon")));
            designerSettings1.Restrictions = designerRestrictions1;
            designerSettings1.Text = "";
            this.environmentSettings1.DesignerSettings = designerSettings1;
            emailSettings1.Address = "";
            emailSettings1.Host = "";
            emailSettings1.MessageTemplate = "";
            emailSettings1.Name = "";
            emailSettings1.Password = "";
            emailSettings1.UserName = "";
            this.environmentSettings1.EmailSettings = emailSettings1;
            previewSettings1.Buttons = ((FastReport.PreviewButtons)((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Zoom)
                        | FastReport.PreviewButtons.PageSetup)
                        | FastReport.PreviewButtons.Close)));
            previewSettings1.Icon = ((System.Drawing.Icon)(resources.GetObject("previewSettings1.Icon")));
            previewSettings1.Text = "";
            this.environmentSettings1.PreviewSettings = previewSettings1;
            this.environmentSettings1.ReportSettings = reportSettings1;
            this.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // frmChargeInvoicePrintStatistisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChargeInvoicePrintStatistisc";
            this.Text = "收费发票统计";
            this.Load += new System.EventHandler(this.frmWaterUserSearch_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.ComboBox cmbChargerWorkName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkInvoiceDateTime;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.DateTimePicker dtpStartCharge;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.CheckBox chkZSH;
        private System.Windows.Forms.TextBox txtSummaryNO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndCharge;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.ComboBox cmbWaterFeeMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbWaterFeeYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbWaterUserMeterReadingNO;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox txtWaterUserNameSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cmbWaterUserTypeSearch;
        private System.Windows.Forms.Label label36;
    }
}
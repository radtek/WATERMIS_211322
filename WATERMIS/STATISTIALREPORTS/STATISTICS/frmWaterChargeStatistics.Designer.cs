namespace STATISTIALREPORTS
{
    partial class frmWaterChargeStatistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterChargeStatistics));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.cmbChargeType = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.btSenior = new System.Windows.Forms.Button();
            this.chkZSH = new System.Windows.Forms.CheckBox();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.cmbChargerWorkName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbWaterFeeMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWaterFeeYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbWaterUserMeterReadingNO = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.txtWaterUserNameSearch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.cmbWaterUserAgentBankSearch = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cmbMFYH = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cmbWaterUserTypeSearch = new System.Windows.Forms.ComboBox();
            this.cmbWaterUserIsAgentSearch = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbChargeType);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.txtSenior);
            this.groupBox1.Controls.Add(this.btSenior);
            this.groupBox1.Controls.Add(this.chkZSH);
            this.groupBox1.Controls.Add(this.cmbWaterMeterType);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkChargeDateTime);
            this.groupBox1.Controls.Add(this.cmbChargerWorkName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbWaterFeeMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbWaterFeeYear);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbWaterUserMeterReadingNO);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.txtWaterUserNameSearch);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.txtWaterUserNOSearch);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.cmbWaterUserAgentBankSearch);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.cmbMFYH);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.cmbWaterUserTypeSearch);
            this.groupBox1.Controls.Add(this.cmbWaterUserIsAgentSearch);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 149);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cmbChargeType
            // 
            this.cmbChargeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargeType.FormattingEnabled = true;
            this.cmbChargeType.Location = new System.Drawing.Point(292, 85);
            this.cmbChargeType.Name = "cmbChargeType";
            this.cmbChargeType.Size = new System.Drawing.Size(88, 24);
            this.cmbChargeType.TabIndex = 141;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(215, 89);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(80, 16);
            this.label38.TabIndex = 142;
            this.label38.Text = "收款方式:";
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.Color.White;
            this.txtSenior.Location = new System.Drawing.Point(767, 58);
            this.txtSenior.Multiline = true;
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(173, 85);
            this.txtSenior.TabIndex = 140;
            // 
            // btSenior
            // 
            this.btSenior.Location = new System.Drawing.Point(946, 58);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(50, 45);
            this.btSenior.TabIndex = 139;
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = true;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // chkZSH
            // 
            this.chkZSH.AutoSize = true;
            this.chkZSH.Checked = true;
            this.chkZSH.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZSH.Location = new System.Drawing.Point(591, 23);
            this.chkZSH.Name = "chkZSH";
            this.chkZSH.Size = new System.Drawing.Size(107, 20);
            this.chkZSH.TabIndex = 138;
            this.chkZSH.Text = "不含增值税";
            this.chkZSH.UseVisualStyleBackColor = true;
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterMeterType.DropDownWidth = 150;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Location = new System.Drawing.Point(101, 85);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterMeterType.TabIndex = 135;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 136;
            this.label9.Text = "用水性质:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 132;
            this.label8.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(422, 116);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 131;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(292, 116);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 130;
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Checked = true;
            this.chkChargeDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChargeDateTime.Location = new System.Drawing.Point(200, 119);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkChargeDateTime.TabIndex = 129;
            this.chkChargeDateTime.Text = "收费时间:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // cmbChargerWorkName
            // 
            this.cmbChargerWorkName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargerWorkName.FormattingEnabled = true;
            this.cmbChargerWorkName.Location = new System.Drawing.Point(101, 117);
            this.cmbChargerWorkName.Name = "cmbChargerWorkName";
            this.cmbChargerWorkName.Size = new System.Drawing.Size(88, 24);
            this.cmbChargerWorkName.TabIndex = 127;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 128;
            this.label7.Text = "收 费 员:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "收费员",
            "收费方式",
            "用户类型",
            "抄表本",
            "区域",
            "抄表员",
            "银行托收",
            "托收银行",
            "用水性质",
            "用户名"});
            this.cmbType.Location = new System.Drawing.Point(655, 117);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(97, 24);
            this.cmbType.TabIndex = 120;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 119;
            this.label4.Text = "统计方式:";
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
            this.cmbWaterFeeMonth.Location = new System.Drawing.Point(655, 85);
            this.cmbWaterFeeMonth.Name = "cmbWaterFeeMonth";
            this.cmbWaterFeeMonth.Size = new System.Drawing.Size(97, 24);
            this.cmbWaterFeeMonth.TabIndex = 117;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(579, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 118;
            this.label3.Text = "水费月份:";
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
            this.cmbWaterFeeYear.Location = new System.Drawing.Point(478, 85);
            this.cmbWaterFeeYear.Name = "cmbWaterFeeYear";
            this.cmbWaterFeeYear.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterFeeYear.TabIndex = 115;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 116;
            this.label6.Text = "水费年份:";
            // 
            // cmbWaterUserMeterReadingNO
            // 
            this.cmbWaterUserMeterReadingNO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserMeterReadingNO.FormattingEnabled = true;
            this.cmbWaterUserMeterReadingNO.Location = new System.Drawing.Point(292, 54);
            this.cmbWaterUserMeterReadingNO.Name = "cmbWaterUserMeterReadingNO";
            this.cmbWaterUserMeterReadingNO.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserMeterReadingNO.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 97;
            this.label2.Text = "抄表本号:";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.DropDownWidth = 150;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(101, 54);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(88, 24);
            this.cmbArea.TabIndex = 92;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(24, 58);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(80, 16);
            this.label54.TabIndex = 93;
            this.label54.Text = "所属区域:";
            // 
            // txtWaterUserNameSearch
            // 
            this.txtWaterUserNameSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNameSearch.Location = new System.Drawing.Point(292, 21);
            this.txtWaterUserNameSearch.Name = "txtWaterUserNameSearch";
            this.txtWaterUserNameSearch.Size = new System.Drawing.Size(88, 26);
            this.txtWaterUserNameSearch.TabIndex = 66;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(215, 26);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(80, 16);
            this.label41.TabIndex = 65;
            this.label41.Text = "用户名称:";
            // 
            // txtWaterUserNOSearch
            // 
            this.txtWaterUserNOSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNOSearch.Location = new System.Drawing.Point(100, 21);
            this.txtWaterUserNOSearch.Name = "txtWaterUserNOSearch";
            this.txtWaterUserNOSearch.Size = new System.Drawing.Size(88, 26);
            this.txtWaterUserNOSearch.TabIndex = 1;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(24, 26);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(80, 16);
            this.label40.TabIndex = 63;
            this.label40.Text = "用户编号:";
            // 
            // cmbWaterUserAgentBankSearch
            // 
            this.cmbWaterUserAgentBankSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserAgentBankSearch.DropDownWidth = 150;
            this.cmbWaterUserAgentBankSearch.FormattingEnabled = true;
            this.cmbWaterUserAgentBankSearch.Location = new System.Drawing.Point(655, 54);
            this.cmbWaterUserAgentBankSearch.Name = "cmbWaterUserAgentBankSearch";
            this.cmbWaterUserAgentBankSearch.Size = new System.Drawing.Size(97, 24);
            this.cmbWaterUserAgentBankSearch.TabIndex = 62;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(579, 58);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(80, 16);
            this.label39.TabIndex = 60;
            this.label39.Text = "托收银行:";
            // 
            // cmbMFYH
            // 
            this.cmbMFYH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMFYH.FormattingEnabled = true;
            this.cmbMFYH.Items.AddRange(new object[] {
            "全部",
            "免费用户",
            "非免费用户"});
            this.cmbMFYH.Location = new System.Drawing.Point(841, 22);
            this.cmbMFYH.Name = "cmbMFYH";
            this.cmbMFYH.Size = new System.Drawing.Size(88, 24);
            this.cmbMFYH.TabIndex = 57;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(764, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 16);
            this.label37.TabIndex = 56;
            this.label37.Text = "是否免费:";
            // 
            // cmbWaterUserTypeSearch
            // 
            this.cmbWaterUserTypeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserTypeSearch.DropDownWidth = 150;
            this.cmbWaterUserTypeSearch.FormattingEnabled = true;
            this.cmbWaterUserTypeSearch.Location = new System.Drawing.Point(478, 22);
            this.cmbWaterUserTypeSearch.Name = "cmbWaterUserTypeSearch";
            this.cmbWaterUserTypeSearch.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserTypeSearch.TabIndex = 46;
            // 
            // cmbWaterUserIsAgentSearch
            // 
            this.cmbWaterUserIsAgentSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserIsAgentSearch.FormattingEnabled = true;
            this.cmbWaterUserIsAgentSearch.Items.AddRange(new object[] {
            "",
            "托收",
            "不托收"});
            this.cmbWaterUserIsAgentSearch.Location = new System.Drawing.Point(479, 54);
            this.cmbWaterUserIsAgentSearch.Name = "cmbWaterUserIsAgentSearch";
            this.cmbWaterUserIsAgentSearch.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserIsAgentSearch.TabIndex = 45;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(402, 58);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 16);
            this.label35.TabIndex = 44;
            this.label35.Text = "银行托收:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(400, 26);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 16);
            this.label36.TabIndex = 47;
            this.label36.Text = "用户类别:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 372);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "应收明细列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.dgList.Size = new System.Drawing.Size(996, 347);
            this.dgList.TabIndex = 5;
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
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
            // frmWaterChargeStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterChargeStatistics";
            this.Text = "营销收费统计";
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
        private System.Windows.Forms.TextBox txtWaterUserNameSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cmbWaterUserAgentBankSearch;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cmbMFYH;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox cmbWaterUserTypeSearch;
        private System.Windows.Forms.ComboBox cmbWaterUserIsAgentSearch;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ComboBox cmbWaterUserMeterReadingNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.ComboBox cmbWaterFeeMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbWaterFeeYear;
        private System.Windows.Forms.Label label6;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.ComboBox cmbChargerWorkName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkZSH;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.ComboBox cmbChargeType;
        private System.Windows.Forms.Label label38;
    }
}
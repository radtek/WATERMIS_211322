namespace WATERFEEMANAGE
{
    partial class frmInformRePrintAndCancel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformRePrintAndCancel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.trMeterReading = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tb2 = new System.Windows.Forms.TableLayoutPanel();
            this.grbSearch = new System.Windows.Forms.GroupBox();
            this.cmbJSZT = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.cmbChargerWorkName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rbInformNO = new System.Windows.Forms.RadioButton();
            this.cmbWaterFeeMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWaterFeeYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.rbWaterUserName = new System.Windows.Forms.RadioButton();
            this.rbWaterUserNO = new System.Windows.Forms.RadioButton();
            this.rbWaterMeterReading = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
            this.txtWaterUserNameSearch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.cmbWaterUserTypeSearch = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.waterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readMeterRecordYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readMeterRecordMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INFORMNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INFORMPRINTDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERUSERQQYE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalChargeend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERUSERJSYE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINTWORKERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterLastNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterEndNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReadingNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReadingPageNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readMeterRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labSum = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btReceiptPrint = new System.Windows.Forms.Button();
            this.txtStartRow = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtEndRow = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtInvoiceNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb1.SuspendLayout();
            this.tb2.SuspendLayout();
            this.grbSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 2;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 163F));
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.trMeterReading, 0, 0);
            this.tb1.Controls.Add(this.tb2, 1, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(10, 10);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 1;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1064, 596);
            this.tb1.TabIndex = 0;
            // 
            // trMeterReading
            // 
            this.trMeterReading.BackColor = System.Drawing.SystemColors.Window;
            this.trMeterReading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trMeterReading.HideSelection = false;
            this.trMeterReading.ImageIndex = 0;
            this.trMeterReading.ImageList = this.imageList1;
            this.trMeterReading.Location = new System.Drawing.Point(4, 4);
            this.trMeterReading.Margin = new System.Windows.Forms.Padding(4);
            this.trMeterReading.Name = "trMeterReading";
            this.trMeterReading.SelectedImageIndex = 1;
            this.trMeterReading.Size = new System.Drawing.Size(155, 588);
            this.trMeterReading.TabIndex = 9;
            this.trMeterReading.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trMeterReading_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "open.ico");
            // 
            // tb2
            // 
            this.tb2.ColumnCount = 1;
            this.tb2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tb2.Controls.Add(this.grbSearch, 0, 0);
            this.tb2.Controls.Add(this.groupBox2, 0, 1);
            this.tb2.Controls.Add(this.panel1, 0, 2);
            this.tb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb2.Location = new System.Drawing.Point(166, 3);
            this.tb2.Name = "tb2";
            this.tb2.RowCount = 3;
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tb2.Size = new System.Drawing.Size(895, 590);
            this.tb2.TabIndex = 10;
            // 
            // grbSearch
            // 
            this.grbSearch.Controls.Add(this.cmbJSZT);
            this.grbSearch.Controls.Add(this.label8);
            this.grbSearch.Controls.Add(this.dtpStart);
            this.grbSearch.Controls.Add(this.label4);
            this.grbSearch.Controls.Add(this.dtpEnd);
            this.grbSearch.Controls.Add(this.chkChargeDateTime);
            this.grbSearch.Controls.Add(this.cmbChargerWorkName);
            this.grbSearch.Controls.Add(this.label7);
            this.grbSearch.Controls.Add(this.rbInformNO);
            this.grbSearch.Controls.Add(this.cmbWaterFeeMonth);
            this.grbSearch.Controls.Add(this.label3);
            this.grbSearch.Controls.Add(this.cmbWaterFeeYear);
            this.grbSearch.Controls.Add(this.label6);
            this.grbSearch.Controls.Add(this.cmbWaterMeterType);
            this.grbSearch.Controls.Add(this.label56);
            this.grbSearch.Controls.Add(this.btSearch);
            this.grbSearch.Controls.Add(this.rbWaterUserName);
            this.grbSearch.Controls.Add(this.rbWaterUserNO);
            this.grbSearch.Controls.Add(this.rbWaterMeterReading);
            this.grbSearch.Controls.Add(this.label42);
            this.grbSearch.Controls.Add(this.txtWaterUserNameSearch);
            this.grbSearch.Controls.Add(this.label41);
            this.grbSearch.Controls.Add(this.txtWaterUserNOSearch);
            this.grbSearch.Controls.Add(this.label40);
            this.grbSearch.Controls.Add(this.cmbWaterUserTypeSearch);
            this.grbSearch.Controls.Add(this.label36);
            this.grbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbSearch.Location = new System.Drawing.Point(3, 3);
            this.grbSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(889, 111);
            this.grbSearch.TabIndex = 60;
            this.grbSearch.TabStop = false;
            this.grbSearch.Text = "查询条件";
            // 
            // cmbJSZT
            // 
            this.cmbJSZT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJSZT.FormattingEnabled = true;
            this.cmbJSZT.Items.AddRange(new object[] {
            "全部",
            "欠费",
            "不欠费"});
            this.cmbJSZT.Location = new System.Drawing.Point(89, 82);
            this.cmbJSZT.Name = "cmbJSZT";
            this.cmbJSZT.Size = new System.Drawing.Size(101, 24);
            this.cmbJSZT.TabIndex = 135;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 136;
            this.label8.Text = "余额状态:";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(625, 49);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(108, 26);
            this.dtpStart.TabIndex = 132;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(737, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 134;
            this.label4.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(762, 49);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 133;
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Checked = true;
            this.chkChargeDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChargeDateTime.Location = new System.Drawing.Point(534, 53);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkChargeDateTime.TabIndex = 131;
            this.chkChargeDateTime.Text = "打印时间:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // cmbChargerWorkName
            // 
            this.cmbChargerWorkName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargerWorkName.FormattingEnabled = true;
            this.cmbChargerWorkName.Location = new System.Drawing.Point(666, 18);
            this.cmbChargerWorkName.Name = "cmbChargerWorkName";
            this.cmbChargerWorkName.Size = new System.Drawing.Size(88, 24);
            this.cmbChargerWorkName.TabIndex = 129;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(605, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 130;
            this.label7.Text = "结算员:";
            // 
            // rbInformNO
            // 
            this.rbInformNO.AutoSize = true;
            this.rbInformNO.Checked = true;
            this.rbInformNO.Location = new System.Drawing.Point(556, 85);
            this.rbInformNO.Name = "rbInformNO";
            this.rbInformNO.Size = new System.Drawing.Size(106, 20);
            this.rbInformNO.TabIndex = 123;
            this.rbInformNO.TabStop = true;
            this.rbInformNO.Text = "按通知单号";
            this.rbInformNO.UseVisualStyleBackColor = true;
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
            this.cmbWaterFeeMonth.Location = new System.Drawing.Point(462, 50);
            this.cmbWaterFeeMonth.Name = "cmbWaterFeeMonth";
            this.cmbWaterFeeMonth.Size = new System.Drawing.Size(53, 24);
            this.cmbWaterFeeMonth.TabIndex = 121;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 122;
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
            this.cmbWaterFeeYear.Location = new System.Drawing.Point(285, 50);
            this.cmbWaterFeeYear.Name = "cmbWaterFeeYear";
            this.cmbWaterFeeYear.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterFeeYear.TabIndex = 119;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 120;
            this.label6.Text = "水费年份:";
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterMeterType.DropDownWidth = 150;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Location = new System.Drawing.Point(90, 51);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(100, 24);
            this.cmbWaterMeterType.TabIndex = 111;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(12, 55);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(80, 16);
            this.label56.TabIndex = 112;
            this.label56.Text = "用水性质:";
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.LimeGreen;
            this.btSearch.Location = new System.Drawing.Point(805, 79);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(62, 29);
            this.btSearch.TabIndex = 73;
            this.btSearch.Tag = "9999";
            this.btSearch.Text = "查询";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // rbWaterUserName
            // 
            this.rbWaterUserName.AutoSize = true;
            this.rbWaterUserName.Location = new System.Drawing.Point(476, 85);
            this.rbWaterUserName.Name = "rbWaterUserName";
            this.rbWaterUserName.Size = new System.Drawing.Size(74, 20);
            this.rbWaterUserName.TabIndex = 70;
            this.rbWaterUserName.Text = "按姓名";
            this.rbWaterUserName.UseVisualStyleBackColor = true;
            this.rbWaterUserName.CheckedChanged += new System.EventHandler(this.rbWaterMeterReading_CheckedChanged);
            // 
            // rbWaterUserNO
            // 
            this.rbWaterUserNO.AutoSize = true;
            this.rbWaterUserNO.Location = new System.Drawing.Point(398, 85);
            this.rbWaterUserNO.Name = "rbWaterUserNO";
            this.rbWaterUserNO.Size = new System.Drawing.Size(74, 20);
            this.rbWaterUserNO.TabIndex = 69;
            this.rbWaterUserNO.Text = "按户号";
            this.rbWaterUserNO.UseVisualStyleBackColor = true;
            this.rbWaterUserNO.CheckedChanged += new System.EventHandler(this.rbWaterMeterReading_CheckedChanged);
            // 
            // rbWaterMeterReading
            // 
            this.rbWaterMeterReading.AutoSize = true;
            this.rbWaterMeterReading.Location = new System.Drawing.Point(288, 85);
            this.rbWaterMeterReading.Name = "rbWaterMeterReading";
            this.rbWaterMeterReading.Size = new System.Drawing.Size(106, 20);
            this.rbWaterMeterReading.TabIndex = 67;
            this.rbWaterMeterReading.Text = "按抄表本号";
            this.rbWaterMeterReading.UseVisualStyleBackColor = true;
            this.rbWaterMeterReading.CheckedChanged += new System.EventHandler(this.rbWaterMeterReading_CheckedChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(210, 87);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(80, 16);
            this.label42.TabIndex = 68;
            this.label42.Text = "排序方式:";
            this.label42.Click += new System.EventHandler(this.label42_Click);
            // 
            // txtWaterUserNameSearch
            // 
            this.txtWaterUserNameSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNameSearch.Location = new System.Drawing.Point(285, 19);
            this.txtWaterUserNameSearch.Name = "txtWaterUserNameSearch";
            this.txtWaterUserNameSearch.Size = new System.Drawing.Size(88, 26);
            this.txtWaterUserNameSearch.TabIndex = 66;
            this.txtWaterUserNameSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(210, 24);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(80, 16);
            this.label41.TabIndex = 65;
            this.label41.Text = "用户名称:";
            // 
            // txtWaterUserNOSearch
            // 
            this.txtWaterUserNOSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNOSearch.Location = new System.Drawing.Point(90, 19);
            this.txtWaterUserNOSearch.Name = "txtWaterUserNOSearch";
            this.txtWaterUserNOSearch.Size = new System.Drawing.Size(100, 26);
            this.txtWaterUserNOSearch.TabIndex = 64;
            this.txtWaterUserNOSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(8, 24);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(93, 16);
            this.label40.TabIndex = 63;
            this.label40.Text = "用户编号：";
            // 
            // cmbWaterUserTypeSearch
            // 
            this.cmbWaterUserTypeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserTypeSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbWaterUserTypeSearch.FormattingEnabled = true;
            this.cmbWaterUserTypeSearch.Location = new System.Drawing.Point(462, 20);
            this.cmbWaterUserTypeSearch.Name = "cmbWaterUserTypeSearch";
            this.cmbWaterUserTypeSearch.Size = new System.Drawing.Size(120, 22);
            this.cmbWaterUserTypeSearch.TabIndex = 46;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(387, 24);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 16);
            this.label36.TabIndex = 47;
            this.label36.Text = "用户类别:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(889, 376);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
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
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.waterUserId,
            this.waterUserNO,
            this.waterUserName,
            this.readMeterRecordYear,
            this.readMeterRecordMonth,
            this.waterMeterId,
            this.waterMeterNo,
            this.INFORMNO,
            this.INFORMPRINTDATETIME,
            this.WATERUSERQQYE,
            this.totalChargeend,
            this.WATERUSERJSYE,
            this.PRINTWORKERNAME,
            this.waterMeterLastNumber,
            this.waterMeterEndNumber,
            this.totalNumber,
            this.waterMeterTypeName,
            this.avePrice,
            this.chargeState,
            this.USERNAME,
            this.waterUserAddress,
            this.meterReadingNO,
            this.meterReadingPageNo,
            this.areaName,
            this.waterMeterPositionName,
            this.waterMeterTypeId,
            this.readMeterRecordId});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 40;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(883, 351);
            this.dgList.TabIndex = 75;
            this.dgList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_RowEnter);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgWaterUser_CellPainting);
            // 
            // waterUserId
            // 
            this.waterUserId.DataPropertyName = "waterUserId";
            this.waterUserId.Frozen = true;
            this.waterUserId.HeaderText = "waterUserId";
            this.waterUserId.Name = "waterUserId";
            this.waterUserId.ReadOnly = true;
            this.waterUserId.Visible = false;
            this.waterUserId.Width = 121;
            // 
            // waterUserNO
            // 
            this.waterUserNO.DataPropertyName = "waterUserNO";
            this.waterUserNO.Frozen = true;
            this.waterUserNO.HeaderText = "用户号";
            this.waterUserNO.Name = "waterUserNO";
            this.waterUserNO.ReadOnly = true;
            this.waterUserNO.Width = 81;
            // 
            // waterUserName
            // 
            this.waterUserName.DataPropertyName = "waterUserName";
            this.waterUserName.Frozen = true;
            this.waterUserName.HeaderText = "用户名";
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.ReadOnly = true;
            this.waterUserName.Width = 81;
            // 
            // readMeterRecordYear
            // 
            this.readMeterRecordYear.DataPropertyName = "readMeterRecordYear";
            this.readMeterRecordYear.Frozen = true;
            this.readMeterRecordYear.HeaderText = "年度";
            this.readMeterRecordYear.Name = "readMeterRecordYear";
            this.readMeterRecordYear.ReadOnly = true;
            this.readMeterRecordYear.Width = 65;
            // 
            // readMeterRecordMonth
            // 
            this.readMeterRecordMonth.DataPropertyName = "readMeterRecordMonth";
            this.readMeterRecordMonth.Frozen = true;
            this.readMeterRecordMonth.HeaderText = "月份";
            this.readMeterRecordMonth.Name = "readMeterRecordMonth";
            this.readMeterRecordMonth.ReadOnly = true;
            this.readMeterRecordMonth.Width = 65;
            // 
            // waterMeterId
            // 
            this.waterMeterId.DataPropertyName = "waterMeterId";
            this.waterMeterId.Frozen = true;
            this.waterMeterId.HeaderText = "waterMeterId";
            this.waterMeterId.Name = "waterMeterId";
            this.waterMeterId.ReadOnly = true;
            this.waterMeterId.Visible = false;
            this.waterMeterId.Width = 129;
            // 
            // waterMeterNo
            // 
            this.waterMeterNo.DataPropertyName = "waterMeterNo";
            this.waterMeterNo.Frozen = true;
            this.waterMeterNo.HeaderText = "水表编号";
            this.waterMeterNo.Name = "waterMeterNo";
            this.waterMeterNo.ReadOnly = true;
            this.waterMeterNo.Width = 97;
            // 
            // INFORMNO
            // 
            this.INFORMNO.DataPropertyName = "INFORMNO";
            this.INFORMNO.HeaderText = "通知单号";
            this.INFORMNO.Name = "INFORMNO";
            this.INFORMNO.ReadOnly = true;
            this.INFORMNO.Width = 97;
            // 
            // INFORMPRINTDATETIME
            // 
            this.INFORMPRINTDATETIME.DataPropertyName = "INFORMPRINTDATETIME";
            dataGridViewCellStyle2.Format = "f";
            dataGridViewCellStyle2.NullValue = null;
            this.INFORMPRINTDATETIME.DefaultCellStyle = dataGridViewCellStyle2;
            this.INFORMPRINTDATETIME.HeaderText = "打印时间";
            this.INFORMPRINTDATETIME.Name = "INFORMPRINTDATETIME";
            this.INFORMPRINTDATETIME.ReadOnly = true;
            this.INFORMPRINTDATETIME.Width = 97;
            // 
            // WATERUSERQQYE
            // 
            this.WATERUSERQQYE.DataPropertyName = "WATERUSERQQYE";
            this.WATERUSERQQYE.HeaderText = "前期余额";
            this.WATERUSERQQYE.Name = "WATERUSERQQYE";
            this.WATERUSERQQYE.ReadOnly = true;
            this.WATERUSERQQYE.Width = 97;
            // 
            // totalChargeend
            // 
            this.totalChargeend.DataPropertyName = "totalChargeend";
            this.totalChargeend.HeaderText = "费用合计";
            this.totalChargeend.Name = "totalChargeend";
            this.totalChargeend.ReadOnly = true;
            this.totalChargeend.Width = 97;
            // 
            // WATERUSERJSYE
            // 
            this.WATERUSERJSYE.DataPropertyName = "WATERUSERJSYE";
            this.WATERUSERJSYE.HeaderText = "结算余额";
            this.WATERUSERJSYE.Name = "WATERUSERJSYE";
            this.WATERUSERJSYE.ReadOnly = true;
            this.WATERUSERJSYE.Width = 97;
            // 
            // PRINTWORKERNAME
            // 
            this.PRINTWORKERNAME.DataPropertyName = "PRINTWORKERNAME";
            this.PRINTWORKERNAME.HeaderText = "结算员";
            this.PRINTWORKERNAME.Name = "PRINTWORKERNAME";
            this.PRINTWORKERNAME.ReadOnly = true;
            this.PRINTWORKERNAME.Width = 81;
            // 
            // waterMeterLastNumber
            // 
            this.waterMeterLastNumber.DataPropertyName = "waterMeterLastNumber";
            this.waterMeterLastNumber.HeaderText = "上期读数";
            this.waterMeterLastNumber.Name = "waterMeterLastNumber";
            this.waterMeterLastNumber.ReadOnly = true;
            this.waterMeterLastNumber.Width = 97;
            // 
            // waterMeterEndNumber
            // 
            this.waterMeterEndNumber.DataPropertyName = "waterMeterEndNumber";
            this.waterMeterEndNumber.HeaderText = "本期读数";
            this.waterMeterEndNumber.Name = "waterMeterEndNumber";
            this.waterMeterEndNumber.ReadOnly = true;
            this.waterMeterEndNumber.Width = 97;
            // 
            // totalNumber
            // 
            this.totalNumber.DataPropertyName = "totalNumber";
            this.totalNumber.HeaderText = "用水量";
            this.totalNumber.Name = "totalNumber";
            this.totalNumber.ReadOnly = true;
            this.totalNumber.Width = 81;
            // 
            // waterMeterTypeName
            // 
            this.waterMeterTypeName.DataPropertyName = "waterMeterTypeName";
            this.waterMeterTypeName.HeaderText = "用水类别";
            this.waterMeterTypeName.Name = "waterMeterTypeName";
            this.waterMeterTypeName.ReadOnly = true;
            this.waterMeterTypeName.Width = 97;
            // 
            // avePrice
            // 
            this.avePrice.DataPropertyName = "avePrice";
            this.avePrice.HeaderText = "平均单价";
            this.avePrice.Name = "avePrice";
            this.avePrice.ReadOnly = true;
            this.avePrice.Width = 97;
            // 
            // chargeState
            // 
            this.chargeState.DataPropertyName = "chargeState";
            this.chargeState.HeaderText = "收费状态";
            this.chargeState.Name = "chargeState";
            this.chargeState.ReadOnly = true;
            this.chargeState.Width = 97;
            // 
            // USERNAME
            // 
            this.USERNAME.DataPropertyName = "USERNAME";
            this.USERNAME.HeaderText = "抄表员";
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.ReadOnly = true;
            this.USERNAME.Width = 81;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.HeaderText = "地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            this.waterUserAddress.Width = 65;
            // 
            // meterReadingNO
            // 
            this.meterReadingNO.DataPropertyName = "meterReadingNO";
            this.meterReadingNO.HeaderText = "抄表本号";
            this.meterReadingNO.Name = "meterReadingNO";
            this.meterReadingNO.ReadOnly = true;
            this.meterReadingNO.Width = 97;
            // 
            // meterReadingPageNo
            // 
            this.meterReadingPageNo.DataPropertyName = "meterReadingPageNo";
            this.meterReadingPageNo.HeaderText = "页号";
            this.meterReadingPageNo.Name = "meterReadingPageNo";
            this.meterReadingPageNo.ReadOnly = true;
            this.meterReadingPageNo.Width = 65;
            // 
            // areaName
            // 
            this.areaName.DataPropertyName = "areaName";
            this.areaName.HeaderText = "区域";
            this.areaName.Name = "areaName";
            this.areaName.ReadOnly = true;
            this.areaName.Width = 65;
            // 
            // waterMeterPositionName
            // 
            this.waterMeterPositionName.DataPropertyName = "waterMeterPositionName";
            this.waterMeterPositionName.HeaderText = "水表位置";
            this.waterMeterPositionName.Name = "waterMeterPositionName";
            this.waterMeterPositionName.ReadOnly = true;
            this.waterMeterPositionName.Width = 97;
            // 
            // waterMeterTypeId
            // 
            this.waterMeterTypeId.DataPropertyName = "waterMeterTypeId";
            this.waterMeterTypeId.HeaderText = "用水类别ID";
            this.waterMeterTypeId.Name = "waterMeterTypeId";
            this.waterMeterTypeId.ReadOnly = true;
            this.waterMeterTypeId.Visible = false;
            this.waterMeterTypeId.Width = 113;
            // 
            // readMeterRecordId
            // 
            this.readMeterRecordId.DataPropertyName = "readMeterRecordId";
            this.readMeterRecordId.HeaderText = "readMeterReordId";
            this.readMeterRecordId.Name = "readMeterRecordId";
            this.readMeterRecordId.ReadOnly = true;
            this.readMeterRecordId.Visible = false;
            this.readMeterRecordId.Width = 161;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(664, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 12);
            this.label1.TabIndex = 72;
            this.label1.Text = "注:只可查询预存用户应收水费";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labSum);
            this.panel1.Controls.Add(this.txtMemo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.btReceiptPrint);
            this.panel1.Controls.Add(this.txtStartRow);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.txtEndRow);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtInvoiceNO);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 81);
            this.panel1.TabIndex = 62;
            // 
            // labSum
            // 
            this.labSum.AutoSize = true;
            this.labSum.Location = new System.Drawing.Point(16, 51);
            this.labSum.Name = "labSum";
            this.labSum.Size = new System.Drawing.Size(80, 16);
            this.labSum.TabIndex = 815;
            this.labSum.Text = "本次查询:";
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.Color.LightYellow;
            this.txtMemo.Location = new System.Drawing.Point(707, 13);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(177, 26);
            this.txtMemo.TabIndex = 813;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(628, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 814;
            this.label5.Text = "作废原因:";
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.LimeGreen;
            this.btCancel.Enabled = false;
            this.btCancel.Location = new System.Drawing.Point(522, 10);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(101, 32);
            this.btCancel.TabIndex = 812;
            this.btCancel.Tag = "9999";
            this.btCancel.Text = "通知单作废";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btReceiptPrint
            // 
            this.btReceiptPrint.BackColor = System.Drawing.Color.LimeGreen;
            this.btReceiptPrint.Enabled = false;
            this.btReceiptPrint.Location = new System.Drawing.Point(399, 10);
            this.btReceiptPrint.Name = "btReceiptPrint";
            this.btReceiptPrint.Size = new System.Drawing.Size(101, 32);
            this.btReceiptPrint.TabIndex = 811;
            this.btReceiptPrint.Tag = "9999";
            this.btReceiptPrint.Text = "通知单补打";
            this.btReceiptPrint.UseVisualStyleBackColor = false;
            this.btReceiptPrint.Click += new System.EventHandler(this.btReceiptPrint_Click);
            // 
            // txtStartRow
            // 
            this.txtStartRow.BackColor = System.Drawing.Color.LightYellow;
            this.txtStartRow.Location = new System.Drawing.Point(257, 12);
            this.txtStartRow.Name = "txtStartRow";
            this.txtStartRow.Size = new System.Drawing.Size(48, 26);
            this.txtStartRow.TabIndex = 806;
            this.txtStartRow.Text = "1";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(213, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 16);
            this.label21.TabIndex = 809;
            this.label21.Text = "行号:";
            // 
            // txtEndRow
            // 
            this.txtEndRow.BackColor = System.Drawing.Color.LightYellow;
            this.txtEndRow.Location = new System.Drawing.Point(332, 12);
            this.txtEndRow.Name = "txtEndRow";
            this.txtEndRow.Size = new System.Drawing.Size(48, 26);
            this.txtEndRow.TabIndex = 808;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(308, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 16);
            this.label20.TabIndex = 807;
            this.label20.Text = "至";
            // 
            // txtInvoiceNO
            // 
            this.txtInvoiceNO.BackColor = System.Drawing.Color.LightYellow;
            this.txtInvoiceNO.Location = new System.Drawing.Point(121, 12);
            this.txtInvoiceNO.Name = "txtInvoiceNO";
            this.txtInvoiceNO.Size = new System.Drawing.Size(86, 26);
            this.txtInvoiceNO.TabIndex = 804;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 805;
            this.label2.Text = "通知单起始号:";
            // 
            // frmInformRePrintAndCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 616);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInformRePrintAndCancel";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "水费结算通知单补打与作废";
            this.Load += new System.EventHandler(this.frmWaterUserPrestoreInitial_Load);
            this.tb1.ResumeLayout(false);
            this.tb2.ResumeLayout(false);
            this.grbSearch.ResumeLayout(false);
            this.grbSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.TreeView trMeterReading;
        private System.Windows.Forms.TableLayoutPanel tb2;
        private System.Windows.Forms.GroupBox grbSearch;
        private System.Windows.Forms.RadioButton rbWaterUserName;
        private System.Windows.Forms.RadioButton rbWaterUserNO;
        private System.Windows.Forms.RadioButton rbWaterMeterReading;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtWaterUserNameSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cmbWaterUserTypeSearch;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox cmbWaterFeeMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbWaterFeeYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtStartRow;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtEndRow;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtInvoiceNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btReceiptPrint;
        private System.Windows.Forms.RadioButton rbInformNO;
        private System.Windows.Forms.ComboBox cmbChargerWorkName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn readMeterRecordYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn readMeterRecordMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn INFORMNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INFORMPRINTDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERUSERQQYE;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalChargeend;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERUSERJSYE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINTWORKERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterLastNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterEndNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn avePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeState;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReadingNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReadingPageNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn readMeterRecordId;
        private System.Windows.Forms.Label labSum;
        private System.Windows.Forms.ComboBox cmbJSZT;
        private System.Windows.Forms.Label label8;

    }
}
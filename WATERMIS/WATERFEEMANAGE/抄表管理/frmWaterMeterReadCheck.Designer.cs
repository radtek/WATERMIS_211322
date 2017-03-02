namespace WATERFEEMANAGE
{
    partial class frmWaterMeterReadCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterReadCheck));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.trMeterReading = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.btSetMonth = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.chkTotalNumber = new System.Windows.Forms.CheckBox();
            this.cmbAreaNOS = new System.Windows.Forms.ComboBox();
            this.cmbMeterReaderS = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.cmbCommunityS = new System.Windows.Forms.ComboBox();
            this.cmbDuanNOS = new System.Windows.Forms.ComboBox();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.cmbPianNOS = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btSenior = new System.Windows.Forms.Button();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFilterSearch = new System.Windows.Forms.TextBox();
            this.labRecordCount = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgWaterList = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.waterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterLastNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterEndNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalNumberDescribe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterTotalCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargetype1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargetype2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargetype3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargetype4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargetype5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargetype6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargetype7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargetype8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraTotalCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readMeterRecordYearAndMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pianNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duanNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMUNITYNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserHouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserchargeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentsign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserPeopleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSummaryS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReadingPageNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avePriceDescribe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trapezoidPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSizeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSizeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterMagnification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterMaxRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterIsSummaryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERFIXVALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsReverse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readMeterRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAcountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.gpbWaterUserMES = new System.Windows.Forms.GroupBox();
            this.txtWaterMeterType = new System.Windows.Forms.TextBox();
            this.txtWaterUserType = new System.Windows.Forms.TextBox();
            this.txtYearAndMonth = new System.Windows.Forms.TextBox();
            this.txtWaterUserAddress = new System.Windows.Forms.TextBox();
            this.txtCharger = new System.Windows.Forms.TextBox();
            this.txtAreaNO = new System.Windows.Forms.TextBox();
            this.txtDuanNO = new System.Windows.Forms.TextBox();
            this.txtPianNO = new System.Windows.Forms.TextBox();
            this.txtWaterUserChargetype = new System.Windows.Forms.TextBox();
            this.txtCreateType = new System.Windows.Forms.TextBox();
            this.txtCommunity = new System.Windows.Forms.TextBox();
            this.txtWaterUserHouseType = new System.Windows.Forms.TextBox();
            this.txtMeterReader = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtWaterUserCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btFold = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.今天ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.本月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.本年ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上年ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            this.tb1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterList)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.gpbWaterUserMES.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trMeterReading
            // 
            this.trMeterReading.BackColor = System.Drawing.SystemColors.Window;
            this.trMeterReading.Dock = System.Windows.Forms.DockStyle.Left;
            this.trMeterReading.FullRowSelect = true;
            this.trMeterReading.HideSelection = false;
            this.trMeterReading.ImageIndex = 0;
            this.trMeterReading.ImageList = this.imageList1;
            this.trMeterReading.Indent = 19;
            this.trMeterReading.ItemHeight = 22;
            this.trMeterReading.Location = new System.Drawing.Point(0, 0);
            this.trMeterReading.Margin = new System.Windows.Forms.Padding(0);
            this.trMeterReading.Name = "trMeterReading";
            this.trMeterReading.SelectedImageIndex = 1;
            this.trMeterReading.Size = new System.Drawing.Size(140, 579);
            this.trMeterReading.TabIndex = 8;
            this.trMeterReading.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trMeterReading_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "open.ico");
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btSetMonth);
            this.groupBox3.Controls.Add(this.dtpEnd);
            this.groupBox3.Controls.Add(this.chkTotalNumber);
            this.groupBox3.Controls.Add(this.cmbAreaNOS);
            this.groupBox3.Controls.Add(this.cmbMeterReaderS);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.txtSenior);
            this.groupBox3.Controls.Add(this.btSearch);
            this.groupBox3.Controls.Add(this.cmbCommunityS);
            this.groupBox3.Controls.Add(this.cmbDuanNOS);
            this.groupBox3.Controls.Add(this.txtWaterUserNOSearch);
            this.groupBox3.Controls.Add(this.cmbWaterMeterType);
            this.groupBox3.Controls.Add(this.cmbPianNOS);
            this.groupBox3.Controls.Add(this.label49);
            this.groupBox3.Controls.Add(this.label56);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.btSenior);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(862, 115);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "9999";
            this.groupBox3.Text = "查询条件";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(667, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 157;
            this.label1.Text = "至";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(558, 46);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 23);
            this.dtpStart.TabIndex = 155;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(492, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 159;
            this.label11.Text = "水费月份:";
            // 
            // btSetMonth
            // 
            this.btSetMonth.BackgroundImage = global::WATERFEEMANAGE.Properties.Resources.onebit_20;
            this.btSetMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetMonth.Location = new System.Drawing.Point(799, 46);
            this.btSetMonth.Name = "btSetMonth";
            this.btSetMonth.Size = new System.Drawing.Size(22, 23);
            this.btSetMonth.TabIndex = 158;
            this.btSetMonth.UseVisualStyleBackColor = true;
            this.btSetMonth.Click += new System.EventHandler(this.btSetMonth_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(690, 46);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 23);
            this.dtpEnd.TabIndex = 156;
            // 
            // chkTotalNumber
            // 
            this.chkTotalNumber.AutoSize = true;
            this.chkTotalNumber.Location = new System.Drawing.Point(13, 85);
            this.chkTotalNumber.Name = "chkTotalNumber";
            this.chkTotalNumber.Size = new System.Drawing.Size(68, 18);
            this.chkTotalNumber.TabIndex = 127;
            this.chkTotalNumber.Text = "有水量";
            this.chkTotalNumber.UseVisualStyleBackColor = true;
            // 
            // cmbAreaNOS
            // 
            this.cmbAreaNOS.DropDownWidth = 120;
            this.cmbAreaNOS.FormattingEnabled = true;
            this.cmbAreaNOS.Location = new System.Drawing.Point(235, 49);
            this.cmbAreaNOS.Name = "cmbAreaNOS";
            this.cmbAreaNOS.Size = new System.Drawing.Size(78, 22);
            this.cmbAreaNOS.TabIndex = 114;
            // 
            // cmbMeterReaderS
            // 
            this.cmbMeterReaderS.FormattingEnabled = true;
            this.cmbMeterReaderS.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.cmbMeterReaderS.Location = new System.Drawing.Point(558, 18);
            this.cmbMeterReaderS.Name = "cmbMeterReaderS";
            this.cmbMeterReaderS.Size = new System.Drawing.Size(88, 22);
            this.cmbMeterReaderS.TabIndex = 126;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(492, 22);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(70, 14);
            this.label37.TabIndex = 125;
            this.label37.Text = "抄 表 员:";
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.SystemColors.Window;
            this.txtSenior.Location = new System.Drawing.Point(515, 83);
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(315, 23);
            this.txtSenior.TabIndex = 121;
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSearch.Location = new System.Drawing.Point(97, 77);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(58, 30);
            this.btSearch.TabIndex = 111;
            this.btSearch.Tag = "9999";
            this.btSearch.Text = "查询";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // cmbCommunityS
            // 
            this.cmbCommunityS.DropDownWidth = 150;
            this.cmbCommunityS.FormattingEnabled = true;
            this.cmbCommunityS.Location = new System.Drawing.Point(725, 18);
            this.cmbCommunityS.Name = "cmbCommunityS";
            this.cmbCommunityS.Size = new System.Drawing.Size(105, 22);
            this.cmbCommunityS.TabIndex = 120;
            // 
            // cmbDuanNOS
            // 
            this.cmbDuanNOS.DropDownWidth = 120;
            this.cmbDuanNOS.FormattingEnabled = true;
            this.cmbDuanNOS.Location = new System.Drawing.Point(388, 49);
            this.cmbDuanNOS.Name = "cmbDuanNOS";
            this.cmbDuanNOS.Size = new System.Drawing.Size(88, 22);
            this.cmbDuanNOS.TabIndex = 118;
            // 
            // txtWaterUserNOSearch
            // 
            this.txtWaterUserNOSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNOSearch.Location = new System.Drawing.Point(77, 19);
            this.txtWaterUserNOSearch.Name = "txtWaterUserNOSearch";
            this.txtWaterUserNOSearch.Size = new System.Drawing.Size(236, 23);
            this.txtWaterUserNOSearch.TabIndex = 83;
            this.txtWaterUserNOSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Items.AddRange(new object[] {
            "",
            "正常",
            "停水",
            "报废"});
            this.cmbWaterMeterType.Location = new System.Drawing.Point(388, 18);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(88, 22);
            this.cmbWaterMeterType.TabIndex = 91;
            // 
            // cmbPianNOS
            // 
            this.cmbPianNOS.DropDownWidth = 120;
            this.cmbPianNOS.FormattingEnabled = true;
            this.cmbPianNOS.Location = new System.Drawing.Point(77, 49);
            this.cmbPianNOS.Name = "cmbPianNOS";
            this.cmbPianNOS.Size = new System.Drawing.Size(78, 22);
            this.cmbPianNOS.TabIndex = 116;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.Location = new System.Drawing.Point(6, 24);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(77, 14);
            this.label49.TabIndex = 82;
            this.label49.Text = "用    户:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(322, 22);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(70, 14);
            this.label56.TabIndex = 92;
            this.label56.Text = "用水性质:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(169, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 14);
            this.label13.TabIndex = 113;
            this.label13.Text = "区    号:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 115;
            this.label8.Text = "片    号:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(322, 53);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(70, 14);
            this.label35.TabIndex = 117;
            this.label35.Text = "段    号:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(657, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 14);
            this.label14.TabIndex = 119;
            this.label14.Text = "小区名称:";
            // 
            // btSenior
            // 
            this.btSenior.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSenior.Location = new System.Drawing.Point(426, 79);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(84, 30);
            this.btSenior.TabIndex = 122;
            this.btSenior.Tag = "9999";
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = false;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.panel1, 0, 2);
            this.tb1.Controls.Add(this.groupBox4, 0, 1);
            this.tb1.Controls.Add(this.groupBox3, 0, 0);
            this.tb1.Controls.Add(this.gpbWaterUserMES, 0, 3);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(140, 0);
            this.tb1.Margin = new System.Windows.Forms.Padding(0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 4;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tb1.Size = new System.Drawing.Size(868, 579);
            this.tb1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFilterSearch);
            this.panel1.Controls.Add(this.labRecordCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 24);
            this.panel1.TabIndex = 904;
            // 
            // txtFilterSearch
            // 
            this.txtFilterSearch.BackColor = System.Drawing.Color.LightYellow;
            this.txtFilterSearch.Location = new System.Drawing.Point(490, -3);
            this.txtFilterSearch.Name = "txtFilterSearch";
            this.txtFilterSearch.ReadOnly = true;
            this.txtFilterSearch.Size = new System.Drawing.Size(61, 23);
            this.txtFilterSearch.TabIndex = 904;
            this.txtFilterSearch.Visible = false;
            // 
            // labRecordCount
            // 
            this.labRecordCount.AutoSize = true;
            this.labRecordCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.labRecordCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRecordCount.ForeColor = System.Drawing.Color.Red;
            this.labRecordCount.Location = new System.Drawing.Point(0, 0);
            this.labRecordCount.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.labRecordCount.Name = "labRecordCount";
            this.labRecordCount.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labRecordCount.Size = new System.Drawing.Size(138, 14);
            this.labRecordCount.TabIndex = 904;
            this.labRecordCount.Tag = "9999";
            this.labRecordCount.Text = "抄表记录共计:0条";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgWaterList);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 124);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(862, 315);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "水表抄表";
            // 
            // dgWaterList
            // 
            this.dgWaterList.AllowUserToAddRows = false;
            this.dgWaterList.AllowUserToDeleteRows = false;
            this.dgWaterList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWaterList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgWaterList.ColumnHeadersHeight = 25;
            this.dgWaterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgWaterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.waterUserId,
            this.waterUserNO,
            this.waterUserName,
            this.waterUserAddress,
            this.waterMeterNo,
            this.waterMeterLastNumber,
            this.waterMeterEndNumber,
            this.totalNumber,
            this.totalNumberDescribe,
            this.avePrice,
            this.waterTotalCharge,
            this.extraChargePrice1,
            this.extraCharge1,
            this.extraChargetype1,
            this.extraChargePrice2,
            this.extraCharge2,
            this.extraChargetype2,
            this.extraChargePrice3,
            this.extraCharge3,
            this.extraChargetype3,
            this.extraChargePrice4,
            this.extraCharge4,
            this.extraChargetype4,
            this.extraChargePrice5,
            this.extraCharge5,
            this.extraChargetype5,
            this.extraChargePrice6,
            this.extraCharge6,
            this.extraChargetype6,
            this.extraChargePrice7,
            this.extraCharge7,
            this.extraChargetype7,
            this.extraChargePrice8,
            this.extraCharge8,
            this.extraChargetype8,
            this.extraTotalCharge,
            this.totalCharge,
            this.readMeterRecordYearAndMonth,
            this.waterMeterTypeId,
            this.waterMeterTypeName,
            this.chargeState,
            this.checkState,
            this.checkDateTime,
            this.checker,
            this.areaNO,
            this.pianNO,
            this.duanNO,
            this.COMMUNITYNAME,
            this.buildingNO,
            this.unitNO,
            this.meterReaderID,
            this.meterReaderName,
            this.chargerName,
            this.waterUserHouseType,
            this.createType,
            this.waterUserchargeType,
            this.agentsign,
            this.waterUserTypeId,
            this.waterUserTypeName,
            this.bankId,
            this.bankName,
            this.waterUserPeopleCount,
            this.isSummaryS,
            this.waterMeterId,
            this.meterReadingPageNo,
            this.avePriceDescribe,
            this.trapezoidPrice,
            this.waterMeterPositionId,
            this.waterMeterPositionName,
            this.waterMeterSizeId,
            this.waterMeterSizeValue,
            this.waterMeterProduct,
            this.waterMeterSerialNumber,
            this.waterMeterMode,
            this.waterMeterMagnification,
            this.waterMeterMaxRange,
            this.waterMeterIsSummaryNo,
            this.WATERFIXVALUE,
            this.IsReverse,
            this.readMeterRecordId,
            this.waterUserCreateDate,
            this.BankAcountNumber,
            this.extraCharge});
            this.dgWaterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWaterList.Location = new System.Drawing.Point(3, 47);
            this.dgWaterList.MultiSelect = false;
            this.dgWaterList.Name = "dgWaterList";
            this.dgWaterList.ReadOnly = true;
            this.dgWaterList.RowHeadersWidth = 45;
            this.dgWaterList.RowTemplate.Height = 23;
            this.dgWaterList.Size = new System.Drawing.Size(856, 265);
            this.dgWaterList.TabIndex = 4;
            this.dgWaterList.Tag = "9999";
            this.dgWaterList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgWaterList_CellFormatting);
            this.dgWaterList.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWaterList_CellMouseEnter);
            this.dgWaterList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgWaterList_CellPainting);
            this.dgWaterList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWaterList_CellClick);
            this.dgWaterList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgWaterList_CurrentCellDirtyStateChanged);
            // 
            // select
            // 
            this.select.FalseValue = "False";
            this.select.Frozen = true;
            this.select.HeaderText = "";
            this.select.Name = "select";
            this.select.ReadOnly = true;
            this.select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.select.TrueValue = "True";
            this.select.Width = 20;
            // 
            // waterUserId
            // 
            this.waterUserId.DataPropertyName = "waterUserId";
            this.waterUserId.Frozen = true;
            this.waterUserId.HeaderText = "waterUserId";
            this.waterUserId.Name = "waterUserId";
            this.waterUserId.ReadOnly = true;
            this.waterUserId.Visible = false;
            this.waterUserId.Width = 109;
            // 
            // waterUserNO
            // 
            this.waterUserNO.DataPropertyName = "waterUserNO";
            this.waterUserNO.Frozen = true;
            this.waterUserNO.HeaderText = "用户号";
            this.waterUserNO.Name = "waterUserNO";
            this.waterUserNO.ReadOnly = true;
            this.waterUserNO.Width = 74;
            // 
            // waterUserName
            // 
            this.waterUserName.DataPropertyName = "waterUserName";
            this.waterUserName.Frozen = true;
            this.waterUserName.HeaderText = "用户名";
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.ReadOnly = true;
            this.waterUserName.Width = 120;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.Frozen = true;
            this.waterUserAddress.HeaderText = "地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            this.waterUserAddress.Width = 200;
            // 
            // waterMeterNo
            // 
            this.waterMeterNo.DataPropertyName = "waterMeterNo";
            this.waterMeterNo.HeaderText = "水表编号";
            this.waterMeterNo.Name = "waterMeterNo";
            this.waterMeterNo.ReadOnly = true;
            this.waterMeterNo.Width = 88;
            // 
            // waterMeterLastNumber
            // 
            this.waterMeterLastNumber.DataPropertyName = "waterMeterLastNumber";
            this.waterMeterLastNumber.HeaderText = "上期读数";
            this.waterMeterLastNumber.Name = "waterMeterLastNumber";
            this.waterMeterLastNumber.ReadOnly = true;
            this.waterMeterLastNumber.Width = 88;
            // 
            // waterMeterEndNumber
            // 
            this.waterMeterEndNumber.DataPropertyName = "waterMeterEndNumber";
            this.waterMeterEndNumber.HeaderText = "本期读数";
            this.waterMeterEndNumber.Name = "waterMeterEndNumber";
            this.waterMeterEndNumber.ReadOnly = true;
            this.waterMeterEndNumber.Width = 88;
            // 
            // totalNumber
            // 
            this.totalNumber.DataPropertyName = "totalNumber";
            this.totalNumber.HeaderText = "用水量";
            this.totalNumber.Name = "totalNumber";
            this.totalNumber.ReadOnly = true;
            this.totalNumber.Width = 74;
            // 
            // totalNumberDescribe
            // 
            this.totalNumberDescribe.DataPropertyName = "totalNumberDescribe";
            this.totalNumberDescribe.HeaderText = "用水量描述";
            this.totalNumberDescribe.Name = "totalNumberDescribe";
            this.totalNumberDescribe.ReadOnly = true;
            this.totalNumberDescribe.Visible = false;
            this.totalNumberDescribe.Width = 102;
            // 
            // avePrice
            // 
            this.avePrice.DataPropertyName = "avePrice";
            this.avePrice.HeaderText = "平均单价";
            this.avePrice.Name = "avePrice";
            this.avePrice.ReadOnly = true;
            this.avePrice.Width = 88;
            // 
            // waterTotalCharge
            // 
            this.waterTotalCharge.DataPropertyName = "waterTotalCharge";
            this.waterTotalCharge.HeaderText = "水费";
            this.waterTotalCharge.Name = "waterTotalCharge";
            this.waterTotalCharge.ReadOnly = true;
            this.waterTotalCharge.Width = 60;
            // 
            // extraChargePrice1
            // 
            this.extraChargePrice1.DataPropertyName = "extraChargePrice1";
            this.extraChargePrice1.HeaderText = "附加费单价1";
            this.extraChargePrice1.Name = "extraChargePrice1";
            this.extraChargePrice1.ReadOnly = true;
            this.extraChargePrice1.Width = 109;
            // 
            // extraCharge1
            // 
            this.extraCharge1.DataPropertyName = "extraCharge1";
            this.extraCharge1.HeaderText = "附加费1";
            this.extraCharge1.Name = "extraCharge1";
            this.extraCharge1.ReadOnly = true;
            this.extraCharge1.Width = 81;
            // 
            // extraChargetype1
            // 
            this.extraChargetype1.DataPropertyName = "extraChargetype1";
            this.extraChargetype1.HeaderText = "附加费计算方式";
            this.extraChargetype1.Name = "extraChargetype1";
            this.extraChargetype1.ReadOnly = true;
            this.extraChargetype1.Visible = false;
            this.extraChargetype1.Width = 130;
            // 
            // extraChargePrice2
            // 
            this.extraChargePrice2.DataPropertyName = "extraChargePrice2";
            this.extraChargePrice2.HeaderText = "extraChargePrice2";
            this.extraChargePrice2.Name = "extraChargePrice2";
            this.extraChargePrice2.ReadOnly = true;
            this.extraChargePrice2.Width = 151;
            // 
            // extraCharge2
            // 
            this.extraCharge2.DataPropertyName = "extraCharge2";
            this.extraCharge2.HeaderText = "附加费2";
            this.extraCharge2.Name = "extraCharge2";
            this.extraCharge2.ReadOnly = true;
            this.extraCharge2.Width = 81;
            // 
            // extraChargetype2
            // 
            this.extraChargetype2.DataPropertyName = "extraChargetype2";
            this.extraChargetype2.HeaderText = "extraChargetype2";
            this.extraChargetype2.Name = "extraChargetype2";
            this.extraChargetype2.ReadOnly = true;
            this.extraChargetype2.Visible = false;
            this.extraChargetype2.Width = 144;
            // 
            // extraChargePrice3
            // 
            this.extraChargePrice3.DataPropertyName = "extraChargePrice3";
            this.extraChargePrice3.HeaderText = "extraChargePrice3";
            this.extraChargePrice3.Name = "extraChargePrice3";
            this.extraChargePrice3.ReadOnly = true;
            this.extraChargePrice3.Width = 151;
            // 
            // extraCharge3
            // 
            this.extraCharge3.DataPropertyName = "extraCharge3";
            this.extraCharge3.HeaderText = "附加费3";
            this.extraCharge3.Name = "extraCharge3";
            this.extraCharge3.ReadOnly = true;
            this.extraCharge3.Width = 81;
            // 
            // extraChargetype3
            // 
            this.extraChargetype3.DataPropertyName = "extraChargetype3";
            this.extraChargetype3.HeaderText = "extraChargetype3";
            this.extraChargetype3.Name = "extraChargetype3";
            this.extraChargetype3.ReadOnly = true;
            this.extraChargetype3.Visible = false;
            this.extraChargetype3.Width = 144;
            // 
            // extraChargePrice4
            // 
            this.extraChargePrice4.DataPropertyName = "extraChargePrice4";
            this.extraChargePrice4.HeaderText = "extraChargePrice4";
            this.extraChargePrice4.Name = "extraChargePrice4";
            this.extraChargePrice4.ReadOnly = true;
            this.extraChargePrice4.Width = 151;
            // 
            // extraCharge4
            // 
            this.extraCharge4.DataPropertyName = "extraCharge4";
            this.extraCharge4.HeaderText = "附加费4";
            this.extraCharge4.Name = "extraCharge4";
            this.extraCharge4.ReadOnly = true;
            this.extraCharge4.Width = 81;
            // 
            // extraChargetype4
            // 
            this.extraChargetype4.DataPropertyName = "extraChargetype4";
            this.extraChargetype4.HeaderText = "extraChargetype4";
            this.extraChargetype4.Name = "extraChargetype4";
            this.extraChargetype4.ReadOnly = true;
            this.extraChargetype4.Visible = false;
            this.extraChargetype4.Width = 144;
            // 
            // extraChargePrice5
            // 
            this.extraChargePrice5.DataPropertyName = "extraChargePrice5";
            this.extraChargePrice5.HeaderText = "extraChargePrice5";
            this.extraChargePrice5.Name = "extraChargePrice5";
            this.extraChargePrice5.ReadOnly = true;
            this.extraChargePrice5.Width = 151;
            // 
            // extraCharge5
            // 
            this.extraCharge5.DataPropertyName = "extraCharge5";
            this.extraCharge5.HeaderText = "附加费5";
            this.extraCharge5.Name = "extraCharge5";
            this.extraCharge5.ReadOnly = true;
            this.extraCharge5.Width = 81;
            // 
            // extraChargetype5
            // 
            this.extraChargetype5.DataPropertyName = "extraChargetype5";
            this.extraChargetype5.HeaderText = "extraChargetype5";
            this.extraChargetype5.Name = "extraChargetype5";
            this.extraChargetype5.ReadOnly = true;
            this.extraChargetype5.Visible = false;
            this.extraChargetype5.Width = 144;
            // 
            // extraChargePrice6
            // 
            this.extraChargePrice6.DataPropertyName = "extraChargePrice6";
            this.extraChargePrice6.HeaderText = "extraChargePrice6";
            this.extraChargePrice6.Name = "extraChargePrice6";
            this.extraChargePrice6.ReadOnly = true;
            this.extraChargePrice6.Width = 151;
            // 
            // extraCharge6
            // 
            this.extraCharge6.DataPropertyName = "extraCharge6";
            this.extraCharge6.HeaderText = "附加费6";
            this.extraCharge6.Name = "extraCharge6";
            this.extraCharge6.ReadOnly = true;
            this.extraCharge6.Width = 81;
            // 
            // extraChargetype6
            // 
            this.extraChargetype6.DataPropertyName = "extraChargetype6";
            this.extraChargetype6.HeaderText = "extraChargetype6";
            this.extraChargetype6.Name = "extraChargetype6";
            this.extraChargetype6.ReadOnly = true;
            this.extraChargetype6.Visible = false;
            this.extraChargetype6.Width = 144;
            // 
            // extraChargePrice7
            // 
            this.extraChargePrice7.DataPropertyName = "extraChargePrice7";
            this.extraChargePrice7.HeaderText = "extraChargePrice7";
            this.extraChargePrice7.Name = "extraChargePrice7";
            this.extraChargePrice7.ReadOnly = true;
            this.extraChargePrice7.Width = 151;
            // 
            // extraCharge7
            // 
            this.extraCharge7.DataPropertyName = "extraCharge7";
            this.extraCharge7.HeaderText = "附加费7";
            this.extraCharge7.Name = "extraCharge7";
            this.extraCharge7.ReadOnly = true;
            this.extraCharge7.Width = 81;
            // 
            // extraChargetype7
            // 
            this.extraChargetype7.HeaderText = "extraChargetype7";
            this.extraChargetype7.Name = "extraChargetype7";
            this.extraChargetype7.ReadOnly = true;
            this.extraChargetype7.Visible = false;
            this.extraChargetype7.Width = 144;
            // 
            // extraChargePrice8
            // 
            this.extraChargePrice8.DataPropertyName = "extraChargePrice8";
            this.extraChargePrice8.HeaderText = "extraChargePrice8";
            this.extraChargePrice8.Name = "extraChargePrice8";
            this.extraChargePrice8.ReadOnly = true;
            this.extraChargePrice8.Width = 151;
            // 
            // extraCharge8
            // 
            this.extraCharge8.DataPropertyName = "extraCharge8";
            this.extraCharge8.HeaderText = "附加费8";
            this.extraCharge8.Name = "extraCharge8";
            this.extraCharge8.ReadOnly = true;
            this.extraCharge8.Width = 81;
            // 
            // extraChargetype8
            // 
            this.extraChargetype8.HeaderText = "extraChargetype8";
            this.extraChargetype8.Name = "extraChargetype8";
            this.extraChargetype8.ReadOnly = true;
            this.extraChargetype8.Visible = false;
            this.extraChargetype8.Width = 144;
            // 
            // extraTotalCharge
            // 
            this.extraTotalCharge.DataPropertyName = "extraTotalCharge";
            this.extraTotalCharge.HeaderText = "附加费小计";
            this.extraTotalCharge.Name = "extraTotalCharge";
            this.extraTotalCharge.ReadOnly = true;
            this.extraTotalCharge.Width = 102;
            // 
            // totalCharge
            // 
            this.totalCharge.DataPropertyName = "totalCharge";
            this.totalCharge.HeaderText = "费用合计";
            this.totalCharge.Name = "totalCharge";
            this.totalCharge.ReadOnly = true;
            this.totalCharge.Width = 88;
            // 
            // readMeterRecordYearAndMonth
            // 
            this.readMeterRecordYearAndMonth.DataPropertyName = "readMeterRecordYearAndMonth";
            this.readMeterRecordYearAndMonth.HeaderText = "水费月份";
            this.readMeterRecordYearAndMonth.Name = "readMeterRecordYearAndMonth";
            this.readMeterRecordYearAndMonth.ReadOnly = true;
            // 
            // waterMeterTypeId
            // 
            this.waterMeterTypeId.DataPropertyName = "waterMeterTypeId";
            this.waterMeterTypeId.HeaderText = "用水性质代码";
            this.waterMeterTypeId.Name = "waterMeterTypeId";
            this.waterMeterTypeId.ReadOnly = true;
            this.waterMeterTypeId.Visible = false;
            this.waterMeterTypeId.Width = 116;
            // 
            // waterMeterTypeName
            // 
            this.waterMeterTypeName.DataPropertyName = "waterMeterTypeName";
            this.waterMeterTypeName.HeaderText = "用水性质";
            this.waterMeterTypeName.Name = "waterMeterTypeName";
            this.waterMeterTypeName.ReadOnly = true;
            this.waterMeterTypeName.Width = 88;
            // 
            // chargeState
            // 
            this.chargeState.DataPropertyName = "chargeState";
            this.chargeState.HeaderText = "抄表状态";
            this.chargeState.Name = "chargeState";
            this.chargeState.ReadOnly = true;
            // 
            // checkState
            // 
            this.checkState.DataPropertyName = "checkState";
            this.checkState.HeaderText = "审核状态";
            this.checkState.Name = "checkState";
            this.checkState.ReadOnly = true;
            // 
            // checkDateTime
            // 
            this.checkDateTime.DataPropertyName = "checkDateTime";
            this.checkDateTime.HeaderText = "审核时间";
            this.checkDateTime.Name = "checkDateTime";
            this.checkDateTime.ReadOnly = true;
            // 
            // checker
            // 
            this.checker.DataPropertyName = "checker";
            this.checker.HeaderText = "审核人";
            this.checker.Name = "checker";
            this.checker.ReadOnly = true;
            // 
            // areaNO
            // 
            this.areaNO.DataPropertyName = "areaNO";
            this.areaNO.HeaderText = "区号";
            this.areaNO.Name = "areaNO";
            this.areaNO.ReadOnly = true;
            this.areaNO.Width = 60;
            // 
            // pianNO
            // 
            this.pianNO.DataPropertyName = "pianNO";
            this.pianNO.HeaderText = "片号";
            this.pianNO.Name = "pianNO";
            this.pianNO.ReadOnly = true;
            this.pianNO.Width = 60;
            // 
            // duanNO
            // 
            this.duanNO.DataPropertyName = "duanNO";
            this.duanNO.HeaderText = "段号";
            this.duanNO.Name = "duanNO";
            this.duanNO.ReadOnly = true;
            this.duanNO.Width = 60;
            // 
            // COMMUNITYNAME
            // 
            this.COMMUNITYNAME.DataPropertyName = "COMMUNITYNAME";
            this.COMMUNITYNAME.HeaderText = "小区名称";
            this.COMMUNITYNAME.Name = "COMMUNITYNAME";
            this.COMMUNITYNAME.ReadOnly = true;
            this.COMMUNITYNAME.Width = 88;
            // 
            // buildingNO
            // 
            this.buildingNO.DataPropertyName = "buildingNO";
            this.buildingNO.HeaderText = "楼号";
            this.buildingNO.Name = "buildingNO";
            this.buildingNO.ReadOnly = true;
            this.buildingNO.Width = 60;
            // 
            // unitNO
            // 
            this.unitNO.DataPropertyName = "unitNO";
            this.unitNO.HeaderText = "单元";
            this.unitNO.Name = "unitNO";
            this.unitNO.ReadOnly = true;
            this.unitNO.Width = 60;
            // 
            // meterReaderID
            // 
            this.meterReaderID.DataPropertyName = "meterReaderID";
            this.meterReaderID.HeaderText = "meterReaderID";
            this.meterReaderID.Name = "meterReaderID";
            this.meterReaderID.ReadOnly = true;
            this.meterReaderID.Visible = false;
            this.meterReaderID.Width = 123;
            // 
            // meterReaderName
            // 
            this.meterReaderName.DataPropertyName = "meterReaderName";
            this.meterReaderName.HeaderText = "抄表员";
            this.meterReaderName.Name = "meterReaderName";
            this.meterReaderName.ReadOnly = true;
            this.meterReaderName.Width = 74;
            // 
            // chargerName
            // 
            this.chargerName.DataPropertyName = "chargerName";
            this.chargerName.HeaderText = "收费员";
            this.chargerName.Name = "chargerName";
            this.chargerName.ReadOnly = true;
            this.chargerName.Width = 74;
            // 
            // waterUserHouseType
            // 
            this.waterUserHouseType.DataPropertyName = "waterUserHouseType";
            this.waterUserHouseType.HeaderText = "户型";
            this.waterUserHouseType.Name = "waterUserHouseType";
            this.waterUserHouseType.ReadOnly = true;
            this.waterUserHouseType.Visible = false;
            this.waterUserHouseType.Width = 60;
            // 
            // createType
            // 
            this.createType.DataPropertyName = "createType";
            this.createType.HeaderText = "建档类型";
            this.createType.Name = "createType";
            this.createType.ReadOnly = true;
            this.createType.Visible = false;
            this.createType.Width = 88;
            // 
            // waterUserchargeType
            // 
            this.waterUserchargeType.DataPropertyName = "waterUserchargeType";
            this.waterUserchargeType.HeaderText = "交费方式";
            this.waterUserchargeType.Name = "waterUserchargeType";
            this.waterUserchargeType.ReadOnly = true;
            this.waterUserchargeType.Visible = false;
            this.waterUserchargeType.Width = 88;
            // 
            // agentsign
            // 
            this.agentsign.DataPropertyName = "agentsign";
            this.agentsign.HeaderText = "银行托收";
            this.agentsign.Name = "agentsign";
            this.agentsign.ReadOnly = true;
            this.agentsign.Visible = false;
            this.agentsign.Width = 88;
            // 
            // waterUserTypeId
            // 
            this.waterUserTypeId.DataPropertyName = "waterUserTypeId";
            this.waterUserTypeId.HeaderText = "waterUserTypeId";
            this.waterUserTypeId.Name = "waterUserTypeId";
            this.waterUserTypeId.ReadOnly = true;
            this.waterUserTypeId.Visible = false;
            this.waterUserTypeId.Width = 137;
            // 
            // waterUserTypeName
            // 
            this.waterUserTypeName.DataPropertyName = "waterUserTypeName";
            this.waterUserTypeName.HeaderText = "用户类型";
            this.waterUserTypeName.Name = "waterUserTypeName";
            this.waterUserTypeName.ReadOnly = true;
            this.waterUserTypeName.Visible = false;
            this.waterUserTypeName.Width = 88;
            // 
            // bankId
            // 
            this.bankId.DataPropertyName = "bankId";
            this.bankId.HeaderText = "bankId";
            this.bankId.Name = "bankId";
            this.bankId.ReadOnly = true;
            this.bankId.Visible = false;
            this.bankId.Width = 74;
            // 
            // bankName
            // 
            this.bankName.DataPropertyName = "bankName";
            this.bankName.HeaderText = "托收银行";
            this.bankName.Name = "bankName";
            this.bankName.ReadOnly = true;
            this.bankName.Visible = false;
            this.bankName.Width = 88;
            // 
            // waterUserPeopleCount
            // 
            this.waterUserPeopleCount.DataPropertyName = "waterUserPeopleCount";
            this.waterUserPeopleCount.HeaderText = "waterUserPeopleCount";
            this.waterUserPeopleCount.Name = "waterUserPeopleCount";
            this.waterUserPeopleCount.ReadOnly = true;
            this.waterUserPeopleCount.Visible = false;
            this.waterUserPeopleCount.Width = 172;
            // 
            // isSummaryS
            // 
            this.isSummaryS.DataPropertyName = "isSummaryS";
            this.isSummaryS.HeaderText = "是否总表";
            this.isSummaryS.Name = "isSummaryS";
            this.isSummaryS.ReadOnly = true;
            this.isSummaryS.Visible = false;
            this.isSummaryS.Width = 88;
            // 
            // waterMeterId
            // 
            this.waterMeterId.DataPropertyName = "waterMeterId";
            this.waterMeterId.HeaderText = "waterMeterId";
            this.waterMeterId.Name = "waterMeterId";
            this.waterMeterId.ReadOnly = true;
            this.waterMeterId.Visible = false;
            this.waterMeterId.Width = 116;
            // 
            // meterReadingPageNo
            // 
            this.meterReadingPageNo.DataPropertyName = "meterReadingPageNo";
            this.meterReadingPageNo.HeaderText = "页号";
            this.meterReadingPageNo.Name = "meterReadingPageNo";
            this.meterReadingPageNo.ReadOnly = true;
            this.meterReadingPageNo.Visible = false;
            this.meterReadingPageNo.Width = 60;
            // 
            // avePriceDescribe
            // 
            this.avePriceDescribe.DataPropertyName = "avePriceDescribe";
            this.avePriceDescribe.HeaderText = "avePriceDescribe";
            this.avePriceDescribe.Name = "avePriceDescribe";
            this.avePriceDescribe.ReadOnly = true;
            this.avePriceDescribe.Visible = false;
            this.avePriceDescribe.Width = 144;
            // 
            // trapezoidPrice
            // 
            this.trapezoidPrice.DataPropertyName = "trapezoidPrice";
            this.trapezoidPrice.HeaderText = "trapezoidPrice";
            this.trapezoidPrice.Name = "trapezoidPrice";
            this.trapezoidPrice.ReadOnly = true;
            this.trapezoidPrice.Visible = false;
            this.trapezoidPrice.Width = 130;
            // 
            // waterMeterPositionId
            // 
            this.waterMeterPositionId.DataPropertyName = "waterMeterPositionId";
            this.waterMeterPositionId.HeaderText = "水表位置";
            this.waterMeterPositionId.Name = "waterMeterPositionId";
            this.waterMeterPositionId.ReadOnly = true;
            this.waterMeterPositionId.Visible = false;
            this.waterMeterPositionId.Width = 88;
            // 
            // waterMeterPositionName
            // 
            this.waterMeterPositionName.DataPropertyName = "waterMeterPositionName";
            this.waterMeterPositionName.HeaderText = "水表位置";
            this.waterMeterPositionName.Name = "waterMeterPositionName";
            this.waterMeterPositionName.ReadOnly = true;
            this.waterMeterPositionName.Width = 88;
            // 
            // waterMeterSizeId
            // 
            this.waterMeterSizeId.DataPropertyName = "waterMeterSizeId";
            this.waterMeterSizeId.HeaderText = "口径ID";
            this.waterMeterSizeId.Name = "waterMeterSizeId";
            this.waterMeterSizeId.ReadOnly = true;
            this.waterMeterSizeId.Visible = false;
            this.waterMeterSizeId.Width = 74;
            // 
            // waterMeterSizeValue
            // 
            this.waterMeterSizeValue.DataPropertyName = "waterMeterSizeValue";
            this.waterMeterSizeValue.HeaderText = "口径";
            this.waterMeterSizeValue.Name = "waterMeterSizeValue";
            this.waterMeterSizeValue.ReadOnly = true;
            this.waterMeterSizeValue.Visible = false;
            this.waterMeterSizeValue.Width = 60;
            // 
            // waterMeterProduct
            // 
            this.waterMeterProduct.DataPropertyName = "waterMeterProduct";
            this.waterMeterProduct.HeaderText = "生产厂家";
            this.waterMeterProduct.Name = "waterMeterProduct";
            this.waterMeterProduct.ReadOnly = true;
            this.waterMeterProduct.Visible = false;
            this.waterMeterProduct.Width = 88;
            // 
            // waterMeterSerialNumber
            // 
            this.waterMeterSerialNumber.DataPropertyName = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.HeaderText = "出厂编号";
            this.waterMeterSerialNumber.Name = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.ReadOnly = true;
            this.waterMeterSerialNumber.Visible = false;
            this.waterMeterSerialNumber.Width = 88;
            // 
            // waterMeterMode
            // 
            this.waterMeterMode.DataPropertyName = "waterMeterMode";
            this.waterMeterMode.HeaderText = "规格";
            this.waterMeterMode.Name = "waterMeterMode";
            this.waterMeterMode.ReadOnly = true;
            this.waterMeterMode.Visible = false;
            this.waterMeterMode.Width = 60;
            // 
            // waterMeterMagnification
            // 
            this.waterMeterMagnification.DataPropertyName = "waterMeterMagnification";
            this.waterMeterMagnification.HeaderText = "倍率";
            this.waterMeterMagnification.Name = "waterMeterMagnification";
            this.waterMeterMagnification.ReadOnly = true;
            this.waterMeterMagnification.Visible = false;
            this.waterMeterMagnification.Width = 60;
            // 
            // waterMeterMaxRange
            // 
            this.waterMeterMaxRange.DataPropertyName = "waterMeterMaxRange";
            this.waterMeterMaxRange.HeaderText = "最大量程";
            this.waterMeterMaxRange.Name = "waterMeterMaxRange";
            this.waterMeterMaxRange.ReadOnly = true;
            this.waterMeterMaxRange.Visible = false;
            this.waterMeterMaxRange.Width = 88;
            // 
            // waterMeterIsSummaryNo
            // 
            this.waterMeterIsSummaryNo.DataPropertyName = "waterMeterParentId";
            this.waterMeterIsSummaryNo.HeaderText = "总表编号";
            this.waterMeterIsSummaryNo.Name = "waterMeterIsSummaryNo";
            this.waterMeterIsSummaryNo.ReadOnly = true;
            this.waterMeterIsSummaryNo.Visible = false;
            this.waterMeterIsSummaryNo.Width = 88;
            // 
            // WATERFIXVALUE
            // 
            this.WATERFIXVALUE.DataPropertyName = "WATERFIXVALUE";
            this.WATERFIXVALUE.HeaderText = "定量用水";
            this.WATERFIXVALUE.Name = "WATERFIXVALUE";
            this.WATERFIXVALUE.ReadOnly = true;
            this.WATERFIXVALUE.Width = 88;
            // 
            // IsReverse
            // 
            this.IsReverse.DataPropertyName = "IsReverse";
            this.IsReverse.HeaderText = "水表倒装";
            this.IsReverse.Name = "IsReverse";
            this.IsReverse.ReadOnly = true;
            this.IsReverse.Width = 88;
            // 
            // readMeterRecordId
            // 
            this.readMeterRecordId.DataPropertyName = "readMeterRecordId";
            this.readMeterRecordId.HeaderText = "readMeterReordId";
            this.readMeterRecordId.Name = "readMeterRecordId";
            this.readMeterRecordId.ReadOnly = true;
            this.readMeterRecordId.Visible = false;
            this.readMeterRecordId.Width = 144;
            // 
            // waterUserCreateDate
            // 
            this.waterUserCreateDate.DataPropertyName = "waterUserCreateDate";
            this.waterUserCreateDate.HeaderText = "waterUserCreateDate";
            this.waterUserCreateDate.Name = "waterUserCreateDate";
            this.waterUserCreateDate.ReadOnly = true;
            this.waterUserCreateDate.Visible = false;
            this.waterUserCreateDate.Width = 165;
            // 
            // BankAcountNumber
            // 
            this.BankAcountNumber.DataPropertyName = "BankAcountNumber";
            this.BankAcountNumber.HeaderText = "BankAcountNumber";
            this.BankAcountNumber.Name = "BankAcountNumber";
            this.BankAcountNumber.ReadOnly = true;
            this.BankAcountNumber.Visible = false;
            this.BankAcountNumber.Width = 144;
            // 
            // extraCharge
            // 
            this.extraCharge.DataPropertyName = "extraCharge";
            this.extraCharge.HeaderText = "extraCharge";
            this.extraCharge.Name = "extraCharge";
            this.extraCharge.ReadOnly = true;
            this.extraCharge.Visible = false;
            this.extraCharge.Width = 109;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelectAll,
            this.toolCheck,
            this.toolStripLabel2,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 19);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(856, 28);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Tag = "9999";
            // 
            // toolSelectAll
            // 
            this.toolSelectAll.Image = global::WATERFEEMANAGE.Properties.Resources.onebit_20;
            this.toolSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelectAll.Name = "toolSelectAll";
            this.toolSelectAll.Size = new System.Drawing.Size(62, 25);
            this.toolSelectAll.Text = "全选";
            this.toolSelectAll.Click += new System.EventHandler(this.toolSelectAll_Click);
            // 
            // toolCheck
            // 
            this.toolCheck.Image = global::WATERFEEMANAGE.Properties.Resources.审核;
            this.toolCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCheck.Name = "toolCheck";
            this.toolCheck.Size = new System.Drawing.Size(62, 25);
            this.toolCheck.Text = "审核";
            this.toolCheck.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(105, 25);
            this.toolStripLabel2.Text = "                   ";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Navy;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(188, 25);
            this.toolStripLabel1.Text = "此界面只可查询到已抄的抄表信息";
            // 
            // gpbWaterUserMES
            // 
            this.gpbWaterUserMES.BackColor = System.Drawing.Color.LimeGreen;
            this.gpbWaterUserMES.Controls.Add(this.txtWaterMeterType);
            this.gpbWaterUserMES.Controls.Add(this.txtWaterUserType);
            this.gpbWaterUserMES.Controls.Add(this.txtYearAndMonth);
            this.gpbWaterUserMES.Controls.Add(this.txtWaterUserAddress);
            this.gpbWaterUserMES.Controls.Add(this.txtCharger);
            this.gpbWaterUserMES.Controls.Add(this.txtAreaNO);
            this.gpbWaterUserMES.Controls.Add(this.txtDuanNO);
            this.gpbWaterUserMES.Controls.Add(this.txtPianNO);
            this.gpbWaterUserMES.Controls.Add(this.txtWaterUserChargetype);
            this.gpbWaterUserMES.Controls.Add(this.txtCreateType);
            this.gpbWaterUserMES.Controls.Add(this.txtCommunity);
            this.gpbWaterUserMES.Controls.Add(this.txtWaterUserHouseType);
            this.gpbWaterUserMES.Controls.Add(this.txtMeterReader);
            this.gpbWaterUserMES.Controls.Add(this.label10);
            this.gpbWaterUserMES.Controls.Add(this.label43);
            this.gpbWaterUserMES.Controls.Add(this.label26);
            this.gpbWaterUserMES.Controls.Add(this.label25);
            this.gpbWaterUserMES.Controls.Add(this.txtWaterUserCount);
            this.gpbWaterUserMES.Controls.Add(this.label2);
            this.gpbWaterUserMES.Controls.Add(this.label22);
            this.gpbWaterUserMES.Controls.Add(this.label5);
            this.gpbWaterUserMES.Controls.Add(this.label21);
            this.gpbWaterUserMES.Controls.Add(this.label20);
            this.gpbWaterUserMES.Controls.Add(this.label6);
            this.gpbWaterUserMES.Controls.Add(this.label9);
            this.gpbWaterUserMES.Controls.Add(this.label7);
            this.gpbWaterUserMES.Controls.Add(this.label15);
            this.gpbWaterUserMES.Controls.Add(this.label4);
            this.gpbWaterUserMES.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbWaterUserMES.Location = new System.Drawing.Point(0, 472);
            this.gpbWaterUserMES.Margin = new System.Windows.Forms.Padding(0);
            this.gpbWaterUserMES.Name = "gpbWaterUserMES";
            this.gpbWaterUserMES.Size = new System.Drawing.Size(868, 107);
            this.gpbWaterUserMES.TabIndex = 11;
            this.gpbWaterUserMES.TabStop = false;
            this.gpbWaterUserMES.Tag = "9999";
            this.gpbWaterUserMES.Text = "用户信息";
            // 
            // txtWaterMeterType
            // 
            this.txtWaterMeterType.BackColor = System.Drawing.Color.LightYellow;
            this.txtWaterMeterType.Location = new System.Drawing.Point(682, 76);
            this.txtWaterMeterType.Name = "txtWaterMeterType";
            this.txtWaterMeterType.ReadOnly = true;
            this.txtWaterMeterType.Size = new System.Drawing.Size(116, 23);
            this.txtWaterMeterType.TabIndex = 92;
            // 
            // txtWaterUserType
            // 
            this.txtWaterUserType.BackColor = System.Drawing.Color.LightYellow;
            this.txtWaterUserType.Location = new System.Drawing.Point(682, 47);
            this.txtWaterUserType.Name = "txtWaterUserType";
            this.txtWaterUserType.ReadOnly = true;
            this.txtWaterUserType.Size = new System.Drawing.Size(116, 23);
            this.txtWaterUserType.TabIndex = 80;
            // 
            // txtYearAndMonth
            // 
            this.txtYearAndMonth.BackColor = System.Drawing.Color.LightYellow;
            this.txtYearAndMonth.Location = new System.Drawing.Point(510, 76);
            this.txtYearAndMonth.Name = "txtYearAndMonth";
            this.txtYearAndMonth.ReadOnly = true;
            this.txtYearAndMonth.Size = new System.Drawing.Size(78, 23);
            this.txtYearAndMonth.TabIndex = 90;
            // 
            // txtWaterUserAddress
            // 
            this.txtWaterUserAddress.BackColor = System.Drawing.Color.LightYellow;
            this.txtWaterUserAddress.Location = new System.Drawing.Point(510, 18);
            this.txtWaterUserAddress.Name = "txtWaterUserAddress";
            this.txtWaterUserAddress.ReadOnly = true;
            this.txtWaterUserAddress.Size = new System.Drawing.Size(288, 23);
            this.txtWaterUserAddress.TabIndex = 69;
            // 
            // txtCharger
            // 
            this.txtCharger.BackColor = System.Drawing.Color.LightYellow;
            this.txtCharger.Location = new System.Drawing.Point(510, 47);
            this.txtCharger.Name = "txtCharger";
            this.txtCharger.ReadOnly = true;
            this.txtCharger.Size = new System.Drawing.Size(78, 23);
            this.txtCharger.TabIndex = 72;
            // 
            // txtAreaNO
            // 
            this.txtAreaNO.BackColor = System.Drawing.Color.LightYellow;
            this.txtAreaNO.Location = new System.Drawing.Point(55, 18);
            this.txtAreaNO.Name = "txtAreaNO";
            this.txtAreaNO.ReadOnly = true;
            this.txtAreaNO.Size = new System.Drawing.Size(50, 23);
            this.txtAreaNO.TabIndex = 64;
            // 
            // txtDuanNO
            // 
            this.txtDuanNO.BackColor = System.Drawing.Color.LightYellow;
            this.txtDuanNO.Location = new System.Drawing.Point(55, 74);
            this.txtDuanNO.Name = "txtDuanNO";
            this.txtDuanNO.ReadOnly = true;
            this.txtDuanNO.Size = new System.Drawing.Size(50, 23);
            this.txtDuanNO.TabIndex = 88;
            // 
            // txtPianNO
            // 
            this.txtPianNO.BackColor = System.Drawing.Color.LightYellow;
            this.txtPianNO.Location = new System.Drawing.Point(55, 47);
            this.txtPianNO.Name = "txtPianNO";
            this.txtPianNO.ReadOnly = true;
            this.txtPianNO.Size = new System.Drawing.Size(50, 23);
            this.txtPianNO.TabIndex = 78;
            // 
            // txtWaterUserChargetype
            // 
            this.txtWaterUserChargetype.BackColor = System.Drawing.Color.LightYellow;
            this.txtWaterUserChargetype.Location = new System.Drawing.Point(197, 72);
            this.txtWaterUserChargetype.Name = "txtWaterUserChargetype";
            this.txtWaterUserChargetype.ReadOnly = true;
            this.txtWaterUserChargetype.Size = new System.Drawing.Size(78, 23);
            this.txtWaterUserChargetype.TabIndex = 86;
            // 
            // txtCreateType
            // 
            this.txtCreateType.BackColor = System.Drawing.Color.LightYellow;
            this.txtCreateType.Location = new System.Drawing.Point(197, 47);
            this.txtCreateType.Name = "txtCreateType";
            this.txtCreateType.ReadOnly = true;
            this.txtCreateType.Size = new System.Drawing.Size(78, 23);
            this.txtCreateType.TabIndex = 84;
            // 
            // txtCommunity
            // 
            this.txtCommunity.BackColor = System.Drawing.Color.LightYellow;
            this.txtCommunity.Location = new System.Drawing.Point(197, 18);
            this.txtCommunity.Name = "txtCommunity";
            this.txtCommunity.ReadOnly = true;
            this.txtCommunity.Size = new System.Drawing.Size(78, 23);
            this.txtCommunity.TabIndex = 74;
            // 
            // txtWaterUserHouseType
            // 
            this.txtWaterUserHouseType.BackColor = System.Drawing.Color.LightYellow;
            this.txtWaterUserHouseType.Location = new System.Drawing.Point(354, 74);
            this.txtWaterUserHouseType.Name = "txtWaterUserHouseType";
            this.txtWaterUserHouseType.ReadOnly = true;
            this.txtWaterUserHouseType.Size = new System.Drawing.Size(64, 23);
            this.txtWaterUserHouseType.TabIndex = 82;
            // 
            // txtMeterReader
            // 
            this.txtMeterReader.BackColor = System.Drawing.Color.LightYellow;
            this.txtMeterReader.Location = new System.Drawing.Point(354, 47);
            this.txtMeterReader.Name = "txtMeterReader";
            this.txtMeterReader.ReadOnly = true;
            this.txtMeterReader.Size = new System.Drawing.Size(64, 23);
            this.txtMeterReader.TabIndex = 76;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(613, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 79;
            this.label10.Text = "用户类别：";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(17, 52);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(49, 14);
            this.label43.TabIndex = 77;
            this.label43.Text = "片号：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(298, 79);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 14);
            this.label26.TabIndex = 81;
            this.label26.Text = "户  型：";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(129, 51);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 14);
            this.label25.TabIndex = 83;
            this.label25.Text = "建档类型：";
            // 
            // txtWaterUserCount
            // 
            this.txtWaterUserCount.BackColor = System.Drawing.Color.LightYellow;
            this.txtWaterUserCount.Location = new System.Drawing.Point(354, 18);
            this.txtWaterUserCount.Name = "txtWaterUserCount";
            this.txtWaterUserCount.ReadOnly = true;
            this.txtWaterUserCount.Size = new System.Drawing.Size(64, 23);
            this.txtWaterUserCount.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 85;
            this.label2.Text = "交费方式：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(298, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 14);
            this.label22.TabIndex = 75;
            this.label22.Text = "抄表员：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 87;
            this.label5.Text = "段号：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(127, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 14);
            this.label21.TabIndex = 73;
            this.label21.Text = "小区名称：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(298, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 14);
            this.label20.TabIndex = 70;
            this.label20.Text = "人口数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(439, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 89;
            this.label6.Text = "应抄月份：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 67;
            this.label9.Text = "收 费 员：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(439, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 68;
            this.label7.Text = "地    址：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(611, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 14);
            this.label15.TabIndex = 91;
            this.label15.Text = "用水性质：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 63;
            this.label4.Text = "区号：";
            // 
            // btFold
            // 
            this.btFold.BackColor = System.Drawing.SystemColors.Control;
            this.btFold.Location = new System.Drawing.Point(102, 0);
            this.btFold.Margin = new System.Windows.Forms.Padding(0);
            this.btFold.Name = "btFold";
            this.btFold.Size = new System.Drawing.Size(35, 23);
            this.btFold.TabIndex = 300;
            this.btFold.TabStop = false;
            this.btFold.Text = "<<";
            this.btFold.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btFold.UseVisualStyleBackColor = false;
            this.btFold.Click += new System.EventHandler(this.btFold_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.今天ToolStripMenuItem,
            this.toolStripSeparator4,
            this.本月ToolStripMenuItem,
            this.上月ToolStripMenuItem,
            this.下月ToolStripMenuItem,
            this.toolStripSeparator5,
            this.本年ToolStripMenuItem,
            this.上年ToolStripMenuItem,
            this.toolStripSeparator6,
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(105, 6);
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(105, 6);
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
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(105, 6);
            // 
            // 全部ToolStripMenuItem
            // 
            this.全部ToolStripMenuItem.Name = "全部ToolStripMenuItem";
            this.全部ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.全部ToolStripMenuItem.Text = "全部";
            this.全部ToolStripMenuItem.Click += new System.EventHandler(this.全部ToolStripMenuItem_Click);
            // 
            // frmWaterMeterReadCheck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1008, 579);
            this.Controls.Add(this.btFold);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.trMeterReading);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterMeterReadCheck";
            this.Text = "水费审核";
            this.Load += new System.EventHandler(this.frmModifyWaterUserMesAndWaterMeterMes_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterList)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gpbWaterUserMES.ResumeLayout(false);
            this.gpbWaterUserMES.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trMeterReading;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.Button btFold;
        private System.Windows.Forms.GroupBox gpbWaterUserMES;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCheck;
        private System.Windows.Forms.ToolStripButton toolSelectAll;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ComboBox cmbCommunityS;
        private System.Windows.Forms.ComboBox cmbDuanNOS;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.ComboBox cmbAreaNOS;
        private System.Windows.Forms.ComboBox cmbPianNOS;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFilterSearch;
        private System.Windows.Forms.Label labRecordCount;
        private System.Windows.Forms.TextBox txtWaterMeterType;
        private System.Windows.Forms.TextBox txtAreaNO;
        private System.Windows.Forms.TextBox txtWaterUserType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtYearAndMonth;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtWaterUserAddress;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtCharger;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtWaterUserCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMeterReader;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtWaterUserHouseType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWaterUserChargetype;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCreateType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCommunity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDuanNO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPianNO;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dgWaterList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ComboBox cmbMeterReaderS;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.CheckBox chkTotalNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btSetMonth;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterLastNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterEndNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalNumberDescribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn avePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterTotalCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge1;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargetype1;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge2;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargetype2;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice3;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge3;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargetype3;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice4;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge4;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargetype4;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice5;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge5;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargetype5;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice6;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge6;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargetype6;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice7;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge7;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargetype7;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice8;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge8;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargetype8;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraTotalCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn readMeterRecordYearAndMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeState;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkState;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn checker;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn pianNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn duanNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMUNITYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserHouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn createType;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserchargeType;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentsign;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankId;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserPeopleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn isSummaryS;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReadingPageNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn avePriceDescribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn trapezoidPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSizeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSizeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterMagnification;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterMaxRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterIsSummaryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERFIXVALUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsReverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn readMeterRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAcountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 今天ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 本月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 本年ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上年ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 全部ToolStripMenuItem;
    }
}
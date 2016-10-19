namespace WATERFEEMANAGE
{
    partial class frmWaterFeeInformPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterFeeInformPrint));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.trMeterReading = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tb2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labTip = new System.Windows.Forms.Label();
            this.labUserCount = new System.Windows.Forms.Label();
            this.grbSearch = new System.Windows.Forms.GroupBox();
            this.chkHSL = new System.Windows.Forms.CheckBox();
            this.labCondition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartRow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInformNO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbChargerS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArearageLess = new System.Windows.Forms.TextBox();
            this.txtArearageGreater = new System.Windows.Forms.TextBox();
            this.cmbDuanNOS = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbPianNOS = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbAreaNOS = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btCharge = new System.Windows.Forms.Button();
            this.chkArearageLess = new System.Windows.Forms.CheckBox();
            this.chkArearageGreater = new System.Windows.Forms.CheckBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.txtWaterUserNameSearch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.cmbMeterReaderS = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labProgress = new System.Windows.Forms.Label();
            this.prb = new System.Windows.Forms.ProgressBar();
            this.dgWaterUser = new System.Windows.Forms.DataGridView();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEndRow = new System.Windows.Forms.TextBox();
            this.dtpMonthSearch = new System.Windows.Forms.DateTimePicker();
            this.waterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pianNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duanNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prestore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTALFEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERAREARAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordernumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTelphoneNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserHouseTypeS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentsign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb1.SuspendLayout();
            this.tb2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterUser)).BeginInit();
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
            this.tb1.Size = new System.Drawing.Size(988, 596);
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
            this.tb2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 819F));
            this.tb2.Controls.Add(this.panel1, 0, 2);
            this.tb2.Controls.Add(this.grbSearch, 0, 0);
            this.tb2.Controls.Add(this.groupBox2, 0, 1);
            this.tb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb2.Location = new System.Drawing.Point(166, 3);
            this.tb2.Name = "tb2";
            this.tb2.RowCount = 3;
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tb2.Size = new System.Drawing.Size(819, 590);
            this.tb2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labTip);
            this.panel1.Controls.Add(this.labUserCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(3, 548);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 39);
            this.panel1.TabIndex = 904;
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.Location = new System.Drawing.Point(8, 13);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(98, 15);
            this.labTip.TabIndex = 902;
            this.labTip.Text = "本次查询:0户";
            // 
            // labUserCount
            // 
            this.labUserCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labUserCount.AutoSize = true;
            this.labUserCount.BackColor = System.Drawing.Color.Transparent;
            this.labUserCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labUserCount.Location = new System.Drawing.Point(243, 16);
            this.labUserCount.Name = "labUserCount";
            this.labUserCount.Size = new System.Drawing.Size(0, 12);
            this.labUserCount.TabIndex = 61;
            // 
            // grbSearch
            // 
            this.grbSearch.BackColor = System.Drawing.Color.LimeGreen;
            this.grbSearch.Controls.Add(this.dtpMonthSearch);
            this.grbSearch.Controls.Add(this.txtEndRow);
            this.grbSearch.Controls.Add(this.label6);
            this.grbSearch.Controls.Add(this.cmbDuanNOS);
            this.grbSearch.Controls.Add(this.dtpMonth);
            this.grbSearch.Controls.Add(this.label5);
            this.grbSearch.Controls.Add(this.chkHSL);
            this.grbSearch.Controls.Add(this.labCondition);
            this.grbSearch.Controls.Add(this.label1);
            this.grbSearch.Controls.Add(this.txtStartRow);
            this.grbSearch.Controls.Add(this.label4);
            this.grbSearch.Controls.Add(this.txtInformNO);
            this.grbSearch.Controls.Add(this.label3);
            this.grbSearch.Controls.Add(this.cmbChargerS);
            this.grbSearch.Controls.Add(this.label2);
            this.grbSearch.Controls.Add(this.txtArearageLess);
            this.grbSearch.Controls.Add(this.txtArearageGreater);
            this.grbSearch.Controls.Add(this.label35);
            this.grbSearch.Controls.Add(this.cmbPianNOS);
            this.grbSearch.Controls.Add(this.label21);
            this.grbSearch.Controls.Add(this.cmbAreaNOS);
            this.grbSearch.Controls.Add(this.label9);
            this.grbSearch.Controls.Add(this.btCharge);
            this.grbSearch.Controls.Add(this.chkArearageLess);
            this.grbSearch.Controls.Add(this.chkArearageGreater);
            this.grbSearch.Controls.Add(this.btSearch);
            this.grbSearch.Controls.Add(this.txtWaterUserNameSearch);
            this.grbSearch.Controls.Add(this.label41);
            this.grbSearch.Controls.Add(this.txtWaterUserNOSearch);
            this.grbSearch.Controls.Add(this.label40);
            this.grbSearch.Controls.Add(this.cmbMeterReaderS);
            this.grbSearch.Controls.Add(this.label36);
            this.grbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbSearch.Location = new System.Drawing.Point(3, 3);
            this.grbSearch.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(813, 114);
            this.grbSearch.TabIndex = 60;
            this.grbSearch.TabStop = false;
            this.grbSearch.Tag = "9999";
            this.grbSearch.Text = "查询条件";
            // 
            // chkHSL
            // 
            this.chkHSL.AutoSize = true;
            this.chkHSL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkHSL.Location = new System.Drawing.Point(554, 52);
            this.chkHSL.Name = "chkHSL";
            this.chkHSL.Size = new System.Drawing.Size(82, 18);
            this.chkHSL.TabIndex = 98;
            this.chkHSL.Text = "发生水量";
            this.chkHSL.UseVisualStyleBackColor = true;
            // 
            // labCondition
            // 
            this.labCondition.AutoSize = true;
            this.labCondition.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCondition.ForeColor = System.Drawing.Color.Red;
            this.labCondition.Location = new System.Drawing.Point(669, 86);
            this.labCondition.Name = "labCondition";
            this.labCondition.Size = new System.Drawing.Size(0, 16);
            this.labCondition.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(543, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 14);
            this.label1.TabIndex = 97;
            this.label1.Text = "当前设定提示余额:";
            // 
            // txtStartRow
            // 
            this.txtStartRow.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartRow.Location = new System.Drawing.Point(420, 79);
            this.txtStartRow.Name = "txtStartRow";
            this.txtStartRow.Size = new System.Drawing.Size(45, 26);
            this.txtStartRow.TabIndex = 77;
            this.txtStartRow.Text = "1";
            this.txtStartRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRowNO_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(351, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 96;
            this.label4.Text = "起始行号：";
            // 
            // txtInformNO
            // 
            this.txtInformNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtInformNO.Location = new System.Drawing.Point(270, 79);
            this.txtInformNO.Name = "txtInformNO";
            this.txtInformNO.Size = new System.Drawing.Size(75, 26);
            this.txtInformNO.TabIndex = 77;
            this.txtInformNO.Text = "09876543";
            this.txtInformNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRowNO_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(202, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 96;
            this.label3.Text = "通知单号：";
            // 
            // cmbChargerS
            // 
            this.cmbChargerS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbChargerS.FormattingEnabled = true;
            this.cmbChargerS.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.cmbChargerS.Location = new System.Drawing.Point(240, 49);
            this.cmbChargerS.Name = "cmbChargerS";
            this.cmbChargerS.Size = new System.Drawing.Size(88, 22);
            this.cmbChargerS.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(173, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 94;
            this.label2.Text = "收 费 员:";
            // 
            // txtArearageLess
            // 
            this.txtArearageLess.BackColor = System.Drawing.SystemColors.Window;
            this.txtArearageLess.Location = new System.Drawing.Point(420, 46);
            this.txtArearageLess.Name = "txtArearageLess";
            this.txtArearageLess.Size = new System.Drawing.Size(77, 26);
            this.txtArearageLess.TabIndex = 92;
            this.txtArearageLess.Text = "0";
            this.txtArearageLess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtArearageGreater
            // 
            this.txtArearageGreater.BackColor = System.Drawing.SystemColors.Window;
            this.txtArearageGreater.Location = new System.Drawing.Point(791, 78);
            this.txtArearageGreater.Name = "txtArearageGreater";
            this.txtArearageGreater.Size = new System.Drawing.Size(16, 26);
            this.txtArearageGreater.TabIndex = 92;
            this.txtArearageGreater.Text = "0";
            this.txtArearageGreater.Visible = false;
            this.txtArearageGreater.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // cmbDuanNOS
            // 
            this.cmbDuanNOS.DropDownWidth = 120;
            this.cmbDuanNOS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDuanNOS.FormattingEnabled = true;
            this.cmbDuanNOS.Location = new System.Drawing.Point(709, 19);
            this.cmbDuanNOS.Name = "cmbDuanNOS";
            this.cmbDuanNOS.Size = new System.Drawing.Size(77, 22);
            this.cmbDuanNOS.TabIndex = 91;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(642, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(70, 14);
            this.label35.TabIndex = 90;
            this.label35.Text = "段    号:";
            // 
            // cmbPianNOS
            // 
            this.cmbPianNOS.DropDownWidth = 120;
            this.cmbPianNOS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbPianNOS.FormattingEnabled = true;
            this.cmbPianNOS.Location = new System.Drawing.Point(420, 19);
            this.cmbPianNOS.Name = "cmbPianNOS";
            this.cmbPianNOS.Size = new System.Drawing.Size(77, 22);
            this.cmbPianNOS.TabIndex = 89;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(351, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 14);
            this.label21.TabIndex = 88;
            this.label21.Text = "片    号：";
            // 
            // cmbAreaNOS
            // 
            this.cmbAreaNOS.DropDownWidth = 120;
            this.cmbAreaNOS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbAreaNOS.FormattingEnabled = true;
            this.cmbAreaNOS.Location = new System.Drawing.Point(551, 19);
            this.cmbAreaNOS.Name = "cmbAreaNOS";
            this.cmbAreaNOS.Size = new System.Drawing.Size(77, 22);
            this.cmbAreaNOS.TabIndex = 87;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(511, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 86;
            this.label9.Text = "区号：";
            // 
            // btCharge
            // 
            this.btCharge.Enabled = false;
            this.btCharge.Location = new System.Drawing.Point(98, 78);
            this.btCharge.Name = "btCharge";
            this.btCharge.Size = new System.Drawing.Size(100, 29);
            this.btCharge.TabIndex = 75;
            this.btCharge.Tag = "9999";
            this.btCharge.Text = "打印通知单";
            this.btCharge.UseVisualStyleBackColor = false;
            this.btCharge.Click += new System.EventHandler(this.btCharge_Click);
            // 
            // chkArearageLess
            // 
            this.chkArearageLess.AutoSize = true;
            this.chkArearageLess.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkArearageLess.Location = new System.Drawing.Point(339, 52);
            this.chkArearageLess.Name = "chkArearageLess";
            this.chkArearageLess.Size = new System.Drawing.Size(89, 18);
            this.chkArearageLess.TabIndex = 74;
            this.chkArearageLess.Text = "结算余额<";
            this.chkArearageLess.UseVisualStyleBackColor = true;
            // 
            // chkArearageGreater
            // 
            this.chkArearageGreater.AutoSize = true;
            this.chkArearageGreater.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkArearageGreater.Location = new System.Drawing.Point(732, 83);
            this.chkArearageGreater.Name = "chkArearageGreater";
            this.chkArearageGreater.Size = new System.Drawing.Size(75, 18);
            this.chkArearageGreater.TabIndex = 74;
            this.chkArearageGreater.Text = "欠费≥:";
            this.chkArearageGreater.UseVisualStyleBackColor = true;
            this.chkArearageGreater.Visible = false;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(11, 78);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(62, 29);
            this.btSearch.TabIndex = 73;
            this.btSearch.Tag = "9999";
            this.btSearch.Text = "查询";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txtWaterUserNameSearch
            // 
            this.txtWaterUserNameSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNameSearch.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWaterUserNameSearch.Location = new System.Drawing.Point(240, 19);
            this.txtWaterUserNameSearch.Name = "txtWaterUserNameSearch";
            this.txtWaterUserNameSearch.Size = new System.Drawing.Size(88, 23);
            this.txtWaterUserNameSearch.TabIndex = 66;
            this.txtWaterUserNameSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.Location = new System.Drawing.Point(173, 24);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(70, 14);
            this.label41.TabIndex = 65;
            this.label41.Text = "用户名称:";
            // 
            // txtWaterUserNOSearch
            // 
            this.txtWaterUserNOSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNOSearch.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWaterUserNOSearch.Location = new System.Drawing.Point(75, 19);
            this.txtWaterUserNOSearch.Name = "txtWaterUserNOSearch";
            this.txtWaterUserNOSearch.Size = new System.Drawing.Size(88, 23);
            this.txtWaterUserNOSearch.TabIndex = 64;
            this.txtWaterUserNOSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(8, 24);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(70, 14);
            this.label40.TabIndex = 63;
            this.label40.Text = "用户编号:";
            // 
            // cmbMeterReaderS
            // 
            this.cmbMeterReaderS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMeterReaderS.FormattingEnabled = true;
            this.cmbMeterReaderS.Location = new System.Drawing.Point(75, 49);
            this.cmbMeterReaderS.Name = "cmbMeterReaderS";
            this.cmbMeterReaderS.Size = new System.Drawing.Size(88, 22);
            this.cmbMeterReaderS.TabIndex = 46;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(8, 53);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(70, 14);
            this.label36.TabIndex = 47;
            this.label36.Text = "抄 表 员:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labProgress);
            this.groupBox2.Controls.Add(this.prb);
            this.groupBox2.Controls.Add(this.dgWaterUser);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(813, 415);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户列表";
            // 
            // labProgress
            // 
            this.labProgress.AutoSize = true;
            this.labProgress.BackColor = System.Drawing.Color.Transparent;
            this.labProgress.Location = new System.Drawing.Point(293, 6);
            this.labProgress.Name = "labProgress";
            this.labProgress.Size = new System.Drawing.Size(72, 16);
            this.labProgress.TabIndex = 74;
            this.labProgress.Tag = "9999";
            this.labProgress.Text = "进度:0/0";
            // 
            // prb
            // 
            this.prb.Location = new System.Drawing.Point(100, 1);
            this.prb.Name = "prb";
            this.prb.Size = new System.Drawing.Size(499, 23);
            this.prb.TabIndex = 73;
            // 
            // dgWaterUser
            // 
            this.dgWaterUser.AllowUserToAddRows = false;
            this.dgWaterUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWaterUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWaterUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWaterUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.waterUserNO,
            this.waterUserName,
            this.areaNO,
            this.pianNO,
            this.duanNO,
            this.prestore,
            this.TOTALFEE,
            this.USERAREARAGE,
            this.ordernumber,
            this.waterUserAddress,
            this.waterUserTelphoneNO,
            this.meterReaderID,
            this.meterReaderName,
            this.waterUserTypeName,
            this.waterUserHouseTypeS,
            this.agentsign,
            this.waterUserId});
            this.dgWaterUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWaterUser.Location = new System.Drawing.Point(3, 22);
            this.dgWaterUser.MultiSelect = false;
            this.dgWaterUser.Name = "dgWaterUser";
            this.dgWaterUser.ReadOnly = true;
            this.dgWaterUser.RowHeadersWidth = 35;
            this.dgWaterUser.RowTemplate.Height = 23;
            this.dgWaterUser.Size = new System.Drawing.Size(807, 390);
            this.dgWaterUser.TabIndex = 61;
            this.dgWaterUser.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgWaterUser_CellPainting);
            // 
            // bgWork
            // 
            this.bgWork.WorkerSupportsCancellation = true;
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            this.bgWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWork_RunWorkerCompleted);
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "yyyy-MM";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(709, 46);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(86, 26);
            this.dtpMonth.TabIndex = 123;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(642, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 124;
            this.label5.Text = "水费月份:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(466, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 125;
            this.label6.Text = "至";
            // 
            // txtEndRow
            // 
            this.txtEndRow.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndRow.Location = new System.Drawing.Point(488, 79);
            this.txtEndRow.Name = "txtEndRow";
            this.txtEndRow.Size = new System.Drawing.Size(45, 26);
            this.txtEndRow.TabIndex = 126;
            this.txtEndRow.Text = "1";
            // 
            // dtpMonthSearch
            // 
            this.dtpMonthSearch.CustomFormat = "yyyy-MM";
            this.dtpMonthSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthSearch.Location = new System.Drawing.Point(780, 24);
            this.dtpMonthSearch.Name = "dtpMonthSearch";
            this.dtpMonthSearch.ShowUpDown = true;
            this.dtpMonthSearch.Size = new System.Drawing.Size(27, 26);
            this.dtpMonthSearch.TabIndex = 127;
            this.dtpMonthSearch.Visible = false;
            // 
            // waterUserNO
            // 
            this.waterUserNO.DataPropertyName = "waterUserNO";
            this.waterUserNO.HeaderText = "用户号";
            this.waterUserNO.Name = "waterUserNO";
            this.waterUserNO.ReadOnly = true;
            this.waterUserNO.Width = 81;
            // 
            // waterUserName
            // 
            this.waterUserName.DataPropertyName = "waterUserName";
            this.waterUserName.HeaderText = "用户名称";
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.ReadOnly = true;
            this.waterUserName.Width = 97;
            // 
            // areaNO
            // 
            this.areaNO.DataPropertyName = "areaNO";
            this.areaNO.HeaderText = "区号";
            this.areaNO.Name = "areaNO";
            this.areaNO.ReadOnly = true;
            this.areaNO.Width = 65;
            // 
            // pianNO
            // 
            this.pianNO.DataPropertyName = "pianNO";
            this.pianNO.HeaderText = "片号";
            this.pianNO.Name = "pianNO";
            this.pianNO.ReadOnly = true;
            this.pianNO.Width = 65;
            // 
            // duanNO
            // 
            this.duanNO.DataPropertyName = "duanNO";
            this.duanNO.HeaderText = "段号";
            this.duanNO.Name = "duanNO";
            this.duanNO.ReadOnly = true;
            this.duanNO.Width = 65;
            // 
            // prestore
            // 
            this.prestore.DataPropertyName = "prestore";
            this.prestore.HeaderText = "账户余额";
            this.prestore.Name = "prestore";
            this.prestore.ReadOnly = true;
            this.prestore.Width = 97;
            // 
            // TOTALFEE
            // 
            this.TOTALFEE.DataPropertyName = "TOTALFEE";
            this.TOTALFEE.HeaderText = "欠费总计";
            this.TOTALFEE.Name = "TOTALFEE";
            this.TOTALFEE.ReadOnly = true;
            this.TOTALFEE.Width = 97;
            // 
            // USERAREARAGE
            // 
            this.USERAREARAGE.DataPropertyName = "USERAREARAGE";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.USERAREARAGE.DefaultCellStyle = dataGridViewCellStyle2;
            this.USERAREARAGE.HeaderText = "结算余额";
            this.USERAREARAGE.Name = "USERAREARAGE";
            this.USERAREARAGE.ReadOnly = true;
            this.USERAREARAGE.Width = 97;
            // 
            // ordernumber
            // 
            this.ordernumber.DataPropertyName = "ordernumber";
            this.ordernumber.HeaderText = "顺序号";
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.ReadOnly = true;
            this.ordernumber.Width = 81;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.HeaderText = "地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            this.waterUserAddress.Width = 200;
            // 
            // waterUserTelphoneNO
            // 
            this.waterUserTelphoneNO.DataPropertyName = "waterUserTelphoneNO";
            this.waterUserTelphoneNO.HeaderText = "联系方式";
            this.waterUserTelphoneNO.Name = "waterUserTelphoneNO";
            this.waterUserTelphoneNO.ReadOnly = true;
            this.waterUserTelphoneNO.Width = 110;
            // 
            // meterReaderID
            // 
            this.meterReaderID.DataPropertyName = "meterReaderID";
            this.meterReaderID.HeaderText = "meterReaderID";
            this.meterReaderID.Name = "meterReaderID";
            this.meterReaderID.ReadOnly = true;
            this.meterReaderID.Visible = false;
            // 
            // meterReaderName
            // 
            this.meterReaderName.DataPropertyName = "meterReaderName";
            this.meterReaderName.HeaderText = "抄表员";
            this.meterReaderName.Name = "meterReaderName";
            this.meterReaderName.ReadOnly = true;
            this.meterReaderName.Width = 81;
            // 
            // waterUserTypeName
            // 
            this.waterUserTypeName.DataPropertyName = "waterUserTypeName";
            this.waterUserTypeName.HeaderText = "用户类别";
            this.waterUserTypeName.Name = "waterUserTypeName";
            this.waterUserTypeName.ReadOnly = true;
            this.waterUserTypeName.Width = 97;
            // 
            // waterUserHouseTypeS
            // 
            this.waterUserHouseTypeS.DataPropertyName = "waterUserHouseTypeS";
            this.waterUserHouseTypeS.HeaderText = "户型";
            this.waterUserHouseTypeS.Name = "waterUserHouseTypeS";
            this.waterUserHouseTypeS.ReadOnly = true;
            this.waterUserHouseTypeS.Width = 65;
            // 
            // agentsign
            // 
            this.agentsign.DataPropertyName = "agentsignS";
            this.agentsign.HeaderText = "银行托收";
            this.agentsign.Name = "agentsign";
            this.agentsign.ReadOnly = true;
            this.agentsign.Width = 97;
            // 
            // waterUserId
            // 
            this.waterUserId.DataPropertyName = "waterUserId";
            this.waterUserId.HeaderText = "waterUserId";
            this.waterUserId.Name = "waterUserId";
            this.waterUserId.ReadOnly = true;
            this.waterUserId.Visible = false;
            this.waterUserId.Width = 121;
            // 
            // frmWaterFeeInformPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 616);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterFeeInformPrint";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "水费通知单打印";
            this.Load += new System.EventHandler(this.frmWaterUserPrestoreInitial_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrestoreWaterUserManualCharge_FormClosing);
            this.tb1.ResumeLayout(false);
            this.tb2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbSearch.ResumeLayout(false);
            this.grbSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.TreeView trMeterReading;
        private System.Windows.Forms.TableLayoutPanel tb2;
        private System.Windows.Forms.GroupBox grbSearch;
        private System.Windows.Forms.TextBox txtWaterUserNameSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cmbMeterReaderS;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgWaterUser;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labUserCount;
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.Button btCharge;
        private System.Windows.Forms.TextBox txtInformNO;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.Label labProgress;
        private System.Windows.Forms.ProgressBar prb;
        private System.Windows.Forms.ComboBox cmbDuanNOS;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbPianNOS;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbAreaNOS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkArearageGreater;
        private System.Windows.Forms.TextBox txtArearageGreater;
        private System.Windows.Forms.TextBox txtArearageLess;
        private System.Windows.Forms.CheckBox chkArearageLess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbChargerS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labCondition;
        private System.Windows.Forms.CheckBox chkHSL;
        private System.Windows.Forms.TextBox txtStartRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpMonthSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn pianNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn duanNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn prestore;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTALFEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERAREARAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTelphoneNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserHouseTypeS;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentsign;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserId;

    }
}
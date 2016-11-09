namespace STATISTIALREPORTS
{
    partial class frmWaterUserStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterUserStatistics));
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExcel = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSetMonth = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.chkSumAndSubMeter = new System.Windows.Forms.CheckBox();
            this.chkSumAndSubMeterState = new System.Windows.Forms.CheckBox();
            this.chkIsReserve = new System.Windows.Forms.CheckBox();
            this.chkCommunity = new System.Windows.Forms.CheckBox();
            this.chkWaterMeterPosition = new System.Windows.Forms.CheckBox();
            this.chkWaterMeterTypeClass = new System.Windows.Forms.CheckBox();
            this.chkWaterMeterState = new System.Windows.Forms.CheckBox();
            this.chkDuanNO = new System.Windows.Forms.CheckBox();
            this.chkAreaNO = new System.Windows.Forms.CheckBox();
            this.chkPianNO = new System.Windows.Forms.CheckBox();
            this.chkWaterUserType = new System.Windows.Forms.CheckBox();
            this.chkWaterMeterType = new System.Windows.Forms.CheckBox();
            this.chkCreateDate = new System.Windows.Forms.CheckBox();
            this.chkCharger = new System.Windows.Forms.CheckBox();
            this.chkMeterReader = new System.Windows.Forms.CheckBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.cmbAreaNOS = new System.Windows.Forms.ComboBox();
            this.cmbDuanNOS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPianNOS = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMeterReader = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.btSenior = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkDateTime = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
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
            this.toolStripWaterUser.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripWaterUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWaterUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolStripSeparator6,
            this.toolExcel});
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
            // toolExcel
            // 
            this.toolExcel.Enabled = false;
            this.toolExcel.Image = global::STATISTIALREPORTS.Properties.Resources.snap_undo;
            this.toolExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExcel.Name = "toolExcel";
            this.toolExcel.Size = new System.Drawing.Size(97, 22);
            this.toolExcel.Text = "导出Excel";
            this.toolExcel.Click += new System.EventHandler(this.toolExcel_Click);
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.btSetMonth);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.chkSumAndSubMeter);
            this.groupBox1.Controls.Add(this.chkSumAndSubMeterState);
            this.groupBox1.Controls.Add(this.chkIsReserve);
            this.groupBox1.Controls.Add(this.chkCommunity);
            this.groupBox1.Controls.Add(this.chkWaterMeterPosition);
            this.groupBox1.Controls.Add(this.chkWaterMeterTypeClass);
            this.groupBox1.Controls.Add(this.chkWaterMeterState);
            this.groupBox1.Controls.Add(this.chkDuanNO);
            this.groupBox1.Controls.Add(this.chkAreaNO);
            this.groupBox1.Controls.Add(this.chkPianNO);
            this.groupBox1.Controls.Add(this.chkWaterUserType);
            this.groupBox1.Controls.Add(this.chkWaterMeterType);
            this.groupBox1.Controls.Add(this.chkCreateDate);
            this.groupBox1.Controls.Add(this.chkCharger);
            this.groupBox1.Controls.Add(this.chkMeterReader);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbWaterMeterType);
            this.groupBox1.Controls.Add(this.label56);
            this.groupBox1.Controls.Add(this.cmbAreaNOS);
            this.groupBox1.Controls.Add(this.cmbDuanNOS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPianNOS);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbMeterReader);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSenior);
            this.groupBox1.Controls.Add(this.btSenior);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkDateTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 141);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "查询条件";
            // 
            // btSetMonth
            // 
            this.btSetMonth.BackgroundImage = global::STATISTIALREPORTS.Properties.Resources.onebit_20;
            this.btSetMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetMonth.Location = new System.Drawing.Point(725, 55);
            this.btSetMonth.Name = "btSetMonth";
            this.btSetMonth.Size = new System.Drawing.Size(22, 23);
            this.btSetMonth.TabIndex = 214;
            this.btSetMonth.UseVisualStyleBackColor = true;
            this.btSetMonth.Click += new System.EventHandler(this.btSetMonth_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(620, 53);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(102, 26);
            this.dtpEnd.TabIndex = 111;
            // 
            // chkSumAndSubMeter
            // 
            this.chkSumAndSubMeter.AutoSize = true;
            this.chkSumAndSubMeter.Location = new System.Drawing.Point(304, 114);
            this.chkSumAndSubMeter.Name = "chkSumAndSubMeter";
            this.chkSumAndSubMeter.Size = new System.Drawing.Size(75, 20);
            this.chkSumAndSubMeter.TabIndex = 213;
            this.chkSumAndSubMeter.Tag = "METERREADERID,METERREADERNAME";
            this.chkSumAndSubMeter.Text = "总分表";
            this.chkSumAndSubMeter.UseVisualStyleBackColor = true;
            // 
            // chkSumAndSubMeterState
            // 
            this.chkSumAndSubMeterState.AutoSize = true;
            this.chkSumAndSubMeterState.Location = new System.Drawing.Point(191, 114);
            this.chkSumAndSubMeterState.Name = "chkSumAndSubMeterState";
            this.chkSumAndSubMeterState.Size = new System.Drawing.Size(107, 20);
            this.chkSumAndSubMeterState.TabIndex = 212;
            this.chkSumAndSubMeterState.Tag = "METERREADERID,METERREADERNAME";
            this.chkSumAndSubMeterState.Text = "总分表状态";
            this.chkSumAndSubMeterState.UseVisualStyleBackColor = true;
            // 
            // chkIsReserve
            // 
            this.chkIsReserve.AutoSize = true;
            this.chkIsReserve.Location = new System.Drawing.Point(98, 115);
            this.chkIsReserve.Name = "chkIsReserve";
            this.chkIsReserve.Size = new System.Drawing.Size(91, 20);
            this.chkIsReserve.TabIndex = 211;
            this.chkIsReserve.Tag = "METERREADERID,METERREADERNAME";
            this.chkIsReserve.Text = "倒装状态";
            this.chkIsReserve.UseVisualStyleBackColor = true;
            // 
            // chkCommunity
            // 
            this.chkCommunity.AutoSize = true;
            this.chkCommunity.Location = new System.Drawing.Point(17, 115);
            this.chkCommunity.Name = "chkCommunity";
            this.chkCommunity.Size = new System.Drawing.Size(59, 20);
            this.chkCommunity.TabIndex = 210;
            this.chkCommunity.Tag = "METERREADERID,METERREADERNAME";
            this.chkCommunity.Text = "小区";
            this.chkCommunity.UseVisualStyleBackColor = true;
            // 
            // chkWaterMeterPosition
            // 
            this.chkWaterMeterPosition.AutoSize = true;
            this.chkWaterMeterPosition.Location = new System.Drawing.Point(892, 88);
            this.chkWaterMeterPosition.Name = "chkWaterMeterPosition";
            this.chkWaterMeterPosition.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterPosition.TabIndex = 209;
            this.chkWaterMeterPosition.Text = "水表位置";
            this.chkWaterMeterPosition.UseVisualStyleBackColor = true;
            // 
            // chkWaterMeterTypeClass
            // 
            this.chkWaterMeterTypeClass.AutoSize = true;
            this.chkWaterMeterTypeClass.Location = new System.Drawing.Point(389, 88);
            this.chkWaterMeterTypeClass.Name = "chkWaterMeterTypeClass";
            this.chkWaterMeterTypeClass.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterTypeClass.TabIndex = 208;
            this.chkWaterMeterTypeClass.Tag = "WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME";
            this.chkWaterMeterTypeClass.Text = "用水分类";
            this.chkWaterMeterTypeClass.UseVisualStyleBackColor = true;
            // 
            // chkWaterMeterState
            // 
            this.chkWaterMeterState.AutoSize = true;
            this.chkWaterMeterState.Location = new System.Drawing.Point(798, 88);
            this.chkWaterMeterState.Name = "chkWaterMeterState";
            this.chkWaterMeterState.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterState.TabIndex = 205;
            this.chkWaterMeterState.Text = "水表状态";
            this.chkWaterMeterState.UseVisualStyleBackColor = true;
            // 
            // chkDuanNO
            // 
            this.chkDuanNO.AutoSize = true;
            this.chkDuanNO.Location = new System.Drawing.Point(729, 88);
            this.chkDuanNO.Name = "chkDuanNO";
            this.chkDuanNO.Size = new System.Drawing.Size(59, 20);
            this.chkDuanNO.TabIndex = 204;
            this.chkDuanNO.Tag = "duanNO";
            this.chkDuanNO.Text = "段号";
            this.chkDuanNO.UseVisualStyleBackColor = true;
            // 
            // chkAreaNO
            // 
            this.chkAreaNO.AutoSize = true;
            this.chkAreaNO.Location = new System.Drawing.Point(660, 88);
            this.chkAreaNO.Name = "chkAreaNO";
            this.chkAreaNO.Size = new System.Drawing.Size(59, 20);
            this.chkAreaNO.TabIndex = 207;
            this.chkAreaNO.Tag = "areaNO";
            this.chkAreaNO.Text = "区号";
            this.chkAreaNO.UseVisualStyleBackColor = true;
            // 
            // chkPianNO
            // 
            this.chkPianNO.AutoSize = true;
            this.chkPianNO.Location = new System.Drawing.Point(591, 88);
            this.chkPianNO.Name = "chkPianNO";
            this.chkPianNO.Size = new System.Drawing.Size(59, 20);
            this.chkPianNO.TabIndex = 206;
            this.chkPianNO.Tag = "pianNO";
            this.chkPianNO.Text = "片号";
            this.chkPianNO.UseVisualStyleBackColor = true;
            // 
            // chkWaterUserType
            // 
            this.chkWaterUserType.AutoSize = true;
            this.chkWaterUserType.Location = new System.Drawing.Point(490, 88);
            this.chkWaterUserType.Name = "chkWaterUserType";
            this.chkWaterUserType.Size = new System.Drawing.Size(91, 20);
            this.chkWaterUserType.TabIndex = 203;
            this.chkWaterUserType.Tag = "waterUserTypeId,waterUserTypeName";
            this.chkWaterUserType.Text = "用户类别";
            this.chkWaterUserType.UseVisualStyleBackColor = true;
            // 
            // chkWaterMeterType
            // 
            this.chkWaterMeterType.AutoSize = true;
            this.chkWaterMeterType.Location = new System.Drawing.Point(288, 88);
            this.chkWaterMeterType.Name = "chkWaterMeterType";
            this.chkWaterMeterType.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterType.TabIndex = 199;
            this.chkWaterMeterType.Tag = "WATERMETERTYPEID,waterMeterTypeName";
            this.chkWaterMeterType.Text = "用水性质";
            this.chkWaterMeterType.UseVisualStyleBackColor = true;
            // 
            // chkCreateDate
            // 
            this.chkCreateDate.AutoSize = true;
            this.chkCreateDate.Location = new System.Drawing.Point(191, 88);
            this.chkCreateDate.Name = "chkCreateDate";
            this.chkCreateDate.Size = new System.Drawing.Size(91, 20);
            this.chkCreateDate.TabIndex = 198;
            this.chkCreateDate.Tag = "readMeterRecordYearAndMonth";
            this.chkCreateDate.Text = "建档日期";
            this.chkCreateDate.UseVisualStyleBackColor = true;
            // 
            // chkCharger
            // 
            this.chkCharger.AutoSize = true;
            this.chkCharger.Location = new System.Drawing.Point(98, 88);
            this.chkCharger.Name = "chkCharger";
            this.chkCharger.Size = new System.Drawing.Size(75, 20);
            this.chkCharger.TabIndex = 200;
            this.chkCharger.Tag = "CHARGERID,CHARGERNAME";
            this.chkCharger.Text = "收费员";
            this.chkCharger.UseVisualStyleBackColor = true;
            // 
            // chkMeterReader
            // 
            this.chkMeterReader.AutoSize = true;
            this.chkMeterReader.Location = new System.Drawing.Point(17, 88);
            this.chkMeterReader.Name = "chkMeterReader";
            this.chkMeterReader.Size = new System.Drawing.Size(75, 20);
            this.chkMeterReader.TabIndex = 202;
            this.chkMeterReader.Tag = "METERREADERID,METERREADERNAME";
            this.chkMeterReader.Text = "抄表员";
            this.chkMeterReader.UseVisualStyleBackColor = true;
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.DropDownWidth = 150;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "全部",
            "正常",
            "注销",
            "换表",
            "未启用",
            "欠费停水",
            "违章停水",
            "坏表",
            "待审核",
            "待拆迁"});
            this.cmbState.Location = new System.Drawing.Point(278, 55);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(102, 24);
            this.cmbState.TabIndex = 194;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 197;
            this.label2.Text = "水表状态:";
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownWidth = 150;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Items.AddRange(new object[] {
            "",
            "正常",
            "停水",
            "报废"});
            this.cmbWaterMeterType.Location = new System.Drawing.Point(88, 55);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(102, 24);
            this.cmbWaterMeterType.TabIndex = 195;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(12, 59);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(80, 16);
            this.label56.TabIndex = 196;
            this.label56.Text = "用水性质:";
            // 
            // cmbAreaNOS
            // 
            this.cmbAreaNOS.DropDownWidth = 120;
            this.cmbAreaNOS.FormattingEnabled = true;
            this.cmbAreaNOS.Location = new System.Drawing.Point(438, 24);
            this.cmbAreaNOS.Name = "cmbAreaNOS";
            this.cmbAreaNOS.Size = new System.Drawing.Size(102, 24);
            this.cmbAreaNOS.TabIndex = 189;
            // 
            // cmbDuanNOS
            // 
            this.cmbDuanNOS.DropDownWidth = 120;
            this.cmbDuanNOS.FormattingEnabled = true;
            this.cmbDuanNOS.Location = new System.Drawing.Point(595, 23);
            this.cmbDuanNOS.Name = "cmbDuanNOS";
            this.cmbDuanNOS.Size = new System.Drawing.Size(88, 24);
            this.cmbDuanNOS.TabIndex = 193;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(551, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 192;
            this.label1.Text = "段号:";
            // 
            // cmbPianNOS
            // 
            this.cmbPianNOS.DropDownWidth = 120;
            this.cmbPianNOS.FormattingEnabled = true;
            this.cmbPianNOS.Location = new System.Drawing.Point(278, 23);
            this.cmbPianNOS.Name = "cmbPianNOS";
            this.cmbPianNOS.Size = new System.Drawing.Size(102, 24);
            this.cmbPianNOS.TabIndex = 191;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(201, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 16);
            this.label21.TabIndex = 190;
            this.label21.Text = "片    号:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(394, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 188;
            this.label9.Text = "区号:";
            // 
            // cmbMeterReader
            // 
            this.cmbMeterReader.FormattingEnabled = true;
            this.cmbMeterReader.Location = new System.Drawing.Point(88, 21);
            this.cmbMeterReader.Name = "cmbMeterReader";
            this.cmbMeterReader.Size = new System.Drawing.Size(105, 24);
            this.cmbMeterReader.TabIndex = 186;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 187;
            this.label4.Text = "抄 表 员:";
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.Color.White;
            this.txtSenior.Location = new System.Drawing.Point(810, 22);
            this.txtSenior.Multiline = true;
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(173, 55);
            this.txtSenior.TabIndex = 179;
            // 
            // btSenior
            // 
            this.btSenior.Location = new System.Drawing.Point(758, 20);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(50, 45);
            this.btSenior.TabIndex = 178;
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = true;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(597, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 112;
            this.label3.Text = "至";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(492, 53);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(102, 26);
            this.dtpStart.TabIndex = 110;
            // 
            // chkDateTime
            // 
            this.chkDateTime.AutoSize = true;
            this.chkDateTime.Location = new System.Drawing.Point(398, 57);
            this.chkDateTime.Name = "chkDateTime";
            this.chkDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkDateTime.TabIndex = 109;
            this.chkDateTime.Text = "建档日期:";
            this.chkDateTime.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 380);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计列表";
            // 
            // dgList
            // 
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
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 25;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(996, 355);
            this.dgList.TabIndex = 2;
            this.dgList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellDoubleClick);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgList_DataBindingComplete);
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
            // frmWaterUserStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterUserStatistics";
            this.Text = "用水用户统计";
            this.Load += new System.EventHandler(this.frmWaterUserSearch_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkDateTime;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox cmbAreaNOS;
        private System.Windows.Forms.ComboBox cmbDuanNOS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPianNOS;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMeterReader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkWaterMeterTypeClass;
        private System.Windows.Forms.CheckBox chkWaterMeterState;
        private System.Windows.Forms.CheckBox chkDuanNO;
        private System.Windows.Forms.CheckBox chkAreaNO;
        private System.Windows.Forms.CheckBox chkPianNO;
        private System.Windows.Forms.CheckBox chkWaterUserType;
        private System.Windows.Forms.CheckBox chkWaterMeterType;
        private System.Windows.Forms.CheckBox chkCreateDate;
        private System.Windows.Forms.CheckBox chkCharger;
        private System.Windows.Forms.CheckBox chkMeterReader;
        private System.Windows.Forms.ToolStripButton toolExcel;
        private System.Windows.Forms.CheckBox chkWaterMeterPosition;
        private System.Windows.Forms.CheckBox chkCommunity;
        private System.Windows.Forms.CheckBox chkIsReserve;
        private System.Windows.Forms.CheckBox chkSumAndSubMeterState;
        private System.Windows.Forms.CheckBox chkSumAndSubMeter;
        private System.Windows.Forms.Button btSetMonth;
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
    }
}
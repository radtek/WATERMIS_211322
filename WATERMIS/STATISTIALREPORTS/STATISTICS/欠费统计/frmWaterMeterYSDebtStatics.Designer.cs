namespace STATISTIALREPORTS
{
    partial class frmWaterMeterYSDebtStatics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterYSDebtStatics));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            FastReport.Design.DesignerSettings designerSettings4 = new FastReport.Design.DesignerSettings();
            FastReport.Design.DesignerRestrictions designerRestrictions4 = new FastReport.Design.DesignerRestrictions();
            FastReport.Export.Email.EmailSettings emailSettings4 = new FastReport.Export.Email.EmailSettings();
            FastReport.PreviewSettings previewSettings4 = new FastReport.PreviewSettings();
            FastReport.ReportSettings reportSettings4 = new FastReport.ReportSettings();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolStatics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolExcel = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbChargeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMeterReaderS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartSearch = new System.Windows.Forms.DateTimePicker();
            this.dtpEndSearch = new System.Windows.Forms.DateTimePicker();
            this.cmbIsTotalNumber = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkWaterMeterTypeClass = new System.Windows.Forms.CheckBox();
            this.chkWaterUserState = new System.Windows.Forms.CheckBox();
            this.chkDuanNO = new System.Windows.Forms.CheckBox();
            this.chkAreaNO = new System.Windows.Forms.CheckBox();
            this.chkPianNO = new System.Windows.Forms.CheckBox();
            this.chkWaterUserType = new System.Windows.Forms.CheckBox();
            this.chkWaterMeterType = new System.Windows.Forms.CheckBox();
            this.chkRecordMonth = new System.Windows.Forms.CheckBox();
            this.chkCharger = new System.Windows.Forms.CheckBox();
            this.chkMeterReader = new System.Windows.Forms.CheckBox();
            this.cmbCharger = new System.Windows.Forms.ComboBox();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.btSenior = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.btSetMonth = new System.Windows.Forms.Button();
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
            this.toolStatics,
            this.toolStripSeparator6,
            this.toolPrint,
            this.toolPrintPreview,
            this.toolExcel});
            this.toolStripWaterUser.Location = new System.Drawing.Point(0, 0);
            this.toolStripWaterUser.Name = "toolStripWaterUser";
            this.toolStripWaterUser.Size = new System.Drawing.Size(1021, 25);
            this.toolStripWaterUser.TabIndex = 57;
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolStatics
            // 
            this.toolStatics.Image = global::STATISTIALREPORTS.Properties.Resources.onebit_02;
            this.toolStatics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStatics.Name = "toolStatics";
            this.toolStatics.Size = new System.Drawing.Size(57, 22);
            this.toolStatics.Text = "统计";
            this.toolStatics.Click += new System.EventHandler(this.toolSearch_Click);
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1021, 537);
            this.tb1.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.btSetMonth);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.cmbChargeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbMeterReaderS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpStartSearch);
            this.groupBox1.Controls.Add(this.dtpEndSearch);
            this.groupBox1.Controls.Add(this.cmbIsTotalNumber);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkWaterMeterTypeClass);
            this.groupBox1.Controls.Add(this.chkWaterUserState);
            this.groupBox1.Controls.Add(this.chkDuanNO);
            this.groupBox1.Controls.Add(this.chkAreaNO);
            this.groupBox1.Controls.Add(this.chkPianNO);
            this.groupBox1.Controls.Add(this.chkWaterUserType);
            this.groupBox1.Controls.Add(this.chkWaterMeterType);
            this.groupBox1.Controls.Add(this.chkRecordMonth);
            this.groupBox1.Controls.Add(this.chkCharger);
            this.groupBox1.Controls.Add(this.chkMeterReader);
            this.groupBox1.Controls.Add(this.cmbCharger);
            this.groupBox1.Controls.Add(this.txtSenior);
            this.groupBox1.Controls.Add(this.btSenior);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkChargeDateTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1015, 120);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "统计条件";
            // 
            // cmbChargeType
            // 
            this.cmbChargeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargeType.FormattingEnabled = true;
            this.cmbChargeType.Items.AddRange(new object[] {
            "全部",
            "非预存",
            "预存"});
            this.cmbChargeType.Location = new System.Drawing.Point(454, 54);
            this.cmbChargeType.Name = "cmbChargeType";
            this.cmbChargeType.Size = new System.Drawing.Size(88, 24);
            this.cmbChargeType.TabIndex = 177;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(377, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 178;
            this.label2.Text = "交费方式:";
            // 
            // cmbMeterReaderS
            // 
            this.cmbMeterReaderS.DropDownWidth = 120;
            this.cmbMeterReaderS.FormattingEnabled = true;
            this.cmbMeterReaderS.Location = new System.Drawing.Point(80, 21);
            this.cmbMeterReaderS.Name = "cmbMeterReaderS";
            this.cmbMeterReaderS.Size = new System.Drawing.Size(88, 24);
            this.cmbMeterReaderS.TabIndex = 176;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 175;
            this.label1.Text = "抄表员:";
            // 
            // dtpStartSearch
            // 
            this.dtpStartSearch.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStartSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartSearch.Location = new System.Drawing.Point(891, 85);
            this.dtpStartSearch.Name = "dtpStartSearch";
            this.dtpStartSearch.Size = new System.Drawing.Size(14, 26);
            this.dtpStartSearch.TabIndex = 174;
            this.dtpStartSearch.Visible = false;
            // 
            // dtpEndSearch
            // 
            this.dtpEndSearch.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpEndSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndSearch.Location = new System.Drawing.Point(928, 85);
            this.dtpEndSearch.Name = "dtpEndSearch";
            this.dtpEndSearch.Size = new System.Drawing.Size(14, 26);
            this.dtpEndSearch.TabIndex = 174;
            this.dtpEndSearch.Visible = false;
            // 
            // cmbIsTotalNumber
            // 
            this.cmbIsTotalNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsTotalNumber.FormattingEnabled = true;
            this.cmbIsTotalNumber.Items.AddRange(new object[] {
            "全部",
            "有水量",
            "无水量"});
            this.cmbIsTotalNumber.Location = new System.Drawing.Point(454, 21);
            this.cmbIsTotalNumber.Name = "cmbIsTotalNumber";
            this.cmbIsTotalNumber.Size = new System.Drawing.Size(88, 24);
            this.cmbIsTotalNumber.TabIndex = 172;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 173;
            this.label4.Text = "用水状态:";
            // 
            // chkWaterMeterTypeClass
            // 
            this.chkWaterMeterTypeClass.AutoSize = true;
            this.chkWaterMeterTypeClass.Location = new System.Drawing.Point(385, 91);
            this.chkWaterMeterTypeClass.Name = "chkWaterMeterTypeClass";
            this.chkWaterMeterTypeClass.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterTypeClass.TabIndex = 164;
            this.chkWaterMeterTypeClass.Tag = "WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME";
            this.chkWaterMeterTypeClass.Text = "用水分类";
            this.chkWaterMeterTypeClass.UseVisualStyleBackColor = true;
            // 
            // chkWaterUserState
            // 
            this.chkWaterUserState.AutoSize = true;
            this.chkWaterUserState.Location = new System.Drawing.Point(794, 91);
            this.chkWaterUserState.Name = "chkWaterUserState";
            this.chkWaterUserState.Size = new System.Drawing.Size(91, 20);
            this.chkWaterUserState.TabIndex = 163;
            this.chkWaterUserState.Text = "用户状态";
            this.chkWaterUserState.UseVisualStyleBackColor = true;
            this.chkWaterUserState.Visible = false;
            // 
            // chkDuanNO
            // 
            this.chkDuanNO.AutoSize = true;
            this.chkDuanNO.Location = new System.Drawing.Point(725, 91);
            this.chkDuanNO.Name = "chkDuanNO";
            this.chkDuanNO.Size = new System.Drawing.Size(59, 20);
            this.chkDuanNO.TabIndex = 163;
            this.chkDuanNO.Tag = "duanNO";
            this.chkDuanNO.Text = "段号";
            this.chkDuanNO.UseVisualStyleBackColor = true;
            // 
            // chkAreaNO
            // 
            this.chkAreaNO.AutoSize = true;
            this.chkAreaNO.Location = new System.Drawing.Point(656, 91);
            this.chkAreaNO.Name = "chkAreaNO";
            this.chkAreaNO.Size = new System.Drawing.Size(59, 20);
            this.chkAreaNO.TabIndex = 163;
            this.chkAreaNO.Tag = "areaNO";
            this.chkAreaNO.Text = "区号";
            this.chkAreaNO.UseVisualStyleBackColor = true;
            // 
            // chkPianNO
            // 
            this.chkPianNO.AutoSize = true;
            this.chkPianNO.Location = new System.Drawing.Point(587, 91);
            this.chkPianNO.Name = "chkPianNO";
            this.chkPianNO.Size = new System.Drawing.Size(59, 20);
            this.chkPianNO.TabIndex = 163;
            this.chkPianNO.Tag = "pianNO";
            this.chkPianNO.Text = "片号";
            this.chkPianNO.UseVisualStyleBackColor = true;
            // 
            // chkWaterUserType
            // 
            this.chkWaterUserType.AutoSize = true;
            this.chkWaterUserType.Location = new System.Drawing.Point(486, 91);
            this.chkWaterUserType.Name = "chkWaterUserType";
            this.chkWaterUserType.Size = new System.Drawing.Size(91, 20);
            this.chkWaterUserType.TabIndex = 163;
            this.chkWaterUserType.Tag = "waterUserTypeId,waterUserTypeName";
            this.chkWaterUserType.Text = "用户类别";
            this.chkWaterUserType.UseVisualStyleBackColor = true;
            // 
            // chkWaterMeterType
            // 
            this.chkWaterMeterType.AutoSize = true;
            this.chkWaterMeterType.Location = new System.Drawing.Point(284, 91);
            this.chkWaterMeterType.Name = "chkWaterMeterType";
            this.chkWaterMeterType.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterType.TabIndex = 162;
            this.chkWaterMeterType.Tag = "WATERMETERTYPEID,waterMeterTypeName";
            this.chkWaterMeterType.Text = "用水性质";
            this.chkWaterMeterType.UseVisualStyleBackColor = true;
            // 
            // chkRecordMonth
            // 
            this.chkRecordMonth.AutoSize = true;
            this.chkRecordMonth.Location = new System.Drawing.Point(183, 91);
            this.chkRecordMonth.Name = "chkRecordMonth";
            this.chkRecordMonth.Size = new System.Drawing.Size(91, 20);
            this.chkRecordMonth.TabIndex = 162;
            this.chkRecordMonth.Tag = "readMeterRecordYearAndMonth";
            this.chkRecordMonth.Text = "水费月份";
            this.chkRecordMonth.UseVisualStyleBackColor = true;
            // 
            // chkCharger
            // 
            this.chkCharger.AutoSize = true;
            this.chkCharger.Location = new System.Drawing.Point(98, 91);
            this.chkCharger.Name = "chkCharger";
            this.chkCharger.Size = new System.Drawing.Size(75, 20);
            this.chkCharger.TabIndex = 162;
            this.chkCharger.Tag = "CHARGERID,CHARGERNAME";
            this.chkCharger.Text = "收费员";
            this.chkCharger.UseVisualStyleBackColor = true;
            // 
            // chkMeterReader
            // 
            this.chkMeterReader.AutoSize = true;
            this.chkMeterReader.Location = new System.Drawing.Point(13, 91);
            this.chkMeterReader.Name = "chkMeterReader";
            this.chkMeterReader.Size = new System.Drawing.Size(75, 20);
            this.chkMeterReader.TabIndex = 162;
            this.chkMeterReader.Tag = "METERREADERID,METERREADERNAME";
            this.chkMeterReader.Text = "抄表员";
            this.chkMeterReader.UseVisualStyleBackColor = true;
            // 
            // cmbCharger
            // 
            this.cmbCharger.DropDownWidth = 120;
            this.cmbCharger.FormattingEnabled = true;
            this.cmbCharger.Location = new System.Drawing.Point(264, 20);
            this.cmbCharger.Name = "cmbCharger";
            this.cmbCharger.Size = new System.Drawing.Size(88, 24);
            this.cmbCharger.TabIndex = 160;
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.Color.White;
            this.txtSenior.Location = new System.Drawing.Point(833, 22);
            this.txtSenior.Multiline = true;
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(173, 25);
            this.txtSenior.TabIndex = 142;
            this.txtSenior.Visible = false;
            // 
            // btSenior
            // 
            this.btSenior.Location = new System.Drawing.Point(733, 17);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(94, 35);
            this.btSenior.TabIndex = 141;
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = true;
            this.btSenior.Visible = false;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 124;
            this.label8.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(236, 53);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 123;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(105, 53);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 122;
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Location = new System.Drawing.Point(13, 57);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkChargeDateTime.TabIndex = 121;
            this.chkChargeDateTime.Text = "水费月份:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 120;
            this.label7.Text = "收费员:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1015, 401);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "应收-欠费统计表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 45;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(1009, 376);
            this.dgList.TabIndex = 402;
            this.dgList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellDoubleClick);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgList_DataBindingComplete);
            // 
            // environmentSettings1
            // 
            designerSettings4.ApplicationConnection = null;
            designerSettings4.DefaultFont = new System.Drawing.Font("宋体", 9F);
            designerSettings4.Icon = ((System.Drawing.Icon)(resources.GetObject("designerSettings4.Icon")));
            designerSettings4.Restrictions = designerRestrictions4;
            designerSettings4.Text = "";
            this.environmentSettings1.DesignerSettings = designerSettings4;
            emailSettings4.Address = "";
            emailSettings4.Host = "";
            emailSettings4.MessageTemplate = "";
            emailSettings4.Name = "";
            emailSettings4.Password = "";
            emailSettings4.UserName = "";
            this.environmentSettings1.EmailSettings = emailSettings4;
            previewSettings4.Buttons = ((FastReport.PreviewButtons)(((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save)
                        | FastReport.PreviewButtons.Zoom)
                        | FastReport.PreviewButtons.PageSetup)
                        | FastReport.PreviewButtons.Close)));
            previewSettings4.Icon = ((System.Drawing.Icon)(resources.GetObject("previewSettings4.Icon")));
            previewSettings4.Text = "";
            this.environmentSettings1.PreviewSettings = previewSettings4;
            this.environmentSettings1.ReportSettings = reportSettings4;
            this.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // btSetMonth
            // 
            this.btSetMonth.BackgroundImage = global::STATISTIALREPORTS.Properties.Resources.onebit_20;
            this.btSetMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetMonth.Location = new System.Drawing.Point(342, 55);
            this.btSetMonth.Name = "btSetMonth";
            this.btSetMonth.Size = new System.Drawing.Size(22, 23);
            this.btSetMonth.TabIndex = 180;
            this.btSetMonth.UseVisualStyleBackColor = true;
            this.btSetMonth.Click += new System.EventHandler(this.btSetMonth_Click);
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
            this.今天ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
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
            this.本月ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.本月ToolStripMenuItem.Text = "本月";
            this.本月ToolStripMenuItem.Click += new System.EventHandler(this.本月ToolStripMenuItem_Click);
            // 
            // 上月ToolStripMenuItem
            // 
            this.上月ToolStripMenuItem.Name = "上月ToolStripMenuItem";
            this.上月ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.上月ToolStripMenuItem.Text = "上月";
            this.上月ToolStripMenuItem.Click += new System.EventHandler(this.上月ToolStripMenuItem_Click);
            // 
            // 下月ToolStripMenuItem
            // 
            this.下月ToolStripMenuItem.Name = "下月ToolStripMenuItem";
            this.下月ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
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
            // frmWaterMeterYSDebtStatics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterMeterYSDebtStatics";
            this.Text = "应收欠费统计";
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
        private System.Windows.Forms.ToolStripButton toolStatics;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.ComboBox cmbCharger;
        private System.Windows.Forms.CheckBox chkRecordMonth;
        private System.Windows.Forms.CheckBox chkCharger;
        private System.Windows.Forms.CheckBox chkMeterReader;
        private System.Windows.Forms.CheckBox chkWaterUserType;
        private System.Windows.Forms.CheckBox chkWaterMeterType;
        private System.Windows.Forms.CheckBox chkWaterMeterTypeClass;
        private System.Windows.Forms.CheckBox chkWaterUserState;
        private System.Windows.Forms.CheckBox chkDuanNO;
        private System.Windows.Forms.CheckBox chkAreaNO;
        private System.Windows.Forms.CheckBox chkPianNO;
        private System.Windows.Forms.ComboBox cmbIsTotalNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndSearch;
        private System.Windows.Forms.DateTimePicker dtpStartSearch;
        private System.Windows.Forms.ToolStripButton toolExcel;
        private System.Windows.Forms.ComboBox cmbMeterReaderS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChargeType;
        private System.Windows.Forms.Label label2;
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
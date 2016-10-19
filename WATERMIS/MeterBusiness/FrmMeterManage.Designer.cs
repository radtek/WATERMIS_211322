namespace MeterBusiness
{
    partial class FrmMeterManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMeterManage));
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_waterMeterSerialNumber_2 = new System.Windows.Forms.MaskedTextBox();
            this.TB_waterMeterSerialNumber_1 = new System.Windows.Forms.MaskedTextBox();
            this.CB_waterMeterProduct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DT_waterMeterProofreadingDate_2 = new System.Windows.Forms.DateTimePicker();
            this.DT_waterMeterProofreadingDate_1 = new System.Windows.Forms.DateTimePicker();
            this.CHK_waterMeterProofreadingDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CHK_waterMeterSerialNumber = new System.Windows.Forms.CheckBox();
            this.CB_waterMeterSize = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.CB_MeterState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbInvoiceCancelReason = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Btn_Scrap = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.MeterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateDescribe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSizeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterStartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterProofreadingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeteProofreadingPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STARTUSEDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolEntering = new System.Windows.Forms.ToolStripButton();
            this.toolBatch = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.toolStripWaterUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 144;
            this.label2.Text = "至";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_waterMeterSerialNumber_2);
            this.groupBox1.Controls.Add(this.TB_waterMeterSerialNumber_1);
            this.groupBox1.Controls.Add(this.CB_waterMeterProduct);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DT_waterMeterProofreadingDate_2);
            this.groupBox1.Controls.Add(this.DT_waterMeterProofreadingDate_1);
            this.groupBox1.Controls.Add(this.CHK_waterMeterProofreadingDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CHK_waterMeterSerialNumber);
            this.groupBox1.Controls.Add(this.CB_waterMeterSize);
            this.groupBox1.Controls.Add(this.label56);
            this.groupBox1.Controls.Add(this.CB_MeterState);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1074, 86);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // TB_waterMeterSerialNumber_2
            // 
            this.TB_waterMeterSerialNumber_2.Location = new System.Drawing.Point(579, 18);
            this.TB_waterMeterSerialNumber_2.Name = "TB_waterMeterSerialNumber_2";
            this.TB_waterMeterSerialNumber_2.Size = new System.Drawing.Size(100, 21);
            this.TB_waterMeterSerialNumber_2.TabIndex = 149;
            // 
            // TB_waterMeterSerialNumber_1
            // 
            this.TB_waterMeterSerialNumber_1.Location = new System.Drawing.Point(441, 18);
            this.TB_waterMeterSerialNumber_1.Name = "TB_waterMeterSerialNumber_1";
            this.TB_waterMeterSerialNumber_1.Size = new System.Drawing.Size(100, 21);
            this.TB_waterMeterSerialNumber_1.TabIndex = 148;
            // 
            // CB_waterMeterProduct
            // 
            this.CB_waterMeterProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_waterMeterProduct.FormattingEnabled = true;
            this.CB_waterMeterProduct.Items.AddRange(new object[] {
            "全部",
            "正常",
            "作废"});
            this.CB_waterMeterProduct.Location = new System.Drawing.Point(87, 54);
            this.CB_waterMeterProduct.Name = "CB_waterMeterProduct";
            this.CB_waterMeterProduct.Size = new System.Drawing.Size(120, 20);
            this.CB_waterMeterProduct.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 145;
            this.label3.Text = "水表厂家：";
            // 
            // DT_waterMeterProofreadingDate_2
            // 
            this.DT_waterMeterProofreadingDate_2.CustomFormat = "yyyy-MM-dd";
            this.DT_waterMeterProofreadingDate_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_2.Location = new System.Drawing.Point(238, 19);
            this.DT_waterMeterProofreadingDate_2.Name = "DT_waterMeterProofreadingDate_2";
            this.DT_waterMeterProofreadingDate_2.Size = new System.Drawing.Size(105, 21);
            this.DT_waterMeterProofreadingDate_2.TabIndex = 143;
            // 
            // DT_waterMeterProofreadingDate_1
            // 
            this.DT_waterMeterProofreadingDate_1.CustomFormat = "yyyy-MM-dd";
            this.DT_waterMeterProofreadingDate_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_1.Location = new System.Drawing.Point(102, 19);
            this.DT_waterMeterProofreadingDate_1.Name = "DT_waterMeterProofreadingDate_1";
            this.DT_waterMeterProofreadingDate_1.Size = new System.Drawing.Size(105, 21);
            this.DT_waterMeterProofreadingDate_1.TabIndex = 142;
            // 
            // CHK_waterMeterProofreadingDate
            // 
            this.CHK_waterMeterProofreadingDate.AutoSize = true;
            this.CHK_waterMeterProofreadingDate.Location = new System.Drawing.Point(9, 22);
            this.CHK_waterMeterProofreadingDate.Name = "CHK_waterMeterProofreadingDate";
            this.CHK_waterMeterProofreadingDate.Size = new System.Drawing.Size(78, 16);
            this.CHK_waterMeterProofreadingDate.TabIndex = 141;
            this.CHK_waterMeterProofreadingDate.Text = "鉴定日期:";
            this.CHK_waterMeterProofreadingDate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(556, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 138;
            this.label4.Text = "至";
            // 
            // CHK_waterMeterSerialNumber
            // 
            this.CHK_waterMeterSerialNumber.AutoSize = true;
            this.CHK_waterMeterSerialNumber.Location = new System.Drawing.Point(365, 22);
            this.CHK_waterMeterSerialNumber.Name = "CHK_waterMeterSerialNumber";
            this.CHK_waterMeterSerialNumber.Size = new System.Drawing.Size(78, 16);
            this.CHK_waterMeterSerialNumber.TabIndex = 140;
            this.CHK_waterMeterSerialNumber.Text = "出厂编号:";
            this.CHK_waterMeterSerialNumber.UseVisualStyleBackColor = true;
            // 
            // CB_waterMeterSize
            // 
            this.CB_waterMeterSize.DropDownHeight = 130;
            this.CB_waterMeterSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_waterMeterSize.DropDownWidth = 150;
            this.CB_waterMeterSize.FormattingEnabled = true;
            this.CB_waterMeterSize.IntegralHeight = false;
            this.CB_waterMeterSize.Items.AddRange(new object[] {
            "",
            "正常",
            "停水",
            "报废"});
            this.CB_waterMeterSize.Location = new System.Drawing.Point(498, 52);
            this.CB_waterMeterSize.Name = "CB_waterMeterSize";
            this.CB_waterMeterSize.Size = new System.Drawing.Size(107, 20);
            this.CB_waterMeterSize.TabIndex = 133;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(457, 57);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(41, 12);
            this.label56.TabIndex = 134;
            this.label56.Text = "口径：";
            // 
            // CB_MeterState
            // 
            this.CB_MeterState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MeterState.FormattingEnabled = true;
            this.CB_MeterState.Items.AddRange(new object[] {
            "全部",
            "正常",
            "作废"});
            this.CB_MeterState.Location = new System.Drawing.Point(312, 53);
            this.CB_MeterState.Name = "CB_MeterState";
            this.CB_MeterState.Size = new System.Drawing.Size(88, 20);
            this.CB_MeterState.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 126;
            this.label1.Text = "水表状态:";
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.panel1, 0, 2);
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.Size = new System.Drawing.Size(1080, 542);
            this.tb1.TabIndex = 60;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbInvoiceCancelReason);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.Btn_Scrap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 43);
            this.panel1.TabIndex = 403;
            // 
            // cmbInvoiceCancelReason
            // 
            this.cmbInvoiceCancelReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceCancelReason.FormattingEnabled = true;
            this.cmbInvoiceCancelReason.Items.AddRange(new object[] {
            "",
            "损坏作废",
            "未打作废"});
            this.cmbInvoiceCancelReason.Location = new System.Drawing.Point(540, 8);
            this.cmbInvoiceCancelReason.Name = "cmbInvoiceCancelReason";
            this.cmbInvoiceCancelReason.Size = new System.Drawing.Size(174, 20);
            this.cmbInvoiceCancelReason.TabIndex = 911;
            this.cmbInvoiceCancelReason.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(464, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 910;
            this.label9.Text = "报废原因:";
            this.label9.Visible = false;
            // 
            // Btn_Scrap
            // 
            this.Btn_Scrap.Enabled = false;
            this.Btn_Scrap.Location = new System.Drawing.Point(383, 5);
            this.Btn_Scrap.Name = "Btn_Scrap";
            this.Btn_Scrap.Size = new System.Drawing.Size(80, 32);
            this.Btn_Scrap.TabIndex = 909;
            this.Btn_Scrap.Text = "水表报废";
            this.Btn_Scrap.UseVisualStyleBackColor = true;
            this.Btn_Scrap.Click += new System.EventHandler(this.Btn_Scrap_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1074, 391);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明细列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeterID,
            this.waterMeterSerialNumber,
            this.waterMeterProduct,
            this.waterMeterMode,
            this.StateDescribe,
            this.waterMeterSizeValue,
            this.waterMeterStartNumber,
            this.waterMeterProofreadingDate,
            this.waterMeteProofreadingPeriod,
            this.STARTUSEDATETIME,
            this.MEMO});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 17);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 35;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(1068, 371);
            this.dgList.TabIndex = 402;
            this.dgList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellDoubleClick);
            this.dgList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellClick);
            // 
            // MeterID
            // 
            this.MeterID.DataPropertyName = "MeterID";
            this.MeterID.HeaderText = "MeterID";
            this.MeterID.Name = "MeterID";
            this.MeterID.ReadOnly = true;
            this.MeterID.Visible = false;
            this.MeterID.Width = 89;
            // 
            // waterMeterSerialNumber
            // 
            this.waterMeterSerialNumber.DataPropertyName = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.HeaderText = "出厂编号";
            this.waterMeterSerialNumber.Name = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.ReadOnly = true;
            this.waterMeterSerialNumber.Width = 97;
            // 
            // waterMeterProduct
            // 
            this.waterMeterProduct.DataPropertyName = "waterMeterProduct";
            this.waterMeterProduct.HeaderText = "水表厂家";
            this.waterMeterProduct.Name = "waterMeterProduct";
            this.waterMeterProduct.ReadOnly = true;
            this.waterMeterProduct.Width = 97;
            // 
            // waterMeterMode
            // 
            this.waterMeterMode.DataPropertyName = "waterMeterMode";
            this.waterMeterMode.HeaderText = "型号";
            this.waterMeterMode.Name = "waterMeterMode";
            this.waterMeterMode.ReadOnly = true;
            this.waterMeterMode.Width = 65;
            // 
            // StateDescribe
            // 
            this.StateDescribe.DataPropertyName = "StateDescribe";
            this.StateDescribe.HeaderText = "水表状态";
            this.StateDescribe.Name = "StateDescribe";
            this.StateDescribe.ReadOnly = true;
            this.StateDescribe.Width = 97;
            // 
            // waterMeterSizeValue
            // 
            this.waterMeterSizeValue.DataPropertyName = "waterMeterSizeValue";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.waterMeterSizeValue.DefaultCellStyle = dataGridViewCellStyle6;
            this.waterMeterSizeValue.HeaderText = "口径";
            this.waterMeterSizeValue.Name = "waterMeterSizeValue";
            this.waterMeterSizeValue.ReadOnly = true;
            this.waterMeterSizeValue.Width = 65;
            // 
            // waterMeterStartNumber
            // 
            this.waterMeterStartNumber.DataPropertyName = "waterMeterStartNumber";
            this.waterMeterStartNumber.HeaderText = "初始读数";
            this.waterMeterStartNumber.Name = "waterMeterStartNumber";
            this.waterMeterStartNumber.ReadOnly = true;
            this.waterMeterStartNumber.Width = 97;
            // 
            // waterMeterProofreadingDate
            // 
            this.waterMeterProofreadingDate.DataPropertyName = "waterMeterProofreadingDate";
            this.waterMeterProofreadingDate.HeaderText = "鉴定日期";
            this.waterMeterProofreadingDate.Name = "waterMeterProofreadingDate";
            this.waterMeterProofreadingDate.ReadOnly = true;
            this.waterMeterProofreadingDate.Width = 97;
            // 
            // waterMeteProofreadingPeriod
            // 
            this.waterMeteProofreadingPeriod.DataPropertyName = "waterMeteProofreadingPeriod";
            this.waterMeteProofreadingPeriod.HeaderText = "鉴定周期";
            this.waterMeteProofreadingPeriod.Name = "waterMeteProofreadingPeriod";
            this.waterMeteProofreadingPeriod.ReadOnly = true;
            this.waterMeteProofreadingPeriod.Width = 97;
            // 
            // STARTUSEDATETIME
            // 
            this.STARTUSEDATETIME.DataPropertyName = "STARTUSEDATETIME";
            this.STARTUSEDATETIME.HeaderText = "启用时间";
            this.STARTUSEDATETIME.Name = "STARTUSEDATETIME";
            this.STARTUSEDATETIME.ReadOnly = true;
            this.STARTUSEDATETIME.Width = 97;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "备注";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.Width = 65;
            // 
            // toolPrintPreview
            // 
            this.toolPrintPreview.Enabled = false;
            this.toolPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolPrintPreview.Image")));
            this.toolPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintPreview.Name = "toolPrintPreview";
            this.toolPrintPreview.Size = new System.Drawing.Size(87, 22);
            this.toolPrintPreview.Text = "打印预览";
            // 
            // toolPrint
            // 
            this.toolPrint.Enabled = false;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(41, 22);
            this.toolPrint.Text = "打印";
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripWaterUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWaterUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolStripSeparator6,
            this.toolEntering,
            this.toolBatch,
            this.toolPrint,
            this.toolPrintPreview});
            this.toolStripWaterUser.Location = new System.Drawing.Point(0, 0);
            this.toolStripWaterUser.Name = "toolStripWaterUser";
            this.toolStripWaterUser.Size = new System.Drawing.Size(1080, 25);
            this.toolStripWaterUser.TabIndex = 59;
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolSearch
            // 
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(41, 22);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AutoSize = false;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(10, 25);
            // 
            // toolEntering
            // 
            this.toolEntering.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolEntering.Image = ((System.Drawing.Image)(resources.GetObject("toolEntering.Image")));
            this.toolEntering.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolEntering.Name = "toolEntering";
            this.toolEntering.Size = new System.Drawing.Size(71, 22);
            this.toolEntering.Text = "单个入库";
            this.toolEntering.Click += new System.EventHandler(this.toolEntering_Click);
            // 
            // toolBatch
            // 
            this.toolBatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolBatch.Image = ((System.Drawing.Image)(resources.GetObject("toolBatch.Image")));
            this.toolBatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBatch.Name = "toolBatch";
            this.toolBatch.Size = new System.Drawing.Size(71, 22);
            this.toolBatch.Text = "批量入库";
            this.toolBatch.Click += new System.EventHandler(this.toolBatch_Click);
            // 
            // FrmMeterManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 567);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmMeterManage";
            this.Text = "水表管理";
            this.Load += new System.EventHandler(this.FrmMeterManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_2;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_1;
        private System.Windows.Forms.CheckBox CHK_waterMeterProofreadingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CHK_waterMeterSerialNumber;
        private System.Windows.Forms.ComboBox CB_waterMeterSize;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox CB_MeterState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolEntering;
        private System.Windows.Forms.ToolStripButton toolBatch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbInvoiceCancelReason;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Btn_Scrap;
        private System.Windows.Forms.ComboBox CB_waterMeterProduct;
        private System.Windows.Forms.MaskedTextBox TB_waterMeterSerialNumber_2;
        private System.Windows.Forms.MaskedTextBox TB_waterMeterSerialNumber_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateDescribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSizeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterStartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterProofreadingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeteProofreadingPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn STARTUSEDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;

    }
}
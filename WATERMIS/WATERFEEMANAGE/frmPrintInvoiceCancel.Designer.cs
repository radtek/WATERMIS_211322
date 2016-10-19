namespace WATERFEEMANAGE
{
    partial class frmPrintInvoiceCancel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintInvoiceCancel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbInvoiceCancelReason = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btInvoiceCancel = new System.Windows.Forms.Button();
            this.ucPageSetUp1 = new BASEFUNCTION.ucPageSetUp();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCharger = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndPrint = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPrint = new System.Windows.Forms.DateTimePicker();
            this.chbInvoicePrintDateTime = new System.Windows.Forms.CheckBox();
            this.txtEndNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartNO = new System.Windows.Forms.TextBox();
            this.chkInvoiceRange = new System.Windows.Forms.CheckBox();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.txtWaterUserNameSearch = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.cmbInvoiceState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.CHARGEINVOICEPRINTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEBATCHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEBATCHNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICECANCEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEPRINTWORKERID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEPRINTWORKERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEPRINTDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterLastNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterEndNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterTotalCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraChargePrice2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.toolStripWaterUser.SuspendLayout();
            this.tb1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.toolPrint.Enabled = false;
            this.toolPrint.Image = global::WATERFEEMANAGE.Properties.Resources.打印;
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
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbInvoiceCancelReason);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btInvoiceCancel);
            this.panel1.Controls.Add(this.ucPageSetUp1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 491);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 43);
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
            this.cmbInvoiceCancelReason.Size = new System.Drawing.Size(174, 24);
            this.cmbInvoiceCancelReason.TabIndex = 911;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(464, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 910;
            this.label9.Text = "作废原因:";
            // 
            // btInvoiceCancel
            // 
            this.btInvoiceCancel.Enabled = false;
            this.btInvoiceCancel.Location = new System.Drawing.Point(383, 5);
            this.btInvoiceCancel.Name = "btInvoiceCancel";
            this.btInvoiceCancel.Size = new System.Drawing.Size(80, 32);
            this.btInvoiceCancel.TabIndex = 909;
            this.btInvoiceCancel.Text = "发票作废";
            this.btInvoiceCancel.UseVisualStyleBackColor = true;
            this.btInvoiceCancel.Click += new System.EventHandler(this.btInvoiceCancel_Click);
            // 
            // ucPageSetUp1
            // 
            this.ucPageSetUp1.BackColor = System.Drawing.Color.Transparent;
            this.ucPageSetUp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucPageSetUp1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucPageSetUp1.Location = new System.Drawing.Point(9, 3);
            this.ucPageSetUp1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucPageSetUp1.Name = "ucPageSetUp1";
            this.ucPageSetUp1.Size = new System.Drawing.Size(321, 39);
            this.ucPageSetUp1.TabIndex = 908;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.cmbCharger);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEndPrint);
            this.groupBox1.Controls.Add(this.dtpStartPrint);
            this.groupBox1.Controls.Add(this.chbInvoicePrintDateTime);
            this.groupBox1.Controls.Add(this.txtEndNO);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtStartNO);
            this.groupBox1.Controls.Add(this.chkInvoiceRange);
            this.groupBox1.Controls.Add(this.cmbWaterMeterType);
            this.groupBox1.Controls.Add(this.label56);
            this.groupBox1.Controls.Add(this.txtWaterUserNameSearch);
            this.groupBox1.Controls.Add(this.label48);
            this.groupBox1.Controls.Add(this.cmbInvoiceState);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 86);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "查询条件";
            // 
            // cmbCharger
            // 
            this.cmbCharger.FormattingEnabled = true;
            this.cmbCharger.Location = new System.Drawing.Point(482, 53);
            this.cmbCharger.Name = "cmbCharger";
            this.cmbCharger.Size = new System.Drawing.Size(100, 24);
            this.cmbCharger.TabIndex = 145;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 146;
            this.label3.Text = "制票员:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 144;
            this.label2.Text = "至";
            // 
            // dtpEndPrint
            // 
            this.dtpEndPrint.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEndPrint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndPrint.Location = new System.Drawing.Point(238, 19);
            this.dtpEndPrint.Name = "dtpEndPrint";
            this.dtpEndPrint.Size = new System.Drawing.Size(105, 26);
            this.dtpEndPrint.TabIndex = 143;
            // 
            // dtpStartPrint
            // 
            this.dtpStartPrint.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStartPrint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartPrint.Location = new System.Drawing.Point(102, 19);
            this.dtpStartPrint.Name = "dtpStartPrint";
            this.dtpStartPrint.Size = new System.Drawing.Size(105, 26);
            this.dtpStartPrint.TabIndex = 142;
            // 
            // chbInvoicePrintDateTime
            // 
            this.chbInvoicePrintDateTime.AutoSize = true;
            this.chbInvoicePrintDateTime.Location = new System.Drawing.Point(9, 22);
            this.chbInvoicePrintDateTime.Name = "chbInvoicePrintDateTime";
            this.chbInvoicePrintDateTime.Size = new System.Drawing.Size(99, 20);
            this.chbInvoicePrintDateTime.TabIndex = 141;
            this.chbInvoicePrintDateTime.Text = "打印时间:";
            this.chbInvoicePrintDateTime.UseVisualStyleBackColor = true;
            // 
            // txtEndNO
            // 
            this.txtEndNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndNO.Location = new System.Drawing.Point(563, 19);
            this.txtEndNO.Name = "txtEndNO";
            this.txtEndNO.Size = new System.Drawing.Size(76, 26);
            this.txtEndNO.TabIndex = 139;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(537, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 138;
            this.label4.Text = "至";
            // 
            // txtStartNO
            // 
            this.txtStartNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartNO.Location = new System.Drawing.Point(458, 19);
            this.txtStartNO.Name = "txtStartNO";
            this.txtStartNO.Size = new System.Drawing.Size(76, 26);
            this.txtStartNO.TabIndex = 137;
            // 
            // chkInvoiceRange
            // 
            this.chkInvoiceRange.AutoSize = true;
            this.chkInvoiceRange.Location = new System.Drawing.Point(365, 22);
            this.chkInvoiceRange.Name = "chkInvoiceRange";
            this.chkInvoiceRange.Size = new System.Drawing.Size(99, 20);
            this.chkInvoiceRange.TabIndex = 140;
            this.chkInvoiceRange.Text = "发票号码:";
            this.chkInvoiceRange.UseVisualStyleBackColor = true;
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownHeight = 130;
            this.cmbWaterMeterType.DropDownWidth = 150;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.IntegralHeight = false;
            this.cmbWaterMeterType.Items.AddRange(new object[] {
            "",
            "正常",
            "停水",
            "报废"});
            this.cmbWaterMeterType.Location = new System.Drawing.Point(289, 53);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(107, 24);
            this.cmbWaterMeterType.TabIndex = 133;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(213, 57);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(80, 16);
            this.label56.TabIndex = 134;
            this.label56.Text = "用水性质:";
            // 
            // txtWaterUserNameSearch
            // 
            this.txtWaterUserNameSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNameSearch.Location = new System.Drawing.Point(102, 52);
            this.txtWaterUserNameSearch.Name = "txtWaterUserNameSearch";
            this.txtWaterUserNameSearch.Size = new System.Drawing.Size(90, 26);
            this.txtWaterUserNameSearch.TabIndex = 132;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(26, 57);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(80, 16);
            this.label48.TabIndex = 131;
            this.label48.Text = "用户名称:";
            // 
            // cmbInvoiceState
            // 
            this.cmbInvoiceState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceState.FormattingEnabled = true;
            this.cmbInvoiceState.Items.AddRange(new object[] {
            "全部",
            "正常",
            "作废"});
            this.cmbInvoiceState.Location = new System.Drawing.Point(731, 20);
            this.cmbInvoiceState.Name = "cmbInvoiceState";
            this.cmbInvoiceState.Size = new System.Drawing.Size(88, 24);
            this.cmbInvoiceState.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(655, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 126;
            this.label1.Text = "发票状态:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 386);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明细列表";
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
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHARGEINVOICEPRINTID,
            this.INVOICEBATCHID,
            this.INVOICEBATCHNAME,
            this.INVOICENO,
            this.INVOICECANCEL,
            this.INVOICEPRINTWORKERID,
            this.INVOICEPRINTWORKERNAME,
            this.INVOICEPRINTDATETIME,
            this.waterUserName,
            this.waterUserAddress,
            this.waterMeterTypeName,
            this.waterMeterLastNumber,
            this.waterMeterEndNumber,
            this.totalNumber,
            this.avePrice,
            this.waterTotalCharge,
            this.extraChargePrice1,
            this.extraCharge1,
            this.extraChargePrice2,
            this.extraCharge2,
            this.totalCharge});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 35;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(996, 361);
            this.dgList.TabIndex = 402;
            this.dgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgList_CellFormatting);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            // 
            // CHARGEINVOICEPRINTID
            // 
            this.CHARGEINVOICEPRINTID.DataPropertyName = "CHARGEINVOICEPRINTID";
            this.CHARGEINVOICEPRINTID.HeaderText = "CHARGEINVOICEPRINTID";
            this.CHARGEINVOICEPRINTID.Name = "CHARGEINVOICEPRINTID";
            this.CHARGEINVOICEPRINTID.ReadOnly = true;
            this.CHARGEINVOICEPRINTID.Visible = false;
            this.CHARGEINVOICEPRINTID.Width = 193;
            // 
            // INVOICEBATCHID
            // 
            this.INVOICEBATCHID.DataPropertyName = "INVOICEBATCHID";
            this.INVOICEBATCHID.HeaderText = "INVOICEBATCHID";
            this.INVOICEBATCHID.Name = "INVOICEBATCHID";
            this.INVOICEBATCHID.ReadOnly = true;
            this.INVOICEBATCHID.Visible = false;
            this.INVOICEBATCHID.Width = 145;
            // 
            // INVOICEBATCHNAME
            // 
            this.INVOICEBATCHNAME.DataPropertyName = "INVOICEBATCHNAME";
            this.INVOICEBATCHNAME.HeaderText = "发票批次";
            this.INVOICEBATCHNAME.Name = "INVOICEBATCHNAME";
            this.INVOICEBATCHNAME.ReadOnly = true;
            this.INVOICEBATCHNAME.Width = 97;
            // 
            // INVOICENO
            // 
            this.INVOICENO.DataPropertyName = "INVOICENO";
            this.INVOICENO.HeaderText = "发票号码";
            this.INVOICENO.Name = "INVOICENO";
            this.INVOICENO.ReadOnly = true;
            this.INVOICENO.Width = 97;
            // 
            // INVOICECANCEL
            // 
            this.INVOICECANCEL.DataPropertyName = "INVOICECANCEL";
            this.INVOICECANCEL.HeaderText = "发票状态";
            this.INVOICECANCEL.Name = "INVOICECANCEL";
            this.INVOICECANCEL.ReadOnly = true;
            this.INVOICECANCEL.Width = 97;
            // 
            // INVOICEPRINTWORKERID
            // 
            this.INVOICEPRINTWORKERID.DataPropertyName = "INVOICEPRINTWORKERID";
            this.INVOICEPRINTWORKERID.HeaderText = "INVOICEPRINTWORKERID";
            this.INVOICEPRINTWORKERID.Name = "INVOICEPRINTWORKERID";
            this.INVOICEPRINTWORKERID.ReadOnly = true;
            this.INVOICEPRINTWORKERID.Visible = false;
            this.INVOICEPRINTWORKERID.Width = 193;
            // 
            // INVOICEPRINTWORKERNAME
            // 
            this.INVOICEPRINTWORKERNAME.DataPropertyName = "INVOICEPRINTWORKERNAME";
            this.INVOICEPRINTWORKERNAME.HeaderText = "制票员";
            this.INVOICEPRINTWORKERNAME.Name = "INVOICEPRINTWORKERNAME";
            this.INVOICEPRINTWORKERNAME.ReadOnly = true;
            this.INVOICEPRINTWORKERNAME.Width = 81;
            // 
            // INVOICEPRINTDATETIME
            // 
            this.INVOICEPRINTDATETIME.DataPropertyName = "INVOICEPRINTDATETIME";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.INVOICEPRINTDATETIME.DefaultCellStyle = dataGridViewCellStyle3;
            this.INVOICEPRINTDATETIME.HeaderText = "打印日期";
            this.INVOICEPRINTDATETIME.Name = "INVOICEPRINTDATETIME";
            this.INVOICEPRINTDATETIME.ReadOnly = true;
            this.INVOICEPRINTDATETIME.Width = 97;
            // 
            // waterUserName
            // 
            this.waterUserName.DataPropertyName = "waterUserName";
            this.waterUserName.HeaderText = "用户名";
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.ReadOnly = true;
            this.waterUserName.Width = 81;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.HeaderText = "用户地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            this.waterUserAddress.Width = 97;
            // 
            // waterMeterTypeName
            // 
            this.waterMeterTypeName.DataPropertyName = "waterMeterTypeName";
            this.waterMeterTypeName.HeaderText = "用水性质";
            this.waterMeterTypeName.Name = "waterMeterTypeName";
            this.waterMeterTypeName.ReadOnly = true;
            this.waterMeterTypeName.Width = 97;
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
            this.totalNumber.HeaderText = "水量";
            this.totalNumber.Name = "totalNumber";
            this.totalNumber.ReadOnly = true;
            this.totalNumber.Width = 65;
            // 
            // avePrice
            // 
            this.avePrice.DataPropertyName = "avePrice";
            this.avePrice.HeaderText = "单价";
            this.avePrice.Name = "avePrice";
            this.avePrice.ReadOnly = true;
            this.avePrice.Width = 65;
            // 
            // waterTotalCharge
            // 
            this.waterTotalCharge.DataPropertyName = "waterTotalCharge";
            this.waterTotalCharge.HeaderText = "水费";
            this.waterTotalCharge.Name = "waterTotalCharge";
            this.waterTotalCharge.ReadOnly = true;
            this.waterTotalCharge.Width = 65;
            // 
            // extraChargePrice1
            // 
            this.extraChargePrice1.DataPropertyName = "extraChargePrice1";
            this.extraChargePrice1.HeaderText = "污水处理费单价";
            this.extraChargePrice1.Name = "extraChargePrice1";
            this.extraChargePrice1.ReadOnly = true;
            this.extraChargePrice1.Width = 145;
            // 
            // extraCharge1
            // 
            this.extraCharge1.DataPropertyName = "extraCharge1";
            this.extraCharge1.HeaderText = "污水处理费";
            this.extraCharge1.Name = "extraCharge1";
            this.extraCharge1.ReadOnly = true;
            this.extraCharge1.Width = 113;
            // 
            // extraChargePrice2
            // 
            this.extraChargePrice2.DataPropertyName = "extraChargePrice2";
            this.extraChargePrice2.HeaderText = "附加费单价";
            this.extraChargePrice2.Name = "extraChargePrice2";
            this.extraChargePrice2.ReadOnly = true;
            this.extraChargePrice2.Width = 113;
            // 
            // extraCharge2
            // 
            this.extraCharge2.DataPropertyName = "extraCharge2";
            this.extraCharge2.HeaderText = "附加费";
            this.extraCharge2.Name = "extraCharge2";
            this.extraCharge2.ReadOnly = true;
            this.extraCharge2.Width = 81;
            // 
            // totalCharge
            // 
            this.totalCharge.DataPropertyName = "totalCharge";
            this.totalCharge.HeaderText = "发票金额";
            this.totalCharge.Name = "totalCharge";
            this.totalCharge.ReadOnly = true;
            this.totalCharge.Width = 97;
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
            previewSettings1.Buttons = ((FastReport.PreviewButtons)(((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save)
                        | FastReport.PreviewButtons.Zoom)
                        | FastReport.PreviewButtons.PageSetup)
                        | FastReport.PreviewButtons.Close)));
            previewSettings1.Icon = ((System.Drawing.Icon)(resources.GetObject("previewSettings1.Icon")));
            previewSettings1.Text = "";
            this.environmentSettings1.PreviewSettings = previewSettings1;
            this.environmentSettings1.ReportSettings = reportSettings1;
            this.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // frmPrintInvoiceCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrintInvoiceCancel";
            this.Text = "自定额发票作废与查询";
            this.Load += new System.EventHandler(this.frmWaterUserSearch_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.ComboBox cmbInvoiceState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox txtWaterUserNameSearch;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtStartNO;
        private System.Windows.Forms.TextBox txtEndNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkInvoiceRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndPrint;
        private System.Windows.Forms.DateTimePicker dtpStartPrint;
        private System.Windows.Forms.CheckBox chbInvoicePrintDateTime;
        private BASEFUNCTION.ucPageSetUp ucPageSetUp1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbInvoiceCancelReason;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btInvoiceCancel;
        private System.Windows.Forms.ComboBox cmbCharger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGEINVOICEPRINTID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEBATCHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEBATCHNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICECANCEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEPRINTWORKERID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEPRINTWORKERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEPRINTDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterLastNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterEndNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn avePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterTotalCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge1;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraChargePrice2;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge2;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCharge;
    }
}
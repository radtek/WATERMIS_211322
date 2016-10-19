namespace STATISTIALREPORTS
{
    partial class frmChargeInvoicePrintSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeInvoicePrintSearch));
            FastReport.Design.DesignerSettings designerSettings3 = new FastReport.Design.DesignerSettings();
            FastReport.Design.DesignerRestrictions designerRestrictions3 = new FastReport.Design.DesignerRestrictions();
            FastReport.Export.Email.EmailSettings emailSettings3 = new FastReport.Export.Email.EmailSettings();
            FastReport.PreviewSettings previewSettings3 = new FastReport.PreviewSettings();
            FastReport.ReportSettings reportSettings3 = new FastReport.ReportSettings();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolExportToExl = new System.Windows.Forms.ToolStripButton();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.INVOICEBATCHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGEWORKERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGEDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGETYPENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGEClASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEBATCHNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICECANCEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEPRINTDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterLastNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterEndNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterTotalCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraCharge2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.cmbChargerWorkName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.btSetMonth = new System.Windows.Forms.Button();
            this.toolStripWaterUser.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tb1.SuspendLayout();
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
            this.toolPrint,
            this.toolPrintPreview,
            this.toolExportToExl});
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
            // toolExportToExl
            // 
            this.toolExportToExl.Enabled = false;
            this.toolExportToExl.Image = global::STATISTIALREPORTS.Properties.Resources.snap_undo;
            this.toolExportToExl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExportToExl.Name = "toolExportToExl";
            this.toolExportToExl.Size = new System.Drawing.Size(97, 22);
            this.toolExportToExl.Text = "导出Excel";
            this.toolExportToExl.Click += new System.EventHandler(this.toolExportToExl_Click);
            // 
            // environmentSettings1
            // 
            designerSettings3.ApplicationConnection = null;
            designerSettings3.DefaultFont = new System.Drawing.Font("宋体", 9F);
            designerSettings3.Icon = ((System.Drawing.Icon)(resources.GetObject("designerSettings3.Icon")));
            designerSettings3.Restrictions = designerRestrictions3;
            designerSettings3.Text = "";
            this.environmentSettings1.DesignerSettings = designerSettings3;
            emailSettings3.Address = "";
            emailSettings3.Host = "";
            emailSettings3.MessageTemplate = "";
            emailSettings3.Name = "";
            emailSettings3.Password = "";
            emailSettings3.UserName = "";
            this.environmentSettings1.EmailSettings = emailSettings3;
            previewSettings3.Buttons = ((FastReport.PreviewButtons)(((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save)
                        | FastReport.PreviewButtons.Zoom)
                        | FastReport.PreviewButtons.PageSetup)
                        | FastReport.PreviewButtons.Close)));
            previewSettings3.Icon = ((System.Drawing.Icon)(resources.GetObject("previewSettings3.Icon")));
            previewSettings3.Text = "";
            this.environmentSettings1.PreviewSettings = previewSettings3;
            this.environmentSettings1.ReportSettings = reportSettings3;
            this.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 435);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "历史收费明细列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INVOICEBATCHID,
            this.CHARGEWORKERNAME,
            this.chargeID,
            this.CHARGEDATETIME,
            this.CHARGETYPENAME,
            this.CHARGEClASS,
            this.INVOICEBATCHNAME,
            this.INVOICENO,
            this.INVOICECANCEL,
            this.INVOICEPRINTDATETIME,
            this.waterUserName,
            this.waterMeterNo,
            this.waterUserAddress,
            this.waterMeterTypeName,
            this.waterMeterLastNumber,
            this.waterMeterEndNumber,
            this.totalNumber,
            this.waterTotalCharge,
            this.extraCharge1,
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
            this.dgList.Size = new System.Drawing.Size(996, 410);
            this.dgList.TabIndex = 402;
            this.dgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgList_CellFormatting);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgList_DataBindingComplete);
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
            // CHARGEWORKERNAME
            // 
            this.CHARGEWORKERNAME.DataPropertyName = "CHARGEWORKERNAME";
            this.CHARGEWORKERNAME.HeaderText = "收费员";
            this.CHARGEWORKERNAME.Name = "CHARGEWORKERNAME";
            this.CHARGEWORKERNAME.ReadOnly = true;
            this.CHARGEWORKERNAME.Width = 81;
            // 
            // chargeID
            // 
            this.chargeID.DataPropertyName = "chargeID";
            this.chargeID.HeaderText = "收费单号";
            this.chargeID.Name = "chargeID";
            this.chargeID.ReadOnly = true;
            this.chargeID.Width = 97;
            // 
            // CHARGEDATETIME
            // 
            this.CHARGEDATETIME.DataPropertyName = "CHARGEDATETIME";
            dataGridViewCellStyle11.Format = "d";
            dataGridViewCellStyle11.NullValue = null;
            this.CHARGEDATETIME.DefaultCellStyle = dataGridViewCellStyle11;
            this.CHARGEDATETIME.HeaderText = "收费日期";
            this.CHARGEDATETIME.Name = "CHARGEDATETIME";
            this.CHARGEDATETIME.ReadOnly = true;
            this.CHARGEDATETIME.Width = 97;
            // 
            // CHARGETYPENAME
            // 
            this.CHARGETYPENAME.DataPropertyName = "CHARGETYPENAME";
            this.CHARGETYPENAME.HeaderText = "收费方式";
            this.CHARGETYPENAME.Name = "CHARGETYPENAME";
            this.CHARGETYPENAME.ReadOnly = true;
            this.CHARGETYPENAME.Width = 97;
            // 
            // CHARGEClASS
            // 
            this.CHARGEClASS.DataPropertyName = "CHARGEClASS";
            this.CHARGEClASS.HeaderText = "收费类别";
            this.CHARGEClASS.Name = "CHARGEClASS";
            this.CHARGEClASS.ReadOnly = true;
            this.CHARGEClASS.Width = 97;
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
            // INVOICEPRINTDATETIME
            // 
            this.INVOICEPRINTDATETIME.DataPropertyName = "INVOICEPRINTDATETIME";
            dataGridViewCellStyle12.Format = "d";
            dataGridViewCellStyle12.NullValue = null;
            this.INVOICEPRINTDATETIME.DefaultCellStyle = dataGridViewCellStyle12;
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
            // waterMeterNo
            // 
            this.waterMeterNo.DataPropertyName = "waterMeterNo";
            this.waterMeterNo.HeaderText = "水表编号";
            this.waterMeterNo.Name = "waterMeterNo";
            this.waterMeterNo.ReadOnly = true;
            this.waterMeterNo.Width = 97;
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
            // waterTotalCharge
            // 
            this.waterTotalCharge.DataPropertyName = "waterTotalCharge";
            this.waterTotalCharge.HeaderText = "水费";
            this.waterTotalCharge.Name = "waterTotalCharge";
            this.waterTotalCharge.ReadOnly = true;
            this.waterTotalCharge.Width = 65;
            // 
            // extraCharge1
            // 
            this.extraCharge1.DataPropertyName = "extraCharge1";
            this.extraCharge1.HeaderText = "污水处理费";
            this.extraCharge1.Name = "extraCharge1";
            this.extraCharge1.ReadOnly = true;
            this.extraCharge1.Width = 113;
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btSetMonth);
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
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkChargeDateTime);
            this.groupBox1.Controls.Add(this.cmbChargerWorkName);
            this.groupBox1.Controls.Add(this.label7);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(616, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 144;
            this.label2.Text = "至";
            // 
            // dtpEndPrint
            // 
            this.dtpEndPrint.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEndPrint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndPrint.Location = new System.Drawing.Point(641, 51);
            this.dtpEndPrint.Name = "dtpEndPrint";
            this.dtpEndPrint.Size = new System.Drawing.Size(105, 26);
            this.dtpEndPrint.TabIndex = 143;
            // 
            // dtpStartPrint
            // 
            this.dtpStartPrint.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStartPrint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartPrint.Location = new System.Drawing.Point(505, 51);
            this.dtpStartPrint.Name = "dtpStartPrint";
            this.dtpStartPrint.Size = new System.Drawing.Size(105, 26);
            this.dtpStartPrint.TabIndex = 142;
            // 
            // chbInvoicePrintDateTime
            // 
            this.chbInvoicePrintDateTime.AutoSize = true;
            this.chbInvoicePrintDateTime.Location = new System.Drawing.Point(412, 54);
            this.chbInvoicePrintDateTime.Name = "chbInvoicePrintDateTime";
            this.chbInvoicePrintDateTime.Size = new System.Drawing.Size(99, 20);
            this.chbInvoicePrintDateTime.TabIndex = 141;
            this.chbInvoicePrintDateTime.Text = "打印时间:";
            this.chbInvoicePrintDateTime.UseVisualStyleBackColor = true;
            // 
            // txtEndNO
            // 
            this.txtEndNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtEndNO.Location = new System.Drawing.Point(904, 18);
            this.txtEndNO.Name = "txtEndNO";
            this.txtEndNO.Size = new System.Drawing.Size(76, 26);
            this.txtEndNO.TabIndex = 139;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(878, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 138;
            this.label4.Text = "至";
            // 
            // txtStartNO
            // 
            this.txtStartNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartNO.Location = new System.Drawing.Point(799, 18);
            this.txtStartNO.Name = "txtStartNO";
            this.txtStartNO.Size = new System.Drawing.Size(76, 26);
            this.txtStartNO.TabIndex = 137;
            // 
            // chkInvoiceRange
            // 
            this.chkInvoiceRange.AutoSize = true;
            this.chkInvoiceRange.Location = new System.Drawing.Point(706, 21);
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
            this.cmbWaterMeterType.Location = new System.Drawing.Point(276, 53);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(107, 24);
            this.cmbWaterMeterType.TabIndex = 133;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(196, 57);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(80, 16);
            this.label56.TabIndex = 134;
            this.label56.Text = "用水性质:";
            // 
            // txtWaterUserNameSearch
            // 
            this.txtWaterUserNameSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNameSearch.Location = new System.Drawing.Point(79, 51);
            this.txtWaterUserNameSearch.Name = "txtWaterUserNameSearch";
            this.txtWaterUserNameSearch.Size = new System.Drawing.Size(90, 26);
            this.txtWaterUserNameSearch.TabIndex = 132;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(3, 56);
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
            this.cmbInvoiceState.Location = new System.Drawing.Point(608, 19);
            this.cmbInvoiceState.Name = "cmbInvoiceState";
            this.cmbInvoiceState.Size = new System.Drawing.Size(88, 24);
            this.cmbInvoiceState.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 126;
            this.label1.Text = "发票状态:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 124;
            this.label8.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(403, 19);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 123;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(276, 19);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 122;
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Checked = true;
            this.chkChargeDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChargeDateTime.Location = new System.Drawing.Point(183, 22);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkChargeDateTime.TabIndex = 121;
            this.chkChargeDateTime.Text = "收费时间:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // cmbChargerWorkName
            // 
            this.cmbChargerWorkName.FormattingEnabled = true;
            this.cmbChargerWorkName.Location = new System.Drawing.Point(81, 20);
            this.cmbChargerWorkName.Name = "cmbChargerWorkName";
            this.cmbChargerWorkName.Size = new System.Drawing.Size(88, 24);
            this.cmbChargerWorkName.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 120;
            this.label7.Text = "收 款 员:";
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
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
            // btSetMonth
            // 
            this.btSetMonth.BackgroundImage = global::STATISTIALREPORTS.Properties.Resources.onebit_20;
            this.btSetMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetMonth.Location = new System.Drawing.Point(509, 20);
            this.btSetMonth.Name = "btSetMonth";
            this.btSetMonth.Size = new System.Drawing.Size(22, 23);
            this.btSetMonth.TabIndex = 180;
            this.btSetMonth.UseVisualStyleBackColor = true;
            this.btSetMonth.Click += new System.EventHandler(this.btSetMonth_Click);
            // 
            // frmChargeInvoicePrintSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChargeInvoicePrintSearch";
            this.Text = "发票使用明细查询";
            this.Load += new System.EventHandler(this.frmWaterUserSearch_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.ToolStripButton toolExportToExl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEndPrint;
        private System.Windows.Forms.DateTimePicker dtpStartPrint;
        private System.Windows.Forms.CheckBox chbInvoicePrintDateTime;
        private System.Windows.Forms.TextBox txtEndNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStartNO;
        private System.Windows.Forms.CheckBox chkInvoiceRange;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox txtWaterUserNameSearch;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox cmbInvoiceState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.ComboBox cmbChargerWorkName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEBATCHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGEWORKERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGEDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGETYPENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGEClASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEBATCHNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICECANCEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEPRINTDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterLastNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterEndNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterTotalCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge1;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraCharge2;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCharge;
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
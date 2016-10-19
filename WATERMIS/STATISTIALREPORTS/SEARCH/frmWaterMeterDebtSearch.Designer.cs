namespace STATISTIALREPORTS
{
    partial class frmWaterMeterDebtSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterDebtSearch));
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
            this.toolExportToExl = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbDuanNOS = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbPianNOS = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbAreaNOS = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkNullRead = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCountPeriod = new System.Windows.Forms.TextBox();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.btSenior = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMeterReader = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWaterUserNameSearch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.cmbWaterUserHouseType = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.waterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.未收期数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pianNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duanNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordernumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserHouseTypeS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterIsSummaryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERFIXVALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankAcountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.cmbDuanNOS);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.cmbPianNOS);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cmbAreaNOS);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.chkNullRead);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCountPeriod);
            this.groupBox1.Controls.Add(this.txtSenior);
            this.groupBox1.Controls.Add(this.btSenior);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbWaterMeterType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbMeterReader);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtWaterUserNameSearch);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.txtWaterUserNOSearch);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.cmbWaterUserHouseType);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 120);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "查询条件";
            // 
            // cmbDuanNOS
            // 
            this.cmbDuanNOS.DropDownWidth = 120;
            this.cmbDuanNOS.FormattingEnabled = true;
            this.cmbDuanNOS.Location = new System.Drawing.Point(484, 56);
            this.cmbDuanNOS.Name = "cmbDuanNOS";
            this.cmbDuanNOS.Size = new System.Drawing.Size(60, 24);
            this.cmbDuanNOS.TabIndex = 151;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(440, 60);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 16);
            this.label35.TabIndex = 150;
            this.label35.Text = "段号：";
            // 
            // cmbPianNOS
            // 
            this.cmbPianNOS.DropDownWidth = 120;
            this.cmbPianNOS.FormattingEnabled = true;
            this.cmbPianNOS.Location = new System.Drawing.Point(249, 55);
            this.cmbPianNOS.Name = "cmbPianNOS";
            this.cmbPianNOS.Size = new System.Drawing.Size(60, 24);
            this.cmbPianNOS.TabIndex = 149;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(205, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 148;
            this.label21.Text = "片号：";
            // 
            // cmbAreaNOS
            // 
            this.cmbAreaNOS.DropDownWidth = 120;
            this.cmbAreaNOS.FormattingEnabled = true;
            this.cmbAreaNOS.Location = new System.Drawing.Point(367, 56);
            this.cmbAreaNOS.Name = "cmbAreaNOS";
            this.cmbAreaNOS.Size = new System.Drawing.Size(60, 24);
            this.cmbAreaNOS.TabIndex = 147;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 146;
            this.label9.Text = "区号：";
            // 
            // chkNullRead
            // 
            this.chkNullRead.AutoSize = true;
            this.chkNullRead.Checked = true;
            this.chkNullRead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNullRead.Location = new System.Drawing.Point(205, 89);
            this.chkNullRead.Name = "chkNullRead";
            this.chkNullRead.Size = new System.Drawing.Size(139, 20);
            this.chkNullRead.TabIndex = 145;
            this.chkNullRead.Text = "计算时包含未抄";
            this.chkNullRead.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 144;
            this.label3.Text = "期未收费";
            // 
            // txtCountPeriod
            // 
            this.txtCountPeriod.BackColor = System.Drawing.SystemColors.Window;
            this.txtCountPeriod.Location = new System.Drawing.Point(60, 85);
            this.txtCountPeriod.Name = "txtCountPeriod";
            this.txtCountPeriod.Size = new System.Drawing.Size(40, 26);
            this.txtCountPeriod.TabIndex = 143;
            this.txtCountPeriod.Text = "1";
            this.txtCountPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCountPeriod_KeyPress);
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.Color.White;
            this.txtSenior.Location = new System.Drawing.Point(754, 21);
            this.txtSenior.Multiline = true;
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(173, 88);
            this.txtSenior.TabIndex = 142;
            // 
            // btSenior
            // 
            this.btSenior.Location = new System.Drawing.Point(933, 21);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(50, 45);
            this.btSenior.TabIndex = 141;
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = true;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 116;
            this.label6.Text = "大于";
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownWidth = 150;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Location = new System.Drawing.Point(100, 54);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterMeterType.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 114;
            this.label5.Text = "用水性质:";
            // 
            // cmbMeterReader
            // 
            this.cmbMeterReader.FormattingEnabled = true;
            this.cmbMeterReader.Location = new System.Drawing.Point(468, 22);
            this.cmbMeterReader.Name = "cmbMeterReader";
            this.cmbMeterReader.Size = new System.Drawing.Size(88, 24);
            this.cmbMeterReader.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 95;
            this.label1.Text = "抄 表 员:";
            // 
            // txtWaterUserNameSearch
            // 
            this.txtWaterUserNameSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNameSearch.Location = new System.Drawing.Point(283, 21);
            this.txtWaterUserNameSearch.Name = "txtWaterUserNameSearch";
            this.txtWaterUserNameSearch.Size = new System.Drawing.Size(88, 26);
            this.txtWaterUserNameSearch.TabIndex = 66;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(206, 26);
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
            // cmbWaterUserHouseType
            // 
            this.cmbWaterUserHouseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserHouseType.FormattingEnabled = true;
            this.cmbWaterUserHouseType.Items.AddRange(new object[] {
            "",
            "楼房",
            "平房"});
            this.cmbWaterUserHouseType.Location = new System.Drawing.Point(656, 22);
            this.cmbWaterUserHouseType.Name = "cmbWaterUserHouseType";
            this.cmbWaterUserHouseType.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserHouseType.TabIndex = 57;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(579, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 16);
            this.label37.TabIndex = 56;
            this.label37.Text = "户    型:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 401);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明细列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToOrderColumns = true;
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
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.waterUserId,
            this.waterUserNO,
            this.waterUserName,
            this.waterMeterId,
            this.waterMeterNo,
            this.未收期数,
            this.waterMeterTypeValue,
            this.waterPhone,
            this.waterUserAddress,
            this.meterReaderName,
            this.chargerName,
            this.pianNO,
            this.areaNO,
            this.duanNO,
            this.ordernumber,
            this.loginId,
            this.waterUserHouseTypeS,
            this.waterUserTypeId,
            this.waterUserTypeName,
            this.bankId,
            this.waterMeterPositionId,
            this.waterMeterPositionName,
            this.waterMeterIsSummaryNo,
            this.WATERFIXVALUE,
            this.waterUserCreateDate,
            this.BankAcountNumber});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 35;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(996, 376);
            this.dgList.TabIndex = 5;
            this.dgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgList_CellFormatting);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            // 
            // environmentSettings1
            // 
            designerSettings1.ApplicationConnection = null;
            designerSettings1.DefaultFont = new System.Drawing.Font("宋体", 9F);
            designerSettings1.Icon = null;
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
            // waterMeterId
            // 
            this.waterMeterId.DataPropertyName = "waterMeterId";
            this.waterMeterId.HeaderText = "waterMeterId";
            this.waterMeterId.Name = "waterMeterId";
            this.waterMeterId.ReadOnly = true;
            this.waterMeterId.Visible = false;
            this.waterMeterId.Width = 129;
            // 
            // waterMeterNo
            // 
            this.waterMeterNo.DataPropertyName = "waterMeterNo";
            this.waterMeterNo.HeaderText = "水表编号";
            this.waterMeterNo.Name = "waterMeterNo";
            this.waterMeterNo.ReadOnly = true;
            this.waterMeterNo.Width = 97;
            // 
            // 未收期数
            // 
            this.未收期数.DataPropertyName = "未收期数";
            this.未收期数.HeaderText = "未收期数";
            this.未收期数.Name = "未收期数";
            this.未收期数.ReadOnly = true;
            this.未收期数.Width = 97;
            // 
            // waterMeterTypeValue
            // 
            this.waterMeterTypeValue.DataPropertyName = "waterMeterTypeValue";
            this.waterMeterTypeValue.HeaderText = "用水类别";
            this.waterMeterTypeValue.Name = "waterMeterTypeValue";
            this.waterMeterTypeValue.ReadOnly = true;
            this.waterMeterTypeValue.Width = 97;
            // 
            // waterPhone
            // 
            this.waterPhone.DataPropertyName = "waterPhone";
            this.waterPhone.HeaderText = "电话";
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.ReadOnly = true;
            this.waterPhone.Width = 65;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.HeaderText = "地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            this.waterUserAddress.Width = 65;
            // 
            // meterReaderName
            // 
            this.meterReaderName.DataPropertyName = "meterReaderName";
            this.meterReaderName.HeaderText = "抄表员";
            this.meterReaderName.Name = "meterReaderName";
            this.meterReaderName.ReadOnly = true;
            this.meterReaderName.Width = 81;
            // 
            // chargerName
            // 
            this.chargerName.DataPropertyName = "chargerName";
            this.chargerName.HeaderText = "收费员";
            this.chargerName.Name = "chargerName";
            this.chargerName.ReadOnly = true;
            this.chargerName.Width = 81;
            // 
            // pianNO
            // 
            this.pianNO.DataPropertyName = "pianNO";
            this.pianNO.HeaderText = "片号";
            this.pianNO.Name = "pianNO";
            this.pianNO.ReadOnly = true;
            this.pianNO.Width = 65;
            // 
            // areaNO
            // 
            this.areaNO.DataPropertyName = "areaNO";
            this.areaNO.HeaderText = "区号";
            this.areaNO.Name = "areaNO";
            this.areaNO.ReadOnly = true;
            this.areaNO.Width = 65;
            // 
            // duanNO
            // 
            this.duanNO.DataPropertyName = "duanNO";
            this.duanNO.HeaderText = "段号";
            this.duanNO.Name = "duanNO";
            this.duanNO.ReadOnly = true;
            this.duanNO.Width = 65;
            // 
            // ordernumber
            // 
            this.ordernumber.DataPropertyName = "ordernumber";
            this.ordernumber.HeaderText = "顺序号";
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.ReadOnly = true;
            this.ordernumber.Width = 81;
            // 
            // loginId
            // 
            this.loginId.DataPropertyName = "loginId";
            this.loginId.HeaderText = "loginId";
            this.loginId.Name = "loginId";
            this.loginId.ReadOnly = true;
            this.loginId.Visible = false;
            this.loginId.Width = 89;
            // 
            // waterUserHouseTypeS
            // 
            this.waterUserHouseTypeS.DataPropertyName = "waterUserHouseTypeS";
            this.waterUserHouseTypeS.HeaderText = "户型";
            this.waterUserHouseTypeS.Name = "waterUserHouseTypeS";
            this.waterUserHouseTypeS.ReadOnly = true;
            this.waterUserHouseTypeS.Width = 65;
            // 
            // waterUserTypeId
            // 
            this.waterUserTypeId.DataPropertyName = "waterUserTypeId";
            this.waterUserTypeId.HeaderText = "waterUserTypeId";
            this.waterUserTypeId.Name = "waterUserTypeId";
            this.waterUserTypeId.ReadOnly = true;
            this.waterUserTypeId.Visible = false;
            this.waterUserTypeId.Width = 153;
            // 
            // waterUserTypeName
            // 
            this.waterUserTypeName.DataPropertyName = "waterUserTypeName";
            this.waterUserTypeName.HeaderText = "用户类型";
            this.waterUserTypeName.Name = "waterUserTypeName";
            this.waterUserTypeName.ReadOnly = true;
            this.waterUserTypeName.Width = 97;
            // 
            // bankId
            // 
            this.bankId.DataPropertyName = "bankId";
            this.bankId.HeaderText = "bankId";
            this.bankId.Name = "bankId";
            this.bankId.ReadOnly = true;
            this.bankId.Visible = false;
            this.bankId.Width = 81;
            // 
            // waterMeterPositionId
            // 
            this.waterMeterPositionId.DataPropertyName = "waterMeterPositionId";
            this.waterMeterPositionId.HeaderText = "水表位置";
            this.waterMeterPositionId.Name = "waterMeterPositionId";
            this.waterMeterPositionId.ReadOnly = true;
            this.waterMeterPositionId.Visible = false;
            this.waterMeterPositionId.Width = 97;
            // 
            // waterMeterPositionName
            // 
            this.waterMeterPositionName.DataPropertyName = "waterMeterPositionName";
            this.waterMeterPositionName.HeaderText = "水表位置";
            this.waterMeterPositionName.Name = "waterMeterPositionName";
            this.waterMeterPositionName.ReadOnly = true;
            this.waterMeterPositionName.Width = 97;
            // 
            // waterMeterIsSummaryNo
            // 
            this.waterMeterIsSummaryNo.DataPropertyName = "waterMeterParentId";
            this.waterMeterIsSummaryNo.HeaderText = "总表编号";
            this.waterMeterIsSummaryNo.Name = "waterMeterIsSummaryNo";
            this.waterMeterIsSummaryNo.ReadOnly = true;
            this.waterMeterIsSummaryNo.Width = 97;
            // 
            // WATERFIXVALUE
            // 
            this.WATERFIXVALUE.DataPropertyName = "WATERFIXVALUE";
            this.WATERFIXVALUE.HeaderText = "定量用水";
            this.WATERFIXVALUE.Name = "WATERFIXVALUE";
            this.WATERFIXVALUE.ReadOnly = true;
            this.WATERFIXVALUE.Width = 97;
            // 
            // waterUserCreateDate
            // 
            this.waterUserCreateDate.DataPropertyName = "waterUserCreateDate";
            this.waterUserCreateDate.HeaderText = "waterUserCreateDate";
            this.waterUserCreateDate.Name = "waterUserCreateDate";
            this.waterUserCreateDate.ReadOnly = true;
            this.waterUserCreateDate.Visible = false;
            this.waterUserCreateDate.Width = 185;
            // 
            // BankAcountNumber
            // 
            this.BankAcountNumber.DataPropertyName = "BankAcountNumber";
            this.BankAcountNumber.HeaderText = "BankAcountNumber";
            this.BankAcountNumber.Name = "BankAcountNumber";
            this.BankAcountNumber.ReadOnly = true;
            this.BankAcountNumber.Visible = false;
            this.BankAcountNumber.Width = 161;
            // 
            // frmWaterMeterDebtSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterMeterDebtSearch";
            this.Text = "水表未收情况查询";
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
        private System.Windows.Forms.ComboBox cmbWaterUserHouseType;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox cmbMeterReader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.Label label6;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCountPeriod;
        private System.Windows.Forms.CheckBox chkNullRead;
        private System.Windows.Forms.ToolStripButton toolExportToExl;
        private System.Windows.Forms.ComboBox cmbDuanNOS;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbPianNOS;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbAreaNOS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn 未收期数;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pianNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn duanNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserHouseTypeS;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterIsSummaryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERFIXVALUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankAcountNumber;
    }
}
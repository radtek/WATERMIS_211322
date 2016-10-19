namespace STATISTIALREPORTS
{
    partial class frmWaterMeterDebtStatisc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterDebtStatisc));
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
            this.ucPageSetUp1 = new BASEFUNCTION.ucPageSetUp();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWaterMeter = new System.Windows.Forms.RadioButton();
            this.rbArea = new System.Windows.Forms.RadioButton();
            this.rbMeterReadingNO = new System.Windows.Forms.RadioButton();
            this.rbMeterReader = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
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
            this.cmbWaterUserAgentBankSearch = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cmbWaterUserHouseType = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cmbWaterUserIsAgentSearch = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
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
            this.tb1.Controls.Add(this.ucPageSetUp1, 0, 2);
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
            // 
            // ucPageSetUp1
            // 
            this.ucPageSetUp1.BackColor = System.Drawing.Color.Transparent;
            this.ucPageSetUp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucPageSetUp1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ucPageSetUp1.Location = new System.Drawing.Point(4, 494);
            this.ucPageSetUp1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ucPageSetUp1.Name = "ucPageSetUp1";
            this.ucPageSetUp1.Size = new System.Drawing.Size(321, 39);
            this.ucPageSetUp1.TabIndex = 905;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbWaterMeter);
            this.groupBox1.Controls.Add(this.rbArea);
            this.groupBox1.Controls.Add(this.rbMeterReadingNO);
            this.groupBox1.Controls.Add(this.rbMeterReader);
            this.groupBox1.Controls.Add(this.label42);
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
            this.groupBox1.Controls.Add(this.cmbWaterUserAgentBankSearch);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.cmbWaterUserHouseType);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.cmbWaterUserIsAgentSearch);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 118);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // rbWaterMeter
            // 
            this.rbWaterMeter.AutoSize = true;
            this.rbWaterMeter.Location = new System.Drawing.Point(682, 91);
            this.rbWaterMeter.Name = "rbWaterMeter";
            this.rbWaterMeter.Size = new System.Drawing.Size(74, 20);
            this.rbWaterMeter.TabIndex = 150;
            this.rbWaterMeter.Text = "按水表";
            this.rbWaterMeter.UseVisualStyleBackColor = true;
            // 
            // rbArea
            // 
            this.rbArea.AutoSize = true;
            this.rbArea.Location = new System.Drawing.Point(605, 91);
            this.rbArea.Name = "rbArea";
            this.rbArea.Size = new System.Drawing.Size(74, 20);
            this.rbArea.TabIndex = 149;
            this.rbArea.Text = "按区域";
            this.rbArea.UseVisualStyleBackColor = true;
            this.rbArea.CheckedChanged += new System.EventHandler(this.rbArea_CheckedChanged);
            // 
            // rbMeterReadingNO
            // 
            this.rbMeterReadingNO.AutoSize = true;
            this.rbMeterReadingNO.Location = new System.Drawing.Point(504, 91);
            this.rbMeterReadingNO.Name = "rbMeterReadingNO";
            this.rbMeterReadingNO.Size = new System.Drawing.Size(106, 20);
            this.rbMeterReadingNO.TabIndex = 146;
            this.rbMeterReadingNO.Text = "按抄表本号";
            this.rbMeterReadingNO.UseVisualStyleBackColor = true;
            // 
            // rbMeterReader
            // 
            this.rbMeterReader.AutoSize = true;
            this.rbMeterReader.Checked = true;
            this.rbMeterReader.Location = new System.Drawing.Point(415, 91);
            this.rbMeterReader.Name = "rbMeterReader";
            this.rbMeterReader.Size = new System.Drawing.Size(90, 20);
            this.rbMeterReader.TabIndex = 148;
            this.rbMeterReader.TabStop = true;
            this.rbMeterReader.Text = "按抄表员";
            this.rbMeterReader.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(331, 92);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(80, 16);
            this.label42.TabIndex = 147;
            this.label42.Text = "统计方式:";
            // 
            // chkNullRead
            // 
            this.chkNullRead.AutoSize = true;
            this.chkNullRead.Checked = true;
            this.chkNullRead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNullRead.Location = new System.Drawing.Point(190, 91);
            this.chkNullRead.Name = "chkNullRead";
            this.chkNullRead.Size = new System.Drawing.Size(139, 20);
            this.chkNullRead.TabIndex = 145;
            this.chkNullRead.Text = "计算时包含未抄";
            this.chkNullRead.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 144;
            this.label3.Text = "期未收费";
            // 
            // txtCountPeriod
            // 
            this.txtCountPeriod.BackColor = System.Drawing.SystemColors.Window;
            this.txtCountPeriod.Location = new System.Drawing.Point(62, 87);
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
            this.txtSenior.Size = new System.Drawing.Size(173, 85);
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
            this.label6.Location = new System.Drawing.Point(25, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 116;
            this.label6.Text = "大于";
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterMeterType.DropDownWidth = 150;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Location = new System.Drawing.Point(469, 54);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterMeterType.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 114;
            this.label5.Text = "用水性质:";
            // 
            // cmbMeterReader
            // 
            this.cmbMeterReader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            // cmbWaterUserAgentBankSearch
            // 
            this.cmbWaterUserAgentBankSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserAgentBankSearch.DropDownWidth = 150;
            this.cmbWaterUserAgentBankSearch.FormattingEnabled = true;
            this.cmbWaterUserAgentBankSearch.Location = new System.Drawing.Point(283, 54);
            this.cmbWaterUserAgentBankSearch.Name = "cmbWaterUserAgentBankSearch";
            this.cmbWaterUserAgentBankSearch.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserAgentBankSearch.TabIndex = 62;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(206, 58);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(80, 16);
            this.label39.TabIndex = 60;
            this.label39.Text = "托收银行:";
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
            // cmbWaterUserIsAgentSearch
            // 
            this.cmbWaterUserIsAgentSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserIsAgentSearch.FormattingEnabled = true;
            this.cmbWaterUserIsAgentSearch.Items.AddRange(new object[] {
            "",
            "托收",
            "不托收"});
            this.cmbWaterUserIsAgentSearch.Location = new System.Drawing.Point(101, 54);
            this.cmbWaterUserIsAgentSearch.Name = "cmbWaterUserIsAgentSearch";
            this.cmbWaterUserIsAgentSearch.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterUserIsAgentSearch.TabIndex = 45;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(24, 58);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 16);
            this.label35.TabIndex = 44;
            this.label35.Text = "银行托收:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 356);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明细列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
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
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 35;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(996, 331);
            this.dgList.TabIndex = 5;
            this.dgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgList_CellFormatting);
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
            // frmWaterMeterDebtStatisc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterMeterDebtStatisc";
            this.Text = "水表未收情况统计";
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
        private System.Windows.Forms.ComboBox cmbWaterUserHouseType;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox cmbWaterUserIsAgentSearch;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbMeterReader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.Label label6;
        private FastReport.EnvironmentSettings environmentSettings1;
        private BASEFUNCTION.ucPageSetUp ucPageSetUp1;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCountPeriod;
        private System.Windows.Forms.CheckBox chkNullRead;
        private System.Windows.Forms.ToolStripButton toolExportToExl;
        private System.Windows.Forms.RadioButton rbArea;
        private System.Windows.Forms.RadioButton rbMeterReader;
        private System.Windows.Forms.RadioButton rbMeterReadingNO;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.RadioButton rbWaterMeter;
    }
}
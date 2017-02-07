namespace STATISTIALREPORTS
{
    partial class frmSalaryStatics
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
            FastReport.Design.DesignerSettings designerSettings1 = new FastReport.Design.DesignerSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalaryStatics));
            FastReport.Design.DesignerRestrictions designerRestrictions1 = new FastReport.Design.DesignerRestrictions();
            FastReport.Export.Email.EmailSettings emailSettings1 = new FastReport.Export.Email.EmailSettings();
            FastReport.PreviewSettings previewSettings1 = new FastReport.PreviewSettings();
            FastReport.ReportSettings reportSettings1 = new FastReport.ReportSettings();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolStatics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExcel = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMeterReaderS = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cmbCommunityS = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDuanNOS = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbAreaNOS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btSetMonth = new System.Windows.Forms.Button();
            this.dtpStartSearch = new System.Windows.Forms.DateTimePicker();
            this.dtpEndSearch = new System.Windows.Forms.DateTimePicker();
            this.chkWaterMeterTypeClass = new System.Windows.Forms.CheckBox();
            this.chkCommunity = new System.Windows.Forms.CheckBox();
            this.chkDuanNO = new System.Windows.Forms.CheckBox();
            this.chkAreaNO = new System.Windows.Forms.CheckBox();
            this.chkWaterUserType = new System.Windows.Forms.CheckBox();
            this.chkWaterMeterType = new System.Windows.Forms.CheckBox();
            this.chkRecordMonth = new System.Windows.Forms.CheckBox();
            this.chkMeterReader = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1021, 537);
            this.tb1.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.cmbMeterReaderS);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.cmbCommunityS);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbDuanNOS);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.cmbAreaNOS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btSetMonth);
            this.groupBox1.Controls.Add(this.dtpStartSearch);
            this.groupBox1.Controls.Add(this.dtpEndSearch);
            this.groupBox1.Controls.Add(this.chkWaterMeterTypeClass);
            this.groupBox1.Controls.Add(this.chkCommunity);
            this.groupBox1.Controls.Add(this.chkDuanNO);
            this.groupBox1.Controls.Add(this.chkAreaNO);
            this.groupBox1.Controls.Add(this.chkWaterUserType);
            this.groupBox1.Controls.Add(this.chkWaterMeterType);
            this.groupBox1.Controls.Add(this.chkRecordMonth);
            this.groupBox1.Controls.Add(this.chkMeterReader);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkChargeDateTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1015, 82);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "统计条件";
            // 
            // cmbMeterReaderS
            // 
            this.cmbMeterReaderS.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMeterReaderS.FormattingEnabled = true;
            this.cmbMeterReaderS.Location = new System.Drawing.Point(71, 21);
            this.cmbMeterReaderS.Name = "cmbMeterReaderS";
            this.cmbMeterReaderS.Size = new System.Drawing.Size(88, 23);
            this.cmbMeterReaderS.TabIndex = 185;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label36.Location = new System.Drawing.Point(11, 26);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(60, 15);
            this.label36.TabIndex = 186;
            this.label36.Text = "抄表员:";
            // 
            // cmbCommunityS
            // 
            this.cmbCommunityS.DropDownWidth = 120;
            this.cmbCommunityS.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCommunityS.FormattingEnabled = true;
            this.cmbCommunityS.Location = new System.Drawing.Point(472, 21);
            this.cmbCommunityS.Name = "cmbCommunityS";
            this.cmbCommunityS.Size = new System.Drawing.Size(141, 23);
            this.cmbCommunityS.TabIndex = 183;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(430, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 182;
            this.label5.Text = "小区:";
            // 
            // cmbDuanNOS
            // 
            this.cmbDuanNOS.DropDownWidth = 120;
            this.cmbDuanNOS.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDuanNOS.FormattingEnabled = true;
            this.cmbDuanNOS.Location = new System.Drawing.Point(344, 21);
            this.cmbDuanNOS.Name = "cmbDuanNOS";
            this.cmbDuanNOS.Size = new System.Drawing.Size(77, 23);
            this.cmbDuanNOS.TabIndex = 184;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(302, 26);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(45, 15);
            this.label35.TabIndex = 181;
            this.label35.Text = "段号:";
            // 
            // cmbAreaNOS
            // 
            this.cmbAreaNOS.DropDownWidth = 120;
            this.cmbAreaNOS.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbAreaNOS.FormattingEnabled = true;
            this.cmbAreaNOS.Location = new System.Drawing.Point(212, 21);
            this.cmbAreaNOS.Name = "cmbAreaNOS";
            this.cmbAreaNOS.Size = new System.Drawing.Size(77, 23);
            this.cmbAreaNOS.TabIndex = 180;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(169, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 179;
            this.label4.Text = "区号:";
            // 
            // btSetMonth
            // 
            this.btSetMonth.BackgroundImage = global::STATISTIALREPORTS.Properties.Resources.onebit_20;
            this.btSetMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetMonth.Location = new System.Drawing.Point(958, 22);
            this.btSetMonth.Name = "btSetMonth";
            this.btSetMonth.Size = new System.Drawing.Size(22, 23);
            this.btSetMonth.TabIndex = 178;
            this.btSetMonth.UseVisualStyleBackColor = true;
            this.btSetMonth.Click += new System.EventHandler(this.btSetMonth_Click);
            // 
            // dtpStartSearch
            // 
            this.dtpStartSearch.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStartSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartSearch.Location = new System.Drawing.Point(929, 50);
            this.dtpStartSearch.Name = "dtpStartSearch";
            this.dtpStartSearch.Size = new System.Drawing.Size(31, 26);
            this.dtpStartSearch.TabIndex = 174;
            this.dtpStartSearch.Visible = false;
            // 
            // dtpEndSearch
            // 
            this.dtpEndSearch.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpEndSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndSearch.Location = new System.Drawing.Point(966, 50);
            this.dtpEndSearch.Name = "dtpEndSearch";
            this.dtpEndSearch.Size = new System.Drawing.Size(31, 26);
            this.dtpEndSearch.TabIndex = 174;
            this.dtpEndSearch.Visible = false;
            // 
            // chkWaterMeterTypeClass
            // 
            this.chkWaterMeterTypeClass.AutoSize = true;
            this.chkWaterMeterTypeClass.Location = new System.Drawing.Point(293, 53);
            this.chkWaterMeterTypeClass.Name = "chkWaterMeterTypeClass";
            this.chkWaterMeterTypeClass.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterTypeClass.TabIndex = 164;
            this.chkWaterMeterTypeClass.Tag = "WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME";
            this.chkWaterMeterTypeClass.Text = "用水分类";
            this.chkWaterMeterTypeClass.UseVisualStyleBackColor = true;
            // 
            // chkCommunity
            // 
            this.chkCommunity.AutoSize = true;
            this.chkCommunity.Location = new System.Drawing.Point(626, 53);
            this.chkCommunity.Name = "chkCommunity";
            this.chkCommunity.Size = new System.Drawing.Size(59, 20);
            this.chkCommunity.TabIndex = 163;
            this.chkCommunity.Tag = "duanNO";
            this.chkCommunity.Text = "小区";
            this.chkCommunity.UseVisualStyleBackColor = true;
            // 
            // chkDuanNO
            // 
            this.chkDuanNO.AutoSize = true;
            this.chkDuanNO.Location = new System.Drawing.Point(561, 53);
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
            this.chkAreaNO.Location = new System.Drawing.Point(492, 53);
            this.chkAreaNO.Name = "chkAreaNO";
            this.chkAreaNO.Size = new System.Drawing.Size(59, 20);
            this.chkAreaNO.TabIndex = 163;
            this.chkAreaNO.Tag = "areaNO";
            this.chkAreaNO.Text = "区号";
            this.chkAreaNO.UseVisualStyleBackColor = true;
            // 
            // chkWaterUserType
            // 
            this.chkWaterUserType.AutoSize = true;
            this.chkWaterUserType.Location = new System.Drawing.Point(394, 53);
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
            this.chkWaterMeterType.Location = new System.Drawing.Point(192, 53);
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
            this.chkRecordMonth.Location = new System.Drawing.Point(91, 53);
            this.chkRecordMonth.Name = "chkRecordMonth";
            this.chkRecordMonth.Size = new System.Drawing.Size(91, 20);
            this.chkRecordMonth.TabIndex = 162;
            this.chkRecordMonth.Tag = "readMeterRecordYearAndMonth";
            this.chkRecordMonth.Text = "水费月份";
            this.chkRecordMonth.UseVisualStyleBackColor = true;
            // 
            // chkMeterReader
            // 
            this.chkMeterReader.AutoSize = true;
            this.chkMeterReader.Location = new System.Drawing.Point(14, 53);
            this.chkMeterReader.Name = "chkMeterReader";
            this.chkMeterReader.Size = new System.Drawing.Size(75, 20);
            this.chkMeterReader.TabIndex = 162;
            this.chkMeterReader.Tag = "METERREADERID,METERREADERNAME";
            this.chkMeterReader.Text = "抄表员";
            this.chkMeterReader.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(826, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 124;
            this.label8.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(850, 20);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 123;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(720, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 122;
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Checked = true;
            this.chkChargeDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChargeDateTime.Location = new System.Drawing.Point(628, 24);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkChargeDateTime.TabIndex = 121;
            this.chkChargeDateTime.Text = "水费月份:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1015, 439);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "应收统计表";
            // 
            // dgList
            // 
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
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.RowHeadersWidth = 45;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(1009, 414);
            this.dgList.TabIndex = 402;
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgList_DataBindingComplete);
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
            this.environmentSettings1.UseOffice2007Form = false;
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
            // frmSalaryStatics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSalaryStatics";
            this.Text = "工资统计表";
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
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.CheckBox chkRecordMonth;
        private System.Windows.Forms.CheckBox chkMeterReader;
        private System.Windows.Forms.CheckBox chkWaterUserType;
        private System.Windows.Forms.CheckBox chkWaterMeterType;
        private System.Windows.Forms.CheckBox chkWaterMeterTypeClass;
        private System.Windows.Forms.CheckBox chkDuanNO;
        private System.Windows.Forms.CheckBox chkAreaNO;
        private System.Windows.Forms.DateTimePicker dtpEndSearch;
        private System.Windows.Forms.DateTimePicker dtpStartSearch;
        private System.Windows.Forms.ToolStripButton toolExcel;
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
        private System.Windows.Forms.ComboBox cmbCommunityS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDuanNOS;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbAreaNOS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMeterReaderS;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox chkCommunity;
    }
}
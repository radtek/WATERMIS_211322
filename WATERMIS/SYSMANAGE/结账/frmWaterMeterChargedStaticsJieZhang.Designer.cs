namespace SYSMANAGE
{
    partial class frmWaterMeterChargedStaticsJieZhang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            FastReport.Design.DesignerSettings designerSettings5 = new FastReport.Design.DesignerSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterChargedStaticsJieZhang));
            FastReport.Design.DesignerRestrictions designerRestrictions5 = new FastReport.Design.DesignerRestrictions();
            FastReport.Export.Email.EmailSettings emailSettings5 = new FastReport.Export.Email.EmailSettings();
            FastReport.PreviewSettings previewSettings5 = new FastReport.PreviewSettings();
            FastReport.ReportSettings reportSettings5 = new FastReport.ReportSettings();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolStatics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSaveAccounts = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgListYingShou = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgListChenQian = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgListDangQi = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDateTimeEndSearch = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTimeStartSearch = new System.Windows.Forms.DateTimePicker();
            this.toolStripWaterUser.SuspendLayout();
            this.tb1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListYingShou)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListChenQian)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListDangQi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripWaterUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWaterUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatics,
            this.toolStripSeparator6,
            this.toolSaveAccounts});
            this.toolStripWaterUser.Location = new System.Drawing.Point(0, 0);
            this.toolStripWaterUser.Name = "toolStripWaterUser";
            this.toolStripWaterUser.Size = new System.Drawing.Size(1021, 25);
            this.toolStripWaterUser.TabIndex = 57;
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolStatics
            // 
            this.toolStatics.Image = global::SYSMANAGE.Properties.Resources.onebit_02;
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
            // toolSaveAccounts
            // 
            this.toolSaveAccounts.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolSaveAccounts.ForeColor = System.Drawing.Color.Red;
            this.toolSaveAccounts.Image = global::SYSMANAGE.Properties.Resources.msg_type_memo;
            this.toolSaveAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaveAccounts.Name = "toolSaveAccounts";
            this.toolSaveAccounts.Size = new System.Drawing.Size(62, 22);
            this.toolSaveAccounts.Tag = "9999";
            this.toolSaveAccounts.Text = "结账";
            this.toolSaveAccounts.Click += new System.EventHandler(this.toolSaveAccounts_Click);
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.tabControl1, 0, 1);
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1021, 537);
            this.tb1.TabIndex = 58;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1015, 464);
            this.tabControl1.TabIndex = 403;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgListYingShou);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1007, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "应收统计表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgListYingShou
            // 
            this.dgListYingShou.AllowUserToDeleteRows = false;
            this.dgListYingShou.AllowUserToOrderColumns = true;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgListYingShou.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgListYingShou.ColumnHeadersHeight = 25;
            this.dgListYingShou.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgListYingShou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListYingShou.Location = new System.Drawing.Point(3, 3);
            this.dgListYingShou.MultiSelect = false;
            this.dgListYingShou.Name = "dgListYingShou";
            this.dgListYingShou.ReadOnly = true;
            this.dgListYingShou.RowHeadersWidth = 45;
            this.dgListYingShou.RowTemplate.Height = 23;
            this.dgListYingShou.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgListYingShou.Size = new System.Drawing.Size(1001, 428);
            this.dgListYingShou.TabIndex = 403;
            this.dgListYingShou.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgListYingShou.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgListYingShou_DataBindingComplete);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1007, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "实收统计表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 428);
            this.tableLayoutPanel1.TabIndex = 904;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgListChenQian);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(995, 185);
            this.groupBox4.TabIndex = 904;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "实收统计表-陈欠";
            // 
            // dgListChenQian
            // 
            this.dgListChenQian.AllowUserToDeleteRows = false;
            this.dgListChenQian.AllowUserToOrderColumns = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgListChenQian.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgListChenQian.ColumnHeadersHeight = 25;
            this.dgListChenQian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgListChenQian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListChenQian.Location = new System.Drawing.Point(3, 22);
            this.dgListChenQian.MultiSelect = false;
            this.dgListChenQian.Name = "dgListChenQian";
            this.dgListChenQian.ReadOnly = true;
            this.dgListChenQian.RowHeadersWidth = 45;
            this.dgListChenQian.RowTemplate.Height = 23;
            this.dgListChenQian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgListChenQian.Size = new System.Drawing.Size(989, 160);
            this.dgListChenQian.TabIndex = 402;
            this.dgListChenQian.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgListChenQian.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgListChenQian_DataBindingComplete);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgListDangQi);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(995, 231);
            this.groupBox2.TabIndex = 903;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实收统计表-当期";
            // 
            // dgListDangQi
            // 
            this.dgListDangQi.AllowUserToDeleteRows = false;
            this.dgListDangQi.AllowUserToOrderColumns = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgListDangQi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgListDangQi.ColumnHeadersHeight = 25;
            this.dgListDangQi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgListDangQi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListDangQi.Location = new System.Drawing.Point(3, 22);
            this.dgListDangQi.MultiSelect = false;
            this.dgListDangQi.Name = "dgListDangQi";
            this.dgListDangQi.ReadOnly = true;
            this.dgListDangQi.RowHeadersWidth = 45;
            this.dgListDangQi.RowTemplate.Height = 23;
            this.dgListDangQi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgListDangQi.Size = new System.Drawing.Size(989, 206);
            this.dgListDangQi.TabIndex = 402;
            this.dgListDangQi.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgListDangQi.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgListDangQi_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDateTimeStartSearch);
            this.groupBox1.Controls.Add(this.dtpDateTimeEndSearch);
            this.groupBox1.Controls.Add(this.chkChargeDateTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1015, 57);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "统计条件";
            // 
            // dtpDateTimeEndSearch
            // 
            this.dtpDateTimeEndSearch.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpDateTimeEndSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTimeEndSearch.Location = new System.Drawing.Point(804, 21);
            this.dtpDateTimeEndSearch.Name = "dtpDateTimeEndSearch";
            this.dtpDateTimeEndSearch.ShowUpDown = true;
            this.dtpDateTimeEndSearch.Size = new System.Drawing.Size(86, 26);
            this.dtpDateTimeEndSearch.TabIndex = 123;
            this.dtpDateTimeEndSearch.Visible = false;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(271, 21);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 122;
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Checked = true;
            this.chkChargeDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChargeDateTime.Enabled = false;
            this.chkChargeDateTime.Location = new System.Drawing.Point(19, 24);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(115, 20);
            this.chkChargeDateTime.TabIndex = 121;
            this.chkChargeDateTime.Text = "结账时间段:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // environmentSettings1
            // 
            designerSettings5.ApplicationConnection = null;
            designerSettings5.DefaultFont = new System.Drawing.Font("宋体", 9F);
            designerSettings5.Icon = ((System.Drawing.Icon)(resources.GetObject("designerSettings5.Icon")));
            designerSettings5.Restrictions = designerRestrictions5;
            designerSettings5.Text = "";
            this.environmentSettings1.DesignerSettings = designerSettings5;
            emailSettings5.Address = "";
            emailSettings5.Host = "";
            emailSettings5.MessageTemplate = "";
            emailSettings5.Name = "";
            emailSettings5.Password = "";
            emailSettings5.UserName = "";
            this.environmentSettings1.EmailSettings = emailSettings5;
            previewSettings5.Buttons = ((FastReport.PreviewButtons)(((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save)
                        | FastReport.PreviewButtons.Zoom)
                        | FastReport.PreviewButtons.PageSetup)
                        | FastReport.PreviewButtons.Close)));
            previewSettings5.Icon = ((System.Drawing.Icon)(resources.GetObject("previewSettings5.Icon")));
            previewSettings5.Text = "";
            this.environmentSettings1.PreviewSettings = previewSettings5;
            this.environmentSettings1.ReportSettings = reportSettings5;
            this.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1001, 226);
            this.groupBox3.TabIndex = 903;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "实收统计表-当期";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 45;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(995, 206);
            this.dataGridView1.TabIndex = 402;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(129, 21);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 122;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 124;
            this.label1.Text = "至";
            // 
            // dtpDateTimeStartSearch
            // 
            this.dtpDateTimeStartSearch.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpDateTimeStartSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTimeStartSearch.Location = new System.Drawing.Point(712, 21);
            this.dtpDateTimeStartSearch.Name = "dtpDateTimeStartSearch";
            this.dtpDateTimeStartSearch.ShowUpDown = true;
            this.dtpDateTimeStartSearch.Size = new System.Drawing.Size(86, 26);
            this.dtpDateTimeStartSearch.TabIndex = 123;
            this.dtpDateTimeStartSearch.Visible = false;
            // 
            // frmWaterMeterChargedStaticsJieZhang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterMeterChargedStaticsJieZhang";
            this.Text = "月末结账";
            this.Load += new System.EventHandler(this.frmWaterUserSearch_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgListYingShou)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgListChenQian)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgListDangQi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolStatics;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.ToolStripButton toolSaveAccounts;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgListDangQi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgListChenQian;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgListYingShou;
        private System.Windows.Forms.DateTimePicker dtpDateTimeEndSearch;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateTimeStartSearch;
    }
}
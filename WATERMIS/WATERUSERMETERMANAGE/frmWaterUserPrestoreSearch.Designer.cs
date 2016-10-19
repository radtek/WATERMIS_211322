namespace WATERUSERMETERMANAGE
{
    partial class frmWaterUserPrestoreSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterUserPrestoreSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.tb2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolExportToExl = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbCharger = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYS = new System.Windows.Forms.TextBox();
            this.chkYS = new System.Windows.Forms.CheckBox();
            this.txtArearageLess = new System.Windows.Forms.TextBox();
            this.txtArearageGreater = new System.Windows.Forms.TextBox();
            this.chkArearageLess = new System.Windows.Forms.CheckBox();
            this.chkArearageGreater = new System.Windows.Forms.CheckBox();
            this.btSenior = new System.Windows.Forms.Button();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.cmbMeterReaderS = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.rbMeterReader = new System.Windows.Forms.RadioButton();
            this.txtWaterUserAddressS = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.cmbCommunityS = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cmbDuanNOS = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbPianNOS = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbAreaNOS = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbWaterUserName = new System.Windows.Forms.RadioButton();
            this.rbWaterUserNO = new System.Windows.Forms.RadioButton();
            this.label42 = new System.Windows.Forms.Label();
            this.txtWaterUserNameSearch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgWaterUser = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.waterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prestoreLast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTALFEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERAREARAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pianNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duanNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMUNITYNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordernumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTelphoneNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserHouseTypeS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentsign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prestore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb1.SuspendLayout();
            this.tb2.SuspendLayout();
            this.toolStripWaterUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterUser)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.tb2, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 1;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1008, 616);
            this.tb1.TabIndex = 0;
            // 
            // tb2
            // 
            this.tb2.ColumnCount = 1;
            this.tb2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1002F));
            this.tb2.Controls.Add(this.toolStripWaterUser, 0, 0);
            this.tb2.Controls.Add(this.groupBox1, 0, 1);
            this.tb2.Controls.Add(this.groupBox2, 0, 2);
            this.tb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb2.Location = new System.Drawing.Point(3, 3);
            this.tb2.Name = "tb2";
            this.tb2.RowCount = 3;
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tb2.Size = new System.Drawing.Size(1002, 610);
            this.tb2.TabIndex = 10;
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.toolStripWaterUser.Size = new System.Drawing.Size(1002, 28);
            this.toolStripWaterUser.TabIndex = 63;
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::WATERUSERMETERMANAGE.Properties.Resources.onebit_02;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(57, 25);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.btSearch_Click);
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
            this.toolPrint.Image = global::WATERUSERMETERMANAGE.Properties.Resources.print;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(57, 25);
            this.toolPrint.Text = "打印";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolPrintPreview
            // 
            this.toolPrintPreview.Enabled = false;
            this.toolPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolPrintPreview.Image")));
            this.toolPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintPreview.Name = "toolPrintPreview";
            this.toolPrintPreview.Size = new System.Drawing.Size(87, 25);
            this.toolPrintPreview.Text = "打印预览";
            this.toolPrintPreview.Click += new System.EventHandler(this.toolPrintPreview_Click);
            // 
            // toolExportToExl
            // 
            this.toolExportToExl.Enabled = false;
            this.toolExportToExl.Image = global::WATERUSERMETERMANAGE.Properties.Resources.snap_undo;
            this.toolExportToExl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExportToExl.Name = "toolExportToExl";
            this.toolExportToExl.Size = new System.Drawing.Size(97, 25);
            this.toolExportToExl.Text = "导出Excel";
            this.toolExportToExl.Click += new System.EventHandler(this.BtExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.cmbCharger);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtYS);
            this.groupBox1.Controls.Add(this.chkYS);
            this.groupBox1.Controls.Add(this.txtArearageLess);
            this.groupBox1.Controls.Add(this.txtArearageGreater);
            this.groupBox1.Controls.Add(this.chkArearageLess);
            this.groupBox1.Controls.Add(this.chkArearageGreater);
            this.groupBox1.Controls.Add(this.btSenior);
            this.groupBox1.Controls.Add(this.txtSenior);
            this.groupBox1.Controls.Add(this.cmbMeterReaderS);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.rbMeterReader);
            this.groupBox1.Controls.Add(this.txtWaterUserAddressS);
            this.groupBox1.Controls.Add(this.label51);
            this.groupBox1.Controls.Add(this.cmbCommunityS);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.cmbDuanNOS);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.cmbPianNOS);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cmbAreaNOS);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.rbWaterUserName);
            this.groupBox1.Controls.Add(this.rbWaterUserNO);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.txtWaterUserNameSearch);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.txtWaterUserNOSearch);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 118);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "查询条件";
            // 
            // cmbCharger
            // 
            this.cmbCharger.DropDownWidth = 120;
            this.cmbCharger.FormattingEnabled = true;
            this.cmbCharger.Location = new System.Drawing.Point(88, 86);
            this.cmbCharger.Name = "cmbCharger";
            this.cmbCharger.Size = new System.Drawing.Size(88, 24);
            this.cmbCharger.TabIndex = 162;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 161;
            this.label7.Text = "收费员:";
            // 
            // txtYS
            // 
            this.txtYS.BackColor = System.Drawing.SystemColors.Window;
            this.txtYS.Location = new System.Drawing.Point(583, 52);
            this.txtYS.Name = "txtYS";
            this.txtYS.Size = new System.Drawing.Size(67, 26);
            this.txtYS.TabIndex = 111;
            this.txtYS.Text = "0.1";
            this.txtYS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chkYS
            // 
            this.chkYS.AutoSize = true;
            this.chkYS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkYS.Location = new System.Drawing.Point(510, 57);
            this.chkYS.Name = "chkYS";
            this.chkYS.Size = new System.Drawing.Size(75, 18);
            this.chkYS.TabIndex = 110;
            this.chkYS.Text = "应收≥:";
            this.chkYS.UseVisualStyleBackColor = true;
            // 
            // txtArearageLess
            // 
            this.txtArearageLess.BackColor = System.Drawing.SystemColors.Window;
            this.txtArearageLess.Location = new System.Drawing.Point(268, 52);
            this.txtArearageLess.Name = "txtArearageLess";
            this.txtArearageLess.Size = new System.Drawing.Size(72, 26);
            this.txtArearageLess.TabIndex = 109;
            this.txtArearageLess.Text = "0";
            this.txtArearageLess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // txtArearageGreater
            // 
            this.txtArearageGreater.BackColor = System.Drawing.SystemColors.Window;
            this.txtArearageGreater.Location = new System.Drawing.Point(431, 52);
            this.txtArearageGreater.Name = "txtArearageGreater";
            this.txtArearageGreater.Size = new System.Drawing.Size(67, 26);
            this.txtArearageGreater.TabIndex = 108;
            this.txtArearageGreater.Text = "0.1";
            this.txtArearageGreater.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // chkArearageLess
            // 
            this.chkArearageLess.AutoSize = true;
            this.chkArearageLess.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkArearageLess.Location = new System.Drawing.Point(197, 57);
            this.chkArearageLess.Name = "chkArearageLess";
            this.chkArearageLess.Size = new System.Drawing.Size(75, 18);
            this.chkArearageLess.TabIndex = 106;
            this.chkArearageLess.Text = "欠费≤:";
            this.chkArearageLess.UseVisualStyleBackColor = true;
            // 
            // chkArearageGreater
            // 
            this.chkArearageGreater.AutoSize = true;
            this.chkArearageGreater.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkArearageGreater.Location = new System.Drawing.Point(358, 57);
            this.chkArearageGreater.Name = "chkArearageGreater";
            this.chkArearageGreater.Size = new System.Drawing.Size(75, 18);
            this.chkArearageGreater.TabIndex = 107;
            this.chkArearageGreater.Text = "欠费≥:";
            this.chkArearageGreater.UseVisualStyleBackColor = true;
            // 
            // btSenior
            // 
            this.btSenior.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSenior.Location = new System.Drawing.Point(697, 50);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(84, 30);
            this.btSenior.TabIndex = 105;
            this.btSenior.Tag = "9999";
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = false;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.SystemColors.Window;
            this.txtSenior.Location = new System.Drawing.Point(787, 52);
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(161, 26);
            this.txtSenior.TabIndex = 104;
            // 
            // cmbMeterReaderS
            // 
            this.cmbMeterReaderS.FormattingEnabled = true;
            this.cmbMeterReaderS.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.cmbMeterReaderS.Location = new System.Drawing.Point(88, 54);
            this.cmbMeterReaderS.Name = "cmbMeterReaderS";
            this.cmbMeterReaderS.Size = new System.Drawing.Size(88, 24);
            this.cmbMeterReaderS.TabIndex = 102;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(27, 58);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(72, 16);
            this.label37.TabIndex = 101;
            this.label37.Text = "抄表员：";
            // 
            // rbMeterReader
            // 
            this.rbMeterReader.AutoSize = true;
            this.rbMeterReader.Checked = true;
            this.rbMeterReader.Location = new System.Drawing.Point(492, 89);
            this.rbMeterReader.Name = "rbMeterReader";
            this.rbMeterReader.Size = new System.Drawing.Size(90, 20);
            this.rbMeterReader.TabIndex = 99;
            this.rbMeterReader.TabStop = true;
            this.rbMeterReader.Text = "按抄表员";
            this.rbMeterReader.UseVisualStyleBackColor = true;
            // 
            // txtWaterUserAddressS
            // 
            this.txtWaterUserAddressS.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserAddressS.Location = new System.Drawing.Point(445, 19);
            this.txtWaterUserAddressS.Name = "txtWaterUserAddressS";
            this.txtWaterUserAddressS.Size = new System.Drawing.Size(104, 26);
            this.txtWaterUserAddressS.TabIndex = 97;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(368, 24);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(88, 16);
            this.label51.TabIndex = 96;
            this.label51.Text = "用户地址：";
            // 
            // cmbCommunityS
            // 
            this.cmbCommunityS.DropDownWidth = 120;
            this.cmbCommunityS.FormattingEnabled = true;
            this.cmbCommunityS.Location = new System.Drawing.Point(268, 86);
            this.cmbCommunityS.Name = "cmbCommunityS";
            this.cmbCommunityS.Size = new System.Drawing.Size(126, 24);
            this.cmbCommunityS.TabIndex = 95;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(192, 90);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 16);
            this.label36.TabIndex = 94;
            this.label36.Text = "小区名称:";
            // 
            // cmbDuanNOS
            // 
            this.cmbDuanNOS.DropDownWidth = 120;
            this.cmbDuanNOS.FormattingEnabled = true;
            this.cmbDuanNOS.Location = new System.Drawing.Point(867, 20);
            this.cmbDuanNOS.Name = "cmbDuanNOS";
            this.cmbDuanNOS.Size = new System.Drawing.Size(81, 24);
            this.cmbDuanNOS.TabIndex = 93;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(824, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 16);
            this.label35.TabIndex = 92;
            this.label35.Text = "段号：";
            // 
            // cmbPianNOS
            // 
            this.cmbPianNOS.DropDownWidth = 120;
            this.cmbPianNOS.FormattingEnabled = true;
            this.cmbPianNOS.Location = new System.Drawing.Point(604, 19);
            this.cmbPianNOS.Name = "cmbPianNOS";
            this.cmbPianNOS.Size = new System.Drawing.Size(81, 24);
            this.cmbPianNOS.TabIndex = 91;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(562, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 90;
            this.label21.Text = "片号：";
            // 
            // cmbAreaNOS
            // 
            this.cmbAreaNOS.DropDownWidth = 120;
            this.cmbAreaNOS.FormattingEnabled = true;
            this.cmbAreaNOS.Location = new System.Drawing.Point(736, 19);
            this.cmbAreaNOS.Name = "cmbAreaNOS";
            this.cmbAreaNOS.Size = new System.Drawing.Size(81, 24);
            this.cmbAreaNOS.TabIndex = 89;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(691, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 88;
            this.label9.Text = "区号：";
            // 
            // rbWaterUserName
            // 
            this.rbWaterUserName.AutoSize = true;
            this.rbWaterUserName.Location = new System.Drawing.Point(664, 89);
            this.rbWaterUserName.Name = "rbWaterUserName";
            this.rbWaterUserName.Size = new System.Drawing.Size(74, 20);
            this.rbWaterUserName.TabIndex = 70;
            this.rbWaterUserName.Text = "按姓名";
            this.rbWaterUserName.UseVisualStyleBackColor = true;
            // 
            // rbWaterUserNO
            // 
            this.rbWaterUserNO.AutoSize = true;
            this.rbWaterUserNO.Location = new System.Drawing.Point(586, 89);
            this.rbWaterUserNO.Name = "rbWaterUserNO";
            this.rbWaterUserNO.Size = new System.Drawing.Size(74, 20);
            this.rbWaterUserNO.TabIndex = 69;
            this.rbWaterUserNO.Text = "按户号";
            this.rbWaterUserNO.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(411, 90);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(88, 16);
            this.label42.TabIndex = 68;
            this.label42.Text = "排序方式：";
            // 
            // txtWaterUserNameSearch
            // 
            this.txtWaterUserNameSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNameSearch.Location = new System.Drawing.Point(268, 19);
            this.txtWaterUserNameSearch.Name = "txtWaterUserNameSearch";
            this.txtWaterUserNameSearch.Size = new System.Drawing.Size(88, 26);
            this.txtWaterUserNameSearch.TabIndex = 66;
            this.txtWaterUserNameSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(192, 24);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(80, 16);
            this.label41.TabIndex = 65;
            this.label41.Text = "用户名称:";
            // 
            // txtWaterUserNOSearch
            // 
            this.txtWaterUserNOSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNOSearch.Location = new System.Drawing.Point(88, 19);
            this.txtWaterUserNOSearch.Name = "txtWaterUserNOSearch";
            this.txtWaterUserNOSearch.Size = new System.Drawing.Size(88, 26);
            this.txtWaterUserNOSearch.TabIndex = 64;
            this.txtWaterUserNOSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(6, 24);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(93, 16);
            this.label40.TabIndex = 63;
            this.label40.Text = "用户编号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgWaterUser);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(996, 448);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户列表";
            // 
            // dgWaterUser
            // 
            this.dgWaterUser.AllowUserToDeleteRows = false;
            this.dgWaterUser.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWaterUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWaterUser.ColumnHeadersHeight = 25;
            this.dgWaterUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.waterUserNO,
            this.waterUserName,
            this.prestoreLast,
            this.TOTALFEE,
            this.USERAREARAGE,
            this.waterUserAddress,
            this.meterReaderName,
            this.chargerName,
            this.areaNO,
            this.pianNO,
            this.duanNO,
            this.COMMUNITYNAME,
            this.ordernumber,
            this.waterUserTelphoneNO,
            this.waterPhone,
            this.waterUserTypeName,
            this.waterUserHouseTypeS,
            this.agentsign,
            this.waterUserId,
            this.prestore});
            this.dgWaterUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWaterUser.Location = new System.Drawing.Point(3, 22);
            this.dgWaterUser.MultiSelect = false;
            this.dgWaterUser.Name = "dgWaterUser";
            this.dgWaterUser.ReadOnly = true;
            this.dgWaterUser.RowHeadersWidth = 40;
            this.dgWaterUser.RowTemplate.Height = 23;
            this.dgWaterUser.Size = new System.Drawing.Size(990, 423);
            this.dgWaterUser.TabIndex = 61;
            this.dgWaterUser.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgWaterUser_CellPainting);
            this.dgWaterUser.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgWaterUser_EditingControlShowing);
            this.dgWaterUser.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgWaterUser_DataBindingComplete);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "open.ico");
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
            // prestoreLast
            // 
            this.prestoreLast.DataPropertyName = "prestore";
            this.prestoreLast.HeaderText = "prestoreLast";
            this.prestoreLast.Name = "prestoreLast";
            this.prestoreLast.ReadOnly = true;
            this.prestoreLast.Visible = false;
            this.prestoreLast.Width = 5;
            // 
            // TOTALFEE
            // 
            this.TOTALFEE.DataPropertyName = "TOTALFEE";
            this.TOTALFEE.HeaderText = "欠费总计";
            this.TOTALFEE.Name = "TOTALFEE";
            this.TOTALFEE.ReadOnly = true;
            // 
            // USERAREARAGE
            // 
            this.USERAREARAGE.DataPropertyName = "USERAREARAGE";
            this.USERAREARAGE.HeaderText = "结算余额";
            this.USERAREARAGE.Name = "USERAREARAGE";
            this.USERAREARAGE.ReadOnly = true;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.HeaderText = "地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            // 
            // meterReaderName
            // 
            this.meterReaderName.DataPropertyName = "meterReaderName";
            this.meterReaderName.HeaderText = "抄表员";
            this.meterReaderName.Name = "meterReaderName";
            this.meterReaderName.ReadOnly = true;
            // 
            // chargerName
            // 
            this.chargerName.DataPropertyName = "chargerName";
            this.chargerName.HeaderText = "收费员";
            this.chargerName.Name = "chargerName";
            this.chargerName.ReadOnly = true;
            // 
            // areaNO
            // 
            this.areaNO.DataPropertyName = "areaNO";
            this.areaNO.HeaderText = "区号";
            this.areaNO.Name = "areaNO";
            this.areaNO.ReadOnly = true;
            // 
            // pianNO
            // 
            this.pianNO.DataPropertyName = "pianNO";
            this.pianNO.HeaderText = "片号";
            this.pianNO.Name = "pianNO";
            this.pianNO.ReadOnly = true;
            // 
            // duanNO
            // 
            this.duanNO.DataPropertyName = "duanNO";
            this.duanNO.HeaderText = "段号";
            this.duanNO.Name = "duanNO";
            this.duanNO.ReadOnly = true;
            // 
            // COMMUNITYNAME
            // 
            this.COMMUNITYNAME.DataPropertyName = "COMMUNITYNAME";
            this.COMMUNITYNAME.HeaderText = "小区名称";
            this.COMMUNITYNAME.Name = "COMMUNITYNAME";
            this.COMMUNITYNAME.ReadOnly = true;
            // 
            // ordernumber
            // 
            this.ordernumber.DataPropertyName = "ordernumber";
            this.ordernumber.HeaderText = "顺序号";
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.ReadOnly = true;
            this.ordernumber.Width = 81;
            // 
            // waterUserTelphoneNO
            // 
            this.waterUserTelphoneNO.DataPropertyName = "waterUserTelphoneNO";
            this.waterUserTelphoneNO.HeaderText = "手机号";
            this.waterUserTelphoneNO.Name = "waterUserTelphoneNO";
            this.waterUserTelphoneNO.ReadOnly = true;
            // 
            // waterPhone
            // 
            this.waterPhone.DataPropertyName = "waterPhone";
            this.waterPhone.HeaderText = "固定电话";
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.ReadOnly = true;
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
            this.waterUserId.Width = 5;
            // 
            // prestore
            // 
            this.prestore.DataPropertyName = "prestore";
            this.prestore.HeaderText = "账户余额";
            this.prestore.Name = "prestore";
            this.prestore.ReadOnly = true;
            this.prestore.Width = 97;
            // 
            // frmWaterUserPrestoreSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 616);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterUserPrestoreSearch";
            this.Text = "用水用户账户余额查询";
            this.Load += new System.EventHandler(this.frmWaterUserPrestoreInitial_Load);
            this.tb1.ResumeLayout(false);
            this.tb2.ResumeLayout(false);
            this.tb2.PerformLayout();
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tb2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMeterReader;
        private System.Windows.Forms.TextBox txtWaterUserAddressS;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.ComboBox cmbCommunityS;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox cmbDuanNOS;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbPianNOS;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbAreaNOS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbWaterUserName;
        private System.Windows.Forms.RadioButton rbWaterUserNO;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtWaterUserNameSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgWaterUser;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.ComboBox cmbMeterReaderS;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtYS;
        private System.Windows.Forms.CheckBox chkYS;
        private System.Windows.Forms.TextBox txtArearageLess;
        private System.Windows.Forms.TextBox txtArearageGreater;
        private System.Windows.Forms.CheckBox chkArearageLess;
        private System.Windows.Forms.CheckBox chkArearageGreater;
        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.ToolStripButton toolExportToExl;
        private System.Windows.Forms.ComboBox cmbCharger;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn prestoreLast;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTALFEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERAREARAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn pianNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn duanNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMUNITYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTelphoneNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserHouseTypeS;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentsign;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn prestore;

    }
}
namespace STATISTIALREPORTS
{
    partial class frmWaterMeterChargePercent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterChargePercent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMeterReader = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCharger = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.btSenior = new System.Windows.Forms.Button();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpMeterReadYearMonthEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpMeterReadYearMonthStart = new System.Windows.Forms.DateTimePicker();
            this.chkMeterReadYearMonth = new System.Windows.Forms.CheckBox();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWaterUserNameSearch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.toolExcel = new System.Windows.Forms.ToolStripButton();
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
            // toolPrint
            // 
            this.toolPrint.Enabled = false;
            this.toolPrint.Image = global::STATISTIALREPORTS.Properties.Resources.打印;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(57, 22);
            this.toolPrint.Text = "打印";
            this.toolPrint.Visible = false;
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
            this.toolPrintPreview.Visible = false;
            this.toolPrintPreview.Click += new System.EventHandler(this.toolPrintPreview_Click);
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.cmbMeterReader);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCharger);
            this.groupBox1.Controls.Add(this.label7);
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
            this.groupBox1.Controls.Add(this.btSenior);
            this.groupBox1.Controls.Add(this.txtSenior);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpMeterReadYearMonthEnd);
            this.groupBox1.Controls.Add(this.dtpMeterReadYearMonthStart);
            this.groupBox1.Controls.Add(this.chkMeterReadYearMonth);
            this.groupBox1.Controls.Add(this.cmbWaterMeterType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtWaterUserNameSearch);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.txtWaterUserNOSearch);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 117);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "查询条件";
            // 
            // cmbMeterReader
            // 
            this.cmbMeterReader.DropDownWidth = 200;
            this.cmbMeterReader.FormattingEnabled = true;
            this.cmbMeterReader.Location = new System.Drawing.Point(484, 23);
            this.cmbMeterReader.Name = "cmbMeterReader";
            this.cmbMeterReader.Size = new System.Drawing.Size(88, 24);
            this.cmbMeterReader.TabIndex = 194;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 195;
            this.label1.Text = "抄 表 员:";
            // 
            // cmbCharger
            // 
            this.cmbCharger.DropDownWidth = 120;
            this.cmbCharger.FormattingEnabled = true;
            this.cmbCharger.Location = new System.Drawing.Point(100, 55);
            this.cmbCharger.Name = "cmbCharger";
            this.cmbCharger.Size = new System.Drawing.Size(88, 24);
            this.cmbCharger.TabIndex = 193;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 192;
            this.label7.Text = "收 费 员:";
            // 
            // chkWaterMeterTypeClass
            // 
            this.chkWaterMeterTypeClass.AutoSize = true;
            this.chkWaterMeterTypeClass.Location = new System.Drawing.Point(401, 90);
            this.chkWaterMeterTypeClass.Name = "chkWaterMeterTypeClass";
            this.chkWaterMeterTypeClass.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterTypeClass.TabIndex = 189;
            this.chkWaterMeterTypeClass.Tag = "WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME";
            this.chkWaterMeterTypeClass.Text = "用水分类";
            this.chkWaterMeterTypeClass.UseVisualStyleBackColor = true;
            // 
            // chkWaterUserState
            // 
            this.chkWaterUserState.AutoSize = true;
            this.chkWaterUserState.Location = new System.Drawing.Point(810, 90);
            this.chkWaterUserState.Name = "chkWaterUserState";
            this.chkWaterUserState.Size = new System.Drawing.Size(91, 20);
            this.chkWaterUserState.TabIndex = 186;
            this.chkWaterUserState.Text = "用户状态";
            this.chkWaterUserState.UseVisualStyleBackColor = true;
            this.chkWaterUserState.Visible = false;
            // 
            // chkDuanNO
            // 
            this.chkDuanNO.AutoSize = true;
            this.chkDuanNO.Location = new System.Drawing.Point(741, 90);
            this.chkDuanNO.Name = "chkDuanNO";
            this.chkDuanNO.Size = new System.Drawing.Size(59, 20);
            this.chkDuanNO.TabIndex = 185;
            this.chkDuanNO.Tag = "duanNO";
            this.chkDuanNO.Text = "段号";
            this.chkDuanNO.UseVisualStyleBackColor = true;
            // 
            // chkAreaNO
            // 
            this.chkAreaNO.AutoSize = true;
            this.chkAreaNO.Location = new System.Drawing.Point(672, 90);
            this.chkAreaNO.Name = "chkAreaNO";
            this.chkAreaNO.Size = new System.Drawing.Size(59, 20);
            this.chkAreaNO.TabIndex = 188;
            this.chkAreaNO.Tag = "areaNO";
            this.chkAreaNO.Text = "区号";
            this.chkAreaNO.UseVisualStyleBackColor = true;
            // 
            // chkPianNO
            // 
            this.chkPianNO.AutoSize = true;
            this.chkPianNO.Location = new System.Drawing.Point(603, 90);
            this.chkPianNO.Name = "chkPianNO";
            this.chkPianNO.Size = new System.Drawing.Size(59, 20);
            this.chkPianNO.TabIndex = 187;
            this.chkPianNO.Tag = "pianNO";
            this.chkPianNO.Text = "片号";
            this.chkPianNO.UseVisualStyleBackColor = true;
            // 
            // chkWaterUserType
            // 
            this.chkWaterUserType.AutoSize = true;
            this.chkWaterUserType.Location = new System.Drawing.Point(502, 90);
            this.chkWaterUserType.Name = "chkWaterUserType";
            this.chkWaterUserType.Size = new System.Drawing.Size(91, 20);
            this.chkWaterUserType.TabIndex = 184;
            this.chkWaterUserType.Tag = "waterUserTypeId,waterUserTypeName";
            this.chkWaterUserType.Text = "用户类别";
            this.chkWaterUserType.UseVisualStyleBackColor = true;
            // 
            // chkWaterMeterType
            // 
            this.chkWaterMeterType.AutoSize = true;
            this.chkWaterMeterType.Location = new System.Drawing.Point(300, 90);
            this.chkWaterMeterType.Name = "chkWaterMeterType";
            this.chkWaterMeterType.Size = new System.Drawing.Size(91, 20);
            this.chkWaterMeterType.TabIndex = 181;
            this.chkWaterMeterType.Tag = "WATERMETERTYPEID,waterMeterTypeName";
            this.chkWaterMeterType.Text = "用水性质";
            this.chkWaterMeterType.UseVisualStyleBackColor = true;
            // 
            // chkRecordMonth
            // 
            this.chkRecordMonth.AutoSize = true;
            this.chkRecordMonth.Location = new System.Drawing.Point(199, 90);
            this.chkRecordMonth.Name = "chkRecordMonth";
            this.chkRecordMonth.Size = new System.Drawing.Size(91, 20);
            this.chkRecordMonth.TabIndex = 180;
            this.chkRecordMonth.Tag = "readMeterRecordYearAndMonth";
            this.chkRecordMonth.Text = "水费月份";
            this.chkRecordMonth.UseVisualStyleBackColor = true;
            // 
            // chkCharger
            // 
            this.chkCharger.AutoSize = true;
            this.chkCharger.Location = new System.Drawing.Point(114, 90);
            this.chkCharger.Name = "chkCharger";
            this.chkCharger.Size = new System.Drawing.Size(75, 20);
            this.chkCharger.TabIndex = 183;
            this.chkCharger.Tag = "CHARGERID,CHARGERNAME";
            this.chkCharger.Text = "收费员";
            this.chkCharger.UseVisualStyleBackColor = true;
            // 
            // chkMeterReader
            // 
            this.chkMeterReader.AutoSize = true;
            this.chkMeterReader.Location = new System.Drawing.Point(29, 90);
            this.chkMeterReader.Name = "chkMeterReader";
            this.chkMeterReader.Size = new System.Drawing.Size(75, 20);
            this.chkMeterReader.TabIndex = 182;
            this.chkMeterReader.Tag = "METERREADERID,METERREADERNAME";
            this.chkMeterReader.Text = "抄表员";
            this.chkMeterReader.UseVisualStyleBackColor = true;
            // 
            // btSenior
            // 
            this.btSenior.Location = new System.Drawing.Point(851, 21);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(50, 45);
            this.btSenior.TabIndex = 178;
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = true;
            this.btSenior.Visible = false;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.Color.White;
            this.txtSenior.Location = new System.Drawing.Point(600, 22);
            this.txtSenior.Multiline = true;
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(241, 25);
            this.txtSenior.TabIndex = 179;
            this.txtSenior.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 123;
            this.label4.Text = "至";
            // 
            // dtpMeterReadYearMonthEnd
            // 
            this.dtpMeterReadYearMonthEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpMeterReadYearMonthEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMeterReadYearMonthEnd.Location = new System.Drawing.Point(600, 55);
            this.dtpMeterReadYearMonthEnd.Name = "dtpMeterReadYearMonthEnd";
            this.dtpMeterReadYearMonthEnd.ShowUpDown = true;
            this.dtpMeterReadYearMonthEnd.Size = new System.Drawing.Size(79, 26);
            this.dtpMeterReadYearMonthEnd.TabIndex = 122;
            // 
            // dtpMeterReadYearMonthStart
            // 
            this.dtpMeterReadYearMonthStart.CustomFormat = "yyyy-MM-dd";
            this.dtpMeterReadYearMonthStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMeterReadYearMonthStart.Location = new System.Drawing.Point(485, 55);
            this.dtpMeterReadYearMonthStart.Name = "dtpMeterReadYearMonthStart";
            this.dtpMeterReadYearMonthStart.ShowUpDown = true;
            this.dtpMeterReadYearMonthStart.Size = new System.Drawing.Size(87, 26);
            this.dtpMeterReadYearMonthStart.TabIndex = 121;
            // 
            // chkMeterReadYearMonth
            // 
            this.chkMeterReadYearMonth.AutoSize = true;
            this.chkMeterReadYearMonth.Checked = true;
            this.chkMeterReadYearMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMeterReadYearMonth.Location = new System.Drawing.Point(392, 59);
            this.chkMeterReadYearMonth.Name = "chkMeterReadYearMonth";
            this.chkMeterReadYearMonth.Size = new System.Drawing.Size(99, 20);
            this.chkMeterReadYearMonth.TabIndex = 120;
            this.chkMeterReadYearMonth.Text = "抄表月份:";
            this.chkMeterReadYearMonth.UseVisualStyleBackColor = true;
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownWidth = 200;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Location = new System.Drawing.Point(283, 55);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(88, 24);
            this.cmbWaterMeterType.TabIndex = 113;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 114;
            this.label5.Text = "用水性质:";
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
            this.label40.Location = new System.Drawing.Point(23, 26);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(80, 16);
            this.label40.TabIndex = 63;
            this.label40.Text = "用户编号:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 404);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 25;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(996, 379);
            this.dgList.TabIndex = 2;
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgList_DataBindingComplete);
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
            // frmWaterMeterChargePercent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterMeterChargePercent";
            this.Text = "水表收费率统计";
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkWaterMeterTypeClass;
        private System.Windows.Forms.CheckBox chkWaterUserState;
        private System.Windows.Forms.CheckBox chkDuanNO;
        private System.Windows.Forms.CheckBox chkAreaNO;
        private System.Windows.Forms.CheckBox chkPianNO;
        private System.Windows.Forms.CheckBox chkWaterUserType;
        private System.Windows.Forms.CheckBox chkWaterMeterType;
        private System.Windows.Forms.CheckBox chkRecordMonth;
        private System.Windows.Forms.CheckBox chkCharger;
        private System.Windows.Forms.CheckBox chkMeterReader;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpMeterReadYearMonthEnd;
        private System.Windows.Forms.DateTimePicker dtpMeterReadYearMonthStart;
        private System.Windows.Forms.CheckBox chkMeterReadYearMonth;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWaterUserNameSearch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cmbCharger;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMeterReader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolExcel;
    }
}
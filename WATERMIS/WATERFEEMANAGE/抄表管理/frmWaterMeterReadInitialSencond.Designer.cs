namespace WATERFEEMANAGE
{
    partial class frmWaterMeterReadInitialSencond
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterReadInitialSencond));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.waterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pianNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duanNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordernumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMUNITYNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labCount = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trMeterReading = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btChangeEndNumber = new System.Windows.Forms.Button();
            this.labProgress = new System.Windows.Forms.Label();
            this.prb = new System.Windows.Forms.ProgressBar();
            this.btInitial = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.txtWaterMeterNO = new System.Windows.Forms.TextBox();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.cmbPianNOS = new System.Windows.Forms.ComboBox();
            this.cmbAreaNOS = new System.Windows.Forms.ComboBox();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.cmbCommunityS = new System.Windows.Forms.ComboBox();
            this.cmbWaterUserTypeSearch = new System.Windows.Forms.ComboBox();
            this.txtYearAndMonth = new System.Windows.Forms.TextBox();
            this.cmbDuanNOS = new System.Windows.Forms.ComboBox();
            this.cmbChargerS = new System.Windows.Forms.ComboBox();
            this.btSenior = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labTip = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btLeft = new System.Windows.Forms.Button();
            this.btRight = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYearAndMonthSave = new System.Windows.Forms.TextBox();
            this.bgWork = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 516);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgList);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 346);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "抄表初始化信息";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.waterUserId,
            this.waterUserNO,
            this.waterUserName,
            this.waterUserAddress,
            this.pianNO,
            this.areaNO,
            this.duanNO,
            this.ordernumber,
            this.waterMeterId,
            this.waterMeterNo,
            this.COMMUNITYNAME,
            this.buildingNO,
            this.unitNO,
            this.meterReaderName,
            this.chargerName});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(151, 22);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(692, 291);
            this.dgList.TabIndex = 11;
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            // 
            // waterUserId
            // 
            this.waterUserId.DataPropertyName = "waterUserId";
            this.waterUserId.HeaderText = "waterUserId";
            this.waterUserId.Name = "waterUserId";
            this.waterUserId.ReadOnly = true;
            this.waterUserId.Visible = false;
            this.waterUserId.Width = 121;
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
            this.waterUserName.HeaderText = "用户名";
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.ReadOnly = true;
            this.waterUserName.Width = 81;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.HeaderText = "地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            this.waterUserAddress.Width = 200;
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
            this.ordernumber.HeaderText = "抄表顺序";
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.ReadOnly = true;
            this.ordernumber.Width = 97;
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
            // COMMUNITYNAME
            // 
            this.COMMUNITYNAME.DataPropertyName = "COMMUNITYNAME";
            this.COMMUNITYNAME.HeaderText = "小区名称";
            this.COMMUNITYNAME.Name = "COMMUNITYNAME";
            this.COMMUNITYNAME.ReadOnly = true;
            this.COMMUNITYNAME.Width = 97;
            // 
            // buildingNO
            // 
            this.buildingNO.DataPropertyName = "buildingNO";
            this.buildingNO.HeaderText = "楼号";
            this.buildingNO.Name = "buildingNO";
            this.buildingNO.ReadOnly = true;
            this.buildingNO.Width = 65;
            // 
            // unitNO
            // 
            this.unitNO.DataPropertyName = "unitNO";
            this.unitNO.HeaderText = "单元号";
            this.unitNO.Name = "unitNO";
            this.unitNO.ReadOnly = true;
            this.unitNO.Width = 81;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.labCount);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(151, 313);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(692, 30);
            this.panel4.TabIndex = 10;
            // 
            // labCount
            // 
            this.labCount.AutoSize = true;
            this.labCount.Location = new System.Drawing.Point(6, 7);
            this.labCount.Name = "labCount";
            this.labCount.Size = new System.Drawing.Size(176, 16);
            this.labCount.TabIndex = 8;
            this.labCount.Text = "用户数量:0;水表数量:0";
            this.labCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.trMeterReading);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(148, 321);
            this.panel3.TabIndex = 6;
            // 
            // trMeterReading
            // 
            this.trMeterReading.BackColor = System.Drawing.SystemColors.Window;
            this.trMeterReading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trMeterReading.FullRowSelect = true;
            this.trMeterReading.HideSelection = false;
            this.trMeterReading.ImageIndex = 0;
            this.trMeterReading.ImageList = this.imageList1;
            this.trMeterReading.ItemHeight = 22;
            this.trMeterReading.Location = new System.Drawing.Point(0, 0);
            this.trMeterReading.Margin = new System.Windows.Forms.Padding(0);
            this.trMeterReading.Name = "trMeterReading";
            this.trMeterReading.SelectedImageIndex = 1;
            this.trMeterReading.Size = new System.Drawing.Size(148, 321);
            this.trMeterReading.TabIndex = 10;
            this.trMeterReading.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trMeterReading_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "open.ico");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btChangeEndNumber);
            this.panel2.Controls.Add(this.labProgress);
            this.panel2.Controls.Add(this.prb);
            this.panel2.Controls.Add(this.btInitial);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 475);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 38);
            this.panel2.TabIndex = 2;
            // 
            // btChangeEndNumber
            // 
            this.btChangeEndNumber.Location = new System.Drawing.Point(624, 4);
            this.btChangeEndNumber.Name = "btChangeEndNumber";
            this.btChangeEndNumber.Size = new System.Drawing.Size(89, 30);
            this.btChangeEndNumber.TabIndex = 4;
            this.btChangeEndNumber.Text = "表底变更";
            this.btChangeEndNumber.UseVisualStyleBackColor = true;
            this.btChangeEndNumber.Click += new System.EventHandler(this.btChangeEndNumber_Click);
            // 
            // labProgress
            // 
            this.labProgress.AutoSize = true;
            this.labProgress.BackColor = System.Drawing.Color.Transparent;
            this.labProgress.Location = new System.Drawing.Point(339, 13);
            this.labProgress.Name = "labProgress";
            this.labProgress.Size = new System.Drawing.Size(72, 16);
            this.labProgress.TabIndex = 3;
            this.labProgress.Tag = "9999";
            this.labProgress.Text = "进度:0/0";
            // 
            // prb
            // 
            this.prb.Location = new System.Drawing.Point(206, 7);
            this.prb.Name = "prb";
            this.prb.Size = new System.Drawing.Size(383, 25);
            this.prb.TabIndex = 2;
            // 
            // btInitial
            // 
            this.btInitial.Location = new System.Drawing.Point(125, 5);
            this.btInitial.Name = "btInitial";
            this.btInitial.Size = new System.Drawing.Size(75, 30);
            this.btInitial.TabIndex = 0;
            this.btInitial.Text = "初始化";
            this.btInitial.UseVisualStyleBackColor = true;
            this.btInitial.Click += new System.EventHandler(this.btInitial_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.Controls.Add(this.txtWaterUserNOSearch);
            this.panel1.Controls.Add(this.txtWaterMeterNO);
            this.panel1.Controls.Add(this.txtSenior);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.cmbPianNOS);
            this.panel1.Controls.Add(this.cmbAreaNOS);
            this.panel1.Controls.Add(this.cmbWaterMeterType);
            this.panel1.Controls.Add(this.cmbCommunityS);
            this.panel1.Controls.Add(this.cmbWaterUserTypeSearch);
            this.panel1.Controls.Add(this.txtYearAndMonth);
            this.panel1.Controls.Add(this.cmbDuanNOS);
            this.panel1.Controls.Add(this.cmbChargerS);
            this.panel1.Controls.Add(this.btSenior);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labTip);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btLeft);
            this.panel1.Controls.Add(this.btRight);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.label56);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label48);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtYearAndMonthSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 114);
            this.panel1.TabIndex = 1;
            this.panel1.Tag = "9999";
            // 
            // txtWaterUserNOSearch
            // 
            this.txtWaterUserNOSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNOSearch.Location = new System.Drawing.Point(689, 43);
            this.txtWaterUserNOSearch.Name = "txtWaterUserNOSearch";
            this.txtWaterUserNOSearch.Size = new System.Drawing.Size(78, 26);
            this.txtWaterUserNOSearch.TabIndex = 95;
            this.txtWaterUserNOSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // txtWaterMeterNO
            // 
            this.txtWaterMeterNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterMeterNO.Location = new System.Drawing.Point(88, 78);
            this.txtWaterMeterNO.Name = "txtWaterMeterNO";
            this.txtWaterMeterNO.Size = new System.Drawing.Size(109, 26);
            this.txtWaterMeterNO.TabIndex = 97;
            this.txtWaterMeterNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.SystemColors.Window;
            this.txtSenior.Location = new System.Drawing.Point(312, 77);
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(292, 26);
            this.txtSenior.TabIndex = 116;
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSearch.Location = new System.Drawing.Point(626, 74);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(58, 30);
            this.btSearch.TabIndex = 103;
            this.btSearch.Text = "查询";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // cmbPianNOS
            // 
            this.cmbPianNOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPianNOS.DropDownWidth = 120;
            this.cmbPianNOS.FormattingEnabled = true;
            this.cmbPianNOS.Location = new System.Drawing.Point(773, 13);
            this.cmbPianNOS.Name = "cmbPianNOS";
            this.cmbPianNOS.Size = new System.Drawing.Size(60, 24);
            this.cmbPianNOS.TabIndex = 107;
            // 
            // cmbAreaNOS
            // 
            this.cmbAreaNOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreaNOS.DropDownWidth = 120;
            this.cmbAreaNOS.FormattingEnabled = true;
            this.cmbAreaNOS.Location = new System.Drawing.Point(662, 12);
            this.cmbAreaNOS.Name = "cmbAreaNOS";
            this.cmbAreaNOS.Size = new System.Drawing.Size(60, 24);
            this.cmbAreaNOS.TabIndex = 105;
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterMeterType.DropDownWidth = 140;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Items.AddRange(new object[] {
            "",
            "正常",
            "停水",
            "报废"});
            this.cmbWaterMeterType.Location = new System.Drawing.Point(493, 12);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(111, 24);
            this.cmbWaterMeterType.TabIndex = 93;
            this.cmbWaterMeterType.SelectionChangeCommitted += new System.EventHandler(this.cmbWaterUserTypeSearch_SelectionChangeCommitted);
            // 
            // cmbCommunityS
            // 
            this.cmbCommunityS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommunityS.DropDownWidth = 120;
            this.cmbCommunityS.FormattingEnabled = true;
            this.cmbCommunityS.Location = new System.Drawing.Point(291, 45);
            this.cmbCommunityS.Name = "cmbCommunityS";
            this.cmbCommunityS.Size = new System.Drawing.Size(111, 24);
            this.cmbCommunityS.TabIndex = 111;
            // 
            // cmbWaterUserTypeSearch
            // 
            this.cmbWaterUserTypeSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterUserTypeSearch.DropDownWidth = 140;
            this.cmbWaterUserTypeSearch.FormattingEnabled = true;
            this.cmbWaterUserTypeSearch.Location = new System.Drawing.Point(291, 12);
            this.cmbWaterUserTypeSearch.Name = "cmbWaterUserTypeSearch";
            this.cmbWaterUserTypeSearch.Size = new System.Drawing.Size(111, 24);
            this.cmbWaterUserTypeSearch.TabIndex = 48;
            this.cmbWaterUserTypeSearch.SelectionChangeCommitted += new System.EventHandler(this.cmbWaterUserTypeSearch_SelectionChangeCommitted);
            // 
            // txtYearAndMonth
            // 
            this.txtYearAndMonth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtYearAndMonth.Location = new System.Drawing.Point(88, 11);
            this.txtYearAndMonth.Name = "txtYearAndMonth";
            this.txtYearAndMonth.ReadOnly = true;
            this.txtYearAndMonth.Size = new System.Drawing.Size(58, 26);
            this.txtYearAndMonth.TabIndex = 2;
            this.txtYearAndMonth.TextChanged += new System.EventHandler(this.cmbWaterUserTypeSearch_SelectionChangeCommitted);
            // 
            // cmbDuanNOS
            // 
            this.cmbDuanNOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuanNOS.DropDownWidth = 120;
            this.cmbDuanNOS.FormattingEnabled = true;
            this.cmbDuanNOS.Location = new System.Drawing.Point(88, 45);
            this.cmbDuanNOS.Name = "cmbDuanNOS";
            this.cmbDuanNOS.Size = new System.Drawing.Size(60, 24);
            this.cmbDuanNOS.TabIndex = 109;
            // 
            // cmbChargerS
            // 
            this.cmbChargerS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargerS.FormattingEnabled = true;
            this.cmbChargerS.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.cmbChargerS.Location = new System.Drawing.Point(493, 45);
            this.cmbChargerS.Name = "cmbChargerS";
            this.cmbChargerS.Size = new System.Drawing.Size(111, 24);
            this.cmbChargerS.TabIndex = 114;
            // 
            // btSenior
            // 
            this.btSenior.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSenior.Location = new System.Drawing.Point(218, 75);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(84, 30);
            this.btSenior.TabIndex = 117;
            this.btSenior.Tag = "9999";
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = false;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "抄表月份:";
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.Location = new System.Drawing.Point(304, 16);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(0, 16);
            this.labTip.TabIndex = 1;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(416, 49);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(80, 16);
            this.label39.TabIndex = 112;
            this.label39.Text = "收 费 员:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(216, 16);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(88, 16);
            this.label36.TabIndex = 49;
            this.label36.Text = "用户类别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 110;
            this.label3.Text = "小区名称：";
            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(148, 12);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(27, 24);
            this.btLeft.TabIndex = 51;
            this.btLeft.Text = "<";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // btRight
            // 
            this.btRight.Location = new System.Drawing.Point(175, 12);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(27, 24);
            this.btRight.TabIndex = 50;
            this.btRight.Text = ">";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(9, 49);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 16);
            this.label35.TabIndex = 108;
            this.label35.Text = "段    号:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(416, 16);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(80, 16);
            this.label56.TabIndex = 94;
            this.label56.Text = "用水性质:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(731, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 106;
            this.label21.Text = "片号：";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(626, 49);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(64, 16);
            this.label48.TabIndex = 96;
            this.label48.Text = "用户号:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(619, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 104;
            this.label9.Text = "区号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 98;
            this.label2.Text = "水表编号:";
            // 
            // txtYearAndMonthSave
            // 
            this.txtYearAndMonthSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtYearAndMonthSave.Location = new System.Drawing.Point(690, 78);
            this.txtYearAndMonthSave.Name = "txtYearAndMonthSave";
            this.txtYearAndMonthSave.ReadOnly = true;
            this.txtYearAndMonthSave.Size = new System.Drawing.Size(14, 26);
            this.txtYearAndMonthSave.TabIndex = 102;
            this.txtYearAndMonthSave.Visible = false;
            // 
            // bgWork
            // 
            this.bgWork.WorkerSupportsCancellation = true;
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            this.bgWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWork_RunWorkerCompleted);
            // 
            // frmWaterMeterReadInitialSencond
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWaterMeterReadInitialSencond";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "二次抄表初始化";
            this.Load += new System.EventHandler(this.frmWaterMeterReadInitial_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWaterMeterReadInitialSencond_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btInitial;
        private System.Windows.Forms.ProgressBar prb;
        private System.Windows.Forms.Label labProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView trMeterReading;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btChangeEndNumber;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labCount;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.ComboBox cmbPianNOS;
        private System.Windows.Forms.ComboBox cmbAreaNOS;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.ComboBox cmbWaterUserTypeSearch;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.TextBox txtYearAndMonth;
        private System.Windows.Forms.ComboBox cmbChargerS;
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.ComboBox cmbCommunityS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.ComboBox cmbDuanNOS;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox txtWaterMeterNO;
        private System.Windows.Forms.TextBox txtYearAndMonthSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn pianNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn duanNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMUNITYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargerName;
    }
}
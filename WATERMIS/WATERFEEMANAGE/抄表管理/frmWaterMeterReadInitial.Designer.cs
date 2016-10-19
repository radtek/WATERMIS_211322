namespace WATERFEEMANAGE
{
    partial class frmWaterMeterReadInitial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterReadInitial));
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
            this.waterMeterStateS = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.labProgress = new System.Windows.Forms.Label();
            this.prb = new System.Windows.Forms.ProgressBar();
            this.btInitial = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbWaterMeterState = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.btSenior = new System.Windows.Forms.Button();
            this.txtSenior = new System.Windows.Forms.TextBox();
            this.cmbMeterReaderS = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cmbCommunityS = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDuanNOS = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbPianNOS = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbAreaNOS = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.txtYearAndMonthSave = new System.Windows.Forms.TextBox();
            this.txtWaterUserNOSearch = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.btRight = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.cmbWaterUserTypeSearch = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.labTip = new System.Windows.Forms.Label();
            this.txtYearAndMonth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(848, 516);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgList);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(842, 354);
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
            this.waterMeterStateS,
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
            this.dgList.Size = new System.Drawing.Size(688, 299);
            this.dgList.TabIndex = 10;
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
            // waterMeterStateS
            // 
            this.waterMeterStateS.DataPropertyName = "waterMeterStateS";
            this.waterMeterStateS.HeaderText = "水表状态";
            this.waterMeterStateS.Name = "waterMeterStateS";
            this.waterMeterStateS.ReadOnly = true;
            this.waterMeterStateS.Width = 97;
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
            this.panel4.Location = new System.Drawing.Point(151, 321);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(688, 30);
            this.panel4.TabIndex = 9;
            // 
            // labCount
            // 
            this.labCount.AutoSize = true;
            this.labCount.Location = new System.Drawing.Point(6, 8);
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
            this.panel3.Size = new System.Drawing.Size(148, 329);
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
            this.trMeterReading.Size = new System.Drawing.Size(148, 329);
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
            this.panel2.Controls.Add(this.labProgress);
            this.panel2.Controls.Add(this.prb);
            this.panel2.Controls.Add(this.btInitial);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 475);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 38);
            this.panel2.TabIndex = 2;
            // 
            // labProgress
            // 
            this.labProgress.AutoSize = true;
            this.labProgress.BackColor = System.Drawing.Color.Transparent;
            this.labProgress.Location = new System.Drawing.Point(324, 14);
            this.labProgress.Name = "labProgress";
            this.labProgress.Size = new System.Drawing.Size(72, 16);
            this.labProgress.TabIndex = 3;
            this.labProgress.Tag = "9999";
            this.labProgress.Text = "进度:0/0";
            // 
            // prb
            // 
            this.prb.Location = new System.Drawing.Point(148, 9);
            this.prb.Name = "prb";
            this.prb.Size = new System.Drawing.Size(499, 23);
            this.prb.TabIndex = 2;
            // 
            // btInitial
            // 
            this.btInitial.Location = new System.Drawing.Point(67, 5);
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
            this.panel1.Controls.Add(this.cmbWaterMeterState);
            this.panel1.Controls.Add(this.label57);
            this.panel1.Controls.Add(this.btSenior);
            this.panel1.Controls.Add(this.txtSenior);
            this.panel1.Controls.Add(this.cmbMeterReaderS);
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.cmbCommunityS);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbDuanNOS);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.cmbPianNOS);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.cmbAreaNOS);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.txtYearAndMonthSave);
            this.panel1.Controls.Add(this.txtWaterUserNOSearch);
            this.panel1.Controls.Add(this.label48);
            this.panel1.Controls.Add(this.cmbWaterMeterType);
            this.panel1.Controls.Add(this.label56);
            this.panel1.Controls.Add(this.btRight);
            this.panel1.Controls.Add(this.btLeft);
            this.panel1.Controls.Add(this.cmbWaterUserTypeSearch);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.labTip);
            this.panel1.Controls.Add(this.txtYearAndMonth);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 106);
            this.panel1.TabIndex = 1;
            this.panel1.Tag = "9999";
            // 
            // cmbWaterMeterState
            // 
            this.cmbWaterMeterState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterMeterState.FormattingEnabled = true;
            this.cmbWaterMeterState.Items.AddRange(new object[] {
            "全部",
            "正常",
            "注销",
            "换表",
            "未启用",
            "欠费停水",
            "坏表"});
            this.cmbWaterMeterState.Location = new System.Drawing.Point(84, 70);
            this.cmbWaterMeterState.Name = "cmbWaterMeterState";
            this.cmbWaterMeterState.Size = new System.Drawing.Size(78, 24);
            this.cmbWaterMeterState.TabIndex = 118;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(5, 74);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(80, 16);
            this.label57.TabIndex = 119;
            this.label57.Text = "水表状态:";
            // 
            // btSenior
            // 
            this.btSenior.BackColor = System.Drawing.SystemColors.Control;
            this.btSenior.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSenior.Location = new System.Drawing.Point(287, 71);
            this.btSenior.Name = "btSenior";
            this.btSenior.Size = new System.Drawing.Size(84, 30);
            this.btSenior.TabIndex = 117;
            this.btSenior.Tag = "";
            this.btSenior.Text = "高级条件";
            this.btSenior.UseVisualStyleBackColor = false;
            this.btSenior.Visible = false;
            this.btSenior.Click += new System.EventHandler(this.btSenior_Click);
            // 
            // txtSenior
            // 
            this.txtSenior.BackColor = System.Drawing.SystemColors.Window;
            this.txtSenior.Location = new System.Drawing.Point(381, 73);
            this.txtSenior.Name = "txtSenior";
            this.txtSenior.ReadOnly = true;
            this.txtSenior.Size = new System.Drawing.Size(292, 26);
            this.txtSenior.TabIndex = 116;
            this.txtSenior.Visible = false;
            // 
            // cmbMeterReaderS
            // 
            this.cmbMeterReaderS.FormattingEnabled = true;
            this.cmbMeterReaderS.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.cmbMeterReaderS.Location = new System.Drawing.Point(489, 40);
            this.cmbMeterReaderS.Name = "cmbMeterReaderS";
            this.cmbMeterReaderS.Size = new System.Drawing.Size(111, 24);
            this.cmbMeterReaderS.TabIndex = 114;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(412, 44);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(80, 16);
            this.label39.TabIndex = 112;
            this.label39.Text = "抄 表 员:";
            // 
            // cmbCommunityS
            // 
            this.cmbCommunityS.DropDownWidth = 120;
            this.cmbCommunityS.FormattingEnabled = true;
            this.cmbCommunityS.Location = new System.Drawing.Point(287, 40);
            this.cmbCommunityS.Name = "cmbCommunityS";
            this.cmbCommunityS.Size = new System.Drawing.Size(111, 24);
            this.cmbCommunityS.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 110;
            this.label3.Text = "小区名称：";
            // 
            // cmbDuanNOS
            // 
            this.cmbDuanNOS.DropDownWidth = 120;
            this.cmbDuanNOS.FormattingEnabled = true;
            this.cmbDuanNOS.Location = new System.Drawing.Point(84, 40);
            this.cmbDuanNOS.Name = "cmbDuanNOS";
            this.cmbDuanNOS.Size = new System.Drawing.Size(78, 24);
            this.cmbDuanNOS.TabIndex = 109;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(5, 44);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 16);
            this.label35.TabIndex = 108;
            this.label35.Text = "段    号:";
            // 
            // cmbPianNOS
            // 
            this.cmbPianNOS.DropDownWidth = 120;
            this.cmbPianNOS.FormattingEnabled = true;
            this.cmbPianNOS.Location = new System.Drawing.Point(656, 7);
            this.cmbPianNOS.Name = "cmbPianNOS";
            this.cmbPianNOS.Size = new System.Drawing.Size(60, 24);
            this.cmbPianNOS.TabIndex = 107;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(614, 11);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 106;
            this.label21.Text = "片号：";
            // 
            // cmbAreaNOS
            // 
            this.cmbAreaNOS.DropDownWidth = 120;
            this.cmbAreaNOS.FormattingEnabled = true;
            this.cmbAreaNOS.Location = new System.Drawing.Point(773, 7);
            this.cmbAreaNOS.Name = "cmbAreaNOS";
            this.cmbAreaNOS.Size = new System.Drawing.Size(60, 24);
            this.cmbAreaNOS.TabIndex = 105;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(730, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 104;
            this.label9.Text = "区号：";
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.SystemColors.Control;
            this.btSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSearch.Location = new System.Drawing.Point(214, 70);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(58, 30);
            this.btSearch.TabIndex = 103;
            this.btSearch.Tag = "";
            this.btSearch.Text = "查询";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txtYearAndMonthSave
            // 
            this.txtYearAndMonthSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtYearAndMonthSave.Location = new System.Drawing.Point(759, 74);
            this.txtYearAndMonthSave.Name = "txtYearAndMonthSave";
            this.txtYearAndMonthSave.ReadOnly = true;
            this.txtYearAndMonthSave.Size = new System.Drawing.Size(14, 26);
            this.txtYearAndMonthSave.TabIndex = 102;
            this.txtYearAndMonthSave.Visible = false;
            // 
            // txtWaterUserNOSearch
            // 
            this.txtWaterUserNOSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserNOSearch.Location = new System.Drawing.Point(685, 38);
            this.txtWaterUserNOSearch.Name = "txtWaterUserNOSearch";
            this.txtWaterUserNOSearch.Size = new System.Drawing.Size(78, 26);
            this.txtWaterUserNOSearch.TabIndex = 95;
            this.txtWaterUserNOSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWaterUserNOSearch_KeyDown);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(622, 44);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(64, 16);
            this.label48.TabIndex = 96;
            this.label48.Text = "用户号:";
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownWidth = 140;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Items.AddRange(new object[] {
            "",
            "正常",
            "停水",
            "报废"});
            this.cmbWaterMeterType.Location = new System.Drawing.Point(489, 7);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(111, 24);
            this.cmbWaterMeterType.TabIndex = 93;
            this.cmbWaterMeterType.SelectionChangeCommitted += new System.EventHandler(this.cmbWaterUserTypeSearch_SelectionChangeCommitted);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(412, 11);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(80, 16);
            this.label56.TabIndex = 94;
            this.label56.Text = "用水性质:";
            // 
            // btRight
            // 
            this.btRight.Location = new System.Drawing.Point(171, 7);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(27, 24);
            this.btRight.TabIndex = 50;
            this.btRight.Text = ">";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(144, 7);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(27, 24);
            this.btLeft.TabIndex = 51;
            this.btLeft.Text = "<";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // cmbWaterUserTypeSearch
            // 
            this.cmbWaterUserTypeSearch.DropDownWidth = 140;
            this.cmbWaterUserTypeSearch.FormattingEnabled = true;
            this.cmbWaterUserTypeSearch.Location = new System.Drawing.Point(287, 7);
            this.cmbWaterUserTypeSearch.Name = "cmbWaterUserTypeSearch";
            this.cmbWaterUserTypeSearch.Size = new System.Drawing.Size(111, 24);
            this.cmbWaterUserTypeSearch.TabIndex = 48;
            this.cmbWaterUserTypeSearch.SelectionChangeCommitted += new System.EventHandler(this.cmbWaterUserTypeSearch_SelectionChangeCommitted);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(212, 11);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(88, 16);
            this.label36.TabIndex = 49;
            this.label36.Text = "用户类别：";
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.Location = new System.Drawing.Point(300, 11);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(0, 16);
            this.labTip.TabIndex = 1;
            // 
            // txtYearAndMonth
            // 
            this.txtYearAndMonth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtYearAndMonth.Location = new System.Drawing.Point(84, 6);
            this.txtYearAndMonth.Name = "txtYearAndMonth";
            this.txtYearAndMonth.ReadOnly = true;
            this.txtYearAndMonth.Size = new System.Drawing.Size(58, 26);
            this.txtYearAndMonth.TabIndex = 2;
            this.txtYearAndMonth.TextChanged += new System.EventHandler(this.cmbWaterUserTypeSearch_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "抄表月份:";
            // 
            // bgWork
            // 
            this.bgWork.WorkerSupportsCancellation = true;
            this.bgWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWork_DoWork);
            this.bgWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWork_RunWorkerCompleted);
            // 
            // frmWaterMeterReadInitial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWaterMeterReadInitial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "抄表初始化";
            this.Load += new System.EventHandler(this.frmWaterMeterReadInitial_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWaterMeterReadInitial_FormClosing);
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
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.Button btInitial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtYearAndMonth;
        private System.Windows.Forms.ProgressBar prb;
        private System.Windows.Forms.Label labProgress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView trMeterReading;
        private System.Windows.Forms.Label labCount;
        private System.Windows.Forms.ComboBox cmbWaterUserTypeSearch;
        private System.Windows.Forms.Label label36;
        private System.ComponentModel.BackgroundWorker bgWork;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox txtWaterUserNOSearch;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtYearAndMonthSave;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.ComboBox cmbAreaNOS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbPianNOS;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbCommunityS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDuanNOS;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbMeterReaderS;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button btSenior;
        private System.Windows.Forms.TextBox txtSenior;
        private System.Windows.Forms.ComboBox cmbWaterMeterState;
        private System.Windows.Forms.Label label57;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterStateS;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMUNITYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargerName;
    }
}
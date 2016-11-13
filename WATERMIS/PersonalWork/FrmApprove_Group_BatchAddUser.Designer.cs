namespace PersonalWork
{
    partial class FrmApprove_Group_BatchAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Group_BatchAddUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.waterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserPeopleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PianNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuanNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordernumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTelphoneNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.communityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMUNITYNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserHouseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterStartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChannelNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERMETERLOCKNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsReverse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PeopleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labState = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.cmbModifyValue = new System.Windows.Forms.ComboBox();
            this.cmbLeft = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.续前行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.顺序续前行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴复制内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.tb1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "open.ico");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgList);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 98);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1002, 430);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "用户及水表列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.waterUserNO,
            this.waterUserName,
            this.waterUserId,
            this.waterUserAddress,
            this.waterUserPeopleCount,
            this.PianNO,
            this.AreaNO,
            this.DuanNO,
            this.ordernumber,
            this.waterUserTelphoneNO,
            this.waterUserTypeId,
            this.waterUserTypeName,
            this.communityID,
            this.COMMUNITYNAME,
            this.buildingNO,
            this.unitNO,
            this.meterReaderID,
            this.meterReaderName,
            this.chargerID,
            this.chargerName,
            this.waterUserHouseType,
            this.createType,
            this.waterMeterPositionId,
            this.waterMeterPositionName,
            this.waterMeterState,
            this.waterMeterTypeId,
            this.waterMeterTypeValue,
            this.waterMeterStartNumber,
            this.waterMeterSerialNumber,
            this.ChannelNO,
            this.waterMeterMode,
            this.WATERMETERLOCKNO,
            this.IsReverse,
            this.PeopleID});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 19);
            this.dgList.Name = "dgList";
            this.dgList.RowHeadersWidth = 35;
            this.dgList.RowTemplate.Height = 30;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgList.Size = new System.Drawing.Size(996, 408);
            this.dgList.TabIndex = 2;
            this.dgList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgWaterListBatch_CellMouseDown);
            this.dgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgWaterListBatch_CellFormatting);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgWaterListBatch_CellPainting);
            this.dgList.CurrentCellChanged += new System.EventHandler(this.dgList_CurrentCellChanged);
            // 
            // waterUserNO
            // 
            this.waterUserNO.DataPropertyName = "waterUserNO";
            this.waterUserNO.HeaderText = "用户号";
            this.waterUserNO.Name = "waterUserNO";
            // 
            // waterUserName
            // 
            this.waterUserName.DataPropertyName = "waterUserName";
            this.waterUserName.HeaderText = "用户名";
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.Width = 150;
            // 
            // waterUserId
            // 
            this.waterUserId.DataPropertyName = "waterUserId";
            this.waterUserId.HeaderText = "waterUserId";
            this.waterUserId.Name = "waterUserId";
            this.waterUserId.Visible = false;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.HeaderText = "地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.Width = 200;
            // 
            // waterUserPeopleCount
            // 
            this.waterUserPeopleCount.DataPropertyName = "waterUserPeopleCount";
            this.waterUserPeopleCount.HeaderText = "人口数";
            this.waterUserPeopleCount.Name = "waterUserPeopleCount";
            this.waterUserPeopleCount.Width = 74;
            // 
            // PianNO
            // 
            this.PianNO.DataPropertyName = "PianNO";
            this.PianNO.HeaderText = "片号";
            this.PianNO.Name = "PianNO";
            this.PianNO.Width = 70;
            // 
            // AreaNO
            // 
            this.AreaNO.DataPropertyName = "AreaNO";
            this.AreaNO.HeaderText = "区号";
            this.AreaNO.Name = "AreaNO";
            this.AreaNO.Width = 50;
            // 
            // DuanNO
            // 
            this.DuanNO.DataPropertyName = "DuanNO";
            this.DuanNO.HeaderText = "段号";
            this.DuanNO.Name = "DuanNO";
            this.DuanNO.Width = 50;
            // 
            // ordernumber
            // 
            this.ordernumber.DataPropertyName = "ordernumber";
            this.ordernumber.HeaderText = "顺序号";
            this.ordernumber.Name = "ordernumber";
            // 
            // waterUserTelphoneNO
            // 
            this.waterUserTelphoneNO.DataPropertyName = "waterUserTelphoneNO";
            this.waterUserTelphoneNO.HeaderText = "联系方式";
            this.waterUserTelphoneNO.Name = "waterUserTelphoneNO";
            // 
            // waterUserTypeId
            // 
            this.waterUserTypeId.DataPropertyName = "waterUserTypeId";
            this.waterUserTypeId.HeaderText = "waterUserTypeId";
            this.waterUserTypeId.Name = "waterUserTypeId";
            this.waterUserTypeId.Visible = false;
            // 
            // waterUserTypeName
            // 
            this.waterUserTypeName.DataPropertyName = "waterUserTypeName";
            this.waterUserTypeName.HeaderText = "用户类别";
            this.waterUserTypeName.Name = "waterUserTypeName";
            // 
            // communityID
            // 
            this.communityID.DataPropertyName = "communityID";
            this.communityID.HeaderText = "小区ID";
            this.communityID.Name = "communityID";
            this.communityID.Visible = false;
            // 
            // COMMUNITYNAME
            // 
            this.COMMUNITYNAME.DataPropertyName = "COMMUNITYNAME";
            this.COMMUNITYNAME.HeaderText = "小区名称";
            this.COMMUNITYNAME.Name = "COMMUNITYNAME";
            // 
            // buildingNO
            // 
            this.buildingNO.DataPropertyName = "buildingNO";
            this.buildingNO.HeaderText = "楼号";
            this.buildingNO.Name = "buildingNO";
            this.buildingNO.Width = 50;
            // 
            // unitNO
            // 
            this.unitNO.DataPropertyName = "unitNO";
            this.unitNO.HeaderText = "单元";
            this.unitNO.Name = "unitNO";
            this.unitNO.Width = 50;
            // 
            // meterReaderID
            // 
            this.meterReaderID.DataPropertyName = "meterReaderID";
            this.meterReaderID.HeaderText = "meterReaderID";
            this.meterReaderID.Name = "meterReaderID";
            this.meterReaderID.Visible = false;
            // 
            // meterReaderName
            // 
            this.meterReaderName.DataPropertyName = "meterReaderName";
            this.meterReaderName.HeaderText = "抄表员";
            this.meterReaderName.Name = "meterReaderName";
            this.meterReaderName.Width = 60;
            // 
            // chargerID
            // 
            this.chargerID.DataPropertyName = "chargerID";
            this.chargerID.HeaderText = "chargerID";
            this.chargerID.Name = "chargerID";
            this.chargerID.Visible = false;
            // 
            // chargerName
            // 
            this.chargerName.DataPropertyName = "chargerName";
            this.chargerName.HeaderText = "收费员";
            this.chargerName.Name = "chargerName";
            this.chargerName.Width = 60;
            // 
            // waterUserHouseType
            // 
            this.waterUserHouseType.DataPropertyName = "waterUserHouseTypeID";
            this.waterUserHouseType.HeaderText = "户型";
            this.waterUserHouseType.Name = "waterUserHouseType";
            this.waterUserHouseType.Width = 60;
            // 
            // createType
            // 
            this.createType.DataPropertyName = "createType";
            this.createType.HeaderText = "建档类型";
            this.createType.Name = "createType";
            // 
            // waterMeterPositionId
            // 
            this.waterMeterPositionId.DataPropertyName = "waterMeterPositionId";
            this.waterMeterPositionId.HeaderText = "水表位置";
            this.waterMeterPositionId.Name = "waterMeterPositionId";
            this.waterMeterPositionId.Visible = false;
            this.waterMeterPositionId.Width = 88;
            // 
            // waterMeterPositionName
            // 
            this.waterMeterPositionName.DataPropertyName = "waterMeterPositionName";
            this.waterMeterPositionName.HeaderText = "水表位置";
            this.waterMeterPositionName.Name = "waterMeterPositionName";
            this.waterMeterPositionName.Width = 88;
            // 
            // waterMeterState
            // 
            this.waterMeterState.DataPropertyName = "waterMeterState";
            this.waterMeterState.HeaderText = "水表状态";
            this.waterMeterState.Name = "waterMeterState";
            this.waterMeterState.Width = 88;
            // 
            // waterMeterTypeId
            // 
            this.waterMeterTypeId.DataPropertyName = "waterMeterTypeId";
            this.waterMeterTypeId.HeaderText = "用水性质ID";
            this.waterMeterTypeId.Name = "waterMeterTypeId";
            this.waterMeterTypeId.Visible = false;
            this.waterMeterTypeId.Width = 102;
            // 
            // waterMeterTypeValue
            // 
            this.waterMeterTypeValue.DataPropertyName = "waterMeterTypeValue";
            this.waterMeterTypeValue.HeaderText = "用水性质";
            this.waterMeterTypeValue.Name = "waterMeterTypeValue";
            this.waterMeterTypeValue.Width = 88;
            // 
            // waterMeterStartNumber
            // 
            this.waterMeterStartNumber.DataPropertyName = "waterMeterStartNumber";
            this.waterMeterStartNumber.HeaderText = "初始读数";
            this.waterMeterStartNumber.Name = "waterMeterStartNumber";
            this.waterMeterStartNumber.Width = 88;
            // 
            // waterMeterSerialNumber
            // 
            this.waterMeterSerialNumber.DataPropertyName = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.HeaderText = "出厂编号";
            this.waterMeterSerialNumber.Name = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.Width = 150;
            // 
            // ChannelNO
            // 
            this.ChannelNO.DataPropertyName = "ChannelNO";
            this.ChannelNO.HeaderText = "通道号";
            this.ChannelNO.Name = "ChannelNO";
            // 
            // waterMeterMode
            // 
            this.waterMeterMode.DataPropertyName = "waterMeterMode";
            this.waterMeterMode.HeaderText = "铅封号";
            this.waterMeterMode.Name = "waterMeterMode";
            this.waterMeterMode.Width = 60;
            // 
            // WATERMETERLOCKNO
            // 
            this.WATERMETERLOCKNO.DataPropertyName = "WATERMETERLOCKNO";
            this.WATERMETERLOCKNO.HeaderText = "表锁号";
            this.WATERMETERLOCKNO.Name = "WATERMETERLOCKNO";
            // 
            // IsReverse
            // 
            this.IsReverse.DataPropertyName = "IsReverse";
            this.IsReverse.HeaderText = "水表倒装";
            this.IsReverse.Name = "IsReverse";
            // 
            // PeopleID
            // 
            this.PeopleID.DataPropertyName = "PeopleID";
            this.PeopleID.HeaderText = "PeopleID";
            this.PeopleID.Name = "PeopleID";
            this.PeopleID.Visible = false;
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox4, 0, 1);
            this.tb1.Controls.Add(this.panel1, 0, 2);
            this.tb1.Controls.Add(this.panel2, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tb1.Size = new System.Drawing.Size(1008, 579);
            this.tb1.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labState);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.cmbModifyValue);
            this.panel1.Controls.Add(this.cmbLeft);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 534);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 42);
            this.panel1.TabIndex = 11;
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(623, 18);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(119, 14);
            this.labState.TabIndex = 109;
            this.labState.Text = "点击保存按钮增户";
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.Magenta;
            this.btSave.Location = new System.Drawing.Point(544, 6);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 30);
            this.btSave.TabIndex = 108;
            this.btSave.Tag = "9999";
            this.btSave.Text = "保存";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.LimeGreen;
            this.btOK.Location = new System.Drawing.Point(461, 6);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 30);
            this.btOK.TabIndex = 107;
            this.btOK.Text = "填充";
            this.btOK.UseVisualStyleBackColor = false;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // cmbModifyValue
            // 
            this.cmbModifyValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModifyValue.FormattingEnabled = true;
            this.cmbModifyValue.Location = new System.Drawing.Point(317, 9);
            this.cmbModifyValue.Name = "cmbModifyValue";
            this.cmbModifyValue.Size = new System.Drawing.Size(134, 22);
            this.cmbModifyValue.TabIndex = 104;
            // 
            // cmbLeft
            // 
            this.cmbLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeft.FormattingEnabled = true;
            this.cmbLeft.Items.AddRange(new object[] {
            "地址",
            "人口数",
            "片号",
            "区号",
            "段号",
            "用户类别",
            "小区名称",
            "楼号",
            "单元",
            "抄表员",
            "收费员",
            "户型",
            "建档类型",
            "水表位置",
            "水表状态",
            "用水性质",
            "初始读数",
            "通道号",
            "铅封号",
            "表锁号",
            "是否倒装"});
            this.cmbLeft.Location = new System.Drawing.Point(131, 9);
            this.cmbLeft.Name = "cmbLeft";
            this.cmbLeft.Size = new System.Drawing.Size(99, 22);
            this.cmbLeft.TabIndex = 105;
            this.cmbLeft.SelectedIndexChanged += new System.EventHandler(this.cmbLeft_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 103;
            this.label2.Text = "全部填充为:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 14);
            this.label1.TabIndex = 101;
            this.label1.Text = "将列表中所选行的:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 89);
            this.panel2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LimeGreen;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1002, 89);
            this.label3.TabIndex = 0;
            this.label3.Tag = "9999";
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.续前行ToolStripMenuItem,
            this.顺序续前行ToolStripMenuItem,
            this.粘贴复制内容ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 76);
            // 
            // 续前行ToolStripMenuItem
            // 
            this.续前行ToolStripMenuItem.Name = "续前行ToolStripMenuItem";
            this.续前行ToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.续前行ToolStripMenuItem.Text = "水表出厂编号续前行";
            this.续前行ToolStripMenuItem.Click += new System.EventHandler(this.续前行ToolStripMenuItem_Click);
            // 
            // 顺序续前行ToolStripMenuItem
            // 
            this.顺序续前行ToolStripMenuItem.Name = "顺序续前行ToolStripMenuItem";
            this.顺序续前行ToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.顺序续前行ToolStripMenuItem.Text = "顺序号续前行";
            this.顺序续前行ToolStripMenuItem.Click += new System.EventHandler(this.顺序续前行ToolStripMenuItem_Click);
            // 
            // 粘贴复制内容ToolStripMenuItem
            // 
            this.粘贴复制内容ToolStripMenuItem.Name = "粘贴复制内容ToolStripMenuItem";
            this.粘贴复制内容ToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.粘贴复制内容ToolStripMenuItem.Text = "粘贴复制内容";
            this.粘贴复制内容ToolStripMenuItem.Click += new System.EventHandler(this.粘贴复制内容ToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // FrmApprove_Group_BatchAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 579);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmApprove_Group_BatchAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "  批量修改用户及水表信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBatchModifyWaterUserMesAndWaterMeterMes_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.tb1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbModifyValue;
        private System.Windows.Forms.ComboBox cmbLeft;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 粘贴复制内容ToolStripMenuItem;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.ToolStripMenuItem 续前行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 顺序续前行ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserPeopleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PianNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuanNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTelphoneNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn communityID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMUNITYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserHouseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn createType;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterState;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterStartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChannelNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERMETERLOCKNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsReverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeopleID;
    }
}
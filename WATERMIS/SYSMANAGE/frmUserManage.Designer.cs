namespace SYSMANAGE
{
    partial class frmUserManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserManage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolModify = new System.Windows.Forms.ToolStripButton();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolDel = new System.Windows.Forms.ToolStripButton();
            this.toolResetPWD = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgUser = new System.Windows.Forms.DataGridView();
            this.LOGINID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGINNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGINPASSWORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELEPHONENO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isMeterReaderS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isChargerS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsCashierS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userstate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generateDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.chkIsCashierS = new System.Windows.Forms.CheckBox();
            this.chkIsCharger = new System.Windows.Forms.CheckBox();
            this.txtWorkNO = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkIsMeterReader = new System.Windows.Forms.CheckBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.txtDEP = new System.Windows.Forms.TextBox();
            this.cmbPost = new System.Windows.Forms.ComboBox();
            this.cmbDEP = new System.Windows.Forms.ComboBox();
            this.txtLogName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbIsCashierS = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbIsCharger = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbIsReader = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbGroupS = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDEPS = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNameS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolModify,
            this.toolAdd,
            this.toolSave,
            this.toolDel,
            this.toolResetPWD});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Tag = "9999";
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::SYSMANAGE.Properties.Resources.onebit_02;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(55, 22);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // toolModify
            // 
            this.toolModify.Image = global::SYSMANAGE.Properties.Resources.onebit_20;
            this.toolModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolModify.Name = "toolModify";
            this.toolModify.Size = new System.Drawing.Size(55, 22);
            this.toolModify.Text = "修改";
            this.toolModify.Click += new System.EventHandler(this.toolModify_Click);
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::SYSMANAGE.Properties.Resources.onebit_31;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(55, 22);
            this.toolAdd.Text = "添加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolSave
            // 
            this.toolSave.Enabled = false;
            this.toolSave.Image = global::SYSMANAGE.Properties.Resources.onebit_34;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(55, 22);
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolDel
            // 
            this.toolDel.Image = global::SYSMANAGE.Properties.Resources.close;
            this.toolDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDel.Name = "toolDel";
            this.toolDel.Size = new System.Drawing.Size(55, 22);
            this.toolDel.Text = "删除";
            this.toolDel.Click += new System.EventHandler(this.toolDel_Click);
            // 
            // toolResetPWD
            // 
            this.toolResetPWD.Image = global::SYSMANAGE.Properties.Resources.minimum;
            this.toolResetPWD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolResetPWD.Name = "toolResetPWD";
            this.toolResetPWD.Size = new System.Drawing.Size(83, 22);
            this.toolResetPWD.Text = "密码重置";
            this.toolResetPWD.Click += new System.EventHandler(this.toolResetPWD_Click);
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.Transparent;
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.groupBox2, 0, 2);
            this.tb1.Controls.Add(this.grpDetail, 0, 1);
            this.tb1.Controls.Add(this.groupBox3, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.97506F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.Size = new System.Drawing.Size(1008, 518);
            this.tb1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgUser);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 201);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1000, 313);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作员列表";
            // 
            // dgUser
            // 
            this.dgUser.AllowUserToAddRows = false;
            this.dgUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LOGINID,
            this.USERNAME,
            this.LOGINNAME,
            this.workNO,
            this.LOGINPASSWORD,
            this.DEPARTMENTNAME,
            this.groupID,
            this.groupName,
            this.POSTNAME,
            this.TELEPHONENO,
            this.isMeterReaderS,
            this.isChargerS,
            this.IsCashierS,
            this.userstate,
            this.generateDateTime,
            this.MEMO});
            this.dgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUser.Location = new System.Drawing.Point(4, 20);
            this.dgUser.MultiSelect = false;
            this.dgUser.Name = "dgUser";
            this.dgUser.ReadOnly = true;
            this.dgUser.RowHeadersWidth = 25;
            this.dgUser.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgUser.RowTemplate.Height = 23;
            this.dgUser.Size = new System.Drawing.Size(992, 289);
            this.dgUser.TabIndex = 0;
            this.dgUser.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgUser_CellPainting);
            this.dgUser.SelectionChanged += new System.EventHandler(this.dgUser_SelectionChanged);
            // 
            // LOGINID
            // 
            this.LOGINID.DataPropertyName = "LOGINID";
            this.LOGINID.HeaderText = "编号";
            this.LOGINID.Name = "LOGINID";
            this.LOGINID.ReadOnly = true;
            this.LOGINID.Width = 60;
            // 
            // USERNAME
            // 
            this.USERNAME.DataPropertyName = "USERNAME";
            this.USERNAME.HeaderText = "姓名";
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.ReadOnly = true;
            this.USERNAME.Width = 60;
            // 
            // LOGINNAME
            // 
            this.LOGINNAME.DataPropertyName = "LOGINNAME";
            this.LOGINNAME.HeaderText = "登录名";
            this.LOGINNAME.Name = "LOGINNAME";
            this.LOGINNAME.ReadOnly = true;
            this.LOGINNAME.Width = 74;
            // 
            // workNO
            // 
            this.workNO.DataPropertyName = "workNO";
            this.workNO.HeaderText = "工号";
            this.workNO.Name = "workNO";
            this.workNO.ReadOnly = true;
            this.workNO.Width = 60;
            // 
            // LOGINPASSWORD
            // 
            this.LOGINPASSWORD.DataPropertyName = "LOGINPASSWORD";
            this.LOGINPASSWORD.HeaderText = "登录密码";
            this.LOGINPASSWORD.Name = "LOGINPASSWORD";
            this.LOGINPASSWORD.ReadOnly = true;
            this.LOGINPASSWORD.Visible = false;
            this.LOGINPASSWORD.Width = 88;
            // 
            // DEPARTMENTNAME
            // 
            this.DEPARTMENTNAME.DataPropertyName = "DEPARTMENTNAME";
            this.DEPARTMENTNAME.HeaderText = "所属部门";
            this.DEPARTMENTNAME.Name = "DEPARTMENTNAME";
            this.DEPARTMENTNAME.ReadOnly = true;
            this.DEPARTMENTNAME.Width = 88;
            // 
            // groupID
            // 
            this.groupID.DataPropertyName = "groupID";
            this.groupID.HeaderText = "groupID";
            this.groupID.Name = "groupID";
            this.groupID.ReadOnly = true;
            this.groupID.Visible = false;
            this.groupID.Width = 81;
            // 
            // groupName
            // 
            this.groupName.DataPropertyName = "groupName";
            this.groupName.HeaderText = "所属分组";
            this.groupName.Name = "groupName";
            this.groupName.ReadOnly = true;
            this.groupName.Width = 88;
            // 
            // POSTNAME
            // 
            this.POSTNAME.DataPropertyName = "POSTNAME";
            this.POSTNAME.HeaderText = "职务";
            this.POSTNAME.Name = "POSTNAME";
            this.POSTNAME.ReadOnly = true;
            this.POSTNAME.Width = 60;
            // 
            // TELEPHONENO
            // 
            this.TELEPHONENO.DataPropertyName = "TELEPHONENO";
            this.TELEPHONENO.HeaderText = "手机号码";
            this.TELEPHONENO.Name = "TELEPHONENO";
            this.TELEPHONENO.ReadOnly = true;
            this.TELEPHONENO.Width = 88;
            // 
            // isMeterReaderS
            // 
            this.isMeterReaderS.DataPropertyName = "isMeterReaderS";
            this.isMeterReaderS.HeaderText = "抄表员";
            this.isMeterReaderS.Name = "isMeterReaderS";
            this.isMeterReaderS.ReadOnly = true;
            this.isMeterReaderS.Width = 74;
            // 
            // isChargerS
            // 
            this.isChargerS.DataPropertyName = "isChargerS";
            this.isChargerS.HeaderText = "收费员";
            this.isChargerS.Name = "isChargerS";
            this.isChargerS.ReadOnly = true;
            this.isChargerS.Width = 74;
            // 
            // IsCashierS
            // 
            this.IsCashierS.DataPropertyName = "IsCashierS";
            this.IsCashierS.HeaderText = "收款员";
            this.IsCashierS.Name = "IsCashierS";
            this.IsCashierS.ReadOnly = true;
            this.IsCashierS.Width = 74;
            // 
            // userstate
            // 
            this.userstate.DataPropertyName = "userstateS";
            this.userstate.HeaderText = "用户状态";
            this.userstate.Name = "userstate";
            this.userstate.ReadOnly = true;
            this.userstate.Width = 88;
            // 
            // generateDateTime
            // 
            this.generateDateTime.DataPropertyName = "generateDateTime";
            dataGridViewCellStyle3.Format = "D";
            dataGridViewCellStyle3.NullValue = null;
            this.generateDateTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.generateDateTime.HeaderText = "生成日期";
            this.generateDateTime.Name = "generateDateTime";
            this.generateDateTime.ReadOnly = true;
            this.generateDateTime.Width = 88;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "备注";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.Width = 60;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.chkIsCashierS);
            this.grpDetail.Controls.Add(this.chkIsCharger);
            this.grpDetail.Controls.Add(this.txtWorkNO);
            this.grpDetail.Controls.Add(this.label8);
            this.grpDetail.Controls.Add(this.txtGroup);
            this.grpDetail.Controls.Add(this.cmbGroup);
            this.grpDetail.Controls.Add(this.label7);
            this.grpDetail.Controls.Add(this.chkIsMeterReader);
            this.grpDetail.Controls.Add(this.txtUserID);
            this.grpDetail.Controls.Add(this.txtTel);
            this.grpDetail.Controls.Add(this.txtState);
            this.grpDetail.Controls.Add(this.txtPost);
            this.grpDetail.Controls.Add(this.cmbState);
            this.grpDetail.Controls.Add(this.txtDEP);
            this.grpDetail.Controls.Add(this.cmbPost);
            this.grpDetail.Controls.Add(this.cmbDEP);
            this.grpDetail.Controls.Add(this.txtLogName);
            this.grpDetail.Controls.Add(this.label6);
            this.grpDetail.Controls.Add(this.label9);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.Controls.Add(this.label4);
            this.grpDetail.Controls.Add(this.txtMemo);
            this.grpDetail.Controls.Add(this.txtName);
            this.grpDetail.Controls.Add(this.label5);
            this.grpDetail.Controls.Add(this.label3);
            this.grpDetail.Controls.Add(this.label1);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.Location = new System.Drawing.Point(4, 64);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(4);
            this.grpDetail.Size = new System.Drawing.Size(1000, 129);
            this.grpDetail.TabIndex = 0;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "操作员详情";
            // 
            // chkIsCashierS
            // 
            this.chkIsCashierS.AutoSize = true;
            this.chkIsCashierS.Location = new System.Drawing.Point(815, 26);
            this.chkIsCashierS.Name = "chkIsCashierS";
            this.chkIsCashierS.Size = new System.Drawing.Size(68, 18);
            this.chkIsCashierS.TabIndex = 14;
            this.chkIsCashierS.Text = "收款员";
            this.chkIsCashierS.UseVisualStyleBackColor = true;
            // 
            // chkIsCharger
            // 
            this.chkIsCharger.AutoSize = true;
            this.chkIsCharger.Location = new System.Drawing.Point(746, 26);
            this.chkIsCharger.Name = "chkIsCharger";
            this.chkIsCharger.Size = new System.Drawing.Size(68, 18);
            this.chkIsCharger.TabIndex = 14;
            this.chkIsCharger.Text = "收费员";
            this.chkIsCharger.UseVisualStyleBackColor = true;
            // 
            // txtWorkNO
            // 
            this.txtWorkNO.Location = new System.Drawing.Point(521, 25);
            this.txtWorkNO.Name = "txtWorkNO";
            this.txtWorkNO.Size = new System.Drawing.Size(122, 23);
            this.txtWorkNO.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(477, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "工号：";
            // 
            // txtGroup
            // 
            this.txtGroup.BackColor = System.Drawing.SystemColors.Window;
            this.txtGroup.Location = new System.Drawing.Point(316, 60);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.ReadOnly = true;
            this.txtGroup.Size = new System.Drawing.Size(125, 23);
            this.txtGroup.TabIndex = 11;
            // 
            // cmbGroup
            // 
            this.cmbGroup.BackColor = System.Drawing.SystemColors.Window;
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(316, 61);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(125, 22);
            this.cmbGroup.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 14);
            this.label7.TabIndex = 9;
            this.label7.Text = "*所属分组：";
            // 
            // chkIsMeterReader
            // 
            this.chkIsMeterReader.AutoSize = true;
            this.chkIsMeterReader.Location = new System.Drawing.Point(677, 26);
            this.chkIsMeterReader.Name = "chkIsMeterReader";
            this.chkIsMeterReader.Size = new System.Drawing.Size(68, 18);
            this.chkIsMeterReader.TabIndex = 8;
            this.chkIsMeterReader.Text = "抄表员";
            this.chkIsMeterReader.UseVisualStyleBackColor = true;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(787, 61);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(122, 23);
            this.txtUserID.TabIndex = 4;
            this.txtUserID.Visible = false;
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.SystemColors.Window;
            this.txtTel.Location = new System.Drawing.Point(93, 97);
            this.txtTel.Name = "txtTel";
            this.txtTel.ReadOnly = true;
            this.txtTel.Size = new System.Drawing.Size(125, 23);
            this.txtTel.TabIndex = 3;
            // 
            // txtState
            // 
            this.txtState.BackColor = System.Drawing.SystemColors.Window;
            this.txtState.Location = new System.Drawing.Point(718, 60);
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(66, 23);
            this.txtState.TabIndex = 3;
            // 
            // txtPost
            // 
            this.txtPost.BackColor = System.Drawing.SystemColors.Window;
            this.txtPost.Location = new System.Drawing.Point(521, 60);
            this.txtPost.Name = "txtPost";
            this.txtPost.ReadOnly = true;
            this.txtPost.Size = new System.Drawing.Size(125, 23);
            this.txtPost.TabIndex = 3;
            // 
            // cmbState
            // 
            this.cmbState.BackColor = System.Drawing.SystemColors.Window;
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "正常",
            "停用"});
            this.cmbState.Location = new System.Drawing.Point(718, 61);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(63, 22);
            this.cmbState.TabIndex = 2;
            // 
            // txtDEP
            // 
            this.txtDEP.BackColor = System.Drawing.SystemColors.Window;
            this.txtDEP.Location = new System.Drawing.Point(93, 60);
            this.txtDEP.Name = "txtDEP";
            this.txtDEP.ReadOnly = true;
            this.txtDEP.Size = new System.Drawing.Size(125, 23);
            this.txtDEP.TabIndex = 3;
            // 
            // cmbPost
            // 
            this.cmbPost.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPost.FormattingEnabled = true;
            this.cmbPost.Location = new System.Drawing.Point(521, 61);
            this.cmbPost.Name = "cmbPost";
            this.cmbPost.Size = new System.Drawing.Size(122, 22);
            this.cmbPost.TabIndex = 2;
            // 
            // cmbDEP
            // 
            this.cmbDEP.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDEP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDEP.FormattingEnabled = true;
            this.cmbDEP.Location = new System.Drawing.Point(93, 61);
            this.cmbDEP.Name = "cmbDEP";
            this.cmbDEP.Size = new System.Drawing.Size(125, 22);
            this.cmbDEP.TabIndex = 2;
            // 
            // txtLogName
            // 
            this.txtLogName.Location = new System.Drawing.Point(316, 24);
            this.txtLogName.Name = "txtLogName";
            this.txtLogName.Size = new System.Drawing.Size(122, 23);
            this.txtLogName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "手机号码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(674, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "状态：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "*登 录 名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(477, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "职务：";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(316, 96);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(468, 23);
            this.txtMemo.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(125, 23);
            this.txtName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "备    注：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "*所属部门：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "*姓    名：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbIsCashierS);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cmbIsCharger);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.cmbIsReader);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cmbGroupS);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.cmbDEPS);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtNameS);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1002, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // cmbIsCashierS
            // 
            this.cmbIsCashierS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsCashierS.FormattingEnabled = true;
            this.cmbIsCashierS.Items.AddRange(new object[] {
            "全部",
            "否",
            "是"});
            this.cmbIsCashierS.Location = new System.Drawing.Point(861, 22);
            this.cmbIsCashierS.Name = "cmbIsCashierS";
            this.cmbIsCashierS.Size = new System.Drawing.Size(58, 22);
            this.cmbIsCashierS.TabIndex = 17;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(806, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 14);
            this.label15.TabIndex = 18;
            this.label15.Text = "收款员：";
            // 
            // cmbIsCharger
            // 
            this.cmbIsCharger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsCharger.FormattingEnabled = true;
            this.cmbIsCharger.Items.AddRange(new object[] {
            "全部",
            "否",
            "是"});
            this.cmbIsCharger.Location = new System.Drawing.Point(737, 21);
            this.cmbIsCharger.Name = "cmbIsCharger";
            this.cmbIsCharger.Size = new System.Drawing.Size(58, 22);
            this.cmbIsCharger.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(682, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 14);
            this.label14.TabIndex = 16;
            this.label14.Text = "收费员：";
            // 
            // cmbIsReader
            // 
            this.cmbIsReader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsReader.FormattingEnabled = true;
            this.cmbIsReader.Items.AddRange(new object[] {
            "全部",
            "否",
            "是"});
            this.cmbIsReader.Location = new System.Drawing.Point(607, 21);
            this.cmbIsReader.Name = "cmbIsReader";
            this.cmbIsReader.Size = new System.Drawing.Size(58, 22);
            this.cmbIsReader.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(552, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 14);
            this.label13.TabIndex = 14;
            this.label13.Text = "抄表员：";
            // 
            // cmbGroupS
            // 
            this.cmbGroupS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupS.FormattingEnabled = true;
            this.cmbGroupS.Location = new System.Drawing.Point(432, 21);
            this.cmbGroupS.Name = "cmbGroupS";
            this.cmbGroupS.Size = new System.Drawing.Size(100, 22);
            this.cmbGroupS.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(360, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "所属分组：";
            // 
            // cmbDEPS
            // 
            this.cmbDEPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDEPS.FormattingEnabled = true;
            this.cmbDEPS.Location = new System.Drawing.Point(80, 21);
            this.cmbDEPS.Name = "cmbDEPS";
            this.cmbDEPS.Size = new System.Drawing.Size(100, 22);
            this.cmbDEPS.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "所属部门：";
            // 
            // txtNameS
            // 
            this.txtNameS.Location = new System.Drawing.Point(242, 20);
            this.txtNameS.Name = "txtNameS";
            this.txtNameS.Size = new System.Drawing.Size(100, 23);
            this.txtNameS.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(199, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "姓名：";
            // 
            // frmUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1008, 543);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUserManage";
            this.Text = "操作员管理";
            this.Load += new System.EventHandler(this.frmUserManage_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolDel;
        private System.Windows.Forms.ToolStripButton toolModify;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbPost;
        private System.Windows.Forms.ComboBox cmbDEP;
        private System.Windows.Forms.TextBox txtLogName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNameS;
        private System.Windows.Forms.ComboBox cmbDEPS;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.TextBox txtDEP;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.ToolStripButton toolResetPWD;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkIsMeterReader;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWorkNO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbGroupS;
        private System.Windows.Forms.CheckBox chkIsCharger;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbIsCharger;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbIsReader;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkIsCashierS;
        private System.Windows.Forms.ComboBox cmbIsCashierS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGINID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGINNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn workNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGINPASSWORD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELEPHONENO;
        private System.Windows.Forms.DataGridViewTextBoxColumn isMeterReaderS;
        private System.Windows.Forms.DataGridViewTextBoxColumn isChargerS;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsCashierS;
        private System.Windows.Forms.DataGridViewTextBoxColumn userstate;
        private System.Windows.Forms.DataGridViewTextBoxColumn generateDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}
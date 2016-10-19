namespace SYSMANAGE
{
    partial class frmSendMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendMessage));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btNew = new System.Windows.Forms.Button();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btSend = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labTip = new System.Windows.Forms.Label();
            this.lsbReceiver = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgUser = new System.Windows.Forms.DataGridView();
            this.LOGINID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPARTMENTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSTNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.cmbPost = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGroupS = new System.Windows.Forms.ComboBox();
            this.txtNameS = new System.Windows.Forms.TextBox();
            this.cmbDEPS = new System.Windows.Forms.ComboBox();
            this.cmbIsReader = new System.Windows.Forms.ComboBox();
            this.cmbIsCharger = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 662);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(656, 656);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btNew);
            this.groupBox6.Controls.Add(this.cmbClass);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.btSend);
            this.groupBox6.Controls.Add(this.txtContent);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 204);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(650, 449);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "内容";
            // 
            // btNew
            // 
            this.btNew.BackColor = System.Drawing.Color.LimeGreen;
            this.btNew.Location = new System.Drawing.Point(389, 362);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(89, 32);
            this.btNew.TabIndex = 29;
            this.btNew.Tag = "9999";
            this.btNew.Text = "新消息";
            this.btNew.UseVisualStyleBackColor = false;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "次要",
            "一般",
            "重要",
            "紧急"});
            this.cmbClass.Location = new System.Drawing.Point(150, 366);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(100, 24);
            this.cmbClass.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "紧急状态：";
            // 
            // btSend
            // 
            this.btSend.BackColor = System.Drawing.Color.LimeGreen;
            this.btSend.Location = new System.Drawing.Point(279, 362);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(89, 32);
            this.btSend.TabIndex = 26;
            this.btSend.Tag = "9999";
            this.btSend.Text = "发送";
            this.btSend.UseVisualStyleBackColor = false;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtContent.Location = new System.Drawing.Point(3, 22);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(644, 332);
            this.txtContent.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labTip);
            this.groupBox1.Controls.Add(this.lsbReceiver);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.groupBox1.Size = new System.Drawing.Size(650, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接收人";
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTip.ForeColor = System.Drawing.Color.DarkBlue;
            this.labTip.Location = new System.Drawing.Point(1, 123);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(84, 14);
            this.labTip.TabIndex = 2;
            this.labTip.Text = "已选择 0 人";
            // 
            // lsbReceiver
            // 
            this.lsbReceiver.ColumnWidth = 100;
            this.lsbReceiver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbReceiver.FormattingEnabled = true;
            this.lsbReceiver.ItemHeight = 16;
            this.lsbReceiver.Location = new System.Drawing.Point(3, 19);
            this.lsbReceiver.MultiColumn = true;
            this.lsbReceiver.Name = "lsbReceiver";
            this.lsbReceiver.Size = new System.Drawing.Size(644, 100);
            this.lsbReceiver.TabIndex = 1;
            this.lsbReceiver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsbReceiver_KeyDown);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtTitle);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 151);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(650, 47);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "标题";
            // 
            // txtTitle
            // 
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(3, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(644, 26);
            this.txtTitle.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(665, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 656);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "通讯录";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgUser);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 185);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(334, 468);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "人员列表";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LOGINID,
            this.USERNAME,
            this.workNO,
            this.DEPARTMENTNAME,
            this.groupID,
            this.groupName,
            this.POSTNAME});
            this.dgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUser.Location = new System.Drawing.Point(4, 23);
            this.dgUser.MultiSelect = false;
            this.dgUser.Name = "dgUser";
            this.dgUser.ReadOnly = true;
            this.dgUser.RowHeadersWidth = 30;
            this.dgUser.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgUser.RowTemplate.Height = 23;
            this.dgUser.Size = new System.Drawing.Size(326, 441);
            this.dgUser.TabIndex = 0;
            this.dgUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUser_CellDoubleClick);
            this.dgUser.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgUser_CellPainting);
            // 
            // LOGINID
            // 
            this.LOGINID.DataPropertyName = "LOGINID";
            this.LOGINID.HeaderText = "编号";
            this.LOGINID.Name = "LOGINID";
            this.LOGINID.ReadOnly = true;
            this.LOGINID.Width = 65;
            // 
            // USERNAME
            // 
            this.USERNAME.DataPropertyName = "USERNAME";
            this.USERNAME.HeaderText = "姓名";
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.ReadOnly = true;
            this.USERNAME.Width = 65;
            // 
            // workNO
            // 
            this.workNO.DataPropertyName = "workNO";
            this.workNO.HeaderText = "工号";
            this.workNO.Name = "workNO";
            this.workNO.ReadOnly = true;
            this.workNO.Width = 65;
            // 
            // DEPARTMENTNAME
            // 
            this.DEPARTMENTNAME.DataPropertyName = "DEPARTMENTNAME";
            this.DEPARTMENTNAME.HeaderText = "所属部门";
            this.DEPARTMENTNAME.Name = "DEPARTMENTNAME";
            this.DEPARTMENTNAME.ReadOnly = true;
            this.DEPARTMENTNAME.Width = 97;
            // 
            // groupID
            // 
            this.groupID.DataPropertyName = "groupID";
            this.groupID.HeaderText = "groupID";
            this.groupID.Name = "groupID";
            this.groupID.ReadOnly = true;
            this.groupID.Visible = false;
            this.groupID.Width = 89;
            // 
            // groupName
            // 
            this.groupName.DataPropertyName = "groupName";
            this.groupName.HeaderText = "所属分组";
            this.groupName.Name = "groupName";
            this.groupName.ReadOnly = true;
            this.groupName.Width = 97;
            // 
            // POSTNAME
            // 
            this.POSTNAME.DataPropertyName = "POSTNAME";
            this.POSTNAME.HeaderText = "职务";
            this.POSTNAME.Name = "POSTNAME";
            this.POSTNAME.ReadOnly = true;
            this.POSTNAME.Width = 65;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btSelectAll);
            this.groupBox3.Controls.Add(this.cmbPost);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbGroupS);
            this.groupBox3.Controls.Add(this.txtNameS);
            this.groupBox3.Controls.Add(this.cmbDEPS);
            this.groupBox3.Controls.Add(this.cmbIsReader);
            this.groupBox3.Controls.Add(this.cmbIsCharger);
            this.groupBox3.Controls.Add(this.btSearch);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox3.Location = new System.Drawing.Point(3, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 163);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // btSelectAll
            // 
            this.btSelectAll.BackColor = System.Drawing.Color.LimeGreen;
            this.btSelectAll.Location = new System.Drawing.Point(268, 124);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(58, 32);
            this.btSelectAll.TabIndex = 25;
            this.btSelectAll.Tag = "9999";
            this.btSelectAll.Text = "全选";
            this.btSelectAll.UseVisualStyleBackColor = false;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // cmbPost
            // 
            this.cmbPost.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPost.DropDownWidth = 100;
            this.cmbPost.FormattingEnabled = true;
            this.cmbPost.Location = new System.Drawing.Point(258, 86);
            this.cmbPost.Name = "cmbPost";
            this.cmbPost.Size = new System.Drawing.Size(70, 24);
            this.cmbPost.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "职务：";
            // 
            // cmbGroupS
            // 
            this.cmbGroupS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupS.DropDownWidth = 150;
            this.cmbGroupS.FormattingEnabled = true;
            this.cmbGroupS.Location = new System.Drawing.Point(84, 89);
            this.cmbGroupS.Name = "cmbGroupS";
            this.cmbGroupS.Size = new System.Drawing.Size(100, 24);
            this.cmbGroupS.TabIndex = 20;
            // 
            // txtNameS
            // 
            this.txtNameS.Location = new System.Drawing.Point(84, 54);
            this.txtNameS.Name = "txtNameS";
            this.txtNameS.Size = new System.Drawing.Size(100, 26);
            this.txtNameS.TabIndex = 13;
            // 
            // cmbDEPS
            // 
            this.cmbDEPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDEPS.DropDownWidth = 150;
            this.cmbDEPS.FormattingEnabled = true;
            this.cmbDEPS.Location = new System.Drawing.Point(84, 22);
            this.cmbDEPS.Name = "cmbDEPS";
            this.cmbDEPS.Size = new System.Drawing.Size(100, 24);
            this.cmbDEPS.TabIndex = 12;
            // 
            // cmbIsReader
            // 
            this.cmbIsReader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsReader.DropDownWidth = 100;
            this.cmbIsReader.FormattingEnabled = true;
            this.cmbIsReader.Items.AddRange(new object[] {
            "全部",
            "否",
            "是"});
            this.cmbIsReader.Location = new System.Drawing.Point(258, 22);
            this.cmbIsReader.Name = "cmbIsReader";
            this.cmbIsReader.Size = new System.Drawing.Size(70, 24);
            this.cmbIsReader.TabIndex = 16;
            // 
            // cmbIsCharger
            // 
            this.cmbIsCharger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsCharger.DropDownWidth = 100;
            this.cmbIsCharger.FormattingEnabled = true;
            this.cmbIsCharger.Items.AddRange(new object[] {
            "全部",
            "否",
            "是"});
            this.cmbIsCharger.Location = new System.Drawing.Point(258, 52);
            this.cmbIsCharger.Name = "cmbIsCharger";
            this.cmbIsCharger.Size = new System.Drawing.Size(70, 24);
            this.cmbIsCharger.TabIndex = 18;
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.LimeGreen;
            this.btSearch.Location = new System.Drawing.Point(194, 124);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(58, 32);
            this.btSearch.TabIndex = 22;
            this.btSearch.Tag = "9999";
            this.btSearch.Text = "查询";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 15;
            this.label11.Text = "所属部门：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "姓    名：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "所属分组：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(198, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 19;
            this.label14.Text = "收费员：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(198, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 17;
            this.label13.Text = "抄表员：";
            // 
            // frmSendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 662);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSendMessage";
            this.Text = "消息发布";
            this.Load += new System.EventHandler(this.frmSendMessage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbDEPS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNameS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbIsReader;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbIsCharger;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbGroupS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgUser;
        private System.Windows.Forms.ListBox lsbReceiver;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGINID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn workNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENTNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSTNAME;
        private System.Windows.Forms.ComboBox cmbPost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btNew;
    }
}
namespace SysControl
{
    partial class UC_UserSearch
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpUserList = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgWaterUser = new System.Windows.Forms.DataGridView();
            this.dgwaterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwaterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwaterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwaterPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgwaterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgprestore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTOTALFEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_waterPhone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TB_waterUserAddress = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.TB_waterUserName = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.TB_waterUserNO = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.btSearch = new System.Windows.Forms.Button();
            this.gpUserList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterUser)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpUserList
            // 
            this.gpUserList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gpUserList.Controls.Add(this.groupBox2);
            this.gpUserList.Controls.Add(this.groupBox1);
            this.gpUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpUserList.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpUserList.Location = new System.Drawing.Point(0, 0);
            this.gpUserList.Name = "gpUserList";
            this.gpUserList.Size = new System.Drawing.Size(349, 673);
            this.gpUserList.TabIndex = 7;
            this.gpUserList.TabStop = false;
            this.gpUserList.Text = "用户目录";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgWaterUser);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 150);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 520);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户列表";
            // 
            // dgWaterUser
            // 
            this.dgWaterUser.AllowUserToAddRows = false;
            this.dgWaterUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgWaterUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWaterUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgWaterUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWaterUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgWaterUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWaterUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgwaterUserNO,
            this.dgwaterUserId,
            this.dgwaterUserName,
            this.dgwaterPhone,
            this.dgwaterUserAddress,
            this.dgprestore,
            this.dgTOTALFEE,
            this.dgBalance});
            this.dgWaterUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWaterUser.Location = new System.Drawing.Point(3, 19);
            this.dgWaterUser.MultiSelect = false;
            this.dgWaterUser.Name = "dgWaterUser";
            this.dgWaterUser.ReadOnly = true;
            this.dgWaterUser.RowHeadersWidth = 45;
            this.dgWaterUser.RowTemplate.Height = 23;
            this.dgWaterUser.Size = new System.Drawing.Size(337, 498);
            this.dgWaterUser.TabIndex = 904;
            this.dgWaterUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWaterUser_CellDoubleClick);
            // 
            // dgwaterUserNO
            // 
            this.dgwaterUserNO.DataPropertyName = "waterUserNO";
            this.dgwaterUserNO.HeaderText = "用户号";
            this.dgwaterUserNO.Name = "dgwaterUserNO";
            this.dgwaterUserNO.ReadOnly = true;
            this.dgwaterUserNO.Width = 74;
            // 
            // dgwaterUserId
            // 
            this.dgwaterUserId.DataPropertyName = "waterUserId";
            this.dgwaterUserId.HeaderText = "waterUserId";
            this.dgwaterUserId.Name = "dgwaterUserId";
            this.dgwaterUserId.ReadOnly = true;
            this.dgwaterUserId.Visible = false;
            this.dgwaterUserId.Width = 109;
            // 
            // dgwaterUserName
            // 
            this.dgwaterUserName.DataPropertyName = "waterUserName";
            this.dgwaterUserName.HeaderText = "用户名称";
            this.dgwaterUserName.Name = "dgwaterUserName";
            this.dgwaterUserName.ReadOnly = true;
            this.dgwaterUserName.Width = 88;
            // 
            // dgwaterPhone
            // 
            this.dgwaterPhone.DataPropertyName = "waterPhone";
            this.dgwaterPhone.HeaderText = "联系电话";
            this.dgwaterPhone.Name = "dgwaterPhone";
            this.dgwaterPhone.ReadOnly = true;
            this.dgwaterPhone.Width = 88;
            // 
            // dgwaterUserAddress
            // 
            this.dgwaterUserAddress.DataPropertyName = "waterUserAddress";
            this.dgwaterUserAddress.HeaderText = "地址";
            this.dgwaterUserAddress.Name = "dgwaterUserAddress";
            this.dgwaterUserAddress.ReadOnly = true;
            this.dgwaterUserAddress.Width = 60;
            // 
            // dgprestore
            // 
            this.dgprestore.DataPropertyName = "prestore";
            this.dgprestore.HeaderText = "账户余额";
            this.dgprestore.Name = "dgprestore";
            this.dgprestore.ReadOnly = true;
            this.dgprestore.Width = 88;
            // 
            // dgTOTALFEE
            // 
            this.dgTOTALFEE.DataPropertyName = "TOTALFEE";
            this.dgTOTALFEE.HeaderText = "水费合计";
            this.dgTOTALFEE.Name = "dgTOTALFEE";
            this.dgTOTALFEE.ReadOnly = true;
            this.dgTOTALFEE.Width = 88;
            // 
            // dgBalance
            // 
            this.dgBalance.DataPropertyName = "Balance";
            this.dgBalance.HeaderText = "结算余额";
            this.dgBalance.Name = "dgBalance";
            this.dgBalance.ReadOnly = true;
            this.dgBalance.Width = 88;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.TB_waterPhone);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.TB_waterUserAddress);
            this.groupBox1.Controls.Add(this.label89);
            this.groupBox1.Controls.Add(this.TB_waterUserName);
            this.groupBox1.Controls.Add(this.label91);
            this.groupBox1.Controls.Add(this.TB_waterUserNO);
            this.groupBox1.Controls.Add(this.label92);
            this.groupBox1.Controls.Add(this.btSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 131);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "查询条件";
            // 
            // TB_waterPhone
            // 
            this.TB_waterPhone.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterPhone.Location = new System.Drawing.Point(81, 54);
            this.TB_waterPhone.Name = "TB_waterPhone";
            this.TB_waterPhone.Size = new System.Drawing.Size(84, 23);
            this.TB_waterPhone.TabIndex = 86;
            this.TB_waterPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 85;
            this.label12.Text = "联系电话：";
            // 
            // TB_waterUserAddress
            // 
            this.TB_waterUserAddress.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterUserAddress.Location = new System.Drawing.Point(238, 54);
            this.TB_waterUserAddress.Name = "TB_waterUserAddress";
            this.TB_waterUserAddress.Size = new System.Drawing.Size(101, 23);
            this.TB_waterUserAddress.TabIndex = 84;
            this.TB_waterUserAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(170, 58);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(77, 14);
            this.label89.TabIndex = 83;
            this.label89.Text = "用户地址：";
            // 
            // TB_waterUserName
            // 
            this.TB_waterUserName.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterUserName.Location = new System.Drawing.Point(238, 24);
            this.TB_waterUserName.Name = "TB_waterUserName";
            this.TB_waterUserName.Size = new System.Drawing.Size(101, 23);
            this.TB_waterUserName.TabIndex = 82;
            this.TB_waterUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(170, 29);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(77, 14);
            this.label91.TabIndex = 81;
            this.label91.Text = "用户名称：";
            // 
            // TB_waterUserNO
            // 
            this.TB_waterUserNO.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterUserNO.Location = new System.Drawing.Point(80, 24);
            this.TB_waterUserNO.Name = "TB_waterUserNO";
            this.TB_waterUserNO.Size = new System.Drawing.Size(85, 23);
            this.TB_waterUserNO.TabIndex = 79;
            this.TB_waterUserNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label92.Location = new System.Drawing.Point(6, 29);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(82, 14);
            this.label92.TabIndex = 80;
            this.label92.Text = "用户编号：";
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.LimeGreen;
            this.btSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSearch.Location = new System.Drawing.Point(12, 85);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(108, 37);
            this.btSearch.TabIndex = 73;
            this.btSearch.Tag = "9999";
            this.btSearch.Text = "查  询";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // UC_UserSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gpUserList);
            this.Name = "UC_UserSearch";
            this.Size = new System.Drawing.Size(349, 673);
            this.gpUserList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterUser)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpUserList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgWaterUser;
        private System.Windows.Forms.TextBox TB_waterPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TB_waterUserAddress;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.TextBox TB_waterUserName;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TextBox TB_waterUserNO;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Button btSearch;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwaterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwaterUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwaterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwaterPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgwaterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgprestore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTOTALFEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBalance;
    }
}

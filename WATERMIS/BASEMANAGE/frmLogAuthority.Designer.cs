namespace BASEMANAGE
{
    partial class frmLogAuthority
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogAuthority));
            this.tb2 = new System.Windows.Forms.TableLayoutPanel();
            this.tb3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgAuthority = new System.Windows.Forms.DataGridView();
            this.GROUPIDS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GROUPNAMES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENUNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MENUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALUE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MENUCLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolUserSearch = new System.Windows.Forms.ToolStripButton();
            this.dgGroup = new System.Windows.Forms.DataGridView();
            this.GROUPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb2.SuspendLayout();
            this.tb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuthority)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // tb2
            // 
            this.tb2.BackColor = System.Drawing.Color.Transparent;
            this.tb2.ColumnCount = 2;
            this.tb2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tb2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.68794F));
            this.tb2.Controls.Add(this.tb3, 1, 0);
            this.tb2.Controls.Add(this.tb1, 0, 0);
            this.tb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb2.Location = new System.Drawing.Point(0, 0);
            this.tb2.Name = "tb2";
            this.tb2.RowCount = 1;
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb2.Size = new System.Drawing.Size(775, 539);
            this.tb2.TabIndex = 14;
            // 
            // tb3
            // 
            this.tb3.BackColor = System.Drawing.Color.Transparent;
            this.tb3.ColumnCount = 1;
            this.tb3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb3.Controls.Add(this.dgAuthority, 0, 1);
            this.tb3.Controls.Add(this.groupBox1, 0, 0);
            this.tb3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb3.Location = new System.Drawing.Point(256, 3);
            this.tb3.Name = "tb3";
            this.tb3.RowCount = 2;
            this.tb3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tb3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb3.Size = new System.Drawing.Size(516, 533);
            this.tb3.TabIndex = 3;
            // 
            // dgAuthority
            // 
            this.dgAuthority.AllowUserToAddRows = false;
            this.dgAuthority.AllowUserToDeleteRows = false;
            this.dgAuthority.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAuthority.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAuthority.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgAuthority.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GROUPIDS,
            this.GROUPNAMES,
            this.MENUNAME,
            this.MEMO,
            this.MENUID,
            this.VALUE,
            this.MENUCLASS});
            this.dgAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAuthority.Location = new System.Drawing.Point(3, 100);
            this.dgAuthority.Name = "dgAuthority";
            this.dgAuthority.RowHeadersWidth = 25;
            this.dgAuthority.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgAuthority.RowTemplate.Height = 23;
            this.dgAuthority.Size = new System.Drawing.Size(510, 430);
            this.dgAuthority.TabIndex = 2;
            this.dgAuthority.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgAuthority_CellPainting);
            this.dgAuthority.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAuthority_CellContentClick);
            // 
            // GROUPIDS
            // 
            this.GROUPIDS.DataPropertyName = "GROUPID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GROUPIDS.DefaultCellStyle = dataGridViewCellStyle2;
            this.GROUPIDS.HeaderText = "GROUPIDS";
            this.GROUPIDS.Name = "GROUPIDS";
            this.GROUPIDS.ReadOnly = true;
            this.GROUPIDS.Visible = false;
            this.GROUPIDS.Width = 88;
            // 
            // GROUPNAMES
            // 
            this.GROUPNAMES.DataPropertyName = "GROUPNAME";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GROUPNAMES.DefaultCellStyle = dataGridViewCellStyle3;
            this.GROUPNAMES.HeaderText = "组名";
            this.GROUPNAMES.Name = "GROUPNAMES";
            this.GROUPNAMES.ReadOnly = true;
            this.GROUPNAMES.Width = 60;
            // 
            // MENUNAME
            // 
            this.MENUNAME.DataPropertyName = "MENUNAME";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MENUNAME.DefaultCellStyle = dataGridViewCellStyle4;
            this.MENUNAME.HeaderText = "菜单名称";
            this.MENUNAME.Name = "MENUNAME";
            this.MENUNAME.ReadOnly = true;
            this.MENUNAME.Visible = false;
            this.MENUNAME.Width = 88;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "权限";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.Width = 60;
            // 
            // MENUID
            // 
            this.MENUID.DataPropertyName = "MENUID";
            this.MENUID.HeaderText = "MENUID";
            this.MENUID.Name = "MENUID";
            this.MENUID.ReadOnly = true;
            this.MENUID.Visible = false;
            this.MENUID.Width = 74;
            // 
            // VALUE
            // 
            this.VALUE.FalseValue = "0";
            this.VALUE.HeaderText = "权限选择";
            this.VALUE.Name = "VALUE";
            this.VALUE.TrueValue = "1";
            this.VALUE.Width = 69;
            // 
            // MENUCLASS
            // 
            this.MENUCLASS.DataPropertyName = "MENUCLASS";
            this.MENUCLASS.HeaderText = "菜单级别";
            this.MENUCLASS.Name = "MENUCLASS";
            this.MENUCLASS.Width = 88;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "权限查询";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "说明:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(72, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "在组名后的\"权限选择\"列打钩，即可将此权限分配给该用户组；取消勾选即可取消该用户组的此项权限。";
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Controls.Add(this.toolStrip1, 0, 0);
            this.tb1.Controls.Add(this.dgGroup, 0, 2);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(3, 3);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(247, 533);
            this.tb1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbGroup);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 66);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户查询";
            // 
            // cmbGroup
            // 
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(109, 25);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(113, 22);
            this.cmbGroup.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 42;
            this.label3.Text = "分组名称：";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolUserSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(247, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolUserSearch
            // 
            this.toolUserSearch.Image = global::BASEMANAGE.Properties.Resources.onebit_02;
            this.toolUserSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUserSearch.Name = "toolUserSearch";
            this.toolUserSearch.Size = new System.Drawing.Size(55, 22);
            this.toolUserSearch.Text = "查询";
            this.toolUserSearch.Click += new System.EventHandler(this.toolUserSearch_Click);
            // 
            // dgGroup
            // 
            this.dgGroup.AllowUserToAddRows = false;
            this.dgGroup.AllowUserToDeleteRows = false;
            this.dgGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgGroup.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GROUPID,
            this.groupName});
            this.dgGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgGroup.Location = new System.Drawing.Point(3, 100);
            this.dgGroup.Name = "dgGroup";
            this.dgGroup.ReadOnly = true;
            this.dgGroup.RowHeadersWidth = 25;
            this.dgGroup.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgGroup.RowTemplate.Height = 23;
            this.dgGroup.Size = new System.Drawing.Size(241, 430);
            this.dgGroup.TabIndex = 16;
            this.dgGroup.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgGroup_CellPainting);
            this.dgGroup.SelectionChanged += new System.EventHandler(this.dgPerson_SelectionChanged);
            // 
            // GROUPID
            // 
            this.GROUPID.DataPropertyName = "GROUPID";
            this.GROUPID.HeaderText = "GROUPID";
            this.GROUPID.Name = "GROUPID";
            this.GROUPID.ReadOnly = true;
            this.GROUPID.Visible = false;
            // 
            // groupName
            // 
            this.groupName.DataPropertyName = "groupName";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.groupName.DefaultCellStyle = dataGridViewCellStyle6;
            this.groupName.HeaderText = "组名";
            this.groupName.Name = "groupName";
            this.groupName.ReadOnly = true;
            this.groupName.Width = 60;
            // 
            // frmLogAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 539);
            this.Controls.Add(this.tb2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogAuthority";
            this.Text = "权限分配";
            this.Load += new System.EventHandler(this.frmLogAuthority_Load);
            this.tb2.ResumeLayout(false);
            this.tb3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAuthority)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.tb1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb2;
        private System.Windows.Forms.TableLayoutPanel tb3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolUserSearch;
        private System.Windows.Forms.DataGridView dgGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgAuthority;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUPIDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GROUPNAMES;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENUNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENUID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VALUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENUCLASS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
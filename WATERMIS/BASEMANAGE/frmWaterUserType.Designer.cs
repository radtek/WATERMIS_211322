namespace BASEMANAGE
{
    partial class frmWaterUserType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterUserType));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolDel = new System.Windows.Forms.ToolStripButton();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btModel = new System.Windows.Forms.Button();
            this.txtInvioceBillName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.chkIsEnable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartDay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStartMonth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.waterUserTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overDuechargeEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overDuechargeStartMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overDuechargeStartDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overDuechargePercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceBillName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolSave,
            this.toolDel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(986, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::BASEMANAGE.Properties.Resources.onebit_31;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(55, 22);
            this.toolAdd.Text = "添加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolSave
            // 
            this.toolSave.Image = global::BASEMANAGE.Properties.Resources.onebit_34;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(55, 22);
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolDel
            // 
            this.toolDel.Image = global::BASEMANAGE.Properties.Resources.onebit_33;
            this.toolDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDel.Name = "toolDel";
            this.toolDel.Size = new System.Drawing.Size(55, 22);
            this.toolDel.Text = "删除";
            this.toolDel.Click += new System.EventHandler(this.toolDel_Click);
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.txtFilePath);
            this.grpDetail.Controls.Add(this.btModel);
            this.grpDetail.Controls.Add(this.txtInvioceBillName);
            this.grpDetail.Controls.Add(this.txtName);
            this.grpDetail.Controls.Add(this.txtMemo);
            this.grpDetail.Controls.Add(this.chkIsEnable);
            this.grpDetail.Controls.Add(this.label1);
            this.grpDetail.Controls.Add(this.label5);
            this.grpDetail.Controls.Add(this.label3);
            this.grpDetail.Controls.Add(this.txtID);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.Location = new System.Drawing.Point(4, 4);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(0);
            this.grpDetail.Size = new System.Drawing.Size(978, 98);
            this.grpDetail.TabIndex = 0;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "用户类别详情";
            // 
            // txtFilePath
            // 
            this.txtFilePath.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilePath.Location = new System.Drawing.Point(773, 26);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(124, 26);
            this.txtFilePath.TabIndex = 27;
            this.txtFilePath.Visible = false;
            // 
            // btModel
            // 
            this.btModel.Location = new System.Drawing.Point(677, 25);
            this.btModel.Name = "btModel";
            this.btModel.Size = new System.Drawing.Size(90, 25);
            this.btModel.TabIndex = 3;
            this.btModel.Text = "选择模板";
            this.btModel.UseVisualStyleBackColor = true;
            this.btModel.Click += new System.EventHandler(this.btModel_Click);
            // 
            // txtInvioceBillName
            // 
            this.txtInvioceBillName.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvioceBillName.Location = new System.Drawing.Point(541, 24);
            this.txtInvioceBillName.Name = "txtInvioceBillName";
            this.txtInvioceBillName.ReadOnly = true;
            this.txtInvioceBillName.Size = new System.Drawing.Size(125, 26);
            this.txtInvioceBillName.TabIndex = 26;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(316, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(125, 26);
            this.txtName.TabIndex = 2;
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(318, 60);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(468, 26);
            this.txtMemo.TabIndex = 5;
            // 
            // chkIsEnable
            // 
            this.chkIsEnable.AutoSize = true;
            this.chkIsEnable.Location = new System.Drawing.Point(95, 63);
            this.chkIsEnable.Name = "chkIsEnable";
            this.chkIsEnable.Size = new System.Drawing.Size(107, 20);
            this.chkIsEnable.TabIndex = 4;
            this.chkIsEnable.Text = "启用滞纳金";
            this.chkIsEnable.UseVisualStyleBackColor = true;
            this.chkIsEnable.Visible = false;
            this.chkIsEnable.CheckedChanged += new System.EventHandler(this.chkIsEnable_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "*类别名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "备    注：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "发票模板：";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Window;
            this.txtID.Location = new System.Drawing.Point(95, 24);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(125, 26);
            this.txtID.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "*类别代码：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 110);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(978, 292);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户类别列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.waterUserTypeId,
            this.waterUserTypeName,
            this.overDuechargeEnable,
            this.overDuechargeStartMonth,
            this.overDuechargeStartDay,
            this.overDuechargePercent,
            this.invoiceBillName,
            this.MEMO});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(4, 23);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 25;
            this.dgList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(970, 265);
            this.dgList.TabIndex = 0;
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgList.SelectionChanged += new System.EventHandler(this.dgList_SelectionChanged);
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.Transparent;
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox2, 0, 2);
            this.tb1.Controls.Add(this.grpDetail, 0, 0);
            this.tb1.Controls.Add(this.groupBox1, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(986, 406);
            this.tb1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPercent);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtStartDay);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtStartMonth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(980, 1);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "滞纳金计算方式";
            // 
            // txtPercent
            // 
            this.txtPercent.BackColor = System.Drawing.SystemColors.Window;
            this.txtPercent.Location = new System.Drawing.Point(110, 49);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(69, 26);
            this.txtPercent.TabIndex = 8;
            this.txtPercent.Text = "0.0003";
            this.txtPercent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercent_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "滞纳金比率：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "号开始算起。";
            // 
            // txtStartDay
            // 
            this.txtStartDay.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartDay.Location = new System.Drawing.Point(278, 18);
            this.txtStartDay.Name = "txtStartDay";
            this.txtStartDay.Size = new System.Drawing.Size(50, 26);
            this.txtStartDay.TabIndex = 7;
            this.txtStartDay.Text = "1";
            this.txtStartDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "个月的";
            // 
            // txtStartMonth
            // 
            this.txtStartMonth.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartMonth.Location = new System.Drawing.Point(166, 17);
            this.txtStartMonth.Name = "txtStartMonth";
            this.txtStartMonth.Size = new System.Drawing.Size(50, 26);
            this.txtStartMonth.TabIndex = 6;
            this.txtStartMonth.Text = "1";
            this.txtStartMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "水费审核之日后，第";
            // 
            // waterUserTypeId
            // 
            this.waterUserTypeId.DataPropertyName = "waterUserTypeId";
            this.waterUserTypeId.HeaderText = "类别代码";
            this.waterUserTypeId.Name = "waterUserTypeId";
            this.waterUserTypeId.ReadOnly = true;
            this.waterUserTypeId.Width = 97;
            // 
            // waterUserTypeName
            // 
            this.waterUserTypeName.DataPropertyName = "waterUserTypeName";
            this.waterUserTypeName.HeaderText = "用户类别";
            this.waterUserTypeName.Name = "waterUserTypeName";
            this.waterUserTypeName.ReadOnly = true;
            this.waterUserTypeName.Width = 97;
            // 
            // overDuechargeEnable
            // 
            this.overDuechargeEnable.DataPropertyName = "overDuechargeEnableS";
            this.overDuechargeEnable.HeaderText = "启用滞纳金";
            this.overDuechargeEnable.Name = "overDuechargeEnable";
            this.overDuechargeEnable.ReadOnly = true;
            this.overDuechargeEnable.Visible = false;
            this.overDuechargeEnable.Width = 113;
            // 
            // overDuechargeStartMonth
            // 
            this.overDuechargeStartMonth.DataPropertyName = "overDuechargeStartMonth";
            this.overDuechargeStartMonth.HeaderText = "开始月数";
            this.overDuechargeStartMonth.Name = "overDuechargeStartMonth";
            this.overDuechargeStartMonth.ReadOnly = true;
            this.overDuechargeStartMonth.Visible = false;
            this.overDuechargeStartMonth.Width = 97;
            // 
            // overDuechargeStartDay
            // 
            this.overDuechargeStartDay.DataPropertyName = "overDuechargeStartDay";
            this.overDuechargeStartDay.HeaderText = "开始日期";
            this.overDuechargeStartDay.Name = "overDuechargeStartDay";
            this.overDuechargeStartDay.ReadOnly = true;
            this.overDuechargeStartDay.Visible = false;
            this.overDuechargeStartDay.Width = 97;
            // 
            // overDuechargePercent
            // 
            this.overDuechargePercent.DataPropertyName = "overDuechargePercent";
            this.overDuechargePercent.HeaderText = "比率";
            this.overDuechargePercent.Name = "overDuechargePercent";
            this.overDuechargePercent.ReadOnly = true;
            this.overDuechargePercent.Visible = false;
            this.overDuechargePercent.Width = 65;
            // 
            // invoiceBillName
            // 
            this.invoiceBillName.DataPropertyName = "invoiceBillName";
            this.invoiceBillName.HeaderText = "发票模板文件";
            this.invoiceBillName.Name = "invoiceBillName";
            this.invoiceBillName.ReadOnly = true;
            this.invoiceBillName.Width = 129;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "备注";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.Width = 65;
            // 
            // frmWaterUserType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BASEMANAGE.Properties.Resources.登录界面;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(986, 431);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterUserType";
            this.Text = "用户类别";
            this.Load += new System.EventHandler(this.frmWaterUserType_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.tb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolDel;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.Button btModel;
        private System.Windows.Forms.TextBox txtInvioceBillName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.CheckBox chkIsEnable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStartMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn overDuechargeEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn overDuechargeStartMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn overDuechargeStartDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn overDuechargePercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceBillName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}
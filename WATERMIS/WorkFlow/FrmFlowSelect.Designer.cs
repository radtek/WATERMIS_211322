namespace WorkFlow
{
    partial class FrmFlowSelect
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolDel = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.WorkCode = new System.Windows.Forms.ComboBox();
            this.WaterMeterTypeClassID = new System.Windows.Forms.ComboBox();
            this.TableID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartDay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStartMonth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TableID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApproveID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table_Name_CH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaterMeterTypeClassID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERMETERTYPECLASSNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.grpDetail.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(987, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(39, 22);
            this.toolAdd.Text = "添加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolSave
            // 
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(39, 22);
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolDel
            // 
            this.toolDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDel.Name = "toolDel";
            this.toolDel.Size = new System.Drawing.Size(39, 22);
            this.toolDel.Text = "删除";
            this.toolDel.Click += new System.EventHandler(this.toolDel_Click);
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(987, 451);
            this.tb1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 64);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(979, 383);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "审批类型列表";
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
            this.TableID1,
            this.ApproveID,
            this.Table_Name_CH,
            this.WaterMeterTypeClassID1,
            this.WATERMETERTYPECLASSNAME,
            this.WorkCode1,
            this.WorkName,
            this.State,
            this.CreateDate,
            this.loginId});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(4, 18);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 25;
            this.dgList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(971, 361);
            this.dgList.TabIndex = 0;
            this.dgList.SelectionChanged += new System.EventHandler(this.dgList_SelectionChanged);
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.WorkCode);
            this.grpDetail.Controls.Add(this.WaterMeterTypeClassID);
            this.grpDetail.Controls.Add(this.TableID);
            this.grpDetail.Controls.Add(this.label1);
            this.grpDetail.Controls.Add(this.label3);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.Location = new System.Drawing.Point(4, 4);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(0);
            this.grpDetail.Size = new System.Drawing.Size(979, 52);
            this.grpDetail.TabIndex = 0;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "审批类型";
            // 
            // WorkCode
            // 
            this.WorkCode.DropDownHeight = 130;
            this.WorkCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkCode.DropDownWidth = 150;
            this.WorkCode.FormattingEnabled = true;
            this.WorkCode.IntegralHeight = false;
            this.WorkCode.Location = new System.Drawing.Point(541, 21);
            this.WorkCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WorkCode.Name = "WorkCode";
            this.WorkCode.Size = new System.Drawing.Size(149, 20);
            this.WorkCode.TabIndex = 178;
            this.WorkCode.Tag = "9999";
            // 
            // WaterMeterTypeClassID
            // 
            this.WaterMeterTypeClassID.DropDownHeight = 130;
            this.WaterMeterTypeClassID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WaterMeterTypeClassID.DropDownWidth = 150;
            this.WaterMeterTypeClassID.FormattingEnabled = true;
            this.WaterMeterTypeClassID.IntegralHeight = false;
            this.WaterMeterTypeClassID.Location = new System.Drawing.Point(317, 21);
            this.WaterMeterTypeClassID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WaterMeterTypeClassID.Name = "WaterMeterTypeClassID";
            this.WaterMeterTypeClassID.Size = new System.Drawing.Size(149, 20);
            this.WaterMeterTypeClassID.TabIndex = 177;
            this.WaterMeterTypeClassID.Tag = "9999";
            // 
            // TableID
            // 
            this.TableID.DropDownHeight = 130;
            this.TableID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TableID.DropDownWidth = 150;
            this.TableID.FormattingEnabled = true;
            this.TableID.IntegralHeight = false;
            this.TableID.Location = new System.Drawing.Point(78, 21);
            this.TableID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TableID.Name = "TableID";
            this.TableID.Size = new System.Drawing.Size(149, 20);
            this.TableID.TabIndex = 176;
            this.TableID.Tag = "9999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "用水类别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "选择流程：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "业务类型：";
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
            this.groupBox1.Location = new System.Drawing.Point(3, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(981, 1);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "滞纳金计算方式";
            // 
            // txtPercent
            // 
            this.txtPercent.BackColor = System.Drawing.SystemColors.Window;
            this.txtPercent.Location = new System.Drawing.Point(110, 49);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(69, 21);
            this.txtPercent.TabIndex = 8;
            this.txtPercent.Text = "0.0003";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "滞纳金比率：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "号开始算起。";
            // 
            // txtStartDay
            // 
            this.txtStartDay.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartDay.Location = new System.Drawing.Point(278, 18);
            this.txtStartDay.Name = "txtStartDay";
            this.txtStartDay.Size = new System.Drawing.Size(50, 21);
            this.txtStartDay.TabIndex = 7;
            this.txtStartDay.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "个月的";
            // 
            // txtStartMonth
            // 
            this.txtStartMonth.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartMonth.Location = new System.Drawing.Point(166, 17);
            this.txtStartMonth.Name = "txtStartMonth";
            this.txtStartMonth.Size = new System.Drawing.Size(50, 21);
            this.txtStartMonth.TabIndex = 6;
            this.txtStartMonth.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "水费审核之日后，第";
            // 
            // TableID1
            // 
            this.TableID1.DataPropertyName = "TableID";
            this.TableID1.HeaderText = "TableID";
            this.TableID1.Name = "TableID1";
            this.TableID1.ReadOnly = true;
            this.TableID1.Visible = false;
            this.TableID1.Width = 89;
            // 
            // ApproveID
            // 
            this.ApproveID.DataPropertyName = "ApproveID";
            this.ApproveID.HeaderText = "ApproveID";
            this.ApproveID.Name = "ApproveID";
            this.ApproveID.ReadOnly = true;
            this.ApproveID.Visible = false;
            this.ApproveID.Width = 105;
            // 
            // Table_Name_CH
            // 
            this.Table_Name_CH.DataPropertyName = "Table_Name_CH";
            this.Table_Name_CH.HeaderText = "审批类型";
            this.Table_Name_CH.Name = "Table_Name_CH";
            this.Table_Name_CH.ReadOnly = true;
            this.Table_Name_CH.Width = 97;
            // 
            // WaterMeterTypeClassID1
            // 
            this.WaterMeterTypeClassID1.DataPropertyName = "WaterMeterTypeClassID";
            this.WaterMeterTypeClassID1.HeaderText = "WaterMeterTypeClassID";
            this.WaterMeterTypeClassID1.Name = "WaterMeterTypeClassID1";
            this.WaterMeterTypeClassID1.ReadOnly = true;
            this.WaterMeterTypeClassID1.Visible = false;
            this.WaterMeterTypeClassID1.Width = 201;
            // 
            // WATERMETERTYPECLASSNAME
            // 
            this.WATERMETERTYPECLASSNAME.DataPropertyName = "WATERMETERTYPECLASSNAME";
            this.WATERMETERTYPECLASSNAME.HeaderText = "用水性质";
            this.WATERMETERTYPECLASSNAME.Name = "WATERMETERTYPECLASSNAME";
            this.WATERMETERTYPECLASSNAME.ReadOnly = true;
            this.WATERMETERTYPECLASSNAME.Width = 97;
            // 
            // WorkCode1
            // 
            this.WorkCode1.DataPropertyName = "WorkCode";
            this.WorkCode1.HeaderText = "WorkCode";
            this.WorkCode1.Name = "WorkCode1";
            this.WorkCode1.ReadOnly = true;
            this.WorkCode1.Visible = false;
            this.WorkCode1.Width = 97;
            // 
            // WorkName
            // 
            this.WorkName.DataPropertyName = "WorkName";
            this.WorkName.HeaderText = "应用流程";
            this.WorkName.Name = "WorkName";
            this.WorkName.ReadOnly = true;
            this.WorkName.Width = 97;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Visible = false;
            this.State.Width = 73;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "创建时间";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 97;
            // 
            // loginId
            // 
            this.loginId.DataPropertyName = "loginId";
            this.loginId.HeaderText = "loginId";
            this.loginId.Name = "loginId";
            this.loginId.ReadOnly = true;
            this.loginId.Visible = false;
            this.loginId.Width = 89;
            // 
            // FrmFlowSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 476);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmFlowSelect";
            this.Text = "工作流设置";
            this.Load += new System.EventHandler(this.FrmFlowSelect_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStartDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStartMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox WorkCode;
        private System.Windows.Forms.ComboBox WaterMeterTypeClassID;
        private System.Windows.Forms.ComboBox TableID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApproveID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table_Name_CH;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaterMeterTypeClassID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERMETERTYPECLASSNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginId;

    }
}
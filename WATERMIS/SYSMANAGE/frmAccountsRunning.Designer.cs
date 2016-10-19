namespace SYSMANAGE
{
    partial class frmAccountsRunning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountsRunning));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolDel = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.ACCOUNTSYEARANDMONTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BUSINESSMONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINANCEMONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCOUNTSDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPERATORNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCOUNTSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkDateTime = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolDel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(960, 25);
            this.toolStrip1.TabIndex = 1;
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
            // toolDel
            // 
            this.toolDel.Image = global::SYSMANAGE.Properties.Resources.close;
            this.toolDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDel.Name = "toolDel";
            this.toolDel.Size = new System.Drawing.Size(55, 22);
            this.toolDel.Text = "删除";
            this.toolDel.Click += new System.EventHandler(this.toolDel_Click);
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.Transparent;
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Controls.Add(this.groupBox3, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.97506F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.Size = new System.Drawing.Size(960, 637);
            this.tb1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 64);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(952, 569);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "账款列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.ColumnHeadersHeight = 45;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ACCOUNTSYEARANDMONTH,
            this.BUSINESSMONEY,
            this.FINANCEMONEY,
            this.ACCOUNTSDATETIME,
            this.OPERATORNAME,
            this.ACCOUNTSID});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(4, 23);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.RowHeadersWidth = 25;
            this.dgList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(944, 542);
            this.dgList.TabIndex = 0;
            this.dgList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellValueChanged);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            // 
            // ACCOUNTSYEARANDMONTH
            // 
            this.ACCOUNTSYEARANDMONTH.DataPropertyName = "ACCOUNTSYEARANDMONTH";
            this.ACCOUNTSYEARANDMONTH.HeaderText = "账款月份";
            this.ACCOUNTSYEARANDMONTH.Name = "ACCOUNTSYEARANDMONTH";
            this.ACCOUNTSYEARANDMONTH.Width = 153;
            // 
            // BUSINESSMONEY
            // 
            this.BUSINESSMONEY.DataPropertyName = "BUSINESSMONEY";
            this.BUSINESSMONEY.HeaderText = "用户余额(营业账款)";
            this.BUSINESSMONEY.Name = "BUSINESSMONEY";
            this.BUSINESSMONEY.Width = 129;
            // 
            // FINANCEMONEY
            // 
            this.FINANCEMONEY.DataPropertyName = "FINANCEMONEY";
            this.FINANCEMONEY.HeaderText = "用户余额(财务账款)";
            this.FINANCEMONEY.Name = "FINANCEMONEY";
            this.FINANCEMONEY.Width = 145;
            // 
            // ACCOUNTSDATETIME
            // 
            this.ACCOUNTSDATETIME.DataPropertyName = "ACCOUNTSDATETIME";
            this.ACCOUNTSDATETIME.HeaderText = "生成时间";
            this.ACCOUNTSDATETIME.Name = "ACCOUNTSDATETIME";
            this.ACCOUNTSDATETIME.Width = 129;
            // 
            // OPERATORNAME
            // 
            this.OPERATORNAME.DataPropertyName = "OPERATORNAME";
            this.OPERATORNAME.HeaderText = "操作员";
            this.OPERATORNAME.Name = "OPERATORNAME";
            // 
            // ACCOUNTSID
            // 
            this.ACCOUNTSID.DataPropertyName = "ACCOUNTSID";
            this.ACCOUNTSID.HeaderText = "ACCOUNTSID";
            this.ACCOUNTSID.Name = "ACCOUNTSID";
            this.ACCOUNTSID.Visible = false;
            this.ACCOUNTSID.Width = 137;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpEnd);
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Controls.Add(this.chkDateTime);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(954, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(245, 20);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 127;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(104, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 126;
            // 
            // chkDateTime
            // 
            this.chkDateTime.AutoSize = true;
            this.chkDateTime.Checked = true;
            this.chkDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateTime.Location = new System.Drawing.Point(9, 23);
            this.chkDateTime.Name = "chkDateTime";
            this.chkDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkDateTime.TabIndex = 125;
            this.chkDateTime.Text = "账款月份:";
            this.chkDateTime.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 128;
            this.label10.Text = "至";
            // 
            // frmAccountsRunning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 662);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAccountsRunning";
            this.Text = "预收账款查询";
            this.Load += new System.EventHandler(this.frmMessageSendSearch_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripButton toolDel;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkDateTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNTSYEARANDMONTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn BUSINESSMONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINANCEMONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNTSDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPERATORNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNTSID;

    }
}
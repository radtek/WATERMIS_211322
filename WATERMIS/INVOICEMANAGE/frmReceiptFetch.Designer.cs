namespace INVOICEMANAGE
{
    partial class frmReceiptFetch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceiptFetch));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.RECEIPTFETCHERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPTFETCHDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPTFETCHSTARTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPTFETCHENDNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPTFETCHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPTFETCHDEPNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPTFETCHERID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.cmbChargerWorkName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbChargerWorkNameSearch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.chkFetch = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.gbDetail.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolSave,
            this.toolStripSeparator1,
            this.toolDelete,
            this.toolStripSeparator2,
            this.toolSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 28);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolAdd
            // 
            this.toolAdd.Image = global::INVOICEMANAGE.Properties.Resources.onebit_31;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(62, 25);
            this.toolAdd.Text = "新增";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolSave
            // 
            this.toolSave.Image = global::INVOICEMANAGE.Properties.Resources.onebit_34;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(62, 25);
            this.toolSave.Text = "保存";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = global::INVOICEMANAGE.Properties.Resources.onebit_33;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(62, 25);
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::INVOICEMANAGE.Properties.Resources.onebit_02;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(62, 25);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.Transparent;
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox2, 0, 2);
            this.tb1.Controls.Add(this.gbDetail, 0, 1);
            this.tb1.Controls.Add(this.groupBox3, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 28);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.Size = new System.Drawing.Size(984, 425);
            this.tb1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 134);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(976, 287);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "领用列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RECEIPTFETCHERNAME,
            this.RECEIPTFETCHDATETIME,
            this.RECEIPTFETCHSTARTNO,
            this.RECEIPTFETCHENDNO,
            this.MEMO,
            this.RECEIPTFETCHID,
            this.RECEIPTFETCHDEPNAME,
            this.RECEIPTFETCHERID});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(4, 23);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 30;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(968, 260);
            this.dgList.TabIndex = 0;
            this.dgList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_RowEnter);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            // 
            // RECEIPTFETCHERNAME
            // 
            this.RECEIPTFETCHERNAME.DataPropertyName = "RECEIPTFETCHERNAME";
            this.RECEIPTFETCHERNAME.HeaderText = "领用人";
            this.RECEIPTFETCHERNAME.Name = "RECEIPTFETCHERNAME";
            this.RECEIPTFETCHERNAME.ReadOnly = true;
            this.RECEIPTFETCHERNAME.Width = 81;
            // 
            // RECEIPTFETCHDATETIME
            // 
            this.RECEIPTFETCHDATETIME.DataPropertyName = "RECEIPTFETCHDATETIME";
            this.RECEIPTFETCHDATETIME.HeaderText = "领用时间";
            this.RECEIPTFETCHDATETIME.Name = "RECEIPTFETCHDATETIME";
            this.RECEIPTFETCHDATETIME.ReadOnly = true;
            this.RECEIPTFETCHDATETIME.Width = 97;
            // 
            // RECEIPTFETCHSTARTNO
            // 
            this.RECEIPTFETCHSTARTNO.DataPropertyName = "RECEIPTFETCHSTARTNO";
            this.RECEIPTFETCHSTARTNO.HeaderText = "起始号码";
            this.RECEIPTFETCHSTARTNO.Name = "RECEIPTFETCHSTARTNO";
            this.RECEIPTFETCHSTARTNO.ReadOnly = true;
            this.RECEIPTFETCHSTARTNO.Width = 97;
            // 
            // RECEIPTFETCHENDNO
            // 
            this.RECEIPTFETCHENDNO.DataPropertyName = "RECEIPTFETCHENDNO";
            this.RECEIPTFETCHENDNO.HeaderText = "终止号码";
            this.RECEIPTFETCHENDNO.Name = "RECEIPTFETCHENDNO";
            this.RECEIPTFETCHENDNO.ReadOnly = true;
            this.RECEIPTFETCHENDNO.Width = 97;
            // 
            // MEMO
            // 
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.HeaderText = "备注";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.Width = 65;
            // 
            // RECEIPTFETCHID
            // 
            this.RECEIPTFETCHID.DataPropertyName = "RECEIPTFETCHID";
            this.RECEIPTFETCHID.HeaderText = "RECEIPTFETCHID";
            this.RECEIPTFETCHID.Name = "RECEIPTFETCHID";
            this.RECEIPTFETCHID.ReadOnly = true;
            this.RECEIPTFETCHID.Visible = false;
            this.RECEIPTFETCHID.Width = 145;
            // 
            // RECEIPTFETCHDEPNAME
            // 
            this.RECEIPTFETCHDEPNAME.DataPropertyName = "RECEIPTFETCHDEPNAME";
            this.RECEIPTFETCHDEPNAME.HeaderText = "领用部门";
            this.RECEIPTFETCHDEPNAME.Name = "RECEIPTFETCHDEPNAME";
            this.RECEIPTFETCHDEPNAME.ReadOnly = true;
            this.RECEIPTFETCHDEPNAME.Visible = false;
            this.RECEIPTFETCHDEPNAME.Width = 97;
            // 
            // RECEIPTFETCHERID
            // 
            this.RECEIPTFETCHERID.DataPropertyName = "RECEIPTFETCHERID";
            this.RECEIPTFETCHERID.HeaderText = "RECEIPTFETCHERID";
            this.RECEIPTFETCHERID.Name = "RECEIPTFETCHERID";
            this.RECEIPTFETCHERID.ReadOnly = true;
            this.RECEIPTFETCHERID.Visible = false;
            this.RECEIPTFETCHERID.Width = 161;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.cmbChargerWorkName);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.txtStartNO);
            this.gbDetail.Controls.Add(this.label4);
            this.gbDetail.Controls.Add(this.txtID);
            this.gbDetail.Controls.Add(this.txtMemo);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.txtEndNO);
            this.gbDetail.Controls.Add(this.label1);
            this.gbDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetail.Location = new System.Drawing.Point(4, 67);
            this.gbDetail.Margin = new System.Windows.Forms.Padding(4);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Padding = new System.Windows.Forms.Padding(4);
            this.gbDetail.Size = new System.Drawing.Size(976, 59);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "领用详细信息";
            // 
            // cmbChargerWorkName
            // 
            this.cmbChargerWorkName.DropDownWidth = 120;
            this.cmbChargerWorkName.FormattingEnabled = true;
            this.cmbChargerWorkName.Location = new System.Drawing.Point(101, 25);
            this.cmbChargerWorkName.Name = "cmbChargerWorkName";
            this.cmbChargerWorkName.Size = new System.Drawing.Size(88, 24);
            this.cmbChargerWorkName.TabIndex = 164;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 165;
            this.label5.Text = "领用人:";
            // 
            // txtStartNO
            // 
            this.txtStartNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartNO.Location = new System.Drawing.Point(284, 25);
            this.txtStartNO.Name = "txtStartNO";
            this.txtStartNO.Size = new System.Drawing.Size(122, 26);
            this.txtStartNO.TabIndex = 1;
            this.txtStartNO.TextChanged += new System.EventHandler(this.txtStartNO_TextChanged);
            this.txtStartNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartNO_KeyPress);
            this.txtStartNO.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartNO_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "起始号码:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Window;
            this.txtID.Location = new System.Drawing.Point(11, 21);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(17, 26);
            this.txtID.TabIndex = 4;
            this.txtID.Visible = false;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(659, 25);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(151, 26);
            this.txtMemo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(614, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "备注:";
            // 
            // txtEndNO
            // 
            this.txtEndNO.Location = new System.Drawing.Point(499, 25);
            this.txtEndNO.Name = "txtEndNO";
            this.txtEndNO.Size = new System.Drawing.Size(100, 26);
            this.txtEndNO.TabIndex = 2;
            this.txtEndNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartNO_KeyPress);
            this.txtEndNO.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartNO_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "终止号码:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox3.Controls.Add(this.cmbChargerWorkNameSearch);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dtEndDate);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dtStartDate);
            this.groupBox3.Controls.Add(this.chkFetch);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(978, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "9999";
            this.groupBox3.Text = "查询条件";
            // 
            // cmbChargerWorkNameSearch
            // 
            this.cmbChargerWorkNameSearch.DropDownWidth = 120;
            this.cmbChargerWorkNameSearch.FormattingEnabled = true;
            this.cmbChargerWorkNameSearch.Location = new System.Drawing.Point(72, 22);
            this.cmbChargerWorkNameSearch.Name = "cmbChargerWorkNameSearch";
            this.cmbChargerWorkNameSearch.Size = new System.Drawing.Size(88, 24);
            this.cmbChargerWorkNameSearch.TabIndex = 162;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 163;
            this.label3.Text = "领用人:";
            // 
            // dtEndDate
            // 
            this.dtEndDate.CustomFormat = "yyyy年MM月dd日";
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(458, 21);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(154, 26);
            this.dtEndDate.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(435, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "至";
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "yyyy年MM月dd日";
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(278, 21);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(154, 26);
            this.dtStartDate.TabIndex = 14;
            // 
            // chkFetch
            // 
            this.chkFetch.AutoSize = true;
            this.chkFetch.Location = new System.Drawing.Point(186, 24);
            this.chkFetch.Name = "chkFetch";
            this.chkFetch.Size = new System.Drawing.Size(99, 20);
            this.chkFetch.TabIndex = 13;
            this.chkFetch.Text = "领用时间:";
            this.chkFetch.UseVisualStyleBackColor = true;
            // 
            // frmReceiptFetch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 453);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReceiptFetch";
            this.Text = "收据领用记录";
            this.Load += new System.EventHandler(this.frmInvoiceStocks_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtStartNO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.CheckBox chkFetch;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.ComboBox cmbChargerWorkNameSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbChargerWorkName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPTFETCHERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPTFETCHDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPTFETCHSTARTNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPTFETCHENDNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPTFETCHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPTFETCHDEPNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPTFETCHERID;
    }
}
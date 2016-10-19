namespace INVOICEMANAGE
{
    partial class frmInvoiceStocks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceStocks));
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
            this.INVOICESTOCKSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEBATCHID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEBATCHNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICESTARTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEENDNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICEMEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.txtStartNO = new System.Windows.Forms.TextBox();
            this.btBatch = new System.Windows.Forms.Button();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbBatchSearch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.toolStrip1.Size = new System.Drawing.Size(896, 28);
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.Size = new System.Drawing.Size(896, 425);
            this.tb1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 168);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(888, 253);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发票列表";
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
            this.INVOICESTOCKSID,
            this.INVOICEBATCHID,
            this.INVOICEBATCHNAME,
            this.INVOICESTARTNO,
            this.INVOICEENDNO,
            this.INVOICEMEMO});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(4, 23);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 30;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(880, 226);
            this.dgList.TabIndex = 0;
            this.dgList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_RowEnter);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            // 
            // INVOICESTOCKSID
            // 
            this.INVOICESTOCKSID.DataPropertyName = "INVOICESTOCKSID";
            this.INVOICESTOCKSID.HeaderText = "INVOICESTOCKSID";
            this.INVOICESTOCKSID.Name = "INVOICESTOCKSID";
            this.INVOICESTOCKSID.ReadOnly = true;
            this.INVOICESTOCKSID.Visible = false;
            this.INVOICESTOCKSID.Width = 153;
            // 
            // INVOICEBATCHID
            // 
            this.INVOICEBATCHID.DataPropertyName = "INVOICEBATCHID";
            this.INVOICEBATCHID.HeaderText = "INVOICEBATCHID";
            this.INVOICEBATCHID.Name = "INVOICEBATCHID";
            this.INVOICEBATCHID.ReadOnly = true;
            this.INVOICEBATCHID.Visible = false;
            this.INVOICEBATCHID.Width = 145;
            // 
            // INVOICEBATCHNAME
            // 
            this.INVOICEBATCHNAME.DataPropertyName = "INVOICEBATCHNAME";
            this.INVOICEBATCHNAME.HeaderText = "发票批次";
            this.INVOICEBATCHNAME.Name = "INVOICEBATCHNAME";
            this.INVOICEBATCHNAME.ReadOnly = true;
            this.INVOICEBATCHNAME.Width = 97;
            // 
            // INVOICESTARTNO
            // 
            this.INVOICESTARTNO.DataPropertyName = "INVOICESTARTNO";
            this.INVOICESTARTNO.HeaderText = "起始号码";
            this.INVOICESTARTNO.Name = "INVOICESTARTNO";
            this.INVOICESTARTNO.ReadOnly = true;
            this.INVOICESTARTNO.Width = 97;
            // 
            // INVOICEENDNO
            // 
            this.INVOICEENDNO.DataPropertyName = "INVOICEENDNO";
            this.INVOICEENDNO.HeaderText = "终止号码";
            this.INVOICEENDNO.Name = "INVOICEENDNO";
            this.INVOICEENDNO.ReadOnly = true;
            this.INVOICEENDNO.Width = 97;
            // 
            // INVOICEMEMO
            // 
            this.INVOICEMEMO.DataPropertyName = "INVOICEMEMO";
            this.INVOICEMEMO.HeaderText = "备注";
            this.INVOICEMEMO.Name = "INVOICEMEMO";
            this.INVOICEMEMO.ReadOnly = true;
            this.INVOICEMEMO.Width = 65;
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.txtStartNO);
            this.gbDetail.Controls.Add(this.btBatch);
            this.gbDetail.Controls.Add(this.cmbBatch);
            this.gbDetail.Controls.Add(this.label5);
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
            this.gbDetail.Size = new System.Drawing.Size(888, 93);
            this.gbDetail.TabIndex = 0;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "发票详细信息";
            // 
            // txtStartNO
            // 
            this.txtStartNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtStartNO.Location = new System.Drawing.Point(105, 23);
            this.txtStartNO.Name = "txtStartNO";
            this.txtStartNO.Size = new System.Drawing.Size(122, 26);
            this.txtStartNO.TabIndex = 1;
            this.txtStartNO.TextChanged += new System.EventHandler(this.txtStartNO_TextChanged);
            this.txtStartNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartNO_KeyPress);
            this.txtStartNO.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartNO_Validating);
            // 
            // btBatch
            // 
            this.btBatch.Location = new System.Drawing.Point(681, 19);
            this.btBatch.Name = "btBatch";
            this.btBatch.Size = new System.Drawing.Size(67, 30);
            this.btBatch.TabIndex = 8;
            this.btBatch.Text = "管理";
            this.btBatch.UseVisualStyleBackColor = true;
            this.btBatch.Click += new System.EventHandler(this.btBatch_Click);
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(520, 23);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(155, 24);
            this.cmbBatch.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "发票批次:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "起始号码:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Window;
            this.txtID.Location = new System.Drawing.Point(681, 60);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(122, 26);
            this.txtID.TabIndex = 4;
            this.txtID.Visible = false;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(105, 55);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(570, 26);
            this.txtMemo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "备    注:";
            // 
            // txtEndNO
            // 
            this.txtEndNO.Location = new System.Drawing.Point(326, 23);
            this.txtEndNO.Name = "txtEndNO";
            this.txtEndNO.Size = new System.Drawing.Size(100, 26);
            this.txtEndNO.TabIndex = 2;
            this.txtEndNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartNO_KeyPress);
            this.txtEndNO.Validating += new System.ComponentModel.CancelEventHandler(this.txtStartNO_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "终止号码:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbBatchSearch);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(890, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // cmbBatchSearch
            // 
            this.cmbBatchSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatchSearch.FormattingEnabled = true;
            this.cmbBatchSearch.Location = new System.Drawing.Point(116, 21);
            this.cmbBatchSearch.Name = "cmbBatchSearch";
            this.cmbBatchSearch.Size = new System.Drawing.Size(185, 24);
            this.cmbBatchSearch.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "发票批次:";
            // 
            // frmInvoiceStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 453);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInvoiceStocks";
            this.Text = "发票库存录入";
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
        private System.Windows.Forms.ComboBox cmbBatchSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btBatch;
        private System.Windows.Forms.TextBox txtStartNO;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICESTOCKSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEBATCHID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEBATCHNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICESTARTNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEENDNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICEMEMO;
    }
}
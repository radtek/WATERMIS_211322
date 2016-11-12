namespace FinanceOS
{
    partial class FrmFinance_Settle_Month
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
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Settle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_LogID = new System.Windows.Forms.ComboBox();
            this.CB_Month = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DG = new System.Windows.Forms.DataGridView();
            this.DEPARTMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEEITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLORCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTHCHECKSTATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTHCHECKWORKERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTHCHECKDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(885, 612);
            this.tb1.TabIndex = 67;
            this.tb1.Tag = "9999";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(879, 70);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Settle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CB_LogID);
            this.panel1.Controls.Add(this.CB_Month);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Btn_Search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 50);
            this.panel1.TabIndex = 0;
            // 
            // Btn_Settle
            // 
            this.Btn_Settle.Location = new System.Drawing.Point(440, 13);
            this.Btn_Settle.Name = "Btn_Settle";
            this.Btn_Settle.Size = new System.Drawing.Size(75, 23);
            this.Btn_Settle.TabIndex = 12;
            this.Btn_Settle.Text = "月  结";
            this.Btn_Settle.UseVisualStyleBackColor = true;
            this.Btn_Settle.Click += new System.EventHandler(this.Btn_Settle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "收费员：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "月";
            // 
            // CB_LogID
            // 
            this.CB_LogID.FormattingEnabled = true;
            this.CB_LogID.Location = new System.Drawing.Point(247, 13);
            this.CB_LogID.Name = "CB_LogID";
            this.CB_LogID.Size = new System.Drawing.Size(79, 20);
            this.CB_LogID.TabIndex = 9;
            // 
            // CB_Month
            // 
            this.CB_Month.FormattingEnabled = true;
            this.CB_Month.Location = new System.Drawing.Point(88, 13);
            this.CB_Month.Name = "CB_Month";
            this.CB_Month.Size = new System.Drawing.Size(69, 20);
            this.CB_Month.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "收费时间：";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(345, 13);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 23);
            this.Btn_Search.TabIndex = 0;
            this.Btn_Search.Text = "查  询";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DG);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(879, 526);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "待结账列表";
            // 
            // DG
            // 
            this.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DEPARTMENT,
            this.FEEITEM,
            this.FEE,
            this.COLORCODE,
            this.MONTHCHECKSTATE,
            this.MONTHCHECKWORKERNAME,
            this.MONTHCHECKDATETIME,
            this.SORT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG.DefaultCellStyle = dataGridViewCellStyle2;
            this.DG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG.Location = new System.Drawing.Point(3, 17);
            this.DG.Name = "DG";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DG.RowTemplate.Height = 23;
            this.DG.Size = new System.Drawing.Size(873, 506);
            this.DG.TabIndex = 0;
            // 
            // DEPARTMENT
            // 
            this.DEPARTMENT.DataPropertyName = "DEPARTMENT";
            this.DEPARTMENT.HeaderText = "部门";
            this.DEPARTMENT.Name = "DEPARTMENT";
            this.DEPARTMENT.Width = 54;
            // 
            // FEEITEM
            // 
            this.FEEITEM.DataPropertyName = "FEEITEM";
            this.FEEITEM.HeaderText = "收费项目";
            this.FEEITEM.Name = "FEEITEM";
            this.FEEITEM.Width = 78;
            // 
            // FEE
            // 
            this.FEE.DataPropertyName = "FEE";
            this.FEE.HeaderText = "费用合计";
            this.FEE.Name = "FEE";
            this.FEE.Width = 78;
            // 
            // COLORCODE
            // 
            this.COLORCODE.DataPropertyName = "COLORCODE";
            this.COLORCODE.HeaderText = "COLORCODE";
            this.COLORCODE.Name = "COLORCODE";
            this.COLORCODE.Visible = false;
            this.COLORCODE.Width = 84;
            // 
            // MONTHCHECKSTATE
            // 
            this.MONTHCHECKSTATE.DataPropertyName = "MONTHCHECKSTATE";
            this.MONTHCHECKSTATE.HeaderText = "审核状态";
            this.MONTHCHECKSTATE.Name = "MONTHCHECKSTATE";
            this.MONTHCHECKSTATE.Width = 78;
            // 
            // MONTHCHECKWORKERNAME
            // 
            this.MONTHCHECKWORKERNAME.DataPropertyName = "MONTHCHECKWORKERNAME";
            this.MONTHCHECKWORKERNAME.HeaderText = "审核人";
            this.MONTHCHECKWORKERNAME.Name = "MONTHCHECKWORKERNAME";
            this.MONTHCHECKWORKERNAME.Width = 66;
            // 
            // MONTHCHECKDATETIME
            // 
            this.MONTHCHECKDATETIME.DataPropertyName = "MONTHCHECKDATETIME";
            this.MONTHCHECKDATETIME.HeaderText = "审核时间";
            this.MONTHCHECKDATETIME.Name = "MONTHCHECKDATETIME";
            this.MONTHCHECKDATETIME.Width = 78;
            // 
            // SORT
            // 
            this.SORT.DataPropertyName = "SORT";
            this.SORT.HeaderText = "SORT";
            this.SORT.Name = "SORT";
            this.SORT.Visible = false;
            this.SORT.Width = 54;
            // 
            // FrmFinance_Settle_Month
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 612);
            this.Controls.Add(this.tb1);
            this.Name = "FrmFinance_Settle_Month";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收费月结";
            this.Load += new System.EventHandler(this.FrmFinance_Settle_Month_Load);
            this.tb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Settle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Month;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CB_LogID;
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEEITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLORCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTHCHECKSTATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTHCHECKWORKERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTHCHECKDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT;
    }
}
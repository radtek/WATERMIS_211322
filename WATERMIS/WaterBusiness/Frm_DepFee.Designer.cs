namespace WaterBusiness
{
    partial class Frm_DepFee
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
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.CB_Month = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DEPARTMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COLORCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEEITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTHCHECKSTATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(1007, 641);
            this.tb1.TabIndex = 66;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 86);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.CB_Month);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 66);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "9999";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(225, 21);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.Btn_Submit.TabIndex = 4;
            this.Btn_Submit.Text = "查询";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // CB_Month
            // 
            this.CB_Month.FormattingEnabled = true;
            this.CB_Month.Location = new System.Drawing.Point(88, 23);
            this.CB_Month.Name = "CB_Month";
            this.CB_Month.Size = new System.Drawing.Size(121, 20);
            this.CB_Month.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择年月";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1001, 539);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DEPARTMENT,
            this.COLORCODE,
            this.SORT,
            this.FEEITEM,
            this.MONTHCHECKSTATE,
            this.FEE});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(995, 519);
            this.dataGridView1.TabIndex = 0;
            // 
            // DEPARTMENT
            // 
            this.DEPARTMENT.DataPropertyName = "DEPARTMENT";
            this.DEPARTMENT.HeaderText = "部门";
            this.DEPARTMENT.Name = "DEPARTMENT";
            // 
            // COLORCODE
            // 
            this.COLORCODE.DataPropertyName = "COLORCODE";
            this.COLORCODE.HeaderText = "Column1";
            this.COLORCODE.Name = "COLORCODE";
            this.COLORCODE.Visible = false;
            // 
            // SORT
            // 
            this.SORT.DataPropertyName = "SORT";
            this.SORT.HeaderText = "Column1";
            this.SORT.Name = "SORT";
            this.SORT.Visible = false;
            // 
            // FEEITEM
            // 
            this.FEEITEM.DataPropertyName = "FEEITEM";
            this.FEEITEM.HeaderText = "收费项目";
            this.FEEITEM.Name = "FEEITEM";
            // 
            // MONTHCHECKSTATE
            // 
            this.MONTHCHECKSTATE.DataPropertyName = "MONTHCHECKSTATE";
            this.MONTHCHECKSTATE.HeaderText = "Column1";
            this.MONTHCHECKSTATE.Name = "MONTHCHECKSTATE";
            this.MONTHCHECKSTATE.Visible = false;
            // 
            // FEE
            // 
            this.FEE.DataPropertyName = "FEE";
            this.FEE.HeaderText = "收费金额";
            this.FEE.Name = "FEE";
            // 
            // Frm_DepFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 641);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Frm_DepFee";
            this.Text = "部门费用";
            this.Load += new System.EventHandler(this.Frm_DepFee_Load);
            this.tb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.ComboBox CB_Month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPARTMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLORCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEEITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTHCHECKSTATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEE;
    }
}
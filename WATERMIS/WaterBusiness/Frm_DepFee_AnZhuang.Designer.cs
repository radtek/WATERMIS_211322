namespace WaterBusiness
{
    partial class Frm_DepFee_AnZhuang
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.COLORCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.业扩类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.收费项目 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTHCHECKSTATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.户数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发票金额 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uC_DateSelect1 = new SysControl.UC_DateSelect();
            this.Btn_Export = new System.Windows.Forms.Button();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
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
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(1018, 725);
            this.tb1.TabIndex = 67;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1010, 82);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.uC_DateSelect1);
            this.panel1.Controls.Add(this.Btn_Export);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 55);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "9999";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 99);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1010, 622);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COLORCODE,
            this.业扩类型,
            this.SORT,
            this.收费项目,
            this.MONTHCHECKSTATE,
            this.户数,
            this.发票金额});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(4, 23);
            this.dgList.Margin = new System.Windows.Forms.Padding(4);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(1002, 595);
            this.dgList.TabIndex = 0;
            // 
            // COLORCODE
            // 
            this.COLORCODE.DataPropertyName = "COLORCODE";
            this.COLORCODE.HeaderText = "Column1";
            this.COLORCODE.Name = "COLORCODE";
            this.COLORCODE.ReadOnly = true;
            this.COLORCODE.Visible = false;
            // 
            // 业扩类型
            // 
            this.业扩类型.DataPropertyName = "业扩类型";
            this.业扩类型.HeaderText = "业扩类型";
            this.业扩类型.Name = "业扩类型";
            this.业扩类型.ReadOnly = true;
            // 
            // SORT
            // 
            this.SORT.DataPropertyName = "SORT";
            this.SORT.HeaderText = "Column1";
            this.SORT.Name = "SORT";
            this.SORT.ReadOnly = true;
            this.SORT.Visible = false;
            // 
            // 收费项目
            // 
            this.收费项目.DataPropertyName = "收费项目";
            this.收费项目.HeaderText = "收费项目";
            this.收费项目.Name = "收费项目";
            this.收费项目.ReadOnly = true;
            // 
            // MONTHCHECKSTATE
            // 
            this.MONTHCHECKSTATE.DataPropertyName = "MONTHCHECKSTATE";
            this.MONTHCHECKSTATE.HeaderText = "Column1";
            this.MONTHCHECKSTATE.Name = "MONTHCHECKSTATE";
            this.MONTHCHECKSTATE.ReadOnly = true;
            this.MONTHCHECKSTATE.Visible = false;
            // 
            // 户数
            // 
            this.户数.DataPropertyName = "户数";
            this.户数.HeaderText = "户数";
            this.户数.Name = "户数";
            this.户数.ReadOnly = true;
            // 
            // 发票金额
            // 
            this.发票金额.DataPropertyName = "发票金额";
            this.发票金额.HeaderText = "发票金额";
            this.发票金额.Name = "发票金额";
            this.发票金额.ReadOnly = true;
            // 
            // uC_DateSelect1
            // 
            this.uC_DateSelect1.DayEnd = new System.DateTime(2017, 5, 31, 18, 45, 23, 712);
            this.uC_DateSelect1.DayStart = new System.DateTime(2017, 5, 31, 18, 45, 23, 712);
            this.uC_DateSelect1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_DateSelect1.Location = new System.Drawing.Point(5, 7);
            this.uC_DateSelect1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_DateSelect1.Name = "uC_DateSelect1";
            this.uC_DateSelect1.Size = new System.Drawing.Size(464, 41);
            this.uC_DateSelect1.TabIndex = 10;
            // 
            // Btn_Export
            // 
            this.Btn_Export.Location = new System.Drawing.Point(586, 12);
            this.Btn_Export.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Export.Name = "Btn_Export";
            this.Btn_Export.Size = new System.Drawing.Size(100, 31);
            this.Btn_Export.TabIndex = 9;
            this.Btn_Export.Text = "导出";
            this.Btn_Export.UseVisualStyleBackColor = true;
            this.Btn_Export.Click += new System.EventHandler(this.Btn_Export_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(478, 12);
            this.Btn_Submit.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(100, 31);
            this.Btn_Submit.TabIndex = 8;
            this.Btn_Submit.Text = "查询";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // Frm_DepFee_AnZhuang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 725);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_DepFee_AnZhuang";
            this.Text = "安装处费用";
            this.Load += new System.EventHandler(this.Frm_DepFee_AnZhuang_Load);
            this.tb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn COLORCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn 业扩类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT;
        private System.Windows.Forms.DataGridViewTextBoxColumn 收费项目;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTHCHECKSTATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn 户数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发票金额;
        private SysControl.UC_DateSelect uC_DateSelect1;
        private System.Windows.Forms.Button Btn_Export;
        private System.Windows.Forms.Button Btn_Submit;
    }
}
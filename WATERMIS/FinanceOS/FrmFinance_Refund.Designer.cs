namespace FinanceOS
{
    partial class FrmFinance_Refund
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
            this.RB_Type2 = new System.Windows.Forms.RadioButton();
            this.RB_Type1 = new System.Windows.Forms.RadioButton();
            this.CB_ID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Keys = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.uC_FlowList1 = new SysControl.UC_FlowList();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Controls.Add(this.uC_FlowList1, 0, 2);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tb1.Size = new System.Drawing.Size(946, 595);
            this.tb1.TabIndex = 68;
            this.tb1.Tag = "9999";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 70);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RB_Type2);
            this.panel1.Controls.Add(this.RB_Type1);
            this.panel1.Controls.Add(this.CB_ID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TB_Keys);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_Search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 50);
            this.panel1.TabIndex = 0;
            // 
            // RB_Type2
            // 
            this.RB_Type2.AutoSize = true;
            this.RB_Type2.Location = new System.Drawing.Point(96, 16);
            this.RB_Type2.Name = "RB_Type2";
            this.RB_Type2.Size = new System.Drawing.Size(71, 16);
            this.RB_Type2.TabIndex = 17;
            this.RB_Type2.Text = "作废退款";
            this.RB_Type2.UseVisualStyleBackColor = true;
            this.RB_Type2.CheckedChanged += new System.EventHandler(this.RB_Type2_CheckedChanged);
            // 
            // RB_Type1
            // 
            this.RB_Type1.AutoSize = true;
            this.RB_Type1.Checked = true;
            this.RB_Type1.Location = new System.Drawing.Point(18, 16);
            this.RB_Type1.Name = "RB_Type1";
            this.RB_Type1.Size = new System.Drawing.Size(71, 16);
            this.RB_Type1.TabIndex = 16;
            this.RB_Type1.TabStop = true;
            this.RB_Type1.Text = "收费退款";
            this.RB_Type1.UseVisualStyleBackColor = true;
            this.RB_Type1.CheckedChanged += new System.EventHandler(this.RB_Type1_CheckedChanged);
            // 
            // CB_ID
            // 
            this.CB_ID.FormattingEnabled = true;
            this.CB_ID.Location = new System.Drawing.Point(247, 13);
            this.CB_ID.Name = "CB_ID";
            this.CB_ID.Size = new System.Drawing.Size(104, 20);
            this.CB_ID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "关键词：";
            // 
            // TB_Keys
            // 
            this.TB_Keys.Location = new System.Drawing.Point(414, 12);
            this.TB_Keys.Name = "TB_Keys";
            this.TB_Keys.Size = new System.Drawing.Size(145, 21);
            this.TB_Keys.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "业务类型：";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(565, 12);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 21);
            this.Btn_Search.TabIndex = 0;
            this.Btn_Search.Text = "搜 索";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uC_DataGridView_Page1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(940, 418);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "待收费列表";
            // 
            // uC_DataGridView_Page1
            // 
            this.uC_DataGridView_Page1.AutoSize = true;
            this.uC_DataGridView_Page1.BackColor = System.Drawing.Color.White;
            this.uC_DataGridView_Page1.DataStatis = null;
            this.uC_DataGridView_Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DataGridView_Page1.Fields = null;
            this.uC_DataGridView_Page1.FieldStatis = null;
            this.uC_DataGridView_Page1.FiledColor = null;
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(3, 17);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(833, 80);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(934, 398);
            this.uC_DataGridView_Page1.TabIndex = 0;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellDoubleClickEvents += new SysControl.UC_DataGridView_Page.CellDoubleClickEvent(this.uC_DataGridView_Page1_CellDoubleClickEvents);
            this.uC_DataGridView_Page1.CellClickEvents += new SysControl.UC_DataGridView_Page.CellClickEvent(this.uC_DataGridView_Page1_CellClickEvents);
            // 
            // uC_FlowList1
            // 
            this.uC_FlowList1.AutoScroll = true;
            this.uC_FlowList1.AutoSize = true;
            this.uC_FlowList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FlowList1.Location = new System.Drawing.Point(3, 507);
            this.uC_FlowList1.MinimumSize = new System.Drawing.Size(900, 85);
            this.uC_FlowList1.Name = "uC_FlowList1";
            this.uC_FlowList1.Size = new System.Drawing.Size(940, 85);
            this.uC_FlowList1.TabIndex = 903;
            this.uC_FlowList1.Tag = "9999";
            this.uC_FlowList1.TaskId = null;
            // 
            // FrmFinance_Refund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 595);
            this.Controls.Add(this.tb1);
            this.Name = "FrmFinance_Refund";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户退款";
            this.Load += new System.EventHandler(this.FrmFinance_Refund_Load);
            this.tb1.ResumeLayout(false);
            this.tb1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RB_Type2;
        private System.Windows.Forms.RadioButton RB_Type1;
        private System.Windows.Forms.ComboBox CB_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Keys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.GroupBox groupBox2;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
        private SysControl.UC_FlowList uC_FlowList1;
    }
}
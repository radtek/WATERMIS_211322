namespace FinanceOS
{
    partial class FrmFinance_Receipted
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
            this.label9 = new System.Windows.Forms.Label();
            this.cmbChargeType = new System.Windows.Forms.ComboBox();
            this.CB_Month = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_DepartementID = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CHARGEWORKERID = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Day = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tb1.Size = new System.Drawing.Size(1124, 750);
            this.tb1.TabIndex = 66;
            this.tb1.Tag = "9999";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1118, 90);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TB_Keys);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbChargeType);
            this.panel1.Controls.Add(this.CB_Month);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.CB_DepartementID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CHARGEWORKERID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CB_Day);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CB_ID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_Search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 70);
            this.panel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(662, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(341, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "关键词可输入用户号、用户名、联系方式、申请人、业务流水号";
            // 
            // cmbChargeType
            // 
            this.cmbChargeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChargeType.FormattingEnabled = true;
            this.cmbChargeType.Items.AddRange(new object[] {
            "全部",
            "决算收费",
            "预算收费"});
            this.cmbChargeType.Location = new System.Drawing.Point(254, 41);
            this.cmbChargeType.Name = "cmbChargeType";
            this.cmbChargeType.Size = new System.Drawing.Size(71, 20);
            this.cmbChargeType.TabIndex = 17;
            // 
            // CB_Month
            // 
            this.CB_Month.FormattingEnabled = true;
            this.CB_Month.Location = new System.Drawing.Point(256, 10);
            this.CB_Month.Name = "CB_Month";
            this.CB_Month.Size = new System.Drawing.Size(69, 20);
            this.CB_Month.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "结算类型：";
            // 
            // CB_DepartementID
            // 
            this.CB_DepartementID.FormattingEnabled = true;
            this.CB_DepartementID.Location = new System.Drawing.Point(75, 42);
            this.CB_DepartementID.Name = "CB_DepartementID";
            this.CB_DepartementID.Size = new System.Drawing.Size(104, 20);
            this.CB_DepartementID.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "部    门：";
            // 
            // CHARGEWORKERID
            // 
            this.CHARGEWORKERID.FormattingEnabled = true;
            this.CHARGEWORKERID.Location = new System.Drawing.Point(480, 9);
            this.CHARGEWORKERID.Name = "CHARGEWORKERID";
            this.CHARGEWORKERID.Size = new System.Drawing.Size(69, 20);
            this.CHARGEWORKERID.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "收费员：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "月";
            // 
            // CB_Day
            // 
            this.CB_Day.FormattingEnabled = true;
            this.CB_Day.Location = new System.Drawing.Point(350, 10);
            this.CB_Day.Name = "CB_Day";
            this.CB_Day.Size = new System.Drawing.Size(48, 20);
            this.CB_Day.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "申请时间：";
            // 
            // CB_ID
            // 
            this.CB_ID.FormattingEnabled = true;
            this.CB_ID.Location = new System.Drawing.Point(75, 10);
            this.CB_ID.Name = "CB_ID";
            this.CB_ID.Size = new System.Drawing.Size(104, 20);
            this.CB_ID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "关键词：";
            // 
            // TB_Keys
            // 
            this.TB_Keys.Location = new System.Drawing.Point(404, 41);
            this.TB_Keys.Name = "TB_Keys";
            this.TB_Keys.Size = new System.Drawing.Size(145, 21);
            this.TB_Keys.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "业务类型：";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(570, 7);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 55);
            this.Btn_Search.TabIndex = 0;
            this.Btn_Search.Text = "搜 索";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uC_DataGridView_Page1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1118, 553);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已费列表";
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
            this.uC_DataGridView_Page1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(3, 17);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(833, 80);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(1112, 533);
            this.uC_DataGridView_Page1.TabIndex = 906;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellDoubleClickEvents += new SysControl.UC_DataGridView_Page.CellDoubleClickEvent(this.uC_DataGridView_Page1_CellDoubleClickEvents);
            this.uC_DataGridView_Page1.CellClickEvents += new SysControl.UC_DataGridView_Page.CellClickEvent(this.uC_DataGridView_Page1_CellClickEvents);
            // 
            // uC_FlowList1
            // 
            this.uC_FlowList1.AutoScroll = true;
            this.uC_FlowList1.AutoSize = true;
            this.uC_FlowList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FlowList1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_FlowList1.Location = new System.Drawing.Point(3, 662);
            this.uC_FlowList1.MinimumSize = new System.Drawing.Size(900, 85);
            this.uC_FlowList1.Name = "uC_FlowList1";
            this.uC_FlowList1.Size = new System.Drawing.Size(1118, 85);
            this.uC_FlowList1.TabIndex = 903;
            this.uC_FlowList1.Tag = "9999";
            this.uC_FlowList1.TaskId = null;
            // 
            // FrmFinance_Receipted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 750);
            this.Controls.Add(this.tb1);
            this.Name = "FrmFinance_Receipted";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收费记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FrmFinance_Receipted_Shown);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Day;
        private System.Windows.Forms.ComboBox CB_Month;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CB_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Keys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.GroupBox groupBox2;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
        private SysControl.UC_FlowList uC_FlowList1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CHARGEWORKERID;
        private System.Windows.Forms.ComboBox CB_DepartementID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbChargeType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
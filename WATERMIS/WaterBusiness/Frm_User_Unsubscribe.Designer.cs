namespace WaterBusiness
{
    partial class Frm_User_Unsubscribe
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
            this.uC_SearchBase1 = new SysControl.UC_SearchBase();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.uC_FlowList1 = new SysControl.UC_FlowList();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.White;
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Controls.Add(this.uC_FlowList1, 0, 2);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tb1.Size = new System.Drawing.Size(1419, 836);
            this.tb1.TabIndex = 63;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uC_SearchBase1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1411, 107);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // uC_SearchBase1
            // 
            this.uC_SearchBase1.BackColor = System.Drawing.Color.Transparent;
            this.uC_SearchBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_SearchBase1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_SearchBase1.Location = new System.Drawing.Point(4, 23);
            this.uC_SearchBase1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_SearchBase1.Name = "uC_SearchBase1";
            this.uC_SearchBase1.Size = new System.Drawing.Size(1403, 80);
            this.uC_SearchBase1.TabIndex = 0;
            this.uC_SearchBase1.Tag = "9999";
            this.uC_SearchBase1.Load += new System.EventHandler(this.uC_SearchBase1_Load);
            this.uC_SearchBase1.BtnEvent += new System.EventHandler(this.uC_SearchBase1_BtnEvent);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uC_DataGridView_Page1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 124);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1411, 595);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户列表";
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
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(4, 23);
            this.uC_DataGridView_Page1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(1111, 107);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(1403, 568);
            this.uC_DataGridView_Page1.TabIndex = 0;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellClickEvents += new SysControl.UC_DataGridView_Page.CellClickEvent(this.uC_DataGridView_Page1_CellClickEvents);
            // 
            // uC_FlowList1
            // 
            this.uC_FlowList1.AutoScroll = true;
            this.uC_FlowList1.AutoSize = true;
            this.uC_FlowList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FlowList1.Location = new System.Drawing.Point(4, 727);
            this.uC_FlowList1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_FlowList1.MinimumSize = new System.Drawing.Size(1200, 113);
            this.uC_FlowList1.Name = "uC_FlowList1";
            this.uC_FlowList1.Size = new System.Drawing.Size(1411, 113);
            this.uC_FlowList1.TabIndex = 903;
            this.uC_FlowList1.Tag = "9999";
            this.uC_FlowList1.TaskId = null;
            // 
            // Frm_User_Unsubscribe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 836);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_User_Unsubscribe";
            this.Text = "用户销户记录";
            this.tb1.ResumeLayout(false);
            this.tb1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private SysControl.UC_SearchBase uC_SearchBase1;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
        private SysControl.UC_FlowList uC_FlowList1;



    }
}
namespace ApproveCenter
{
    partial class FrmUser_AddWater
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uC_SearchBase1 = new SysControl.UC_SearchBase();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.uC_FlowList1 = new SysControl.UC_FlowList();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uC_SearchBase1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_DataGridView_Page1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uC_FlowList1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1205, 688);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // uC_SearchBase1
            // 
            this.uC_SearchBase1.BackColor = System.Drawing.Color.Transparent;
            this.uC_SearchBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_SearchBase1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_SearchBase1.Location = new System.Drawing.Point(4, 4);
            this.uC_SearchBase1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_SearchBase1.Name = "uC_SearchBase1";
            this.uC_SearchBase1.Size = new System.Drawing.Size(1197, 85);
            this.uC_SearchBase1.TabIndex = 3;
            this.uC_SearchBase1.Tag = "9999";
            this.uC_SearchBase1.Load += new System.EventHandler(this.uC_SearchBase1_Load);
            this.uC_SearchBase1.BtnEvent += new System.EventHandler(this.uC_SearchBase1_BtnEvent);
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
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(4, 97);
            this.uC_DataGridView_Page1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(1111, 107);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(1197, 494);
            this.uC_DataGridView_Page1.TabIndex = 4;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellClickEvents += new SysControl.UC_DataGridView_Page.CellClickEvent(this.uC_DataGridView_Page1_CellClickEvents);
            // 
            // uC_FlowList1
            // 
            this.uC_FlowList1.AutoScroll = true;
            this.uC_FlowList1.AutoSize = true;
            this.uC_FlowList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FlowList1.Location = new System.Drawing.Point(4, 599);
            this.uC_FlowList1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_FlowList1.MinimumSize = new System.Drawing.Size(1200, 113);
            this.uC_FlowList1.Name = "uC_FlowList1";
            this.uC_FlowList1.Size = new System.Drawing.Size(1200, 113);
            this.uC_FlowList1.TabIndex = 5;
            this.uC_FlowList1.Tag = "9999";
            this.uC_FlowList1.TaskId = null;
            // 
            // FrmUser_AddWater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 688);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUser_AddWater";
            this.Text = "补交水量";
            this.Load += new System.EventHandler(this.FrmUser_AddWater_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SysControl.UC_SearchBase uC_SearchBase1;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
        private SysControl.UC_FlowList uC_FlowList1;
    }
}
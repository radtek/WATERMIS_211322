namespace ApproveCenter
{
    partial class FrmUser_ChargeAbate
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
            this.uC_FlowList1 = new SysControl.UC_FlowList();
            this.uC_SearchModule1 = new SysControl.UC_SearchModule();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uC_FlowList1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uC_SearchModule1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_DataGridView_Page1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(885, 259);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // uC_FlowList1
            // 
            this.uC_FlowList1.AutoScroll = true;
            this.uC_FlowList1.AutoSize = true;
            this.uC_FlowList1.BackColor = System.Drawing.Color.White;
            this.uC_FlowList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FlowList1.Location = new System.Drawing.Point(3, 192);
            this.uC_FlowList1.MinimumSize = new System.Drawing.Size(900, 60);
            this.uC_FlowList1.Name = "uC_FlowList1";
            this.uC_FlowList1.Size = new System.Drawing.Size(900, 64);
            this.uC_FlowList1.TabIndex = 2;
            this.uC_FlowList1.Tag = "9999";
            this.uC_FlowList1.TaskId = null;
            // 
            // uC_SearchModule1
            // 
            this.uC_SearchModule1.AutoSize = true;
            this.uC_SearchModule1.BackColor = System.Drawing.Color.White;
            this.uC_SearchModule1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_SearchModule1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_SearchModule1.Location = new System.Drawing.Point(0, 0);
            this.uC_SearchModule1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_SearchModule1.MinimumSize = new System.Drawing.Size(890, 70);
            this.uC_SearchModule1.Name = "uC_SearchModule1";
            this.uC_SearchModule1.Size = new System.Drawing.Size(890, 70);
            this.uC_SearchModule1.TabIndex = 1;
            this.uC_SearchModule1.Tag = "9999";
            this.uC_SearchModule1.Load += new System.EventHandler(this.uC_SearchModule1_Load);
            this.uC_SearchModule1.BtnEvent += new System.EventHandler(this.uC_SearchModule1_BtnEvent);
            // 
            // uC_DataGridView_Page1
            // 
            this.uC_DataGridView_Page1.AutoScroll = true;
            this.uC_DataGridView_Page1.AutoSize = true;
            this.uC_DataGridView_Page1.BackColor = System.Drawing.Color.White;
            this.uC_DataGridView_Page1.DataStatis = null;
            this.uC_DataGridView_Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DataGridView_Page1.Fields = null;
            this.uC_DataGridView_Page1.FieldStatis = null;
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(3, 73);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(833, 100);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(879, 113);
            this.uC_DataGridView_Page1.TabIndex = 0;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellDoubleClickEvents += new SysControl.UC_DataGridView_Page.CellDoubleClickEvent(this.uC_DataGridView_Page1_CellDoubleClickEvents);
            // 
            // FrmUser_ChargeAbate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 259);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmUser_ChargeAbate";
            this.Text = "费用减免申请记录";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SysControl.UC_SearchModule uC_SearchModule1;
        private SysControl.UC_FlowList uC_FlowList1;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
    }
}
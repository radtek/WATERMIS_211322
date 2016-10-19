namespace PersonalWork
{
    partial class FrmPerson_Approve_Scrap
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.uC_SearchApprove1 = new SysControl.UC_SearchApprove();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_FlowList1 = new SysControl.UC_FlowList();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uC_SearchApprove1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 70);
            this.panel1.TabIndex = 2;
            // 
            // uC_SearchApprove1
            // 
            this.uC_SearchApprove1.BackColor = System.Drawing.Color.White;
            this.uC_SearchApprove1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_SearchApprove1.Location = new System.Drawing.Point(0, 0);
            this.uC_SearchApprove1.Name = "uC_SearchApprove1";
            this.uC_SearchApprove1.Size = new System.Drawing.Size(976, 70);
            this.uC_SearchApprove1.State = 4;
            this.uC_SearchApprove1.TabIndex = 0;
            this.uC_SearchApprove1.Tag = "9999";
            this.uC_SearchApprove1.WrokType = 6;
            this.uC_SearchApprove1.BtnEvent += new System.EventHandler(this.uC_SearchApprove1_BtnEvent);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uC_FlowList1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 656);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(976, 85);
            this.panel2.TabIndex = 3;
            // 
            // uC_FlowList1
            // 
            this.uC_FlowList1.AutoScroll = true;
            this.uC_FlowList1.AutoSize = true;
            this.uC_FlowList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FlowList1.Location = new System.Drawing.Point(0, 0);
            this.uC_FlowList1.MinimumSize = new System.Drawing.Size(900, 85);
            this.uC_FlowList1.Name = "uC_FlowList1";
            this.uC_FlowList1.Size = new System.Drawing.Size(976, 85);
            this.uC_FlowList1.TabIndex = 0;
            this.uC_FlowList1.Tag = "9999";
            this.uC_FlowList1.TaskId = null;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uC_DataGridView_Page1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 586);
            this.panel3.TabIndex = 4;
            // 
            // uC_DataGridView_Page1
            // 
            this.uC_DataGridView_Page1.AutoSize = true;
            this.uC_DataGridView_Page1.BackColor = System.Drawing.Color.White;
            this.uC_DataGridView_Page1.DataStatis = null;
            this.uC_DataGridView_Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DataGridView_Page1.Fields = null;
            this.uC_DataGridView_Page1.FieldStatis = null;
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(0, 0);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(976, 586);
            this.uC_DataGridView_Page1.TabIndex = 0;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellClickEvents += new SysControl.UC_DataGridView_Page.CellClickEvent(this.uC_DataGridView_Page1_CellClickEvents);
            // 
            // FrmPerson_Approve_Scrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 741);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPerson_Approve_Scrap";
            this.Text = "作废审批";
            this.Load += new System.EventHandler(this.FrmPerson_Approve_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SysControl.UC_SearchApprove uC_SearchApprove1;
        private System.Windows.Forms.Panel panel2;
        private SysControl.UC_FlowList uC_FlowList1;
        private System.Windows.Forms.Panel panel3;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
    }
}
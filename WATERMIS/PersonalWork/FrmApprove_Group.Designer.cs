namespace PersonalWork
{
    partial class FrmApprove_Group
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Group));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PL_Proc = new System.Windows.Forms.Panel();
            this.uC_Approve_GroupInfos1 = new SysControl.UC_Approve_GroupInfos();
            this.uC_ApproveList1 = new SysControl.UC_ApproveList();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_ApproveList1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1153, 684);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.PL_Proc, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uC_Approve_GroupInfos1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(637, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(513, 678);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // PL_Proc
            // 
            this.PL_Proc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PL_Proc.BackgroundImage")));
            this.PL_Proc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Proc.Location = new System.Drawing.Point(3, 203);
            this.PL_Proc.Name = "PL_Proc";
            this.PL_Proc.Size = new System.Drawing.Size(507, 472);
            this.PL_Proc.TabIndex = 2;
            // 
            // uC_Approve_GroupInfos1
            // 
            this.uC_Approve_GroupInfos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Approve_GroupInfos1.Location = new System.Drawing.Point(3, 3);
            this.uC_Approve_GroupInfos1.Name = "uC_Approve_GroupInfos1";
            this.uC_Approve_GroupInfos1.Size = new System.Drawing.Size(507, 194);
            this.uC_Approve_GroupInfos1.TabIndex = 3;
            // 
            // uC_ApproveList1
            // 
            this.uC_ApproveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ApproveList1.Location = new System.Drawing.Point(3, 3);
            this.uC_ApproveList1.Name = "uC_ApproveList1";
            this.uC_ApproveList1.Size = new System.Drawing.Size(628, 678);
            this.uC_ApproveList1.TabIndex = 1;
            // 
            // FrmApprove_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 684);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmApprove_Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的审批";
            this.Load += new System.EventHandler(this.FrmApprove_Group_Load);
            this.Shown += new System.EventHandler(this.FrmApprove_Group_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmApprove_Group_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel PL_Proc;
        private SysControl.UC_ApproveList uC_ApproveList1;
        private SysControl.UC_Approve_GroupInfos uC_Approve_GroupInfos1;
    }
}
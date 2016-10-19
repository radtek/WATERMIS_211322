namespace PersonalWork
{
    partial class FrmMaintain_Approve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaintain_Approve));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PL_Proc = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Memo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MaintainTypeID = new System.Windows.Forms.ComboBox();
            this.MaintainDescribe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uC_UserInfos1 = new SysControl.UC_UserInfos();
            this.uC_ApproveList1 = new SysControl.UC_ApproveList();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.91874F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.08126F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_ApproveList1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1219, 684);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.PL_Proc, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uC_UserInfos1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(672, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(544, 678);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // PL_Proc
            // 
            this.PL_Proc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PL_Proc.BackgroundImage")));
            this.PL_Proc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Proc.Location = new System.Drawing.Point(3, 303);
            this.PL_Proc.Name = "PL_Proc";
            this.PL_Proc.Size = new System.Drawing.Size(538, 372);
            this.PL_Proc.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.Memo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.MaintainTypeID);
            this.panel1.Controls.Add(this.MaintainDescribe);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 94);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Memo
            // 
            this.Memo.Enabled = false;
            this.Memo.Location = new System.Drawing.Point(83, 64);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(407, 21);
            this.Memo.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 82;
            this.label5.Text = "备    注：";
            // 
            // MaintainTypeID
            // 
            this.MaintainTypeID.Enabled = false;
            this.MaintainTypeID.FormattingEnabled = true;
            this.MaintainTypeID.Location = new System.Drawing.Point(83, 34);
            this.MaintainTypeID.Name = "MaintainTypeID";
            this.MaintainTypeID.Size = new System.Drawing.Size(192, 20);
            this.MaintainTypeID.TabIndex = 81;
            // 
            // MaintainDescribe
            // 
            this.MaintainDescribe.Enabled = false;
            this.MaintainDescribe.Location = new System.Drawing.Point(83, 3);
            this.MaintainDescribe.Name = "MaintainDescribe";
            this.MaintainDescribe.Size = new System.Drawing.Size(407, 21);
            this.MaintainDescribe.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "故障类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = " 故障说明：";
            // 
            // uC_UserInfos1
            // 
            this.uC_UserInfos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UserInfos1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserInfos1.Name = "uC_UserInfos1";
            this.uC_UserInfos1.Size = new System.Drawing.Size(538, 194);
            this.uC_UserInfos1.TabIndex = 4;
            // 
            // uC_ApproveList1
            // 
            this.uC_ApproveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ApproveList1.Location = new System.Drawing.Point(3, 3);
            this.uC_ApproveList1.Name = "uC_ApproveList1";
            this.uC_ApproveList1.Size = new System.Drawing.Size(663, 678);
            this.uC_ApproveList1.TabIndex = 1;
            // 
            // FrmMaintain_Approve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 684);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMaintain_Approve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "故障报修审批";
            this.Load += new System.EventHandler(this.FrmMaintain_Approve_Load);
            this.Shown += new System.EventHandler(this.FrmMaintain_Approve_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMaintain_Approve_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel PL_Proc;
        private SysControl.UC_ApproveList uC_ApproveList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox MaintainTypeID;
        private System.Windows.Forms.TextBox MaintainDescribe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private SysControl.UC_UserInfos uC_UserInfos1;
    }
}
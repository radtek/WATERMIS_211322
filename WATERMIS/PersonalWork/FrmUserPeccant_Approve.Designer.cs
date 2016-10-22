namespace PersonalWork
{
    partial class FrmUserPeccant_Approve
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PL_Proc = new System.Windows.Forms.Panel();
            this.uC_UserInfos1 = new SysControl.UC_UserInfos();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SubmitDate = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.ApplyUser = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.PecantDescribe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uC_ApproveList1 = new SysControl.UC_ApproveList();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 510F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_ApproveList1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1135, 661);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.PL_Proc, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.uC_UserInfos1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(628, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(504, 655);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // PL_Proc
            // 
            this.PL_Proc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Proc.Location = new System.Drawing.Point(3, 280);
            this.PL_Proc.Name = "PL_Proc";
            this.PL_Proc.Size = new System.Drawing.Size(498, 372);
            this.PL_Proc.TabIndex = 2;
            // 
            // uC_UserInfos1
            // 
            this.uC_UserInfos1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserInfos1.Name = "uC_UserInfos1";
            this.uC_UserInfos1.Size = new System.Drawing.Size(498, 194);
            this.uC_UserInfos1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.SubmitDate);
            this.panel1.Controls.Add(this.label80);
            this.panel1.Controls.Add(this.ApplyUser);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.PecantDescribe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 71);
            this.panel1.TabIndex = 4;
            this.panel1.Tag = "9999";
            // 
            // SubmitDate
            // 
            this.SubmitDate.Location = new System.Drawing.Point(320, 8);
            this.SubmitDate.Name = "SubmitDate";
            this.SubmitDate.ReadOnly = true;
            this.SubmitDate.Size = new System.Drawing.Size(161, 21);
            this.SubmitDate.TabIndex = 82;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(246, 14);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(65, 12);
            this.label80.TabIndex = 85;
            this.label80.Text = "发现时间：";
            // 
            // ApplyUser
            // 
            this.ApplyUser.Location = new System.Drawing.Point(76, 8);
            this.ApplyUser.Name = "ApplyUser";
            this.ApplyUser.ReadOnly = true;
            this.ApplyUser.Size = new System.Drawing.Size(149, 21);
            this.ApplyUser.TabIndex = 81;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 84;
            this.label13.Text = "发 现 人：";
            // 
            // PecantDescribe
            // 
            this.PecantDescribe.Location = new System.Drawing.Point(76, 38);
            this.PecantDescribe.Name = "PecantDescribe";
            this.PecantDescribe.ReadOnly = true;
            this.PecantDescribe.Size = new System.Drawing.Size(405, 21);
            this.PecantDescribe.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 80;
            this.label1.Text = "违章说明：";
            // 
            // uC_ApproveList1
            // 
            this.uC_ApproveList1.Location = new System.Drawing.Point(3, 3);
            this.uC_ApproveList1.Name = "uC_ApproveList1";
            this.uC_ApproveList1.Size = new System.Drawing.Size(612, 655);
            this.uC_ApproveList1.TabIndex = 1;
            // 
            // FrmUserPeccant_Approve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmUserPeccant_Approve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "违章处罚审批";
            this.Load += new System.EventHandler(this.FrmUserPeccant_Approve_Load);
            this.Shown += new System.EventHandler(this.FrmUserPeccant_Approve_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUserPeccant_Approve_FormClosed);
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
        private SysControl.UC_UserInfos uC_UserInfos1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox SubmitDate;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.TextBox ApplyUser;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox PecantDescribe;
        private System.Windows.Forms.Label label1;
        private SysControl.UC_ApproveList uC_ApproveList1;
    }
}
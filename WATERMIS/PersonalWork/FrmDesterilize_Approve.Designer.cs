namespace PersonalWork
{
    partial class FrmDesterilize_Approve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDesterilize_Approve));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PL_Proc = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Fee_State = new System.Windows.Forms.TextBox();
            this.SubmitDate = new System.Windows.Forms.TextBox();
            this.ApplyUser = new System.Windows.Forms.TextBox();
            this.DisuseNO = new System.Windows.Forms.TextBox();
            this.DisuseDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DesterilizeDescribe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.12245F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.87755F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_ApproveList1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1176, 684);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.PL_Proc, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uC_UserInfos1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(663, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(510, 678);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // PL_Proc
            // 
            this.PL_Proc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PL_Proc.BackgroundImage")));
            this.PL_Proc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL_Proc.Location = new System.Drawing.Point(3, 303);
            this.PL_Proc.Name = "PL_Proc";
            this.PL_Proc.Size = new System.Drawing.Size(504, 372);
            this.PL_Proc.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.Fee_State);
            this.panel1.Controls.Add(this.SubmitDate);
            this.panel1.Controls.Add(this.ApplyUser);
            this.panel1.Controls.Add(this.DisuseNO);
            this.panel1.Controls.Add(this.DisuseDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DesterilizeDescribe);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 203);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 94);
            this.panel1.TabIndex = 3;
            // 
            // Fee_State
            // 
            this.Fee_State.Enabled = false;
            this.Fee_State.Location = new System.Drawing.Point(433, 64);
            this.Fee_State.Name = "Fee_State";
            this.Fee_State.ReadOnly = true;
            this.Fee_State.Size = new System.Drawing.Size(51, 21);
            this.Fee_State.TabIndex = 98;
            // 
            // SubmitDate
            // 
            this.SubmitDate.Enabled = false;
            this.SubmitDate.Location = new System.Drawing.Point(274, 64);
            this.SubmitDate.Name = "SubmitDate";
            this.SubmitDate.ReadOnly = true;
            this.SubmitDate.Size = new System.Drawing.Size(93, 21);
            this.SubmitDate.TabIndex = 97;
            // 
            // ApplyUser
            // 
            this.ApplyUser.Enabled = false;
            this.ApplyUser.Location = new System.Drawing.Point(79, 64);
            this.ApplyUser.Name = "ApplyUser";
            this.ApplyUser.ReadOnly = true;
            this.ApplyUser.Size = new System.Drawing.Size(118, 21);
            this.ApplyUser.TabIndex = 96;
            // 
            // DisuseNO
            // 
            this.DisuseNO.Enabled = false;
            this.DisuseNO.Location = new System.Drawing.Point(95, 9);
            this.DisuseNO.Name = "DisuseNO";
            this.DisuseNO.ReadOnly = true;
            this.DisuseNO.Size = new System.Drawing.Size(194, 21);
            this.DisuseNO.TabIndex = 95;
            // 
            // DisuseDate
            // 
            this.DisuseDate.Enabled = false;
            this.DisuseDate.Location = new System.Drawing.Point(366, 8);
            this.DisuseDate.Name = "DisuseDate";
            this.DisuseDate.ReadOnly = true;
            this.DisuseDate.Size = new System.Drawing.Size(120, 21);
            this.DisuseDate.TabIndex = 94;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 93;
            this.label2.Text = "申请时间：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(373, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 92;
            this.label10.Text = "欠费状态：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 88;
            this.label6.Text = "申 请 人：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 87;
            this.label4.Text = "恢复说明：";
            // 
            // DesterilizeDescribe
            // 
            this.DesterilizeDescribe.Enabled = false;
            this.DesterilizeDescribe.Location = new System.Drawing.Point(79, 36);
            this.DesterilizeDescribe.Name = "DesterilizeDescribe";
            this.DesterilizeDescribe.ReadOnly = true;
            this.DesterilizeDescribe.Size = new System.Drawing.Size(405, 21);
            this.DesterilizeDescribe.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 82;
            this.label5.Text = "报停时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "报停受理编号：";
            // 
            // uC_UserInfos1
            // 
            this.uC_UserInfos1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserInfos1.Name = "uC_UserInfos1";
            this.uC_UserInfos1.Size = new System.Drawing.Size(502, 194);
            this.uC_UserInfos1.TabIndex = 4;
            // 
            // uC_ApproveList1
            // 
            this.uC_ApproveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_ApproveList1.Location = new System.Drawing.Point(3, 3);
            this.uC_ApproveList1.Name = "uC_ApproveList1";
            this.uC_ApproveList1.Size = new System.Drawing.Size(654, 678);
            this.uC_ApproveList1.TabIndex = 1;
            // 
            // FrmDesterilize_Approve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 684);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDesterilize_Approve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用水恢复-营业";
            this.Load += new System.EventHandler(this.FrmDesterilize_Approve_Load);
            this.Shown += new System.EventHandler(this.FrmDesterilize_Approve_Shown);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDesterilize_Approve_FormClosed);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox DesterilizeDescribe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private SysControl.UC_UserInfos uC_UserInfos1;
        private SysControl.UC_ApproveList uC_ApproveList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DisuseNO;
        private System.Windows.Forms.TextBox DisuseDate;
        private System.Windows.Forms.TextBox Fee_State;
        private System.Windows.Forms.TextBox SubmitDate;
        private System.Windows.Forms.TextBox ApplyUser;
    }
}
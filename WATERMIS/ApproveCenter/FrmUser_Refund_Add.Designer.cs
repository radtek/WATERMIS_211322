namespace ApproveCenter
{
    partial class FrmUser_Refund_Add
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
            this.label7 = new System.Windows.Forms.Label();
            this.WATERUSERNO = new System.Windows.Forms.TextBox();
            this.CHARGEBCSS_IN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Memo = new System.Windows.Forms.RichTextBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.CHARGETYPEID = new System.Windows.Forms.ComboBox();
            this.RefundDescribe = new System.Windows.Forms.TextBox();
            this.waterPhone = new System.Windows.Forms.TextBox();
            this.ApplyUser = new System.Windows.Forms.TextBox();
            this.CHARGEID_IN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.WATERUSERNO);
            this.panel1.Controls.Add(this.CHARGEBCSS_IN);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Memo);
            this.panel1.Controls.Add(this.Btn_Search);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.CHARGETYPEID);
            this.panel1.Controls.Add(this.RefundDescribe);
            this.panel1.Controls.Add(this.waterPhone);
            this.panel1.Controls.Add(this.ApplyUser);
            this.panel1.Controls.Add(this.CHARGEID_IN);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 444);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "9999";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "用 户 号：";
            // 
            // WATERUSERNO
            // 
            this.WATERUSERNO.Enabled = false;
            this.WATERUSERNO.Location = new System.Drawing.Point(308, 88);
            this.WATERUSERNO.Name = "WATERUSERNO";
            this.WATERUSERNO.Size = new System.Drawing.Size(117, 21);
            this.WATERUSERNO.TabIndex = 15;
            // 
            // CHARGEBCSS_IN
            // 
            this.CHARGEBCSS_IN.Enabled = false;
            this.CHARGEBCSS_IN.Location = new System.Drawing.Point(109, 54);
            this.CHARGEBCSS_IN.Name = "CHARGEBCSS_IN";
            this.CHARGEBCSS_IN.Size = new System.Drawing.Size(117, 21);
            this.CHARGEBCSS_IN.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "退款金额：";
            // 
            // Memo
            // 
            this.Memo.BackColor = System.Drawing.Color.White;
            this.Memo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Memo.Enabled = false;
            this.Memo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Memo.ForeColor = System.Drawing.Color.Red;
            this.Memo.Location = new System.Drawing.Point(34, 288);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(391, 71);
            this.Memo.TabIndex = 12;
            this.Memo.Text = "说明：\n1、当天的交费，可以当天退\n2、当月交费，需要走审批流程\n3、历史月份交费，不可退款";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(360, 20);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(65, 23);
            this.Btn_Search.TabIndex = 11;
            this.Btn_Search.Text = "查询";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(149, 383);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(114, 38);
            this.Btn_Submit.TabIndex = 10;
            this.Btn_Submit.Text = "提  交";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // CHARGETYPEID
            // 
            this.CHARGETYPEID.Enabled = false;
            this.CHARGETYPEID.FormattingEnabled = true;
            this.CHARGETYPEID.Location = new System.Drawing.Point(109, 158);
            this.CHARGETYPEID.Name = "CHARGETYPEID";
            this.CHARGETYPEID.Size = new System.Drawing.Size(186, 20);
            this.CHARGETYPEID.TabIndex = 9;
            // 
            // RefundDescribe
            // 
            this.RefundDescribe.Location = new System.Drawing.Point(109, 193);
            this.RefundDescribe.Multiline = true;
            this.RefundDescribe.Name = "RefundDescribe";
            this.RefundDescribe.Size = new System.Drawing.Size(316, 80);
            this.RefundDescribe.TabIndex = 8;
            // 
            // waterPhone
            // 
            this.waterPhone.Location = new System.Drawing.Point(109, 122);
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.Size = new System.Drawing.Size(186, 21);
            this.waterPhone.TabIndex = 7;
            // 
            // ApplyUser
            // 
            this.ApplyUser.Location = new System.Drawing.Point(109, 88);
            this.ApplyUser.Name = "ApplyUser";
            this.ApplyUser.Size = new System.Drawing.Size(117, 21);
            this.ApplyUser.TabIndex = 6;
            // 
            // CHARGEID_IN
            // 
            this.CHARGEID_IN.Location = new System.Drawing.Point(109, 21);
            this.CHARGEID_IN.Name = "CHARGEID_IN";
            this.CHARGEID_IN.Size = new System.Drawing.Size(245, 21);
            this.CHARGEID_IN.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "退款方式：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "*退款原因：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "*联系电话：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "申 请 人：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*收款流水号：";
            // 
            // FrmUser_Refund_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 444);
            this.Controls.Add(this.panel1);
            this.Name = "FrmUser_Refund_Add";
            this.Tag = "9999";
            this.Text = "用户退款申请";
            this.Load += new System.EventHandler(this.FrmUser_Refund_Add_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CHARGETYPEID;
        private System.Windows.Forms.TextBox RefundDescribe;
        private System.Windows.Forms.TextBox waterPhone;
        private System.Windows.Forms.TextBox ApplyUser;
        private System.Windows.Forms.TextBox CHARGEID_IN;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.RichTextBox Memo;
        private System.Windows.Forms.TextBox CHARGEBCSS_IN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox WATERUSERNO;
    }
}
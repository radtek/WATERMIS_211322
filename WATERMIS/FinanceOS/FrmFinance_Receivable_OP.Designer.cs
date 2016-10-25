namespace FinanceOS
{
    partial class FrmFinance_Receivable_OP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinance_Receivable_OP));
            this.LB_TotalFee = new System.Windows.Forms.Label();
            this.Btn_Print = new System.Windows.Forms.Button();
            this.FP_Dep = new System.Windows.Forms.FlowLayoutPanel();
            this.PL = new System.Windows.Forms.Panel();
            this.POSRUNNINGNO = new System.Windows.Forms.TextBox();
            this.LB_POSRUNNINGNO = new System.Windows.Forms.Label();
            this.CHARGEBCSS = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TOTALCHARGE = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labReceiptNO = new System.Windows.Forms.Label();
            this.CHARGETYPEID = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ReceiptPrintSign = new System.Windows.Forms.CheckBox();
            this.Memo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RECEIPTNO = new System.Windows.Forms.MaskedTextBox();
            this.LB_Title = new System.Windows.Forms.Label();
            this.FP_Items = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StateName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CreateDate = new System.Windows.Forms.TextBox();
            this.waterUserId = new System.Windows.Forms.TextBox();
            this.waterUserName = new System.Windows.Forms.TextBox();
            this.SD = new System.Windows.Forms.TextBox();
            this.Table_Name_CH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PL.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_TotalFee
            // 
            this.LB_TotalFee.AutoSize = true;
            this.LB_TotalFee.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_TotalFee.ForeColor = System.Drawing.Color.Red;
            this.LB_TotalFee.Location = new System.Drawing.Point(214, 147);
            this.LB_TotalFee.Name = "LB_TotalFee";
            this.LB_TotalFee.Size = new System.Drawing.Size(64, 12);
            this.LB_TotalFee.TabIndex = 31;
            this.LB_TotalFee.Text = "总计：0元";
            // 
            // Btn_Print
            // 
            this.Btn_Print.Location = new System.Drawing.Point(190, 483);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(97, 33);
            this.Btn_Print.TabIndex = 30;
            this.Btn_Print.Text = "打印收据";
            this.Btn_Print.UseVisualStyleBackColor = true;
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // FP_Dep
            // 
            this.FP_Dep.BackColor = System.Drawing.Color.White;
            this.FP_Dep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP_Dep.BackgroundImage")));
            this.FP_Dep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FP_Dep.Location = new System.Drawing.Point(16, 175);
            this.FP_Dep.Name = "FP_Dep";
            this.FP_Dep.Size = new System.Drawing.Size(486, 76);
            this.FP_Dep.TabIndex = 29;
            // 
            // PL
            // 
            this.PL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PL.Controls.Add(this.POSRUNNINGNO);
            this.PL.Controls.Add(this.LB_POSRUNNINGNO);
            this.PL.Controls.Add(this.CHARGEBCSS);
            this.PL.Controls.Add(this.label6);
            this.PL.Controls.Add(this.TOTALCHARGE);
            this.PL.Controls.Add(this.label4);
            this.PL.Controls.Add(this.labReceiptNO);
            this.PL.Controls.Add(this.CHARGETYPEID);
            this.PL.Controls.Add(this.label23);
            this.PL.Controls.Add(this.ReceiptPrintSign);
            this.PL.Controls.Add(this.Memo);
            this.PL.Controls.Add(this.label3);
            this.PL.Controls.Add(this.RECEIPTNO);
            this.PL.Location = new System.Drawing.Point(16, 320);
            this.PL.Name = "PL";
            this.PL.Size = new System.Drawing.Size(486, 149);
            this.PL.TabIndex = 28;
            // 
            // POSRUNNINGNO
            // 
            this.POSRUNNINGNO.Location = new System.Drawing.Point(327, 41);
            this.POSRUNNINGNO.Name = "POSRUNNINGNO";
            this.POSRUNNINGNO.Size = new System.Drawing.Size(144, 21);
            this.POSRUNNINGNO.TabIndex = 152;
            this.POSRUNNINGNO.Visible = false;
            // 
            // LB_POSRUNNINGNO
            // 
            this.LB_POSRUNNINGNO.AutoSize = true;
            this.LB_POSRUNNINGNO.Location = new System.Drawing.Point(265, 45);
            this.LB_POSRUNNINGNO.Name = "LB_POSRUNNINGNO";
            this.LB_POSRUNNINGNO.Size = new System.Drawing.Size(59, 12);
            this.LB_POSRUNNINGNO.TabIndex = 151;
            this.LB_POSRUNNINGNO.Text = "POS单号：";
            this.LB_POSRUNNINGNO.Visible = false;
            // 
            // CHARGEBCSS
            // 
            this.CHARGEBCSS.Enabled = false;
            this.CHARGEBCSS.Location = new System.Drawing.Point(327, 11);
            this.CHARGEBCSS.Name = "CHARGEBCSS";
            this.CHARGEBCSS.Size = new System.Drawing.Size(144, 21);
            this.CHARGEBCSS.TabIndex = 150;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 149;
            this.label6.Text = "实收金额：";
            // 
            // TOTALCHARGE
            // 
            this.TOTALCHARGE.Enabled = false;
            this.TOTALCHARGE.Location = new System.Drawing.Point(84, 11);
            this.TOTALCHARGE.Name = "TOTALCHARGE";
            this.TOTALCHARGE.ReadOnly = true;
            this.TOTALCHARGE.Size = new System.Drawing.Size(144, 21);
            this.TOTALCHARGE.TabIndex = 142;
            this.TOTALCHARGE.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 141;
            this.label4.Text = "合计金额：";
            // 
            // labReceiptNO
            // 
            this.labReceiptNO.AutoSize = true;
            this.labReceiptNO.BackColor = System.Drawing.Color.Transparent;
            this.labReceiptNO.Location = new System.Drawing.Point(114, 81);
            this.labReceiptNO.Name = "labReceiptNO";
            this.labReceiptNO.Size = new System.Drawing.Size(65, 12);
            this.labReceiptNO.TabIndex = 139;
            this.labReceiptNO.Text = "收 据 号：";
            // 
            // CHARGETYPEID
            // 
            this.CHARGETYPEID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CHARGETYPEID.FormattingEnabled = true;
            this.CHARGETYPEID.Location = new System.Drawing.Point(84, 41);
            this.CHARGETYPEID.Name = "CHARGETYPEID";
            this.CHARGETYPEID.Size = new System.Drawing.Size(144, 20);
            this.CHARGETYPEID.TabIndex = 133;
            this.CHARGETYPEID.SelectedIndexChanged += new System.EventHandler(this.CHARGETYPEID_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(18, 45);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 134;
            this.label23.Text = "收款方式：";
            // 
            // ReceiptPrintSign
            // 
            this.ReceiptPrintSign.AutoSize = true;
            this.ReceiptPrintSign.Checked = true;
            this.ReceiptPrintSign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ReceiptPrintSign.Enabled = false;
            this.ReceiptPrintSign.Location = new System.Drawing.Point(18, 81);
            this.ReceiptPrintSign.Name = "ReceiptPrintSign";
            this.ReceiptPrintSign.Size = new System.Drawing.Size(72, 16);
            this.ReceiptPrintSign.TabIndex = 132;
            this.ReceiptPrintSign.Text = "打印收据";
            this.ReceiptPrintSign.UseVisualStyleBackColor = true;
            // 
            // Memo
            // 
            this.Memo.Location = new System.Drawing.Point(84, 109);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(387, 21);
            this.Memo.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 129;
            this.label3.Text = "备    注：";
            // 
            // RECEIPTNO
            // 
            this.RECEIPTNO.Location = new System.Drawing.Point(180, 76);
            this.RECEIPTNO.Name = "RECEIPTNO";
            this.RECEIPTNO.Size = new System.Drawing.Size(144, 21);
            this.RECEIPTNO.TabIndex = 145;
            // 
            // LB_Title
            // 
            this.LB_Title.AutoSize = true;
            this.LB_Title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_Title.Location = new System.Drawing.Point(17, 141);
            this.LB_Title.Name = "LB_Title";
            this.LB_Title.Size = new System.Drawing.Size(182, 22);
            this.LB_Title.TabIndex = 27;
            this.LB_Title.Text = "各部门费用列表(预算)：";
            // 
            // FP_Items
            // 
            this.FP_Items.AutoScroll = true;
            this.FP_Items.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP_Items.BackgroundImage")));
            this.FP_Items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FP_Items.Location = new System.Drawing.Point(16, 256);
            this.FP_Items.Name = "FP_Items";
            this.FP_Items.Size = new System.Drawing.Size(486, 58);
            this.FP_Items.TabIndex = 26;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(344, 483);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(97, 33);
            this.Btn_Submit.TabIndex = 25;
            this.Btn_Submit.Text = "收费完成";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Visible = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(21, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 100);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.StateName);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.CreateDate);
            this.panel1.Controls.Add(this.waterUserId);
            this.panel1.Controls.Add(this.waterUserName);
            this.panel1.Controls.Add(this.SD);
            this.panel1.Controls.Add(this.Table_Name_CH);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 80);
            this.panel1.TabIndex = 0;
            // 
            // StateName
            // 
            this.StateName.Location = new System.Drawing.Point(390, 44);
            this.StateName.Name = "StateName";
            this.StateName.ReadOnly = true;
            this.StateName.Size = new System.Drawing.Size(74, 21);
            this.StateName.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(322, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "审批状态：";
            // 
            // CreateDate
            // 
            this.CreateDate.Location = new System.Drawing.Point(390, 14);
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Size = new System.Drawing.Size(74, 21);
            this.CreateDate.TabIndex = 9;
            // 
            // waterUserId
            // 
            this.waterUserId.Location = new System.Drawing.Point(242, 44);
            this.waterUserId.Name = "waterUserId";
            this.waterUserId.ReadOnly = true;
            this.waterUserId.Size = new System.Drawing.Size(76, 21);
            this.waterUserId.TabIndex = 8;
            // 
            // waterUserName
            // 
            this.waterUserName.Location = new System.Drawing.Point(76, 45);
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.ReadOnly = true;
            this.waterUserName.Size = new System.Drawing.Size(106, 21);
            this.waterUserName.TabIndex = 7;
            // 
            // SD
            // 
            this.SD.Location = new System.Drawing.Point(221, 14);
            this.SD.Name = "SD";
            this.SD.ReadOnly = true;
            this.SD.Size = new System.Drawing.Size(97, 21);
            this.SD.TabIndex = 6;
            // 
            // Table_Name_CH
            // 
            this.Table_Name_CH.Location = new System.Drawing.Point(76, 14);
            this.Table_Name_CH.Name = "Table_Name_CH";
            this.Table_Name_CH.ReadOnly = true;
            this.Table_Name_CH.Size = new System.Drawing.Size(85, 21);
            this.Table_Name_CH.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(7, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "业务类型：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(322, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "提交时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(186, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "用户号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(164, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "流水号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名称：";
            // 
            // FrmFinance_Receivable_OP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 541);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LB_TotalFee);
            this.Controls.Add(this.Btn_Print);
            this.Controls.Add(this.FP_Dep);
            this.Controls.Add(this.PL);
            this.Controls.Add(this.LB_Title);
            this.Controls.Add(this.FP_Items);
            this.Controls.Add(this.Btn_Submit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFinance_Receivable_OP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "业扩收费";
            this.Load += new System.EventHandler(this.FrmFinance_Receivable_OP_Load);
            this.PL.ResumeLayout(false);
            this.PL.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_TotalFee;
        private System.Windows.Forms.Button Btn_Print;
        private System.Windows.Forms.FlowLayoutPanel FP_Dep;
        private System.Windows.Forms.Panel PL;
        private System.Windows.Forms.TextBox POSRUNNINGNO;
        private System.Windows.Forms.Label LB_POSRUNNINGNO;
        private System.Windows.Forms.MaskedTextBox CHARGEBCSS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TOTALCHARGE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labReceiptNO;
        private System.Windows.Forms.ComboBox CHARGETYPEID;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox ReceiptPrintSign;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox RECEIPTNO;
        private System.Windows.Forms.Label LB_Title;
        private System.Windows.Forms.FlowLayoutPanel FP_Items;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Table_Name_CH;
        private System.Windows.Forms.TextBox waterUserId;
        private System.Windows.Forms.TextBox waterUserName;
        private System.Windows.Forms.TextBox SD;
        private System.Windows.Forms.TextBox CreateDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox StateName;
    }
}
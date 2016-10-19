namespace PersonalWork
{
    partial class FrmApprove_Single_Budget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Single_Budget));
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
            this.FP_Dep = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Print = new System.Windows.Forms.Button();
            this.LB_TotalFee = new System.Windows.Forms.Label();
            this.PL.SuspendLayout();
            this.SuspendLayout();
            // 
            // PL
            // 
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
            this.PL.Location = new System.Drawing.Point(12, 262);
            this.PL.Name = "PL";
            this.PL.Size = new System.Drawing.Size(486, 149);
            this.PL.TabIndex = 21;
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
            this.LB_Title.Location = new System.Drawing.Point(13, 14);
            this.LB_Title.Name = "LB_Title";
            this.LB_Title.Size = new System.Drawing.Size(170, 22);
            this.LB_Title.TabIndex = 20;
            this.LB_Title.Text = "各部门预算费用列表：";
            // 
            // FP_Items
            // 
            this.FP_Items.AutoScroll = true;
            this.FP_Items.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP_Items.BackgroundImage")));
            this.FP_Items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FP_Items.Location = new System.Drawing.Point(12, 130);
            this.FP_Items.Name = "FP_Items";
            this.FP_Items.Size = new System.Drawing.Size(486, 123);
            this.FP_Items.TabIndex = 19;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(251, 427);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(97, 33);
            this.Btn_Submit.TabIndex = 18;
            this.Btn_Submit.Text = "收费完成";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // FP_Dep
            // 
            this.FP_Dep.BackColor = System.Drawing.Color.White;
            this.FP_Dep.Location = new System.Drawing.Point(12, 48);
            this.FP_Dep.Name = "FP_Dep";
            this.FP_Dep.Size = new System.Drawing.Size(486, 76);
            this.FP_Dep.TabIndex = 22;
            // 
            // Btn_Print
            // 
            this.Btn_Print.Location = new System.Drawing.Point(146, 427);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(97, 33);
            this.Btn_Print.TabIndex = 23;
            this.Btn_Print.Text = "打印收据";
            this.Btn_Print.UseVisualStyleBackColor = true;
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // LB_TotalFee
            // 
            this.LB_TotalFee.AutoSize = true;
            this.LB_TotalFee.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_TotalFee.ForeColor = System.Drawing.Color.Red;
            this.LB_TotalFee.Location = new System.Drawing.Point(194, 19);
            this.LB_TotalFee.Name = "LB_TotalFee";
            this.LB_TotalFee.Size = new System.Drawing.Size(64, 12);
            this.LB_TotalFee.TabIndex = 24;
            this.LB_TotalFee.Text = "总计：0元";
            // 
            // FrmApprove_Single_Budget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 470);
            this.Controls.Add(this.LB_TotalFee);
            this.Controls.Add(this.Btn_Print);
            this.Controls.Add(this.FP_Dep);
            this.Controls.Add(this.PL);
            this.Controls.Add(this.LB_Title);
            this.Controls.Add(this.FP_Items);
            this.Controls.Add(this.Btn_Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmApprove_Single_Budget";
            this.Text = "FrmApprove_Single_Budget";
            this.Load += new System.EventHandler(this.FrmApprove_Single_Budget_Load);
            this.PL.ResumeLayout(false);
            this.PL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.FlowLayoutPanel FP_Dep;
        private System.Windows.Forms.Button Btn_Print;
        private System.Windows.Forms.Label LB_TotalFee;
    }
}
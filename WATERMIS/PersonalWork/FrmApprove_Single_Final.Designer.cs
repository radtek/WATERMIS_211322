namespace PersonalWork
{
    partial class FrmApprove_Single_Final
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Single_Final));
            this.LB_TotalFee = new System.Windows.Forms.Label();
            this.Btn_Print = new System.Windows.Forms.Button();
            this.FP_Dep = new System.Windows.Forms.FlowLayoutPanel();
            this.LB_Title = new System.Windows.Forms.Label();
            this.FP_Items = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.PL = new System.Windows.Forms.Panel();
            this.POSRUNNINGNO = new System.Windows.Forms.TextBox();
            this.LB_POSRUNNINGNO = new System.Windows.Forms.Label();
            this.CHARGEBCSS = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.prestore = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Abate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TOTALCHARGE = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labReceiptNO = new System.Windows.Forms.Label();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.labInvoiceBatch = new System.Windows.Forms.Label();
            this.labInvoiceNO = new System.Windows.Forms.Label();
            this.INVOICEPRINTSIGN = new System.Windows.Forms.CheckBox();
            this.CHARGETYPEID = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ReceiptPrintSign = new System.Windows.Forms.CheckBox();
            this.Memo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CHARGEBCYS = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RECEIPTNO = new System.Windows.Forms.MaskedTextBox();
            this.InvoiceNO = new System.Windows.Forms.MaskedTextBox();
            this.Btn_Settle = new System.Windows.Forms.Button();
            this.LB_Prestore = new System.Windows.Forms.Label();
            this.PL.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_TotalFee
            // 
            this.LB_TotalFee.AutoSize = true;
            this.LB_TotalFee.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_TotalFee.ForeColor = System.Drawing.Color.Red;
            this.LB_TotalFee.Location = new System.Drawing.Point(185, 17);
            this.LB_TotalFee.Name = "LB_TotalFee";
            this.LB_TotalFee.Size = new System.Drawing.Size(90, 12);
            this.LB_TotalFee.TabIndex = 31;
            this.LB_TotalFee.Text = "决算费用：0元";
            // 
            // Btn_Print
            // 
            this.Btn_Print.Enabled = false;
            this.Btn_Print.Location = new System.Drawing.Point(207, 425);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(97, 33);
            this.Btn_Print.TabIndex = 30;
            this.Btn_Print.Text = "结算打印";
            this.Btn_Print.UseVisualStyleBackColor = true;
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // FP_Dep
            // 
            this.FP_Dep.BackColor = System.Drawing.Color.White;
            this.FP_Dep.Location = new System.Drawing.Point(12, 46);
            this.FP_Dep.Name = "FP_Dep";
            this.FP_Dep.Size = new System.Drawing.Size(486, 76);
            this.FP_Dep.TabIndex = 29;
            // 
            // LB_Title
            // 
            this.LB_Title.AutoSize = true;
            this.LB_Title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_Title.Location = new System.Drawing.Point(13, 12);
            this.LB_Title.Name = "LB_Title";
            this.LB_Title.Size = new System.Drawing.Size(170, 22);
            this.LB_Title.TabIndex = 27;
            this.LB_Title.Text = "各部门决算费用列表：";
            // 
            // FP_Items
            // 
            this.FP_Items.AutoScroll = true;
            this.FP_Items.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP_Items.BackgroundImage")));
            this.FP_Items.Location = new System.Drawing.Point(12, 128);
            this.FP_Items.Name = "FP_Items";
            this.FP_Items.Size = new System.Drawing.Size(486, 76);
            this.FP_Items.TabIndex = 26;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(311, 425);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(97, 33);
            this.Btn_Submit.TabIndex = 25;
            this.Btn_Submit.Text = "收费完成";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // PL
            // 
            this.PL.Controls.Add(this.POSRUNNINGNO);
            this.PL.Controls.Add(this.LB_POSRUNNINGNO);
            this.PL.Controls.Add(this.CHARGEBCSS);
            this.PL.Controls.Add(this.label6);
            this.PL.Controls.Add(this.prestore);
            this.PL.Controls.Add(this.label2);
            this.PL.Controls.Add(this.Abate);
            this.PL.Controls.Add(this.label5);
            this.PL.Controls.Add(this.TOTALCHARGE);
            this.PL.Controls.Add(this.label4);
            this.PL.Controls.Add(this.labReceiptNO);
            this.PL.Controls.Add(this.cmbBatch);
            this.PL.Controls.Add(this.labInvoiceBatch);
            this.PL.Controls.Add(this.labInvoiceNO);
            this.PL.Controls.Add(this.INVOICEPRINTSIGN);
            this.PL.Controls.Add(this.CHARGETYPEID);
            this.PL.Controls.Add(this.label23);
            this.PL.Controls.Add(this.ReceiptPrintSign);
            this.PL.Controls.Add(this.Memo);
            this.PL.Controls.Add(this.label3);
            this.PL.Controls.Add(this.CHARGEBCYS);
            this.PL.Controls.Add(this.label7);
            this.PL.Controls.Add(this.RECEIPTNO);
            this.PL.Controls.Add(this.InvoiceNO);
            this.PL.Location = new System.Drawing.Point(12, 210);
            this.PL.Name = "PL";
            this.PL.Size = new System.Drawing.Size(486, 188);
            this.PL.TabIndex = 32;
            // 
            // POSRUNNINGNO
            // 
            this.POSRUNNINGNO.Location = new System.Drawing.Point(327, 92);
            this.POSRUNNINGNO.Name = "POSRUNNINGNO";
            this.POSRUNNINGNO.Size = new System.Drawing.Size(144, 21);
            this.POSRUNNINGNO.TabIndex = 152;
            this.POSRUNNINGNO.Visible = false;
            // 
            // LB_POSRUNNINGNO
            // 
            this.LB_POSRUNNINGNO.AutoSize = true;
            this.LB_POSRUNNINGNO.Location = new System.Drawing.Point(265, 97);
            this.LB_POSRUNNINGNO.Name = "LB_POSRUNNINGNO";
            this.LB_POSRUNNINGNO.Size = new System.Drawing.Size(59, 12);
            this.LB_POSRUNNINGNO.TabIndex = 151;
            this.LB_POSRUNNINGNO.Text = "POS单号：";
            this.LB_POSRUNNINGNO.Visible = false;
            // 
            // CHARGEBCSS
            // 
            this.CHARGEBCSS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CHARGEBCSS.ForeColor = System.Drawing.Color.Red;
            this.CHARGEBCSS.Location = new System.Drawing.Point(84, 67);
            this.CHARGEBCSS.Name = "CHARGEBCSS";
            this.CHARGEBCSS.Size = new System.Drawing.Size(144, 21);
            this.CHARGEBCSS.TabIndex = 150;
            this.CHARGEBCSS.TextChanged += new System.EventHandler(this.CHARGEBCSS_TextChanged);
            this.CHARGEBCSS.MouseLeave += new System.EventHandler(this.CHARGEBCSS_MouseLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 149;
            this.label6.Text = "实收金额：";
            // 
            // prestore
            // 
            this.prestore.Enabled = false;
            this.prestore.Location = new System.Drawing.Point(327, 13);
            this.prestore.Name = "prestore";
            this.prestore.ReadOnly = true;
            this.prestore.Size = new System.Drawing.Size(144, 21);
            this.prestore.TabIndex = 148;
            this.prestore.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 147;
            this.label2.Text = "预算金额：";
            // 
            // Abate
            // 
            this.Abate.Enabled = false;
            this.Abate.Location = new System.Drawing.Point(261, -9);
            this.Abate.Name = "Abate";
            this.Abate.ReadOnly = true;
            this.Abate.Size = new System.Drawing.Size(144, 21);
            this.Abate.TabIndex = 144;
            this.Abate.Text = "0";
            this.Abate.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 143;
            this.label5.Text = "减免金额：";
            this.label5.Visible = false;
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
            this.labReceiptNO.Location = new System.Drawing.Point(18, 127);
            this.labReceiptNO.Name = "labReceiptNO";
            this.labReceiptNO.Size = new System.Drawing.Size(65, 12);
            this.labReceiptNO.TabIndex = 139;
            this.labReceiptNO.Text = "收 据 号：";
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(327, 120);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(144, 20);
            this.cmbBatch.TabIndex = 138;
            this.cmbBatch.Visible = false;
            // 
            // labInvoiceBatch
            // 
            this.labInvoiceBatch.AutoSize = true;
            this.labInvoiceBatch.Location = new System.Drawing.Point(259, 126);
            this.labInvoiceBatch.Name = "labInvoiceBatch";
            this.labInvoiceBatch.Size = new System.Drawing.Size(65, 12);
            this.labInvoiceBatch.TabIndex = 137;
            this.labInvoiceBatch.Text = "发票批次：";
            this.labInvoiceBatch.Visible = false;
            // 
            // labInvoiceNO
            // 
            this.labInvoiceNO.AutoSize = true;
            this.labInvoiceNO.Location = new System.Drawing.Point(18, 127);
            this.labInvoiceNO.Name = "labInvoiceNO";
            this.labInvoiceNO.Size = new System.Drawing.Size(65, 12);
            this.labInvoiceNO.TabIndex = 135;
            this.labInvoiceNO.Text = "发 票 号：";
            this.labInvoiceNO.Visible = false;
            // 
            // INVOICEPRINTSIGN
            // 
            this.INVOICEPRINTSIGN.AutoSize = true;
            this.INVOICEPRINTSIGN.Location = new System.Drawing.Point(110, 98);
            this.INVOICEPRINTSIGN.Name = "INVOICEPRINTSIGN";
            this.INVOICEPRINTSIGN.Size = new System.Drawing.Size(72, 16);
            this.INVOICEPRINTSIGN.TabIndex = 131;
            this.INVOICEPRINTSIGN.Text = "打印发票";
            this.INVOICEPRINTSIGN.UseVisualStyleBackColor = true;
            this.INVOICEPRINTSIGN.CheckedChanged += new System.EventHandler(this.INVOICEPRINTSIGN_CheckedChanged);
            // 
            // CHARGETYPEID
            // 
            this.CHARGETYPEID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CHARGETYPEID.FormattingEnabled = true;
            this.CHARGETYPEID.Location = new System.Drawing.Point(327, 64);
            this.CHARGETYPEID.Name = "CHARGETYPEID";
            this.CHARGETYPEID.Size = new System.Drawing.Size(144, 20);
            this.CHARGETYPEID.TabIndex = 133;
            this.CHARGETYPEID.SelectedIndexChanged += new System.EventHandler(this.CHARGETYPEID_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(259, 70);
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
            this.ReceiptPrintSign.Location = new System.Drawing.Point(18, 99);
            this.ReceiptPrintSign.Name = "ReceiptPrintSign";
            this.ReceiptPrintSign.Size = new System.Drawing.Size(72, 16);
            this.ReceiptPrintSign.TabIndex = 132;
            this.ReceiptPrintSign.Text = "打印收据";
            this.ReceiptPrintSign.UseVisualStyleBackColor = true;
            this.ReceiptPrintSign.CheckedChanged += new System.EventHandler(this.ReceiptPrintSign_CheckedChanged);
            // 
            // Memo
            // 
            this.Memo.Location = new System.Drawing.Point(84, 149);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(387, 21);
            this.Memo.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 129;
            this.label3.Text = "备    注：";
            // 
            // CHARGEBCYS
            // 
            this.CHARGEBCYS.Enabled = false;
            this.CHARGEBCYS.Location = new System.Drawing.Point(84, 39);
            this.CHARGEBCYS.Name = "CHARGEBCYS";
            this.CHARGEBCYS.ReadOnly = true;
            this.CHARGEBCYS.Size = new System.Drawing.Size(144, 21);
            this.CHARGEBCYS.TabIndex = 128;
            this.CHARGEBCYS.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 127;
            this.label7.Text = "应收金额：";
            // 
            // RECEIPTNO
            // 
            this.RECEIPTNO.Location = new System.Drawing.Point(84, 123);
            this.RECEIPTNO.Mask = "999999999999999999999";
            this.RECEIPTNO.Name = "RECEIPTNO";
            this.RECEIPTNO.Size = new System.Drawing.Size(144, 21);
            this.RECEIPTNO.TabIndex = 145;
            // 
            // InvoiceNO
            // 
            this.InvoiceNO.Location = new System.Drawing.Point(84, 123);
            this.InvoiceNO.Mask = "999999999999999999";
            this.InvoiceNO.Name = "InvoiceNO";
            this.InvoiceNO.Size = new System.Drawing.Size(144, 21);
            this.InvoiceNO.TabIndex = 146;
            this.InvoiceNO.Visible = false;
            // 
            // Btn_Settle
            // 
            this.Btn_Settle.Enabled = false;
            this.Btn_Settle.Location = new System.Drawing.Point(103, 425);
            this.Btn_Settle.Name = "Btn_Settle";
            this.Btn_Settle.Size = new System.Drawing.Size(97, 33);
            this.Btn_Settle.TabIndex = 153;
            this.Btn_Settle.Text = "结  算";
            this.Btn_Settle.UseVisualStyleBackColor = true;
            this.Btn_Settle.Click += new System.EventHandler(this.Btn_Settle_Click);
            // 
            // LB_Prestore
            // 
            this.LB_Prestore.AutoSize = true;
            this.LB_Prestore.ForeColor = System.Drawing.Color.Maroon;
            this.LB_Prestore.Location = new System.Drawing.Point(366, 17);
            this.LB_Prestore.Name = "LB_Prestore";
            this.LB_Prestore.Size = new System.Drawing.Size(0, 12);
            this.LB_Prestore.TabIndex = 154;
            // 
            // FrmApprove_Single_Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 470);
            this.Controls.Add(this.LB_Prestore);
            this.Controls.Add(this.Btn_Settle);
            this.Controls.Add(this.PL);
            this.Controls.Add(this.LB_TotalFee);
            this.Controls.Add(this.Btn_Print);
            this.Controls.Add(this.FP_Dep);
            this.Controls.Add(this.LB_Title);
            this.Controls.Add(this.FP_Items);
            this.Controls.Add(this.Btn_Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmApprove_Single_Final";
            this.Text = "FrmApprove_Single_Final";
            this.Load += new System.EventHandler(this.FrmApprove_Single_Final_Load);
            this.PL.ResumeLayout(false);
            this.PL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_TotalFee;
        private System.Windows.Forms.Button Btn_Print;
        private System.Windows.Forms.FlowLayoutPanel FP_Dep;
        private System.Windows.Forms.Label LB_Title;
        private System.Windows.Forms.FlowLayoutPanel FP_Items;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Panel PL;
        private System.Windows.Forms.TextBox POSRUNNINGNO;
        private System.Windows.Forms.Label LB_POSRUNNINGNO;
        private System.Windows.Forms.MaskedTextBox CHARGEBCSS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox prestore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox Abate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox TOTALCHARGE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labReceiptNO;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.Label labInvoiceBatch;
        private System.Windows.Forms.Label labInvoiceNO;
        private System.Windows.Forms.CheckBox INVOICEPRINTSIGN;
        private System.Windows.Forms.ComboBox CHARGETYPEID;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox ReceiptPrintSign;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox CHARGEBCYS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox RECEIPTNO;
        private System.Windows.Forms.MaskedTextBox InvoiceNO;
        private System.Windows.Forms.Button Btn_Settle;
        private System.Windows.Forms.Label LB_Prestore;
    }
}
namespace FinanceOS
{
    partial class FrmFinance_Receivable_JS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinance_Receivable_JS));
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
            this.PL_JS = new System.Windows.Forms.Panel();
            this.LB_Prestore = new System.Windows.Forms.Label();
            this.Btn_Settle = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.RECEIPTNO = new System.Windows.Forms.TextBox();
            this.POSRUNNINGNO = new System.Windows.Forms.TextBox();
            this.LB_POSRUNNINGNO = new System.Windows.Forms.Label();
            this.CHARGEBCSS = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.prestore = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Abate = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TOTALCHARGE = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CHARGETYPEID = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ReceiptPrintSign = new System.Windows.Forms.CheckBox();
            this.Memo = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.CHARGEBCYS = new System.Windows.Forms.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.LB_TotalFee = new System.Windows.Forms.Label();
            this.Btn_Print = new System.Windows.Forms.Button();
            this.FP_Dep = new System.Windows.Forms.FlowLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.FP_Items = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.waterUserAddress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PL_JS.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 100);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.waterUserAddress);
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
            // PL_JS
            // 
            this.PL_JS.Controls.Add(this.LB_Prestore);
            this.PL_JS.Controls.Add(this.Btn_Settle);
            this.PL_JS.Controls.Add(this.panel4);
            this.PL_JS.Controls.Add(this.LB_TotalFee);
            this.PL_JS.Controls.Add(this.Btn_Print);
            this.PL_JS.Controls.Add(this.FP_Dep);
            this.PL_JS.Controls.Add(this.label20);
            this.PL_JS.Controls.Add(this.FP_Items);
            this.PL_JS.Controls.Add(this.Btn_Submit);
            this.PL_JS.Location = new System.Drawing.Point(4, 115);
            this.PL_JS.Name = "PL_JS";
            this.PL_JS.Size = new System.Drawing.Size(508, 391);
            this.PL_JS.TabIndex = 35;
            // 
            // LB_Prestore
            // 
            this.LB_Prestore.AutoSize = true;
            this.LB_Prestore.ForeColor = System.Drawing.Color.Maroon;
            this.LB_Prestore.Location = new System.Drawing.Point(374, 16);
            this.LB_Prestore.Name = "LB_Prestore";
            this.LB_Prestore.Size = new System.Drawing.Size(0, 12);
            this.LB_Prestore.TabIndex = 163;
            // 
            // Btn_Settle
            // 
            this.Btn_Settle.Location = new System.Drawing.Point(154, 349);
            this.Btn_Settle.Name = "Btn_Settle";
            this.Btn_Settle.Size = new System.Drawing.Size(97, 33);
            this.Btn_Settle.TabIndex = 162;
            this.Btn_Settle.Text = "结  算";
            this.Btn_Settle.UseVisualStyleBackColor = true;
            this.Btn_Settle.Visible = false;
            this.Btn_Settle.Click += new System.EventHandler(this.Btn_Settle_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.RECEIPTNO);
            this.panel4.Controls.Add(this.POSRUNNINGNO);
            this.panel4.Controls.Add(this.LB_POSRUNNINGNO);
            this.panel4.Controls.Add(this.CHARGEBCSS);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.prestore);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.Abate);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.TOTALCHARGE);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.CHARGETYPEID);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.ReceiptPrintSign);
            this.panel4.Controls.Add(this.Memo);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.CHARGEBCYS);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(10, 186);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(486, 153);
            this.panel4.TabIndex = 161;
            // 
            // RECEIPTNO
            // 
            this.RECEIPTNO.Location = new System.Drawing.Point(327, 93);
            this.RECEIPTNO.Name = "RECEIPTNO";
            this.RECEIPTNO.Size = new System.Drawing.Size(144, 21);
            this.RECEIPTNO.TabIndex = 153;
            // 
            // POSRUNNINGNO
            // 
            this.POSRUNNINGNO.Location = new System.Drawing.Point(327, 66);
            this.POSRUNNINGNO.Name = "POSRUNNINGNO";
            this.POSRUNNINGNO.Size = new System.Drawing.Size(144, 21);
            this.POSRUNNINGNO.TabIndex = 152;
            this.POSRUNNINGNO.Visible = false;
            // 
            // LB_POSRUNNINGNO
            // 
            this.LB_POSRUNNINGNO.AutoSize = true;
            this.LB_POSRUNNINGNO.Location = new System.Drawing.Point(265, 71);
            this.LB_POSRUNNINGNO.Name = "LB_POSRUNNINGNO";
            this.LB_POSRUNNINGNO.Size = new System.Drawing.Size(59, 12);
            this.LB_POSRUNNINGNO.TabIndex = 151;
            this.LB_POSRUNNINGNO.Text = "POS单号：";
            this.LB_POSRUNNINGNO.Visible = false;
            // 
            // CHARGEBCSS
            // 
            this.CHARGEBCSS.Enabled = false;
            this.CHARGEBCSS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CHARGEBCSS.ForeColor = System.Drawing.Color.Red;
            this.CHARGEBCSS.Location = new System.Drawing.Point(84, 67);
            this.CHARGEBCSS.Name = "CHARGEBCSS";
            this.CHARGEBCSS.Size = new System.Drawing.Size(144, 21);
            this.CHARGEBCSS.TabIndex = 150;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 149;
            this.label11.Text = "实收金额：";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(259, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 147;
            this.label12.Text = "预算金额：";
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(234, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 143;
            this.label13.Text = "减免金额：";
            this.label13.Visible = false;
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 141;
            this.label14.Text = "合计金额：";
            // 
            // CHARGETYPEID
            // 
            this.CHARGETYPEID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CHARGETYPEID.FormattingEnabled = true;
            this.CHARGETYPEID.Location = new System.Drawing.Point(327, 38);
            this.CHARGETYPEID.Name = "CHARGETYPEID";
            this.CHARGETYPEID.Size = new System.Drawing.Size(144, 20);
            this.CHARGETYPEID.TabIndex = 133;
            this.CHARGETYPEID.SelectedIndexChanged += new System.EventHandler(this.CHARGETYPEID_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(259, 44);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 134;
            this.label16.Text = "收款方式：";
            // 
            // ReceiptPrintSign
            // 
            this.ReceiptPrintSign.AutoSize = true;
            this.ReceiptPrintSign.Checked = true;
            this.ReceiptPrintSign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ReceiptPrintSign.Enabled = false;
            this.ReceiptPrintSign.Location = new System.Drawing.Point(156, 95);
            this.ReceiptPrintSign.Name = "ReceiptPrintSign";
            this.ReceiptPrintSign.Size = new System.Drawing.Size(72, 16);
            this.ReceiptPrintSign.TabIndex = 132;
            this.ReceiptPrintSign.Text = "打印收据";
            this.ReceiptPrintSign.UseVisualStyleBackColor = true;
            // 
            // Memo
            // 
            this.Memo.Location = new System.Drawing.Point(84, 122);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(387, 21);
            this.Memo.TabIndex = 130;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 128);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 129;
            this.label17.Text = "备    注：";
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 127;
            this.label18.Text = "应收金额：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(263, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 139;
            this.label15.Text = "收 据 号：";
            // 
            // LB_TotalFee
            // 
            this.LB_TotalFee.AutoSize = true;
            this.LB_TotalFee.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_TotalFee.ForeColor = System.Drawing.Color.Red;
            this.LB_TotalFee.Location = new System.Drawing.Point(68, 16);
            this.LB_TotalFee.Name = "LB_TotalFee";
            this.LB_TotalFee.Size = new System.Drawing.Size(90, 12);
            this.LB_TotalFee.TabIndex = 160;
            this.LB_TotalFee.Text = "决算费用：0元";
            // 
            // Btn_Print
            // 
            this.Btn_Print.Location = new System.Drawing.Point(154, 349);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(97, 33);
            this.Btn_Print.TabIndex = 159;
            this.Btn_Print.Text = "收  费";
            this.Btn_Print.UseVisualStyleBackColor = true;
            this.Btn_Print.Visible = false;
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // FP_Dep
            // 
            this.FP_Dep.BackColor = System.Drawing.Color.White;
            this.FP_Dep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FP_Dep.Location = new System.Drawing.Point(10, 41);
            this.FP_Dep.Name = "FP_Dep";
            this.FP_Dep.Size = new System.Drawing.Size(486, 76);
            this.FP_Dep.TabIndex = 158;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(11, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 22);
            this.label20.TabIndex = 157;
            this.label20.Text = "决算：";
            // 
            // FP_Items
            // 
            this.FP_Items.AutoScroll = true;
            this.FP_Items.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP_Items.BackgroundImage")));
            this.FP_Items.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FP_Items.Location = new System.Drawing.Point(10, 122);
            this.FP_Items.Name = "FP_Items";
            this.FP_Items.Size = new System.Drawing.Size(486, 58);
            this.FP_Items.TabIndex = 156;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(258, 349);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(97, 33);
            this.Btn_Submit.TabIndex = 155;
            this.Btn_Submit.Text = "收费完成";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.AutoSize = true;
            this.waterUserAddress.Location = new System.Drawing.Point(188, 63);
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.Size = new System.Drawing.Size(29, 12);
            this.waterUserAddress.TabIndex = 12;
            this.waterUserAddress.Text = "地址";
            this.waterUserAddress.Visible = false;
            // 
            // FrmFinance_Receivable_JS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 507);
            this.Controls.Add(this.PL_JS);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmFinance_Receivable_JS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "结算收费";
            this.Load += new System.EventHandler(this.FrmFinance_Receivable_JS_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PL_JS.ResumeLayout(false);
            this.PL_JS.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox StateName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CreateDate;
        private System.Windows.Forms.TextBox waterUserId;
        private System.Windows.Forms.TextBox waterUserName;
        private System.Windows.Forms.TextBox SD;
        private System.Windows.Forms.TextBox Table_Name_CH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PL_JS;
        private System.Windows.Forms.Label LB_Prestore;
        private System.Windows.Forms.Button Btn_Settle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox POSRUNNINGNO;
        private System.Windows.Forms.Label LB_POSRUNNINGNO;
        private System.Windows.Forms.MaskedTextBox CHARGEBCSS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox prestore;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox Abate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox TOTALCHARGE;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox CHARGETYPEID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox ReceiptPrintSign;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox CHARGEBCYS;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LB_TotalFee;
        private System.Windows.Forms.Button Btn_Print;
        private System.Windows.Forms.FlowLayoutPanel FP_Dep;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.FlowLayoutPanel FP_Items;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.TextBox RECEIPTNO;
        private System.Windows.Forms.Label waterUserAddress;
    }
}
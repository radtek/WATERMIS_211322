namespace WaterBusiness
{
    partial class Frm_Meter_Disuse_Add2
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.WitnessPhone = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.Witness = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.DisuseDescribe = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.ReportDate = new System.Windows.Forms.DateTimePicker();
            this.WaterFee = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.WaterPrice = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.WaterNum = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uC_UserMeterDetails1 = new SysControl.UC_UserMeterDetails();
            this.uC_UserSearch1 = new SysControl.UC_UserSearch();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_UserSearch1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(945, 618);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uC_UserMeterDetails1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(403, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 384F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(539, 612);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.WitnessPhone);
            this.panel2.Controls.Add(this.Witness);
            this.panel2.Controls.Add(this.DisuseDescribe);
            this.panel2.Controls.Add(this.ReportDate);
            this.panel2.Controls.Add(this.WaterFee);
            this.panel2.Controls.Add(this.WaterPrice);
            this.panel2.Controls.Add(this.WaterNum);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Btn_Submit);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(533, 222);
            this.panel2.TabIndex = 5;
            // 
            // WitnessPhone
            // 
            this.WitnessPhone.AllowEmpty = true;
            this.WitnessPhone.EmptyMessage = "";
            this.WitnessPhone.ErrorMessage = "";
            this.WitnessPhone.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.WitnessPhone.Location = new System.Drawing.Point(102, 133);
            this.WitnessPhone.Name = "WitnessPhone";
            this.WitnessPhone.RegexExpression = "";
            this.WitnessPhone.RemoveSpace = false;
            this.WitnessPhone.Size = new System.Drawing.Size(253, 21);
            this.WitnessPhone.TabIndex = 26;
            this.WitnessPhone.ValidateState = false;
            // 
            // Witness
            // 
            this.Witness.AllowEmpty = true;
            this.Witness.EmptyMessage = "";
            this.Witness.ErrorMessage = "";
            this.Witness.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.Witness.Location = new System.Drawing.Point(101, 103);
            this.Witness.Name = "Witness";
            this.Witness.RegexExpression = "";
            this.Witness.RemoveSpace = false;
            this.Witness.Size = new System.Drawing.Size(183, 21);
            this.Witness.TabIndex = 24;
            this.Witness.ValidateState = false;
            // 
            // DisuseDescribe
            // 
            this.DisuseDescribe.AllowEmpty = false;
            this.DisuseDescribe.EmptyMessage = "";
            this.DisuseDescribe.ErrorMessage = "";
            this.DisuseDescribe.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.DisuseDescribe.Location = new System.Drawing.Point(101, 13);
            this.DisuseDescribe.Multiline = true;
            this.DisuseDescribe.Name = "DisuseDescribe";
            this.DisuseDescribe.RegexExpression = "";
            this.DisuseDescribe.RemoveSpace = false;
            this.DisuseDescribe.Size = new System.Drawing.Size(393, 47);
            this.DisuseDescribe.TabIndex = 20;
            this.DisuseDescribe.ValidateState = false;
            // 
            // ReportDate
            // 
            this.ReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ReportDate.Location = new System.Drawing.Point(358, 101);
            this.ReportDate.Name = "ReportDate";
            this.ReportDate.Size = new System.Drawing.Size(136, 21);
            this.ReportDate.TabIndex = 25;
            // 
            // WaterFee
            // 
            this.WaterFee.AllowEmpty = false;
            this.WaterFee.EmptyMessage = "";
            this.WaterFee.Enabled = false;
            this.WaterFee.ErrorMessage = "";
            this.WaterFee.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.货币;
            this.WaterFee.Location = new System.Drawing.Point(389, 69);
            this.WaterFee.Name = "WaterFee";
            this.WaterFee.RegexExpression = "";
            this.WaterFee.RemoveSpace = false;
            this.WaterFee.Size = new System.Drawing.Size(105, 21);
            this.WaterFee.TabIndex = 23;
            this.WaterFee.ValidateState = false;
            // 
            // WaterPrice
            // 
            this.WaterPrice.AllowEmpty = false;
            this.WaterPrice.EmptyMessage = "";
            this.WaterPrice.Enabled = false;
            this.WaterPrice.ErrorMessage = "";
            this.WaterPrice.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.货币;
            this.WaterPrice.Location = new System.Drawing.Point(248, 69);
            this.WaterPrice.Name = "WaterPrice";
            this.WaterPrice.RegexExpression = "";
            this.WaterPrice.RemoveSpace = false;
            this.WaterPrice.Size = new System.Drawing.Size(66, 21);
            this.WaterPrice.TabIndex = 22;
            this.WaterPrice.ValidateState = false;
            // 
            // WaterNum
            // 
            this.WaterNum.AllowEmpty = false;
            this.WaterNum.EmptyMessage = "";
            this.WaterNum.ErrorMessage = "";
            this.WaterNum.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.数字;
            this.WaterNum.Location = new System.Drawing.Point(101, 69);
            this.WaterNum.Name = "WaterNum";
            this.WaterNum.RegexExpression = "";
            this.WaterNum.RemoveSpace = false;
            this.WaterNum.Size = new System.Drawing.Size(100, 21);
            this.WaterNum.TabIndex = 21;
            this.WaterNum.ValidateState = false;
            this.WaterNum.TextChanged += new System.EventHandler(this.WaterNum_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "发现时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "单价：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "联系电话：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "发 现 人：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "水费合计：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "*补缴水量：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Submit.Enabled = false;
            this.Btn_Submit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.Location = new System.Drawing.Point(230, 170);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(108, 37);
            this.Btn_Submit.TabIndex = 27;
            this.Btn_Submit.Tag = "9999";
            this.Btn_Submit.Text = "提  交";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*违章说明：";
            // 
            // uC_UserMeterDetails1
            // 
            this.uC_UserMeterDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UserMeterDetails1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserMeterDetails1.Name = "uC_UserMeterDetails1";
            this.uC_UserMeterDetails1.Size = new System.Drawing.Size(533, 378);
            this.uC_UserMeterDetails1.TabIndex = 6;
            this.uC_UserMeterDetails1.Load += new System.EventHandler(this.uC_UserMeterDetails1_Load);
            // 
            // uC_UserSearch1
            // 
            this.uC_UserSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UserSearch1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserSearch1.Name = "uC_UserSearch1";
            this.uC_UserSearch1.Size = new System.Drawing.Size(394, 612);
            this.uC_UserSearch1.TabIndex = 8;
            this.uC_UserSearch1.BtnSearchEvent += new System.EventHandler(this.uC_UserSearch1_BtnSearchEvent);
            // 
            // Frm_Meter_Disuse_Add2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 618);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Frm_Meter_Disuse_Add2";
            this.Text = "用户报停（监察）";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label1;
        private SysControl.UC_UserMeterDetails uC_UserMeterDetails1;
        private SysControl.UC_UserSearch uC_UserSearch1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox WaterFee;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox WaterPrice;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox WaterNum;
        private System.Windows.Forms.DateTimePicker ReportDate;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox DisuseDescribe;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox WitnessPhone;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox Witness;
    }
}
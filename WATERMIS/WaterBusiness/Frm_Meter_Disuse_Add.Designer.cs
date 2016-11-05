namespace WaterBusiness
{
    partial class Frm_Meter_Disuse_Add
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_Num = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LB_Fee = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ApplyPhone = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ApplyUser = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.DisuseDescribe = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.uC_UserMeterDetails1 = new SysControl.UC_UserMeterDetails();
            this.uC_UserSearch1 = new SysControl.UC_UserSearch();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.19743F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.80257F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_UserSearch1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(932, 601);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uC_UserMeterDetails1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(359, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.63636F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(570, 595);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DisuseDescribe);
            this.panel1.Controls.Add(this.LB_Num);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.LB_Fee);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.ApplyPhone);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.ApplyUser);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 211);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(20, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 12);
            this.label1.TabIndex = 89;
            this.label1.Tag = "9999";
            this.label1.Text = "说明：如果欠费金额是正数，该用户不存在欠费。";
            // 
            // LB_Num
            // 
            this.LB_Num.AutoSize = true;
            this.LB_Num.Location = new System.Drawing.Point(257, 76);
            this.LB_Num.Name = "LB_Num";
            this.LB_Num.Size = new System.Drawing.Size(0, 12);
            this.LB_Num.TabIndex = 87;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 86;
            this.label8.Text = "欠费水量：";
            // 
            // LB_Fee
            // 
            this.LB_Fee.AutoSize = true;
            this.LB_Fee.Location = new System.Drawing.Point(92, 76);
            this.LB_Fee.Name = "LB_Fee";
            this.LB_Fee.Size = new System.Drawing.Size(0, 12);
            this.LB_Fee.TabIndex = 85;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 84;
            this.label10.Text = "欠费金额：";
            // 
            // ApplyPhone
            // 
            this.ApplyPhone.Location = new System.Drawing.Point(344, 133);
            this.ApplyPhone.Name = "ApplyPhone";
            this.ApplyPhone.Size = new System.Drawing.Size(157, 21);
            this.ApplyPhone.TabIndex = 83;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(265, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 82;
            this.label11.Text = " 联系电话：";
            // 
            // ApplyUser
            // 
            this.ApplyUser.Location = new System.Drawing.Point(94, 133);
            this.ApplyUser.Name = "ApplyUser";
            this.ApplyUser.Size = new System.Drawing.Size(157, 21);
            this.ApplyUser.TabIndex = 81;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 80;
            this.label12.Text = "抄 表 员：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 12);
            this.label13.TabIndex = 75;
            this.label13.Text = "*报停原因：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Submit.Enabled = false;
            this.Btn_Submit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.Location = new System.Drawing.Point(212, 166);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(108, 37);
            this.Btn_Submit.TabIndex = 74;
            this.Btn_Submit.Tag = "9999";
            this.Btn_Submit.Text = "提  交";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // DisuseDescribe
            // 
            this.DisuseDescribe.AllowEmpty = false;
            this.DisuseDescribe.EmptyMessage = "";
            this.DisuseDescribe.ErrorMessage = "";
            this.DisuseDescribe.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.DisuseDescribe.Location = new System.Drawing.Point(94, 12);
            this.DisuseDescribe.Multiline = true;
            this.DisuseDescribe.Name = "DisuseDescribe";
            this.DisuseDescribe.RegexExpression = "";
            this.DisuseDescribe.RemoveSpace = false;
            this.DisuseDescribe.Size = new System.Drawing.Size(407, 48);
            this.DisuseDescribe.TabIndex = 88;
            this.DisuseDescribe.ValidateState = false;
            // 
            // uC_UserMeterDetails1
            // 
            this.uC_UserMeterDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UserMeterDetails1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserMeterDetails1.Name = "uC_UserMeterDetails1";
            this.uC_UserMeterDetails1.Size = new System.Drawing.Size(564, 372);
            this.uC_UserMeterDetails1.TabIndex = 6;
            // 
            // uC_UserSearch1
            // 
            this.uC_UserSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UserSearch1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserSearch1.Name = "uC_UserSearch1";
            this.uC_UserSearch1.Size = new System.Drawing.Size(350, 595);
            this.uC_UserSearch1.TabIndex = 9;
            this.uC_UserSearch1.BtnSearchEvent += new System.EventHandler(this.uC_UserSearch1_BtnSearchEvent);
            // 
            // Frm_Meter_Disuse_Add
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(932, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Frm_Meter_Disuse_Add";
            this.Text = "用户报停（营业）";
            this.Load += new System.EventHandler(this.Frm_Meter_Disuse_Add_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SysControl.UC_UserSearch uC_UserSearch1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private SysControl.UC_UserMeterDetails uC_UserMeterDetails1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB_Num;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LB_Fee;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ApplyPhone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ApplyUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Btn_Submit;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox DisuseDescribe;
        private System.Windows.Forms.Label label1;

    }
}
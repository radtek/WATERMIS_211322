namespace WaterBusiness
{
    partial class Frm_User_Peccant_Add_JC
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
            this.userName = new System.Windows.Forms.TextBox();
            this.Memo = new System.Windows.Forms.TextBox();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.QueryKey = new System.Windows.Forms.TextBox();
            this.AcceptID = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WaterUserNO = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.waterUserName = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.PeccantAdress = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.PecantDescribe = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.ApplyPhone = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.ApplyUser = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.waterPhone = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.Enabled = false;
            this.userName.Location = new System.Drawing.Point(107, 256);
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Size = new System.Drawing.Size(144, 21);
            this.userName.TabIndex = 110;
            // 
            // Memo
            // 
            this.Memo.Location = new System.Drawing.Point(107, 228);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(326, 21);
            this.Memo.TabIndex = 17;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.Teal;
            this.Btn_Submit.FlatAppearance.BorderSize = 0;
            this.Btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Submit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.ForeColor = System.Drawing.Color.White;
            this.Btn_Submit.Location = new System.Drawing.Point(107, 305);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(113, 37);
            this.Btn_Submit.TabIndex = 17;
            this.Btn_Submit.Text = "提  交";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 109;
            this.label7.Text = "受 理 人：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 108;
            this.label6.Text = "备    注：";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(29, 137);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(71, 12);
            this.label74.TabIndex = 107;
            this.label74.Text = "*违章说明：";
            // 
            // QueryKey
            // 
            this.QueryKey.Location = new System.Drawing.Point(330, 25);
            this.QueryKey.Name = "QueryKey";
            this.QueryKey.Size = new System.Drawing.Size(103, 21);
            this.QueryKey.TabIndex = 102;
            this.QueryKey.Text = "123456";
            this.QueryKey.Visible = false;
            // 
            // AcceptID
            // 
            this.AcceptID.BackColor = System.Drawing.SystemColors.Control;
            this.AcceptID.Enabled = false;
            this.AcceptID.Location = new System.Drawing.Point(107, 23);
            this.AcceptID.Name = "AcceptID";
            this.AcceptID.ReadOnly = true;
            this.AcceptID.Size = new System.Drawing.Size(143, 21);
            this.AcceptID.TabIndex = 105;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(261, 28);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(65, 12);
            this.label79.TabIndex = 106;
            this.label79.Text = "查询密码：";
            this.label79.Visible = false;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(35, 28);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(65, 12);
            this.label85.TabIndex = 104;
            this.label85.Text = "受理编号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 98;
            this.label5.Text = " 用 户 名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 95;
            this.label4.Text = "*违章地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 94;
            this.label3.Text = "*发 现 人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 92;
            this.label2.Text = "*联系电话：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 90;
            this.label1.Text = "*户    号：";
            // 
            // WaterUserNO
            // 
            this.WaterUserNO.AllowEmpty = false;
            this.WaterUserNO.EmptyMessage = "";
            this.WaterUserNO.ErrorMessage = "";
            this.WaterUserNO.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.WaterUserNO.Location = new System.Drawing.Point(107, 51);
            this.WaterUserNO.Name = "WaterUserNO";
            this.WaterUserNO.RegexExpression = "";
            this.WaterUserNO.RemoveSpace = false;
            this.WaterUserNO.Size = new System.Drawing.Size(143, 21);
            this.WaterUserNO.TabIndex = 10;
            this.WaterUserNO.ValidateState = false;
            this.WaterUserNO.Leave += new System.EventHandler(this.WaterUserNO_Leave);
            // 
            // waterUserName
            // 
            this.waterUserName.AllowEmpty = true;
            this.waterUserName.EmptyMessage = "";
            this.waterUserName.ErrorMessage = "";
            this.waterUserName.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.waterUserName.Location = new System.Drawing.Point(330, 51);
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.RegexExpression = "";
            this.waterUserName.RemoveSpace = false;
            this.waterUserName.Size = new System.Drawing.Size(103, 21);
            this.waterUserName.TabIndex = 11;
            this.waterUserName.ValidateState = false;
            // 
            // PeccantAdress
            // 
            this.PeccantAdress.AllowEmpty = false;
            this.PeccantAdress.EmptyMessage = "";
            this.PeccantAdress.ErrorMessage = "";
            this.PeccantAdress.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.PeccantAdress.Location = new System.Drawing.Point(107, 107);
            this.PeccantAdress.Name = "PeccantAdress";
            this.PeccantAdress.RegexExpression = "";
            this.PeccantAdress.RemoveSpace = false;
            this.PeccantAdress.Size = new System.Drawing.Size(326, 21);
            this.PeccantAdress.TabIndex = 13;
            this.PeccantAdress.ValidateState = false;
            // 
            // PecantDescribe
            // 
            this.PecantDescribe.AllowEmpty = false;
            this.PecantDescribe.EmptyMessage = "";
            this.PecantDescribe.ErrorMessage = "";
            this.PecantDescribe.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.PecantDescribe.Location = new System.Drawing.Point(107, 135);
            this.PecantDescribe.Multiline = true;
            this.PecantDescribe.Name = "PecantDescribe";
            this.PecantDescribe.RegexExpression = "";
            this.PecantDescribe.RemoveSpace = false;
            this.PecantDescribe.Size = new System.Drawing.Size(326, 50);
            this.PecantDescribe.TabIndex = 14;
            this.PecantDescribe.ValidateState = false;
            // 
            // ApplyPhone
            // 
            this.ApplyPhone.AllowEmpty = false;
            this.ApplyPhone.EmptyMessage = "";
            this.ApplyPhone.ErrorMessage = "";
            this.ApplyPhone.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.ApplyPhone.Location = new System.Drawing.Point(330, 201);
            this.ApplyPhone.Name = "ApplyPhone";
            this.ApplyPhone.RegexExpression = "";
            this.ApplyPhone.RemoveSpace = false;
            this.ApplyPhone.Size = new System.Drawing.Size(103, 21);
            this.ApplyPhone.TabIndex = 16;
            this.ApplyPhone.ValidateState = false;
            // 
            // ApplyUser
            // 
            this.ApplyUser.AllowEmpty = false;
            this.ApplyUser.EmptyMessage = "";
            this.ApplyUser.ErrorMessage = "";
            this.ApplyUser.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.ApplyUser.Location = new System.Drawing.Point(107, 201);
            this.ApplyUser.Name = "ApplyUser";
            this.ApplyUser.RegexExpression = "";
            this.ApplyUser.RemoveSpace = false;
            this.ApplyUser.Size = new System.Drawing.Size(144, 21);
            this.ApplyUser.TabIndex = 15;
            this.ApplyUser.ValidateState = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 111;
            this.label8.Text = "*联系电话：";
            // 
            // waterPhone
            // 
            this.waterPhone.AllowEmpty = false;
            this.waterPhone.EmptyMessage = "";
            this.waterPhone.ErrorMessage = "";
            this.waterPhone.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.waterPhone.Location = new System.Drawing.Point(106, 79);
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.RegexExpression = "";
            this.waterPhone.RemoveSpace = false;
            this.waterPhone.Size = new System.Drawing.Size(143, 21);
            this.waterPhone.TabIndex = 12;
            this.waterPhone.ValidateState = false;
            // 
            // Frm_User_Peccant_Add_JC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 368);
            this.Controls.Add(this.waterPhone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ApplyUser);
            this.Controls.Add(this.ApplyPhone);
            this.Controls.Add(this.PecantDescribe);
            this.Controls.Add(this.PeccantAdress);
            this.Controls.Add(this.waterUserName);
            this.Controls.Add(this.WaterUserNO);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.Memo);
            this.Controls.Add(this.Btn_Submit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label74);
            this.Controls.Add(this.QueryKey);
            this.Controls.Add(this.AcceptID);
            this.Controls.Add(this.label79);
            this.Controls.Add(this.label85);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_User_Peccant_Add_JC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "违章处罚-监察";
            this.Load += new System.EventHandler(this.Frm_User_Peccant_Add_JC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox QueryKey;
        private System.Windows.Forms.TextBox AcceptID;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox WaterUserNO;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterUserName;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox PeccantAdress;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox PecantDescribe;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox ApplyPhone;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox ApplyUser;
        private System.Windows.Forms.Label label8;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterPhone;
    }
}
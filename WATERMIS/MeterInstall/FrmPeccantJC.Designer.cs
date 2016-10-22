namespace MeterInstall
{
    partial class FrmPeccantJC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPeccantJC));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.waterPhone = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.waterUserNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.contractNO = new System.Windows.Forms.TextBox();
            this.waterUserPeopleCount = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.ApplyUser = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.waterUserHouseType = new System.Windows.Forms.ComboBox();
            this.PeccantMemo = new System.Windows.Forms.TextBox();
            this.waterUserName = new System.Windows.Forms.TextBox();
            this.waterUserAddress = new System.Windows.Forms.TextBox();
            this.waterUserTypeId = new System.Windows.Forms.ComboBox();
            this.QueryKey = new System.Windows.Forms.TextBox();
            this.AcceptID = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.waterPhone);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.waterUserNO);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.userName);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.Btn_Submit);
            this.groupBox6.Controls.Add(this.contractNO);
            this.groupBox6.Controls.Add(this.waterUserPeopleCount);
            this.groupBox6.Controls.Add(this.label71);
            this.groupBox6.Controls.Add(this.ApplyUser);
            this.groupBox6.Controls.Add(this.label73);
            this.groupBox6.Controls.Add(this.waterUserHouseType);
            this.groupBox6.Controls.Add(this.PeccantMemo);
            this.groupBox6.Controls.Add(this.waterUserName);
            this.groupBox6.Controls.Add(this.waterUserAddress);
            this.groupBox6.Controls.Add(this.waterUserTypeId);
            this.groupBox6.Controls.Add(this.QueryKey);
            this.groupBox6.Controls.Add(this.AcceptID);
            this.groupBox6.Controls.Add(this.label74);
            this.groupBox6.Controls.Add(this.label78);
            this.groupBox6.Controls.Add(this.label79);
            this.groupBox6.Controls.Add(this.label80);
            this.groupBox6.Controls.Add(this.label83);
            this.groupBox6.Controls.Add(this.label84);
            this.groupBox6.Controls.Add(this.label85);
            this.groupBox6.Controls.Add(this.label86);
            this.groupBox6.Controls.Add(this.label87);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(635, 322);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "用户详细信息";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(428, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 30);
            this.label4.TabIndex = 84;
            this.label4.Tag = "9999";
            this.label4.Text = "监察提交入口";
            // 
            // waterPhone
            // 
            this.waterPhone.AllowEmpty = true;
            this.waterPhone.EmptyMessage = "";
            this.waterPhone.ErrorMessage = "";
            this.waterPhone.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.手机号;
            this.waterPhone.Location = new System.Drawing.Point(84, 118);
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.RegexExpression = "";
            this.waterPhone.RemoveSpace = false;
            this.waterPhone.Size = new System.Drawing.Size(99, 21);
            this.waterPhone.TabIndex = 83;
            this.waterPhone.ValidateState = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 12);
            this.label3.TabIndex = 82;
            this.label3.Text = "*说明:如果是新用户报装，用户号留空";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // waterUserNO
            // 
            this.waterUserNO.Location = new System.Drawing.Point(84, 28);
            this.waterUserNO.Name = "waterUserNO";
            this.waterUserNO.ReadOnly = true;
            this.waterUserNO.Size = new System.Drawing.Size(99, 21);
            this.waterUserNO.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 80;
            this.label1.Text = "用 户 号：";
            // 
            // userName
            // 
            this.userName.Enabled = false;
            this.userName.Location = new System.Drawing.Point(445, 150);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(78, 21);
            this.userName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 79;
            this.label2.Text = "*受理人：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.Teal;
            this.Btn_Submit.FlatAppearance.BorderSize = 0;
            this.Btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Submit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.ForeColor = System.Drawing.Color.White;
            this.Btn_Submit.Location = new System.Drawing.Point(222, 275);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(99, 30);
            this.Btn_Submit.TabIndex = 12;
            this.Btn_Submit.Tag = "9999";
            this.Btn_Submit.Text = "提交申请";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // contractNO
            // 
            this.contractNO.Location = new System.Drawing.Point(288, 120);
            this.contractNO.Name = "contractNO";
            this.contractNO.Size = new System.Drawing.Size(235, 21);
            this.contractNO.TabIndex = 4;
            // 
            // waterUserPeopleCount
            // 
            this.waterUserPeopleCount.Location = new System.Drawing.Point(84, 148);
            this.waterUserPeopleCount.Name = "waterUserPeopleCount";
            this.waterUserPeopleCount.Size = new System.Drawing.Size(99, 21);
            this.waterUserPeopleCount.TabIndex = 5;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(16, 154);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(65, 12);
            this.label71.TabIndex = 66;
            this.label71.Text = "用水人数：";
            // 
            // ApplyUser
            // 
            this.ApplyUser.Location = new System.Drawing.Point(288, 149);
            this.ApplyUser.Name = "ApplyUser";
            this.ApplyUser.Size = new System.Drawing.Size(78, 21);
            this.ApplyUser.TabIndex = 6;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(220, 124);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(65, 12);
            this.label73.TabIndex = 61;
            this.label73.Text = "合同编号：";
            // 
            // waterUserHouseType
            // 
            this.waterUserHouseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterUserHouseType.FormattingEnabled = true;
            this.waterUserHouseType.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.waterUserHouseType.Location = new System.Drawing.Point(288, 179);
            this.waterUserHouseType.Name = "waterUserHouseType";
            this.waterUserHouseType.Size = new System.Drawing.Size(78, 20);
            this.waterUserHouseType.TabIndex = 9;
            // 
            // PeccantMemo
            // 
            this.PeccantMemo.Location = new System.Drawing.Point(84, 208);
            this.PeccantMemo.Multiline = true;
            this.PeccantMemo.Name = "PeccantMemo";
            this.PeccantMemo.Size = new System.Drawing.Size(439, 57);
            this.PeccantMemo.TabIndex = 11;
            // 
            // waterUserName
            // 
            this.waterUserName.Location = new System.Drawing.Point(288, 60);
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.Size = new System.Drawing.Size(236, 21);
            this.waterUserName.TabIndex = 1;
            this.waterUserName.TextChanged += new System.EventHandler(this.waterUserName_TextChanged);
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.Location = new System.Drawing.Point(288, 89);
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.Size = new System.Drawing.Size(236, 21);
            this.waterUserAddress.TabIndex = 2;
            // 
            // waterUserTypeId
            // 
            this.waterUserTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterUserTypeId.DropDownWidth = 150;
            this.waterUserTypeId.FormattingEnabled = true;
            this.waterUserTypeId.Location = new System.Drawing.Point(84, 178);
            this.waterUserTypeId.Name = "waterUserTypeId";
            this.waterUserTypeId.Size = new System.Drawing.Size(97, 20);
            this.waterUserTypeId.TabIndex = 8;
            // 
            // QueryKey
            // 
            this.QueryKey.Location = new System.Drawing.Point(84, 88);
            this.QueryKey.Name = "QueryKey";
            this.QueryKey.Size = new System.Drawing.Size(99, 21);
            this.QueryKey.TabIndex = 28;
            this.QueryKey.Text = "123456";
            // 
            // AcceptID
            // 
            this.AcceptID.BackColor = System.Drawing.SystemColors.Control;
            this.AcceptID.Enabled = false;
            this.AcceptID.Location = new System.Drawing.Point(84, 58);
            this.AcceptID.Name = "AcceptID";
            this.AcceptID.ReadOnly = true;
            this.AcceptID.Size = new System.Drawing.Size(99, 21);
            this.AcceptID.TabIndex = 25;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(10, 214);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(71, 12);
            this.label74.TabIndex = 57;
            this.label74.Text = "*违章说明：";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(220, 154);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(65, 12);
            this.label78.TabIndex = 35;
            this.label78.Text = "申 请 人：";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(16, 94);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(65, 12);
            this.label79.TabIndex = 32;
            this.label79.Text = "查询密码：";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(10, 122);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(71, 12);
            this.label80.TabIndex = 30;
            this.label80.Text = "*联系方式：";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(214, 94);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(71, 12);
            this.label83.TabIndex = 28;
            this.label83.Text = "*地    址：";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(214, 64);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(71, 12);
            this.label84.TabIndex = 26;
            this.label84.Text = "*用户名称：";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(16, 64);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(65, 12);
            this.label85.TabIndex = 24;
            this.label85.Text = "受理编号：";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(220, 183);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(65, 12);
            this.label86.TabIndex = 53;
            this.label86.Text = "户    型：";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(10, 182);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(71, 12);
            this.label87.TabIndex = 28;
            this.label87.Text = "*用户类别：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(10, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 85;
            this.label5.Tag = "9999";
            this.label5.Text = "(限200字内)";
            // 
            // FrmPeccantJC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(635, 322);
            this.Controls.Add(this.groupBox6);
            this.Name = "FrmPeccantJC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "违章用户报装监察入口";
            this.Load += new System.EventHandler(this.FrmPeccant_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.TextBox contractNO;
        private System.Windows.Forms.TextBox waterUserPeopleCount;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox ApplyUser;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.ComboBox waterUserHouseType;
        private System.Windows.Forms.TextBox PeccantMemo;
        private System.Windows.Forms.TextBox waterUserName;
        private System.Windows.Forms.TextBox waterUserAddress;
        private System.Windows.Forms.ComboBox waterUserTypeId;
        private System.Windows.Forms.TextBox QueryKey;
        private System.Windows.Forms.TextBox AcceptID;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox waterUserNO;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;



    }
}
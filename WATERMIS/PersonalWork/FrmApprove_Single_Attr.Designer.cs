namespace PersonalWork
{
    partial class FrmApprove_Single_Attr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Single_Attr));
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.PL = new System.Windows.Forms.Panel();
            this.IsBoost = new System.Windows.Forms.CheckBox();
            this.waterUserPeopleCount = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.waterUserHouseType = new System.Windows.Forms.ComboBox();
            this.Memo = new System.Windows.Forms.TextBox();
            this.waterUserName = new System.Windows.Forms.TextBox();
            this.waterUserAddress = new System.Windows.Forms.TextBox();
            this.waterUserTypeId = new System.Windows.Forms.ComboBox();
            this.waterPhone = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.PL.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.SeaGreen;
            this.Btn_Submit.FlatAppearance.BorderSize = 0;
            this.Btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Submit.Font = new System.Drawing.Font("微软雅黑 Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.ForeColor = System.Drawing.Color.White;
            this.Btn_Submit.Location = new System.Drawing.Point(173, 417);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(129, 41);
            this.Btn_Submit.TabIndex = 8;
            this.Btn_Submit.Text = "信息确认";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // PL
            // 
            this.PL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PL.BackgroundImage")));
            this.PL.Controls.Add(this.IsBoost);
            this.PL.Controls.Add(this.waterUserPeopleCount);
            this.PL.Controls.Add(this.label71);
            this.PL.Controls.Add(this.waterUserHouseType);
            this.PL.Controls.Add(this.Memo);
            this.PL.Controls.Add(this.waterUserName);
            this.PL.Controls.Add(this.waterUserAddress);
            this.PL.Controls.Add(this.waterUserTypeId);
            this.PL.Controls.Add(this.waterPhone);
            this.PL.Controls.Add(this.label74);
            this.PL.Controls.Add(this.label80);
            this.PL.Controls.Add(this.label83);
            this.PL.Controls.Add(this.label84);
            this.PL.Controls.Add(this.label86);
            this.PL.Controls.Add(this.label87);
            this.PL.Dock = System.Windows.Forms.DockStyle.Top;
            this.PL.Location = new System.Drawing.Point(0, 0);
            this.PL.Name = "PL";
            this.PL.Size = new System.Drawing.Size(510, 132);
            this.PL.TabIndex = 9;
            // 
            // IsBoost
            // 
            this.IsBoost.AutoSize = true;
            this.IsBoost.BackColor = System.Drawing.Color.Transparent;
            this.IsBoost.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IsBoost.BackgroundImage")));
            this.IsBoost.Location = new System.Drawing.Point(358, 70);
            this.IsBoost.Name = "IsBoost";
            this.IsBoost.Size = new System.Drawing.Size(72, 16);
            this.IsBoost.TabIndex = 103;
            this.IsBoost.Text = "是否加压";
            this.IsBoost.UseVisualStyleBackColor = false;
            // 
            // waterUserPeopleCount
            // 
            this.waterUserPeopleCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waterUserPeopleCount.Location = new System.Drawing.Point(77, 41);
            this.waterUserPeopleCount.Name = "waterUserPeopleCount";
            this.waterUserPeopleCount.Size = new System.Drawing.Size(99, 21);
            this.waterUserPeopleCount.TabIndex = 101;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.Location = new System.Drawing.Point(11, 45);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(65, 12);
            this.label71.TabIndex = 102;
            this.label71.Text = "用水人数：";
            // 
            // waterUserHouseType
            // 
            this.waterUserHouseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterUserHouseType.FormattingEnabled = true;
            this.waterUserHouseType.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.waterUserHouseType.Location = new System.Drawing.Point(257, 68);
            this.waterUserHouseType.Name = "waterUserHouseType";
            this.waterUserHouseType.Size = new System.Drawing.Size(78, 20);
            this.waterUserHouseType.TabIndex = 98;
            // 
            // Memo
            // 
            this.Memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Memo.Location = new System.Drawing.Point(77, 97);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(235, 21);
            this.Memo.TabIndex = 95;
            // 
            // waterUserName
            // 
            this.waterUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waterUserName.Location = new System.Drawing.Point(257, 11);
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.Size = new System.Drawing.Size(236, 21);
            this.waterUserName.TabIndex = 84;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waterUserAddress.Location = new System.Drawing.Point(257, 41);
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.Size = new System.Drawing.Size(236, 21);
            this.waterUserAddress.TabIndex = 88;
            // 
            // waterUserTypeId
            // 
            this.waterUserTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterUserTypeId.DropDownWidth = 150;
            this.waterUserTypeId.FormattingEnabled = true;
            this.waterUserTypeId.Location = new System.Drawing.Point(77, 69);
            this.waterUserTypeId.Name = "waterUserTypeId";
            this.waterUserTypeId.Size = new System.Drawing.Size(97, 20);
            this.waterUserTypeId.TabIndex = 96;
            // 
            // waterPhone
            // 
            this.waterPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waterPhone.Location = new System.Drawing.Point(77, 11);
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.Size = new System.Drawing.Size(99, 21);
            this.waterPhone.TabIndex = 89;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.Transparent;
            this.label74.Location = new System.Drawing.Point(11, 101);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(65, 12);
            this.label74.TabIndex = 99;
            this.label74.Text = "备    注：";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.Location = new System.Drawing.Point(5, 15);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(71, 12);
            this.label80.TabIndex = 90;
            this.label80.Text = "*联系方式：";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.BackColor = System.Drawing.Color.Transparent;
            this.label83.Location = new System.Drawing.Point(182, 45);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(71, 12);
            this.label83.TabIndex = 87;
            this.label83.Text = "*地    址：";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.Location = new System.Drawing.Point(182, 15);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(71, 12);
            this.label84.TabIndex = 83;
            this.label84.Text = "*用户名称：";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Location = new System.Drawing.Point(188, 72);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(65, 12);
            this.label86.TabIndex = 97;
            this.label86.Text = "户    型：";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.BackColor = System.Drawing.Color.Transparent;
            this.label87.Location = new System.Drawing.Point(5, 72);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(71, 12);
            this.label87.TabIndex = 85;
            this.label87.Text = "*用户类别：";
            // 
            // FP
            // 
            this.FP.AutoScroll = true;
            this.FP.BackColor = System.Drawing.Color.Transparent;
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.Dock = System.Windows.Forms.DockStyle.Top;
            this.FP.Location = new System.Drawing.Point(0, 132);
            this.FP.Name = "FP";
            this.FP.Size = new System.Drawing.Size(510, 273);
            this.FP.TabIndex = 10;
            // 
            // FrmApprove_Single_Attr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(510, 470);
            this.Controls.Add(this.FP);
            this.Controls.Add(this.PL);
            this.Controls.Add(this.Btn_Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmApprove_Single_Attr";
            this.Text = "FrmApprove_Single_Attr";
            this.Load += new System.EventHandler(this.FrmApprove_Single_Attr_Load);
            this.PL.ResumeLayout(false);
            this.PL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Panel PL;
        private System.Windows.Forms.CheckBox IsBoost;
        private System.Windows.Forms.TextBox waterUserPeopleCount;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.ComboBox waterUserHouseType;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.TextBox waterUserName;
        private System.Windows.Forms.TextBox waterUserAddress;
        private System.Windows.Forms.ComboBox waterUserTypeId;
        private System.Windows.Forms.TextBox waterPhone;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.FlowLayoutPanel FP;
    }
}
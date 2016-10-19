namespace ApproveCenter
{
    partial class FrmUser_WaterPrice_Add
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
            this.readMeterRecordId = new System.Windows.Forms.TextBox();
            this.meterReaderName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.waterMeterTypeId = new System.Windows.Forms.ComboBox();
            this.IsLong = new System.Windows.Forms.CheckBox();
            this.IsMonth = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.waterUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.waterMeterType_New = new System.Windows.Forms.ComboBox();
            this.WaterPriceDescribe = new System.Windows.Forms.TextBox();
            this.waterPhone = new System.Windows.Forms.TextBox();
            this.waterUserAddress = new System.Windows.Forms.TextBox();
            this.WATERUSERNO = new System.Windows.Forms.TextBox();
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
            this.panel1.Controls.Add(this.readMeterRecordId);
            this.panel1.Controls.Add(this.meterReaderName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.waterMeterTypeId);
            this.panel1.Controls.Add(this.IsLong);
            this.panel1.Controls.Add(this.IsMonth);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.waterUserName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Btn_Search);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.waterMeterType_New);
            this.panel1.Controls.Add(this.WaterPriceDescribe);
            this.panel1.Controls.Add(this.waterPhone);
            this.panel1.Controls.Add(this.waterUserAddress);
            this.panel1.Controls.Add(this.WATERUSERNO);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 423);
            this.panel1.TabIndex = 1;
            this.panel1.Tag = "9999";
            // 
            // readMeterRecordId
            // 
            this.readMeterRecordId.Location = new System.Drawing.Point(281, 93);
            this.readMeterRecordId.Name = "readMeterRecordId";
            this.readMeterRecordId.Size = new System.Drawing.Size(171, 21);
            this.readMeterRecordId.TabIndex = 22;
            this.readMeterRecordId.Visible = false;
            // 
            // meterReaderName
            // 
            this.meterReaderName.Enabled = false;
            this.meterReaderName.Location = new System.Drawing.Point(136, 93);
            this.meterReaderName.Name = "meterReaderName";
            this.meterReaderName.Size = new System.Drawing.Size(117, 21);
            this.meterReaderName.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "*抄 表 员：";
            // 
            // waterMeterTypeId
            // 
            this.waterMeterTypeId.Enabled = false;
            this.waterMeterTypeId.FormattingEnabled = true;
            this.waterMeterTypeId.Location = new System.Drawing.Point(136, 164);
            this.waterMeterTypeId.Name = "waterMeterTypeId";
            this.waterMeterTypeId.Size = new System.Drawing.Size(186, 20);
            this.waterMeterTypeId.TabIndex = 19;
            // 
            // IsLong
            // 
            this.IsLong.AutoSize = true;
            this.IsLong.Location = new System.Drawing.Point(246, 331);
            this.IsLong.Name = "IsLong";
            this.IsLong.Size = new System.Drawing.Size(144, 16);
            this.IsLong.TabIndex = 18;
            this.IsLong.Text = "长期变更（下月生效）";
            this.IsLong.UseVisualStyleBackColor = true;
            // 
            // IsMonth
            // 
            this.IsMonth.AutoSize = true;
            this.IsMonth.Checked = true;
            this.IsMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsMonth.Location = new System.Drawing.Point(136, 331);
            this.IsMonth.Name = "IsMonth";
            this.IsMonth.Size = new System.Drawing.Size(72, 16);
            this.IsMonth.TabIndex = 17;
            this.IsMonth.Text = "变更当月";
            this.IsMonth.UseVisualStyleBackColor = true;
            this.IsMonth.CheckedChanged += new System.EventHandler(this.IsMonth_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "联系电话：";
            // 
            // waterUserName
            // 
            this.waterUserName.Enabled = false;
            this.waterUserName.Location = new System.Drawing.Point(136, 57);
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.Size = new System.Drawing.Size(117, 21);
            this.waterUserName.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "用 户 名：";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(266, 23);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(65, 23);
            this.Btn_Search.TabIndex = 11;
            this.Btn_Search.Text = "查询";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(184, 368);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(114, 38);
            this.Btn_Submit.TabIndex = 10;
            this.Btn_Submit.Text = "提  交";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // waterMeterType_New
            // 
            this.waterMeterType_New.FormattingEnabled = true;
            this.waterMeterType_New.Location = new System.Drawing.Point(136, 198);
            this.waterMeterType_New.Name = "waterMeterType_New";
            this.waterMeterType_New.Size = new System.Drawing.Size(186, 20);
            this.waterMeterType_New.TabIndex = 9;
            // 
            // WaterPriceDescribe
            // 
            this.WaterPriceDescribe.Location = new System.Drawing.Point(136, 233);
            this.WaterPriceDescribe.Multiline = true;
            this.WaterPriceDescribe.Name = "WaterPriceDescribe";
            this.WaterPriceDescribe.Size = new System.Drawing.Size(316, 80);
            this.WaterPriceDescribe.TabIndex = 8;
            // 
            // waterPhone
            // 
            this.waterPhone.Location = new System.Drawing.Point(335, 57);
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.Size = new System.Drawing.Size(117, 21);
            this.waterPhone.TabIndex = 7;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.Enabled = false;
            this.waterUserAddress.Location = new System.Drawing.Point(136, 128);
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.Size = new System.Drawing.Size(316, 21);
            this.waterUserAddress.TabIndex = 6;
            // 
            // WATERUSERNO
            // 
            this.WATERUSERNO.Location = new System.Drawing.Point(136, 24);
            this.WATERUSERNO.Name = "WATERUSERNO";
            this.WATERUSERNO.Size = new System.Drawing.Size(117, 21);
            this.WATERUSERNO.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "变更后用水性质：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "*变更原因：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "原用水性质：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "地    址：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*用 户 号：";
            // 
            // FrmUser_WaterPrice_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 423);
            this.Controls.Add(this.panel1);
            this.Name = "FrmUser_WaterPrice_Add";
            this.Text = "变更水价申请";
            this.Load += new System.EventHandler(this.FrmUser_WaterPrice_Add_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox waterUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.ComboBox waterMeterType_New;
        private System.Windows.Forms.TextBox WaterPriceDescribe;
        private System.Windows.Forms.TextBox waterPhone;
        private System.Windows.Forms.TextBox waterUserAddress;
        private System.Windows.Forms.TextBox WATERUSERNO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox IsLong;
        private System.Windows.Forms.CheckBox IsMonth;
        private System.Windows.Forms.ComboBox waterMeterTypeId;
        private System.Windows.Forms.TextBox meterReaderName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox readMeterRecordId;
    }
}
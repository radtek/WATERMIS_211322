namespace MeterInstall
{
    partial class FrmGroupPeople
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
            this.IsBoot = new System.Windows.Forms.CheckBox();
            this.UserCount_Apply = new System.Windows.Forms.MaskedTextBox();
            this.waterUserHouseTypeID = new System.Windows.Forms.ComboBox();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.waterMeterTypeId = new System.Windows.Forms.ComboBox();
            this.waterUserTypeId = new System.Windows.Forms.ComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IsBoot);
            this.panel1.Controls.Add(this.UserCount_Apply);
            this.panel1.Controls.Add(this.waterUserHouseTypeID);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.waterMeterTypeId);
            this.panel1.Controls.Add(this.waterUserTypeId);
            this.panel1.Controls.Add(this.label86);
            this.panel1.Controls.Add(this.label87);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 290);
            this.panel1.TabIndex = 0;
            // 
            // IsBoot
            // 
            this.IsBoot.AutoSize = true;
            this.IsBoot.Location = new System.Drawing.Point(137, 189);
            this.IsBoot.Name = "IsBoot";
            this.IsBoot.Size = new System.Drawing.Size(72, 16);
            this.IsBoot.TabIndex = 76;
            this.IsBoot.Text = "是否加压";
            this.IsBoot.UseVisualStyleBackColor = true;
            // 
            // UserCount_Apply
            // 
            this.UserCount_Apply.Location = new System.Drawing.Point(137, 149);
            this.UserCount_Apply.Mask = "9999";
            this.UserCount_Apply.Name = "UserCount_Apply";
            this.UserCount_Apply.Size = new System.Drawing.Size(100, 21);
            this.UserCount_Apply.TabIndex = 75;
            this.UserCount_Apply.Text = "1";
            // 
            // waterUserHouseTypeID
            // 
            this.waterUserHouseTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterUserHouseTypeID.FormattingEnabled = true;
            this.waterUserHouseTypeID.Location = new System.Drawing.Point(137, 106);
            this.waterUserHouseTypeID.Name = "waterUserHouseTypeID";
            this.waterUserHouseTypeID.Size = new System.Drawing.Size(168, 20);
            this.waterUserHouseTypeID.TabIndex = 74;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(143, 231);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(101, 33);
            this.Btn_Submit.TabIndex = 73;
            this.Btn_Submit.Text = "保  存";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 72;
            this.label3.Text = "户    型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 71;
            this.label2.Text = "是否加压：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 70;
            this.label1.Text = "*用户数量：";
            // 
            // waterMeterTypeId
            // 
            this.waterMeterTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterMeterTypeId.FormattingEnabled = true;
            this.waterMeterTypeId.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.waterMeterTypeId.Location = new System.Drawing.Point(137, 66);
            this.waterMeterTypeId.Name = "waterMeterTypeId";
            this.waterMeterTypeId.Size = new System.Drawing.Size(168, 20);
            this.waterMeterTypeId.TabIndex = 69;
            // 
            // waterUserTypeId
            // 
            this.waterUserTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterUserTypeId.DropDownWidth = 150;
            this.waterUserTypeId.FormattingEnabled = true;
            this.waterUserTypeId.Location = new System.Drawing.Point(137, 26);
            this.waterUserTypeId.Name = "waterUserTypeId";
            this.waterUserTypeId.Size = new System.Drawing.Size(168, 20);
            this.waterUserTypeId.TabIndex = 67;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(60, 69);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(71, 12);
            this.label86.TabIndex = 68;
            this.label86.Text = "*用水性质：";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(60, 29);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(71, 12);
            this.label87.TabIndex = 66;
            this.label87.Text = "*用户类别：";
            // 
            // FrmGroupPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 290);
            this.Controls.Add(this.panel1);
            this.Name = "FrmGroupPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单位报装-用户添加";
            this.Load += new System.EventHandler(this.FrmGroupPeople_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox IsBoot;
        private System.Windows.Forms.MaskedTextBox UserCount_Apply;
        private System.Windows.Forms.ComboBox waterUserHouseTypeID;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox waterMeterTypeId;
        private System.Windows.Forms.ComboBox waterUserTypeId;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;

    }
}
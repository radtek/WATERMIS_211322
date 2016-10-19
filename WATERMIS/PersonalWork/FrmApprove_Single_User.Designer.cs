namespace PersonalWork
{
    partial class FrmApprove_Single_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Single_User));
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.PL = new System.Windows.Forms.Panel();
            this.LB_MeterInfo = new System.Windows.Forms.Label();
            this.memo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ordernumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chargeType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BankAcountNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bankId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.agentsign = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.meterReadingPageNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.meterReadingID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UnitNO = new System.Windows.Forms.TextBox();
            this.BuildingNO = new System.Windows.Forms.TextBox();
            this.COMMUNITYID = new System.Windows.Forms.ComboBox();
            this.DUANID = new System.Windows.Forms.ComboBox();
            this.PIANID = new System.Windows.Forms.ComboBox();
            this.areaId = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.CreateTypeID = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.meterReaderID = new System.Windows.Forms.ComboBox();
            this.chargerID = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
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
            this.Btn_Submit.Location = new System.Drawing.Point(185, 418);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(129, 41);
            this.Btn_Submit.TabIndex = 7;
            this.Btn_Submit.Text = "确定增户";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // PL
            // 
            this.PL.AutoScroll = true;
            this.PL.BackColor = System.Drawing.Color.Transparent;
            this.PL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PL.BackgroundImage")));
            this.PL.Controls.Add(this.meterReaderID);
            this.PL.Controls.Add(this.chargerID);
            this.PL.Controls.Add(this.label22);
            this.PL.Controls.Add(this.label55);
            this.PL.Controls.Add(this.CreateTypeID);
            this.PL.Controls.Add(this.label54);
            this.PL.Controls.Add(this.UnitNO);
            this.PL.Controls.Add(this.BuildingNO);
            this.PL.Controls.Add(this.COMMUNITYID);
            this.PL.Controls.Add(this.DUANID);
            this.PL.Controls.Add(this.PIANID);
            this.PL.Controls.Add(this.areaId);
            this.PL.Controls.Add(this.label49);
            this.PL.Controls.Add(this.label9);
            this.PL.Controls.Add(this.label52);
            this.PL.Controls.Add(this.label38);
            this.PL.Controls.Add(this.label53);
            this.PL.Controls.Add(this.label45);
            this.PL.Controls.Add(this.LB_MeterInfo);
            this.PL.Controls.Add(this.memo);
            this.PL.Controls.Add(this.label8);
            this.PL.Controls.Add(this.ordernumber);
            this.PL.Controls.Add(this.label7);
            this.PL.Controls.Add(this.chargeType);
            this.PL.Controls.Add(this.label6);
            this.PL.Controls.Add(this.BankAcountNumber);
            this.PL.Controls.Add(this.label5);
            this.PL.Controls.Add(this.bankId);
            this.PL.Controls.Add(this.label4);
            this.PL.Controls.Add(this.agentsign);
            this.PL.Controls.Add(this.label3);
            this.PL.Dock = System.Windows.Forms.DockStyle.Top;
            this.PL.Location = new System.Drawing.Point(0, 0);
            this.PL.Name = "PL";
            this.PL.Size = new System.Drawing.Size(510, 407);
            this.PL.TabIndex = 8;
            this.PL.Paint += new System.Windows.Forms.PaintEventHandler(this.PL_Paint);
            // 
            // LB_MeterInfo
            // 
            this.LB_MeterInfo.AutoSize = true;
            this.LB_MeterInfo.BackColor = System.Drawing.Color.White;
            this.LB_MeterInfo.Location = new System.Drawing.Point(39, 338);
            this.LB_MeterInfo.Name = "LB_MeterInfo";
            this.LB_MeterInfo.Size = new System.Drawing.Size(65, 12);
            this.LB_MeterInfo.TabIndex = 16;
            this.LB_MeterInfo.Text = "水表编号：";
            // 
            // memo
            // 
            this.memo.Location = new System.Drawing.Point(110, 296);
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(355, 21);
            this.memo.TabIndex = 15;
            this.memo.TextChanged += new System.EventHandler(this.memo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(39, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "备    注：";
            // 
            // ordernumber
            // 
            this.ordernumber.Location = new System.Drawing.Point(110, 260);
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.Size = new System.Drawing.Size(100, 21);
            this.ordernumber.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(33, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "*顺 序 号：";
            // 
            // chargeType
            // 
            this.chargeType.FormattingEnabled = true;
            this.chargeType.Items.AddRange(new object[] {
            "非预存",
            "预存"});
            this.chargeType.Location = new System.Drawing.Point(110, 225);
            this.chargeType.Name = "chargeType";
            this.chargeType.Size = new System.Drawing.Size(168, 20);
            this.chargeType.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(39, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "交费方式：";
            // 
            // BankAcountNumber
            // 
            this.BankAcountNumber.Location = new System.Drawing.Point(110, 189);
            this.BankAcountNumber.Name = "BankAcountNumber";
            this.BankAcountNumber.Size = new System.Drawing.Size(362, 21);
            this.BankAcountNumber.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(39, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "银行卡号：";
            // 
            // bankId
            // 
            this.bankId.FormattingEnabled = true;
            this.bankId.Location = new System.Drawing.Point(110, 154);
            this.bankId.Name = "bankId";
            this.bankId.Size = new System.Drawing.Size(362, 20);
            this.bankId.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(39, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "托收银行：";
            // 
            // agentsign
            // 
            this.agentsign.FormattingEnabled = true;
            this.agentsign.Items.AddRange(new object[] {
            "不托收",
            "托收"});
            this.agentsign.Location = new System.Drawing.Point(110, 119);
            this.agentsign.Name = "agentsign";
            this.agentsign.Size = new System.Drawing.Size(121, 20);
            this.agentsign.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "银行托收：";
            // 
            // meterReadingPageNo
            // 
            this.meterReadingPageNo.Location = new System.Drawing.Point(365, 390);
            this.meterReadingPageNo.Name = "meterReadingPageNo";
            this.meterReadingPageNo.Size = new System.Drawing.Size(100, 21);
            this.meterReadingPageNo.TabIndex = 3;
            this.meterReadingPageNo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(288, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "*页    号：";
            this.label2.Visible = false;
            // 
            // meterReadingID
            // 
            this.meterReadingID.FormattingEnabled = true;
            this.meterReadingID.Location = new System.Drawing.Point(137, 392);
            this.meterReadingID.Name = "meterReadingID";
            this.meterReadingID.Size = new System.Drawing.Size(121, 20);
            this.meterReadingID.TabIndex = 1;
            this.meterReadingID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(60, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*抄 表 本：";
            this.label1.Visible = false;
            // 
            // UnitNO
            // 
            this.UnitNO.Location = new System.Drawing.Point(407, 52);
            this.UnitNO.Name = "UnitNO";
            this.UnitNO.Size = new System.Drawing.Size(65, 21);
            this.UnitNO.TabIndex = 97;
            // 
            // BuildingNO
            // 
            this.BuildingNO.Location = new System.Drawing.Point(276, 52);
            this.BuildingNO.Name = "BuildingNO";
            this.BuildingNO.Size = new System.Drawing.Size(76, 21);
            this.BuildingNO.TabIndex = 95;
            // 
            // COMMUNITYID
            // 
            this.COMMUNITYID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.COMMUNITYID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.COMMUNITYID.DropDownWidth = 150;
            this.COMMUNITYID.FormattingEnabled = true;
            this.COMMUNITYID.Location = new System.Drawing.Point(110, 53);
            this.COMMUNITYID.Name = "COMMUNITYID";
            this.COMMUNITYID.Size = new System.Drawing.Size(88, 20);
            this.COMMUNITYID.TabIndex = 93;
            // 
            // DUANID
            // 
            this.DUANID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DUANID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.DUANID.DropDownWidth = 120;
            this.DUANID.FormattingEnabled = true;
            this.DUANID.Location = new System.Drawing.Point(407, 21);
            this.DUANID.Name = "DUANID";
            this.DUANID.Size = new System.Drawing.Size(65, 20);
            this.DUANID.TabIndex = 91;
            // 
            // PIANID
            // 
            this.PIANID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.PIANID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.PIANID.DropDownWidth = 120;
            this.PIANID.FormattingEnabled = true;
            this.PIANID.Location = new System.Drawing.Point(110, 21);
            this.PIANID.Name = "PIANID";
            this.PIANID.Size = new System.Drawing.Size(90, 20);
            this.PIANID.TabIndex = 90;
            // 
            // areaId
            // 
            this.areaId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.areaId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.areaId.DropDownWidth = 120;
            this.areaId.FormattingEnabled = true;
            this.areaId.Location = new System.Drawing.Point(276, 21);
            this.areaId.Name = "areaId";
            this.areaId.Size = new System.Drawing.Size(76, 20);
            this.areaId.TabIndex = 89;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.White;
            this.label49.Location = new System.Drawing.Point(33, 58);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(71, 12);
            this.label49.TabIndex = 92;
            this.label49.Text = "*小区名称：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(209, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 86;
            this.label9.Text = "*区    号：";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.White;
            this.label52.Location = new System.Drawing.Point(217, 58);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(65, 12);
            this.label52.TabIndex = 94;
            this.label52.Text = "楼    号：";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(45, 27);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(59, 12);
            this.label38.TabIndex = 87;
            this.label38.Text = "*片   号:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.White;
            this.label53.Location = new System.Drawing.Point(370, 58);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(41, 12);
            this.label53.TabIndex = 96;
            this.label53.Text = "单元：";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(362, 27);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(47, 12);
            this.label45.TabIndex = 88;
            this.label45.Text = "*段号：";
            // 
            // CreateTypeID
            // 
            this.CreateTypeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CreateTypeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CreateTypeID.DropDownWidth = 120;
            this.CreateTypeID.FormattingEnabled = true;
            this.CreateTypeID.Items.AddRange(new object[] {
            "正式",
            "非正式",
            "基建",
            "无表"});
            this.CreateTypeID.Location = new System.Drawing.Point(302, 260);
            this.CreateTypeID.Name = "CreateTypeID";
            this.CreateTypeID.Size = new System.Drawing.Size(163, 20);
            this.CreateTypeID.TabIndex = 100;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.White;
            this.label54.Location = new System.Drawing.Point(235, 263);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(71, 12);
            this.label54.TabIndex = 98;
            this.label54.Text = "*建档类型：";
            // 
            // meterReaderID
            // 
            this.meterReaderID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.meterReaderID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.meterReaderID.FormattingEnabled = true;
            this.meterReaderID.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.meterReaderID.Location = new System.Drawing.Point(112, 86);
            this.meterReaderID.Name = "meterReaderID";
            this.meterReaderID.Size = new System.Drawing.Size(88, 20);
            this.meterReaderID.TabIndex = 103;
            // 
            // chargerID
            // 
            this.chargerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.chargerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.chargerID.FormattingEnabled = true;
            this.chargerID.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.chargerID.Location = new System.Drawing.Point(276, 86);
            this.chargerID.Name = "chargerID";
            this.chargerID.Size = new System.Drawing.Size(76, 20);
            this.chargerID.TabIndex = 104;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(35, 90);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 101;
            this.label22.Text = "抄 表 员：";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.White;
            this.label55.Location = new System.Drawing.Point(217, 90);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(65, 12);
            this.label55.TabIndex = 102;
            this.label55.Text = "收 费 员：";
            // 
            // FrmApprove_Single_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(510, 470);
            this.Controls.Add(this.PL);
            this.Controls.Add(this.Btn_Submit);
            this.Controls.Add(this.meterReadingID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.meterReadingPageNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmApprove_Single_User";
            this.Text = "FrmApprove_Single_User";
            this.Load += new System.EventHandler(this.FrmApprove_Single_User_Load);
            this.PL.ResumeLayout(false);
            this.PL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Panel PL;
        private System.Windows.Forms.ComboBox meterReadingID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox meterReadingPageNo;
        private System.Windows.Forms.TextBox memo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ordernumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox chargeType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BankAcountNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox bankId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox agentsign;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LB_MeterInfo;
        private System.Windows.Forms.TextBox UnitNO;
        private System.Windows.Forms.TextBox BuildingNO;
        private System.Windows.Forms.ComboBox COMMUNITYID;
        private System.Windows.Forms.ComboBox DUANID;
        private System.Windows.Forms.ComboBox PIANID;
        private System.Windows.Forms.ComboBox areaId;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox CreateTypeID;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ComboBox meterReaderID;
        private System.Windows.Forms.ComboBox chargerID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label55;
    }
}
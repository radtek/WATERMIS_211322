namespace MeterInstall
{
    partial class FrmGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroup));
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.contractNO = new System.Windows.Forms.TextBox();
            this.waterUserPeopleCount = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.ApplyUser = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.Memo = new System.Windows.Forms.TextBox();
            this.waterUserName = new System.Windows.Forms.TextBox();
            this.waterUserAddress = new System.Windows.Forms.TextBox();
            this.QueryKey = new System.Windows.Forms.TextBox();
            this.waterPhone = new System.Windows.Forms.TextBox();
            this.AcceptID = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.toolStripWaterUser.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripWaterUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWaterUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPrint,
            this.toolPrintPreview,
            this.toolStripSeparator1});
            this.toolStripWaterUser.Location = new System.Drawing.Point(0, 0);
            this.toolStripWaterUser.Name = "toolStripWaterUser";
            this.toolStripWaterUser.Size = new System.Drawing.Size(640, 25);
            this.toolStripWaterUser.TabIndex = 61;
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolPrint
            // 
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(71, 22);
            this.toolPrint.Text = "打印工单";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolPrintPreview
            // 
            this.toolPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintPreview.Name = "toolPrintPreview";
            this.toolPrintPreview.Size = new System.Drawing.Size(71, 22);
            this.toolPrintPreview.Text = "打印预览";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.FP);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.userName);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.Btn_Submit);
            this.groupBox6.Controls.Add(this.contractNO);
            this.groupBox6.Controls.Add(this.waterUserPeopleCount);
            this.groupBox6.Controls.Add(this.label71);
            this.groupBox6.Controls.Add(this.ApplyUser);
            this.groupBox6.Controls.Add(this.label73);
            this.groupBox6.Controls.Add(this.Memo);
            this.groupBox6.Controls.Add(this.waterUserName);
            this.groupBox6.Controls.Add(this.waterUserAddress);
            this.groupBox6.Controls.Add(this.QueryKey);
            this.groupBox6.Controls.Add(this.waterPhone);
            this.groupBox6.Controls.Add(this.AcceptID);
            this.groupBox6.Controls.Add(this.label74);
            this.groupBox6.Controls.Add(this.label78);
            this.groupBox6.Controls.Add(this.label79);
            this.groupBox6.Controls.Add(this.label80);
            this.groupBox6.Controls.Add(this.label83);
            this.groupBox6.Controls.Add(this.label84);
            this.groupBox6.Controls.Add(this.label85);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 25);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(640, 517);
            this.groupBox6.TabIndex = 62;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "用户详细信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 12);
            this.label1.TabIndex = 86;
            this.label1.Text = "说明：（单击上方空白处添加，双击修改，点击“X”删除）";
            // 
            // FP
            // 
            this.FP.AutoScroll = true;
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.Location = new System.Drawing.Point(84, 175);
            this.FP.Name = "FP";
            this.FP.Size = new System.Drawing.Size(529, 247);
            this.FP.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 84;
            this.label4.Text = "用户详情：";
            // 
            // userName
            // 
            this.userName.Enabled = false;
            this.userName.Location = new System.Drawing.Point(490, 113);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(123, 21);
            this.userName.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 79;
            this.label2.Text = "受理人：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Submit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.Location = new System.Drawing.Point(241, 461);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(109, 38);
            this.Btn_Submit.TabIndex = 77;
            this.Btn_Submit.Tag = "9999";
            this.Btn_Submit.Text = "提交申请";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // contractNO
            // 
            this.contractNO.Location = new System.Drawing.Point(306, 85);
            this.contractNO.Name = "contractNO";
            this.contractNO.Size = new System.Drawing.Size(306, 21);
            this.contractNO.TabIndex = 31;
            // 
            // waterUserPeopleCount
            // 
            this.waterUserPeopleCount.Location = new System.Drawing.Point(83, 113);
            this.waterUserPeopleCount.Name = "waterUserPeopleCount";
            this.waterUserPeopleCount.ReadOnly = true;
            this.waterUserPeopleCount.Size = new System.Drawing.Size(128, 21);
            this.waterUserPeopleCount.TabIndex = 65;
            this.waterUserPeopleCount.Text = "0";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(17, 117);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(65, 12);
            this.label71.TabIndex = 66;
            this.label71.Text = "用 户 数：";
            // 
            // ApplyUser
            // 
            this.ApplyUser.Location = new System.Drawing.Point(306, 113);
            this.ApplyUser.Name = "ApplyUser";
            this.ApplyUser.Size = new System.Drawing.Size(120, 21);
            this.ApplyUser.TabIndex = 39;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(239, 88);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(65, 12);
            this.label73.TabIndex = 61;
            this.label73.Text = "合同编号：";
            // 
            // Memo
            // 
            this.Memo.Location = new System.Drawing.Point(84, 144);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(528, 21);
            this.Memo.TabIndex = 40;
            // 
            // waterUserName
            // 
            this.waterUserName.Location = new System.Drawing.Point(306, 23);
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.Size = new System.Drawing.Size(307, 21);
            this.waterUserName.TabIndex = 27;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.Location = new System.Drawing.Point(306, 53);
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.Size = new System.Drawing.Size(307, 21);
            this.waterUserAddress.TabIndex = 29;
            // 
            // QueryKey
            // 
            this.QueryKey.Location = new System.Drawing.Point(84, 53);
            this.QueryKey.Name = "QueryKey";
            this.QueryKey.Size = new System.Drawing.Size(128, 21);
            this.QueryKey.TabIndex = 28;
            this.QueryKey.Text = "123456";
            // 
            // waterPhone
            // 
            this.waterPhone.Location = new System.Drawing.Point(84, 83);
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.Size = new System.Drawing.Size(128, 21);
            this.waterPhone.TabIndex = 30;
            // 
            // AcceptID
            // 
            this.AcceptID.BackColor = System.Drawing.SystemColors.Control;
            this.AcceptID.Enabled = false;
            this.AcceptID.Location = new System.Drawing.Point(84, 23);
            this.AcceptID.Name = "AcceptID";
            this.AcceptID.ReadOnly = true;
            this.AcceptID.Size = new System.Drawing.Size(128, 21);
            this.AcceptID.TabIndex = 25;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(17, 148);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(65, 12);
            this.label74.TabIndex = 57;
            this.label74.Text = "备    注：";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(238, 117);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(65, 12);
            this.label78.TabIndex = 35;
            this.label78.Text = "申 请 人：";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(18, 57);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(65, 12);
            this.label79.TabIndex = 32;
            this.label79.Text = "查询密码：";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(11, 87);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(71, 12);
            this.label80.TabIndex = 30;
            this.label80.Text = "*联系方式：";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(233, 57);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(71, 12);
            this.label83.TabIndex = 28;
            this.label83.Text = "*单位地址：";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(232, 27);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(71, 12);
            this.label84.TabIndex = 26;
            this.label84.Text = "*单位名称：";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(18, 27);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(65, 12);
            this.label85.TabIndex = 24;
            this.label85.Text = "受理编号：";
            // 
            // FrmGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 542);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多位用户报装";
            this.Load += new System.EventHandler(this.FrmGroup_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel FP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.TextBox contractNO;
        private System.Windows.Forms.TextBox waterUserPeopleCount;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox ApplyUser;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.TextBox waterUserName;
        private System.Windows.Forms.TextBox waterUserAddress;
        private System.Windows.Forms.TextBox QueryKey;
        private System.Windows.Forms.TextBox waterPhone;
        private System.Windows.Forms.TextBox AcceptID;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label85;


    }
}
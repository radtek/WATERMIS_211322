namespace WaterBusiness
{
    partial class Frm_BlackList_Cancel
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelMemo = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.waterUserId = new System.Windows.Forms.TextBox();
            this.waterUserName = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.AddDate = new System.Windows.Forms.TextBox();
            this.MEMO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.waterUserAddress = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(529, 317);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CancelMemo);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 134);
            this.panel1.TabIndex = 5;
            // 
            // CancelMemo
            // 
            this.CancelMemo.AllowEmpty = false;
            this.CancelMemo.EmptyMessage = "";
            this.CancelMemo.ErrorMessage = "";
            this.CancelMemo.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.CancelMemo.Location = new System.Drawing.Point(80, 13);
            this.CancelMemo.Multiline = true;
            this.CancelMemo.Name = "CancelMemo";
            this.CancelMemo.RegexExpression = "";
            this.CancelMemo.RemoveSpace = false;
            this.CancelMemo.Size = new System.Drawing.Size(414, 65);
            this.CancelMemo.TabIndex = 20;
            this.CancelMemo.ValidateState = false;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Submit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.Location = new System.Drawing.Point(193, 88);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(136, 37);
            this.Btn_Submit.TabIndex = 27;
            this.Btn_Submit.Tag = "9999";
            this.Btn_Submit.Text = "取消黑名单";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "取消原因：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.waterUserAddress);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.MEMO);
            this.panel2.Controls.Add(this.AddDate);
            this.panel2.Controls.Add(this.userName);
            this.panel2.Controls.Add(this.waterUserName);
            this.panel2.Controls.Add(this.waterUserId);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 171);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "户    号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "操作员：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "加入时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "加入原因：";
            // 
            // waterUserId
            // 
            this.waterUserId.Location = new System.Drawing.Point(80, 17);
            this.waterUserId.Name = "waterUserId";
            this.waterUserId.ReadOnly = true;
            this.waterUserId.Size = new System.Drawing.Size(100, 21);
            this.waterUserId.TabIndex = 5;
            // 
            // waterUserName
            // 
            this.waterUserName.Location = new System.Drawing.Point(232, 17);
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.ReadOnly = true;
            this.waterUserName.Size = new System.Drawing.Size(100, 21);
            this.waterUserName.TabIndex = 6;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(394, 17);
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Size = new System.Drawing.Size(100, 21);
            this.userName.TabIndex = 7;
            // 
            // AddDate
            // 
            this.AddDate.Location = new System.Drawing.Point(80, 44);
            this.AddDate.Name = "AddDate";
            this.AddDate.ReadOnly = true;
            this.AddDate.Size = new System.Drawing.Size(100, 21);
            this.AddDate.TabIndex = 8;
            // 
            // MEMO
            // 
            this.MEMO.Location = new System.Drawing.Point(80, 99);
            this.MEMO.Multiline = true;
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            this.MEMO.Size = new System.Drawing.Size(414, 53);
            this.MEMO.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "地    址：";
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.Location = new System.Drawing.Point(80, 71);
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            this.waterUserAddress.Size = new System.Drawing.Size(414, 21);
            this.waterUserAddress.TabIndex = 11;
            // 
            // Frm_BlackList_Cancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 317);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "Frm_BlackList_Cancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息查看";
            this.Load += new System.EventHandler(this.Frm_BlackList_Cancel_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox CancelMemo;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox waterUserId;
        private System.Windows.Forms.TextBox MEMO;
        private System.Windows.Forms.TextBox AddDate;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox waterUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox waterUserAddress;
    }
}
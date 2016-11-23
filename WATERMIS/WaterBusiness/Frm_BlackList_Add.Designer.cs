namespace WaterBusiness
{
    partial class Frm_BlackList_Add
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
            this.waterPhone = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.MEMO = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.AddDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uC_UserDetails1 = new SysControl.UC_UserDetails();
            this.uC_UserSearch1 = new SysControl.UC_UserSearch();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(936, 634);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uC_UserDetails1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(403, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(530, 628);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.waterPhone);
            this.panel1.Controls.Add(this.MEMO);
            this.panel1.Controls.Add(this.AddDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 384);
            this.panel1.TabIndex = 5;
            // 
            // waterPhone
            // 
            this.waterPhone.AllowEmpty = true;
            this.waterPhone.EmptyMessage = "";
            this.waterPhone.ErrorMessage = "";
            this.waterPhone.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.waterPhone.Location = new System.Drawing.Point(101, 98);
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.RegexExpression = "";
            this.waterPhone.RemoveSpace = false;
            this.waterPhone.Size = new System.Drawing.Size(176, 21);
            this.waterPhone.TabIndex = 26;
            this.waterPhone.ValidateState = false;
            // 
            // MEMO
            // 
            this.MEMO.AllowEmpty = false;
            this.MEMO.EmptyMessage = "";
            this.MEMO.ErrorMessage = "";
            this.MEMO.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.MEMO.Location = new System.Drawing.Point(101, 13);
            this.MEMO.Multiline = true;
            this.MEMO.Name = "MEMO";
            this.MEMO.RegexExpression = "";
            this.MEMO.RemoveSpace = false;
            this.MEMO.Size = new System.Drawing.Size(393, 47);
            this.MEMO.TabIndex = 20;
            this.MEMO.ValidateState = false;
            // 
            // AddDate
            // 
            this.AddDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.AddDate.Location = new System.Drawing.Point(101, 68);
            this.AddDate.Name = "AddDate";
            this.AddDate.Size = new System.Drawing.Size(136, 21);
            this.AddDate.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "加入时间：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "联系电话：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Submit.Enabled = false;
            this.Btn_Submit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.Location = new System.Drawing.Point(230, 143);
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
            this.label1.Location = new System.Drawing.Point(33, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "说    明：";
            // 
            // uC_UserDetails1
            // 
            this.uC_UserDetails1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_UserDetails1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserDetails1.Name = "uC_UserDetails1";
            this.uC_UserDetails1.Size = new System.Drawing.Size(524, 230);
            this.uC_UserDetails1.TabIndex = 6;
            // 
            // uC_UserSearch1
            // 
            this.uC_UserSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UserSearch1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserSearch1.Name = "uC_UserSearch1";
            this.uC_UserSearch1.Size = new System.Drawing.Size(394, 628);
            this.uC_UserSearch1.TabIndex = 8;
            this.uC_UserSearch1.BtnSearchEvent += new System.EventHandler(this.uC_UserSearch1_BtnSearchEvent);
            // 
            // Frm_BlackList_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 634);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Frm_BlackList_Add";
            this.Text = "添加黑名单";
            this.Load += new System.EventHandler(this.Frm_BlackList_Add_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterPhone;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox MEMO;
        private System.Windows.Forms.DateTimePicker AddDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label1;
        private SysControl.UC_UserDetails uC_UserDetails1;
        private SysControl.UC_UserSearch uC_UserSearch1;
    }
}
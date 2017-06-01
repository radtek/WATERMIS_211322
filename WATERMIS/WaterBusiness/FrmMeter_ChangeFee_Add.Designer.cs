namespace WaterBusiness
{
    partial class FrmMeter_ChangeFee_Add
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
            this.label4 = new System.Windows.Forms.Label();
            this.ChangeDescribe = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.ApplyUser = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.waterMeterEndNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uC_UserSearch1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(925, 703);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uC_UserMeterDetails1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(403, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 371F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(519, 697);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.waterPhone);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ChangeDescribe);
            this.panel1.Controls.Add(this.ApplyUser);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.waterMeterEndNumber);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 320);
            this.panel1.TabIndex = 7;
            // 
            // waterPhone
            // 
            this.waterPhone.AllowEmpty = false;
            this.waterPhone.EmptyMessage = "";
            this.waterPhone.ErrorMessage = "";
            this.waterPhone.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.数字;
            this.waterPhone.Location = new System.Drawing.Point(334, 80);
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.RegexExpression = "";
            this.waterPhone.RemoveSpace = false;
            this.waterPhone.Size = new System.Drawing.Size(160, 21);
            this.waterPhone.TabIndex = 12;
            this.waterPhone.ValidateState = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 78;
            this.label4.Text = "*联系电话：";
            // 
            // ChangeDescribe
            // 
            this.ChangeDescribe.AllowEmpty = false;
            this.ChangeDescribe.EmptyMessage = "";
            this.ChangeDescribe.ErrorMessage = "";
            this.ChangeDescribe.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.ChangeDescribe.Location = new System.Drawing.Point(89, 7);
            this.ChangeDescribe.Multiline = true;
            this.ChangeDescribe.Name = "ChangeDescribe";
            this.ChangeDescribe.RegexExpression = "";
            this.ChangeDescribe.RemoveSpace = false;
            this.ChangeDescribe.Size = new System.Drawing.Size(405, 64);
            this.ChangeDescribe.TabIndex = 10;
            this.ChangeDescribe.ValidateState = false;
            // 
            // ApplyUser
            // 
            this.ApplyUser.AllowEmpty = false;
            this.ApplyUser.EmptyMessage = "";
            this.ApplyUser.ErrorMessage = "";
            this.ApplyUser.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.ApplyUser.Location = new System.Drawing.Point(89, 80);
            this.ApplyUser.Name = "ApplyUser";
            this.ApplyUser.RegexExpression = "";
            this.ApplyUser.RemoveSpace = false;
            this.ApplyUser.Size = new System.Drawing.Size(160, 21);
            this.ApplyUser.TabIndex = 11;
            this.ApplyUser.ValidateState = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 75;
            this.label5.Text = "*申 请 人：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Submit.Enabled = false;
            this.Btn_Submit.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.Location = new System.Drawing.Point(210, 177);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(108, 37);
            this.Btn_Submit.TabIndex = 14;
            this.Btn_Submit.Tag = "9999";
            this.Btn_Submit.Text = "提  交";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(91, 111);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(405, 59);
            this.flowLayoutPanel1.TabIndex = 10;
            this.flowLayoutPanel1.Visible = false;
            // 
            // waterMeterEndNumber
            // 
            this.waterMeterEndNumber.Location = new System.Drawing.Point(62, 33);
            this.waterMeterEndNumber.Name = "waterMeterEndNumber";
            this.waterMeterEndNumber.Size = new System.Drawing.Size(21, 21);
            this.waterMeterEndNumber.TabIndex = 9;
            this.waterMeterEndNumber.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "水表读数：";
            this.label8.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "上传照片：";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*换表原因：";
            // 
            // uC_UserMeterDetails1
            // 
            this.uC_UserMeterDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UserMeterDetails1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserMeterDetails1.Name = "uC_UserMeterDetails1";
            this.uC_UserMeterDetails1.Size = new System.Drawing.Size(513, 365);
            this.uC_UserMeterDetails1.TabIndex = 6;
            this.uC_UserMeterDetails1.Tag = "";
            // 
            // uC_UserSearch1
            // 
            this.uC_UserSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UserSearch1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserSearch1.Name = "uC_UserSearch1";
            this.uC_UserSearch1.Size = new System.Drawing.Size(394, 697);
            this.uC_UserSearch1.TabIndex = 9;
            this.uC_UserSearch1.BtnSearchEvent += new System.EventHandler(this.uC_UserSearch1_BtnSearchEvent);
            // 
            // FrmMeter_ChangeFee_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 703);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmMeter_ChangeFee_Add";
            this.Text = "收费换表";
            this.Load += new System.EventHandler(this.FrmMeter_ChangeFee_Add_Load);
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
        private System.Windows.Forms.Label label4;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox ChangeDescribe;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox ApplyUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox waterMeterEndNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private SysControl.UC_UserMeterDetails uC_UserMeterDetails1;
        private SysControl.UC_UserSearch uC_UserSearch1;
    }
}
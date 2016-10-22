namespace PersonalWork
{
    partial class FrmChange_MeterScrap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChange_MeterScrap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LB_State = new System.Windows.Forms.Label();
            this.Btn_Check = new System.Windows.Forms.Button();
            this.WATERMETERLOCKNO = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.waterMeterMode = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.IsReverse = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.waterMeterSerialNumber = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.waterMeterId = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.waterMeterEndNumber = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.LB_Tip = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UserOpinion = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.LB_State);
            this.panel1.Controls.Add(this.Btn_Check);
            this.panel1.Controls.Add(this.WATERMETERLOCKNO);
            this.panel1.Controls.Add(this.waterMeterMode);
            this.panel1.Controls.Add(this.IsReverse);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.waterMeterSerialNumber);
            this.panel1.Controls.Add(this.waterMeterId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.waterMeterEndNumber);
            this.panel1.Controls.Add(this.LB_Tip);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UserOpinion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 370);
            this.panel1.TabIndex = 7;
            // 
            // LB_State
            // 
            this.LB_State.AutoSize = true;
            this.LB_State.BackColor = System.Drawing.Color.Transparent;
            this.LB_State.Location = new System.Drawing.Point(272, 176);
            this.LB_State.Name = "LB_State";
            this.LB_State.Size = new System.Drawing.Size(17, 12);
            this.LB_State.TabIndex = 20;
            this.LB_State.Text = "？";
            // 
            // Btn_Check
            // 
            this.Btn_Check.Location = new System.Drawing.Point(299, 171);
            this.Btn_Check.Name = "Btn_Check";
            this.Btn_Check.Size = new System.Drawing.Size(69, 23);
            this.Btn_Check.TabIndex = 14;
            this.Btn_Check.Text = "查 询";
            this.Btn_Check.UseVisualStyleBackColor = true;
            this.Btn_Check.Click += new System.EventHandler(this.Btn_Check_Click);
            // 
            // WATERMETERLOCKNO
            // 
            this.WATERMETERLOCKNO.AllowEmpty = false;
            this.WATERMETERLOCKNO.EmptyMessage = "";
            this.WATERMETERLOCKNO.ErrorMessage = "";
            this.WATERMETERLOCKNO.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.WATERMETERLOCKNO.Location = new System.Drawing.Point(287, 204);
            this.WATERMETERLOCKNO.Name = "WATERMETERLOCKNO";
            this.WATERMETERLOCKNO.RegexExpression = "";
            this.WATERMETERLOCKNO.RemoveSpace = false;
            this.WATERMETERLOCKNO.Size = new System.Drawing.Size(98, 21);
            this.WATERMETERLOCKNO.TabIndex = 16;
            this.WATERMETERLOCKNO.ValidateState = false;
            // 
            // waterMeterMode
            // 
            this.waterMeterMode.AllowEmpty = false;
            this.waterMeterMode.EmptyMessage = "";
            this.waterMeterMode.ErrorMessage = "";
            this.waterMeterMode.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.waterMeterMode.Location = new System.Drawing.Point(100, 204);
            this.waterMeterMode.Name = "waterMeterMode";
            this.waterMeterMode.RegexExpression = "";
            this.waterMeterMode.RemoveSpace = false;
            this.waterMeterMode.Size = new System.Drawing.Size(98, 21);
            this.waterMeterMode.TabIndex = 15;
            this.waterMeterMode.ValidateState = false;
            // 
            // IsReverse
            // 
            this.IsReverse.AutoSize = true;
            this.IsReverse.BackColor = System.Drawing.Color.Transparent;
            this.IsReverse.Location = new System.Drawing.Point(418, 207);
            this.IsReverse.Name = "IsReverse";
            this.IsReverse.Size = new System.Drawing.Size(48, 16);
            this.IsReverse.TabIndex = 17;
            this.IsReverse.Text = "倒装";
            this.IsReverse.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(212, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "*表 锁 号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(24, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "*铅 封 号：";
            // 
            // waterMeterSerialNumber
            // 
            this.waterMeterSerialNumber.AllowEmpty = false;
            this.waterMeterSerialNumber.EmptyMessage = "";
            this.waterMeterSerialNumber.ErrorMessage = "";
            this.waterMeterSerialNumber.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.waterMeterSerialNumber.Location = new System.Drawing.Point(100, 171);
            this.waterMeterSerialNumber.Name = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.RegexExpression = "";
            this.waterMeterSerialNumber.RemoveSpace = false;
            this.waterMeterSerialNumber.Size = new System.Drawing.Size(167, 21);
            this.waterMeterSerialNumber.TabIndex = 13;
            this.waterMeterSerialNumber.ValidateState = false;
            this.waterMeterSerialNumber.TextChanged += new System.EventHandler(this.waterMeterSerialNumber_TextChanged);
            // 
            // waterMeterId
            // 
            this.waterMeterId.AllowEmpty = false;
            this.waterMeterId.EmptyMessage = "";
            this.waterMeterId.ErrorMessage = "";
            this.waterMeterId.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.waterMeterId.Location = new System.Drawing.Point(100, 138);
            this.waterMeterId.Name = "waterMeterId";
            this.waterMeterId.ReadOnly = true;
            this.waterMeterId.RegexExpression = "";
            this.waterMeterId.RemoveSpace = false;
            this.waterMeterId.Size = new System.Drawing.Size(189, 21);
            this.waterMeterId.TabIndex = 12;
            this.waterMeterId.ValidateState = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "*新水表编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(297, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "*水表读数：";
            // 
            // waterMeterEndNumber
            // 
            this.waterMeterEndNumber.AllowEmpty = false;
            this.waterMeterEndNumber.EmptyMessage = "";
            this.waterMeterEndNumber.ErrorMessage = "";
            this.waterMeterEndNumber.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.数字;
            this.waterMeterEndNumber.Location = new System.Drawing.Point(372, 138);
            this.waterMeterEndNumber.Name = "waterMeterEndNumber";
            this.waterMeterEndNumber.RegexExpression = "";
            this.waterMeterEndNumber.RemoveSpace = false;
            this.waterMeterEndNumber.Size = new System.Drawing.Size(114, 21);
            this.waterMeterEndNumber.TabIndex = 12;
            this.waterMeterEndNumber.ValidateState = false;
            // 
            // LB_Tip
            // 
            this.LB_Tip.AutoSize = true;
            this.LB_Tip.BackColor = System.Drawing.Color.Transparent;
            this.LB_Tip.Location = new System.Drawing.Point(18, 143);
            this.LB_Tip.Name = "LB_Tip";
            this.LB_Tip.Size = new System.Drawing.Size(77, 12);
            this.LB_Tip.TabIndex = 8;
            this.LB_Tip.Text = "旧水表编号：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.SeaGreen;
            this.Btn_Submit.FlatAppearance.BorderSize = 0;
            this.Btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Submit.Font = new System.Drawing.Font("微软雅黑 Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.ForeColor = System.Drawing.Color.White;
            this.Btn_Submit.Location = new System.Drawing.Point(173, 304);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(129, 41);
            this.Btn_Submit.TabIndex = 18;
            this.Btn_Submit.Text = "更换水表";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "我的意见：";
            // 
            // UserOpinion
            // 
            this.UserOpinion.Location = new System.Drawing.Point(78, 41);
            this.UserOpinion.Multiline = true;
            this.UserOpinion.Name = "UserOpinion";
            this.UserOpinion.Size = new System.Drawing.Size(408, 69);
            this.UserOpinion.TabIndex = 11;
            // 
            // FrmChange_MeterScrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChange_MeterScrap";
            this.Text = "FrmChange_MeterScrap";
            this.Load += new System.EventHandler(this.FrmChange_MeterScrap_Load);
            this.Shown += new System.EventHandler(this.FrmChange_MeterScrap_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterMeterEndNumber;
        private System.Windows.Forms.Label LB_Tip;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserOpinion;
        private System.Windows.Forms.Label label3;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterMeterSerialNumber;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterMeterId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox IsReverse;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox WATERMETERLOCKNO;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterMeterMode;
        private System.Windows.Forms.Button Btn_Check;
        private System.Windows.Forms.Label LB_State;
    }
}
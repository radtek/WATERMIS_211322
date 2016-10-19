namespace PersonalWork
{
    partial class FrmDisUse_MeterIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisUse_MeterIn));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UserOpinion = new System.Windows.Forms.TextBox();
            this.LB_Tip = new System.Windows.Forms.Label();
            this.WaterMeterNum = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.WaterMeterNum);
            this.panel1.Controls.Add(this.LB_Tip);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UserOpinion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 370);
            this.panel1.TabIndex = 5;
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
            this.Btn_Submit.TabIndex = 6;
            this.Btn_Submit.Text = "水表入库";
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
            this.UserOpinion.TabIndex = 1;
            // 
            // LB_Tip
            // 
            this.LB_Tip.AutoSize = true;
            this.LB_Tip.BackColor = System.Drawing.Color.Transparent;
            this.LB_Tip.Location = new System.Drawing.Point(12, 144);
            this.LB_Tip.Name = "LB_Tip";
            this.LB_Tip.Size = new System.Drawing.Size(125, 12);
            this.LB_Tip.TabIndex = 8;
            this.LB_Tip.Text = "用 户 号：水表编号：";
            // 
            // WaterMeterNum
            // 
            this.WaterMeterNum.AllowEmpty = false;
            this.WaterMeterNum.EmptyMessage = "";
            this.WaterMeterNum.ErrorMessage = "";
            this.WaterMeterNum.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.数字;
            this.WaterMeterNum.Location = new System.Drawing.Point(78, 173);
            this.WaterMeterNum.Name = "WaterMeterNum";
            this.WaterMeterNum.RegexExpression = "";
            this.WaterMeterNum.RemoveSpace = false;
            this.WaterMeterNum.Size = new System.Drawing.Size(152, 21);
            this.WaterMeterNum.TabIndex = 9;
            this.WaterMeterNum.ValidateState = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "水表读数：";
            // 
            // FrmDisUse_MeterIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDisUse_MeterIn";
            this.Text = "FrmDisUse_MeterIn";
            this.Load += new System.EventHandler(this.FrmDisUse_MeterIn_Load);
            this.Shown += new System.EventHandler(this.FrmDisUse_MeterIn_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserOpinion;
        private System.Windows.Forms.Label LB_Tip;
        private System.Windows.Forms.Label label2;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox WaterMeterNum;
    }
}
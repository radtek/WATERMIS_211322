namespace PersonalWork
{
    partial class FrmChange_MeterInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChange_MeterInit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LB_Tip = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UserOpinion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LB_S = new System.Windows.Forms.Label();
            this.LB_EndNumber = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.LB_EndNumber);
            this.panel1.Controls.Add(this.LB_S);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LB_Tip);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UserOpinion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 370);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(86, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 15);
            this.label2.TabIndex = 8;
            this.label2.Tag = "9999";
            this.label2.Text = "警告：提交后用户表底数将置为【0】。";
            // 
            // LB_Tip
            // 
            this.LB_Tip.AutoSize = true;
            this.LB_Tip.BackColor = System.Drawing.Color.Transparent;
            this.LB_Tip.Location = new System.Drawing.Point(10, 128);
            this.LB_Tip.Name = "LB_Tip";
            this.LB_Tip.Size = new System.Drawing.Size(125, 12);
            this.LB_Tip.TabIndex = 7;
            this.LB_Tip.Text = "用 户 号：水表编号：";
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
            this.Btn_Submit.Text = "用户换表确认";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 44);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "表站表数：";
            // 
            // LB_S
            // 
            this.LB_S.AutoSize = true;
            this.LB_S.BackColor = System.Drawing.Color.Transparent;
            this.LB_S.Location = new System.Drawing.Point(16, 191);
            this.LB_S.Name = "LB_S";
            this.LB_S.Size = new System.Drawing.Size(0, 12);
            this.LB_S.TabIndex = 10;
            // 
            // LB_EndNumber
            // 
            this.LB_EndNumber.AutoSize = true;
            this.LB_EndNumber.BackColor = System.Drawing.Color.Transparent;
            this.LB_EndNumber.Location = new System.Drawing.Point(76, 159);
            this.LB_EndNumber.Name = "LB_EndNumber";
            this.LB_EndNumber.Size = new System.Drawing.Size(11, 12);
            this.LB_EndNumber.TabIndex = 11;
            this.LB_EndNumber.Text = "0";
            // 
            // FrmChange_MeterInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChange_MeterInit";
            this.Text = "FrmChange_MeterInit";
            this.Load += new System.EventHandler(this.FrmChange_MeterInit_Load);
            this.Shown += new System.EventHandler(this.FrmChange_MeterInit_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LB_Tip;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserOpinion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LB_EndNumber;
        private System.Windows.Forms.Label LB_S;
        private System.Windows.Forms.Label label3;
    }
}
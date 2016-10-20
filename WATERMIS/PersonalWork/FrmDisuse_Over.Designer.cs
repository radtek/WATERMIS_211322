namespace PersonalWork
{
    partial class FrmDisuse_Over
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisuse_Over));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Over = new System.Windows.Forms.Button();
            this.Btn_Voided = new System.Windows.Forms.Button();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.LB_GoPointID = new System.Windows.Forms.Label();
            this.CB_GoPointID = new System.Windows.Forms.ComboBox();
            this.IsSkip = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserOpinion = new System.Windows.Forms.TextBox();
            this.IsPass = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.Btn_Over);
            this.panel1.Controls.Add(this.Btn_Voided);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.LB_GoPointID);
            this.panel1.Controls.Add(this.CB_GoPointID);
            this.panel1.Controls.Add(this.IsSkip);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UserOpinion);
            this.panel1.Controls.Add(this.IsPass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 370);
            this.panel1.TabIndex = 4;
            // 
            // Btn_Over
            // 
            this.Btn_Over.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Over.ForeColor = System.Drawing.Color.Maroon;
            this.Btn_Over.Location = new System.Drawing.Point(417, 302);
            this.Btn_Over.Name = "Btn_Over";
            this.Btn_Over.Size = new System.Drawing.Size(71, 29);
            this.Btn_Over.TabIndex = 9;
            this.Btn_Over.Text = "结束审批";
            this.Btn_Over.UseVisualStyleBackColor = true;
            this.Btn_Over.Click += new System.EventHandler(this.Btn_Over_Click);
            // 
            // Btn_Voided
            // 
            this.Btn_Voided.Location = new System.Drawing.Point(30, 290);
            this.Btn_Voided.Name = "Btn_Voided";
            this.Btn_Voided.Size = new System.Drawing.Size(129, 41);
            this.Btn_Voided.TabIndex = 8;
            this.Btn_Voided.Text = "作废";
            this.Btn_Voided.UseVisualStyleBackColor = true;
            this.Btn_Voided.Visible = false;
            this.Btn_Voided.Click += new System.EventHandler(this.Btn_Voided_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.SeaGreen;
            this.Btn_Submit.FlatAppearance.BorderSize = 0;
            this.Btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Submit.Font = new System.Drawing.Font("微软雅黑 Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.ForeColor = System.Drawing.Color.White;
            this.Btn_Submit.Location = new System.Drawing.Point(165, 290);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(129, 41);
            this.Btn_Submit.TabIndex = 6;
            this.Btn_Submit.Text = "提交审批";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // LB_GoPointID
            // 
            this.LB_GoPointID.AutoSize = true;
            this.LB_GoPointID.BackColor = System.Drawing.Color.Transparent;
            this.LB_GoPointID.Location = new System.Drawing.Point(281, 17);
            this.LB_GoPointID.Name = "LB_GoPointID";
            this.LB_GoPointID.Size = new System.Drawing.Size(65, 12);
            this.LB_GoPointID.TabIndex = 5;
            this.LB_GoPointID.Text = "跳回节点：";
            this.LB_GoPointID.Visible = false;
            // 
            // CB_GoPointID
            // 
            this.CB_GoPointID.FormattingEnabled = true;
            this.CB_GoPointID.Location = new System.Drawing.Point(348, 13);
            this.CB_GoPointID.Name = "CB_GoPointID";
            this.CB_GoPointID.Size = new System.Drawing.Size(121, 20);
            this.CB_GoPointID.TabIndex = 4;
            this.CB_GoPointID.Visible = false;
            // 
            // IsSkip
            // 
            this.IsSkip.AutoSize = true;
            this.IsSkip.BackColor = System.Drawing.Color.Transparent;
            this.IsSkip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IsSkip.BackgroundImage")));
            this.IsSkip.Location = new System.Drawing.Point(180, 16);
            this.IsSkip.Name = "IsSkip";
            this.IsSkip.Size = new System.Drawing.Size(72, 16);
            this.IsSkip.TabIndex = 3;
            this.IsSkip.Text = "跳回重审";
            this.IsSkip.UseVisualStyleBackColor = false;
            this.IsSkip.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "我的意见：";
            // 
            // UserOpinion
            // 
            this.UserOpinion.Location = new System.Drawing.Point(83, 43);
            this.UserOpinion.Multiline = true;
            this.UserOpinion.Name = "UserOpinion";
            this.UserOpinion.Size = new System.Drawing.Size(408, 69);
            this.UserOpinion.TabIndex = 1;
            // 
            // IsPass
            // 
            this.IsPass.AutoSize = true;
            this.IsPass.BackColor = System.Drawing.Color.Transparent;
            this.IsPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("IsPass.BackgroundImage")));
            this.IsPass.Checked = true;
            this.IsPass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsPass.Location = new System.Drawing.Point(82, 16);
            this.IsPass.Name = "IsPass";
            this.IsPass.Size = new System.Drawing.Size(48, 16);
            this.IsPass.TabIndex = 0;
            this.IsPass.Text = "同意";
            this.IsPass.UseVisualStyleBackColor = false;
            this.IsPass.CheckedChanged += new System.EventHandler(this.IsPass_CheckedChanged);
            // 
            // FrmDisuse_Over
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDisuse_Over";
            this.Text = "FrmDisuse_Over";
            this.Load += new System.EventHandler(this.FrmDisuse_Over_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Voided;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label LB_GoPointID;
        private System.Windows.Forms.ComboBox CB_GoPointID;
        private System.Windows.Forms.CheckBox IsSkip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserOpinion;
        private System.Windows.Forms.CheckBox IsPass;
        private System.Windows.Forms.Button Btn_Over;
    }
}
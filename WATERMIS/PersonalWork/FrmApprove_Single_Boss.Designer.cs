namespace PersonalWork
{
    partial class FrmApprove_Single_Boss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Single_Boss));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LB_Tip = new System.Windows.Forms.Label();
            this.Abate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_More = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.LB_Tip);
            this.panel1.Controls.Add(this.Abate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Btn_More);
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
            this.panel1.Size = new System.Drawing.Size(510, 470);
            this.panel1.TabIndex = 2;
            // 
            // LB_Tip
            // 
            this.LB_Tip.AutoSize = true;
            this.LB_Tip.BackColor = System.Drawing.Color.White;
            this.LB_Tip.Location = new System.Drawing.Point(211, 74);
            this.LB_Tip.Name = "LB_Tip";
            this.LB_Tip.Size = new System.Drawing.Size(0, 12);
            this.LB_Tip.TabIndex = 19;
            this.LB_Tip.Visible = false;
            // 
            // Abate
            // 
            this.Abate.Location = new System.Drawing.Point(83, 70);
            this.Abate.Name = "Abate";
            this.Abate.Size = new System.Drawing.Size(119, 21);
            this.Abate.TabIndex = 18;
            this.Abate.Text = "0";
            this.Abate.Visible = false;
            this.Abate.TextChanged += new System.EventHandler(this.Abate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(15, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "费用减免：";
            this.label2.Visible = false;
            // 
            // Btn_More
            // 
            this.Btn_More.Location = new System.Drawing.Point(332, 400);
            this.Btn_More.Name = "Btn_More";
            this.Btn_More.Size = new System.Drawing.Size(129, 41);
            this.Btn_More.TabIndex = 16;
            this.Btn_More.Text = "查看费用明细";
            this.Btn_More.UseVisualStyleBackColor = true;
            this.Btn_More.Click += new System.EventHandler(this.Btn_More_Click_1);
            // 
            // Btn_Voided
            // 
            this.Btn_Voided.Enabled = false;
            this.Btn_Voided.Location = new System.Drawing.Point(40, 400);
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
            this.Btn_Submit.Location = new System.Drawing.Point(186, 400);
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
            this.LB_GoPointID.Location = new System.Drawing.Point(281, 34);
            this.LB_GoPointID.Name = "LB_GoPointID";
            this.LB_GoPointID.Size = new System.Drawing.Size(65, 12);
            this.LB_GoPointID.TabIndex = 5;
            this.LB_GoPointID.Text = "跳回节点：";
            this.LB_GoPointID.Visible = false;
            // 
            // CB_GoPointID
            // 
            this.CB_GoPointID.FormattingEnabled = true;
            this.CB_GoPointID.Location = new System.Drawing.Point(348, 30);
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
            this.IsSkip.Location = new System.Drawing.Point(180, 33);
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
            this.label1.Location = new System.Drawing.Point(15, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "我的意见：";
            // 
            // UserOpinion
            // 
            this.UserOpinion.Location = new System.Drawing.Point(83, 112);
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
            this.IsPass.Location = new System.Drawing.Point(82, 33);
            this.IsPass.Name = "IsPass";
            this.IsPass.Size = new System.Drawing.Size(48, 16);
            this.IsPass.TabIndex = 0;
            this.IsPass.Text = "同意";
            this.IsPass.UseVisualStyleBackColor = false;
            this.IsPass.CheckedChanged += new System.EventHandler(this.IsPass_CheckedChanged);
            // 
            // FrmApprove_Single_Boss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(510, 470);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmApprove_Single_Boss";
            this.Text = "领导审核";
            this.Load += new System.EventHandler(this.FrmApprove_Single_Boss_Load);
            this.Shown += new System.EventHandler(this.FrmApprove_Single_Boss_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_More;
        private System.Windows.Forms.Button Btn_Voided;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label LB_GoPointID;
        private System.Windows.Forms.ComboBox CB_GoPointID;
        private System.Windows.Forms.CheckBox IsSkip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserOpinion;
        private System.Windows.Forms.CheckBox IsPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Abate;
        private System.Windows.Forms.Label LB_Tip;
    }
}
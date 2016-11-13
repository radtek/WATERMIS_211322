namespace PersonalWork
{
    partial class FrmApprove_Group_Install
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Group_Install));
            this.panel1 = new System.Windows.Forms.Panel();
            this.waterUserPeopleCount = new System.Windows.Forms.TextBox();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UserOpinion = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.waterUserPeopleCount);
            this.panel1.Controls.Add(this.Btn_Save);
            this.panel1.Controls.Add(this.FP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UserOpinion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 447);
            this.panel1.TabIndex = 2;
            // 
            // waterUserPeopleCount
            // 
            this.waterUserPeopleCount.Enabled = false;
            this.waterUserPeopleCount.Location = new System.Drawing.Point(83, 88);
            this.waterUserPeopleCount.Name = "waterUserPeopleCount";
            this.waterUserPeopleCount.ReadOnly = true;
            this.waterUserPeopleCount.Size = new System.Drawing.Size(84, 21);
            this.waterUserPeopleCount.TabIndex = 98;
            this.waterUserPeopleCount.Text = "0";
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.SeaGreen;
            this.Btn_Save.FlatAppearance.BorderSize = 0;
            this.Btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Save.ForeColor = System.Drawing.Color.White;
            this.Btn_Save.Location = new System.Drawing.Point(115, 400);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(129, 41);
            this.Btn_Save.TabIndex = 88;
            this.Btn_Save.Text = "保存信息";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // FP
            // 
            this.FP.AutoScroll = true;
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FP.Location = new System.Drawing.Point(17, 115);
            this.FP.Name = "FP";
            this.FP.Size = new System.Drawing.Size(474, 273);
            this.FP.TabIndex = 87;
            this.FP.Click += new System.EventHandler(this.FP_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(15, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 86;
            this.label4.Text = "用户详情：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.SeaGreen;
            this.Btn_Submit.FlatAppearance.BorderSize = 0;
            this.Btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.ForeColor = System.Drawing.Color.White;
            this.Btn_Submit.Location = new System.Drawing.Point(265, 400);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(129, 41);
            this.Btn_Submit.TabIndex = 6;
            this.Btn_Submit.Text = "提交审批";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Visible = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "审批意见：";
            // 
            // UserOpinion
            // 
            this.UserOpinion.Location = new System.Drawing.Point(83, 14);
            this.UserOpinion.Multiline = true;
            this.UserOpinion.Name = "UserOpinion";
            this.UserOpinion.Size = new System.Drawing.Size(408, 69);
            this.UserOpinion.TabIndex = 1;
            // 
            // FrmApprove_Group_Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 447);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmApprove_Group_Install";
            this.Text = "FrmApprove_Group_Install";
            this.Load += new System.EventHandler(this.FrmApprove_Group_Install_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserOpinion;
        private System.Windows.Forms.FlowLayoutPanel FP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.TextBox waterUserPeopleCount;
    }
}
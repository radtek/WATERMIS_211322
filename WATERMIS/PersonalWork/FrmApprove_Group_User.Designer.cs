namespace PersonalWork
{
    partial class FrmApprove_Group_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Group_User));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAddWaterUserBatch = new System.Windows.Forms.Button();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.btAddWaterUserBatch);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 447);
            this.panel1.TabIndex = 2;
            // 
            // btAddWaterUserBatch
            // 
            this.btAddWaterUserBatch.BackColor = System.Drawing.Color.SeaGreen;
            this.btAddWaterUserBatch.FlatAppearance.BorderSize = 0;
            this.btAddWaterUserBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddWaterUserBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btAddWaterUserBatch.ForeColor = System.Drawing.Color.White;
            this.btAddWaterUserBatch.Location = new System.Drawing.Point(147, 76);
            this.btAddWaterUserBatch.Name = "btAddWaterUserBatch";
            this.btAddWaterUserBatch.Size = new System.Drawing.Size(129, 41);
            this.btAddWaterUserBatch.TabIndex = 7;
            this.btAddWaterUserBatch.Text = "开始增户";
            this.btAddWaterUserBatch.UseVisualStyleBackColor = false;
            this.btAddWaterUserBatch.Click += new System.EventHandler(this.btAddWaterUserBatch_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.BackColor = System.Drawing.Color.SeaGreen;
            this.Btn_Submit.FlatAppearance.BorderSize = 0;
            this.Btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Submit.ForeColor = System.Drawing.Color.White;
            this.Btn_Submit.Location = new System.Drawing.Point(147, 138);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(129, 41);
            this.Btn_Submit.TabIndex = 6;
            this.Btn_Submit.Text = "增户完成";
            this.Btn_Submit.UseVisualStyleBackColor = false;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // FrmApprove_Group_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 447);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmApprove_Group_User";
            this.Text = "FrmApprove_Group_User";
            this.Load += new System.EventHandler(this.FrmApprove_Group_User_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Button btAddWaterUserBatch;
    }
}
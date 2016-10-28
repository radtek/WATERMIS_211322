namespace PersonalWork
{
    partial class FrmApprove_Group_Final
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
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(161, 358);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(97, 33);
            this.Btn_Submit.TabIndex = 26;
            this.Btn_Submit.Text = "收费完成";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            // 
            // FrmApprove_Group_Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 430);
            this.Controls.Add(this.Btn_Submit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmApprove_Group_Final";
            this.Text = "FrmApprove_Group_Final";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Submit;
    }
}
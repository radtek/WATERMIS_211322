namespace SysControl
{
    partial class FrmGroupMeter_Show
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupMeter_Show));
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FP
            // 
            this.FP.AutoScroll = true;
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP.Location = new System.Drawing.Point(0, 0);
            this.FP.Name = "FP";
            this.FP.Size = new System.Drawing.Size(451, 233);
            this.FP.TabIndex = 87;
            // 
            // FrmGroupMeter_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 233);
            this.Controls.Add(this.FP);
            this.Name = "FrmGroupMeter_Show";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单位用户报装-水表安装详情";
            this.Load += new System.EventHandler(this.FrmGroupMeter_Show_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FP;

    }
}
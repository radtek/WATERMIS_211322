namespace PersonalWork
{
    partial class FrmChargePoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChargePoint));
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FP
            // 
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP.Location = new System.Drawing.Point(0, 0);
            this.FP.Name = "FP";
            this.FP.Size = new System.Drawing.Size(618, 462);
            this.FP.TabIndex = 0;
            // 
            // FrmChargePoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 462);
            this.Controls.Add(this.FP);
            this.Name = "FrmChargePoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "费用明细表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FP;
    }
}
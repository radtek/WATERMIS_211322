namespace FinanceOS
{
    partial class FrmFinanceCenter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinanceCenter));
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FP
            // 
            this.FP.AutoScroll = true;
            this.FP.BackColor = System.Drawing.Color.White;
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP.Location = new System.Drawing.Point(0, 0);
            this.FP.Name = "FP";
            this.FP.Padding = new System.Windows.Forms.Padding(30);
            this.FP.Size = new System.Drawing.Size(698, 591);
            this.FP.TabIndex = 1;
            // 
            // FrmFinanceCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 591);
            this.Controls.Add(this.FP);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmFinanceCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "业扩收费";
            this.Load += new System.EventHandler(this.FrmFinanceCenter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FP;
    }
}
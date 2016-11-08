namespace SysControl
{
    partial class FrmFileShow
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
            this.WB1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WB1
            // 
            this.WB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB1.Location = new System.Drawing.Point(0, 0);
            this.WB1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB1.Name = "WB1";
            this.WB1.Size = new System.Drawing.Size(682, 582);
            this.WB1.TabIndex = 0;
            this.WB1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // FrmFileShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 582);
            this.Controls.Add(this.WB1);
            this.Name = "FrmFileShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件查看";
            this.Load += new System.EventHandler(this.FrmFileShow_Load);
            this.Shown += new System.EventHandler(this.FrmFileShow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WB1;
    }
}
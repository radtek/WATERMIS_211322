namespace SysControl
{
    partial class FrmFileUpload
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
            this.WB1.IsWebBrowserContextMenuEnabled = false;
            this.WB1.Location = new System.Drawing.Point(0, 0);
            this.WB1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB1.Name = "WB1";
            this.WB1.ScriptErrorsSuppressed = true;
            this.WB1.ScrollBarsEnabled = false;
            this.WB1.Size = new System.Drawing.Size(604, 625);
            this.WB1.TabIndex = 0;
            this.WB1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB1_DocumentCompleted);
            // 
            // FrmFileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 625);
            this.Controls.Add(this.WB1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFileUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片上传";
            this.Load += new System.EventHandler(this.FrmFileUpload_Load);
            this.Shown += new System.EventHandler(this.FrmFileUpload_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WB1;

    }
}
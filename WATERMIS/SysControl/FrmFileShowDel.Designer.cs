namespace SysControl
{
    partial class FrmFileShowDel
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
            this.WB1.Size = new System.Drawing.Size(667, 618);
            this.WB1.TabIndex = 1;
            this.WB1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB1_DocumentCompleted);
            // 
            // FrmFileShowDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 618);
            this.Controls.Add(this.WB1);
            this.Name = "FrmFileShowDel";
            this.Text = "图片查看删除";
            this.Load += new System.EventHandler(this.FrmFileShowDel_Load);
            this.Shown += new System.EventHandler(this.FrmFileShowDel_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WB1;
    }
}
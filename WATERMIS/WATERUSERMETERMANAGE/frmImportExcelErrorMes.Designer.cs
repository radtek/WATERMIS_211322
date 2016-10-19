namespace WATERUSERMETERMANAGE
{
    partial class frmImportExcelErrorMes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportExcelErrorMes));
            this.rtxtError = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtError
            // 
            this.rtxtError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtError.Location = new System.Drawing.Point(0, 0);
            this.rtxtError.Name = "rtxtError";
            this.rtxtError.ReadOnly = true;
            this.rtxtError.Size = new System.Drawing.Size(505, 418);
            this.rtxtError.TabIndex = 0;
            this.rtxtError.Text = "";
            // 
            // frmImportExcelErrorMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 418);
            this.Controls.Add(this.rtxtError);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmImportExcelErrorMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EXCEL导入问题";
            this.Load += new System.EventHandler(this.frmImportExcelErrorMes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtError;
    }
}
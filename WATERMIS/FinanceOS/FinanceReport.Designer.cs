namespace FinanceOS
{
    partial class FinanceReport
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WB4 = new System.Windows.Forms.WebBrowser();
            this.WB3 = new System.Windows.Forms.WebBrowser();
            this.WB2 = new System.Windows.Forms.WebBrowser();
            this.WB1 = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.WB4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.WB3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.WB2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.WB1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 773);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // WB4
            // 
            this.WB4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB4.IsWebBrowserContextMenuEnabled = false;
            this.WB4.Location = new System.Drawing.Point(561, 389);
            this.WB4.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB4.Name = "WB4";
            this.WB4.Size = new System.Drawing.Size(552, 381);
            this.WB4.TabIndex = 3;
            this.WB4.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB4_DocumentCompleted);
            // 
            // WB3
            // 
            this.WB3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB3.IsWebBrowserContextMenuEnabled = false;
            this.WB3.Location = new System.Drawing.Point(3, 389);
            this.WB3.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB3.Name = "WB3";
            this.WB3.Size = new System.Drawing.Size(552, 381);
            this.WB3.TabIndex = 2;
            this.WB3.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB3_DocumentCompleted);
            // 
            // WB2
            // 
            this.WB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB2.IsWebBrowserContextMenuEnabled = false;
            this.WB2.Location = new System.Drawing.Point(561, 3);
            this.WB2.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB2.Name = "WB2";
            this.WB2.Size = new System.Drawing.Size(552, 380);
            this.WB2.TabIndex = 1;
            this.WB2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB2_DocumentCompleted);
            // 
            // WB1
            // 
            this.WB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB1.IsWebBrowserContextMenuEnabled = false;
            this.WB1.Location = new System.Drawing.Point(3, 3);
            this.WB1.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB1.Name = "WB1";
            this.WB1.Size = new System.Drawing.Size(552, 380);
            this.WB1.TabIndex = 0;
            this.WB1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB1_DocumentCompleted);
            // 
            // FinanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 773);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FinanceReport";
            this.Text = "财务报表";
            this.Load += new System.EventHandler(this.FinanceReport_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.WebBrowser WB4;
        private System.Windows.Forms.WebBrowser WB3;
        private System.Windows.Forms.WebBrowser WB2;
        private System.Windows.Forms.WebBrowser WB1;
    }
}
namespace SYSMANAGE
{
    partial class frmNoticeShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoticeShow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labClass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labFromName = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.Label();
            this.labContent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labClass, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labFromName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labTitle, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labContent, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 304F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 458);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labClass
            // 
            this.labClass.AutoSize = true;
            this.labClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labClass.Location = new System.Drawing.Point(105, 2);
            this.labClass.Name = "labClass";
            this.labClass.Size = new System.Drawing.Size(426, 34);
            this.labClass.TabIndex = 10;
            this.labClass.Tag = "9999";
            this.labClass.Text = "消息级别";
            this.labClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 304);
            this.label1.TabIndex = 4;
            this.label1.Text = "消息内容：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(5, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 100);
            this.label2.TabIndex = 2;
            this.label2.Text = "消息标题：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(5, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 40);
            this.label3.TabIndex = 3;
            this.label3.Text = "发件人：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labFromName
            // 
            this.labFromName.AutoSize = true;
            this.labFromName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFromName.Location = new System.Drawing.Point(105, 38);
            this.labFromName.Name = "labFromName";
            this.labFromName.Size = new System.Drawing.Size(426, 40);
            this.labFromName.TabIndex = 5;
            this.labFromName.Text = "发件人";
            this.labFromName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTitle.ForeColor = System.Drawing.Color.Red;
            this.labTitle.Location = new System.Drawing.Point(105, 80);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(426, 100);
            this.labTitle.TabIndex = 6;
            this.labTitle.Tag = "9999";
            this.labTitle.Text = "消息标题";
            // 
            // labContent
            // 
            this.labContent.AutoSize = true;
            this.labContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labContent.Location = new System.Drawing.Point(105, 182);
            this.labContent.Name = "labContent";
            this.labContent.Size = new System.Drawing.Size(426, 304);
            this.labContent.TabIndex = 8;
            this.labContent.Text = "消息内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(5, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 34);
            this.label4.TabIndex = 9;
            this.label4.Text = "消息级别:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmNoticeShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 458);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNoticeShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息查看";
            this.Load += new System.EventHandler(this.frmNoticeShow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labFromName;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label labContent;
        private System.Windows.Forms.Label labClass;
        private System.Windows.Forms.Label label4;

    }
}
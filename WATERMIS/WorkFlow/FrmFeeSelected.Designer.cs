namespace WorkFlow
{
    partial class FrmFeeSelected
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeeSelected));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.FP1 = new System.Windows.Forms.FlowLayoutPanel();
            this.RB_Final = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FP1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.05467F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.94533F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(627, 439);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.RB_Final);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 64);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(244, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "确  定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FP1
            // 
            this.FP1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP1.BackgroundImage")));
            this.FP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP1.Location = new System.Drawing.Point(3, 3);
            this.FP1.Name = "FP1";
            this.FP1.Size = new System.Drawing.Size(621, 363);
            this.FP1.TabIndex = 1;
            // 
            // RB_Final
            // 
            this.RB_Final.AutoSize = true;
            this.RB_Final.BackColor = System.Drawing.Color.Transparent;
            this.RB_Final.Checked = true;
            this.RB_Final.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RB_Final.Location = new System.Drawing.Point(31, 24);
            this.RB_Final.Name = "RB_Final";
            this.RB_Final.Size = new System.Drawing.Size(48, 16);
            this.RB_Final.TabIndex = 2;
            this.RB_Final.Text = "预收";
            this.RB_Final.UseVisualStyleBackColor = false;
            this.RB_Final.CheckedChanged += new System.EventHandler(this.RB_Final_CheckedChanged_1);
            // 
            // FrmFeeSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 439);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmFeeSelected";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收费项目选择";
            this.Load += new System.EventHandler(this.FrmFeeSelected_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel FP1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox RB_Final;
    }
}
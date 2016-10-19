namespace SYSMANAGE
{
    partial class frmBackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackUp));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btBackUp = new System.Windows.Forms.Button();
            this.labPosition = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.btBackUp);
            this.groupBox1.Controls.Add(this.labPosition);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(443, 235);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库备份";
            // 
            // btBackUp
            // 
            this.btBackUp.Location = new System.Drawing.Point(11, 25);
            this.btBackUp.Margin = new System.Windows.Forms.Padding(4);
            this.btBackUp.Name = "btBackUp";
            this.btBackUp.Size = new System.Drawing.Size(100, 31);
            this.btBackUp.TabIndex = 1;
            this.btBackUp.Text = "点击备份";
            this.btBackUp.UseVisualStyleBackColor = true;
            this.btBackUp.Click += new System.EventHandler(this.btBackUp_Click);
            // 
            // labPosition
            // 
            this.labPosition.Location = new System.Drawing.Point(12, 67);
            this.labPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labPosition.Name = "labPosition";
            this.labPosition.Size = new System.Drawing.Size(411, 165);
            this.labPosition.TabIndex = 0;
            this.labPosition.Text = "备份到的路径";
            // 
            // frmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(443, 245);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBackUp";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Text = "数据库备份";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labPosition;
        private System.Windows.Forms.Button btBackUp;
    }
}
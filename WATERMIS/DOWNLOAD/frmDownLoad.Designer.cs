namespace DOWNLOAD
{
    partial class frmDownLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownLoad));
            this.labFile = new System.Windows.Forms.Label();
            this.btDown = new System.Windows.Forms.Button();
            this.labState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labFile
            // 
            this.labFile.AutoSize = true;
            this.labFile.BackColor = System.Drawing.Color.Transparent;
            this.labFile.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labFile.Location = new System.Drawing.Point(5, 47);
            this.labFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFile.Name = "labFile";
            this.labFile.Size = new System.Drawing.Size(0, 14);
            this.labFile.TabIndex = 0;
            // 
            // btDown
            // 
            this.btDown.Location = new System.Drawing.Point(0, 7);
            this.btDown.Margin = new System.Windows.Forms.Padding(4);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(123, 31);
            this.btDown.TabIndex = 1;
            this.btDown.Text = "点击开始更新";
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.BackColor = System.Drawing.Color.Transparent;
            this.labState.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labState.ForeColor = System.Drawing.Color.Red;
            this.labState.Location = new System.Drawing.Point(129, 17);
            this.labState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(0, 14);
            this.labState.TabIndex = 0;
            // 
            // frmDownLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DOWNLOAD.Properties.Resources.登录界面;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(318, 188);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.labFile);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件下载";
            this.Load += new System.EventHandler(this.frmDownLoad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labFile;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Label labState;
    }
}
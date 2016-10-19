namespace SysControl
{
    partial class UC_Menu
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Menu));
            this.sMetroPicture = new System.Windows.Forms.PictureBox();
            this.sMetroTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sMetroPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // sMetroPicture
            // 
            this.sMetroPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sMetroPicture.BackgroundImage")));
            this.sMetroPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sMetroPicture.Location = new System.Drawing.Point(5, 5);
            this.sMetroPicture.Name = "sMetroPicture";
            this.sMetroPicture.Size = new System.Drawing.Size(64, 64);
            this.sMetroPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sMetroPicture.TabIndex = 0;
            this.sMetroPicture.TabStop = false;
            this.sMetroPicture.Tag = "9999";
            this.sMetroPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sMetroTitle
            // 
            this.sMetroTitle.AutoSize = true;
            this.sMetroTitle.BackColor = System.Drawing.Color.Transparent;
            this.sMetroTitle.Location = new System.Drawing.Point(13, 75);
            this.sMetroTitle.Name = "sMetroTitle";
            this.sMetroTitle.Size = new System.Drawing.Size(0, 12);
            this.sMetroTitle.TabIndex = 2;
            this.sMetroTitle.Tag = "9999";
            // 
            // UC_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.sMetroTitle);
            this.Controls.Add(this.sMetroPicture);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.Name = "UC_Menu";
            this.Size = new System.Drawing.Size(75, 93);
            this.Tag = "9999";
            this.Load += new System.EventHandler(this.UC_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sMetroPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sMetroPicture;
        private System.Windows.Forms.Label sMetroTitle;
    }
}

namespace PersonalWork
{
    partial class FrmPersonalCenter
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonalCenter));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.PL = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FP);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PL);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 741);
            this.splitContainer1.SplitterDistance = 112;
            this.splitContainer1.TabIndex = 5;
            // 
            // FP
            // 
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP.Location = new System.Drawing.Point(0, 0);
            this.FP.Name = "FP";
            this.FP.Size = new System.Drawing.Size(112, 741);
            this.FP.TabIndex = 4;
            // 
            // PL
            // 
            this.PL.BackColor = System.Drawing.Color.Transparent;
            this.PL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PL.BackgroundImage")));
            this.PL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL.Location = new System.Drawing.Point(0, 0);
            this.PL.Name = "PL";
            this.PL.Size = new System.Drawing.Size(904, 741);
            this.PL.TabIndex = 0;
            // 
            // FrmPersonalCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 741);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPersonalCenter";
            this.Text = "个人事务处理中心";
            this.Load += new System.EventHandler(this.FrmPersonalCenter_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel FP;
        private System.Windows.Forms.Panel PL;


    }
}


namespace SysControl
{
    partial class UC_FlowList
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
            this.FP_Flow = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FP_Flow
            // 
            this.FP_Flow.AutoScroll = true;
            this.FP_Flow.BackColor = System.Drawing.Color.White;
            this.FP_Flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP_Flow.Location = new System.Drawing.Point(0, 0);
            this.FP_Flow.Name = "FP_Flow";
            this.FP_Flow.Size = new System.Drawing.Size(900, 85);
            this.FP_Flow.TabIndex = 904;
            this.FP_Flow.Tag = "9999";
            this.FP_Flow.WrapContents = false;
            // 
            // UC_FlowList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.FP_Flow);
            this.MinimumSize = new System.Drawing.Size(900, 85);
            this.Name = "UC_FlowList";
            this.Size = new System.Drawing.Size(900, 85);
            this.Tag = "9999";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FP_Flow;
    }
}

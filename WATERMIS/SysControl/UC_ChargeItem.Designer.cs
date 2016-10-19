namespace SysControl
{
    partial class UC_ChargeItem
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
            this.LB_FeeItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_FeeItem
            // 
            this.LB_FeeItem.AutoSize = true;
            this.LB_FeeItem.BackColor = System.Drawing.Color.Transparent;
            this.LB_FeeItem.Location = new System.Drawing.Point(8, 7);
            this.LB_FeeItem.Name = "LB_FeeItem";
            this.LB_FeeItem.Size = new System.Drawing.Size(0, 12);
            this.LB_FeeItem.TabIndex = 1;
            // 
            // UC_ChargeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LB_FeeItem);
            this.Name = "UC_ChargeItem";
            this.Size = new System.Drawing.Size(142, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_FeeItem;
    }
}

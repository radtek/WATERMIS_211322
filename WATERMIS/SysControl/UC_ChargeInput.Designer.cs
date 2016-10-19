namespace SysControl
{
    partial class UC_ChargeInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ChargeInput));
            this.LB_FeeName = new System.Windows.Forms.Label();
            this.TB_Fee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_FeeName
            // 
            this.LB_FeeName.AutoSize = true;
            this.LB_FeeName.BackColor = System.Drawing.Color.Transparent;
            this.LB_FeeName.Location = new System.Drawing.Point(10, 8);
            this.LB_FeeName.Name = "LB_FeeName";
            this.LB_FeeName.Size = new System.Drawing.Size(53, 12);
            this.LB_FeeName.TabIndex = 0;
            this.LB_FeeName.Text = "设计费：";
            // 
            // TB_Fee
            // 
            this.TB_Fee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Fee.Location = new System.Drawing.Point(80, 3);
            this.TB_Fee.Name = "TB_Fee";
            this.TB_Fee.Size = new System.Drawing.Size(112, 21);
            this.TB_Fee.TabIndex = 1;
            this.TB_Fee.TextChanged += new System.EventHandler(this.TB_Fee_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(201, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "元";
            // 
            // UC_ChargeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Fee);
            this.Controls.Add(this.LB_FeeName);
            this.Name = "UC_ChargeInput";
            this.Size = new System.Drawing.Size(225, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_FeeName;
        private System.Windows.Forms.TextBox TB_Fee;
        private System.Windows.Forms.Label label2;
    }
}

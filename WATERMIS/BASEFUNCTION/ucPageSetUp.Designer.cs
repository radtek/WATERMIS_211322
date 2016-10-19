namespace BASEFUNCTION
{
    partial class ucPageSetUp
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
            this.txtPageNO = new System.Windows.Forms.TextBox();
            this.btNextPage = new System.Windows.Forms.Button();
            this.btLastPage = new System.Windows.Forms.Button();
            this.btEndPage = new System.Windows.Forms.Button();
            this.btFirst = new System.Windows.Forms.Button();
            this.labSumPage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPageNO
            // 
            this.txtPageNO.Location = new System.Drawing.Point(85, 4);
            this.txtPageNO.Name = "txtPageNO";
            this.txtPageNO.Size = new System.Drawing.Size(35, 21);
            this.txtPageNO.TabIndex = 9;
            this.txtPageNO.Text = "1";
            this.txtPageNO.TextChanged += new System.EventHandler(this.txtPageNO_TextChanged);
            this.txtPageNO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNO_KeyPress);
            // 
            // btNextPage
            // 
            this.btNextPage.Location = new System.Drawing.Point(156, 3);
            this.btNextPage.Name = "btNextPage";
            this.btNextPage.Size = new System.Drawing.Size(39, 23);
            this.btNextPage.TabIndex = 8;
            this.btNextPage.Text = "下页";
            this.btNextPage.UseVisualStyleBackColor = true;
            this.btNextPage.Click += new System.EventHandler(this.btNextPage_Click);
            // 
            // btLastPage
            // 
            this.btLastPage.Location = new System.Drawing.Point(40, 3);
            this.btLastPage.Name = "btLastPage";
            this.btLastPage.Size = new System.Drawing.Size(39, 23);
            this.btLastPage.TabIndex = 7;
            this.btLastPage.Text = "上页";
            this.btLastPage.UseVisualStyleBackColor = true;
            this.btLastPage.Click += new System.EventHandler(this.btLastPage_Click);
            // 
            // btEndPage
            // 
            this.btEndPage.Location = new System.Drawing.Point(195, 3);
            this.btEndPage.Name = "btEndPage";
            this.btEndPage.Size = new System.Drawing.Size(39, 23);
            this.btEndPage.TabIndex = 6;
            this.btEndPage.Text = "末页";
            this.btEndPage.UseVisualStyleBackColor = true;
            this.btEndPage.Click += new System.EventHandler(this.btEndPage_Click);
            // 
            // btFirst
            // 
            this.btFirst.Location = new System.Drawing.Point(1, 3);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(39, 23);
            this.btFirst.TabIndex = 5;
            this.btFirst.Text = "首页";
            this.btFirst.UseVisualStyleBackColor = true;
            this.btFirst.Click += new System.EventHandler(this.btFirst_Click);
            // 
            // labSumPage
            // 
            this.labSumPage.AutoSize = true;
            this.labSumPage.Location = new System.Drawing.Point(121, 8);
            this.labSumPage.Name = "labSumPage";
            this.labSumPage.Size = new System.Drawing.Size(17, 12);
            this.labSumPage.TabIndex = 10;
            this.labSumPage.Text = "/1";
            // 
            // ucPageSetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labSumPage);
            this.Controls.Add(this.txtPageNO);
            this.Controls.Add(this.btNextPage);
            this.Controls.Add(this.btLastPage);
            this.Controls.Add(this.btEndPage);
            this.Controls.Add(this.btFirst);
            this.Name = "ucPageSetUp";
            this.Size = new System.Drawing.Size(236, 29);
            this.Load += new System.EventHandler(this.ucPageSetUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPageNO;
        private System.Windows.Forms.Button btNextPage;
        private System.Windows.Forms.Button btLastPage;
        private System.Windows.Forms.Button btEndPage;
        private System.Windows.Forms.Button btFirst;
        private System.Windows.Forms.Label labSumPage;
    }
}

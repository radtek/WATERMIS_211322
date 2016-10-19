namespace SysControl
{
    partial class UC_DepartmentFee
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
            this.Btn_Dep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Dep
            // 
            this.Btn_Dep.BackColor = System.Drawing.Color.Tan;
            this.Btn_Dep.FlatAppearance.BorderSize = 0;
            this.Btn_Dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Dep.Location = new System.Drawing.Point(0, 0);
            this.Btn_Dep.Name = "Btn_Dep";
            this.Btn_Dep.Size = new System.Drawing.Size(150, 30);
            this.Btn_Dep.TabIndex = 2;
            this.Btn_Dep.Tag = "9999";
            this.Btn_Dep.UseVisualStyleBackColor = false;
            this.Btn_Dep.Click += new System.EventHandler(this.Btn_Dep_Click);
            // 
            // UC_DepartmentFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_Dep);
            this.Name = "UC_DepartmentFee";
            this.Size = new System.Drawing.Size(150, 30);
            this.Load += new System.EventHandler(this.UC_DepartmentFee_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Dep;

    }
}

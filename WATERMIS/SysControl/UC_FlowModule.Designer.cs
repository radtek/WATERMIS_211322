namespace SysControl
{
    partial class UC_FlowModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_FlowModule));
            this.LB_Name = new System.Windows.Forms.Label();
            this.LB_Date = new System.Windows.Forms.Label();
            this.LB_Point = new System.Windows.Forms.Label();
            this.LB_PointGo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_Name
            // 
            this.LB_Name.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_Name.Location = new System.Drawing.Point(13, 3);
            this.LB_Name.Name = "LB_Name";
            this.LB_Name.Size = new System.Drawing.Size(73, 17);
            this.LB_Name.TabIndex = 0;
            this.LB_Name.Click += new System.EventHandler(this.LB_Point_Click);
            // 
            // LB_Date
            // 
            this.LB_Date.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_Date.Location = new System.Drawing.Point(8, 41);
            this.LB_Date.Name = "LB_Date";
            this.LB_Date.Size = new System.Drawing.Size(80, 17);
            this.LB_Date.TabIndex = 1;
            this.LB_Date.Text = "------------";
            this.LB_Date.Click += new System.EventHandler(this.LB_Point_Click);
            // 
            // LB_Point
            // 
            this.LB_Point.BackColor = System.Drawing.Color.Green;
            this.LB_Point.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LB_Point.ForeColor = System.Drawing.Color.White;
            this.LB_Point.Image = ((System.Drawing.Image)(resources.GetObject("LB_Point.Image")));
            this.LB_Point.Location = new System.Drawing.Point(107, 0);
            this.LB_Point.Name = "LB_Point";
            this.LB_Point.Size = new System.Drawing.Size(107, 64);
            this.LB_Point.TabIndex = 2;
            this.LB_Point.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Point.Click += new System.EventHandler(this.LB_Point_Click);
            // 
            // LB_PointGo
            // 
            this.LB_PointGo.BackColor = System.Drawing.Color.Green;
            this.LB_PointGo.Image = ((System.Drawing.Image)(resources.GetObject("LB_PointGo.Image")));
            this.LB_PointGo.Location = new System.Drawing.Point(3, 21);
            this.LB_PointGo.Name = "LB_PointGo";
            this.LB_PointGo.Size = new System.Drawing.Size(102, 18);
            this.LB_PointGo.TabIndex = 4;
            this.LB_PointGo.Click += new System.EventHandler(this.LB_Point_Click);
            // 
            // UC_FlowModule
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LB_PointGo);
            this.Controls.Add(this.LB_Point);
            this.Controls.Add(this.LB_Date);
            this.Controls.Add(this.LB_Name);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_FlowModule";
            this.Size = new System.Drawing.Size(217, 66);
            this.Load += new System.EventHandler(this.UC_FlowModule_Load);
            this.Click += new System.EventHandler(this.LB_Point_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LB_Name;
        private System.Windows.Forms.Label LB_Date;
        private System.Windows.Forms.Label LB_Point;
        private System.Windows.Forms.Label LB_PointGo;
    }
}

namespace SysControl
{
    partial class UC_ApproveList
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
            this.dgPoint = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPoint
            // 
            this.dgPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPoint.Location = new System.Drawing.Point(0, 0);
            this.dgPoint.Name = "dgPoint";
            this.dgPoint.RowTemplate.Height = 23;
            this.dgPoint.Size = new System.Drawing.Size(612, 666);
            this.dgPoint.TabIndex = 2;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "ROWNUM";
            this.Column9.FillWeight = 40F;
            this.Column9.HeaderText = "序号";
            this.Column9.Name = "Column9";
            this.Column9.Width = 40;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PointSort";
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "节点";
            this.Column1.Name = "Column1";
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "PointName";
            this.Column2.HeaderText = "节点名称";
            this.Column2.Name = "Column2";
            this.Column2.Width = 78;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "DoName";
            this.Column3.HeaderText = "审核明细";
            this.Column3.Name = "Column3";
            this.Column3.Width = 78;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column4.DataPropertyName = "userName";
            this.Column4.HeaderText = "(待)审核人";
            this.Column4.Name = "Column4";
            this.Column4.Width = 21;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "AcceptDate";
            this.Column5.HeaderText = "审核时间";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.DataPropertyName = "UserOpinion";
            this.Column6.HeaderText = "审核意见";
            this.Column6.Name = "Column6";
            this.Column6.Width = 78;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "IsPass";
            this.Column7.FillWeight = 50F;
            this.Column7.HeaderText = "审核状态";
            this.Column7.Name = "Column7";
            this.Column7.Width = 50;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "GoPointID";
            this.Column8.FillWeight = 60F;
            this.Column8.HeaderText = "审核跳转";
            this.Column8.Name = "Column8";
            this.Column8.Width = 60;
            // 
            // UC_ApproveList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgPoint);
            this.Name = "UC_ApproveList";
            this.Size = new System.Drawing.Size(612, 666);
            ((System.ComponentModel.ISupportInitialize)(this.dgPoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}

namespace SYSMANAGE
{
    partial class frmSysVision
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSysVision));
            this.gbList = new System.Windows.Forms.GroupBox();
            this.dgFile = new System.Windows.Forms.DataGridView();
            this.FileVision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFile)).BeginInit();
            this.SuspendLayout();
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.dgFile);
            this.gbList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbList.Location = new System.Drawing.Point(10, 10);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(499, 424);
            this.gbList.TabIndex = 0;
            this.gbList.TabStop = false;
            this.gbList.Text = "文件列表";
            // 
            // dgFile
            // 
            this.dgFile.AllowUserToAddRows = false;
            this.dgFile.AllowUserToDeleteRows = false;
            this.dgFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFile.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFile.ColumnHeadersHeight = 25;
            this.dgFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.FileVision});
            this.dgFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFile.Location = new System.Drawing.Point(3, 19);
            this.dgFile.Name = "dgFile";
            this.dgFile.ReadOnly = true;
            this.dgFile.RowTemplate.Height = 23;
            this.dgFile.Size = new System.Drawing.Size(493, 402);
            this.dgFile.TabIndex = 0;
            this.dgFile.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgFile_CellPainting);
            // 
            // FileVision
            // 
            this.FileVision.HeaderText = "文件版本";
            this.FileVision.Name = "FileVision";
            this.FileVision.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "文件名称";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // frmSysVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 444);
            this.Controls.Add(this.gbList);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSysVision";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于系统";
            this.Load += new System.EventHandler(this.frmSysVision_Load);
            this.gbList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.DataGridView dgFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileVision;


    }
}
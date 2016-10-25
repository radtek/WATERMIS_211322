namespace SysControl
{
    partial class UC_DataGridView_Page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_DataGridView_Page));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uPage = new SysControl.UC_PageControlBar();
            this.DG = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.uPage, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.DG, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(841, 279);
            this.tableLayoutPanel2.TabIndex = 1;
            this.tableLayoutPanel2.Tag = "9999";
            // 
            // uPage
            // 
            this.uPage.AutoSize = true;
            this.uPage.BackColor = System.Drawing.Color.White;
            this.uPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uPage.BackgroundImage")));
            this.uPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uPage.Location = new System.Drawing.Point(0, 246);
            this.uPage.Margin = new System.Windows.Forms.Padding(0);
            this.uPage.MinimumSize = new System.Drawing.Size(830, 22);
            this.uPage.Name = "uPage";
            this.uPage.Size = new System.Drawing.Size(841, 33);
            this.uPage.TabIndex = 3;
            this.uPage.Tag = "9999";
            this.uPage.myPagerEvents += new SysControl.UC_PageControlBar.MyPagerEvents(this.uPage_myPagerEvents);
            // 
            // DG
            // 
            this.DG.AllowUserToAddRows = false;
            this.DG.AllowUserToDeleteRows = false;
            this.DG.AllowUserToOrderColumns = true;
            this.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DG.BackgroundColor = System.Drawing.Color.White;
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG.Location = new System.Drawing.Point(3, 3);
            this.DG.Name = "DG";
            this.DG.ReadOnly = true;
            this.DG.RowTemplate.Height = 23;
            this.DG.Size = new System.Drawing.Size(835, 240);
            this.DG.TabIndex = 1;
            this.DG.Tag = "9999";
            this.DG.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellDoubleClick);
            this.DG.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DG_CellPainting);
            this.DG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellClick);
            // 
            // UC_DataGridView_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(833, 80);
            this.Name = "UC_DataGridView_Page";
            this.Size = new System.Drawing.Size(841, 279);
            this.Tag = "9999";
            this.Load += new System.EventHandler(this.UC_DataGridView_Page_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView DG;
        private UC_PageControlBar uPage;


    }
}

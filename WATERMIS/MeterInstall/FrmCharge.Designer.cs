namespace MeterInstall
{
    partial class FrmCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCharge));
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.uC_SearchCharge1 = new SysControl.UC_SearchCharge();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.tb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tb1.BackgroundImage")));
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.uC_SearchCharge1, 0, 0);
            this.tb1.Controls.Add(this.uC_DataGridView_Page1, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.Size = new System.Drawing.Size(1096, 735);
            this.tb1.TabIndex = 59;
            this.tb1.Tag = "9999";
            // 
            // uC_SearchCharge1
            // 
            this.uC_SearchCharge1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uC_SearchCharge1.BackgroundImage")));
            this.uC_SearchCharge1.Location = new System.Drawing.Point(0, 0);
            this.uC_SearchCharge1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_SearchCharge1.Name = "uC_SearchCharge1";
            this.uC_SearchCharge1.Size = new System.Drawing.Size(848, 65);
            this.uC_SearchCharge1.TabIndex = 909;
            this.uC_SearchCharge1.Load += new System.EventHandler(this.uC_SearchCharge1_Load);
            this.uC_SearchCharge1.BtnEvent += new System.EventHandler(this.uC_SearchCharge1_BtnEvent);
            // 
            // uC_DataGridView_Page1
            // 
            this.uC_DataGridView_Page1.AutoSize = true;
            this.uC_DataGridView_Page1.BackColor = System.Drawing.Color.White;
            this.uC_DataGridView_Page1.DataStatis = null;
            this.uC_DataGridView_Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DataGridView_Page1.Fields = null;
            this.uC_DataGridView_Page1.FieldStatis = null;
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(3, 68);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(833, 393);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(1090, 664);
            this.uC_DataGridView_Page1.TabIndex = 910;
            this.uC_DataGridView_Page1.Tag = "9999";
            // 
            // FrmCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 735);
            this.Controls.Add(this.tb1);
            this.Name = "FrmCharge";
            this.Text = "收费记录";
            this.Load += new System.EventHandler(this.FrmCharge_Load);
            this.tb1.ResumeLayout(false);
            this.tb1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private SysControl.UC_SearchCharge uC_SearchCharge1;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
    }
}
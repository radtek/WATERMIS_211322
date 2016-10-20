namespace MeterInstall
{
    partial class FrmWaterUserListPeccant
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.uC_SearchModule1 = new SysControl.UC_SearchModule();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uC_SearchModule1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 70);
            this.panel1.TabIndex = 1;
            this.panel1.Tag = "9999";
            // 
            // uC_SearchModule1
            // 
            this.uC_SearchModule1.AutoSize = true;
            this.uC_SearchModule1.BackColor = System.Drawing.Color.White;
            this.uC_SearchModule1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_SearchModule1.Font = new System.Drawing.Font("微软雅黑 Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_SearchModule1.Location = new System.Drawing.Point(0, 0);
            this.uC_SearchModule1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_SearchModule1.MinimumSize = new System.Drawing.Size(890, 70);
            this.uC_SearchModule1.Name = "uC_SearchModule1";
            this.uC_SearchModule1.Size = new System.Drawing.Size(1049, 70);
            this.uC_SearchModule1.TabIndex = 909;
            this.uC_SearchModule1.Tag = "9999";
            this.uC_SearchModule1.Load += new System.EventHandler(this.uC_SearchModule1_Load);
            this.uC_SearchModule1.BtnEvent += new System.EventHandler(this.uC_SearchModule1_BtnEvent);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uC_DataGridView_Page1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1049, 584);
            this.panel2.TabIndex = 2;
            this.panel2.Tag = "9999";
            // 
            // uC_DataGridView_Page1
            // 
            this.uC_DataGridView_Page1.AutoSize = true;
            this.uC_DataGridView_Page1.BackColor = System.Drawing.Color.White;
            this.uC_DataGridView_Page1.DataStatis = null;
            this.uC_DataGridView_Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DataGridView_Page1.Fields = null;
            this.uC_DataGridView_Page1.FieldStatis = null;
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(0, 0);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(833, 393);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(1049, 584);
            this.uC_DataGridView_Page1.TabIndex = 910;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellDoubleClickEvents += new SysControl.UC_DataGridView_Page.CellDoubleClickEvent(this.uC_DataGridView_Page1_CellDoubleClickEvents);
            // 
            // FrmWaterUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 654);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmWaterUserList";
            this.Tag = "9999";
            this.Text = "增户记录";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private SysControl.UC_SearchModule uC_SearchModule1;
        private System.Windows.Forms.Panel panel2;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
    }
}
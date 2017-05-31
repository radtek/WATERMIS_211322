namespace WaterBusiness
{
    partial class FrmClassified
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
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uC_DateSelect1 = new SysControl.UC_DateSelect();
            this.Btn_Export = new System.Windows.Forms.Button();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TC = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DV0 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DV1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DV2 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DV3 = new System.Windows.Forms.DataGridView();
            this.tb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TC.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DV0)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DV1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DV2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DV3)).BeginInit();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(1117, 759);
            this.tb1.TabIndex = 66;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1109, 75);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.uC_DateSelect1);
            this.panel1.Controls.Add(this.Btn_Export);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 53);
            this.panel1.TabIndex = 0;
            this.panel1.Tag = "9999";
            // 
            // uC_DateSelect1
            // 
            this.uC_DateSelect1.DayEnd = new System.DateTime(2017, 5, 31, 23, 36, 31, 914);
            this.uC_DateSelect1.DayStart = new System.DateTime(2017, 5, 31, 23, 36, 31, 916);
            this.uC_DateSelect1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uC_DateSelect1.Location = new System.Drawing.Point(4, 3);
            this.uC_DateSelect1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_DateSelect1.Name = "uC_DateSelect1";
            this.uC_DateSelect1.Size = new System.Drawing.Size(464, 41);
            this.uC_DateSelect1.TabIndex = 13;
            // 
            // Btn_Export
            // 
            this.Btn_Export.Location = new System.Drawing.Point(585, 8);
            this.Btn_Export.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Export.Name = "Btn_Export";
            this.Btn_Export.Size = new System.Drawing.Size(100, 31);
            this.Btn_Export.TabIndex = 12;
            this.Btn_Export.Text = "导出";
            this.Btn_Export.UseVisualStyleBackColor = true;
            this.Btn_Export.Click += new System.EventHandler(this.Btn_Export_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(477, 8);
            this.Btn_Submit.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(100, 31);
            this.Btn_Submit.TabIndex = 11;
            this.Btn_Submit.Text = "查询";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TC);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 92);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1109, 663);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计报表";
            // 
            // TC
            // 
            this.TC.Controls.Add(this.tabPage1);
            this.TC.Controls.Add(this.tabPage2);
            this.TC.Controls.Add(this.tabPage3);
            this.TC.Controls.Add(this.tabPage4);
            this.TC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC.Location = new System.Drawing.Point(4, 18);
            this.TC.Name = "TC";
            this.TC.SelectedIndex = 0;
            this.TC.Size = new System.Drawing.Size(1101, 641);
            this.TC.TabIndex = 0;
            this.TC.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DV0);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1093, 615);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "上户统计";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DV0
            // 
            this.DV0.AllowUserToAddRows = false;
            this.DV0.AllowUserToDeleteRows = false;
            this.DV0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DV0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DV0.Location = new System.Drawing.Point(3, 3);
            this.DV0.Name = "DV0";
            this.DV0.ReadOnly = true;
            this.DV0.RowTemplate.Height = 23;
            this.DV0.Size = new System.Drawing.Size(1087, 609);
            this.DV0.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DV1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1093, 615);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "销户统计";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DV1
            // 
            this.DV1.AllowUserToAddRows = false;
            this.DV1.AllowUserToDeleteRows = false;
            this.DV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DV1.Location = new System.Drawing.Point(3, 3);
            this.DV1.Name = "DV1";
            this.DV1.ReadOnly = true;
            this.DV1.RowTemplate.Height = 23;
            this.DV1.Size = new System.Drawing.Size(1087, 609);
            this.DV1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DV2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1093, 615);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "停户统计";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DV2
            // 
            this.DV2.AllowUserToAddRows = false;
            this.DV2.AllowUserToDeleteRows = false;
            this.DV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DV2.Location = new System.Drawing.Point(0, 0);
            this.DV2.Name = "DV2";
            this.DV2.ReadOnly = true;
            this.DV2.RowTemplate.Height = 23;
            this.DV2.Size = new System.Drawing.Size(1093, 615);
            this.DV2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DV3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1093, 615);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "用户恢复统计";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DV3
            // 
            this.DV3.AllowUserToAddRows = false;
            this.DV3.AllowUserToDeleteRows = false;
            this.DV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DV3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DV3.Location = new System.Drawing.Point(0, 0);
            this.DV3.Name = "DV3";
            this.DV3.ReadOnly = true;
            this.DV3.RowTemplate.Height = 23;
            this.DV3.Size = new System.Drawing.Size(1093, 615);
            this.DV3.TabIndex = 1;
            // 
            // FrmClassified
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 759);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmClassified";
            this.Text = "用户统计";
            this.tb1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.TC.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DV0)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DV1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DV2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DV3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private SysControl.UC_DateSelect uC_DateSelect1;
        private System.Windows.Forms.Button Btn_Export;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl TC;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView DV0;
        private System.Windows.Forms.DataGridView DV1;
        private System.Windows.Forms.DataGridView DV2;
        private System.Windows.Forms.DataGridView DV3;
    }
}
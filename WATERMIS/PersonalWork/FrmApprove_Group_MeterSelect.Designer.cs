namespace PersonalWork
{
    partial class FrmApprove_Group_MeterSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApprove_Group_MeterSelect));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Selected = new System.Windows.Forms.Button();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.waterMeterSizeId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_SelectedCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FP, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 490);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_SelectedCancel);
            this.panel1.Controls.Add(this.Btn_Selected);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.waterMeterSizeId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 44);
            this.panel1.TabIndex = 0;
            // 
            // Btn_Selected
            // 
            this.Btn_Selected.Location = new System.Drawing.Point(229, 12);
            this.Btn_Selected.Name = "Btn_Selected";
            this.Btn_Selected.Size = new System.Drawing.Size(60, 23);
            this.Btn_Selected.TabIndex = 3;
            this.Btn_Selected.Text = "全选";
            this.Btn_Selected.UseVisualStyleBackColor = true;
            this.Btn_Selected.Click += new System.EventHandler(this.Btn_Selected_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(446, 11);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.Btn_Submit.TabIndex = 2;
            this.Btn_Submit.Text = "提交";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // waterMeterSizeId
            // 
            this.waterMeterSizeId.FormattingEnabled = true;
            this.waterMeterSizeId.Location = new System.Drawing.Point(83, 14);
            this.waterMeterSizeId.Name = "waterMeterSizeId";
            this.waterMeterSizeId.Size = new System.Drawing.Size(140, 20);
            this.waterMeterSizeId.TabIndex = 1;
            this.waterMeterSizeId.SelectedIndexChanged += new System.EventHandler(this.waterMeterSizeId_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "水表口径：";
            // 
            // FP
            // 
            this.FP.AutoScroll = true;
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP.Location = new System.Drawing.Point(3, 47);
            this.FP.Name = "FP";
            this.FP.Size = new System.Drawing.Size(643, 440);
            this.FP.TabIndex = 1;
            // 
            // Btn_SelectedCancel
            // 
            this.Btn_SelectedCancel.Location = new System.Drawing.Point(295, 11);
            this.Btn_SelectedCancel.Name = "Btn_SelectedCancel";
            this.Btn_SelectedCancel.Size = new System.Drawing.Size(66, 23);
            this.Btn_SelectedCancel.TabIndex = 4;
            this.Btn_SelectedCancel.Text = "全不选";
            this.Btn_SelectedCancel.UseVisualStyleBackColor = true;
            this.Btn_SelectedCancel.Click += new System.EventHandler(this.Btn_SelectedCancel_Click);
            // 
            // FrmApprove_Group_MeterSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 490);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmApprove_Group_MeterSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水表选择";
            this.Load += new System.EventHandler(this.FrmApprove_Group_MeterSelect_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel FP;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.ComboBox waterMeterSizeId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Selected;
        private System.Windows.Forms.Button Btn_SelectedCancel;
    }
}
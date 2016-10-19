namespace PersonalWork
{
    partial class FrmApprove_MeterSelect
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
            this.TB_MeterInfos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.waterMeterSerialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_MeterInfos
            // 
            this.TB_MeterInfos.Enabled = false;
            this.TB_MeterInfos.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TB_MeterInfos.Location = new System.Drawing.Point(92, 57);
            this.TB_MeterInfos.Multiline = true;
            this.TB_MeterInfos.Name = "TB_MeterInfos";
            this.TB_MeterInfos.ReadOnly = true;
            this.TB_MeterInfos.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TB_MeterInfos.Size = new System.Drawing.Size(375, 257);
            this.TB_MeterInfos.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(16, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "水表信息：";
            // 
            // waterMeterSerialNumber
            // 
            this.waterMeterSerialNumber.Location = new System.Drawing.Point(92, 22);
            this.waterMeterSerialNumber.Name = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.Size = new System.Drawing.Size(278, 21);
            this.waterMeterSerialNumber.TabIndex = 1;
            this.waterMeterSerialNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.waterMeterSerialNumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "水表编号：";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(175, 333);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(92, 28);
            this.Btn_Submit.TabIndex = 15;
            this.Btn_Submit.Text = "确  定";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(392, 22);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 23);
            this.Btn_Search.TabIndex = 16;
            this.Btn_Search.Text = "查询";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // FrmApprove_MeterSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 385);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.Btn_Submit);
            this.Controls.Add(this.TB_MeterInfos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.waterMeterSerialNumber);
            this.Controls.Add(this.label2);
            this.Name = "FrmApprove_MeterSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择水表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_MeterInfos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox waterMeterSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Button Btn_Search;
    }
}
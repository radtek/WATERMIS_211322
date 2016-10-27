namespace PersonalWork
{
    partial class FrmApprove_Group_MeterSize
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
            this.Memo = new System.Windows.Forms.TextBox();
            this.MeterCount = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.waterMeterSizeId = new System.Windows.Forms.ComboBox();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Memo);
            this.panel1.Controls.Add(this.MeterCount);
            this.panel1.Controls.Add(this.waterMeterSizeId);
            this.panel1.Controls.Add(this.Btn_Submit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 244);
            this.panel1.TabIndex = 0;
            // 
            // Memo
            // 
            this.Memo.Location = new System.Drawing.Point(109, 112);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(120, 21);
            this.Memo.TabIndex = 6;
            // 
            // MeterCount
            // 
            this.MeterCount.AllowEmpty = false;
            this.MeterCount.EmptyMessage = "";
            this.MeterCount.ErrorMessage = "";
            this.MeterCount.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.数字;
            this.MeterCount.Location = new System.Drawing.Point(109, 76);
            this.MeterCount.Name = "MeterCount";
            this.MeterCount.RegexExpression = "";
            this.MeterCount.RemoveSpace = false;
            this.MeterCount.Size = new System.Drawing.Size(100, 21);
            this.MeterCount.TabIndex = 5;
            this.MeterCount.ValidateState = false;
            // 
            // waterMeterSizeId
            // 
            this.waterMeterSizeId.FormattingEnabled = true;
            this.waterMeterSizeId.Location = new System.Drawing.Point(108, 41);
            this.waterMeterSizeId.Name = "waterMeterSizeId";
            this.waterMeterSizeId.Size = new System.Drawing.Size(121, 20);
            this.waterMeterSizeId.TabIndex = 4;
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(97, 183);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(75, 23);
            this.Btn_Submit.TabIndex = 3;
            this.Btn_Submit.Text = "提  交";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "备    注：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "水表数量：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "水表口径：";
            // 
            // FrmApprove_Group_MeterSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 244);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmApprove_Group_MeterSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水表口径选择";
            this.Load += new System.EventHandler(this.FrmApprove_Group_MeterSize_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public Common.WinControl.Ryan.RegTextbox.RyanTextBox MeterCount;
        public System.Windows.Forms.ComboBox waterMeterSizeId;
        public System.Windows.Forms.TextBox Memo;
    }
}
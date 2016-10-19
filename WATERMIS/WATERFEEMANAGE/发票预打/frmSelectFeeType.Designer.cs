namespace WATERFEEMANAGE
{
    partial class frmSelectFeeType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectFeeType));
            this.btPrintWaterFee = new System.Windows.Forms.Button();
            this.btPrintFJF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btPrintWaterFee
            // 
            this.btPrintWaterFee.BackColor = System.Drawing.Color.LimeGreen;
            this.btPrintWaterFee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrintWaterFee.Location = new System.Drawing.Point(44, 18);
            this.btPrintWaterFee.Name = "btPrintWaterFee";
            this.btPrintWaterFee.Size = new System.Drawing.Size(152, 38);
            this.btPrintWaterFee.TabIndex = 0;
            this.btPrintWaterFee.Text = "打印水费";
            this.btPrintWaterFee.UseVisualStyleBackColor = false;
            this.btPrintWaterFee.Click += new System.EventHandler(this.btPrintWaterFee_Click);
            // 
            // btPrintFJF
            // 
            this.btPrintFJF.BackColor = System.Drawing.Color.LimeGreen;
            this.btPrintFJF.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrintFJF.Location = new System.Drawing.Point(44, 65);
            this.btPrintFJF.Name = "btPrintFJF";
            this.btPrintFJF.Size = new System.Drawing.Size(152, 38);
            this.btPrintFJF.TabIndex = 1;
            this.btPrintFJF.Text = "打印污水、附加费";
            this.btPrintFJF.UseVisualStyleBackColor = false;
            this.btPrintFJF.Click += new System.EventHandler(this.btPrintFJF_Click);
            // 
            // frmSelectFeeType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WATERFEEMANAGE.Properties.Resources.flow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(249, 115);
            this.ControlBox = false;
            this.Controls.Add(this.btPrintFJF);
            this.Controls.Add(this.btPrintWaterFee);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectFeeType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "9999";
            this.Text = "打印费用选择";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btPrintWaterFee;
        private System.Windows.Forms.Button btPrintFJF;
    }
}
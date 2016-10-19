namespace AppManage
{
    partial class EquipmentManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentManage));
            this.FP1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FP1
            // 
            this.FP1.AutoScroll = true;
            this.FP1.BackColor = System.Drawing.Color.White;
            this.FP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP1.Location = new System.Drawing.Point(0, 0);
            this.FP1.Name = "FP1";
            this.FP1.Size = new System.Drawing.Size(749, 507);
            this.FP1.TabIndex = 0;
            // 
            // EquipmentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 507);
            this.Controls.Add(this.FP1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EquipmentManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手机管理";
            this.Load += new System.EventHandler(this.EquipmentManage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FP1;

    }
}
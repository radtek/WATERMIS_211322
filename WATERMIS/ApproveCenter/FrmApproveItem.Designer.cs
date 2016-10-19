namespace ApproveCenter
{
    partial class FrmApproveItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApproveItem));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FP = new System.Windows.Forms.FlowLayoutPanel();
            this.PL = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FP);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PL);
            this.splitContainer1.Size = new System.Drawing.Size(1038, 630);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 4;
            // 
            // FP
            // 
            this.FP.AutoScroll = true;
            this.FP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FP.BackgroundImage")));
            this.FP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FP.Location = new System.Drawing.Point(0, 0);
            this.FP.Name = "FP";
            this.FP.Size = new System.Drawing.Size(155, 630);
            this.FP.TabIndex = 4;
            // 
            // PL
            // 
            this.PL.BackColor = System.Drawing.Color.Transparent;
            this.PL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PL.BackgroundImage")));
            this.PL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PL.Location = new System.Drawing.Point(0, 0);
            this.PL.Name = "PL";
            this.PL.Size = new System.Drawing.Size(879, 630);
            this.PL.TabIndex = 1;
            // 
            // FrmApproveItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 630);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmApproveItem";
            this.Text = "审批中心";
            this.Load += new System.EventHandler(this.FrmApproveItem_Load);
            this.Shown += new System.EventHandler(this.FrmApproveItem_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel FP;
        private System.Windows.Forms.Panel PL;
    }
}
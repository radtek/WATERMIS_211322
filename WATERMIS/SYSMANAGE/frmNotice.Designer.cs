namespace SYSMANAGE
{
    partial class frmNotice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotice));
            this.trShade = new System.Windows.Forms.Timer(this.components);
            this.trClose = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labFrom = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.LinkLabel();
            this.labClass = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trShade
            // 
            this.trShade.Interval = 300;
            this.trShade.Tick += new System.EventHandler(this.trShade_Tick);
            // 
            // trClose
            // 
            this.trClose.Interval = 15000;
            this.trClose.Tick += new System.EventHandler(this.trClose_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "来自:";
            // 
            // labFrom
            // 
            this.labFrom.AutoSize = true;
            this.labFrom.BackColor = System.Drawing.Color.Transparent;
            this.labFrom.Location = new System.Drawing.Point(46, 14);
            this.labFrom.Name = "labFrom";
            this.labFrom.Size = new System.Drawing.Size(52, 15);
            this.labFrom.TabIndex = 2;
            this.labFrom.Text = "发送人";
            // 
            // labTitle
            // 
            this.labTitle.BackColor = System.Drawing.Color.Transparent;
            this.labTitle.Location = new System.Drawing.Point(6, 41);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(233, 110);
            this.labTitle.TabIndex = 4;
            this.labTitle.TabStop = true;
            this.labTitle.Text = "linkLabel1";
            this.labTitle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labContent_LinkClicked);
            // 
            // labClass
            // 
            this.labClass.AutoSize = true;
            this.labClass.BackColor = System.Drawing.Color.Transparent;
            this.labClass.Location = new System.Drawing.Point(202, 14);
            this.labClass.Name = "labClass";
            this.labClass.Size = new System.Drawing.Size(37, 15);
            this.labClass.TabIndex = 11;
            this.labClass.Text = "消息";
            this.labClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(133, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "消息级别:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmNotice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SYSMANAGE.Properties.Resources.flow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(243, 160);
            this.Controls.Add(this.labClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.labFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "通知消息";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNotice_Load);
            this.MouseEnter += new System.EventHandler(this.frmNotice_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.frmNotice_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer trShade;
        private System.Windows.Forms.Timer trClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labFrom;
        private System.Windows.Forms.LinkLabel labTitle;
        private System.Windows.Forms.Label labClass;
        private System.Windows.Forms.Label label2;
    }
}
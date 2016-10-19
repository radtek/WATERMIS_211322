namespace WATERMIS
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.txtLogPWD = new System.Windows.Forms.TextBox();
            this.txtLogName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labConnect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLogPWD
            // 
            this.txtLogPWD.Location = new System.Drawing.Point(257, 179);
            this.txtLogPWD.Name = "txtLogPWD";
            this.txtLogPWD.PasswordChar = '*';
            this.txtLogPWD.Size = new System.Drawing.Size(84, 21);
            this.txtLogPWD.TabIndex = 2;
            this.txtLogPWD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLogPWD_KeyDown);
            // 
            // txtLogName
            // 
            this.txtLogName.Location = new System.Drawing.Point(257, 155);
            this.txtLogName.Name = "txtLogName";
            this.txtLogName.Size = new System.Drawing.Size(84, 21);
            this.txtLogName.TabIndex = 1;
            this.txtLogName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLogName_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(352, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 54);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // labConnect
            // 
            this.labConnect.BackColor = System.Drawing.Color.Transparent;
            this.labConnect.Location = new System.Drawing.Point(150, 155);
            this.labConnect.Name = "labConnect";
            this.labConnect.Size = new System.Drawing.Size(32, 47);
            this.labConnect.TabIndex = 5;
            this.labConnect.Click += new System.EventHandler(this.labConnect_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = global::WATERMIS.Properties.Resources.loginPic;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(521, 350);
            this.Controls.Add(this.labConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogPWD);
            this.Controls.Add(this.txtLogName);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自来水MIS系统";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogPWD;
        private System.Windows.Forms.TextBox txtLogName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labConnect;

    }
}
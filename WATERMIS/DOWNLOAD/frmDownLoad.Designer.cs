namespace DOWNLOAD
{
    partial class frmDownLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownLoad));
            this.labFile = new System.Windows.Forms.Label();
            this.btDown = new System.Windows.Forms.Button();
            this.labState = new System.Windows.Forms.Label();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.labClose = new System.Windows.Forms.Label();
            this.trChange = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // labFile
            // 
            this.labFile.AutoSize = true;
            this.labFile.BackColor = System.Drawing.Color.Transparent;
            this.labFile.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labFile.Location = new System.Drawing.Point(198, 49);
            this.labFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFile.Name = "labFile";
            this.labFile.Size = new System.Drawing.Size(35, 14);
            this.labFile.TabIndex = 0;
            this.labFile.Text = "1111";
            this.labFile.Visible = false;
            // 
            // btDown
            // 
            this.btDown.Location = new System.Drawing.Point(198, 67);
            this.btDown.Margin = new System.Windows.Forms.Padding(4);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(29, 31);
            this.btDown.TabIndex = 1;
            this.btDown.Text = "点击开始更新";
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Visible = false;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.BackColor = System.Drawing.Color.Transparent;
            this.labState.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labState.ForeColor = System.Drawing.Color.Red;
            this.labState.Location = new System.Drawing.Point(129, 17);
            this.labState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(0, 14);
            this.labState.TabIndex = 0;
            // 
            // picUpdate
            // 
            this.picUpdate.BackColor = System.Drawing.Color.Transparent;
            this.picUpdate.BackgroundImage = global::DOWNLOAD.Properties.Resources.同步1;
            this.picUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUpdate.Location = new System.Drawing.Point(22, 12);
            this.picUpdate.Name = "picUpdate";
            this.picUpdate.Size = new System.Drawing.Size(175, 86);
            this.picUpdate.TabIndex = 2;
            this.picUpdate.TabStop = false;
            // 
            // labClose
            // 
            this.labClose.AutoSize = true;
            this.labClose.BackColor = System.Drawing.Color.Transparent;
            this.labClose.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labClose.ForeColor = System.Drawing.Color.Magenta;
            this.labClose.Location = new System.Drawing.Point(33, 105);
            this.labClose.Name = "labClose";
            this.labClose.Size = new System.Drawing.Size(160, 16);
            this.labClose.TabIndex = 3;
            this.labClose.Text = "正在与服务器同步...";
            this.labClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labClose.DoubleClick += new System.EventHandler(this.labClose_DoubleClick);
            // 
            // trChange
            // 
            this.trChange.Enabled = true;
            this.trChange.Interval = 200;
            this.trChange.Tick += new System.EventHandler(this.trChange_Tick);
            // 
            // frmDownLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DOWNLOAD.Properties.Resources.登录界面;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(217, 130);
            this.Controls.Add(this.labClose);
            this.Controls.Add(this.picUpdate);
            this.Controls.Add(this.btDown);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.labFile);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在与服务器同步";
            this.Load += new System.EventHandler(this.frmDownLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labFile;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.PictureBox picUpdate;
        private System.Windows.Forms.Label labClose;
        private System.Windows.Forms.Timer trChange;
    }
}
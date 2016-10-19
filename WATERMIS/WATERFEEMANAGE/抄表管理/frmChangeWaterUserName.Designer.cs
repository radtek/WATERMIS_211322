namespace WATERFEEMANAGE
{
    partial class frmChangeWaterUserName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeWaterUserName));
            this.label1 = new System.Windows.Forms.Label();
            this.btChange = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.txtWaterUserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWaterUserNameNew = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "用 户 名:";
            // 
            // btChange
            // 
            this.btChange.Location = new System.Drawing.Point(88, 96);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(64, 31);
            this.btChange.TabIndex = 7;
            this.btChange.Text = "修改";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(184, 96);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(64, 31);
            this.btClose.TabIndex = 8;
            this.btClose.Text = "关闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // txtWaterUserName
            // 
            this.txtWaterUserName.BackColor = System.Drawing.SystemColors.Control;
            this.txtWaterUserName.Location = new System.Drawing.Point(100, 11);
            this.txtWaterUserName.Name = "txtWaterUserName";
            this.txtWaterUserName.ReadOnly = true;
            this.txtWaterUserName.Size = new System.Drawing.Size(194, 26);
            this.txtWaterUserName.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "新用户名:";
            // 
            // txtWaterUserNameNew
            // 
            this.txtWaterUserNameNew.Location = new System.Drawing.Point(100, 52);
            this.txtWaterUserNameNew.Name = "txtWaterUserNameNew";
            this.txtWaterUserNameNew.Size = new System.Drawing.Size(194, 26);
            this.txtWaterUserNameNew.TabIndex = 15;
            // 
            // frmChangeWaterUserName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 140);
            this.Controls.Add(this.txtWaterUserNameNew);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWaterUserName);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btChange);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeWaterUserName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "户名变更";
            this.Load += new System.EventHandler(this.frmChangeEndNumber_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox txtWaterUserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWaterUserNameNew;
    }
}
namespace BASEFUNCTION
{
    partial class frmQuestionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuestionDialog));
            this.labTip = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btNO = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labTip
            // 
            this.labTip.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTip.Location = new System.Drawing.Point(12, 9);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(281, 56);
            this.labTip.TabIndex = 0;
            this.labTip.Text = "提示\r\n";
            // 
            // btOK
            // 
            this.btOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOK.Location = new System.Drawing.Point(26, 75);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(58, 30);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "是";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btNO
            // 
            this.btNO.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btNO.Location = new System.Drawing.Point(109, 75);
            this.btNO.Name = "btNO";
            this.btNO.Size = new System.Drawing.Size(58, 30);
            this.btNO.TabIndex = 2;
            this.btNO.Text = "否";
            this.btNO.UseVisualStyleBackColor = true;
            this.btNO.Click += new System.EventHandler(this.btNO_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.Location = new System.Drawing.Point(192, 75);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(58, 30);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // frmQuestionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 112);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btNO);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.labTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuestionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请选择";
            this.Load += new System.EventHandler(this.frmQuestionDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labTip;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btNO;
        private System.Windows.Forms.Button btCancel;
    }
}
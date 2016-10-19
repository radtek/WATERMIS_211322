namespace WATERFEEMANAGE
{
    partial class frmChangeEndNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangeEndNumber));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWaterMeterEndNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btChange = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.txtWaterUserName = new System.Windows.Forms.TextBox();
            this.txtWaterUserNO = new System.Windows.Forms.TextBox();
            this.txtWaterUserAddress = new System.Windows.Forms.TextBox();
            this.txtWaterMeterNO = new System.Windows.Forms.TextBox();
            this.txtWaterMeterLastNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "用 户 号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "水表编号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "地    址:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "上期读数:";
            // 
            // txtWaterMeterEndNumber
            // 
            this.txtWaterMeterEndNumber.Location = new System.Drawing.Point(100, 186);
            this.txtWaterMeterEndNumber.Name = "txtWaterMeterEndNumber";
            this.txtWaterMeterEndNumber.Size = new System.Drawing.Size(73, 26);
            this.txtWaterMeterEndNumber.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 191);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "变更读数:";
            // 
            // btChange
            // 
            this.btChange.Location = new System.Drawing.Point(91, 262);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(64, 31);
            this.btChange.TabIndex = 7;
            this.btChange.Text = "变更";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(187, 262);
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
            this.txtWaterUserName.Size = new System.Drawing.Size(127, 26);
            this.txtWaterUserName.TabIndex = 9;
            // 
            // txtWaterUserNO
            // 
            this.txtWaterUserNO.BackColor = System.Drawing.SystemColors.Control;
            this.txtWaterUserNO.Location = new System.Drawing.Point(100, 46);
            this.txtWaterUserNO.Name = "txtWaterUserNO";
            this.txtWaterUserNO.ReadOnly = true;
            this.txtWaterUserNO.Size = new System.Drawing.Size(127, 26);
            this.txtWaterUserNO.TabIndex = 10;
            // 
            // txtWaterUserAddress
            // 
            this.txtWaterUserAddress.BackColor = System.Drawing.SystemColors.Control;
            this.txtWaterUserAddress.Location = new System.Drawing.Point(100, 81);
            this.txtWaterUserAddress.Name = "txtWaterUserAddress";
            this.txtWaterUserAddress.ReadOnly = true;
            this.txtWaterUserAddress.Size = new System.Drawing.Size(260, 26);
            this.txtWaterUserAddress.TabIndex = 11;
            // 
            // txtWaterMeterNO
            // 
            this.txtWaterMeterNO.BackColor = System.Drawing.SystemColors.Control;
            this.txtWaterMeterNO.Location = new System.Drawing.Point(100, 116);
            this.txtWaterMeterNO.Name = "txtWaterMeterNO";
            this.txtWaterMeterNO.ReadOnly = true;
            this.txtWaterMeterNO.Size = new System.Drawing.Size(127, 26);
            this.txtWaterMeterNO.TabIndex = 12;
            // 
            // txtWaterMeterLastNumber
            // 
            this.txtWaterMeterLastNumber.BackColor = System.Drawing.SystemColors.Control;
            this.txtWaterMeterLastNumber.Location = new System.Drawing.Point(100, 151);
            this.txtWaterMeterLastNumber.Name = "txtWaterMeterLastNumber";
            this.txtWaterMeterLastNumber.ReadOnly = true;
            this.txtWaterMeterLastNumber.Size = new System.Drawing.Size(127, 26);
            this.txtWaterMeterLastNumber.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 228);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "变更原因:";
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(100, 224);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(275, 26);
            this.txtMemo.TabIndex = 15;
            // 
            // frmChangeEndNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 305);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWaterMeterLastNumber);
            this.Controls.Add(this.txtWaterMeterNO);
            this.Controls.Add(this.txtWaterUserAddress);
            this.Controls.Add(this.txtWaterUserNO);
            this.Controls.Add(this.txtWaterUserName);
            this.Controls.Add(this.txtWaterMeterEndNumber);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btChange);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangeEndNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "表底变更";
            this.Load += new System.EventHandler(this.frmChangeEndNumber_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWaterMeterEndNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox txtWaterUserName;
        private System.Windows.Forms.TextBox txtWaterUserNO;
        private System.Windows.Forms.TextBox txtWaterUserAddress;
        private System.Windows.Forms.TextBox txtWaterMeterNO;
        private System.Windows.Forms.TextBox txtWaterMeterLastNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMemo;
    }
}
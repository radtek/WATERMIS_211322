namespace METERREADINGMACHINE
{
    partial class frmWaterMeterCharge
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labWaterUserName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labWaterMeterType = new System.Windows.Forms.Label();
            this.labWaterMeterSYDS = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbWaterMeterTypeNew = new System.Windows.Forms.ComboBox();
            this.btChangeWaterMeterTypeID = new System.Windows.Forms.Button();
            this.btChangeLastNumber = new System.Windows.Forms.Button();
            this.txtSYDSNew = new System.Windows.Forms.TextBox();
            this.labWaterMeterNO = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "用 户 名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "水表编号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "初始读数:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "用水性质:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "用水性质:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "初始读数:";
            // 
            // labWaterUserName
            // 
            this.labWaterUserName.AutoSize = true;
            this.labWaterUserName.Location = new System.Drawing.Point(90, 12);
            this.labWaterUserName.Name = "labWaterUserName";
            this.labWaterUserName.Size = new System.Drawing.Size(56, 16);
            this.labWaterUserName.TabIndex = 6;
            this.labWaterUserName.Text = "label7";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labWaterMeterType);
            this.groupBox1.Controls.Add(this.labWaterMeterSYDS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 89);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "变更前信息";
            // 
            // labWaterMeterType
            // 
            this.labWaterMeterType.AutoSize = true;
            this.labWaterMeterType.Location = new System.Drawing.Point(81, 62);
            this.labWaterMeterType.Name = "labWaterMeterType";
            this.labWaterMeterType.Size = new System.Drawing.Size(64, 16);
            this.labWaterMeterType.TabIndex = 8;
            this.labWaterMeterType.Text = "label10";
            // 
            // labWaterMeterSYDS
            // 
            this.labWaterMeterSYDS.AutoSize = true;
            this.labWaterMeterSYDS.Location = new System.Drawing.Point(81, 30);
            this.labWaterMeterSYDS.Name = "labWaterMeterSYDS";
            this.labWaterMeterSYDS.Size = new System.Drawing.Size(56, 16);
            this.labWaterMeterSYDS.TabIndex = 7;
            this.labWaterMeterSYDS.Text = "label9";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbWaterMeterTypeNew);
            this.groupBox2.Controls.Add(this.btChangeWaterMeterTypeID);
            this.groupBox2.Controls.Add(this.btChangeLastNumber);
            this.groupBox2.Controls.Add(this.txtSYDSNew);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(5, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 86);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变更后信息";
            // 
            // cmbWaterMeterTypeNew
            // 
            this.cmbWaterMeterTypeNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterMeterTypeNew.DropDownWidth = 150;
            this.cmbWaterMeterTypeNew.FormattingEnabled = true;
            this.cmbWaterMeterTypeNew.Items.AddRange(new object[] {
            "",
            "正常",
            "停水",
            "报废"});
            this.cmbWaterMeterTypeNew.Location = new System.Drawing.Point(88, 54);
            this.cmbWaterMeterTypeNew.Name = "cmbWaterMeterTypeNew";
            this.cmbWaterMeterTypeNew.Size = new System.Drawing.Size(120, 24);
            this.cmbWaterMeterTypeNew.TabIndex = 92;
            // 
            // btChangeWaterMeterTypeID
            // 
            this.btChangeWaterMeterTypeID.Location = new System.Drawing.Point(214, 52);
            this.btChangeWaterMeterTypeID.Name = "btChangeWaterMeterTypeID";
            this.btChangeWaterMeterTypeID.Size = new System.Drawing.Size(84, 28);
            this.btChangeWaterMeterTypeID.TabIndex = 10;
            this.btChangeWaterMeterTypeID.Text = "变更水价";
            this.btChangeWaterMeterTypeID.UseVisualStyleBackColor = true;
            this.btChangeWaterMeterTypeID.Click += new System.EventHandler(this.btChangeWaterMeterTypeID_Click);
            // 
            // btChangeLastNumber
            // 
            this.btChangeLastNumber.Location = new System.Drawing.Point(214, 20);
            this.btChangeLastNumber.Name = "btChangeLastNumber";
            this.btChangeLastNumber.Size = new System.Drawing.Size(84, 28);
            this.btChangeLastNumber.TabIndex = 10;
            this.btChangeLastNumber.Text = "变更读数";
            this.btChangeLastNumber.UseVisualStyleBackColor = true;
            this.btChangeLastNumber.Click += new System.EventHandler(this.btOK_Click);
            // 
            // txtSYDSNew
            // 
            this.txtSYDSNew.Location = new System.Drawing.Point(88, 22);
            this.txtSYDSNew.Name = "txtSYDSNew";
            this.txtSYDSNew.Size = new System.Drawing.Size(120, 26);
            this.txtSYDSNew.TabIndex = 6;
            // 
            // labWaterMeterNO
            // 
            this.labWaterMeterNO.AutoSize = true;
            this.labWaterMeterNO.Location = new System.Drawing.Point(90, 37);
            this.labWaterMeterNO.Name = "labWaterMeterNO";
            this.labWaterMeterNO.Size = new System.Drawing.Size(56, 16);
            this.labWaterMeterNO.TabIndex = 9;
            this.labWaterMeterNO.Text = "label8";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(7, 257);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 30);
            this.btClose.TabIndex = 11;
            this.btClose.Text = "关闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmWaterMeterCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 292);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.labWaterMeterNO);
            this.Controls.Add(this.labWaterUserName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWaterMeterCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "水表信息变更";
            this.Load += new System.EventHandler(this.frmWaterMeterCharge_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labWaterUserName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labWaterMeterNO;
        private System.Windows.Forms.Label labWaterMeterType;
        private System.Windows.Forms.Label labWaterMeterSYDS;
        private System.Windows.Forms.TextBox txtSYDSNew;
        private System.Windows.Forms.ComboBox cmbWaterMeterTypeNew;
        private System.Windows.Forms.Button btChangeLastNumber;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btChangeWaterMeterTypeID;
    }
}
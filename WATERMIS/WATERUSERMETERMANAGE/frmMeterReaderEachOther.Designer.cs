namespace WATERUSERMETERMANAGE
{
    partial class frmMeterReaderEachOther
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMeterReaderEachOther));
            this.chkLsbRight = new System.Windows.Forms.CheckedListBox();
            this.lsbLeft = new System.Windows.Forms.ListBox();
            this.btOK = new System.Windows.Forms.Button();
            this.txtNameRight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameLeft = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtChargerLeft = new System.Windows.Forms.TextBox();
            this.lsbLeftCharger = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btChangeCharger = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtChargerRight = new System.Windows.Forms.TextBox();
            this.lsbRightCharger = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkLsbRight
            // 
            this.chkLsbRight.FormattingEnabled = true;
            this.chkLsbRight.Location = new System.Drawing.Point(15, 55);
            this.chkLsbRight.Name = "chkLsbRight";
            this.chkLsbRight.Size = new System.Drawing.Size(146, 319);
            this.chkLsbRight.TabIndex = 0;
            this.chkLsbRight.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLsbRight_ItemCheck);
            // 
            // lsbLeft
            // 
            this.lsbLeft.BackColor = System.Drawing.Color.White;
            this.lsbLeft.ForeColor = System.Drawing.Color.Red;
            this.lsbLeft.FormattingEnabled = true;
            this.lsbLeft.ItemHeight = 16;
            this.lsbLeft.Location = new System.Drawing.Point(35, 59);
            this.lsbLeft.Name = "lsbLeft";
            this.lsbLeft.Size = new System.Drawing.Size(126, 324);
            this.lsbLeft.TabIndex = 1;
            this.lsbLeft.SelectedIndexChanged += new System.EventHandler(this.lsbLeft_SelectedIndexChanged);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(203, 401);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 29);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "互换";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // txtNameRight
            // 
            this.txtNameRight.Location = new System.Drawing.Point(89, 21);
            this.txtNameRight.Name = "txtNameRight";
            this.txtNameRight.Size = new System.Drawing.Size(72, 26);
            this.txtNameRight.TabIndex = 6;
            this.txtNameRight.TextChanged += new System.EventHandler(this.txtNameRight_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "姓名检索:";
            // 
            // txtNameLeft
            // 
            this.txtNameLeft.Location = new System.Drawing.Point(89, 26);
            this.txtNameLeft.Name = "txtNameLeft";
            this.txtNameLeft.Size = new System.Drawing.Size(72, 26);
            this.txtNameLeft.TabIndex = 3;
            this.txtNameLeft.TextChanged += new System.EventHandler(this.txtNameLeft_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "姓名检索:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = global::WATERUSERMETERMANAGE.Properties.Resources.抄表员互换箭头;
            this.label2.Location = new System.Drawing.Point(209, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 52);
            this.label2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtNameLeft);
            this.groupBox2.Controls.Add(this.lsbLeft);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 389);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "9999";
            this.groupBox2.Text = "抄表员列表";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtNameRight);
            this.groupBox3.Controls.Add(this.chkLsbRight);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(277, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 385);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "9999";
            this.groupBox3.Text = "抄表员列表";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 468);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::WATERUSERMETERMANAGE.Properties.Resources.登录界面;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btOK);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(495, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "抄表员互换";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::WATERUSERMETERMANAGE.Properties.Resources.登录界面;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btChangeCharger);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(495, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "收费员互换";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtChargerLeft);
            this.groupBox1.Controls.Add(this.lsbLeftCharger);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(9, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 389);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "收费员列表";
            // 
            // txtChargerLeft
            // 
            this.txtChargerLeft.Location = new System.Drawing.Point(89, 26);
            this.txtChargerLeft.Name = "txtChargerLeft";
            this.txtChargerLeft.Size = new System.Drawing.Size(72, 26);
            this.txtChargerLeft.TabIndex = 3;
            this.txtChargerLeft.TextChanged += new System.EventHandler(this.txtChargerLeft_TextChanged);
            // 
            // lsbLeftCharger
            // 
            this.lsbLeftCharger.BackColor = System.Drawing.Color.White;
            this.lsbLeftCharger.ForeColor = System.Drawing.Color.Red;
            this.lsbLeftCharger.FormattingEnabled = true;
            this.lsbLeftCharger.ItemHeight = 16;
            this.lsbLeftCharger.Location = new System.Drawing.Point(35, 59);
            this.lsbLeftCharger.Name = "lsbLeftCharger";
            this.lsbLeftCharger.Size = new System.Drawing.Size(126, 324);
            this.lsbLeftCharger.TabIndex = 1;
            this.lsbLeftCharger.SelectedIndexChanged += new System.EventHandler(this.lsbLeftCharger_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "姓名检索:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Image = global::WATERUSERMETERMANAGE.Properties.Resources.抄表员互换箭头;
            this.label5.Location = new System.Drawing.Point(210, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 52);
            this.label5.TabIndex = 10;
            // 
            // btChangeCharger
            // 
            this.btChangeCharger.Location = new System.Drawing.Point(204, 402);
            this.btChangeCharger.Name = "btChangeCharger";
            this.btChangeCharger.Size = new System.Drawing.Size(75, 29);
            this.btChangeCharger.TabIndex = 11;
            this.btChangeCharger.Text = "互换";
            this.btChangeCharger.UseVisualStyleBackColor = true;
            this.btChangeCharger.Click += new System.EventHandler(this.btChangeCharger_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtChargerRight);
            this.groupBox4.Controls.Add(this.lsbRightCharger);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(278, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 385);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "9999";
            // 
            // txtChargerRight
            // 
            this.txtChargerRight.Location = new System.Drawing.Point(89, 21);
            this.txtChargerRight.Name = "txtChargerRight";
            this.txtChargerRight.Size = new System.Drawing.Size(72, 26);
            this.txtChargerRight.TabIndex = 6;
            this.txtChargerRight.TextChanged += new System.EventHandler(this.txtChargerRight_TextChanged);
            // 
            // lsbRightCharger
            // 
            this.lsbRightCharger.FormattingEnabled = true;
            this.lsbRightCharger.Location = new System.Drawing.Point(15, 55);
            this.lsbRightCharger.Name = "lsbRightCharger";
            this.lsbRightCharger.Size = new System.Drawing.Size(146, 319);
            this.lsbRightCharger.TabIndex = 0;
            this.lsbRightCharger.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkLsbRight_ItemCheck);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "姓名检索:";
            // 
            // frmMeterReaderEachOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WATERUSERMETERMANAGE.Properties.Resources.登录界面;
            this.ClientSize = new System.Drawing.Size(503, 468);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMeterReaderEachOther";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "抄表(收费)员互换";
            this.Load += new System.EventHandler(this.frmMeterReaderEachOther_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkLsbRight;
        private System.Windows.Forms.ListBox lsbLeft;
        private System.Windows.Forms.TextBox txtNameLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtChargerLeft;
        private System.Windows.Forms.ListBox lsbLeftCharger;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btChangeCharger;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtChargerRight;
        private System.Windows.Forms.CheckedListBox lsbRightCharger;
        private System.Windows.Forms.Label label6;
    }
}
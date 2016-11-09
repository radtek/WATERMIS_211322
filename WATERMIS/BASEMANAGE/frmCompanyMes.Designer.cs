namespace BASEMANAGE
{
    partial class frmCompanyMes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyMes));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSetUp = new System.Windows.Forms.Button();
            this.btCancle = new System.Windows.Forms.Button();
            this.txtTaxNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddressAndTel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBankNameAndAccountNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChecker = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rb01 = new System.Windows.Forms.RadioButton();
            this.rb010003 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(119, 43);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 26);
            this.txtName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "公司名称:";
            // 
            // btSetUp
            // 
            this.btSetUp.Location = new System.Drawing.Point(97, 253);
            this.btSetUp.Name = "btSetUp";
            this.btSetUp.Size = new System.Drawing.Size(60, 32);
            this.btSetUp.TabIndex = 4;
            this.btSetUp.Text = "设置";
            this.btSetUp.UseVisualStyleBackColor = true;
            this.btSetUp.Click += new System.EventHandler(this.btSetUp_Click);
            // 
            // btCancle
            // 
            this.btCancle.Location = new System.Drawing.Point(175, 253);
            this.btCancle.Name = "btCancle";
            this.btCancle.Size = new System.Drawing.Size(60, 32);
            this.btCancle.TabIndex = 5;
            this.btCancle.Text = "取消";
            this.btCancle.UseVisualStyleBackColor = true;
            this.btCancle.Click += new System.EventHandler(this.btCancle_Click);
            // 
            // txtTaxNO
            // 
            this.txtTaxNO.Location = new System.Drawing.Point(119, 77);
            this.txtTaxNO.Name = "txtTaxNO";
            this.txtTaxNO.Size = new System.Drawing.Size(236, 26);
            this.txtTaxNO.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "纳税人识别号:";
            // 
            // txtAddressAndTel
            // 
            this.txtAddressAndTel.Location = new System.Drawing.Point(119, 111);
            this.txtAddressAndTel.Name = "txtAddressAndTel";
            this.txtAddressAndTel.Size = new System.Drawing.Size(236, 26);
            this.txtAddressAndTel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "地址、电话:";
            // 
            // txtBankNameAndAccountNO
            // 
            this.txtBankNameAndAccountNO.Location = new System.Drawing.Point(119, 145);
            this.txtBankNameAndAccountNO.Name = "txtBankNameAndAccountNO";
            this.txtBankNameAndAccountNO.Size = new System.Drawing.Size(236, 26);
            this.txtBankNameAndAccountNO.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "开户行及账号:";
            // 
            // txtPayee
            // 
            this.txtPayee.Location = new System.Drawing.Point(119, 180);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(88, 26);
            this.txtPayee.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "收款人:";
            // 
            // txtChecker
            // 
            this.txtChecker.Location = new System.Drawing.Point(119, 213);
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.Size = new System.Drawing.Size(88, 26);
            this.txtChecker.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "复核人:";
            // 
            // rb01
            // 
            this.rb01.AutoSize = true;
            this.rb01.Location = new System.Drawing.Point(128, 13);
            this.rb01.Name = "rb01";
            this.rb01.Size = new System.Drawing.Size(106, 20);
            this.rb01.TabIndex = 16;
            this.rb01.TabStop = true;
            this.rb01.Text = "自来水公司";
            this.rb01.UseVisualStyleBackColor = true;
            this.rb01.CheckedChanged += new System.EventHandler(this.rb01_CheckedChanged);
            // 
            // rb010003
            // 
            this.rb010003.AutoSize = true;
            this.rb010003.Location = new System.Drawing.Point(244, 13);
            this.rb010003.Name = "rb010003";
            this.rb010003.Size = new System.Drawing.Size(90, 20);
            this.rb010003.TabIndex = 17;
            this.rb010003.TabStop = true;
            this.rb010003.Text = "安装公司";
            this.rb010003.UseVisualStyleBackColor = true;
            this.rb010003.CheckedChanged += new System.EventHandler(this.rb01_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "公司选择:";
            // 
            // frmCompanyMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 293);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rb010003);
            this.Controls.Add(this.rb01);
            this.Controls.Add(this.txtChecker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPayee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBankNameAndAccountNO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddressAndTel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTaxNO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btCancle);
            this.Controls.Add(this.btSetUp);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompanyMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "公司信息设置";
            this.Load += new System.EventHandler(this.frmCompanyMes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSetUp;
        private System.Windows.Forms.Button btCancle;
        private System.Windows.Forms.TextBox txtTaxNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddressAndTel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBankNameAndAccountNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChecker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb01;
        private System.Windows.Forms.RadioButton rb010003;
        private System.Windows.Forms.Label label7;
    }
}
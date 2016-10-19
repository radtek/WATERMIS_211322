namespace WATERFEEMANAGE
{
    partial class frmPrintInvoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintInvoice));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.txtInvoiceNO = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btInvoicePrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtExtraChargePrice2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtExtraChargePrice1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtWaterPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalCharge = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtExtraCharge2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExtraCharge1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWaterTotalCharge = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWaterMeterType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWaterToltalNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWaterUserAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWaterUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bgGetFPNO = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 343);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbBatch);
            this.groupBox4.Controls.Add(this.txtInvoiceNO);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.btInvoicePrint);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 282);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(716, 58);
            this.groupBox4.TabIndex = 122;
            this.groupBox4.TabStop = false;
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.DropDownWidth = 130;
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(92, 21);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(125, 24);
            this.cmbBatch.TabIndex = 110;
            // 
            // txtInvoiceNO
            // 
            this.txtInvoiceNO.BackColor = System.Drawing.Color.LightYellow;
            this.txtInvoiceNO.Location = new System.Drawing.Point(316, 20);
            this.txtInvoiceNO.Name = "txtInvoiceNO";
            this.txtInvoiceNO.Size = new System.Drawing.Size(109, 26);
            this.txtInvoiceNO.TabIndex = 9;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(15, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 16);
            this.label23.TabIndex = 109;
            this.label23.Text = "发票批次:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(236, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 16);
            this.label24.TabIndex = 108;
            this.label24.Text = "发票号码:";
            // 
            // btInvoicePrint
            // 
            this.btInvoicePrint.Enabled = false;
            this.btInvoicePrint.Location = new System.Drawing.Point(452, 18);
            this.btInvoicePrint.Name = "btInvoicePrint";
            this.btInvoicePrint.Size = new System.Drawing.Size(80, 32);
            this.btInvoicePrint.TabIndex = 10;
            this.btInvoicePrint.Text = "打印发票";
            this.btInvoicePrint.UseVisualStyleBackColor = true;
            this.btInvoicePrint.Click += new System.EventHandler(this.btInvoicePrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtExtraChargePrice2);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtExtraChargePrice1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtWaterPrice);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtTotalCharge);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtExtraCharge2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtExtraCharge1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtWaterTotalCharge);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbWaterMeterType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtWaterToltalNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtWaterUserAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtWaterUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发票信息";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(641, 171);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 28;
            this.label17.Text = "元";
            // 
            // txtExtraChargePrice2
            // 
            this.txtExtraChargePrice2.BackColor = System.Drawing.SystemColors.Window;
            this.txtExtraChargePrice2.Location = new System.Drawing.Point(552, 166);
            this.txtExtraChargePrice2.Name = "txtExtraChargePrice2";
            this.txtExtraChargePrice2.Size = new System.Drawing.Size(88, 26);
            this.txtExtraChargePrice2.TabIndex = 27;
            this.txtExtraChargePrice2.Text = "0";
            this.txtExtraChargePrice2.TextChanged += new System.EventHandler(this.txtWaterToltalNumber_TextChanged);
            this.txtExtraChargePrice2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            this.txtExtraChargePrice2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterTotalCharge_KeyPress);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(460, 171);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 16);
            this.label18.TabIndex = 26;
            this.label18.Text = "附加费单价：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(407, 171);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 16);
            this.label15.TabIndex = 25;
            this.label15.Text = "元";
            // 
            // txtExtraChargePrice1
            // 
            this.txtExtraChargePrice1.BackColor = System.Drawing.SystemColors.Window;
            this.txtExtraChargePrice1.Location = new System.Drawing.Point(318, 166);
            this.txtExtraChargePrice1.Name = "txtExtraChargePrice1";
            this.txtExtraChargePrice1.Size = new System.Drawing.Size(88, 26);
            this.txtExtraChargePrice1.TabIndex = 24;
            this.txtExtraChargePrice1.Text = "0";
            this.txtExtraChargePrice1.TextChanged += new System.EventHandler(this.txtWaterToltalNumber_TextChanged);
            this.txtExtraChargePrice1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            this.txtExtraChargePrice1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterTotalCharge_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(194, 171);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 16);
            this.label16.TabIndex = 23;
            this.label16.Text = "污水处理费单价：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(145, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 22;
            this.label14.Text = "元";
            // 
            // txtWaterPrice
            // 
            this.txtWaterPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterPrice.Location = new System.Drawing.Point(90, 166);
            this.txtWaterPrice.Name = "txtWaterPrice";
            this.txtWaterPrice.Size = new System.Drawing.Size(53, 26);
            this.txtWaterPrice.TabIndex = 21;
            this.txtWaterPrice.Text = "0";
            this.txtWaterPrice.TextChanged += new System.EventHandler(this.txtWaterToltalNumber_TextChanged);
            this.txtWaterPrice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            this.txtWaterPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterTotalCharge_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "单    价：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(179, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "元";
            // 
            // txtTotalCharge
            // 
            this.txtTotalCharge.BackColor = System.Drawing.SystemColors.Window;
            this.txtTotalCharge.Location = new System.Drawing.Point(90, 238);
            this.txtTotalCharge.Name = "txtTotalCharge";
            this.txtTotalCharge.Size = new System.Drawing.Size(88, 26);
            this.txtTotalCharge.TabIndex = 18;
            this.txtTotalCharge.Text = "0";
            this.txtTotalCharge.TextChanged += new System.EventHandler(this.txtTotalCharge_TextChanged);
            this.txtTotalCharge.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            this.txtTotalCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterTotalCharge_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "合    计：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(612, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "元";
            // 
            // txtExtraCharge2
            // 
            this.txtExtraCharge2.BackColor = System.Drawing.SystemColors.Window;
            this.txtExtraCharge2.Location = new System.Drawing.Point(523, 203);
            this.txtExtraCharge2.Name = "txtExtraCharge2";
            this.txtExtraCharge2.Size = new System.Drawing.Size(88, 26);
            this.txtExtraCharge2.TabIndex = 15;
            this.txtExtraCharge2.Text = "0";
            this.txtExtraCharge2.TextChanged += new System.EventHandler(this.txtCharge_TextChanged);
            this.txtExtraCharge2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            this.txtExtraCharge2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterTotalCharge_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(462, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "附加费：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "元";
            // 
            // txtExtraCharge1
            // 
            this.txtExtraCharge1.BackColor = System.Drawing.SystemColors.Window;
            this.txtExtraCharge1.Location = new System.Drawing.Point(320, 203);
            this.txtExtraCharge1.Name = "txtExtraCharge1";
            this.txtExtraCharge1.Size = new System.Drawing.Size(88, 26);
            this.txtExtraCharge1.TabIndex = 12;
            this.txtExtraCharge1.Text = "0";
            this.txtExtraCharge1.TextChanged += new System.EventHandler(this.txtCharge_TextChanged);
            this.txtExtraCharge1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            this.txtExtraCharge1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterTotalCharge_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "污水处理费：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "元";
            // 
            // txtWaterTotalCharge
            // 
            this.txtWaterTotalCharge.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterTotalCharge.Location = new System.Drawing.Point(90, 203);
            this.txtWaterTotalCharge.Name = "txtWaterTotalCharge";
            this.txtWaterTotalCharge.Size = new System.Drawing.Size(88, 26);
            this.txtWaterTotalCharge.TabIndex = 9;
            this.txtWaterTotalCharge.Text = "0";
            this.txtWaterTotalCharge.TextChanged += new System.EventHandler(this.txtCharge_TextChanged);
            this.txtWaterTotalCharge.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            this.txtWaterTotalCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterTotalCharge_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "水    费：";
            // 
            // cmbWaterMeterType
            // 
            this.cmbWaterMeterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaterMeterType.FormattingEnabled = true;
            this.cmbWaterMeterType.Location = new System.Drawing.Point(90, 132);
            this.cmbWaterMeterType.Name = "cmbWaterMeterType";
            this.cmbWaterMeterType.Size = new System.Drawing.Size(166, 24);
            this.cmbWaterMeterType.TabIndex = 7;
            this.cmbWaterMeterType.SelectionChangeCommitted += new System.EventHandler(this.cmbWaterMeterType_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "用水性质：";
            // 
            // txtWaterToltalNumber
            // 
            this.txtWaterToltalNumber.Location = new System.Drawing.Point(90, 97);
            this.txtWaterToltalNumber.Name = "txtWaterToltalNumber";
            this.txtWaterToltalNumber.Size = new System.Drawing.Size(88, 26);
            this.txtWaterToltalNumber.TabIndex = 5;
            this.txtWaterToltalNumber.Text = "0";
            this.txtWaterToltalNumber.TextChanged += new System.EventHandler(this.txtWaterToltalNumber_TextChanged);
            this.txtWaterToltalNumber.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            this.txtWaterToltalNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaterToltalNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "用水吨数：";
            // 
            // txtWaterUserAddress
            // 
            this.txtWaterUserAddress.Location = new System.Drawing.Point(90, 63);
            this.txtWaterUserAddress.Name = "txtWaterUserAddress";
            this.txtWaterUserAddress.Size = new System.Drawing.Size(220, 26);
            this.txtWaterUserAddress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "地    址：";
            // 
            // txtWaterUserName
            // 
            this.txtWaterUserName.Location = new System.Drawing.Point(90, 29);
            this.txtWaterUserName.Name = "txtWaterUserName";
            this.txtWaterUserName.Size = new System.Drawing.Size(220, 26);
            this.txtWaterUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "用 户 名：";
            // 
            // bgGetFPNO
            // 
            this.bgGetFPNO.WorkerSupportsCancellation = true;
            this.bgGetFPNO.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgGetFPNO_DoWork);
            this.bgGetFPNO.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGetFPNO_RunWorkerCompleted);
            // 
            // frmPrintInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 343);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定额发票打印";
            this.Load += new System.EventHandler(this.frmPrintInvoice_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWaterUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWaterToltalNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWaterUserAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWaterMeterType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWaterTotalCharge;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtExtraCharge2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExtraCharge1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalCharge;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtWaterPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtExtraChargePrice1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtExtraChargePrice2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.TextBox txtInvoiceNO;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btInvoicePrint;
        private System.ComponentModel.BackgroundWorker bgGetFPNO;

    }
}
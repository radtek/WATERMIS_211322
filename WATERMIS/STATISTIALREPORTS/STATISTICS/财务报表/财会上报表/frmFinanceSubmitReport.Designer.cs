namespace STATISTIALREPORTS
{
    partial class frmFinanceSubmitReport
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
            FastReport.Design.DesignerSettings designerSettings2 = new FastReport.Design.DesignerSettings();
            FastReport.Design.DesignerRestrictions designerRestrictions2 = new FastReport.Design.DesignerRestrictions();
            FastReport.Export.Email.EmailSettings emailSettings2 = new FastReport.Export.Email.EmailSettings();
            FastReport.PreviewSettings previewSettings2 = new FastReport.PreviewSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinanceSubmitReport));
            FastReport.ReportSettings reportSettings2 = new FastReport.ReportSettings();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolStatics = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSetMonth = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.今天ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.本月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下月ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.本年ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上年ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpStartSearch = new System.Windows.Forms.DateTimePicker();
            this.dtpEndSearch = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkChargeDateTime = new System.Windows.Forms.CheckBox();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripWaterUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripWaterUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWaterUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatics});
            this.toolStripWaterUser.Location = new System.Drawing.Point(0, 0);
            this.toolStripWaterUser.Name = "toolStripWaterUser";
            this.toolStripWaterUser.Size = new System.Drawing.Size(533, 25);
            this.toolStripWaterUser.TabIndex = 57;
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolStatics
            // 
            this.toolStatics.Image = global::STATISTIALREPORTS.Properties.Resources.onebit_02;
            this.toolStatics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStatics.Name = "toolStatics";
            this.toolStatics.Size = new System.Drawing.Size(57, 22);
            this.toolStatics.Text = "生成";
            this.toolStatics.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.btSetMonth);
            this.groupBox1.Controls.Add(this.dtpStartSearch);
            this.groupBox1.Controls.Add(this.dtpEndSearch);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.chkChargeDateTime);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 57);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "统计条件";
            // 
            // btSetMonth
            // 
            this.btSetMonth.BackgroundImage = global::STATISTIALREPORTS.Properties.Resources.onebit_20;
            this.btSetMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetMonth.ContextMenuStrip = this.contextMenuStrip1;
            this.btSetMonth.Location = new System.Drawing.Point(340, 21);
            this.btSetMonth.Name = "btSetMonth";
            this.btSetMonth.Size = new System.Drawing.Size(22, 23);
            this.btSetMonth.TabIndex = 177;
            this.btSetMonth.UseVisualStyleBackColor = true;
            this.btSetMonth.Click += new System.EventHandler(this.btSetMonth_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.今天ToolStripMenuItem,
            this.toolStripSeparator1,
            this.本月ToolStripMenuItem,
            this.上月ToolStripMenuItem,
            this.下月ToolStripMenuItem,
            this.toolStripSeparator2,
            this.本年ToolStripMenuItem,
            this.上年ToolStripMenuItem,
            this.toolStripSeparator3,
            this.全部ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 190);
            // 
            // 今天ToolStripMenuItem
            // 
            this.今天ToolStripMenuItem.Name = "今天ToolStripMenuItem";
            this.今天ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.今天ToolStripMenuItem.Text = "今天";
            this.今天ToolStripMenuItem.Click += new System.EventHandler(this.今天ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(105, 6);
            // 
            // 本月ToolStripMenuItem
            // 
            this.本月ToolStripMenuItem.Name = "本月ToolStripMenuItem";
            this.本月ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.本月ToolStripMenuItem.Text = "本月";
            this.本月ToolStripMenuItem.Click += new System.EventHandler(this.本月ToolStripMenuItem_Click);
            // 
            // 上月ToolStripMenuItem
            // 
            this.上月ToolStripMenuItem.Name = "上月ToolStripMenuItem";
            this.上月ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.上月ToolStripMenuItem.Text = "上月";
            this.上月ToolStripMenuItem.Click += new System.EventHandler(this.上月ToolStripMenuItem_Click);
            // 
            // 下月ToolStripMenuItem
            // 
            this.下月ToolStripMenuItem.Name = "下月ToolStripMenuItem";
            this.下月ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.下月ToolStripMenuItem.Text = "下月";
            this.下月ToolStripMenuItem.Click += new System.EventHandler(this.下月ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(105, 6);
            // 
            // 本年ToolStripMenuItem
            // 
            this.本年ToolStripMenuItem.Name = "本年ToolStripMenuItem";
            this.本年ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.本年ToolStripMenuItem.Text = "本年";
            this.本年ToolStripMenuItem.Click += new System.EventHandler(this.本年ToolStripMenuItem_Click);
            // 
            // 上年ToolStripMenuItem
            // 
            this.上年ToolStripMenuItem.Name = "上年ToolStripMenuItem";
            this.上年ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.上年ToolStripMenuItem.Text = "上年";
            this.上年ToolStripMenuItem.Click += new System.EventHandler(this.上年ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(105, 6);
            // 
            // 全部ToolStripMenuItem
            // 
            this.全部ToolStripMenuItem.Name = "全部ToolStripMenuItem";
            this.全部ToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.全部ToolStripMenuItem.Text = "全部";
            this.全部ToolStripMenuItem.Click += new System.EventHandler(this.全部ToolStripMenuItem_Click);
            // 
            // dtpStartSearch
            // 
            this.dtpStartSearch.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStartSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartSearch.Location = new System.Drawing.Point(377, 20);
            this.dtpStartSearch.Name = "dtpStartSearch";
            this.dtpStartSearch.Size = new System.Drawing.Size(10, 26);
            this.dtpStartSearch.TabIndex = 176;
            this.dtpStartSearch.Visible = false;
            // 
            // dtpEndSearch
            // 
            this.dtpEndSearch.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpEndSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndSearch.Location = new System.Drawing.Point(390, 20);
            this.dtpEndSearch.Name = "dtpEndSearch";
            this.dtpEndSearch.Size = new System.Drawing.Size(10, 26);
            this.dtpEndSearch.TabIndex = 175;
            this.dtpEndSearch.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 124;
            this.label8.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(232, 20);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 123;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(104, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 122;
            // 
            // chkChargeDateTime
            // 
            this.chkChargeDateTime.AutoSize = true;
            this.chkChargeDateTime.Checked = true;
            this.chkChargeDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChargeDateTime.Location = new System.Drawing.Point(12, 24);
            this.chkChargeDateTime.Name = "chkChargeDateTime";
            this.chkChargeDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkChargeDateTime.TabIndex = 121;
            this.chkChargeDateTime.Text = "水费期间:";
            this.chkChargeDateTime.UseVisualStyleBackColor = true;
            // 
            // environmentSettings1
            // 
            designerSettings2.ApplicationConnection = null;
            designerSettings2.DefaultFont = new System.Drawing.Font("宋体", 9F);
            designerSettings2.Icon = null;
            designerSettings2.Restrictions = designerRestrictions2;
            designerSettings2.Text = "";
            this.environmentSettings1.DesignerSettings = designerSettings2;
            emailSettings2.Address = "";
            emailSettings2.Host = "";
            emailSettings2.MessageTemplate = "";
            emailSettings2.Name = "";
            emailSettings2.Password = "";
            emailSettings2.UserName = "";
            this.environmentSettings1.EmailSettings = emailSettings2;
            previewSettings2.Buttons = ((FastReport.PreviewButtons)(((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save)
                        | FastReport.PreviewButtons.Zoom)
                        | FastReport.PreviewButtons.PageSetup)
                        | FastReport.PreviewButtons.Close)));
            previewSettings2.Icon = ((System.Drawing.Icon)(resources.GetObject("previewSettings2.Icon")));
            previewSettings2.Text = "";
            this.environmentSettings1.PreviewSettings = previewSettings2;
            this.environmentSettings1.ReportSettings = reportSettings2;
            this.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(533, 524);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "9999";
            this.groupBox2.Text = "营业明细";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.DarkBlue;
            this.label18.Location = new System.Drawing.Point(55, 489);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(256, 16);
            this.label18.TabIndex = 1;
            this.label18.Tag = "9999";
            this.label18.Text = "六、本期期末预收账款余额(财会):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DarkBlue;
            this.label14.Location = new System.Drawing.Point(55, 393);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(256, 16);
            this.label14.TabIndex = 1;
            this.label14.Tag = "9999";
            this.label14.Text = "五、      本月应收账款应入账数:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.DarkBlue;
            this.label21.Location = new System.Drawing.Point(55, 369);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(256, 16);
            this.label21.TabIndex = 1;
            this.label21.Tag = "9999";
            this.label21.Text = "四、本期期末预收账款余额(营业):";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Yellow;
            this.label20.Location = new System.Drawing.Point(79, 345);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(232, 16);
            this.label20.TabIndex = 1;
            this.label20.Tag = "9999";
            this.label20.Text = "(1+2+3)本月实际实收款项合计:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Yellow;
            this.label19.Location = new System.Drawing.Point(127, 321);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(184, 16);
            this.label19.TabIndex = 1;
            this.label19.Tag = "9999";
            this.label19.Text = "3、本月滞纳金实收合计:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Yellow;
            this.label13.Location = new System.Drawing.Point(79, 297);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(232, 16);
            this.label13.TabIndex = 1;
            this.label13.Tag = "9999";
            this.label13.Text = "2、本月预收账款（预存）增减:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(143, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 16);
            this.label9.TabIndex = 1;
            this.label9.Tag = "9999";
            this.label9.Text = "1、本月实际实收小计:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(135, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 16);
            this.label7.TabIndex = 1;
            this.label7.Tag = "9999";
            this.label7.Text = "三、本月实际实收金额:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(223, 465);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 16);
            this.label17.TabIndex = 0;
            this.label17.Tag = "9999";
            this.label17.Text = "③ 附加费:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(223, 441);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 16);
            this.label16.TabIndex = 0;
            this.label16.Tag = "9999";
            this.label16.Text = "② 污水费:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(223, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 0;
            this.label12.Tag = "9999";
            this.label12.Text = "③ 附加费:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 249);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 0;
            this.label11.Tag = "9999";
            this.label11.Text = "② 污水费:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(223, 417);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 0;
            this.label15.Tag = "9999";
            this.label15.Text = "①   水费:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 0;
            this.label6.Tag = "9999";
            this.label6.Text = "③ 附加费:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 0;
            this.label10.Tag = "9999";
            this.label10.Text = "①   水费:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 0;
            this.label5.Tag = "9999";
            this.label5.Text = "② 污水费:";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ForeColor = System.Drawing.Color.DarkBlue;
            this.label41.Location = new System.Drawing.Point(312, 489);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(0, 16);
            this.label41.TabIndex = 0;
            this.label41.Tag = "9999";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(312, 465);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(0, 16);
            this.label40.TabIndex = 0;
            this.label40.Tag = "9999";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(312, 441);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(0, 16);
            this.label39.TabIndex = 0;
            this.label39.Tag = "9999";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(312, 417);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(0, 16);
            this.label38.TabIndex = 0;
            this.label38.Tag = "9999";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ForeColor = System.Drawing.Color.DarkBlue;
            this.label37.Location = new System.Drawing.Point(312, 393);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(0, 16);
            this.label37.TabIndex = 0;
            this.label37.Tag = "9999";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.DarkBlue;
            this.label36.Location = new System.Drawing.Point(312, 369);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(0, 16);
            this.label36.TabIndex = 0;
            this.label36.Tag = "9999";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.ForeColor = System.Drawing.Color.Yellow;
            this.label35.Location = new System.Drawing.Point(312, 345);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(0, 16);
            this.label35.TabIndex = 0;
            this.label35.Tag = "9999";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.Yellow;
            this.label34.Location = new System.Drawing.Point(312, 321);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(0, 16);
            this.label34.TabIndex = 0;
            this.label34.Tag = "9999";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ForeColor = System.Drawing.Color.Yellow;
            this.label33.Location = new System.Drawing.Point(312, 297);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(0, 16);
            this.label33.TabIndex = 0;
            this.label33.Tag = "9999";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(312, 273);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(0, 16);
            this.label32.TabIndex = 0;
            this.label32.Tag = "9999";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(312, 249);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(0, 16);
            this.label31.TabIndex = 0;
            this.label31.Tag = "9999";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(312, 225);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(0, 16);
            this.label30.TabIndex = 0;
            this.label30.Tag = "9999";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.Yellow;
            this.label29.Location = new System.Drawing.Point(312, 201);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(0, 16);
            this.label29.TabIndex = 0;
            this.label29.Tag = "9999";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.DarkBlue;
            this.label28.Location = new System.Drawing.Point(312, 177);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(0, 16);
            this.label28.TabIndex = 0;
            this.label28.Tag = "9999";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(312, 153);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(0, 16);
            this.label27.TabIndex = 0;
            this.label27.Tag = "9999";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(312, 129);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 16);
            this.label26.TabIndex = 0;
            this.label26.Tag = "9999";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(312, 105);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(0, 16);
            this.label25.TabIndex = 0;
            this.label25.Tag = "9999";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.DarkBlue;
            this.label24.Location = new System.Drawing.Point(312, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 16);
            this.label24.TabIndex = 0;
            this.label24.Tag = "9999";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.DarkBlue;
            this.label23.Location = new System.Drawing.Point(312, 57);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 16);
            this.label23.TabIndex = 0;
            this.label23.Tag = "9999";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.DarkBlue;
            this.label22.Location = new System.Drawing.Point(312, 33);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 16);
            this.label22.TabIndex = 0;
            this.label22.Tag = "9999";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 0;
            this.label4.Tag = "9999";
            this.label4.Text = "①   水费:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(135, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 0;
            this.label3.Tag = "9999";
            this.label3.Text = "二、本月实际应收金额:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(55, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 16);
            this.label2.TabIndex = 0;
            this.label2.Tag = "9999";
            this.label2.Text = "上期期末预收账款用户余额(财会):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 16);
            this.label1.TabIndex = 0;
            this.label1.Tag = "9999";
            this.label1.Text = "一、上期期末预收账款用户余额(营业):";
            // 
            // frmFinanceSubmitReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 606);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFinanceSubmitReport";
            this.Text = "财会上报工作表";
            this.Load += new System.EventHandler(this.frmWaterUserSearch_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolStatics;
        private System.Windows.Forms.GroupBox groupBox1;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkChargeDateTime;
        private System.Windows.Forms.DateTimePicker dtpStartSearch;
        private System.Windows.Forms.DateTimePicker dtpEndSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 今天ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 本月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下月ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 本年ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上年ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 全部ToolStripMenuItem;
        private System.Windows.Forms.Button btSetMonth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
    }
}
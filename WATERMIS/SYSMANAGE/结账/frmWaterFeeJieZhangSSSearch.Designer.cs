namespace SYSMANAGE
{
    partial class frmWaterFeeJieZhangSSSearch
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
            FastReport.Design.DesignerSettings designerSettings1 = new FastReport.Design.DesignerSettings();
            FastReport.Design.DesignerRestrictions designerRestrictions1 = new FastReport.Design.DesignerRestrictions();
            FastReport.Export.Email.EmailSettings emailSettings1 = new FastReport.Export.Email.EmailSettings();
            FastReport.PreviewSettings previewSettings1 = new FastReport.PreviewSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterFeeJieZhangSSSearch));
            FastReport.ReportSettings reportSettings1 = new FastReport.ReportSettings();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgJieZhangYS = new System.Windows.Forms.DataGridView();
            this.ACCOUNTSYEARANDMONTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCOUNTSDATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ACCOUNTSWORKERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERMETERTYPECLASSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERMETERTYPECLASSNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BILLCOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICECOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RECEIPTNOCOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTALNUMBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERTOTALCHARGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXTRACHARGE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXTRACHARGE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTALCHARGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OVERDUEMONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTALCHARGEEND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YCZJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SETTLEACCOUNTSSSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpStartSearch = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.tb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJieZhangYS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // environmentSettings1
            // 
            designerSettings1.ApplicationConnection = null;
            designerSettings1.DefaultFont = new System.Drawing.Font("宋体", 9F);
            designerSettings1.Icon = null;
            designerSettings1.Restrictions = designerRestrictions1;
            designerSettings1.Text = "";
            this.environmentSettings1.DesignerSettings = designerSettings1;
            emailSettings1.Address = "";
            emailSettings1.Host = "";
            emailSettings1.MessageTemplate = "";
            emailSettings1.Name = "";
            emailSettings1.Password = "";
            emailSettings1.UserName = "";
            this.environmentSettings1.EmailSettings = emailSettings1;
            previewSettings1.Buttons = ((FastReport.PreviewButtons)(((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Save)
                        | FastReport.PreviewButtons.Zoom)
                        | FastReport.PreviewButtons.PageSetup)
                        | FastReport.PreviewButtons.Close)));
            previewSettings1.Icon = ((System.Drawing.Icon)(resources.GetObject("previewSettings1.Icon")));
            previewSettings1.Text = "";
            this.environmentSettings1.PreviewSettings = previewSettings1;
            this.environmentSettings1.ReportSettings = reportSettings1;
            this.environmentSettings1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolPrint,
            this.toolPrintPreview});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 59;
            this.toolStrip1.Tag = "9999";
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::SYSMANAGE.Properties.Resources.onebit_02;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(60, 22);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // toolPrint
            // 
            this.toolPrint.Image = global::SYSMANAGE.Properties.Resources.print;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(60, 22);
            this.toolPrint.Text = "打印";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolPrintPreview
            // 
            this.toolPrintPreview.Image = global::SYSMANAGE.Properties.Resources.print;
            this.toolPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintPreview.Name = "toolPrintPreview";
            this.toolPrintPreview.Size = new System.Drawing.Size(92, 22);
            this.toolPrintPreview.Text = "打印预览";
            this.toolPrintPreview.Click += new System.EventHandler(this.toolPrintPreview_Click);
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.dgJieZhangYS, 0, 1);
            this.tb1.Controls.Add(this.groupBox1, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.28205F));
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 60;
            // 
            // dgJieZhangYS
            // 
            this.dgJieZhangYS.AllowUserToDeleteRows = false;
            this.dgJieZhangYS.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgJieZhangYS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgJieZhangYS.ColumnHeadersHeight = 25;
            this.dgJieZhangYS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgJieZhangYS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ACCOUNTSYEARANDMONTH,
            this.ACCOUNTSDATETIME,
            this.ACCOUNTSWORKERNAME,
            this.WATERMETERTYPECLASSID,
            this.WATERMETERTYPECLASSNAME,
            this.waterMeterTypeName,
            this.BILLCOUNT,
            this.INVOICECOUNT,
            this.RECEIPTNOCOUNT,
            this.TOTALNUMBER,
            this.WATERTOTALCHARGE,
            this.EXTRACHARGE1,
            this.EXTRACHARGE2,
            this.TOTALCHARGE,
            this.OVERDUEMONEY,
            this.TOTALCHARGEEND,
            this.YCZJ,
            this.SSJE,
            this.SETTLEACCOUNTSSSID});
            this.dgJieZhangYS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgJieZhangYS.Location = new System.Drawing.Point(3, 72);
            this.dgJieZhangYS.MultiSelect = false;
            this.dgJieZhangYS.Name = "dgJieZhangYS";
            this.dgJieZhangYS.ReadOnly = true;
            this.dgJieZhangYS.RowHeadersWidth = 45;
            this.dgJieZhangYS.RowTemplate.Height = 23;
            this.dgJieZhangYS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgJieZhangYS.Size = new System.Drawing.Size(1002, 462);
            this.dgJieZhangYS.TabIndex = 405;
            this.dgJieZhangYS.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgJieZhangYS_CellDoubleClick);
            this.dgJieZhangYS.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgJieZhangYS_DataBindingComplete);
            // 
            // ACCOUNTSYEARANDMONTH
            // 
            this.ACCOUNTSYEARANDMONTH.DataPropertyName = "ACCOUNTSYEARANDMONTH";
            this.ACCOUNTSYEARANDMONTH.HeaderText = "结账月份";
            this.ACCOUNTSYEARANDMONTH.Name = "ACCOUNTSYEARANDMONTH";
            this.ACCOUNTSYEARANDMONTH.ReadOnly = true;
            this.ACCOUNTSYEARANDMONTH.Visible = false;
            // 
            // ACCOUNTSDATETIME
            // 
            this.ACCOUNTSDATETIME.DataPropertyName = "ACCOUNTSDATETIME";
            this.ACCOUNTSDATETIME.HeaderText = "结账时间";
            this.ACCOUNTSDATETIME.Name = "ACCOUNTSDATETIME";
            this.ACCOUNTSDATETIME.ReadOnly = true;
            this.ACCOUNTSDATETIME.Visible = false;
            this.ACCOUNTSDATETIME.Width = 150;
            // 
            // ACCOUNTSWORKERNAME
            // 
            this.ACCOUNTSWORKERNAME.DataPropertyName = "ACCOUNTSWORKERNAME";
            this.ACCOUNTSWORKERNAME.HeaderText = "操作员";
            this.ACCOUNTSWORKERNAME.Name = "ACCOUNTSWORKERNAME";
            this.ACCOUNTSWORKERNAME.ReadOnly = true;
            this.ACCOUNTSWORKERNAME.Visible = false;
            // 
            // WATERMETERTYPECLASSID
            // 
            this.WATERMETERTYPECLASSID.DataPropertyName = "WATERMETERTYPECLASSID";
            this.WATERMETERTYPECLASSID.HeaderText = "分类编号";
            this.WATERMETERTYPECLASSID.Name = "WATERMETERTYPECLASSID";
            this.WATERMETERTYPECLASSID.ReadOnly = true;
            // 
            // WATERMETERTYPECLASSNAME
            // 
            this.WATERMETERTYPECLASSNAME.DataPropertyName = "WATERMETERTYPECLASSNAME";
            this.WATERMETERTYPECLASSNAME.HeaderText = "分类名称";
            this.WATERMETERTYPECLASSNAME.Name = "WATERMETERTYPECLASSNAME";
            this.WATERMETERTYPECLASSNAME.ReadOnly = true;
            // 
            // waterMeterTypeName
            // 
            this.waterMeterTypeName.DataPropertyName = "waterMeterTypeName";
            this.waterMeterTypeName.HeaderText = "用水性质";
            this.waterMeterTypeName.Name = "waterMeterTypeName";
            this.waterMeterTypeName.ReadOnly = true;
            this.waterMeterTypeName.Visible = false;
            // 
            // BILLCOUNT
            // 
            this.BILLCOUNT.DataPropertyName = "BILLCOUNT";
            this.BILLCOUNT.HeaderText = "单据数";
            this.BILLCOUNT.Name = "BILLCOUNT";
            this.BILLCOUNT.ReadOnly = true;
            // 
            // INVOICECOUNT
            // 
            this.INVOICECOUNT.DataPropertyName = "INVOICECOUNT";
            this.INVOICECOUNT.HeaderText = "发票张数";
            this.INVOICECOUNT.Name = "INVOICECOUNT";
            this.INVOICECOUNT.ReadOnly = true;
            this.INVOICECOUNT.Width = 120;
            // 
            // RECEIPTNOCOUNT
            // 
            this.RECEIPTNOCOUNT.DataPropertyName = "RECEIPTNOCOUNT";
            this.RECEIPTNOCOUNT.HeaderText = "收据张数";
            this.RECEIPTNOCOUNT.Name = "RECEIPTNOCOUNT";
            this.RECEIPTNOCOUNT.ReadOnly = true;
            // 
            // TOTALNUMBER
            // 
            this.TOTALNUMBER.DataPropertyName = "TOTALNUMBER";
            this.TOTALNUMBER.HeaderText = "总水量";
            this.TOTALNUMBER.Name = "TOTALNUMBER";
            this.TOTALNUMBER.ReadOnly = true;
            // 
            // WATERTOTALCHARGE
            // 
            this.WATERTOTALCHARGE.DataPropertyName = "WATERTOTALCHARGE";
            this.WATERTOTALCHARGE.HeaderText = "水费";
            this.WATERTOTALCHARGE.Name = "WATERTOTALCHARGE";
            this.WATERTOTALCHARGE.ReadOnly = true;
            // 
            // EXTRACHARGE1
            // 
            this.EXTRACHARGE1.DataPropertyName = "EXTRACHARGE1";
            this.EXTRACHARGE1.HeaderText = "污水处理费";
            this.EXTRACHARGE1.Name = "EXTRACHARGE1";
            this.EXTRACHARGE1.ReadOnly = true;
            // 
            // EXTRACHARGE2
            // 
            this.EXTRACHARGE2.DataPropertyName = "EXTRACHARGE2";
            this.EXTRACHARGE2.HeaderText = "附加费";
            this.EXTRACHARGE2.Name = "EXTRACHARGE2";
            this.EXTRACHARGE2.ReadOnly = true;
            // 
            // TOTALCHARGE
            // 
            this.TOTALCHARGE.DataPropertyName = "TOTALCHARGE";
            this.TOTALCHARGE.HeaderText = "水费小计";
            this.TOTALCHARGE.Name = "TOTALCHARGE";
            this.TOTALCHARGE.ReadOnly = true;
            // 
            // OVERDUEMONEY
            // 
            this.OVERDUEMONEY.DataPropertyName = "OVERDUEMONEY";
            this.OVERDUEMONEY.HeaderText = "滞纳金";
            this.OVERDUEMONEY.Name = "OVERDUEMONEY";
            this.OVERDUEMONEY.ReadOnly = true;
            // 
            // TOTALCHARGEEND
            // 
            this.TOTALCHARGEEND.DataPropertyName = "TOTALCHARGEEND";
            this.TOTALCHARGEEND.HeaderText = "水费总计";
            this.TOTALCHARGEEND.Name = "TOTALCHARGEEND";
            this.TOTALCHARGEEND.ReadOnly = true;
            // 
            // YCZJ
            // 
            this.YCZJ.DataPropertyName = "YCZJ";
            this.YCZJ.HeaderText = "预存增减";
            this.YCZJ.Name = "YCZJ";
            this.YCZJ.ReadOnly = true;
            // 
            // SSJE
            // 
            this.SSJE.DataPropertyName = "SSJE";
            this.SSJE.HeaderText = "实收金额";
            this.SSJE.Name = "SSJE";
            this.SSJE.ReadOnly = true;
            // 
            // SETTLEACCOUNTSSSID
            // 
            this.SETTLEACCOUNTSSSID.DataPropertyName = "SETTLEACCOUNTSSSID";
            this.SETTLEACCOUNTSSSID.HeaderText = "SETTLEACCOUNTSSSID";
            this.SETTLEACCOUNTSSSID.Name = "SETTLEACCOUNTSSSID";
            this.SETTLEACCOUNTSSSID.ReadOnly = true;
            this.SETTLEACCOUNTSSSID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox1.Controls.Add(this.dtpStartSearch);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 59);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "9999";
            this.groupBox1.Text = "查询条件";
            // 
            // dtpStartSearch
            // 
            this.dtpStartSearch.CustomFormat = "yyyy-MM";
            this.dtpStartSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartSearch.Location = new System.Drawing.Point(263, 21);
            this.dtpStartSearch.Name = "dtpStartSearch";
            this.dtpStartSearch.ShowUpDown = true;
            this.dtpStartSearch.Size = new System.Drawing.Size(86, 26);
            this.dtpStartSearch.TabIndex = 185;
            this.dtpStartSearch.Visible = false;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(103, 21);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowUpDown = true;
            this.dtpStart.Size = new System.Drawing.Size(86, 26);
            this.dtpStart.TabIndex = 183;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 184;
            this.label1.Text = "结账月份:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LimeGreen;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 59);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "9999";
            this.groupBox2.Text = "查询条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 184;
            this.label2.Text = "结账月份:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(103, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(86, 21);
            this.dateTimePicker1.TabIndex = 183;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 35);
            this.button1.TabIndex = 179;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmWaterFeeJieZhangSSSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterFeeJieZhangSSSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "结账数据-实收查询";
            this.Load += new System.EventHandler(this.frmWaterUserSearch_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tb1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgJieZhangYS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private System.Windows.Forms.DataGridView dgJieZhangYS;
        private System.Windows.Forms.DateTimePicker dtpStartSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNTSYEARANDMONTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNTSDATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNTSWORKERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERMETERTYPECLASSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERMETERTYPECLASSNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BILLCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICECOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RECEIPTNOCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTALNUMBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERTOTALCHARGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXTRACHARGE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXTRACHARGE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTALCHARGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OVERDUEMONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTALCHARGEEND;
        private System.Windows.Forms.DataGridViewTextBoxColumn YCZJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SSJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SETTLEACCOUNTSSSID;
    }
}
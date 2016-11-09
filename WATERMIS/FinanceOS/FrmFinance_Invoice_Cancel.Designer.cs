namespace FinanceOS
{
    partial class FrmFinance_Invoice_Cancel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinance_Invoice_Cancel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolCancelReason = new System.Windows.Forms.ToolStripComboBox();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolChangeInvoiceNO = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除一行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加一行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.txtInvoiceOpener = new System.Windows.Forms.TextBox();
            this.txtChecker = new System.Windows.Forms.TextBox();
            this.txtPayee = new System.Windows.Forms.TextBox();
            this.txtCompanyBankNameAndAccountNO = new System.Windows.Forms.TextBox();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.txtCompanyFPTaxNO = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtSumMoney = new System.Windows.Forms.TextBox();
            this.txtCapMoney = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.FeeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Units = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtWaterUserBankAccount = new System.Windows.Forms.TextBox();
            this.txtWaterUserAddress = new System.Windows.Forms.TextBox();
            this.txtWaterUserFPTaxNO = new System.Windows.Forms.TextBox();
            this.txtWaterUserName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labInvoiceState = new System.Windows.Forms.Label();
            this.rbZZ = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.txtInvoiceNO = new System.Windows.Forms.TextBox();
            this.cmbBatch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolCancelReason,
            this.toolCancel,
            this.toolStripSeparator1,
            this.toolChangeInvoiceNO});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(879, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Tag = "9999";
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(78, 28);
            this.toolStripLabel1.Text = "作废原因:";
            // 
            // toolCancelReason
            // 
            this.toolCancelReason.Items.AddRange(new object[] {
            "损坏作废",
            "未打作废"});
            this.toolCancelReason.Name = "toolCancelReason";
            this.toolCancelReason.Size = new System.Drawing.Size(121, 31);
            // 
            // toolCancel
            // 
            this.toolCancel.Enabled = false;
            this.toolCancel.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolCancel.Image = global::FinanceOS.Properties.Resources.onebit_33;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(66, 28);
            this.toolCancel.Text = "作废";
            this.toolCancel.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolChangeInvoiceNO
            // 
            this.toolChangeInvoiceNO.Enabled = false;
            this.toolChangeInvoiceNO.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolChangeInvoiceNO.Image = global::FinanceOS.Properties.Resources.onebit_20;
            this.toolChangeInvoiceNO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolChangeInvoiceNO.Name = "toolChangeInvoiceNO";
            this.toolChangeInvoiceNO.Size = new System.Drawing.Size(66, 28);
            this.toolChangeInvoiceNO.Text = "变更";
            this.toolChangeInvoiceNO.Click += new System.EventHandler(this.toolChangeInvoiceNO_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除一行ToolStripMenuItem,
            this.增加一行ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 删除一行ToolStripMenuItem
            // 
            this.删除一行ToolStripMenuItem.Name = "删除一行ToolStripMenuItem";
            this.删除一行ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除一行ToolStripMenuItem.Text = "删除一行";
            // 
            // 增加一行ToolStripMenuItem
            // 
            this.增加一行ToolStripMenuItem.Name = "增加一行ToolStripMenuItem";
            this.增加一行ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加一行ToolStripMenuItem.Text = "增加一行";
            // 
            // tb1
            // 
            this.tb1.BackgroundImage = global::FinanceOS.Properties.Resources.InvoiceBg;
            this.tb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tb1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.panel4, 0, 3);
            this.tb1.Controls.Add(this.panel3, 0, 2);
            this.tb1.Controls.Add(this.panel2, 0, 1);
            this.tb1.Controls.Add(this.panel1, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 31);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 4;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.48763F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.08481F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.14841F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.27915F));
            this.tb1.Size = new System.Drawing.Size(879, 564);
            this.tb1.TabIndex = 2;
            this.tb1.Tag = "9999";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.txtMemo);
            this.panel4.Controls.Add(this.txtInvoiceOpener);
            this.panel4.Controls.Add(this.txtChecker);
            this.panel4.Controls.Add(this.txtPayee);
            this.panel4.Controls.Add(this.txtCompanyBankNameAndAccountNO);
            this.panel4.Controls.Add(this.txtCompanyAddress);
            this.panel4.Controls.Add(this.txtCompanyFPTaxNO);
            this.panel4.Controls.Add(this.txtCompanyName);
            this.panel4.Controls.Add(this.txtSumMoney);
            this.panel4.Controls.Add(this.txtCapMoney);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1, 353);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(877, 210);
            this.panel4.TabIndex = 3;
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.SystemColors.Window;
            this.txtMemo.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMemo.Location = new System.Drawing.Point(560, 48);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ReadOnly = true;
            this.txtMemo.Size = new System.Drawing.Size(306, 113);
            this.txtMemo.TabIndex = 4;
            // 
            // txtInvoiceOpener
            // 
            this.txtInvoiceOpener.AcceptsReturn = true;
            this.txtInvoiceOpener.BackColor = System.Drawing.SystemColors.Window;
            this.txtInvoiceOpener.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInvoiceOpener.Location = new System.Drawing.Point(638, 176);
            this.txtInvoiceOpener.Name = "txtInvoiceOpener";
            this.txtInvoiceOpener.ReadOnly = true;
            this.txtInvoiceOpener.Size = new System.Drawing.Size(111, 23);
            this.txtInvoiceOpener.TabIndex = 3;
            // 
            // txtChecker
            // 
            this.txtChecker.AcceptsReturn = true;
            this.txtChecker.BackColor = System.Drawing.SystemColors.Window;
            this.txtChecker.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChecker.Location = new System.Drawing.Point(345, 176);
            this.txtChecker.Name = "txtChecker";
            this.txtChecker.ReadOnly = true;
            this.txtChecker.Size = new System.Drawing.Size(111, 23);
            this.txtChecker.TabIndex = 3;
            // 
            // txtPayee
            // 
            this.txtPayee.AcceptsReturn = true;
            this.txtPayee.BackColor = System.Drawing.SystemColors.Window;
            this.txtPayee.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPayee.Location = new System.Drawing.Point(95, 176);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.ReadOnly = true;
            this.txtPayee.Size = new System.Drawing.Size(111, 23);
            this.txtPayee.TabIndex = 3;
            // 
            // txtCompanyBankNameAndAccountNO
            // 
            this.txtCompanyBankNameAndAccountNO.AcceptsReturn = true;
            this.txtCompanyBankNameAndAccountNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompanyBankNameAndAccountNO.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompanyBankNameAndAccountNO.Location = new System.Drawing.Point(166, 141);
            this.txtCompanyBankNameAndAccountNO.Name = "txtCompanyBankNameAndAccountNO";
            this.txtCompanyBankNameAndAccountNO.ReadOnly = true;
            this.txtCompanyBankNameAndAccountNO.Size = new System.Drawing.Size(355, 23);
            this.txtCompanyBankNameAndAccountNO.TabIndex = 3;
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompanyAddress.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompanyAddress.Location = new System.Drawing.Point(166, 110);
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.ReadOnly = true;
            this.txtCompanyAddress.Size = new System.Drawing.Size(355, 23);
            this.txtCompanyAddress.TabIndex = 3;
            // 
            // txtCompanyFPTaxNO
            // 
            this.txtCompanyFPTaxNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompanyFPTaxNO.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompanyFPTaxNO.Location = new System.Drawing.Point(166, 79);
            this.txtCompanyFPTaxNO.Name = "txtCompanyFPTaxNO";
            this.txtCompanyFPTaxNO.ReadOnly = true;
            this.txtCompanyFPTaxNO.Size = new System.Drawing.Size(355, 23);
            this.txtCompanyFPTaxNO.TabIndex = 3;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCompanyName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCompanyName.Location = new System.Drawing.Point(166, 48);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(355, 23);
            this.txtCompanyName.TabIndex = 3;
            // 
            // txtSumMoney
            // 
            this.txtSumMoney.BackColor = System.Drawing.SystemColors.Window;
            this.txtSumMoney.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSumMoney.Location = new System.Drawing.Point(638, 8);
            this.txtSumMoney.Name = "txtSumMoney";
            this.txtSumMoney.ReadOnly = true;
            this.txtSumMoney.Size = new System.Drawing.Size(163, 23);
            this.txtSumMoney.TabIndex = 2;
            // 
            // txtCapMoney
            // 
            this.txtCapMoney.BackColor = System.Drawing.SystemColors.Window;
            this.txtCapMoney.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCapMoney.Location = new System.Drawing.Point(171, 8);
            this.txtCapMoney.Name = "txtCapMoney";
            this.txtCapMoney.ReadOnly = true;
            this.txtCapMoney.Size = new System.Drawing.Size(310, 23);
            this.txtCapMoney.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.dgList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1, 206);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(877, 146);
            this.panel3.TabIndex = 2;
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeeItem,
            this.InvoiceTitle,
            this.Units,
            this.Quantity,
            this.Price,
            this.TotalMoney,
            this.TaxPercent,
            this.TaxMoney});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(0, 0);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 25;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(877, 146);
            this.dgList.TabIndex = 0;
            this.dgList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellValueChanged);
            this.dgList.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgList_CellMouseDown);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            // 
            // FeeItem
            // 
            this.FeeItem.DataPropertyName = "FeeItem";
            this.FeeItem.HeaderText = "应税名称";
            this.FeeItem.Name = "FeeItem";
            this.FeeItem.ReadOnly = true;
            // 
            // InvoiceTitle
            // 
            this.InvoiceTitle.DataPropertyName = "FeeItemInvoiceTitle";
            this.InvoiceTitle.HeaderText = "应税名称(发票项目)";
            this.InvoiceTitle.Name = "InvoiceTitle";
            this.InvoiceTitle.ReadOnly = true;
            this.InvoiceTitle.Width = 150;
            // 
            // Units
            // 
            this.Units.DataPropertyName = "Units";
            this.Units.HeaderText = "单位";
            this.Units.Name = "Units";
            this.Units.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "数量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "单价(含税)";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // TotalMoney
            // 
            this.TotalMoney.DataPropertyName = "TotalMoney";
            this.TotalMoney.HeaderText = "金额(含税)";
            this.TotalMoney.Name = "TotalMoney";
            this.TotalMoney.ReadOnly = true;
            // 
            // TaxPercent
            // 
            this.TaxPercent.DataPropertyName = "TaxPercent";
            this.TaxPercent.HeaderText = "税率";
            this.TaxPercent.Name = "TaxPercent";
            this.TaxPercent.ReadOnly = true;
            // 
            // TaxMoney
            // 
            this.TaxMoney.DataPropertyName = "TaxMoney";
            this.TaxMoney.HeaderText = "税额";
            this.TaxMoney.Name = "TaxMoney";
            this.TaxMoney.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.txtWaterUserBankAccount);
            this.panel2.Controls.Add(this.txtWaterUserAddress);
            this.panel2.Controls.Add(this.txtWaterUserFPTaxNO);
            this.panel2.Controls.Add(this.txtWaterUserName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 82);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 123);
            this.panel2.TabIndex = 1;
            // 
            // txtWaterUserBankAccount
            // 
            this.txtWaterUserBankAccount.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserBankAccount.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWaterUserBankAccount.Location = new System.Drawing.Point(164, 97);
            this.txtWaterUserBankAccount.Name = "txtWaterUserBankAccount";
            this.txtWaterUserBankAccount.ReadOnly = true;
            this.txtWaterUserBankAccount.Size = new System.Drawing.Size(366, 23);
            this.txtWaterUserBankAccount.TabIndex = 1;
            // 
            // txtWaterUserAddress
            // 
            this.txtWaterUserAddress.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserAddress.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWaterUserAddress.Location = new System.Drawing.Point(164, 67);
            this.txtWaterUserAddress.Name = "txtWaterUserAddress";
            this.txtWaterUserAddress.ReadOnly = true;
            this.txtWaterUserAddress.Size = new System.Drawing.Size(366, 23);
            this.txtWaterUserAddress.TabIndex = 1;
            // 
            // txtWaterUserFPTaxNO
            // 
            this.txtWaterUserFPTaxNO.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserFPTaxNO.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWaterUserFPTaxNO.Location = new System.Drawing.Point(164, 37);
            this.txtWaterUserFPTaxNO.Name = "txtWaterUserFPTaxNO";
            this.txtWaterUserFPTaxNO.ReadOnly = true;
            this.txtWaterUserFPTaxNO.Size = new System.Drawing.Size(366, 23);
            this.txtWaterUserFPTaxNO.TabIndex = 1;
            // 
            // txtWaterUserName
            // 
            this.txtWaterUserName.BackColor = System.Drawing.SystemColors.Window;
            this.txtWaterUserName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWaterUserName.Location = new System.Drawing.Point(164, 7);
            this.txtWaterUserName.Name = "txtWaterUserName";
            this.txtWaterUserName.ReadOnly = true;
            this.txtWaterUserName.Size = new System.Drawing.Size(366, 23);
            this.txtWaterUserName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labInvoiceState);
            this.panel1.Controls.Add(this.rbZZ);
            this.panel1.Controls.Add(this.rbNormal);
            this.panel1.Controls.Add(this.txtInvoiceNO);
            this.panel1.Controls.Add(this.cmbBatch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 80);
            this.panel1.TabIndex = 0;
            // 
            // labInvoiceState
            // 
            this.labInvoiceState.AutoSize = true;
            this.labInvoiceState.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labInvoiceState.ForeColor = System.Drawing.Color.Red;
            this.labInvoiceState.Location = new System.Drawing.Point(750, 10);
            this.labInvoiceState.Name = "labInvoiceState";
            this.labInvoiceState.Size = new System.Drawing.Size(68, 27);
            this.labInvoiceState.TabIndex = 115;
            this.labInvoiceState.Tag = "9999";
            this.labInvoiceState.Text = "正常";
            // 
            // rbZZ
            // 
            this.rbZZ.AutoSize = true;
            this.rbZZ.Enabled = false;
            this.rbZZ.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbZZ.Location = new System.Drawing.Point(116, 55);
            this.rbZZ.Name = "rbZZ";
            this.rbZZ.Size = new System.Drawing.Size(81, 18);
            this.rbZZ.TabIndex = 114;
            this.rbZZ.Text = "专用发票";
            this.rbZZ.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Enabled = false;
            this.rbNormal.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbNormal.Location = new System.Drawing.Point(20, 55);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(81, 18);
            this.rbNormal.TabIndex = 113;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "普通发票";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // txtInvoiceNO
            // 
            this.txtInvoiceNO.BackColor = System.Drawing.Color.LightYellow;
            this.txtInvoiceNO.Location = new System.Drawing.Point(531, 53);
            this.txtInvoiceNO.Name = "txtInvoiceNO";
            this.txtInvoiceNO.Size = new System.Drawing.Size(125, 21);
            this.txtInvoiceNO.TabIndex = 112;
            // 
            // cmbBatch
            // 
            this.cmbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBatch.DropDownWidth = 130;
            this.cmbBatch.FormattingEnabled = true;
            this.cmbBatch.Location = new System.Drawing.Point(296, 54);
            this.cmbBatch.Name = "cmbBatch";
            this.cmbBatch.Size = new System.Drawing.Size(144, 20);
            this.cmbBatch.TabIndex = 111;
            this.cmbBatch.SelectionChangeCommitted += new System.EventHandler(this.cmbBatch_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(228, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "发票批次：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(457, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "发票号码：";
            // 
            // FrmFinance_Invoice_Cancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 595);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFinance_Invoice_Cancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发票打印";
            this.Load += new System.EventHandler(this.FrmFinance_Invoice_PrintShow_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tb1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtWaterUserName;
        private System.Windows.Forms.TextBox txtWaterUserFPTaxNO;
        private System.Windows.Forms.TextBox txtWaterUserBankAccount;
        private System.Windows.Forms.TextBox txtWaterUserAddress;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.TextBox txtCompanyBankNameAndAccountNO;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.TextBox txtCompanyFPTaxNO;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtSumMoney;
        private System.Windows.Forms.TextBox txtCapMoney;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.TextBox txtInvoiceOpener;
        private System.Windows.Forms.TextBox txtChecker;
        private System.Windows.Forms.TextBox txtPayee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBatch;
        private System.Windows.Forms.TextBox txtInvoiceNO;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除一行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加一行ToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbZZ;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolChangeInvoiceNO;
        private System.Windows.Forms.Label labInvoiceState;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolCancelReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Units;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxMoney;
    }
}
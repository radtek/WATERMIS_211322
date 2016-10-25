namespace WorkFlow
{
    partial class FrmChargeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChargeList));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TV_FeeItems = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Units = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DefaultValue = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_submit = new System.Windows.Forms.Button();
            this.State = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InvoiceTitle = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.FeeItem = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.Sort = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 627);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.TV_FeeItems);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 621);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目列表";
            // 
            // TV_FeeItems
            // 
            this.TV_FeeItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_FeeItems.HideSelection = false;
            this.TV_FeeItems.ItemHeight = 22;
            this.TV_FeeItems.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TV_FeeItems.Location = new System.Drawing.Point(3, 17);
            this.TV_FeeItems.Margin = new System.Windows.Forms.Padding(4);
            this.TV_FeeItems.Name = "TV_FeeItems";
            this.TV_FeeItems.Size = new System.Drawing.Size(148, 601);
            this.TV_FeeItems.TabIndex = 12;
            this.TV_FeeItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_FeeItems_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.Sort);
            this.panel1.Controls.Add(this.FeeItem);
            this.panel1.Controls.Add(this.InvoiceTitle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Units);
            this.panel1.Controls.Add(this.Price);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DefaultValue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_submit);
            this.panel1.Controls.Add(this.State);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(163, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 621);
            this.panel1.TabIndex = 1;
            // 
            // Units
            // 
            this.Units.Location = new System.Drawing.Point(115, 140);
            this.Units.Name = "Units";
            this.Units.Size = new System.Drawing.Size(116, 21);
            this.Units.TabIndex = 137;
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(115, 171);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(117, 21);
            this.Price.TabIndex = 136;
            this.Price.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 132;
            this.label3.Text = "单    价：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 131;
            this.label2.Text = "单    位：";
            // 
            // DefaultValue
            // 
            this.DefaultValue.Location = new System.Drawing.Point(115, 108);
            this.DefaultValue.Name = "DefaultValue";
            this.DefaultValue.Size = new System.Drawing.Size(116, 21);
            this.DefaultValue.TabIndex = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(44, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 129;
            this.label1.Text = "添  加";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Btn_submit
            // 
            this.Btn_submit.Location = new System.Drawing.Point(138, 273);
            this.Btn_submit.Name = "Btn_submit";
            this.Btn_submit.Size = new System.Drawing.Size(84, 30);
            this.Btn_submit.TabIndex = 128;
            this.Btn_submit.Text = "保  存";
            this.Btn_submit.UseVisualStyleBackColor = true;
            this.Btn_submit.Click += new System.EventHandler(this.Btn_submit_Click);
            // 
            // State
            // 
            this.State.AutoSize = true;
            this.State.BackColor = System.Drawing.Color.White;
            this.State.Checked = true;
            this.State.CheckState = System.Windows.Forms.CheckState.Checked;
            this.State.Location = new System.Drawing.Point(116, 238);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(48, 16);
            this.State.TabIndex = 127;
            this.State.Text = "启用";
            this.State.UseVisualStyleBackColor = false;
            this.State.CheckedChanged += new System.EventHandler(this.State_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(38, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 123;
            this.label14.Text = "*收费名目：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(44, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 124;
            this.label15.Text = "默 认 值：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(38, 84);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(71, 12);
            this.label29.TabIndex = 122;
            this.label29.Text = " 排    序：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 138;
            this.label4.Text = "发票名目：";
            // 
            // InvoiceTitle
            // 
            this.InvoiceTitle.AllowEmpty = false;
            this.InvoiceTitle.EmptyMessage = "";
            this.InvoiceTitle.ErrorMessage = "";
            this.InvoiceTitle.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.InvoiceTitle.Location = new System.Drawing.Point(115, 202);
            this.InvoiceTitle.Name = "InvoiceTitle";
            this.InvoiceTitle.RegexExpression = "";
            this.InvoiceTitle.RemoveSpace = false;
            this.InvoiceTitle.Size = new System.Drawing.Size(116, 21);
            this.InvoiceTitle.TabIndex = 139;
            this.InvoiceTitle.ValidateState = false;
            // 
            // FeeItem
            // 
            this.FeeItem.AllowEmpty = false;
            this.FeeItem.EmptyMessage = "";
            this.FeeItem.ErrorMessage = "";
            this.FeeItem.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.FeeItem.Location = new System.Drawing.Point(115, 46);
            this.FeeItem.Name = "FeeItem";
            this.FeeItem.RegexExpression = "";
            this.FeeItem.RemoveSpace = false;
            this.FeeItem.Size = new System.Drawing.Size(116, 21);
            this.FeeItem.TabIndex = 140;
            this.FeeItem.ValidateState = false;
            // 
            // Sort
            // 
            this.Sort.AllowEmpty = false;
            this.Sort.EmptyMessage = "";
            this.Sort.ErrorMessage = "";
            this.Sort.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.文本;
            this.Sort.Location = new System.Drawing.Point(116, 78);
            this.Sort.Name = "Sort";
            this.Sort.RegexExpression = "";
            this.Sort.RemoveSpace = false;
            this.Sort.Size = new System.Drawing.Size(47, 21);
            this.Sort.TabIndex = 141;
            this.Sort.Text = "1";
            this.Sort.ValidateState = false;
            // 
            // FrmChargeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 627);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmChargeList";
            this.Text = "收费项目管理";
            this.Load += new System.EventHandler(this.FrmChargeList_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button Btn_submit;
        private System.Windows.Forms.CheckBox State;
        private System.Windows.Forms.TreeView TV_FeeItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox DefaultValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Units;
        private System.Windows.Forms.MaskedTextBox Price;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox FeeItem;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox InvoiceTitle;
        private System.Windows.Forms.Label label4;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox Sort;
    }
}
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
            this.FeeItem = new System.Windows.Forms.MaskedTextBox();
            this.Sort = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 465);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.TV_FeeItems);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 459);
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
            this.TV_FeeItems.Size = new System.Drawing.Size(148, 439);
            this.TV_FeeItems.TabIndex = 12;
            this.TV_FeeItems.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_FeeItems_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.Units);
            this.panel1.Controls.Add(this.Price);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DefaultValue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_submit);
            this.panel1.Controls.Add(this.State);
            this.panel1.Controls.Add(this.FeeItem);
            this.panel1.Controls.Add(this.Sort);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(163, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 459);
            this.panel1.TabIndex = 1;
            // 
            // Units
            // 
            this.Units.Location = new System.Drawing.Point(115, 143);
            this.Units.Name = "Units";
            this.Units.Size = new System.Drawing.Size(116, 21);
            this.Units.TabIndex = 137;
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(115, 175);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(117, 21);
            this.Price.TabIndex = 136;
            this.Price.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 132;
            this.label3.Text = "单    价：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(44, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 131;
            this.label2.Text = "单    位：";
            // 
            // DefaultValue
            // 
            this.DefaultValue.Location = new System.Drawing.Point(115, 111);
            this.DefaultValue.Name = "DefaultValue";
            this.DefaultValue.Size = new System.Drawing.Size(116, 21);
            this.DefaultValue.TabIndex = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(44, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 129;
            this.label1.Text = "添  加";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Btn_submit
            // 
            this.Btn_submit.Location = new System.Drawing.Point(138, 248);
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
            this.State.Location = new System.Drawing.Point(115, 210);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(48, 16);
            this.State.TabIndex = 127;
            this.State.Text = "启用";
            this.State.UseVisualStyleBackColor = false;
            this.State.CheckedChanged += new System.EventHandler(this.State_CheckedChanged);
            // 
            // FeeItem
            // 
            this.FeeItem.Location = new System.Drawing.Point(115, 47);
            this.FeeItem.Name = "FeeItem";
            this.FeeItem.Size = new System.Drawing.Size(117, 21);
            this.FeeItem.TabIndex = 126;
            // 
            // Sort
            // 
            this.Sort.Location = new System.Drawing.Point(115, 79);
            this.Sort.Mask = "99";
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(41, 21);
            this.Sort.TabIndex = 120;
            this.Sort.Text = "0";
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
            this.label15.Location = new System.Drawing.Point(44, 116);
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
            // FrmChargeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 465);
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
        private System.Windows.Forms.MaskedTextBox FeeItem;
        private System.Windows.Forms.MaskedTextBox Sort;
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
    }
}
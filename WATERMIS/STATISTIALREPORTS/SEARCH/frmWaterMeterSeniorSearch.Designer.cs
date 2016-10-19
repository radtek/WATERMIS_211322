namespace STATISTIALREPORTS
{
    partial class frmWaterMeterSeniorSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterMeterSeniorSearch));
            this.btOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btInsert = new System.Windows.Forms.Button();
            this.btInsertContition = new System.Windows.Forms.Button();
            this.cmbValue = new System.Windows.Forms.ComboBox();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btBraketsRight = new System.Windows.Forms.Button();
            this.btBraketsLeft = new System.Windows.Forms.Button();
            this.btOr = new System.Windows.Forms.Button();
            this.btAnd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labHaveSetUpHidden = new System.Windows.Forms.Label();
            this.labHaveSetUp = new System.Windows.Forms.Label();
            this.btClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(77, 299);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 37);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "确定";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btInsert);
            this.groupBox1.Controls.Add(this.btInsertContition);
            this.groupBox1.Controls.Add(this.cmbValue);
            this.groupBox1.Controls.Add(this.cmbOperator);
            this.groupBox1.Controls.Add(this.cmbItem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 102);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择条件";
            // 
            // btInsert
            // 
            this.btInsert.Enabled = false;
            this.btInsert.Location = new System.Drawing.Point(299, 22);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(71, 30);
            this.btInsert.TabIndex = 100;
            this.btInsert.Text = "插入值";
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // btInsertContition
            // 
            this.btInsertContition.Location = new System.Drawing.Point(110, 61);
            this.btInsertContition.Name = "btInsertContition";
            this.btInsertContition.Size = new System.Drawing.Size(93, 30);
            this.btInsertContition.TabIndex = 99;
            this.btInsertContition.Text = "加入条件";
            this.btInsertContition.UseVisualStyleBackColor = true;
            this.btInsertContition.Click += new System.EventHandler(this.btInsertContition_Click);
            // 
            // cmbValue
            // 
            this.cmbValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValue.DropDownWidth = 100;
            this.cmbValue.FormattingEnabled = true;
            this.cmbValue.Items.AddRange(new object[] {
            "抄表员"});
            this.cmbValue.Location = new System.Drawing.Point(192, 25);
            this.cmbValue.Name = "cmbValue";
            this.cmbValue.Size = new System.Drawing.Size(97, 24);
            this.cmbValue.TabIndex = 2;
            // 
            // cmbOperator
            // 
            this.cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperator.DropDownWidth = 100;
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Items.AddRange(new object[] {
            "=",
            ">",
            ">=",
            "<",
            "<=",
            "<>",
            "包含"});
            this.cmbOperator.Location = new System.Drawing.Point(116, 25);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(66, 24);
            this.cmbOperator.TabIndex = 1;
            // 
            // cmbItem
            // 
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.DropDownWidth = 100;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Items.AddRange(new object[] {
            "抄表员",
            "抄表本",
            "区域",
            "用户类别",
            "用户号",
            "水表编号",
            "用水性质",
            "定量用水"});
            this.cmbItem.Location = new System.Drawing.Point(10, 25);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(97, 24);
            this.cmbItem.TabIndex = 0;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btBraketsRight);
            this.groupBox2.Controls.Add(this.btBraketsLeft);
            this.groupBox2.Controls.Add(this.btOr);
            this.groupBox2.Controls.Add(this.btAnd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(10, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 64);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运算符";
            // 
            // btBraketsRight
            // 
            this.btBraketsRight.Enabled = false;
            this.btBraketsRight.Location = new System.Drawing.Point(280, 22);
            this.btBraketsRight.Name = "btBraketsRight";
            this.btBraketsRight.Size = new System.Drawing.Size(90, 30);
            this.btBraketsRight.TabIndex = 3;
            this.btBraketsRight.Text = "右括号\")\"";
            this.btBraketsRight.UseVisualStyleBackColor = true;
            this.btBraketsRight.Click += new System.EventHandler(this.btBraketsRight_Click);
            // 
            // btBraketsLeft
            // 
            this.btBraketsLeft.Location = new System.Drawing.Point(172, 22);
            this.btBraketsLeft.Name = "btBraketsLeft";
            this.btBraketsLeft.Size = new System.Drawing.Size(90, 30);
            this.btBraketsLeft.TabIndex = 2;
            this.btBraketsLeft.Text = "左括号\"(\"";
            this.btBraketsLeft.UseVisualStyleBackColor = true;
            this.btBraketsLeft.Click += new System.EventHandler(this.btBraketsLeft_Click);
            // 
            // btOr
            // 
            this.btOr.Enabled = false;
            this.btOr.Location = new System.Drawing.Point(96, 22);
            this.btOr.Name = "btOr";
            this.btOr.Size = new System.Drawing.Size(58, 30);
            this.btOr.TabIndex = 1;
            this.btOr.Text = "或者";
            this.btOr.UseVisualStyleBackColor = true;
            this.btOr.Click += new System.EventHandler(this.btOr_Click);
            // 
            // btAnd
            // 
            this.btAnd.Enabled = false;
            this.btAnd.Location = new System.Drawing.Point(20, 22);
            this.btAnd.Name = "btAnd";
            this.btAnd.Size = new System.Drawing.Size(58, 30);
            this.btAnd.TabIndex = 0;
            this.btAnd.Text = "并且";
            this.btAnd.UseVisualStyleBackColor = true;
            this.btAnd.Click += new System.EventHandler(this.btAnd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labHaveSetUpHidden);
            this.groupBox3.Controls.Add(this.labHaveSetUp);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(10, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(383, 112);
            this.groupBox3.TabIndex = 100;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "已设置条件";
            // 
            // labHaveSetUpHidden
            // 
            this.labHaveSetUpHidden.AutoSize = true;
            this.labHaveSetUpHidden.Location = new System.Drawing.Point(293, 96);
            this.labHaveSetUpHidden.Name = "labHaveSetUpHidden";
            this.labHaveSetUpHidden.Size = new System.Drawing.Size(0, 16);
            this.labHaveSetUpHidden.TabIndex = 102;
            this.labHaveSetUpHidden.Visible = false;
            // 
            // labHaveSetUp
            // 
            this.labHaveSetUp.Location = new System.Drawing.Point(17, 22);
            this.labHaveSetUp.Name = "labHaveSetUp";
            this.labHaveSetUp.Size = new System.Drawing.Size(351, 75);
            this.labHaveSetUp.TabIndex = 0;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(186, 299);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 37);
            this.btClear.TabIndex = 101;
            this.btClear.Text = "清空";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // frmWaterMeterSeniorSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 349);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btOK);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWaterMeterSeniorSearch";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "高级条件设置";
            this.Load += new System.EventHandler(this.frmSeniorSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.ComboBox cmbValue;
        private System.Windows.Forms.Button btInsertContition;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btBraketsLeft;
        private System.Windows.Forms.Button btOr;
        private System.Windows.Forms.Button btAnd;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labHaveSetUp;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Label labHaveSetUpHidden;
        private System.Windows.Forms.Button btBraketsRight;
    }
}
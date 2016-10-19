namespace WorkFlow
{
    partial class Meter_WorkPoint
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PointSort = new System.Windows.Forms.MaskedTextBox();
            this.LB_Creaate = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.State = new System.Windows.Forms.ComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.PointName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TV_Point = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TV_Flow = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 454);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PointSort);
            this.groupBox3.Controls.Add(this.LB_Creaate);
            this.groupBox3.Controls.Add(this.Btn_Submit);
            this.groupBox3.Controls.Add(this.State);
            this.groupBox3.Controls.Add(this.label86);
            this.groupBox3.Controls.Add(this.PointName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(364, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(414, 446);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "详细信息";
            // 
            // PointSort
            // 
            this.PointSort.Location = new System.Drawing.Point(106, 76);
            this.PointSort.Mask = "90";
            this.PointSort.Name = "PointSort";
            this.PointSort.Size = new System.Drawing.Size(100, 21);
            this.PointSort.TabIndex = 104;
            // 
            // LB_Creaate
            // 
            this.LB_Creaate.AutoSize = true;
            this.LB_Creaate.Location = new System.Drawing.Point(35, 208);
            this.LB_Creaate.Name = "LB_Creaate";
            this.LB_Creaate.Size = new System.Drawing.Size(53, 12);
            this.LB_Creaate.TabIndex = 103;
            this.LB_Creaate.Text = "新建节点";
            this.LB_Creaate.Click += new System.EventHandler(this.LB_Creaate_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(142, 194);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(124, 40);
            this.Btn_Submit.TabIndex = 102;
            this.Btn_Submit.Text = "提交";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // State
            // 
            this.State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.State.FormattingEnabled = true;
            this.State.Items.AddRange(new object[] {
            "楼房",
            "平房"});
            this.State.Location = new System.Drawing.Point(106, 128);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(78, 20);
            this.State.TabIndex = 100;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Location = new System.Drawing.Point(33, 132);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(65, 12);
            this.label86.TabIndex = 99;
            this.label86.Text = "状    态：";
            // 
            // PointName
            // 
            this.PointName.Location = new System.Drawing.Point(106, 35);
            this.PointName.Margin = new System.Windows.Forms.Padding(4);
            this.PointName.Name = "PointName";
            this.PointName.Size = new System.Drawing.Size(160, 21);
            this.PointName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 83);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "*节点排序：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*节点名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TV_Point);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(184, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(172, 446);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "节点列表";
            // 
            // TV_Point
            // 
            this.TV_Point.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Point.HideSelection = false;
            this.TV_Point.ItemHeight = 22;
            this.TV_Point.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TV_Point.Location = new System.Drawing.Point(4, 18);
            this.TV_Point.Margin = new System.Windows.Forms.Padding(4);
            this.TV_Point.Name = "TV_Point";
            this.TV_Point.Size = new System.Drawing.Size(164, 424);
            this.TV_Point.TabIndex = 11;
            this.TV_Point.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Point_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TV_Flow);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(172, 446);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "流程列表";
            // 
            // TV_Flow
            // 
            this.TV_Flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Flow.HideSelection = false;
            this.TV_Flow.ItemHeight = 22;
            this.TV_Flow.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TV_Flow.Location = new System.Drawing.Point(4, 18);
            this.TV_Flow.Margin = new System.Windows.Forms.Padding(4);
            this.TV_Flow.Name = "TV_Flow";
            this.TV_Flow.Size = new System.Drawing.Size(164, 424);
            this.TV_Flow.TabIndex = 11;
            this.TV_Flow.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Flow_AfterSelect);
            // 
            // Meter_WorkPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 454);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Meter_WorkPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "流程节点设置";
            this.Load += new System.EventHandler(this.Meter_WorkPoint_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView TV_Point;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView TV_Flow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LB_Creaate;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.ComboBox State;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox PointName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox PointSort;
    }
}
namespace WorkFlow
{
    partial class Meter_WorkDo
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TV_Do = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TV_Point = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TV_Flow = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FormName = new System.Windows.Forms.TextBox();
            this.FrmAssemblyName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IsCashier = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RTB_Charge = new System.Windows.Forms.RichTextBox();
            this.LB_Charge = new System.Windows.Forms.Label();
            this.loginId = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.DepartementID = new System.Windows.Forms.ComboBox();
            this.IsCharge = new System.Windows.Forms.CheckBox();
            this.IsViewCharge = new System.Windows.Forms.CheckBox();
            this.IsVoided = new System.Windows.Forms.CheckBox();
            this.LB_Skip = new System.Windows.Forms.Label();
            this.GoPointID = new System.Windows.Forms.ComboBox();
            this.IsSkip = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeLimit = new System.Windows.Forms.MaskedTextBox();
            this.LB_Creaate = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.State = new System.Windows.Forms.ComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.DoName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.YS = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 621);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TV_Do);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(374, 4);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(142, 613);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "项目列表";
            // 
            // TV_Do
            // 
            this.TV_Do.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Do.HideSelection = false;
            this.TV_Do.ItemHeight = 22;
            this.TV_Do.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TV_Do.Location = new System.Drawing.Point(4, 18);
            this.TV_Do.Margin = new System.Windows.Forms.Padding(4);
            this.TV_Do.Name = "TV_Do";
            this.TV_Do.Size = new System.Drawing.Size(134, 591);
            this.TV_Do.TabIndex = 11;
            this.TV_Do.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Do_AfterSelect);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TV_Point);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(224, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(142, 613);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "节点列表";
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
            this.TV_Point.Size = new System.Drawing.Size(134, 591);
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
            this.groupBox2.Size = new System.Drawing.Size(212, 613);
            this.groupBox2.TabIndex = 3;
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
            this.TV_Flow.Size = new System.Drawing.Size(204, 591);
            this.TV_Flow.TabIndex = 11;
            this.TV_Flow.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Flow_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.YS);
            this.groupBox1.Controls.Add(this.FormName);
            this.groupBox1.Controls.Add(this.FrmAssemblyName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.IsCashier);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.RTB_Charge);
            this.groupBox1.Controls.Add(this.LB_Charge);
            this.groupBox1.Controls.Add(this.loginId);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Controls.Add(this.DepartementID);
            this.groupBox1.Controls.Add(this.IsCharge);
            this.groupBox1.Controls.Add(this.IsViewCharge);
            this.groupBox1.Controls.Add(this.IsVoided);
            this.groupBox1.Controls.Add(this.LB_Skip);
            this.groupBox1.Controls.Add(this.GoPointID);
            this.groupBox1.Controls.Add(this.IsSkip);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TimeLimit);
            this.groupBox1.Controls.Add(this.LB_Creaate);
            this.groupBox1.Controls.Add(this.Btn_Submit);
            this.groupBox1.Controls.Add(this.State);
            this.groupBox1.Controls.Add(this.label86);
            this.groupBox1.Controls.Add(this.DoName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(523, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 615);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目详细信息";
            // 
            // FormName
            // 
            this.FormName.AcceptsReturn = true;
            this.FormName.Location = new System.Drawing.Point(89, 146);
            this.FormName.Margin = new System.Windows.Forms.Padding(4);
            this.FormName.Name = "FormName";
            this.FormName.Size = new System.Drawing.Size(160, 21);
            this.FormName.TabIndex = 7;
            // 
            // FrmAssemblyName
            // 
            this.FrmAssemblyName.AcceptsReturn = true;
            this.FrmAssemblyName.Location = new System.Drawing.Point(89, 144);
            this.FrmAssemblyName.Margin = new System.Windows.Forms.Padding(4);
            this.FrmAssemblyName.Name = "FrmAssemblyName";
            this.FrmAssemblyName.Size = new System.Drawing.Size(160, 21);
            this.FrmAssemblyName.TabIndex = 6;
            this.FrmAssemblyName.Text = "PersonalWork";
            this.FrmAssemblyName.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 151);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 129;
            this.label4.Text = "框架名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 128;
            this.label5.Text = "命名空间：";
            this.label5.Visible = false;
            // 
            // IsCashier
            // 
            this.IsCashier.AutoSize = true;
            this.IsCashier.Location = new System.Drawing.Point(24, 247);
            this.IsCashier.Name = "IsCashier";
            this.IsCashier.Size = new System.Drawing.Size(84, 16);
            this.IsCashier.TabIndex = 11;
            this.IsCashier.Text = "是否收费员";
            this.IsCashier.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 126;
            this.label6.Text = "天";
            // 
            // RTB_Charge
            // 
            this.RTB_Charge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Charge.Location = new System.Drawing.Point(94, 300);
            this.RTB_Charge.Name = "RTB_Charge";
            this.RTB_Charge.ReadOnly = true;
            this.RTB_Charge.Size = new System.Drawing.Size(248, 96);
            this.RTB_Charge.TabIndex = 99;
            this.RTB_Charge.Text = "";
            this.RTB_Charge.Visible = false;
            this.RTB_Charge.Click += new System.EventHandler(this.RTB_Charge_Click);
            // 
            // LB_Charge
            // 
            this.LB_Charge.AutoSize = true;
            this.LB_Charge.Location = new System.Drawing.Point(21, 303);
            this.LB_Charge.Name = "LB_Charge";
            this.LB_Charge.Size = new System.Drawing.Size(65, 12);
            this.LB_Charge.TabIndex = 124;
            this.LB_Charge.Text = "收费项目：";
            this.LB_Charge.Visible = false;
            // 
            // loginId
            // 
            this.loginId.Location = new System.Drawing.Point(312, 56);
            this.loginId.Name = "loginId";
            this.loginId.Size = new System.Drawing.Size(30, 21);
            this.loginId.TabIndex = 123;
            this.loginId.Visible = false;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(89, 95);
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Size = new System.Drawing.Size(248, 21);
            this.userName.TabIndex = 4;
            this.userName.Click += new System.EventHandler(this.userName_Click);
            // 
            // DepartementID
            // 
            this.DepartementID.FormattingEnabled = true;
            this.DepartementID.Location = new System.Drawing.Point(89, 72);
            this.DepartementID.Name = "DepartementID";
            this.DepartementID.Size = new System.Drawing.Size(173, 20);
            this.DepartementID.TabIndex = 3;
            // 
            // IsCharge
            // 
            this.IsCharge.AutoSize = true;
            this.IsCharge.Location = new System.Drawing.Point(24, 270);
            this.IsCharge.Name = "IsCharge";
            this.IsCharge.Size = new System.Drawing.Size(276, 16);
            this.IsCharge.TabIndex = 12;
            this.IsCharge.Text = "是否允许收费（如果允许，需要选择收费项目）";
            this.IsCharge.UseVisualStyleBackColor = true;
            this.IsCharge.CheckedChanged += new System.EventHandler(this.IsCharge_CheckedChanged);
            // 
            // IsViewCharge
            // 
            this.IsViewCharge.AutoSize = true;
            this.IsViewCharge.Location = new System.Drawing.Point(24, 224);
            this.IsViewCharge.Name = "IsViewCharge";
            this.IsViewCharge.Size = new System.Drawing.Size(120, 16);
            this.IsViewCharge.TabIndex = 10;
            this.IsViewCharge.Text = "能否查看收费明细";
            this.IsViewCharge.UseVisualStyleBackColor = true;
            this.IsViewCharge.CheckedChanged += new System.EventHandler(this.IsViewCharge_CheckedChanged);
            // 
            // IsVoided
            // 
            this.IsVoided.AutoSize = true;
            this.IsVoided.Location = new System.Drawing.Point(24, 201);
            this.IsVoided.Name = "IsVoided";
            this.IsVoided.Size = new System.Drawing.Size(192, 16);
            this.IsVoided.TabIndex = 9;
            this.IsVoided.Text = "能否作废（作废本次操作流程）";
            this.IsVoided.UseVisualStyleBackColor = true;
            this.IsVoided.CheckedChanged += new System.EventHandler(this.IsVoided_CheckedChanged);
            // 
            // LB_Skip
            // 
            this.LB_Skip.AutoSize = true;
            this.LB_Skip.Location = new System.Drawing.Point(153, 178);
            this.LB_Skip.Name = "LB_Skip";
            this.LB_Skip.Size = new System.Drawing.Size(53, 12);
            this.LB_Skip.TabIndex = 117;
            this.LB_Skip.Text = "跳回节点";
            this.LB_Skip.Visible = false;
            // 
            // GoPointID
            // 
            this.GoPointID.FormattingEnabled = true;
            this.GoPointID.Location = new System.Drawing.Point(212, 174);
            this.GoPointID.Name = "GoPointID";
            this.GoPointID.Size = new System.Drawing.Size(130, 20);
            this.GoPointID.TabIndex = 98;
            this.GoPointID.Visible = false;
            // 
            // IsSkip
            // 
            this.IsSkip.AutoSize = true;
            this.IsSkip.Location = new System.Drawing.Point(24, 178);
            this.IsSkip.Name = "IsSkip";
            this.IsSkip.Size = new System.Drawing.Size(96, 16);
            this.IsSkip.TabIndex = 8;
            this.IsSkip.Text = "是否允许跳转";
            this.IsSkip.UseVisualStyleBackColor = true;
            this.IsSkip.CheckedChanged += new System.EventHandler(this.IsSkip_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 114;
            this.label3.Text = "*审核人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 113;
            this.label2.Text = "*审核部门：";
            // 
            // TimeLimit
            // 
            this.TimeLimit.Location = new System.Drawing.Point(89, 48);
            this.TimeLimit.Mask = "90";
            this.TimeLimit.Name = "TimeLimit";
            this.TimeLimit.Size = new System.Drawing.Size(67, 21);
            this.TimeLimit.TabIndex = 2;
            // 
            // LB_Creaate
            // 
            this.LB_Creaate.AutoSize = true;
            this.LB_Creaate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LB_Creaate.Location = new System.Drawing.Point(33, 444);
            this.LB_Creaate.Name = "LB_Creaate";
            this.LB_Creaate.Size = new System.Drawing.Size(53, 12);
            this.LB_Creaate.TabIndex = 111;
            this.LB_Creaate.Text = "新建项目";
            this.LB_Creaate.Click += new System.EventHandler(this.LB_Creaate_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Enabled = false;
            this.Btn_Submit.Location = new System.Drawing.Point(130, 428);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(124, 40);
            this.Btn_Submit.TabIndex = 14;
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
            this.State.Location = new System.Drawing.Point(89, 121);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(78, 20);
            this.State.TabIndex = 5;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Location = new System.Drawing.Point(21, 126);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(65, 12);
            this.label86.TabIndex = 108;
            this.label86.Text = "状    态：";
            // 
            // DoName
            // 
            this.DoName.Location = new System.Drawing.Point(89, 24);
            this.DoName.Margin = new System.Windows.Forms.Padding(4);
            this.DoName.Name = "DoName";
            this.DoName.Size = new System.Drawing.Size(160, 21);
            this.DoName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 105;
            this.label7.Text = "*审核期限：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 106;
            this.label1.Text = "*项目名称：";
            // 
            // YS
            // 
            this.YS.AutoSize = true;
            this.YS.Location = new System.Drawing.Point(212, 247);
            this.YS.Name = "YS";
            this.YS.Size = new System.Drawing.Size(72, 16);
            this.YS.TabIndex = 130;
            this.YS.Text = "是否应收";
            this.YS.UseVisualStyleBackColor = true;
            // 
            // Meter_WorkDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 621);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Meter_WorkDo";
            this.Text = "审批项目";
            this.Load += new System.EventHandler(this.Meter_WorkDo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView TV_Flow;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView TV_Do;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView TV_Point;
        private System.Windows.Forms.MaskedTextBox TimeLimit;
        private System.Windows.Forms.Label LB_Creaate;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.ComboBox State;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox DoName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_Skip;
        private System.Windows.Forms.ComboBox GoPointID;
        private System.Windows.Forms.CheckBox IsSkip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox IsVoided;
        private System.Windows.Forms.CheckBox IsViewCharge;
        private System.Windows.Forms.CheckBox IsCharge;
        private System.Windows.Forms.TextBox loginId;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.ComboBox DepartementID;
        private System.Windows.Forms.Label LB_Charge;
        private System.Windows.Forms.RichTextBox RTB_Charge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox IsCashier;
        private System.Windows.Forms.TextBox FormName;
        private System.Windows.Forms.TextBox FrmAssemblyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox YS;

    }
}
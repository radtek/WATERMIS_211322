namespace WorkFlow
{
    partial class FrmWorkFlow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkFlow));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LB_Creaate = new System.Windows.Forms.Label();
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.State = new System.Windows.Forms.ComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.ParentID = new System.Windows.Forms.ComboBox();
            this.WorkCode = new System.Windows.Forms.TextBox();
            this.WorkName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TV_Flow = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FrmAssemblyName = new System.Windows.Forms.TextBox();
            this.FormName = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FormName);
            this.groupBox3.Controls.Add(this.FrmAssemblyName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.LB_Creaate);
            this.groupBox3.Controls.Add(this.Btn_Submit);
            this.groupBox3.Controls.Add(this.State);
            this.groupBox3.Controls.Add(this.label86);
            this.groupBox3.Controls.Add(this.ParentID);
            this.groupBox3.Controls.Add(this.WorkCode);
            this.groupBox3.Controls.Add(this.WorkName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(252, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(306, 457);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "详细信息";
            // 
            // LB_Creaate
            // 
            this.LB_Creaate.AutoSize = true;
            this.LB_Creaate.Location = new System.Drawing.Point(35, 322);
            this.LB_Creaate.Name = "LB_Creaate";
            this.LB_Creaate.Size = new System.Drawing.Size(63, 14);
            this.LB_Creaate.TabIndex = 103;
            this.LB_Creaate.Text = "新建流程";
            this.LB_Creaate.Click += new System.EventHandler(this.LB_Creaate_Click);
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(143, 306);
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
            this.State.Location = new System.Drawing.Point(106, 229);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(78, 22);
            this.State.TabIndex = 100;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Location = new System.Drawing.Point(27, 235);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(77, 14);
            this.label86.TabIndex = 99;
            this.label86.Text = "状    态：";
            // 
            // ParentID
            // 
            this.ParentID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParentID.FormattingEnabled = true;
            this.ParentID.Location = new System.Drawing.Point(106, 191);
            this.ParentID.Margin = new System.Windows.Forms.Padding(4);
            this.ParentID.Name = "ParentID";
            this.ParentID.Size = new System.Drawing.Size(160, 22);
            this.ParentID.TabIndex = 2;
            // 
            // WorkCode
            // 
            this.WorkCode.AcceptsReturn = true;
            this.WorkCode.Location = new System.Drawing.Point(106, 74);
            this.WorkCode.Margin = new System.Windows.Forms.Padding(4);
            this.WorkCode.Name = "WorkCode";
            this.WorkCode.Size = new System.Drawing.Size(160, 23);
            this.WorkCode.TabIndex = 1;
            // 
            // WorkName
            // 
            this.WorkName.Location = new System.Drawing.Point(106, 35);
            this.WorkName.Margin = new System.Windows.Forms.Padding(4);
            this.WorkName.Name = "WorkName";
            this.WorkName.Size = new System.Drawing.Size(160, 23);
            this.WorkName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "*流程编码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = " 所属上级：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "*流程名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TV_Flow);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(240, 457);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "流程列表";
            // 
            // TV_Flow
            // 
            this.TV_Flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Flow.HideSelection = false;
            this.TV_Flow.ImageIndex = 1;
            this.TV_Flow.ImageList = this.imageList1;
            this.TV_Flow.ItemHeight = 22;
            this.TV_Flow.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TV_Flow.Location = new System.Drawing.Point(4, 20);
            this.TV_Flow.Margin = new System.Windows.Forms.Padding(4);
            this.TV_Flow.Name = "TV_Flow";
            this.TV_Flow.SelectedImageIndex = 0;
            this.TV_Flow.Size = new System.Drawing.Size(232, 433);
            this.TV_Flow.TabIndex = 11;
            this.TV_Flow.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Flow_AfterSelect);
            this.TV_Flow.Click += new System.EventHandler(this.TV_Flow_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "dep.ico");
            this.imageList1.Images.SetKeyName(1, "dep_all.ico");
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.Transparent;
            this.tb1.ColumnCount = 2;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.groupBox3, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 1;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.54464F));
            this.tb1.Size = new System.Drawing.Size(562, 465);
            this.tb1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 104;
            this.label3.Text = "命名空间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 105;
            this.label4.Text = "框架名称：";
            // 
            // FrmAssemblyName
            // 
            this.FrmAssemblyName.AcceptsReturn = true;
            this.FrmAssemblyName.Location = new System.Drawing.Point(106, 113);
            this.FrmAssemblyName.Margin = new System.Windows.Forms.Padding(4);
            this.FrmAssemblyName.Name = "FrmAssemblyName";
            this.FrmAssemblyName.Size = new System.Drawing.Size(160, 23);
            this.FrmAssemblyName.TabIndex = 106;
            // 
            // FormName
            // 
            this.FormName.AcceptsReturn = true;
            this.FormName.Location = new System.Drawing.Point(106, 152);
            this.FormName.Margin = new System.Windows.Forms.Padding(4);
            this.FormName.Name = "FormName";
            this.FormName.Size = new System.Drawing.Size(160, 23);
            this.FormName.TabIndex = 107;
            // 
            // FrmWorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 465);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmWorkFlow";
            this.Text = "流程管理";
            this.Load += new System.EventHandler(this.FrmWorkFlow_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tb1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ParentID;
        private System.Windows.Forms.TextBox WorkCode;
        private System.Windows.Forms.TextBox WorkName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView TV_Flow;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.ComboBox State;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label LB_Creaate;
        private System.Windows.Forms.TextBox FormName;
        private System.Windows.Forms.TextBox FrmAssemblyName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;


    }
}
namespace SYSMANAGE
{
    partial class frmMessageReceiveSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageReceiveSearch));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSearch = new System.Windows.Forms.ToolStripButton();
            this.toolDel = new System.Windows.Forms.ToolStripButton();
            this.toolDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.MESSAGESENDID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MESSAGESENDTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MESSAGETITLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MESSAGECONTENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MESSAGECLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MESSAGEREADEDSIGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MESSAGERECEIVEID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTitleS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbIsRead = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.chkDateTime = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LimeGreen;
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSearch,
            this.toolDel,
            this.toolDeleteAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(960, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Tag = "9999";
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSearch
            // 
            this.toolSearch.Image = global::SYSMANAGE.Properties.Resources.onebit_02;
            this.toolSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSearch.Name = "toolSearch";
            this.toolSearch.Size = new System.Drawing.Size(55, 22);
            this.toolSearch.Text = "查询";
            this.toolSearch.Click += new System.EventHandler(this.toolSearch_Click);
            // 
            // toolDel
            // 
            this.toolDel.Image = global::SYSMANAGE.Properties.Resources.close;
            this.toolDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDel.Name = "toolDel";
            this.toolDel.Size = new System.Drawing.Size(55, 22);
            this.toolDel.Text = "删除";
            this.toolDel.Click += new System.EventHandler(this.toolDel_Click);
            // 
            // toolDeleteAll
            // 
            this.toolDeleteAll.Image = global::SYSMANAGE.Properties.Resources.close;
            this.toolDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDeleteAll.Name = "toolDeleteAll";
            this.toolDeleteAll.Size = new System.Drawing.Size(83, 22);
            this.toolDeleteAll.Text = "全部删除";
            this.toolDeleteAll.Click += new System.EventHandler(this.toolDeleteAll_Click);
            // 
            // tb1
            // 
            this.tb1.BackColor = System.Drawing.Color.Transparent;
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.groupBox2, 0, 2);
            this.tb1.Controls.Add(this.grpDetail, 0, 1);
            this.tb1.Controls.Add(this.groupBox3, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.97506F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tb1.Size = new System.Drawing.Size(960, 637);
            this.tb1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 277);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(952, 356);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "消息列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MESSAGESENDID,
            this.MESSAGESENDTIME,
            this.MESSAGETITLE,
            this.MESSAGECONTENT,
            this.MESSAGECLASS,
            this.MESSAGEREADEDSIGN,
            this.MESSAGERECEIVEID});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(4, 23);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 25;
            this.dgList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(944, 329);
            this.dgList.TabIndex = 0;
            this.dgList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgList_CellFormatting);
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellClick);
            // 
            // MESSAGESENDID
            // 
            this.MESSAGESENDID.DataPropertyName = "MESSAGESENDID";
            this.MESSAGESENDID.HeaderText = "MESSAGESENDID";
            this.MESSAGESENDID.Name = "MESSAGESENDID";
            this.MESSAGESENDID.ReadOnly = true;
            this.MESSAGESENDID.Visible = false;
            this.MESSAGESENDID.Width = 137;
            // 
            // MESSAGESENDTIME
            // 
            this.MESSAGESENDTIME.DataPropertyName = "MESSAGESENDTIME";
            this.MESSAGESENDTIME.HeaderText = "发布时间";
            this.MESSAGESENDTIME.Name = "MESSAGESENDTIME";
            this.MESSAGESENDTIME.ReadOnly = true;
            this.MESSAGESENDTIME.Width = 153;
            // 
            // MESSAGETITLE
            // 
            this.MESSAGETITLE.DataPropertyName = "MESSAGETITLE";
            this.MESSAGETITLE.HeaderText = "消息标题";
            this.MESSAGETITLE.Name = "MESSAGETITLE";
            this.MESSAGETITLE.ReadOnly = true;
            this.MESSAGETITLE.Width = 129;
            // 
            // MESSAGECONTENT
            // 
            this.MESSAGECONTENT.DataPropertyName = "MESSAGECONTENT";
            this.MESSAGECONTENT.HeaderText = "消息内容";
            this.MESSAGECONTENT.Name = "MESSAGECONTENT";
            this.MESSAGECONTENT.ReadOnly = true;
            this.MESSAGECONTENT.Width = 145;
            // 
            // MESSAGECLASS
            // 
            this.MESSAGECLASS.DataPropertyName = "MESSAGECLASS";
            this.MESSAGECLASS.HeaderText = "消息级别";
            this.MESSAGECLASS.Name = "MESSAGECLASS";
            this.MESSAGECLASS.ReadOnly = true;
            this.MESSAGECLASS.Width = 129;
            // 
            // MESSAGEREADEDSIGN
            // 
            this.MESSAGEREADEDSIGN.DataPropertyName = "MESSAGEREADEDSIGN";
            this.MESSAGEREADEDSIGN.HeaderText = "已读标志";
            this.MESSAGEREADEDSIGN.Name = "MESSAGEREADEDSIGN";
            this.MESSAGEREADEDSIGN.ReadOnly = true;
            // 
            // MESSAGERECEIVEID
            // 
            this.MESSAGERECEIVEID.DataPropertyName = "MESSAGERECEIVEID";
            this.MESSAGERECEIVEID.HeaderText = "MESSAGERECEIVEID";
            this.MESSAGERECEIVEID.Name = "MESSAGERECEIVEID";
            this.MESSAGERECEIVEID.ReadOnly = true;
            this.MESSAGERECEIVEID.Visible = false;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.tableLayoutPanel1);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetail.Location = new System.Drawing.Point(4, 64);
            this.grpDetail.Margin = new System.Windows.Forms.Padding(4);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Padding = new System.Windows.Forms.Padding(4);
            this.grpDetail.Size = new System.Drawing.Size(952, 205);
            this.grpDetail.TabIndex = 0;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "消息详情";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtContent, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 178);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.SystemColors.Window;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Location = new System.Drawing.Point(97, 36);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(844, 139);
            this.txtContent.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.SystemColors.Window;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(97, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(844, 26);
            this.txtTitle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "消息标题：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 145);
            this.label3.TabIndex = 2;
            this.label3.Text = "消息内容：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTitleS);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbIsRead);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpEnd);
            this.groupBox3.Controls.Add(this.dtpStart);
            this.groupBox3.Controls.Add(this.chkDateTime);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(954, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询条件";
            // 
            // txtTitleS
            // 
            this.txtTitleS.Location = new System.Drawing.Point(545, 20);
            this.txtTitleS.Name = "txtTitleS";
            this.txtTitleS.Size = new System.Drawing.Size(125, 26);
            this.txtTitleS.TabIndex = 132;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(499, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 131;
            this.label4.Text = "标题:";
            // 
            // cmbIsRead
            // 
            this.cmbIsRead.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsRead.FormattingEnabled = true;
            this.cmbIsRead.Items.AddRange(new object[] {
            "全部",
            "否",
            "是"});
            this.cmbIsRead.Location = new System.Drawing.Point(414, 22);
            this.cmbIsRead.Name = "cmbIsRead";
            this.cmbIsRead.Size = new System.Drawing.Size(68, 24);
            this.cmbIsRead.TabIndex = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 129;
            this.label1.Text = "已读:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(245, 20);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(105, 26);
            this.dtpEnd.TabIndex = 127;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(104, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 26);
            this.dtpStart.TabIndex = 126;
            // 
            // chkDateTime
            // 
            this.chkDateTime.AutoSize = true;
            this.chkDateTime.Checked = true;
            this.chkDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDateTime.Location = new System.Drawing.Point(9, 23);
            this.chkDateTime.Name = "chkDateTime";
            this.chkDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkDateTime.TabIndex = 125;
            this.chkDateTime.Text = "发布时间:";
            this.chkDateTime.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 128;
            this.label10.Text = "至";
            // 
            // frmMessageReceiveSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 662);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMessageReceiveSearch";
            this.Text = "消息信箱";
            this.Load += new System.EventHandler(this.frmMessageSendSearch_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSearch;
        private System.Windows.Forms.ToolStripButton toolDel;
        private System.Windows.Forms.ToolStripButton toolDeleteAll;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.CheckBox chkDateTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.ComboBox cmbIsRead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESSAGESENDID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESSAGESENDTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESSAGETITLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESSAGECONTENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESSAGECLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESSAGEREADEDSIGN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESSAGERECEIVEID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTitleS;

    }
}
namespace UPLOAD
{
    partial class frmUpload
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpload));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvDirectory = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.btPreview = new System.Windows.Forms.Button();
            this.btUpload = new System.Windows.Forms.Button();
            this.txtVersion2 = new System.Windows.Forms.TextBox();
            this.txtVersion1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.OPERATORTIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VERSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILEPATH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btDeleteAll = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSearch = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndPrint = new System.Windows.Forms.DateTimePicker();
            this.dtpStartPrint = new System.Windows.Forms.DateTimePicker();
            this.chkUpDateTime = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tvDirectory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btPreview);
            this.groupBox1.Controls.Add(this.btUpload);
            this.groupBox1.Controls.Add(this.txtVersion2);
            this.groupBox1.Controls.Add(this.txtVersion1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFileName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 389);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件选择";
            // 
            // tvDirectory
            // 
            this.tvDirectory.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvDirectory.ImageIndex = 0;
            this.tvDirectory.ImageList = this.imageList1;
            this.tvDirectory.Location = new System.Drawing.Point(90, 76);
            this.tvDirectory.Name = "tvDirectory";
            this.tvDirectory.SelectedImageIndex = 1;
            this.tvDirectory.Size = new System.Drawing.Size(201, 178);
            this.tvDirectory.TabIndex = 6;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "open.ico");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "更新至路径:";
            // 
            // btPreview
            // 
            this.btPreview.Location = new System.Drawing.Point(365, 16);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(50, 30);
            this.btPreview.TabIndex = 2;
            this.btPreview.Text = "浏览";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // btUpload
            // 
            this.btUpload.BackColor = System.Drawing.Color.LimeGreen;
            this.btUpload.Location = new System.Drawing.Point(152, 264);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(64, 30);
            this.btUpload.TabIndex = 2;
            this.btUpload.Text = "上传";
            this.btUpload.UseVisualStyleBackColor = false;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // txtVersion2
            // 
            this.txtVersion2.BackColor = System.Drawing.SystemColors.Window;
            this.txtVersion2.Location = new System.Drawing.Point(84, 47);
            this.txtVersion2.Name = "txtVersion2";
            this.txtVersion2.Size = new System.Drawing.Size(26, 23);
            this.txtVersion2.TabIndex = 1;
            this.txtVersion2.Text = "0";
            this.txtVersion2.Validating += new System.ComponentModel.CancelEventHandler(this.txtVersion_Validating);
            // 
            // txtVersion1
            // 
            this.txtVersion1.BackColor = System.Drawing.SystemColors.Window;
            this.txtVersion1.Location = new System.Drawing.Point(46, 47);
            this.txtVersion1.Name = "txtVersion1";
            this.txtVersion1.Size = new System.Drawing.Size(26, 23);
            this.txtVersion1.TabIndex = 1;
            this.txtVersion1.Text = "1";
            this.txtVersion1.Validating += new System.ComponentModel.CancelEventHandler(this.txtVersion_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(72, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "版本:";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFileName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFileName.Location = new System.Drawing.Point(46, 20);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(311, 21);
            this.txtFileName.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 424);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::UPLOAD.Properties.Resources.登录界面;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(593, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件上传";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::UPLOAD.Properties.Resources.登录界面;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(593, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "上传历史";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(587, 389);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgList.ColumnHeadersHeight = 25;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OPERATORTIME,
            this.FILENAME,
            this.VERSION,
            this.FILEPATH});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 100);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 35;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(581, 286);
            this.dgList.TabIndex = 403;
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            // 
            // OPERATORTIME
            // 
            this.OPERATORTIME.DataPropertyName = "OPERATORTIME";
            this.OPERATORTIME.HeaderText = "上传时间";
            this.OPERATORTIME.Name = "OPERATORTIME";
            this.OPERATORTIME.ReadOnly = true;
            this.OPERATORTIME.Width = 92;
            // 
            // FILENAME
            // 
            this.FILENAME.DataPropertyName = "FILENAME";
            this.FILENAME.HeaderText = "文件名称";
            this.FILENAME.Name = "FILENAME";
            this.FILENAME.ReadOnly = true;
            this.FILENAME.Width = 92;
            // 
            // VERSION
            // 
            this.VERSION.DataPropertyName = "VERSION";
            this.VERSION.HeaderText = "版本";
            this.VERSION.Name = "VERSION";
            this.VERSION.ReadOnly = true;
            this.VERSION.Width = 62;
            // 
            // FILEPATH
            // 
            this.FILEPATH.DataPropertyName = "FILEPATH";
            this.FILEPATH.HeaderText = "更新路径";
            this.FILEPATH.Name = "FILEPATH";
            this.FILEPATH.ReadOnly = true;
            this.FILEPATH.Width = 92;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFilter);
            this.groupBox2.Controls.Add(this.btDeleteAll);
            this.groupBox2.Controls.Add(this.btDelete);
            this.groupBox2.Controls.Add(this.btSearch);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpEndPrint);
            this.groupBox2.Controls.Add(this.dtpStartPrint);
            this.groupBox2.Controls.Add(this.chkUpDateTime);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 91);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // txtFilter
            // 
            this.txtFilter.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilter.Location = new System.Drawing.Point(444, 26);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(105, 26);
            this.txtFilter.TabIndex = 154;
            this.txtFilter.Visible = false;
            // 
            // btDeleteAll
            // 
            this.btDeleteAll.BackColor = System.Drawing.Color.LimeGreen;
            this.btDeleteAll.Enabled = false;
            this.btDeleteAll.Location = new System.Drawing.Point(444, 52);
            this.btDeleteAll.Name = "btDeleteAll";
            this.btDeleteAll.Size = new System.Drawing.Size(87, 30);
            this.btDeleteAll.TabIndex = 153;
            this.btDeleteAll.Text = "全部删除";
            this.btDeleteAll.UseVisualStyleBackColor = false;
            this.btDeleteAll.Click += new System.EventHandler(this.btDeleteAll_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.LimeGreen;
            this.btDelete.Enabled = false;
            this.btDelete.Location = new System.Drawing.Point(374, 52);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(64, 30);
            this.btDelete.TabIndex = 152;
            this.btDelete.Text = "删除";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSearch
            // 
            this.btSearch.BackColor = System.Drawing.Color.LimeGreen;
            this.btSearch.Location = new System.Drawing.Point(287, 52);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(64, 30);
            this.btSearch.TabIndex = 151;
            this.btSearch.Text = "查询";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Location = new System.Drawing.Point(110, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(105, 26);
            this.txtName.TabIndex = 150;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(33, 61);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(80, 16);
            this.label48.TabIndex = 149;
            this.label48.Text = "文件名称:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 148;
            this.label5.Text = "至";
            // 
            // dtpEndPrint
            // 
            this.dtpEndPrint.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.dtpEndPrint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndPrint.Location = new System.Drawing.Point(246, 22);
            this.dtpEndPrint.Name = "dtpEndPrint";
            this.dtpEndPrint.Size = new System.Drawing.Size(105, 26);
            this.dtpEndPrint.TabIndex = 147;
            // 
            // dtpStartPrint
            // 
            this.dtpStartPrint.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.dtpStartPrint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartPrint.Location = new System.Drawing.Point(110, 22);
            this.dtpStartPrint.Name = "dtpStartPrint";
            this.dtpStartPrint.Size = new System.Drawing.Size(105, 26);
            this.dtpStartPrint.TabIndex = 146;
            // 
            // chkUpDateTime
            // 
            this.chkUpDateTime.AutoSize = true;
            this.chkUpDateTime.Location = new System.Drawing.Point(17, 25);
            this.chkUpDateTime.Name = "chkUpDateTime";
            this.chkUpDateTime.Size = new System.Drawing.Size(99, 20);
            this.chkUpDateTime.TabIndex = 145;
            this.chkUpDateTime.Text = "上传时间:";
            this.chkUpDateTime.UseVisualStyleBackColor = true;
            // 
            // frmUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UPLOAD.Properties.Resources.登录界面;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(601, 424);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上传文件";
            this.Load += new System.EventHandler(this.frmUpload_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpload_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btUpload;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btPreview;
        private System.Windows.Forms.TextBox txtVersion1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVersion2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvDirectory;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPERATORTIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn VERSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILEPATH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEndPrint;
        private System.Windows.Forms.DateTimePicker dtpStartPrint;
        private System.Windows.Forms.CheckBox chkUpDateTime;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btDeleteAll;
        private System.Windows.Forms.TextBox txtFilter;
    }
}


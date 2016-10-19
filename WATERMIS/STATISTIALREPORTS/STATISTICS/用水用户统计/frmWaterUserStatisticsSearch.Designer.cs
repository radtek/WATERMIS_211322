namespace STATISTIALREPORTS
{
    partial class frmWaterUserStatisticsSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWaterUserStatisticsSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            FastReport.Design.DesignerSettings designerSettings1 = new FastReport.Design.DesignerSettings();
            FastReport.Design.DesignerRestrictions designerRestrictions1 = new FastReport.Design.DesignerRestrictions();
            FastReport.Export.Email.EmailSettings emailSettings1 = new FastReport.Export.Email.EmailSettings();
            FastReport.PreviewSettings previewSettings1 = new FastReport.PreviewSettings();
            FastReport.ReportSettings reportSettings1 = new FastReport.ReportSettings();
            this.toolStripWaterUser = new System.Windows.Forms.ToolStrip();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.toolPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolExcel = new System.Windows.Forms.ToolStripButton();
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.environmentSettings1 = new FastReport.EnvironmentSettings();
            this.waterUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTelphoneNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserPeopleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pianNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duanNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordernumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMUNITYNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meterReaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chargerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterUserCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterStateS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSizeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERMETERTYPECLASSNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERMETERLOCKNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsReverse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isSummaryMeterS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterParentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripWaterUser.SuspendLayout();
            this.tb1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripWaterUser
            // 
            this.toolStripWaterUser.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripWaterUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWaterUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolPrint,
            this.toolPrintPreview,
            this.toolExcel});
            this.toolStripWaterUser.Location = new System.Drawing.Point(0, 0);
            this.toolStripWaterUser.Name = "toolStripWaterUser";
            this.toolStripWaterUser.Size = new System.Drawing.Size(1008, 25);
            this.toolStripWaterUser.TabIndex = 57;
            this.toolStripWaterUser.Text = "toolStrip2";
            // 
            // toolPrint
            // 
            this.toolPrint.Enabled = false;
            this.toolPrint.Image = global::STATISTIALREPORTS.Properties.Resources.打印;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(57, 22);
            this.toolPrint.Text = "打印";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // toolPrintPreview
            // 
            this.toolPrintPreview.Enabled = false;
            this.toolPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("toolPrintPreview.Image")));
            this.toolPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrintPreview.Name = "toolPrintPreview";
            this.toolPrintPreview.Size = new System.Drawing.Size(87, 22);
            this.toolPrintPreview.Text = "打印预览";
            this.toolPrintPreview.Click += new System.EventHandler(this.toolPrintPreview_Click);
            // 
            // toolExcel
            // 
            this.toolExcel.Enabled = false;
            this.toolExcel.Image = global::STATISTIALREPORTS.Properties.Resources.snap_undo;
            this.toolExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExcel.Name = "toolExcel";
            this.toolExcel.Size = new System.Drawing.Size(97, 22);
            this.toolExcel.Text = "导出Excel";
            this.toolExcel.Click += new System.EventHandler(this.toolExcel_Click);
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Controls.Add(this.groupBox2, 0, 0);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 25);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 1;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb1.Size = new System.Drawing.Size(1008, 537);
            this.tb1.TabIndex = 58;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1002, 531);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户列表";
            // 
            // dgList
            // 
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToOrderColumns = true;
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
            this.waterUserId,
            this.waterUserNO,
            this.waterUserName,
            this.waterUserAddress,
            this.waterUserTelphoneNO,
            this.waterPhone,
            this.waterUserPeopleCount,
            this.pianNO,
            this.areaNO,
            this.duanNO,
            this.ordernumber,
            this.COMMUNITYNAME,
            this.meterReaderName,
            this.chargerName,
            this.waterUserTypeId,
            this.waterUserTypeName,
            this.waterUserCreateDate,
            this.waterMeterPositionName,
            this.waterMeterStateS,
            this.waterMeterSizeValue,
            this.WATERMETERTYPECLASSNAME,
            this.waterMeterTypeValue,
            this.waterMeterSerialNumber,
            this.waterMeterMode,
            this.WATERMETERLOCKNO,
            this.IsReverse,
            this.isSummaryMeterS,
            this.waterMeterParentId,
            this.waterMeterParentName});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(3, 22);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowHeadersWidth = 45;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgList.Size = new System.Drawing.Size(996, 506);
            this.dgList.TabIndex = 901;
            this.dgList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgList_CellPainting);
            this.dgList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgList_DataBindingComplete);
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
            // waterUserId
            // 
            this.waterUserId.DataPropertyName = "waterUserId";
            this.waterUserId.HeaderText = "waterUserId";
            this.waterUserId.Name = "waterUserId";
            this.waterUserId.ReadOnly = true;
            this.waterUserId.Visible = false;
            this.waterUserId.Width = 121;
            // 
            // waterUserNO
            // 
            this.waterUserNO.DataPropertyName = "waterUserNO";
            this.waterUserNO.HeaderText = "用户号";
            this.waterUserNO.Name = "waterUserNO";
            this.waterUserNO.ReadOnly = true;
            this.waterUserNO.Width = 81;
            // 
            // waterUserName
            // 
            this.waterUserName.DataPropertyName = "waterUserName";
            this.waterUserName.HeaderText = "用户名称";
            this.waterUserName.Name = "waterUserName";
            this.waterUserName.ReadOnly = true;
            // 
            // waterUserAddress
            // 
            this.waterUserAddress.DataPropertyName = "waterUserAddress";
            this.waterUserAddress.HeaderText = "地址";
            this.waterUserAddress.Name = "waterUserAddress";
            this.waterUserAddress.ReadOnly = true;
            this.waterUserAddress.Width = 200;
            // 
            // waterUserTelphoneNO
            // 
            this.waterUserTelphoneNO.DataPropertyName = "waterUserTelphoneNO";
            this.waterUserTelphoneNO.HeaderText = "手机号";
            this.waterUserTelphoneNO.Name = "waterUserTelphoneNO";
            this.waterUserTelphoneNO.ReadOnly = true;
            // 
            // waterPhone
            // 
            this.waterPhone.DataPropertyName = "waterPhone";
            this.waterPhone.HeaderText = "固定电话";
            this.waterPhone.Name = "waterPhone";
            this.waterPhone.ReadOnly = true;
            this.waterPhone.Width = 120;
            // 
            // waterUserPeopleCount
            // 
            this.waterUserPeopleCount.DataPropertyName = "waterUserPeopleCount";
            this.waterUserPeopleCount.HeaderText = "人口数";
            this.waterUserPeopleCount.Name = "waterUserPeopleCount";
            this.waterUserPeopleCount.ReadOnly = true;
            this.waterUserPeopleCount.Width = 81;
            // 
            // pianNO
            // 
            this.pianNO.DataPropertyName = "pianNO";
            this.pianNO.HeaderText = "片号";
            this.pianNO.Name = "pianNO";
            this.pianNO.ReadOnly = true;
            // 
            // areaNO
            // 
            this.areaNO.DataPropertyName = "areaNO";
            this.areaNO.HeaderText = "区号";
            this.areaNO.Name = "areaNO";
            this.areaNO.ReadOnly = true;
            this.areaNO.Width = 81;
            // 
            // duanNO
            // 
            this.duanNO.DataPropertyName = "duanNO";
            this.duanNO.HeaderText = "段号";
            this.duanNO.Name = "duanNO";
            this.duanNO.ReadOnly = true;
            // 
            // ordernumber
            // 
            this.ordernumber.DataPropertyName = "ordernumber";
            this.ordernumber.HeaderText = "顺序号";
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.ReadOnly = true;
            this.ordernumber.Width = 81;
            // 
            // COMMUNITYNAME
            // 
            this.COMMUNITYNAME.DataPropertyName = "COMMUNITYNAME";
            this.COMMUNITYNAME.HeaderText = "小区名称";
            this.COMMUNITYNAME.Name = "COMMUNITYNAME";
            this.COMMUNITYNAME.ReadOnly = true;
            // 
            // meterReaderName
            // 
            this.meterReaderName.DataPropertyName = "meterReaderName";
            this.meterReaderName.HeaderText = "抄表员";
            this.meterReaderName.Name = "meterReaderName";
            this.meterReaderName.ReadOnly = true;
            this.meterReaderName.Width = 81;
            // 
            // chargerName
            // 
            this.chargerName.DataPropertyName = "chargerName";
            this.chargerName.HeaderText = "收费员";
            this.chargerName.Name = "chargerName";
            this.chargerName.ReadOnly = true;
            // 
            // waterUserTypeId
            // 
            this.waterUserTypeId.DataPropertyName = "waterUserTypeId";
            this.waterUserTypeId.HeaderText = "waterUserTypeId";
            this.waterUserTypeId.Name = "waterUserTypeId";
            this.waterUserTypeId.ReadOnly = true;
            this.waterUserTypeId.Visible = false;
            this.waterUserTypeId.Width = 153;
            // 
            // waterUserTypeName
            // 
            this.waterUserTypeName.DataPropertyName = "waterUserTypeName";
            this.waterUserTypeName.HeaderText = "用户类别";
            this.waterUserTypeName.Name = "waterUserTypeName";
            this.waterUserTypeName.ReadOnly = true;
            this.waterUserTypeName.Width = 97;
            // 
            // waterUserCreateDate
            // 
            this.waterUserCreateDate.DataPropertyName = "waterUserCreateDate";
            this.waterUserCreateDate.HeaderText = "建档日期";
            this.waterUserCreateDate.Name = "waterUserCreateDate";
            this.waterUserCreateDate.ReadOnly = true;
            this.waterUserCreateDate.Width = 97;
            // 
            // waterMeterPositionName
            // 
            this.waterMeterPositionName.DataPropertyName = "waterMeterPositionName";
            this.waterMeterPositionName.HeaderText = "水表位置";
            this.waterMeterPositionName.Name = "waterMeterPositionName";
            this.waterMeterPositionName.ReadOnly = true;
            // 
            // waterMeterStateS
            // 
            this.waterMeterStateS.DataPropertyName = "waterMeterStateS";
            this.waterMeterStateS.HeaderText = "水表状态";
            this.waterMeterStateS.Name = "waterMeterStateS";
            this.waterMeterStateS.ReadOnly = true;
            // 
            // waterMeterSizeValue
            // 
            this.waterMeterSizeValue.DataPropertyName = "waterMeterSizeValue";
            this.waterMeterSizeValue.HeaderText = "水表口径";
            this.waterMeterSizeValue.Name = "waterMeterSizeValue";
            this.waterMeterSizeValue.ReadOnly = true;
            // 
            // WATERMETERTYPECLASSNAME
            // 
            this.WATERMETERTYPECLASSNAME.DataPropertyName = "WATERMETERTYPECLASSNAME";
            this.WATERMETERTYPECLASSNAME.HeaderText = "用水分类";
            this.WATERMETERTYPECLASSNAME.Name = "WATERMETERTYPECLASSNAME";
            this.WATERMETERTYPECLASSNAME.ReadOnly = true;
            // 
            // waterMeterTypeValue
            // 
            this.waterMeterTypeValue.DataPropertyName = "waterMeterTypeValue";
            this.waterMeterTypeValue.HeaderText = "用水性质";
            this.waterMeterTypeValue.Name = "waterMeterTypeValue";
            this.waterMeterTypeValue.ReadOnly = true;
            // 
            // waterMeterSerialNumber
            // 
            this.waterMeterSerialNumber.DataPropertyName = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.HeaderText = "出厂编号";
            this.waterMeterSerialNumber.Name = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.ReadOnly = true;
            // 
            // waterMeterMode
            // 
            this.waterMeterMode.DataPropertyName = "waterMeterMode";
            this.waterMeterMode.HeaderText = "铅封号";
            this.waterMeterMode.Name = "waterMeterMode";
            this.waterMeterMode.ReadOnly = true;
            // 
            // WATERMETERLOCKNO
            // 
            this.WATERMETERLOCKNO.DataPropertyName = "WATERMETERLOCKNO";
            this.WATERMETERLOCKNO.HeaderText = "表锁号";
            this.WATERMETERLOCKNO.Name = "WATERMETERLOCKNO";
            this.WATERMETERLOCKNO.ReadOnly = true;
            // 
            // IsReverse
            // 
            this.IsReverse.DataPropertyName = "IsReverse";
            this.IsReverse.HeaderText = "倒表";
            this.IsReverse.Name = "IsReverse";
            this.IsReverse.ReadOnly = true;
            // 
            // isSummaryMeterS
            // 
            this.isSummaryMeterS.DataPropertyName = "isSummaryMeterS";
            this.isSummaryMeterS.HeaderText = "总分表";
            this.isSummaryMeterS.Name = "isSummaryMeterS";
            this.isSummaryMeterS.ReadOnly = true;
            // 
            // waterMeterParentId
            // 
            this.waterMeterParentId.DataPropertyName = "waterMeterParentId";
            this.waterMeterParentId.HeaderText = "总表编号";
            this.waterMeterParentId.Name = "waterMeterParentId";
            this.waterMeterParentId.ReadOnly = true;
            // 
            // waterMeterParentName
            // 
            this.waterMeterParentName.DataPropertyName = "waterMeterParentName";
            this.waterMeterParentName.HeaderText = "所属总表";
            this.waterMeterParentName.Name = "waterMeterParentName";
            this.waterMeterParentName.ReadOnly = true;
            this.waterMeterParentName.Width = 200;
            // 
            // frmWaterUserStatisticsSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.toolStripWaterUser);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmWaterUserStatisticsSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户及水表明细查询";
            this.Load += new System.EventHandler(this.frmWaterUserSearch_Load);
            this.toolStripWaterUser.ResumeLayout(false);
            this.toolStripWaterUser.PerformLayout();
            this.tb1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripWaterUser;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.ToolStripButton toolPrintPreview;
        private FastReport.EnvironmentSettings environmentSettings1;
        private System.Windows.Forms.ToolStripButton toolExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTelphoneNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserPeopleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn pianNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn duanNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordernumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMUNITYNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn meterReaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterUserCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterStateS;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSizeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERMETERTYPECLASSNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERMETERLOCKNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsReverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn isSummaryMeterS;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterParentName;
    }
}
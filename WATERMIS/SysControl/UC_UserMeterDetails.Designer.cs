namespace SysControl
{
    partial class UC_UserMeterDetails
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgWaterMeter = new System.Windows.Forms.DataGridView();
            this.waterMeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterPositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSizeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterStateS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterTypeValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterStartNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waterMeterSerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WATERFIXVALUE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoWaterMeter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uC_UserDetails1 = new SysControl.UC_UserDetails();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterMeter)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uC_UserDetails1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(528, 400);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgWaterMeter);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 253);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(522, 144);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "水表列表";
            // 
            // dgWaterMeter
            // 
            this.dgWaterMeter.AllowUserToAddRows = false;
            this.dgWaterMeter.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgWaterMeter.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWaterMeter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgWaterMeter.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWaterMeter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgWaterMeter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWaterMeter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.waterMeterNo,
            this.waterMeterPositionName,
            this.waterMeterSizeValue,
            this.waterMeterStateS,
            this.waterMeterTypeValue,
            this.waterMeterStartNumber,
            this.waterMeterSerialNumber,
            this.WATERFIXVALUE,
            this.memoWaterMeter});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgWaterMeter.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgWaterMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWaterMeter.Location = new System.Drawing.Point(3, 17);
            this.dgWaterMeter.MultiSelect = false;
            this.dgWaterMeter.Name = "dgWaterMeter";
            this.dgWaterMeter.ReadOnly = true;
            this.dgWaterMeter.RowHeadersWidth = 25;
            this.dgWaterMeter.RowTemplate.Height = 23;
            this.dgWaterMeter.Size = new System.Drawing.Size(516, 124);
            this.dgWaterMeter.TabIndex = 1;
            // 
            // waterMeterNo
            // 
            this.waterMeterNo.DataPropertyName = "waterMeterNo";
            this.waterMeterNo.HeaderText = "水表编号";
            this.waterMeterNo.Name = "waterMeterNo";
            this.waterMeterNo.ReadOnly = true;
            this.waterMeterNo.Width = 88;
            // 
            // waterMeterPositionName
            // 
            this.waterMeterPositionName.DataPropertyName = "waterMeterPositionName";
            this.waterMeterPositionName.HeaderText = "水表位置";
            this.waterMeterPositionName.Name = "waterMeterPositionName";
            this.waterMeterPositionName.ReadOnly = true;
            this.waterMeterPositionName.Width = 88;
            // 
            // waterMeterSizeValue
            // 
            this.waterMeterSizeValue.DataPropertyName = "waterMeterSizeValue";
            this.waterMeterSizeValue.HeaderText = "口径";
            this.waterMeterSizeValue.Name = "waterMeterSizeValue";
            this.waterMeterSizeValue.ReadOnly = true;
            this.waterMeterSizeValue.Width = 60;
            // 
            // waterMeterStateS
            // 
            this.waterMeterStateS.DataPropertyName = "waterMeterStateS";
            this.waterMeterStateS.HeaderText = "水表状态";
            this.waterMeterStateS.Name = "waterMeterStateS";
            this.waterMeterStateS.ReadOnly = true;
            this.waterMeterStateS.Width = 88;
            // 
            // waterMeterTypeValue
            // 
            this.waterMeterTypeValue.DataPropertyName = "waterMeterTypeValue";
            this.waterMeterTypeValue.HeaderText = "用水类别";
            this.waterMeterTypeValue.Name = "waterMeterTypeValue";
            this.waterMeterTypeValue.ReadOnly = true;
            this.waterMeterTypeValue.Width = 88;
            // 
            // waterMeterStartNumber
            // 
            this.waterMeterStartNumber.DataPropertyName = "waterMeterStartNumber";
            this.waterMeterStartNumber.HeaderText = "初始读数";
            this.waterMeterStartNumber.Name = "waterMeterStartNumber";
            this.waterMeterStartNumber.ReadOnly = true;
            this.waterMeterStartNumber.Width = 88;
            // 
            // waterMeterSerialNumber
            // 
            this.waterMeterSerialNumber.DataPropertyName = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.HeaderText = "出厂编号";
            this.waterMeterSerialNumber.Name = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.ReadOnly = true;
            this.waterMeterSerialNumber.Width = 88;
            // 
            // WATERFIXVALUE
            // 
            this.WATERFIXVALUE.DataPropertyName = "WATERFIXVALUE";
            this.WATERFIXVALUE.HeaderText = "定量用水";
            this.WATERFIXVALUE.Name = "WATERFIXVALUE";
            this.WATERFIXVALUE.ReadOnly = true;
            this.WATERFIXVALUE.Width = 88;
            // 
            // memoWaterMeter
            // 
            this.memoWaterMeter.DataPropertyName = "memo";
            this.memoWaterMeter.HeaderText = "备注";
            this.memoWaterMeter.Name = "memoWaterMeter";
            this.memoWaterMeter.ReadOnly = true;
            this.memoWaterMeter.Width = 60;
            // 
            // uC_UserDetails1
            // 
            this.uC_UserDetails1.Location = new System.Drawing.Point(3, 3);
            this.uC_UserDetails1.Name = "uC_UserDetails1";
            this.uC_UserDetails1.Size = new System.Drawing.Size(522, 244);
            this.uC_UserDetails1.TabIndex = 5;
            // 
            // UC_UserMeterDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "UC_UserMeterDetails";
            this.Size = new System.Drawing.Size(528, 400);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWaterMeter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgWaterMeter;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterPositionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSizeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterStateS;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterTypeValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterStartNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn waterMeterSerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn WATERFIXVALUE;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoWaterMeter;
        public UC_UserDetails uC_UserDetails1;

    }
}

namespace SysControl
{
    partial class UC_SearchCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_SearchCharge));
            this.Btn_Search = new System.Windows.Forms.Button();
            this.CB_MONTHCHECKSTATE = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CB_DAYCHECKSTATE = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_CHARGEID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DT_waterMeterProofreadingDate_2 = new System.Windows.Forms.DateTimePicker();
            this.DT_waterMeterProofreadingDate_1 = new System.Windows.Forms.DateTimePicker();
            this.CHK_waterMeterProofreadingDate = new System.Windows.Forms.CheckBox();
            this.CB_CHARGEWORKERID = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_waterUserName = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.TB_waterUserNO = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.CB_CHARGETYPEID = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(763, 7);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 50);
            this.Btn_Search.TabIndex = 154;
            this.Btn_Search.Text = "查  询";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // CB_MONTHCHECKSTATE
            // 
            this.CB_MONTHCHECKSTATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_MONTHCHECKSTATE.FormattingEnabled = true;
            this.CB_MONTHCHECKSTATE.Items.AddRange(new object[] {
            "",
            "是",
            "否"});
            this.CB_MONTHCHECKSTATE.Location = new System.Drawing.Point(510, 36);
            this.CB_MONTHCHECKSTATE.Name = "CB_MONTHCHECKSTATE";
            this.CB_MONTHCHECKSTATE.Size = new System.Drawing.Size(47, 20);
            this.CB_MONTHCHECKSTATE.TabIndex = 152;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(459, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 153;
            this.label10.Text = "月结账:";
            // 
            // CB_DAYCHECKSTATE
            // 
            this.CB_DAYCHECKSTATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_DAYCHECKSTATE.FormattingEnabled = true;
            this.CB_DAYCHECKSTATE.Items.AddRange(new object[] {
            "",
            "是",
            "否"});
            this.CB_DAYCHECKSTATE.Location = new System.Drawing.Point(406, 36);
            this.CB_DAYCHECKSTATE.Name = "CB_DAYCHECKSTATE";
            this.CB_DAYCHECKSTATE.Size = new System.Drawing.Size(47, 20);
            this.CB_DAYCHECKSTATE.TabIndex = 150;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(353, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 151;
            this.label9.Text = "日结账:";
            // 
            // TB_CHARGEID
            // 
            this.TB_CHARGEID.BackColor = System.Drawing.SystemColors.Window;
            this.TB_CHARGEID.Location = new System.Drawing.Point(631, 36);
            this.TB_CHARGEID.Name = "TB_CHARGEID";
            this.TB_CHARGEID.Size = new System.Drawing.Size(122, 21);
            this.TB_CHARGEID.TabIndex = 148;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(566, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 149;
            this.label4.Text = "收费单号:";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(210, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 147;
            this.label8.Text = "至";
            // 
            // DT_waterMeterProofreadingDate_2
            // 
            this.DT_waterMeterProofreadingDate_2.CustomFormat = "yyyy-MM-dd 23:59:59";
            this.DT_waterMeterProofreadingDate_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_2.Location = new System.Drawing.Point(257, 36);
            this.DT_waterMeterProofreadingDate_2.Name = "DT_waterMeterProofreadingDate_2";
            this.DT_waterMeterProofreadingDate_2.Size = new System.Drawing.Size(88, 21);
            this.DT_waterMeterProofreadingDate_2.TabIndex = 146;
            this.DT_waterMeterProofreadingDate_2.ValueChanged += new System.EventHandler(this.DT_waterMeterProofreadingDate_2_ValueChanged);
            // 
            // DT_waterMeterProofreadingDate_1
            // 
            this.DT_waterMeterProofreadingDate_1.CustomFormat = "yyyy-MM-dd 00:00:00";
            this.DT_waterMeterProofreadingDate_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_1.Location = new System.Drawing.Point(99, 36);
            this.DT_waterMeterProofreadingDate_1.Name = "DT_waterMeterProofreadingDate_1";
            this.DT_waterMeterProofreadingDate_1.Size = new System.Drawing.Size(89, 21);
            this.DT_waterMeterProofreadingDate_1.TabIndex = 145;
            // 
            // CHK_waterMeterProofreadingDate
            // 
            this.CHK_waterMeterProofreadingDate.BackColor = System.Drawing.Color.White;
            this.CHK_waterMeterProofreadingDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CHK_waterMeterProofreadingDate.BackgroundImage")));
            this.CHK_waterMeterProofreadingDate.Checked = true;
            this.CHK_waterMeterProofreadingDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_waterMeterProofreadingDate.Location = new System.Drawing.Point(15, 39);
            this.CHK_waterMeterProofreadingDate.Name = "CHK_waterMeterProofreadingDate";
            this.CHK_waterMeterProofreadingDate.Size = new System.Drawing.Size(78, 16);
            this.CHK_waterMeterProofreadingDate.TabIndex = 144;
            this.CHK_waterMeterProofreadingDate.Tag = "9999";
            this.CHK_waterMeterProofreadingDate.Text = "收费时间:";
            this.CHK_waterMeterProofreadingDate.UseVisualStyleBackColor = false;
            // 
            // CB_CHARGEWORKERID
            // 
            this.CB_CHARGEWORKERID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_CHARGEWORKERID.FormattingEnabled = true;
            this.CB_CHARGEWORKERID.Location = new System.Drawing.Point(406, 7);
            this.CB_CHARGEWORKERID.Name = "CB_CHARGEWORKERID";
            this.CB_CHARGEWORKERID.Size = new System.Drawing.Size(151, 20);
            this.CB_CHARGEWORKERID.TabIndex = 142;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(353, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 143;
            this.label7.Text = "收费员:";
            // 
            // TB_waterUserName
            // 
            this.TB_waterUserName.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterUserName.Location = new System.Drawing.Point(257, 7);
            this.TB_waterUserName.Name = "TB_waterUserName";
            this.TB_waterUserName.Size = new System.Drawing.Size(88, 21);
            this.TB_waterUserName.TabIndex = 137;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Location = new System.Drawing.Point(193, 12);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(59, 12);
            this.label41.TabIndex = 136;
            this.label41.Text = "用户名称:";
            // 
            // TB_waterUserNO
            // 
            this.TB_waterUserNO.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterUserNO.Location = new System.Drawing.Point(99, 7);
            this.TB_waterUserNO.Name = "TB_waterUserNO";
            this.TB_waterUserNO.Size = new System.Drawing.Size(89, 21);
            this.TB_waterUserNO.TabIndex = 132;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(34, 12);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(59, 12);
            this.label40.TabIndex = 135;
            this.label40.Text = "用户编号:";
            // 
            // CB_CHARGETYPEID
            // 
            this.CB_CHARGETYPEID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_CHARGETYPEID.FormattingEnabled = true;
            this.CB_CHARGETYPEID.Location = new System.Drawing.Point(631, 7);
            this.CB_CHARGETYPEID.Name = "CB_CHARGETYPEID";
            this.CB_CHARGETYPEID.Size = new System.Drawing.Size(122, 20);
            this.CB_CHARGETYPEID.TabIndex = 133;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Location = new System.Drawing.Point(566, 12);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(59, 12);
            this.label38.TabIndex = 134;
            this.label38.Text = "收款方式:";
            // 
            // UC_SearchCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.CB_MONTHCHECKSTATE);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CB_DAYCHECKSTATE);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TB_CHARGEID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DT_waterMeterProofreadingDate_2);
            this.Controls.Add(this.DT_waterMeterProofreadingDate_1);
            this.Controls.Add(this.CHK_waterMeterProofreadingDate);
            this.Controls.Add(this.CB_CHARGEWORKERID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TB_waterUserName);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.TB_waterUserNO);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.CB_CHARGETYPEID);
            this.Controls.Add(this.label38);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_SearchCharge";
            this.Size = new System.Drawing.Size(848, 65);
            this.Tag = "9999";
            this.Load += new System.EventHandler(this.UC_SearchCharge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.ComboBox CB_MONTHCHECKSTATE;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CB_DAYCHECKSTATE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TB_CHARGEID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_2;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_1;
        private System.Windows.Forms.CheckBox CHK_waterMeterProofreadingDate;
        private System.Windows.Forms.ComboBox CB_CHARGEWORKERID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TB_waterUserName;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox TB_waterUserNO;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox CB_CHARGETYPEID;
        private System.Windows.Forms.Label label38;
    }
}

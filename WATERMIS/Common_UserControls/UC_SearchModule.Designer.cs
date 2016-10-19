namespace Common_UserControls
{
    partial class UC_SearchModule
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
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.TB_waterPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_waterUserAddress = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.TB_waterUserName = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.TB_AcceptID = new System.Windows.Forms.TextBox();
            this.CB_loginId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DT_waterMeterProofreadingDate_2 = new System.Windows.Forms.DateTimePicker();
            this.DT_waterMeterProofreadingDate_1 = new System.Windows.Forms.DateTimePicker();
            this.CHK_waterMeterProofreadingDate = new System.Windows.Forms.CheckBox();
            this.CB_State = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 174;
            this.label4.Text = "受理编号：";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(825, 7);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(75, 54);
            this.Btn_Search.TabIndex = 173;
            this.Btn_Search.Text = "查询";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // TB_waterPhone
            // 
            this.TB_waterPhone.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterPhone.Location = new System.Drawing.Point(91, 37);
            this.TB_waterPhone.Name = "TB_waterPhone";
            this.TB_waterPhone.Size = new System.Drawing.Size(87, 21);
            this.TB_waterPhone.TabIndex = 172;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 171;
            this.label1.Text = "联系电话：";
            // 
            // TB_waterUserAddress
            // 
            this.TB_waterUserAddress.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterUserAddress.Location = new System.Drawing.Point(272, 37);
            this.TB_waterUserAddress.Name = "TB_waterUserAddress";
            this.TB_waterUserAddress.Size = new System.Drawing.Size(159, 21);
            this.TB_waterUserAddress.TabIndex = 170;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(192, 43);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(65, 12);
            this.label89.TabIndex = 169;
            this.label89.Text = "用户地址：";
            // 
            // TB_waterUserName
            // 
            this.TB_waterUserName.BackColor = System.Drawing.SystemColors.Window;
            this.TB_waterUserName.Location = new System.Drawing.Point(653, 7);
            this.TB_waterUserName.Name = "TB_waterUserName";
            this.TB_waterUserName.Size = new System.Drawing.Size(159, 21);
            this.TB_waterUserName.TabIndex = 168;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(577, 12);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(65, 12);
            this.label91.TabIndex = 167;
            this.label91.Text = "用户名称：";
            // 
            // TB_AcceptID
            // 
            this.TB_AcceptID.BackColor = System.Drawing.SystemColors.Window;
            this.TB_AcceptID.Location = new System.Drawing.Point(457, 7);
            this.TB_AcceptID.Name = "TB_AcceptID";
            this.TB_AcceptID.Size = new System.Drawing.Size(102, 21);
            this.TB_AcceptID.TabIndex = 166;
            // 
            // CB_loginId
            // 
            this.CB_loginId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_loginId.FormattingEnabled = true;
            this.CB_loginId.Items.AddRange(new object[] {
            "全部",
            "正常",
            "作废"});
            this.CB_loginId.Location = new System.Drawing.Point(506, 41);
            this.CB_loginId.Name = "CB_loginId";
            this.CB_loginId.Size = new System.Drawing.Size(120, 20);
            this.CB_loginId.TabIndex = 165;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 164;
            this.label3.Text = "受理人：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 163;
            this.label2.Text = "至";
            // 
            // DT_waterMeterProofreadingDate_2
            // 
            this.DT_waterMeterProofreadingDate_2.CustomFormat = "yyyy-MM-dd";
            this.DT_waterMeterProofreadingDate_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_2.Location = new System.Drawing.Point(238, 7);
            this.DT_waterMeterProofreadingDate_2.Name = "DT_waterMeterProofreadingDate_2";
            this.DT_waterMeterProofreadingDate_2.Size = new System.Drawing.Size(105, 21);
            this.DT_waterMeterProofreadingDate_2.TabIndex = 162;
            this.DT_waterMeterProofreadingDate_2.ValueChanged += new System.EventHandler(this.DT_waterMeterProofreadingDate_2_ValueChanged);
            // 
            // DT_waterMeterProofreadingDate_1
            // 
            this.DT_waterMeterProofreadingDate_1.CustomFormat = "yyyy-MM-dd";
            this.DT_waterMeterProofreadingDate_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_1.Location = new System.Drawing.Point(102, 7);
            this.DT_waterMeterProofreadingDate_1.Name = "DT_waterMeterProofreadingDate_1";
            this.DT_waterMeterProofreadingDate_1.Size = new System.Drawing.Size(105, 21);
            this.DT_waterMeterProofreadingDate_1.TabIndex = 161;
            // 
            // CHK_waterMeterProofreadingDate
            // 
            this.CHK_waterMeterProofreadingDate.AutoSize = true;
            this.CHK_waterMeterProofreadingDate.Location = new System.Drawing.Point(9, 10);
            this.CHK_waterMeterProofreadingDate.Name = "CHK_waterMeterProofreadingDate";
            this.CHK_waterMeterProofreadingDate.Size = new System.Drawing.Size(78, 16);
            this.CHK_waterMeterProofreadingDate.TabIndex = 160;
            this.CHK_waterMeterProofreadingDate.Text = "受理日期:";
            this.CHK_waterMeterProofreadingDate.UseVisualStyleBackColor = true;
            // 
            // CB_State
            // 
            this.CB_State.DropDownHeight = 130;
            this.CB_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_State.DropDownWidth = 150;
            this.CB_State.FormattingEnabled = true;
            this.CB_State.IntegralHeight = false;
            this.CB_State.Items.AddRange(new object[] {
            "",
            "正常",
            "停水",
            "报废"});
            this.CB_State.Location = new System.Drawing.Point(707, 41);
            this.CB_State.Name = "CB_State";
            this.CB_State.Size = new System.Drawing.Size(107, 20);
            this.CB_State.TabIndex = 158;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(655, 46);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(41, 12);
            this.label56.TabIndex = 159;
            this.label56.Text = "状态：";
            // 
            // UC_SearchModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.TB_waterPhone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_waterUserAddress);
            this.Controls.Add(this.label89);
            this.Controls.Add(this.TB_waterUserName);
            this.Controls.Add(this.label91);
            this.Controls.Add(this.TB_AcceptID);
            this.Controls.Add(this.CB_loginId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DT_waterMeterProofreadingDate_2);
            this.Controls.Add(this.DT_waterMeterProofreadingDate_1);
            this.Controls.Add(this.CHK_waterMeterProofreadingDate);
            this.Controls.Add(this.CB_State);
            this.Controls.Add(this.label56);
            this.Name = "UC_SearchModule";
            this.Size = new System.Drawing.Size(908, 69);
            this.Load += new System.EventHandler(this.UC_SearchModule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.TextBox TB_waterPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_waterUserAddress;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.TextBox TB_waterUserName;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TextBox TB_AcceptID;
        private System.Windows.Forms.ComboBox CB_loginId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_2;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_1;
        private System.Windows.Forms.CheckBox CHK_waterMeterProofreadingDate;
        private System.Windows.Forms.ComboBox CB_State;
        private System.Windows.Forms.Label label56;
    }
}

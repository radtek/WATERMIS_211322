namespace SysControl
{
    partial class UC_SearchBase
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
            this.label2 = new System.Windows.Forms.Label();
            this.DT_waterMeterProofreadingDate_2 = new System.Windows.Forms.DateTimePicker();
            this.DT_waterMeterProofreadingDate_1 = new System.Windows.Forms.DateTimePicker();
            this.CHK_waterMeterProofreadingDate = new System.Windows.Forms.CheckBox();
            this.CB_loginId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_State = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_PointSort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_SearchKey = new System.Windows.Forms.TextBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 178;
            this.label2.Tag = "9999";
            this.label2.Text = "至";
            // 
            // DT_waterMeterProofreadingDate_2
            // 
            this.DT_waterMeterProofreadingDate_2.CustomFormat = "yyyy-MM-dd";
            this.DT_waterMeterProofreadingDate_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_2.Location = new System.Drawing.Point(311, 5);
            this.DT_waterMeterProofreadingDate_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DT_waterMeterProofreadingDate_2.Name = "DT_waterMeterProofreadingDate_2";
            this.DT_waterMeterProofreadingDate_2.Size = new System.Drawing.Size(147, 26);
            this.DT_waterMeterProofreadingDate_2.TabIndex = 177;
            this.DT_waterMeterProofreadingDate_2.Tag = "9999";
            this.DT_waterMeterProofreadingDate_2.ValueChanged += new System.EventHandler(this.DT_waterMeterProofreadingDate_2_ValueChanged);
            // 
            // DT_waterMeterProofreadingDate_1
            // 
            this.DT_waterMeterProofreadingDate_1.CustomFormat = "yyyy-MM-dd";
            this.DT_waterMeterProofreadingDate_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_1.Location = new System.Drawing.Point(123, 5);
            this.DT_waterMeterProofreadingDate_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DT_waterMeterProofreadingDate_1.Name = "DT_waterMeterProofreadingDate_1";
            this.DT_waterMeterProofreadingDate_1.Size = new System.Drawing.Size(147, 26);
            this.DT_waterMeterProofreadingDate_1.TabIndex = 176;
            this.DT_waterMeterProofreadingDate_1.Tag = "9999";
            // 
            // CHK_waterMeterProofreadingDate
            // 
            this.CHK_waterMeterProofreadingDate.AutoSize = true;
            this.CHK_waterMeterProofreadingDate.Location = new System.Drawing.Point(15, 8);
            this.CHK_waterMeterProofreadingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CHK_waterMeterProofreadingDate.Name = "CHK_waterMeterProofreadingDate";
            this.CHK_waterMeterProofreadingDate.Size = new System.Drawing.Size(107, 20);
            this.CHK_waterMeterProofreadingDate.TabIndex = 175;
            this.CHK_waterMeterProofreadingDate.Tag = "9999";
            this.CHK_waterMeterProofreadingDate.Text = "受理日期：";
            this.CHK_waterMeterProofreadingDate.UseVisualStyleBackColor = true;
            // 
            // CB_loginId
            // 
            this.CB_loginId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_loginId.FormattingEnabled = true;
            this.CB_loginId.Location = new System.Drawing.Point(124, 44);
            this.CB_loginId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_loginId.Name = "CB_loginId";
            this.CB_loginId.Size = new System.Drawing.Size(145, 24);
            this.CB_loginId.TabIndex = 182;
            this.CB_loginId.Tag = "9999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 181;
            this.label3.Tag = "9999";
            this.label3.Text = "提 交 人：";
            // 
            // CB_State
            // 
            this.CB_State.DropDownHeight = 130;
            this.CB_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_State.DropDownWidth = 150;
            this.CB_State.FormattingEnabled = true;
            this.CB_State.IntegralHeight = false;
            this.CB_State.Location = new System.Drawing.Point(337, 44);
            this.CB_State.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_State.Name = "CB_State";
            this.CB_State.Size = new System.Drawing.Size(120, 24);
            this.CB_State.TabIndex = 179;
            this.CB_State.Tag = "9999";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(277, 48);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(56, 16);
            this.label56.TabIndex = 180;
            this.label56.Tag = "9999";
            this.label56.Text = "状态：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 183;
            this.label1.Tag = "9999";
            this.label1.Text = "审批节点：";
            // 
            // CB_PointSort
            // 
            this.CB_PointSort.DropDownHeight = 130;
            this.CB_PointSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_PointSort.DropDownWidth = 150;
            this.CB_PointSort.FormattingEnabled = true;
            this.CB_PointSort.IntegralHeight = false;
            this.CB_PointSort.Location = new System.Drawing.Point(557, 44);
            this.CB_PointSort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_PointSort.Name = "CB_PointSort";
            this.CB_PointSort.Size = new System.Drawing.Size(151, 24);
            this.CB_PointSort.TabIndex = 184;
            this.CB_PointSort.Tag = "9999";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 186;
            this.label4.Tag = "9999";
            this.label4.Text = "关 键 字：";
            // 
            // TB_SearchKey
            // 
            this.TB_SearchKey.BackColor = System.Drawing.SystemColors.Window;
            this.TB_SearchKey.Location = new System.Drawing.Point(555, 5);
            this.TB_SearchKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_SearchKey.Name = "TB_SearchKey";
            this.TB_SearchKey.Size = new System.Drawing.Size(153, 26);
            this.TB_SearchKey.TabIndex = 185;
            this.TB_SearchKey.Tag = "9999";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(720, 5);
            this.Btn_Search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(89, 63);
            this.Btn_Search.TabIndex = 187;
            this.Btn_Search.Tag = "9999";
            this.Btn_Search.Text = "查询";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // UC_SearchBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_SearchKey);
            this.Controls.Add(this.CB_PointSort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_loginId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CB_State);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DT_waterMeterProofreadingDate_2);
            this.Controls.Add(this.DT_waterMeterProofreadingDate_1);
            this.Controls.Add(this.CHK_waterMeterProofreadingDate);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_SearchBase";
            this.Size = new System.Drawing.Size(819, 77);
            this.Tag = "9999";
            this.Load += new System.EventHandler(this.UC_SearchBase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_2;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_1;
        private System.Windows.Forms.CheckBox CHK_waterMeterProofreadingDate;
        private System.Windows.Forms.ComboBox CB_loginId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_State;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_PointSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_SearchKey;
        private System.Windows.Forms.Button Btn_Search;
    }
}

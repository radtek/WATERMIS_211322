namespace WaterBusiness
{
    partial class Frm_Bus_Search
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
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_SearchKey = new System.Windows.Forms.TextBox();
            this.CB_loginId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_TableName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_State = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DT_waterMeterProofreadingDate_2 = new System.Windows.Forms.DateTimePicker();
            this.DT_waterMeterProofreadingDate_1 = new System.Windows.Forms.DateTimePicker();
            this.CHK_waterMeterProofreadingDate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uC_DataGridView_Page1 = new SysControl.UC_DataGridView_Page();
            this.uC_FlowList1 = new SysControl.UC_FlowList();
            this.tb1.SuspendLayout();
            this.GB1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.GB1, 0, 0);
            this.tb1.Controls.Add(this.groupBox2, 0, 1);
            this.tb1.Controls.Add(this.uC_FlowList1, 0, 2);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Margin = new System.Windows.Forms.Padding(4);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 3;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tb1.Size = new System.Drawing.Size(1167, 640);
            this.tb1.TabIndex = 64;
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.Btn_Search);
            this.GB1.Controls.Add(this.label4);
            this.GB1.Controls.Add(this.TB_SearchKey);
            this.GB1.Controls.Add(this.CB_loginId);
            this.GB1.Controls.Add(this.label1);
            this.GB1.Controls.Add(this.CB_TableName);
            this.GB1.Controls.Add(this.label3);
            this.GB1.Controls.Add(this.CB_State);
            this.GB1.Controls.Add(this.label56);
            this.GB1.Controls.Add(this.label2);
            this.GB1.Controls.Add(this.DT_waterMeterProofreadingDate_2);
            this.GB1.Controls.Add(this.DT_waterMeterProofreadingDate_1);
            this.GB1.Controls.Add(this.CHK_waterMeterProofreadingDate);
            this.GB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB1.Location = new System.Drawing.Point(4, 4);
            this.GB1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 9);
            this.GB1.Name = "GB1";
            this.GB1.Padding = new System.Windows.Forms.Padding(4);
            this.GB1.Size = new System.Drawing.Size(1159, 97);
            this.GB1.TabIndex = 60;
            this.GB1.TabStop = false;
            this.GB1.Text = "查询条件";
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(718, 23);
            this.Btn_Search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(89, 63);
            this.Btn_Search.TabIndex = 200;
            this.Btn_Search.Tag = "9999";
            this.Btn_Search.Text = "查询";
            this.Btn_Search.UseVisualStyleBackColor = true;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(464, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 199;
            this.label4.Tag = "9999";
            this.label4.Text = "关 键 字：";
            // 
            // TB_SearchKey
            // 
            this.TB_SearchKey.BackColor = System.Drawing.SystemColors.Window;
            this.TB_SearchKey.Location = new System.Drawing.Point(553, 23);
            this.TB_SearchKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_SearchKey.Name = "TB_SearchKey";
            this.TB_SearchKey.Size = new System.Drawing.Size(153, 26);
            this.TB_SearchKey.TabIndex = 198;
            this.TB_SearchKey.Tag = "9999";
            // 
            // CB_loginId
            // 
            this.CB_loginId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_loginId.DropDownHeight = 130;
            this.CB_loginId.DropDownWidth = 150;
            this.CB_loginId.FormattingEnabled = true;
            this.CB_loginId.IntegralHeight = false;
            this.CB_loginId.Location = new System.Drawing.Point(555, 62);
            this.CB_loginId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_loginId.Name = "CB_loginId";
            this.CB_loginId.Size = new System.Drawing.Size(151, 24);
            this.CB_loginId.TabIndex = 197;
            this.CB_loginId.Tag = "9999";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(462, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 196;
            this.label1.Tag = "9999";
            this.label1.Text = "提 交 人：";
            // 
            // CB_TableName
            // 
            this.CB_TableName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_TableName.FormattingEnabled = true;
            this.CB_TableName.Location = new System.Drawing.Point(122, 62);
            this.CB_TableName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_TableName.Name = "CB_TableName";
            this.CB_TableName.Size = new System.Drawing.Size(145, 24);
            this.CB_TableName.TabIndex = 195;
            this.CB_TableName.Tag = "9999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 194;
            this.label3.Tag = "9999";
            this.label3.Text = "业务类型：";
            // 
            // CB_State
            // 
            this.CB_State.DropDownHeight = 130;
            this.CB_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_State.DropDownWidth = 150;
            this.CB_State.FormattingEnabled = true;
            this.CB_State.IntegralHeight = false;
            this.CB_State.Location = new System.Drawing.Point(335, 62);
            this.CB_State.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB_State.Name = "CB_State";
            this.CB_State.Size = new System.Drawing.Size(120, 24);
            this.CB_State.TabIndex = 192;
            this.CB_State.Tag = "9999";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(275, 66);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(56, 16);
            this.label56.TabIndex = 193;
            this.label56.Tag = "9999";
            this.label56.Text = "状态：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 191;
            this.label2.Tag = "9999";
            this.label2.Text = "至";
            // 
            // DT_waterMeterProofreadingDate_2
            // 
            this.DT_waterMeterProofreadingDate_2.CustomFormat = "yyyy-MM-dd";
            this.DT_waterMeterProofreadingDate_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_2.Location = new System.Drawing.Point(309, 23);
            this.DT_waterMeterProofreadingDate_2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DT_waterMeterProofreadingDate_2.Name = "DT_waterMeterProofreadingDate_2";
            this.DT_waterMeterProofreadingDate_2.Size = new System.Drawing.Size(147, 26);
            this.DT_waterMeterProofreadingDate_2.TabIndex = 190;
            this.DT_waterMeterProofreadingDate_2.Tag = "9999";
            this.DT_waterMeterProofreadingDate_2.ValueChanged += new System.EventHandler(this.DT_waterMeterProofreadingDate_2_ValueChanged);
            // 
            // DT_waterMeterProofreadingDate_1
            // 
            this.DT_waterMeterProofreadingDate_1.CustomFormat = "yyyy-MM-dd";
            this.DT_waterMeterProofreadingDate_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT_waterMeterProofreadingDate_1.Location = new System.Drawing.Point(121, 23);
            this.DT_waterMeterProofreadingDate_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DT_waterMeterProofreadingDate_1.Name = "DT_waterMeterProofreadingDate_1";
            this.DT_waterMeterProofreadingDate_1.Size = new System.Drawing.Size(147, 26);
            this.DT_waterMeterProofreadingDate_1.TabIndex = 189;
            this.DT_waterMeterProofreadingDate_1.Tag = "9999";
            // 
            // CHK_waterMeterProofreadingDate
            // 
            this.CHK_waterMeterProofreadingDate.AutoSize = true;
            this.CHK_waterMeterProofreadingDate.Location = new System.Drawing.Point(13, 26);
            this.CHK_waterMeterProofreadingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CHK_waterMeterProofreadingDate.Name = "CHK_waterMeterProofreadingDate";
            this.CHK_waterMeterProofreadingDate.Size = new System.Drawing.Size(107, 20);
            this.CHK_waterMeterProofreadingDate.TabIndex = 188;
            this.CHK_waterMeterProofreadingDate.Tag = "9999";
            this.CHK_waterMeterProofreadingDate.Text = "受理日期：";
            this.CHK_waterMeterProofreadingDate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.uC_DataGridView_Page1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 114);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1159, 438);
            this.groupBox2.TabIndex = 902;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询列表";
            // 
            // uC_DataGridView_Page1
            // 
            this.uC_DataGridView_Page1.AutoSize = true;
            this.uC_DataGridView_Page1.BackColor = System.Drawing.Color.White;
            this.uC_DataGridView_Page1.DataStatis = null;
            this.uC_DataGridView_Page1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_DataGridView_Page1.Fields = null;
            this.uC_DataGridView_Page1.FieldStatis = null;
            this.uC_DataGridView_Page1.FiledColor = null;
            this.uC_DataGridView_Page1.Location = new System.Drawing.Point(4, 23);
            this.uC_DataGridView_Page1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_DataGridView_Page1.MinimumSize = new System.Drawing.Size(1111, 107);
            this.uC_DataGridView_Page1.Name = "uC_DataGridView_Page1";
            this.uC_DataGridView_Page1.PageIndex = 1;
            this.uC_DataGridView_Page1.PageOrderField = null;
            this.uC_DataGridView_Page1.PageSize = 100;
            this.uC_DataGridView_Page1.Size = new System.Drawing.Size(1151, 411);
            this.uC_DataGridView_Page1.TabIndex = 0;
            this.uC_DataGridView_Page1.Tag = "9999";
            this.uC_DataGridView_Page1.CellClickEvents += new SysControl.UC_DataGridView_Page.CellClickEvent(this.uC_DataGridView_Page1_CellClickEvents);
            // 
            // uC_FlowList1
            // 
            this.uC_FlowList1.AutoScroll = true;
            this.uC_FlowList1.AutoSize = true;
            this.uC_FlowList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_FlowList1.Location = new System.Drawing.Point(4, 560);
            this.uC_FlowList1.Margin = new System.Windows.Forms.Padding(4);
            this.uC_FlowList1.MinimumSize = new System.Drawing.Size(1200, 113);
            this.uC_FlowList1.Name = "uC_FlowList1";
            this.uC_FlowList1.Size = new System.Drawing.Size(1200, 113);
            this.uC_FlowList1.TabIndex = 0;
            this.uC_FlowList1.Tag = "9999";
            this.uC_FlowList1.TaskId = null;
            // 
            // Frm_Bus_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 640);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Bus_Search";
            this.Text = "综合查询";
            this.Load += new System.EventHandler(this.Frm_Bus_Search_Load);
            this.tb1.ResumeLayout(false);
            this.tb1.PerformLayout();
            this.GB1.ResumeLayout(false);
            this.GB1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_SearchKey;
        private System.Windows.Forms.ComboBox CB_loginId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_TableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_State;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_2;
        private System.Windows.Forms.DateTimePicker DT_waterMeterProofreadingDate_1;
        private System.Windows.Forms.CheckBox CHK_waterMeterProofreadingDate;
        private SysControl.UC_DataGridView_Page uC_DataGridView_Page1;
        private SysControl.UC_FlowList uC_FlowList1;
    }
}
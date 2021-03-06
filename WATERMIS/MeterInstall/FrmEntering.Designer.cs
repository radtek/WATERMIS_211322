namespace MeterInstall
{
    partial class FrmEntering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntering));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTipMonth = new System.Windows.Forms.ToolTip(this.components);
            this.Btn_Submit = new System.Windows.Forms.Button();
            this.label61 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.MEMO = new System.Windows.Forms.TextBox();
            this.waterMeterMode = new System.Windows.Forms.TextBox();
            this.waterMeterProduct = new System.Windows.Forms.TextBox();
            this.waterMeterSizeId = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.MeterState = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.waterMeterProofreadingDate = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.waterMeterMaxRange = new System.Windows.Forms.MaskedTextBox();
            this.waterMeteProofreadingPeriod = new System.Windows.Forms.MaskedTextBox();
            this.waterMeterSerialNumber = new System.Windows.Forms.MaskedTextBox();
            this.waterMeterStartNumber = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.ico");
            this.imageList1.Images.SetKeyName(1, "open.ico");
            // 
            // toolTipMonth
            // 
            this.toolTipMonth.ToolTipTitle = "请填写6位月份，例如201509";
            // 
            // Btn_Submit
            // 
            this.Btn_Submit.Location = new System.Drawing.Point(182, 172);
            this.Btn_Submit.Name = "Btn_Submit";
            this.Btn_Submit.Size = new System.Drawing.Size(138, 37);
            this.Btn_Submit.TabIndex = 11;
            this.Btn_Submit.Text = "保  存";
            this.Btn_Submit.UseVisualStyleBackColor = true;
            this.Btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(303, 104);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(17, 12);
            this.label61.TabIndex = 115;
            this.label61.Text = "月";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(195, 105);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(65, 12);
            this.label46.TabIndex = 114;
            this.label46.Text = "鉴定周期：";
            // 
            // MEMO
            // 
            this.MEMO.Location = new System.Drawing.Point(83, 135);
            this.MEMO.Name = "MEMO";
            this.MEMO.Size = new System.Drawing.Size(438, 21);
            this.MEMO.TabIndex = 10;
            // 
            // waterMeterMode
            // 
            this.waterMeterMode.Location = new System.Drawing.Point(433, 172);
            this.waterMeterMode.Name = "waterMeterMode";
            this.waterMeterMode.Size = new System.Drawing.Size(89, 21);
            this.waterMeterMode.TabIndex = 7;
            this.waterMeterMode.Visible = false;
            // 
            // waterMeterProduct
            // 
            this.waterMeterProduct.Location = new System.Drawing.Point(434, 68);
            this.waterMeterProduct.Name = "waterMeterProduct";
            this.waterMeterProduct.Size = new System.Drawing.Size(88, 21);
            this.waterMeterProduct.TabIndex = 6;
            // 
            // waterMeterSizeId
            // 
            this.waterMeterSizeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.waterMeterSizeId.FormattingEnabled = true;
            this.waterMeterSizeId.Location = new System.Drawing.Point(254, 33);
            this.waterMeterSizeId.Name = "waterMeterSizeId";
            this.waterMeterSizeId.Size = new System.Drawing.Size(89, 20);
            this.waterMeterSizeId.TabIndex = 2;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(22, 139);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(65, 12);
            this.label33.TabIndex = 110;
            this.label33.Text = "备    注：";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(195, 72);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 12);
            this.label30.TabIndex = 99;
            this.label30.Text = "最大量程：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(365, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 101;
            this.label13.Text = "规格型号：";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 12);
            this.label14.TabIndex = 98;
            this.label14.Text = "*出厂编号：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(373, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 104;
            this.label15.Text = "生产厂家：";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(189, 37);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 12);
            this.label27.TabIndex = 95;
            this.label27.Text = "*口    径：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(16, 72);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(71, 12);
            this.label29.TabIndex = 89;
            this.label29.Text = "*初始读数：";
            // 
            // MeterState
            // 
            this.MeterState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeterState.Enabled = false;
            this.MeterState.FormattingEnabled = true;
            this.MeterState.Items.AddRange(new object[] {
            "正常",
            "停水",
            "未启用"});
            this.MeterState.Location = new System.Drawing.Point(434, 33);
            this.MeterState.Name = "MeterState";
            this.MeterState.Size = new System.Drawing.Size(87, 20);
            this.MeterState.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(367, 37);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 12);
            this.label17.TabIndex = 90;
            this.label17.Text = "*水表状态：";
            // 
            // waterMeterProofreadingDate
            // 
            this.waterMeterProofreadingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.waterMeterProofreadingDate.Location = new System.Drawing.Point(82, 101);
            this.waterMeterProofreadingDate.Name = "waterMeterProofreadingDate";
            this.waterMeterProofreadingDate.Size = new System.Drawing.Size(88, 21);
            this.waterMeterProofreadingDate.TabIndex = 113;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(22, 105);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 12);
            this.label31.TabIndex = 102;
            this.label31.Text = "鉴定日期：";
            // 
            // waterMeterMaxRange
            // 
            this.waterMeterMaxRange.Location = new System.Drawing.Point(254, 68);
            this.waterMeterMaxRange.Mask = "99999";
            this.waterMeterMaxRange.Name = "waterMeterMaxRange";
            this.waterMeterMaxRange.Size = new System.Drawing.Size(89, 21);
            this.waterMeterMaxRange.TabIndex = 117;
            this.waterMeterMaxRange.Text = "99999";
            // 
            // waterMeteProofreadingPeriod
            // 
            this.waterMeteProofreadingPeriod.Location = new System.Drawing.Point(254, 100);
            this.waterMeteProofreadingPeriod.Mask = "99";
            this.waterMeteProofreadingPeriod.Name = "waterMeteProofreadingPeriod";
            this.waterMeteProofreadingPeriod.Size = new System.Drawing.Size(44, 21);
            this.waterMeteProofreadingPeriod.TabIndex = 118;
            this.waterMeteProofreadingPeriod.Text = "12";
            // 
            // waterMeterSerialNumber
            // 
            this.waterMeterSerialNumber.Location = new System.Drawing.Point(82, 32);
            this.waterMeterSerialNumber.Name = "waterMeterSerialNumber";
            this.waterMeterSerialNumber.Size = new System.Drawing.Size(90, 21);
            this.waterMeterSerialNumber.TabIndex = 119;
            // 
            // waterMeterStartNumber
            // 
            this.waterMeterStartNumber.AllowEmpty = false;
            this.waterMeterStartNumber.EmptyMessage = "";
            this.waterMeterStartNumber.ErrorMessage = "";
            this.waterMeterStartNumber.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.数字;
            this.waterMeterStartNumber.Location = new System.Drawing.Point(82, 68);
            this.waterMeterStartNumber.Name = "waterMeterStartNumber";
            this.waterMeterStartNumber.RegexExpression = "";
            this.waterMeterStartNumber.RemoveSpace = false;
            this.waterMeterStartNumber.Size = new System.Drawing.Size(90, 21);
            this.waterMeterStartNumber.TabIndex = 120;
            this.waterMeterStartNumber.Text = "0";
            this.waterMeterStartNumber.ValidateState = false;
            this.waterMeterStartNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.waterMeterStartNumber_KeyPress);
            // 
            // FrmEntering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 229);
            this.Controls.Add(this.waterMeterStartNumber);
            this.Controls.Add(this.waterMeterSerialNumber);
            this.Controls.Add(this.waterMeteProofreadingPeriod);
            this.Controls.Add(this.waterMeterMaxRange);
            this.Controls.Add(this.Btn_Submit);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.MEMO);
            this.Controls.Add(this.waterMeterMode);
            this.Controls.Add(this.waterMeterProduct);
            this.Controls.Add(this.waterMeterSizeId);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.MeterState);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.waterMeterProofreadingDate);
            this.Controls.Add(this.label31);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmEntering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "水表入库（单个）";
            this.Load += new System.EventHandler(this.FrmEntering_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTipMonth;
        private System.Windows.Forms.Button Btn_Submit;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox MEMO;
        private System.Windows.Forms.TextBox waterMeterMode;
        private System.Windows.Forms.TextBox waterMeterProduct;
        private System.Windows.Forms.ComboBox waterMeterSizeId;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox MeterState;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker waterMeterProofreadingDate;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.MaskedTextBox waterMeterMaxRange;
        private System.Windows.Forms.MaskedTextBox waterMeteProofreadingPeriod;
        private System.Windows.Forms.MaskedTextBox waterMeterSerialNumber;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox waterMeterStartNumber;

    }
}
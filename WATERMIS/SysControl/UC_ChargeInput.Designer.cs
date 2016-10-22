namespace SysControl
{
    partial class UC_ChargeInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ChargeInput));
            this.LB_FeeName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Price = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.TB_Fee = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.TB_Quantity = new Common.WinControl.Ryan.RegTextbox.RyanTextBox();
            this.SuspendLayout();
            // 
            // LB_FeeName
            // 
            this.LB_FeeName.AutoSize = true;
            this.LB_FeeName.BackColor = System.Drawing.Color.Transparent;
            this.LB_FeeName.Location = new System.Drawing.Point(10, 8);
            this.LB_FeeName.Name = "LB_FeeName";
            this.LB_FeeName.Size = new System.Drawing.Size(53, 12);
            this.LB_FeeName.TabIndex = 0;
            this.LB_FeeName.Text = "设计费：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(162, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "元";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(187, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "数量：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(293, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "合计：";
            // 
            // TB_Price
            // 
            this.TB_Price.AllowEmpty = false;
            this.TB_Price.EmptyMessage = "";
            this.TB_Price.ErrorMessage = "";
            this.TB_Price.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.货币;
            this.TB_Price.Location = new System.Drawing.Point(82, 3);
            this.TB_Price.Name = "TB_Price";
            this.TB_Price.RegexExpression = "";
            this.TB_Price.RemoveSpace = false;
            this.TB_Price.Size = new System.Drawing.Size(75, 21);
            this.TB_Price.TabIndex = 7;
            this.TB_Price.ValidateState = false;
            this.TB_Price.TextChanged += new System.EventHandler(this.TB_Price_TextChanged);
            // 
            // TB_Fee
            // 
            this.TB_Fee.AllowEmpty = false;
            this.TB_Fee.EmptyMessage = "";
            this.TB_Fee.ErrorMessage = "";
            this.TB_Fee.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.货币;
            this.TB_Fee.Location = new System.Drawing.Point(338, 3);
            this.TB_Fee.Name = "TB_Fee";
            this.TB_Fee.ReadOnly = true;
            this.TB_Fee.RegexExpression = "";
            this.TB_Fee.RemoveSpace = false;
            this.TB_Fee.Size = new System.Drawing.Size(80, 21);
            this.TB_Fee.TabIndex = 6;
            this.TB_Fee.ValidateState = false;
            this.TB_Fee.TextChanged += new System.EventHandler(this.TB_Fee_TextChanged_1);
            // 
            // TB_Quantity
            // 
            this.TB_Quantity.AllowEmpty = false;
            this.TB_Quantity.EmptyMessage = "";
            this.TB_Quantity.ErrorMessage = "";
            this.TB_Quantity.InputType = Common.WinControl.Ryan.RegTextbox.RyanTextBox.EMInputTypes.数字;
            this.TB_Quantity.Location = new System.Drawing.Point(232, 3);
            this.TB_Quantity.Name = "TB_Quantity";
            this.TB_Quantity.RegexExpression = "";
            this.TB_Quantity.RemoveSpace = false;
            this.TB_Quantity.Size = new System.Drawing.Size(54, 21);
            this.TB_Quantity.TabIndex = 4;
            this.TB_Quantity.ValidateState = false;
            this.TB_Quantity.TextChanged += new System.EventHandler(this.TB_Quantity_TextChanged);
            // 
            // UC_ChargeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.TB_Price);
            this.Controls.Add(this.TB_Fee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Quantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LB_FeeName);
            this.Name = "UC_ChargeInput";
            this.Size = new System.Drawing.Size(422, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_FeeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox TB_Quantity;
        private System.Windows.Forms.Label label3;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox TB_Fee;
        private Common.WinControl.Ryan.RegTextbox.RyanTextBox TB_Price;
    }
}

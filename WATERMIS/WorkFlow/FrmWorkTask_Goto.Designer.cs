namespace WorkFlow
{
    partial class FrmWorkTask_Goto
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_WorkFlow = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Btn_Goto = new System.Windows.Forms.Button();
            this.Btn_Scrap = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.LB_Table_Name_CH = new System.Windows.Forms.Label();
            this.LB_SD = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UserOpinion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "流程跳转：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "任务类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "流 水 号：";
            // 
            // CB_WorkFlow
            // 
            this.CB_WorkFlow.FormattingEnabled = true;
            this.CB_WorkFlow.Location = new System.Drawing.Point(116, 178);
            this.CB_WorkFlow.Name = "CB_WorkFlow";
            this.CB_WorkFlow.Size = new System.Drawing.Size(162, 20);
            this.CB_WorkFlow.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(39, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(333, 64);
            this.textBox1.TabIndex = 6;
            this.textBox1.Tag = "9999";
            this.textBox1.Text = "警告：此功能可能会影响审批流程的正常运行，如果不了解各项功能，请慎用！";
            // 
            // Btn_Goto
            // 
            this.Btn_Goto.Location = new System.Drawing.Point(118, 335);
            this.Btn_Goto.Name = "Btn_Goto";
            this.Btn_Goto.Size = new System.Drawing.Size(75, 23);
            this.Btn_Goto.TabIndex = 7;
            this.Btn_Goto.Text = "流程跳转";
            this.Btn_Goto.UseVisualStyleBackColor = true;
            this.Btn_Goto.Click += new System.EventHandler(this.Btn_Goto_Click);
            // 
            // Btn_Scrap
            // 
            this.Btn_Scrap.Location = new System.Drawing.Point(296, 335);
            this.Btn_Scrap.Name = "Btn_Scrap";
            this.Btn_Scrap.Size = new System.Drawing.Size(75, 23);
            this.Btn_Scrap.TabIndex = 8;
            this.Btn_Scrap.Text = "作废流程";
            this.Btn_Scrap.UseVisualStyleBackColor = true;
            this.Btn_Scrap.Click += new System.EventHandler(this.Btn_Scrap_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(207, 335);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 9;
            this.Btn_Cancel.Text = "取  消";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // LB_Table_Name_CH
            // 
            this.LB_Table_Name_CH.AutoSize = true;
            this.LB_Table_Name_CH.Location = new System.Drawing.Point(116, 113);
            this.LB_Table_Name_CH.Name = "LB_Table_Name_CH";
            this.LB_Table_Name_CH.Size = new System.Drawing.Size(0, 12);
            this.LB_Table_Name_CH.TabIndex = 10;
            // 
            // LB_SD
            // 
            this.LB_SD.AutoSize = true;
            this.LB_SD.Location = new System.Drawing.Point(114, 147);
            this.LB_SD.Name = "LB_SD";
            this.LB_SD.Size = new System.Drawing.Size(0, 12);
            this.LB_SD.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "备注说明：";
            // 
            // UserOpinion
            // 
            this.UserOpinion.Location = new System.Drawing.Point(116, 216);
            this.UserOpinion.Multiline = true;
            this.UserOpinion.Name = "UserOpinion";
            this.UserOpinion.Size = new System.Drawing.Size(256, 95);
            this.UserOpinion.TabIndex = 13;
            // 
            // FrmWorkTask_Goto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 389);
            this.Controls.Add(this.UserOpinion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LB_SD);
            this.Controls.Add(this.LB_Table_Name_CH);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Scrap);
            this.Controls.Add(this.Btn_Goto);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CB_WorkFlow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkTask_Goto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工作任务编辑";
            this.Load += new System.EventHandler(this.FrmWorkTask_Goto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_WorkFlow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Btn_Goto;
        private System.Windows.Forms.Button Btn_Scrap;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Label LB_Table_Name_CH;
        private System.Windows.Forms.Label LB_SD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UserOpinion;
    }
}
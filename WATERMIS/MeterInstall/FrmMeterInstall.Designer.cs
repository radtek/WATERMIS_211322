namespace MeterInstall
{
    partial class FrmMeterInstall
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser0 = new System.Windows.Forms.WebBrowser();
            this.Btn_Transition = new System.Windows.Forms.Button();
            this.Btn_Group = new System.Windows.Forms.Button();
            this.Btn_Single = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.webBrowser3 = new System.Windows.Forms.WebBrowser();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(855, 582);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.Btn_Transition);
            this.tabPage1.Controls.Add(this.Btn_Group);
            this.tabPage1.Controls.Add(this.Btn_Single);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(847, 556);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "用户报装";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowser0);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30, 30, 30, 0);
            this.panel1.Size = new System.Drawing.Size(841, 417);
            this.panel1.TabIndex = 7;
            // 
            // webBrowser0
            // 
            this.webBrowser0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser0.Location = new System.Drawing.Point(30, 30);
            this.webBrowser0.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser0.Name = "webBrowser0";
            this.webBrowser0.Size = new System.Drawing.Size(781, 387);
            this.webBrowser0.TabIndex = 0;
            // 
            // Btn_Transition
            // 
            this.Btn_Transition.Location = new System.Drawing.Point(575, 457);
            this.Btn_Transition.Name = "Btn_Transition";
            this.Btn_Transition.Size = new System.Drawing.Size(130, 50);
            this.Btn_Transition.TabIndex = 6;
            this.Btn_Transition.Text = "临时用水";
            this.Btn_Transition.UseVisualStyleBackColor = true;
            // 
            // Btn_Group
            // 
            this.Btn_Group.Location = new System.Drawing.Point(383, 457);
            this.Btn_Group.Name = "Btn_Group";
            this.Btn_Group.Size = new System.Drawing.Size(130, 50);
            this.Btn_Group.TabIndex = 5;
            this.Btn_Group.Text = "单位用户";
            this.Btn_Group.UseVisualStyleBackColor = true;
            this.Btn_Group.Click += new System.EventHandler(this.Btn_Group_Click);
            // 
            // Btn_Single
            // 
            this.Btn_Single.Location = new System.Drawing.Point(191, 457);
            this.Btn_Single.Name = "Btn_Single";
            this.Btn_Single.Size = new System.Drawing.Size(130, 50);
            this.Btn_Single.TabIndex = 4;
            this.Btn_Single.Text = "独立用户";
            this.Btn_Single.UseVisualStyleBackColor = true;
            this.Btn_Single.Click += new System.EventHandler(this.Btn_Single_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(847, 556);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "个人/单位报装流程";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(841, 550);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowser2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(847, 556);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "临时用水报装流程";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(0, 0);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(847, 556);
            this.webBrowser2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.webBrowser3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(847, 556);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "系统使用问答";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // webBrowser3
            // 
            this.webBrowser3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser3.Location = new System.Drawing.Point(0, 0);
            this.webBrowser3.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser3.Name = "webBrowser3";
            this.webBrowser3.Size = new System.Drawing.Size(847, 556);
            this.webBrowser3.TabIndex = 0;
            // 
            // FrmMeterInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 582);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmMeterInstall";
            this.Text = "用户报装";
            this.Load += new System.EventHandler(this.FrmMeterInstall_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Transition;
        private System.Windows.Forms.Button Btn_Group;
        private System.Windows.Forms.Button Btn_Single;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.WebBrowser webBrowser3;
        private System.Windows.Forms.WebBrowser webBrowser0;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.WebBrowser webBrowser2;

    }
}
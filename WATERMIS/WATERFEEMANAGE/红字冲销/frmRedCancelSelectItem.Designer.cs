namespace WATERFEEMANAGE
{
    partial class frmRedCancelSelectItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRedCancelSelectItem));
            this.tb1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btNext = new System.Windows.Forms.Button();
            this.txtFormID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbPrestore = new System.Windows.Forms.RadioButton();
            this.rbCharge = new System.Windows.Forms.RadioButton();
            this.tb1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tb2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb1
            // 
            this.tb1.ColumnCount = 1;
            this.tb1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Controls.Add(this.panel1, 0, 0);
            this.tb1.Controls.Add(this.tb2, 0, 1);
            this.tb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb1.Location = new System.Drawing.Point(0, 0);
            this.tb1.Margin = new System.Windows.Forms.Padding(0);
            this.tb1.Name = "tb1";
            this.tb1.RowCount = 2;
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tb1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb1.Size = new System.Drawing.Size(494, 372);
            this.tb1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WATERFEEMANAGE.Properties.Resources.redcancelguid;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 88);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(311, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择要冲销的单据";
            // 
            // tb2
            // 
            this.tb2.ColumnCount = 2;
            this.tb2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tb2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb2.Controls.Add(this.panel3, 0, 0);
            this.tb2.Controls.Add(this.panel2, 1, 0);
            this.tb2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb2.Location = new System.Drawing.Point(0, 88);
            this.tb2.Margin = new System.Windows.Forms.Padding(0);
            this.tb2.Name = "tb2";
            this.tb2.RowCount = 1;
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb2.Size = new System.Drawing.Size(494, 284);
            this.tb2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::WATERFEEMANAGE.Properties.Resources.peple;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(119, 284);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btNext);
            this.panel2.Controls.Add(this.txtFormID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.rbPrestore);
            this.panel2.Controls.Add(this.rbCharge);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(123, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 276);
            this.panel2.TabIndex = 0;
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(127, 166);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 30);
            this.btNext.TabIndex = 4;
            this.btNext.Text = "下一步";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // txtFormID
            // 
            this.txtFormID.Location = new System.Drawing.Point(127, 118);
            this.txtFormID.Margin = new System.Windows.Forms.Padding(4);
            this.txtFormID.Name = "txtFormID";
            this.txtFormID.Size = new System.Drawing.Size(162, 26);
            this.txtFormID.TabIndex = 3;
            this.txtFormID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFormID_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(67, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "单据号:";
            // 
            // rbPrestore
            // 
            this.rbPrestore.AutoSize = true;
            this.rbPrestore.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbPrestore.Location = new System.Drawing.Point(68, 69);
            this.rbPrestore.Margin = new System.Windows.Forms.Padding(4);
            this.rbPrestore.Name = "rbPrestore";
            this.rbPrestore.Size = new System.Drawing.Size(122, 20);
            this.rbPrestore.TabIndex = 1;
            this.rbPrestore.Text = "红冲预存单据";
            this.rbPrestore.UseVisualStyleBackColor = true;
            // 
            // rbCharge
            // 
            this.rbCharge.AutoSize = true;
            this.rbCharge.Checked = true;
            this.rbCharge.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbCharge.Location = new System.Drawing.Point(68, 33);
            this.rbCharge.Margin = new System.Windows.Forms.Padding(4);
            this.rbCharge.Name = "rbCharge";
            this.rbCharge.Size = new System.Drawing.Size(122, 20);
            this.rbCharge.TabIndex = 0;
            this.rbCharge.TabStop = true;
            this.rbCharge.Text = "红冲收费单据";
            this.rbCharge.UseVisualStyleBackColor = true;
            // 
            // frmRedCancelSelectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 372);
            this.Controls.Add(this.tb1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRedCancelSelectItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "";
            this.Text = "红字冲销向导";
            this.Load += new System.EventHandler(this.frmRedCancelSelectItem_Load);
            this.tb1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tb2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tb1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tb2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbPrestore;
        private System.Windows.Forms.RadioButton rbCharge;
        private System.Windows.Forms.TextBox txtFormID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btNext;
    }
}
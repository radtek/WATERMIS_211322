namespace SysControl
{
    partial class FrmWorkPoint_Show
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
            this.GB1 = new System.Windows.Forms.GroupBox();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.PointName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcceptUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserOpinion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSkip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DV = new System.Windows.Forms.DataGridView();
            this.GB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DV)).BeginInit();
            this.SuspendLayout();
            // 
            // GB1
            // 
            this.GB1.Controls.Add(this.dgList);
            this.GB1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GB1.Location = new System.Drawing.Point(0, 0);
            this.GB1.Name = "GB1";
            this.GB1.Size = new System.Drawing.Size(1058, 129);
            this.GB1.TabIndex = 2;
            this.GB1.TabStop = false;
            this.GB1.Text = "当前节点";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PointName,
            this.DoName,
            this.userName,
            this.AcceptUser,
            this.IsPass,
            this.UserOpinion,
            this.TimeLimit,
            this.PointTime,
            this.IsSkip,
            this.GoPoint});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgList.Location = new System.Drawing.Point(3, 17);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(1052, 109);
            this.dgList.TabIndex = 1;
            // 
            // PointName
            // 
            this.PointName.DataPropertyName = "PointName";
            this.PointName.HeaderText = "节点名称";
            this.PointName.Name = "PointName";
            this.PointName.ReadOnly = true;
            this.PointName.Width = 61;
            // 
            // DoName
            // 
            this.DoName.DataPropertyName = "DoName";
            this.DoName.HeaderText = "审核明细";
            this.DoName.Name = "DoName";
            this.DoName.ReadOnly = true;
            this.DoName.Width = 61;
            // 
            // userName
            // 
            this.userName.DataPropertyName = "userName";
            this.userName.HeaderText = "权限人员";
            this.userName.Name = "userName";
            this.userName.ReadOnly = true;
            this.userName.Width = 61;
            // 
            // AcceptUser
            // 
            this.AcceptUser.DataPropertyName = "AcceptUser";
            this.AcceptUser.HeaderText = "审核人员";
            this.AcceptUser.Name = "AcceptUser";
            this.AcceptUser.ReadOnly = true;
            this.AcceptUser.Width = 61;
            // 
            // IsPass
            // 
            this.IsPass.DataPropertyName = "IsPass";
            this.IsPass.HeaderText = "审核状态";
            this.IsPass.Name = "IsPass";
            this.IsPass.ReadOnly = true;
            this.IsPass.Width = 61;
            // 
            // UserOpinion
            // 
            this.UserOpinion.DataPropertyName = "UserOpinion";
            this.UserOpinion.HeaderText = "审核意见";
            this.UserOpinion.Name = "UserOpinion";
            this.UserOpinion.ReadOnly = true;
            this.UserOpinion.Width = 61;
            // 
            // TimeLimit
            // 
            this.TimeLimit.DataPropertyName = "TimeLimit";
            this.TimeLimit.HeaderText = "审核期限(天)";
            this.TimeLimit.Name = "TimeLimit";
            this.TimeLimit.ReadOnly = true;
            this.TimeLimit.Width = 72;
            // 
            // PointTime
            // 
            this.PointTime.DataPropertyName = "PointTime";
            this.PointTime.HeaderText = "开始时间";
            this.PointTime.Name = "PointTime";
            this.PointTime.ReadOnly = true;
            this.PointTime.Width = 61;
            // 
            // IsSkip
            // 
            this.IsSkip.DataPropertyName = "IsSkip";
            this.IsSkip.HeaderText = "是否跳转";
            this.IsSkip.Name = "IsSkip";
            this.IsSkip.ReadOnly = true;
            this.IsSkip.Width = 61;
            // 
            // GoPoint
            // 
            this.GoPoint.DataPropertyName = "GoPoint";
            this.GoPoint.HeaderText = "跳转节点";
            this.GoPoint.Name = "GoPoint";
            this.GoPoint.ReadOnly = true;
            this.GoPoint.Width = 61;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1058, 401);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "历史审批";
            // 
            // DV
            // 
            this.DV.AllowUserToAddRows = false;
            this.DV.AllowUserToDeleteRows = false;
            this.DV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DV.Location = new System.Drawing.Point(3, 17);
            this.DV.Name = "DV";
            this.DV.ReadOnly = true;
            this.DV.RowTemplate.Height = 23;
            this.DV.Size = new System.Drawing.Size(1052, 381);
            this.DV.TabIndex = 1;
            // 
            // FrmWorkPoint_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 530);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GB1);
            this.Name = "FrmWorkPoint_Show";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "审批明细";
            this.Load += new System.EventHandler(this.FrmWorkPoint_Show_Load);
            this.GB1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB1;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcceptUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserOpinion;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSkip;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoPoint;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DV;
    }
}
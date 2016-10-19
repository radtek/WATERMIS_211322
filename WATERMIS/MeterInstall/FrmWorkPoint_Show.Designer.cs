namespace MeterInstall
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
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgList
            // 
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
            this.dgList.Location = new System.Drawing.Point(0, 0);
            this.dgList.Name = "dgList";
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(1058, 530);
            this.dgList.TabIndex = 0;
            // 
            // PointName
            // 
            this.PointName.DataPropertyName = "PointName";
            this.PointName.HeaderText = "节点名称";
            this.PointName.Name = "PointName";
            // 
            // DoName
            // 
            this.DoName.DataPropertyName = "DoName";
            this.DoName.HeaderText = "审核明细";
            this.DoName.Name = "DoName";
            // 
            // userName
            // 
            this.userName.DataPropertyName = "userName";
            this.userName.HeaderText = "权限人员";
            this.userName.Name = "userName";
            // 
            // AcceptUser
            // 
            this.AcceptUser.DataPropertyName = "AcceptUser";
            this.AcceptUser.HeaderText = "审核人员";
            this.AcceptUser.Name = "AcceptUser";
            // 
            // IsPass
            // 
            this.IsPass.DataPropertyName = "IsPass";
            this.IsPass.HeaderText = "审核状态";
            this.IsPass.Name = "IsPass";
            // 
            // UserOpinion
            // 
            this.UserOpinion.DataPropertyName = "UserOpinion";
            this.UserOpinion.HeaderText = "审核意见";
            this.UserOpinion.Name = "UserOpinion";
            // 
            // TimeLimit
            // 
            this.TimeLimit.DataPropertyName = "TimeLimit";
            this.TimeLimit.HeaderText = "审核期限(天)";
            this.TimeLimit.Name = "TimeLimit";
            // 
            // PointTime
            // 
            this.PointTime.DataPropertyName = "PointTime";
            this.PointTime.HeaderText = "开始时间";
            this.PointTime.Name = "PointTime";
            // 
            // IsSkip
            // 
            this.IsSkip.DataPropertyName = "IsSkip";
            this.IsSkip.HeaderText = "是否跳转";
            this.IsSkip.Name = "IsSkip";
            // 
            // GoPoint
            // 
            this.GoPoint.DataPropertyName = "GoPoint";
            this.GoPoint.HeaderText = "跳转节点";
            this.GoPoint.Name = "GoPoint";
            // 
            // FrmWorkPoint_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 530);
            this.Controls.Add(this.dgList);
            this.Name = "FrmWorkPoint_Show";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "审批明细";
            this.Load += new System.EventHandler(this.FrmWorkPoint_Show_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
    }
}
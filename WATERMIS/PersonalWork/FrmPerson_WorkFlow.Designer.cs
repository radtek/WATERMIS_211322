namespace PersonalWork
{
    partial class FrmPerson_WorkFlow
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
            this.dgList1 = new System.Windows.Forms.DataGridView();
            this.ROWNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkFlowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgList1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgList1
            // 
            this.dgList1.AllowUserToAddRows = false;
            this.dgList1.AllowUserToDeleteRows = false;
            this.dgList1.AllowUserToOrderColumns = true;
            this.dgList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROWNUM,
            this.WorkName,
            this.WorkCode,
            this.STATE,
            this.ModifyDate,
            this.ModifyUser,
            this.WorkFlowID});
            this.dgList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList1.Location = new System.Drawing.Point(0, 0);
            this.dgList1.Name = "dgList1";
            this.dgList1.ReadOnly = true;
            this.dgList1.RowTemplate.Height = 23;
            this.dgList1.Size = new System.Drawing.Size(872, 725);
            this.dgList1.TabIndex = 0;
            this.dgList1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList1_CellDoubleClick);
            // 
            // ROWNUM
            // 
            this.ROWNUM.DataPropertyName = "ROWNUM";
            this.ROWNUM.HeaderText = "序号";
            this.ROWNUM.Name = "ROWNUM";
            this.ROWNUM.ReadOnly = true;
            // 
            // WorkName
            // 
            this.WorkName.DataPropertyName = "WorkName";
            this.WorkName.HeaderText = "流程名称";
            this.WorkName.Name = "WorkName";
            this.WorkName.ReadOnly = true;
            // 
            // WorkCode
            // 
            this.WorkCode.DataPropertyName = "WorkCode";
            this.WorkCode.HeaderText = "流程代码";
            this.WorkCode.Name = "WorkCode";
            this.WorkCode.ReadOnly = true;
            // 
            // STATE
            // 
            this.STATE.DataPropertyName = "STATE";
            this.STATE.HeaderText = "状态";
            this.STATE.Name = "STATE";
            this.STATE.ReadOnly = true;
            // 
            // ModifyDate
            // 
            this.ModifyDate.DataPropertyName = "ModifyDate";
            this.ModifyDate.HeaderText = "编辑时间";
            this.ModifyDate.Name = "ModifyDate";
            this.ModifyDate.ReadOnly = true;
            // 
            // ModifyUser
            // 
            this.ModifyUser.DataPropertyName = "ModifyUser";
            this.ModifyUser.HeaderText = "编辑人";
            this.ModifyUser.Name = "ModifyUser";
            this.ModifyUser.ReadOnly = true;
            // 
            // WorkFlowID
            // 
            this.WorkFlowID.DataPropertyName = "WorkFlowID";
            this.WorkFlowID.HeaderText = "WorkFlowID";
            this.WorkFlowID.Name = "WorkFlowID";
            this.WorkFlowID.ReadOnly = true;
            this.WorkFlowID.Visible = false;
            // 
            // FrmPerson_WorkFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 725);
            this.Controls.Add(this.dgList1);
            this.Name = "FrmPerson_WorkFlow";
            this.Text = "工作流程查看";
            this.Load += new System.EventHandler(this.FrmPerson_WorkFlow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROWNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkFlowID;

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Common.DotNetData;
using System.Collections;
using Common.DotNetUI;

namespace WorkFlow
{
    public partial class FrmWorkTask_Goto : Form
    {
        public string TaskID;
        public string TableName;
        public string SD;
        public string Table_Name_CH;
        public FrmWorkTask_Goto()
        {
            InitializeComponent();
        }

        private void FrmWorkTask_Goto_Load(object sender, EventArgs e)
        {
            LB_Table_Name_CH.Text = Table_Name_CH;
            LB_SD.Text = SD;

            BindWorkFlow();
        }

        private void BindWorkFlow()
        {
            string sqlstr = @"SELECT DISTINCT MWR.PointSort,MWR.PointName FROM Meter_WorkTask MW, Meter_WorkResolve MWR 
WHERE MW.TaskID= MWR.TaskID AND MW.TaskID=@TaskID 
AND MWR.PointSort<MW.PointSort AND MW.[State]=1
ORDER BY MWR.PointSort";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            if (DataTableHelper.IsExistRows(dt))
            {
                ControlBindHelper.BindComboBoxData(this.CB_WorkFlow, dt, "PointName", "PointSort");
            }
            else
            {
                Btn_Goto.Enabled = false;
                Btn_Scrap.Enabled = false;
            }

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Btn_Goto_Click(object sender, EventArgs e)
        {

            //UPDATE Meter_WorkTask SET PointSort=
            string sqlstr = "UPDATE Meter_WorkTask SET PointSort=@PointSort WHERE TaskID=@TaskID";
            int count = new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@PointSort", this.CB_WorkFlow.SelectedValue), new SqlParameter("@TaskID", TaskID) });
            if (count > 0)
            {
                MessageBox.Show("跳转成功！");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("跳转失败！");
            }
        }

        private void Btn_Scrap_Click(object sender, EventArgs e)
        {
            string sqlstr = string.Format(@"UPDATE Meter_WorkTask SET [State]=4 WHERE TaskID=@TaskID
UPDATE {0} SET [State]=4 WHERE TaskID=@TaskID", TableName);
            int count = new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            if (count > 0)
            {
                MessageBox.Show("作废成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("作废失败！");
            }

        }
    }
}

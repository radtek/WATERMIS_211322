using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Common.DotNetData;
using Common.DotNetUI;
using System.Collections;
using DBinterface.DAL;
using DBinterface.IDAL;

namespace FinanceOS
{
    public partial class FrmFinance_RefundShow2 : Form
    {
        public string TaskID = string.Empty;

        public FrmFinance_RefundShow2()
        {
            InitializeComponent();
        }

        private void FrmFinance_RefundShow2_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TaskID))
            {
                GetTaskInfos();
            }
        }

        private void GetTaskInfos()
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("View_WorkBase", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel2.Controls);
            string sqlstr = "SELECT PointTime,( SELECT top 1 PointName FROM  Meter_WorkResolve WHERE TaskID=MW.TaskID AND PointSort=MW.PointSort) AS PointName FROM Meter_WorkTask MW WHERE MW.TaskID=@TaskID";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID) });
            if (DataTableHelper.IsExistRows(dt))
            {
                PointTime.Text = dt.Rows[0][0].ToString();
                PointName.Text = dt.Rows[0][1].ToString();

                CHARGEBCSS.Text = prestore.Text;
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            decimal _prestore = 0m;
            if (decimal.TryParse(prestore.Text, out _prestore))
            {
                decimal _bcss = 0m;
                if (decimal.TryParse(CHARGEBCSS.Text, out _bcss))
                {
                    if (_bcss > _prestore)
                    {
                        MessageBox.Show("退款金额不能大于账户余额！");
                    }
                    else
                    {
                        PersonalWork_IDAL sysidal = new PersonalWork_DAL();
                        if (sysidal.UserPrestoreRefund(TaskID,Memo.Text))
                        {
                            MessageBox.Show("退款成功！");
                        }
                        else
                        {
                            MessageBox.Show("退款失败！");
                        }
                    }
                }
            }
        }
    }
}

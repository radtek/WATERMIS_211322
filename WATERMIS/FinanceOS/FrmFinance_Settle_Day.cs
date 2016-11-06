using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using DBinterface.DAL;
using DBinterface.IDAL;
using System.Data.SqlClient;

namespace FinanceOS
{
    public partial class FrmFinance_Settle_Day : Form
    {
       // private Finance_IDAL fdal = new Finance_Dal();

        //private string TaskID = string.Empty;
        //private string PointSort = string.Empty;
        //private string ResolveID = string.Empty;
        //private string TableName = string.Empty;
        //private bool _IsFinal = true;

        private string strLogID;
        private string strName;
        private string strRealName;

        public FrmFinance_Settle_Day()
        {
            InitializeComponent();
        }
        private void FrmFinance_Settle_Day_Load(object sender, EventArgs e)
        {
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

                BindData();
            }
            else
            {
                MessageBox.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        private void BindData()
        {
            DataTable dt = new DataTable();
            string sqlstr=@"SELECT DISTINCT ChargeMonth,ChargeMonth AS ChargeMonthVALUE FROM
(SELECT CASE WHEN MONTH(MC.CHARGEDATETIME) < 10 THEN CAST(YEAR(MC.CHARGEDATETIME) AS varchar) + '0' + CAST(MONTH(MC.CHARGEDATETIME) AS varchar) 
 ELSE CAST(YEAR(MC.CHARGEDATETIME) AS varchar) + CAST(MONTH(MC.CHARGEDATETIME) AS varchar) END AS ChargeMonth FROM Meter_Charge MC
 WHERE MC.CHARGEWORKERID=@LoginID) T GROUP BY ChargeMonth ORDER BY ChargeMonth DESC";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@LoginID", strLogID) });
            ControlBindHelper.BindComboBoxData(this.CB_Month, dt, "ChargeMonthVALUE", "ChargeMonth");

            sqlstr = @"SELECT DISTINCT CHARGEDAY,CHARGEDAY AS CHARGEDAYVALUE FROM
(SELECT DAY(MC.CHARGEDATETIME) AS CHARGEDAY  FROM Meter_Charge MC
 WHERE MC.CHARGEWORKERID=@LoginID) T GROUP BY CHARGEDAY ORDER BY CHARGEDAY DESC";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@LoginID", strLogID) });
            ControlBindHelper.BindComboBoxData(this.CB_Day, dt, "CHARGEDAYVALUE", "CHARGEDAY");

            ShowData();
        }

        private void ShowData()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"SELECT * FROM (SELECT MC.*,MWT.SD,MWT.TaskName,CASE WHEN DAYCHECKSTATE=0 THEN '-' ELSE '已结' END AS DAYCHECKSTATES,
(SELECT TOP 1 CHARGETYPENAME FROM CHARGETYPE WHERE CHARGETYPEID=MC.CHARGETYPEID) AS CHARGETYPE,
 CASE WHEN MONTH(MC.CHARGEDATETIME) < 10 THEN CAST(YEAR(MC.CHARGEDATETIME) AS varchar) + '0' + CAST(MONTH(MC.CHARGEDATETIME) AS varchar) 
 ELSE CAST(YEAR(MC.CHARGEDATETIME) AS varchar) + CAST(MONTH(MC.CHARGEDATETIME) AS varchar) END AS ChargeMonth, DAY(MC.CHARGEDATETIME) AS CHARGEDAY
FROM Meter_Charge MC LEFT JOIN Meter_WorkTask MWT  ON MC.TaskID=MWT.TaskID) MT WHERE CHARGEWORKERID='{0}' ", strLogID);

            if (CB_Month.SelectedValue!=null)
            {
                if (!CB_Month.SelectedValue.ToString().Equals(""))
                {
                    sb.AppendFormat(" AND ChargeMonth='{0}'", CB_Month.SelectedValue);
                }
                if (!CB_Day.SelectedValue.ToString().Equals(""))
                {
                    sb.AppendFormat(" AND CHARGEDAY='{0}'", CB_Day.SelectedValue);
                }
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "CHARGEID", "流水号" }, 
                                                           { "CHARGEDATETIME", "收费时间" },
                                                           { "CHARGEBCSS", "本次实收" }, 
                                                           { "CHARGEBCYS", "本次应收" }, 
                                                           { "TOTALCHARGE", "费用合计" }, 
                                                           { "prestore", "账户余额" },
                                                           { "FeeList", "收费明细" },
                                                           { "CHARGETYPE", "收费类型" },
                                                           { "POSRUNNINGNO", "银行单号" },
                                                           { "DAYCHECKSTATES", "日审核状态" },
                                                           { "DAYCHECKDATETIME", "审核时间" },
                                                           { "MONTHCHECKSTATE", "月审核状态" },
                                                           { "MONTHCHECKWORKERNAME", "月审核人" },
                                                           { "MONTHCHECKDATETIME", "审核时间" },
                                                           { "InvoicePrintTime", "发票打印时间" },
                                                           { "InvoiceNO", "发票打印编号" },
                                                           { "CHARGECANCEL", "收费取消标记" }
                                                           
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "CHARGEID", "合计" }, { "CHARGEBCSS", "" }, { "CHARGEBCYS", "" }, { "TOTALCHARGE", "" }, { "prestore", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "CHARGEDATETIME";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void Btn_Settle_Click(object sender, EventArgs e)
        {
            string sqlstr = @"UPDATE Meter_Charge SET DAYCHECKSTATE=1,DAYCHECKDATETIME=GETDATE(),MONTHCHECKWORKERNAME=@LoginID WHERE CHARGEWORKERID=@LoginID AND DAY(CHARGEDATETIME)=@CHARGEDAY
AND MONTHCHECKSTATE<>1 AND (CASE WHEN MONTH(CHARGEDATETIME) < 10 THEN CAST(YEAR(CHARGEDATETIME) AS varchar) + '0' + CAST(MONTH(CHARGEDATETIME) AS varchar) 
 ELSE CAST(YEAR(CHARGEDATETIME) AS varchar) + CAST(MONTH(CHARGEDATETIME) AS varchar) END) =@ChargeMonth ";

            int count = new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@LoginID", strLogID), new SqlParameter("@CHARGEDAY", CB_Day.SelectedValue), new SqlParameter("@ChargeMonth", CB_Month.SelectedValue) });
            if (count>0)
            {
                MessageBox.Show("日结成功！");
                ShowData();
            }
        }

        private void Btn_Settle_Cancel_Click(object sender, EventArgs e)
        {
            string sqlstr = @"UPDATE Meter_Charge SET DAYCHECKSTATE=0,DAYCHECKDATETIME=GETDATE(),MONTHCHECKWORKERNAME=@LoginID WHERE CHARGEWORKERID=@LoginID AND DAY(CHARGEDATETIME)=@CHARGEDAY
AND MONTHCHECKSTATE<>1 AND (CASE WHEN MONTH(CHARGEDATETIME) < 10 THEN CAST(YEAR(CHARGEDATETIME) AS varchar) + '0' + CAST(MONTH(CHARGEDATETIME) AS varchar) 
 ELSE CAST(YEAR(CHARGEDATETIME) AS varchar) + CAST(MONTH(CHARGEDATETIME) AS varchar) END) =@ChargeMonth ";

            int count = new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@LoginID", strLogID), new SqlParameter("@CHARGEDAY", CB_Day.SelectedValue), new SqlParameter("@ChargeMonth", CB_Month.SelectedValue) });
            if (count > 0)
            {
                MessageBox.Show("取消结算成功！");
                ShowData();
            }
        }

        
    }
}

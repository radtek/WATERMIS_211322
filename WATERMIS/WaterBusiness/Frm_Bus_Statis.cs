using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using Common.DotNetUI;

namespace WaterBusiness
{
    public partial class Frm_Bus_Statis : DockContentEx
    {
        public Frm_Bus_Statis()
        {
            InitializeComponent();
        }

        private void Frm_Bus_Statis_Load(object sender, EventArgs e)
        {
        }
      
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            string sqlstr = string.Format(@"DECLARE @StartDate NVARCHAR(50)='{0}'
DECLARE @EndDate Nvarchar(50)='{1}'
SELECT TABLEID AS 编号,Table_Name_CH AS 业务类型
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  PointTime BETWEEN  @StartDate AND @EndDate AND V.STATE IN (1,2,3,4,5)) AS 本月提交
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  PointTime BETWEEN  @StartDate AND @EndDate  AND V.STATE IN (1,2)) AS 本月审批中
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  PointTime BETWEEN  @StartDate AND @EndDate  AND V.STATE =4) AS 作废
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  PointTime BETWEEN  @StartDate AND @EndDate  AND V.STATE =5) AS 本月提交并审批完成
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND PointTime BETWEEN  @StartDate AND @EndDate  AND V.STATE =5) AS 本月所有审批完成
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND PointTime BETWEEN  @StartDate AND @EndDate  AND V.STATE =5 
AND TaskID IN (SELECT TaskID FROM View_ChargeFee WHERE TaskID=convert(uniqueidentifier,V.TaskID))) AS 收费用户
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND PointTime BETWEEN  @StartDate AND @EndDate  AND V.STATE =5 
AND TaskID NOT IN (SELECT TaskID FROM View_ChargeFee WHERE TaskID=convert(uniqueidentifier,V.TaskID))) AS 免费用户数
 FROM View_TaskStat VT
 WHERE PointTime BETWEEN  @StartDate AND @EndDate
GROUP BY Table_Name_CH,TABLEID
", uC_DateSelect1.DayStart, uC_DateSelect1.DayEnd);



                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);

                dgList.DataSource = dt;


        }

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            string strCaption = "部门费用统计";
            ExportExcel ExportExcel = new ExportExcel();
            ExportExcel.ExportToExcel(strCaption, dgList);
        }

      

       
    }
}

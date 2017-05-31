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
    public partial class FrmClassified : DockContentEx
    {
        public FrmClassified()
        {
            InitializeComponent();
        }

        private DataGridView DV;

        private int _Type = 0;

        private void Btn_Export_Click(object sender, EventArgs e)
        {
            if (DV!=null)
            {
                string strCaption = "统计报表";
                ExportExcel ExportExcel = new ExportExcel();
                ExportExcel.ExportToExcel(strCaption, DV);
            }
          
        }

       
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Type = TC.SelectedIndex;
            SearchData();

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void SearchData()
        {
            string sqlstr = string.Empty;
            DataTable dt;
            switch (_Type)
            {
                case 0:
                    sqlstr = string.Format(@"DECLARE @StartDate NVARCHAR(50)='{0}'
DECLARE @EndDate Nvarchar(50)='{1}'
SELECT '单用户报装' AS 业务类型, WU.areaNO AS 片号,WU.duanNO AS 段号,COUNT(1) AS 用户数
  FROM Meter_Install_Single MIS,Meter_WorkTask MW,waterUser WU 
  WHERE MIS.TaskID=MW.TaskID AND MIS.waterUserId=WU.waterUserId AND MW.State=5 AND PointTime BETWEEN  @StartDate AND @EndDate
  GROUP BY WU.areaNO,WU.duanNO
  UNION ALL  
 SELECT '多用户报装', WU.areaNO AS 片号,WU.duanNO AS 段号,COUNT(1) AS 用户数
  FROM Meter_Install_Group MIG,Meter_WorkTask MW,waterUser WU,Meter_Groupeople_Detail MG
  WHERE MIG.TaskID=MW.TaskID AND MIG.GroupID=MG.GroupID AND MG.waterUserId=WU.waterUserId AND MW.State=5 AND PointTime BETWEEN  @StartDate AND @EndDate
  GROUP BY WU.areaNO,WU.duanNO
  UNION ALL
SELECT '违章报装(营业)', WU.areaNO AS 片号,WU.duanNO AS 段号,COUNT(1) AS 用户数
  FROM Meter_Install_Peccant MIS,Meter_WorkTask MW,waterUser WU 
  WHERE MIS.TaskID=MW.TaskID AND MIS.waterUserId=WU.waterUserId AND MW.State=5 AND PointTime BETWEEN  @StartDate AND @EndDate AND PeccantInstallType=1
  GROUP BY WU.areaNO,WU.duanNO
    UNION ALL
SELECT '违章报装(监察)', WU.areaNO AS 片号,WU.duanNO AS 段号,COUNT(1) AS 用户数
  FROM Meter_Install_Peccant MIS,Meter_WorkTask MW,waterUser WU 
  WHERE MIS.TaskID=MW.TaskID AND MIS.waterUserId=WU.waterUserId AND MW.State=5 AND PointTime BETWEEN  @StartDate AND @EndDate AND PeccantInstallType=2
  GROUP BY WU.areaNO,WU.duanNO", uC_DateSelect1.DayStart, uC_DateSelect1.DayEnd);

                    dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                    DV0.DataSource = dt;
                    DV = DV0;
                    break;
                case 1:
                    sqlstr = string.Format(@"DECLARE @StartDate NVARCHAR(50)='{0}'
DECLARE @EndDate Nvarchar(50)='{1}'
  SELECT '销户统计' AS 业务类型, WU.areaNO AS 片号,WU.duanNO AS 段号,COUNT(1) AS 用户数
  FROM User_Unsubscribe U,Meter_WorkTask MW,waterUser WU 
  WHERE U.TaskID=MW.TaskID AND U.WaterUserNO=WU.waterUserId AND MW.State=5 AND PointTime BETWEEN  @StartDate AND @EndDate 
  GROUP BY WU.areaNO,WU.duanNO", uC_DateSelect1.DayStart, uC_DateSelect1.DayEnd);

                    dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                    DV1.DataSource = dt;
                    DV = DV1;
                    break;
                case 2:
                    sqlstr = string.Format(@"DECLARE @StartDate NVARCHAR(50)='{0}'
DECLARE @EndDate Nvarchar(50)='{1}'
  SELECT '停户统计' AS 业务类型, WU.areaNO AS 片号,WU.duanNO AS 段号,COUNT(1) AS 用户数
  FROM Meter_Disuse U,Meter_WorkTask MW,waterUser WU 
  WHERE U.TaskID=MW.TaskID AND U.WaterUserNO=WU.waterUserId AND MW.State=5 AND PointTime BETWEEN  @StartDate AND @EndDate 
  GROUP BY WU.areaNO,WU.duanNO", uC_DateSelect1.DayStart, uC_DateSelect1.DayEnd);

                    dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                    DV2.DataSource = dt;
                    DV = DV2;
                    break;
                case 3:
                    sqlstr = string.Format(@"DECLARE @StartDate NVARCHAR(50)='{0}'
DECLARE @EndDate Nvarchar(50)='{1}'
   SELECT '恢复统计' AS 业务类型, WU.areaNO AS 片号,WU.duanNO AS 段号,COUNT(1) AS 用户数
  FROM Meter_Desterilize U,Meter_WorkTask MW,waterUser WU 
  WHERE U.TaskID=MW.TaskID AND U.WaterUserNO=WU.waterUserId AND MW.State=5 AND PointTime BETWEEN  @StartDate AND @EndDate 
  GROUP BY WU.areaNO,WU.duanNO", uC_DateSelect1.DayStart, uC_DateSelect1.DayEnd);

                    dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                    DV3.DataSource = dt;
                    DV = DV3;
                    break;
            }
             
        }

    }
}

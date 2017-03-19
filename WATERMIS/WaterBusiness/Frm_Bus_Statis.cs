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
            Init();
        }
        public void Init()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateMonth,CreateMonth AS CMonth FROM View_TaskStat ORDER BY CreateMonth DESC ");
            ControlBindHelper.BindComboBoxData(this.CB_Month, dt, "CMonth", "CreateMonth");

        }
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CB_Month.Text))
            {
//                string sqlstr = string.Format(@"DECLARE @CMONTH NVARCHAR(50)='201701'
//SELECT Table_Name_CH,TABLEID
//,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  CreateMonth =@CMONTH AND V.STATE IN (1,2,3,4,5)) AS SUBMIT
//,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  CreateMonth =@CMONTH  AND V.STATE IN (1,2)) AS ING
//,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  CreateMonth =@CMONTH  AND V.STATE =4) AS SCRAP
//,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  CreateMonth =@CMONTH  AND V.STATE =5) AS TOVER
//,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  OverMonth =@CMONTH  AND V.STATE =5) AS TALLOVER
// FROM View_TaskStat VT
// WHERE CreateMonth =@CMONTH
//GROUP BY Table_Name_CH,TABLEID", CB_Month.Text.Trim());
                string sqlstr = string.Format(@"SELECT Table_Name_CH,TABLEID
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  CreateMonth ='{0}' AND V.STATE IN (1,2,3,4,5)) AS SUBMIT
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  CreateMonth ='{0}'  AND V.STATE IN (1,2)) AS ING
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  CreateMonth ='{0}'  AND V.STATE =4) AS SCRAP
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  CreateMonth ='{0}'  AND V.STATE =5) AS TOVER
,(SELECT COUNT(1) FROM View_TaskStat V WHERE TABLEID = VT.TABLEID AND  OverMonth ='{0}'  AND V.STATE =5) AS TALLOVER
 FROM View_TaskStat VT
 WHERE CreateMonth ='{0}'
GROUP BY Table_Name_CH,TABLEID", CB_Month.Text.Trim());
                uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "SUBMIT", "本月提交" }, 
                                                           { "ING", "本月未完成" }, 
                                                           { "SCRAP", "本月作废" }, 
                                                           { "TOVER", "本月提交并审批完成" } ,
                                                           { "TALLOVER", "本月所有审批完成" } 
                                                           
            };
                uC_DataGridView_Page1.SqlString = sqlstr;
                uC_DataGridView_Page1.PageOrderField = "TABLEID";
                uC_DataGridView_Page1.PageIndex = 1;
                uC_DataGridView_Page1.Init();
            }


        }

      

       
    }
}

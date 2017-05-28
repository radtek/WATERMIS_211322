using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;
using System.Data.SqlClient;

namespace MeterInstall
{
    public partial class FrmRecords : Form
    {
        private IMeter_Install_Single sysidal = new Meter_Install_Single();

        public FrmRecords()
        {
            InitializeComponent();
        }
        private void FrmRecords_Load(object sender, EventArgs e)
        {
        }

        private void uC_DataGridView_Page1_CellClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                string taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                uC_FlowList1.TaskId = taskid;
                uC_FlowList1.DataBind();

            }
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                FrmSingle frm = new FrmSingle();
                frm.key = dgList.CurrentRow.Cells["SingleID"].Value.ToString();
                frm.state = dgList.CurrentRow.Cells["State"].Value.ToString();
                frm.taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    uC_SearchBase1_BtnEvent(null, null);
                }
            }
        }

      

        private void uC_SearchBase1_Load(object sender, EventArgs e)
        {
            uC_SearchBase1.WorkCode = "Meter_Install_Single";
            uC_SearchBase1.PkName = new string[] { "AcceptID", "waterUserName", "ApplyUser", "waterUserNO", "waterPhone", "waterUserAddress", "Memo" };
            uC_SearchBase1.Init();
        }

        private void uC_SearchBase1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM (SELECT MIS.TaskID,SingleID,AcceptID,waterUserName,ApplyUser,waterPhone,MIS.waterUserTypeId,WT.waterUserTypeName,WUH.waterUserHouseType,
CASE IsBoost WHEN '1' THEN '√' ELSE '' END AS IsBoost,waterUserPeopleCount,QueryKey,MW.[State],MWS.Value as FlowState,MW.PointSort,MIS.loginId,
SubmitDate,waterUserAddress,MIS.Memo,CreateDate,MIS.waterUserNO 
FROM Meter_Install_Single MIS left join  waterUserType WT 
on MIS.waterUserTypeId=WT.waterUserTypeId left join waterUserHouseType WUH 
on mis.waterUserHouseType=WUH.waterUserHouseTypeID left join Meter_WorkTaskState MWS on MIS.State=MWS.ID 
left join Meter_WorkTask MW on MIS.TaskID=MW.TaskID) M ";

            if (!string.IsNullOrEmpty(uC_SearchBase1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchBase1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "waterUserTypeName", "用户类型" } ,
                                                           { "waterUserHouseType", "房屋类型" } ,
                                                           { "IsBoost", "是否加压" }, 
                                                           { "waterUserPeopleCount", "用水人数" } ,
                                                           { "QueryKey", "查询密码" }, 
                                                           { "FlowState", "状态" } ,
                                                           { "SubmitDate", "申请时间" },
                                                           { "waterUserAddress", "地址" }, 
                                                           { "Memo", "备注" }   
            };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

       
    }
}

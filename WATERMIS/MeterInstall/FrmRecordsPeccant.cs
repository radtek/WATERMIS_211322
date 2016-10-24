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
    public partial class FrmRecordsPeccant : Form
    {
        private IMeter_Install_Peccant sysdal = new Meter_Install_Peccant();

        public FrmRecordsPeccant()
        {
            InitializeComponent();
        }
        private void FrmRecords_Load(object sender, EventArgs e)
        {
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM (SELECT TaskID,SingleID,AcceptID,waterUserName,ApplyUser,waterPhone,MIS.waterUserTypeId,WT.waterUserTypeName,
WUH.waterUserHouseType,waterUserPeopleCount,QueryKey,[State],PeccantMemo,MWS.Value as FlowState,SubmitDate,waterUserAddress,MIS.Memo,CreateDate,
(CASE PeccantInstallType WHEN '1' THEN '营业入口' ELSE '监察入口' END) AS PeccantInstallType
FROM Meter_Install_Peccant MIS left join  waterUserType WT on MIS.waterUserTypeId=WT.waterUserTypeId left join waterUserHouseType WUH 
on mis.waterUserHouseType=WUH.waterUserHouseTypeID left join Meter_WorkTaskState MWS on MIS.State=MWS.ID) M ";

            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "waterUserTypeName", "用户类型" } ,
                                                           { "waterUserHouseType", "户型" } ,
                                                           { "waterUserPeopleCount", "用水人数" } ,
                                                           { "QueryKey", "查询密码" }, 
                                                           { "FlowState", "状态" } ,
                                                           { "SubmitDate", "申请时间" },
                                                           { "waterUserAddress", "地址" }, 
                                                           { "PeccantMemo", "违章说明" },  
                                                           { "PeccantInstallType", "入口类型" }  
            };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
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
                object objPeccantInstallType = dgList.CurrentRow.Cells["PeccantInstallType"].Value;
                if(objPeccantInstallType!=null&&objPeccantInstallType!=DBNull.Value)
                    if (objPeccantInstallType.ToString() == "营业入口")
                    {
                        FrmPeccantYY frm = new FrmPeccantYY();
                        frm.key = dgList.CurrentRow.Cells["SingleID"].Value.ToString();
                        frm.state = dgList.CurrentRow.Cells["State"].Value.ToString();
                        frm.taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            uC_SearchModule1_BtnEvent(null, null);
                        }
                    }
                    else
                    {
                        FrmPeccantJC frm = new FrmPeccantJC();
                        frm.key = dgList.CurrentRow.Cells["SingleID"].Value.ToString();
                        frm.state = dgList.CurrentRow.Cells["State"].Value.ToString();
                        frm.taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            uC_SearchModule1_BtnEvent(null, null);
                        }
                    }
            }
        }

       
    }
}

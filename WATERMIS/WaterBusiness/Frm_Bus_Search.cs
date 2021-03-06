using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using Common.DotNetUI;
using System.Data.SqlClient;

namespace WaterBusiness
{
    public partial class Frm_Bus_Search : DockContentEx
    {
        private StringBuilder sb = new StringBuilder();
        private string[] PkName = new string[] { "AcceptID", "waterUserName", "waterUserId", "waterPhone", "waterUserAddress" }; 
        public Frm_Bus_Search()
        {
            InitializeComponent();
        }

        private void Frm_Bus_Search_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT VT.loginId,B.userName FROM View_TABLEUNION VT,base_login B WHERE VT.loginId=B.loginId AND VT.State<>4 ORDER BY VT.loginId");
            ControlBindHelper.BindComboBoxData(this.CB_loginId, dt, "userName", "loginId", true);

            DataTable dt2 = new SqlServerHelper().GetDataTable("Meter_WorkTaskState", "[ID] <>0", "ID");
            ControlBindHelper.BindComboBoxData(this.CB_State, dt2, "Value", "ID", true);


            string sqlstr = "SELECT DISTINCT TableName,Table_Name_CH FROM View_TABLEUNION";
            DataTable dt3 = new SqlServerHelper().GetDateTableBySql(sqlstr);

            ControlBindHelper.BindComboBoxData(this.CB_TableName, dt3, "Table_Name_CH", "TableName", true);
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

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            
            sb.Length = 0;
            DateTime dt1;
            DateTime dt2;
            string sqlwhere = "";
            if (CHK_waterMeterProofreadingDate.Checked)
            {
                if (!DateTime.TryParse(DT_waterMeterProofreadingDate_1.Text, out dt1))
                {
                    MessageBox.Show("请重新选择鉴定日期！");
                    return;
                }
                if (!DateTime.TryParse(DT_waterMeterProofreadingDate_2.Text, out dt2))
                {
                    MessageBox.Show("请重新选择鉴定日期！");
                    return;
                }
                if (dt2 < dt1)
                {
                    MessageBox.Show("请重新选择鉴定日期！");
                    return;
                }
                else
                {
                    dt2 = dt2.AddDays(1);
                    sb.AppendFormat(" CreateDate >'{0}' and CreateDate < '{1}'", dt1, dt2);
                }

                if (new SqlServerHelper().GetSqlWhereByControlCombox(this.GB1.Controls, ref sqlwhere))
                {
                    sb.Append(sqlwhere);
                }
            }
            else
            {
                if (new SqlServerHelper().GetSqlWhereByControlCombox(this.GB1.Controls, ref sqlwhere))
                {
                    sb.Append(" 1=1 ");
                    sb.Append(sqlwhere);
                }
            }

            if (!string.IsNullOrEmpty(TB_SearchKey.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(sb.ToString().Trim()))
                {
                    sb.Append("AND ");
                }
                sb.Append(" (");
                for (int i = 0; i < PkName.Length - 1; i++)
                {
                    sb.AppendFormat("{0} LIKE '%{1}%' ", PkName[i], TB_SearchKey.Text.Trim());
                    if (i < (PkName.Length - 2))
                    {
                        sb.Append(" OR ");
                    }
                }
                sb.Append(" )");
            }
           
            string sqlstr = @"SELECT * FROM
(SELECT V.*,L.userName,W.Value AS FlowState 
FROM  View_TABLEUNION V  LEFT JOIN V_LOGIN L ON V.LOGINID=L.loginId,Meter_WorkTaskState W 
WHERE V.State=W.ID) M";

            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                sqlstr += " WHERE " + sb.ToString();
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "waterUserAddress", "地址" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "Table_Name_CH", "报装类型" } ,
                                                           { "userName", "受理人" } ,
                                                           { "FlowState", "状态" } ,
                                                           { "CreateDate", "创建时间" }
            };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();

        }

        private void DT_waterMeterProofreadingDate_2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1;
            DateTime dt2;
            if (!DateTime.TryParse(DT_waterMeterProofreadingDate_1.Text, out dt1))
            {
                return;
            }
            if (!DateTime.TryParse(DT_waterMeterProofreadingDate_2.Text, out dt2))
            {
                return;
            }
            if (dt2 < dt1)
            {
                DT_waterMeterProofreadingDate_2.Text = DT_waterMeterProofreadingDate_1.Text;
            }
        }

       
    }
}

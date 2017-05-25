using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using BASEFUNCTION;

namespace WorkFlow
{
    public partial class FrmApproveLog : DockContentEx
    {
        public FrmApproveLog()
        {
            InitializeComponent();
        }

        private void FrmApproveLog_Load(object sender, EventArgs e)
        {
            Init();
        }

        public void Init()
        {
            BindTask();
            BindUser();
            BindState();
        }

        private void BindState()
        {
            string sqlstr_Task = "SELECT DISTINCT State,CASE STATE WHEN 1 THEN '审批中' WHEN 2 THEN '挂起' WHEN 3 THEN '跳转' WHEN 4 THEN '作废' WHEN 5 THEN '结束' ELSE '未知' END AS STATES  FROM ApproveLog";

            DataTable dt2 = new SqlServerHelper().GetDateTableBySql(sqlstr_Task);
            ControlBindHelper.BindComboBoxData(this.CB_State, dt2, "STATES", "State", true);
        }

        private void BindUser()
        {
            string sqlstr_Task = "SELECT DISTINCT userName,loginId  FROM ApproveLog";

            DataTable dt2 = new SqlServerHelper().GetDateTableBySql(sqlstr_Task);
            ControlBindHelper.BindComboBoxData(this.CB_loginId, dt2, "userName", "loginId", true);
        }

        private void BindTask()
        {
            string sqlstr_Task = "SELECT DISTINCT Table_Name_CH,TableID FROM View_TABLEUNION ORDER BY TableID";

            DataTable dt2 = new SqlServerHelper().GetDateTableBySql(sqlstr_Task);
            ControlBindHelper.BindComboBoxData(this.CB_TaskCode, dt2, "Table_Name_CH", "TableID", true);
        }

        private StringBuilder sb = new StringBuilder();   

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            sb.Length = 0;
            DateTime dt1;
            DateTime dt2;
            sb.Append("SELECT A.*,V.waterUserName,V.waterUserAddress,V.waterPhone,V.SD,V.Table_Name_CH,V.waterUserId,CASE A.STATE WHEN 1 THEN '审批中' WHEN 2 THEN '挂起' WHEN 3 THEN '跳转' WHEN 4 THEN '作废' WHEN 5 THEN '结束' ELSE '未知' END AS STATES FROM ApproveLog A LEFT JOIN View_TABLEUNION V ON A.TaskID=V.TaskID WHERE 1=1 ");
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
                    sb.AppendFormat(" AND A.CreateDate >'{0}' and A.CreateDate < '{1}'", dt1, dt2);
                }
                
            }

            if (!string.IsNullOrEmpty(CB_TaskCode.SelectedValue.ToString()))
            {
                sb.AppendFormat(" AND V.TableID='{0}'", CB_TaskCode.SelectedValue);
            }
            if (!string.IsNullOrEmpty(CB_loginId.SelectedValue.ToString()))
            {
                sb.AppendFormat(" AND A.loginId='{0}'", CB_loginId.SelectedValue);
            }
            if (!string.IsNullOrEmpty(CB_State.SelectedValue.ToString()))
            {
                sb.AppendFormat(" AND A.State='{0}'", CB_State.SelectedValue);
            }

            if (!string.IsNullOrEmpty(TB_Keys.Text))
            {
                sb.AppendFormat(" AND (userName LIKE '%{0}%' OR waterUserName LIKE '%{0}%' OR waterUserAddress LIKE '%{0}%' OR waterPhone LIKE '%{0}%' OR SD LIKE '%{0}%' )", TB_Keys.Text);
            }


            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                { "SD", "流水号" }, 
                  { "userName", "审批人" },
                     { "CreateDate", "审批时间" },
                     { "UserOpinion", "审批意见" },
                       { "STATES", "状态" }, 
                                                           { "waterUserId", "户号" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "Table_Name_CH", "任务类型" },
                                                            { "waterPhone", "联系电话" },
                                                              { "waterUserAddress", "地址" },
                                                           { "PointSort", "节点" }, 
                                                           { "Matter", "备注" }
                                                          
            };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();

            

            
        }

       
    }
}

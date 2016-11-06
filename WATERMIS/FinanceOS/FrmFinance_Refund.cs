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

namespace FinanceOS
{
    public partial class FrmFinance_Refund : Form
    {
        private Finance_IDAL fdal = new Finance_Dal();
        private int _ReType = 1;

        public FrmFinance_Refund()
        {
            InitializeComponent();
        }

        private void FrmFinance_Refund_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            ControlBindHelper.BindComboBoxData(this.CB_ID, fdal.GetTableList(), "Table_Name_CH", "TableID", true);
            ShowData();
        }

        private void RB_Type1_CheckedChanged(object sender, EventArgs e)
        {
            _ReType = 1;
        }

        private void RB_Type2_CheckedChanged(object sender, EventArgs e)
        {
            _ReType = 2;
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            switch (_ReType)
            {
                case 1://收费退款
                    Refund1();
                    break;
                case 2://作废退款
                    Refund2();
                    break;
                default:
                    Refund1();
                    break;
            }
        }

        private void Refund2()
        {
            
        }

        private void Refund1()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT MT.Table_Name_CH,VW.SD,VW.waterUserId,VW.waterUserName,VW.ApplyUser,VT.FEE,VW.waterPhone,VT.CreateDate,VT.PointTime,VW.TableID,VT.TaskID,VT.STATES,VW.ID,VT.ChargeID,VT.CHARGEWORKERNAME,VT.ChargeDate,VT.IsFinal,(CASE WHEN VT.IsFinal=1 THEN '预算' ELSE '决算' END) AS IsFinalS,VT.DepartementID,BD.departmentName
FROM View_TaskFee VT  LEFT JOIN View_WorkBase VW ON VT.TaskID=VW.TASKID,Meter_Table MT , base_department BD  WHERE VW.TableID=MT.TableID AND  VT.DepartementID=BD.departmentID AND VW.[State] IN (1,2,5) AND VT.States=1");

            sb.Append(" AND VT.States=0 ");

            if (!CB_ID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VW.TableID='{0}'", CB_ID.SelectedValue);
            }

            if (!TB_Keys.Text.Equals(""))
            {
                sb.AppendFormat(" AND (waterUserName LIKE '%{0}%' OR ApplyUser LIKE '%{0}%' OR waterPhone LIKE '%{0}%' OR waterUserId LIKE '%{0}%' OR SD LIKE '%{0}%')", TB_Keys.Text.Trim());
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "waterUserId", "用户ID" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "FEE", "应收合计" },
                                                           { "ApplyPhone", "联系电话" },
                                                           { "CreateDate", "申请时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "Table_Name_CH", "合计" }, { "FEE", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "PointTime";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_DataGridView_Page1_CellClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                string taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                if (!string.IsNullOrEmpty(taskid))
                {
                    uC_FlowList1.TaskId = taskid;
                    uC_FlowList1.DataBind();
                }
            }
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using DBinterface.IDAL;
using Common.DotNetUI;

namespace FinanceOS
{
    public partial class FrmFinance_Receipted : Form
    {
        private Finance_IDAL fdal = new Finance_Dal();
        private string _IsFinal = "1";

        public FrmFinance_Receipted()
        {
            InitializeComponent();
            cmbChargeType.SelectedIndex = 0;
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            
            if (dgList.CurrentRow != null)
            {
                string _ChargeID = dgList.CurrentRow.Cells["ChargeID"].Value.ToString();
                if (_ChargeID.Contains("合计"))
                    return;
                //string _Loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                //string _ChargerID = dgList.CurrentRow.Cells["CHARGEWORKERID"].Value.ToString();
                //if (_Loginid.Equals(_ChargerID))
                //{
                FrmFinance_Cancel frm = new FrmFinance_Cancel();
                frm.ChargeID = _ChargeID;
                frm.TaskID = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                frm.ChargerID=dgList.CurrentRow.Cells["CHARGEWORKERID"].Value.ToString();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ShowData();
                }

                //}
            }
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

        private void FrmFinance_Receipted_Shown(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataTable dt = new SqlServerHelper().GetDataTable("base_department", "departmentID<>'01'", "departmentID");
            ControlBindHelper.BindComboBoxData(this.CB_DepartementID, dt, "departmentName", "departmentID", true);

            ControlBindHelper.BindComboBoxData(this.CB_ID, fdal.GetTableList(), "Table_Name_CH", "TableID", true);

            ControlBindHelper.BindComboBoxData(this.CB_Month, fdal.GetChargeMonth(), "CreateMonthVALUE", "CreateMonth", true);

            ControlBindHelper.BindComboBoxData(this.CB_Day, fdal.GetChargeDay(), "CreateDayVALUE", "CreateDay", true);
            //AND VW.[State] IN (1,2,5)
            string sqlstr = @"SELECT DISTINCT VT.CHARGEWORKERID,CHARGEWORKERNAME
FROM View_TaskFee VT  LEFT JOIN View_WorkBase VW ON VT.TaskID=VW.TASKID,Meter_Table MT WHERE VW.TableID=MT.TableID AND VT.States=1 ";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            ControlBindHelper.BindComboBoxData(this.CHARGEWORKERID, dt, "CHARGEWORKERNAME", "CHARGEWORKERID", true);

            ShowData();
        }

        private void ShowData()
        {
            //AND VW.[State] IN (1,2,5)
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT VT.*,MC.CHARGEBCSS FROM View_TaskChargeList VT INNER JOIN Meter_Charge MC ON MC.CHARGEID=VT.ChargeID  WHERE MC.CHARGEBCSS<>0 AND VT.States=1");

            if (!CB_ID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.TableID='{0}'", CB_ID.SelectedValue);
            }
            if (!CB_Month.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.CreateMonth='{0}'", CB_Month.SelectedValue);
            }
            if (!CB_Day.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.CreateDay='{0}'", CB_Day.SelectedValue);
            }
            if (!TB_Keys.Text.Equals(""))
            {
                sb.AppendFormat(" AND (waterUserName LIKE '%{0}%' OR ApplyUser LIKE '%{0}%' OR waterPhone LIKE '%{0}%' OR waterUserId LIKE '%{0}%' OR SD LIKE '%{0}%' )", TB_Keys.Text.Trim());
            }
            if (!CHARGEWORKERID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.CHARGEWORKERID='{0}'", CHARGEWORKERID.SelectedValue);
            }
            if (!CB_DepartementID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VT.DepartementID='{0}'", CB_DepartementID.SelectedValue);
            }

            if (cmbChargeType.SelectedIndex>0)
            {
                sb.AppendFormat(" AND VT.IsFinal='{0}'", cmbChargeType.SelectedIndex-1);
            }


            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "ChargeID", "收费流水号" }, 
                                                           { "ChargeDate", "收费时间" }, 
                                                           { "CHARGEWORKERNAME", "收费员" }, 
                                                           { "CHARGEBCSS", "收费金额" },
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "departmentName", "部门" }, 
                                                           { "IsFinalS", "结算类型" }, 
                                                           { "SD", "业务流水号" }, 
                                                           { "waterUserId", "用户ID" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "waterUserAddress", "地址" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "ApplyPhone", "联系电话" },
                                                           { "CreateDate", "申请时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "ChargeID", "合计" }, { "CHARGEBCSS", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "ChargeDate";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }
    }
}

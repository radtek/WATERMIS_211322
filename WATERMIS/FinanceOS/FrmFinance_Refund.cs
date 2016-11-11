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
        private int _ReType = 2;

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

        private void Refund1()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"SELECT * FROM Meter_Charge WHERE CHARGEID IN
(SELECT DISTINCT MWF.ChargeID FROM Meter_WorkTask MW,Meter_WorkResolve MWR,Meter_WorkResolveFee MWF 
WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort AND MWR.ResolveID=MWF.ResolveID
AND MW.[State]=1 AND MWF.[State]=1 AND ISNULL(MWF.ChargeID,'')<>N'') AND CHARGEWORKERID='{0}' ", AppDomain.CurrentDomain.GetData("LOGINID").ToString());

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "CHARGEID", "收费流水号" }, 
                                                           { "CHARGEBCSS", "本次实收" }, 
                                                           { "CHARGEBCYS", "本次应收" }, 
                                                           { "TOTALCHARGE", "费用合计" }, 
                                                           { "FeeList", "收费明细" },
                                                           { "CHARGEDATETIME", "收费时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "CHARGEID", "合计" }, { "TOTALCHARGE", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "CHARGEDATETIME";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void Refund2()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT * FROM View_WorkBase VW WHERE VW.prestore>0 AND VW.[State]=4");

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
                                                           { "prestore", "账户余额" },
                                                           { "waterPhone", "联系电话" },
                                                           { "CreateDate", "申请时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "Table_Name_CH", "合计" }, { "prestore", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
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
             DataGridView dgList = (DataGridView)sender;
             if (dgList.CurrentRow != null)
             {
                 switch (_ReType)
                 {
                     case 1://收费退款
                         FrmFinance_RefundShow1 frm = new FrmFinance_RefundShow1();
                         if (frm.ShowDialog() == DialogResult.OK)
                         {
                             Refund1();
                         }
                         break;
                     case 2://作废退款
                         FrmFinance_RefundShow2 frm2 = new FrmFinance_RefundShow2();
                         frm2.TaskID = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                         if (frm2.ShowDialog() == DialogResult.OK)
                         {
                             Refund2();
                         }

                         break;
                     default:
                         break;
                 }
             }
        }

    }
}

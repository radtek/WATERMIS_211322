using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using DBinterface.IDAL;
using DBinterface.DAL;
using BLL;
using BASEFUNCTION;

namespace FinanceOS
{
    public partial class FrmFinance_Invoice_Print : Form
    {
        private Finance_IDAL fdal = new Finance_Dal();

        public FrmFinance_Invoice_Print()
        {
            InitializeComponent();
        }
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();
        Messages mes = new Messages();

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLoginID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strLoginName = "";

        /// <summary>
        /// 登陆用户所属组ID
        /// </summary>
        private string strGroupID = "";

        /// <summary>
        /// 公司名称
        /// </summary>
        private string strCompanyName = "";

        /// <summary>
        /// 公司纳税人识别号
        /// </summary>
        private string strCompanyTaxNO = "";

        /// <summary>
        /// 公司地址和电话
        /// </summary>
        private string strCompanyAddressAndTel = "";

        /// <summary>
        /// 收款人
        /// </summary>
        public string strCompanyPayee = "";

        /// <summary>
        /// 复核人
        /// </summary>
        public string strCompanyChecker = "";

        /// <summary>
        /// 开户行及账号
        /// </summary>
        private string strCompanyBankNameAndAccountNO = "";
        private void FrmFinance_Invoice_Print_Load(object sender, EventArgs e)
        {
            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLoginID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strLoginName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindData();
            GetCompanyFPMes();
        }
        /// <summary>
        /// 获取公司开票信息
        /// </summary>
        private void GetCompanyFPMes()
        {
            DataTable dtCompany = BLLBASE_DEPARTMENT.QueryDep(" AND departmentID='01'");
            if (dtCompany.Rows.Count > 0)
            {
                object objCompany = dtCompany.Rows[0]["departmentName"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyName = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["FPAddressAndTel"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyAddressAndTel = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["FPTaxNO"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyTaxNO = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["FPBankNameAndAccountNO"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyBankNameAndAccountNO = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["Payee"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyPayee = objCompany.ToString();

                objCompany = dtCompany.Rows[0]["Checker"];
                if (objCompany != null && objCompany != DBNull.Value)
                    strCompanyChecker = objCompany.ToString();
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        private void BindData()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql(@"SELECT DISTINCT Meter_Table.TableID,Meter_Table.Table_Name_CH FROM View_WorkBase,Meter_Table WHERE View_WorkBase.TableID=Meter_Table.TableID AND View_WorkBase.[State]=5
AND TaskID IN (SELECT TaskID FROM View_TaskFee WHERE StateS=1 AND IsFinal=0 AND [State]=5)");
            ControlBindHelper.BindComboBoxData(this.CB_ID, dt, "Table_Name_CH", "TableID", true);
            dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT CreateMonth,CreateMonth AS CreateMonthVALUE FROM View_TaskFee WHERE StateS=1 AND IsFinal=0 AND [State]=5");
            ControlBindHelper.BindComboBoxData(this.CB_Month, dt, "CreateMonthVALUE", "CreateMonth", true);

            ShowData();
        }

        private void ShowData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT     SUM(MWF.Fee) AS FEE, MWK.TaskID, MWF.State AS StateS, MWK.PointTime, MWK.AcceptDate AS CreateDate, MWF.CHARGEWORKERID, MWF.CHARGEWORKERNAME, MWF.ChargeDate, 
                      MWF.ChargeID, DAY(MWK.AcceptDate) AS CreateDay, CASE WHEN MONTH(MWK.AcceptDate) < 10 THEN CAST(YEAR(MWK.AcceptDate) AS varchar) + '0' + CAST(MONTH(MWK.AcceptDate) 
                      AS varchar) ELSE CAST(YEAR(MWK.AcceptDate) AS varchar) + CAST(MONTH(MWK.AcceptDate) AS varchar) END AS CreateMonth, DAY(MWF.ChargeDate) AS ChargeDay, 
                      CASE WHEN MONTH(MWF.ChargeDate) < 10 THEN CAST(YEAR(MWF.ChargeDate) AS varchar) + '0' + CAST(MONTH(MWF.ChargeDate) AS varchar) ELSE CAST(YEAR(MWF.ChargeDate) AS varchar) 
                      + CAST(MONTH(MWF.ChargeDate) AS varchar) END AS ChargeMonth, MWF.IsFinal, MWR.DepartementID, MWK.State,(SELECT departmentName FROM base_department WHERE departmentID=  MWR.DepartementID) AS DepartementName,
VW.ID,VW.SD,VW.waterUserId,VW.waterUserName,VW.waterUserAddress,VW.waterPhone,VW.TableName,VW.Table_Name_CH 
FROM         dbo.Meter_WorkTask AS MWK LEFT JOIN View_WorkBase VW ON MWK.TaskID=VW.TaskID INNER JOIN
                      dbo.Meter_WorkResolve AS MWR ON MWK.TaskID = MWR.TaskID AND MWK.PointSort > MWR.PointSort INNER JOIN
                      dbo.Meter_WorkResolveFee AS MWF ON MWR.ResolveID = MWF.ResolveID,Meter_Charge MC
WHERE     (MWR.YS = 1) AND (MWF.Fee <> 0) AND (MWK.State =5) AND (MWF.IsFinal = 0) 
AND MWF.FeeID NOT IN (SELECT FeeID FROM Meter_FeeItmes WHERE IsPrestore=1) AND MWF.ChargeID=MC.CHARGEID AND ISNULL(MC.INVOICEPRINTSIGN,'')<>1
GROUP BY MWK.TaskID, MWF.State, MWK.PointTime, MWK.AcceptDate, MWF.CHARGEWORKERID, MWF.CHARGEWORKERNAME, MWF.ChargeDate, MWF.ChargeID, MWF.IsFinal, MWR.DepartementID, 
                      MWK.State,VW.ID,VW.SD,VW.waterUserId,VW.waterUserName,VW.waterUserAddress,VW.waterPhone,VW.TableName,VW.Table_Name_CH ");

            if (!CB_ID.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VW.TableID='{0}'", CB_ID.SelectedValue);
            }
            if (!CB_Month.SelectedValue.ToString().Equals(""))
            {
                sb.AppendFormat(" AND VF.ChargeMonth='{0}'", CB_Month.SelectedValue);
            }
          
            if (!TB_Keys.Text.Equals(""))
            {
                sb.AppendFormat(" AND (VW.waterUserName LIKE '%{0}%' OR VW.waterUserId LIKE '%{0}%' OR VW.SD LIKE '%{0}%')", TB_Keys.Text.Trim());
            }

            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "Table_Name_CH", "业务类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "waterUserId", "用户ID" }, 
                                                           { "waterUserName", "户名" }, 
                                                           { "waterUserAddress", "地址" }, 
                                                           { "waterPhone", "联系方式" }, 
                                                           { "ApplyUser", "申请人" },
                                                           { "FEE", "费用合计" },
                                                           { "CHARGEWORKERNAME", "收费员" },
                                                           { "ChargeDate", "收费时间" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "Table_Name_CH", "合计" }, { "FEE", "" } };
            uC_DataGridView_Page1.SqlString = sb.ToString();
            uC_DataGridView_Page1.PageOrderField = "ChargeDate";
            uC_DataGridView_Page1.PageOrderType = "DESC";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_DataGridView_Page1_CellClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dgList = (DataGridView)sender;
            //if (dgList.CurrentRow != null)
            //{
            //    string taskid = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
            //    if (!string.IsNullOrEmpty(taskid))
            //    {
            //        uC_FlowList1.TaskId = taskid;
            //        uC_FlowList1.DataBind();
            //    }
            //}
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                string strWaterUserID = "", strWaterUserName = "", strWaterUserAddress = "", strWaterUserTel = "",
                    strWaterUserFPTaxNO = "", strWaterUserFPBankNameAndAccountNO = "", strChargeID = "", 
                    strTable_Name_CH = "",strFeeDepID="",strFeeDepName="";
                
                object obj = dgList.CurrentRow.Cells["waterUserName"].Value;
                if (obj != null && obj != DBNull.Value)
                    strWaterUserName=obj.ToString();
                
                obj = dgList.CurrentRow.Cells["waterUserAddress"].Value;
                if (obj != null && obj != DBNull.Value)
                    strWaterUserAddress=obj.ToString();
                
                obj = dgList.CurrentRow.Cells["waterPhone"].Value;
                if (obj != null && obj != DBNull.Value)
                    strWaterUserTel=obj.ToString();

                obj = dgList.CurrentRow.Cells["waterUserId"].Value;
                if (obj != null && obj != DBNull.Value&&obj.ToString()!="")
                {
                    strWaterUserID = obj.ToString();
                    DataTable dt = BLLwaterUser.QueryUser(" AND WATERUSERID='" + strWaterUserID+"'");
                    if (dt.Rows.Count > 0)
                    {
                        //单位用户报装怎么获取纳税人识别号及开户行信息

                        object objFP = dt.Rows[0]["FPTaxNO"];
                        if (objFP != null && objFP != DBNull.Value)
                            strWaterUserFPTaxNO = objFP.ToString();

                        objFP = dt.Rows[0]["FPBankNameAndAccountNO"];
                        if (objFP != null && objFP != DBNull.Value)
                            strWaterUserFPBankNameAndAccountNO = objFP.ToString();
                    }
                }

                obj = dgList.CurrentRow.Cells["Table_Name_CH"].Value;
                if (obj != null && obj != DBNull.Value)
                    strTable_Name_CH = obj.ToString();

                obj = dgList.CurrentRow.Cells["DepartementID"].Value;
                if (obj != null && obj != DBNull.Value)
                    strFeeDepID = obj.ToString();

                obj = dgList.CurrentRow.Cells["DepartementName"].Value;
                if (obj != null && obj != DBNull.Value)
                    strFeeDepName = obj.ToString();

                obj = dgList.CurrentRow.Cells["ChargeID"].Value;
                if (obj != null && obj != DBNull.Value && obj.ToString() != "")
                {
                    strChargeID = obj.ToString();
                    string strGetSQL = @"SELECT * FROM Meter_WorkResolveFee A INNER JOIN Meter_FeeItmes B
                                    ON  A.FeeID=B.FeeID AND IsPrestore<>'1' AND ChargeID='"+strChargeID+"'";

                    //获取待打发票明细
                    DataTable dtFeeDetail = new SqlServerHelper().GetDateTableBySql(strGetSQL);
                    FrmFinance_Invoice_PrintShow frm = new FrmFinance_Invoice_PrintShow();
                    frm.ChargeID = strChargeID;
                    frm.strLoginID = this.strLoginID;
                    frm.strLoginName = this.strLoginName;

                    frm.strCompanyName = this.strCompanyName;
                    frm.strCompanyTaxNO = this.strCompanyTaxNO;
                    frm.strCompanyAddressAndTel = this.strCompanyAddressAndTel;
                    frm.strCompanyBankNameAndAccountNO = this.strCompanyBankNameAndAccountNO;
                    frm.strCompanyPayee = this.strCompanyPayee;
                    frm.strCompanyChecker = this.strCompanyChecker;

                    frm.strWaterUserID = strWaterUserID;
                    frm.strWaterUserName = strWaterUserName;
                    frm.strWaterUserAddress = strWaterUserAddress;
                    frm.strWaterUserTel = strWaterUserTel;
                    frm.strWaterUserFPTaxNO = strWaterUserFPTaxNO;
                    frm.strWaterUserFPBankNameAndAccountNO = strWaterUserFPBankNameAndAccountNO;

                    frm.strTable_Name_CH = strTable_Name_CH;
                    frm.strFeeDepID = strFeeDepID;
                    frm.strFeeDepName = strFeeDepName;


                    frm.dtFPDetail = dtFeeDetail;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ShowData();
                    }
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace MeterInstall
{
    public partial class FrmChargePeccant : Form
    {
        private IMeter_Install_Peccant sysdal = new Meter_Install_Peccant();

        public FrmChargePeccant()
        {
            InitializeComponent();
        }

        private void uC_SearchCharge1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM
(SELECT DISTINCT MC.CHARGEID,MC.CHARGEWORKERID,MC.CHARGEWORKERNAME,MC.CHARGEDATETIME,
MC.CHARGEClASS,MC.CHARGETYPEID,CT.CHARGETYPENAME,
MC.CHARGEBCSS,CHARGEBCYS,MC.TOTALCHARGE,MC.Abate,MC.prestore,MC.FeeList,MC.InvoiceNO,MC.RECEIPTNO,MC.POSRUNNINGNO,
CASE WHEN MC.DAYCHECKSTATE=1 THEN '√' ELSE '' END AS DAYCHECKSTATE,
MC.DAYCHECKDATETIME,MC.DAYCHECKWORKERNAME,
CASE WHEN MC.MONTHCHECKSTATE=1 THEN '√' ELSE '' END AS MONTHCHECKSTATE,
MC.MONTHCHECKDATETIME,MC.MONTHCHECKWORKERNAME,
MIS.waterUserNO,MIS.waterUserName,MIS.waterUserAddress,MIS.waterPhone,MC.CreateDate  
FROM Meter_Charge MC,Meter_Install_Peccant MIS,Meter_WorkResolveFee MWF,Meter_WorkResolve MWR,CHARGETYPE CT 
WHERE MC.CHARGEID=MWF.ChargeID AND MWF.ResolveID=MWR.ResolveID AND MWR.TaskID=MIS.TaskID AND MC.CHARGETYPEID=CT.CHARGETYPEID) T ";

            if (!string.IsNullOrEmpty(uC_SearchCharge1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchCharge1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "CHARGEWORKERNAME", "收费员" }, 
                                                           { "CHARGEDATETIME", "收费时间" }, 
                                                           { "chargeID", "收费单号" }, 
                                                           { "CHARGEClASS", "收费类别" }, 
                                                           { "CHARGETYPENAME", "收款方式" }, 
                                                           { "CHARGEBCSS", "本次实收" } ,
                                                           { "CHARGEBCYS", "本次应收" },
                                                           { "TOTALCHARGE", "费用总计" },
                                                                { "Abate", "本次减免" },
                                                                { "prestore", "用户余额" },
                                                                 { "FeeList", "收费明细" },
                                                                { "INVOICENO", "发票号" },
                                                                  { "RECEIPTNO", "收据号" },
                                                                { "POSRUNNINGNO", "POS机交易流水号" },
                                                                  { "DAYCHECKSTATE", "日结账" },
                                                                { "DAYCHECKDATETIME", "审核时间" },
                                                           { "DAYCHECKWORKERNAME", "审核员" },
                                                         { "MONTHCHECKSTATES", "月结账" },
                                                                { "MONTHCHECKDATETIME", "审核时间" },
                                                                  { "MONTHCHECKWORKERNAME", "审核人" },
                                                                { "waterUserNO", "用户号" },
                                                                  { "waterUserName", "用户名" },
                                                                { "waterUserAddress", "地址" },
                                                                  { "waterPhone", "电话" }
            };
            uC_DataGridView_Page1.FieldStatis = new string[,] { { "CHARGEWORKERNAME", "合计" }, { "CHARGEBCSS","" }, { "CHARGEBCYS", ""}, { "TOTALCHARGE","" }, { "Abate","" }, { "prestore","" } };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void FrmCharge_Load(object sender, EventArgs e)
        {
          
            uC_SearchCharge1.Init();
        }
    }
}

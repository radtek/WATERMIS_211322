using System;
using System.Windows.Forms;

namespace MeterInstall
{
    public partial class FrmWaterUserListPeccant : Form
    {
        public FrmWaterUserListPeccant()
        {
            InitializeComponent();
        }

        private void uC_SearchModule1_BtnEvent(object sender, EventArgs e)
        {
            string sqlstr = @"SELECT * FROM
(SELECT MIS.AcceptID,MIS.loginId, W.waterUserNO,W.waterUserName,UA.CreateDate,W.waterPhone,W.waterUserAddress,W.meterReadingID,
WUT.waterUserTypeName,WUH.waterUserHouseType,MIS.STATE,W.Memo
FROM User_Append UA,Meter_Install_Peccant MIS ,waterUser W LEFT JOIN waterUserType WUT ON W.waterUserTypeId=WUT.waterUserTypeId LEFT JOIN waterUserHouseType WUH ON 
W.waterUserHouseType=WUH.waterUserHouseTypeID WHERE UA.TaskID=MIS.TaskID AND UA.waterUserNO=W.waterUserNO) T";
            if (!string.IsNullOrEmpty(uC_SearchModule1.sb.ToString()))
            {
                sqlstr += " WHERE " + uC_SearchModule1.sb.ToString();
            }
            uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "AcceptID", "受理编号" }, 
                                                           { "waterUserNO", "户号" }, 
                                                           { "waterUserName", "用户名" }, 
                                                           { "waterPhone", "联系电话" }, 
                                                           { "waterUserAddress", "地址" }, 
                                                           { "meterReadingID", "表本" } ,
                                                           { "waterUserTypeName", "用户类型" },
                                                           { "waterUserHouseType", "户型" },
                                                           { "Memo", "备注" }   
            };
           // uC_DataGridView_Page1.FieldStatis = new string[,] { { "waterMeterNo", "合计" } };
            uC_DataGridView_Page1.SqlString = sqlstr;
            uC_DataGridView_Page1.PageOrderField = "CreateDate";
            uC_DataGridView_Page1.PageIndex = 1;
            uC_DataGridView_Page1.Init();
        }

        private void uC_SearchModule1_Load(object sender, EventArgs e)
        {
            uC_SearchModule1.Init();
        }

        private void uC_DataGridView_Page1_CellDoubleClickEvents(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList.CurrentRow != null)
            {
                string _waterUserNO = dgList.CurrentRow.Cells["waterUserNO"].Value.ToString();
               
            }
        }


       
    }
}

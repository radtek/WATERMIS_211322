using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using System.Data.SqlClient;

namespace SysControl
{
    public partial class UC_SearchBase : UserControl
    {
        public UC_SearchBase()
        {
            InitializeComponent();
        }

        public StringBuilder sb = new StringBuilder();

        public string WorkCode = string.Empty;
        public string[] PkName;


        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler BtnEvent;

        private void UC_SearchBase_Load(object sender, EventArgs e)
        {

        }

        public void Init()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT VT.loginId,B.userName FROM View_TABLEUNION VT,base_login B WHERE VT.loginId=B.loginId AND VT.State<>4 ORDER BY VT.loginId");
            ControlBindHelper.BindComboBoxData(this.CB_loginId, dt, "userName", "loginId", true);

            DataTable dt2 = new SqlServerHelper().GetDataTable("Meter_WorkTaskState", "[ID] <>0", "ID");
            ControlBindHelper.BindComboBoxData(this.CB_State, dt2, "Value", "ID", true);

            if (!string.IsNullOrEmpty(WorkCode))
            {
                string sqlstr = "SELECT P.PointName,P.PointSort  FROM Meter_WorkFlow F,Meter_WorkPoint P WHERE F.WorkFlowID=P.WorkFlowID AND F.WorkCode=@WorkCode ORDER BY PointSort";
                DataTable dt3 = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { 
                new SqlParameter("@WorkCode",WorkCode)
                });

                ControlBindHelper.BindComboBoxData(this.CB_PointSort, dt3, "PointName", "PointSort", true);
            }
        }


        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WorkCode) || PkName.Length==0)
            {
                MessageBox.Show("系统调用错误，请联系技术人员！");
                return;
            }

            sb.Length = 0;
            DateTime dt1;
            DateTime dt2;
            // sb.Append("SELECT TaskID,AcceptID,waterUserName,ApplyUser,waterPhone,MIS.waterUserTypeId,WT.waterUserTypeName,WUH.waterUserHouseType,CASE IsBoost WHEN '1' THEN '√' ELSE '' END AS IsBoost,waterUserPeopleCount,QueryKey,[State],MWS.Value as FlowState,SubmitDate,waterUserAddress,MIS.Memo FROM Meter_Install_Single MIS left join  waterUserType WT on MIS.waterUserTypeId=WT.waterUserTypeId left join waterUserHouseType WUH on mis.waterUserHouseType=WUH.waterUserHouseTypeID left join Meter_WorkTaskState MWS on MIS.State=MWS.ID ");

            //sb.Append(" WHERE [State] <>0 ");
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

                if (new SqlServerHelper().GetSqlWhereByControlCombox(this.Controls, ref sqlwhere))
                {
                    sb.Append(sqlwhere);
                }
            }
            else
            {
                if (new SqlServerHelper().GetSqlWhereByControlCombox(this.Controls, ref sqlwhere))
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
                for (int i = 0; i < PkName.Length-1; i++)
                {
                    sb.AppendFormat("{0} LIKE '%{1}%' ", PkName[i], TB_SearchKey.Text.Trim());
                    if (i<(PkName.Length-2))
                    {
                        sb.Append(" OR ");
                    }
                }
                 sb.Append(" )");
            }

            if (BtnEvent != null)
            {
                BtnEvent(sender, e);
            }   
           
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

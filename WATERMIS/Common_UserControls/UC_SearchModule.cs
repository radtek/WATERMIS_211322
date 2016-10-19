using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.BLL;
using Common.DotNetUI;

namespace Common_UserControls
{
    public partial class UC_SearchModule : UserControl
    {
        public StringBuilder sb = new StringBuilder();


        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler BtnEvent;

        public UC_SearchModule()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            sb.Length = 0;
            DateTime dt1;
            DateTime dt2;
            // sb.Append("SELECT TaskID,AcceptID,waterUserName,ApplyUser,waterPhone,MIS.waterUserTypeId,WT.waterUserTypeName,WUH.waterUserHouseType,CASE IsBoost WHEN '1' THEN '√' ELSE '' END AS IsBoost,waterUserPeopleCount,QueryKey,[State],MWS.Value as FlowState,SubmitDate,waterUserAddress,MIS.Memo FROM Meter_Install_Single MIS left join  waterUserType WT on MIS.waterUserTypeId=WT.waterUserTypeId left join waterUserHouseType WUH on mis.waterUserHouseType=WUH.waterUserHouseTypeID left join Meter_WorkTaskState MWS on MIS.State=MWS.ID ");

            //sb.Append(" WHERE [State] <>0 ");

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
                    sb.AppendFormat(" AND AcceptDate >'{0}' and AcceptDate < '{1}'", dt1, dt2);
                }
            }

            string sqlwhere = "";
            if (new SqlServerHelper().GetSqlWhereByControl(this.Controls, ref sqlwhere))
            {
               // sb.Append(" AND ");
                sb.Append(sqlwhere);
            }

            if (BtnEvent != null)
            {
                BtnEvent(sender, e);
            }   
           
        }

        private void UC_SearchModule_Load(object sender, EventArgs e)
        {
        }

        public void Init()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT loginId, userName FROM Meter_WorkDo WHERE (loginId IS NOT NULL) AND (loginId <> '') AND (userName <> '')");
            ControlBindHelper.BindComboBoxData(this.CB_loginId, dt, "userName", "loginId", true);

            DataTable dt2 = new SqlServerHelper().GetDataTable("Meter_WorkTaskState", "[ID] <>0", "ID");
            ControlBindHelper.BindComboBoxData(this.CB_State, dt2, "Value", "ID", true);

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

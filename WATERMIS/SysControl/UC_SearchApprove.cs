using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;

namespace SysControl
{
    public partial class UC_SearchApprove : UserControl
    {
        public UC_SearchApprove()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                return parms;
            }
        }

        private int _WrokType = 99;
        [Browsable(true)]
        [Category("文本")]
        [Description("标签名字")]
        [DefaultValue("")]//默认值  
        public int WrokType
        {
            get { return _WrokType; }
            set { _WrokType = value; }
        }

        private int _state = 1;
        [Browsable(true)]
        [Category("文本")]
        [Description("标签名字")]
        [DefaultValue("")]//默认值  
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

        public StringBuilder sb = new StringBuilder();

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("鼠标")]
        [Browsable(true)]
        public event EventHandler BtnEvent;

        private void UC_SearchApprove_Load(object sender, EventArgs e)
        {

        }

        public void Init(string _loginId)
        {
            string sqlstr_LoginID = "";
            string sqlstr_Task = "";

            sqlstr_LoginID = AppDomain.CurrentDomain.GetData("GROUPID").ToString().Equals("0001")? "SELECT DISTINCT loginId, userName FROM Meter_WorkDo WHERE (loginId IS NOT NULL) AND (loginId <> '') AND (userName <> '')" : "SELECT DISTINCT loginId, userName FROM Meter_WorkDo WHERE loginId ='" + _loginId + "'";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr_LoginID);
            ControlBindHelper.BindComboBoxData(this.CB_loginId, dt, "userName", "loginId", true);
            if (!AppDomain.CurrentDomain.GetData("GROUPID").ToString().Equals("0001"))
            {
                this.CB_loginId.SelectedValue = _loginId;
                this.CB_loginId.Enabled = false;
            }

            switch (_WrokType)
            {
                case 1:
                    sqlstr_Task = "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort";
                    break;
                case 2:
                    sqlstr_Task = "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort AND MW.[State]=" + _state + "";
                    break;
                case 3:
                    sqlstr_Task = AppDomain.CurrentDomain.GetData("GROUPID").ToString().Equals("0001") ? "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort" : "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort AND ','+loginId+',' like '%,'+'" + _loginId + "'+',%'";
                    break;
                case 4:
                    sqlstr_Task = AppDomain.CurrentDomain.GetData("GROUPID").ToString().Equals("0001") ? "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort AND MW.[State]=" + _state + "" : "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort AND ','+loginId+',' like '%,'+'" + _loginId + "'+',%' AND MW.[State]=" + _state + "";
                    break;
                case 5:
                    sqlstr_Task = AppDomain.CurrentDomain.GetData("GROUPID").ToString().Equals("0001") ? "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort>MWR.PointSort AND MWR.IsPass IS NOT NULL" : "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort>MWR.PointSort AND ','+loginId+',' like '%,'+'" + _loginId + "'+',%' AND MWR.IsPass IS NOT NULL";
                    break;
                case 6:
                    sqlstr_Task = AppDomain.CurrentDomain.GetData("GROUPID").ToString().Equals("0001") ? "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE  MW.TaskID=MWR.TaskID AND MWR.MakeVoided=1 AND MW.[State]=4" : "SELECT MW.TaskCode,MWR.WorkName FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE  MW.TaskID=MWR.TaskID AND MWR.MakeVoided=1 AND ','+loginId+',' like '%,'+'" + _loginId + "'+',%' AND MW.[State]=4";
                    break;
                default:
                    break;
            }

            DataTable dt2 = new SqlServerHelper().GetDateTableBySql(sqlstr_Task);
            ControlBindHelper.BindComboBoxData(this.CB_TaskCode, dt2, "WorkName", "TaskCode", true);
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            sb.Length = 0;
            DateTime dt1;
            DateTime dt2;
            //string sqlwhere = "";
            sb.Append(" 1=1 ");
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
                    sb.AppendFormat(" AND CreateDate >'{0}' and CreateDate < '{1}'", dt1, dt2);
                }
            }
            if (CB_loginId.SelectedValue!=null && CB_loginId.SelectedValue!= DBNull.Value)
            {
                sb.AppendFormat(" AND ','+loginId+',' LIKE '%,'+'{0}'+',%'", CB_loginId.SelectedValue);
            }
            if (CB_TaskCode.SelectedValue != null && CB_TaskCode.SelectedValue != DBNull.Value)
            {
                sb.AppendFormat(" AND TaskCode='{0}'", CB_TaskCode.SelectedValue);
            }
            if (!string.IsNullOrEmpty(TB_Key.Text.Trim()))
            {
                sb.AppendFormat("AND (SD LIKE '%{0}%' OR waterUserName LIKE '%{0}%' OR waterPhone LIKE '%{0}%' OR waterUserAddress LIKE '%{0}%' OR waterPhone LIKE '%{0}%')", TB_Key.Text.Trim());
            }

            //if (new SqlServerHelper().GetSqlWhereByControl(this.Controls, ref sqlwhere))
            //{
            //    sb.Append(" ");
            //    sb.Append(sqlwhere);
            //}

            if (BtnEvent != null)
            {
                BtnEvent(sender, e);
            }
        }

        private void CHK_waterMeterProofreadingDate_CheckedChanged(object sender, EventArgs e)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using Common.DotNetData;
using SysControl;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace FinanceOS
{
    public partial class FrmFinance_Cancel : Form
    {
        private string _ChargeID;

        public string ChargeID
        {
            get { return _ChargeID; }
            set { _ChargeID = value; }
        }

        public string TaskID;

        public string ChargerID=string.Empty;

        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public FrmFinance_Cancel()
        {
            InitializeComponent();
        }

        private void FrmFinance_Cancel_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            string sqlstr = "SELECT MC.*,CT.CHARGETYPENAME,CC.CHARGEClASSNAME,CASE WHEN MC.MONTHCHECKSTATE=0 THEN '-' ELSE '已审核' END AS MONTHCHECKSTATENAME FROM Meter_Charge MC,CHARGETYPE CT,CHARGEClASS CC WHERE MC.CHARGETYPEID=CT.CHARGETYPEID AND MC.CHARGEClASS=CC.CHARGEClASS AND MC.CHARGEID=@CHARGEID";
            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@CHARGEID", _ChargeID) });

            Hashtable ht = DataTableHelper.DataTableToHashtable(dt);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);

            ht = new SqlServerHelper().GetHashtableById("View_WorkBase", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel2.Controls);

            dt = new SqlServerHelper().GetDataTable("Meter_WorkResolveFee", "ChargeID='" + _ChargeID + "'", "ChargeDate");
            FP.Controls.Clear();
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_ChargeItem UC = new UC_ChargeItem();
                    UC.FeeItem = string.Format("{0}:{1}", dr["FeeItem"].ToString(), dr["Fee"].ToString());

                    FP.Controls.Add(UC);
                }
            }

            string _Loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            bool _IsAllow = true;
            if (_Loginid.Equals(ChargerID))
            {
                _IsAllow = false;
            }
            else
            {
                Btn_Print.Enabled = true;
            }

            sqlstr =string.Format(@"SELECT COUNT(*) FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID
AND MW.[State]=1 AND MW.PointSort=MWR.PointSort AND MW.TaskID=@TaskID AND MWR.loginId LIKE '%{0}%'", _Loginid);
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID)});
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                _IsAllow = false;
            }

            sqlstr = @"SELECT COUNT(0) FROM Meter_Charge WHERE CHARGEWORKERID='0092' AND ISNULL(MONTHCHECKSTATE,'')<>'1' AND ISNULL(CHARGECANCEL,'')<>'1' AND TaskID=@TaskID
AND CHARGEID=@CHARGEID";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@TaskID", TaskID), new SqlParameter("@CHARGEID", _ChargeID) });
            if (dt.Rows[0][0].ToString().Equals("0"))
            {
                _IsAllow = false;
            }

            Btn_Cancel.Visible = _IsAllow;

        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            if (sysidal.CancelCharge(TaskID, _ChargeID, CANCELMEMO.Text))
            {
                MessageBox.Show("取消收费成功！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

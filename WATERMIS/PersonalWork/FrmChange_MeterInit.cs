using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using System.Collections;
using DBinterface.IDAL;
using Common.DotNetData;
using System.Data.SqlClient;
using BASEFUNCTION;
using BLL;

namespace PersonalWork
{
    public partial class FrmChange_MeterInit : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;

        private string ComputerName = "";
        private string ip = "";
        private string _waterUserId;
        private string _waterMeterId;
        private int _DesterilizeType = 0;

        private string strLogID="";
        private string strName="";
        private string strRealName="";

        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        Log log = new Log(Application.StartupPath+@"\Logs\",LogType.Daily);

        public FrmChange_MeterInit()
        {
            InitializeComponent();
        }

        private void FrmChange_MeterInit_Load(object sender, EventArgs e)
        {
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
            {
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                strName = AppDomain.CurrentDomain.GetData("LOGINNAME").ToString();
                strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
            }
            else
            {
                MessageBox.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            #region //2017-2-22 RONG
            bool IsAllowEdit = false;
            if (ht.Contains("Edit"))
            {
                if (bool.TryParse(ht["Edit"].ToString(), out IsAllowEdit))
                {

                }
            }
            Btn_Submit.Enabled = IsAllowEdit;
            #endregion
        }

        private void FrmChange_MeterInit_Shown(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();

                DataTable dt = sysidal.GetUserMeterInfoByTaskId("Meter_Change", TaskID);
                if (DataTableHelper.IsExistRows(dt))
                {
                    _waterUserId = dt.Rows[0][0].ToString();
                    _waterMeterId = dt.Rows[0][1].ToString();
                    LB_Tip.Text = string.Format("用 户 号：{0}；水表编号：{1}", _waterUserId, _waterMeterId);
                }
            }

            DataTable dtm = new SqlServerHelper().GetDateTableBySql(string.Format("SELECT waterMeterEndNumber FROM Meter_Change WHERE TaskID='{0}'", TaskID));
            if (DataTableHelper.IsExistRows(dtm))
            {
                LB_EndNumber.Text = dtm.Rows[0][0].ToString();
            }

            DataTable dts = new SqlServerHelper().GetDateTableBySql(string.Format("SELECT TOP 1 waterMeterEndNumber,readMeterRecordYearAndMonth,meterReaderName FROM readMeterRecord WHERE waterMeterId='{0}' ORDER BY readMeterRecordDate DESC", _waterMeterId));
            if (DataTableHelper.IsExistRows(dts))
            {
                LB_S.Text = string.Format("抄表员：{0}，抄表月份：{1}，表底数：{2}",dts.Rows[0][2].ToString(),dts.Rows[0][1].ToString(),dts.Rows[0][0].ToString());
            }

        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;

            try
            {
                string strReadMeterRecordID = GETTABLEID.GetTableID(strLogID, "READMETERRECORD");
                if (BLLreadMeterRecord.ChangeWaterMeter(_waterMeterId, strReadMeterRecordID, strRealName))
                {
                    Hashtable HL = new Hashtable();
                    HL["LOGTYPE"] = 6; //6-抄表台账相关日志
                    HL["LOGCONTENT"] = string.Format("用户换表-用户号：{0}；水表编号：{1}", _waterUserId, _waterMeterId);
                    HL["LOGDATETIME"] = DateTime.Now.ToString();
                    HL["OPERATORID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                    HL["OPERATORNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                    HL["MEMO"] = TaskID;
                    new SqlServerHelper().Submit_AddOrEdit("OPERATORLOG", "LOGID", "", HL);
                    //======================================

                    int count = sysidal.UpdateApprove_defalut("Meter_Change", ResolveID, true, UserOpinion.Text.Trim(), PointSort, TaskID);

                    if (count > 0)
                    {
                        mes.Show("审批成功！");
                    }
                    else
                    {
                        mes.Show("审批失败！");
                        Btn_Submit.Enabled = true;
                    }
                }
                else
                {
                    mes.Show("变更表底数失败！");
                    Btn_Submit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
            }
        }
    }
}

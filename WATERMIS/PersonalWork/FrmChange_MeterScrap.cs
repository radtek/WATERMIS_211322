using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.DAL;
using DBinterface.IDAL;
using System.Collections;
using System.Data.SqlClient;
using Common.DotNetData;

namespace PersonalWork
{
    public partial class FrmChange_MeterScrap : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;

        private string _waterUserId;
        private string _waterMeterId;
        private bool _MeterAllow = false;
        private string _waterMeterSerialNumber = string.Empty;

        public FrmChange_MeterScrap()
        {
            InitializeComponent();
        }

        private void FrmChange_MeterScrap_Load(object sender, EventArgs e)
        {
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

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;

            if (waterMeterEndNumber.ValidateState & waterMeterEndNumber.ValidateState & waterMeterMode.ValidateState & WATERMETERLOCKNO.ValidateState)
            {
                if (!_MeterAllow)
                {
                    Btn_Submit.Enabled = true;
                    return;
                }
                if (!CheckMeterNumber(waterMeterSerialNumber.Text))
                {
                    MessageBox.Show("水表不可用，请重新输入水表编号");
                    Btn_Submit.Enabled = true;
                    return;
                }
                Hashtable Hmr = new Hashtable();

                //首先更新Meter
                //用户水表编号：waterMeterId
                //用户水表号：waterMeterNo
                //所属用户ID：waterUserId
                //水表型号（铅封号）：waterMeterMode
                //表锁号：WATERMETERLOCKNO
                //倒装：IsReverse
                Hmr = new SqlServerHelper().GetHashTableByControl(this.panel1.Controls);
                Hmr.Remove("USEROPINION");
                Hmr["WATERMETERNO"] = _waterMeterId;
                Hmr["WATERUSERID"] = _waterUserId;
                Hmr["METERSTATE"] = 1;
                Hmr.Remove("WATERMETERSERIALNUMBER");
                Hmr.Remove("WATERMETERENDNUMBER");
                if (new SqlServerHelper().UpdateByHashtable("Meter", "waterMeterSerialNumber", waterMeterSerialNumber.Text.Trim(), Hmr)==0)
                {
                    MessageBox.Show("水表出库失败！");
                    Btn_Submit.Enabled = true;
                    return;
                }
                //报废水表
                string sqlstr = "UPDATE Meter SET MeterState=2 WHERE waterMeterId =@waterMeterId";
                new SqlServerHelper().UpdateByHashtable(sqlstr, new SqlParameter[] { new SqlParameter("@waterMeterId", _waterMeterId) });

                //其次更新Meter_Change
                //Meter_Change
                //原水表ID： waterMeterId
                //原水表读数： waterMeterEndNumber
                //新水表ID： waterMeterSerialNumber
                Hmr.Clear();
                Hmr["WATERMETERID"] = _waterMeterId;
                Hmr["WATERMETERENDNUMBER"] = waterMeterEndNumber.Text.Trim();
                Hmr["WATERMETERSERIALNUMBER"] = waterMeterSerialNumber.Text.Trim();
                if (new SqlServerHelper().UpdateByHashtable("Meter_Change", "TaskID", TaskID, Hmr) == 0)
                {
                    MessageBox.Show("信息保存失败！");
                    Btn_Submit.Enabled = true;
                    return;
                }

                //第三更新waterMeter
                //水表厂家：waterMeterProduct
                //水表出厂编号：waterMeterSerialNumber
                //水表型号（铅封号）：waterMeterMode
                //表锁号：WATERMETERLOCKNO
                //倒装：IsReverse
                //鉴定日期： waterMeterProofreadingDate
                //鉴定周期： waterMeteProofreadingPeriod
                //启用时间： STARTUSEDATETIME
                //口径：waterMeterSizeId

                Hmr.Clear();
                Hmr = new SqlServerHelper().GetHashtableById("Meter", "waterMeterSerialNumber", waterMeterSerialNumber.Text.Trim());
                Hashtable Hm = new Hashtable();
                Hm["WATERMETERPRODUCT"] = Hmr["WATERMETERPRODUCT"];
                Hm["WATERMETERSERIALNUMBER"] = Hmr["WATERMETERSERIALNUMBER"];
                Hm["WATERMETERMODE"] = Hmr["WATERMETERMODE"];
                Hm["WATERMETERLOCKNO"] = Hmr["WATERMETERLOCKNO"];
                Hm["ISREVERSE"] = Hmr["ISREVERSE"];
                Hm["WATERMETERPROOFREADINGDATE"] = Hmr["WATERMETERPROOFREADINGDATE"];
                Hm["WATERMETEPROOFREADINGPERIOD"] = Hmr["WATERMETEPROOFREADINGPERIOD"];
                Hm["STARTUSEDATETIME"] = Hmr["STARTUSEDATETIME"];
                Hm["WATERMETERSIZEID"] = Hmr["WATERMETERSIZEID"];
                if (!new SqlServerHelper().Submit_AddOrEdit("waterMeter", "waterMeterId", _waterMeterId, Hm))
                {
                    MessageBox.Show("换表失败！");
                    Btn_Submit.Enabled = true;
                    return;
                }

                Hashtable HL = new Hashtable();
                HL["LOGTYPE"] = 2; //2-水表日志
                HL["LOGCONTENT"] = string.Format("用户换表-用户号：{0}；出库水表出厂编号：{1}，", _waterUserId, waterMeterSerialNumber.Text);
                HL["LOGDATETIME"] = DateTime.Now.ToString();
                HL["OPERATORID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                HL["OPERATORNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                HL["MEMO"] = TaskID;
                new SqlServerHelper().Submit_AddOrEdit("OPERATORLOG", "LOGID", "", HL);
                string Matter = string.Format("【更换水表】-旧表读数：{0}；旧表编号：{1}；新表编号：{2}；铅封号：{3}；表锁号：{4}", waterMeterEndNumber.Text, waterMeterId.Text, waterMeterSerialNumber.Text, waterMeterMode.Text, WATERMETERLOCKNO.Text);
                int count = sysidal.UpdateApprove_defalut("Meter_Change", ResolveID, true, UserOpinion.Text.Trim(), PointSort, TaskID,Matter);

                if (count > 0)
                {
                    MessageBox.Show("审批成功！");
                }
                else
                {
                    MessageBox.Show("审批失败！");
                    Btn_Submit.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("信息不完整！");
            }
        }

        private void FrmChange_MeterScrap_Shown(object sender, EventArgs e)
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
                    waterMeterId.Text = _waterMeterId;
                }
            }
        }

        private void Btn_Check_Click(object sender, EventArgs e)
        {
            if (!CheckMeterNumber(waterMeterSerialNumber.Text))
            {
                LB_State.Text = "×";
                MessageBox.Show("水表不可用，请重新输入水表编号");
            }
            else
            {
                LB_State.Text = "√";
            }
        }

        private bool CheckMeterNumber(string SerialNumber)
        {
            bool resutl = false;
            if (!string.IsNullOrEmpty(SerialNumber))
            {
                string sqlstr = "SELECT COUNT(1) FROM Meter WHERE NOT EXISTS(SELECT waterMeterSerialNumber FROM waterMeter WHERE waterMeterSerialNumber=METER.waterMeterSerialNumber) AND MeterState=0  AND waterMeterSerialNumber=@waterMeterSerialNumber";
                DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@waterMeterSerialNumber", SerialNumber) });
                _MeterAllow=int.Parse(dt.Rows[0][0].ToString()) == 0 ? false : true;
                resutl = _MeterAllow;
            }

            return resutl;
        }

        private void waterMeterSerialNumber_TextChanged(object sender, EventArgs e)
        {
            if (!_waterMeterSerialNumber.Equals(waterMeterSerialNumber.Text.Trim()))
            {
                LB_State.Text = "?";
                _MeterAllow = false;
            }
        }

    }
}

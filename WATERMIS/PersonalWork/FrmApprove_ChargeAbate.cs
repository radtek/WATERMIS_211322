using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetUI;

namespace PersonalWork
{
    public partial class FrmApprove_ChargeAbate : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;
        private bool skip = false;

        public FrmApprove_ChargeAbate()
        {
            InitializeComponent();
        }

        private void FrmApprove_ChargeAbate_Load(object sender, EventArgs e)
        {
            ht = (Hashtable)this.Tag;
            TaskID = ht["TaskID"].ToString();
            ResolveID = ht["ResolveID"].ToString();
            PointSort = ht["PointSort"].ToString();
            BindCombox();
            InitData();
            InitView();
        }

        private void BindCombox()
        {
            DataTable dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT readMeterRecordYear FROM  V_YSDETAIL_BYWATERMETER WHERE chargeState<>'3'");
            ControlBindHelper.BindComboBoxData(this.readMeterRecordYear, dt, "readMeterRecordYear", "readMeterRecordYear");

            dt = new SqlServerHelper().GetDateTableBySql("SELECT DISTINCT readMeterRecordMonth FROM  V_YSDETAIL_BYWATERMETER WHERE chargeState<>'3'");
            ControlBindHelper.BindComboBoxData(this.readMeterRecordMonth, dt, "readMeterRecordMonth", "readMeterRecordMonth");

            dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterTypeid, dt, "waterMeterTypeValue", "waterMeterTypeId");

            dt = new SqlServerHelper().GetDataTable("waterUserType", "", "waterUserTypeId");
            ControlBindHelper.BindComboBoxData(this.waterUserTypeId, dt, "waterUserTypeName", "waterUserTypeId");
        }

        private void InitData()
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("User_ChargeAbate", "TaskID", TaskID);
            new SqlServerHelper().BindHashTableToForm(ht, this.panel1.Controls);
        }

        private void InitView()
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("Meter_WorkResolve", "ResolveID", ResolveID);

            if (ht != null)
            {
                UserOpinion.Text = ht["USEROPINION"].ToString().Trim();

                if (ht["MAKESKIP"] != null && ht["MAKEPOINTID"] != null)//是否显示跳转
                {
                    skip = (bool)ht["MAKESKIP"];
                    if (skip)
                    {
                        IsSkip.Visible = true;
                        LB_GoPointID.Visible = true;
                        CB_GoPointID.Visible = true;
                        string sqlstr = string.Format("SELECT PointName,PointSort  FROM Meter_WorkPoint WHERE WorkFlowID='{0}' AND PointSort IN ({1}) ORDER BY PointSort", ht["WORKFLOWID"].ToString(), ht["GOPOINTID"].ToString());
                        DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
                        ControlBindHelper.BindComboBoxData(this.CB_GoPointID, dt, "PointName", "PointSort");
                    }
                }
                if (!string.IsNullOrEmpty(ht["ISVOIDED"].ToString()))//是否显示报废
                {
                    bool isvisable = false;
                    if (bool.TryParse(ht["ISVOIDED"].ToString(), out isvisable))
                        Btn_Voided.Visible = isvisable;
                }
            }

        }

        private void Btn_Voided_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            Btn_Voided.Enabled = false;
            int count = sysidal.UpdateApprove_Voided_ByTableName("User_ChargeAbate", ResolveID, UserOpinion.Text.Trim(), TaskID);
            if (count > 0)
            {
                MessageBox.Show("作废完成！");
            }
            else
            {
                MessageBox.Show("作废失败！");
                Btn_Submit.Enabled = true;
                Btn_Voided.Enabled = true;
            }
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            Btn_Submit.Enabled = false;
            int count = sysidal.UpdateApprove_defalut("User_ChargeAbate", ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), PointSort, TaskID);
            if (count > 0)
            {

                if (sysidal.IsWorkTaskOver("User_ChargeAbate", TaskID))//获取审批状态，如果是Meter_WorkTask.state=5 和User_WaterPrice.state=5,说明审批流程走完
                {
                    bool IsChargeAbate = false;
                   
                    //===================================================================================减免水费
                    //返回bool类型

                    #region 20160909 ByRen

                    //增加台账及冲减明细表字段AbateMoney(减免金额)
                    //ALTER TABLE readMeterRecord ADD AbateMoney decimal(18,2) default 0
                    //ALTER TABLE readMeterRecordCancel ADD AbateMoney decimal(18,2) default 0

                    int intRows = 0;
                    try
                    {
                        string strTableName = "readMeterRecord", strPkName = "readMeterRecordId", strPkValue = readMeterRecordId.Text;
                        Hashtable dtReadMeterRecord = new Hashtable();
                        dtReadMeterRecord.Add("AbateMoney", Abate.Text);
                        intRows = new SqlServerHelper().UpdateByHashtable(strTableName, strPkName, strPkValue, dtReadMeterRecord);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("执行减免语句出错,原因:" + ex.Message);
                        //日志
                    }
                    IsChargeAbate = intRows > 0 ? true : false;
                    #endregion

                    if (IsChargeAbate)
                    {
                        Hashtable hu = new Hashtable();
                        hu["IsAbate"] = 1;
                        hu["CHARGEWORKERNAME"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                        hu["CHARGEWORKERID"] = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                        hu["CHARGEWORKERDate"] = DateTime.Now.ToString();
                        int upCount = new SqlServerHelper().UpdateByHashtable("User_ChargeAbate", "TaskID", TaskID, hu);
                        if (upCount > 0)
                        {
                            //==========================================================================================如果金额小于指定金额，不需要总经理审批
                            this.DialogResult = DialogResult.OK;
                            MessageBox.Show("水费减免成功！");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("水费减免成功 ，记录保存失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("水费减免失败！");
                    }

                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("审批成功！");
                    this.Close();
                }

            }
            else
            {
                Btn_Submit.Enabled = true;
            }
        }

    }
}

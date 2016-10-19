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
using Common.DotNetUI;
using BASEFUNCTION;
using Microsoft.VisualBasic;

namespace PersonalWork
{
    public partial class FrmApprove_WaterPrice_Default : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        public Hashtable ht = new Hashtable();
        public string ResolveID = string.Empty;
        public string PointSort = string.Empty;
        public string TaskID = string.Empty;
        public bool IsCharge = false;
        private bool skip = false;

        //存储台账ID ByRen====================
        private string strReadMeterRecordID = "";

        //对话框类
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        //==============================

        public FrmApprove_WaterPrice_Default()
        {
            InitializeComponent();
        }

        private void FrmApprove_WaterPrice_Default_Load(object sender, EventArgs e)
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
            DataTable dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterType_Current, dt, "waterMeterTypeValue", "waterMeterTypeId");
            dt = new SqlServerHelper().GetDataTable("waterMeterType", "", "waterMeterTypeId");
            ControlBindHelper.BindComboBoxData(this.waterMeterType_New, dt, "waterMeterTypeValue", "waterMeterTypeId");
        }

        private void InitData()
        {
            Hashtable ht = new SqlServerHelper().GetHashtableById("User_WaterPrice", "TaskID", TaskID);

            //获取台账ID，ByRen=====
            object objReadMeterRecordID = ht["READMETERRECORDID"];
            if (objReadMeterRecordID != null && objReadMeterRecordID != DBNull.Value)
                strReadMeterRecordID = objReadMeterRecordID.ToString();
            //else
            //{
            //    mes.Show("台账ID为空，无法变更水价");
            //    return;
            //}
            //====================

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
            int count = sysidal.UpdateApprove_Voided_ByTableName("User_WaterPrice", ResolveID, UserOpinion.Text.Trim(), TaskID);
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
            int count = sysidal.UpdateApprove_defalut("User_WaterPrice", ResolveID, IsPass.Checked, UserOpinion.Text.Trim(), PointSort, TaskID);
            if (count > 0)
            {

                if (sysidal.IsWorkTaskOver("User_WaterPrice", TaskID))//获取审批状态，如果是Meter_WorkTask.state=5 和User_WaterPrice.state=5,说明审批流程走完
                {
                    bool IsChangeMeterType = false;
                    //户号：this.WATERUSERNO.Text
                    //原用水性质：this.waterMeterType_Current
                    //新用水性质：this.waterMeterType_New
                    //变更周期：只变本月：IsMonth.checked;从下个月开始变更：IsLong.checked;如果从本月开始一直变更：IsMonth.checked && IsLong.checked
                    //=========================================================================================================================//变更用水性质

                    #region 20160912 ByRen
                    //本类开头增加台账ID变量strReadMeterRecordID
                    // 修改本类函数 InitData()获取台账ID
                    //本类引用basefunction/Microsoft.VisualBasic类库、声明messages及log类
                    //本类增加函数GetAvePrice
                    //隐藏窗体FrmUser_WaterPrice_Add显示的台账IDreadMeterRecordId

                    string strSQLExcute = "";
                    string strWaterMeterTypeID = "", strWaterMeterTypeName = "", strWaterMeterTypeClassID = "", strWaterMeterTypeClassName = "";
                    DateTime dtNow = mes.GetDatetimeNow();

                    if (IsMonth.Checked && !IsLong.Checked)
                    {
                        #region 变更本月水价
                        int intNotReadMonth = 1;//获取未抄月份数量,取阶梯水价

                        DataTable dtReadMeterRecord = new SqlServerHelper().GetDataTable("readMeterRecord", "readMeterRecordId='" + strReadMeterRecordID + "'", "");
                        if (dtReadMeterRecord.Rows.Count > 0)
                        {
                            object objTotalNumber = dtReadMeterRecord.Rows[0]["totalNumber"];
                            try
                            {

                                object objLastReadMonths = dtReadMeterRecord.Rows[0]["lastNumberYearMonth"];
                                if (objLastReadMonths != null && objLastReadMonths != DBNull.Value)
                                {
                                    DateTime dtLastReadDate = Convert.ToDateTime(objLastReadMonths.ToString().Substring(0, 4) + "-" + objLastReadMonths.ToString().Substring(4, 2) + "-01");
                                    intNotReadMonth = dtNow.Year * 12 + dtNow.Month - dtLastReadDate.Year * 12 - dtLastReadDate.Month;
                                    if (intNotReadMonth < 1)
                                        intNotReadMonth = 1;
                                }
                                else
                                {
                                    object objWaterMeterID = dtReadMeterRecord.Rows[0]["waterMeterId"];
                                    if (objWaterMeterID.ToString() != "")
                                    {
                                        string strSQLGetInitialMonth = "SELECT TOP 1 initialReadMeterMesDateTime FROM readMeterRecord WHERE waterMeterId='" + objWaterMeterID.ToString() + "' ORDER BY initialReadMeterMesDateTime";
                                        DataTable dtInitialMonth = new SqlServerHelper().GetDataTable(strSQLGetInitialMonth);
                                        if (dtInitialMonth.Rows.Count > 0)
                                        {
                                            object objInitialMonth = dtInitialMonth.Rows[0]["initialReadMeterMesDateTime"];
                                            if (Information.IsDate(objInitialMonth))
                                            {
                                                DateTime dtLastYearAndMonth = Convert.ToDateTime(objInitialMonth);
                                                //strLastReadMonths = dtLastYearAndMonth.ToString("yyyyMM");
                                                intNotReadMonth = dtNow.Year * 12 + dtNow.Month - dtLastYearAndMonth.Year * 12 - dtLastYearAndMonth.Month + 1;
                                            }
                                        }
                                    }
                                }

                                strWaterMeterTypeID = waterMeterType_New.SelectedValue.ToString();
                                DataTable dtWaterMeterType = new SqlServerHelper().GetDataTable("V_WATERMTERTYPE", "waterMeterTypeId='" + strWaterMeterTypeID + "'", "");
                                if (dtWaterMeterType.Rows.Count > 0)
                                {
                                    object objWaterMeterType = dtWaterMeterType.Rows[0]["waterMeterTypeValue"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeName = objWaterMeterType.ToString();

                                    objWaterMeterType = dtWaterMeterType.Rows[0]["WATERMETERTYPECLASSID"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeClassID = objWaterMeterType.ToString();

                                    objWaterMeterType = dtWaterMeterType.Rows[0]["WATERMETERTYPECLASSNAME"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeClassName = objWaterMeterType.ToString();


                                    string[] strWaterMeterRecordTrapePrice = new string[3];
                                    object objWaterMeterRecordTrapePrice = dtWaterMeterType.Rows[0]["trapezoidPrice"];
                                    if (objWaterMeterRecordTrapePrice != null && objWaterMeterRecordTrapePrice != DBNull.Value)
                                    {
                                        strWaterMeterRecordTrapePrice = GetAvePrice(Convert.ToDecimal(objTotalNumber), objWaterMeterRecordTrapePrice.ToString(), intNotReadMonth);
                                    }
                                    else
                                    {
                                        strWaterMeterRecordTrapePrice[0] = "0";
                                        strWaterMeterRecordTrapePrice[1] = "无";
                                        strWaterMeterRecordTrapePrice[2] = "0";
                                    }
                                    decimal decExtraChargePrice1 = 0, decExtraChargePrice2 = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decExtraCharge = 0, decTotalFee = 0;
                                    object objExtraFee = dtWaterMeterType.Rows[0]["extraCharge"];
                                    if (objExtraFee != null && objExtraFee != DBNull.Value)
                                    {
                                        string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                                        for (int j = 0; j < strAllExtraFee.Length; j++)
                                        {
                                            string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                                            if (strSingleExtraFee[0].Contains("F"))
                                            {
                                                string strNum = strSingleExtraFee[0].Substring(1, 1);
                                                if (strNum == "1")
                                                    decExtraChargePrice1 = Convert.ToDecimal(strSingleExtraFee[1]);
                                                if (strNum == "2")
                                                    decExtraChargePrice2 = Convert.ToDecimal(strSingleExtraFee[1]);
                                            }
                                        }
                                    }
                                    //计算附加费
                                    decExtraCharge1 = decExtraChargePrice1 * Convert.ToDecimal(objTotalNumber);
                                    decExtraCharge2 = decExtraChargePrice2 * Convert.ToDecimal(strWaterMeterRecordTrapePrice[2]);

                                    decExtraCharge = decExtraCharge1 + decExtraCharge2;
                                    decTotalFee = decExtraCharge + Convert.ToDecimal(strWaterMeterRecordTrapePrice[2]);

                                    strSQLExcute = string.Format(@"UPDATE readMeterRecord SET 
avePrice={0},avePriceDescribe='{1}',waterTotalCharge={2},extraChargePrice1={3},extraChargePrice2={4},
extraCharge1={5},extraCharge2={6},extraCharge={7},totalCharge={8},
waterMeterTypeClassID='{9}',waterMeterTypeClassName='{10}',waterMeterTypeId='{11}',waterMeterTypeName='{12}'
WHERE readMeterRecordId='{13}'", strWaterMeterRecordTrapePrice[0], strWaterMeterRecordTrapePrice[1], strWaterMeterRecordTrapePrice[2],
                              decExtraChargePrice1, decExtraChargePrice2, decExtraCharge1, decExtraCharge2, decExtraCharge, decTotalFee,
                              strWaterMeterTypeClassID, strWaterMeterTypeClassName, strWaterMeterTypeID, strWaterMeterTypeName, strReadMeterRecordID
                               );
                                }
                                else
                                {
                                    mes.Show("获取新的用水性质信息失败,变更失败!");
                                    IsChangeMeterType = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                mes.Show("变更水价失败,原因:" + ex.Message);
                                log.Write(ex.ToString(), MsgType.Error);
                                IsChangeMeterType = false;
                            }
                        }
                        else
                        {
                            mes.Show("变更台账ID为空,变更失败!");
                            IsChangeMeterType = false;
                        }
                        #endregion
                    }
                    if (!IsMonth.Checked && IsLong.Checked)
                    {
                        #region 变更永久水价

                        string strWaterUserNO = WATERUSERNO.Text;
                        if (strWaterUserNO.Trim() == "")
                        {
                            mes.Show("获取用户号失败,变更失败!");
                            IsChangeMeterType = false;
                        }
                        else
                        {
                            try
                            {
                                strWaterMeterTypeID = waterMeterType_New.SelectedValue.ToString();
                                DataTable dtWaterMeterType = new SqlServerHelper().GetDataTable("V_WATERMTERTYPE", "waterMeterTypeId='" + strWaterMeterTypeID + "'", "");
                                if (dtWaterMeterType.Rows.Count > 0)
                                {
                                    object objWaterMeterType = dtWaterMeterType.Rows[0]["waterMeterTypeValue"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeName = objWaterMeterType.ToString();

                                    objWaterMeterType = dtWaterMeterType.Rows[0]["WATERMETERTYPECLASSID"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeClassID = objWaterMeterType.ToString();

                                    objWaterMeterType = dtWaterMeterType.Rows[0]["WATERMETERTYPECLASSNAME"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeClassName = objWaterMeterType.ToString();

                                    strSQLExcute = string.Format(@"UPDATE waterMeter SET
waterMeterTypeClassID='{0}',waterMeterTypeId='{1}'
WHERE waterUserId='{2}'", strWaterMeterTypeClassID, strWaterMeterTypeID, strWaterUserNO
                               );
                                }
                                else
                                {
                                    mes.Show("获取新的用水性质信息失败,变更失败!");
                                    IsChangeMeterType = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                mes.Show("变更水价失败,原因:" + ex.Message);
                                log.Write(ex.ToString(), MsgType.Error);
                                IsChangeMeterType = false;
                            }
                        }
                        #endregion
                    }

                    if (IsMonth.Checked && IsLong.Checked)
                    {
                        #region 变更本月水价
                        int intNotReadMonth = 1;//获取未抄月份数量,取阶梯水价

                        DataTable dtReadMeterRecord = new SqlServerHelper().GetDataTable("readMeterRecord", "readMeterRecordId='" + strReadMeterRecordID + "'", "");
                        if (dtReadMeterRecord.Rows.Count > 0)
                        {
                            object objTotalNumber = dtReadMeterRecord.Rows[0]["totalNumber"];
                            try
                            {

                                object objLastReadMonths = dtReadMeterRecord.Rows[0]["lastNumberYearMonth"];
                                if (objLastReadMonths != null && objLastReadMonths != DBNull.Value)
                                {
                                    DateTime dtLastReadDate = Convert.ToDateTime(objLastReadMonths.ToString().Substring(0, 4) + "-" + objLastReadMonths.ToString().Substring(4, 2) + "-01");
                                    intNotReadMonth = dtNow.Year * 12 + dtNow.Month - dtLastReadDate.Year * 12 - dtLastReadDate.Month;
                                    if (intNotReadMonth < 1)
                                        intNotReadMonth = 1;
                                }
                                else
                                {
                                    object objWaterMeterID = dtReadMeterRecord.Rows[0]["waterMeterId"];
                                    if (objWaterMeterID.ToString() != "")
                                    {
                                        string strSQLGetInitialMonth = "SELECT TOP 1 initialReadMeterMesDateTime FROM readMeterRecord WHERE waterMeterId='" + objWaterMeterID.ToString() + "' ORDER BY initialReadMeterMesDateTime";
                                        DataTable dtInitialMonth = new SqlServerHelper().GetDataTable(strSQLGetInitialMonth);
                                        if (dtInitialMonth.Rows.Count > 0)
                                        {
                                            object objInitialMonth = dtInitialMonth.Rows[0]["initialReadMeterMesDateTime"];
                                            if (Information.IsDate(objInitialMonth))
                                            {
                                                DateTime dtLastYearAndMonth = Convert.ToDateTime(objInitialMonth);
                                                //strLastReadMonths = dtLastYearAndMonth.ToString("yyyyMM");
                                                intNotReadMonth = dtNow.Year * 12 + dtNow.Month - dtLastYearAndMonth.Year * 12 - dtLastYearAndMonth.Month + 1;
                                            }
                                        }
                                    }
                                }

                                strWaterMeterTypeID = waterMeterType_New.SelectedValue.ToString();

                                DataTable dtWaterMeterType = new SqlServerHelper().GetDataTable("V_WATERMTERTYPE","waterMeterTypeId='" + strWaterMeterTypeID + "'","");
                                if (dtWaterMeterType.Rows.Count > 0)
                                {
                                    object objWaterMeterType = dtWaterMeterType.Rows[0]["waterMeterTypeValue"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeName = objWaterMeterType.ToString();

                                    objWaterMeterType = dtWaterMeterType.Rows[0]["WATERMETERTYPECLASSID"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeClassID = objWaterMeterType.ToString();

                                    objWaterMeterType = dtWaterMeterType.Rows[0]["WATERMETERTYPECLASSNAME"];
                                    if (objWaterMeterType != null && objWaterMeterType != DBNull.Value)
                                        strWaterMeterTypeClassName = objWaterMeterType.ToString();


                                    string[] strWaterMeterRecordTrapePrice = new string[3];
                                    object objWaterMeterRecordTrapePrice = dtWaterMeterType.Rows[0]["trapezoidPrice"];
                                    if (objWaterMeterRecordTrapePrice != null && objWaterMeterRecordTrapePrice != DBNull.Value)
                                    {
                                        strWaterMeterRecordTrapePrice = GetAvePrice(Convert.ToDecimal(objTotalNumber), objWaterMeterRecordTrapePrice.ToString(), intNotReadMonth);
                                    }
                                    else
                                    {
                                        strWaterMeterRecordTrapePrice[0] = "0";
                                        strWaterMeterRecordTrapePrice[1] = "无";
                                        strWaterMeterRecordTrapePrice[2] = "0";
                                    }
                                    decimal decExtraChargePrice1 = 0, decExtraChargePrice2 = 0, decExtraCharge1 = 0, decExtraCharge2 = 0, decExtraCharge = 0, decTotalFee = 0;
                                    object objExtraFee = dtWaterMeterType.Rows[0]["extraCharge"];
                                    if (objExtraFee != null && objExtraFee != DBNull.Value)
                                    {
                                        string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                                        for (int j = 0; j < strAllExtraFee.Length; j++)
                                        {
                                            string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                                            if (strSingleExtraFee[0].Contains("F"))
                                            {
                                                string strNum = strSingleExtraFee[0].Substring(1, 1);
                                                if (strNum == "1")
                                                    decExtraChargePrice1 = Convert.ToDecimal(strSingleExtraFee[1]);
                                                if (strNum == "2")
                                                    decExtraChargePrice2 = Convert.ToDecimal(strSingleExtraFee[1]);
                                            }
                                        }
                                    }
                                    //计算附加费
                                    decExtraCharge1 = decExtraChargePrice1 * Convert.ToDecimal(objTotalNumber);
                                    decExtraCharge2 = decExtraChargePrice2 * Convert.ToDecimal(strWaterMeterRecordTrapePrice[2]);

                                    decExtraCharge = decExtraCharge1 + decExtraCharge2;
                                    decTotalFee = decExtraCharge + Convert.ToDecimal(strWaterMeterRecordTrapePrice[2]);


                                    string strWaterUserNO = WATERUSERNO.Text;
                                    if (strWaterUserNO.Trim() == "")
                                    {
                                        mes.Show("获取用户号失败,变更失败!");
                                        IsChangeMeterType = false;
                                    }

                                    strSQLExcute = string.Format(@"
BEGIN TRAN
BEGIN
UPDATE readMeterRecord SET 
avePrice={0},avePriceDescribe='{1}',waterTotalCharge={2},extraChargePrice1={3},extraChargePrice2={4},
extraCharge1={5},extraCharge2={6},extraCharge={7},totalCharge={8},
waterMeterTypeClassID='{9}',waterMeterTypeClassName='{10}',waterMeterTypeId='{11}',waterMeterTypeName='{12}'
WHERE readMeterRecordId='{13}'", strWaterMeterRecordTrapePrice[0], strWaterMeterRecordTrapePrice[1], strWaterMeterRecordTrapePrice[2],
                              decExtraChargePrice1, decExtraChargePrice2, decExtraCharge1, decExtraCharge2, decExtraCharge, decTotalFee,
                              strWaterMeterTypeClassID, strWaterMeterTypeClassName, strWaterMeterTypeID, strWaterMeterTypeName, strReadMeterRecordID
                               );
                                    strSQLExcute += string.Format(@"UPDATE waterMeter SET
waterMeterTypeClassID='{0}',waterMeterTypeId='{1}'
WHERE waterUserId='{2}'", strWaterMeterTypeClassID, strWaterMeterTypeID, strWaterUserNO
                               );
                                    strSQLExcute += string.Format(@"
END
IF(@@ERROR>0)
BEGIN
ROLLBACK TRAN
RETURN
END
COMMIT TRAN
");
                                }
                                else
                                {
                                    mes.Show("获取新的用水性质信息失败,变更失败!");
                                    IsChangeMeterType = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                mes.Show("变更水价失败,原因:" + ex.Message);
                                log.Write(ex.ToString(), MsgType.Error);
                                IsChangeMeterType = false;
                            }
                        }
                        else
                        {
                            mes.Show("变更台账ID为空,变更失败!");
                            IsChangeMeterType = false;
                        }
                        #endregion
                    }
                    if (new SqlServerHelper().ExcuteSql(strSQLExcute) > 0)
                        IsChangeMeterType = true;
                    else
                        IsChangeMeterType = false;
                    #endregion
                    if (IsChangeMeterType)
                    {
                        Hashtable hu = new Hashtable();
                        hu["OPState"] = 1;
                        hu["OPUser"] = AppDomain.CurrentDomain.GetData("USERNAME").ToString();
                        hu["OPDate"] = DateTime.Now.ToString();
                        int upCount = new SqlServerHelper().UpdateByHashtable("User_WaterPrice", "TaskID", TaskID, hu);
                        if (upCount>0)
                        {
                            this.DialogResult = DialogResult.OK;
                            MessageBox.Show("用水性质变更成功！");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("用水性质变更成功 ，记录保存失败！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("用水性质变更失败！");
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
        /// <summary>
        /// 根据用水类别的阶梯水价获取平均单价和计算过程
        /// </summary>
        /// <param name="decTotalNumber">总用水量</param>
        /// <param name="strTrapePriceString">阶梯水价说明</param>
        /// <param name="intNotReadMonths">未抄月份</param>
        /// <returns></returns>
        private string[] GetAvePrice(decimal decTotalNumber, string strTrapePriceString, int intNotReadMonths)
        {
            string[] strComputeTrape = new string[3];
            //string strTrapePriceString="0-32:1.52|32-50:2.3|50-80:3.5|80-100:4.5|100-120:6";
            string[] strTrapePrice = strTrapePriceString.Split('|');
            decimal decWaterSum = 0, decWaterTotalNumber = decTotalNumber;
            for (int i = strTrapePrice.Length - 1; i >= 0; i--)
            {
                string[] strJTAndPrice = strTrapePrice[i].Split(':');
                string[] strJT = strJTAndPrice[0].Split('-');
                if (Information.IsNumeric(strJT[0]) && Information.IsNumeric(strJT[1]))
                {
                    if (decTotalNumber > (Convert.ToDecimal(strJT[0]) * intNotReadMonths) && decTotalNumber <= (Convert.ToDecimal(strJT[1]) * intNotReadMonths))
                    {
                        decWaterSum += (decTotalNumber - (Convert.ToDecimal(strJT[0]) * intNotReadMonths)) * (Convert.ToDecimal(strJTAndPrice[1]));

                        if (strComputeTrape[1] != null)
                            strComputeTrape[1] += "+(" + decTotalNumber.ToString() + "-" + (Convert.ToDecimal(strJT[0]) * intNotReadMonths) + ")*" + strJTAndPrice[1];
                        else
                            strComputeTrape[1] += "计算过程:(" + decTotalNumber.ToString() + "-" + (Convert.ToDecimal(strJT[0]) * intNotReadMonths) + ")*" + strJTAndPrice[1];

                        decTotalNumber = (Convert.ToDecimal(strJT[0]) * intNotReadMonths);
                        //decTotalNumber = decTotalNumber - Convert.ToDecimal(strJT[0]);
                    }
                    else
                        continue;
                }

            }
            if (decWaterTotalNumber > 0)
                strComputeTrape[0] = (decWaterSum / decWaterTotalNumber).ToString("f3");
            else
                strComputeTrape[0] = "0";
            strComputeTrape[1] += "=" + decWaterSum.ToString() + "÷" + decWaterTotalNumber.ToString() + "=" + strComputeTrape[0];
            strComputeTrape[2] = decWaterSum.ToString("F2");
            return strComputeTrape;
        }
        
    }
}

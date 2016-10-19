using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using MODEL;
using BASEFUNCTION;
using System.Data.OleDb;

namespace METERREADINGMACHINE
{
    public partial class frmWaterMeterCharge : Form
    {
        public frmWaterMeterCharge()
        {
            InitializeComponent();
        }
        BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();

        /// <summary>
        /// 用水类别名称、用水类别代码、用户名、水表号、上月读数、抄表流水号、抄表本（记录日志用）
        /// </summary>
        public string strWaterMeterTypeName = "", strWaterMeterTypeID = "", strWaterUserName = "", strSBH = "", strSYDS = "", strRecordID = "", strMeterReadingID;
        
        /// <summary>
        /// 父窗体
        /// </summary>
        public frmFromMachineManage frm = null;

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        private void frmWaterMeterCharge_Load(object sender, EventArgs e)
        {
            BindWaterMeterType();

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("操作员ID获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();


            labWaterUserName.Text = strWaterUserName;
            labWaterMeterNO.Text = strSBH;
            labWaterMeterSYDS.Text = strSYDS;
            labWaterMeterType.Text = strWaterMeterTypeName;
            txtSYDSNew.Text = strSYDS;
            cmbWaterMeterTypeNew.SelectedValue = strWaterMeterTypeID;
        }

        DataTable dtWaterMeterType =null;
        /// <summary>
        /// 绑定用水类别
        /// </summary>
        private void BindWaterMeterType()
        {
            dtWaterMeterType = BLLWATERMETERTYPE.Query("");
            cmbWaterMeterTypeNew.DataSource = dtWaterMeterType;
            cmbWaterMeterTypeNew.DisplayMember = "waterMeterTypeValue";
            cmbWaterMeterTypeNew.ValueMember = "waterMeterTypeId";
        }

        string strDBFPath = Application.StartupPath + @"\HndSet\";
        private void btOK_Click(object sender, EventArgs e)
        {
            if (mes.ShowQ("变更后该记录将置为未抄!\n确定要将用户'" + strWaterUserName + "'的水表编号为'" + strSBH + "'的水表初始读数变更吗?") != DialogResult.OK)
                return;
            if (!Information.IsNumeric(txtSYDSNew.Text))
            {
                mes.Show("上月读数只能为数字!");
                txtSYDSNew.Focus();
                return;
            }
            else
            {
                if ((int)Math.Ceiling(Convert.ToDouble(txtSYDSNew.Text)) != Convert.ToInt64(txtSYDSNew.Text))
                {
                    mes.Show("上月读数只能为整数!");
                    txtSYDSNew.Focus();
                    return;
                }
            }

            try
            {
                MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                MODELreadMeterRecord.readMeterRecordId = strRecordID;

                MODELreadMeterRecord.waterMeterLastNumber = Convert.ToInt32(txtSYDSNew.Text);
                MODELreadMeterRecord.MEMO = "初始读数变更:" + strSYDS + "→" + txtSYDSNew.Text + ";";

                if (BLLreadMeterRecord.UpdateHandSetWaterMeterLastNumber(MODELreadMeterRecord))
                {
                    string connectString =
                                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
                    string strSQLUpdateWaterMeterType = "UPDATE INTERDB SET sy1syds=" + MODELreadMeterRecord.waterMeterLastNumber +
                                                               " WHERE cbsx='" + strRecordID + "'";
                    int intRow = 0;
                    try
                    {
                        intRow = ExcuteSQL(strSQLUpdateWaterMeterType, connectString);
                    }
                    catch (Exception ex)
                    {
                        mes.Show("修改抄表机数据库失败,请确认数据文件是否存在");
                        log.Write(ex.ToString(), MsgType.Error);
                        return;
                    }
                    if (intRow > 0)
                    {
                        try
                        {
                            frm.dgList.CurrentRow.Cells["syds"].Value = MODELreadMeterRecord.waterMeterLastNumber;

                            string strSQLUpdateSetUnRead = "UPDATE INTERDB SET CBBZ='0',DYBZ='0' WHERE cbsx='" + strRecordID + "'";
                            ExcuteSQL(strSQLUpdateSetUnRead, connectString);

                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                            MODELOPERATORLOG.LOGCONTENT = "修改初始读数:" + strWaterUserName + "'-'" + strSBH +":"+ strSYDS + "→" + txtSYDSNew.Text;
                            MODELOPERATORLOG.METERREADINGID = strMeterReadingID;
                            MODELOPERATORLOG.LOGTYPE = "3";  //1代表用户 2代表水表 3抄表机
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strUserName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                        }
                        catch (Exception ex)
                        {
                            mes.Show("置为未抄失败,请确认抄表机数据文件是否存在");
                            log.Write(ex.ToString(), MsgType.Error);
                            return;
                        }
                    }
                    else
                    {
                        mes.Show("修改抄表机数据库失败,请确认数据文件中抄表记录是否存在!");
                        return;
                    }
                }
                else
                {
                    mes.Show("修改抄表表记录失败,请确认抄表表记录是否存在!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        ///根据用水类别的阶梯水价获取平均单价和计算过程
        /// </summary>
        /// <returns></returns>
        private string[] GetAvePrice(decimal decTotalNumber, string strTrapePriceString)
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
                    if (decTotalNumber > Convert.ToDecimal(strJT[0]) && decTotalNumber <= Convert.ToDecimal(strJT[1]))
                    {
                        decWaterSum += (decTotalNumber - Convert.ToDecimal(strJT[0])) * (Convert.ToDecimal(strJTAndPrice[1]));

                        if (strComputeTrape[1] != null)
                            strComputeTrape[1] += "+(" + decTotalNumber.ToString() + "-" + strJT[0] + ")*" + strJTAndPrice[1];
                        else
                            strComputeTrape[1] += "计算过程:(" + decTotalNumber.ToString() + "-" + strJT[0] + ")*" + strJTAndPrice[1];

                        decTotalNumber = Convert.ToDecimal(strJT[0]);
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
        ///// <summary>
        ///// 存储选择用水性质的单价、污水处理费、附加费
        ///// </summary>
        //decimal decPrice = 0, decExtraChargePrice1 = 0, decExtraChargePrice2 = 0;
        //private void cmbWaterMeterTypeNew_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataRow[] dr = dtWaterMeterType.Select("");
        //}
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        private int ExcuteSQL(string SQLString, string strConn)
        {
            using (OleDbConnection connection = new OleDbConnection(strConn))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                            connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btChangeWaterMeterTypeID_Click(object sender, EventArgs e)
        {
            if (mes.ShowQ("变更后该记录将置为未抄!\n确定要将用户'" + strWaterUserName + "'的水表编号为'" + strSBH + "'的用水性质信息变更吗?") != DialogResult.OK)
                return;
            try
            {
                MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();
                if (cmbWaterMeterTypeNew.SelectedValue == null || cmbWaterMeterTypeNew.SelectedValue == DBNull.Value)
                {
                    mes.Show("用水性质不能为空!");
                    return;
                }
                else
                {
                    DataRow[] drWaterMeterType = dtWaterMeterType.Select("waterMeterTypeId='" + cmbWaterMeterTypeNew.SelectedValue.ToString() + "'");
                    if (drWaterMeterType.Length > 0)
                    {
                        object objTrapePrice = drWaterMeterType[0]["trapezoidPrice"];

                        if (objTrapePrice != null && objTrapePrice!=DBNull.Value)
                        MODELreadMeterRecord.trapezoidPrice = objTrapePrice.ToString();

                        string[] strTrapePrice = objTrapePrice.ToString().Split('|');
                        if (strTrapePrice[0].Split(':').Length > 0)
                        {
                            if (Information.IsNumeric(strTrapePrice[0].Split(':')[1]))
                            {
                                MODELreadMeterRecord.avePrice = Convert.ToDecimal(strTrapePrice[0].Split(':')[1]);
                            }
                        }
                        object objExtraFee = drWaterMeterType[0]["extraCharge"];
                        if (objExtraFee != null && objExtraFee != DBNull.Value)
                        {
                            MODELreadMeterRecord.extraCharge = objExtraFee.ToString();
                            string[] strAllExtraFee = objExtraFee.ToString().Split('|');
                            for (int j = 0; j < strAllExtraFee.Length; j++)
                            {
                                string[] strSingleExtraFee = strAllExtraFee[j].Split(':');
                                if (strSingleExtraFee[0].Contains("F"))
                                {
                                    string strNum = strSingleExtraFee[0].Substring(1, 1);
                                    if (strNum == "1")
                                    {
                                        if (Information.IsNumeric(strSingleExtraFee[1]))
                                            MODELreadMeterRecord.extraChargePrice1 = Convert.ToDecimal(strSingleExtraFee[1]);
                                    }
                                    if (strNum == "2")
                                    {
                                        if (Information.IsNumeric(strSingleExtraFee[1]))
                                            MODELreadMeterRecord.extraChargePrice2 = Convert.ToDecimal(strSingleExtraFee[1]);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        mes.Show("获取用水单价失败,无法完成修改!");
                        return;
                    }
                }

                MODELreadMeterRecord.readMeterRecordId = strRecordID;

                MODELreadMeterRecord.waterMeterTypeId = cmbWaterMeterTypeNew.SelectedValue.ToString();
                MODELreadMeterRecord.waterMeterTypeName = cmbWaterMeterTypeNew.Text;
                MODELreadMeterRecord.MEMO = "用水性质变更:"  + strWaterMeterTypeName + "→" + cmbWaterMeterTypeNew.Text+";";

                if (BLLreadMeterRecord.UpdateHandSetWaterMeterType(MODELreadMeterRecord))
                {
                    string connectString =
                                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
                    string strSQLUpdateWaterMeterType = "UPDATE INTERDB SET yslbdm='" + MODELreadMeterRecord.waterMeterTypeId + "'," +
                                                              "yslb='" + MODELreadMeterRecord.waterMeterTypeName + "'," +
                                                              "szydj=" + MODELreadMeterRecord.avePrice + "," +
                                                              "fjfdj=" + MODELreadMeterRecord.extraChargePrice1 + "," +
                                                              "fjfdj1=" + MODELreadMeterRecord.extraChargePrice2 +
                                                               " WHERE recordid='" + strRecordID + "'";
                    int intRow = 0;
                    try
                    {
                        intRow = ExcuteSQL(strSQLUpdateWaterMeterType, connectString);
                    }
                    catch (Exception ex)
                    {
                        mes.Show("修改抄表机数据库失败,请确认数据文件是否存在");
                        log.Write(ex.ToString(), MsgType.Error);
                        return;
                    }
                    if (intRow > 0)
                    {
                        frm.dgList.CurrentRow.Cells["yslbdm"].Value = MODELreadMeterRecord.waterMeterTypeId;
                        frm.dgList.CurrentRow.Cells["yslb"].Value = MODELreadMeterRecord.waterMeterTypeName;
                        frm.dgList.CurrentRow.Cells["szydj"].Value = MODELreadMeterRecord.avePrice;
                        frm.dgList.CurrentRow.Cells["fjfdj"].Value = MODELreadMeterRecord.extraChargePrice1;
                        frm.dgList.CurrentRow.Cells["fjfdj1"].Value = MODELreadMeterRecord.extraChargePrice2;

                        string strSQLUpdateSetUnRead = "UPDATE INTERDB SET CBBZ='0',DYBZ='0' WHERE recordid='" + strRecordID + "'";
                        try
                        {
                            ExcuteSQL(strSQLUpdateSetUnRead, connectString);

                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                            MODELOPERATORLOG.LOGCONTENT = "修改用水性质:" + strWaterUserName + "'-'" + strSBH + ":" + strWaterMeterTypeName + "→" + cmbWaterMeterTypeNew.Text;
                            MODELOPERATORLOG.LOGTYPE = "3";  //1代表用户 2代表水表 3抄表机
                            MODELOPERATORLOG.METERREADINGID = strMeterReadingID;
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strUserName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                        }
                        catch (Exception ex)
                        {
                            mes.Show("置为未抄失败,请确认抄表机数据文件是否存在");
                            log.Write(ex.ToString(), MsgType.Error);
                            return;
                        }
                        if (mes.ShowQ("是否要继续更改水表的用水性质?") != DialogResult.OK)
                            return;

                        MODELwaterMeter MODELwaterMeter = new MODELwaterMeter();
                        MODELwaterMeter.waterMeterId = strSBH;
                        MODELwaterMeter.waterMeterTypeId = MODELreadMeterRecord.waterMeterTypeId;
                        if (BLLwaterMeter.UpdateWaterMeterType(MODELwaterMeter))
                        {
                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                            MODELOPERATORLOG.LOGCONTENT = "修改水表基础表用水性质:" + strWaterUserName + "'-'" + strSBH + ":" + strWaterMeterTypeName + "→" + cmbWaterMeterTypeNew.Text;
                            MODELOPERATORLOG.LOGTYPE = "3";  //1代表用户 2代表水表 3抄表机
                            MODELOPERATORLOG.METERREADINGID = strMeterReadingID;
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strUserName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                            mes.Show("水表编号为'" + strSBH + "'的用水性质更改成功!");
                        }
                    }
                    else
                    {
                        mes.Show("修改抄表机数据文件失败,请确认抄表记录是否存在");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
        }
    }
}

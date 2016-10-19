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
    public partial class frmWaterUserCharge : Form
    {
        public frmWaterUserCharge()
        {
            InitializeComponent();
        }

        BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLWATERMETERTYPE BLLWATERMETERTYPE = new BLLWATERMETERTYPE();
        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        BLLwaterMeter BLLwaterMeter = new BLLwaterMeter();

        /// <summary>
        /// 用户ID、用户名、抄表流水号
        /// </summary>
        public string strWaterUserNO = "", strWaterUserName = "", strRecordID = "", strMeterReadingID = "";
        
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
            labWaterUserName.Text = strWaterUserName;
            txtWaterUserName.Text = strWaterUserName;

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
        }

        string strDBFPath = Application.StartupPath + @"\HndSet\";
        private void btOK_Click(object sender, EventArgs e)
        {
            if (txtWaterUserName.Text.Trim()=="")
            {
                mes.Show("请输入变更后的用户名!");
                txtWaterUserName.Focus();
                return;
            }
            if (mes.ShowQ("确定要将姓名为'" + strWaterUserName + "'的用户名变更为'" + txtWaterUserName.Text + "'吗?") != DialogResult.OK)
                return;

            try
            {
                MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                MODELreadMeterRecord.readMeterRecordId = strRecordID;

                MODELreadMeterRecord.waterUserName = txtWaterUserName.Text;

                if (BLLreadMeterRecord.UpdateHandSetWaterUserName(MODELreadMeterRecord))
                {
                    string connectString =
                                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDBFPath + ";Extended Properties=dBASE IV;User ID=Admin;Password=;";
                    string strSQLUpdateWaterMeterType = "UPDATE INTERDB SET yhm='" + MODELreadMeterRecord.waterUserName + "' " +
                                                               " WHERE recordid='" + strRecordID + "'";
                    int intRow = ExcuteSQL(strSQLUpdateWaterMeterType, connectString);
                    if (intRow > 0)
                    {
                        frm.dgList.CurrentRow.Cells["yhm"].Value = MODELreadMeterRecord.waterUserName;
                        //mes.Show("信息变更成功,如果要更改用户基础信息请手动更改!");
                        if (mes.ShowQ("信息变更成功,是否要继续更改用户基础信息?") != DialogResult.OK)
                            return;
                        MODELWaterUser MODELWaterUser = new MODELWaterUser();
                        MODELWaterUser.waterUserNO = strWaterUserNO;
                        MODELWaterUser.waterUserName = MODELreadMeterRecord.waterUserName;
                        if (BLLwaterUser.UpdateHandSetUser(MODELWaterUser))
                        {
                            mes.Show("用户基础信息变更成功!");

                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                            MODELOPERATORLOG.LOGCONTENT = "修改用户名:" + strWaterUserName +  "→" + txtWaterUserName.Text;
                            MODELOPERATORLOG.METERREADINGID = strMeterReadingID;
                            MODELOPERATORLOG.LOGTYPE = "3";  //1代表用户 2代表水表 3抄表机
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strUserName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                        }
                        else
                        {
                            mes.Show("用户基础信息变更失败,请手动修改户号为'"+strWaterUserNO+"的用户名!");
                            return;
                        }

                    }
                    else
                    {
                        mes.Show("更新抄表数据文件失败,请重试!");
                        return;
                    }
                }
                else
                {
                    mes.Show("更新抄表数据失败,请重试!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
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
    }
}

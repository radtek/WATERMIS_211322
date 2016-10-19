using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BASEFUNCTION;
using BLL;
using MODEL;

namespace WATERFEEMANAGE
{
    public partial class frmChangeWaterUserName : Form
    {
        public frmChangeWaterUserName()
        {
            InitializeComponent();
        }

        BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();
        Messages mes = new Messages();
        BLLreadMeterRecord BLLreadMeterRecord = new BLLreadMeterRecord();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        public string strWaterUserName = "", strRecordID = "", strWaterUserID = "", strMeterReadingID = "";
        public frmWaterMeterReadCanModify frmWaterMeterRead = null;

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        private void frmChangeEndNumber_Load(object sender, EventArgs e)
        {
            this.txtWaterUserName.Text = strWaterUserName;

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

        private void btChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (strRecordID.Trim() == "")
                {
                    mes.Show("抄表记录ID为空，请重新查询抄表记录后再修改用户名!");
                    return;
                }
                if (txtWaterUserNameNew.Text.Trim() == "")
                {
                    mes.Show("请输入新用户名!");
                    txtWaterUserNameNew.Focus();
                    return;
                }
                if (mes.ShowQ("确定要变更'" + strWaterUserName + "'的用户名吗？") != DialogResult.OK)
                    return;
                MODELreadMeterRecord MODELreadMeterRecord = new MODELreadMeterRecord();

                MODELreadMeterRecord.waterUserName = txtWaterUserNameNew.Text;

                MODELreadMeterRecord.readMeterRecordId = strRecordID;
                if (BLLreadMeterRecord.UpdateHandSetWaterUserName(MODELreadMeterRecord))
                {
                    try
                    {
                        MODELWaterUser MODELWaterUser = new MODELWaterUser();
                        MODELWaterUser.waterUserId = strWaterUserID;
                        MODELWaterUser.waterUserName=txtWaterUserNameNew.Text;
                        if (BLLwaterUser.UpdateUserName(MODELWaterUser))
                        {
                            frmWaterMeterRead.dgWaterList.CurrentRow.Cells["waterUserName"].Value = txtWaterUserNameNew.Text;
                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                            MODELOPERATORLOG.METERREADINGID = strMeterReadingID;
                            MODELOPERATORLOG.LOGCONTENT = "变更用户名:" + MODELWaterUser.waterUserId + "-" +txtWaterUserName.Text+"→"+ MODELWaterUser.waterUserName;
                            MODELOPERATORLOG.LOGTYPE = "1";  //1代表用户 2代表水表
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strUserName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                            mes.Show("户名变更成功!");
                            btChange.Enabled = false;
                        }
                    }
                    catch (Exception)
                    {
                        mes.Show("户名基础信息变更失败,请重试!");
                        return;
                    }
                }
                else
                {
                    mes.Show("抄表记录户名变更失败,请重试!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show("抄表记录户名变更失败,原因:" + ex.ToString());
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}

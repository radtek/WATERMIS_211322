using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using BLL;
using MODEL;

namespace WATERFEEMANAGE
{
    public partial class frmChangeWaterUserMesApply : Form
    {
        public frmChangeWaterUserMesApply()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        public string strWaterUserID = "";
        public string strWaterUserName = "";
        public string strWaterUserAddress = "";
        public string strWaterUserTel = "";
        public string strLogID = "";
        public string strUserName = "";

        private void frmChangeWaterUserMesApply_Load(object sender, EventArgs e)
        {
            labWaterUserName.Text = strWaterUserName;
            labWaterUserAddress.Text = strWaterUserAddress;
            labWaterUserTel.Text = strWaterUserTel;
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQLUpdate = "UPDATE WATERUSER SET ";
                string strUpdateContent = "";
                if (chkWaterUserName.Checked)
                {
                    strUpdateContent = "WATERUSERNAME='" + txtWaterUserName.Text + "'";
                }
                if (chkWaterUserAddress.Checked)
                {
                    if (strUpdateContent == "")
                        strUpdateContent = "waterUserAddress='" + txtWaterUserAddress.Text + "'";
                    else
                        strUpdateContent += "," + "waterUserAddress='" + txtWaterUserAddress.Text + "'";
                }
                if (chkWaterUserTel.Checked)
                {
                    if (strUpdateContent == "")
                        strUpdateContent = "waterUserTelphoneNO='" + txtWaterUserTel.Text + "'";
                    else
                        strUpdateContent += "," + "waterUserTelphoneNO='" + txtWaterUserTel.Text + "'";
                }
                if (strUpdateContent == "")
                {
                    mes.Show("请勾选要变更的信息!");
                    return;
                }
                else
                {
                    if (BLLwaterUser.UpdateSQL(strSQLUpdate + strUpdateContent + " WHERE WATERUSERID='" + strWaterUserID + "'"))
                    {
                        frmWaterMeterReadSingleCharge frm = (frmWaterMeterReadSingleCharge)this.Owner;
                        if (chkWaterUserName.Checked)
                        {
                            frm.txtWaterUserName.Text = txtWaterUserName.Text;
                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                            //MODELOPERATORLOG.METERREADINGID = strMeterReadingID;
                            MODELOPERATORLOG.LOGCONTENT = "变更用户名:" + strWaterUserID + "-" + labWaterUserName.Text + "→" + txtWaterUserName.Text;
                            MODELOPERATORLOG.LOGTYPE = "1";  //1代表用户 2代表水表
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strUserName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                        }
                        if (chkWaterUserAddress.Checked)
                        {
                            frm.txtWaterUserAddress.Text = txtWaterUserAddress.Text;
                        }
                        if (chkWaterUserTel.Checked)
                        {
                            frm.txtWaterUserPhone.Text = txtWaterUserTel.Text;
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        mes.Show("变更用户信息失败!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BASEFUNCTION;
using MODEL;
using BLL;
using System.Net;

namespace WATERMIS
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        //[DllImport("user32.dll")]       
        //public static extern bool ReleaseCapture();      
        //[DllImport("user32.dll")]      
        //public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);     
        //public const int WM_SYSCOMMAND = 0x0112;     
        //public const int SC_MOVE = 0xF010;      
        //public const int HTCAPTION = 0x0002;  

        string strLogNameOld = "";
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //this.Location = new Point(20,(Screen.PrimaryScreen.WorkingArea.Height-this.Height)/2);
            string strName= ConfigurationSettings.AppSettings["USERNAME"];
            txtLogName.Text = strName;
            //btLogin_Click(null, null);
        }

        Messages mes = new Messages();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLOPERATORLOG BLLOPERATORLOG = new BLLOPERATORLOG();
        private void btLogin_Click(object sender, EventArgs e)
        {
            string strLogID;
            string strName;
            string strRealName;
            string strPWD;
            string strDepID, strDepName, strPostID, strState = "", strGroupID="",strGroupName="";
            string strSQL;
            DataTable dt = new DataTable();
            if (txtLogName.Text.Trim() == "")
            {
                mes.Show("请输入用户名!");
                return;
            }
            else
                strName = txtLogName.Text.Trim();
            if (txtLogPWD.Text.Trim() == "")
            {
                mes.Show("请输入密码!");
                return;
            }
            else
                strPWD = txtLogPWD.Text.Trim();
            //strPWD = DBUtility.DESEncrypt.Encrypt(strPWD);
            strSQL = " AND LOGINNAME='" + strName + "' AND Password='" + strPWD + "' ";
            //btLogin.Enabled = false;
            //btCancle.Enabled = false;
            //labelS.Visible = true;
            try
            {
                    dt = BLLBASE_LOGIN.QueryUser(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        strLogID = dt.Rows[0]["LOGINID"].ToString();
                        strRealName = dt.Rows[0]["USERNAME"].ToString();
                        strDepID = dt.Rows[0]["DEPARTMENTID"].ToString();
                        strPostID = dt.Rows[0]["POSTID"].ToString();
                        strDepName = dt.Rows[0]["DEPARTMENTNAME"].ToString();
                        strState = dt.Rows[0]["userstateS"].ToString();
                        strGroupID = dt.Rows[0]["groupID"].ToString();
                        strGroupName = dt.Rows[0]["groupName"].ToString();

                        if (strState == "停用")
                        {
                            mes.Show("用户已被管理员停用!");
                            return;
                        }


                        AppDomain.CurrentDomain.SetData("LOGINID", strLogID);
                        AppDomain.CurrentDomain.SetData("LOGINNAME", strName);
                        AppDomain.CurrentDomain.SetData("USERNAME", strRealName);
                        AppDomain.CurrentDomain.SetData("DEPARTMENTID", strDepID);
                        AppDomain.CurrentDomain.SetData("DEPARTMENTNAME", strDepName);
                        AppDomain.CurrentDomain.SetData("POSTID", strPostID);
                        AppDomain.CurrentDomain.SetData("GROUPID", strGroupID);
                        AppDomain.CurrentDomain.SetData("GROUPNAME", strGroupName);

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //AppSettingsSection app = config.AppSettings; //app.Settings.Add("x", "this is X"); 
            //            app.Settings["USERNAME"].Value = strName;
                        //            config.Save(ConfigurationSaveMode.Modified);

                        //如果配置文件中的登陆名和现在登陆的登陆名不一致，则修改config配置文件中的用户名
                        if (strLogNameOld != strName)
                            ModifyConfig(strName);

                        try
                        {
                            MODELOPERATORLOG MODELOPERATORLOG = new MODELOPERATORLOG();
                            MODELOPERATORLOG.LOGCONTENT = "用户:" + strLogID + "-" + strRealName + "登陆,登陆IP:" + GetAddressIP();
                            //MODELOPERATORLOG.METERREADINGID = cmbWaterUserMeterReadingNO.SelectedValue.ToString();
                            MODELOPERATORLOG.LOGTYPE = "5";  //5登陆日志
                            MODELOPERATORLOG.OPERATORID = strLogID;
                            MODELOPERATORLOG.OPERATORNAME = strRealName;
                            BLLOPERATORLOG.Insert(MODELOPERATORLOG);
                        }
                        catch (Exception ex)
                        {

                        }
                        this.DialogResult = DialogResult.OK;

                        this.Close();
                    }
                    else
                    {
                        mes.Show("用户不存在或密码错误!");
                        return;
                    }
            }
            catch (Exception ex)
            {
                //labelS.Visible = false;
                mes.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        private string GetAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                    break;
                }
            }
            return AddressIP;
        }

        private void txtLogPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btLogin_Click(null,null);
            }
        }

        private void txtLogName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLogPWD.Focus();
            }
        }

        private void btCancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void ModifyConfig(string strName)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == "USERNAME")
                {
                    isModified = true;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isModified)
            {
                config.AppSettings.Settings.Remove("USERNAME");
            }
            config.AppSettings.Settings.Add("USERNAME", strName);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            txtLogPWD.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now.AddDays(-1);
            TimeSpan ts = dt1 - dt2;
            mes.Show(dt1.ToShortDateString()+"-"+dt2.ToShortDateString()+"=" +ts.Days.ToString());
        }

        private void labConnect_Click(object sender, EventArgs e)
        {
            frmConnectConfig frm = new frmConnectConfig();
            frm.ShowDialog();
        }
        ///// <summary>
        ///// 写配置文件,如果节点不存在则自动创建
        ///// </summary>
        ///// <param name="key">键值</param>
        ///// <param name="value">值</param>
        ///// <returns></returns>
        //public static bool SetConfig(string key, string value)
        //{
        //    try
        //    {
        //        Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //        if (!conf.AppSettings.Settings.AllKeys.Contains(key))
        //            conf.AppSettings.Settings.Add(key, value);
        //        else
        //            conf.AppSettings.Settings[key].Value = value;
        //        conf.Save();
        //        return true;
        //    }
        //    catch { return false; }
        //}
    }
}

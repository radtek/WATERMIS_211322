using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BASEFUNCTION
{
    public partial class frmConnectConfig : Form
    {
        public frmConnectConfig()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        Log Log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        //存储配置文件中的登陆名、密码、数据库名及IP地址
        string strLogNameOld = "";
        string strPWDOld = "";
        string strDataBaseOld = "";
        string strIPOld = "";

        private void frmConnectConfig_Load(object sender, EventArgs e)
        {
            strLogNameOld = ConfigurationSettings.AppSettings["connStringLoginName"];
            strPWDOld = ConfigurationSettings.AppSettings["connStringPWD"];
            strDataBaseOld = ConfigurationSettings.AppSettings["connStringDataSourceName"];
            strIPOld = ConfigurationSettings.AppSettings["connStringServerIP"];

            txtName.Text = strLogNameOld;
            txtPWD.Text = strPWDOld;
            txtDataBase.Text = strDataBaseOld;
            txtIP.Text = strIPOld;
        }

        private void btConnectTest_Click(object sender, EventArgs e)
        {
            string strLogName = "", strPWD = "", strDataBase = "", strIP = "";

            if (txtName.Text != "")
                strLogName = txtName.Text;
            else
            {
                mes.Show("用户名不能为空!");
                txtName.Focus();
                return;
            }

            strPWD = txtPWD.Text;

            if (txtDataBase.Text != "")
                strDataBase = txtDataBase.Text;
            else
            {
                mes.Show("数据库名不能为空!");
                txtDataBase.Focus();
                return;
            }

            if (txtIP.Text != "")
                strIP = txtIP.Text;
            else
            {
                mes.Show("服务器IP不能为空!");
                txtIP.Focus();
                return;
            }

            string strSQLConn = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", strIP, strDataBase, strLogName, strPWD);
            using (SqlConnection sqlconn = new SqlConnection(strSQLConn))
            {
                try
                {
                    sqlconn.Open();
                }
                catch (SqlException ex)
                {
                    string strErrCode = ex.Message;
                    mes.Show("数据库连接失败!错误:" + strErrCode);
                    return;
                }
                mes.Show("数据库连接成功!");
            }
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string strLogName = "", strPWD = "", strDataBase = "", strIP = "";

                if (txtName.Text != "")
                    strLogName = txtName.Text;
                else
                {
                    mes.Show("用户名不能为空!");
                    txtName.Focus();
                    return;
                }

                strPWD = txtPWD.Text;

                if (txtDataBase.Text != "")
                    strDataBase = txtDataBase.Text;
                else
                {
                    mes.Show("数据库名不能为空!");
                    txtDataBase.Focus();
                    return;
                }

                if (txtIP.Text != "")
                    strIP = txtIP.Text;
                else
                {
                    mes.Show("服务器IP不能为空!");
                    txtIP.Focus();
                    return;
                }
                if (strLogNameOld != strLogName)
                {
                    ModifyConfig(strLogName, "connStringLoginName");
                    strLogNameOld = strLogName;
                }

                if (strPWDOld != strPWD)
                {
                    ModifyConfig(strPWD, "connStringPWD");
                    strPWDOld = strPWD;
                }

                if (strDataBaseOld != strDataBase)
                {
                    ModifyConfig(strDataBase, "connStringDataSourceName");
                    strDataBaseOld = strDataBase;
                }

                if (strIPOld != strIP)
                {
                    ModifyConfig(strIP, "connStringServerIP");
                    strIPOld = strIP;
                }
                string strSQLConn = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", strIP, strDataBase, strLogName, strPWD);
                DBUtility.DbHelperSQL.connectionString = strSQLConn;
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                Log.Write(ex.ToString(), MsgType.Error);
            }
        }

        /// <summary>
        /// 修改config配置文件
        /// </summary>
        /// <param name="strName"></param>
        private void ModifyConfig(string strValue,string strKey)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    isModified = true;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isModified)
            {
                config.AppSettings.Settings.Remove(strKey);
            }
            config.AppSettings.Settings.Add(strKey, strValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}

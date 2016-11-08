using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using BASEFUNCTION;
using BLL;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using System.Diagnostics;

namespace WATERMIS
{
    static class Program
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            using (SqlConnection sqlconn = new SqlConnection(DBUtility.DbHelperSQL.connectionString))
            {
                try
                {
                    sqlconn.Open();
                }
                catch (SqlException ex)
                {
                    string strErrCode = ex.Message;
                    MessageBox.Show("数据库连接失败!错误:" + strErrCode);
                    frmConnectConfig frmConnectConfig = new frmConnectConfig();
                    frmConnectConfig.ShowDialog();
                    return;
                }
            }

            Messages mes = new Messages();
            if (mes.TestTheProcess())//检测程序是否已打开。
                return;

            #region 监测是否有新版本
            BLLFILEUPLOAD BLLFILEUPLOAD = new BLLFILEUPLOAD();
            string strVersion = "";
            string strConfigPath = Application.StartupPath + @"\CONFIG.INI";
            if (!File.Exists(strConfigPath))
            {
                mes.Show("配置文件已丢失，请联系开发人员。");
                Application.Exit();
                return;
            }
            StringBuilder strRead = new StringBuilder(255);
            int i = GetPrivateProfileString("VERSION", "VERSION", "", strRead, 255, strConfigPath);
            strVersion = strRead.ToString();
            int intCount = 0;
            try
            {
                string strCount = "SELECT COUNT(*) FROM FILEUPLOAD WHERE VERSION>'" + strVersion + "'";
                object objCount = BLLFILEUPLOAD.QueryCustom(strCount);
                if (objCount != null && objCount != DBNull.Value)
                    intCount = Convert.ToInt32(objCount);
            }
            catch (Exception ex)
            {

            }
            #endregion
            if (intCount > 0)
            {
                Application.Exit();
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(Application.StartupPath + @"\DOWNLOAD.exe");
            }
            else
            {
                FrmLogin frm = new FrmLogin();
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
            }
        }
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
            //BLLBASE_LOGIN.SETSTATE(GName.ToString(), GPWD.ToString(), "0");
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Log lg = new Log(Application.StartupPath + "\\Log\\", LogType.Daily);
            lg.Write(e.Exception.ToString(), MsgType.Error);
            Messages mes = new Messages();
            mes.Show(e.Exception.Message.ToString());
        }
    }
}

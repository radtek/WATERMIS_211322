using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.InteropServices; 
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using DBUtility;
using BASEFUNCTION;

namespace DOWNLOAD
{
    public partial class frmDownLoad : Form
    {
        public frmDownLoad()
        {
            InitializeComponent();
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 文件版本信息
        /// </summary>
        string strVersion = "";
        /// <summary>
        /// 配置文件路径
        /// </summary>
        string strConfigPath = "";
            DataTable dt = new DataTable();
        private void frmDownLoad_Load(object sender, EventArgs e)
        {
            strConfigPath = Application.StartupPath + @"\CONFIG.INI";
            if (!File.Exists(strConfigPath))
            {
                MessageBox.Show("配置文件已丢失，请联系开发人员。");
                this.Dispose();
                this.Close();
                return;
            }
            StringBuilder strRead = new StringBuilder(255);
            int i = GetPrivateProfileString("VERSION", "VERSION", "", strRead, 255, strConfigPath);
            strVersion = strRead.ToString();

            //strVersion = ConfigurationSettings.AppSettings["VERSION"];
            string strServerIp = ReadConfig.GetAttributeValue("connStringServerIP");
            string strDataSourceName = ReadConfig.GetAttributeValue("connStringDataSourceName");
            string strLoginName = ReadConfig.GetAttributeValue("connStringLoginName");
            string strPWD = ReadConfig.GetAttributeValue("connStringPWD");
            string strConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", strServerIp, strDataSourceName, strLoginName, strPWD);
            DBUtility.DbHelperSQL.connectionString = strConnectionString;

            dt = Query(" AND VERSION>'" + strVersion + "'");
            if (dt.Rows.Count > 0)
                btDown.Enabled = true;
            else
                btDown.Enabled = false;
        }
        /// <summary>
        /// 监测主系统是否在运行
        /// </summary>
        private bool TestTheProcess()
        {
            bool isProcess = false;
            Process currentProcess = Process.GetCurrentProcess(); //得到当前进程的ID
            string strProcessName = "WATERMIS";
            Process[] procList = Process.GetProcessesByName(strProcessName);//根据进程的名称得到所有进程
            if (procList.Length > 0)
            {
                MessageBox.Show("系统检测到主程序正在运行,请关闭主程序后再执行升级操作!");
                isProcess = true;
            }
            //foreach (Process proc in procList)
            //{
            //    //找到相同进程
            //    if (proc.Id == currentProcess.Id)
            //    {
            //        MessageBox.Show("系统监测到主程序正在运行,请关闭主程序后再执行升级操作!");
            //        isProcess = true;
            //        break;
            //    }
            //}
            return isProcess;
        }
        private void btDown_Click(object sender, EventArgs e)
        {
            if (TestTheProcess())
                return;
            labState.Text = "系统正在更新，请勿关闭此对话框，请稍后...";
            try
            {
                strVersion = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int intS = dt.Rows[i]["FILENAME"].ToString().LastIndexOf('.');
                    int intlength = dt.Rows[i]["FILENAME"].ToString().Length;
                    //string strExtension = "";

                    //int intFirstVersion = 0;//判断是不是自己写的程序。自己写的程序版本号均为1.0.0.x。

                    MODELFILEDOWNLOAD MODELFILEDOWNLOAD = new MODELFILEDOWNLOAD();
                    MODELFILEDOWNLOAD.FILECONTENT = new Byte[0];
                    MODELFILEDOWNLOAD.FILECONTENT = (Byte[])(dt.Rows[i]["FILECONTENT"]);
                    MODELFILEDOWNLOAD.FILENAME = dt.Rows[i]["FILENAME"].ToString();
                    MODELFILEDOWNLOAD.VERSION = dt.Rows[i]["VERSION"].ToString();
                    MODELFILEDOWNLOAD.FILEPATH = dt.Rows[i]["FILEPATH"].ToString();
                    strVersion = MODELFILEDOWNLOAD.VERSION;
                    //strExtension = MODELFILEDOWNLOAD.FILENAME.Substring(intS, intlength - intS);
                    //int intIsHave= MODELFILEDOWNLOAD.VERSION.IndexOf('.');//判断版本中是否用‘.’分割。
                    //if (intIsHave > 0)
                    //{
                    //    intFirstVersion = Convert.ToInt32(MODELFILEDOWNLOAD.VERSION.Substring(0, intIsHave));
                    //    if ((strExtension.ToLower() == ".dll" || strExtension.ToLower() == ".exe") && intFirstVersion == 2012)
                    //        strVersion = MODELFILEDOWNLOAD.VERSION;
                    //}
                    FileStream fs = new FileStream(Application.StartupPath + @"\" + MODELFILEDOWNLOAD.FILEPATH +@"\"+ MODELFILEDOWNLOAD.FILENAME, FileMode.OpenOrCreate);
                    fs.Write(MODELFILEDOWNLOAD.FILECONTENT, 0, MODELFILEDOWNLOAD.FILECONTENT.Length);
                    fs.Close();
                    labFile.Text += Environment.NewLine + "文件名:" + MODELFILEDOWNLOAD.FILENAME + " 当前版本:" + MODELFILEDOWNLOAD.VERSION;
                }
                if (strVersion != "")
                {
                    WritePrivateProfileString("VERSION", "VERSION", strVersion, strConfigPath);
                }
                labState.Text = "更新成功!";

                if (MessageBox.Show("文件更新成功，是否启动主系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Application.Exit();
                    System.Diagnostics.Process process = System.Diagnostics.Process.Start(Application.StartupPath + @"\WATERMIS.exe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private DataTable Query(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM FILEUPLOAD WHERE 1=1 ");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
    }
    class MODELFILEDOWNLOAD
    {
        private string _FILENAME;
        private string _VERSION;
        private Byte[] _FILECONTENT;
        private DateTime _OPERATORTIME;
        private string _FILEPATH;
        private string _MEMO;

        public string FILENAME
        {
            get
            {
                return _FILENAME;
            }
            set
            {
                _FILENAME = value;
            }
        }
        public string VERSION
        {
            get
            {
                return _VERSION;
            }
            set
            {
                _VERSION = value;
            }
        }
        public Byte[] FILECONTENT
        {
            get
            {
                return _FILECONTENT;
            }
            set
            {
                _FILECONTENT = value;
            }
        }
        public DateTime OPERATORTIME
        {
            get
            {
                return _OPERATORTIME;
            }
            set
            {
                _OPERATORTIME = value;
            }
        }
        public string FILEPATH
        {
            get
            {
                return _FILEPATH;
            }
            set
            {
                _FILEPATH = value;
            }
        }
        public string MEMO
        {
            get
            {
                return _MEMO;
            }
            set
            {
                _MEMO = value;
            }
        }
    }
}

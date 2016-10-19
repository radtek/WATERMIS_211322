using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UPLOAD
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //using (SqlConnection sqlconn = new SqlConnection(DBUtility.DbHelperSQL.connectionString))
            //{
            //    try
            //    {
            //        sqlconn.Open();
            //    }
            //    catch (SqlException ex)
            //    {
            //        string strErrCode = ex.ErrorCode.ToString();
            //        MessageBox.Show("数据库连接失败!错误代码:" + strErrCode);
            //        return;
            //    }
            //}
            Application.Run(new frmUpload());
        }
    }
}

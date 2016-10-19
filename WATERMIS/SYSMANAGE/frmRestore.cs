using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BLL;
using MODEL;
using BASEFUNCTION;
using System.Configuration;

namespace SYSMANAGE
{
    public partial class frmRestore : DockContentEx
    {
        public frmRestore()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        private void btBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                string strDataSourceName = ConfigurationSettings.AppSettings["connStringDataSourceName"];
                string strBackUpPath;
                if (mes.ShowQ("    该操作会关闭所有正在连接服务器的客户端，数据库还原前请先做好\n数据库备份,还原后数据将无法恢复,确定要继续吗?") != DialogResult.OK)
                    return;
                OpenFileDialog OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Filter = "数据库备份(*.bak)|*.bak";
                OpenFileDialog.InitialDirectory = Application.StartupPath + @"\Data";
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    strBackUpPath=OpenFileDialog.FileName;
                    if (!File.Exists(strBackUpPath))
                    {
                        mes.Show("备份文件不存在，请确认文件是否存在.");
                        return;
                    }
                        labPosition.Text = "备份所在路径："+strBackUpPath;
                    string strSQL = "select spid from master..sysprocesses where dbid=db_id('" + strDataSourceName + "')";
                    DataTable dt = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        string strSQLKILL = "kill "+dt.Rows[i][0].ToString();
                        DBUtility.DbHelperSQL.ExecuteSql(strSQLKILL);
                    }
                    string strRestore = "use master restore database " + strDataSourceName + " from Disk='" + strBackUpPath + "'";
                    if (DBUtility.DbHelperSQL.ExecuteSql(strRestore) != 0)
                    {
                        mes.Show("数据库还原成功!");
                    }
                }
            }
            catch (Exception ex)
            {
                mes.GetErrorMes(ex);
            }
        }
    }
}

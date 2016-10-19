using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BLL;
using MODEL;
using BASEFUNCTION;

namespace SYSMANAGE
{
    public partial class frmBackUp : DockContentEx
    {
        public frmBackUp()
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
                SaveFileDialog SaveFileDialog = new SaveFileDialog();
                SaveFileDialog.Filter = "数据库备份(*.bak)|*.bak";
                SaveFileDialog.InitialDirectory = Application.StartupPath + @"\Data";
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    strBackUpPath = SaveFileDialog.FileName;
                    string strSQL = "BACKUP DATABASE " + strDataSourceName + " TO Disk='" + strBackUpPath + "'";
                    if (DBUtility.DbHelperSQL.ExecuteSql(strSQL) != 0)
                    {
                        mes.Show("备份成功!");
                        labPosition.Text ="备份路径："+ strBackUpPath;
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

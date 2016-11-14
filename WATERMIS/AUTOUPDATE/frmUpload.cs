using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;

namespace UPLOAD
{
    public partial class frmUpload : Form
    {
        public frmUpload()
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

        Messages mes = new Messages();
        ReadConfig ReadConfig = new ReadConfig();
        private void frmUpload_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;

            strConfigPath = Application.StartupPath + @"\CONFIG.INI";
            if (!File.Exists(strConfigPath))
            {
                MessageBox.Show("配置文件已丢失，请联系开发人员。");
                this.Dispose();
                this.Close();
                return;
            }

            TreeNode trFather = tvDirectory.Nodes.Add("根目录");
            trFather.Tag = "";
            GetSubDirectoryNodes(trFather, Application.StartupPath, false);
            StringBuilder strRead = new StringBuilder(255);
            int i = GetPrivateProfileString("VERSION", "VERSION", "", strRead, 255, strConfigPath);
            strVersion = strRead.ToString();

            this.Text = "上传文件—当前系统版本:" + strVersion;

            if (strVersion.IndexOf('.') > 0)
            {
                if (Information.IsNumeric(strVersion))
                {
                    strVersion = (Convert.ToDouble(strVersion) + 0.1).ToString("0.0");
                    string[] str = strVersion.Split('.');
                    txtVersion1.Text = str[0];
                    txtVersion2.Text = str[1];
                }

            }
            string strServerIp = ReadConfig.GetAttributeValue("connStringServerIP");
            string strDataSourceName = ReadConfig.GetAttributeValue("connStringDataSourceName"); 
            string strLoginName = ReadConfig.GetAttributeValue("connStringLoginName");
            string strPWD = ReadConfig.GetAttributeValue("connStringPWD");
            string strConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID=SERVICECLIENT;Password=##AUTHORITY@C2s;", strServerIp, strDataSourceName, strLoginName, strPWD);
           DBUtility.DbHelperSQL.connectionString = strConnectionString;
        }

        private void frmUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否启动主程序程序开始升级?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                System.Diagnostics.Process process = System.Diagnostics.Process.Start(Application.StartupPath + @"\WATERMIS.exe");
                //this.Close();
            }
        }
        private void ModifyConfig(string strName)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == "VERSION")
                {
                    isModified = true;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isModified)
            {
                config.AppSettings.Settings.Remove("VERSION");
            }
            config.AppSettings.Settings.Add("VERSION", strName);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        string strFullName = "";
        private void btPreview_Click(object sender, EventArgs e)
        {
            OpenFileDialog opdialog = new OpenFileDialog();
            opdialog.Filter = "dll文件(*.dll)|*.dll|exe程序文件(*.exe)|*.exe|报表文件(*.frx)|*.frx|所有文件(*.*)|*.*";
            if (opdialog.ShowDialog() == DialogResult.OK)
            {
                strFullName = "";
                txtFileName.Clear();
                strFullName = opdialog.FileName;
                if (!File.Exists(strFullName))
                {
                    MessageBox.Show("选择的文件已经删除或者不存在!请重新选择。");
                    txtFileName.Clear();
                    return;
                }
                else
                    txtFileName.Text = strFullName;
            }
        }
        public string AssemblyFileVersion()
        {

            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            else
            {
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }
        private void btUpload_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Trim() == "")
            {
                MessageBox.Show("请先点击浏览按钮选择要上传的文件!");
                btPreview.Focus();
                return;
            }
            if (!Information.IsNumeric(txtVersion1.Text))
            {
                MessageBox.Show("版本号只能为整数数字");
                txtVersion1.Focus();
                return;
            }
            if (!Information.IsNumeric(txtVersion2.Text))
            {
                MessageBox.Show("版本号只能为整数数字");
                txtVersion2.Focus();
                return;
            }
            if (!File.Exists(strFullName))
            {
                MessageBox.Show("选择的文件已经删除或者不存在!请重新选择。");
                txtFileName.Clear();
                return;
            }
            if (tvDirectory.SelectedNode == null)
            {
                MessageBox.Show("请选择文件的更新路径!");
                tvDirectory.Focus();
                return;
            }
            else
            {
                if (tvDirectory.SelectedNode.Tag == null || tvDirectory.SelectedNode.Tag == DBNull.Value)
                {
                    MessageBox.Show("获取文件的更新路径失败,请重新选择!");
                    tvDirectory.Focus();
                    return;
                }
            }
            try
            {
                FileInfo fileinfo = new FileInfo(strFullName);
                MODELFILEDOWNLOAD MODELFILEDOWNLOAD = new MODELFILEDOWNLOAD();
                MODELFILEDOWNLOAD.FILENAME = fileinfo.Name;
                MODELFILEDOWNLOAD.FILEPATH = tvDirectory.SelectedNode.Tag.ToString();

                MODELFILEDOWNLOAD.VERSION = txtVersion1.Text + "." + txtVersion2.Text;
                string strFilter = " AND FILENAME='" + MODELFILEDOWNLOAD.FILENAME + "' AND VERSION='" + MODELFILEDOWNLOAD.VERSION + "'";
                if (Query(strFilter).Rows.Count > 0)
                {
                    MessageBox.Show("该文件已经上传至服务器,无需再次上传。");
                    txtFileName.Clear();
                    return;
                }
                //if (fileinfo.Extension.ToLower() == ".dll" || fileinfo.Extension.ToLower() == ".exe")
                //{
                //    MODELFILEDOWNLOAD.VERSION = FileVersionInfo.GetVersionInfo(strFullName).FileVersion;
                //}
                //else
                //    MODELFILEDOWNLOAD.VERSION = "9";//不是DLL或者EXE的文件。
                FileStream fs = new FileStream(strFullName, FileMode.Open);
                MODELFILEDOWNLOAD.FILECONTENT = new Byte[fs.Length];
                fs.Position = 0;
                fs.Read(MODELFILEDOWNLOAD.FILECONTENT, 0, Convert.ToInt32(fs.Length));
                MODELFILEDOWNLOAD.OPERATORTIME = GetDatetimeNow();
                fs.Close();
                if (Insert(MODELFILEDOWNLOAD))
                {
                    MessageBox.Show("文件上传成功!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtVersion_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).Text.Length > 1)
            {
                MessageBox.Show("只能输入一位数字");
                e.Cancel = true;
            }
        }
        private DateTime GetDatetimeNow()
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(DBUtility.DbHelperSQL.ExecuteScalar("SELECT TOP 1 GETDATE() FROM sysusers").ToString());
            return dt;
        }
        private DataTable Query(string strFilter)
        {
            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM FILEUPLOAD WHERE 1=1 ");
            dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }

        ////private Color RowBackColorAlt = Color.FromArgb(200, 200, 200);//交替色 
        ////private Color RowBackColorSel = Color.FromArgb(150, 200, 250);//选择项目颜色 
        //private void lsbApplicationFold_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    //Brush myBrush = Brushes.Black;

        //    //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        //    //{
        //    //    myBrush = new SolidBrush(RowBackColorSel);
        //    //}
        //    //else if (e.Index % 2 == 0)
        //    //{
        //    //    myBrush = new SolidBrush(RowBackColorAlt);
        //    //}
        //    //else
        //    //{
        //    //    myBrush = new SolidBrush(Color.White);
        //    //}
        //    e.DrawBackground();
        //    //e.Graphics.FillRectangle(myBrush, e.Bounds);
        //    e.DrawFocusRectangle();//焦点框 

        //    //绘制图标 
        //    Image image = Image.FromFile("images/folder.ico");
        //    Graphics g = e.Graphics;
        //    Rectangle bounds = e.Bounds;
        //    Rectangle imageRect = new Rectangle(
        //        bounds.X,
        //        bounds.Y,
        //        bounds.Height,
        //        bounds.Height);
        //    Rectangle textRect = new Rectangle(
        //        imageRect.Right,
        //        bounds.Y,
        //        bounds.Width - imageRect.Right,
        //        bounds.Height);

        //    if (image != null)
        //    {
        //        g.DrawImage(
        //            image,
        //            imageRect,
        //            0,
        //            0,
        //            image.Width,
        //            image.Height,
        //            GraphicsUnit.Pixel);
        //    }

        //    //文本 
        //    StringFormat strFormat = new StringFormat();
        //    //strFormat.Alignment = StringAlignment.Center; 
        //    strFormat.LineAlignment = StringAlignment.Center;
        //    e.Graphics.DrawString(lsbApplicationFold.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), textRect, strFormat);
        //}

        //private void lsbApplicationFold_MeasureItem(object sender, MeasureItemEventArgs e)
        //{
        //    //e.ItemHeight = 120;
        //}

        //private void lsbApplicationFold_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    int index = this.lsbApplicationFold.IndexFromPoint(e.Location);
        //    if (index != System.Windows.Forms.ListBox.NoMatches)
        //    {
        //       string strParentName=((ListItem)lsbApplicationFold.Items[index]).strName;
        //       string strParentID = Application.StartupPath + @"\" + strParentName;
        //       System.IO.DirectoryInfo drInfo = new DirectoryInfo(Application.StartupPath + @"\" + strParentName);
        //  DirectoryInfo[] drInfoChild= drInfo.GetDirectories();
        //  foreach (DirectoryInfo drInfoTemp in drInfoChild)
        //  {
        //      ListItem lst = new ListItem(drInfoTemp.Name,drInfoTemp.Name+"\\");
        //      lsbApplicationFold.Items.Add(drInfoTemp.Name);
        //  }
        //    }
        //}
        // 遍历子目录
        private void GetSubDirectoryNodes(TreeNode parentNode, string fullName, bool getFileNames)
        {
            DirectoryInfo dir = new DirectoryInfo(fullName);
            DirectoryInfo[] subDirs = dir.GetDirectories();
            // 为每一个子目录添加一个子节点
            foreach (DirectoryInfo subDir in subDirs)
            {
                // 不显示隐藏文件夹
                if ((subDir.Attributes & FileAttributes.Hidden) != 0)
                {
                    continue;
                }
                TreeNode subNode = new TreeNode(subDir.Name);
                subNode.Tag = parentNode.Tag.ToString() + @"\" + subDir.Name;
                parentNode.Nodes.Add(subNode);
                // 递归调用GetSubDirectoryNodes
                GetSubDirectoryNodes(subNode, subDir.FullName, getFileNames);
            }
            // 获取目录中的文件
            if (getFileNames)
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    TreeNode fileNode = new TreeNode(file.Name);
                    parentNode.Nodes.Add(fileNode);
                }
            }
        }

        private void dgList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //判断是不是列Header
            if (e.ColumnIndex < 0 && e.RowIndex >= 0)
            {
                //单元格描绘  
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                //决定行号码描绘的范围   
                //不管e.AdvancedBorderStyle和e.CellStyle.Padding  
                Rectangle indexRect = e.CellBounds; indexRect.Inflate(-2, -2);
                //行号码描绘  
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, indexRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                //描绘完后通知 
                e.Handled = true;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (chkUpDateTime.Checked)
            {
                strFilter += " AND OPERATORTIME BETWEEN '" + dtpStartPrint.Text + "' AND '" + dtpEndPrint.Text + "'"; ;
            }
            if (txtName.Text.Trim() == "")
            {
                strFilter += " AND FILENAME LIKE '%" + txtName.Text + "%'";
            }
            txtFilter.Text = strFilter;

            dgList.DataSource = GetUpLoad(strFilter);
            if (dgList.Rows.Count == 0)
            {
                btDelete.Enabled = false;
                btDeleteAll.Enabled = false;
            }
            else
            {
                btDelete.Enabled = true;
                btDeleteAll.Enabled = true;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgList.CurrentRow == null)
                    return;

                if (mes.ShowQ("确定要删除此条信息吗?") != DialogResult.OK)
                    return;
                string strFileNameS = "", strVisionS = "";
                object objFileName = dgList.CurrentRow.Cells["FILENAME"].Value;
                if (objFileName != null && objFileName != DBNull.Value)
                {
                    strFileNameS = objFileName.ToString();
                }
                objFileName = dgList.CurrentRow.Cells["VERSION"].Value;
                if (objFileName != null && objFileName != DBNull.Value)
                {
                    strVisionS = objFileName.ToString();
                }
                if (strFileNameS != "" && strVisionS != "")
                {
                    string strFilter = " AND FILENAME='" + strFileNameS + "' AND VERSION='" + strVisionS + "'";
                    if (Delete(strFilter))
                    {
                        dgList.Rows.Remove(dgList.CurrentRow);
                    }
                    else
                    {
                        mes.Show("删除失败,请查询后重试!");
                        return;
                    }
                }
                else
                {
                    mes.Show("获取文件列表唯一标识失败!请重新查询后选择!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                return;
            }
        }

        private void btDeleteAll_Click(object sender, EventArgs e)
        {
            if (mes.ShowQ("确定要删除列表中所有的上传信息吗?") != DialogResult.OK)
                return;
            try
            {
                for (int i = dgList.Rows.Count - 1; i >= 0; i--)
                {
                    string strFileNameS = "", strVisionS = "";
                    object objFileName = dgList.Rows[i].Cells["FILENAME"].Value;
                    if (objFileName != null && objFileName != DBNull.Value)
                    {
                        strFileNameS = objFileName.ToString();
                    }
                    objFileName = dgList.Rows[i].Cells["VERSION"].Value;
                    if (objFileName != null && objFileName != DBNull.Value)
                    {
                        strVisionS = objFileName.ToString();
                    }
                    if (strFileNameS != "" && strVisionS != "")
                    {
                        string strFilter = " AND FILENAME='" + strFileNameS + "' AND VERSION='" + strVisionS + "'";
                        if (Delete(strFilter))
                        {
                            dgList.Rows.Remove(dgList.Rows[i]);
                        }
                        else
                        {
                            mes.Show("第"+(i+1).ToString()+"行信息删除失败,请查询后重试!");
                            return;
                        }
                    }
                    else
                    {
                        mes.Show("获取文件列表唯一标识失败!请重新查询后选择!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                return;
            }
        }
        private DataTable GetUpLoad(string strFilter)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM FILEUPLOAD WHERE 1=1 ");
            DataTable dt = DBUtility.DbHelperSQL.Query(str.ToString() + strFilter).Tables[0];
            return dt;
        }
        private bool Insert(MODELFILEDOWNLOAD MODELFILEDOWNLOAD)
        {
            StringBuilder str = new StringBuilder();
            str.Append("INSERT INTO FILEUPLOAD(FILENAME,VERSION,FILECONTENT,OPERATORTIME,FILEPATH) ");
            str.Append("VALUES(@FILENAME,@VERSION,@FILECONTENT,@OPERATORTIME,@FILEPATH)");

            SqlParameter[] para =
           {
               new SqlParameter("@FILENAME",SqlDbType.VarChar,50),
               new SqlParameter("@VERSION",SqlDbType.VarChar,50),
               new SqlParameter("@FILECONTENT",SqlDbType.Image),
               new SqlParameter("@OPERATORTIME",SqlDbType.DateTime),
               new SqlParameter("@FILEPATH",SqlDbType.VarChar,200)
           };
            para[0].Value = MODELFILEDOWNLOAD.FILENAME;
            para[1].Value = MODELFILEDOWNLOAD.VERSION;
            para[2].Value = MODELFILEDOWNLOAD.FILECONTENT;
            para[3].Value = MODELFILEDOWNLOAD.OPERATORTIME;
            para[4].Value = MODELFILEDOWNLOAD.FILEPATH;
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
                return true;
            else
                return false;
        }
        private bool Delete(string strFilter)
        {
            StringBuilder str = new StringBuilder();
            str.Append("DELETE FROM FILEUPLOAD WHERE 1=1 ");
            if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString() + strFilter) > 0)
                return true;
            else
                return false;
        }
    }
    public class ReadConfig
    {
        private static string strFileName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"WATERMIS.exe.config";

        /// <summary>  
        /// 获取配置文件的属性  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public string GetAttributeValue(string key)
        {
            string value = string.Empty;

            try
            {
                if (File.Exists(strFileName))
                {
                    XmlDocument xml = new XmlDocument();

                    xml.Load(strFileName);

                    XmlNode xNode = xml.SelectSingleNode("//appSettings");

                    XmlElement element = (XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");

                    value = element.GetAttribute("value").ToString();
                }
            }
            catch { }

            return value;
        }
    } 

    class Messages
    {
        /// <summary>
        /// 确定一个按钮的对话框
        /// </summary>
        /// <param name="strContent"></param>
        public void Show(string strContent)
        {
            MessageBox.Show(strContent, "自来水MIS系统", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        /// <summary>
        /// OK,NO两个按钮的对话框
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public DialogResult ShowQ(string strContent)
        {
            return MessageBox.Show(strContent, "自来水MIS系统", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDatetimeNow()
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(DBUtility.DbHelperSQL.ExecuteScalar("SELECT TOP 1 GETDATE() FROM sysusers").ToString());
            return dt;
        }

        public DateTime GetMondayOfTheWeek(DateTime dt)
        {
            int WeekToday = Convert.ToInt32(dt.DayOfWeek.ToString("d"));
            if (WeekToday == 0)
                WeekToday = 7;
            DateTime Monday = dt.AddDays((-1) * (WeekToday - 1));
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));
            return Monday;
        }

        /// <summary>
        /// 监测主系统是否在运行
        /// </summary>
        public bool TestTheProcess()
        {
            bool isProcess = false;
            Process currentProcess = Process.GetCurrentProcess(); //得到当前进程的ID
            Process[] procList = Process.GetProcessesByName(currentProcess.ProcessName);//根据进程的名称得到所有进程
            if (procList.Length > 1)
            {
                if (ShowQ("系统检测到另一个程序正在运行,是否再打开一个?") != DialogResult.OK)
                    isProcess = true;
            }
            //foreach (Process proc in procList)
            //{
            //    //找到相同进程
            //    if (proc.Id == currentProcess.Id)
            //    {
            //        mes.Show("系统监测到主程序正在运行,请关闭主程序后再执行升级操作!");
            //        isProcess = true;
            //        break;
            //    }
            //}
            return isProcess;
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

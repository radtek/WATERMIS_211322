using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BASEFUNCTION
{
    public class Messages
    {
        /// <summary>
        /// 确定一个按钮的对话框
        /// </summary>
        /// <param name="strContent"></param>
        public void Show(string strContent)
        {
            MessageBox.Show(strContent, "自来水MIS系统",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
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
        /// 是，否，取消三个按钮的对话框
        /// </summary>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public DialogResult ShowQuestion(string strContent)
        {
            frmQuestionDialog frm = new frmQuestionDialog();
            frm.strTip = strContent;
            return frm.ShowDialog();
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
        public void GetErrorMes(Exception ex)
        {
            Log lg = new Log(Application.StartupPath + "\\Log\\", LogType.Daily);
            lg.Write(ex.ToString(), MsgType.Error);
            Show(ex.Message.ToString());
        }

        public DateTime GetMondayOfTheWeek(DateTime dt)
        {
            int WeekToday =Convert.ToInt32( dt.DayOfWeek.ToString("d"));
            if (WeekToday == 0)
                WeekToday = 7;
            DateTime Monday = dt.AddDays((-1)*(WeekToday-1));
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
                if(ShowQ("系统检测到另一个程序正在运行,是否再打开一个?")!=DialogResult.OK)
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
}

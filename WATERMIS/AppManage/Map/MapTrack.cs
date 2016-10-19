using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;
using BASEFUNCTION;

namespace AppManage.Map
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]

    public partial class MapTrack : Form
    {
        public MapTrack()
        {
            InitializeComponent();
        }

        private EquipMent_IDAL sysidal = new EquipMent_DAL();



        private void MapTrack_Load(object sender, EventArgs e)
        {
            BindMeterUser();
            ShowMap();
        }

        private void BindMeterUser()
        {
            CB_User.DataSource = sysidal.GetLoginUserInID();

            CB_User.DisplayMember = "USERNAME";
            CB_User.ValueMember = "LOGINID";
        }

        void ShowMap()
        {
            string str_url = Application.StartupPath + "\\Map\\TrackMap.html";
            Uri url = new Uri(str_url);
            webBrowser1.Url = url;
            webBrowser1.ObjectForScripting = this;
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // ShowTrack();
        }

        private void ShowTrack()
        {
            string loginid = CB_User.SelectedValue.ToString();
            string datatime = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            DataTable dt = sysidal.GetMeterTrack(loginid, datatime);

            if (DataTableHelper.IsExistRows(dt))
            {
                Rows_Num = dt.Rows.Count;
                pointArr = new double[2 * Rows_Num];

                for (int i = 0; i < Rows_Num * 2 - 1; i = i + 2)
                {
                    pointArr[i] = Convert.ToDouble(dt.Rows[i / 2]["Longitude"].ToString());
                    pointArr[i + 1] = Convert.ToDouble(dt.Rows[i / 2]["Latitude"].ToString());

                }
            }

            webBrowser1.Document.InvokeScript("ShowTrackMarker");
        }

        #region
        int Rows_Num = 0;
        double[] pointArr;
        #endregion

        //辅助方法  
        //获取计数  
        public int getRowsNumber()
        {
            return Rows_Num;
        }

        public void ClearRows_num()
        {
            Rows_Num = 0;
        }
        //根据索引获取特定坐标  
        public double Getpoints(int index)
        { return pointArr[index]; }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowTrack();
        }
    }
}

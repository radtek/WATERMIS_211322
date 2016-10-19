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
using System.Collections;

namespace AppManage.Map
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]

    public partial class MapPosition : Form
    {
        public MapPosition()
        {
            InitializeComponent();
        }
        private EquipMent_IDAL sysidal = new EquipMent_DAL();

        private void MapPosition_Load(object sender, EventArgs e)
        {
            ShowMap();
        }

        void ShowMap()
        {
            string str_url = Application.StartupPath + "\\Map\\IndexMap.html";
            Uri url = new Uri(str_url);
            webBrowser1.Url = url;
            webBrowser1.ObjectForScripting = this;
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
            
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ShowMarker();
        }

        #region
        int Rows_Num = 0;
        double[] pointArr;
        #endregion


        void ShowMarker()
        {
            DataTable dt = sysidal.GetWaterUserGPS();
            ArrayList a = new ArrayList();

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

            webBrowser1.Document.InvokeScript("ShowAllMarker");
            
        }

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

        private void MapPosition_Shown(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }



    }
}

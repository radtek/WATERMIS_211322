using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BASEFUNCTION;

namespace SYSMANAGE
{
    public partial class frmSysVision : Form
    {
        public frmSysVision()
        {
            InitializeComponent();
        }

        Messages mes = new Messages();
        string strPath = Application.StartupPath;
        private void frmSysVision_Load(object sender, EventArgs e)
        {
            GetVision();
        }
        private void GetVision()
        {
            DirectoryInfo dir = new DirectoryInfo(strPath);
            FileInfo[] files = dir.GetFiles("*.exe");
            SortAsFileName(ref files);

            string strFileName="",strFileVision="";
            foreach (FileInfo file in files)
            {
                if (File.Exists(file.FullName))
                {
                    strFileName = file.Name;
                    strFileVision = mes.GetFileVersion(file.FullName);
                    dgFile.Rows.Add();
                    dgFile.Rows[dgFile.Rows.Count - 1].Cells["FileName"].Value = strFileName;
                    dgFile.Rows[dgFile.Rows.Count - 1].Cells["FileVision"].Value = strFileVision;                    
                }
            }
            files = dir.GetFiles("*.dll");
            SortAsFileName(ref files);

            strFileName = "";
            strFileVision = "";
            foreach (FileInfo file in files)
            {
                if (File.Exists(file.FullName))
                {
                    strFileName = file.Name;
                    strFileVision = mes.GetFileVersion(file.FullName);
                    dgFile.Rows.Add();
                    dgFile.Rows[dgFile.Rows.Count - 1].Cells["FileName"].Value = strFileName;
                    dgFile.Rows[dgFile.Rows.Count - 1].Cells["FileVision"].Value = strFileVision;
                }
            }
        }
        /// <summary>
        /// C#按文件名排序（顺序）
        /// </summary>
        /// <param name="arrFi">待排序数组</param>
        private void SortAsFileName(ref FileInfo[] arrFi)
        {
            Array.Sort(arrFi, delegate(FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });
        }

        private void dgFile_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WATERUSERMETERMANAGE
{
    public partial class frmImportExcelErrorMes : Form
    {
        /// <summary>
        /// Excel导入类型：1 用户表  2水表表
        /// </summary>
        public string strExcelType = "1";

        /// <summary>
        /// Excel导入问题内容描述
        /// </summary>
        public string strError = "";

        public frmImportExcelErrorMes()
        {
            InitializeComponent();
        }

        private void frmImportExcelErrorMes_Load(object sender, EventArgs e)
        {
            if (strExcelType == "1")
                this.Text = "用户档案EXCEL表导入问题";
            else if (strExcelType == "2")
                this.Text = "用水用户档案EXCEL表导入问题";
            rtxtError.Text = strError;
        }
    }
}

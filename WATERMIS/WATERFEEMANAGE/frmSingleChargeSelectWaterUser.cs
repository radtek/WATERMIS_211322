using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;

namespace WATERFEEMANAGE
{
    public partial class frmSingleChargeSelectWaterUser : Form
    {
        public frmSingleChargeSelectWaterUser()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询到的用户列表
        /// </summary>
        public DataTable dtWaterUserList = new DataTable();

        Messages mes = new Messages();

        /// <summary>
        /// 窗体类型，1 营业厅坐收,只针对预存用户；2 预存收费界面；3 营销收费界面
        /// </summary>
        public string strFormType = "1";

        private void frmSingleChargeSelectWaterUser_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;
            this.dgList.DataSource = dtWaterUserList;
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;
            object objWaterUserID = dgList.CurrentRow.Cells["waterUserNO"].Value;
            if (objWaterUserID != null && objWaterUserID != DBNull.Value)
            {
                if (strFormType == "1")
                {
                    frmWaterMeterReadSingleCharge frm = (frmWaterMeterReadSingleCharge)this.Owner;
                    frm.strSelectWaterUser = objWaterUserID.ToString();
                }
                else if (strFormType == "2")
                {
                    frmPrestoreCharge frm = (frmPrestoreCharge)this.Owner;
                    frm.strSelectWaterUser = objWaterUserID.ToString();
                }
                else if (strFormType == "3")
                {
                    frmWaterMeterReadSingleChargeAll frm = (frmWaterMeterReadSingleChargeAll)this.Owner;
                    frm.strSelectWaterUser = objWaterUserID.ToString();
                }
                else if (strFormType == "4")
                {
                    frmPrestoreReturnBack frm = (frmPrestoreReturnBack)this.Owner;
                    frm.strSelectWaterUser = objWaterUserID.ToString();
                }
                else if (strFormType == "5")
                {
                    frmPrestoreTransfer frm = (frmPrestoreTransfer)this.Owner;
                    frm.strSelectWaterUser = objWaterUserID.ToString();
                }
                else if (strFormType == "6")
                {
                    frmPrestoreTransfer frm = (frmPrestoreTransfer)this.Owner;
                    frm.strSelectWaterUser2 = objWaterUserID.ToString();
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                mes.Show("获取用户号失败,请重新选择!");
                return;
            }
        }

        private void dgList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex<0||e.ColumnIndex<0)
            {
                mes.Show("请选择用户所在的行!");
                return;
            }
            btSelect_Click(null,null);
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BLL;
using MODEL;
using BASEFUNCTION;

namespace WATERFEEMANAGE
{
    public partial class frmRedCancelSelectItem : Form
    {
        public frmRedCancelSelectItem()
        {
            InitializeComponent();
            tb1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb1, true, null);
            tb2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tb2, true, null);
        }

        Messages mes = new Messages();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);
        BLLWATERFEECHARGE BLLWATERFEECHARGE = new BLLWATERFEECHARGE();
        BLLPRESTORERUNNINGACCOUNT BLLPRESTORERUNNINGACCOUNT = new BLLPRESTORERUNNINGACCOUNT();

        private void frmRedCancelSelectItem_Load(object sender, EventArgs e)
        {

        }

        private void btNext_Click(object sender, EventArgs e)
        {
            DataTable dtList=new DataTable();
            if(txtFormID.Text.Trim()=="")
            {
                mes.Show("请输入要冲销的单据号!");
                txtFormID.Focus();
                return;
            }
            if (rbCharge.Checked)
            {
                dtList = BLLWATERFEECHARGE.QueryLS(" AND chargeState='3' AND CHARGECANCEL='0' AND CHARGEID='" + txtFormID.Text + "'");

                if (dtList.Rows.Count == 0)
                {
                    mes.Show("未找到该单据号对应的收费信息!");
                    txtFormID.Focus();
                    return;
                }
                else
                {
                    frmRedCancelCharge frm = new frmRedCancelCharge();
                    frm.dtList = dtList;
                    frm.ShowDialog();
                }
            }
            else if (rbPrestore.Checked)
            {
                dtList = BLLPRESTORERUNNINGACCOUNT.Query(" AND CHARGEID='" + txtFormID.Text + "'");

                if (dtList.Rows.Count == 0)
                {
                    mes.Show("未找到该单据号对应的预存信息!");
                    txtFormID.Focus();
                    return;
                }
                else
                {
                    frmRedCancelPrestoreCharge frm = new frmRedCancelPrestoreCharge();
                    frm.dtList = dtList;
                    frm.ShowDialog();
                }
            }

        }

        private void txtFormID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btNext_Click(null,null);
            }
        }
    }
}

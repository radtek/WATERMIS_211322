using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BASEFUNCTION;
using BLL;

namespace WATERUSERMETERMANAGE
{
    public partial class frmMeterReaderEachOther : Form
    {
        public frmMeterReaderEachOther()
        {
            InitializeComponent();
        }

        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLwaterUser BLLwaterUser = new BLLwaterUser();
        Messages mes = new Messages();

        private void frmMeterReaderEachOther_Load(object sender, EventArgs e)
        {
            BindMeterReaderLeft();
            BindMeterReaderRight("");

            BindMeterChargerLeft();
            BindMeterChargerRight("");
        }

        private void BindMeterReaderLeft()
        {
            string strFilter = " AND isMeterReader='1'";
            if (txtNameLeft.Text.Trim() != "")
            {
                strFilter += " AND userName LIKE '%"+txtNameLeft.Text+"%'";
            }
            DataTable dtLeft = BLLBASE_LOGIN.QueryUser(strFilter);

            lsbLeft.Items.Clear();
            for (int i = 0; i < dtLeft.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object obj = dtLeft.Rows[i]["loginId"];
                if (obj != null && obj != DBNull.Value)
                {
                    strID = obj.ToString();
                    obj = dtLeft.Rows[i]["userName"];
                    if (obj != null && obj != DBNull.Value)
                    {
                        strName = obj.ToString();

                    }
                    ListItem ListItem = new ListItem(strName,strID);
                    lsbLeft.Items.Add(ListItem);
                }
            }

        }
        private void BindMeterReaderRight(string strF)
        {
            string strFilter = " AND isMeterReader='1'";
            if (txtNameRight.Text.Trim() != "")
            {
                strFilter += " AND userName LIKE '%" + txtNameRight.Text + "%'";
            }
            strFilter += strF;
            DataTable dtRight = BLLBASE_LOGIN.QueryUser(strFilter);

            chkLsbRight.Items.Clear();
            for (int i = 0; i < dtRight.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object obj = dtRight.Rows[i]["loginId"];
                if (obj != null && obj != DBNull.Value)
                {
                    strID = obj.ToString();
                    obj = dtRight.Rows[i]["userName"];
                    if (obj != null && obj != DBNull.Value)
                    {
                        strName = obj.ToString();

                    }
                    ListItem ListItem = new ListItem(strName, strID);
                    chkLsbRight.Items.Add(ListItem);
                }
            }
        }

        private void BindMeterChargerLeft()
        {
            string strFilter = " AND isCharger='1'";
            if (txtChargerLeft.Text.Trim() != "")
            {
                strFilter += " AND userName LIKE '%" + txtChargerLeft.Text + "%'";
            }
            DataTable dtLeft = BLLBASE_LOGIN.QueryUser(strFilter);

            lsbLeftCharger.Items.Clear();
            for (int i = 0; i < dtLeft.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object obj = dtLeft.Rows[i]["loginId"];
                if (obj != null && obj != DBNull.Value)
                {
                    strID = obj.ToString();
                    obj = dtLeft.Rows[i]["userName"];
                    if (obj != null && obj != DBNull.Value)
                    {
                        strName = obj.ToString();

                    }
                    ListItem ListItem = new ListItem(strName, strID);
                    lsbLeftCharger.Items.Add(ListItem);
                }
            }

        }
        private void BindMeterChargerRight(string strF)
        {
            string strFilter = " AND isCharger='1'";
            if (txtChargerRight.Text.Trim() != "")
            {
                strFilter += " AND userName LIKE '%" + txtChargerRight.Text + "%'";
            }
            strFilter += strF;
            DataTable dtRight = BLLBASE_LOGIN.QueryUser(strFilter);

            lsbRightCharger.Items.Clear();
            for (int i = 0; i < dtRight.Rows.Count; i++)
            {
                string strID = "", strName = "";
                object obj = dtRight.Rows[i]["loginId"];
                if (obj != null && obj != DBNull.Value)
                {
                    strID = obj.ToString();
                    obj = dtRight.Rows[i]["userName"];
                    if (obj != null && obj != DBNull.Value)
                    {
                        strName = obj.ToString();

                    }
                    ListItem ListItem = new ListItem(strName, strID);
                    lsbRightCharger.Items.Add(ListItem);
                }
            }
        }

        private void chkLsbRight_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox chkLSB = (CheckedListBox)sender;
            if (chkLSB.CheckedItems.Count > 0)
            {
                for (int i = 0; i < chkLSB.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        chkLSB.SetItemCheckState(i,
                        System.Windows.Forms.CheckState.Unchecked);
                    }
                }
            } 
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsbLeft.SelectedItem == null)
                {
                    mes.Show("请从左边列表内选择抄表员!");
                    return;
                }
                if (chkLsbRight.CheckedItems.Count == 0)
                {
                    mes.Show("请从右边列表内选择抄表员!");
                    return;
                }
                ListItem lstLeft = (ListItem)lsbLeft.SelectedItem;
                ListItem lstRight = (ListItem)chkLsbRight.CheckedItems[0];
                BLLwaterUser.UpdateMeterReader(lstLeft.strID, "999999999", "999999999");
                BLLwaterUser.UpdateMeterReader(lstRight.strID, lstLeft.strID, lstLeft.strName);
                BLLwaterUser.UpdateMeterReader("999999999", lstRight.strID, lstRight.strName);
                mes.Show("互换成功");
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
            }
        }

        private void txtNameLeft_TextChanged(object sender, EventArgs e)
        {
            BindMeterReaderLeft();
        }

        private void txtNameRight_TextChanged(object sender, EventArgs e)
        {
            BindMeterReaderRight("");
        }

        private void lsbLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbLeft.SelectedItem != null)
            {
                ListItem lst = (ListItem)lsbLeft.SelectedItem;
                BindMeterReaderRight(" AND loginId<>'"+lst.strID+"'");
            }
        }

        private void lsbLeftCharger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbLeftCharger.SelectedItem != null)
            {
                ListItem lst = (ListItem)lsbLeftCharger.SelectedItem;
                BindMeterChargerRight(" AND loginId<>'" + lst.strID + "'");
            }
        }

        private void txtChargerLeft_TextChanged(object sender, EventArgs e)
        {
            BindMeterChargerLeft();
        }

        private void txtChargerRight_TextChanged(object sender, EventArgs e)
        {
            BindMeterChargerRight("");
        }

        private void btChangeCharger_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsbLeftCharger.SelectedItem == null)
                {
                    mes.Show("请从左边列表内选择收费员!");
                    return;
                }
                if (lsbRightCharger.CheckedItems.Count == 0)
                {
                    mes.Show("请从右边列表内选择收费员!");
                    return;
                }
                ListItem lstLeft = (ListItem)lsbLeftCharger.SelectedItem;
                ListItem lstRight = (ListItem)lsbRightCharger.CheckedItems[0];
                BLLwaterUser.UpdateCharger(lstLeft.strID, "999999999", "999999999");
                BLLwaterUser.UpdateCharger(lstRight.strID, lstLeft.strID, lstLeft.strName);
                BLLwaterUser.UpdateCharger("999999999", lstRight.strID, lstRight.strName);
                mes.Show("互换成功");
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
            }
        }
    }

}

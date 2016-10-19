using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using BASEFUNCTION;
using MODEL;

namespace SYSMANAGE
{
    public partial class frmSendMessage : DockContentEx
    {
        public frmSendMessage()
        {
            InitializeComponent();
        }

        BLLMESSAGESEND BLLMESSAGESEND = new BLLMESSAGESEND();
        BLLMESSAGERECEIVE BLLMESSAGERECEIVE = new BLLMESSAGERECEIVE();
        BLLBASE_LOGIN BLLBASE_LOGIN = new BLLBASE_LOGIN();
        BLLBASE_DEPARTMENT BLLBASE_DEPARTMENT = new BLLBASE_DEPARTMENT();
        BLLBASE_POST BLLBASE_POST = new BLLBASE_POST();
        BLLloginGroup BLLloginGroup = new BLLloginGroup();
        Messages mes = new Messages();
        GETTABLEID GETTABLEID = new GETTABLEID();
        Log log = new Log(Application.StartupPath + @"\Logs\", LogType.Daily);

        /// <summary>
        /// 登陆用户的ID
        /// </summary>
        private string strLogID = "";

        /// <summary>
        /// 登陆用户的姓名
        /// </summary>
        private string strUserName = "";

        private void frmSendMessage_Load(object sender, EventArgs e)
        {
            dgUser.AutoGenerateColumns = false;
            cmbIsReader.SelectedIndex = 0;
            cmbIsCharger.SelectedIndex = 0;
            cmbClass.SelectedIndex = 0;

            //获取用户ID
            if (AppDomain.CurrentDomain.GetData("LOGINID") != null && AppDomain.CurrentDomain.GetData("LOGINID") != DBNull.Value)
                strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            else
            {
                mes.Show("收费员姓名获取失败!请重新打开该窗体!");
                this.Close();
            }

            //获取用户姓名
            if (AppDomain.CurrentDomain.GetData("USERNAME") != null && AppDomain.CurrentDomain.GetData("USERNAME") != DBNull.Value)
                strUserName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            BindPost();
            BindGroup();
            BindDEP();
        }

        /// <summary>
        /// 绑定职务
        /// </summary>
        private void BindPost()
        {
            DataTable dt = BLLBASE_POST.QueryPost("");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["POSTID"] = DBNull.Value;
                dr["POSTNAME"] = "全部";
                dt.Rows.InsertAt(dr,0);
                cmbPost.DisplayMember = "POSTNAME";
                cmbPost.ValueMember = "POSTID";
                cmbPost.DataSource = dt;
            }
        }
        /// <summary>
        /// 绑定分组
        /// </summary>
        private void BindGroup()
        {
            DataTable dt = BLLloginGroup.Query("");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["groupId"] = DBNull.Value;
                dr["groupName"] = "全部";
                dt.Rows.InsertAt(dr, 0);
                cmbGroupS.DisplayMember = "groupName";
                cmbGroupS.ValueMember = "groupId";
                cmbGroupS.DataSource = dt;
            }
        }
        /// <summary>
        /// 将部门数据绑定到部门列表中
        /// </summary>
        /// <param name="cmb"></param>
        private void BindDEP()
        {
            DataTable dt = BLLBASE_DEPARTMENT.QueryDep("");
            if (dt.Rows.Count > 0)
            {
                cmbDEPS.DisplayMember = "DEPARTMENTNAME";
                cmbDEPS.ValueMember = "DEPARTMENTID";
                cmbDEPS.DataSource = dt;
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string str = " AND loginId<>'"+strLogID+"' ";
            if (cmbDEPS.SelectedValue != DBNull.Value && cmbDEPS.SelectedValue != null)
                if (cmbDEPS.SelectedValue.ToString() != "01")
                {
                    string strList = "0";
                    strList = GetDepList(strList, cmbDEPS.SelectedValue.ToString());
                }
            //strList = GetDepList(strList, cmbDEPS.SelectedValue.ToString());
            //str += " AND  DEPARTMENTID IN (" + strList + ")";
            if (txtNameS.Text.Trim() != "")
                str += " AND USERNAME LIKE '%" + txtNameS.Text.Trim() + "%'";

            if (cmbGroupS.SelectedValue != DBNull.Value && cmbGroupS.SelectedValue != null)
                str += " AND groupID = '" + cmbGroupS.SelectedValue.ToString() + "'";

            if (cmbIsReader.SelectedIndex > 0)
                str += " AND isMeterReader='" + (cmbIsReader.SelectedIndex - 1).ToString() + "'";

            if (cmbIsCharger.SelectedIndex > 0)
                str += " AND isCharger='" + (cmbIsCharger.SelectedIndex - 1).ToString() + "'";

            if (cmbPost.SelectedValue != DBNull.Value && cmbPost.SelectedValue != null)
                str += " AND POSTID = '" + cmbPost.SelectedValue.ToString() + "'";

            str += " ORDER BY loginId";
            DataTable dtList = BLLBASE_LOGIN.QueryUser(str);
            dgUser.DataSource = dtList;
            if (dgUser.Rows.Count == 0)
            {
                btSelectAll.Enabled = false;
            }
            else
                btSelectAll.Enabled = true;
        }

        /// <summary>
        /// 递归获取子部门ID
        /// </summary>
        /// <param name="strList">返回的部门ID字符串，可以直接用在数据库查询语句中</param>
        /// <param name="strDepID">第一级父部门ID</param>
        /// <returns></returns>
        private string GetDepList(string strList, string strDepID)
        {
            DataTable dt = new DataTable();
            string strDepChildID;
            strList += "," + strDepID;
            dt = BLLBASE_DEPARTMENT.QueryDep(" AND PARENTID='" + strDepID + "'");
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strDepChildID = dt.Rows[i]["DEPARTMENTID"].ToString();
                    strList = GetDepList(strList, strDepChildID);
                }
            }
            return strList;
        }

        private void dgUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strUserID = "", strUserName = "";
            object objUserID = dgUser.Rows[e.RowIndex].Cells["loginId"].Value;
            if (objUserID != null && objUserID != DBNull.Value)
            {
                strUserID = objUserID.ToString();
                object objUserName = dgUser.Rows[e.RowIndex].Cells["userName"].Value;
                if (objUserName != null && objUserName != DBNull.Value)
                {
                    strUserName = objUserName.ToString();
                }

                if (!isExist(strUserID))
                {
                    ListItem lst = new ListItem(strUserName, strUserID);
                    lsbReceiver.Items.Add(lst);
                    labTip.Text = "已选择 " + lsbReceiver.Items.Count + " 人";
                }
            }
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            if (dgUser.Rows.Count == 0)
            {
                mes.Show("列表为空,无法添加!");
                return;
            }
            int intCount = 0;//成功添加的人数
            try
            {
                for (int i = 0; i < dgUser.Rows.Count; i++)
                {
                    string strUserID = "", strUserName = "";
                    object objUserID = dgUser.Rows[i].Cells["loginId"].Value;
                    if (objUserID != null && objUserID != DBNull.Value)
                    {
                        strUserID = objUserID.ToString();
                        object objUserName = dgUser.Rows[i].Cells["userName"].Value;
                        if (objUserName != null && objUserName != DBNull.Value)
                        {
                            strUserName = objUserName.ToString();
                        }

                        if (!isExist(strUserID))
                        {
                            ListItem lst = new ListItem(strUserName, strUserID);
                            lsbReceiver.Items.Add(lst);
                            intCount++;
                        }
                    }
                }
                labTip.Text = "已选择 " + lsbReceiver.Items.Count + " 人";
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
            }
            finally
            {
                mes.Show("共添加'" + intCount.ToString() + "'人");
            }
        }

        /// <summary>
        /// 判断接收人中是否已经存在
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        private bool isExist(string strID)
        {
            bool isExist = false;
            for (int i = 0; i < lsbReceiver.Items.Count; i++)
            {
                ListItem lst = ((ListItem)lsbReceiver.Items[i]);
                if (lst.strID == strID)
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }

        private void dgUser_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void btSend_Click(object sender, EventArgs e)
        {
            if (lsbReceiver.Items.Count == 0)
            {
                mes.Show("请从通讯录里选择接收人!");
                return;
            }
            if (txtTitle.Text.Trim() == "")
            {
                mes.Show("请填写消息标题!");
                return;
            }
            if (txtContent.Text.Trim() == "")
            {
                if (mes.ShowQ("消息内容为空，确定不填写内容吗?") != DialogResult.OK)
                {
                    return;
                }
            }
            if (cmbClass.SelectedIndex < 0)
            {
                mes.Show("请选择消息'紧急状态'!");
                return;
            }

            try
            {
                MODELMESSAGESEND MODELMESSAGESEND = new MODELMESSAGESEND();
                MODELMESSAGESEND.MESSAGESENDID = GETTABLEID.GetTableID(strLogID, "MESSAGESEND");
                string strReceiveName = "";
                for (int i = 0; i < lsbReceiver.Items.Count; i++)
                {
                    ListItem lst = (ListItem)lsbReceiver.Items[i];
                    if (i == 0)
                        strReceiveName = lst.strName;
                    else
                        strReceiveName += ";" + lst.strName;
                }
                MODELMESSAGESEND.MESSAGERECEIVER = strReceiveName;
                MODELMESSAGESEND.MESSAGETITLE = txtTitle.Text;
                MODELMESSAGESEND.MESSAGECLASS = (cmbClass.SelectedIndex + 1).ToString();
                MODELMESSAGESEND.MESSAGECONTENT = txtContent.Text;

                MODELMESSAGESEND.MESSAGESENDERID = strLogID;
                MODELMESSAGESEND.MESSAGESENDERNAME = strUserName;
                MODELMESSAGESEND.MESSAGESENDTIME = mes.GetDatetimeNow();
                if (BLLMESSAGESEND.Insert(MODELMESSAGESEND))
                {
                    try
                    {
                        for (int j = 0; j < lsbReceiver.Items.Count; j++)
                        {
                            ListItem lst = (ListItem)lsbReceiver.Items[j];
                            MODELMESSAGERECEIVE MODELMESSAGERECEIVE = new MODELMESSAGERECEIVE();
                            MODELMESSAGERECEIVE.MESSAGERECEIVEID = GETTABLEID.GetTableID(strLogID, "MESSAGERECEIVE");
                            MODELMESSAGERECEIVE.MESSAGESENDID = MODELMESSAGESEND.MESSAGESENDID;
                            MODELMESSAGERECEIVE.MESSAGERECEIVERID = lst.strID;
                            MODELMESSAGERECEIVE.MESSAGERECEIVERNAME = lst.strName;
                            if (!BLLMESSAGERECEIVE.Insert(MODELMESSAGERECEIVE))
                            {
                                mes.Show("发送给'" + lst.strName + "'时发生错误,请重新发送!");

                                //回滚发送的邮件
                                BLLMESSAGERECEIVE.Delete(" AND MESSAGESENDID='" + MODELMESSAGERECEIVE.MESSAGESENDID + "'");

                                //回滚发送的内容
                                BLLMESSAGESEND.Delete(MODELMESSAGESEND.MESSAGESENDID);
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        mes.Show(ex.Message);
                        log.Write(ex.ToString(), MsgType.Error);

                        //回滚发送的内容
                        BLLMESSAGESEND.Delete(MODELMESSAGESEND.MESSAGESENDID);

                        //回滚发送的邮件
                        BLLMESSAGERECEIVE.Delete(" AND MESSAGESENDID='" + MODELMESSAGESEND.MESSAGESENDID + "'");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
            mes.Show("发送完成!");
            btSend.Enabled = false;
            btNew.Enabled = true;
        }

        private void lsbReceiver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lsbReceiver.SelectedItem != null)
                {
                    int intSelectIndex = lsbReceiver.SelectedIndex;
                    lsbReceiver.Items.Remove(lsbReceiver.SelectedItem);
                    labTip.Text = "已选择 "+lsbReceiver.Items.Count+" 人";
                    if(intSelectIndex<lsbReceiver.Items.Count)
                        lsbReceiver.SelectedItem=lsbReceiver.Items[intSelectIndex];
                }
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            btSend.Enabled = true;
            lsbReceiver.Items.Clear();
            labTip.Text = "已选择 0 人";
            txtTitle.Clear();
            txtContent.Clear();
        }
    }
}

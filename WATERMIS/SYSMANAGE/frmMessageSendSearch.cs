using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using BASEFUNCTION;
using Microsoft.VisualBasic;

namespace SYSMANAGE
{
    public partial class frmMessageSendSearch : DockContentEx
    {
        public frmMessageSendSearch()
        {
            InitializeComponent();
        }

        BLLMESSAGESEND BLLMESSAGESEND = new BLLMESSAGESEND();

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

        private void frmMessageSendSearch_Load(object sender, EventArgs e)
        {
            dgList.AutoGenerateColumns = false;

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

            toolSearch_Click(null,null);
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilter = " AND MESSAGESENDERID='" + strLogID + "' AND ISDELETE='0' ";
            if (chkDateTime.Checked)
            {
                strFilter += " AND MESSAGESENDTIME BETWEEN '"+dtpStart.Text+"' AND '"+dtpEnd.Text+"'";
            }
            if (txtTitleS.Text.Trim() != "")
                strFilter += " AND MESSAGETITLE LIKE '%" + txtTitleS.Text + "%'";
            //清空明细部分
            lsbReceiver.Items.Clear();
            txtTitle.Clear();
            txtContent.Clear();

            DataTable dtList = BLLMESSAGESEND.Query(strFilter);
            dgList.DataSource = dtList;

            if (dtList.Rows.Count > 0)
            {
                toolDel.Enabled = true;
                toolDeleteAll.Enabled = true;
                dgList_CellClick(null,new DataGridViewCellEventArgs(2,0));
            }
            else
            {
                toolDel.Enabled = false;
                toolDeleteAll.Enabled = false;
            }

        }

        private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            lsbReceiver.Items.Clear();
            txtTitle.Clear();
            txtContent.Clear();

            //object obj = dgList.Rows[e.RowIndex].Cells["MESSAGESENDID"].Value;
            //if (obj != null && obj != DBNull.Value)
            //{
            //    txtID.Text = obj.ToString();
            //}
            //else
            //    txtID.Clear();

            object obj = dgList.Rows[e.RowIndex].Cells["MESSAGERECEIVER"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                string[] strNameS = obj.ToString().Split(';');
                for (int i = 0; i < strNameS.Length; i++)
                {
                    lsbReceiver.Items.Add(strNameS[i]);
                }
            }
            obj = dgList.Rows[e.RowIndex].Cells["MESSAGETITLE"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtTitle.Text = obj.ToString();
            }
            obj = dgList.Rows[e.RowIndex].Cells["MESSAGECONTENT"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                txtContent.Text = obj.ToString();
            }

        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
            {
                mes.Show("请从消息列表内选择要删除的行!");
                return;
            }

            try
            {
                object obj = dgList.CurrentRow.Cells["MESSAGESENDID"].Value;
                if (obj == null || obj == DBNull.Value)
                {
                    mes.Show("获取消息唯一标识失败,请重新查询后再操作!");
                    return;
                }
                if (mes.ShowQ("确定要删除此消息吗？") != DialogResult.OK)
                    return;

                if (BLLMESSAGESEND.UpdateDeleteSign(obj.ToString()))
                {
                    dgList.Rows.Remove(dgList.CurrentRow);
                }
                else
                {
                    mes.Show("删除消息失败，请重新查询后再操作!");
                    return;
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(), MsgType.Error);
                return;
            }
        }

        private void toolDeleteAll_Click(object sender, EventArgs e)
        {
            if (dgList.Rows.Count == 0)
            {
                mes.Show("删除列表为空，没有可删除的消息!");
                return;
            }

            if (mes.ShowQ("确定要删除列表内的所有消息吗？") != DialogResult.OK)
                return;

            try
            {
                for (int i = dgList.Rows.Count - 1; i > -1; i--)
                {
                    object obj = dgList.Rows[i].Cells["MESSAGESENDID"].Value;
                    if (obj == null || obj == DBNull.Value)
                    {
                        mes.Show("第" + (i + 1).ToString() + "行获取消息唯一标识失败,请重新查询后再操作!");
                        return;
                    }
                    if (BLLMESSAGESEND.UpdateDeleteSign(obj.ToString()))
                    {
                        dgList.Rows.Remove(dgList.Rows[i]);
                    }
                    else
                    {
                        mes.Show("删除消息失败，请重新查询后再操作!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                mes.Show(ex.Message);
                log.Write(ex.ToString(),MsgType.Error);
                return;
            }
        }

        private void dgList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgList.Columns[e.ColumnIndex].Name == "MESSAGECLASS")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (e.Value.ToString() == "1")
                        e.Value = "次要";
                    else if (e.Value.ToString() == "2")
                        e.Value = "一般";
                    else if (e.Value.ToString() == "3")
                        e.Value = "重要";
                    else if (e.Value.ToString() == "4")
                        e.Value = "紧急";
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using MODEL;
using BASEFUNCTION;
using Microsoft.VisualBasic;

namespace SYSMANAGE
{
    public partial class frmAccountsRunning : DockContentEx
    {
        public frmAccountsRunning()
        {
            InitializeComponent();
        }

        BLLACCOUNTSRUNNING BLLACCOUNTSRUNNING = new BLLACCOUNTSRUNNING();

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
            dgList.Columns["ACCOUNTSYEARANDMONTH"].DefaultCellStyle.Format = "yyyy-MM";
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

            for (int i = 0; i < dgList.Columns.Count; i++)
            {
                if(dgList.Columns[i].Name=="BUSINESSMONEY"||dgList.Columns[i].Name=="FINANCEMONEY")
                {
                dgList.Columns[i].ReadOnly=false;
                    dgList.Columns[i].DefaultCellStyle.BackColor=Color.Pink;
                }
                else
                    dgList.Columns[i].ReadOnly=true;
            }

                toolSearch_Click(null, null);
        }

        private void toolSearch_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (chkDateTime.Checked)
            {
                strFilter += " AND ACCOUNTSYEARANDMONTH BETWEEN '" + new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, 1, 0, 0, 0) + "' AND '" + new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, 1, 23, 59, 59).AddMonths(1).AddDays(-1) + "'";
            }

            DataTable dtList = BLLACCOUNTSRUNNING.Query(strFilter);
            dgList.DataSource = dtList;

            if (dtList.Rows.Count > 0)
            {
                toolDel.Enabled = true;
            }
            else
            {
                toolDel.Enabled = false;
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
                object obj = dgList.CurrentRow.Cells["ACCOUNTSID"].Value;
                if (obj == null || obj == DBNull.Value)
                {
                    mes.Show("获取消息唯一标识失败,请重新查询后再操作!");
                    return;
                }
                if (mes.ShowQ("确定要删除此消息吗？") != DialogResult.OK)
                    return;

                if (BLLACCOUNTSRUNNING.Delete(obj.ToString()))
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
                    object obj = dgList.Rows[i].Cells["ACCOUNTSID"].Value;
                    if (obj == null || obj == DBNull.Value)
                    {
                        mes.Show("第" + (i + 1).ToString() + "行获取消息唯一标识失败,请重新查询后再操作!");
                        return;
                    }
                    if (BLLACCOUNTSRUNNING.Delete(obj.ToString()))
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

        private void dgList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object objID = dgList.Rows[e.RowIndex].Cells["ACCOUNTSID"].Value;
                if (objID != null && objID != DBNull.Value)
                {
                        if (dgList.Columns[e.ColumnIndex].Name == "BUSINESSMONEY")
                        {
                            object obj = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            if (Information.IsNumeric(obj))
                            {
                                MODELACCOUNTSRUNNING MODELACCOUNTSRUNNING = new MODELACCOUNTSRUNNING();
                                MODELACCOUNTSRUNNING.ACCOUNTSID = objID.ToString();
                                MODELACCOUNTSRUNNING.BUSINESSMONEY = Convert.ToDecimal(obj);
                                if (BLLACCOUNTSRUNNING.UpdateBusinessMoney(MODELACCOUNTSRUNNING))
                                {
                                    //dgList.Rows.Remove(dgList.Rows[e.RowIndex]);
                                }
                                else
                                {
                                    mes.Show("更新营业用户余额失败，请重试!");
                                }
                            }
                        }
                        if (dgList.Columns[e.ColumnIndex].Name == "FINANCEMONEY")
                        {
                            object obj = dgList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            if (Information.IsNumeric(obj))
                            {
                                MODELACCOUNTSRUNNING MODELACCOUNTSRUNNING = new MODELACCOUNTSRUNNING();
                                MODELACCOUNTSRUNNING.ACCOUNTSID = objID.ToString();
                                MODELACCOUNTSRUNNING.FINANCEMONEY = Convert.ToDecimal(obj);
                                if (BLLACCOUNTSRUNNING.UpdateFinanceMoney(MODELACCOUNTSRUNNING))
                                {
                                    //dgList.Rows.Remove(dgList.Rows[e.RowIndex]);
                                }
                                else
                                {
                                    mes.Show("更新财务用户余额失败，请重试!");
                                }
                            }
                        }
                }
                else
                {
                    mes.Show("获取唯一标识失败!请查询后重新操作!");
                }
            }
        }
    }
}

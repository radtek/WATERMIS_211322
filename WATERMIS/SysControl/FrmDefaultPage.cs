using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using DBinterface.DAL;
using DBinterface.IDAL;
using BASEFUNCTION;
using BLL;
using SYSMANAGE;

namespace SysControl
{
    public partial class FrmDefaultPage : DockContentEx
    {
        BLLMESSAGERECEIVE BLLMESSAGERECEIVE = new BLLMESSAGERECEIVE();
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();
        private string loginid = "";

        public FrmDefaultPage()
        {
            InitializeComponent();
        }

        private void FrmDefaultPage_Load(object sender, EventArgs e)
        {
            dgNotice.AutoGenerateColumns = false;
            loginid = AppDomain.CurrentDomain.GetData("LOGINID").ToString();

            InitTaskWork();
        }

        #region Tab1
        private void InitTaskWork()
        {
            string sqlstr = string.Format(@"SELECT top 10  ROW_NUMBER() OVER(ORDER BY CreateDate) AS rowNum, MW.TaskName,MW.TaskCode,MWR.DoName,MW.PointTime,MWR.TimeLimit,MW.TaskID,MWR.ResolveID,MWR.PointSort,MWR.PointName,MW.SD,MWR.WorkName,MW.AcceptUser,MW.AcceptDate,MWR.CreateDate,MWR.isPass,loginId
   FROM Meter_WorkTask MW,Meter_WorkResolve MWR WHERE MW.TaskID=MWR.TaskID AND MW.PointSort=MWR.PointSort AND ','+loginId+',' like '%,'+'{0}'+',%' AND MW.[State]=1 ORDER BY  CreateDate DESC", loginid);

            string[,] Fields = new string[,] { { "rowNum", "序号" }, 
                                                           { "WorkName", "审批类型" }, 
                                                           { "SD", "流水号" }, 
                                                           { "PointName", "审批进度" }, 
                                                           { "DoName", "审批事项" } ,
                                                           { "PointTime", "处理开始时间" } ,
                                                           { "TimeLimit", "审批期限（天）" }, 
                                                           { "AcceptUser", "受理人" }, 
                                                           { "AcceptDate", "申请时间" }
                                                          
            };
            DataTable _DataSource = new SqlServerHelper().GetDateTableBySql(sqlstr);

            if (_DataSource != null)
            {
                DG.Columns.Clear();
                foreach (DataColumn dc in _DataSource.Columns)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = dc.ColumnName;
                    col.DataPropertyName = dc.ColumnName;
                    col.HeaderText = dc.ColumnName;

                    bool isShow = false;
                    for (int i = 0; i < Fields.GetLength(0); i++)
                    {
                        if (dc.ColumnName.ToUpper().Equals(Fields[i, 0].ToUpper()))
                        {
                            isShow = true;
                            col.DataPropertyName = Fields[i, 0];
                            col.HeaderText = Fields[i, 1];
                            col.DisplayIndex = i;

                            break;
                        }
                    }
                    col.Visible = isShow;
                    DG.Columns.Add(col);
                }

                DG.DataSource = _DataSource;
            }

            #region 显示消息
            DataTable dtNotice = BLLMESSAGERECEIVE.Query("  AND MESSAGERECEIVERID='" + loginid + "' AND MESSAGERECEIVE.ISDELETE='0' AND MESSAGEREADEDSIGN='0' ");
            dgNotice.DataSource = dtNotice;
            #endregion

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgList = (DataGridView)sender;
            if (dgList != null)
            {
                if (dgList.CurrentRow != null)
                {
                    string TaskID = dgList.CurrentRow.Cells["TaskID"].Value.ToString();
                    string ResolveID = dgList.CurrentRow.Cells["ResolveID"].Value.ToString();
                    string PointSort = dgList.CurrentRow.Cells["PointSort"].Value.ToString();
                    string TaskCode = dgList.CurrentRow.Cells["TaskCode"].Value.ToString();

                    string FrmAssemblyName = string.Empty;
                    string FormName = string.Empty;
                    if (sysidal.GetAssemblyName(ResolveID, ref FrmAssemblyName, ref FormName))
                    {
                        Hashtable ht = new Hashtable();
                        string path = FrmAssemblyName;
                        string name = FrmAssemblyName + "." + FormName;
                        Form Frm = (Form)Assembly.Load(path).CreateInstance(name);
                        ht["ResolveID"] = ResolveID;
                        ht["PointSort"] = PointSort;
                        ht["TaskID"] = TaskID;
                        Frm.Tag = ht;
                        Frm.ShowDialog();
                        if (Frm.DialogResult == DialogResult.OK)
                        {
                            this.InitTaskWork();
                        }
                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.InitTaskWork();
        }
        #endregion

        private void Btn_Submit_Click(object sender, EventArgs e)
        {

        }

        private void dgNotice_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string strFromName = "", strTitle = "", strContent = "", strClass = "", strReceiveID = "";

            object obj = dgNotice.Rows[e.RowIndex].Cells["MESSAGERECEIVEID"].Value;
            if (obj != null && obj != DBNull.Value)
            {
                strReceiveID = obj.ToString();

                obj = dgNotice.Rows[e.RowIndex].Cells["MESSAGESENDERNAME"].Value;
                if (obj != null && obj != DBNull.Value)
                    strFromName = obj.ToString();

                obj = dgNotice.Rows[e.RowIndex].Cells["MESSAGETITLE"].Value;
                if (obj != null && obj != DBNull.Value)
                    strTitle = obj.ToString();

                obj = dgNotice.Rows[e.RowIndex].Cells["MESSAGECONTENT"].Value;
                if (obj != null && obj != DBNull.Value)
                    strContent = obj.ToString();

                obj = dgNotice.Rows[e.RowIndex].Cells["MESSAGECLASS"].Value;
                if (obj != null && obj != DBNull.Value)
                    strClass = obj.ToString();
                frmNoticeShow frm = new frmNoticeShow();
                frm.strFromName = strFromName;
                frm.strTitle = strTitle;
                frm.strContent = strContent;
                frm.strClass = strClass;
                frm.Show();

                try
                {
                    BLLMESSAGERECEIVE.UpdateReadSign(strReceiveID);
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private void dgNotice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgNotice.Columns[e.ColumnIndex].Name == "MESSAGECLASS")
            {
                object obj = e.Value;
                if (obj != null && obj != DBNull.Value)
                {
                    if (obj.ToString() == "1")
                        e.Value = "次要";
                    else if (obj.ToString() == "2")
                        e.Value = "一般";
                    else if (obj.ToString() == "3")
                        e.Value = "重要";
                    else if (obj.ToString() == "4")
                        e.Value = "紧急";
                }
            }
        }
    }
}

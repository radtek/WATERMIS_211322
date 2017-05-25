using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DotNetUI;
using BASEFUNCTION;
using System.Collections;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace WorkFlow
{
    public partial class FrmFlowSelect : DockContentEx
    {
        private string _ApproveID = string.Empty;

        private PersonalWork_IDAL sysdal = new PersonalWork_DAL();

        public FrmFlowSelect()
        {
            InitializeComponent();
        }

        private void FrmFlowSelect_Load(object sender, EventArgs e)
        {
            InitData();

            LoadDataList();
        }

        private void LoadDataList()
        {
            string sqlstr = @"SELECT WS.WATERMETERTYPECLASSNAME, MW.WorkName, WA.*,(SELECT TOP 1 Table_Name_CH FROM View_TABLEUNION WHERE TableID=WA.TableID) AS Table_Name_CH
FROM WaterUserType_Approve WA LEFT OUTER JOIN Meter_WorkFlow MW ON WA.WorkCode = MW.WorkCode LEFT OUTER JOIN
 WATERMETERTYPECLASS WS ON WA.WaterMeterTypeClassID = WS.WATERMETERTYPECLASSID";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);

            dgList.DataSource = dt;
        }

        private void InitData()
        {
            string sqlstr = "SELECT DISTINCT TableID,Table_Name_CH FROM View_TABLEUNION ORDER BY TableID";

            DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            ControlBindHelper.BindComboBoxData(this.TableID, dt, "Table_Name_CH", "TableID");

            sqlstr = "SELECT WATERMETERTYPECLASSID,WATERMETERTYPECLASSNAME FROM WATERMETERTYPECLASS";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            ControlBindHelper.BindComboBoxData(this.WaterMeterTypeClassID, dt, "WATERMETERTYPECLASSNAME", "WATERMETERTYPECLASSID");

            sqlstr = " SELECT WorkCode,WorkName FROM Meter_WorkFlow WHERE ParentID <>'0' AND State=1";
            dt = new SqlServerHelper().GetDateTableBySql(sqlstr);
            ControlBindHelper.BindComboBoxData(this.WorkCode, dt, "WorkName", "WorkCode");

        }
        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (toolAdd.Text == "添加")
            {
                toolAdd.Text = "取消";
                toolDel.Enabled = false;

                dgList.Enabled = false;
                _ApproveID = "";
            }
            else
            {
                dgList_SelectionChanged(null, null);
                toolAdd.Text = "添加";
                toolDel.Enabled = true;
                dgList.Enabled = true;
            }
        }

        private void dgList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
            {
                return;
            }
            else
            {
                object obj = dgList.CurrentRow.Cells["ApproveID"].Value;
                if (obj != null && obj != DBNull.Value)
                {
                    _ApproveID = obj.ToString();
                    this.TableID.SelectedValue = dgList.CurrentRow.Cells["TableID1"].Value;
                    this.WaterMeterTypeClassID.SelectedValue = dgList.CurrentRow.Cells["WaterMeterTypeClassID1"].Value;
                    this.WorkCode.SelectedValue = dgList.CurrentRow.Cells["WorkCode1"].Value;
                }
                else
                {
                    _ApproveID = "";
                }
            }
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (dgList.CurrentRow == null)
                return;
            if (!string.IsNullOrEmpty(_ApproveID))
            {
                int count = new SqlServerHelper().DeleteData("WaterUserType_Approve", "ApproveID",_ApproveID);
                LoadDataList();
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            Hashtable ht = new SqlServerHelper().GetHashTableByControl(this.grpDetail.Controls);

            if (string.IsNullOrEmpty(_ApproveID))
            {
                if (sysdal.IsExistWorkFlow(ht["TABLEID"].ToString(), ht["WATERMETERTYPECLASSID"].ToString()))
                {
                    MessageBox.Show("已经存在相同规则，不要重复添加！");
                    return;
                }
                
            }

            if (new SqlServerHelper().Submit_AddOrEdit("WaterUserType_Approve", "ApproveID", _ApproveID, ht))
            {
                MessageBox.Show("保存成功！");
                _ApproveID = "";
                LoadDataList();
            }
            else
            {
                MessageBox.Show("保存失败");
            }
           
        }
    }
}

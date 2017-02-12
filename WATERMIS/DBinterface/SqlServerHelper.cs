using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBUtility;
using Common.DotNetCode;
using System.Data.SqlClient;
using Common.DotNetData;
using Common.DotNetUI;
using Common.WinControl.Ryan.RegTextbox;

public class SqlServerHelper
{
    protected LogHelper Logger = new LogHelper("SQLServerLog");

    public bool Submit_AddOrEdit(string tableName, string pkName, string pkVal, Hashtable ht)
    {
        bool result;
        if (string.IsNullOrEmpty(pkVal))
        {
            result = (this.InsertByHashtable(tableName, ht) > 0);
        }
        else
        {
            result = (this.UpdateByHashtable(tableName, pkName, pkVal, ht) > 0);
        }
        return result;
    }

    public Hashtable GetHashtableById(string tableName, string pkName, string pkVal)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Select * From ").Append(tableName).Append(" Where ").Append(pkName).Append("=@ID");
        DataTable dt = DbHelperSQL.Query(sb.ToString(), new SqlParameter[]
            {
                new SqlParameter("@ID", pkVal)
            }).Tables[0];
        return DataTableHelper.DataTableToHashtable(dt);
    }

    public Hashtable GetHashtableById(string tableName, string pkName, string pkVal, string strWhere)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Select * From ").Append(tableName).Append(" Where ").Append(pkName).Append("=@ID");
        if (!string.IsNullOrEmpty(strWhere))
        {
            sb.Append(" AND " + strWhere );
        }
        DataTable dt = DbHelperSQL.Query(sb.ToString(), new SqlParameter[]
            {
                new SqlParameter("@ID", pkVal)
            }).Tables[0];
        return DataTableHelper.DataTableToHashtable(dt);
    }

    public int IsExist(string tableName, string pkName, string pkVal)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("Select Count(1) from " + tableName);
        strSql.Append(" where " + pkName + " = @" + pkName);
        SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@" + pkName, pkVal)
            };
        return DbHelperSQL.ExecuteSql(strSql.ToString(), param);
    }

    public bool IsExist(string tableName, string pkName, string pkVal, string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("Select Count(1) from " + tableName);
        strSql.Append(" where " + pkName + " = @" + pkName);
        strSql.Append(" AND "+strWhere);
        SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@" + pkName, pkVal)
            };
        DataTable dt = GetDateTableBySql(strSql.ToString(), param);
        return int.Parse(dt.Rows[0][0].ToString()) > 0 ? true : false;
    }

    public virtual int InsertByHashtable(string tableName, Hashtable ht)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" Insert Into ");
        sb.Append(tableName);
        sb.Append("(");
        StringBuilder sp = new StringBuilder();
        StringBuilder sb_prame = new StringBuilder();
        foreach (string key in ht.Keys)
        {
            sb_prame.Append("," + key);
            sp.Append(",@" + key);
        }
        sb.Append(sb_prame.ToString().Substring(1, sb_prame.ToString().Length - 1) + ") Values (");
        sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
        return DbHelperSQL.ExecuteSql(sb.ToString(), this.GetParameter(ht));
    }

    public SqlParameter[] GetParameter(Hashtable ht)
    {
        SqlParameter[] _params = new SqlParameter[ht.Count];
        int i = 0;
        foreach (string key in ht.Keys)
        {
            _params[i] = new SqlParameter("@" + key, ht[key]);
            i++;
        }
        return _params;
    }

    public int InsertByHashtableReturnPkVal(string tableName, Hashtable ht)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" Declare @ReturnValue int Insert Into ");
        sb.Append(tableName);
        sb.Append("(");
        StringBuilder sp = new StringBuilder();
        StringBuilder sb_prame = new StringBuilder();
        foreach (string key in ht.Keys)
        {
            sb_prame.Append("," + key);
            sp.Append(",@" + key);
        }
        sb.Append(sb_prame.ToString().Substring(1, sb_prame.ToString().Length - 1) + ") Values (");
        sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ") Set @ReturnValue=SCOPE_IDENTITY() Select @ReturnValue");
        object _object = DbHelperSQL.GetSingle(sb.ToString(), this.GetParameter(ht));
        return (_object == DBNull.Value) ? 0 : Convert.ToInt32(_object);
    }

    public int UpdateByHashtable(string tableName, string pkName, string pkVal, Hashtable ht)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(" Update ");
        sb.Append(tableName);
        sb.Append(" Set ");
        bool isFirstValue = true;
        foreach (string key in ht.Keys)
        {
            if (isFirstValue)
            {
                isFirstValue = false;
                sb.Append(key);
                sb.Append("=");
                sb.Append("@" + key);
            }
            else
            {
                sb.Append("," + key);
                sb.Append("=");
                sb.Append("@" + key);
            }
        }
        sb.Append(" Where ").Append(pkName).Append("=").Append("@" + pkName);
        ht[pkName] = pkVal;
        SqlParameter[] _params = this.GetParameter(ht);
        return DbHelperSQL.ExecuteSql(sb.ToString(), _params);
    }

    public int UpdateByHashtable(string sqlstr, params SqlParameter[] cmdParms)
    {
        return DbHelperSQL.ExecuteSql(sqlstr, cmdParms);
    }
    
    public int UpdateByHashtable(string sqlstr)
    {
        return DbHelperSQL.ExecuteSql(sqlstr);
    }

    public int DeleteData(string tableName, string pkName, string pkVal)
    {
        StringBuilder sb = new StringBuilder(string.Concat(new string[]
            {
                "Delete From ",
                tableName,
                " Where ",
                pkName,
                " = @ID"
            }));
        return DbHelperSQL.ExecuteSql(sb.ToString(), new SqlParameter[]
            {
                new SqlParameter("@ID", pkVal)
            });
    }

    public int BatchDeleteData(string tableName, string pkName, object[] pkValues)
    {
        SqlParameter[] param = new SqlParameter[pkValues.Length];
        int index = 0;
        string str = "@ID" + index;
        StringBuilder sql = new StringBuilder(string.Concat(new string[]
            {
                "DELETE FROM ",
                tableName,
                " WHERE ",
                pkName,
                " IN ("
            }));
        for (int i = 0; i < param.Length - 1; i++)
        {
            object obj2 = pkValues[i];
            str = "@ID" + index;
            sql.Append(str).Append(",");
            param[index] = new SqlParameter(str, obj2);
            index++;
        }
        str = "@ID" + index;
        sql.Append(str);
        param[index] = new SqlParameter(str, pkValues[index]);
        sql.Append(")");
        return DbHelperSQL.ExecuteSql(sql.ToString(), param);
    }

    public object GetFirsRowsValue(string sqlstr)
    {
        DataTable dt = GetDateTableBySql(sqlstr);
        if (DataTableHelper.IsExistRows(dt))
        {
            return dt.Rows[0][0];
        }
        else
        {
            return null;
        }
    }

    public object GetFirsRowsValue(string sqlstr, params SqlParameter[] cmdParms)
    {
        DataTable dt = GetDateTableBySql(sqlstr, cmdParms);
        if (DataTableHelper.IsExistRows(dt))
        {
            return dt.Rows[0][0];
        }
        else
        {
            return null;
        }
    }

    public DataTable GetDateTableBySql(string sqlstr)
    {
        return DbHelperSQL.Query(sqlstr).Tables[0];
    }

    public DataTable GetDateTableBySql(string sqlstr, params SqlParameter[] cmdParms)
    {
        return DbHelperSQL.Query(sqlstr, cmdParms).Tables[0];
    }

    public DataTable GetDataTable(string tableName)
    {
        return GetDataTable(tableName, "", "");
    }

    public DataTable GetDataTable(string tableName, string strWhere, string order)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Select * From ").Append(tableName);
        if (!string.IsNullOrEmpty(strWhere))
        {
            sb.Append(" Where ").Append(strWhere);
        }
        if (!string.IsNullOrEmpty(order))
        {
            sb.Append(" order by ").Append(order);
        }
        DataTable dt = DbHelperSQL.Query(sb.ToString(), null).Tables[0];

        return dt;
    }

    public Hashtable GetHashTableByControl(Control.ControlCollection Controls)
    {
        Hashtable ht = new Hashtable();

        foreach (Control c in Controls)
        {
            if (c is RyanTextBox)
            {
                RyanTextBox txt0 = (RyanTextBox)c;
                ht[txt0.Name.ToUpper()] = txt0.Text.Trim();
            }
            if (c is MaskedTextBox)
            {
                MaskedTextBox txt1 = (MaskedTextBox)c;
                ht[txt1.Name.ToUpper()] = txt1.Text.Trim();
            }
            if (c is TextBox)
            {
                TextBox txt2 = (TextBox)c;
                ht[txt2.Name.ToUpper()] = txt2.Text.Trim();
            }

            if (c is CheckBox)
            {
                CheckBox txt3 = (CheckBox)c;
                ht[txt3.Name.ToUpper()] = txt3.Checked ? 1 : 0;
            }

            if (c is ComboBox)
            {
                ComboBox txt4 = (ComboBox)c;
                ht[txt4.Name.ToUpper()] = txt4.SelectedValue;
            }
            if (c is DateTimePicker)
            {
                DateTimePicker txt5 = (DateTimePicker)c;

                DateTime dtDate;
                if (DateTime.TryParse(txt5.Value.ToString(), out dtDate))
                {
                    ht[txt5.Name.ToUpper()] = txt5.Value;
                }
            }
        }

        return ht;
    }

    public void ClearControls(Control.ControlCollection Controls)
    {
        Hashtable ht = new Hashtable();

        foreach (Control c in Controls)
        {
            if (c is RyanTextBox)
            {
                RyanTextBox txt0 = (RyanTextBox)c;
                txt0.Text = "";
            }

            if (c is MaskedTextBox)
            {
                MaskedTextBox txt1 = (MaskedTextBox)c;
                txt1.Text = "";
            }
            if (c is TextBox)
            {
                TextBox txt2 = (TextBox)c;
                txt2.Text = "";
            }

            if (c is CheckBox)
            {
                CheckBox txt3 = (CheckBox)c;
                txt3.Checked = false;
            }



        }

    }

    public void BindHashTableToForm(Hashtable ht, Control.ControlCollection Controls)
    {
        if (ht.Count > 0)
        {
            foreach (string htName in ht.Keys)
            {
                foreach (Control c in Controls)
                {
                    if (c.Name.ToUpper().Equals(htName))
                    {
                        if (c is RyanTextBox)
                        {
                            RyanTextBox txt0 = (RyanTextBox)c;
                            txt0.Text = ht[htName].ToString();
                        }
                        if (c is MaskedTextBox)
                        {
                            MaskedTextBox txt1 = (MaskedTextBox)c;
                            txt1.Text = ht[htName].ToString();
                        }

                        if (c is TextBox)
                        {
                            TextBox txt2 = (TextBox)c;
                            txt2.Text = ht[htName].ToString();
                        }

                        if (c is CheckBox)
                        {
                            CheckBox txt3 = (CheckBox)c;
                            if (!string.IsNullOrEmpty(ht[htName].ToString()))
                            {
                                bool isCheck = false;
                                if (bool.TryParse(ht[htName].ToString(), out isCheck))
                                {
                                    txt3.Checked = isCheck;
                                }
                                else
                                {
                                    txt3.Checked = ht[htName].ToString().Equals("1") ? true : false;
                                }
                            }
                            else
                            {
                                txt3.Checked = false;
                            }
                           
                        }

                        if (c is ComboBox)
                        {
                            ComboBox txt4 = (ComboBox)c;
                            foreach (System.Data.DataRowView dr in txt4.Items)
                            {

                                if (ht[htName].ToString().Equals(dr[txt4.ValueMember].ToString()) || ht[htName].ToString().Replace("True","1").Equals(dr[txt4.ValueMember].ToString()))
                                {
                                    txt4.Text = dr[txt4.DisplayMember].ToString();
                                   // continue;
                                }
                                //else
                                //{
                                //    txt4.Text = "";
                                //}
                            }
                        }
                        if (c is DateTimePicker)
                        {
                            DateTimePicker txt5 = (DateTimePicker)c;
                            DateTime dtDate;
                            if (DateTime.TryParse(ht[htName].ToString(), out dtDate))
                            {
                                txt5.Value = dtDate;

                            }
                        }
                    }
                }
            }

        }
    }

    public bool GetSqlWhereByControl(Control.ControlCollection Controls,ref string sqlWhere)
    {
        bool result = false;
        bool isFirst = true;
        StringBuilder sb=new StringBuilder();
        foreach (Control c in Controls)
        {
            if (c is MaskedTextBox)
            {
                MaskedTextBox txt1 = (MaskedTextBox)c;
                if (!string.IsNullOrEmpty(txt1.Text))
                {
                    result = true;
                    if (isFirst)
                    {
                        isFirst = false;
                        sb.AppendFormat("{0} LIKE '%{1}%'", txt1.Name.Substring(3, txt1.Name.Length - 3), txt1.Text);
                    }
                    else
                    {
                        sb.AppendFormat(" AND {0} LIKE '%{1}%'", txt1.Name.Substring(3, txt1.Name.Length - 3), txt1.Text);
                    }

                }

            }
            if (c is TextBox)
            {
                TextBox txt2 = (TextBox)c;
                if (!string.IsNullOrEmpty(txt2.Text))
                {
                    result = true;
                    if (isFirst)
                    {
                        isFirst = false;
                        sb.AppendFormat("{0} LIKE '%{1}%'", txt2.Name.Substring(3, txt2.Name.Length - 3), txt2.Text);
                    }
                    else
                    {
                        sb.AppendFormat(" AND {0} LIKE '%{1}%'", txt2.Name.Substring(3, txt2.Name.Length - 3), txt2.Text);
                    }
                }
            }

            if (c is ComboBox)
            {
                ComboBox txt4 = (ComboBox)c;
                if (txt4.SelectedValue==null)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(txt4.SelectedValue.ToString()))
                {
                    result = true;
                    if (isFirst)
                    {
                        isFirst = false;
                        sb.AppendFormat("{0} LIKE '%{1}%'", txt4.Name.Substring(3, txt4.Name.Length - 3), txt4.SelectedValue);
                    }
                    else
                    {
                        sb.AppendFormat(" AND {0} LIKE '%{1}%'", txt4.Name.Substring(3, txt4.Name.Length - 3), txt4.SelectedValue);
                    }
                }
            }
        }
        sqlWhere = sb.ToString();
        return result;
    }

    public DataTable GetPageList(string sql, SqlParameter[] param, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
    {
        StringBuilder sb = new StringBuilder();
        DataTable result;
        try
        {
            int num = (pageIndex - 1) * pageSize;
            int num2 = pageIndex * pageSize;
            sb.Append("Select * From (Select ROW_NUMBER() Over (Order By " + orderField + " " + orderType);
            sb.Append(string.Concat(new object[]
				{
					") As rowNum, * From (",
					sql,
					") As T ) As N Where rowNum > ",
					num,
					" And rowNum <= ",
					num2
				}));
            if (param!=null)
            {
                count = Convert.ToInt32(DbHelperSQL.GetSingle(new StringBuilder("Select Count(1) From (" + sql + ") As t").ToString(), param));
                result = this.GetDateTableBySql(sb.ToString(), param);
            }
            else
            {
                count = Convert.ToInt32(DbHelperSQL.GetSingle(new StringBuilder("Select Count(1) From (" + sql + ") As t").ToString()));
                result = this.GetDateTableBySql(sb.ToString());
            }
        }
        catch (Exception e)
        {
            this.Logger.WriteLog(string.Concat(new string[]
				{
					"-----------数据分页（Oracle）-----------\r\n",
					sb.ToString(),
					"\r\n",
					e.Message,
					"\r\n"
				}));
            result = null;
        }
        return result;
    }

    public DataTable GetPageList(string sql, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
    {
        return GetPageList(sql, null, orderField, orderType, pageIndex, pageSize, ref count);
    }

    public DataTable GetPageList(string sql, string orderField, int pageIndex, int pageSize, ref int count)
    {
        return GetPageList(sql, null, orderField, "DESC", pageIndex, pageSize, ref count);
    }

    public DataTable GetPageList(string sql, string orderField, int pageIndex,  ref int count)
    {
        return GetPageList(sql, null, orderField, "DESC", pageIndex, 100, ref count);
    }

    public string GetSDByTable(string tableName, string createDate, string SDName)
    {
        string dateStr = DateTime.Now.ToString("yyyyMMdd");
        int index = 1;
        string sqlstr = "SELECT TableID FROM Meter_Table WHERE Table_Name=@Table_Name";
        string _TableOrder = "00";
        DataTable dt = DbHelperSQL.Query(sqlstr, new SqlParameter[] { new SqlParameter("@Table_Name", tableName) }).Tables[0];
        if (DataTableHelper.IsExistRows(dt))
        {
            _TableOrder = dt.Rows[0][0].ToString().Trim();
        }
        else
        {
            switch (tableName.ToUpper())
            {
                case "USER_REFUND":
                    _TableOrder = "10";
                    break;
                case "USER_WATERPRICE":
                    _TableOrder = "11";
                    break;
                case "USER_CHARGEABATE":
                    _TableOrder = "12";
                    break;
                case "USER_ADDWATER":
                    _TableOrder = "14";
                    break;
                default:
                    _TableOrder = "00";
                    break;
            }
        }
        sqlstr = string.Format("SELECT COUNT(1),MAX({2}) FROM {0} where datediff(dd,{1},GETDATE())=0", tableName, createDate, SDName);
         dt = DbHelperSQL.Query(sqlstr, null).Tables[0];
        if (DataTableHelper.IsExistRows(dt))
        {
            int count = int.Parse(dt.Rows[0][0].ToString()) + 1;
            index = count;
            if (!string.IsNullOrEmpty(dt.Rows[0][1].ToString()))
            {
                string sd = dt.Rows[0][1].ToString();
                int MaxSD = int.Parse(sd.Substring(sd.Length - 4, 4));
                if (index == MaxSD)
                {
                    for (int i = 1; i < 100; i++)
                    {
                        index=index+i;
                        if (index == MaxSD)
                        {
                            break;
                        }
                    }
                }
            }
        }
       
        string ord = String.Format("{0:0000}", index);

        return (dateStr + _TableOrder + ord);
    }

    public string GetSDByTable(string tableName)
    {
        return GetSDByTable(tableName, "CreateDate", "SD");
    }

    public bool CreateWorkTask(string ExcePkValue, string AcceptID, string ExceTableName, string ExcePkName, string FlowDesc)
    {
        return CreateWorkTask(ExcePkValue, AcceptID, ExceTableName, ExcePkName, FlowDesc, ExceTableName);
    }

    public bool CreateWorkTask(string ExcePkValue, string AcceptID, string ExceTableName, string ExcePkName, string FlowDesc,string FlowCode)
    {
        bool result = true;
        try
        {
            string strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
            string strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

            string sqlstr = string.Format(@"DECLARE @ExceID NVARCHAR(50)='{0}'
DECLARE @WorkCode NVARCHAR(50)='{7}'
DECLARE @TaskName NVARCHAR(50)='{6}-{1}'
DECLARE @SD NVARCHAR(50)='{1}'
DECLARE @PointSort INT=1
DECLARE @AcceptUserID NVARCHAR(50)='{2}'
DECLARE @AcceptUser NVARCHAR(50)='{3}'
DECLARE @TaskID NVARCHAR(50)=NEWID()
DECLARE @WORKFLOWID NVARCHAR(50)=''
--DECLARE @TaskCode NVARCHAR(50)=''
DECLARE @UserOpinion NVARCHAR(50)='系统提交'
DECLARE @NEXTSORT INT
SELECT @WORKFLOWID=WorkFlowID FROM Meter_WorkFlow WHERE WorkCode=@WorkCode
if(@WORKFLOWID<>'')
begin
SET XACT_ABORT ON
begin tran
--写入Meter_WorkResolve
INSERT INTO Meter_WorkResolve(ResolveID,TaskID,WorkFlowID,WorkName,PointName,PointSort,DoID,DoName,DepartementID,loginId,userName,Rulers,GroupID,TimeLimit,IsSkip,GoPointID,IsVoided,IsViewCharge,IsCharge,IsCashier,YS) 
SELECT NEWID() AS ResolveID, @TaskID AS TaskID,VW.WorkFlowID,VW.WorkName,VW.PointName,VW.PointSort,VW.DoID,VW.DoName,VW.DepartementID,VW.loginId,VW.userName,VW.Rulers,VW.GroupID,VW.TimeLimit,VW.IsSkip,VW.GoPointID,VW.IsVoided,VW.IsViewCharge,VW.IsCharge,VW.IsCashier,VW.YS  FROM [View_WorkResolve] VW  WHERE WORKFLOWID=@WORKFLOWID
--写入Meter_WorkTask
INSERT INTO Meter_WorkTask (TaskID,TaskName,WorkFlowID,TaskCode,PointSort,AcceptUserID,AcceptUser,SD) VALUES (@TaskID,@TaskName,@WORKFLOWID,@WorkCode,@PointSort,@AcceptUserID,@AcceptUser,@SD)
UPDATE {4} SET [State]=1,FlowID=@WORKFLOWID,TaskID=@TaskID WHERE {5}=@ExceID
commit tran
SELECT  TOP 1 @NEXTSORT=PointSort FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort>@PointSort ORDER BY PointSort
SET XACT_ABORT ON
BEGIN TRAN  
UPDATE Meter_WorkResolve SET IsPass=1,AcceptUserID=@AcceptUserID,UserOpinion=@UserOpinion,AcceptUser=@AcceptUser,AcceptDate=GETDATE() WHERE TaskID=@TaskID
and PointSort=@PointSort and ','+loginId+',' like '%,'+@AcceptUserID+',%'
UPDATE Meter_WorkTask SET PointSort=@NEXTSORT,PointTime=GETDATE() WHERE TaskID=@TaskID
INSERT INTO Meter_WorkResolveFee (FeeID,FeeItem,DefaultValue,Sort,ResolveID,IsFinal) SELECT MF.FeeID, MF.FeeItem, MF.DefaultValue, MF.Sort,MWR.ResolveID,MWF.IsFinal FROM Meter_WorkDoFee MWF INNER JOIN Meter_FeeItmes MF ON MWF.FeeID = MF.FeeID INNER JOIN Meter_WorkResolve MWR ON MWF.DoID = MWR.DoID WHERE (MF.State = 1) AND (MWR.TaskID = @TaskID)
COMMIT TRAN
end", ExcePkValue, AcceptID, strLogID, strRealName, ExceTableName, ExcePkName, FlowDesc, FlowCode);
            DbHelperSQL.ExecuteSql(sqlstr);
        }
        catch (Exception ex)
        {

            result = false;
        }
        return result;
    }

    /// <summary>
    /// 自定义执行语句 20160909 ByRen
    /// </summary>
    /// <param name="strSQL"></param>
    /// <returns></returns>
    public int ExcuteSql(string strSQL)
    {
        return DbHelperSQL.ExecuteSql(strSQL);
    }
}

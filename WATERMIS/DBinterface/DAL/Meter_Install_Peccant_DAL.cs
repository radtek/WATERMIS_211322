using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBinterface.IDAL;
using DBUtility;//Please add references
namespace DBinterface.DAL
{
    /// <summary>
    /// 数据访问类:Meter_Install_Single
    /// </summary>
    public partial class Meter_Install_Single : IMeter_Install_Single
    {
        public Meter_Install_Single()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SingleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Meter_Install_Single");
            strSql.Append(" where SingleID=@SingleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = SingleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DBinterface.Model.Meter_Install_Single model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Meter_Install_Single(");
            strSql.Append("SingleID,SD,AcceptID,QueryKey,loginId,userName,AcceptDate,waterUserTypeId,State,FlowID,ApplyUser,waterUserName,SubmitDate,ContractNO,waterUserAddress,IsBoost,waterUserPeopleCount,waterUserHouseType,waterPhone)");
            strSql.Append(" values (");
            strSql.Append("@SingleID,@SD,@AcceptID,@QueryKey,@loginId,@userName,@AcceptDate,@waterUserTypeId,@State,@FlowID,@ApplyUser,@waterUserName,@SubmitDate,@ContractNO,@waterUserAddress,@IsBoost,@waterUserPeopleCount,@waterUserHouseType,@waterPhone)");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleID", SqlDbType.NVarChar,50),
					new SqlParameter("@SD", SqlDbType.Int,4),
					new SqlParameter("@AcceptID", SqlDbType.Int,4),
					new SqlParameter("@QueryKey", SqlDbType.Int,4),
					new SqlParameter("@loginId", SqlDbType.VarChar,50),
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@AcceptDate", SqlDbType.DateTime),
					new SqlParameter("@waterUserTypeId", SqlDbType.VarChar,30),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@FlowID", SqlDbType.NVarChar,50),
					new SqlParameter("@ApplyUser", SqlDbType.NVarChar,50),
					new SqlParameter("@waterUserName", SqlDbType.VarBinary,70),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@ContractNO", SqlDbType.NVarChar,50),
					new SqlParameter("@waterUserAddress", SqlDbType.VarChar,100),
					new SqlParameter("@IsBoost", SqlDbType.Bit,1),
					new SqlParameter("@waterUserPeopleCount", SqlDbType.Int,4),
					new SqlParameter("@waterUserHouseType", SqlDbType.VarChar,10),
					new SqlParameter("@waterPhone", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SingleID;
            parameters[1].Value = model.SD;
            parameters[2].Value = model.AcceptID;
            parameters[3].Value = model.QueryKey;
            parameters[4].Value = model.loginId;
            parameters[5].Value = model.userName;
            parameters[6].Value = model.AcceptDate;
            parameters[7].Value = model.waterUserTypeId;
            parameters[8].Value = model.State;
            parameters[9].Value = model.FlowID;
            parameters[10].Value = model.ApplyUser;
            parameters[11].Value = model.waterUserName;
            parameters[12].Value = model.SubmitDate;
            parameters[13].Value = model.ContractNO;
            parameters[14].Value = model.waterUserAddress;
            parameters[15].Value = model.IsBoost;
            parameters[16].Value = model.waterUserPeopleCount;
            parameters[17].Value = model.waterUserHouseType;
            parameters[18].Value = model.waterPhone;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DBinterface.Model.Meter_Install_Single model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Meter_Install_Single set ");
            strSql.Append("SD=@SD,");
            strSql.Append("AcceptID=@AcceptID,");
            strSql.Append("QueryKey=@QueryKey,");
            strSql.Append("loginId=@loginId,");
            strSql.Append("userName=@userName,");
            strSql.Append("AcceptDate=@AcceptDate,");
            strSql.Append("waterUserTypeId=@waterUserTypeId,");
            strSql.Append("State=@State,");
            strSql.Append("FlowID=@FlowID,");
            strSql.Append("ApplyUser=@ApplyUser,");
            strSql.Append("waterUserName=@waterUserName,");
            strSql.Append("SubmitDate=@SubmitDate,");
            strSql.Append("ContractNO=@ContractNO,");
            strSql.Append("waterUserAddress=@waterUserAddress,");
            strSql.Append("IsBoost=@IsBoost,");
            strSql.Append("waterUserPeopleCount=@waterUserPeopleCount,");
            strSql.Append("waterUserHouseType=@waterUserHouseType,");
            strSql.Append("waterPhone=@waterPhone");
            strSql.Append(" where SingleID=@SingleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SD", SqlDbType.Int,4),
					new SqlParameter("@AcceptID", SqlDbType.Int,4),
					new SqlParameter("@QueryKey", SqlDbType.Int,4),
					new SqlParameter("@loginId", SqlDbType.VarChar,50),
					new SqlParameter("@userName", SqlDbType.VarChar,50),
					new SqlParameter("@AcceptDate", SqlDbType.DateTime),
					new SqlParameter("@waterUserTypeId", SqlDbType.VarChar,30),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@FlowID", SqlDbType.NVarChar,50),
					new SqlParameter("@ApplyUser", SqlDbType.NVarChar,50),
					new SqlParameter("@waterUserName", SqlDbType.VarBinary,70),
					new SqlParameter("@SubmitDate", SqlDbType.DateTime),
					new SqlParameter("@ContractNO", SqlDbType.NVarChar,50),
					new SqlParameter("@waterUserAddress", SqlDbType.VarChar,100),
					new SqlParameter("@IsBoost", SqlDbType.Bit,1),
					new SqlParameter("@waterUserPeopleCount", SqlDbType.Int,4),
					new SqlParameter("@waterUserHouseType", SqlDbType.VarChar,10),
					new SqlParameter("@waterPhone", SqlDbType.VarChar,50),
					new SqlParameter("@SingleID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.SD;
            parameters[1].Value = model.AcceptID;
            parameters[2].Value = model.QueryKey;
            parameters[3].Value = model.loginId;
            parameters[4].Value = model.userName;
            parameters[5].Value = model.AcceptDate;
            parameters[6].Value = model.waterUserTypeId;
            parameters[7].Value = model.State;
            parameters[8].Value = model.FlowID;
            parameters[9].Value = model.ApplyUser;
            parameters[10].Value = model.waterUserName;
            parameters[11].Value = model.SubmitDate;
            parameters[12].Value = model.ContractNO;
            parameters[13].Value = model.waterUserAddress;
            parameters[14].Value = model.IsBoost;
            parameters[15].Value = model.waterUserPeopleCount;
            parameters[16].Value = model.waterUserHouseType;
            parameters[17].Value = model.waterPhone;
            parameters[18].Value = model.SingleID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string SingleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Meter_Install_Single ");
            strSql.Append(" where SingleID=@SingleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = SingleID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string SingleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Meter_Install_Single ");
            strSql.Append(" where SingleID in (" + SingleIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DBinterface.Model.Meter_Install_Single GetModel(string SingleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SingleID,SD,AcceptID,QueryKey,loginId,userName,AcceptDate,waterUserTypeId,State,FlowID,ApplyUser,waterUserName,SubmitDate,ContractNO,waterUserAddress,IsBoost,waterUserPeopleCount,waterUserHouseType,waterPhone from Meter_Install_Single ");
            strSql.Append(" where SingleID=@SingleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@SingleID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = SingleID;

            DBinterface.Model.Meter_Install_Single model = new DBinterface.Model.Meter_Install_Single();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DBinterface.Model.Meter_Install_Single DataRowToModel(DataRow row)
        {
            DBinterface.Model.Meter_Install_Single model = new DBinterface.Model.Meter_Install_Single();
            if (row != null)
            {
                if (row["SingleID"] != null)
                {
                    model.SingleID = row["SingleID"].ToString();
                }
                if (row["SD"] != null && row["SD"].ToString() != "")
                {
                    model.SD = int.Parse(row["SD"].ToString());
                }
                if (row["AcceptID"] != null && row["AcceptID"].ToString() != "")
                {
                    model.AcceptID = int.Parse(row["AcceptID"].ToString());
                }
                if (row["QueryKey"] != null && row["QueryKey"].ToString() != "")
                {
                    model.QueryKey = int.Parse(row["QueryKey"].ToString());
                }
                if (row["loginId"] != null)
                {
                    model.loginId = row["loginId"].ToString();
                }
                if (row["userName"] != null)
                {
                    model.userName = row["userName"].ToString();
                }
                if (row["AcceptDate"] != null && row["AcceptDate"].ToString() != "")
                {
                    model.AcceptDate = DateTime.Parse(row["AcceptDate"].ToString());
                }
                if (row["waterUserTypeId"] != null)
                {
                    model.waterUserTypeId = row["waterUserTypeId"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["FlowID"] != null)
                {
                    model.FlowID = row["FlowID"].ToString();
                }
                if (row["ApplyUser"] != null)
                {
                    model.ApplyUser = row["ApplyUser"].ToString();
                }
                if (row["waterUserName"] != null && row["waterUserName"].ToString() != "")
                {
                    model.waterUserName = (byte[])row["waterUserName"];
                }
                if (row["SubmitDate"] != null && row["SubmitDate"].ToString() != "")
                {
                    model.SubmitDate = DateTime.Parse(row["SubmitDate"].ToString());
                }
                if (row["ContractNO"] != null)
                {
                    model.ContractNO = row["ContractNO"].ToString();
                }
                if (row["waterUserAddress"] != null)
                {
                    model.waterUserAddress = row["waterUserAddress"].ToString();
                }
                if (row["IsBoost"] != null && row["IsBoost"].ToString() != "")
                {
                    if ((row["IsBoost"].ToString() == "1") || (row["IsBoost"].ToString().ToLower() == "true"))
                    {
                        model.IsBoost = true;
                    }
                    else
                    {
                        model.IsBoost = false;
                    }
                }
                if (row["waterUserPeopleCount"] != null && row["waterUserPeopleCount"].ToString() != "")
                {
                    model.waterUserPeopleCount = int.Parse(row["waterUserPeopleCount"].ToString());
                }
                if (row["waterUserHouseType"] != null)
                {
                    model.waterUserHouseType = row["waterUserHouseType"].ToString();
                }
                if (row["waterPhone"] != null)
                {
                    model.waterPhone = row["waterPhone"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SingleID,SD,AcceptID,QueryKey,loginId,userName,AcceptDate,waterUserTypeId,State,FlowID,ApplyUser,waterUserName,SubmitDate,ContractNO,waterUserAddress,IsBoost,waterUserPeopleCount,waterUserHouseType,waterPhone ");
            strSql.Append(" FROM Meter_Install_Single ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable GetLists(string strWhere)
        {
            return GetList(strWhere).Tables[0];
        }

        public DataTable GetAllAcceptID()
        {
            string strSql = "SELECT DISTINCT loginId, userName FROM Meter_Install_Single WHERE (loginId IS NOT NULL) AND (loginId <> '') AND (userName <> '')";
            return DbHelperSQL.Query(strSql).Tables[0];
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" SingleID,SD,AcceptID,QueryKey,loginId,userName,AcceptDate,waterUserTypeId,State,FlowID,ApplyUser,waterUserName,SubmitDate,ContractNO,waterUserAddress,IsBoost,waterUserPeopleCount,waterUserHouseType,waterPhone ");
            strSql.Append(" FROM Meter_Install_Single ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Meter_Install_Single ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.SingleID desc");
            }
            strSql.Append(")AS Row, T.*  from Meter_Install_Single T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Meter_Install_Single";
            parameters[1].Value = "SingleID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        //WorkCode ：Meter_Install_Single

        public bool CreateWorkTask(string SingleID, string AcceptID)
        {
            bool result = true;
            try
            {
                string strLogID = AppDomain.CurrentDomain.GetData("LOGINID").ToString();
                string strRealName = AppDomain.CurrentDomain.GetData("USERNAME").ToString();

                string sqlstr = string.Format(@"DECLARE @SingleID NVARCHAR(50)='{0}'
DECLARE @WorkCode NVARCHAR(50)='Meter_Install_Single'
DECLARE @TaskName NVARCHAR(50)='用户报装-{1}'
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
INSERT INTO Meter_WorkResolve(ResolveID,TaskID,WorkFlowID,WorkName,PointName,PointSort,DoID,DoName,DepartementID,loginId,userName,Rulers,GroupID,TimeLimit,IsSkip,GoPointID,IsVoided,IsViewCharge,IsCharge,IsCashier) 
SELECT NEWID() AS ResolveID, @TaskID AS TaskID,VW.WorkFlowID,VW.WorkName,VW.PointName,VW.PointSort,VW.DoID,VW.DoName,VW.DepartementID,VW.loginId,VW.userName,VW.Rulers,VW.GroupID,VW.TimeLimit,VW.IsSkip,VW.GoPointID,VW.IsVoided,VW.IsViewCharge,VW.IsCharge,VW.IsCashier  FROM [View_WorkResolve] VW  WHERE WORKFLOWID=@WORKFLOWID
--写入Meter_WorkTask
INSERT INTO Meter_WorkTask (TaskID,TaskName,WorkFlowID,TaskCode,PointSort,AcceptUserID,AcceptUser,SD) VALUES (@TaskID,@TaskName,@WORKFLOWID,@WorkCode,@PointSort,@AcceptUserID,@AcceptUser,@SD)
--写入Meter_Install_Single
UPDATE Meter_Install_Single SET [State]=1,FlowID=@WORKFLOWID,TaskID=@TaskID WHERE SingleID=@SingleID
commit tran
SELECT  TOP 1 @NEXTSORT=PointSort FROM Meter_WorkResolve WHERE TaskID=@TaskID AND PointSort>@PointSort ORDER BY PointSort
SET XACT_ABORT ON
BEGIN TRAN  
UPDATE Meter_WorkResolve SET IsPass=1,AcceptUserID=@AcceptUserID,UserOpinion=@UserOpinion,AcceptUser=@AcceptUser,AcceptDate=GETDATE() WHERE TaskID=@TaskID
and PointSort=@PointSort and ','+loginId+',' like '%,'+@AcceptUserID+',%'
UPDATE Meter_WorkTask SET PointSort=@NEXTSORT,PointTime=GETDATE() WHERE TaskID=@TaskID
INSERT INTO Meter_WorkResolveFee (FeeID,FeeItem,IsFinal,DefaultValue,Sort,ResolveID) SELECT MF.FeeID, MF.FeeItem,MWF.IsFinal, MF.DefaultValue, MF.Sort,MWR.ResolveID FROM Meter_WorkDoFee MWF INNER JOIN Meter_FeeItmes MF ON MWF.FeeID = MF.FeeID INNER JOIN Meter_WorkResolve MWR ON MWF.DoID = MWR.DoID WHERE (MF.State = 1) AND (MWR.TaskID = @TaskID)
COMMIT TRAN
end", SingleID, AcceptID, strLogID, strRealName);
                DbHelperSQL.ExecuteSql(sqlstr);
            }
            catch (Exception ex)
            {

                result = false;
            }
            return result;
        }


        #endregion  ExtensionMethod
    }
}


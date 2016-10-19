using System;
using System.Collections.Generic;
using System.Text;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using DBinterface.IDAL;

namespace DBinterface.DAL
{
    public partial class Meter_DAL : Meter_IDAL
    {
        public Meter_DAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string MeterID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Meter");
			strSql.Append(" where MeterID=@MeterID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MeterID", SqlDbType.VarChar,50)			};
			parameters[0].Value = MeterID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(DBinterface.Model.Meter_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Meter(");
			strSql.Append("MeterID,waterMeterStartNumber,MeterState,waterUserId,waterMeterPositionName,waterMeterPositionId,waterMeterSizeId,waterMeterTypeId,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,isSummaryMeter,waterMeterParentId,waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,STARTUSEDATETIME,MEMO,CreateDate,ScrapDate,ScrapReason)");
			strSql.Append(" values (");
			strSql.Append("@MeterID,@waterMeterStartNumber,@MeterState,@waterUserId,@waterMeterPositionName,@waterMeterPositionId,@waterMeterSizeId,@waterMeterTypeId,@WATERFIXVALUE,@waterMeterProduct,@waterMeterSerialNumber,@waterMeterMode,@isSummaryMeter,@waterMeterParentId,@waterMeterMagnification,@waterMeterMaxRange,@waterMeterProofreadingDate,@waterMeteProofreadingPeriod,@STARTUSEDATETIME,@MEMO,@CreateDate,@ScrapDate,@ScrapReason)");
			SqlParameter[] parameters = {
					new SqlParameter("@MeterID", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterStartNumber", SqlDbType.Int,4),
					new SqlParameter("@MeterState", SqlDbType.TinyInt,1),
					new SqlParameter("@waterUserId", SqlDbType.VarChar,30),
					new SqlParameter("@waterMeterPositionName", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterPositionId", SqlDbType.VarChar,30),
					new SqlParameter("@waterMeterSizeId", SqlDbType.VarChar,30),
					new SqlParameter("@waterMeterTypeId", SqlDbType.VarChar,30),
					new SqlParameter("@WATERFIXVALUE", SqlDbType.Int,4),
					new SqlParameter("@waterMeterProduct", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterSerialNumber", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterMode", SqlDbType.VarChar,50),
					new SqlParameter("@isSummaryMeter", SqlDbType.VarChar,10),
					new SqlParameter("@waterMeterParentId", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterMagnification", SqlDbType.Int,4),
					new SqlParameter("@waterMeterMaxRange", SqlDbType.Int,4),
					new SqlParameter("@waterMeterProofreadingDate", SqlDbType.DateTime),
					new SqlParameter("@waterMeteProofreadingPeriod", SqlDbType.Int,4),
					new SqlParameter("@STARTUSEDATETIME", SqlDbType.DateTime),
					new SqlParameter("@MEMO", SqlDbType.VarChar,200),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ScrapDate", SqlDbType.DateTime),
					new SqlParameter("@ScrapReason", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.MeterID;
			parameters[1].Value = model.waterMeterStartNumber;
			parameters[2].Value = model.MeterState;
			parameters[3].Value = model.waterUserId;
			parameters[4].Value = model.waterMeterPositionName;
			parameters[5].Value = model.waterMeterPositionId;
			parameters[6].Value = model.waterMeterSizeId;
			parameters[7].Value = model.waterMeterTypeId;
			parameters[8].Value = model.WATERFIXVALUE;
			parameters[9].Value = model.waterMeterProduct;
			parameters[10].Value = model.waterMeterSerialNumber;
			parameters[11].Value = model.waterMeterMode;
			parameters[12].Value = model.isSummaryMeter;
			parameters[13].Value = model.waterMeterParentId;
			parameters[14].Value = model.waterMeterMagnification;
			parameters[15].Value = model.waterMeterMaxRange;
			parameters[16].Value = model.waterMeterProofreadingDate;
			parameters[17].Value = model.waterMeteProofreadingPeriod;
			parameters[18].Value = model.STARTUSEDATETIME;
			parameters[19].Value = model.MEMO;
			parameters[20].Value = model.CreateDate;
			parameters[21].Value = model.ScrapDate;
			parameters[22].Value = model.ScrapReason;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Update(DBinterface.Model.Meter_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Meter set ");
			strSql.Append("waterMeterStartNumber=@waterMeterStartNumber,");
			strSql.Append("MeterState=@MeterState,");
			strSql.Append("waterUserId=@waterUserId,");
			strSql.Append("waterMeterPositionName=@waterMeterPositionName,");
			strSql.Append("waterMeterPositionId=@waterMeterPositionId,");
			strSql.Append("waterMeterSizeId=@waterMeterSizeId,");
			strSql.Append("waterMeterTypeId=@waterMeterTypeId,");
			strSql.Append("WATERFIXVALUE=@WATERFIXVALUE,");
			strSql.Append("waterMeterProduct=@waterMeterProduct,");
			strSql.Append("waterMeterSerialNumber=@waterMeterSerialNumber,");
			strSql.Append("waterMeterMode=@waterMeterMode,");
			strSql.Append("isSummaryMeter=@isSummaryMeter,");
			strSql.Append("waterMeterParentId=@waterMeterParentId,");
			strSql.Append("waterMeterMagnification=@waterMeterMagnification,");
			strSql.Append("waterMeterMaxRange=@waterMeterMaxRange,");
			strSql.Append("waterMeterProofreadingDate=@waterMeterProofreadingDate,");
			strSql.Append("waterMeteProofreadingPeriod=@waterMeteProofreadingPeriod,");
			strSql.Append("STARTUSEDATETIME=@STARTUSEDATETIME,");
			strSql.Append("MEMO=@MEMO,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("ScrapDate=@ScrapDate,");
			strSql.Append("ScrapReason=@ScrapReason");
			strSql.Append(" where MeterID=@MeterID ");
			SqlParameter[] parameters = {
					new SqlParameter("@waterMeterStartNumber", SqlDbType.Int,4),
					new SqlParameter("@MeterState", SqlDbType.TinyInt,1),
					new SqlParameter("@waterUserId", SqlDbType.VarChar,30),
					new SqlParameter("@waterMeterPositionName", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterPositionId", SqlDbType.VarChar,30),
					new SqlParameter("@waterMeterSizeId", SqlDbType.VarChar,30),
					new SqlParameter("@waterMeterTypeId", SqlDbType.VarChar,30),
					new SqlParameter("@WATERFIXVALUE", SqlDbType.Int,4),
					new SqlParameter("@waterMeterProduct", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterSerialNumber", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterMode", SqlDbType.VarChar,50),
					new SqlParameter("@isSummaryMeter", SqlDbType.VarChar,10),
					new SqlParameter("@waterMeterParentId", SqlDbType.VarChar,50),
					new SqlParameter("@waterMeterMagnification", SqlDbType.Int,4),
					new SqlParameter("@waterMeterMaxRange", SqlDbType.Int,4),
					new SqlParameter("@waterMeterProofreadingDate", SqlDbType.DateTime),
					new SqlParameter("@waterMeteProofreadingPeriod", SqlDbType.Int,4),
					new SqlParameter("@STARTUSEDATETIME", SqlDbType.DateTime),
					new SqlParameter("@MEMO", SqlDbType.VarChar,200),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ScrapDate", SqlDbType.DateTime),
					new SqlParameter("@ScrapReason", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.waterMeterStartNumber;
			parameters[1].Value = model.MeterState;
			parameters[2].Value = model.waterUserId;
			parameters[3].Value = model.waterMeterPositionName;
			parameters[4].Value = model.waterMeterPositionId;
			parameters[5].Value = model.waterMeterSizeId;
			parameters[6].Value = model.waterMeterTypeId;
			parameters[7].Value = model.WATERFIXVALUE;
			parameters[8].Value = model.waterMeterProduct;
			parameters[9].Value = model.waterMeterSerialNumber;
			parameters[10].Value = model.waterMeterMode;
			parameters[11].Value = model.isSummaryMeter;
			parameters[12].Value = model.waterMeterParentId;
			parameters[13].Value = model.waterMeterMagnification;
			parameters[14].Value = model.waterMeterMaxRange;
			parameters[15].Value = model.waterMeterProofreadingDate;
			parameters[16].Value = model.waterMeteProofreadingPeriod;
			parameters[17].Value = model.STARTUSEDATETIME;
			parameters[18].Value = model.MEMO;
			parameters[19].Value = model.CreateDate;
			parameters[20].Value = model.ScrapDate;
			parameters[21].Value = model.ScrapReason;
			parameters[22].Value = model.MeterID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string MeterID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Meter ");
			strSql.Append(" where MeterID=@MeterID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MeterID", SqlDbType.VarChar,50)			};
			parameters[0].Value = MeterID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string MeterIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Meter ");
			strSql.Append(" where MeterID in ("+MeterIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public DBinterface.Model.Meter_Model GetModel(string MeterID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MeterID,waterMeterStartNumber,MeterState,waterUserId,waterMeterPositionName,waterMeterPositionId,waterMeterSizeId,waterMeterTypeId,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,isSummaryMeter,waterMeterParentId,waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,STARTUSEDATETIME,MEMO,CreateDate,ScrapDate,ScrapReason from Meter ");
			strSql.Append(" where MeterID=@MeterID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MeterID", SqlDbType.VarChar,50)			};
			parameters[0].Value = MeterID;

            DBinterface.Model.Meter_Model model = new DBinterface.Model.Meter_Model();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public DBinterface.Model.Meter_Model DataRowToModel(DataRow row)
		{
            DBinterface.Model.Meter_Model model = new DBinterface.Model.Meter_Model();
			if (row != null)
			{
				if(row["MeterID"]!=null)
				{
					model.MeterID=row["MeterID"].ToString();
				}
				if(row["waterMeterStartNumber"]!=null && row["waterMeterStartNumber"].ToString()!="")
				{
					model.waterMeterStartNumber=int.Parse(row["waterMeterStartNumber"].ToString());
				}
				if(row["MeterState"]!=null && row["MeterState"].ToString()!="")
				{
					model.MeterState=int.Parse(row["MeterState"].ToString());
				}
				if(row["waterUserId"]!=null)
				{
					model.waterUserId=row["waterUserId"].ToString();
				}
				if(row["waterMeterPositionName"]!=null)
				{
					model.waterMeterPositionName=row["waterMeterPositionName"].ToString();
				}
				if(row["waterMeterPositionId"]!=null)
				{
					model.waterMeterPositionId=row["waterMeterPositionId"].ToString();
				}
				if(row["waterMeterSizeId"]!=null)
				{
					model.waterMeterSizeId=row["waterMeterSizeId"].ToString();
				}
				if(row["waterMeterTypeId"]!=null)
				{
					model.waterMeterTypeId=row["waterMeterTypeId"].ToString();
				}
				if(row["WATERFIXVALUE"]!=null && row["WATERFIXVALUE"].ToString()!="")
				{
					model.WATERFIXVALUE=int.Parse(row["WATERFIXVALUE"].ToString());
				}
				if(row["waterMeterProduct"]!=null)
				{
					model.waterMeterProduct=row["waterMeterProduct"].ToString();
				}
				if(row["waterMeterSerialNumber"]!=null)
				{
					model.waterMeterSerialNumber=row["waterMeterSerialNumber"].ToString();
				}
				if(row["waterMeterMode"]!=null)
				{
					model.waterMeterMode=row["waterMeterMode"].ToString();
				}
				if(row["isSummaryMeter"]!=null)
				{
					model.isSummaryMeter=row["isSummaryMeter"].ToString();
				}
				if(row["waterMeterParentId"]!=null)
				{
					model.waterMeterParentId=row["waterMeterParentId"].ToString();
				}
				if(row["waterMeterMagnification"]!=null && row["waterMeterMagnification"].ToString()!="")
				{
					model.waterMeterMagnification=int.Parse(row["waterMeterMagnification"].ToString());
				}
				if(row["waterMeterMaxRange"]!=null && row["waterMeterMaxRange"].ToString()!="")
				{
					model.waterMeterMaxRange=int.Parse(row["waterMeterMaxRange"].ToString());
				}
				if(row["waterMeterProofreadingDate"]!=null && row["waterMeterProofreadingDate"].ToString()!="")
				{
					model.waterMeterProofreadingDate=DateTime.Parse(row["waterMeterProofreadingDate"].ToString());
				}
				if(row["waterMeteProofreadingPeriod"]!=null && row["waterMeteProofreadingPeriod"].ToString()!="")
				{
					model.waterMeteProofreadingPeriod=int.Parse(row["waterMeteProofreadingPeriod"].ToString());
				}
				if(row["STARTUSEDATETIME"]!=null && row["STARTUSEDATETIME"].ToString()!="")
				{
					model.STARTUSEDATETIME=DateTime.Parse(row["STARTUSEDATETIME"].ToString());
				}
				if(row["MEMO"]!=null)
				{
					model.MEMO=row["MEMO"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["ScrapDate"]!=null && row["ScrapDate"].ToString()!="")
				{
					model.ScrapDate=DateTime.Parse(row["ScrapDate"].ToString());
				}
				if(row["ScrapReason"]!=null)
				{
					model.ScrapReason=row["ScrapReason"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MeterID,waterMeterStartNumber,MeterState,waterUserId,waterMeterPositionName,waterMeterPositionId,waterMeterSizeId,waterMeterTypeId,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,isSummaryMeter,waterMeterParentId,waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,STARTUSEDATETIME,MEMO,CreateDate,ScrapDate,ScrapReason ");
			strSql.Append(" FROM Meter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" MeterID,waterMeterStartNumber,MeterState,waterUserId,waterMeterPositionName,waterMeterPositionId,waterMeterSizeId,waterMeterTypeId,WATERFIXVALUE,waterMeterProduct,waterMeterSerialNumber,waterMeterMode,isSummaryMeter,waterMeterParentId,waterMeterMagnification,waterMeterMaxRange,waterMeterProofreadingDate,waterMeteProofreadingPeriod,STARTUSEDATETIME,MEMO,CreateDate,ScrapDate,ScrapReason ");
			strSql.Append(" FROM Meter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Meter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.MeterID desc");
			}
			strSql.Append(")AS Row, T.*  from Meter T ");
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
			parameters[0].Value = "Meter";
			parameters[1].Value = "MeterID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}
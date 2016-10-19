using System;
using System.Data;
using System.Collections.Generic;
using DBinterface.Model;
using DBinterface.DALFactory;
using DBinterface.IDAL;
using Common.DotNetData;
using Common.DotNetCode;
namespace DBinterface.BLL
{
	/// <summary>
	/// Meter_Install_Single
	/// </summary>
	public partial class Meter_Install_Single
	{
		private readonly IMeter_Install_Single dal=DataAccess.CreateMeter_Install_Single();
		public Meter_Install_Single()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SingleID)
		{
			return dal.Exists(SingleID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DBinterface.Model.Meter_Install_Single model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DBinterface.Model.Meter_Install_Single model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SingleID)
		{
			
			return dal.Delete(SingleID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SingleIDlist )
		{
			return dal.DeleteList(PageValidate.SafeLongFilter(SingleIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DBinterface.Model.Meter_Install_Single GetModel(string SingleID)
		{
			
			return dal.GetModel(SingleID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public DBinterface.Model.Meter_Install_Single GetModelByCache(string SingleID)
		{
			
			string CacheKey = "Meter_Install_SingleModel-" + SingleID;
			object objModel = DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(SingleID);
					if (objModel != null)
					{
						int ModelCache = 30;
						DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DBinterface.Model.Meter_Install_Single)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DBinterface.Model.Meter_Install_Single> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DBinterface.Model.Meter_Install_Single> DataTableToList(DataTable dt)
		{
			List<DBinterface.Model.Meter_Install_Single> modelList = new List<DBinterface.Model.Meter_Install_Single>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DBinterface.Model.Meter_Install_Single model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


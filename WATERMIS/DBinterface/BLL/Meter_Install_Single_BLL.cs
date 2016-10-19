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
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string SingleID)
		{
			return dal.Exists(SingleID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Add(DBinterface.Model.Meter_Install_Single model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(DBinterface.Model.Meter_Install_Single model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string SingleID)
		{
			
			return dal.Delete(SingleID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string SingleIDlist )
		{
			return dal.DeleteList(PageValidate.SafeLongFilter(SingleIDlist,0) );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DBinterface.Model.Meter_Install_Single GetModel(string SingleID)
		{
			
			return dal.GetModel(SingleID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DBinterface.Model.Meter_Install_Single> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// ��ҳ��ȡ�����б�
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


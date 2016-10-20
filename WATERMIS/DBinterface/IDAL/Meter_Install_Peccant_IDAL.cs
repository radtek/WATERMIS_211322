using System;
using System.Data;
namespace DBinterface.IDAL
{
	/// <summary>
	/// 接口层Meter_Install_Single
	/// </summary>
    public interface IMeter_Install_Peccant
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string SingleID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(DBinterface.Model.Meter_Install_Single model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(DBinterface.Model.Meter_Install_Single model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string SingleID);
		bool DeleteList(string SingleIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		DBinterface.Model.Meter_Install_Single GetModel(string SingleID);
		DBinterface.Model.Meter_Install_Single DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
        DataTable GetAllAcceptID();
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx
        bool CreateWorkTask(string SingleID, string AcceptID);
		#endregion  MethodEx
	} 
}

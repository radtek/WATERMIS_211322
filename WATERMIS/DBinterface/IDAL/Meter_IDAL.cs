using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DBinterface.IDAL
{
    public interface Meter_IDAL
    {
        #region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string MeterID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
        bool Add(DBinterface.Model.Meter_Model model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        bool Update(DBinterface.Model.Meter_Model model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(string MeterID);
		bool DeleteList(string MeterIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        DBinterface.Model.Meter_Model GetModel(string MeterID);
        DBinterface.Model.Meter_Model DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	} 
}

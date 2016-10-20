using System;
using System.Data;
namespace DBinterface.IDAL
{
	/// <summary>
	/// �ӿڲ�Meter_Install_Single
	/// </summary>
    public interface IMeter_Install_Peccant
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(string SingleID);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Add(DBinterface.Model.Meter_Install_Single model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(DBinterface.Model.Meter_Install_Single model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(string SingleID);
		bool DeleteList(string SingleIDlist );
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		DBinterface.Model.Meter_Install_Single GetModel(string SingleID);
		DBinterface.Model.Meter_Install_Single DataRowToModel(DataRow row);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
        DataTable GetAllAcceptID();
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
		#region  MethodEx
        bool CreateWorkTask(string SingleID, string AcceptID);
		#endregion  MethodEx
	} 
}

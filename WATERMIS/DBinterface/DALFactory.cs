using System;
using System.Reflection;
using DBinterface.IDAL;
using Common.DotNetData;
namespace DBinterface.DALFactory
{
	/// <summary>
	/// ���󹤳�ģʽ����DAL��
	/// web.config ��Ҫ�������ã�(���ù���ģʽ+�������+�������,ʵ�ֶ�̬������ͬ�����ݲ����ӿ�) 
	/// DataCache���ڵ���������ļ�����
	/// <appSettings> 
	/// <add key="DAL" value="DBinterface.SQLServerDAL" /> (����������ռ����ʵ���������Ϊ�Լ���Ŀ�������ռ�)
	/// </appSettings> 
	/// </summary>
	public sealed class DataAccess//<t>
	{
        private static readonly string AssemblyPath = "DBinterface.DAL";
		/// <summary>
		/// ���������ӻ����ȡ
		/// </summary>
		public static object CreateObject(string AssemblyPath,string ClassNamespace)
		{
			object objType = DataCache.GetCache(ClassNamespace);//�ӻ����ȡ
			if (objType == null)
			{
				try
				{
					objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//���䴴��
					DataCache.SetCache(ClassNamespace, objType);// д�뻺��
				}
				catch
				{}
			}
			return objType;
		}
		/// <summary>
		/// �������ݲ�ӿ�
		/// </summary>
		//public static t Create(string ClassName)
		//{
			//string ClassNamespace = AssemblyPath +"."+ ClassName;
			//object objType = CreateObject(AssemblyPath, ClassNamespace);
			//return (t)objType;
		//}
		/// <summary>
		/// ����Meter_Install_Single���ݲ�ӿڡ�
		/// </summary>
		public static DBinterface.IDAL.IMeter_Install_Single CreateMeter_Install_Single()
		{

			string ClassNamespace = AssemblyPath +".Meter_Install_Single";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (DBinterface.IDAL.IMeter_Install_Single)objType;
		}

	}
}

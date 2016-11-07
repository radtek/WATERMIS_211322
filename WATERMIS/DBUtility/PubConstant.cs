using System;
using System.Configuration;
namespace DBUtility
{
    
    public class PubConstant
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString(int i)
        {
            string _connectionString;
            if (i == 1)
            {
                string strServerIp = ConfigurationSettings.AppSettings["connStringServerIP"];
                string strDataSourceName = ConfigurationSettings.AppSettings["connStringDataSourceName"];
                string strLoginName = ConfigurationSettings.AppSettings["connStringLoginName"];
                string strPWD = ConfigurationSettings.AppSettings["connStringPWD"];
                //_connectionString = ConfigurationSettings.AppSettings["connString"];
                //_connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};",strServerIp,strDataSourceName,strLoginName,strPWD); 
                _connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID=SERVICECLIENT;Password=##AUTHORITY@C2s;", strServerIp, strDataSourceName); 
            }
            else
                _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CRYSTAL.mdb;User Id=admin;Password=;";// ConfigurationSettings.AppSettings["connStringAccess"];
            //string ConStringEncrypt = ConfigurationSettings.AppSettings["ConStringEncrypt"];
            //if (ConStringEncrypt.ToLower() == "true")
            //{
            //    //_connectionString = DESEncrypt.Decrypt(_connectionString);
            //    _connectionString = DESEncrypt.Encrypt(_connectionString);
            //}
            return _connectionString;

        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationSettings.AppSettings["configName"];
            string ConStringEncrypt = ConfigurationSettings.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }


    }
}

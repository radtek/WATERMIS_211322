using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace BLL
{
    public class BLLACCOUNTSRUNNING
   {
       public DataTable Query(string strWhere)
       {
           DataTable DT = new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM ACCOUNTSRUNNING WHERE 1=1 ");
           DT = DBUtility.DbHelperSQL.Query(str.ToString() + strWhere).Tables[0];
           return DT;
       }
       public bool UpdateBusinessMoney(MODELACCOUNTSRUNNING MODELACCOUNTSRUNNING)
        {
            StringBuilder str=new StringBuilder();
            str.Append("UPDATE ACCOUNTSRUNNING SET BUSINESSMONEY=@BUSINESSMONEY WHERE ACCOUNTSID=@ACCOUNTSID");
            SqlParameter[] para=
            {
                new SqlParameter("ACCOUNTSID",SqlDbType.VarChar,30)
            };
            para[0].Value = MODELACCOUNTSRUNNING.BUSINESSMONEY;
            para[1].Value = MODELACCOUNTSRUNNING.ACCOUNTSID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
        }
       public bool UpdateFinanceMoney(MODELACCOUNTSRUNNING MODELACCOUNTSRUNNING)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE ACCOUNTSRUNNING SET FINANCEMONEY=@FINANCEMONEY WHERE ACCOUNTSID=@ACCOUNTSID");
           SqlParameter[] para =
            {
                new SqlParameter("ACCOUNTSID",SqlDbType.VarChar,30)
            };
           para[0].Value = MODELACCOUNTSRUNNING.FINANCEMONEY;
           para[1].Value = MODELACCOUNTSRUNNING.ACCOUNTSID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Delete(string strDEPID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM ACCOUNTSRUNNING WHERE ACCOUNTSID=@ACCOUNTSID");
           SqlParameter[] para =
           {
               new SqlParameter("@ACCOUNTSID",SqlDbType.VarChar,30)
           };
           para[0].Value = strDEPID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       /// <summary>
       /// 执行自定义语句
       /// </summary>
       /// <param name="MODELreadMeterRecord"></param>
       /// <returns></returns>
       public int ExcuteSQL(string strSQL)
       {
           int intCount = DBUtility.DbHelperSQL.ExecuteSql(strSQL);
           return intCount;
           //if (DBUtility.DbHelperSQL.ExecuteSql(strSQL) > 0)
           //    return true;
           //else
           //    return false;
       }
    }
}

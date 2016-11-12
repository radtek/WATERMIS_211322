using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLMESSAGERECEIVE
    {
       public DataTable Query(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM MESSAGERECEIVE INNER JOIN MESSAGESEND ON MESSAGERECEIVE.MESSAGESENDID=MESSAGESEND.MESSAGESENDID ");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }
       public bool Delete(string strFilter)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM MESSAGERECEIVE WHERE 1=1 ");
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString() + strFilter) > 0)
               return true;
           else
               return false;
       }

       /// <summary>
       /// 更新已读标志
       /// </summary>
       /// <param name="strID"></param>
       /// <returns></returns>
       public bool UpdateReadSign(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE MESSAGERECEIVE SET MESSAGEREADEDSIGN='1',MESSAGEREADEDDATETIME=GETDATE(),ISPOPSHOW='1' WHERE  MESSAGERECEIVEID=@MESSAGERECEIVEID");
           SqlParameter[] para =
           {
               new SqlParameter("@MESSAGERECEIVEID",SqlDbType.VarChar,50)
           };
           para[0].Value = strID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       /// <summary>
       /// 更新删除标志
       /// </summary>
       /// <param name="strID"></param>
       /// <returns></returns>
       public bool UpdateDeleteSign(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE MESSAGERECEIVE SET ISDELETE='1',DELETEDATETIME=GETDATE() WHERE  MESSAGERECEIVEID=@MESSAGERECEIVEID");
           SqlParameter[] para =
           {
               new SqlParameter("@MESSAGERECEIVEID",SqlDbType.VarChar,50)
           };
           para[0].Value = strID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }

       /// <summary>
       /// 更新弹窗口标志
       /// </summary>
       /// <param name="strID"></param>
       /// <returns></returns>
       public bool UpdatePopSign(string strID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("UPDATE MESSAGERECEIVE SET ISPOPSHOW='1' WHERE  MESSAGERECEIVEID=@MESSAGERECEIVEID");
           SqlParameter[] para =
           {
               new SqlParameter("@MESSAGERECEIVEID",SqlDbType.VarChar,50)
           };
           para[0].Value = strID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELMESSAGERECEIVE MODELMESSAGERECEIVE)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO MESSAGERECEIVE(MESSAGERECEIVEID,MESSAGESENDID,MESSAGERECEIVERID,MESSAGERECEIVERNAME) ");
           str.Append("VALUES(@MESSAGERECEIVEID,@MESSAGESENDID,@MESSAGERECEIVERID,@MESSAGERECEIVERNAME)");
           SqlParameter[] para =
           {
               new SqlParameter("@MESSAGERECEIVEID",SqlDbType.VarChar,50),
               new SqlParameter("@MESSAGESENDID",SqlDbType.VarChar,50),
               new SqlParameter("@MESSAGERECEIVERID",SqlDbType.VarChar,30),
               new SqlParameter("@MESSAGERECEIVERNAME",SqlDbType.VarChar,50)
           };
           para[0].Value = MODELMESSAGERECEIVE.MESSAGERECEIVEID;
           para[1].Value = MODELMESSAGERECEIVE.MESSAGESENDID;
           para[2].Value = MODELMESSAGERECEIVE.MESSAGERECEIVERID;
           para[3].Value = MODELMESSAGERECEIVE.MESSAGERECEIVERNAME;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}

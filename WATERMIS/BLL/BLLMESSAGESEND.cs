using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using MODEL;

namespace BLL
{
    public class BLLMESSAGESEND
    {
       public DataTable Query(string strFilter)
       {
           DataTable dt=new DataTable();
           StringBuilder str = new StringBuilder();
           str.Append("SELECT * FROM MESSAGESEND WHERE 1=1");
           dt = DBUtility.DbHelperSQL.Query(str.ToString()+strFilter).Tables[0];
           return dt;
       }
        /// <summary>
        /// 删除已发布消息
        /// </summary>
        /// <param name="strUserID"></param>
        /// <returns></returns>
       public bool Delete(string strUserID)
       {
           StringBuilder str = new StringBuilder();
           str.Append("DELETE FROM MESSAGESEND WHERE MESSAGESENDID=@MESSAGESENDID");
           SqlParameter[] para =
           {
               new SqlParameter("@MESSAGESENDID",SqlDbType.VarChar,30)
           };
           para[0].Value = strUserID;
           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(),para) > 0)
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
           str.Append("UPDATE MESSAGESEND SET ISDELETE='1',DELETEDATETIME=GETDATE() WHERE  MESSAGESENDID=@MESSAGESENDID");
           SqlParameter[] para =
           {
               new SqlParameter("@MESSAGESENDID",SqlDbType.VarChar,50)
           };
           para[0].Value =strID;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
       public bool Insert(MODELMESSAGESEND MODELMESSAGESEND)
       {
           StringBuilder str = new StringBuilder();
           str.Append("INSERT INTO MESSAGESEND(MESSAGESENDID,MESSAGESENDERID,MESSAGESENDERNAME,MESSAGERECEIVER,MESSAGECONTENT,MESSAGECLASS,MESSAGESENDTIME,MESSAGETITLE) ");
           str.Append("VALUES(@MESSAGESENDID,@MESSAGESENDERID,@MESSAGESENDERNAME,@MESSAGERECEIVER,@MESSAGECONTENT,@MESSAGECLASS,@MESSAGESENDTIME,@MESSAGETITLE)");
           SqlParameter[] para =
           {
               new SqlParameter("@MESSAGESENDID",SqlDbType.VarChar,50),
               new SqlParameter("@MESSAGESENDERID",SqlDbType.VarChar,50),
               new SqlParameter("@MESSAGESENDERNAME",SqlDbType.VarChar,50),
               new SqlParameter("@MESSAGERECEIVER",SqlDbType.VarChar,1000),
               new SqlParameter("@MESSAGECONTENT",SqlDbType.VarChar,1000),
               new SqlParameter("@MESSAGECLASS",SqlDbType.VarChar,10),
               new SqlParameter("@MESSAGESENDTIME",SqlDbType.DateTime),
               new SqlParameter("@MESSAGETITLE",SqlDbType.VarChar,100)
           };
           para[0].Value = MODELMESSAGESEND.MESSAGESENDID;
           para[1].Value = MODELMESSAGESEND.MESSAGESENDERID;
           para[2].Value = MODELMESSAGESEND.MESSAGESENDERNAME;
           para[3].Value = MODELMESSAGESEND.MESSAGERECEIVER;
           para[4].Value = MODELMESSAGESEND.MESSAGECONTENT;
           para[5].Value = MODELMESSAGESEND.MESSAGECLASS;
           para[6].Value = MODELMESSAGESEND.MESSAGESENDTIME;
           para[7].Value = MODELMESSAGESEND.MESSAGETITLE;

           if (DBUtility.DbHelperSQL.ExecuteSql(str.ToString(), para) > 0)
               return true;
           else
               return false;
       }
    }
}

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.Sql;

namespace DBUtility
{
    /// <summary>
    /// 数据访问抽象基础类
    /// Copyright (C) 2004-2008 By LiTianPing 
    /// </summary>
    public abstract class DbHelperSQL
    {
        #region SQL部分
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        public static string connectionString = PubConstant.ConnectionString(1);
        public DbHelperSQL()
        {
        }

        #region 公用方法
        /// <summary>
        /// 判断是否存在某表的某个字段
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>是否存在</returns>
        public static bool ColumnExists(string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = GetSingle(sql);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool Exists(string strSql)
        {
            object obj = DbHelperSQL.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = DbHelperSQL.GetSingle(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = DbHelperSQL.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行带一个参数的存储过程
        /// </summary>
        /// <param name="strProName">存储过程名</param>
        /// <param name="strPara">参数</param>
        /// <returns></returns>
        public static DataSet ExecuteProOnePara(string strProName, string strPara)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strProName, connection);
                //把Command执行类型改为存储过程方式，默认为Text。
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 200;

                //传递一个输入参数，需赋值
                SqlParameter sp = cmd.Parameters.Add("@STRFILTER", SqlDbType.VarChar, 500);
                sp.Value = strPara;
                        //使用SqlDataAdapter将自动完成数据库的打开和关闭过程，并执行相应t-sql语句或存储过程
                        //如果存储过程只是执行相关操作，如级联删除或更新，使用SqlCommand的execute方法即可。
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        connection.Open();
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        da.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 执行带二个参数的存储过程
        /// </summary>
        /// <param name="strProName">存储过程名</param>
        /// <param name="strPara">参数</param>
        /// <returns></returns>
        public static DataSet ExecuteProTwoPara(string strProName, string strPara, string strPara1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strProName, connection);
                //把Command执行类型改为存储过程方式，默认为Text。
                cmd.CommandType = CommandType.StoredProcedure;

                //传递一个输入参数，需赋值
                SqlParameter sp = cmd.Parameters.Add("@STRFILTER", SqlDbType.VarChar, 500);
                sp.Value = strPara;

                //传递一个输入参数，需赋值
                SqlParameter sp1 = cmd.Parameters.Add("@STRGROUPTYPE", SqlDbType.VarChar, 30);
                sp1.Value = strPara1;
                //使用SqlDataAdapter将自动完成数据库的打开和关闭过程，并执行相应t-sql语句或存储过程
                //如果存储过程只是执行相关操作，如级联删除或更新，使用SqlCommand的execute方法即可。
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        connection.Open();
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        da.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 执行带四个参数的存储过程
        /// </summary>
        /// <param name="strProName">存储过程名</param>
        /// <param name="strPara">参数</param>
        /// <returns></returns>
        public static DataSet ExecuteProFourthPara(string strProName, string strPara1, DateTime strPara2, int strPara3, decimal strPara4)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strProName, connection);
                //把Command执行类型改为存储过程方式，默认为Text。
                cmd.CommandType = CommandType.StoredProcedure;

                //传递一个输入参数，需赋值
                SqlParameter sp1 = cmd.Parameters.Add("@STRFILTER", SqlDbType.VarChar, 200);
                sp1.Value = strPara1;

                //传递一个输入参数，需赋值
                SqlParameter sp2 = cmd.Parameters.Add("@YEARANDMONTH", SqlDbType.DateTime);
                sp2.Value = strPara2;

                //传递一个输入参数，需赋值
                SqlParameter sp3 = cmd.Parameters.Add("@MONTHCOUNT", SqlDbType.Int);
                sp3.Value = strPara3;

                //传递一个输入参数，需赋值
                SqlParameter sp4 = cmd.Parameters.Add("@RANGEVALUE", SqlDbType.Float);
                sp4.Value = strPara4;
                //使用SqlDataAdapter将自动完成数据库的打开和关闭过程，并执行相应t-sql语句或存储过程
                //如果存储过程只是执行相关操作，如级联删除或更新，使用SqlCommand的execute方法即可。
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    try
                    {
                        connection.Open();
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        da.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行Sql和Oracle滴混合事务
        /// </summary>
        /// <param name="list">SQL命令行列表</param>
        /// <param name="oracleCmdSqlList">Oracle命令行列表</param>
        /// <returns>执行结果 0-由于SQL造成事务失败 -1 由于Oracle造成事务失败 1-整体事务执行成功</returns>
        //public static int ExecuteSqlTran(List<CommandInfo> list, List<CommandInfo> oracleCmdSqlList)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        SqlTransaction tx = conn.BeginTransaction();
        //        cmd.Transaction = tx;
        //        try
        //        {
        //            foreach (CommandInfo myDE in list)
        //            {
        //                string cmdText = myDE.CommandText;
        //                SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
        //                PrepareCommand(cmd, conn, tx, cmdText, cmdParms);
        //                if (myDE.EffentNextType == EffentNextType.SolicitationEvent)
        //                {
        //                    if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
        //                    {
        //                        tx.Rollback();
        //                        throw new Exception("违背要求" + myDE.CommandText + "必须符合select count(..的格式");
        //                        //return 0;
        //                    }

        //                    object obj = cmd.ExecuteScalar();
        //                    bool isHave = false;
        //                    if (obj == null && obj == DBNull.Value)
        //                    {
        //                        isHave = false;
        //                    }
        //                    isHave = Convert.ToInt32(obj) > 0;
        //                    if (isHave)
        //                    {
        //                        //引发事件
        //                        myDE.OnSolicitationEvent();
        //                    }
        //                }
        //                if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
        //                {
        //                    if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
        //                    {
        //                        tx.Rollback();
        //                        throw new Exception("SQL:违背要求" + myDE.CommandText + "必须符合select count(..的格式");
        //                        //return 0;
        //                    }

        //                    object obj = cmd.ExecuteScalar();
        //                    bool isHave = false;
        //                    if (obj == null && obj == DBNull.Value)
        //                    {
        //                        isHave = false;
        //                    }
        //                    isHave = Convert.ToInt32(obj) > 0;

        //                    if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
        //                    {
        //                        tx.Rollback();
        //                        throw new Exception("SQL:违背要求" + myDE.CommandText + "返回值必须大于0");
        //                        //return 0;
        //                    }
        //                    if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
        //                    {
        //                        tx.Rollback();
        //                        throw new Exception("SQL:违背要求" + myDE.CommandText + "返回值必须等于0");
        //                        //return 0;
        //                    }
        //                    continue;
        //                }
        //                int val = cmd.ExecuteNonQuery();
        //                if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
        //                {
        //                    tx.Rollback();
        //                    throw new Exception("SQL:违背要求" + myDE.CommandText + "必须有影响行");
        //                    //return 0;
        //                }
        //                cmd.Parameters.Clear();
        //            }
        //            string oraConnectionString = PubConstant.GetConnectionString("ConnectionStringPPC");
        //            bool res = OracleHelper.ExecuteSqlTran(oraConnectionString, oracleCmdSqlList);
        //            if (!res)
        //            {
        //                tx.Rollback();
        //                throw new Exception("Oracle执行失败");
        //                // return -1;
        //            }
        //            tx.Commit();
        //            return 1;
        //        }
        //        catch (System.Data.SqlClient.SqlException e)
        //        {
        //            tx.Rollback();
        //            throw e;
        //        }
        //        catch (Exception e)
        //        {
        //            tx.Rollback();
        //            throw e;
        //        }
        //    }
        //}
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        public static object GetSingle(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }

        }
        public static object ExecuteScalar(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                object val =cmd.ExecuteScalar();
                return val;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                try
                {
                    connection.Open();
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    command.Dispose();
                    connection.Close();
                }
                return ds;
            }
        }
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                    command.Dispose();
                    connection.Close();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }



        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                            throw e;

                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static int ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            try
        //            {
        //                int count = 0;
        //                //循环
        //                foreach (CommandInfo myDE in cmdList)
        //                {
        //                    string cmdText = myDE.CommandText;
        //                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);

        //                    if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
        //                    {
        //                        if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }

        //                        object obj = cmd.ExecuteScalar();
        //                        bool isHave = false;
        //                        if (obj == null && obj == DBNull.Value)
        //                        {
        //                            isHave = false;
        //                        }
        //                        isHave = Convert.ToInt32(obj) > 0;

        //                        if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }
        //                        if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
        //                        {
        //                            trans.Rollback();
        //                            return 0;
        //                        }
        //                        continue;
        //                    }
        //                    int val = cmd.ExecuteNonQuery();
        //                    count += val;
        //                    if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
        //                    {
        //                        trans.Rollback();
        //                        return 0;
        //                    }
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //                return count;
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        //public static void ExecuteSqlTranWithIndentity(System.Collections.Generic.List<CommandInfo> SQLStringList)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction trans = conn.BeginTransaction())
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            try
        //            {
        //                int indentity = 0;
        //                //循环
        //                foreach (CommandInfo myDE in SQLStringList)
        //                {
        //                    string cmdText = myDE.CommandText;
        //                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Parameters;
        //                    foreach (SqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.InputOutput)
        //                        {
        //                            q.Value = indentity;
        //                        }
        //                    }
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    foreach (SqlParameter q in cmdParms)
        //                    {
        //                        if (q.Direction == ParameterDirection.Output)
        //                        {
        //                            indentity = Convert.ToInt32(q.Value);
        //                        }
        //                    }
        //                    cmd.Parameters.Clear();
        //                }
        //                trans.Commit();
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return 0;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;

        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }


        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion
        #endregion

        ////private OleDbConnection con = null;
        ////private OleDbCommand com = null;
        ////private OleDbTransaction trans = null;

        ////#region Access部分


        //////数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        ////public static string connectionString = PubConstant.ConnectionString(2);
        ////public static OleDbConnection connection = new OleDbConnection(connectionString);
        ////public DbHelperSQL()
        ////{

        ////}

        ////#region 公用方法
        /////// <summary>
        /////// 判断是否存在某表的某个字段
        /////// </summary>
        /////// <param name="tableName">表名称</param>
        /////// <param name="columnName">列名称</param>
        /////// <returns>是否存在</returns>
        ////public static bool ColumnExists(string tableName, string columnName)
        ////{
        ////    string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
        ////    object res = GetSingle(sql);
        ////    if (res == null)
        ////    {
        ////        return false;
        ////    }
        ////    return Convert.ToInt32(res) > 0;
        ////}
        ////public static int GetMaxID(string FieldName, string TableName)
        ////{
        ////    string strsql = "select max(" + FieldName + ")+1 from " + TableName;
        ////    object obj = OleDb.GetSingle(strsql);
        ////    if (obj == null)
        ////    {
        ////        return 1;
        ////    }
        ////    else
        ////    {
        ////        return int.Parse(obj.ToString());
        ////    }
        ////}
        ////public static int GetMaxID(string FieldName, string TableName,string strwhere)
        ////{
        ////    string strsql = "select max(" + FieldName + ")+1 from " + TableName+" where "+strwhere;
        ////    object obj = OleDb.GetSingle(strsql);
        ////    if (obj == null)
        ////    {
        ////        return 1;
        ////    }
        ////    else
        ////    {
        ////        return int.Parse(obj.ToString());
        ////    }
        ////}
        ////public static bool Exists(string strSql)
        ////{
        ////    object obj = OleDb.GetSingle(strSql);
        ////    int cmdresult;
        ////    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        ////    {
        ////        cmdresult = 0;
        ////    }
        ////    else
        ////    {
        ////        cmdresult = int.Parse(obj.ToString());
        ////    }
        ////    if (cmdresult == 0)
        ////    {
        ////        return false;
        ////    }
        ////    else
        ////    {
        ////        return true;
        ////    }
        ////}
        /////// <summary>
        /////// 表是否存在
        /////// </summary>
        /////// <param name="TableName"></param>
        /////// <returns></returns>
        ////public static bool TabExists(string TableName)
        ////{
        ////    string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
        ////    //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
        ////    object obj = OleDb.GetSingle(strsql);
        ////    int cmdresult;
        ////    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        ////    {
        ////        cmdresult = 0;
        ////    }
        ////    else
        ////    {
        ////        cmdresult = int.Parse(obj.ToString());
        ////    }
        ////    if (cmdresult == 0)
        ////    {
        ////        return false;
        ////    }
        ////    else
        ////    {
        ////        return true;
        ////    }
        ////}
        ////public static bool Exists(string strSql, params OleDbParameter[] cmdParms)
        ////{
        ////    object obj = OleDb.GetSingle(strSql, cmdParms);
        ////    int cmdresult;
        ////    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        ////    {
        ////        cmdresult = 0;
        ////    }
        ////    else
        ////    {
        ////        cmdresult = int.Parse(obj.ToString());
        ////    }
        ////    if (cmdresult == 0)
        ////    {
        ////        return false;
        ////    }
        ////    else
        ////    {
        ////        return true;
        ////    }
        ////}
        ////#endregion

        ////#region  执行简单SQL语句

        /////// <summary>
        /////// 执行SQL语句，返回影响的记录数
        /////// </summary>
        /////// <param name="SQLString">SQL语句</param>
        /////// <returns>影响的记录数</returns>
        ////public static int ExecuteSql(string SQLString)
        ////{
        ////        using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
        ////        {
        ////            try
        ////            {
        ////                int rows = cmd.ExecuteNonQuery();
        ////                return rows;
        ////            }
        ////            catch (System.Data.OleDb.OleDbException e)
        ////            {
        ////                throw e;
        ////            }
        ////        }
        ////}

        ////public static int ExecuteSqlByTime(string SQLString, int Times)
        ////{
        ////        using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
        ////        {
        ////            try
        ////            {
        ////                cmd.CommandTimeout = Times;
        ////                int rows = cmd.ExecuteNonQuery();
        ////                return rows;
        ////            }
        ////            catch (System.Data.OleDb.OleDbException e)
        ////            {
        ////                throw e;
        ////            }
        ////        }
        ////}

        /////// <summary>
        /////// 执行Sql和Oracle滴混合事务
        /////// </summary>
        /////// <param name="list">SQL命令行列表</param>
        /////// <param name="oracleCmdSqlList">Oracle命令行列表</param>
        /////// <returns>执行结果 0-由于SQL造成事务失败 -1 由于Oracle造成事务失败 1-整体事务执行成功</returns>
        //////public static int ExecuteSqlTran(List<CommandInfo> list, List<CommandInfo> oracleCmdSqlList)
        //////{
        //////    using (OleDbConnection conn = new OleDbConnection(connectionString))
        //////    {
        //////        conn.Open();
        //////        OleDbCommand cmd = new OleDbCommand();
        //////        cmd.Connection = conn;
        //////        OleDbTransaction tx = conn.BeginTransaction();
        //////        cmd.Transaction = tx;
        //////        try
        //////        {
        //////            foreach (CommandInfo myDE in list)
        //////            {
        //////                string cmdText = myDE.CommandText;
        //////                OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Parameters;
        //////                PrepareCommand(cmd, conn, tx, cmdText, cmdParms);
        //////                if (myDE.EffentNextType == EffentNextType.SolicitationEvent)
        //////                {
        //////                    if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
        //////                    {
        //////                        tx.Rollback();
        //////                        throw new Exception("违背要求" + myDE.CommandText + "必须符合select count(..的格式");
        //////                        //return 0;
        //////                    }

        //////                    object obj = cmd.ExecuteScalar();
        //////                    bool isHave = false;
        //////                    if (obj == null && obj == DBNull.Value)
        //////                    {
        //////                        isHave = false;
        //////                    }
        //////                    isHave = Convert.ToInt32(obj) > 0;
        //////                    if (isHave)
        //////                    {
        //////                        //引发事件
        //////                        myDE.OnSolicitationEvent();
        //////                    }
        //////                }
        //////                if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
        //////                {
        //////                    if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
        //////                    {
        //////                        tx.Rollback();
        //////                        throw new Exception("SQL:违背要求" + myDE.CommandText + "必须符合select count(..的格式");
        //////                        //return 0;
        //////                    }

        //////                    object obj = cmd.ExecuteScalar();
        //////                    bool isHave = false;
        //////                    if (obj == null && obj == DBNull.Value)
        //////                    {
        //////                        isHave = false;
        //////                    }
        //////                    isHave = Convert.ToInt32(obj) > 0;

        //////                    if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
        //////                    {
        //////                        tx.Rollback();
        //////                        throw new Exception("SQL:违背要求" + myDE.CommandText + "返回值必须大于0");
        //////                        //return 0;
        //////                    }
        //////                    if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
        //////                    {
        //////                        tx.Rollback();
        //////                        throw new Exception("SQL:违背要求" + myDE.CommandText + "返回值必须等于0");
        //////                        //return 0;
        //////                    }
        //////                    continue;
        //////                }
        //////                int val = cmd.ExecuteNonQuery();
        //////                if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
        //////                {
        //////                    tx.Rollback();
        //////                    throw new Exception("SQL:违背要求" + myDE.CommandText + "必须有影响行");
        //////                    //return 0;
        //////                }
        //////                cmd.Parameters.Clear();
        //////            }
        //////            string oraConnectionString = PubConstant.GetConnectionString("ConnectionStringPPC");
        //////            bool res = OracleHelper.ExecuteSqlTran(oraConnectionString, oracleCmdSqlList);
        //////            if (!res)
        //////            {
        //////                tx.Rollback();
        //////                throw new Exception("Oracle执行失败");
        //////                // return -1;
        //////            }
        //////            tx.Commit();
        //////            return 1;
        //////        }
        //////        catch (System.Data.OleDb.OleDbException e)
        //////        {
        //////            tx.Rollback();
        //////            throw e;
        //////        }
        //////        catch (Exception e)
        //////        {
        //////            tx.Rollback();
        //////            throw e;
        //////        }
        //////    }
        //////}
        /////// <summary>
        /////// 执行多条SQL语句，实现数据库事务。
        /////// </summary>
        /////// <param name="SQLStringList">多条SQL语句</param>		
        ////public static int ExecuteSqlTran(List<String> SQLStringList)
        ////{
        ////    using (OleDbConnection conn = new OleDbConnection(connectionString))
        ////    {
        ////        conn.Open();
        ////        OleDbCommand cmd = new OleDbCommand();
        ////        cmd.Connection = conn;
        ////        OleDbTransaction tx = conn.BeginTransaction();
        ////        cmd.Transaction = tx;
        ////        try
        ////        {
        ////            int count = 0;
        ////            for (int n = 0; n < SQLStringList.Count; n++)
        ////            {
        ////                string strsql = SQLStringList[n];
        ////                if (strsql.Trim().Length > 1)
        ////                {
        ////                    cmd.CommandText = strsql;
        ////                    count += cmd.ExecuteNonQuery();
        ////                }
        ////            }
        ////            tx.Commit();
        ////            return count;
        ////        }
        ////        catch
        ////        {
        ////            tx.Rollback();
        ////            return 0;
        ////        }
        ////    }
        ////}
        /////// <summary>
        /////// 执行带一个存储过程参数的的SQL语句。
        /////// </summary>
        /////// <param name="SQLString">SQL语句</param>
        /////// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /////// <returns>影响的记录数</returns>
        ////public static int ExecuteSql(string SQLString, string content)
        ////{
        ////        OleDbCommand cmd = new OleDbCommand(SQLString, connection);
        ////        System.Data.OleDb.OleDbParameter myParameter = new System.Data.OleDb.OleDbParameter("@content", OleDbType.Variant);
        ////        myParameter.Value = content;
        ////        cmd.Parameters.Add(myParameter);
        ////        try
        ////        {
        ////            int rows = cmd.ExecuteNonQuery();
        ////            return rows;
        ////        }
        ////        catch (System.Data.OleDb.OleDbException e)
        ////        {
        ////            throw e;
        ////        }
        ////}
        /////// <summary>
        /////// 执行带一个存储过程参数的的SQL语句。
        /////// </summary>
        /////// <param name="SQLString">SQL语句</param>
        /////// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /////// <returns>影响的记录数</returns>
        ////public static object ExecuteSqlGet(string SQLString, string content)
        ////{
        ////        OleDbCommand cmd = new OleDbCommand(SQLString, connection);
        ////        System.Data.OleDb.OleDbParameter myParameter = new System.Data.OleDb.OleDbParameter("@content", OleDbType.Variant);
        ////        myParameter.Value = content;
        ////        cmd.Parameters.Add(myParameter);
        ////        try
        ////        {
        ////            object obj = cmd.ExecuteScalar();
        ////            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        ////            {
        ////                return null;
        ////            }
        ////            else
        ////            {
        ////                return obj;
        ////            }
        ////        }
        ////        catch (System.Data.OleDb.OleDbException e)
        ////        {
        ////            throw e;
        ////        }
        ////}
        /////// <summary>
        /////// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /////// </summary>
        /////// <param name="strSQL">SQL语句</param>
        /////// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /////// <returns>影响的记录数</returns>
        ////public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        ////{
        ////        OleDbCommand cmd = new OleDbCommand(strSQL, connection);
        ////        System.Data.OleDb.OleDbParameter myParameter = new System.Data.OleDb.OleDbParameter("@fs", OleDbType.Variant);
        ////        myParameter.Value = fs;
        ////        cmd.Parameters.Add(myParameter);
        ////        try
        ////        {
        ////            int rows = cmd.ExecuteNonQuery();
        ////            return rows;
        ////        }
        ////        catch (System.Data.OleDb.OleDbException e)
        ////        {
        ////            throw e;
        ////        }
        ////}

        /////// <summary>
        /////// 执行一条计算查询结果语句，返回查询结果（object）。
        /////// </summary>
        /////// <param name="SQLString">计算查询结果语句</param>
        /////// <returns>查询结果（object）</returns>
        ////public static object GetSingle(string SQLString)
        ////{
        ////        using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
        ////        {
        ////            try
        ////            {
        ////                object obj = cmd.ExecuteScalar();
        ////                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        ////                {
        ////                    return null;
        ////                }
        ////                else
        ////                {
        ////                    return obj;
        ////                }
        ////            }
        ////            catch (System.Data.OleDb.OleDbException e)
        ////            {
        ////                throw e;
        ////            }
        ////    }
        ////}
        ////public static object GetSingle(string SQLString, int Times)
        ////{
        ////        using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
        ////        {
        ////            try
        ////            {
        ////                cmd.CommandTimeout = Times;
        ////                object obj = cmd.ExecuteScalar();
        ////                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        ////                {
        ////                    return null;
        ////                }
        ////                else
        ////                {
        ////                    return obj;
        ////                }
        ////            }
        ////            catch (System.Data.OleDb.OleDbException e)
        ////            {
        ////                throw e;
        ////            }
        ////    }
        ////}
        /////// <summary>
        /////// 执行查询语句，返回OleDbDataReader ( 注意：调用该方法后，一定要对OleDbDataReader进行Close )
        /////// </summary>
        /////// <param name="strSQL">查询语句</param>
        /////// <returns>OleDbDataReader</returns>
        ////public static OleDbDataReader ExecuteReader(string strSQL)
        ////{
        ////    OleDbConnection connection = new OleDbConnection(connectionString);
        ////    OleDbCommand cmd = new OleDbCommand(strSQL, connection);
        ////    try
        ////    {
        ////        connection.Open();
        ////        OleDbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        ////        return myReader;
        ////    }
        ////    catch (System.Data.OleDb.OleDbException e)
        ////    {
        ////        throw e;
        ////    }

        ////}
        ////public static int ExecuteScalar(string strSQL)
        ////{
        ////    OleDbCommand cmd = new OleDbCommand(strSQL, connection);
        ////    try
        ////    {
        ////        connection.Open();
        ////        int val = Convert.ToInt32(cmd.ExecuteScalar());
        ////        return val;
        ////    }
        ////    catch (System.Data.OleDb.OleDbException e)
        ////    {
        ////        throw e;
        ////    }
        ////}
        /////// <summary>
        /////// 执行查询语句，返回DataSet
        /////// </summary>
        /////// <param name="SQLString">查询语句</param>
        /////// <returns>DataSet</returns>
        ////public static DataSet Query(string SQLString)
        ////{
        ////        DataSet ds = new DataSet();
        ////        try
        ////        {
        ////            OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
        ////            command.Fill(ds, "ds");
        ////        }
        ////        catch (System.Data.OleDb.OleDbException ex)
        ////        {
        ////            throw new Exception(ex.Message);
        ////        }
        ////        return ds;
        ////}
        ////public static DataSet Query(string SQLString, int Times)
        ////{
        ////        DataSet ds = new DataSet();
        ////        try
        ////        {
        ////            OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
        ////            command.SelectCommand.CommandTimeout = Times;
        ////            command.Fill(ds, "ds");
        ////        }
        ////        catch (System.Data.OleDb.OleDbException ex)
        ////        {
        ////            throw new Exception(ex.Message);
        ////        }
        ////        return ds;
        ////}



        ////#endregion

        ////#region 执行带参数的SQL语句

        /////// <summary>
        /////// 执行SQL语句，返回影响的记录数
        /////// </summary>
        /////// <param name="SQLString">SQL语句</param>
        /////// <returns>影响的记录数</returns>
        ////public static int ExecuteSql(string SQLString, params OleDbParameter[] cmdParms)
        ////{
        ////        using (OleDbCommand cmd = new OleDbCommand())
        ////        {
        ////            try
        ////            {
        ////                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        ////                int rows = cmd.ExecuteNonQuery();
        ////                cmd.Parameters.Clear();
        ////                return rows;
        ////            }
        ////            catch (System.Data.OleDb.OleDbException e)
        ////            {
        ////                throw e;
        ////            }
        ////    }
        ////}


        /////// <summary>
        /////// 执行多条SQL语句，实现数据库事务。
        /////// </summary>
        /////// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>
        ////public static void ExecuteSqlTran(Hashtable SQLStringList)
        ////{
        ////    using (OleDbConnection conn = new OleDbConnection(connectionString))
        ////    {
        ////        conn.Open();
        ////        using (OleDbTransaction trans = conn.BeginTransaction())
        ////        {
        ////            OleDbCommand cmd = new OleDbCommand();
        ////            try
        ////            {
        ////                //循环
        ////                foreach (DictionaryEntry myDE in SQLStringList)
        ////                {
        ////                    string cmdText = myDE.Key.ToString();
        ////                    OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
        ////                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        ////                    int val = cmd.ExecuteNonQuery();
        ////                    cmd.Parameters.Clear();
        ////                }
        ////                trans.Commit();
        ////            }
        ////            catch
        ////            {
        ////                trans.Rollback();
        ////                throw;
        ////            }
        ////        }
        ////    }
        ////}
        /////// <summary>
        /////// 执行多条SQL语句，实现数据库事务。
        /////// </summary>
        /////// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>
        //////public static int ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> cmdList)
        //////{
        //////    using (OleDbConnection conn = new OleDbConnection(connectionString))
        //////    {
        //////        conn.Open();
        //////        using (OleDbTransaction trans = conn.BeginTransaction())
        //////        {
        //////            OleDbCommand cmd = new OleDbCommand();
        //////            try
        //////            {
        //////                int count = 0;
        //////                //循环
        //////                foreach (CommandInfo myDE in cmdList)
        //////                {
        //////                    string cmdText = myDE.CommandText;
        //////                    OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Parameters;
        //////                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);

        //////                    if (myDE.EffentNextType == EffentNextType.WhenHaveContine || myDE.EffentNextType == EffentNextType.WhenNoHaveContine)
        //////                    {
        //////                        if (myDE.CommandText.ToLower().IndexOf("count(") == -1)
        //////                        {
        //////                            trans.Rollback();
        //////                            return 0;
        //////                        }

        //////                        object obj = cmd.ExecuteScalar();
        //////                        bool isHave = false;
        //////                        if (obj == null && obj == DBNull.Value)
        //////                        {
        //////                            isHave = false;
        //////                        }
        //////                        isHave = Convert.ToInt32(obj) > 0;

        //////                        if (myDE.EffentNextType == EffentNextType.WhenHaveContine && !isHave)
        //////                        {
        //////                            trans.Rollback();
        //////                            return 0;
        //////                        }
        //////                        if (myDE.EffentNextType == EffentNextType.WhenNoHaveContine && isHave)
        //////                        {
        //////                            trans.Rollback();
        //////                            return 0;
        //////                        }
        //////                        continue;
        //////                    }
        //////                    int val = cmd.ExecuteNonQuery();
        //////                    count += val;
        //////                    if (myDE.EffentNextType == EffentNextType.ExcuteEffectRows && val == 0)
        //////                    {
        //////                        trans.Rollback();
        //////                        return 0;
        //////                    }
        //////                    cmd.Parameters.Clear();
        //////                }
        //////                trans.Commit();
        //////                return count;
        //////            }
        //////            catch
        //////            {
        //////                trans.Rollback();
        //////                throw;
        //////            }
        //////        }
        //////    }
        //////}
        ///////// <summary>
        ///////// 执行多条SQL语句，实现数据库事务。
        ///////// </summary>
        ///////// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>
        //////public static void ExecuteSqlTranWithIndentity(System.Collections.Generic.List<CommandInfo> SQLStringList)
        //////{
        //////    using (OleDbConnection conn = new OleDbConnection(connectionString))
        //////    {
        //////        conn.Open();
        //////        using (OleDbTransaction trans = conn.BeginTransaction())
        //////        {
        //////            OleDbCommand cmd = new OleDbCommand();
        //////            try
        //////            {
        //////                int indentity = 0;
        //////                //循环
        //////                foreach (CommandInfo myDE in SQLStringList)
        //////                {
        //////                    string cmdText = myDE.CommandText;
        //////                    OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Parameters;
        //////                    foreach (OleDbParameter q in cmdParms)
        //////                    {
        //////                        if (q.Direction == ParameterDirection.InputOutput)
        //////                        {
        //////                            q.Value = indentity;
        //////                        }
        //////                    }
        //////                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //////                    int val = cmd.ExecuteNonQuery();
        //////                    foreach (OleDbParameter q in cmdParms)
        //////                    {
        //////                        if (q.Direction == ParameterDirection.Output)
        //////                        {
        //////                            indentity = Convert.ToInt32(q.Value);
        //////                        }
        //////                    }
        //////                    cmd.Parameters.Clear();
        //////                }
        //////                trans.Commit();
        //////            }
        //////            catch
        //////            {
        //////                trans.Rollback();
        //////                throw;
        //////            }
        //////        }
        //////    }
        //////}
        /////// <summary>
        /////// 执行多条SQL语句，实现数据库事务。
        /////// </summary>
        /////// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>
        ////public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        ////{
        ////    using (OleDbConnection conn = new OleDbConnection(connectionString))
        ////    {
        ////        conn.Open();
        ////        using (OleDbTransaction trans = conn.BeginTransaction())
        ////        {
        ////            OleDbCommand cmd = new OleDbCommand();
        ////            try
        ////            {
        ////                int indentity = 0;
        ////                //循环
        ////                foreach (DictionaryEntry myDE in SQLStringList)
        ////                {
        ////                    string cmdText = myDE.Key.ToString();
        ////                    OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
        ////                    foreach (OleDbParameter q in cmdParms)
        ////                    {
        ////                        if (q.Direction == ParameterDirection.InputOutput)
        ////                        {
        ////                            q.Value = indentity;
        ////                        }
        ////                    }
        ////                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        ////                    int val = cmd.ExecuteNonQuery();
        ////                    foreach (OleDbParameter q in cmdParms)
        ////                    {
        ////                        if (q.Direction == ParameterDirection.Output)
        ////                        {
        ////                            indentity = Convert.ToInt32(q.Value);
        ////                        }
        ////                    }
        ////                    cmd.Parameters.Clear();
        ////                }
        ////                trans.Commit();
        ////            }
        ////            catch
        ////            {
        ////                trans.Rollback();
        ////                throw;
        ////            }
        ////        }
        ////    }
        ////}
        /////// <summary>
        /////// 执行一条计算查询结果语句，返回查询结果（object）。
        /////// </summary>
        /////// <param name="SQLString">计算查询结果语句</param>
        /////// <returns>查询结果（object）</returns>
        ////public static object GetSingle(string SQLString, params OleDbParameter[] cmdParms)
        ////{
        ////    using (OleDbConnection connection = new OleDbConnection(connectionString))
        ////    {
        ////        using (OleDbCommand cmd = new OleDbCommand())
        ////        {
        ////            try
        ////            {
        ////                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        ////                object obj = cmd.ExecuteScalar();
        ////                cmd.Parameters.Clear();
        ////                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        ////                {
        ////                    return null;
        ////                }
        ////                else
        ////                {
        ////                    return obj;
        ////                }
        ////            }
        ////            catch (System.Data.OleDb.OleDbException e)
        ////            {
        ////                throw e;
        ////            }
        ////        }
        ////    }
        ////}

        /////// <summary>
        /////// 执行查询语句，返回OleDbDataReader ( 注意：调用该方法后，一定要对OleDbDataReader进行Close )
        /////// </summary>
        /////// <param name="strSQL">查询语句</param>
        /////// <returns>OleDbDataReader</returns>
        ////public static OleDbDataReader ExecuteReader(string SQLString, params OleDbParameter[] cmdParms)
        ////{
        ////    OleDbConnection connection = new OleDbConnection(connectionString);
        ////    OleDbCommand cmd = new OleDbCommand();
        ////    try
        ////    {
        ////        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        ////        OleDbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        ////        cmd.Parameters.Clear();
        ////        return myReader;
        ////    }
        ////    catch (System.Data.OleDb.OleDbException e)
        ////    {
        ////        throw e;
        ////    }
        ////    //			finally
        ////    //			{
        ////    //				cmd.Dispose();
        ////    //				connection.Close();
        ////    //			}	

        ////}

        /////// <summary>
        /////// 执行查询语句，返回DataSet
        /////// </summary>
        /////// <param name="SQLString">查询语句</param>
        /////// <returns>DataSet</returns>
        ////public static DataSet Query(string SQLString, params OleDbParameter[] cmdParms)
        ////{
        ////        OleDbCommand cmd = new OleDbCommand();
        ////        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
        ////        using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
        ////        {
        ////            DataSet ds = new DataSet();
        ////            try
        ////            {
        ////                da.Fill(ds, "ds");
        ////                cmd.Parameters.Clear();
        ////            }
        ////            catch (System.Data.OleDb.OleDbException ex)
        ////            {
        ////                throw new Exception(ex.Message);
        ////            }
        ////            return ds;
        ////        }
        ////}


        ////private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        ////{
        ////    //if (conn.State != ConnectionState.Open)
        ////    //    conn.Open();
        ////    cmd.Connection = conn;
        ////    cmd.CommandText = cmdText;
        ////    if (trans != null)
        ////        cmd.Transaction = trans;
        ////    cmd.CommandType = CommandType.Text;//cmdType;
        ////    if (cmdParms != null)
        ////    {


        ////        foreach (OleDbParameter parameter in cmdParms)
        ////        {
        ////            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        ////                (parameter.Value == null))
        ////            {
        ////                parameter.Value = DBNull.Value;
        ////            }
        ////            cmd.Parameters.Add(parameter);
        ////        }
        ////    }
        ////}

        ////#endregion

        ////#region 存储过程操作

        /////// <summary>
        /////// 执行存储过程，返回OleDbDataReader ( 注意：调用该方法后，一定要对OleDbDataReader进行Close )
        /////// </summary>
        /////// <param name="storedProcName">存储过程名</param>
        /////// <param name="parameters">存储过程参数</param>
        /////// <returns>OleDbDataReader</returns>
        ////public static OleDbDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        ////{
        ////    OleDbDataReader returnReader;
        ////    OleDbCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        ////    command.CommandType = CommandType.StoredProcedure;
        ////    returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
        ////    return returnReader;

        ////}


        /////// <summary>
        /////// 执行存储过程
        /////// </summary>
        /////// <param name="storedProcName">存储过程名</param>
        /////// <param name="parameters">存储过程参数</param>
        /////// <param name="tableName">DataSet结果中的表名</param>
        /////// <returns>DataSet</returns>
        ////public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        ////{
        ////        DataSet dataSet = new DataSet();
        ////        OleDbDataAdapter sqlDA = new OleDbDataAdapter();
        ////        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        ////        sqlDA.Fill(dataSet, tableName);
        ////        return dataSet;
        ////}
        ////public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        ////{
        ////        DataSet dataSet = new DataSet();
        ////        OleDbDataAdapter sqlDA = new OleDbDataAdapter();
        ////        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        ////        sqlDA.SelectCommand.CommandTimeout = Times;
        ////        sqlDA.Fill(dataSet, tableName);
        ////        return dataSet;
        ////}


        /////// <summary>
        /////// 构建 OleDbCommand 对象(用来返回一个结果集，而不是一个整数值)
        /////// </summary>
        /////// <param name="connection">数据库连接</param>
        /////// <param name="storedProcName">存储过程名</param>
        /////// <param name="parameters">存储过程参数</param>
        /////// <returns>OleDbCommand</returns>
        ////private static OleDbCommand BuildQueryCommand(OleDbConnection connection, string storedProcName, IDataParameter[] parameters)
        ////{
        ////    OleDbCommand command = new OleDbCommand(storedProcName, connection);
        ////    command.CommandType = CommandType.StoredProcedure;
        ////    foreach (OleDbParameter parameter in parameters)
        ////    {
        ////        if (parameter != null)
        ////        {
        ////            // 检查未分配值的输出参数,将其分配以DBNull.Value.
        ////            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        ////                (parameter.Value == null))
        ////            {
        ////                parameter.Value = DBNull.Value;
        ////            }
        ////            command.Parameters.Add(parameter);
        ////        }
        ////    }

        ////    return command;
        ////}

        /////// <summary>
        /////// 执行存储过程，返回影响的行数		
        /////// </summary>
        /////// <param name="storedProcName">存储过程名</param>
        /////// <param name="parameters">存储过程参数</param>
        /////// <param name="rowsAffected">影响的行数</param>
        /////// <returns></returns>
        ////public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        ////{
        ////        int result;
        ////        OleDbCommand command = BuildIntCommand(connection, storedProcName, parameters);
        ////        rowsAffected = command.ExecuteNonQuery();
        ////        result = (int)command.Parameters["ReturnValue"].Value;
        ////        return result;
        ////}

        /////// <summary>
        /////// 创建 OleDbCommand 对象实例(用来返回一个整数值)	
        /////// </summary>
        /////// <param name="storedProcName">存储过程名</param>
        /////// <param name="parameters">存储过程参数</param>
        /////// <returns>OleDbCommand 对象实例</returns>
        ////private static OleDbCommand BuildIntCommand(OleDbConnection connection, string storedProcName, IDataParameter[] parameters)
        ////{
        ////    OleDbCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        ////    command.Parameters.Add(new OleDbParameter("ReturnValue",
        ////        OleDbType.BigInt, 4, ParameterDirection.ReturnValue,
        ////        false, 0, 0, string.Empty, DataRowVersion.Default, null));
        ////    return command;
        ////}
        ////#endregion
        ////#endregion

        ////#region Access事务部分
        //#region 公用方法

        //public static int GetMaxID(DbTrans dbTran, string FieldName, string TableName)
        //{
        //    string strsql = "select max(" + FieldName + ")+1 from " + TableName;
        //    object obj = GetSingle(dbTran, strsql);
        //    if (obj == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return int.Parse(obj.ToString());
        //    }
        //}

        //public static int GetMaxStrID(DbTrans dbTran, string FieldName, string TableName)
        //{
        //    string strsql = "select " + FieldName + " from " + TableName;
        //    DataTable dt = Query(dbTran, strsql).Tables[0];
        //    if (dt.Rows.Count == 0)
        //        return 1;
        //    else
        //    {
        //        int maxID = 0; ;
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (i == 0)
        //            {
        //                maxID = int.Parse(dt.Rows[i][0].ToString());
        //            }
        //            else
        //            {
        //                if (maxID < int.Parse(dt.Rows[i][0].ToString()))
        //                    maxID = int.Parse(dt.Rows[i][0].ToString());
        //            }
        //        }
        //        return maxID + 1;
        //    }
        //}

        //public static bool Exists(DbTrans dbTran, string strSql)
        //{
        //    object obj = GetSingle(dbTran, strSql);
        //    int cmdresult;
        //    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //    {
        //        cmdresult = 0;
        //    }
        //    else
        //    {
        //        cmdresult = int.Parse(obj.ToString());
        //    }
        //    if (cmdresult == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //public static bool Exists(DbTrans dbTran, string strSql, params OleDbParameter[] cmdParms)
        //{
        //    object obj = GetSingle(dbTran, strSql, cmdParms);
        //    int cmdresult;
        //    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //    {
        //        cmdresult = 0;
        //    }
        //    else
        //    {
        //        cmdresult = int.Parse(obj.ToString());
        //    }
        //    if (cmdresult == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //#endregion

        //#region  执行简单SQL语句

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(DbTrans dbTran, string SQLString)
        //{
        //    try
        //    {
        //        dbTran.com.CommandText = SQLString;
        //        int rows = dbTran.com.ExecuteNonQuery();
        //        return rows;
        //    }
        //    catch
        //    { throw; }
        //}

        ///// <summary>
        ///// 执行SQL语句，设置命令的执行等待时间
        ///// </summary>
        ///// <param name="SQLString"></param>
        ///// <param name="Times"></param>
        ///// <returns></returns>
        //public static int ExecuteSqlByTime(DbTrans dbTran, string SQLString, int Times)
        //{
        //    try
        //    {
        //        dbTran.com.CommandText = SQLString;
        //        dbTran.com.CommandTimeout = Times;
        //        int rows = dbTran.com.ExecuteNonQuery();
        //        return rows;
        //    }
        //    catch (OleDbException E)
        //    {
        //        throw new Exception(E.Message);
        //    }
        //}

        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">多条SQL语句</param>		
        //public static void ExecuteSqlTran(DbTrans dbTran, ArrayList SQLStringList)
        //{
        //    try
        //    {
        //        for (int n = 0; n < SQLStringList.Count; n++)
        //        {
        //            string strsql = SQLStringList[n].ToString();
        //            if (strsql.Trim().Length > 1)
        //            {
        //                dbTran.com.CommandText = strsql;
        //                dbTran.com.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (OleDbException E)
        //    {

        //        throw new Exception(E.Message);
        //    }
        //}
        ///// <summary>
        ///// 执行带一个存储过程参数的的SQL语句。
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(DbTrans dbTran, string SQLString, string content)
        //{
        //    dbTran.com.CommandText = SQLString;
        //    OleDbParameter myParameter = new OleDbParameter("@content", OleDbType.WChar);
        //    myParameter.Value = content;
        //    dbTran.com.Parameters.Add(myParameter);
        //    try
        //    {
        //        int rows = dbTran.com.ExecuteNonQuery();
        //        return rows;
        //    }
        //    catch (OleDbException E)
        //    {
        //        throw new Exception(E.Message);
        //    }
        //    //finally
        //    //{
        //    //    cmd.Dispose();
        //    //    connection.Close();
        //    //}
        //}
        ///// <summary>
        ///// 执行带一个存储过程参数的的SQL语句。
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        ///// <returns>影响的记录数</returns>
        //public static object ExecuteSqlGet(DbTrans dbTran, string SQLString, string content)
        //{
        //    dbTran.com.CommandText = SQLString;
        //    OleDbParameter myParameter = new OleDbParameter("@content", OleDbType.WChar);
        //    myParameter.Value = content;
        //    dbTran.com.Parameters.Add(myParameter);
        //    try
        //    {
        //        //con.Open();
        //        object obj = dbTran.com.ExecuteScalar();
        //        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return obj;
        //        }
        //    }
        //    catch (OleDbException E)
        //    {
        //        throw new Exception(E.Message);
        //    }
        //    //finally
        //    //{
        //    //    cmd.Dispose();
        //    //    connection.Close();
        //    //}
        //}
        ///// <summary>
        ///// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        ///// </summary>
        ///// <param name="strSQL">SQL语句</param>
        ///// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSqlInsertImg(DbTrans dbTran, string strSQL, byte[] fs)
        //{
        //    dbTran.com.CommandText = strSQL;
        //    OleDbParameter myParameter = new OleDbParameter("@fs", OleDbType.Variant);
        //    myParameter.Value = fs;
        //    dbTran.com.Parameters.Add(myParameter);
        //    try
        //    {
        //        //con.Open();
        //        int rows = dbTran.com.ExecuteNonQuery();
        //        return rows;
        //    }
        //    catch (OleDbException E)
        //    {
        //        throw new Exception(E.Message);
        //    }
        //    //finally
        //    //{
        //    //    com.Dispose();
        //    //    con.Close();
        //    //}
        //}

        ///// <summary>
        ///// 执行一条计算查询结果语句，返回查询结果（object）。
        ///// </summary>
        ///// <param name="SQLString">计算查询结果语句</param>
        ///// <returns>查询结果（object）</returns>
        //public static object GetSingle(DbTrans dbTran, string SQLString)
        //{
        //    try
        //    {
        //        dbTran.com.CommandText = SQLString;
        //        object obj = dbTran.com.ExecuteScalar();
        //        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return obj;
        //        }
        //    }
        //    catch (OleDbException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}


        ///// <summary>
        ///// 执行查询语句，返回OleDbDataReader(使用该方法切记要手工关闭OleDbDataReader和连接)
        ///// </summary>
        ///// <param name="strSQL">查询语句</param>
        ///// <returns>OleDbDataReader</returns>
        //public static OleDbDataReader ExecuteReader(DbTrans dbTran, string strSQL)
        //{
        //    dbTran.com.CommandText = strSQL;
        //    try
        //    {
        //        return dbTran.com.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (OleDbException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    //finally //不能在此关闭，否则，返回的对象将无法使用
        //    //{
        //    //	cmd.Dispose();
        //    //	connection.Close();
        //    //}	
        //}
        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(DbTrans dbTran, string SQLString)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        OleDbDataAdapter command = new OleDbDataAdapter(dbTran.com);
        //        command.SelectCommand.CommandText = SQLString;
        //        command.Fill(ds, "ds");
        //    }
        //    catch (OleDbException ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return ds;
        //}
        ///// <summary>
        ///// 执行查询语句，返回DataSet,设置命令的执行等待时间
        ///// </summary>
        ///// <param name="SQLString"></param>
        ///// <param name="Times"></param>
        ///// <returns></returns>
        //public static DataSet Query(DbTrans dbTran, string SQLString, int Times)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        OleDbDataAdapter command = new OleDbDataAdapter(dbTran.com);
        //        dbTran.com.CommandText = SQLString;
        //        command.SelectCommand.CommandTimeout = Times;
        //        command.Fill(ds, "ds");
        //    }
        //    catch (OleDbException ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return ds;
        //}



        //#endregion

        //#region 执行带参数的SQL语句

        ///// <summary>
        ///// 执行SQL语句，返回影响的记录数
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //public static int ExecuteSql(DbTrans dbTran, string SQLString, params OleDbParameter[] cmdParms)
        //{
        //    try
        //    {
        //        PrepareCommand(dbTran.com, dbTran.con, null, SQLString, cmdParms);
        //        int rows = dbTran.com.ExecuteNonQuery();
        //        dbTran.com.Parameters.Clear();
        //        return rows;
        //    }
        //    catch (OleDbException E)
        //    {
        //        throw new Exception(E.Message);
        //    }
        //}


        ///// <summary>
        ///// 执行多条SQL语句，实现数据库事务。
        ///// </summary>
        ///// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>
        //public static void ExecuteSqlTran(DbTrans dbTran, Hashtable SQLStringList)
        //{
        //    try
        //    {
        //        //循环
        //        foreach (DictionaryEntry myDE in SQLStringList)
        //        {
        //            string cmdText = myDE.Key.ToString();
        //            dbTran.com.CommandText = cmdText;
        //            OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
        //            PrepareCommand(dbTran.com, dbTran.con, dbTran.trans, cmdText, cmdParms);
        //            //int val = dbTran.com.ExecuteNonQuery();
        //            dbTran.com.Parameters.Clear();

        //            //trans.Commit();
        //        }
        //    }
        //    catch
        //    {
        //        //trans.Rollback();
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// 执行一条计算查询结果语句，返回查询结果（object）。
        ///// </summary>
        ///// <param name="SQLString">计算查询结果语句</param>
        ///// <returns>查询结果（object）</returns>
        //public static object GetSingle(DbTrans dbTran, string SQLString, params OleDbParameter[] cmdParms)
        //{
        //    try
        //    {
        //        PrepareCommand(dbTran.com, dbTran.con, null, SQLString, cmdParms);
        //        object obj = dbTran.com.ExecuteScalar();
        //        dbTran.com.Parameters.Clear();
        //        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return obj;
        //        }
        //    }
        //    catch (OleDbException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        ///// <summary>
        ///// 执行查询语句，返回OleDbDataReader (使用该方法切记要手工关闭OleDbDataReader和连接)
        ///// </summary>
        ///// <param name="strSQL">查询语句</param>
        ///// <returns>OleDbDataReader</returns>
        //public static OleDbDataReader ExecuteReader(DbTrans dbTran, string SQLString, params OleDbParameter[] cmdParms)
        //{
        //    //OleDbConnection connection = new OleDbConnection(connectionString);
        //    //OleDbCommand cmd = new OleDbCommand();
        //    try
        //    {
        //        PrepareCommand(dbTran.com, dbTran.con, null, SQLString, cmdParms);
        //        OleDbDataReader myReader = dbTran.com.ExecuteReader();
        //        dbTran.com.Parameters.Clear();
        //        return myReader;
        //    }
        //    catch (OleDbException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    //finally //不能在此关闭，否则，返回的对象将无法使用
        //    //{
        //    //	cmd.Dispose();
        //    //	connection.Close();
        //    //}	

        //}

        ///// <summary>
        ///// 执行查询语句，返回DataSet
        ///// </summary>
        ///// <param name="SQLString">查询语句</param>
        ///// <returns>DataSet</returns>
        //public static DataSet Query(DbTrans dbTran, string SQLString, params OleDbParameter[] cmdParms)
        //{
        //    PrepareCommand(dbTran.com, dbTran.con, null, SQLString, cmdParms);
        //    using (OleDbDataAdapter da = new OleDbDataAdapter(dbTran.com))
        //    {
        //        DataSet ds = new DataSet();
        //        try
        //        {
        //            da.Fill(ds, "ds");
        //            dbTran.com.Parameters.Clear();
        //        }
        //        catch (OleDbException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return ds;
        //    }
        //}

        //#endregion

        //#region 存储过程操作

        ///// <summary>
        ///// 执行存储过程  (使用该方法切记要手工关闭OleDbDataReader和连接)
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>OleDbDataReader</returns>
        //public static int RunProcedure(DbTrans dbTran, string storedProcName, IDataParameter[] parameters)
        //{
        //    int result;
        //    OleDbCommand command = BuildQueryCommand(dbTran, storedProcName, parameters);
        //    command.CommandType = CommandType.StoredProcedure;
        //    result = command.ExecuteNonQuery();
        //    //Connection.Close(); 不能在此关闭，否则，返回的对象将无法使用            
        //    command.CommandType = CommandType.Text;
        //    command.Parameters.Clear();
        //    return result;

        //}
        //private static OleDbCommand BuildQueryCommand(DbTrans dbTran, string storedProcName, IDataParameter[] parameters)
        //{
        //    OleDbCommand command = dbTran.com;
        //    command.CommandText = storedProcName;
        //    dbTran.com.CommandType = CommandType.StoredProcedure;
        //    foreach (OleDbParameter parameter in parameters)
        //    {
        //        if (parameter != null)
        //        {
        //            // 检查未分配值的输出参数,将其分配以DBNull.Value.
        //            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                (parameter.Value == null))
        //            {
        //                parameter.Value = DBNull.Value;
        //            }
        //            command.Parameters.Add(parameter);
        //        }
        //    }

        //    return command;
        //}

        ///// <summary>
        ///// 执行存储过程
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="tableName">DataSet结果中的表名</param>
        ///// <returns>DataSet</returns>
        //public static DataSet RunProcedure(DbTrans dbTran, string storedProcName, IDataParameter[] parameters, string tableName)
        //{
        //    DataSet dataSet = new DataSet();
        //    OleDbDataAdapter sqlDA = new OleDbDataAdapter(dbTran.com);
        //    sqlDA.SelectCommand = BuildQueryCommand(dbTran.con, storedProcName, parameters);
        //    sqlDA.Fill(dataSet, tableName);
        //    return dataSet;
        //}
        //public static DataSet RunProcedure(DbTrans dbTran, string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        //{
        //    DataSet dataSet = new DataSet();
        //    OleDbDataAdapter sqlDA = new OleDbDataAdapter(dbTran.com);
        //    sqlDA.SelectCommand = BuildQueryCommand(dbTran.con, storedProcName, parameters);
        //    sqlDA.SelectCommand.CommandTimeout = Times;
        //    sqlDA.Fill(dataSet, tableName);
        //    return dataSet;
        //}



        ///// <summary>
        ///// 执行存储过程，返回影响的行数		
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="rowsAffected">影响的行数</param>
        ///// <returns></returns>
        //public static int RunProcedure(DbTrans dbTran, string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        //{
        //    int result;
        //    OleDbCommand command = BuildIntCommand(dbTran.con, storedProcName, parameters);
        //    rowsAffected = command.ExecuteNonQuery();
        //    result = (int)command.Parameters["ReturnValue"].Value;
        //    //Connection.Close();
        //    return result;
        //}
        //#endregion
        //public static int GetMaxID(DbTrans dbTrans, string FieldName, string TableName, string strwhere)
        //{
        //    string strsql = "select max(" + FieldName + ")+1 from " + TableName + " where " + strwhere;
        //    object obj = GetSingle(dbTrans,strsql);
        //    if (obj == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return int.Parse(obj.ToString());
        //    }
        //}
        //#endregion
    }

}

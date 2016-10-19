using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.Data.OleDb;
namespace Model
{
    /// <summary>
    /// ���ݷ��ʳ��������
    /// Copyright (C) 2004-2008 LiTianPing
    /// All rights reserved
    /// </summary>
    public class DbTrans
    {
        //���ݿ������ַ���(web.config������)
        //public string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public string connectionString = GetRegKeyValue("DataServer");
      //  public string connectionString = "server=127.0.0.1;database=Rack;uid=sa;pwd=";
        public OleDbConnection con = null;
        public OleDbCommand com = null;
        public OleDbTransaction trans = null;
        public DbTrans()
        {
            con = new OleDbConnection(connectionString);
        }
        public DbTrans(string StrSqlCon)
        {
            con = new OleDbConnection(StrSqlCon);
        }
        public void begainTrans()
        {
            con.Open();
            com = new OleDbCommand();
            com.Connection = con;
            trans = con.BeginTransaction();
            com.Transaction = trans;
        }
        public void commited()
        {
            try
            {
                trans.Commit();
                con.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public void rollBack()
        {
            if (con != null && trans != null)
            {
                trans.Rollback();
                con.Close();
            }
        }
        public void close()
        {
            if (con != null)
                con.Close();
        }
        /// <summary>
        /// �õ�ע����ֵ
        /// </summary>
        /// <param name="key">��ֵ��</param>
        public static string GetRegKeyValue(string key)
        {

            string keyValue;

            RegistryKey regLocal = Registry.LocalMachine;

            try
            {
                keyValue = regLocal.OpenSubKey("SOFTWARE").OpenSubKey("HengLianKeJi").
                    OpenSubKey("HuoJiaShengChanGuanLi").OpenSubKey("V2").GetValue(key).ToString();
                return keyValue;
            }
            catch
            {
                //ShowErrorMessage("��ȡ���ݿ����ӳ���"+ex.Message);
                return string.Empty;
            }
        }

    }

}

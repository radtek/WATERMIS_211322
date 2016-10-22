using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SysControl;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using Common.DotNetData;
using DBinterface.IDAL;
using DBinterface.DAL;

namespace PersonalWork
{
   public class ApproveDispose
    {
       private static PersonalWork_IDAL sysidal = new PersonalWork_DAL();

       public static bool UpdateFeeItem(Control FP_Fee, string ResolveID)
       {
           StringBuilder sb = new StringBuilder();
           sb.AppendLine(@"SET XACT_ABORT ON
  BEGIN TRAN");

           foreach (Control c in FP_Fee.Controls)
           {
               if (c is UC_ChargeInput)
               {
                   UC_ChargeInput UC = (UC_ChargeInput)c;
                   int feeid = 0;

                   if (int.TryParse(UC.FeeID, out feeid))
                   {
                       sb.AppendLine(string.Format("UPDATE Meter_WorkResolveFee SET Price='{5}',Quantity='{6}', FEE='{0}',AcceptID='{1}',AcceptUser='{2}',AcceptDate='{3}' WHERE ResolveID=@ResolveID AND FeeID='{4}'", UC.Fee, AppDomain.CurrentDomain.GetData("LOGINID"), AppDomain.CurrentDomain.GetData("USERNAME"), DateTime.Now.ToString(), feeid, UC.Price, UC.Quantity));
                   }
               }
           }
           sb.AppendLine(" COMMIT TRAN");

           int count = DbHelperSQL.ExecuteSql(sb.ToString(), new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID) });

           return count > 0 ? true : false;
       }

       public static void BindFeeItemTextBox(Control FP_Fee, string ResolveID)
       {
           //string sqlstr = "SELECT FeeID,FeeItem,Fee,DefaultValue,IsFinal  FROM Meter_WorkResolveFee WHERE ResolveID=@ResolveID ORDER BY Sort";

           //DataTable dt = new SqlServerHelper().GetDateTableBySql(sqlstr, new SqlParameter[] { new SqlParameter("@ResolveID", ResolveID) });

           DataTable dt = sysidal.GetFeeItems(ResolveID);
           if (DataTableHelper.IsExistRows(dt))
           {
               // GB_Fee.Text = dt.Rows[0]["IsFinal"].ToString().ToLower().Equals("true") ? "预算" : "决算";
               FP_Fee.Height = dt.Rows.Count * 33;
               foreach (DataRow dr in dt.Rows)
               {
                   UC_ChargeInput UC = new UC_ChargeInput();
                  
                   UC.FeeID = dr["FeeID"].ToString();
                   UC.FeeItem = dr["FeeItem"].ToString().Trim();
                   UC.Quantity = int.Parse(dr["QUANTITY"].ToString());
                   UC.Price = float.Parse(dr["PRICE"].ToString());
                   UC.Fee = float.Parse(dr["Fee"].ToString());

                   if (float.Parse(dr["PRICE"].ToString()) == 0f)
                   {
                       DataTable dd = sysidal.GetLastFeeItemsByDep(ResolveID, (int)dr["FeeID"]);//FEE,Price,Quantity 
                       if (DataTableHelper.IsExistRows(dd))
                       {
                           UC.Quantity = int.Parse(dd.Rows[0]["QUANTITY"].ToString());
                           UC.Price = float.Parse(dd.Rows[0]["PRICE"].ToString());
                           UC.Fee = float.Parse(dd.Rows[0]["FEE"].ToString()); ;
                       }
                   }

                   FP_Fee.Controls.Add(UC);
               }
           }
       }

       public static void BindFeeItemLabel(Control FP_Items, string TaskID,string PointSort)
       {
           DataTable dt = sysidal.GetDataTableLastApproveFee(TaskID, PointSort);
           if (DataTableHelper.IsExistRows(dt))
           {
               FP_Items.Height = ((dt.Rows.Count + 2) / 3) * 33;
               foreach (DataRow dr in dt.Rows)
               {
                   UC_ChargeItem UC = new UC_ChargeItem();
                   UC.FeeItem = string.Format("{0}-{1}:{2}元;", dr["PointName"].ToString().Trim(), dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());

                   FP_Items.Controls.Add(UC);
               }
           }
       }

       public static void BindLastFeeItems(Control FP_Items, string TaskID, string PointSort, out decimal TotalFee, out bool IsFinal,out int LastPointSort,out int state,out string items)
       {
           TotalFee = 0m;
           IsFinal = false;
           LastPointSort = 0;
           state = 0;
           items = "";
           DataTable dt = sysidal.GetLastFeeItems(TaskID, PointSort);
           if (DataTableHelper.IsExistRows(dt))
           {
               IsFinal = !Convert.ToBoolean(dt.Rows[0]["IsFinal"].ToString());
               LastPointSort = int.Parse(dt.Rows[0]["PointSort"].ToString());
               state = int.Parse(dt.Rows[0]["State"].ToString());
               FP_Items.Height = ((dt.Rows.Count + 2) / 3) * 33;
               foreach (DataRow dr in dt.Rows)
               {
                  
                   decimal _fee = 0m;
                   if (decimal.TryParse(dr["Fee"].ToString(), out _fee))
                   {
                       TotalFee += _fee;
                   }
                   
                   UC_ChargeItem UC = new UC_ChargeItem();
                   UC.FeeItem = string.Format("{0}:{1}元;", dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());
                   items += string.Format("{0}:{1};", dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString());
                   FP_Items.Controls.Add(UC);
               }
               items.TrimEnd(';');
           }
       }
           

    }
}

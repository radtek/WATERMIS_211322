using System;
using System.Collections.Generic;
using System.Text;

namespace BASEFUNCTION
{
   public class GetID
    {
           string strSQL;
           object objGetID;
           string strDate;
           string strReturnID = null;
           Messages mes = new Messages();
       /// <summary>
       /// 事故案件编号，格式20120710001
       /// </summary>
       /// <returns></returns>
       public string GetIDByDate(DateTime dtCaseDate)
           {
               try
               {
                   strDate = dtCaseDate.ToString("yyyyMMdd");
                   strSQL = "SELECT MAX(RIGHT(ACCIDENTID,3)) FROM _DEP_ACCIDENT_CASE WHERE LEFT(ACCIDENTID,8)='" + strDate + "'";
                   objGetID = DBUtility.DbHelperSQL.GetSingle(strSQL);
                   if (objGetID == null)
                       strReturnID = "001";
                   else
                   {
                       strReturnID = (int.Parse(objGetID.ToString()) + 1).ToString();
                       strReturnID = strReturnID.PadLeft(3, '0');
                   }
                   strReturnID = strDate + strReturnID;
                   return strReturnID;
               }
               catch (Exception ex)
               {
                   mes.GetErrorMes(ex);
                   return "11111111000";
               }
       }
    }
}

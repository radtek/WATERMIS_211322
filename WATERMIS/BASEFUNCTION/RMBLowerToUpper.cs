using System;
using System.Collections.Generic;
using System.Text;

namespace BASEFUNCTION
{
   public class RMBLowerToUpper
   {
       /// <summary>
       /// 转换人民币大小写。
       /// </summary>
       /// <param name="strMoney"></param>
       /// <returns></returns>
       public string CapsLockMoney(string strMoney)
       {
           string strPayMoney = "";
           if (strMoney.Length <= 10)
           {
               string[] strMoneys = strMoney.Split('.');
               if (strMoneys.Length == 2)
               {
                   strPayMoney = LeftChines(strMoneys[0].ToString()) + RigthChinese(strMoneys[1].ToString());
               }
               else
               {
                   strPayMoney = LeftChines(strMoneys[0].ToString());
               }
           }
           return strPayMoney;
       }
       /// <summary>
       /// 转换小数位。
       /// </summary>
       /// <param name="strLeft"></param>
       /// <returns></returns>
       private string LeftChines(string strLeft)
       {
           string integer = "";
           if (strLeft.Length < 8)
           {
               for (int i = 0; i < strLeft.Length; i++)
               {

                   //7代表整数位限七位这里可以自己定义。
                   integer += ConvertChinese(strLeft.Substring(i, 1)) + ConvertIntegerConstant(i + (7 - strLeft.Length));
               }
           }
           return integer;
       }
       /// <summary>
       /// 转换整数位。
       /// </summary>
       /// <param name="strRight"></param>
       /// <returns></returns>
       private string RigthChinese(string strRight)
       {
           string decimalfraction = "";

           if (strRight.Length < 3)
           {
               for (int i = 0; i < strRight.Length; i++)
               {
                   decimalfraction += ConvertChinese(strRight.Substring(i, 1)) + ConvertDigit(i);
               }
           }
           return decimalfraction;
       }
       /// <summary>
       /// 将一位数字转换成中文大写数字
       /// </summary>
       private string ConvertChinese(string str)
       {
           string cstr = "";
           switch (str)
           {
               case "0": cstr = "零"; break;
               case "1": cstr = "壹"; break;
               case "2": cstr = "贰"; break;
               case "3": cstr = "叁"; break;
               case "4": cstr = "肆"; break;
               case "5": cstr = "伍"; break;
               case "6": cstr = "陆"; break;
               case "7": cstr = "柒"; break;
               case "8": cstr = "捌"; break;
               case "9": cstr = "玖"; break;
           }
           return (cstr);
       }
       /// <summary>
       /// 将位置转换成位数。
       /// </summary>
       private string ConvertDigit(int i)
       {
           string cstr = "";
           switch (i)
           {
               case 0: cstr = "角"; break;
               case 1: cstr = "分"; break;
           }
           return (cstr);
       }
       /// <summary>
       ///
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
       private string ConvertIntegerConstant(int i)
       {
           string cstr = "";
           switch (i)
           {
               case 0: cstr = "佰"; break;
               case 1: cstr = "拾"; break;
               case 2: cstr = "万"; break;
               case 3: cstr = "仟"; break;
               case 4: cstr = "佰"; break;
               case 5: cstr = "拾"; break;
               case 6: cstr = "元"; break;
           }
           return (cstr);
       }
    }
}

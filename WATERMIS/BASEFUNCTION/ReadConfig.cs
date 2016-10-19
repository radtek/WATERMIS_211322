using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace BASEFUNCTION
{
    public class ReadConfig
    {
        private static string strFileName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"WATERMIS.exe.config";

        ///// <summary>  
        ///// 获取配置文件中制定的项值  
        ///// </summary>  
        //public static string ConfigKeyValue
        //{
        //    get
        //    {
        //        string time = GetAttributeValue(currentConfig, "ConfigKeyValue");

        //        if (string.IsNullOrEmpty(time))
        //        {
        //            return "";
        //        }

        //        return time;
        //    }
        //}
        /// <summary>  
        /// 获取配置文件的属性  
        /// </summary>  
        /// <param name="key"></param>  
        /// <returns></returns>  
        public static string GetAttributeValue(string key)
        {
            string value = string.Empty;

            try
            {
                if (File.Exists(strFileName))
                {
                    XmlDocument xml = new XmlDocument();

                    xml.Load(strFileName);

                    XmlNode xNode = xml.SelectSingleNode("//appSettings");

                    XmlElement element = (XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");

                    value = element.GetAttribute("value").ToString();
                }
            }
            catch { }

            return value;
        }
    } 
}

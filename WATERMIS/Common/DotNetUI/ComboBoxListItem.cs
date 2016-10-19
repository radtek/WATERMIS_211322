using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Common.DotNetUI
{
    public class ComboBoxListItem
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ComboBoxListItem(string strKey, string strValue)
        {
            this.Key = strKey;
            this.Value = strValue;
        }
        public override string ToString()
        {
            return this.Key;
        }

        /// <summary>
        /// 根据ListItem中的Value找到特定的ListItem(仅在ComboBox的Item都为ListItem时有效)
        /// </summary>
        /// <param name="cmb">要查找的ComboBox</param>
        /// <param name="strValue">要查找ListItem的Value</param>
        /// <returns>返回传入的ComboBox中符合条件的第一个ListItem，如果没有找到则返回null.</returns>
        public static ComboBoxListItem FindByValue(ComboBox cmb, string strValue)
        {
            foreach (ComboBoxListItem li in cmb.Items)
            {
                if (li.Value == strValue)
                {
                    return li;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据ListItem中的Key找到特定的ListItem(仅在ComboBox的Item都为ListItem时有效)
        /// </summary>
        /// <param name="cmb">要查找的ComboBox</param>
        /// <param name="strValue">要查找ListItem的Key</param>
        /// <returns>返回传入的ComboBox中符合条件的第一个ListItem，如果没有找到则返回null.</returns>
        public static ComboBoxListItem FindByText(ComboBox cmb, string strText)
        {
            foreach (ComboBoxListItem li in cmb.Items)
            {
                if (li.Value == strText)
                {
                    return li;
                }
            }
            return null;
        }
    }
}

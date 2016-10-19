using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

public class CreateForm
{
    /// <summary>  
    /// 打开新的子窗体  
    /// </summary>  
    /// <param name="strName">窗体的类名</param>  
    /// <param name="AssemblyName">窗体所在类库的名称</param>   
    public static void ShowPannel(string strName, string AssemblyName, Control PL, Hashtable ht)
    {
        try
        {
            string path = AssemblyName;//项目的Assembly选项名称  
            string name = AssemblyName + "." + strName; //类的名字  
            Form Frm = (Form)Assembly.Load(path).CreateInstance(name);
            Frm.FormBorderStyle = FormBorderStyle.None;
            Frm.Dock = DockStyle.Fill;
            Frm.TopLevel = false;
            Frm.Tag = ht;
            PL.Controls.Clear();
            PL.Controls.Add(Frm);
            Frm.Show();
        }
        catch (Exception ex)
        {

        }

    }
}

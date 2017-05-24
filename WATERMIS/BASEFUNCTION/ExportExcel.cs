using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;


namespace BASEFUNCTION
{
   public class ExportExcel
   {
       Messages mes = new Messages();
       /// <summary>
        /// 另存新档按钮
       /// </summary>
       /// <param name="dgForm"></param>
        /// <param name="intHeadType">导出的Head名称 0为HeaderText，1为Name</param>
        public void SaveAs(DataGridView dgForm,int intHeadType) //另存新档按钮   导出成Excel
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";

            saveFileDialog.FilterIndex = 0;

            saveFileDialog.RestoreDirectory = true;

            saveFileDialog.CreatePrompt = true;

            saveFileDialog.Title = "Export Excel File To";


            saveFileDialog.ShowDialog();


            Stream myStream;

            myStream = saveFileDialog.OpenFile();

            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));

            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

            string str = "";

            try
            {
                int intFistColumn = 0;

                for (int i = 0; i < dgForm.ColumnCount; i++)
                {
                    if (dgForm.Columns[i].Visible)
                    {
                        intFistColumn = i;
                        break;
                    }
                }


                //写标题

                for (int i = 0; i < dgForm.ColumnCount; i++)
                {
                    if (!dgForm.Columns[i].Visible)
                        continue;
                    if (i > intFistColumn)
                    {

                        str += "\t";

                    }
                    if (intHeadType==0)
                    str += dgForm.Columns[i].HeaderText;
                    else
                        str += dgForm.Columns[i].Name;
                }


                sw.WriteLine(str);



                //写内容

                for (int j = 0; j < dgForm.Rows.Count; j++)
                {

                    string tempStr = "";

                    for (int k = 0; k < dgForm.Columns.Count; k++)
                    {
                    if (!dgForm.Columns[k].Visible)
                        continue;

                    if (k > intFistColumn)
                        {

                            tempStr += "\t";

                        }

                        if (dgForm.Rows[j].Cells[k].Value != DBNull.Value && dgForm.Rows[j].Cells[k].Value != null)
                            tempStr += dgForm.Rows[j].Cells[k].Value.ToString();
                        else
                            tempStr += "";

                    }



                    sw.WriteLine(tempStr);

                }

                sw.Close();

                myStream.Close();

            }

            catch (Exception e)
            {

                MessageBox.Show(e.ToString());

            }

            finally
            {

                sw.Close();

                myStream.Close();

            }

        }

        /// <summary>
        /// DataGridView导出Excel
        /// </summary>
        /// <param name="strCaption">Excel文件中的标题</param>
        /// <param name="myDGV">DataGridView 控件</param>
        /// <returns>0:成功;1:DataGridView中无记录;2:Excel无法启动;9999:异常错误</returns>
        public int ExportToExcel(string strCaption, DataGridView myDGV)
        {
            int result = 9999;

            //保存
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName == "")
                {
                    MessageBox.Show("请输入保存文件名！");
                    saveFileDialog.ShowDialog();
                }
                // 列索引，行索引，总列数，总行数


                int intColumsCount = 0;
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    if (myDGV.Columns[i].Visible)
                    {
                        intColumsCount++;
                    }
                }

                int ColIndex = 0;
                int dgColIndex = 0;
                int RowIndex = 0;
                int ColCount = intColumsCount;
                int RowCount = myDGV.RowCount;

                if (myDGV.RowCount == 0)
                {
                    result = 1;
                }

                // 创建Excel对象
                Excel.Application xlApp = new Excel.ApplicationClass();
                if (xlApp == null)
                {
                    result = 2;
                }
                try
                {
                    // 创建Excel工作薄
                    Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                    Excel.Worksheet xlSheet = (Excel.Worksheet)xlBook.Worksheets[1];
                    // 设置标题
                    Excel.Range range = xlSheet.get_Range(xlApp.Cells[1, 1], xlApp.Cells[1, ColCount]); //标题所占的单元格数与DataGridView中的列数相同
                    range.MergeCells = true;
                    xlApp.ActiveCell.FormulaR1C1 = strCaption;
                    xlApp.ActiveCell.Font.Size = 20;
                    xlApp.ActiveCell.Font.Bold = true;
                    xlApp.ActiveCell.HorizontalAlignment = Excel.Constants.xlCenter;
                    // 创建缓存数据
                    object[,] objData = new object[RowCount + 1, ColCount];
                    //获取列标题
                    foreach (DataGridViewColumn col in myDGV.Columns)
                    {
                        if (col.Visible)
                        objData[RowIndex, ColIndex++] = col.HeaderText;
                    }
                    // 获取数据
                    for (RowIndex = 1; RowIndex <= RowCount; RowIndex++)
                    {
                        dgColIndex = 0;
                        for (ColIndex = 0; ColIndex < ColCount; ColIndex++)
                        {
                            for (; dgColIndex < myDGV.Columns.Count; dgColIndex++)
                            {
                                if (!myDGV.Columns[dgColIndex].Visible)
                                    continue;
                                else
                                {
                                    if (myDGV[dgColIndex, RowIndex - 1].ValueType == typeof(string)
                                        || myDGV[dgColIndex, RowIndex - 1].ValueType == typeof(DateTime))//这里就是验证DataGridView单元格中的类型,如果是string或是DataTime类型,则在放入缓存时在该内容前加入" ";
                                    {
                                        if (myDGV.Rows[RowIndex-1].Cells[dgColIndex] is DataGridViewCheckBoxCell)
                                        {
                                            DataGridViewCheckBoxCell dc = new DataGridViewCheckBoxCell();
                                            bool isChecked = Convert.ToBoolean(dc.Value);
                                            if (isChecked)
                                                objData[RowIndex, ColIndex] = "是";
                                            else
                                                objData[RowIndex, ColIndex] = "否";
                                        }
                                        else
                                            objData[RowIndex, ColIndex] = "'" + myDGV[dgColIndex, RowIndex - 1].FormattedValue;
                                        //objData[RowIndex, ColIndex] = "'" + myDGV[dgColIndex, RowIndex - 1].Value;
                                    }
                                    else
                                    {
                                        //if (myDGV.Rows[RowIndex].Cells[dgColIndex] is DataGridViewCheckBoxCell)
                                        //{
                                        //    DataGridViewCheckBoxCell dc = new DataGridViewCheckBoxCell();
                                        //    bool isChecked=Convert.ToBoolean(dc.Value);
                                        //    if (isChecked)
                                        //    objData[RowIndex, ColIndex] = "是";
                                        //    else
                                        //        objData[RowIndex, ColIndex] = "否";
                                        //}
                                        //else
                                            objData[RowIndex, ColIndex] = myDGV[dgColIndex, RowIndex - 1].Value;
                                    }
                                    dgColIndex++;
                                    break;
                                }
                            }
                        }
                        System.Windows.Forms.Application.DoEvents();
                    }
                    // 写入Excel
                    range = xlSheet.get_Range(xlApp.Cells[2, 1], xlApp.Cells[RowCount+2, ColCount]);
                    range.Value2 = objData;

                    xlBook.Saved = true;
                    xlBook.SaveCopyAs(saveFileDialog.FileName);
                }
                catch (Exception err)
                {
                    result = 9999;
                    
                }
                finally
                {
                    xlApp.Quit();
                    GC.Collect(); //强制回收
                    mes.Show("导出成功!");
                }
                //返回值
                result = 0;
            }

            return result;
        } 
    }
}

using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace SysControl
{
    public partial class UC_DataGridView_Page : UserControl
    {
        public UC_DataGridView_Page()
        {
            InitializeComponent();
        }

        //uC_DataGridView_Page1.Fields = new string[,] { { "rowNum", "序号" }, { "waterMeterId", "用户ID" }, { "waterMeterNo", "用户号" }, { "totalNumber", "总水量" }, { "avePrice", "总水价" }, { "totalCharge", "totalCharge" } };
        //   uC_DataGridView_Page1.FieldStatis = new string[,] { { "waterMeterId", "合计" }, { "totalNumber", "" }, { "avePrice", "" }, { "totalCharge", "" } };
        //   uC_DataGridView_Page1.SqlString = "SELECT * FROM readMeterRecord ";
        //   uC_DataGridView_Page1.PageIndex = 1;
        //   uC_DataGridView_Page1.Init();

        public delegate void CellClickEvent(object sender, DataGridViewCellEventArgs e);
        public delegate void CellDoubleClickEvent(object sender, DataGridViewCellEventArgs e);
        public event CellClickEvent CellClickEvents;
        public event CellDoubleClickEvent CellDoubleClickEvents;

        private DataTable _DataSource;

        //public DataTable DataSource
        //{
        //    get { return _DataSource; }
        //    set { _DataSource = value; }
        //}

        private string _PageOrderField;

        [Browsable(true)]
        [Category("文本")]
        [Description("排序字段")]
        [DefaultValue("")]//默认值  
        public string PageOrderField
        {
            get { return _PageOrderField; }
            set { _PageOrderField = value; }
        }

        private string _PageOrderType = "DESC";
        [Browsable(true)]
        [Category("文本")]
        [Description("排序方式")]
        [DefaultValue("DESC")]//默认值  
        public string PageOrderType
        {
            get { return _PageOrderType; }
            set { _PageOrderType = value; }
        }

        private int _PageIndex = 1;
        [Browsable(true)]
        [Category("文本")]
        [Description("索引页")]
        [DefaultValue("")]//默认值  
        public int PageIndex
        {
            get { return _PageIndex; }
            set { _PageIndex = value; }
        }

        private int _PageSize = 100;
        [Browsable(true)]
        [Category("文本")]
        [Description("分页数量")]
        [DefaultValue("")]//默认值  
        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        private string _SqlString = "";
        [Browsable(true)]
        [Category("文本")]
        [Description("查询语句")]
        [DefaultValue("")]//默认值  
        public string SqlString
        {
            get { return _SqlString; }
            set { _SqlString = value; }
        }

        private string[,] _Fields;
        [Browsable(true)]
        [Category("文本")]
        [Description("显示字段")]
        [DefaultValue("")]//默认值  
        public string[,] Fields
        {
            get { return _Fields; }
            set { _Fields = value; }
        }

        private string[,] _FieldStatis;

        public string[,] FieldStatis
        {
            get { return _FieldStatis; }
            set { _FieldStatis = value; }
        }

        private DataRow _DataStatis;

        public DataRow DataStatis
        {
            get { return _DataStatis; }
            set { _DataStatis = value; }
        }

        private int _RowCount = 0;

        public int RowCount
        {
            get { return _RowCount; }
        }

        private string _FiledColor;
        [Browsable(true)]
        [Category("文本")]
        [Description("变色索引")]
        [DefaultValue("")]//默认值  
        public string FiledColor
        {
            get { return _FiledColor; }
            set { _FiledColor = value; }
        }

        //private string[,] _ColorValue;

        //public string[,] ColorValue
        //{
        //    get { return _ColorValue; }
        //    set { _ColorValue = value; }
        //}

        public void Init()
        {
            if (string.IsNullOrEmpty(_PageOrderField))
            {
                return;
            }
            if (Fields == null)
            {
                return;
            }
            DG.DataSource = null;
            RefreshData();
            if (_DataSource!=null)
            {
                foreach (DataColumn dc in _DataSource.Columns)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = dc.ColumnName;
                    col.DataPropertyName = dc.ColumnName;
                    col.HeaderText = dc.ColumnName;
                    bool isShow = false;
                    for (int i = 0; i < Fields.GetLength(0); i++)
                    {
                        if (dc.ColumnName.ToUpper().Equals(Fields[i, 0].ToUpper()))
                        {
                            isShow = true;
                            col.DataPropertyName = Fields[i, 0];
                            col.HeaderText = Fields[i, 1];
                            col.DisplayIndex = i;
                            break;
                        }
                    }
                    col.Visible = isShow;
                    DG.Columns.Add(col);
                }
            }
            DG.DataSource = _DataSource;
            uPage.RefreshPager(_PageSize, _RowCount, _PageIndex);
        }

        private void RefreshData()
        {
            _DataSource = new SqlServerHelper().GetPageList(_SqlString, _PageOrderField, _PageIndex, _PageSize, ref _RowCount);
            if (_DataSource!=null)
            {
                DataRow newrow = _DataSource.NewRow();
                if (_FieldStatis != null)
                {
                    for (int i = 0; i < _FieldStatis.GetLength(0); i++)
                    {
                        if (!FieldStatis[i, 1].Equals("合计"))
                        {
                            FieldStatis[i, 1] = _DataSource.Compute("SUM(" + FieldStatis[i, 0] + ")", "").ToString();
                        }

                        Type Dtype = _DataSource.Columns[FieldStatis[i, 0]].DataType;
                        string FC = FieldStatis[i, 1];
                        try
                        {
                            if (!string.IsNullOrEmpty(FC))
                            {
                                newrow[FieldStatis[i, 0]] = System.ComponentModel.TypeDescriptor.GetConverter(Dtype).ConvertFrom(FC);
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }
                    _DataSource.Rows.Add(newrow);
                }
            }
        }

        private void UC_DataGridView_Page_Load(object sender, EventArgs e)
        {

        }

        private void uPage_myPagerEvents(int curPage, int pageSize)
        {
            this.PageIndex = curPage;
            this.PageSize = pageSize;
            RefreshData();
            DG.DataSource = _DataSource;
            uPage.RefreshPager(_PageSize, _RowCount, _PageIndex);
        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellClickEvents != null)
            {
                DataGridView DgList = (DataGridView)sender;
                CellClickEvents(sender, e);
            }
        }

        private void DG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CellDoubleClickEvents != null)
            {
                CellDoubleClickEvents(sender, e);
            }
        }

        private void DG_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (!string.IsNullOrEmpty(_FiledColor))
            {
                if (e.RowIndex>-1 && e.ColumnIndex>-1)
                {
                    if (DG.Rows[e.RowIndex].Cells[_FiledColor].Value != null && DG.Rows[e.RowIndex].Cells[_FiledColor].Value != DBNull.Value)
                    {
                        string _Value=DG.Rows[e.RowIndex].Cells[_FiledColor].Value.ToString();

                        switch (_Value.ToUpper())
                        { 
                            case "0":
                                DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                break;
                            case "1":
                            case "TRUE":
                                DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                                break;
                            case "2":
                                DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                                break;
                            case "3":
                                DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
                                break;
                            case "4":
                                DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                                break;
                            case "5":
                                DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                                break;
                            case "6":
                                DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Teal;
                                break;
                            default:
                                DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                break;
                        }

                        //if (_ColorValue.GetLength(0) > 0)
                        //{
                        //    if (Array.IndexOf(_ColorValue,_Value)!=-1)
                        //    {
                                
                        //    }
                        //}
                        //switch ()
                        //{
                        //    case "":

                        //        break;

                        //    default:
                        //        DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        //        break;

                        //}
                        //if (DG.Rows[e.RowIndex].Cells[_FiledColor].Value.ToString().Equals("1"))
                        //{
                        //    DG.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                        //}
                    }
                }
             
            }
        }

    }
}

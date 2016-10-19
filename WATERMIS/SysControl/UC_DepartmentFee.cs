using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SysControl
{
    public partial class UC_DepartmentFee : UserControl
    {
        public UC_DepartmentFee()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000; // Turn off WS_CLIPCHILDREN 
                return parms;
            }
        }

        private string _DepartementID;

        public string DepartementID
        {
            get { return _DepartementID; }
            set { _DepartementID = value; }
        }

        private string _departmentName;

        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        private string _ResolveID;

        public string ResolveID
        {
            get { return _ResolveID; }
            set { _ResolveID = value; }
        }

        private int _ItemsCount;

        public int ItemsCount
        {
            get { return _ItemsCount; }
            set { _ItemsCount = value; }
        }

        private decimal _TotalFee;

        public decimal TotalFee
        {
            get { return _TotalFee; }
            set { _TotalFee = value; }
        }

        private int _STATE;

        public int STATE
        {
            get { return _STATE; }
            set
            {
                _STATE = value; Btn_Dep.BackColor = value != 0 ? Color.DarkSeaGreen : Color.Tan;
            }
        }

        private bool _IsFinal;

        public bool IsFinal
        {
            get { return _IsFinal; }
            set { _IsFinal = value; }
        }

        private int _FeePointSort;

        public int FeePointSort
        {
            get { return _FeePointSort; }
            set { _FeePointSort = value; }
        }

        public void DataRowToProperty(DataRow dr)
        {
            try
            {
                if (dr != null)
                {
                    DepartementID = dr["DepartementID"].ToString();
                    DepartmentName = dr["DepartmentName"].ToString();
                    ResolveID = dr["ResolveID"].ToString();
                    ItemsCount = int.Parse(dr["ItemsCount"].ToString());
                    TotalFee = decimal.Parse(dr["TotalFee"].ToString());
                    STATE = int.Parse(dr["STATE"].ToString());
                    IsFinal = Convert.ToBoolean(dr["IsFinal"].ToString());
                    FeePointSort = int.Parse(dr["FeePointSort"].ToString());
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        public event EventHandler Button_Open_Click;

        private void Btn_Dep_Click(object sender, EventArgs e)
        {
            if (Button_Open_Click != null)
                Button_Open_Click(this, e);
        }

        private void UC_DepartmentFee_Load(object sender, EventArgs e)
        {
            Btn_Dep.Text = string.Format("{0}({1}/{2})", _departmentName, _ItemsCount.ToString(), _TotalFee.ToString());
            //Btn_Dep.Text = string.Format("{0}({1}/{2})-{3}", _departmentName, _ItemsCount.ToString(), _TotalFee.ToString(), _STATE==0?"未收":"已收");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;

namespace SysControl
{
    public partial class UC_ChargePoint : UserControl
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        public UC_ChargePoint()
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

        private string _TaskID;

        public string TaskID
        {
            get { return _TaskID; }
            set { _TaskID = value; }
        }

        private int _PointSort;

        public int PointSort
        {
            get { return _PointSort; }
            set { _PointSort = value; }
        }

        private string _DepartementID;

        public string DepartementID
        {
            get { return _DepartementID; }
            set { _DepartementID = value; }
        }

        public string PointName
        {
            set { Lb_PointName.Text = value; }
        }
        private decimal TotalFee = 0m;
       

        public void InitData()
        {
            FP.Controls.Clear();
            TotalFee = 0m;
            DataTable dt = sysidal.GetChargePointItem(_TaskID, _PointSort, _DepartementID);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_ChargeItem UC = new UC_ChargeItem();
                    decimal _fee = 0m;
                    if (decimal.TryParse(dr["Fee"].ToString(),out _fee))
                    {
                        TotalFee += _fee;
                    }

                    UC.FeeItem = string.Format("{0}:{1}元;",dr["FeeItem"].ToString().Trim(), dr["Fee"].ToString()); ;

                    FP.Controls.Add(UC);
                }
            }
            LB_TotalFee.Text = TotalFee.ToString("f2");
        }


    }
}

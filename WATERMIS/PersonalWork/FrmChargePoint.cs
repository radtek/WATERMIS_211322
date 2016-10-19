using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBinterface.IDAL;
using DBinterface.DAL;
using Common.DotNetData;
using SysControl;

namespace PersonalWork
{
    public partial class FrmChargePoint : Form
    {
        private PersonalWork_IDAL sysidal = new PersonalWork_DAL();

        private string _TaskID;

        public string TaskID
        {
            get { return _TaskID; }
            set { _TaskID = value; }
        }

        private string _DepartementID;

        public string DepartementID
        {
            get { return _DepartementID; }
            set { _DepartementID = value; }
        }

        public FrmChargePoint()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }

        public void InitData()
        {
            FP.Controls.Clear();
            DataTable dt = sysidal.GetAllChargePoint(_TaskID);
            if (DataTableHelper.IsExistRows(dt))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UC_ChargePoint UC = new UC_ChargePoint();
                    UC.TaskID = _TaskID;
                    UC.PointName = dr["PointName"].ToString();
                    UC.PointSort = int.Parse(dr["PointSort"].ToString());
                    UC.DepartementID = _DepartementID;
                    UC.InitData();
                    FP.Controls.Add(UC);
                }
            }
        }
    }
}

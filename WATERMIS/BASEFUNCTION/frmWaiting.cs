using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BASEFUNCTION
{
    public partial class frmWaiting : Form
    {
        public static frmWaiting _Instance = null;

        public frmWaiting()
        {
            InitializeComponent();
        }

        public static void Show(Form owner)
        {
            owner.UseWaitCursor = true;

            if (_Instance == null) _Instance = new frmWaiting();
            _Instance.Owner = owner;
            _Instance.Show();

            Application.DoEvents();
        }

        public static void Show(Form owner, bool disableOwner)
        {            
            owner.UseWaitCursor = true;
            owner.Enabled = !disableOwner;

            if (_Instance == null) _Instance = new frmWaiting();
            _Instance.Owner = owner;
            _Instance.Show();

            Application.DoEvents();
        }

        public static void Hide(Form owner)
        {
            owner.UseWaitCursor = false;
            owner.Enabled = true;

            if (_Instance != null) _Instance.Hide();
            Application.DoEvents();
        }
    }
}

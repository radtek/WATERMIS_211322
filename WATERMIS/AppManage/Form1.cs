using System;
using System.Windows.Forms;

namespace AppManage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“wATERMANAGEDataSet.MeterEquipment”中。您可以根据需要移动或移除它。

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EquipmentManage frm = new EquipmentManage();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MeterRepair frm = new MeterRepair();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserSuggest frm = new UserSuggest();
            frm.Show();
        }
    }
}

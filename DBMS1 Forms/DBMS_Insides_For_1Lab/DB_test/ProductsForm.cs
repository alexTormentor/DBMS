using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbLib;

namespace DB_test
{
    public partial class ProductsForm : Form
    {
        IDb db;
        List<Core> core;

        public ProductsForm(IDb db)
        {
            InitializeComponent();
            this.db = db;
            Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reload(txtSearch.Text);
        }

        private void Reload(string query="")
        {
            core = db.GetCore(query);
            gridProducts.DataSource = core;
        }
    }
}

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
    public partial class FormOder : Form
    {
        public IDb db;

        public List<Core> core;
        public List<Mech> mech;
        public List<Corpus> corpus;

        public FormOder(IDb db)
        {
            InitializeComponent();
            this.db = db;
            Reload();
        }

        public void Reload()
        {
            core = db.GetCore();
            mech = db.GetMech();
            corpus = db.GetCorpus();

            gridChassis.DataSource = corpus;
            comboMech.DataSource = mech;
            comboCore.DataSource = core;
        }

        private void btnChassis_Click(object sender, EventArgs e)
        {

        }
    }
}

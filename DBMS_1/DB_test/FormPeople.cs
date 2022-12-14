using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DbLib;

namespace DB_test
{
    public partial class FormPeople : Form
    {
        IDb db;
        private List<Mech> mech;

        public FormPeople(IDb db)
        {
            InitializeComponent();
            this.db = db;
            mech = new List<Mech>();
            Reload(this.db);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            db.AddMech(new Mech("Игла-4", "Полисталь", "Ускоритель частиц", "Термоядерный", "Страйдер", 4));
            Reload(db);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idx = gridMech.CurrentCell.RowIndex;
            int id = mech[idx].ID;

            db.DeleteMech(id);
            Reload(db);
        }

        // Загрузить данные и отобразить их в таблице
        private void Reload(IDb db)
        {
            mech = db.GetMech();
            gridMech.DataSource = mech;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_test
{
    public partial class Procedure : Form
    {
        public Procedure()
        {
            InitializeComponent();
            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-NVJTH5L\\SQLEXPRESS;Initial Catalog=Lab1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            cnn.Open();
            string proc = "sp_GetMech";
            SqlDataAdapter de = new SqlDataAdapter(proc, cnn);
            DataSet dw = new DataSet();
            de.Fill(dw);
            cnn.Close();
            dataGridView1.DataSource = dw.Tables[0];
        }
    }
}
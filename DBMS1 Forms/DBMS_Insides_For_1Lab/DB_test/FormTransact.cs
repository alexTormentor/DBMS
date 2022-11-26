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
    public partial class FormTransact : Form
    {
        public FormTransact()
        {
            InitializeComponent();
            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-NVJTH5L\\SQLEXPRESS;Initial Catalog=Lab1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            cnn.Open();
            SqlDataAdapter de = new SqlDataAdapter("select * from Mecha where ArmoreType = 'Титановая' ", cnn);
            DataSet dq = new DataSet();
            de.Fill(dq);
            cnn.Close();
            dataGridView1.DataSource = dq.Tables[0];
        }
    }
}

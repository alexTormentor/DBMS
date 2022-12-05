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


            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-NVJTH5L\\SQLEXPRESS;Initial Catalog=Lab1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    // выполняем две отдельные команды
                    command.CommandText = "INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID)" +
                        " VALUES('Игла-5', 'Полисталь', 'Фазмаган', 'Фазовый', 'Страйдер', 17)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID)" +
                        " VALUES('ХХХХХХХХ-5', 'Титановая', 'БАЛАБОБА', 'ХХХХХХХХХ', 'ХХХХХХХХХ', 17)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID)" +
                        " VALUES('АААААА', 'Титановая', 'АААА', 'АААА', 'АААА', 17)";
                    command.ExecuteNonQuery();

                    // подтверждаем транзакцию
                    transaction.Commit();
                    Console.WriteLine("Данные добавлены в базу данных");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
            }


            SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-NVJTH5L\\SQLEXPRESS;Initial Catalog=Lab1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            cnn.Open();
            SqlDataAdapter de = new SqlDataAdapter("select * from Mecha where ArmoreType = 'Титановая' ", cnn);
            DataSet dq = new DataSet();
            de.Fill(dq);
            cnn.Close();
            dataGridView1.DataSource = dq.Tables[0];
        }

        private void FormTransact_Load(object sender, EventArgs e)
        {

        }
    }
}

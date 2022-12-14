using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;

namespace DbConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDb db = new Db();
            var mech = db.GetMech();
            Transact();

            PrintMech(mech);

            Console.ReadKey();
        }

        private static void Transact()
        {
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
                        " VALUES('АААААА', 'ААААА', 'АААА', 'АААА', 'АААА', 17)";
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
        }

        private static void PrintMech(List<Mech> mech)
        {
            Console.WriteLine("|   ID |         Model |        ArmoreType |       WeaponType |         EngineType |        Type |       SerialID |");
            Console.WriteLine("|------|---------------|-------------------|------------------|--------------------|-------------|----------------|");
            foreach (var mecha in mech)
            {
                Console.WriteLine($"| {mecha.ID,4} | {mecha.Model,16} | {mecha.ArmoreType,16} | {mecha.WeaponType,16} |{mecha.EngineType,16} | {mecha.Type,16} | {mecha.SerialID,16} |");
            }
        }
    }
}

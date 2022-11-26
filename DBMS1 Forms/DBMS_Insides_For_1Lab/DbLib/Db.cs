using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DbLib
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class Db : IDb
    {
        private string connectionString = "Data Source=DESKTOP-NVJTH5L\\SQLEXPRESS;Initial Catalog=Lab1;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection cnn;

        public Db()
        {
            cnn = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Возвращает список всех людей в базе
        /// </summary>
        public List<Mech> GetMech()
        {
            cnn.Open();

            var da = new SqlDataAdapter("select * from Mecha", cnn);
            var ds = new DataSet();
            da.Fill(ds);
            var tableMech = ds.Tables[0];

            var mech = new List<Mech>();
            
            foreach(DataRow row in tableMech.Rows)
            {
                var newMech = new Mech(
                    (string)row["Model"], (string)row["ArmoreType"],
                    (string)row["WeaponType"], (string)row["EngineType"],
                    (string)row["Type"], (int)row["SerialID"],
                    (int)row["ID"]);
                mech.Add(newMech);
            }

            cnn.Close();
            return mech;
        }

        public List<Core> GetCore(string searchQuery = "")
        {
            string sql;
            if (searchQuery == "")
            {
                sql = "SELECT * FROM Core2";
            }
            else
            {
                sql = $"SELECT * FROM Core WHERE Core2.MechSystem = N'{searchQuery}'";
            }

            cnn.Open();

            var da = new SqlDataAdapter(sql, cnn);
            var ds = new DataSet();
            da.Fill(ds);
            var tableCore = ds.Tables[0];

            var core = new List<Core>();

            foreach (DataRow row in tableCore.Rows)
            {
                var newCore = new Core(
                    (string)row["MechSystem"],
                    (int)row["Power"],
                    (int)row["Id"]);
                core.Add(newCore);
            }

            cnn.Close();

            return core;
        }

        /// <summary>
        /// Возвращает список заказов
        /// </summary>
        /// <returns></returns>
        public List<Corpus> GetCorpus()
        {
            cnn.Open();

            var da = new SqlDataAdapter(
                "select Mecha.Model, Mecha.Type, " +
                "       Core2.MechSystem, Core2.Power from Corpus " +
                "INNER JOIN Core2 ON Core2.Id = Corpus.CoreId " +
                "INNER JOIN Mecha ON Mecha.ID = Corpus.MechId",
                cnn);
            var ds = new DataSet();
            da.Fill(ds);
            var tableCorpus = ds.Tables[0];

            var corpus = new List<Corpus>();

            foreach (DataRow row in tableCorpus.Rows)
            {
                var newCorpus = new Corpus(
                    (string)row["Model"],
                    (string)row["ArmoreType"],
                    (string)row["WeaponType"],
                    (string)row["EngineType"],
                    (string)row["Type"],
                    (int)row["Price"]);
                corpus.Add(newCorpus);
            }

            cnn.Close();
            return corpus;
        }

        /// <summary>
        /// Добавляет новую запись о человеке в базу
        /// </summary>
        public void AddMech(Mech mech)
        {
            var sql = $"insert into Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID) " +
                $"values (N'{mech.Model}', N'{mech.ArmoreType}', N'{mech.WeaponType}'," +
                $" N'{mech.EngineType}', N'{mech.Type}', N'{mech.SerialID}')";
            ExecCommand(sql);
        }

        /// <summary>
        /// Удаляет человека из базы
        /// </summary>
        /// <param name="id">ID человека</param>
        public void DeleteMech(int id)
        {
            var sql = $"delete from Mecha where ID = {id}";
            ExecCommand(sql);
        }

        /// <summary>
        /// Совершает заказ
        /// </summary>
        /// <param name="personId">Id покупателя</param>
        /// <param name="productId">Id товара</param>
        public void Create(int mechId, int coreId)
        {
            var sql = $"EXEC Create {mechId}, {coreId}";
            ExecCommand(sql);
        }

        // Выполняет SQL запроч
        private void ExecCommand(string sql)
        {
            cnn.Open();
            var cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}

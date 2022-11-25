using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MechPatterns_v2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-NVJTH5L\\SQLEXPRESS;Initial Catalog=Lab1;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //await InsertData(connectionString);
            //await DeleteData(connectionString);
            //await UpdateData(connectionString);
            //await ReadData(connectionString);
            //await ScalarData(connectionString);
            // данные для добавления
            //await ParameterData(connectionString); - не работает
            //await ProcadureData(connectionString);
            //await ProcDataProcedure(connectionString);
            //await ProcParam(connectionString);
            //await UseNewProc(connectionString);
            await Transaction(connectionString);
            Console.Read();
        }

        private static async Task Transaction(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlTransaction transaction = connection.BeginTransaction();


                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    // выполняем две отдельные команды
                    command.CommandText = "INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID) " +
                        "VALUES('Архонт-12', 'Титановая', 'Лазер', 'Фазовый', 'Страйдер', 3)";
                    await command.ExecuteNonQueryAsync();
                    command.CommandText = "INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID) " +
                        "VALUES('Скорпион', 'Кластерная', 'Комплекс Хазард', 'Термоядерный', 'Глайдер', 14)";
                    await command.ExecuteNonQueryAsync();

                    // подтверждаем транзакцию
                    await transaction.CommitAsync();
                    Console.WriteLine("Данные добавлены в базу данных");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // если ошибка, откатываем назад все изменения
                    await transaction.RollbackAsync();
                }
            }
        }

        private static async Task GetAllMechAsync(string connectionString)
        {
            string sqlExpression = "SELECT * FROM Mecha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        // выводим названия столбцов
                        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}" +
                            $"\t{reader.GetName(4)}\t{reader.GetName(5)}\t{reader.GetName(6)}");

                        while (await reader.ReadAsync()) // построчно считываем данные
                        {
                            object id = reader.GetValue(0);
                            object model = reader.GetValue(1);
                            object armore = reader.GetValue(2);
                            object weapon = reader.GetValue(3);
                            object engine = reader.GetValue(4);
                            object type = reader.GetValue(5);
                            object serial = reader.GetValue(6);
                            Console.WriteLine($"{id} \t{model} \t{armore}\t{weapon} \t{engine}\t{type} \t{serial}");
                        }
                    }
                }
            }
        }
        private static async Task GetSerialRangeAsync(string connectionString, string model)
        {
            string sqlExpression = "sp_GetSerialRange";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter modelParam = new SqlParameter
                {
                    ParameterName = "@Model",
                    Value = model
                };
                command.Parameters.Add(modelParam);

                // определяем первый выходной параметр
                SqlParameter minSerialParam = new SqlParameter
                {
                    ParameterName = "@minSerial",
                    SqlDbType = SqlDbType.Int, // тип параметра

                    // указываем, что параметр будет выходным
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(minSerialParam);

                // определяем второй выходной параметр
                SqlParameter maxSerialParam = new SqlParameter
                {
                    ParameterName = "@maxSerial",
                    SqlDbType = SqlDbType.Int,
                    // указываем, что параметр будет выходным
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(maxSerialParam);

                await command.ExecuteNonQueryAsync();
                object minSerial = command.Parameters["@minSerial"].Value;
                object maxSerial = command.Parameters["@maxSerial"].Value;
                Console.WriteLine($"самый ранний прототип: {minSerial}");
                Console.WriteLine($"самый новый прототип: {maxSerial}");
            }
        }

        private static async Task UseNewProc(string connectionString)
        {
            await GetAllMechAsync(connectionString);   // сначала выводим всех пользователей

            Console.Write("Введите название модели:");
            string model = Console.ReadLine();

            await GetSerialRangeAsync(connectionString, model);
        }

        private static async Task ProcParam(string connectionString)
        {
            string proc = @"CREATE PROCEDURE [dbo].[sp_GetSerialRange]
                                @Model varchar(50),
                                @minSerial int out,
                                @maxSerial int out
                            AS
                                SELECT @minSerial = MIN(SerialID), @maxSerial = MAX(SerialID) FROM Mecha WHERE Model LIKE '%' + @Model + '%';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(proc, connection);

                await command.ExecuteNonQueryAsync();
            }
        }

        private static async Task ProcDataProcedure(string connectionString)
        {
            Console.Write("Введите название модели: ");
            string model = Console.ReadLine();
            Console.Write("Введите тип брони: ");
            string armore = Console.ReadLine();
            Console.Write("Введите тип вооружения: ");
            string weapon = Console.ReadLine();
            Console.Write("Введите тип двигателя: ");
            string engine = Console.ReadLine();
            Console.Write("Введите тип меха: ");
            string type = Console.ReadLine();

            Console.Write("Введите серийный номер: ");
            int serial = Int32.Parse(Console.ReadLine());

            await AddMechAsync(connectionString, model, armore, weapon, engine, type, serial);

            Console.WriteLine();

            await GetMechAsync(connectionString);
        }

        // добавление пользователя
        private static async Task AddMechAsync(string connectionString, string model, string armore, string weapon, string engine, string type, int serial)
        {
            // название процедуры
            string sqlExpression = "sp_InsertMech";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter modelParam = new SqlParameter
                {
                    ParameterName = "@Model",
                    Value = model
                };
                SqlParameter armoreParam = new SqlParameter
                {
                    ParameterName = "@ArmoreType",
                    Value = armore
                };
                SqlParameter weaponParam = new SqlParameter
                {
                    ParameterName = "@WeaponType",
                    Value = weapon
                };
                SqlParameter engineParam = new SqlParameter
                {
                    ParameterName = "@EngineType",
                    Value = engine
                };
                SqlParameter typeParam = new SqlParameter
                {
                    ParameterName = "@Type",
                    Value = type
                };
                // добавляем параметр
                command.Parameters.Add(modelParam);
                command.Parameters.Add(armoreParam);
                command.Parameters.Add(weaponParam);
                command.Parameters.Add(engineParam);
                command.Parameters.Add(typeParam);
                SqlParameter serialParam = new SqlParameter
                {
                    ParameterName = "@SerialID",
                    Value = serial
                };
                command.Parameters.Add(serialParam);

                // выполняем процедуру
                var id = await command.ExecuteScalarAsync();
                // если нам не надо возвращать id
                //var id = await command.ExecuteNonQueryAsync();

                Console.WriteLine($"Id добавленного объекта: {id}");
            }
        }

        private static async Task GetMechAsync(string connectionString)
        {
            // название процедуры
            string sqlExpression = "sp_GetMech";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(2)}\t{reader.GetName(1)}");

                        while (await reader.ReadAsync())
                        {
                            int id = reader.GetInt32(0);
                            string model = reader.GetString(1);
                            string armore = reader.GetString(2);
                            string weapon = reader.GetString(3);
                            string engine = reader.GetString(4);
                            string type = reader.GetString(5);
                            int serial = reader.GetInt32(6);
                            Console.WriteLine($"{id} \t{model} \t{armore} \t{weapon} \t{engine} \t{type} \t{serial}");
                        }
                    }
                }
            }
        }

        private static async Task ProcadureData(string connectionString)
        {
            string proc1 = @"CREATE PROCEDURE [dbo].[sp_InsertMech]
                                @Model varchar(50),
                                @ArmoreType varchar(50),
                                @WeaponType varchar(50),
                                @EngineType varchar(50),
                                @Type varchar(50),
                                @SerialID int
                            AS
                                INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID)
                                VALUES (@Model, @ArmoreType, @WeaponType, @EngineType, @Type, @SerialID)
   
                                SELECT SCOPE_IDENTITY()
                            GO";

            string proc2 = @"CREATE PROCEDURE [dbo].[sp_GetMech]
                                AS
                                    SELECT * FROM Mecha 
                                GO";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(proc1, connection);

                // добавляем первую процедуру
                await command.ExecuteNonQueryAsync();

                // добавляем вторую процедуру
                command.CommandText = proc2;
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Хранимые процедуры добавлены в базу данных.");
            }
        }

        private static async Task ParameterData(string connectionString)
        {
            string model = "Вальтер-5";
            string armoreType = "Титановая";
            string weaponType = "Пулемётный комплекс";
            string engineType = "Гибридный";
            string type = "Глайдер";
            int serialID = 12;
            // выражение SQL для добавления данных
            string sqlExpression = "INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID) " +
                "VALUES (@Model, @ArmoreType, @WeaponType, @EngineType, @Type, @SerialID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                // создаем параметр для имени
                SqlParameter modelParam = new SqlParameter("@Model", System.Data.SqlDbType.VarChar, 50);
                modelParam.Value = model;
                SqlParameter armoreTypeParam = new SqlParameter("@ArmoreType", System.Data.SqlDbType.VarChar, 50);
                armoreTypeParam.Value = armoreType;
                SqlParameter weaponTypeParam = new SqlParameter("@WeaponType", System.Data.SqlDbType.VarChar, 50);
                weaponTypeParam.Value = weaponType;
                SqlParameter engineTypeParam = new SqlParameter("@EngineType", System.Data.SqlDbType.VarChar, 50);
                engineTypeParam.Value = engineType;
                SqlParameter typeParam = new SqlParameter("@Type", System.Data.SqlDbType.VarChar, 50);
                typeParam.Value = type;


                // добавляем параметр к команде
                command.Parameters.Add(modelParam);
                command.Parameters.Add(armoreTypeParam);
                command.Parameters.Add(weaponTypeParam);
                command.Parameters.Add(engineTypeParam);
                command.Parameters.Add(typeParam);
                // создаем параметр для возраста
                SqlParameter serialIDParam = new SqlParameter("@SerialID", serialID);
                // добавляем параметр к команде
                command.Parameters.Add(serialID);

                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");
            }
        }

        private static async Task ScalarData(string connectionString)
        {
            string sqlExpression = "SELECT COUNT(*) FROM Mecha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                object count = await command.ExecuteScalarAsync();

                command.CommandText = "SELECT MIN(SerialID) FROM Mecha";
                object minAge = await command.ExecuteScalarAsync();

                command.CommandText = "SELECT AVG(SerialID) FROM Mecha";
                object avgAge = await command.ExecuteScalarAsync();

                Console.WriteLine($"В таблице {count} объектa(ов)");
                Console.WriteLine($"Самый ранний прототип: {minAge}");
                Console.WriteLine($"Среднее количество версий прототипов: {avgAge}");
            }
        }

        private static async Task ReadData(string connectionString)
        {
            string sqlExpression = "SELECT * FROM Mecha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);
                    string columnName3 = reader.GetName(2);
                    string columnName4 = reader.GetName(3);
                    string columnName5 = reader.GetName(4);
                    string columnName6 = reader.GetName(5);
                    string columnName7 = reader.GetName(6);

                    Console.WriteLine($"{columnName1}\t{columnName2}\t{columnName3}\t{columnName4}\t{columnName5}\t{columnName6}" +
                        $"\t{columnName7}");

                    while (await reader.ReadAsync()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object model = reader.GetValue(1);
                        object armoreType = reader.GetValue(2);
                        object weaponType = reader.GetValue(3);
                        object engineType = reader.GetValue(4);
                        object Type = reader.GetValue(5);
                        object serialID = reader.GetValue(6);

                        Console.WriteLine($"{id} \t{model} \t{armoreType}\t{weaponType} \t{engineType}\t{Type} \t{serialID}");
                    }
                }

                await reader.CloseAsync();
            }
        }

        private static async Task UpdateData(string connectionString)
        {
            Console.WriteLine("Введите название:");
            string model = Console.ReadLine();

            Console.WriteLine("Введите тип брони:");
            string armoreType = Console.ReadLine();

            Console.WriteLine("Введите тип оружия:");
            string weaponType = Console.ReadLine();

            Console.WriteLine("Введите тип двигателя:");
            string engineType = Console.ReadLine();

            Console.WriteLine("Введите тип меха:");
            string Type = Console.ReadLine();

            Console.WriteLine("Введите серийный номер:");
            int serialID = Int32.Parse(Console.ReadLine());

            string sqlExpression = $"INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID) VALUES " +
                $"('{model}', '{armoreType}', '{weaponType}', '{engineType}' , '{Type}', {serialID})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // добавление
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");

                // обновление ранее добавленного объекта
                Console.WriteLine("Введите новое название:");
                model = Console.ReadLine();
                sqlExpression = $"UPDATE Mecha SET Model='{model}' WHERE serialID={serialID}";
                command.CommandText = sqlExpression;
                number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Обновлено объектов: {number}");
            }
        }

        private static async Task DeleteData(string connectionString)
        {
            string sqlExpression = "DELETE  FROM Mecha WHERE Model='Энигма-6'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Удалено объектов: {number}");
            }
        }

        private static async Task InsertData(string connectionString)
        {
            string sqlExpression = "INSERT INTO Mecha (Model, ArmoreType, WeaponType, EngineType, Type, SerialID) " +
                            "VALUES ('Энигма-6', 'Листовая', 'Ракетный комплекс', 'Фазовый', 'Страйдер', 36)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Добавлено объектов: {number}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS_3_Requests;
using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Requests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("LINQ запрос");
            LinqRequest();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Асинк запрос");
            await AsyncLinq();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Запрос конкретного параметра");
            Where();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("То же на Linq");
            WhereLinq();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Like от EFCore поиск совпаденй");
            EFCoreLike();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Все найденные");
            Find();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Возврат первого значения (если условие вып. или не найдо то по умолчанию)");
            FirstOrDefault();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Выборка");
            Select();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Сортировка с ориентацией");
            OrderBy();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Присоединение");
            Join();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("по сути иннер джойн");
            ImplateTables();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("группировка");
            Group();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("подготовка");
            RecreateTableForNextStep();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("объединение данныъ");
            Union();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("пересечение даных");
            Intersect();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("исключение");
            Except();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("подсчет");
            Count();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("мин ср макс значения");
            MinAvMax();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("суммарные значения");
            Sum();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("подготовка");
            ReCreateAgain();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("обычное получение");
            StandartExtract();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("без изменений запроса");
            AsNoTracking();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("с имзенением");
            QueryTrackingBehavior();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("изменение");
            ChangeTracker();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("отслеживаемые запросы");
            OtsledRequest();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("снова");
            OtsledRequest2();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("перечисление");
            IEnumerableMethod();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("запрашиваемое");
            IQueryableMethod();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("фильтр запроса");
            RequestFilter();
            Console.Read();
        }

        private static void RequestFilter()
        {
            using (ApplicationContext5 db = new ApplicationContext5())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Power high = new Power { Name = "Кратковременная, высокая" };
                Power longWork = new Power { Name = "низкая эффективность, режим долгосрочной работы" };
                Mech5 mech1 = new Mech5 { Name = "Энигма", Age = 17, Power = longWork };
                Mech5 mech2 = new Mech5 { Name = "Архонт", Age = 18, Power = longWork };
                Mech5 mech3 = new Mech5 { Name = "Битум", Age = 19, Power = high };
                Mech5 mech4 = new Mech5 { Name = "Марк 2", Age = 20, Power = high };

                db.Power.AddRange(longWork, high);
                db.Mech5.AddRange(mech1, mech2, mech3, mech4);
                db.SaveChanges();
            }

            using (ApplicationContext5 db = new ApplicationContext5() { RoleId = 2 })
            {
                var users = db.Mech5.Include(u => u.Power).ToList();
                foreach (Mech5 user in users)
                    Console.WriteLine($"Модель: {user.Name}  Серия: {user.Age}  Мощность: {user.Power?.Name}");
            }
        }

        private static void IQueryableMethod()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                IQueryable<Mech4> userIQuer = db.Mech4;
                var users = userIQuer.Where(p => p.Id < 10).ToList();

                foreach (var user in users) Console.WriteLine(user.Name);
            }
        }

        private static void IEnumerableMethod()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                IEnumerable<Mech4> userIEnum = db.Mech4;
                var users = userIEnum.Where(p => p.Id < 10).ToList();

                foreach (var user in users) Console.WriteLine(user.Name);
            }
        }

        private static void OtsledRequest2()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                var user1 = db.Mech4.FirstOrDefault();
                var user2 = db.Mech4.AsNoTracking().FirstOrDefault();

                if (user1 != null && user2 != null)
                {
                    Console.WriteLine($"Предыдущая модель: {user1.Name}   Модель: {user2.Name}");

                    user1.Name = "Энигма";

                    Console.WriteLine($"Следующая: {user1.Name}   Модель: {user2.Name}");
                }
            }
        }

        private static void OtsledRequest()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                var user1 = db.Mech4.FirstOrDefault();
                var user2 = db.Mech4.FirstOrDefault();
                if (user1 != null && user2 != null)
                {
                    Console.WriteLine($"Ранняя версия: {user1.Name}   Текущая: {user2.Name}");

                    user1.Name = "Архонт-4";

                    Console.WriteLine($"Следующая: {user1.Name}   Модель: {user2.Name}");
                }
            }
        }

        private static void ChangeTracker()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                var users = db.Mech3.ToList();

                foreach (var u in users)
                    Console.WriteLine($"{u.Name} ({u.Age})");

                int count = db.ChangeTracker.Entries().Count();
                Console.WriteLine($"{count}");
            }
        }

        private static void QueryTrackingBehavior()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
                var user = db.Mech3.FirstOrDefault();
                if (user != null)
                {
                    user.Age = 8;
                    db.SaveChanges();
                }

                var users = db.Mech3.ToList();
                foreach (var u in users)
                    Console.WriteLine($"{u.Name} ({u.Age})");
            }
        }

        private static void AsNoTracking()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                var user = db.Mech3.AsNoTracking().FirstOrDefault();
                if (user != null)
                {
                    user.Age = 22;
                    db.SaveChanges();
                }

                var users = db.Mech3.AsNoTracking().ToList();
                foreach (var u in users)
                    Console.WriteLine($"{u.Name} ({u.Age})");
            }
        }

        private static void StandartExtract()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                var user = db.Mech3.FirstOrDefault();
                if (user != null)
                {
                    user.Age = 18;
                    db.SaveChanges();
                }

                var users = db.Mech3.ToList();
                foreach (var u in users)
                    Console.WriteLine($"{u.Name} ({u.Age})");
            }
        }

        private static void ReCreateAgain()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                // пересоздаем базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Mech3 Enigma = new Mech3 { Name = "Энигма", Age = 36 };
                Mech3 Archont = new Mech3 { Name = "Архонт", Age = 39 };
                Mech3 Bitum = new Mech3 { Name = "Битум", Age = 28 };
                Mech3 Mark2 = new Mech3 { Name = "Марк 2", Age = 25 };

                db.Mech3.AddRange(Enigma, Archont, Bitum, Mark2);
                db.SaveChanges();
            }
        }

        private static void Sum()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // суммарный возраст всех пользователей 
                int sum1 = db.Mech.Sum(u => u.Age);
                // суммарный возраст тех, кто работает в Microsoft
                int sum2 = db.Mech.Where(u => u.Engine!.Name == "атомный")
                    .Sum(u => u.Age);
                Console.WriteLine(sum1);
                Console.WriteLine(sum2);
            }
        }

        private static void MinAvMax()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // минимальный возраст
                int minAge = db.Mech.Min(u => u.Age);
                // максимальный возраст
                int maxAge = db.Mech.Max(u => u.Age);
                // средний возраст пользователей, которые работают в Microsoft
                double avgAge = db.Mech.Where(u => u.Engine!.Name == "фазовый")
                    .Average(p => p.Age);

                Console.WriteLine(minAge);
                Console.WriteLine(maxAge);
                Console.WriteLine(avgAge);
            }
        }

        private static void Count()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int number1 = db.Mech.Count();
                // найдем кол-во пользователей, которые в имени содержат подстроку Tom
                int number2 = db.Mech.Count(u => u.Name!.Contains("Энигма"));

                Console.WriteLine(number1);
                Console.WriteLine(number2);
            }
        }

        private static void Except()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var selector1 = db.Mech.Where(u => u.Age > 30); // 
                var selector2 = db.Mech.Where(u => u.Name!.Contains("Энигма"));
                var users = selector1.Except(selector2);

                foreach (var user in users)
                    Console.WriteLine(user.Name);
            }
        }

        private static void Intersect()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Mech.Where(u => u.Age > 30)
                    .Intersect(db.Mech.Where(u => u.Name!.Contains("Архонт")));
                foreach (var user in users)
                    Console.WriteLine(user.Name);
            }
        }

        private static void Union()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Mech.Where(u => u.Age < 30)
                    .Union(db.Mech.Where(u => u.Name!.Contains("Архонт")));
                foreach (var user in users)
                    Console.WriteLine(user.Name);
            }
        }

        private static void RecreateTableForNextStep()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздаем базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Engine phase = new Engine { Name = "фазовый" };
                Engine atomic = new Engine { Name = "атомный" };
                db.Engine.AddRange(phase, atomic);

                Mech Enigma = new Mech { Name = "Энигма", Age = 36, Engine = phase };
                Mech Archont = new Mech { Name = "Архонт", Age = 39, Engine = atomic };
                Mech Bitum = new Mech { Name = "Битум", Age = 28, Engine = phase };
                Mech Mark2 = new Mech { Name = "Марк 2", Age = 25, Engine = atomic };

                db.Mech.AddRange(Enigma, Archont, Bitum, Mark2);
                db.SaveChanges();
            }
        }

        private static void Group()
        {
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                var groups = from u in db.Mech2
                    group u by u.Corpus2!.Name
                    into g
                    select new
                    {
                        g.Key,
                        Count = g.Count()
                    };
                foreach (var group in groups)
                {
                    Console.WriteLine($"{group.Key} - {group.Count}");
                }
            }
        }

        private static void ImplateTables()
        {
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                // пересоздаем базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Type strider = new Type { Name = "Страйдер" };

                Corpus2 standart = new Corpus2 { Name = "Стандарт", Type = strider };
                Corpus2 heavy = new Corpus2 { Name = "Тяжелый", Type = strider };
                db.Corpus2.AddRange(standart, heavy);

                Mech2 Enigma = new Mech2 { Name = "Энигма", Age = 36, Corpus2 = standart };
                Mech2 Archont = new Mech2 { Name = "Архонт", Age = 39, Corpus2 = heavy };
                Mech2 Bitum = new Mech2 { Name = "Битум", Age = 28, Corpus2 = standart };
                Mech2 Mark2 = new Mech2 { Name = "Марк 2", Age = 25, Corpus2 = heavy };

                db.Mech2.AddRange(Enigma, Archont, Bitum, Mark2);
                db.SaveChanges();
            }

            using (ApplicationContext2 db = new ApplicationContext2())
            {
                var users = from user in db.Mech2
                    join company in db.Corpus2 on user.CompanyId equals company.Id
                    join country in db.Type on company.CountryId equals country.Id
                    select new
                    {
                        Name = user.Name,
                        Company = company.Name,
                        Age = user.Age,
                        Country = country.Name
                    };
                foreach (var u in users)
                    Console.WriteLine($"{u.Name} ({u.Company} - {u.Country}) - {u.Age}");
            }
        }

        private static void Join()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Mech.Join(db.Engine, // второй набор
                    u => u.CompanyId, // свойство-селектор объекта из первого набора
                    c => c.Id, // свойство-селектор объекта из второго набора
                    (u, c) => new // результат
                    {
                        Name = u.Name,
                        Company = c.Name,
                        Age = u.Age
                    });
                foreach (var u in users)
                    Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");
            }
        }

        private static void OrderBy()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Mech.OrderBy(p => p.Name);
                foreach (var user in users)
                    Console.WriteLine($"{user.Id}.{user.Name} ({user.Age})");
            }
        }

        private static void Select()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Mech.Select(p => new
                {
                    Name = p.Name,
                    Age = p.Age,
                    Company = p.Engine!.Name
                });
                foreach (var user in users)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company}");
            }
        }

        private static void FirstOrDefault()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Mech? user = db.Mech.FirstOrDefault();
                if (user != null) Console.WriteLine(user.Name);
            }
        }

        private static void Find()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Mech? user = db.Mech.Find(3); // выберем элемент с id=3
                if (user != null) Console.WriteLine($"{user.Name} ({user.Age})");
            }
        }

        private static void EFCoreLike()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Mech.Where(p => EF.Functions.Like(p.Name!, "%Энигма%"));
                foreach (Mech user in users)
                    Console.WriteLine($"{user.Name} ({user.Age})");
            }
        }

        private static void WhereLinq()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = (from user in db.Mech
                    where user.Engine!.Name == "Кинетический"
                    select user).ToList();
                foreach (Mech user in users)
                    Console.WriteLine($"{user.Name} ({user.Age})");
            }
        }

        private static void Where()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Mech.Where(p => p.Engine!.Name == "Кинетический");
                foreach (Mech user in users)
                    Console.WriteLine($"{user.Name} ({user.Age})");
            }
        }

        private static async Task AsyncLinq()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = await db.Mech
                    .Include(p => p.Engine)
                    .Where(p => p.CompanyId == 1)
                    .ToListAsync(); // асинхронное получение данных

                foreach (var user in users)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Engine?.Name}");
            }
        }

        private static void LinqRequest()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздаем базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Engine phase = new Engine { Name = "Фазовый" };
                Engine kinetic = new Engine { Name = "Кинетический" };
                db.Engine.AddRange(phase, kinetic);

                Mech Enigma = new Mech { Name = "Энигма", Age = 36, Engine = phase };
                Mech Archont = new Mech { Name = "Архонт", Age = 39, Engine = kinetic };
                Mech Bitum = new Mech { Name = "Битум", Age = 28, Engine = phase };
                Mech Mark2 = new Mech { Name = "Марк 2", Age = 25, Engine = kinetic };

                db.Mech.AddRange(Enigma, Archont, Bitum, Mark2);
                db.SaveChanges();
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = (from user in db.Mech.Include(p => p.Engine)
                    where user.CompanyId == 1
                    select user).ToList();

                foreach (var user in users)
                    Console.WriteLine($"{user.Name} ({user.Age}) - {user.Engine?.Name}");
            }
        }
    }
}
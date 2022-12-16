using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBMS_3_Loading
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Жадная загрузка - подготовка");
            PreLoad();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Жадная загрузка");
            EagerLoad();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("включение доп. данных");
            EagerInclude();
            // добавление данных
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Используем начальные данные");
            ThenInclude();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("включение доп. данных");
            PolyLevelEager();*/

            /*Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("явная загрузка");
            ExplicitLoad();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("с коллекцией");
            Collection();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("получение по ссылке");
            Reference();*/

            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Ленивая загрузка");
            LazyLoad();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Ленивая загрузка х2");
            Lazy2();

            Console.Read();
        }

        private static void Lazy2()
        {
            using (ApplicationContext5 db = new ApplicationContext5())
            {
                var corpuses = db.Corpus4.ToList();
                foreach (Corpus4 corp in corpuses)
                {
                    Console.Write($"{corp.Name}:");
                    foreach (Mech4 mech in corp.Mech4)
                        Console.Write($"{mech.Model} ");
                    Console.WriteLine();
                }
            }
        }

        private static void LazyLoad()
        {
            using (ApplicationContext5 db = new ApplicationContext5())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // добавляем начальные данные
                Corpus4 Standart = new Corpus4 { Name = "Стандарт" };
                Corpus4 Transformer = new Corpus4 { Name = "Трансформер" };
                db.Corpus4.AddRange(Standart, Transformer);


                Mech4 Enigma = new Mech4 { Model = "Энигма", Corpus4 = Standart };
                Mech4 Archont = new Mech4 { Model = "Архонт", Corpus4 = Transformer };
                Mech4 Bitum = new Mech4 { Model = "Битум", Corpus4 = Standart };
                Mech4 Mark2 = new Mech4 { Model = "Марк 2", Corpus4 = Transformer };
                db.Mech4.AddRange(Enigma, Archont, Bitum, Mark2);

                db.SaveChanges();
            }

            using (ApplicationContext5 db = new ApplicationContext5())
            {
                var mechas = db.Mech4.ToList();
                foreach (Mech4 mech in mechas)
                    Console.WriteLine($"{mech.Model} - {mech.Corpus4?.Name}");
            }
        }

        private static void Reference()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                Mech? mech = db.Mech.FirstOrDefault(); // получаем первого пользователя
                if (mech != null)
                {
                    db.Entry(mech).Reference(u => u.Corpus).Load();
                    Console.WriteLine($"{mech.Name} - {mech.Corpus?.Name}"); // Tom - Microsoft
                }
            }
        }

        private static void Collection()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                Corpus? corpus = db.Corpus.FirstOrDefault();
                if (corpus != null)
                {
                    db.Entry(corpus).Collection(c => c.Mech).Load();

                    Console.WriteLine($"Корпус: {corpus.Name}");
                    foreach (var u in corpus.Mech)
                        Console.WriteLine($"Модель: {u.Name}");
                }
            }
        }

        private static void ExplicitLoad()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // добавляем начальные данные
                Corpus classic = new Corpus { Name = "Microsoft" };
                Corpus transformer = new Corpus { Name = "Google" };
                db.Corpus.AddRange(classic, transformer);

                Mech Enigma = new Mech { Name = "Энигма", Corpus = classic };
                Mech Archont = new Mech { Name = "Архонт", Corpus = classic };
                Mech Bitum = new Mech { Name = "Битум", Corpus = transformer };
                Mech Mark2 = new Mech { Name = "Марк 2", Corpus = transformer };
                db.Mech.AddRange(Enigma, Archont, Bitum, Mark2);

                db.SaveChanges();
            }

            using (ApplicationContext4 db = new ApplicationContext4())
            {
                Corpus? corpus = db.Corpus.FirstOrDefault();
                if (corpus != null)
                {
                    db.Mech.Where(u => u.CompanyId == corpus.Id).Load();

                    Console.WriteLine($"Корпус: {corpus.Name}");
                    foreach (var u in corpus.Mech)
                        Console.WriteLine($"Модель: {u.Name}");
                }
            }
        }

        private static void PolyLevelEager()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Status InProgress = new Status { Name = "В разработке." };
                Status Ready = new Status { Name = "Выпущен." };
                db.Status.AddRange(InProgress, Ready);

                Weapon washington = new Weapon { WeaponType = "Ракетный комплекс" };
                db.Weapon.Add(washington);

                Corporation2 SteelHeart = new Corporation2 { Name = "СтилХарт", Weapon = washington };
                db.Corporation2.Add(SteelHeart);

                Corpus3 Standart = new Corpus3 { Name = "Стандарт", Corporation2 = SteelHeart };
                Corpus3 Transformer = new Corpus3 { Name = "Трансформер", Corporation2 = SteelHeart };
                db.Corpus3.AddRange(Standart, Transformer);

                Mech3 Enigma = new Mech3 { Model = "Энигма", Corpus3 = Standart, Status = InProgress };
                Mech3 Archont = new Mech3 { Model = "Архонт", Corpus3 = Transformer, Status = Ready };
                Mech3 Bitum = new Mech3 { Model = "Битум", Corpus3 = Standart, Status = Ready };
                Mech3 Mark2 = new Mech3 { Model = "Марк 2", Corpus3 = Transformer, Status = InProgress };
                db.Mech3.AddRange(Enigma, Archont, Bitum, Mark2);

                db.SaveChanges();
            }

            using (ApplicationContext3 db = new ApplicationContext3())
            {
                // получаем пользователей
                var mech = db.Mech3
                    .Include(u => u.Corpus3) // добавляем данные по компаниям
                    .ThenInclude(comp => comp!.Corporation2) // к компании добавляем страну 
                    .ThenInclude(count => count!.Weapon) // к стране добавляем столицу
                    .Include(u => u.Status) // добавляем данные по должностям
                    .ToList();
                foreach (var mechas in mech)
                {
                    Console.WriteLine($"{mechas.Model} - {mechas.Status?.Name}");
                    Console.WriteLine(
                        $"{mechas.Corpus3?.Name} - {mechas.Corpus3?.Corporation2?.Name} - {mechas.Corpus3?.Corporation2?.Weapon?.WeaponType}");
                    Console.WriteLine("----------------------"); // для красоты
                }
            }
        }

        private static void ThenInclude()
        {
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                MechCore Aetherium = new MechCore { Name = "Этериум" };
                MechCore Celtec = new MechCore { Name = "Кельтек" };
                db.Core.AddRange(Aetherium, Celtec);

                // добавляем начальные данные
                Corpus2 Standart = new Corpus2 { Name = "Стандарт", Core = Aetherium };
                Corpus2 Transformer = new Corpus2 { Name = "Трансформер", Core = Celtec };
                db.Corpus.AddRange(Standart, Transformer);


                Mech2 Enigma = new Mech2 { Name = "Энигма", Corpus = Standart };
                Mech2 Archont = new Mech2 { Name = "Архонт", Corpus = Transformer };
                Mech2 Bitum = new Mech2 { Name = "Битум", Corpus = Standart };
                Mech2 mark2 = new Mech2 { Name = "Марк 2", Corpus = Transformer };
                db.Mech.AddRange(Enigma, Archont, Bitum, mark2);

                db.SaveChanges();
            }

// получение данных
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                // получаем пользователей
                var mech = db.Mech
                    .Include(u => u.Corpus) // подгружаем данные по компаниям
                    .ThenInclude(c => c!.Core) // к компаниям подгружаем данные по странам
                    .ToList();
                foreach (var mechas in mech)
                    Console.WriteLine($"{mechas.Name} - {mechas.Corpus?.Name} - {mechas.Corpus?.Core?.Name}");
            }
        }

        private static void EagerInclude()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Corpus classic = new Corpus { Name = "Стандарт" };
                Corpus transformer = new Corpus { Name = "Трансформер" };
                db.Corpus.AddRange(classic, transformer);

                Mech Enigma = new Mech { Name = "Энигма", Corpus = classic };
                Mech Archont = new Mech { Name = "Архонт", Corpus = transformer };
                Mech Bitum = new Mech { Name = "Битум", Corpus = transformer };
                Mech Mark2 = new Mech { Name = "Марк 2", Corpus = transformer };
                db.Mech.AddRange(Enigma, Archont, Bitum, Mark2);
                db.SaveChanges();
                var mech = db.Mech
                    .Include(u => u.Corpus) // добавляем данные по компаниям
                    .ToList();
                foreach (var user in mech)
                    Console.WriteLine($"{user.Name} - {user.Corpus?.Name}");
                var corpuses = db.Corpus
                    .Include(c => c.Mech) // добавляем данные по пользователям
                    .ToList();
                foreach (var corpus in corpuses)
                {
                    Console.WriteLine(corpus.Name);
                    // выводим сотрудников компании
                    foreach (var mechas in corpus.Mech)
                        Console.WriteLine(mechas.Name);
                    Console.WriteLine("----------------------"); // для красоты
                }
            }
        }

        private static void EagerWithAlreadyLoadedData()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем пользователей
                var mech = db.Mech
                    //.Include(u => u.Company)  // подгружаем данные по компаниям
                    .ToList();
                foreach (var mechas in mech)
                    Console.WriteLine($"{mechas.Name} - {mechas.Corpus?.Name}");
            }
        }

        private static void EagerLoad()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Corpus classic = new Corpus { Name = "Стандарт" };
                Corpus transformer = new Corpus { Name = "Трансформер" };
                db.Corpus.AddRange(classic, transformer);

                Mech Enigma = new Mech { Name = "Энигма", Corpus = classic };
                Mech Archont = new Mech { Name = "Архонт", Corpus = transformer };
                Mech Bitum = new Mech { Name = "Битум", Corpus = classic };
                Mech Mark2 = new Mech { Name = "Марк 2", Corpus = transformer };
                db.Mech.AddRange(Enigma, Archont, Bitum, Mark2);
                db.SaveChanges();

                var mech = db.Mech.ToList(); // метод Include не используется
                foreach (var mechas in mech)
                    Console.WriteLine($"{mechas.Name} - {mechas.Corpus?.Name}");
            }
        }

        private static void PreLoad()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // добавляем начальные данные
                Corpus classic = new Corpus { Name = "Стандартный" };
                Corpus transformer = new Corpus { Name = "Трансформер" };
                db.Corpus.AddRange(classic, transformer);

                Mech Enigma = new Mech { Name = "Энигма", Corpus = classic };
                Mech Archont = new Mech { Name = "Архонт", Corpus = transformer };
                Mech Bitum = new Mech { Name = "Битум", Corpus = classic };
                Mech Mark2 = new Mech { Name = "Марк 2", Corpus = transformer };
                db.Mech.AddRange(Enigma, Archont, Bitum, Mark2);

                db.SaveChanges();

                // получаем пользователей
                var mech = db.Mech
                    .Include(u => u.Corpus) // подгружаем данные по компаниям
                    .ToList();
                foreach (var mechas in mech)
                    Console.WriteLine($"{mechas.Name} - {mechas.Corpus?.Name}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBMS_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Добавление");
            Add();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Считывание");
            Read();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("обновление");
            Update();
            Read();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Удаление");
            Delete();
            Read();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("демонстрация один к одному");
            OneToOne();
            Read();
            Console.WriteLine("--------------------");
            Console.ReadLine();*/


            /*Console.WriteLine("Один ко многим");
            Add2OneToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Один ко многим - считывание");
            Read2OneToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Один ко многим - обновление");
            Update2OneToMany();
            Read2OneToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Один ко многим - удаление");
            Delete2OneToMany();
            Read2OneToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();*/

            /*Console.WriteLine("Многие ко многим");
            Add3ManyToMany();
            Read3ManyToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Многие ко многим - Обновление");
            Update3ManyToMany();
            Read3ManyToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();*/
            

            /*Console.WriteLine("Многие ко многим - внешние ключи");
            Add4ManyToMany();
            Read4ManyToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Многие ко многим - Обновление по внешним ключам");
            Read4ManyToMany();
            Read4_2ManyToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();*/

            Console.WriteLine("Многие ко многим - создание 3 БД");
            Add5ManyToMany();
            Read5ManyToMany();
            Console.WriteLine("--------------------");
            Console.ReadLine();
            Console.WriteLine("Многие ко многим - удаление");
            Delete5ManyToMany();
            Read5ManyToMany();


            Console.Read();
        }

        private static void Delete5ManyToMany()
        {
            using (ApplicationContext5 db = new ApplicationContext5())
            {
                // удаление курса у студента
                Pilot3 pilot = db.Pilot.Include(s => s.MechDifficult).FirstOrDefault(s => s.PilotType == "Классическое");
                Type3 type = db.Types.FirstOrDefault(c => c.TypeMech == "Страйдер");
                if (pilot != null && type != null)
                {
                    var mechDif = pilot.MechDifficult.FirstOrDefault(sc => sc.TypeID == type.Id);
                    pilot.MechDifficult.Remove(mechDif);
                    db.SaveChanges();
                }
            }
        }

        private static void Read5ManyToMany()
        {
            using (ApplicationContext5 db = new ApplicationContext5())
            {
                var types = db.Types.Include(c => c.MechDifficult)
                    .ThenInclude(sc => sc.Pilot)
                    .ToList();
                // выводим все курсы
                foreach (var c in types)
                {
                    Console.WriteLine($"\nТип: {c.TypeMech}");
                    // выводим всех студентов для данного кура
                    foreach (MechDifficult sc in c.MechDifficult)
                        Console.WriteLine($"Управление: {sc.Pilot?.PilotType}  Дата тестирования: {sc.TestDate.ToShortDateString()}");
                    Console.WriteLine("-------------------"); // для красоты
                }
            }
        }

        private static void Add5ManyToMany()
        {
            using (ApplicationContext5 db = new ApplicationContext5())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Pilot3 s1 = new Pilot3 { PilotType = "Классическое" };
                Pilot3 s2 = new Pilot3 { PilotType = "Соматическое" };
                Pilot3 s3 = new Pilot3 { PilotType = "Интегрированное" };
                db.Pilot.AddRange(s1, s2, s3);

                Type3 c1 = new Type3 { TypeMech = "Страйдер" };
                Type3 c2 = new Type3 { TypeMech = "Глайдер" };
                db.Types.AddRange(c1, c2);

                // добавляем к студентам курсы
                s1.MechDifficult.Add(new MechDifficult { Type = c1, Pilot = s1, TestDate = DateTime.Now });
                s2.MechDifficult.Add(new MechDifficult { Type = c1, Pilot = s2, TestDate = DateTime.Now });
                s2.MechDifficult.Add(new MechDifficult { Type = c2, Pilot = s2, TestDate = DateTime.Now });

                db.SaveChanges();
            }
        }

        private static void Read4_2ManyToMany()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                var types = db.Type.Include(c => c.Pilot).ToList();
                // выводим все курсы
                foreach (var type in types)
                {
                    Console.WriteLine($"Тип: {type.TypeMech}");
                    // выводим всех студентов для данного кура
                    foreach (var s in type.Testing)
                        Console.WriteLine(
                            $"Управление: {s.Pilot.Pilot}  Дата тестирования: {s.TestDate.ToShortDateString()}  Стабильность: {s.Mark}");
                    Console.WriteLine("-------------------");
                }
            }
        }

        private static void Read4ManyToMany()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                var types = db.Type.Include(c => c.Pilot).ToList();
                // выводим все курсы
                foreach (var type in types)
                {
                    Console.WriteLine($"Тип: {type.TypeMech}");
                    // выводим всех студентов для данного кура
                    foreach (Pilot2 s in type.Pilot)
                        Console.WriteLine($"Управление: {s.Pilot}");
                    Console.WriteLine("-------------------");
                }
            }
        }

        private static void Add4ManyToMany()
        {
            using (ApplicationContext4 db = new ApplicationContext4())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // создание и добавление моделей
                Pilot2 Somathic = new Pilot2 { Pilot = "Соматическое" };
                Pilot2 Standart = new Pilot2 { Pilot = "Стандартное" };
                Pilot2 Integrated = new Pilot2 { Pilot = "Интегрированное" };
                db.Pilot.AddRange(Somathic, Standart, Integrated);

                Type2 Strider = new Type2 { TypeMech = "Страйдер" };
                Type2 Glider = new Type2 { TypeMech = "Глайдер" };

                db.Type.AddRange(Strider, Glider);

                // добавляем к студентам курсы
                Standart.Testing.Add(new Testing { Type = Strider, TestDate = DateTime.Now });
                Standart.Type.Add(Glider);
                Somathic.Testing.Add(new Testing { Type = Strider, TestDate = DateTime.Now, Mark = 4 });
                Integrated.Testing.Add(new Testing { Type = Glider, TestDate = DateTime.Now });

                db.SaveChanges();
            }
        }

        private static void Update3ManyToMany()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                Pilot Somathic = db.Pilot.Include(s => s.Type).FirstOrDefault(s => s.Name == "Соматическое управление");
                Type Strider = db.Type.FirstOrDefault(c => c.TypeMech == "Страйдер");
                Type Glider = db.Type.FirstOrDefault(c => c.TypeMech == "Глайдер");
                if (Somathic != null && Strider != null && Glider != null)
                {
                    // удаление курса у студента
                    Somathic.Type.Remove(Strider);
                    // добавление нового курса студенту
                    Somathic.Type.Add(Glider);
                    db.SaveChanges();
                }
                Pilot pilot = db.Pilot.FirstOrDefault();
                db.Pilot.Remove(pilot);
                db.SaveChanges();
            }
        }

        private static void Read3ManyToMany()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                var types = db.Type.Include(c => c.Pilot).ToList();
                // выводим все курсы
                foreach (var type in types)
                {
                    Console.WriteLine($"Тип: {type.TypeMech}");
                    // выводим всех студентов для данного кура
                    foreach (Pilot s in type.Pilot)
                        Console.WriteLine($"Управление: {s.Name}");
                    Console.WriteLine("-------------------");
                }
            }
        }

        private static void Add3ManyToMany()
        {
            using (ApplicationContext3 db = new ApplicationContext3())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // создание и добавление моделей
                Pilot Standart = new Pilot { Name = "Обычное пилотирование" };
                Pilot Somathic = new Pilot { Name = "Соматическое подключение" };
                Pilot Integrated = new Pilot { Name = "Интегрированное управление" };
                db.Pilot.AddRange(Standart, Somathic, Integrated);

                Type Strider = new Type { TypeMech = "Страйдер" };
                Type Glider = new Type { TypeMech = "Глайдер" };
                db.Type.AddRange(Strider, Glider);

                // добавляем к студентам курсы
                Standart.Type.Add(Strider);
                Standart.Type.Add(Glider);
                Somathic.Type.Add(Strider);
                Integrated.Type.Add(Glider);
                Strider.Pilot.AddRange(new List<Pilot>() { Standart, Integrated });

                db.SaveChanges();
            }
        }

        private static void Delete2OneToMany()
        {
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                Mech2 mech1 = db.Mech.FirstOrDefault(p => p.Model == "Энигма");
                if (mech1 != null)
                {
                    db.Mech.Remove(mech1);
                    db.SaveChanges();
                }

                Corporation corp = db.Corporations.FirstOrDefault();
                if (corp != null)
                {
                    db.Corporations.Remove(corp);
                    db.SaveChanges();
                }
            }
        }

        private static void Update2OneToMany()
        {
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                // изменение имени пользователя
                Mech2 mech1 = db.Mech.FirstOrDefault(p => p.Model == "Архонт");
                if (mech1 != null)
                {
                    mech1.Model = "Битум";
                    db.SaveChanges();
                }

                // изменение названия компании
                Corporation corp = db.Corporations.FirstOrDefault(p => p.Name == "Стилхарт");
                if (corp != null)
                {
                    corp.Name = "BlackIron";
                    db.SaveChanges();
                }

                // смена компании сотрудника
                Mech2 user2 = db.Mech.FirstOrDefault(p => p.Model == "Энигма");
                if (user2 != null && corp != null)
                {
                    user2.Corporations = corp;
                    db.SaveChanges();
                }
            }
        }

        private static void Read2OneToMany()
        {
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                // вывод пользователей
                var mechas = db.Mech.Include(u => u.Corporations).ToList();
                foreach (Mech2 mech in mechas)
                    Console.WriteLine($"{mech.Model} - {mech.Corporations?.Name}");

                // вывод компаний
                var corps = db.Corporations.Include(c => c.Mech).ToList();
                foreach (Corporation corp in corps)
                {
                    Console.WriteLine($"\n Компания: {corp.Name}");
                    foreach (Mech2 mech in corp.Mech)
                    {
                        Console.WriteLine($"{mech.Model}");
                    }
                }
            }
        }

        private static void Add2OneToMany()
        {
            using (ApplicationContext2 db = new ApplicationContext2())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // создание и добавление моделей
                Corporation Steelheart = new Corporation { Name = "Стилхарт" };
                Corporation Ion = new Corporation { Name = "Айон" };
                db.Corporations.AddRange(Steelheart, Ion);

                Mech2 Enigma = new Mech2 { Model = "Энигма", Corporations = Steelheart };
                Mech2 Archont = new Mech2 { Model = "Архонт", Corporations = Steelheart };
                Mech2 Bitum = new Mech2 { Model = "Битум", Corporations = Ion };
                db.Mech.AddRange(Enigma, Archont, Bitum);
                db.SaveChanges();
            }
        }

        private static void OneToOne()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Mech mech1 = new Mech { Model = "Град-5", SerialID = "3" };
                Mech mech2 = new Mech { Model = "Град-4", SerialID = "1" };
                db.Mechas.AddRange(mech1, mech2);

                MechSystem sys1 = new MechSystem { Version = 2, Name = "Град", Mech = mech1 };
                MechSystem sys2 = new MechSystem { Version = 2, Name = "Град", Mech = mech2 };
                db.MechSys.AddRange(sys1, sys2);

                db.SaveChanges();
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                // получим данные
                foreach (var u in db.Mechas.Include(u => u.MechSys).ToList())
                {
                    Console.WriteLine($"Система: {u.MechSys?.Name} Версия: {u.MechSys?.Version}");
                    Console.WriteLine($"Модель: {u.Model}  Серия: {u.SerialID} \n");
                }
            }
        }

        private static void Delete()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // удаляем первый объект User
                Mech mech = db.Mechas.FirstOrDefault();
                if (mech != null)
                {
                    db.Mechas.Remove(mech);
                    db.SaveChanges();
                }

                // удаляем объект UserProfile c логином login2
                MechSystem sys = db.MechSys.FirstOrDefault(p => p.Mech.Model == "Битум mk.I");
                if (sys != null)
                {
                    db.MechSys.Remove(sys);
                    db.SaveChanges();
                }
            }
        }

        private static void Update()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Mech mech = db.Mechas.FirstOrDefault();
                // получаем первый объект User
                if (mech != null)
                {
                    mech.SerialID = "3";
                    db.SaveChanges();
                }

                // получаем объект UserProfile для пользователя с логином "login2"
                MechSystem system = db.MechSys.FirstOrDefault(p => p.Mech.Model == "Архонт-2");
                if (system != null)
                {
                    system.Name = "Битум mk.II";
                    db.SaveChanges();
                }
            }
        }

        private static void Read()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (Mech mech in db.Mechas.Include(u => u.MechSys).ToList())
                {
                    Console.WriteLine($"Система: {mech.MechSys?.Name} Версия: {mech.MechSys?.Version}");
                    Console.WriteLine($"Модель: {mech.Model}  Серия: {mech.SerialID} \n");
                }
            }
        }

        private static void Add()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Mech mech1 = new Mech { Model = "Энигма", SerialID = "1" };
                Mech mech2 = new Mech { Model = "Архонт-2", SerialID = "3" };
                db.Mechas.AddRange(mech1, mech2);

                MechSystem system1 = new MechSystem { Version = 2, Name = "Энигма", Mech = mech1 };
                MechSystem system2 = new MechSystem { Version = 7, Name = "Архонт", Mech = mech2 };
                db.MechSys.AddRange(system1, system2);

                db.SaveChanges();
            }
        }
    }
}
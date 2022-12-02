using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMech_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Что вы хотите?\n1 - добавить что-то\n2 - вывести что есть\n");
            int chose = Convert.ToInt32(Console.ReadLine());
            using (MechDB db = new MechDB())
            {
                Mech mech;

                if (chose == 1)
                {
                    Add(out mech);
                    Insert(db, mech);
                }
                else if (chose == 2) ReadDB(db);
            }
            Console.Read();
        }

        private static void ReadDB(MechDB db)
        {
            // получаем объекты из бд и выводим на консоль
            var mechas = db.Mechas;
            Console.WriteLine("Список объектов:");
            foreach (Mech machine in mechas)
            {
                Console.WriteLine("{0}.{1} \t {2} \t {3} \t {4} \t {5} \t {6}", machine.ID, machine.Model, machine.Armore, 
                    machine.Weapon, machine.Engine, machine.Type, machine.SerialID);
            }
        }

        private static void Insert(MechDB db, Mech mech)
        {
            // добавляем их в бд
            db.Mechas.Add(mech);
            db.SaveChanges();
            Console.WriteLine("Объекты успешно сохранены");
        }

        private static void Add(out Mech mech)
        {
            string model;
            Console.WriteLine("\nВведите модель\n->");
            model = Console.ReadLine();
            string armore;
            Console.WriteLine("\nВведите тип брони\n->");
            armore = Console.ReadLine();
            string weapon;
            Console.WriteLine("\nВведите вооружение\n->");
            weapon = Console.ReadLine();
            string engine;
            Console.WriteLine("\nВведите тип двигателя\n->");
            engine = Console.ReadLine();
            string type;
            Console.WriteLine("\nВведите тип корпуса\n->");
            type = Console.ReadLine();
            Console.WriteLine("\nВведите серию\n->");
            int serial = Convert.ToInt32(Console.ReadLine());
            mech = new Mech { Model = model, Armore = armore, Weapon = weapon, Engine = engine, Type = type, SerialID = serial };
        }
    }
}

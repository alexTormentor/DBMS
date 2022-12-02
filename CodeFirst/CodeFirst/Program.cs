using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Что вы хотите?\n1 - добавить что-то\n2 - вывести что есть\n");
            int chose = Convert.ToInt32(Console.ReadLine());
            using (UserContext db = new UserContext())
            {
                User user;

                if (chose == 1)
                {
                    Add(out user);
                    Insert(db, user);
                }
                else if (chose == 2) ReadDB(db);
            }
            Console.Read();
        }

        private static void ReadDB(UserContext db)
        {
            // получаем объекты из бд и выводим на консоль
            var users = db.Users;
            Console.WriteLine("Список объектов:");
            foreach (User u in users)
            {
                Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
            }
        }

        private static void Insert(UserContext db, User user)
        {
            // добавляем их в бд
            db.Users.Add(user);
            db.SaveChanges();
            Console.WriteLine("Объекты успешно сохранены");
        }

        private static void Add(out User user)
        {
            string name;
            Console.WriteLine("\nВведите имя\n->");
            name = Console.ReadLine();
            Console.WriteLine("\nВведите возраст\n->");
            int age = Convert.ToInt32(Console.ReadLine());
            // создаем два объекта User
            user = new User { Name = name, Age = age };
        }
    }
}

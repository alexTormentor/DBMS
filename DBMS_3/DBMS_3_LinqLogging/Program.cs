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
            using (ApplicationContext db = new ApplicationContext())
            {
                Mech user1 = new Mech { Model = "Tom", Age = 33 };
                Mech user2 = new Mech { Model = "Alice", Age = 26 };
 
                db.Mech.Add(user1);
                db.Mech.Add(user2);
                db.SaveChanges();
 
                var users = db.Mech.ToList();
                Console.WriteLine("Список пользователей:");
                foreach (Mech u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Model} - {u.Age}");
                }
            }

            Console.Read();
        }
    }
}
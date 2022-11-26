using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DbLib;

namespace DB_test
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            IDb db;
            if (args.Length > 0 && args[0] == "test")
            {
                db = new TestDb();
            } else
            {
                db = new Db();
            }
            
            Application.Run(new FormMenu(db));
        }
    }
}

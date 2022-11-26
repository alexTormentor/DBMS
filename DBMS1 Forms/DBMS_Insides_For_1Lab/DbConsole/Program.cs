using System;
using System.Collections.Generic;
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
            PrintMech(mech);

            Console.ReadKey();
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

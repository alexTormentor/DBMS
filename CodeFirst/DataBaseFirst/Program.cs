using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Lab1Entities db = new Lab1Entities())
            {
                var mechas = db.Mechas;
                foreach (Mecha mech in mechas)
                {
                    Console.WriteLine("{0}.{1}\t{2}\t{3}\t\t{4}\t{5}\t{6}", mech.ID, mech.Model, mech.ArmoreType, mech.WeaponType, 
                        mech.EngineType, mech.Type, mech.SerialID);
                }
                Console.ReadLine();
            }
        }
    }
}

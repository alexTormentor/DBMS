using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLib
{
    public class Core
    {
        public Core() { }

        public Core(string system, int power, int id = 0)
        {
            Id = id;
            MechSystem = system;
            Power = power;
        }

        public int Id { get; set; }
        public string MechSystem { get; set; }
        public int Power { get; set; }

        public override string ToString()
        {
            return $"{MechSystem} ({Power}р)";
        }
    }
}

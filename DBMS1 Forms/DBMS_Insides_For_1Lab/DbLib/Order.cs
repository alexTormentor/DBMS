using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLib
{
    public class Corpus
    {
        public Corpus() { }

        public Corpus(string model, string armore, string weapon, string engine, string type, int price)
        {
            Model = model;
            ArmoreType = armore;
            WeaponType = weapon;
            EngineType = engine;
            Type = type;
            Price = price;
        }

        public string Model { get; set; }
        public string ArmoreType { get; set; }
        public string WeaponType { get; set; }
        public string EngineType { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }
}

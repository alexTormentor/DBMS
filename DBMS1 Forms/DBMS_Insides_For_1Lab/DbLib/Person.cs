using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLib
{
    /// <summary>
    /// Класс человека из БД
    /// </summary>
    public class Mech
    {
        public Mech() {}

        public Mech(string model, string armore, string weapon, string engine, string type, int serial, int id = 0)
        {
            ID = id;
            Model = model;
            ArmoreType = armore;
            WeaponType = weapon;
            EngineType = engine;
            Type = type;
            SerialID = serial;
        }

        public int ID { get; set; }
        public string Model { get; set; }
        public string ArmoreType { get; set; }
        public string WeaponType { get; set; }
        public string EngineType { get; set; }
        public string Type { get; set; }
        public int SerialID { get; set; }

        public override string ToString()
        {
            return $"{Model} {ArmoreType} {WeaponType} {EngineType} {Type}({SerialID}р)";
        }
    }
}

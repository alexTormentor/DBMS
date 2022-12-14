using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLib;

namespace DB_test
{
    public class TestDb : IDb
    {
        private List<Mech> mech;
        int lastId;

        public TestDb()
        {
            mech = new List<Mech>()
            {
                new Mech("Гриди", "Полисталь", "Тахионный ускоритель", "Хайтек V3.4", "Шагоход", 1),
                new Mech("Игла-3", "Полисталь", "Ускоритель частиц", "Термоядерный", "Страйдер", 6),
            };

            lastId = 3;
        }

        public void AddMech(Mech mech)
        {
            mech.ID = lastId;
            lastId++;
        }

        public void Create(int mechId, int coreId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMech(int id)
        {
            int idx = mech.FindIndex(x => x.ID == id);
            mech.RemoveAt(idx);
        }

        public List<Corpus> GetCorpus()
        {
            throw new NotImplementedException();
        }

        public List<Mech> GetMech()
        {
            return mech.ToList();
        }

        public List<Core> GetCore(string searchQuery = "")
        {
            throw new NotImplementedException();
        }
    }
}

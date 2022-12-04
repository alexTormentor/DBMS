using System.Collections.Generic;

namespace DbLib
{
    /// <summary>
    /// Интерфейс работы с базой данных
    /// </summary>
    public interface IDb
    {
        void AddMech(Mech mech);
        void DeleteMech(int id);
        void Create(int mechId, int coreId);
        List<Mech> GetMech();
        List<Core> GetCore(string searchQuery = "");
        List<Corpus> GetCorpus();
    }
}
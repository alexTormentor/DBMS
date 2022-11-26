using System.Collections.Generic;

namespace DbLib
{
    /// <summary>
    /// Интерфейс работы с базой данных
    /// </summary>
    public interface IDb
    {
        /// <summary>
        /// Добавляет новую запись о человеке в базу
        /// </summary>
        void AddMech(Mech mech);

        /// <summary>
        /// Удаляет человека из базы
        /// </summary>
        /// <param name="id">ID человека</param>
        void DeleteMech(int id);

        /// <summary>
        /// Совершает заказ
        /// </summary>
        /// <param name="personId">Id покупателя</param>
        /// <param name="productId">Id товара</param>
        void Create(int mechId, int coreId);

        /// <summary>
        /// Возвращает список всех людей в базе
        /// </summary>
        List<Mech> GetMech();

        /// <summary>
        /// Ищет товары в базе данных
        /// </summary>
        /// <param name="searchQuery">Поисковый запрос</param>
        /// <returns></returns>
        List<Core> GetCore(string searchQuery = "");

        /// <summary>
        /// Возвращает список заказов
        /// </summary>
        /// <returns></returns>
        List<Corpus> GetCorpus();
    }
}
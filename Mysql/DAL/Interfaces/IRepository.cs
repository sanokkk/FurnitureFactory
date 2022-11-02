using System.Collections.Generic;

namespace Mysql.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Select();

        T Get(int id);

        void Delete(T entity);

        void Add(T entity);

        void Update(T entity);
    }
}

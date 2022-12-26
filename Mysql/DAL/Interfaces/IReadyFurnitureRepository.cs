using Mysql.Models;
using System.Collections.Generic;

namespace Mysql.DAL.Interfaces
{
    public interface IReadyFurnitureRepository: IRepository<readyComponent>
    {
        IEnumerable<readyComponent> GetByName(string name);
        IEnumerable<readyComponent> GetByFilters(string name="", int fiber=0, int component=0);

    }
}

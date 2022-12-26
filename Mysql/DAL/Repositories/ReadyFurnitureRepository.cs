using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class ReadyFurnitureRepository : IReadyFurnitureRepository
    {
        private readonly ApplicationDbContext _db;
        public ReadyFurnitureRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(readyComponent entity)
        {
            _db.readyComponents.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(readyComponent entity)
        {
            _db.readyComponents.Remove(entity);
            _db.SaveChanges();
        }

        public readyComponent Get(int id)
        {
            return _db.readyComponents.FirstOrDefault(x => x.id_readyFurniture == id);
        }

        public IEnumerable<readyComponent> GetByFilters(string name = "", int fiber = 0, int component = 0)
        {
            return _db.readyComponents.Where(x => x.name_readyFurniture.Contains(name)).Where(x => x.id_fiber == fiber).
                Where(x => x.id_component == component).ToList();
        }

        public IEnumerable<readyComponent> GetByName(string name)
        {
            return _db.readyComponents.Where(x => x.name_readyFurniture.Contains(name)).ToList();
        }

        public IEnumerable<readyComponent> Select()
        {
            return _db.readyComponents.ToList();
        }

        public void Update(readyComponent entity)
        {
            _db.readyComponents.Update(entity);
            _db.SaveChanges();
        }
    }
}

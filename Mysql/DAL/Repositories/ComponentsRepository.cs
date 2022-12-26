using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class ComponentsRepository : IComponentsRepository
    {
        private readonly ApplicationDbContext _db;
        public ComponentsRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(component entity)
        {
            _db.components.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(component entity)
        {
            _db.components.Remove(entity);
            _db.SaveChanges();
        }

        public component Get(int id)
        {
            return _db.components.FirstOrDefault(x => x.id_component == id);
        }

        public IEnumerable<component> Select()
        {
            return _db.components.ToList();
        }

        public void Update(component entity)
        {
            _db.components.Update(entity);
            _db.SaveChanges();
        }
    }
}

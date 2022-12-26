using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(production entity)
        {
            _db.production.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(production entity)
        {
            _db.production.Remove(entity);
            _db.SaveChanges();
        }

        public production Get(int id)
        {
            return _db.production.FirstOrDefault(x => x.id_plan == id);
        }

        public IEnumerable<production> Select()
        {
            return _db.production.ToList();
        }

        public void Update(production entity)
        {
            _db.production.Update(entity);
            _db.SaveChanges();
        }
    }
}

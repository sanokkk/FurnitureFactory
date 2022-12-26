using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class FiberRepository : IFiberRepository
    {
        private readonly ApplicationDbContext _db;
        public FiberRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(fiber entity)
        {
            _db.fiber.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(fiber entity)
        {
            _db.fiber.Remove(entity);
            _db.SaveChanges();
        }

        public fiber Get(int id)
        {
            var entity = _db.fiber.FirstOrDefault(x => x.id_fiber == id);
            return entity;
        }

        public IEnumerable<fiber> Select()
        {
            return _db.fiber.ToList();
        }


        public void Update(fiber entity)
        {

            _db.fiber.Update(entity);
            _db.SaveChanges();
        }
    }
}

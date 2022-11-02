using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _db;
        public TestRepository(ApplicationDbContext db)
        {
            _db=db;
        }
        public void Add(test entity)
        {
            _db.test.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(test entity)
        {
            _db.test.Remove(entity);
            _db.SaveChanges();
        }

        public test Get(int id)
        {
            var entity = _db.test.FirstOrDefault(x => x.id_test == id);
            return entity;
        }

        public IEnumerable<test> Select()
        {
            return _db.test.ToList();
        }


        public void Update(test entity)
        {
            
            _db.test.Update(entity);
            _db.SaveChanges();
        }
    }
}

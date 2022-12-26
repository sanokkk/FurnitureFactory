using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(employee entity)
        {
            _db.employees.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(employee entity)
        {
            _db.employees.Remove(entity);
            _db.SaveChanges();
        }

        public employee Get(int id)
        {
            var entity = _db.employees.FirstOrDefault(x => x.id_employee == id);
            return entity;
        }

        public IEnumerable<employee> Select()
        {
            return _db.employees.ToList();
        }


        public void Update(employee entity)
        {

            _db.employees.Update(entity);
            _db.SaveChanges();
        }
    }
}

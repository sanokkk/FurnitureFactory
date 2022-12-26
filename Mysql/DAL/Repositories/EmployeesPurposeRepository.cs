using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class EmployeesPurposeRepository : IEmployeesPurposeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeesPurposeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<employee_purpose> Select()
        {
            var response = _db.employees_purpose.ToList();
            return response;
        }

        #region Для классов, используемых для перечислений, только Select
        public void Add(employee_purpose entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(employee_purpose entity)
        {
            throw new System.NotImplementedException();
        }

        public employee_purpose Get(int id)
        {
            var response = _db.employees_purpose.FirstOrDefault(x => x.id_purpose == id);
            return response;
        }



        public void Update(employee_purpose entity)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}

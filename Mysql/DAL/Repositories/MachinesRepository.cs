using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class MachinesRepository : IMachinesRepository
    {
        private readonly ApplicationDbContext _db;
        public MachinesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(machine entity)
        {
            _db.machines.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(machine entity)
        {
            _db.machines.Remove(entity);
            _db.SaveChanges();
        }

        public machine Get(int id)
        {
            return _db.machines.FirstOrDefault(x => x.id_machine == id);
        }

        public IEnumerable<machine> Select()
        {
            return _db.machines.ToList();
        }

        public void Update(machine entity)
        {
            _db.machines.Update(entity);
            _db.SaveChanges();
        }
    }
}

using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class MachinesPurposeRepository : IMachinesPurposeRepository
    {
        private readonly ApplicationDbContext _db;
        public MachinesPurposeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(machinePurpose entity)
        {
            _db.machines_purpose.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(machinePurpose entity)
        {
            _db.machines_purpose.Remove(entity);
            _db.SaveChanges();
        }

        public machinePurpose Get(int id)
        {
            return _db.machines_purpose.FirstOrDefault(x => x.id_purpose == id);
        }

        public IEnumerable<machinePurpose> Select()
        {
            return _db.machines_purpose.ToList();
        }

        public void Update(machinePurpose entity)
        {
            _db.machines_purpose.Update(entity);
            _db.SaveChanges();
        }
    }
}

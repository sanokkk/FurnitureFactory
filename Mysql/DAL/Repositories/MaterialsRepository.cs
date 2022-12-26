using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private readonly ApplicationDbContext _db;
        public MaterialsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(material entity)
        {
            _db.materials.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(material entity)
        {
            _db.materials.Remove(entity);
            _db.SaveChanges();
        }

        public material Get(int id)
        {
            var entity = _db.materials.FirstOrDefault(x => x.id_material == id);
            return entity;
        }

        public IEnumerable<material> Select()
        {
            return _db.materials.ToList();
        }


        public void Update(material entity)
        {

            _db.materials.Update(entity);
            _db.SaveChanges();
        }
    }
}

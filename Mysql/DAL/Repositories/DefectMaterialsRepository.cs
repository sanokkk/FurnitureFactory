using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class DefectMaterialsRepository : IDefectMaterialsRepository
    {
        private readonly ApplicationDbContext _db;
        public DefectMaterialsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(defectMaterial entity)
        {
            _db.defectMaterials.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(defectMaterial entity)
        {
            _db.defectMaterials.Remove(entity);
            _db.SaveChanges();
        }

        public defectMaterial Get(int id)
        {
            var response = _db.defectMaterials.FirstOrDefault(x => x.id_defectMaterial == id);
            return response;
        }

        public IEnumerable<defectMaterial> Select()
        {
            var response = _db.defectMaterials.ToList();
            return response;
        }

        public void Update(defectMaterial entity)
        {
            _db.defectMaterials.Update(entity);
            _db.SaveChanges();
        }
    }
}

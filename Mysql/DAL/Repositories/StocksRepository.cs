using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mysql.DAL.Repositories
{
    public class StocksRepository : IStocksRepository
    {
        private readonly ApplicationDbContext _db;
        public StocksRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(stock entity)
        {
            _db.stocks.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(stock entity)
        {
            _db.stocks.Remove(entity);
            _db.SaveChanges();
        }

        public stock Get(int id)
        {
            return _db.stocks.FirstOrDefault(x => x.id_stock == id);
        }

        public IEnumerable<stock> Select()
        {
            return _db.stocks.ToList();
        }

        public void Update(stock entity)
        {
            _db.stocks.Update(entity);
            _db.SaveChanges();
        }
    }
}

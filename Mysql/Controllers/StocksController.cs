using Microsoft.AspNetCore.Mvc;
using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Linq;

namespace Mysql.Controllers
{
    public class StocksController: Controller
    {
        private readonly IStocksRepository _db;
        private readonly IReadyFurnitureRepository _rf;
        public StocksController(IStocksRepository db, IReadyFurnitureRepository rf)
        {
            _db = db;
            _rf = rf;
        }

        [HttpGet]
        public IActionResult Select(int pg = 1)
        {
            var response = _db.Select();

            #region Реализация пагинации
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            int recsCount = response.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = response.Skip(recSkip).Take(pager.PageSize).ToList();

            var rf = _rf.Select().ToList();
            this.ViewBag.Furniture = rf;

            this.ViewBag.Pager = pager;
            #endregion

            return View(data);
            //return View(response);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(stock entity)
        {
            if (ModelState.IsValid)
            {
                _db.Add(entity);
                return RedirectToAction("Select", "Stocks");
            }
            return View(entity);
        }

        public IActionResult Delete(int id)
        {
            var response = _db.Get(id);
            _db.Delete(response);
            return RedirectToAction("Select", "Stocks");
        }

        public IActionResult Update(int id)
        {
            var response = _db.Get(id);
            return View(response);

        }

        [HttpPost]
        public IActionResult Update(int id, stock entity)
        {
            if (ModelState.IsValid)
            {
                var response = _db.Get(id);
                response.stock_adress = entity.stock_adress;
                response.id_readyFurniture = entity.id_readyFurniture;

                _db.Update(response);
                return RedirectToAction("Select", "Stocks");
            }
            return View(entity);
        }

    }
}

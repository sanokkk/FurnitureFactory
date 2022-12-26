using Microsoft.AspNetCore.Mvc;
using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Linq;

namespace Mysql.Controllers
{
    public class FiberController : Controller
    {
        private readonly IFiberRepository _db;
        public FiberController(IFiberRepository db)
        {
            _db = db;
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
        public IActionResult Add(fiber entity)
        {
            _db.Add(entity);
            return RedirectToAction("Select", "Fiber");
        }

        public IActionResult Delete(int id)
        {
            var response = _db.Get(id);
            _db.Delete(response);
            return RedirectToAction("Select", "Fiber");
        }

        public IActionResult Update(int id)
        {
            var response = _db.Get(id);
            return View(response);

        }

        [HttpPost]
        public IActionResult Update(int id, fiber entity)
        {
            var response = _db.Get(id);
            response.name_fiber = entity.name_fiber;

            _db.Update(response);
            return RedirectToAction("Select", "Fiber");
        }
    }
}

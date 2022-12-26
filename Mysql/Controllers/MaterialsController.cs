using Microsoft.AspNetCore.Mvc;
using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Linq;

namespace Mysql.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly IMaterialsRepository _db;
        public MaterialsController(IMaterialsRepository db)
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
        public IActionResult Add(material entity)
        {
            _db.Add(entity);
            return RedirectToAction("Select", "Materials");
        }

        public IActionResult Delete(int id)
        {
            var response = _db.Get(id);
            _db.Delete(response);
            return RedirectToAction("Select", "Materials");
        }

        public IActionResult Update(int id)
        {
            var response = _db.Get(id);
            return View(response);

        }

        [HttpPost]
        public IActionResult Update(int id, material entity)
        {
            var response = _db.Get(id);
            response.name_material = entity.name_material;

            _db.Update(response);
            return RedirectToAction("Select", "Materials");
        }
    }
}

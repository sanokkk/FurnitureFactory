using Microsoft.AspNetCore.Mvc;
using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Linq;

namespace Mysql.Controllers
{
    public class ReadyFurnitureController: Controller
    {
        private readonly IReadyFurnitureRepository _db;
        private readonly IFiberRepository _fb;
        private readonly IComponentsRepository _cp;
        public ReadyFurnitureController(IReadyFurnitureRepository db, IFiberRepository fb, IComponentsRepository cp)
        {
            _db = db;
            _fb = fb;
            _cp = cp;
        }

        public IActionResult Select(int pg = 1, int idFiber=11)
        {
            var response = _db.Select();
            //реализовать либо модальное окно, либо отдельную страницу для расширенного поиска,
            //где будут фильтры, которыми будут отбираться объекты
            

            #region Реализация пагинации
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            var response2 = _db.Get(8);
            int recsCount = response.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = response.Skip(recSkip).Take(pager.PageSize).ToList();

            var cp = _cp.Select().ToList();
            var fb = _fb.Select().ToList();

            this.ViewBag.Component = cp;
            this.ViewBag.Fiber = fb;

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
        public IActionResult Add(readyComponent entity)
        {
            if (ModelState.IsValid)
            {
                _db.Add(entity);
                return RedirectToAction("Select", "ReadyFurniture");
            }
            return View(entity);
            
        }

        public IActionResult Delete(int id)
        {
            var response = _db.Get(id);
            _db.Delete(response);
            return RedirectToAction("Select", "ReadyFurniture");
        }

        public IActionResult Update(int id)
        {
            var response = _db.Get(id);
            return View(response);

        }

        [HttpPost]
        public IActionResult Update(int id, readyComponent entity)
        {
            if (ModelState.IsValid)
            {
                var response = _db.Get(id);
                response.name_readyFurniture = entity.name_readyFurniture;
                response.id_component = entity.id_component;
                response.id_fiber = entity.id_fiber;

                _db.Update(response);
                return RedirectToAction("Select", "ReadyFurniture");
            }
            return View(entity);
            
        }


        

       

        public IActionResult GetByName(string name, int pg = 1)
        {
            var response = _db.GetByName(name).ToList();
            #region Реализация пагинации
            const int pageSize = 5;
            if (pg < 1)
                pg = 1;

            var response2 = _db.Get(8);
            int recsCount = response.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = response.Skip(recSkip).Take(pager.PageSize).ToList();

            var cp = _cp.Select().ToList();
            var fb = _fb.Select().ToList();

            this.ViewBag.Component = cp;
            this.ViewBag.Fiber = fb;

            this.ViewBag.Pager = pager;
            #endregion

            return View(data);
            //return View(response);
        }
    }
}

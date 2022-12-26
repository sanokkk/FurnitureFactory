using Microsoft.AspNetCore.Mvc;
using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Linq;

namespace Mysql.Controllers
{
    public class MachinesController: Controller
    {
        private readonly IMachinesRepository _db;
        private readonly IMachinesPurposeRepository _purpose;
        public MachinesController(IMachinesRepository db, IMachinesPurposeRepository purpose)
        {
            _db = db;
            _purpose = purpose;
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

            var purpose = _purpose.Select().ToList();
            this.ViewBag.Purpose = purpose;

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
        public IActionResult Add(machine entity)
        {
            _db.Add(entity);
            return RedirectToAction("Select", "Machines");
        }

        public IActionResult Delete(int id)
        {
            var response = _db.Get(id);
            _db.Delete(response);
            return RedirectToAction("Select", "Machines");
        }

        public IActionResult Update(int id)
        {
            var response = _db.Get(id);
            return View(response);

        }

        [HttpPost]
        public IActionResult Update(int id, machine entity)
        {
            var response = _db.Get(id);
            response.id_purpose = entity.id_purpose;

            _db.Update(response);
            return RedirectToAction("Select", "Machines");
        }


    }
}

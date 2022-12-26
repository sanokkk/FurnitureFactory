using Microsoft.AspNetCore.Mvc;
using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Linq;

namespace Mysql.Controllers
{
    public class ProductionController: Controller
    {
        private readonly IProductionRepository _db;
        private readonly IMachinesRepository _mc;
        private readonly IStocksRepository _st;
        private readonly IEmployeesRepository _rp;
        private readonly IMachinesPurposeRepository _pr;
        public ProductionController(IProductionRepository db, IMachinesRepository mc, IStocksRepository st, IEmployeesRepository rp, IMachinesPurposeRepository pr)
        {
            _db = db;
            _mc = mc;
            _st = st;
            _rp = rp;
            _pr = pr;
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

            var mc = _mc.Select().ToList();
            var st = _st.Select().ToList();
            var rp = _rp.Select().ToList();
            var pr = _pr.Select().ToList();

            this.ViewBag.Machine = mc;
            this.ViewBag.Stock = st;
            this.ViewBag.Employees = rp;
            this.ViewBag.Purpose = pr;

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
        public IActionResult Add(production entity)
        {
            _db.Add(entity);
            return RedirectToAction("Select", "Production");
        }

        public IActionResult Delete(int id)
        {
            var response = _db.Get(id);
            _db.Delete(response);
            return RedirectToAction("Select", "Production");
        }

        public IActionResult Update(int id)
        {
            var response = _db.Get(id);
            return View(response);

        }

        [HttpPost]
        public IActionResult Update(int id, production entity)
        {
            var response = _db.Get(id);
            response.id_machine = entity.id_machine;
            response.id_stock = entity.id_stock;
            response.id_employee = entity.id_employee;

            _db.Update(response);
            return RedirectToAction("Select", "Production");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Linq;

namespace Mysql.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesRepository _db;
        private readonly IEmployeesPurposeRepository _purposeRepository;
        public EmployeesController(IEmployeesRepository db, IEmployeesPurposeRepository purposeRepository)
        {
            _db = db;
            _purposeRepository = purposeRepository;
        }

        [HttpGet]
        public IActionResult Select(int pg=1)
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
            var purpose = _purposeRepository.Select().ToList();
            this.ViewBag.Purpose = purpose;
            #endregion

            return View(data);
            //return View(response);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(employee entity)
        {
            _db.Add(entity);
            return RedirectToAction("Select", "Employees");
        }

        public IActionResult Delete(int id)
        {
            var response = _db.Get(id);
            _db.Delete(response);
            return RedirectToAction("Select", "Employees");
        }

        public IActionResult Update(int id)
        {
            var response = _db.Get(id);
            return View(response);

        }

        [HttpPost]
        public IActionResult Update(int id, employee entity)
        {
            var response = _db.Get(id);
            response.name = entity.name;
            response.id_purpose = entity.id_purpose;

            _db.Update(response);
            return RedirectToAction("Select", "Employees");
        }
    }
}

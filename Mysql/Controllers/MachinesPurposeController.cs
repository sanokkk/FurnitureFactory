using Microsoft.AspNetCore.Mvc;
using Mysql.DAL.Interfaces;
using Mysql.Models;
using System.Linq;

namespace Mysql.Controllers
{
    public class MachinesPurposeController : Controller
    {
        private readonly IMachinesPurposeRepository _db;
        public MachinesPurposeController(IMachinesPurposeRepository db)
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
    }
}

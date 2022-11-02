using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mysql.DAL;
using Mysql.DAL.Interfaces;
using Mysql.Models;

namespace Mysql.Controllers
{
    public class TestController: Controller
    {
        private readonly ITestRepository _db;

        public TestController(ITestRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Select()
        {
            var response = _db.Select();
            return View(response);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]        
        
        public IActionResult Add(test entity)
        {
            _db.Add(entity);
            return RedirectToAction("Select", "Test");
        }



        
        public IActionResult Delete(int id)
        {
            var response = _db.Get(id);
            _db.Delete(response);
            return RedirectToAction("Select", "Test");
        }

        public IActionResult Update(int id)
        {
            var response = _db.Get(id);
            return View(response);
            
        }



        [HttpPost]
        public IActionResult Update(int id,test entity)
        {
            var response = _db.Get(id);
            response.name = entity.name;
            
            _db.Update(response);
            return RedirectToAction("Select", "Test");
        }

    }
}
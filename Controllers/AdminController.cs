using EggSplorer.Data;
using EggSplorer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EggSplorer.Controllers
{
    public class AdminController : Controller
    {
        private readonly EggsplorerContext _context;

        public AdminController(EggsplorerContext context)
        {
            _context = context;
        }

        public IActionResult index()
        {
            return View();
        }

        //-------------------------------------------------------------------

        public IActionResult bIndex()
        {
            var mymodel = _context.Orders.ToList();
            return View(mymodel);
        }
        public IActionResult bEdit()
        {
            return View();
        }
        public IActionResult bDelete()
        {
            return View();
        }

        //-------------------------------------------------------------------

        public IActionResult gIndex()
        {
            var mymodel = _context.Users.ToList();
            return View(mymodel);
        }
        public IActionResult gCreate()
        {
            return View();
        }
        public IActionResult gEdit()
        {
            return View();
        }
        public IActionResult gDelete()
        {
            return View();
        }

        //-------------------------------------------------------------------

        public IActionResult pIndex()
        {
            var mymodel = _context.Products.ToList();
            return View(mymodel);
        }
        public IActionResult pCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult pCreate(Products product)
        {
            if(ModelState.IsValid)
            {
                // Add the order to the database
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult pEdit(int id)
        {
            Products product = _context.Products.Where(p => p.Id == id).First();
            return View(product);
        }
        [HttpPost]
        public IActionResult pDelete(int id)
        {
            Products product = _context.Products.Where(p => p.Id == id).First();
            return View(product);
        }
    }
}

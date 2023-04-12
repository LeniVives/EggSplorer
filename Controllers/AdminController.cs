using EggSplorer.Data;
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
            return View();
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
        public IActionResult pEdit()
        {
            return View();
        }
        public IActionResult pDelete()
        {
            return View();
        }
    }
}

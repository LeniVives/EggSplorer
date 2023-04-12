using Microsoft.AspNetCore.Mvc;

namespace EggSplorer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult index()
        {
            return View();
        }

        //-------------------------------------------------------------------

        public IActionResult bIndex()
        {
            return View();
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
            return View();
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

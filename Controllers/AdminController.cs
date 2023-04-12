using Microsoft.AspNetCore.Mvc;

namespace EggSplorer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult bEdit()
        {
            return View();
        }
        public IActionResult bDelete()
        {
            return View();
        }

        //-------------------------------------------------------------------

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

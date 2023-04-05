using Microsoft.AspNetCore.Mvc;

namespace EggSplorer.Controllers
{
    public class BestelController : Controller
    {
        public IActionResult Winkelmandje()
        {
            return View();
        }
    }
}

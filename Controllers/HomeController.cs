using EggSplorer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EggSplorer.Data;

namespace EggSplorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Producten()
        {
            EggSplorer.Data.EggsplorerContext _content = new EggSplorer.Data.EggsplorerContext();

            return View("Producten", _content);
        }
        public IActionResult Info()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registratie()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
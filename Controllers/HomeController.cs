using EggSplorer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EggSplorer.Data;
using Microsoft.EntityFrameworkCore;

namespace EggSplorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EggsplorerContext _context;

        public HomeController(ILogger<HomeController> logger,EggsplorerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Producten(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            var products = from s in _context.Products
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    products = products.OrderBy(s => s.ProductPrice);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.ProductPrice);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            return View(await products.AsNoTracking().ToListAsync());
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
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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Producten()
        //{
        //    var context = new EggsplorerContext();
        //    var products = context.Products.OrderBy(p => p.Name).ToList();
        //    return View(products);
        //}
        //[HttpPost]
        //public IActionResult Producten(string sorting)
        //{
        //    var context = new EggsplorerContext();

        //    if (sorting == "sortname")
        //    {
        //        var productsdec = context.Products.OrderByDescending(p => p.Name).ToList();
        //        return View(productsdec);
        //    }

        //    var products = context.Products.OrderBy(p => p.Name).ToList();
        //    return View(products);
        //}

        public async Task<IActionResult> Producten(string sortOrder)
        {
            var _context = new EggsplorerContext();
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
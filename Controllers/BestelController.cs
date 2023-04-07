using EggSplorer.Data;
using EggSplorer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EggSplorer.Controllers
{
    public class BestelController : Controller
    {
        public IActionResult Winkelmandje()
        {
            return View();
        }

        public IActionResult Index()
        {
            var _context = new EggsplorerContext();
            var products = from s in _context.Products
                           select s;
            products = products.OrderBy(s => s.Name);
            return View(products);
        }
    }
}

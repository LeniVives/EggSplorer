using EggSplorer.Data;
using EggSplorer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EggSplorer.Controllers
{
    public class BestelController : Controller
    {
        public IActionResult Winkelmandje()
        {
            return View();
        }

        public async Task<IActionResult> Index(string sortOrder)
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
    }
}

using EggSplorer.Data;
using EggSplorer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace EggSplorer.Controllers
{
    public class BestelController : Controller
    {
        private readonly EggsplorerContext _context;

        public BestelController(EggsplorerContext context)
        {
            _context = context;
        }

        //index with orderviewmodel
        public IActionResult Index()
        {
            var mymodel = _context.Products.ToList();
            return View(mymodel);
        }
        [HttpPost]
        public IActionResult Index(List<MiniOrderDetail> info)
        {
			if (!ModelState.IsValid)
            {
				var mymodel = _context.Products.ToList();
				return View(mymodel);
            }

			var temp = 0;
			foreach (var item in info)
			{
				temp += item.Quantity;
			}
			if (temp <= 0)
			{
				var mymodel = _context.Products.ToList();
				return View(mymodel);
			}

            dynamic mymodel2 = new ExpandoObject();
            mymodel2.Products = _context.Products.ToList();
            mymodel2.Details = info;


            return View("Winkelmandje", mymodel2);
		}


        //[HttpPost]
        //public ActionResult AddOrderDetail(OrderViewModel model, int amount)
        //{
        //    var product = _context.Products.Find(model.OrderDetails.ProductId);
        //    var order = _context.Orders.Find(model.OrderDetails.OrderId);

        //    var orderDetail = new OrderDetails
        //    {
        //        Product = product,
        //        Order = order,
        //        Quantity = amount
        //    };

        //    _context.OrderDetails.Add(orderDetail);
        //    _context.SaveChanges();

        //    var refererUrl = Request.Headers["Referer"].ToString();
        //    return Redirect(refererUrl);
        //}


        public IActionResult Winkelmandje()
        {
            return View();
        }
    }
}

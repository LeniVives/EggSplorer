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

            var order = new Orders
            {
                OrderPlaced = DateTime.Now,
                UserID = 0,
                OrderDetail = new List<OrderDetails>()
            };

            var temp = 0;

            foreach (var item in info)
            {
                temp += item.Quantity;

                //make new orderDetails
                var newOrderDetail = new OrderDetails
                {
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };

                // Add the new order item to the order
                order.OrderDetail.Add(newOrderDetail);
            }

            // Add the order to the database
            _context.Orders.Add(order);
            _context.SaveChanges();

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


        public IActionResult Winkelmandje()
        {
            return View();
        }

        public IActionResult Thankyou()
        {
            return View();
        }
    }
}

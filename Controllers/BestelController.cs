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
        public IActionResult Winkelmandje(List<MiniOrderDetail> info)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            info = info.Where(i => i.Quantity > 0).ToList();

            if (info.Count == 0)
            {
                return RedirectToAction("Index");
            }

            dynamic mymodel = new ExpandoObject();
            mymodel.Products = _context.Products.ToList();
            mymodel.Details = info;

            return View(mymodel);
        }

        [HttpPost]
        public IActionResult Thankyou(List<MiniOrderDetail> info)
        {
            var order = new Orders
            {
                OrderPlaced = DateTime.Now,
                UserID = 0,
                OrderDetail = new List<OrderDetails>(),
                //OrderTotal = info.Sum(i => i.Quantity * _context.Products.Find(i.ProductId).ProductPrice)
                OrderTotal = 0
            };

            decimal totalprice = 0;

            foreach (var item in info)
            {
                //make new orderDetails
                var newOrderDetail = new OrderDetails
                {
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                totalprice += item.Quantity * 
                    _context.Products.Where(p => p.Id == item.ProductId).First().ProductPrice;

                // Add the new order item to the order
                order.OrderDetail.Add(newOrderDetail);
            }
            order.OrderTotal = totalprice;

            // Add the order to the database
            _context.Orders.Add(order);
            _context.SaveChanges();

            return View();
        }
    }
}

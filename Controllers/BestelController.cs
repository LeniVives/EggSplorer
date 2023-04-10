using EggSplorer.Data;
using EggSplorer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
            System.Diagnostics.Debug.WriteLine("Index");
            var orderViewModel = new OrderViewModel
            {
                OrderDetails = new OrderDetails(
                    quantity: 0,
                    orderId: 0,
                    order: null!,
                    productId: 0,
                    product: null!

                    
                    ),
                Products = _context.Products.ToList()
            };
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel orderViewModel)
        {
            System.Diagnostics.Debug.WriteLine("HttpPost");
            System.Diagnostics.Debug.WriteLine(ModelState);

            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("ModelState.IsValid");
                var order = new Orders();
                _context.Orders.Add(order);
                _context.SaveChanges();

                orderViewModel.OrderDetails.OrderId = order.Id;
                _context.OrderDetails.Add(orderViewModel.OrderDetails);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(orderViewModel);
        }
    }
}

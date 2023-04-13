using EggSplorer.Data;
using EggSplorer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace EggSplorer.Controllers
{
    public class AdminController : Controller
    {
        private readonly EggsplorerContext _context;

        public AdminController(EggsplorerContext context)
        {
            _context = context;
        }

        public IActionResult index()
        {
            return View();
        }

        //-------------------------------------------------------------------

        public IActionResult bIndex()
        {
            var orderDetails = _context.OrderDetails.ToList();
            var orders = _context.Orders.Include(o => o.User).ToList();
            var products = _context.Products.ToList();
            var productNames = products.ToDictionary(p => p.Id, p => p.Name);
            var productPrices = products.ToDictionary(p => p.Id, p => p.ProductPrice);
            decimal totalPrice = 0;

            dynamic mymodel = new ExpandoObject();
            mymodel.Products = products;
            mymodel.ProductNames = productNames;
            mymodel.ProductPrices = productPrices;

            mymodel.Orders = orders;
            mymodel.OrderDetails = orderDetails;

            foreach (var order in orders)
            {
                decimal orderPrice = 0;
                foreach (var detail in orderDetails)
                {
                    if (detail.OrderId == order.Id)
                    {
                        decimal productPrice = detail.Quantity * detail.Product.ProductPrice;
                        orderPrice += productPrice;
                        totalPrice += productPrice;
                    }
                }
            }
            mymodel.TotalPrice = totalPrice;

            return View("bIndex", mymodel);
        }



        public IActionResult bEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult bDelete(int[] selectedOrders)
        {
            if (selectedOrders != null)
            {
                foreach (var orderId in selectedOrders)
                {
                    var order = _context.Orders.Find(orderId);
                    if (order != null)
                    {
                        var orderDetails = _context.OrderDetails.Where(od => od.OrderId == orderId);
                        foreach (var orderDetail in orderDetails)
                        {
                            _context.OrderDetails.Remove(orderDetail);
                        }
                        _context.Orders.Remove(order);
                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("bIndex");
        }



        //-------------------------------------------------------------------

        public IActionResult gIndex()
        {
            var mymodel = _context.Users.ToList();
            return View(mymodel);
        }
        public IActionResult gCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult gCreate(Users user)
        {
            if (ModelState.IsValid)
            {
                // Add the order to the database
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("gIndex");
            }
            return View();
        }
        [HttpPost]
        public IActionResult gEdit(int id)
        {
            Users user = _context.Users.Where(p => p.ID == id).First();
            return View(user);
        }
        [HttpPost]
        public IActionResult gEditcomplete(Users user)
        {
            if (ModelState.IsValid)
            {
                var toupdate = _context.Users.Where(p => p.ID == user.ID).First();

                toupdate.FirstName = user.FirstName;
                toupdate.LastName = user.LastName;
                toupdate.PhoneNumber = user.PhoneNumber;
                toupdate.Email = user.Email;
                toupdate.Password = user.Password;
                toupdate.IsAdmin = user.IsAdmin;
                toupdate.IsApproved = user.IsApproved;
                _context.SaveChanges();
            }

            return RedirectToAction("gIndex");
        }
        public IActionResult gDelete()
        {
            return View();
        }

        //-------------------------------------------------------------------

        public IActionResult pIndex()
        {
            var mymodel = _context.Products.ToList();
            return View(mymodel);
        }
        public IActionResult pCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult pCreate(Products product)
        {
            if(ModelState.IsValid)
            {
                // Add the order to the database
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("pIndex");
            }
            return View();
        }
        [HttpPost]
        public IActionResult pEdit(int id)
        {
            Products product = _context.Products.Where(p => p.Id == id).First();
            return View(product);
        }
        [HttpPost]
        public IActionResult pEditcomplete(Products product)
        {
            if(ModelState.IsValid)
            {
                var toupdate = _context.Products.Where(p => p.Id == product.Id).First();

                toupdate.Name = product.Name;
                toupdate.Description = product.Description;
                toupdate.ProductPrice = product.ProductPrice;
                _context.SaveChanges();
            }

            return RedirectToAction("pIndex");
        }
        [HttpPost]
        public IActionResult pDelete(int[] selectedProducts)
        {
            if (selectedProducts == null)
            {
                return RedirectToAction("pIndex");
            }
            var tobedeleted = new List<Products>();
            foreach (var productid in selectedProducts)
            {
                tobedeleted.Add(_context.Products.Where(p => p.Id == productid).First());
            }
            return View(tobedeleted);
        }
        [HttpPost]
        public IActionResult pDeletecomplete(int[] deleteus)
        {
            foreach (var productid in deleteus)
            {
                var product = _context.Products.Where(p => p.Id == productid).First();
                if (product != null)
                {
                    _context.Products.Remove(product);
                }
            }
            _context.SaveChanges();

            return RedirectToAction("pIndex");
        }
    }
}

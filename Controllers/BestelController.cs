﻿using EggSplorer.Data;
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
            var orderViewModel = new OrderViewModel
            {
                OrderDetails = new OrderDetails(),
                Products = _context.Products.ToList()
            };
            return View(orderViewModel);
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

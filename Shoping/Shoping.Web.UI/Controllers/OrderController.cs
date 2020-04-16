using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoping.Domain.Contract.Repositories;
using Shoping.Domain.Entities;

namespace Shoping.Web.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository repository;
        private readonly Cart cart;

        public OrderController(IOrderRepository order ,Cart cart )
        {
            this.repository = order;
            this.cart = cart;
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count()==0)
            {
                ModelState.AddModelError("", "امکان ثبت سفارش خالی وجود ندارد");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                TempData["OrderId"] = order.OrderID;
                TempData["Price"] = order.Lines.Sum(c => c.Product.Price * c.Quantity);

                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
          
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}
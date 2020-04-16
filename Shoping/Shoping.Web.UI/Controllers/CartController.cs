using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoping.Domain.Contract.Repositories;
using Shoping.Domain.Entities;
using Shoping.Web.UI.Infrastructures;

namespace Shoping.Web.UI.Controllers
{
    public class CartController : Controller
    {

        private IProductRepository rep;
        private  Cart _cart;

        public CartController(IProductRepository rep,Cart cart)
        {
            this.rep = rep;
            _cart = cart;
        }
        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(_cart);
        }

        public IActionResult AddToCart(int productid,string returnUrl)
        {
            Product product = rep.GetById(productid);
            if (product !=null)
            {
                
                _cart.AddItem(product, 1);
             
            }
            return RedirectToAction("index", new { returnUrl });
        }

        public IActionResult RemoveFromCart(int productid, string returnUrl)
        {
            Product product = rep.GetById(productid);
            if (product !=null)
            {
             
                _cart.RemoveLine(product);
               
            }
            return RedirectToAction("index", new { returnUrl });
        }

        //private Cart GetCart()
        //{
        //    Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        //    return cart;
        //}

        //private void SaveCart(Cart cart)
        //{
        //    HttpContext.Session.SetJson("Cart",cart);
        //}
    }
}
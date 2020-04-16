using Microsoft.AspNetCore.Mvc;
using Shoping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Components
{
    public class CartViewComponent: ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart =cart;
        }
        public IViewComponentResult Invoke()
        {
            return View("View", _cart);

        }
    }
}

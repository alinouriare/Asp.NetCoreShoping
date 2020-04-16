using Microsoft.AspNetCore.Mvc;
using Shoping.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoping.Web.UI.Components
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly IProductRepository rep;

        public CategoryViewComponent(IProductRepository rep)
        {
            this.rep = rep;
        }
        public IViewComponentResult Invoke()
        {
            return View("View",rep.GetAllCategories());
        }
    }
}

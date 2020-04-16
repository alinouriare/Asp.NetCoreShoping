using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoping.DAL.EF;
using Shoping.DAL.EF.Repositories;

using Shoping.Domain.Contract.Repositories;
using Shoping.Web.UI.Models;

namespace Shoping.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private int pageSize = 6;

        private readonly IProductRepository _rep;
        public HomeController(IProductRepository rep)
        {
            _rep = rep;
        }
        public IActionResult Index(string category, int page = 1)
        {
            HomeViewModel model = new HomeViewModel();
            model.Result = _rep.GetPagedData(category, page, pageSize);
            model.Category = category;

            return View(model);


        }

        public IActionResult Select2()
        {
            return View();
        }

        public IActionResult Find(string term)
        {
            var result = _rep.Find(term);

            return Json(new { results= result.Select(c => new { Id = c.ProductID, text = c.Name }) });
        }

        public IActionResult Find2(string q)
        {
          
            var item = _rep.Find(q);
            return Json(new { total_count= 10, incomplete_results=false, items =item});
        }


      public IActionResult Search(string category)
        {
            var result = _rep.Search(category);
            return Json(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoping.Domain.Contract.Repositories;
using Shoping.Domain.Entities;
using Shoping.Web.UI.Models;

namespace Shoping.Web.UI.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        IHostingEnvironment _env;
        public ProductController(IProductRepository productRepository,IHostingEnvironment env)
        {
            _env = env;
            _productRepository = productRepository;
        }

        //public IActionResult Index()
        //{
        //    return View(_productRepository.GetAll());
        //}


        public IActionResult Index(string category, int page = 1)
        {
            HomeViewModel model = new HomeViewModel();
            model.Result = _productRepository.GetPagedData(category, page, 6);
            model.Category = category;

            return View(model);


        }
        public IActionResult Create()
        {

            return View("Edit", new Product());
        }

        public IActionResult Edit(int id)
        {
            return View(_productRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product product,IFormFile files)
        {
           
            if (files?.Length>0)
            {
                string ext = System.IO.Path.GetExtension(files.FileName);

                if (ext.ToLower() !=".jpg")
                {
                    return Content( "Only images are allowed");

                }
                else
                {
                  
                    var nameFile = DateTime.Now.Ticks + ext;


                    string path = $"{_env.WebRootPath}\\images\\{nameFile}";


                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        files.CopyToAsync(stream).Wait();
                    }
                    product.ImageUrl = nameFile;
                }

               
            }

            if (ModelState.IsValid)
            {
                _productRepository.SaveProduct(product);
                TempData["message"] = $"{product.Name} ذخیره شد";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }

        }
        public IActionResult Delete(int id)
        {
            _productRepository.DeleteProduct(id);
            TempData["message"] = $"حذف با موفقیت انجام شد";
            return RedirectToAction("Index");
        }
    }
}
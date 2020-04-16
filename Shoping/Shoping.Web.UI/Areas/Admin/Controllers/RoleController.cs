using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shoping.Web.UI.Areas.Admin.Models;
using Shoping.Web.UI.Areas.Admin.Models.Identity;
using Shoping.Web.UI.Models.Identity;

namespace Shoping.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _role;

        public RoleController(RoleManager<AppRole> role)
        {
            _role = role;
        }
        public IActionResult Index()
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();

            nodes.Add(new TreeViewNode
            {

                id = "8005b0dc-ae8f-478d-9f97-b2851d9511c5",
                parent = "#",
                text = "اجزای سیستم"

            });
            foreach (AppRole subnode in _role.Roles.Where(r => r.RoleLevel != "Admin"))
            {
                nodes.Add(new TreeViewNode
                {

                    id = subnode.Id,
                    parent = subnode.RoleLevel,
                    text = subnode.Description


                });
            }



            ViewBag.Json = JsonConvert.SerializeObject(nodes);
      
     
            ViewBag.ViewTitle = "نمایش درختی اجزای سیستم";
            return View();

        }

        public IActionResult Create()
        {

            ViewBag.LevelSet = _role.Roles.ToList();
            ViewBag.ViewTitle = "ایجاد اجزای جدید";
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CreateRole model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole();
                role.Name = model.Name;
                role.RoleLevel = model.RoleLevel;
                role.Description = model.Description;

                IdentityResult result = await _role.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }



            }
            return View(model);
        }


        public IActionResult Find(string term)
        {
           

            var roles = _role.Roles.Where(c => c.Description.Contains(term));

            return Json(new { results = roles.Select(c => new { Id = c.Id, text = c.Description }) });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoping.Web.UI.Areas.Admin.Models.Identity;
using Shoping.Web.UI.Models.Identity;

namespace Shoping.Web.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _user;
        private readonly RoleManager<AppRole> _role;

        private readonly AppIdentityDbContext _ctx;
        public UserController(UserManager<AppUser> user, RoleManager<AppRole> role
            , AppIdentityDbContext context)
        {
            _user = user;
            _role = role;
            _ctx = context;
        }
        public IActionResult Index()
        {
          var appUser=   _user.Users.ToList();
            return View(appUser);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Create(CreateUser model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { 
                
                FirstName=model.FirstName,
                LastName=model.LastName,
                UserName=model.UserName,
                Email=model.Email,
                PhoneNumber=model.PhoneNumber
                
                };
                using (var tran=_ctx.Database.BeginTransaction())
                {
                    try
                    {
                        IdentityResult resultuser = await _user.CreateAsync(user, model.Password);
                        foreach (var item in model.idrole)
                        {
                            var rolename = _role.FindByIdAsync(item).Result;
                            IdentityResult resultrole = await _user.AddToRoleAsync(user, rolename.Name);
                            
                        }

                      
                        tran.Commit();
                    }
                    catch (Exception e)
                    {

                        tran.Rollback();
                        return Content("er");
                    }
                }


                return RedirectToAction(nameof(Index));

            }

            return View(model);
        }

        public IActionResult Find(string term)
        {


            var roles = _role.Roles.Where(c => c.Description.Contains(term)).ToList();

            return Json(new { results = roles.Select(c => new { Id = c.Id, text = c.Description }) });
        }
    }
}
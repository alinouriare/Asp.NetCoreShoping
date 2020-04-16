using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoping.Web.UI.Models.Identity;

namespace Shoping.Web.UI.Controllers
{
    public class AccountController : Controller
    {
        
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private RoleManager<AppRole> roleManager;
        public AccountController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signInMgr, RoleManager<AppRole> roleMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            roleManager = roleMgr;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl=returnUrl});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult>  Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user =await userManager.FindByNameAsync(loginModel.Name);
                if (user !=null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(loginModel.Name,loginModel.Password,false,false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Product/Index");
                    }
                }
            }
            ModelState.AddModelError("", "نام کاربری یا کلمه عبور اشتباه است");
            return View(loginModel);
        }


        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
           

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.UserName, Email = model.Email };
                var roleresult = await roleManager.FindByNameAsync("Shop");

                var result = await userManager.CreateAsync(user, model.Password);

              
                if (result.Succeeded)
                {
                    var userresult =await  userManager.FindByNameAsync(model.UserName);
                    if (userresult !=null)
                    {
                        var rolset = await userManager.AddToRoleAsync(user, roleresult.Name);

                    }
                    return RedirectToAction("Login", "Account");
                }
                AddErrors(result);
            }
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty,error.Description);
            }
        }
    }
}
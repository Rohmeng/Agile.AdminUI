using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agile.AdminUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Agile.BaseLib.IoC;
using Microsoft.Extensions.Options;
using Agile.BaseLib.Options;
using Agile.BaseLib.DbContext;
using Agile.Entity;
using System.Security.Claims;

namespace Agile.AdminUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, AllowAnonymous, Route("/SignIn")]
        public IActionResult SignIn(string ReturnUrl = "/")
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect(ReturnUrl);
            }
            ViewBag.Url = ReturnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken, Route("/SignIn")]
        public async Task<IActionResult> SignIn(string name, string password, string returnUrl = null)
        {
            //验证模型是否正确
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewData["ReturnUrl"] = returnUrl;
            if (ValidateLogin(name, password))
            {
                var claims = new List<Claim>
                {
                    new Claim("user", name),
                    new Claim("role", "Member")
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }
            }
            return View();
        }

        private bool ValidateLogin(string userName, string password)
        {
            // For this sample, all logins are successful.
            return true;
        }

        [HttpGet]
        public async Task<IActionResult> SignOut(string returnurl)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(returnurl ?? "/");
        }

        public IActionResult DbCreate()
        {
            try
            {
                //生成数据库表
                SugarDbContext db = new SugarDbContext();
                db.GetInstance().CodeFirst.SetStringDefaultLength(20).InitTables(typeof(MenuInfo), typeof(UserInfo), typeof(UserRelationRole), typeof(UserRoleInfo), typeof(UserRoleRelateMenu));
                var o = AspectCoreContainer.Resolve<IOptions<DbContextOption>>();
                return Json(new { result = "成功生成数据库表", option = o.Value });
            }
            catch (Exception e)
            {
                return Json(new { result = "生成数据库表失败", message = e.Message });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

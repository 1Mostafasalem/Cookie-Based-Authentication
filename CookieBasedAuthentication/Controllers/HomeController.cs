using CookieBasedAuthentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookieBasedAuthentication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string txtUserName,string txtPassword)
        {
            if(txtUserName.ToLower()=="admin" && txtPassword.ToLower() == "123")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,txtUserName),
                    new Claim(ClaimTypes.Role,"Admin"),
                };

                var identity = new ClaimsIdentity(
                    claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal, props);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout(){
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}

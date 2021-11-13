using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieBasedAuthentication.Controllers
{
    [Authorize]
    //[Authorize(Roles = "Adminn")]

    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult TestRoleAuth()
        {
            return View();
        }
    }
}

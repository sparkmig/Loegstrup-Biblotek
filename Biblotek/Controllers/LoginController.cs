using Biblotek.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblotek.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public bool Index(LoginModel loginModel)
        {
            var isValid = new AdminService().Login(loginModel.Email, loginModel.Password);
            
            if (isValid)
                HttpContext.Session.SetString("username", loginModel.Email);
             

            return isValid;
        }

        [HttpGet, Route("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("username", "");
            return Redirect("Home");
        }
    }
}

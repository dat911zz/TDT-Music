using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

namespace TDT.CAdmin.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISecurityHelper _securityHelper;

        public AuthController(ILogger<HomeController> logger, ISecurityHelper securityHelper)
        {
            _logger = logger;
            _securityHelper = securityHelper;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string urlCallback = "")
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                return View();
            }
            //if (!string.IsNullOrEmpty(urlCallback))
            //{
            //    return Redirect(HttpContext.Request.);
            //}
            var userName = _securityHelper.ValidateToken(token);
            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(LoginModel model, string urlCallback = "")
        {
            if (ModelState.IsValid)
            {
                var auth = APICallHelper.Post<AuthDTO>("auth/login", new LoginModel()
                {
                    UserName = model.UserName,
                    Password = model.Password
                }.ToString()).Result;

                if (!string.IsNullOrEmpty(auth.Token))
                {
                    return RedirectToAction("Index", "Home");
                }
            }           
            return View(model);
        }
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Request.Headers.Remove("Authorization");
            HttpContext.Session.Clear();
            return View();
        }
    }
}

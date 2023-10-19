using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Models;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;
using System.Collections.Generic;
using TDT.Core.Enums;

namespace TDT.CAdmin.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISecurityHelper _securityHelper;
        private readonly IEmailSender _mailSender;

        public AuthController(ILogger<HomeController> logger, ISecurityHelper securityHelper, IEmailSender mailSender)
        {
            _logger = logger;
            _securityHelper = securityHelper;
            _mailSender = mailSender;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Error = null;
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
        public async Task<IActionResult> Login(LoginModel model, string urlCallback = "")
        {
            if (ModelState.IsValid)
            {
                var auth = APICallHelper.Post<AuthDTO>("auth/login?isCadmin=true", new LoginModel()
                {
                    UserName = model.UserName,
                    Password = model.Password
                }.ToString()).Result;
                if (string.IsNullOrEmpty(auth.Token))
                {
                    ViewBag.Error = new HtmlString(auth.Msg);
                    return View();
                }
                var claims = _securityHelper.ValidateToken(auth.Token);
                var listAddClaim = claims.ToList();
                listAddClaim.Add(new Claim("token", auth.Token));
                claims = listAddClaim.AsEnumerable();
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var testTime = long.Parse(claims.FirstOrDefault(x => x.Type == "exp").Value);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
                return RedirectToAction("Index", "Home", null);
            }           
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult ResetPassword(string email, string token)
        {
            var claims = _securityHelper.ValidateToken(token);
            if (claims.Count() == 0)
            {
                return APIHelper.GetJsonResult(APIStatusCode.InvalidAuthenticationString);
            }
            return View();
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TDT.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.Extensions.Logging;
using Azure.Core;
using TDT.API.Containers;
using System.Linq;
using TDT.Core.Enums;
using TDT.Core.Ultils;
using SignInResult = TDT.Core.Enums.SignInResult;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TDT.IdentityCore.Utils;

namespace TDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _cfg;
        private readonly ILogger<HomeController> _logger;
        public LoginController(IConfiguration cfg, ILogger<HomeController> logger)
        {
            _cfg = cfg;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel login)
        {
            try
            {
                IActionResult response = Unauthorized();
                User user = Authenticate(login);
                if (user != null)
                {
                    string token = SecurityHelper.GenerateJWT(_cfg, user);
                    response = APIHelper.GetJsonResult(SignInResult.AccessGranted, new Dictionary<string, object>()
                    {
                        {"token", token}
                    });
                    _logger.LogInformation("{0} connected", HttpContext.Connection.RemoteIpAddress);
                }
                else
                {
                    response = APIHelper.GetJsonResult(SignInResult.Invalid);
                    _logger.LogInformation("{0} failed to connect", HttpContext.Connection.RemoteIpAddress);
                }
                return response;
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }
        private User Authenticate(LoginModel login)
        {
            User user = null;
            //Find user
            user = Ultils.Instance.Db.Users.FirstOrDefault(u =>
            u.UserName.Equals(login.UserName)
            );
            if (user != null)
            {
                if (!SecurityHelper.VerifyHashedPassword(user.PasswordHash, login.Password))
                {
                    user = null;
                }
            }
            return user;
        }
    }
}

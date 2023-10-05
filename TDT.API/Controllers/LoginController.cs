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
using System.Linq;
using TDT.Core.Enums;
using TDT.Core.Ultils;
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
        private readonly QLDVModelDataContext _db;
        public LoginController(IConfiguration cfg, ILogger<HomeController> logger, QLDVModelDataContext db)
        {
            _cfg = cfg;
            _logger = logger;
            _db = db;
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
                    response = APIHelper.GetJsonResult(APIStatusCode.AccessGranted, new Dictionary<string, object>()
                    {
                        {"token", token}
                    });
                    _logger.LogInformation("{0} connected", HttpContext.Connection.RemoteIpAddress);
                }
                else
                {
                    response = APIHelper.GetJsonResult(APIStatusCode.InvalidAccount);
                    _logger.LogInformation("{0} failed to connect", HttpContext.Connection.RemoteIpAddress);
                }
                return response;
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
            
        }
        private User Authenticate(LoginModel login)
        {
            User user = null;
            //Find user
            user = _db.Users.FirstOrDefault(u =>
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

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
            IActionResult response = Unauthorized();
            User user = Authenticate(login);
            if (user != null)
            {
                string token = GenerateJWT(user);
                response = Ok(new { token = token });
                _logger.LogInformation("{0} connected", HttpContext.Connection.RemoteIpAddress);
            }
            else
            {
                _logger.LogInformation("{0} failed to connect", HttpContext.Connection.RemoteIpAddress);
            }

            return response;
        }
        private User Authenticate(LoginModel login)
        {
            User user = null;
            //Find user
            user = Ultils.Instance.Db.Users.First(u => 
            u.UserName.Equals(login.UserName)
            );
            if (user != null)
            {
                if (!IdentityCore.Utils.PasswordGenerator.VerifyHashedPassword(user.PasswordHash, login.Password))
                {
                    user = null;
                }
            }
            return user;
        }
        private string GenerateJWT(User userInfo)
        {
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _cfg["Jwt:Issuer"],
                _cfg["Jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

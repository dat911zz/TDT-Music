using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TDT.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace TDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _cfg;
        public LoginController(IConfiguration cfg)
        {
            _cfg = cfg;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]Login login)
        {
            IActionResult response = Unauthorized();
            User user = Authenticate(login);
            if (user != null)
            {
                string token = GenerateJWT(user);
                response = Ok(new { token = token });
            }

            return response;
        }
        private User Authenticate(Login login)
        {
            User user = null;
            //Find user
            return user;
        }
        private string GenerateJWT(User userInfo)
        {
            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["Jwt:Key"]));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _cfg["Jwt:Issuer"], 
                _cfg["Jwt:Issuer"], 
                null, 
                expires: DateTime.Now.AddMinutes(120), 
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.Enums;
using TDT.Core.ModelClone;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly QLDVModelDataContext _db;
        public UserController(ILogger<UserController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]UserIdentiyModel model)
        {
            try
            {
                if (_db.Users.Any(u => u.UserName.Equals(model.UserName)))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ExistingAccount);
                }
                _db.Users.InsertOnSubmit(new User()
                {
                    UserName = model.UserName,
                    Address = model.Address,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    PasswordHash = SecurityHelper.HashPassword(model.Password)
                });
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", model}
                }, "Đăng ký");
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _db.Users.AsEnumerable();
            return Ok(users);
        }

        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var user = _db.Users.Where(u => u.UserName.Equals(username.Trim()));
            return Ok(user);
        }

        [HttpPut("{username}")]
        public IActionResult Update(string username, UserDetailModel model)
        {
            User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
            if (user == null || string.IsNullOrEmpty(user.UserName) == false)
            {
                return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "cập nhật");
            }
            user.Email = model.Email;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.PasswordHash = SecurityHelper.HashPassword(model.Password);

            return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "cập nhật");

        }

        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
            return Ok(new { message = "User deleted successfully" });
        }

    }
}

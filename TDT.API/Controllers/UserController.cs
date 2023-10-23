using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.Enums;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private static readonly string CTR_NAME = "Tài khoản";
        private readonly ILogger<UserController> _logger;
        private readonly QLDVModelDataContext _db;
        public UserController(ILogger<UserController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _db.Users.AsEnumerable();

            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", users}
                }, "Lấy dữ liệu");
        }

        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var user = _db.Users.Where(u => u.UserName.Equals(username.Trim()));
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", user}
                }, "Lấy dữ liệu");
        }

        [HttpPut("{username}")]
        public IActionResult Update(string username, [FromBody]UserDetailModel model)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
                if (user == null || string.IsNullOrEmpty(user.UserName))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "cập nhật " + CTR_NAME);
                }
                user.Email = model.Email;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.PasswordHash = SecurityHelper.HashPassword(model.Password);
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "cập nhật " + CTR_NAME);
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
                if (user == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "xóa " + CTR_NAME);
                }
                _db.Users.DeleteOnSubmit(user);
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa " + CTR_NAME);
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }       
        }        
    }
}

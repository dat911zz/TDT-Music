using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Helper;
using TDT.Core.ModelClone;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
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

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var users = _db.Users.AsEnumerable();

            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", users}
                }, "Lấy dữ liệu");
        }

        [Authorize]
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var user = _db.Users.Where(u => u.UserName.Equals(username.Trim()));
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", user}
                }, "Lấy dữ liệu");
        }

        [Authorize]
        [HttpPut("{username}")]
        public IActionResult Update(string username, [FromBody]UserDetailModel model)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
                if (user == null || string.IsNullOrEmpty(user.UserName))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "cập nhật tài khoản");
                }
                user.Email = model.Email;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                user.PasswordHash = SecurityHelper.HashPassword(model.Password);
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "cập nhật tài khoản");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }


        }
        [Authorize]
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
                if (user == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "xóa tài khoản");
                }
                _db.Users.DeleteOnSubmit(user);
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa tài khoản");
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

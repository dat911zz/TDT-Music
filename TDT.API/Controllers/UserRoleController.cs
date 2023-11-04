using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Models;
using TDT.Core.Ultils;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRoleController : ControllerBase
    {
        private static readonly string CTR_NAME = "vai trò cho tài khoản";
        private readonly ILogger<UserRoleController> _logger;
        private readonly QLDVModelDataContext _db;
        public UserRoleController(ILogger<UserRoleController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var roles = _db.LNK_UserRoles.Where(r => r.User.UserName.Equals(username)).Select(s => new RoleDTO
            {
                Id = s.Role.Id,
                Name = s.Role.Name,
                Description = s.Role.Description,
                CreateDate = s.Role.CreateDate
            }).ToList();
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
            {
                    {"data", roles ?? new List<RoleDTO>()}
                }, "Lấy dữ liệu");
        }
        [HttpPost]
        public IActionResult Insert(string username, int roleId)
        {
            try
            {
                if (_db.LNK_UserRoles.Any(s => s.User.UserName.Equals(username) && s.RoleId == roleId))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.Exist);
                }
                var user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username));
                if (user == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.AccountNotFound);
                }
                _db.LNK_UserRoles.InsertOnSubmit(new LNK_UserRole
                {
                    UserId = user.Id,
                    RoleId = roleId
                });
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "thêm " + CTR_NAME);
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpDelete]
        public IActionResult Delete(string username, int roleId)
        {
            try
            {
                var model = _db.LNK_UserRoles.FirstOrDefault(m => m.RoleId == roleId && m.User.UserName.Equals(username) );
                if (model == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "xóa " + CTR_NAME);
                }
                _db.LNK_UserRoles.DeleteOnSubmit(model);
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

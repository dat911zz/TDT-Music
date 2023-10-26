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
    public class UserGroupController : ControllerBase
    {
        private static readonly string CTR_NAME = "người dùng trong nhóm";
        private readonly ILogger<UserGroupController> _logger;
        private readonly QLDVModelDataContext _db;
        public UserGroupController(ILogger<UserGroupController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var groups = _db.Users.Where(u => u.UserName.Equals(username)).FirstOrDefault()?.LNK_UserGroups.Select(s => new GroupDTO
            {
                Id = s.Group.Id,
                Name = s.Group.Name,
                Description = s.Group.Description,
                CreateDate = s.Group.CreateDate
            });
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
            {
                    {"data", groups ?? new List<GroupDTO>()}
                }, "Lấy dữ liệu");
        }
        [HttpPost]
        public IActionResult Insert(string username, int groupId)
        {
            try
            {
                if (_db.LNK_UserGroups.Any(s => s.User.UserName.Equals(username) && s.GroupId == groupId))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.Exist);
                }
                var user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username));
                _db.LNK_UserGroups.InsertOnSubmit(new LNK_UserGroup
                {
                    UserId = user.Id,
                    GroupId = groupId
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
        public IActionResult Delete(int roleId, int permId)
        {
            try
            {
                var model = _db.LNK_RolePermissions.FirstOrDefault(m => m.RoleId == roleId && m.PermissionId == permId);
                if (model == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "xóa " + CTR_NAME);
                }
                _db.LNK_RolePermissions.DeleteOnSubmit(model);
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

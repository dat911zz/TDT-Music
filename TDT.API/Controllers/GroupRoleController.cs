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
    public class GroupRoleController : ControllerBase
    {
        private static readonly string CTR_NAME = "vai trò cho nhóm";
        private readonly ILogger<GroupRoleController> _logger;
        private readonly QLDVModelDataContext _db;
        public GroupRoleController(ILogger<GroupRoleController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var roles = _db.Groups.Where(r => r.Id == id).FirstOrDefault()?.LNK_GroupRoles.Select(s => new RoleDTO
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
        public IActionResult Insert(int roleId, int permId)
        {
            try
            {
                if (_db.LNK_RolePermissions.Any(s => s.RoleId == roleId && s.PermissionId == permId))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.Exist);
                }
                _db.LNK_RolePermissions.InsertOnSubmit(new LNK_RolePermission
                {
                    PermissionId = permId,
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

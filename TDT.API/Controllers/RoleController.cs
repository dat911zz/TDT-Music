using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using TDT.Core.Enums;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;
using System.Linq;
using TDT.Core.DTO;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private static readonly string CTR_NAME = "Vai trò";
        private readonly ILogger<RoleController> _logger;
        private readonly QLDVModelDataContext _db;
        public RoleController(ILogger<RoleController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var roles = _db.Roles.Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                CreateDate = r.CreateDate
            }).AsEnumerable();

            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", roles}
                }, "Lấy dữ liệu");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var role = _db.Roles.Where(u => u.Id == id).Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                CreateDate = r.CreateDate
            });
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", role}
                }, "Lấy dữ liệu");
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var role = _db.Roles.Where(u => u.Name.Equals(name)).Select(r => new RoleDTO
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                CreateDate = r.CreateDate
            });
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", role}
                }, "Lấy dữ liệu");
        }

        [HttpPost]
        public IActionResult Insert([FromBody] RoleDTO model)
        {
            try
            {
                var roleF = _db.Roles.FirstOrDefault(u => u.Name.Equals(model.Name));
                if (roleF != null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "thêm " + CTR_NAME);
                }
                Role role = new Role();
                role.Name = model.Name;
                role.Description = model.Description;
                _db.Roles.InsertOnSubmit(role);
                _db.SubmitChanges();
                int roleId = _db.Roles.Where(u => u.Name == role.Name).Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    CreateDate = r.CreateDate
                }).FirstOrDefault().Id;
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, new Dictionary<string, object>
                {
                    { "data", new int[] {roleId } }
                },
                formatValue: "thêm " + CTR_NAME);
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RoleDTO model)
        {
            try
            {
                var role = _db.Roles.FirstOrDefault(u => u.Id == id);
                if (role == null || string.IsNullOrEmpty(role.Name))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "cập nhật " + CTR_NAME);
                }
                role.Name = model.Name;
                role.Description = model.Description;
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var role = _db.Roles.FirstOrDefault(u => u.Id == id);
                if (role == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "xóa " + CTR_NAME);
                }
                _db.Roles.DeleteOnSubmit(role);
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

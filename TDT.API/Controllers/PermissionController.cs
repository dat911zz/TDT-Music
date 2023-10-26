using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Models;
using TDT.Core.Ultils;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase
    {
        private static readonly string CTR_NAME = "Quyền";
        private readonly ILogger<PermissionController> _logger;
        private readonly QLDVModelDataContext _db;
        public PermissionController(ILogger<PermissionController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var roles = _db.Permissions.Select(r => new PermissionDTO
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
            var role = _db.Permissions.Where(u => u.Id == id).Select(r => new PermissionDTO
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
        public IActionResult Insert([FromBody] PermissionDTO model)
        {
            try
            {
                var permF = _db.Permissions.FirstOrDefault(u => u.Name.Equals(model.Name));
                if (permF != null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "thêm " + CTR_NAME);
                }
                Permission perm = new Permission();
                perm.Name = model.Name;
                perm.Description = model.Description;
                _db.Permissions.InsertOnSubmit(perm);
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

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] PermissionDTO model)
        {
            try
            {
                var perm = _db.Permissions.FirstOrDefault(u => u.Id == id);
                if (perm == null || string.IsNullOrEmpty(perm.Name))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "cập nhật " + CTR_NAME);
                }
                perm.Name = model.Name;
                perm.Description = model.Description;
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
                var role = _db.Permissions.FirstOrDefault(u => u.Id == id);
                if (role == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "xóa " + CTR_NAME);
                }
                _db.Permissions.DeleteOnSubmit(role);
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

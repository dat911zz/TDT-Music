using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Models;
using TDT.Core.Ultils;
using System.Linq;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : ControllerBase
    {
        private static readonly string CTR_NAME = "Nhóm";
        private readonly ILogger<GroupController> _logger;
        private readonly QLDVModelDataContext _db;
        public GroupController(ILogger<GroupController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var roles = _db.Groups.Select(r => new GroupDTO
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
            var gr = _db.Groups.Where(u => u.Id == id).Select(r => new GroupDTO
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                CreateDate = r.CreateDate
            });
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", gr}
                }, "Lấy dữ liệu");
        }

        [HttpPost]
        public IActionResult Insert([FromBody] GroupDTO model)
        {
            try
            {
                var grF = _db.Groups.FirstOrDefault(u => u.Name.Equals(model.Name));
                if (grF != null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "thêm " + CTR_NAME);
                }
                Group gr = new Group();
                gr.Name = model.Name;
                gr.Description = model.Description;
                _db.Groups.InsertOnSubmit(gr);
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
        public IActionResult Update(int id, [FromBody] GroupDTO model)
        {
            try
            {
                var role = _db.Groups.FirstOrDefault(u => u.Id == id);
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
                var gr = _db.Groups.FirstOrDefault(u => u.Id == id);
                if (gr == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "xóa " + CTR_NAME);
                }
                _db.Groups.DeleteOnSubmit(gr);
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

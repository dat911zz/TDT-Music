using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Models;
using TDT.Core.Ultils;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly QLDVModelDataContext _db;
        public AdminController(ILogger<AdminController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        public IActionResult GetRolePermissions()
        {
            var roles = _db.Roles.ToList();


            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", roles}
                }, "Lấy dữ liệu");
        }
        [HttpGet("{id}")]
        public IActionResult GetRolePermissions(int id)
        {
            var perms = _db.Roles.Where(r => r.Id == id).FirstOrDefault().LNK_RolePermissions.Select(s => new PermissionDTO { 
                Id = s.Permission.Id, Name = s.Permission.Name, Description = s.Permission.Description, CreateDate = s.Permission.CreateDate
            }).ToList();

            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
            {
                    {"data", perms}
                }, "Lấy dữ liệu");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDT.Core.DTO.Firestore;
using TDT.Core.Enums;
using TDT.Core.Helper;
using TDT.Core.Ultils;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        [HttpGet("GetLink")]
        public JsonResult Get(string path)
        {
            return new JsonResult(FirebaseService.Instance.getStorage(path));
        }
    }
}

using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO.Firestore;
using TDT.Core.Enums;
using TDT.Core.Helper;
using TDT.Core.Ultils;

namespace TDT.API.Controllers
{
    public class FileUploadModel<T>
    {
        public IFormFile FileDetails { get; set; }
        //public FileType FileType { get; set; }
        public T srcObj { get; set; }
    }
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ArtistController : Controller
    {
        // GET: api/<PlaylistController>
        [Route("load")]
        [HttpGet]
        public JsonResult Load()
        {
            Query query = FirestoreService.Instance.OrderByDescending("Artist", "follow");
            List<ArtistDTO> result = FirestoreService.Instance.Gets<ArtistDTO>(query);
            return new JsonResult(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult TestByteArray([FromForm] FileUploadModel<ArtistDTO> fileData)
        {
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                    {
                        {"data", fileData}
                    }, "Thông tin dữ liệu test");
        }
    }
}

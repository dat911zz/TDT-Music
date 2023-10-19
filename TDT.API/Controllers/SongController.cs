using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TDT.Core.DTO.Firestore;
using TDT.Core.Enums;
using TDT.Core.Helper;
using TDT.Core.Ultils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // GET: api/<SongController>

        [Route("load")]
        [HttpGet]
        public JsonResult load()
        {
            Query query = FirestoreService.Instance.OrderByDescending("Song", "releaseDate");
            return new JsonResult(FirestoreService.Instance.Gets<SongDTO>(query));
        }

        [HttpGet("{encodeId}")]
        public JsonResult Get(string encodeId)
        {
            return new JsonResult(FirestoreService.Instance.Gets<SongDTO>("Song", encodeId));
        }

        // POST api/<SongController>
        [Route("InsertOrUpdate")]
        [HttpPost]
        [Authorize]
        public IActionResult InsertOrUpdate(string key, string urlMP3, [FromBody]SongDTO song)
        {
            //List<string> result = FirebaseService.Instance.pushSong(song, urlMP3).Result;
            //if(result != null && result.Count > 0)
            //{
            //    return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "cập nhật bài hát");
            //}
            return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "cập nhật bài hát");
        }
    }
}

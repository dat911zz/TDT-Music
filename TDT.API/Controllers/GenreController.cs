using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.DTO.Firestore;
using TDT.Core.Enums;
using TDT.Core.Helper;
using TDT.Core.Ultils;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        // GET: api/<SongController>

        [HttpGet]
        public JsonResult Gets()
        {
            return new JsonResult(FirestoreService.Instance.Gets<Genre>("Genre"));
        }

        [HttpGet("{id}")]
        public JsonResult Get(string id)
        {
            return new JsonResult(FirestoreService.Instance.Gets<Genre>(FirestoreService.CL_Genre, id));
        }

        [HttpGet("GetId")]
        public JsonResult GetId(string alias)
        {
            Query query = FirestoreService.Instance.WhereEqualTo(FirestoreService.CL_Genre, "alias", alias);
            List<Genre> genres = FirestoreService.Instance.Gets<Genre>(query);
            if(genres == null || genres.Count == 0)
            {
                return new JsonResult("");
            }
            Genre g = genres.First();
            return new JsonResult(g.id);
        }
         
        [Route("InsertOrUpdate")]
        [HttpPost]
        [Authorize]
        public JsonResult InsertOrUpdate([FromForm] FileUploadModel<Genre> fileData)
        {
            Stream image = fileData.FileDetails.OpenReadStream();
            List<string> paramCheck = new List<string>() { "id", "title", "alias", "name" };
            Genre genre = fileData.srcObj;
            var resParam = HelperUtility.GetParamsIllegal(paramCheck, genre);
            if (resParam.Count > 0)
            {
                return APIHelper.GetJsonResult(APIStatusCode.NullParams, formatValue: string.Join(",", resParam.ToArray()));
            }
            try
            {
                FirestoreService.Instance.SetAsync(FirestoreService.CL_Genre, genre.id, genre).Wait();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, new Dictionary<string, object>()
                    {
                        {"data", genre}
                    }, "cập nhật");
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
        [Authorize]
        public JsonResult Delete(string id)
        {
            FirestoreService.Instance.DeleteAsync(FirestoreService.CL_Genre, id).Wait();
            return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa");
        }
    }
}

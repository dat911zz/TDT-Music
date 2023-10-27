using Firebase.Auth;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.DTO.Firestore;
using TDT.Core.Enums;
using TDT.Core.Helper;
using TDT.Core.Models;
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
        [HttpGet]
        public JsonResult Gets()
        {
            return new JsonResult(FirestoreService.Instance.Gets<ArtistDTO>(FirestoreService.CL_Artist));
        }

        [Route("Load")]
        [HttpGet]
        public JsonResult Load()
        {
            Query query = FirestoreService.Instance.OrderByDescending(FirestoreService.CL_Artist, "follow");
            List<ArtistDTO> result = FirestoreService.Instance.Gets<ArtistDTO>(query);
            return new JsonResult(result);
        }

        [HttpGet("{encodeId}")]
        public JsonResult Get(string encodeId)
        {
            return new JsonResult(FirestoreService.Instance.Gets<ArtistDTO>(FirestoreService.CL_Artist, encodeId));
        }

        [Route("InsertOrUpdate")]
        [HttpPost]
        [Authorize]
        public JsonResult InsertOrUpdate([FromBody] ArtistDTO artist)
        {
          
            List<string> paramCheck = new List<string>() { "id", "alias", "thumbnail", "thumbnailM" };
            var resParam = HelperUtility.GetParamsIllegal(paramCheck, artist);
            if (resParam.Count > 0)
            {
                return APIHelper.GetJsonResult(APIStatusCode.NullParams, formatValue: string.Join(",", resParam.ToArray()));
            }
            try
            {
                FirestoreService.Instance.SetAsync(FirestoreService.CL_Artist_Test, artist.id, artist).Wait();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, new Dictionary<string, object>()
                    {
                        {"data", artist}
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
            FirestoreService.Instance.DeleteAsync(FirestoreService.CL_Artist_Test, id).Wait();
            return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa");
        }
    }
}

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
        public JsonResult InsertOrUpdate([FromForm] FileUploadModel<ArtistDTO> fileData)
        {
            Stream image = fileData.FileDetails.OpenReadStream();
            List<string> paramCheck = new List<string>() { "id", "alias", "thumbnail", "thumbnailM" };
            ArtistDTO artist = fileData.srcObj;
            var resParam = HelperUtility.GetParamsIllegal(paramCheck, artist);
            if (resParam.Count > 0)
            {
                return APIHelper.GetJsonResult(APIStatusCode.NullParams, formatValue: string.Join(",", resParam.ToArray()));
            }
            try
            {
                string thumbnail = artist.id + "_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "." + fileData.FileDetails.FileName.Split('.').Last();
                string url = FirebaseService.Instance.pushFile(image, "Images/Artist/0/" + thumbnail).Result;
                DataHelper.Instance.ThumbArtist.Add(artist.id, url);
                FirebaseService.Instance.pushFile(image, "Images/Artist/1/" + thumbnail).Wait();
                artist.thumbnail = "Images/Artist/0/" + thumbnail;
                artist.thumbnailM = "Images/Artist/1/" + thumbnail;
                FirestoreService.Instance.SetAsync(FirestoreService.CL_Artist, artist.id, artist).Wait();
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
            FirestoreService.Instance.DeleteAsync(FirestoreService.CL_Artist, id).Wait();
            return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa");
        }
    }
}

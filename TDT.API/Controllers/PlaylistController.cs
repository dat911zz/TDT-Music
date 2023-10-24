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
    public class PlaylistController : ControllerBase
    {
        // GET: api/<PlaylistController>
        [Route("Load")]
        [HttpGet]
        public JsonResult Load()
        {
            Query query = FirestoreService.Instance.OrderByDescending("Playlist", "releasedAt");
            List<PlaylistDTO> result = FirestoreService.Instance.Gets<PlaylistDTO>(query);
            return new JsonResult(result);
        }

        [Route("Gets")]
        [HttpGet]
        public JsonResult Gets()
        {
            return new JsonResult(FirestoreService.Instance.Gets<PlaylistDTO>(FirestoreService.CL_Playlist));
        }

        [HttpGet("{encodeId}")]
        public JsonResult Get(string encodeId)
        {
            return new JsonResult(FirestoreService.Instance.Gets<PlaylistDTO>(FirestoreService.CL_Playlist, encodeId));
        }

        [Route("InsertOrUpdate")]
        [HttpPost]
        [Authorize]
        public JsonResult InsertOrUpdate([FromForm] FileUploadModel<PlaylistDTO> fileData)
        {
            Stream image = fileData.FileDetails.OpenReadStream();
            List<string> paramCheck = new List<string>() { "encodeId", "title", "thumbnail", "thumbnailM" };
            PlaylistDTO playlist = fileData.srcObj;
            var resParam = HelperUtility.GetParamsIllegal(paramCheck, playlist);
            if (resParam.Count > 0)
            {
                return APIHelper.GetJsonResult(APIStatusCode.NullParams, formatValue: string.Join(",", resParam.ToArray()));
            }
            try
            {
                string thumbnail = playlist.encodeId + "_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "." + fileData.FileDetails.FileName.Split('.').Last();
                string url = FirebaseService.Instance.pushFile(image, "Images/Playlist/0/" + thumbnail).Result;
                DataHelper.Instance.ThumbArtist.Add(playlist.encodeId, url);
                FirebaseService.Instance.pushFile(image, "Images/Playlist/1/" + thumbnail).Wait();
                playlist.thumbnail = "Images/Playlist/0/" + thumbnail;
                playlist.thumbnailM = "Images/Playlist/1/" + thumbnail;
                FirestoreService.Instance.SetAsync(FirestoreService.CL_Playlist, playlist.encodeId, playlist).Wait();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, new Dictionary<string, object>()
                    {
                        {"data", playlist}
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

        [HttpDelete("{encodeId}")]
        [Authorize]
        public JsonResult Delete(string encodeId)
        {
            FirestoreService.Instance.DeleteAsync(FirestoreService.CL_Playlist, encodeId).Wait();
            return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa");
        }
    }
}

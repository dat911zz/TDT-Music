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
            Query query = FirestoreService.Instance.WhereEqualTo(FirestoreService.CL_Playlist, "isPrivate", false).OrderByDescending("contentLastUpdate");
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

        [Route("GetArrayContains")]
        [HttpPost]
        public JsonResult GetArrayContains(string path, List<string> values)
        {
            Query query = FirestoreService.Instance.WhereIn(FirestoreService.CL_Playlist, path, values);
            return new JsonResult(FirestoreService.Instance.Gets<PlaylistDTO>(query));
        }

        [Route("InsertOrUpdate")]
        [HttpPost]
        [Authorize]
        public JsonResult InsertOrUpdate([FromBody] PlaylistDTO playlist)
        {
            List<string> paramCheck = new List<string>() { "encodeId", "title", "thumbnail"};
            var resParam = HelperUtility.GetParamsIllegal(paramCheck, playlist);
            if (resParam.Count > 0)
            {
                return APIHelper.GetJsonResult(APIStatusCode.NullParams, formatValue: string.Join(",", resParam.ToArray()));
            }
            try
            {
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

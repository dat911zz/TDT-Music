 using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        int limitRelease = 30;
        // GET: api/<SongController>

        [Route("LoadSongReleaseAll")]
        [HttpGet]
        public JsonResult LoadSongReleaseAll()
        {
            Query query = FirestoreService.Instance.OrderByDescending(FirestoreService.CL_Song, "releaseDate").Limit(limitRelease);
            List<SongDTO> res = FirestoreService.Instance.Gets<SongDTO>(query);
            return new JsonResult(res);
        }

        [Route("LoadSongReleaseVN")]
        [HttpGet]
        public JsonResult LoadSongReleaseVN()
        {
            string idGenreVN = APIHelper.GetStringValue($"{FirestoreService.CL_Genre}/GetId?alias={HelperUtility.GetAlias("Việt Nam")}");
            if (string.IsNullOrEmpty(idGenreVN))
                return new JsonResult(null);
            Query query = FirestoreService.Instance.WhereArrayContains(FirestoreService.CL_Song, "genreIds", idGenreVN).OrderByDescending("releaseDate").Limit(limitRelease);
            List<SongDTO> res = FirestoreService.Instance.Gets<SongDTO>(query);
            return new JsonResult(res);
        }

        [HttpGet]
        public JsonResult Gets()
        {
            return new JsonResult(FirestoreService.Instance.Gets<SongDTO>(FirestoreService.CL_Song));
        }

        [HttpGet("{encodeId}")]
        public JsonResult Get(string encodeId)
        {
            //var list1 = FirestoreService.Instance.Gets<SongDTO>(FirestoreService.Instance.GetCollectionReference("Song").OrderByDescending("encodeId").Limit(5));
            //var list2 = FirestoreService.Instance.Gets<SongDTO>(FirestoreService.Instance.GetCollectionReference("Song").OrderByDescending("encodeId").StartAfter("ZZZZW6WE").Limit(3));
            return new JsonResult(FirestoreService.Instance.Gets<SongDTO>(FirestoreService.CL_Song, encodeId));
        }

        [Route("InsertOrUpdate")]
        [HttpPost]
        [Authorize]
        public JsonResult InsertOrUpdate([FromBody] SongDTO song)
        {
            
            List<string> paramCheck = new List<string>() { "encodeId", "title", "thumbnail" };
            var resParam = HelperUtility.GetParamsIllegal(paramCheck, song);
            if (resParam.Count > 0)
            {
                return APIHelper.GetJsonResult(APIStatusCode.NullParams, formatValue: string.Join(",", resParam.ToArray()));
            }
            try
            {
                FirestoreService.Instance.SetAsync(FirestoreService.CL_Song, song.encodeId, song).Wait();      // Sửa Song Test
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, new Dictionary<string, object>()
                    {
                        {"data", song}
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
            FirestoreService.Instance.DeleteAsync(FirestoreService.CL_Song, encodeId).Wait();
            return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa");
        }
    }
}

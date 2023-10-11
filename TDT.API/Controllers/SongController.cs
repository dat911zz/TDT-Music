﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
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
            var dics = FirebaseService.Instance.getDictionary("Song", "id");
            return new JsonResult(dics.Values.Select(x => ConvertService.Instance.convertToObjectFromJson<SongDTO>(x.ToString())).ToList());
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public JsonResult Get(string id)
        {
            var song = FirebaseService.Instance.getSingleValue<SongDTO>(id);
            return new JsonResult(song);
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

        //// PUT api/<SongController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SongController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

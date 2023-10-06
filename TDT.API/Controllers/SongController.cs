using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // GET: api/<SongController>

        [Route("load")]
        [HttpGet]
        public JsonResult load()
        {
            var dics = FirebaseService.Instance.getDictionary("Song", "id");
            List<SongDTO> songs = dics.Values.Select(x => ConvertService.Instance.convertToObjectFromJson<SongDTO>(x.ToString())).ToList();
            return new JsonResult(songs);
        }

        [Route("release")]
        [HttpGet]
        public JsonResult release()
        {
            var list = FirebaseService.Instance.getPlaylistRelease().Result;
            list = list.OrderByDescending(x => long.Parse(x.Object.releasedAt)).Take(10).ToList();
            return new JsonResult(list);
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var list = FirebaseService.Instance.get1().Result;
            return new JsonResult(list);
        }

        //// POST api/<SongController>
        //[HttpPost]
        //public void Post([FromHeader] string value)
        //{
        //    int a = 0;
        //}

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

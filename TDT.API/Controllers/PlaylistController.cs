using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        // GET: api/<PlaylistController>
        [Route("load")]
        [HttpGet]
        public JsonResult load()
        {
            var dics = FirebaseService.Instance.getDictionary("Playlist", "id");
            return new JsonResult(dics.Values.Select(x => ConvertService.Instance.convertToObjectFromJson<PlaylistDTO>(x.ToString())).ToList());
        }

        // GET api/<PlaylistController>/5
        [HttpGet("{encodeId}")]
        public JsonResult Get(string encodeId)
        {
            PlaylistDTO playlist;
            string json = FirebaseService.Instance.getValueJson($"/Playlist/{encodeId}").Result;
            if (string.IsNullOrEmpty(json))
            {
                return new JsonResult(null);
            }
            playlist = ConvertService.Instance.convertToObjectFromJson<PlaylistDTO>(json);
            return new JsonResult(playlist);
        }

        // POST api/<PlaylistController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlaylistController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlaylistController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}

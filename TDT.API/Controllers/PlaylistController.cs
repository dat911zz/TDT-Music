using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO.Firestore;
using TDT.Core.Helper;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        // GET: api/<PlaylistController>
        [Route("load")]
        [HttpGet]
        public JsonResult Load()
        {
            Query query = FirestoreService.Instance.OrderByDescending("Playlist", "releasedAt");
            List<PlaylistDTO> result = FirestoreService.Instance.Gets<PlaylistDTO>(query);
            return new JsonResult(result);
        }

        // GET api/<PlaylistController>/5
        [HttpGet("{encodeId}")]
        public JsonResult Get(string encodeId)
        {
            PlaylistDTO playlist = FirestoreService.Instance.Gets<PlaylistDTO>("Playlist", encodeId);
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

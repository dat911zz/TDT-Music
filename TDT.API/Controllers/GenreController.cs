using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TDT.Core.DTO.Firestore;
using TDT.Core.Helper;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        // GET: api/<SongController>

        [Route("load")]
        [HttpGet]
        public JsonResult Load()
        {
            var res = FirestoreService.Instance.Gets<Genre>("Genre");
            return new JsonResult(res);
        }
    }
}

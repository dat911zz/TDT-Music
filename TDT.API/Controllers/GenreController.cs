using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Helper;

namespace TDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        // GET: api/<SongController>

        [Route("load")]
        [HttpGet]
        public JsonResult load()
        {
            var dics = FirebaseService.Instance.getDictionary("Genre");
            return new JsonResult(dics.Values.Select(x => ConvertService.Instance.convertToObjectFromJson<Genre>(x.ToString())).ToList());
        }
    }
}

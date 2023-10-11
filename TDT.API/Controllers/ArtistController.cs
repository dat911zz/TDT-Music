using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Helper;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        // GET: api/<PlaylistController>
        [Route("load")]
        [HttpGet]
        public JsonResult load()
        {
            var dics = FirebaseService.Instance.getDictionary("Artist", "id");
            return new JsonResult(dics.Values.Select(x => ConvertService.Instance.convertToObjectFromJson<ArtistDTO>(x.ToString())).ToList());
        }
    }
}

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
    public class ArtistController : ControllerBase
    {
        // GET: api/<PlaylistController>
        [Route("load")]
        [HttpGet]
        public JsonResult Load()
        {
            Query query = FirestoreService.Instance.OrderByDescending("Artist", "follow");
            List<ArtistDTO> result = FirestoreService.Instance.Gets<ArtistDTO>(query);
            return new JsonResult(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TDT.Core.Helper;
using TDT.Core.Models;

namespace TDT.Core.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        [HttpGet("GetViewColor")]
        public JsonResult GetViewColor()
        {
            return new JsonResult(DataHelper.Instance.VIEW_COLOR);
        }
        [HttpPost("SetViewColor")]
        public void SetViewColor([FromForm] int value)
        {
            DataHelper.Instance.VIEW_COLOR = value;
        }
    }
}

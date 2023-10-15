using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

namespace TDT.CAdmin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ResponseDataDTO<User> userDetail = APICallHelper.Get<ResponseDataDTO<User>>("user", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;

            return View(userDetail.Data);
        }
    }
}

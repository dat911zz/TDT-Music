using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TDT.CAdmin.Filters;
using TDT.CAdmin.Models;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

namespace TDT.CAdmin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Start session");
            //var test = Directory.GetCurrentDirectory();
            //ResponseDataDTO<User> userDetail = APICallHelper.Get<ResponseDataDTO<User>>("user", token: auth.Token).Result;
            //ResponseDataDTO<User> res = APICallHelper.Get<ResponseDataDTO<User>>($"user/{pUser}", token: auth.Token).Result;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode, string msg = "Có lỗi đã xảy ra!")
        {
            ViewBag.ErrorCode = statusCode != 0 ? statusCode : 404;
            ViewBag.ErrorContent = msg;
            return View();
        }
    }
}

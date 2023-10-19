using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TDT_Music.Models;

namespace TDT_Music.Controllers
{
    public class HubController : Controller
    {
        private readonly ILogger<HubController> _logger;

        public HubController(ILogger<HubController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Chill()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode, string msg = "Có lỗi đã xảy ra!")
        {
            ViewBag.ErrorCode = statusCode != 0 ? statusCode : 404;
            ViewBag.ErrorContent = msg;
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TDT.Core.Extensions;
using TDT.Core.Ultils.MVCMessage;
using TDT_Music.Models;

namespace TDT_Music.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            this.MessageContainer().AddMessage(
                "Tính năng thông báo đã được cập nhật! " +
                "Có thể sử dụng được tại các controller. " +
                "Chi tiết vui lòng liên hệ Vũ Đạt để được biết thêm.",
                ToastMessageType.Info
                );
            return View();
        }

        public IActionResult Privacy()
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

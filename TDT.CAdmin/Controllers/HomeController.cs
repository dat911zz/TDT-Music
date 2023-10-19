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
using TDT.Core.Extensions;
using TDT.CAdmin.Filters;
using TDT.CAdmin.Models;
using TDT.Core.DTO;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;
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
			this.MessageContainer().AddMessage(
                "Tính năng thông báo đã được cập nhật! " +
                "Có thể sử dụng được tại các controller. " +
                "Chi tiết vui lòng liên hệ Vũ Đạt để được biết thêm.",
                ToastMessageType.Info
                );

            //this.MessageContainer().AddException(new Exception("HEHE?"));
            //this.MessageContainer().AddErrorFlashMessage("Có lỗi xảy ra, vui lòng thực hiện lại!");
            //this.MessageContainer().AddMessage("OK nè!", ToastMessageType.Success);
            //this.MessageContainer().AddMessage("Cảnh báo nè!", ToastMessageType.Warning);
            //this.MessageContainer().AddMessage("Thông báo nè!", ToastMessageType.Info);
            //this.MessageContainer().AddMessage("Lỗi do mèo làm nè!", ToastMessageType.Error);

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

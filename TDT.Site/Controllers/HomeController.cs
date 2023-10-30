using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;
using TDT.Site.Models;

namespace TDT.Site.Controllers
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
            //this.MessageContainer().AddMessage(
            //    "Tính năng thông báo đã được cập nhật! " +
            //    "Có thể sử dụng được tại các controller. " +
            //    "Chi tiết vui lòng liên hệ Vũ Đạt để được biết thêm.",
            //    ToastMessageType.Info
            //    );
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                this.MessageContainer().AddFlashMessage("Không được bỏ trống từ khóa", ToastMessageType.Warning);
                return Redirect("/");
            }
            ViewData["key"] = key;
            return View();
        }

        [HttpPost]
        public string GetHtmlSong([FromForm] string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                return "";
            }
            string alias = HelperUtility.GetAlias(key);
            string genVN = FirestoreService.Instance.GetIdGenre("Việt Nam");
            List<SongDTO> list = DataHelper.Instance.Songs.Values.OrderByDescending(x => x.ReleaseDate())
                .Where(x => x.genreIds != null && x.genreIds.Contains(genVN) && !string.IsNullOrEmpty(x.alias) && x.alias.ToLower().Contains(alias)).Take(30).ToList();
            return Generator.GeneratePageSong(list);
        }
        [HttpPost]
        public string GetHtmlPlaylist([FromForm] string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            string alias = HelperUtility.GetAlias(key);
            List<PlaylistDTO> list = DataHelper.Instance.Playlists.Values.OrderByDescending(x => x.releaseDate)
                .Where(x => !string.IsNullOrEmpty(x.aliasTitle) && x.aliasTitle.ToLower().Contains(alias)).Take(30).ToList();
            return Generator.GeneratePlaylistsElement(list, true);
        }
        [HttpPost]
        public string GetHtmlArtist([FromForm] string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            string alias = HelperUtility.GetAlias(key);
            List<ArtistDTO> list = DataHelper.Instance.Artists.Values.OrderByDescending(x => x.totalFollow)
                .Where(x => !string.IsNullOrEmpty(x.alias) && x.alias.ToLower().Contains(alias)).Take(30).ToList();
            return Generator.GenerateArtistsElement(list);
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

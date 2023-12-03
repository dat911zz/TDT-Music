using Google.Cloud.Firestore;
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
        int size_ajax = 50;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
            ViewData["SongSize"] = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Song).Count().GetSnapshotAsync().Result.Count;
            ViewData["PlaylistSize"] = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Playlist).Count().GetSnapshotAsync().Result.Count;
            ViewData["ArtistSize"] = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Artist).Count().GetSnapshotAsync().Result.Count;
            ViewData["SizeAjax"] = size_ajax;
            return View();
        }

        [HttpPost]
        public string GetHtmlSong([FromForm] string key, int s)
        {
            if(string.IsNullOrEmpty(key))
            {
                return "";
            }
            string alias = HelperUtility.GetAlias(key);
            string title = HelperUtility.GetTitleWithRemoveVietnamese(key);
            Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Song).Offset((int)((s - 1) * size_ajax)).Limit(size_ajax);
            List<SongDTO> list = FirestoreService.Instance.Gets<SongDTO>(query);
            var res = list.Where(x => (!string.IsNullOrEmpty(x.title) && HelperUtility.GetTitleWithRemoveVietnamese(x.title).Contains(title)) || (!string.IsNullOrEmpty(x.alias) && x.alias.ToLower().Contains(alias))).ToList();
            return Generator.GeneratePageSong(res);
        }
        [HttpPost]
        public string GetHtmlPlaylist([FromForm] string key, int s)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            string alias = HelperUtility.GetAlias(key);
            string title = HelperUtility.GetTitleWithRemoveVietnamese(key);
            Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Playlist).Offset((int)((s - 1) * size_ajax)).Limit(size_ajax);
            List<PlaylistDTO> list = FirestoreService.Instance.Gets<PlaylistDTO>(query);
            var res = list.Where(x => (!string.IsNullOrEmpty(x.title) && HelperUtility.GetTitleWithRemoveVietnamese(x.title).Contains(title)) || (!string.IsNullOrEmpty(x.aliasTitle) && x.aliasTitle.ToLower().Contains(alias))).ToList();
            return Generator.GeneratePlaylistsElement(res, true);
        }
        [HttpPost]
        public string GetHtmlArtist([FromForm] string key, int s)
        {
            if (string.IsNullOrEmpty(key))
            {
                return "";
            }
            string alias = HelperUtility.GetAlias(key);
            string name = HelperUtility.GetTitleWithRemoveVietnamese(key);
            Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Artist).Offset((int)((s - 1) * size_ajax)).Limit(size_ajax);
            List<ArtistDTO> list = FirestoreService.Instance.Gets<ArtistDTO>(query);
            var res = list.Where(x => (!string.IsNullOrEmpty(x.name) && HelperUtility.GetTitleWithRemoveVietnamese(x.name).Contains(name)) || (!string.IsNullOrEmpty(x.alias) && x.alias.ToLower().Contains(alias))).ToList();
            return Generator.GenerateArtistsElement(res);
        }

        [HttpPost]
        public void ShowNotiWarning([FromForm] string noti)
        {
            this.MessageContainer().AddFlashMessage(noti, ToastMessageType.Warning);
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

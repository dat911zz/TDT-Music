using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;

namespace TDT.Site.Controllers
{
    public class HubController : Controller
    {
        private readonly ILogger<HubController> _logger;

        public HubController(ILogger<HubController> logger)
        {
            _logger = logger;
        }
        public IActionResult Top100()
        {
            if(DataHelper.Instance.Top100.Count <= 0)
            {
                DataHelper.Instance.Top100 = FirestoreService.Instance.Gets<TypePlaylistDTO>(FirestoreService.CL_TypePlaylist).OrderByDescending(t => t.title).ToList();
            }
            string json = JsonConvert.SerializeObject(DataHelper.Instance.Top100);
            ViewData["ArrayTitleSection"] = json;
            return View(DataHelper.Instance.Top100);
        }
        public string GetHtmlSectionTop100(string key)
        {
            TypePlaylistDTO type = DataHelper.Instance.Top100.Where(t => t.title.Equals(key)).FirstOrDefault();
            if (type == null)
            {
                this.MessageContainer().AddFlashMessage("Lỗi load dữ liệu với key:" + key, TDT.Core.Ultils.MVCMessage.ToastMessageType.Error);
                return string.Empty;
            }
            return Generator.GeneratePlaylistsElement(type.playlists, true);
        }
        public IActionResult new_release(string option)
        {
            ViewData["option"] = option;
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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Newtonsoft.Json;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;

namespace TDT.Site.Controllers
{
    public class AlbumController : Controller
    {
        static int q = 0;
        static long d = 0;
        public IActionResult Index(string encodeId)
        {
            PlaylistDTO playlist;
            if (string.IsNullOrEmpty(encodeId))
            {
                this.MessageContainer().AddFlashMessage("Đường dẫn không hợp lệ !!!", TDT.Core.Ultils.MVCMessage.ToastMessageType.Error);
                return Redirect("/");
            }
            playlist = DataHelper.GetPlaylist(encodeId);
            if (playlist == null)
            {
                this.MessageContainer().AddFlashMessage("Playlist không tồn tại", TDT.Core.Ultils.MVCMessage.ToastMessageType.Error);
                return Redirect("/");
            }
            ViewData["songs"] = playlist.songs;
            ViewData["thumbnail"] = DataHelper.GetThumbnailPlaylist(playlist);
            q = 0;
            d = 0;
            ViewData["fromstack"] = playlist.isAlbum ? "album" : "playlist";
            ViewData["titlestack"] = playlist.title;
            return View(playlist);
        }

        public string GetHtmlSong(string page, string json)
        {
            int p;
            var o = JsonConvert.SerializeObject(new { html = "", quantity = 0, duration = 0, durationHtml = "" });
            if (!int.TryParse(page, out p))
            {
                return o;
            }
            List<string> list = JsonConvert.DeserializeObject<List<string>>(json).Skip((int)((p - 1) * 5)).Take(5).ToList();
            if(list != null && list.Count > 0)
            {
                string res = "";
                foreach (var item in list)
                {
                    var song = DataHelper.GetSong(item);
                    if (song == null)
                        continue;
                    AlbumController.d += song.duration;
                    AlbumController.q += 1;
                    res += Generator.GenerateSongElement(song);
                    DataHelper.GetMP3(song.encodeId);
                }
                return JsonConvert.SerializeObject(new { html = res, quantity = AlbumController.q, duration = AlbumController.d, durationHtml = HelperUtility.GetTime(AlbumController.d)});
            }
            return o;
        }
    }
}

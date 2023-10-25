using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;
using TDT.Core.Ultils;

namespace TDT_Music.Controllers
{
    public class AlbumController : Controller
    {
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
            ViewData["thumbnail"] = DataHelper.GetThumbnailPlaylist(playlist);
            return View(playlist);
        }

        public string GetHtmlSong(string page, string json)
        {
            int p;
            if(!int.TryParse(page, out p))
            {
                return string.Empty;
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
                    res += Generator.GenerateSongElement(song);
                }
                return res;
            }
            return string.Empty;
        }
    }
}

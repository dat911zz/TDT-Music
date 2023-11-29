using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TDT.Core.DTO.Firestore;
using TDT.Core.DTO;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.Ultils.MVCMessage;
using TDT.Core.Ultils;
using System.Collections.Generic;

namespace TDT.Site.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Playlist()
        {
            if (HttpContext.User.Identity.Name != null)
            {
                ResponseDataDTO<UserPlaylistDTO> res = APICallHelper.Get<ResponseDataDTO<UserPlaylistDTO>>(
                $"User/GetPlaylistds?username={HttpContext.User.Identity.Name}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value
                        ).Result;
                List<PlaylistDTO> playlists = new List<PlaylistDTO>();
                foreach (var item in res.Data)
                {
                    var p = DataHelper.GetPlaylist(item.PlaylistId);
                    if(p != null)
                    {
                        playlists.Add(p);
                    }
                }
                return View(playlists);
            }
            return RedirectToAction("Index", "Auth");
        }

        public IActionResult HistorySong()
        {
            if (HttpContext.User.Identity.Name != null)
            {
                ResponseDataDTO<ListenedDTO> res = APICallHelper.Get<ResponseDataDTO<ListenedDTO>>(
                $"User/GetListeneds?username={HttpContext.User.Identity.Name}").Result;
                List<SongDTO> songs = new List<SongDTO>();
                foreach (var item in res.Data)
                {
                    var s = DataHelper.GetSong(item.SongId);
                    if (s != null)
                    {
                        songs.Add(s);
                    }
                }
                return View(songs);
            }
            return RedirectToAction("Index", "Auth");
        }
    }
}

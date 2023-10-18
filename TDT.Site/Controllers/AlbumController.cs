using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TDT.Core.DTO;
using TDT.Core.Helper;
using TDT.Core.Ultils;
using TDT_Music.Services;

namespace TDT_Music.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index(string encodeId)
        {
            PlaylistDTO playlist;
            if (string.IsNullOrEmpty(encodeId))
            {
                throw new Exception("Đường dẫn không hợp lệ !!!");
            }
            if(!DataHelper.Instance.Playlists.Keys.Contains(encodeId)) {
                playlist = DBService.Instance.getFirebase<PlaylistDTO>($"Playlist/{encodeId}");
                if(playlist == null)
                {
                    throw new Exception("Playlist không tồn tại");
                }
            }
            else
            {
                playlist = DataHelper.Instance.Playlists[encodeId];
            }
            return View();
        }
    }
}

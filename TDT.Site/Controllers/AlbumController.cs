using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
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
            List<SongDTO> songs = new List<SongDTO>();
            foreach (var item in playlist.songs)
            {
                if(DataHelper.Instance.Songs.Keys.Contains(item))
                {
                    songs.Add(DataHelper.Instance.Songs[item]);
                }
                else
                {
                    var song = DataHelper.GetSong(item);
                    if(song == null)
                    {
                        continue;
                    }
                    songs.Add(song);
                }
            }
            ViewData["songs"] = songs;
            ViewData["thumbnail"] = DataHelper.GetThumbnailPlaylist(playlist);
            return View(playlist);
        }

        public string LoadImg(string encodeId, string thumbpath)
        {
            return DataHelper.GetThumbnailSong(encodeId, thumbpath);
        }
    }
}

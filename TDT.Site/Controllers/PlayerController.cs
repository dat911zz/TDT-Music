using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;
using TDT.Site.Services;

namespace TDT.Site.Controllers
{
    public class PlayerController : Controller
    {
        public bool CheckShowPlayer()
        {
            return PlayerService.GetPlayers().Count > 0;
        }
        public string GetSrc()
        {
            return JsonConvert.SerializeObject(PlayerService.GetPlayers().Values.ToList());
        }

        [HttpPost]
        public void SetSrc([FromForm] string[] list)
        {
            PlayerService.SetPlayer(list.ToList());
        }
        [HttpPost]
        public string GetSrc([FromForm] string[] list)
        {
            Dictionary<string, Player> temp = new Dictionary<string, Player>();
            foreach (string songId in list)
            {
                if (temp.ContainsKey(songId))
                    continue;
                var song = DataHelper.GetSong(songId);
                if (song != null)
                {
                    temp.Add(song.encodeId, new Player
                    {
                        Id = song.encodeId,
                        Name = song.title,
                        Thumbnail = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail),
                        Src = DataHelper.GetMP3(song.encodeId),
                        Artists = Generator.GenerateArtistLink(song.artists)
                    });
                }
            }
            return JsonConvert.SerializeObject(temp.Values.ToList());
        }

        public int GetCurIndex()
        {
            return PlayerService.CurIndex;
        }
        [HttpPost]
        public void SetCurIndex([FromForm] int index)
        {
            PlayerService.CurIndex = index;
        }

        public bool GetIsShuffle()
        {
            return PlayerService.IsShuffle;
        }
        [HttpPost]
        public void SetIsShuffle([FromForm] bool value)
        {
            PlayerService.IsShuffle = value;
        }

        public bool GetIsRepeat()
        {
            return PlayerService.IsRepeat;
        }
        [HttpPost]
        public void SetIsRepeat([FromForm] bool value)
        {
            PlayerService.IsRepeat = value;
        }
        public bool GetIsRepeatOne()
        {
            return PlayerService.IsRepeatOne;
        }
        [HttpPost]
        public void SetIsRepeatOne([FromForm] bool value)
        {
            PlayerService.IsRepeatOne = value;
        }

        public string GetCurUrl()
        {
            return PlayerService.CurUrl;
        }
        [HttpPost]
        public void SetCurUrl([FromForm] string url)
        {
            PlayerService.CurUrl = url;
        }
    }
}

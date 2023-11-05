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
            return !PlayerService.Instance.StackIsEmpty();
        }
        public string GetSrc()
        {
            return JsonConvert.SerializeObject(PlayerService.GetPlayers().Values.ToList());
        }

        [HttpPost]
        public void SetSrc([FromForm] string[] list, string from = null, string title = null, int? index = null, string id = null)
        {
            PlayerService.Instance.SetPlayer(list.ToList());
            if(index != null && !string.IsNullOrEmpty(id))
            {
                PlayerService.Instance.ChoosePlayer((int)index, id);
            }
            if(!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(title))
            {
                PlayerService.Instance.StackFrom = from;
                PlayerService.Instance.StackTitle = title;
            }
        }
        [HttpPost]
        public void ChoosePlayer([FromForm] int index, string id)
        {
            PlayerService.Instance.ChoosePlayer(index, id);
        }

        [HttpPost]
        public string GetSrc([FromForm] string[] list)
        {
            Dictionary<string, Player> temp = new Dictionary<string, Player>();
            int i = 0;
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
                        Index = i++,
                        Name = song.title,
                        Thumbnail = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail),
                        Src = DataHelper.GetMP3(song.encodeId),
                        Artists = Generator.GenerateArtistLink(song.artists)
                    });
                }
            }
            return JsonConvert.SerializeObject(temp.Values.ToList());
        }

        [HttpPost]
        public JsonResult ChangeMusic([FromForm] string type)
        {
            Player player = PlayerService.Instance.ChangeMusic(type);
            if(player == null)
            {
                return new JsonResult("");
            }
            return new JsonResult(JsonConvert.SerializeObject(player));
        }

        public int GetCurIndex()
        {
            return PlayerService.CurIndex;
        }
        [HttpPost]
        public void SetCurIndex([FromForm] int index)
        {
            PlayerService.CurIndex = index;
            PlayerService.CurTime = 0;
        }
        public double GetCurTime()
        {
            return PlayerService.CurTime;
        }
        [HttpPost]
        public void SetCurTime([FromForm] double time)
        {
            PlayerService.CurTime = time;
        }

        public bool GetIsShuffle()
        {
            return PlayerService.IsShuffle;
        }
        [HttpPost]
        public void SetIsShuffle([FromForm] bool value)
        {
            PlayerService.IsShuffle = value;
            PlayerService.Instance.ShuffleStack();
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
        public bool GetIsPlaying()
        {
            return PlayerService.IsPlaying;
        }
        [HttpPost]
        public void SetIsPlaying([FromForm] bool value)
        {
            PlayerService.IsPlaying = value;
        }

        public string GetCurUrl()
        {
            return PlayerService.UrlStack;
        }
        [HttpPost]
        public void SetCurUrl([FromForm] string url)
        {
            PlayerService.UrlStack = url;
        }
        public string GetHtmlStack()
        {
            return PlayerService.Instance.GetHtmlStack();
        }
    }
}

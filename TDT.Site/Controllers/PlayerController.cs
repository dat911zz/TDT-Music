using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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

        public int GetCurIndex()
        {
            return PlayerService.CurIndex;
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
    }
}

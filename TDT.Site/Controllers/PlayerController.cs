using Microsoft.AspNetCore.Mvc;
using TDT.Site.Services;

namespace TDT.Site.Controllers
{
    public class PlayerController : Controller
    {
        public bool CheckShowPlayer()
        {
            return PlayerService.GetPlayers().Count > 0;
        }
    }
}

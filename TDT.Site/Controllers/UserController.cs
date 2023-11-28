using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Extensions;
using TDT.Core.Models;
using TDT.Core.Ultils.MVCMessage;
using TDT.Core.Ultils;
using System.Collections.Generic;
using TDT.Core.DTO.Firestore;
using TDT.Core.Helper;

namespace TDT.Site.Controllers
{
    public class UserController : Controller
    {
        public string GetHtmlUserPlaylist()
        {
            if (HttpContext.User.Identity.Name != null)
            {
                ResponseDataDTO<UserPlaylistDTO> res = APICallHelper.Get<ResponseDataDTO<UserPlaylistDTO>>(
                $"User/GetPlaylistds?username={HttpContext.User.Identity.Name}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value
                        ).Result;
                if (res == null)
                {
                    this.MessageContainer().AddMessage("Phiên hết hạn", ToastMessageType.Error);
                }
                else
                {
                    string html = @"
                        <nav class=""zm-navbar zm-navbar-my-playlist"">
                            <ul class=""zm-navbar-menu playlist-personal"">
                                {0}
                            </ul>
                        </nav>
                    ";
                    string temp = "";
                    foreach (var item in res.Data)
                    {
                        PlaylistDTO playlist = DataHelper.GetPlaylist(item.PlaylistId);
                        if (playlist != null)
                        {
                            temp += @"
                                <li class=""zm-navbar-item is-one-row"">
                                    <a class="""" href=""/Album?encodeId={0}"">{1}</a><button
                                        class=""zm-btn zm-tooltip-btn is-hover-circle button"" tabindex=""0"">
                                        <i class=""icon ic-more""></i>
                                    </button>
                                </li>
                            ";
                        }
                    }
                    return string.Format(html, temp);
                }
            }
            return "";
        }
    }
}

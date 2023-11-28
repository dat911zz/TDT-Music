﻿using Microsoft.AspNetCore.Mvc;
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
                            temp += string.Format(@"
                                <li class=""zm-navbar-item is-one-row"">
                                    <a class="""" href=""/Album?encodeId={0}"">{1}</a><button
                                        class=""zm-btn zm-tooltip-btn is-hover-circle button"" tabindex=""0"">
                                        <i class=""icon ic-more""></i>
                                    </button>
                                </li>
                            ", playlist.encodeId, playlist.title);
                        }
                    }
                    return string.Format(html, temp);
                }
            }
            return "";
        }
        public string GetHtmlMenuUserPlaylist()
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
                        <div class=""menu add-playlist-content submenu-content"">
                            <ul class=""menu-list"">
                                <li class=""search-box"">
                                    <input class=""input"" placeholder=""Tìm playlist"" />
                                </li>
                                <li class=""mar-t-10"">
                                    <button class=""zm-btn button"" tabindex=""0"">
                                        <i class=""icon ic- z-ic-svg ic-svg-add""></i><span>Tạo playlist mới</span>
                                    </button>
                                </li>
                            </ul>
                            <div class=""playlist-container"">
                                <div class=""top-shadow""></div>
                                <div class=""content"">
                                    <div style=""position: relative; overflow: hidden; width: 100%; height: 100%"">
                                        <div style=""
                                    position: absolute;
                                    inset: 0px;
                                    overflow: hidden scroll;
                                    margin-right: -6px;
                                    margin-bottom: 0px;
                                  "">
                                            <ul class=""menu-list"">
                                                {0}
                                            </ul>
                                        </div>
                                        <div class=""track-horizontal"" style=""
                                    position: absolute;
                                    height: 6px;
                                    transition: opacity 200ms ease 0s;
                                    opacity: 0;
                                  "">
                                            <div style=""
                                      position: relative;
                                      display: block;
                                      height: 100%;
                                      cursor: pointer;
                                      border-radius: inherit;
                                      background-color: rgba(0, 0, 0, 0.2);
                                      width: 0px;
                                    ""></div>
                                        </div>
                                        <div class=""track-vertical"" style=""
                                    position: absolute;
                                    width: 4px;
                                    transition: opacity 200ms ease 0s;
                                    opacity: 0;
                                    right: 2px;
                                    top: 2px;
                                    bottom: 2px;
                                    z-index: 100;
                                  "">
                                            <div class=""thumb-vertical"" style=""position: relative; display: block; width: 100%; height: 0px"">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ";
                    string temp = "";
                    foreach (var item in res.Data)
                    {
                        PlaylistDTO playlist = DataHelper.GetPlaylist(item.PlaylistId);
                        if (playlist != null)
                        {
                            temp += string.Format(@"
                                <li>
                                    <button class=""zm-btn button"" tabindex=""0"" data-id=""{0}"">
                                        <i class=""icon ic-list-music""></i><span>{1}</span>
                                    </button>
                                </li>
                            ", playlist.encodeId, playlist.title);
                        }
                    }
                    return string.Format(html, temp);
                }
            }
            return "";
        }
    }
}

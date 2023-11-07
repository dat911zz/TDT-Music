﻿using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.ServiceImp;

namespace TDT.Site.Services
{
    public class PlayerService
    {
        #region Singleton
        private static PlayerService _instance;
        private PlayerService() { }
        public static PlayerService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerService();
                }
                return _instance;
            }
        }
        #endregion

        #region Const
        public static int CurIndex = 0;
        public static int CurDuration = 0;
        public static bool IsShuffle = false;
        public static bool IsRepeat = false;
        public static bool IsRepeatOne = false;
        public static bool IsPlaying = false;
        public static string UrlStack = "";
        public static double CurTime = 0;

        private static Dictionary<string, Player> players = new Dictionary<string, Player>();
        private List<Player> StackPlayer = new List<Player>();
        private List<Player> PrevPlayer = new List<Player>();
        private List<Player> History = new List<Player>();

        public string StackFrom = "";
        public string StackTitle = "";
        #endregion

        public static Player NewPlayer(string songId, int index)
        {
            var song = DataHelper.GetSong(songId);
            if (song != null)
            {
                return new Player
                {
                    Id = song.encodeId,
                    Index = index,
                    Name = song.title,
                    Thumbnail = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail),
                    Src = DataHelper.GetMP3(song.encodeId),
                    Artists = Generator.GenerateArtistLink(song.artists),
                    UrlPlaylist = string.IsNullOrEmpty(song.album) ? "" : $"/Album?encodeId={song.album}"
                };
            }
            return null;
        }
        public static Dictionary<string, Player> GetPlayers()
        {
            return players;
        }
        public void ShuffleStack()
        {
            if (StackIsEmpty())
                return;
            Player player = StackPlayer.First();
            StackPlayer.RemoveAt(0);
            StackPlayer.AddRange(PrevPlayer);
            PrevPlayer.Clear();
            if (IsShuffle)
            {
                StackPlayer.Shuffle();
            }
            else
            {
                StackPlayer = StackPlayer.OrderBy(s => s.Index).ToList();
            }
            StackPlayer.Insert(0, player);
        }
        public void ClearStack()
        {
            StackPlayer.Clear();
            PrevPlayer.Clear();
        }
        public void SetPlayer(List<string> songIds)
        {
            Dictionary<string, Player> temp = new Dictionary<string, Player>();
            int i = 0;
            foreach (string songId in songIds)
            {
                Player player = null;
                if (players.ContainsKey(songId))
                {
                    if(!temp.ContainsKey(songId))
                    {
                        player = players[songId];
                        player.Index = i++;
                        temp.Add(songId, player);
                    }
                    continue;
                }
                player = NewPlayer(songId, i);
                if (player != null)
                {
                    i++;
                    players.Add(songId, player);
                    temp.Add(songId, players[songId]);
                }
            }
            if(temp.Count > 0)
            {
                players = temp;
                PrevPlayer.Clear();
                StackPlayer = players.Values.ToList();
                ShuffleStack();
            }
        }
        public bool StackIsEmpty()
        {
            return StackPlayer.Count == 0;
        }
        public bool HistoryIsEmpty()
        {
            return History.Count == 0;
        }
        public Player ChangeMusic(string type = "init")
        {
            try
            {
                if(StackIsEmpty())
                {
                    if(IsRepeat)
                    {
                        StackPlayer.AddRange(PrevPlayer);
                        PrevPlayer.Clear();
                        return ChangeMusic();
                    }
                    return null;
                }    
                if(!IsRepeatOne)
                {
                    if (type == "next")
                    {
                        PrevPlayer.Add(StackPlayer.First());
                        StackPlayer.RemoveAt(0);
                        return ChangeMusic();
                    }
                    if (type == "prev")
                    {
                        if (PrevPlayer.Count == 0)
                            return null;
                        StackPlayer.Insert(0, PrevPlayer.Last());
                        PrevPlayer.RemoveAt(PrevPlayer.Count - 1);
                        return ChangeMusic();
                    }
                }
                return StackPlayer.First();
            }
            catch
            {
                return null;
            }
        }
        public void ChoosePlayer(int index, string id)
        {
            int i = 0;
            bool containsStack = false;
            bool containsHistory = false;
            foreach (Player player in StackPlayer)
            {
                if (player.Id == id && player.Index == index)
                {
                    containsStack = true;
                    break;
                }
                i++;
            }
            if(!containsStack)
            {
                i = 0;
                foreach (Player player in PrevPlayer)
                {
                    if (player.Id == id && player.Index == index)
                    {
                        containsHistory = true;
                        break;
                    }
                    i++;
                }
            }
            
            if (containsStack)
            {
                for(int iS = 0; iS < i; iS++)
                {
                    PrevPlayer.Add(StackPlayer[iS]);
                }
                StackPlayer.RemoveRange(0, i);
            }
            else if(containsHistory)
            {
                for(int iH = PrevPlayer.Count - 1; iH >= i; iH--)
                {
                    StackPlayer.Insert(0, PrevPlayer[iH]);
                }
                PrevPlayer.RemoveRange(i, PrevPlayer.Count - i);
            }
            else
            {
                PrevPlayer.Clear();
                StackPlayer.Clear();
                StackPlayer.Add(NewPlayer(id, index));
            }
        }

        #region Html
        public string GetHtmlStack()
        {
            if (StackIsEmpty())
                return "";
            string itemActive = GetHtmlItemSongActiveInStack();
            string list = GetHtmlSongsInStack();
            string recommend = "";
            List<SongDTO> songs = DataHelper.Instance.Songs.Values.Take(5).ToList();
            foreach (SongDTO song in songs)
            {
                recommend += GetHtmlItemRecommend(song);
            }
            string res = @"
                <div class=""player-queue player-queue-animation-exit player-queue-animation-exit-active"">
                    <div class=""player-queue__container"">
                        <div class=""player-queue__header"">
                            <div class=""level tab-bars"">
                                <div class=""level-left"">
                                    <div class=""level-item is-active"">
                                        <h6 class=""has-text-white queue-list-title"">Danh sách phát</h6>
                                    </div>
                                    <div class=""level-item"">
                                        <h6 class=""has-text-white"">Nghe gần đây</h6>
                                    </div>
                                </div>
                                <div class=""level-right"">
                                    <div class=""level"">
                                        <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                                tabindex=""0""><i class=""icon ic-20-Clock""></i></button></div>
                                        <div class=""level-item""><span id=""queue_menu""><button
                                                    class=""zm-btn zm-tooltip-btn is-hover-circle button"" tabindex=""0""><i
                                                        class=""icon ic-more""></i></button></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""player-queue__scroll"">
                            <div class=""queue-item-pinned show"" style=""--transition: 0px; height: unset; display: block; z-index: 1000000;"">
                                "
                                    + itemActive + GetHtmlHeaderNextSong() +
                               @"
                            </div>
                            <div tabindex=""0"" style=""position: relative; overflow: hidden; width: 100%; height: 100%;"">
                                <div id=""queue-scroll""
                                    style=""position: absolute; inset: 0px; overflow: hidden scroll; margin-right: -6px; margin-bottom: 0px;"">
                                    <div style=""width: 100%; height: 100%; position: absolute; top: 0px;"">
                                        <div class=""player-queue__list undefined""
                                            style=""box-sizing: border-box; margin-top: 0px; padding-top:116px;"">
                                            " 
                                                + list + 
                                            @"
                                        </div>
                                        <div>
                                            <div id=""queue-recommend"" style=""padding: 0px 8px;"">
                                                <div class=""queue-recommend"">
                                                    <div class=""header-wrapper""
                                                        style=""position: relative; top: 0; right: 0; --header-wrapper-bg: transparent;"">
                                                        <div class=""level header"">
                                                            <div class=""header-left level-left"">
                                                                <h3 class=""title"">Tự động phát</h3>
                                                                <h3 class=""subtitle"">Gợi ý từ nội dung đang phát</h3>
                                                            </div>
                                                            <div class=""level-right""><button
                                                                    class=""zm-btn zm-auto-play-switch pull-left button"" tabindex=""0""><i
                                                                        class=""icon ic-svg-switch""><svg id=""Layer_1"" x=""0px"" y=""0px""
                                                                            width=""24px"" height=""15px"" viewBox=""0 0 24 15""
                                                                            xml:space=""preserve"">
                                                                            <style type=""text/css"">
                                                                                .st1 {
                                                                                    fill-rule: evenodd;
                                                                                    clip-rule: evenodd;
                                                                                    fill: #FFFFFF;
                                                                                }
                                                                            </style>
                                                                            <path id=""Rectangle-8"" class=""st0""
                                                                                d=""M16.5,0h-9C3.4,0,0,3.4,0,7.5l0,0C0,11.6,3.4,15,7.5,15h9c4.1,0,7.5-3.4,7.5-7.5l0,0 C24,3.4,20.6,0,16.5,0z"">
                                                                            </path>
                                                                            <circle id=""Oval-2"" class=""st1"" cx=""16.5"" cy=""7.5"" r=""6.5"">
                                                                            </circle>
                                                                        </svg></i></button></div>
                                                        </div>
                                                    </div>
                                                    <div style=""height: 0px;""></div>
                                                    <div class=""list player-queue__list"">
                                                        "
                                                        + recommend +
                                                        @"
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class=""track-horizontal""
                                    style=""position: absolute; height: 6px; transition: opacity 200ms ease 0s; opacity: 0;"">
                                    <div
                                        style=""position: relative; display: block; height: 100%; cursor: pointer; border-radius: inherit; background-color: rgba(0, 0, 0, 0.2); width: 0px;"">
                                    </div>
                                </div>
                                <div class=""track-vertical""
                                    style=""position: absolute; width: 4px; transition: opacity 200ms ease 0s; opacity: 0; right: 2px; top: 2px; bottom: 2px; z-index: 100;"">
                                    <div class=""thumb-vertical""
                                        style=""position: relative; display: block; width: 100%; height: 30px; transform: translateY(122.256px);"">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            return res;
        }
        public string GetHtmlChangeStack()
        {
            if (StackIsEmpty())
                return "";
            string itemActive = GetHtmlItemSongActiveInStack();
            string list = GetHtmlSongsInStack();
            string recommend = "";
            List<SongDTO> songs = DataHelper.Instance.Songs.Values.Take(5).ToList();
            foreach (SongDTO song in songs)
            {
                recommend += GetHtmlItemRecommend(song);
            }
            string res = @"
                        <div class=""player-queue__scroll"">
                            <div class=""queue-item-pinned show"" style=""--transition: 0px; height: unset; display: block; z-index: 1000000;"">
                                "
                                    + itemActive + GetHtmlHeaderNextSong() +
                               @"
                            </div>
                            <div tabindex=""0"" style=""position: relative; overflow: hidden; width: 100%; height: 100%;"">
                                <div id=""queue-scroll""
                                    style=""position: absolute; inset: 0px; overflow: hidden scroll; margin-right: -6px; margin-bottom: 0px;"">
                                    <div style=""width: 100%; height: 100%; position: absolute; top: 0px;"">
                                        <div class=""player-queue__list undefined""
                                            style=""box-sizing: border-box; margin-top: 0px; padding-top:116px;"">
                                            "
                                                + list +
                                            @"
                                        </div>
                                        <div>
                                            <div id=""queue-recommend"" style=""padding: 0px 8px;"">
                                                <div class=""queue-recommend"">
                                                    <div class=""header-wrapper""
                                                        style=""position: relative; top: 0; right: 0; --header-wrapper-bg: transparent;"">
                                                        <div class=""level header"">
                                                            <div class=""header-left level-left"">
                                                                <h3 class=""title"">Tự động phát</h3>
                                                                <h3 class=""subtitle"">Gợi ý từ nội dung đang phát</h3>
                                                            </div>
                                                            <div class=""level-right""><button
                                                                    class=""zm-btn zm-auto-play-switch pull-left button"" tabindex=""0""><i
                                                                        class=""icon ic-svg-switch""><svg id=""Layer_1"" x=""0px"" y=""0px""
                                                                            width=""24px"" height=""15px"" viewBox=""0 0 24 15""
                                                                            xml:space=""preserve"">
                                                                            <style type=""text/css"">
                                                                                .st1 {
                                                                                    fill-rule: evenodd;
                                                                                    clip-rule: evenodd;
                                                                                    fill: #FFFFFF;
                                                                                }
                                                                            </style>
                                                                            <path id=""Rectangle-8"" class=""st0""
                                                                                d=""M16.5,0h-9C3.4,0,0,3.4,0,7.5l0,0C0,11.6,3.4,15,7.5,15h9c4.1,0,7.5-3.4,7.5-7.5l0,0 C24,3.4,20.6,0,16.5,0z"">
                                                                            </path>
                                                                            <circle id=""Oval-2"" class=""st1"" cx=""16.5"" cy=""7.5"" r=""6.5"">
                                                                            </circle>
                                                                        </svg></i></button></div>
                                                        </div>
                                                    </div>
                                                    <div style=""height: 0px;""></div>
                                                    <div class=""list player-queue__list"">
                                                        "
                                                        + recommend +
                                                        @"
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class=""track-horizontal""
                                    style=""position: absolute; height: 6px; transition: opacity 200ms ease 0s; opacity: 0;"">
                                    <div
                                        style=""position: relative; display: block; height: 100%; cursor: pointer; border-radius: inherit; background-color: rgba(0, 0, 0, 0.2); width: 0px;"">
                                    </div>
                                </div>
                                <div class=""track-vertical""
                                    style=""position: absolute; width: 4px; transition: opacity 200ms ease 0s; opacity: 0; right: 2px; top: 2px; bottom: 2px; z-index: 100;"">
                                    <div class=""thumb-vertical""
                                        style=""position: relative; display: block; width: 100%; height: 30px; transform: translateY(122.256px);"">
                                    </div>
                                </div>
                            </div>
                        </div>
            ";
            return res;
        }
        public string GetHtmlHistory()
        {
            if(HistoryIsEmpty())
            {
                return @"
                    <div class=""player-queue__scroll"">
                        <div class=""empty-img""></div>
                        <div class=""empty-queue"">
                            <div class=""content"">Khám phá thêm các bài hát mới của TDT</div><button
                                class=""zm-btn is-outlined active button"" tabindex=""0""><i class=""icon ic-play""></i><span>Phát nhạc mới phát
                                    hành</span></button>
                        </div>
                    </div>
                ";
            }
            string res = @"
                <div class=""player-queue__scroll"">
                    <div style=""position: relative; overflow: hidden; width: 100%; height: 100%;"">
                        <div id=""queue-scroll""
                            style=""position: absolute; inset: 0px; overflow: hidden scroll; margin-right: -6px; margin-bottom: 0px;"">
                            <div class=""list player-queue__list"">
                                {0}
                            </div>
                        </div>
                        <div class=""track-horizontal""
                            style=""position: absolute; height: 6px; transition: opacity 200ms ease 0s; opacity: 0;"">
                            <div
                                style=""position: relative; display: block; height: 100%; cursor: pointer; border-radius: inherit; background-color: rgba(0, 0, 0, 0.2); width: 0px;"">
                            </div>
                        </div>
                        <div class=""track-vertical""
                            style=""position: absolute; width: 4px; transition: opacity 200ms ease 0s; opacity: 0; right: 2px; top: 2px; bottom: 2px; z-index: 100;"">
                            <div class=""thumb-vertical""
                                style=""position: relative; display: block; width: 100%; height: 30px; transform: translateY(0px);""></div>
                        </div>
                    </div>
                </div>
            ";
            return string.Format(res, GetHtmlSongsInHistory());
        }
        public string GetHtmlSongsInStack()
        {
            string list = "";
            for (int i = 0; i < PrevPlayer.Count; i++)
            {
                if (!string.IsNullOrEmpty(PrevPlayer[i].Src))
                {
                    list += GetHtmlItemSongInPrev(PrevPlayer[i]);
                }
            }
            for (int i = 1; i < StackPlayer.Count; i++)
            {
                if (!string.IsNullOrEmpty(StackPlayer[i].Src))
                {
                    list += GetHtmlItemSongInStack(StackPlayer[i]);
                }
            }
            return list;
        }
        public string GetHtmlSongsInHistory()
        {
            string list = "";
            for (int i = 1; i < History.Count; i++)
            {
                if (!string.IsNullOrEmpty(StackPlayer[i].Src))
                {
                    list += GetHtmlItemSongInHistory(StackPlayer[i]);
                }
            }
            return list;
        }
        public static string GetHtmlItemSongActiveInStack()
        {
            if (PlayerService.Instance.StackIsEmpty())
                return "";
            Player player = PlayerService.Instance.StackPlayer[0];
            SongDTO song = DataHelper.GetSong(player.Id);
            string img = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
            string res = @"
                <div class=""list-item media-item full-left"">
                    <div class=""media is-active"">
                        <div class=""media-left"">
                            <div class=""song-thumb active"">
                                <figure class=""image is-40x40"" title=""{0}""><img src=""{1}"" alt=""""></figure>
                                <div class=""opacity ""></div>
                                <div class=""zm-actions-container"">
                                    <div class=""zm-box zm-actions""><button
                                            class=""zm-btn zm-tooltip-btn animation-like is-hidden active is-hover-circle button""
                                            tabindex=""0""><i class=""icon ic-like""></i><i
                                                class=""icon ic-like-full""></i></button><button
                                            class=""zm-btn action-play  button"" tabindex=""0""><i
                                                class=""icon action-play ic-gif-playing-white""></i></button><button
                                            class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button""
                                            tabindex=""0""><i class=""icon ic-more""></i></button></div>
                                </div>
                            </div>
                            <div class=""card-info"">
                                <div class=""title-wrapper""><span class=""item-title title""><span><span><span>{0}</span></span><span
                                                style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></span>
                                </div>
                                <h3 class=""is-one-line is-truncate subtitle"">{2}</h3>
                            </div>
                        </div>
                        <div class=""media-right"">
                            <div class=""level"">
                                <div class=""level-item""><button
                                        class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                        tabindex=""0""><i class=""icon ic-like""></i><i
                                            class=""icon ic-like-full""></i></button></div>
                                <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                        tabindex=""0""><i class=""icon ic-more""></i></button></div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            return string.Format(res, song.title, img, Generator.GenerateArtistLink(song.artists));
        }
        public static string GetHtmlHeaderNextSong()
        {
            string sub = "";
            if(!string.IsNullOrEmpty(PlayerService.Instance.StackFrom) && !string.IsNullOrEmpty(PlayerService.Instance.StackTitle))
            {
                sub = string.Format(@"
                    <h3 class=""subtitle is-6""><span>Từ {0}</span><a class=""""
                            href=""{1}""><span><span><span><span>{2}</span></span></span><span
                                    style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></a>
                    </h3>
                ", PlayerService.Instance.StackFrom, UrlStack, PlayerService.Instance.StackTitle);
            }
            string res = @"
                <div class=""next-songs"">
                    <h3 class=""title is-6"">Tiếp theo</h3>
                    {0}
                </div>
            ";
            return string.Format(res, sub);
        }
        public static string GetHtmlItemSongInStack(Player player)
        {
            SongDTO song = DataHelper.GetSong(player.Id);
            string img = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
            string res = @"
                <div data-index=""{0}"" data-id=""{4}"" style=""z-index: 1065;"">
                    <div>
                        <div class=""list-item media-item full-left"">
                            <div class=""media"">
                                <div class=""media-left"">
                                    <div class=""song-thumb"">
                                        <figure class=""image is-40x40"" title=""{1}""><img src=""{2}"" alt=""""></figure>
                                        <div class=""opacity ""></div>
                                        <div class=""zm-actions-container"">
                                            <div class=""zm-box zm-actions""><button
                                                    class=""zm-btn zm-tooltip-btn animation-like is-hidden active is-hover-circle button""
                                                    tabindex=""0""><i class=""icon ic-like""></i><i
                                                        class=""icon ic-like-full""></i></button><button
                                                    class=""zm-btn action-play  button"" tabindex=""0""><i
                                                        class=""icon action-play ic-play""></i></button><button
                                                    class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0""><i
                                                        class=""icon ic-more""></i></button></div>
                                        </div>
                                    </div>
                                    <div class=""card-info"">
                                        <div class=""title-wrapper""><span class=""item-title title""><span><span><span>{1}</span></span><span
                                                        style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></span>
                                        </div>
                                        <h3 class=""is-one-line is-truncate subtitle"">{3}</h3>
                                    </div>
                                </div>
                                <div class=""media-right"">
                                    <div class=""level"">
                                        <div class=""level-item""><button
                                                class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                                tabindex=""0""><i class=""icon ic-like""></i><i class=""icon ic-like-full""></i></button>
                                        </div>
                                        <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                                tabindex=""0""><i class=""icon ic-more""></i></button></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            return string.Format(res, player.Index, song.title, img, Generator.GenerateArtistLink(song.artists), song.encodeId);
        }
        public static string GetHtmlItemSongInHistory(Player player)
        {
            SongDTO song = DataHelper.GetSong(player.Id);
            string img = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
            string res = @"
                <div data-id=""{0}"" data-index=""{1}"" class=""list-item media-item full-left"">
                    <div class=""media"">
                        <div class=""media-left"">
                            <div class=""song-thumb"">
                                <figure class=""image is-40x40"" title=""{2}""><img src=""{3}"" alt=""""></figure>
                                <div class=""opacity ""></div>
                                <div class=""zm-actions-container"">
                                    <div class=""zm-box zm-actions""><button
                                            class=""zm-btn zm-tooltip-btn animation-like is-hidden active is-hover-circle button""
                                            tabindex=""0""><i class=""icon ic-like""></i><i
                                                class=""icon ic-like-full""></i></button><button
                                            class=""zm-btn action-play  button"" tabindex=""0""><i
                                                class=""icon action-play ic-play""></i></button><button
                                            class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0""><i
                                                class=""icon ic-more""></i></button></div>
                                </div>
                            </div>
                            <div class=""card-info"">
                                <div class=""title-wrapper""><span class=""item-title title""><span><span><span>{2}</span></span><span
                                                style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></span>
                                </div>
                                <h3 class=""is-one-line is-truncate subtitle"">{4}</h3>
                            </div>
                        </div>
                        <div class=""media-right"">
                            <div class=""level"">
                                <div class=""level-item""><button
                                        class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                        tabindex=""0""><i class=""icon ic-like""></i><i class=""icon ic-like-full""></i></button>
                                </div>
                                <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                        tabindex=""0""><i class=""icon ic-more""></i></button></div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            return string.Format(res, song.encodeId, player.Index, song.title, img, Generator.GenerateArtistLink(song.artists));
        }
        public static string GetHtmlItemSongInPrev(Player player)
        {
            SongDTO song = DataHelper.GetSong(player.Id);
            string img = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
            string res = @"
                <div data-index=""{0}"" data-id=""{4}"" style=""z-index: 1065;"">
                    <div>
                        <div class=""list-item media-item full-left"">
                            <div class=""media is-pre"">
                                <div class=""media-left"">
                                    <div class=""song-thumb"">
                                        <figure class=""image is-40x40"" title=""{1}""><img src=""{2}"" alt=""""></figure>
                                        <div class=""opacity ""></div>
                                        <div class=""zm-actions-container"">
                                            <div class=""zm-box zm-actions""><button
                                                    class=""zm-btn zm-tooltip-btn animation-like is-hidden active is-hover-circle button""
                                                    tabindex=""0""><i class=""icon ic-like""></i><i
                                                        class=""icon ic-like-full""></i></button><button
                                                    class=""zm-btn action-play  button"" tabindex=""0""><i
                                                        class=""icon action-play ic-play""></i></button><button
                                                    class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0""><i
                                                        class=""icon ic-more""></i></button></div>
                                        </div>
                                    </div>
                                    <div class=""card-info"">
                                        <div class=""title-wrapper""><span class=""item-title title""><span><span><span>{1}</span></span><span
                                                        style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></span>
                                        </div>
                                        <h3 class=""is-one-line is-truncate subtitle"">{3}</h3>
                                    </div>
                                </div>
                                <div class=""media-right"">
                                    <div class=""level"">
                                        <div class=""level-item""><button
                                                class=""zm-btn zm-tooltip-btn animation-like undefined active is-hover-circle button""
                                                tabindex=""0""><i class=""icon ic-like""></i><i class=""icon ic-like-full""></i></button>
                                        </div>
                                        <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button""
                                                tabindex=""0""><i class=""icon ic-more""></i></button></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            return string.Format(res, player.Index, song.title, img, Generator.GenerateArtistLink(song.artists), song.encodeId);
        }
        public static string GetHtmlItemRecommend(SongDTO song)
        {
            string img = DataHelper.GetThumbnailSong(song.encodeId, song.thumbnail);
            string res = @"
                <div class=""list-item media-item full-left"">
                    <div class=""media"">
                        <div class=""media-left"">
                            <div class=""song-thumb"">
                                <figure class=""image is-40x40"" title=""{0}""><img src=""{1}"" alt=""""></figure>
                                <div class=""opacity ""></div>
                                <div class=""zm-actions-container"">
                                    <div class=""zm-box zm-actions""><button
                                            class=""zm-btn zm-tooltip-btn animation-like is-hidden active is-hover-circle button""
                                            tabindex=""0""><i class=""icon ic-like""></i><i class=""icon ic-like-full""></i></button><button
                                            class=""zm-btn action-play  button"" tabindex=""0""><i
                                                class=""icon action-play ic-play""></i></button><button
                                            class=""zm-btn zm-tooltip-btn is-hidden is-hover-circle button"" tabindex=""0""><i
                                                class=""icon ic-more""></i></button>
                                    </div>
                                </div>
                            </div>
                            <div class=""card-info"">
                                <div class=""title-wrapper""><span class=""item-title title""><span><span><span>{0}</span></span><span
                                                style=""position: fixed; visibility: hidden; top: 0px; left: 0px;"">…</span></span></span>
                                </div>
                                <h3 class=""is-one-line is-truncate subtitle"">{2}</h3>
                            </div>
                        </div>
                        <div class=""media-right"">
                            <div class=""level"">
                                <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button"" tabindex=""0""><i
                                            class=""icon ic-add-play-now""></i></button></div>
                                <div class=""level-item""><button class=""zm-btn zm-tooltip-btn is-hover-circle button"" tabindex=""0""><i
                                            class=""icon ic-more""></i></button></div>
                            </div>
                        </div>
                    </div>
                </div>
            ";
            return string.Format(res, song.title, img, Generator.GenerateArtistLink(song.artists));
        }

        #endregion
    }

    public class Player
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string Src { get; set; }
        public string Artists { get; set; }
        public string UrlPlaylist { get; set; }
    }
}

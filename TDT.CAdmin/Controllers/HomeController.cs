using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TDT.Core.Extensions;
using TDT.CAdmin.Filters;
using TDT.CAdmin.Models;
using TDT.Core.DTO;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;
using TDT.IdentityCore.Utils;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using static TDT.Core.Ultils.HelperUtility;
using System.Threading;
using Newtonsoft.Json;
using TDT.Core.DTO.Firestore;
using X.PagedList;
using static TDT.Core.DTO.Firestore.SongDTO;
using TDT.Core.Helper;

namespace TDT.CAdmin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<SongDTO> _songs;
        private List<Genre> _genres;
        private List<ArtistDTO> _artist;
        private List<PlaylistDTO> _playlist;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            GetDataSongs();
            GetDataGenre();
            GetDataArtist();
            GetDataPlaylist();
            #region Load all data if newer
            DataBindings.Instance.LoadDataFromAPI(HttpContext, _logger);
            #endregion
        }

        //public IActionResult Index()
        //{
        //    SecurityHelper.ImportControllerAction(Assembly.GetExecutingAssembly().GetAllControllerAction());
        //    _logger.LogInformation("Start session");

        //    if (string.IsNullOrEmpty(HttpContext.Session.GetString("NotifyUpdate")))
        //    {
        //        this.MessageContainer().AddMessage(
        //        "Tính năng thông báo đã được cập nhật! " +
        //        "Có thể sử dụng được tại các controller. " +
        //        "Chi tiết vui lòng liên hệ Vũ Đạt để được biết thêm.",
        //        ToastMessageType.Info
        //        );
        //        HttpContext.Session.SetString("NotifyUpdate", "1");
        //    }

        //    #region Example for using Toast message
        //    //this.MessageContainer().AddException(new Exception("HEHE?"));
        //    //this.MessageContainer().AddErrorFlashMessage("Có lỗi xảy ra, vui lòng thực hiện lại!");
        //    //this.MessageContainer().AddMessage("OK nè!", ToastMessageType.Success);
        //    //this.MessageContainer().AddMessage("Cảnh báo nè!", ToastMessageType.Warning);
        //    //this.MessageContainer().AddMessage("Thông báo nè!", ToastMessageType.Info);
        //    //this.MessageContainer().AddMessage("Lỗi do mèo làm nè!", ToastMessageType.Error);
        //    #endregion

        //    //var test = Directory.GetCurrentDirectory();
        //    //ResponseDataDTO<User> userDetail = APICallHelper.Get<ResponseDataDTO<User>>("user", token: auth.Token).Result;
        //    //ResponseDataDTO<User> res = APICallHelper.Get<ResponseDataDTO<User>>($"user/{pUser}", token: auth.Token).Result;
        //    return View();
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode, string msg = "Có lỗi đã xảy ra!")
        {
            ViewBag.ErrorCode = statusCode != 0 ? statusCode : 404;
            if (statusCode == 401)
           {
                msg = "Truy cập bị từ chối!";
            }
            ViewBag.ErrorContent = msg;
            return View();
        }
        private void GetDataSongs()
        {
            if (DataHelper.Instance.Songs.Count <= 0)
            {
                _songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}");
                if (_songs != null)
                {
                    foreach (SongDTO song in _songs)
                    {
                        if (!DataHelper.Instance.Songs.Keys.Contains(song.encodeId))
                        {
                            DataHelper.Instance.Songs.Add(song.encodeId, song);
                        }
                    }
                }
            }
            else
            {
                _songs = DataHelper.Instance.Songs.Values.ToList();
            }
        }
        public void GetDataGenre()
        {
            if (DataHelper.Instance.Genres.Count <= 0)
            {
                _genres = APIHelper.Gets<Genre>($"{FirestoreService.CL_Genre}");
                if (_genres != null)
                {
                    foreach (Genre genre in _genres)
                    {
                        if (!DataHelper.Instance.Genres.Keys.Contains(genre.id))
                        {
                            DataHelper.Instance.Genres.Add(genre.id, genre);
                        }
                    }
                }
            }
            else
            {
                _genres = DataHelper.Instance.Genres.Values.ToList();
            }
        }
        public void GetDataArtist()
        {
            if (DataHelper.Instance.Artists.Count <= 0)
            {
                _artist = APIHelper.Gets<ArtistDTO>($"{FirestoreService.CL_Artist}");
                if (_artist != null)
                {
                    foreach (ArtistDTO artist in _artist)
                    {
                        if (!DataHelper.Instance.Artists.Keys.Contains(artist.id))
                        {
                            DataHelper.Instance.Artists.Add(artist.id, artist);
                        }
                    }
                }
            }
            else
            {
                _artist = DataHelper.Instance.Artists.Values.ToList();
            }
        }
        public void GetDataPlaylist()
        {
            if (DataHelper.Instance.Playlists.Count <= 0)
            {
                _playlist = APIHelper.Gets<PlaylistDTO>($"{FirestoreService.CL_Playlist}");
                if (_playlist != null)
                {
                    foreach (PlaylistDTO playlist in _playlist)
                    {
                        if (!DataHelper.Instance.Playlists.Keys.Contains(playlist.encodeId))
                        {
                            DataHelper.Instance.Playlists.Add(playlist.encodeId, playlist);
                        }
                    }
                }
            }
            else
            {
                _playlist = DataHelper.Instance.Playlists.Values.ToList();
            }
        }
        private void LoadDataIfNeeded()
        {
            if (DataHelper.Instance.Songs.Count <= 0)
            {
                _songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}");
                if (_songs != null)
                {
                    foreach (SongDTO song in _songs)
                    {
                        if (!DataHelper.Instance.Songs.Keys.Contains(song.encodeId))
                        {
                            DataHelper.Instance.Songs.Add(song.encodeId, song);
                        }
                    }
                }
            }
        }
        private List<Tuple<string, int>> GetTopLikedSongsStats()
        {
            LoadDataIfNeeded();
            var sortedSongs = DataHelper.Instance.Songs.Values.OrderByDescending(song => song.like).ToList();
            var topLikedSongs = sortedSongs.Take(5).ToList();
            var likeStatsList = new List<Tuple<string, int>>();
            foreach (var song in topLikedSongs)
            {
                var likeStats = Tuple.Create(song.title, song.like);
                likeStatsList.Add(likeStats);
            }
            return likeStatsList;
        }
        public IActionResult Index()
        {
            LoadDataIfNeeded();
            int totalSongs = DataHelper.Instance.Songs.Count;
            int totalGenres = DataHelper.Instance.Genres.Count;
            int totalArtists = DataHelper.Instance.Artists.Count;
            int totalPlaylist = DataHelper.Instance.Playlists.Count;
            int totalComments = DataHelper.Instance.Songs.Values.Sum(song => song.comment);
            int totalLikes = DataHelper.Instance.Songs.Values.Sum(song => song.like);
            int totalListens = DataHelper.Instance.Songs.Values.Sum(song => song.listen);
            int totalDistributors = DataHelper.Instance.Songs.Select(song => song.Value.distributor).Distinct().Count();
            ViewBag.TotalSongs = totalSongs;
            ViewBag.TotalGenres = totalGenres;
            ViewBag.TotalArtists = totalArtists;
            ViewBag.TotalPlaylist = totalPlaylist;
            ViewBag.TotalComments = totalComments;
            ViewBag.TotalLikes = totalLikes;
            ViewBag.TotalListens = totalListens;
            ViewBag.TotalDistributors = totalDistributors;
            var topLikedSongsStats = GetTopLikedSongsStats();
            ViewBag.TopLikedSongsStats = topLikedSongsStats;
            return View();
        }
    }
}

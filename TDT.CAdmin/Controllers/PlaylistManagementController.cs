using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.DTO.Firestore;
using TDT.Core.Extensions;
using TDT.Core.Helper;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;
using X.PagedList;

namespace TDT.CAdmin.Controllers
{
    public class PlaylistManagementController : Controller
    {
        private List<PlaylistDTO> _playlists;
        public PlaylistManagementController()
        {
            GetDataPlayList();
        }
        public void GetDataPlayList()
        {
            if (DataHelper.Instance.Playlists.Count <= 0)
            {
                _playlists = APIHelper.Gets<PlaylistDTO>($"{FirestoreService.CL_Playlist}"+ "/Gets");

                if (_playlists != null)
                {
                    foreach (PlaylistDTO playlist in _playlists)
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
                _playlists = DataHelper.Instance.Playlists.Values.ToList();
            }
        }
        public IActionResult Index(string searchTerm, int? page)
        {
            ViewBag.SearchTerm = "";
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<PlaylistDTO> lsong = _playlists;

            if (DataHelper.Instance.Playlists.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    lsong = _playlists.Where(r => r.title.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                    ViewBag.SoBH = lsong.Count;
                }
            }
            IPagedList<PlaylistDTO> pagedList = lsong == null ? new List<PlaylistDTO>().ToPagedList() : lsong.OrderByDescending(o => o.releaseDate).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
        [HttpGet]
        public string LoadImg(string encodeID, string thumbnail)
        {
            //string img;
            //img = FirebaseService.Instance.getStorage(thumbnail);

            string img;
            if (DataHelper.Instance.ThumbPlaylist.Keys.Contains(encodeID))
            {
                img = DataHelper.Instance.ThumbPlaylist[encodeID];
            }
            else
            {
                img = FirebaseService.Instance.getStorage( thumbnail);
                try
                {
                    DataHelper.Instance.ThumbPlaylist.Add(encodeID, img);
                }
                catch { }
            }
            return img;
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(PlaylistDTO song, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0 && file.ContentType == "audio/mpeg")
                {

                }
            }

            return View();
        }


        public IActionResult Edit(string? encodeId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(PlaylistDTO song)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            ResponseDataDTO<PlaylistDTO> playlistDTO = APICallHelper.Delete<ResponseDataDTO<PlaylistDTO>>($"Playlist/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (playlistDTO.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage("Xóa play list thành công!", ToastMessageType.Success);
            }
            else
            {
                this.MessageContainer().AddFlashMessage(playlistDTO.Msg, ToastMessageType.Error);
            }
            return new JsonResult("ok");
        }
        public IActionResult Details(string id)
        {
            PlaylistDTO playlist = new PlaylistDTO();
            if (id != null)
            {
                playlist = _playlists.FirstOrDefault(s => s.encodeId.Equals(id));
                return View(playlist);

            }
            return View();
        }
    }
}

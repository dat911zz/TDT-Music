using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Helper;
using TDT.Core.ModelClone;
using TDT.Core.Ultils;
using X.PagedList;

namespace TDT.CAdmin.Controllers
{
    public class PlaylistManagementController : Controller
    {
        List<PlaylistDTO> _playlists = new List<PlaylistDTO>();

        public PlaylistManagementController()
        {
            if (DataHelper.Instance.Playlists.Count <= 0)
            {
                HttpService httpService = new HttpService(APICallHelper.DOMAIN + "Playlist/load");
                string json = httpService.getJson();
                _playlists = ConvertService.Instance.convertToObjectFromJson<List<PlaylistDTO>>(json);
            }
            else
            {
                _playlists = DataHelper.Instance.Playlists.Values.ToList();
            }
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

        public IActionResult Index(int? page)
        {
            if (_playlists != null)
            {
                int pageNumber = (page ?? 1);
                int pageSize = 10; 
                IPagedList<PlaylistDTO> pagedList = _playlists.ToPagedList(pageNumber, pageSize);
                return View(pagedList);
            }
            return View();
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

        public IActionResult Delete(string id)
        {
            PlaylistDTO playlist = new PlaylistDTO();
            if (id != null)
            {
                playlist = _playlists.FirstOrDefault(s => s.encodeId.Equals(id));
                return View(playlist);

            }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteS(string id)
        {
            PlaylistDTO playlist = new PlaylistDTO();
            if (id != null)
            {
                playlist = _playlists.FirstOrDefault(s => s.encodeId.Equals(id));
                return View(playlist);

            }
            return View();
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

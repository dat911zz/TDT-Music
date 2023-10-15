using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDT.Core.DTO;
using TDT.Core.Ultils;
using Microsoft.AspNetCore.Http;
using TDT.Core.Helper;
using System.Linq;
using X.PagedList;
using TDT.Core.ModelClone;
using System.Text;

namespace TDT.CAdmin.Controllers
{
    public class MusicManagementController : Controller
    {
        List<SongDTO> _songs = new List<SongDTO>();

        public MusicManagementController()
        {
            if (DataHelper.Instance.Songs.Count <= 0)
            {
                HttpService httpService = new HttpService(APICallHelper.DOMAIN + "Song/load");
                string json = httpService.getJson();
                _songs = ConvertService.Instance.convertToObjectFromJson<List<SongDTO>>(json);
            }
            else
            {
                _songs = DataHelper.Instance.Songs.Values.ToList();
            }
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

        public IActionResult Index(int? page)
        {
            if (_songs != null)
            {
                int pageNumber = (page ?? 1);
                int pageSize = 10; // 

                List<SongDTO> lsong = _songs.ToList();
                IPagedList<SongDTO> pagedList = lsong.ToPagedList(pageNumber, pageSize);

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
            if (DataHelper.Instance.ThumbSong.Keys.Contains(encodeID))
            {
                img = DataHelper.Instance.ThumbSong[encodeID];
            }
            else
            {
                img = FirebaseService.Instance.getStorage(thumbnail);
                DataHelper.Instance.ThumbSong.Add(encodeID, img);
            }
            return img;
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(SongDTO song, IFormFile file)
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
        public IActionResult Edit(SongDTO song)
        {
            return View();
        }

        public IActionResult Delete(string id)
        {
            SongDTO song = new SongDTO();
            if (id != null)
            {
                song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
                return View(song);

            }
            return View();
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteS(string id)
        {
            SongDTO song = new SongDTO();
            if (id != null)
            {
                song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
                return View(song);

            }
            return View();
        }
        public IActionResult Details(string id)
        {
            SongDTO song = new SongDTO();
            if(id != null)
            {
                song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
                return View(song);

            }
            return View();
        }
    }
}

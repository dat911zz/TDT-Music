using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TDT.Core.Ultils;
using Microsoft.AspNetCore.Http;
using TDT.Core.Helper;
using System.Linq;
using X.PagedList;
using TDT.Core.DTO.Firestore;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System.Threading.Tasks;

namespace TDT.CAdmin.Controllers
{
    public class MusicManagementController : Controller
    {
        long? lengthSong = null;
        int pageSize = 10;
        private readonly List<SongDTO> _songs;

        public MusicManagementController()
        {
            if(lengthSong == null)
            {
                _songs = APIHelper.Gets<SongDTO>($"{FirestoreService.CL_Song}");
            }
        }

        public IActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            Query query = FirestoreService.Instance.GetCollectionReference("Song").OrderByDescending("releaseDate").Limit(pageSize * pageNumber).LimitToLast(pageSize);
            List<SongDTO> songs = FirestoreService.Instance.Gets<SongDTO>(query);
            return View(songs); 
        }

        [HttpGet]
        public string LoadImg(string encodeID, string thumbnail)
        {
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
            string id;

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

        //public IActionResult Delete(string id)
        //{
        //    SongDTO song = new SongDTO();
        //    if (id != null)
        //    {
        //        song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
        //        return View(song);

        //    }
        //    return View();
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteS(string id)
        //{
        //    SongDTO song = new SongDTO();
        //    if (id != null)
        //    {
        //        song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
        //        return View(song);

        //    }
        //    return View();
        //}
        //public IActionResult Details(string id)
        //{
        //    SongDTO song = new SongDTO();
        //    if(id != null)
        //    {
        //        song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
        //        return View(song);

        //    }
        //    return View();
        //}
    }
}

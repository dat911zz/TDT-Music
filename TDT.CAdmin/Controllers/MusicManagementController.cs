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
using TDT.Core.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System;
using TDT.Core.Enums;
using Newtonsoft.Json;
using TDT.Core.Extensions;
using TDT.Core.Models;
using TDT.Core.Ultils.MVCMessage;

namespace TDT.CAdmin.Controllers
{
    public class MusicManagementController : Controller
    {
        private List<SongDTO> _songs;
        private List<Genre> _genres;

        public MusicManagementController()
        {

            GetDataMusic();
            GetDataGenre();
        }
        public void GetDataMusic()
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
        public IActionResult Index(string searchTerm, int? page)
        {
            ViewBag.SearchTerm = "";
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            List<SongDTO> lsong = _songs;

            if (DataHelper.Instance.Songs.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    lsong = _songs.Where(r => r.title.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                    //pageSize = lsong.Count;
                    ViewBag.SoBH = lsong.Count;
                }
            }
            IPagedList<SongDTO> pagedList = lsong == null ? new List<SongDTO>().ToPagedList() : lsong.OrderByDescending(o => o.releaseDate).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
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
            if(DataHelper.Instance.Genres.Count > 0)
            {
                ViewBag.MaGenre = new SelectList(_genres, "id", "name");
            }
            return View();
        }

        public bool IsIdInUse(string id)
        {
            return _songs.Any(song => song.encodeId == id);
        }


        [HttpPost]
        public IActionResult Create([FromForm] FileUploadModel<SongDTO> fileData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string id = HelperUtility.GenerateRandomString(8);
                    do
                    {
                        id = HelperUtility.GenerateRandomString(8);
                    } while (IsIdInUse(id));

                    SongDTO roleDetail = APICallHelper.Post<SongDTO>(
                    $"Song/InsertOrUpdate",
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                    requestBody: JsonConvert.SerializeObject(fileData)
                    ).Result;
                    if (roleDetail.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        //FlashMessage để truyền message từ đây sang action hoặc controller khác
                        this.MessageContainer().AddFlashMessage("Tạo bài hát thành công!", ToastMessageType.Success);
                    }
                    else
                    {
                        //Truyền message trong nội bộ hàm
                        this.MessageContainer().AddMessage(roleDetail.Msg, ToastMessageType.Error);
                        return View();
                    }

                    return RedirectToAction(nameof(Index));
                }
                return View();


            }
            catch
            {
                return View();
            }
        }


        public IActionResult Edit(string id)
        {
            SongDTO song = new SongDTO();
            if (id != null)
            {
                song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
                return View(song);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(SongDTO song)
        {
            return View();
        }


        [HttpPost]
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
        public IActionResult Details(string id)
        {
            SongDTO song = new SongDTO();
            if (id != null)
            {
                song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
                return View(song);

            }
            return View();
        }
    }
}

using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class MusicManagementController : Controller
    {
        private List<SongDTO> _songs;
        private List<Genre> _genres;

        public MusicManagementController()
        {

            //GetDataMusic();
            //GetDataGenre();
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
        //public IActionResult Index(string searchTerm, int? page)
        //{
        //    ViewBag.SearchTerm = "";
        //    int pageSize = 6;
        //    int pageNumber = (page ?? 1);
        //    List<SongDTO> lsong = _songs;

        //    if (DataHelper.Instance.Songs.Count > 0)
        //    {
        //        if (!string.IsNullOrEmpty(searchTerm))
        //        {
        //            lsong = _songs.Where(r => r.title.ToLower().Contains(searchTerm.ToLower())).ToList();
        //            ViewBag.SearchTerm = searchTerm;
        //            //pageSize = lsong.Count;
        //            ViewBag.SoBH = lsong.Count;
        //        }
        //    }
        //    IPagedList<SongDTO> pagedList = lsong == null ? new List<SongDTO>().ToPagedList() : lsong.OrderByDescending(o => o.releaseDate).ToPagedList(pageNumber, pageSize);
        //    return View(pagedList);
        //}
        public IActionResult Index(string searchTerm, int? page)
        {
            ViewBag.SearchTerm = "";
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Song).OrderByDescending("releaseDate").Offset((int)((pageNumber - 1) * pageSize)).Limit(pageSize);
            List<SongDTO> lsong = FirestoreService.Instance.Gets<SongDTO>(query);
            int sobs = (int)FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Song).Count().GetSnapshotAsync().Result.Count;
            ViewBag.SoBH = sobs;
            PageList<List<SongDTO>> pageList = new PageList<List<SongDTO>>(pageNumber, pageSize, sobs, lsong);
            return View(pageList);
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

      
        public bool IsIdInUse(string id)
        {
            return _songs.Any(song => song.encodeId == id);
        }
        public IActionResult Create()
        {
            //    if (DataHelper.Instance.Genres.Count > 0)
            //    {
            //        ViewBag.MaGenre = new SelectList(_genres, "id", "name");
            //    }
            return View();
        }

        [HttpPost]
        public IActionResult Create(SongDTO songdto, IFormFile uploadFile)
        {
            try
            {

                string id = string.Empty;
                do
                {
                    id = HelperUtility.GenerateRandomString(8);
                 
                } while (IsIdInUse(id));
                songdto.encodeId = id;
                Stream image = uploadFile.OpenReadStream();
                string thumbnail = id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff").Replace("/", "_") + "." + uploadFile.FileName.Split('.').Last();
                string url = FirebaseService.Instance.pushFile(image, "Images/Song/0/" + thumbnail).Result;
                DataHelper.Instance.ThumbSong.Add(id, url);
                FirebaseService.Instance.pushFile(image, "Images/Song/1/" + thumbnail).Wait();
                songdto.thumbnail = "Images/Song/0/" + thumbnail;
                songdto.thumbnailM = "Images/Song/1/" + thumbnail;

                SongDTO Songfile = APICallHelper.Post<SongDTO>(
                   $"Song/InsertOrUpdate",
                   token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                   requestBody: JsonConvert.SerializeObject(songdto)
               ).Result;

                if (Songfile.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                {
                    //FlashMessage để truyền message từ đây sang action hoặc controller khác
                    this.MessageContainer().AddFlashMessage("Tạo bài hát thành công!", ToastMessageType.Success);
                }
                else
                {
                    //Truyền message trong nội bộ hàm
                    this.MessageContainer().AddMessage(Songfile.Msg, ToastMessageType.Error);
                    return View();
                }
                return RedirectToAction(nameof(Index));
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
        public IActionResult Edit(SongDTO song, IFormFile uploadFile)
        {
            try
            {
                if(uploadFile != null) {
                    Stream image = uploadFile.OpenReadStream();
                    string thumbnail = song.encodeId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff").Replace("/", "_") + "." + uploadFile.FileName.Split('.').Last();
                    string url = FirebaseService.Instance.pushFile(image, "Images/Song/0/" + thumbnail).Result;
                    DataHelper.Instance.ThumbSong.Add(song.encodeId, url);
                    FirebaseService.Instance.pushFile(image, "Images/Song/1/" + thumbnail).Wait();
                    song.thumbnail = "Images/Song/0/" + thumbnail;
                    song.thumbnailM = "Images/Song/1/" + thumbnail;
                }
                SongDTO Songfile = APICallHelper.Post<SongDTO>(
                $"Song/InsertOrUpdate",
                token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                requestBody: JsonConvert.SerializeObject(song)
                ).Result;

                if (Songfile.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                {
                    //FlashMessage để truyền message từ đây sang action hoặc controller khác
                    this.MessageContainer().AddFlashMessage("Sửa hát thành công!", ToastMessageType.Success);
                }
                else
                {
                    //Truyền message trong nội bộ hàm
                    this.MessageContainer().AddMessage(Songfile.Msg, ToastMessageType.Error);
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult Delete(string id)
        {
            id = "2123";
            ResponseDataDTO<SongDTO> songDTO = APICallHelper.Delete<ResponseDataDTO<SongDTO>>($"Song/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (songDTO.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage("Xóa bài hát thành công!", ToastMessageType.Success);
            }
            else
            {
                this.MessageContainer().AddFlashMessage(songDTO.Msg, ToastMessageType.Error);
            }
            return new JsonResult("ok");
        }
        public IActionResult Details(string id)
        {
            SongDTO song = new SongDTO();
            //if (id != null)
            //{
            //    song = _songs.FirstOrDefault(s => s.encodeId.Equals(id));
            //    return View(song);

            //}
            Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Song).WhereEqualTo("encodeId", id);
            List<SongDTO> lsong = FirestoreService.Instance.Gets<SongDTO>(query);
            if(lsong != null)
            {
                song = lsong[0];
                return View(song);
            }
            return View();
        }
    }
}

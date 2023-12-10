using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class PlaylistManagementController : Controller
    {
        public PlaylistManagementController()
        {
        }
        public bool IsIdInUse(string id)
        {
            PlaylistDTO playlist = DataHelper.GetPlaylist(id);
            if (playlist != null)
            {
                return true;
            }
            return false;
        }
        public IActionResult Index(string searchTerm, int? page)
        {
            ViewBag.SearchTerm = "";
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<PlaylistDTO> playlists = null;
            int sobs = 0;
            if (string.IsNullOrEmpty(searchTerm))
            {
                Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Playlist).Offset((int)((pageNumber - 1) * pageSize)).Limit(pageSize);
                playlists = FirestoreService.Instance.Gets<PlaylistDTO>(query);
                sobs = (int)FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Playlist).Count().GetSnapshotAsync().Result.Count;
                ViewBag.SoBH = sobs;
            }
            else if (DataHelper.Instance.Playlists.Count > 0)
            {
                var _playlist = DataHelper.Instance.Playlists.Values.ToList();
                playlists = _playlist.Where(r => r.title.ToLower().Contains(searchTerm.ToLower())).ToList();
                ViewBag.SoBH = playlists.Count;
                sobs = playlists.Count;
                playlists = _playlist.Where(r => r.title.ToLower().Contains(searchTerm.ToLower())).Skip((int)((pageNumber - 1) * pageSize)).Take(pageSize).ToList();
                ViewBag.SearchTerm = searchTerm;
            }

            PageList<List<PlaylistDTO>> pageList = new PageList<List<PlaylistDTO>>(pageNumber, pageSize, sobs, playlists);
            return View(pageList);
        }
        [HttpGet]
        public string LoadImg(string encodeID, string thumbnail)
        {
            string img;
            if (DataHelper.Instance.ThumbPlaylist.Keys.Contains(encodeID))
            {
                img = DataHelper.Instance.ThumbPlaylist[encodeID];
            }
            else
            {
                img = FirebaseService.Instance.getStorage(thumbnail);
                DataHelper.Instance.ThumbPlaylist.Add(encodeID, img);
            }
            return img;
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(PlaylistDTO playlist, IFormFile uploadFile)
        {
            string id = string.Empty;
            do
            {
                id = HelperUtility.GenerateRandomString(8);

            } while (IsIdInUse(id));
            try
            {
                playlist.encodeId = id;
                Stream image = uploadFile.OpenReadStream();
                string thumbnail = id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff").Replace("/", "_") + "." + uploadFile.FileName.Split('.').Last();
                string url = FirebaseService.Instance.pushFile(image, "Images/Playlist/0/" + thumbnail).Result;
                DataHelper.Instance.ThumbArtist.Add(id, url);
                FirebaseService.Instance.pushFile(image, "Images/Playlist/1/" + thumbnail).Wait();
                playlist.thumbnail = "Images/Playlist/0/" + thumbnail;
                playlist.thumbnailM = "Images/Playlist/1/" + thumbnail;

                PlaylistDTO Songfile = APICallHelper.Post<PlaylistDTO>(
                   $"Playlist/InsertOrUpdate",
                   token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                   requestBody: JsonConvert.SerializeObject(playlist)
               ).Result;

                if (Songfile.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                {
                    //FlashMessage để truyền message từ đây sang action hoặc controller khác
                    this.MessageContainer().AddFlashMessage("Tạo playlist thành công!", ToastMessageType.Success);
                    if (DataHelper.Instance.Playlists.ContainsKey(playlist.encodeId))
                    {
                        DataHelper.Instance.Playlists[playlist.encodeId] = playlist;
                    }
                    else
                    {
                        DataHelper.Instance.Playlists.Add(playlist.encodeId, playlist);
                    }
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
        public IActionResult Edit(string? id)
        {
            PlaylistDTO playlist = new PlaylistDTO();
            if (id != null)
            {
                playlist = APIHelper.Get<PlaylistDTO>(FirestoreService.CL_Playlist, id);
                return View(playlist);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(PlaylistDTO playlist, IFormFile uploadFile)
        {
            try
            {
                if (uploadFile != null)
                {
                    Stream image = uploadFile.OpenReadStream();
                    string thumbnail = playlist.encodeId + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff").Replace("/", "_") + "." + uploadFile.FileName.Split('.').Last();
                    string url = FirebaseService.Instance.pushFile(image, "Images/Playlist/0/" + thumbnail).Result;
                    DataHelper.Instance.ThumbSong.Remove(playlist.encodeId);
                    DataHelper.Instance.ThumbSong.Add(playlist.encodeId, url);
                    FirebaseService.Instance.pushFile(image, "Images/Playlist/1/" + thumbnail).Wait();
                    playlist.thumbnail = "Images/Playlist/0/" + thumbnail;
                    playlist.thumbnailM = "Images/Playlist/1/" + thumbnail;
                }

                PlaylistDTO Songfile = APICallHelper.Post<PlaylistDTO>(
                $"Playlist/InsertOrUpdate",
                token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                requestBody: JsonConvert.SerializeObject(playlist)
                ).Result;

                if (Songfile.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                {
                    //FlashMessage để truyền message từ đây sang action hoặc controller khác
                    this.MessageContainer().AddFlashMessage("Sửa Play list thành công!", ToastMessageType.Success);
                    if (DataHelper.Instance.Playlists.ContainsKey(playlist.encodeId))
                    {
                        DataHelper.Instance.Playlists[playlist.encodeId] = playlist;
                    }
                    else
                    {
                        DataHelper.Instance.Playlists.Add(playlist.encodeId, playlist);
                    }
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
            ResponseDataDTO<PlaylistDTO> playlistDTO = APICallHelper.Delete<ResponseDataDTO<PlaylistDTO>>($"Playlist/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (playlistDTO.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage("Xóa play list thành công!", ToastMessageType.Success);
                if (DataHelper.Instance.Playlists.ContainsKey(id))
                {
                    DataHelper.Instance.Playlists.Remove(id);
                }
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
                playlist = APIHelper.Get<PlaylistDTO>(FirestoreService.CL_Playlist, id);
                return View(playlist);

            }
            return View();
        }
    }
}

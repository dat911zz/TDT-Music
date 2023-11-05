﻿using Google.Cloud.Firestore;
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

        public MusicManagementController()
        {

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
        public bool IsIdInUse(string id)
        {
            ResponseDataDTO<SongDTO> songdto = APICallHelper.Get<ResponseDataDTO<SongDTO>>($"Song/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (songdto != null)
                return true;
            return false;
        }
        public IActionResult Index(string searchTerm, int? page)
        {
            ViewBag.SearchTerm = "";
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Song).Offset((int)((pageNumber - 1) * pageSize)).Limit(pageSize);
            //Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Song).OrderByDescending("releaseDate").Offset((int)((pageNumber - 1) * pageSize)).Limit(pageSize);
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
            img = FirebaseService.Instance.getStorage(thumbnail);
            return img;
        }
        public IActionResult Create()
        {
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
            Query query = FirestoreService.Instance.GetCollectionReference(FirestoreService.CL_Song).WhereEqualTo("encodeId", id);
            List<SongDTO> lsong = FirestoreService.Instance.Gets<SongDTO>(query);
            if (lsong != null)
            {
                song = lsong[0];
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

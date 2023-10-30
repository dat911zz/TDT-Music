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
    public class ArtistManagementController : Controller
    {
        public List<ArtistDTO> artist = new List<ArtistDTO>();
        // GET: ArtistManagementController

        public ArtistManagementController()
        {
            GetDataArtist();
        }


        public void GetDataArtist()
        {
            if (DataHelper.Instance.Artists.Count <= 0)
            {
                artist = APIHelper.Gets<ArtistDTO>($"{FirestoreService.CL_Artist}");
                if (artist != null)
                {
                    foreach (ArtistDTO art in artist)
                    {
                        if (!DataHelper.Instance.Artists.Keys.Contains(art.id)) ;
                        {
                            DataHelper.Instance.Artists.Add(art.id, art);
                        }
                    }
                }
            }
            else
            {
                artist = DataHelper.Instance.Artists.Values.ToList();
            }
        }
        public IActionResult Index(string searchTerm, int? page)
        {
            ViewBag.SearchTerm = "";
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<ArtistDTO> list_art = artist;

            if (DataHelper.Instance.Artists.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    list_art = artist.Where(r => r.name.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                    ViewBag.SoNS = list_art.Count;
                }
            }
            IPagedList<ArtistDTO> pagedList = list_art == null ? new List<ArtistDTO>().ToPagedList() : list_art.OrderByDescending(o => o.birthday).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
        [HttpGet]

        // GET: ArtistManagementController/Details/5


        // GET: ArtistManagementController/Create
        [HttpGet]
        public string LoadImg(string encodeID, string thumbnail)
        {
            string img;
            if (DataHelper.Instance.ThumbArtist.Keys.Contains(encodeID))
            {
                img = DataHelper.Instance.ThumbArtist[encodeID];
            }
            else
            {
                img = FirebaseService.Instance.getStorage(thumbnail);
                DataHelper.Instance.ThumbArtist.Add(encodeID, img);
            }
            return img;
        }


        public bool IsIdInUse(string id)
        {
            return artist.Any(art => art.id == id);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(ArtistDTO artistDTO, IFormFile uploadFile)
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
                    Stream image = uploadFile.OpenReadStream();
                    string thumbnail = id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff").Replace("/", "_") + "." + uploadFile.FileName.Split('.').Last();
                    string url = FirebaseService.Instance.pushFile(image, "Images/Artist/0/" + thumbnail).Result;
                    DataHelper.Instance.ThumbSong.Add(id, url);
                    FirebaseService.Instance.pushFile(image, "Images/Artist/1/" + thumbnail).Wait();
                    artistDTO.thumbnail = "Images/Artist/0/" + thumbnail;
                    artistDTO.thumbnailM = "Images/Artist/1/" + thumbnail;
                    artistDTO.cover = "Images/Artist/cover/default_cover.png";
                    ArtistDTO artist = APICallHelper.Post<ArtistDTO>(
                    $"Artist/InsertOrUpdate",
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                    requestBody: JsonConvert.SerializeObject(artistDTO)
                    ).Result;
                    if (artist.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        //FlashMessage để truyền message từ đây sang action hoặc controller khác
                        this.MessageContainer().AddFlashMessage("Tạo nghệ sĩ thành công!", ToastMessageType.Success);
                    }
                    else
                    {
                        //Truyền message trong nội bộ hàm
                        this.MessageContainer().AddMessage(artist.Msg, ToastMessageType.Error);
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

        // GET: ArtistManagementController/Edit/5
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ArtistDTO art = new ArtistDTO();
            if (id != null)
            {
                art = artist.FirstOrDefault(s => s.id.Equals(id));
                return View(art);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(ArtistDTO Art, IFormFile file)
        {
            return View();
        }

        // GET: ArtistManagementController/Delete/5
       
        [HttpPost]
        public ActionResult Delete(string id)
        {
            id = "a";
            ResponseDataDTO<ArtistDTO> playlistDTO = APICallHelper.Delete<ResponseDataDTO<ArtistDTO>>($"Artist/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (playlistDTO.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage("Xóa nghệ sĩ thành công!", ToastMessageType.Success);
            }
            else
            {
                this.MessageContainer().AddFlashMessage(playlistDTO.Msg, ToastMessageType.Error);
            }
            return new JsonResult("ok");
        }
        public IActionResult Details(string id)
        {
            ArtistDTO art = new ArtistDTO();
            if (id != null)
            {
                art = artist.FirstOrDefault(s => s.id.Equals(id));
                return View(art);

            }
            return View();
        }
    }

}

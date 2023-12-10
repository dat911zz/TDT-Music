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
    public class GenreController : Controller
    {

        private List<Genre> _genres;

        public GenreController()
        {
            GetDataGenre();
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
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            List<Genre> lgenre = _genres;

            if (DataHelper.Instance.Genres.Count > 0)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    lgenre = _genres.Where(r => r.title.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                    ViewBag.SoCD = lgenre.Count;
                }
            }
            IPagedList<Genre> pagedList = lgenre == null ? new List<Genre>().ToPagedList() : lgenre.OrderByDescending(o => o.name).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
        public IActionResult Create()
        {
            if (DataHelper.Instance.Genres.Count > 0)
            {
                ViewBag.MaGenre = new SelectList(_genres, "id", "title", "alias", "name");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Genre genre, IFormFile file)
        {
            try
            {
                if (genre == null)
                {
                    return BadRequest("Dữ liệu thể loại không hợp lệ.");
                }
                string id = string.Empty;
                do
                {
                    id = HelperUtility.GenerateRandomString(8);
                } while (IsIdInUse(id));

                genre.id = id;
                await FirestoreService.Instance.SetAsync(FirestoreService.CL_Genre, genre.id, genre);

                if (file != null)
                {
                    var apiResponse = APICallHelper.Post<Genre>(
                        "Genre/InsertOrUpdate",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                        requestBody: JsonConvert.SerializeObject(genre)
                    ).Result;

                    if (apiResponse.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        this.MessageContainer().AddFlashMessage("Tạo Chủ Đề thành công!", ToastMessageType.Success);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        this.MessageContainer().AddMessage(apiResponse.Msg, ToastMessageType.Error);
                        return View();
                    }
                }
                else
                {
                     GetDataGenre();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Edit(string ID)
        {
            if (ID != null)
            {
                Genre lgenre = _genres.FirstOrDefault(s => s.id.Equals(ID));
                return View(lgenre);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Genre genre, IFormFile file)
        {
            try
            {
                if (genre == null)
                {
                    return BadRequest("Dữ liệu thể loại không hợp lệ.");
                }

                string id = genre.id;
                await FirestoreService.Instance.SetAsync(FirestoreService.CL_Genre, id, genre);

                if (file != null)
                {
                    var apiResponse = APICallHelper.Post<Genre>(
                        "Genre/InsertOrUpdate",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                        requestBody: JsonConvert.SerializeObject(genre)
                    ).Result;

                    if (apiResponse.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        this.MessageContainer().AddFlashMessage("Cập nhật Chủ Đề thành công!", ToastMessageType.Success);

                        return RedirectToAction(nameof(Index)); 
                    }
                    else
                    {
                        this.MessageContainer().AddMessage(apiResponse.Msg, ToastMessageType.Error);
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction(nameof(Index)); 
                }
            }
            catch
            {
                return View();
            }
        }
        public bool IsIdInUse(string id)
        {
            return _genres.Any(genre => genre.id == id);
        }

      
        [HttpPost]
        public IActionResult Delete(string id)
        {
            ResponseDataDTO<Genre> genre = APICallHelper.Delete<ResponseDataDTO<Genre>>($"Genre/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (genre.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage("Xóa chủ đề thành công!", ToastMessageType.Success);
            }
            else
            {
                this.MessageContainer().AddFlashMessage(genre.Msg, ToastMessageType.Error);
            }
            return new JsonResult("ok");
        }
        public IActionResult Details(string id)
        {
            Genre genre = new Genre();
            if (id != null)
            {
                genre = _genres.FirstOrDefault(s => s.id.Equals(id));
                return View(genre);

            }
            return View();
        }
    }
}

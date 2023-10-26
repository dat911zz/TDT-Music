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

        public bool IsIdInUse(string id)
        {
            return _genres.Any(genre => genre.id == id);
        }
        public IActionResult Edit(string id)
        {
            Genre lgenre = new Genre();
            if (id != null)
            {
                lgenre = _genres.FirstOrDefault(s => s.id.Equals(id));
                return View(lgenre);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Genre lgenre)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            Genre lgenre = new Genre();
            if (id != null)
            {
                lgenre = _genres.FirstOrDefault(s => s.id.Equals(id));
                return View(lgenre);
            }
            return View();
        }
        public IActionResult Details(string id)
        {
            Genre lgenre = new Genre();
            if (id != null)
            {
                lgenre = _genres.FirstOrDefault(s => s.id.Equals(id));
                return View(lgenre);

            }
            return View();
        }
    }
}

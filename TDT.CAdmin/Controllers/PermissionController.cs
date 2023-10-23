using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Models;
using TDT.Core.Ultils;
using X.PagedList;

namespace TDT.CAdmin.Controllers
{
    public class PermissionController : Controller
    {
        public readonly ILogger<PermissionController> _logger;
        public PermissionController(ILogger<PermissionController> logger)
        {
            _logger = logger;


        }
        // GET: PermissionController
        public ActionResult Index(int? page )
        {
            ResponseDataDTO<PermissionDTO> roles = APICallHelper.Get<ResponseDataDTO<PermissionDTO>>("Permission", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;

            if (roles.Data != null)
            {
                int pageNumber = (page ?? 1);
                int pageSize = 10;

                IPagedList<PermissionDTO> pagedList = roles.Data.ToPagedList(pageNumber, pageSize);

                return View(pagedList);

            }
            return View();
        }

        // GET: PermissionController/Details/5
        public ActionResult Details(int id)
        {
            ResponseDataDTO<PermissionDTO> preDetail = APICallHelper.Get<ResponseDataDTO<PermissionDTO>>($"Permission/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(preDetail.Data.FirstOrDefault());
        }

        // GET: PermissionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PermissionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                PermissionDTO permission = new PermissionDTO();
                permission.Name = collection["Name"].ToString();
                permission.Description = collection["Description"].ToString();

                ResponseDataDTO<PermissionDTO> roleDetail = APICallHelper.Post<ResponseDataDTO<PermissionDTO>>(
                    $"Permission",
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                    requestBody: permission.ToString()
                    ).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PermissionController/Edit/5
        public ActionResult Edit(int id)
        {
            ResponseDataDTO<PermissionDTO> preDetail = APICallHelper.Get<ResponseDataDTO<PermissionDTO>>($"Permission/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;

            return View(preDetail.Data.FirstOrDefault());

        }

        // POST: PermissionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PermissionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PermissionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

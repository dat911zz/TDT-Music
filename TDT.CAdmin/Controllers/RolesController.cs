using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text;
using TDT.Core.DTO;
using TDT.Core.Ultils;
using X.PagedList;

namespace TDT.CAdmin.Controllers
{
    public class RolesController : Controller
    {
        public readonly ILogger<RolesController> _logger;
        public RolesController(ILogger<RolesController> logger)
        {
            _logger = logger;


        }
        // GET: Roles_Controller
        public ActionResult Index(int? page)
        {
            ResponseDataDTO<RoleDTO> roles = APICallHelper.Get<ResponseDataDTO<RoleDTO>>("Role", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;

            if (roles.Data != null)
            {
                int pageNumber = (page ?? 1);
                int pageSize = 10;

                IPagedList<RoleDTO> pagedList = roles.Data.ToPagedList(pageNumber, pageSize);

                return View(pagedList);

            }
            return View();
        }

        // GET: Roles_Controller/Details/5
        public ActionResult Details(int id)
        {
            ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Get<ResponseDataDTO<RoleDTO>>($"Role/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(roleDetail.Data.FirstOrDefault());
        }

        // GET: Roles_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                RoleDTO role = new RoleDTO();
                role.Name = collection["Name"].ToString();
                role.Description = collection["Description"].ToString();

                ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Post<ResponseDataDTO<RoleDTO>>(
                    $"Role",
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                    requestBody: role.ToString()
                    ).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Get<ResponseDataDTO<RoleDTO>>($"Role/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(roleDetail.Data.FirstOrDefault());
        }

        // POST: Roles_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                RoleDTO role = new RoleDTO();
               
                role.Id = Convert.ToInt32(collection["Id"].ToString());
                role.Name = collection["Name"].ToString();
                role.Description = collection["Description"].ToString();
                string createDateStr = collection["CreateDate"];
                DateTime createDate;
                if (DateTime.TryParse(createDateStr, out createDate))
                {
                    role.CreateDate = createDate;
                }
                ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Put<ResponseDataDTO<RoleDTO>>(
                    $"Role/{id}",
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                    requestBody: role.ToString()
                    ).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Get<ResponseDataDTO<RoleDTO>>($"Role/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(roleDetail.Data.FirstOrDefault());
        }

        // POST: Roles_Controller/Delete/5
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

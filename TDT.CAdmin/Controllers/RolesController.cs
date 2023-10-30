 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDT.Core.DTO;
using TDT.Core.Extensions;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;
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
        public ActionResult Index(string? searchTerm, int? page)
        {
            ResponseDataDTO<RoleDTO> roles = APICallHelper.Get<ResponseDataDTO<RoleDTO>>("Role", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            ViewBag.SearchTerm = "";
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            // Lọc vai trò dựa trên từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
               if(roles.Data != null)
                {
                    roles.Data = roles.Data.Where(r => r.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                }
                else return View();
            }
            IPagedList<RoleDTO> pagedList = roles.Data == null ? new List<RoleDTO>().ToPagedList() : roles.Data.OrderByDescending(o => o.CreateDate).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
        public ActionResult Details(int id)
        {
            ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Get<ResponseDataDTO<RoleDTO>>($"Role/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(roleDetail.Data.FirstOrDefault());
        }
        public ActionResult Create()
        {
            return View();
        }
        // POST: Roles_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleDTO role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (role.Name == "" || role.Description == "")
                    {
                        this.MessageContainer().AddMessage("Vui lòng điền đẩy đủ thông tin!", ToastMessageType.Warning);
                        return View();
                    }
                    ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Post<ResponseDataDTO<RoleDTO>>(
                       $"Role",
                       token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                       requestBody:JsonConvert.SerializeObject(role)
                       ).Result;
                    if (roleDetail.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        this.MessageContainer().AddFlashMessage("Tạo  vai trò thành công!", ToastMessageType.Success);
                    }
                    else
                    {
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
        public ActionResult Edit(int id)
        {
            ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Get<ResponseDataDTO<RoleDTO>>($"Role/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(roleDetail.Data.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoleDTO role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Put<ResponseDataDTO<RoleDTO>>(
                        $"Role/{id}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                        requestBody: JsonConvert.SerializeObject(role)
                        ).Result;
                    if (roleDetail.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        this.MessageContainer().AddFlashMessage("Sửa vai trò thành công!", ToastMessageType.Success);
                    }
                    else
                    {
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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Delete<ResponseDataDTO<RoleDTO>>($"Role/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (roleDetail.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage("Xóa vai trò thành công!", ToastMessageType.Success);
            }
            else
            {
                this.MessageContainer().AddFlashMessage(roleDetail.Msg, ToastMessageType.Error);
            }
            return new JsonResult("ok");
        }
    }
}

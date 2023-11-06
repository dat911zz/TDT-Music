using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Extensions;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;
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
        public async Task<ActionResult> Index(string? searchTerm, int? page)
        {
            await DataBindings.Instance.LoadPermissions(User.GetToken());
            ViewBag.SearchTerm = "";
            int pageNumber = (page ?? 1);
            int pageSize = 6;

            // Lọc vai trò dựa trên từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (DataBindings.Instance.Permissions != null)
                {
                    DataBindings.Instance.Permissions = DataBindings.Instance.Permissions.Where(r => r.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                }
                else return View();
            }

            IPagedList<PermissionDTO> pagedList = DataBindings.Instance.Permissions == null ? new List<PermissionDTO>().ToPagedList() : DataBindings.Instance.Permissions.OrderByDescending(o => o.CreateDate).ToPagedList(pageNumber, pageSize);

            return View(pagedList);
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
        public ActionResult Create(PermissionDTO permission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (permission.Name == "" || permission.Description == "")
                    {
                        this.MessageContainer().AddMessage("Vui lòng điền đẩy đủ thông tin!", ToastMessageType.Warning);
                        return View();
                    }
                    ResponseDataDTO<PermissionDTO> res = APICallHelper.Post<ResponseDataDTO<PermissionDTO>>(
                       $"Permission",
                       token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                       requestBody: JsonConvert.SerializeObject(permission)
                       ).Result;
                    if (res.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        //FlashMessage để truyền message từ đây sang action hoặc controller khác
                        this.MessageContainer().AddFlashMessage("Tạo quyền thành công!", ToastMessageType.Success);
                    }
                    else
                    {
                        //Truyền message trong nội bộ hàm
                        this.MessageContainer().AddMessage(res.Msg, ToastMessageType.Error);
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

        // GET: PermissionController/Edit/5
        public ActionResult Edit(int id)
        {
            ResponseDataDTO<PermissionDTO> preDetail = APICallHelper.Get<ResponseDataDTO<PermissionDTO>>($"Permission/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;

            return View(preDetail.Data.FirstOrDefault());

        }

        // POST: PermissionController/Edit/5
        [HttpPost]
        public ActionResult Edit(PermissionDTO permission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResponseDataDTO<PermissionDTO> res = APICallHelper.Put<ResponseDataDTO<PermissionDTO>>(
                        $"Permission/{permission.Id}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                        requestBody: JsonConvert.SerializeObject(permission)
                        ).Result;
                    if (res.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        //FlashMessage để truyền message từ đây sang action hoặc controller khác
                        this.MessageContainer().AddFlashMessage("Sửa quyền thành công!", ToastMessageType.Success);
                    }
                    else
                    {
                        this.MessageContainer().AddMessage(res.Msg, ToastMessageType.Error);
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

        // POST: PermissionController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ResponseDataDTO<PermissionDTO> roleDetail = APICallHelper.Delete<ResponseDataDTO<PermissionDTO>>($"Permission/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (roleDetail.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage("Xóa quyền thành công!", ToastMessageType.Success);
                var perm = DataBindings.Instance.Permissions.FirstOrDefault(p => p.Id == id);
                DataBindings.Instance.Permissions.Remove(perm);
            }
            else
            {
                this.MessageContainer().AddFlashMessage(roleDetail.Msg, ToastMessageType.Error);
            }
            return new JsonResult("ok");
        }
    }
}

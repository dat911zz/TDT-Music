 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.CAdmin.Models;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Extensions;
using TDT.Core.Models;
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
        public async Task<ActionResult> Index(string? searchTerm, int? page)
        {
            await DataBindings.Instance.LoadRoles(HttpContext.User.GetToken(), _logger);
            var roles = DataBindings.Instance.Roles;
            ViewBag.SearchTerm = "";
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            // Lọc vai trò dựa trên từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
               if(roles != null)
                {
                    roles = roles.Where(r => r.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                }
                else return View();
            }
            IPagedList<RoleDTO> pagedList = roles == null ? new List<RoleDTO>().ToPagedList() : roles.OrderByDescending(o => o.CreateDate).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
        public ActionResult Details(int id)
        {
            ResponseDataDTO<RoleDTO> roleDetail = APICallHelper.Get<ResponseDataDTO<RoleDTO>>($"Role/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            RoleDTO role = roleDetail.Data.FirstOrDefault();
            ResponseDataDTO<PermissionDTO> resPerms = APICallHelper.Get<ResponseDataDTO<PermissionDTO>>(
            $"RolePermission/{role.Id}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            ViewBag.perms = resPerms.Data;
            return View(role);
        }
        public ActionResult Create()
        {
            ViewBag.perms = DataBindings.Instance.Permissions;
            return View();
        }
        // POST: Roles_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleDTO role, IFormCollection frm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var perms = frm["RolePerms"].ToList();
                    if (role.Name == "" || role.Description == "")
                    {
                        this.MessageContainer().AddMessage("Vui lòng điền đẩy đủ thông tin!", ToastMessageType.Warning);
                        return View();
                    }
                    ResponseDataDTO<RoleDTO> resRole = APICallHelper.Post<ResponseDataDTO<RoleDTO>>(
                       $"Role",
                       token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                       requestBody:JsonConvert.SerializeObject(role)
                       ).Result;

                    await DataBindings.Instance.LoadRoles(HttpContext.User.GetToken(), _logger, 1000);
                    if (resRole.Code != APIStatusCode.ActionSucceeded)
                    {
                        //FlashMessage để truyền message từ đây sang action hoặc controller khác
                        this.MessageContainer().AddMessage(resRole.Msg, ToastMessageType.Error);
                        ViewBag.roles = DataBindings.Instance.Roles;
                        return View();
                    }
                    foreach (var perm in DataBindings.Instance.Permissions)
                    {
                        if (perms.Any(r => r.Equals(role.Id.ToString())))
                        {
                            APIResponseModel resPerm = APICallHelper.Post<APIResponseModel>(
                            $"RolePermission?roleId={role.Id}&permId={perm.Id}",
                            token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
                            if (resRole.Code != APIStatusCode.ActionSucceeded)
                            {
                                this.MessageContainer().AddMessage(resRole.Msg, ToastMessageType.Error);
                                ViewBag.roles = DataBindings.Instance.Roles;
                                return View();
                            }
                        }
                        else
                        {
                            APIResponseModel resPerm = APICallHelper.Delete<APIResponseModel>(
                            $"RolePermission?roleId= {role.Id} &permId= {perm.Id}",
                            token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
                        }
                    }
                    if (resRole.Code == APIStatusCode.ActionSucceeded)
                    {
                        this.MessageContainer().AddFlashMessage("Tạo vai trò thành công!", ToastMessageType.Success);
                    }
                    else
                    {
                        this.MessageContainer().AddMessage(resRole.Msg, ToastMessageType.Error);
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
            ResponseDataDTO<RoleDTO> resPerms = APICallHelper.Get<ResponseDataDTO<RoleDTO>>(
            $"RolePermission/{roleDetail.Data.FirstOrDefault().Id}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            ViewBag.rolePerms = resPerms.Data;
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
        [HttpGet]
        public ActionResult AssignPermission(string? searchTerm, int? page)
        {
            ViewBag.Perms = DataBindings.Instance.Permissions;
            var roles = DataBindings.Instance.Roles;
            ViewBag.SearchTerm = "";
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            // Lọc vai trò dựa trên từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (roles != null)
                {
                    roles = roles.Where(r => r.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                }
                else return View();
            }
            IPagedList<RoleDTO> pagedList = roles == null ? new List<RoleDTO>().ToPagedList() : roles.OrderByDescending(o => o.CreateDate).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
    }
}

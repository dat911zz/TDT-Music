    using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TDT.CAdmin.Models;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Extensions;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;
using X.PagedList;
using User = TDT.Core.Models.User;

namespace TDT.CAdmin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public UserController(ILogger<HomeController> logger)
        {
            _logger = logger;
            
        }
        public async Task<IActionResult> Index(string? searchTerm, int? page)
        {
            await DataBindings.Instance.LoadUsers(User.GetToken());
            var users = DataBindings.Instance.Users;
            ViewBag.SearchTerm = "";
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            // Lọc vai trò dựa trên từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (users != null)
                {
                    users = users.Where(u => u.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                }
                else return View();
            }
            IPagedList<UserDTO> pagedList = users == null ? new List<UserDTO>().ToPagedList() : users.OrderByDescending(o => o.CreateDate).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.roles = DataBindings.Instance.Roles;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(UserIdentiyModel user, IFormCollection frm)
        {
            if (ModelState.IsValid)
            {
                var roles = frm["UserRoles"].ToList();
                ResponseDataDTO<UserIdentiyModel> resUser = APICallHelper.Post<ResponseDataDTO<UserIdentiyModel>>(
                    "Auth/Register",
                    JsonConvert.SerializeObject(user),
                    token: HttpContext.User.GetToken()).Result;
                await DataBindings.Instance.LoadUsers(HttpContext.User.GetToken());
                if (resUser.Code != APIStatusCode.ActionSucceeded)
                {
                    //FlashMessage để truyền message từ đây sang action hoặc controller khác
                    this.MessageContainer().AddMessage(resUser.Msg, ToastMessageType.Error);
                    ViewBag.roles = DataBindings.Instance.Roles;
                    return View();
                }
                foreach (var role in DataBindings.Instance.Roles)
                {
                    if (roles.Any(r => r.Equals(role.Id.ToString())))
                    {
                        APIResponseModel resRole = APICallHelper.Post<APIResponseModel>(
                        $"UserRole?username={user.UserName}&roleId={role.Id}",
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
                        APIResponseModel resRole = APICallHelper.Delete<APIResponseModel>(
                        $"UserRole?username={user.UserName}&roleId={role.Id}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
                    }
                }
                

                if (resUser.Code == APIStatusCode.ActionSucceeded)
                {
                    //FlashMessage để truyền message từ đây sang action hoặc controller khác
                    this.MessageContainer().AddFlashMessage("Tạo tài khoản thành công!", ToastMessageType.Success);
                }
                else
                {
                    //Truyền message trong nội bộ hàm
                    this.MessageContainer().AddMessage(resUser.Msg, ToastMessageType.Error);
                    ViewBag.roles = DataBindings.Instance.Roles;
                    return View();
                }

                return RedirectToAction("Index");
            }
            this.MessageContainer().AddMessage("Vui lòng điền đẩy đủ thông tin!", ToastMessageType.Warning);
            return View();
        }
        public ActionResult Details(string id)
        {
            ResponseDataDTO<User> userDetail = APICallHelper.Get<ResponseDataDTO<User>>($"user/{id.Trim()}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            User user = userDetail.Data.FirstOrDefault();
            ResponseDataDTO<RoleDTO> resRole = APICallHelper.Get<ResponseDataDTO<RoleDTO>>(
            $"UserRole/{user.UserName}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            ViewBag.roles = resRole.Data;
            return View(user);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            ViewBag.roles = DataBindings.Instance.Roles;
            ResponseDataDTO<UserDTO> userDetail = APICallHelper.Get<ResponseDataDTO<UserDTO>>($"user/{id.Trim()}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            ResponseDataDTO<RoleDTO> resRole = APICallHelper.Get<ResponseDataDTO<RoleDTO>>(
            $"UserRole/{userDetail.Data.FirstOrDefault().UserName}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            ViewBag.userRoles = resRole.Data;
            var userIdentity = userDetail.Data.Select(s => new UserIdentiyModel
            {
                UserName = s.UserName,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email,
                CreateDate = s.CreateDate,
                Password = ""
            }).FirstOrDefault();
            return View(userIdentity);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UserIdentiyModel model, IFormCollection frm)
        {
            var roles = frm["UserRoles"].ToList();
            ResponseDataDTO<UserDetailModel> res = APICallHelper.Put<ResponseDataDTO<UserDetailModel>>($"user/{model.UserName.Trim()}",
                JsonConvert.SerializeObject(model),
                token: HttpContext.User.GetToken())
                .Result;
            if (res.Code != APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage(res.Msg, ToastMessageType.Error);
                return View();
            }
            await DataBindings.Instance.LoadUsers(HttpContext.User.GetToken());
            var users = DataBindings.Instance.Users;
            if (res.Code != APIStatusCode.ActionSucceeded)
            {
                //FlashMessage để truyền message từ đây sang action hoặc controller khác
                this.MessageContainer().AddMessage(res.Msg, ToastMessageType.Error);
                ViewBag.roles = DataBindings.Instance.Roles;
                return View();
            }
            foreach (var role in DataBindings.Instance.Roles)
            {
                if (roles.Any(r => r.Equals(role.Id.ToString())))
                {
                    APIResponseModel resRole = APICallHelper.Post<APIResponseModel>(
                    $"UserRole?username={model.UserName}&roleId={role.Id}",
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
                    if (resRole.Code != APIStatusCode.Exist)
                    {
                        if (resRole.Code != APIStatusCode.ActionSucceeded)
                        {
                            this.MessageContainer().AddMessage(resRole.Msg, ToastMessageType.Error);
                            ViewBag.roles = DataBindings.Instance.Roles;
                            return View();
                        }
                    }                   
                }
                else
                {
                    APIResponseModel resRole = APICallHelper.Delete<APIResponseModel>(
                    $"UserRole?username={model.UserName}&roleId={role.Id}",
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
                }
            }
            this.MessageContainer().AddFlashMessage($"Đã cập nhật thông tin cho tài khoản {model.UserName}!", ToastMessageType.Success);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            ResponseDataDTO<User> res = APICallHelper.Delete<ResponseDataDTO<User>>($"user/{id.Trim()}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (res.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                //FlashMessage để truyền message từ đây sang action hoặc controller khác
                this.MessageContainer().AddFlashMessage(res.Msg, ToastMessageType.Success);
                
                UserDTO user = DataBindings.Instance.Users.FirstOrDefault(u => u.UserName.Equals(id));
                DataBindings.Instance.Users.Remove(user);
            }
            else
            {
                //Truyền message trong nội bộ hàm
                this.MessageContainer().AddFlashMessage(res.Msg, ToastMessageType.Error);
            }
            var users = DataBindings.Instance.Users;
            return new JsonResult("ok");
        }
    }
}

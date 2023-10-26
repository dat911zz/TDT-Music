using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Extensions;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.Core.Ultils.MVCMessage;
using X.PagedList;

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
        public IActionResult Index(int? page)
        {
            ResponseDataDTO<UserDTO> users = APICallHelper.Get<ResponseDataDTO<UserDTO>>("user", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            IPagedList<UserDTO> pagedList = users.Data == null ? new List<UserDTO>().ToPagedList() : users.Data.OrderByDescending(o => o.CreateDate).ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserIdentiyModel user)
        {
            if (ModelState.IsValid)
            {
                ResponseDataDTO<UserIdentiyModel> response = APICallHelper.Post<ResponseDataDTO<UserIdentiyModel>>(
                    "Auth/Register",
                    JsonConvert.SerializeObject(user),
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;

                if (response.Code == APIStatusCode.ActionSucceeded)
                {
                    //FlashMessage để truyền message từ đây sang action hoặc controller khác
                    this.MessageContainer().AddFlashMessage("Tạo tài khoản thành công!", ToastMessageType.Success);
                }
                else
                {
                    //Truyền message trong nội bộ hàm
                    this.MessageContainer().AddMessage(response.Msg, ToastMessageType.Error);
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
            return View(userDetail.Data.FirstOrDefault());
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            ResponseDataDTO<User> userDetail = APICallHelper.Put<ResponseDataDTO<User>>($"user/{id.Trim()}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(userDetail.Data.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {
            ResponseDataDTO<User> res = APICallHelper.Post<ResponseDataDTO<User>>($"user/{model.UserName.Trim()}",
                JsonConvert.SerializeObject(model),
                token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value)
                .Result;
            if (res.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                //FlashMessage để truyền message từ đây sang action hoặc controller khác
                this.MessageContainer().AddFlashMessage(res.Msg, ToastMessageType.Success);
            }
            else
            {
                //Truyền message trong nội bộ hàm
                this.MessageContainer().AddFlashMessage(res.Msg, ToastMessageType.Error);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            ResponseDataDTO<User> res = APICallHelper.Delete<ResponseDataDTO<User>>($"user/{id.Trim()}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (res.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                //FlashMessage để truyền message từ đây sang action hoặc controller khác
                this.MessageContainer().AddFlashMessage(res.Msg, ToastMessageType.Success);
            }
            else
            {
                //Truyền message trong nội bộ hàm
                this.MessageContainer().AddFlashMessage(res.Msg, ToastMessageType.Error);
            }
            return new JsonResult("ok");
        }
        
        //    public ActionResult Edit(int id)
        //    {
        //        List<string> cvList = new List<string>() { "Nhân Viên", "Quản trị viên" };
        //        Session["CVList"] = new SelectList(cvList);
        //        return View(_services.DbContext.QueryTable<TaiKhoanV2>("TaiKhoan").SingleOrDefault(x => x.MaTaiKhoan == id));
        //    }
        //    [HttpPost]
        //    public ActionResult Edit(TaiKhoanV2 model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var account = _services.DbContext.QueryTable<TaiKhoanV2>("TaiKhoan").SingleOrDefault(x => x.MaTaiKhoan == model.MaTaiKhoan);
        //            //Update
        //            var result = _services.DbContext.Exceute("exec SP_CapNhatTaiKhoan @matk, '@tendn', '@mk', N'@cv'",
        //                new
        //                {
        //                    matk = model.MaTaiKhoan,
        //                    tendn = model.TenDN,
        //                    mk = model.MatKhau,
        //                    cv = model.ChucVu
        //                });
        //            if (result == 0)
        //            {
        //                throw new Exception("Thao tác thất bại, vui lòng kiểm tra lại!");
        //            }
        //            return RedirectToAction("Index");
        //        }
        //        return View();
        //    }

        //    [HttpPost]
        //    public string Delete(int id)
        //    {
        //        try
        //        {
        //            var account = _services.DbContext.QueryTable<TaiKhoanV2>("TaiKhoan").SingleOrDefault(x => x.MaTaiKhoan == id);

        //            if (account == null)
        //            {
        //                return "Không tìm thấy tài khoản!";
        //            }
        //            var result = _services.DbContext.Exceute("" +
        //                "exec SP_XoaTaiKhoan @maTK",
        //                    new
        //                    {
        //                        matk = account.MaTaiKhoan,
        //                    }
        //            );
        //            return "ok";
        //        }
        //        catch (Exception ex)
        //        {
        //            return ex.Message;
        //        }

        //    }
    }
}

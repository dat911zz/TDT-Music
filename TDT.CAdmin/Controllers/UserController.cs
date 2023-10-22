using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using TDT.Core.DTO;
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
            if (users.Data != null)
            {
                int pageNumber = (page ?? 1);
                int pageSize = 10;

                IPagedList<UserDTO> pagedList = users.Data.ToPagedList(pageNumber, pageSize);

                return View(pagedList);

            }
            return View();
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
                ResponseDataDTO<UserIdentiyModel> response = APICallHelper.Put<ResponseDataDTO<UserIdentiyModel>>(
                    "Auth/Register",
                    JsonConvert.SerializeObject(user),
                    token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;

                if (response.Code == Core.Enums.APIStatusCode.Succeeded)
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
        public ActionResult Edit(string id)
        {
            ResponseDataDTO<User> userDetail = APICallHelper.Get<ResponseDataDTO<User>>($"user/{id.Trim()}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(userDetail.Data.FirstOrDefault());
        }
    //    [HttpPost]
    //    public ActionResult Create(TaiKhoanV2 model, FormCollection collection)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                if (_services.Db.TAIKHOANs.Any(x => x.TENDN.Equals(model.TenDN)))
    //                {
    //                    ModelState.AddModelError("", "Tên đăng nhập đã trùng!");
    //                }
    //                else
    //                {
    //                    if (!model.TenDN.Equals("sa"))
    //                    {
    //                        //_services.Db.TAIKHOANs.InsertOnSubmit(model);
    //                        //_services.Db.SubmitChanges();
    //                        string address = "";
    //                        address += collection["address"].ToString() + " ,";
    //                        address += collection["ward"].ToString() + " ,";
    //                        address += collection["district"].ToString() + " ,";
    //                        address += collection["province"].ToString() + ".";

    //                        var result = _services.DbContext.Exceute(string.Format("exec TaoTaiKhoanNhanVien N'{0}', '{1}', '{2}', N'{3}', '{4}', '{5}', '{6}', N'{7}'",
    //                                collection["hoten"].ToString(),
    //                                collection["ns"].ToString(),
    //                                collection["sdt"].ToString(),
    //                                address,
    //                                collection["email"].ToString(),
    //                                model.TenDN,
    //                                model.MatKhau,
    //                                model.ChucVu
    //                            ));
    //                        if (result == 0)
    //                        {
    //                            throw new Exception("Thao tác thất bại!");
    //                        }
    //                        return RedirectToAction("Index");
    //                    }
    //                    else
    //                    {
    //                        ModelState.AddModelError("TenDN", "Tên đăng nhập không hợp lệ!");
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                ModelState.AddModelError("", ex.Message);
    //            }
    //        }
    //        return View();
    //    }
    //    public ActionResult Details(int id)
    //    {
    //        IEnumerable<TaiKhoanV2> users = _services.DbContext.QueryTable<TaiKhoanV2>("TaiKhoan");
    //        ViewBag.NVList = _services.DbContext.QueryTable<NhanVien>("NhanVien");
    //        return View(users.SingleOrDefault(x => x.MaTaiKhoan == id));
    //    }
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

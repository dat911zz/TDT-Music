using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.DTO;
using TDT.Core.Extensions;
using TDT.Core.Ultils.MVCMessage;
using TDT.Core.Ultils;
using X.PagedList;

namespace TDT.CAdmin.Controllers
{
    public class GroupController : Controller
    {
        public readonly ILogger<GroupController> _logger;
        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;


        }
        // GET: Groups_Controller
        public ActionResult Index(string searchTerm, int? page)
        {
            ResponseDataDTO<GroupDTO> Groups = APICallHelper.Get<ResponseDataDTO<GroupDTO>>("Group", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            ViewBag.SearchTerm = "";
            int pageNumber = (page ?? 1);
            int pageSize = 6;

            // Lọc vai trò dựa trên từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                if (Groups.Data != null)
                {
                    Groups.Data = Groups.Data.Where(r => r.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                    ViewBag.SearchTerm = searchTerm;
                   
                }
                else return View();
            }

            IPagedList<GroupDTO> pagedList = Groups.Data == null ? new List<GroupDTO>().ToPagedList() : Groups.Data.OrderByDescending(o => o.CreateDate).ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
        // GET: Groups_Controller/Details/5
        public ActionResult Details(int id)
        {
            ResponseDataDTO<GroupDTO> GroupDetail = APICallHelper.Get<ResponseDataDTO<GroupDTO>>($"Group/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(GroupDetail.Data.FirstOrDefault());
        }

        // GET: Groups_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupDTO Group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Group.Name == "" || Group.Description == "")
                    {
                        this.MessageContainer().AddMessage("Vui lòng điền đẩy đủ thông tin!", ToastMessageType.Warning);
                        return View();
                    }
                    ResponseDataDTO<GroupDTO> GroupDetail = APICallHelper.Post<ResponseDataDTO<GroupDTO>>(
                       $"Group",
                       token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                       requestBody: JsonConvert.SerializeObject(Group)
                       ).Result;
                    if (GroupDetail.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        //FlashMessage để truyền message từ đây sang action hoặc controller khác
                        this.MessageContainer().AddFlashMessage("Tạo nhóm quyền thành công!", ToastMessageType.Success);
                    }
                    else
                    {
                        //Truyền message trong nội bộ hàm
                        this.MessageContainer().AddMessage(GroupDetail.Msg, ToastMessageType.Error);
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

        // GET: Groups_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            ResponseDataDTO<GroupDTO> GroupDetail = APICallHelper.Get<ResponseDataDTO<GroupDTO>>($"Group/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            return View(GroupDetail.Data.FirstOrDefault());
        }

        // POST: Groups_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GroupDTO Group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResponseDataDTO<GroupDTO> GroupDetail = APICallHelper.Put<ResponseDataDTO<GroupDTO>>(
                        $"Group/{id}",
                        token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value,
                        requestBody: JsonConvert.SerializeObject(Group)
                        ).Result;
                    if (GroupDetail.Code == Core.Enums.APIStatusCode.ActionSucceeded)
                    {
                        //FlashMessage để truyền message từ đây sang action hoặc controller khác
                        this.MessageContainer().AddFlashMessage("Sửa nhóm quyền thành công!", ToastMessageType.Success);
                    }
                    else
                    {
                        //Truyền message trong nội bộ hàm
                        this.MessageContainer().AddMessage(GroupDetail.Msg, ToastMessageType.Error);
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

        // POST: Groups_Controller/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ResponseDataDTO<GroupDTO> GroupDetail = APICallHelper.Delete<ResponseDataDTO<GroupDTO>>($"Group/{id}", token: HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("token")).Value).Result;
            if (GroupDetail.Code == Core.Enums.APIStatusCode.ActionSucceeded)
            {
                this.MessageContainer().AddFlashMessage("Xóa nhóm quền thành công!", ToastMessageType.Success);
            }
            else
            {
                this.MessageContainer().AddFlashMessage(GroupDetail.Msg, ToastMessageType.Error);
            }
            return new JsonResult("ok");
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Models;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private static readonly string CTR_NAME = "Tài khoản";
        private readonly ILogger<UserController> _logger;
        private readonly QLDVModelDataContext _db;
        public UserController(ILogger<UserController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IList<UserDTO> users = new List<UserDTO>();
            users = _db.Users.Select(s => new UserDTO
            {
                UserName = s.UserName,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email,
                PasswordHash = "",
                CreateDate = s.CreateDate,
                LockoutEnabled = s.LockoutEnabled,
                LockoutEnd = s.LockoutEnd,
                AccessFailedCount = s.AccessFailedCount,
                EmailConfirmed = s.EmailConfirmed,
                PhoneNumberConfirmed = s.PhoneNumberConfirmed,
                Id = s.Id
            }).ToList();
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", users}
                }, "Lấy dữ liệu");
        }

        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            IList<UserDTO> users = new List<UserDTO>();
            var user = GetUser(username);
            if(user != null)
            {
                users.Add(user);
            }
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
            {
                {"data", users }
            }, "Lấy dữ liệu");
        }

        [HttpPut("{username}")]
        public IActionResult Update(string username, [FromBody] UserDetailModel model)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
                if (user == null || string.IsNullOrEmpty(user.UserName))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "cập nhật " + CTR_NAME);
                }
                user.Email = model.Email;
                user.Address = model.Address;
                user.PhoneNumber = model.PhoneNumber;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    user.PasswordHash = SecurityHelper.HashPassword(model.Password);
                }
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "cập nhật " + CTR_NAME);
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            try
            {
                User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
                if (user == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "xóa " + CTR_NAME);
                }
                _db.Users.DeleteOnSubmit(user);
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa " + CTR_NAME);
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpGet("GetListeneds")]
        [AllowAnonymous]
        public JsonResult GetListeneds(string username)
        {
            var user = GetUser(username);
            if(user == null)
            {
                return APIHelper.GetJsonResult(APIStatusCode.InvalidAccount);
            }
            IList<ListenedDTO> listeneds = new List<ListenedDTO>();
            listeneds = _db.ListeningHistories.Where(l => l.UserId == user.Id).Select(l => new ListenedDTO
            {
                UserId = l.UserId,
                SongId = l.SongId,
                AccessDate = l.AccessDate
            }).ToList();
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", listeneds}
                }, "Lấy dữ liệu");
        }

        [HttpPost]
        public IActionResult InsertListened([FromBody] ListenedDTO model)
        {
            try
            {
                if (_db.ListeningHistories.Any(u => u.UserId.Equals(model.UserId) && u.SongId.Equals(model.SongId)))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.Exist);
                }
                _db.ListeningHistories.InsertOnSubmit(new ListeningHistory()
                {
                    UserId = model.UserId,
                    SongId = model.SongId,
                    AccessDate = model.AccessDate
                });
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "thêm lịch sử nghe nhạc");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpPut("UpdateListened")]
        public IActionResult UpdateListened(string username, [FromBody] ListenedDTO model)
        {
            try
            {
                var listened = _db.ListeningHistories.FirstOrDefault(l => l.UserId == model.UserId && l.SongId == model.SongId);
                if (listened == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ActionFailed, formatValue: "cập nhật lịch sử nghe nhạc");
                }
                listened.AccessDate = model.AccessDate;
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "cập nhật lịch sử nghe nhạc");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpDelete("DeleteListened")]
        public IActionResult DeleteListened(string username, string songId)
        {
            try
            {
                UserDTO user = GetUser(username);
                if (user == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.InvalidAccount);
                }
                var listened = _db.ListeningHistories.Where(l => l.UserId == user.Id && l.SongId == songId).FirstOrDefault();
                if (listened == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.NotExist);
                }
                _db.ListeningHistories.DeleteOnSubmit(listened);
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "xóa lịch sử nghe nhạc thành công");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpGet("GetPlaylistds")]
        [AllowAnonymous]
        public JsonResult GetPlaylists(string username)
        {
            var user = GetUser(username);
            if (user == null)
            {
                return APIHelper.GetJsonResult(APIStatusCode.InvalidAccount);
            }
            IList<UserPlaylistDTO> userPlaylists = new List<UserPlaylistDTO>();
            userPlaylists = _db.UserPlaylists.Where(up => up.UserId == user.Id).Select(up => new UserPlaylistDTO
            {
                UserId = up.UserId,
                PlaylistId = up.PlaylistId,
                CreateDate = up.CreateDate
            }).ToList();
            return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                {
                    {"data", userPlaylists}
                }, "Lấy dữ liệu");
        }

        private UserDTO GetUser(string username)
        {
            UserDTO user = _db.Users.Where(u => u.UserName.Equals(username.Trim())).Select(s => new UserDTO
            {
                UserName = s.UserName,
                Address = s.Address,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email,
                PasswordHash = "",
                CreateDate = s.CreateDate,
                LockoutEnabled = s.LockoutEnabled,
                LockoutEnd = s.LockoutEnd,
                AccessFailedCount = s.AccessFailedCount,
                EmailConfirmed = s.EmailConfirmed,
                PhoneNumberConfirmed = s.PhoneNumberConfirmed,
                Id = s.Id
            }).FirstOrDefault();
            return user;
        }
    }
}

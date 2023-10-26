using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TDT.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.Extensions.Logging;
using Azure.Core;
using System.Linq;
using TDT.Core.Enums;
using TDT.Core.Ultils;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TDT.IdentityCore.Utils;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.AspNetCore.Http;
using TDT.Core.DTO.Firestore;

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _cfg;
        private ISecurityHelper _securityHelper;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _mailSender;
        private readonly QLDVModelDataContext _db;

        public AuthController(
            IConfiguration cfg, 
            ISecurityHelper securityHelper,
            IEmailSender mailSender,
            ILogger<HomeController> logger, 
            QLDVModelDataContext db)
        {
            _cfg = cfg;
            _logger = logger;
            _db = db;
            _securityHelper = securityHelper;
            _mailSender = mailSender;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginModel login, bool isCAdmin = false)
        {
            try
            {
                IActionResult response = Unauthorized();
                User user = Authenticate(login);
                if (user != null)
                {
                    if (user.LockoutEnabled)
                    {
                        response = APIHelper.GetJsonResult(APIStatusCode.AccountLockout);
                    }
                    else
                    {
                        string token = isCAdmin ? _securityHelper.GenerateJWT(user) : _securityHelper.GenerateJWT(user, false);
                        response = APIHelper.GetJsonResult(APIStatusCode.AccessGranted, new Dictionary<string, object>()
                        {
                            {"token", token}
                        });
                        _logger.LogInformation("{0} connected", HttpContext.Connection.RemoteIpAddress);
                    }                  
                }
                else
                {
                    response = APIHelper.GetJsonResult(APIStatusCode.InvalidAccount);
                    _logger.LogInformation("{0} failed to connect", HttpContext.Connection.RemoteIpAddress);
                }
                return response;
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
            
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody] UserIdentiyModel model)
        {
            try
            {
                if (_db.Users.Any(u => u.UserName.Equals(model.UserName) || u.Email.Equals(model.Email)))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.ExistingAccount);
                }
                _db.Users.InsertOnSubmit(new User()
                {
                    UserName = model.UserName,
                    Address = model.Address,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    PasswordHash = SecurityHelper.HashPassword(model.Password)
                });
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.ActionSucceeded, formatValue: "tạo tài khoản");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        private User Authenticate(LoginModel login)
        {
            User user = null;
            //Find user
            user = _db.Users.FirstOrDefault(u =>
            u.UserName.Equals(login.UserName) || u.Email.Equals(login.UserName)
            );
            if (user != null)
            {
                if (!SecurityHelper.VerifyHashedPassword(user.PasswordHash, login.Password))
                {
                    user = null;
                }
            }
            return user;
        }

        [HttpPost]
        [Authorize]
        public IActionResult LockoutAccount(string username, [FromBody]DateTime lockoutEnd)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.NullParams);
                }
                if (!_db.Users.Any(u => u.UserName.Equals(username.Trim())))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.AccountNotFound);
                }
                var user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
                user.LockoutEnd = lockoutEnd;
                user.LockoutEnabled = true;
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.Succeeded, new Dictionary<string, object>()
                    {
                        {"data", lockoutEnd}
                    }, "Khóa tài khoản");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult UnlockAccount(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.NullParams);
                }
                if (!_db.Users.Any(u => u.UserName.Equals(username.Trim())))
                {
                    return APIHelper.GetJsonResult(APIStatusCode.AccountNotFound);
                }
                var user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username.Trim()));
                user.LockoutEnd = null;
                user.LockoutEnabled = false;
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.Succeeded, formatValue: "Mở khóa tài khoản");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ForgotPassword(string username)
        {
            try
            {
                string email = "";
                if (new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").IsMatch(username))
                {
                    email = username;
                }
                else
                {
                    User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(username));
                    if (user == null)
                    {
                        return APIHelper.GetJsonResult(APIStatusCode.AccountNotFound);
                    }
                    email = user.Email;
                }
                string token = _securityHelper.GeneratePasswordResetToken(username);
                string url = Url.Action("ResetPassword", "Auth", new { token, email = email }, Request.Scheme);

                if (!string.IsNullOrEmpty(email))
                {
                    _mailSender.SendEmailAsync(email, "Khôi phục tài khoản",
                        "<h1>Đường link khôi phục tài khoản:</h1>" +
                        "<a href='" + url + "'>Link</a>"
                        );
                }
                return APIHelper.GetJsonResult(APIStatusCode.Succeeded, formatValue: "Đã gửi mail khôi phục");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }
            
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ResetPassword(string email, string token, string newPassword)
        {
            try
            {   
                var user = _db.Users.FirstOrDefault(u => u.Email.Trim().Contains(email));
                if (user == null)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.InvalidEmail);
                }
                if (_securityHelper.ValidateToken(token).Count() == 0)
                {
                    return APIHelper.GetJsonResult(APIStatusCode.InvalidAuthenticationString);
                }
                
                user.PasswordHash = SecurityHelper.HashPassword(newPassword);
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(APIStatusCode.Succeeded, formatValue: "Đặt lại mật khẩu");
            }
            catch (Exception ex)
            {
                return APIHelper.GetJsonResult(APIStatusCode.RequestFailed, new Dictionary<string, object>()
                    {
                        {"exception", ex.Message}
                    });
            }           
        }
    }
}

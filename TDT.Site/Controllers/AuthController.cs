using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TDT.Core.DTO;
using TDT.Core.Enums;
using TDT.Core.Ultils;
using TDT.IdentityCore.Utils;
using Microsoft.AspNetCore.Identity.UI.Services;
using TDT.Core.Models;
using Google.Rpc;
using Newtonsoft.Json;
using TDT.Core.Extensions;
using TDT.Core.Ultils.MVCMessage;
using static Google.Rpc.Context.AttributeContext.Types;
using Microsoft.AspNetCore.Http;

namespace TDT_Music.Controllers
{
    public class AuthController : Controller
    {
		private readonly ILogger<AuthController> _logger;
		private readonly ISecurityHelper _securityHelper;
		private readonly IEmailSender _mailSender;

		public AuthController(ILogger<AuthController> logger, ISecurityHelper securityHelper, IEmailSender mailSender)
		{
			_logger = logger;
			_securityHelper = securityHelper;
			_mailSender = mailSender;
		}
		public IActionResult Index(string urlCallback, UserIdentiyModel? model, int mode = 0)
		{
			ViewBag.mode = mode;
			ViewBag.urlCallback = urlCallback;
			return View(model);
		}
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model, string urlCallback)
		{
			if (string.IsNullOrEmpty(urlCallback))
				urlCallback = "/Home/Index";
            if (ModelState.IsValid)
			{
				var auth = APICallHelper.Post<AuthDTO>("auth/login?isCadmin=false", new LoginModel()
				{
					UserName = model.UserName,
					Password = model.Password
				}.ToString()).Result;
				if (string.IsNullOrEmpty(auth.Token))
				{
					this.MessageContainer().AddFlashMessage(auth.Msg, ToastMessageType.Error);
					return Redirect(urlCallback);
				}
				var claims = _securityHelper.ValidateToken(auth.Token);
				var listAddClaim = claims.ToList();
				listAddClaim.Add(new Claim("token", auth.Token));
				claims = listAddClaim.AsEnumerable();
				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var testTime = long.Parse(claims.FirstOrDefault(x => x.Type == "exp").Value);
				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(identity));
				this.MessageContainer().AddFlashMessage("Chào mừng bạn đã trở lại!", ToastMessageType.Success);
                return Redirect(urlCallback);
            }
			this.MessageContainer().AddFlashMessage("Vui lòng điền đầy đủ thông tin!", ToastMessageType.Warning);
            return Redirect(urlCallback);
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
		public ActionResult Register(IFormCollection frm)
		{
            var user = new UserIdentiyModel
            {
                UserName = frm["username"],
                Email = frm["email"],
                Address = "",
                PhoneNumber = frm["phone"],
                Password = frm["password"]
            };
            if (ModelState.IsValid)
			{				
				ResponseDataDTO<UserIdentiyModel> response = APICallHelper.Post<ResponseDataDTO<UserIdentiyModel>>(
					"auth/register",
					JsonConvert.SerializeObject(user)
					).Result;

				if (response.Code == APIStatusCode.ActionSucceeded)
				{
					this.MessageContainer().AddFlashMessage("Tạo tài khoản thành công!", ToastMessageType.Success);
				}
				else
				{
					this.MessageContainer().AddFlashMessage(response.Msg, ToastMessageType.Error);
					return RedirectToAction("Index", user);
				}
				return RedirectToAction("Index");
			}
            this.MessageContainer().AddFlashMessage("Vui lòng điền đẩy đủ thông tin!", ToastMessageType.Warning);
			return RedirectToAction("Index", user);
		}
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public ActionResult ForgotPassword()
		{
			return View();
		}
		public IActionResult ResetPassword(string email, string token)
		{
			var claims = _securityHelper.ValidateToken(token);
			if (claims.Count() == 0)
			{
				return APIHelper.GetJsonResult(APIStatusCode.InvalidAuthenticationString);
			}
			return View();
		}
	}
}

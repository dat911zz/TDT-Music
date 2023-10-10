using Microsoft.AspNetCore.Mvc;

namespace TDT.CAdmin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}

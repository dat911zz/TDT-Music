using Microsoft.AspNetCore.Mvc;

namespace TDT_Music.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
